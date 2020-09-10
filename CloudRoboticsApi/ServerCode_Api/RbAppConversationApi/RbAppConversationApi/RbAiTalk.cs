using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Net.Http;
using System.Web;
using System.Collections.Generic;
using CloudRoboticsUtil;
using System.IO;

namespace RbAppConversationApi
{
    public class RbAiTalk : MarshalByRefObject, IAppRouterDll
    {
        private readonly string intentNone = "None";
        private readonly string intentTalkRinna = "talkRinna";
        private readonly string intentFinishTalk = "finishTalk";
        private readonly string typeInit = "init";
        private readonly string typeFinish = "finish";
        private readonly string typeFinishTalk = "finishTalk";
        private readonly string typeTalkRinna = "talkRinna";
        private readonly string typeDanceApp1 = "danceApp1";
        private readonly string stateBegin = "begin";
        private readonly string stateProcessing = "processing";
        private readonly string stateEnd = "end";
        private string sqlConnString = string.Empty;
        private string rinnaApiEndpoint = string.Empty;
        private string rinnaKey = string.Empty;
        private string rinnaId = string.Empty;
        private string luisApiEndpoint = string.Empty;
        private string luisPgmApiEndpoint = string.Empty;
        private string luisKey = string.Empty;
        private string luisAppId = string.Empty;

        public JArrayString ProcessMessage(RbAppMasterCache rbappmc, RbAppRouterCache rbapprc, RbHeader rbh, string rbBodyString)
        {
            // RbAppLog
            var appName = Path.GetFileNameWithoutExtension(this.GetType().Assembly.Location);
            string storageConnectionString = string.Format("DefaultEndpointsProtocol=https;AccountName={0};AccountKey={1}",
                        rbappmc.StorageAccount, rbappmc.StorageKey);
            RbAppLog RbAppLog = new RbAppLog();
            RbAppLog.Initialize(storageConnectionString, "RbAppLog", appName);

            // Request Message
            var requestBody = new ReqBody();
            var jo_reqBody = (JObject)JsonConvert.DeserializeObject(rbBodyString);

            requestBody.visitor = (string)jo_reqBody["visitor"];
            requestBody.visitor_id = (string)jo_reqBody["visitor_id"];

            // Response Message
            JArray jArrayMessages = new JArray();

            // rbh.MessageId == "finish"
            if (rbh.MessageId == typeFinish)
            {
                var resBody = new ResBody();
                resBody.visitor = requestBody.visitor;
                resBody.visitor_id = requestBody.visitor_id;
                resBody.type = typeFinish;

                return BuildMessages(jArrayMessages, rbh, resBody);
            }

            // rbh.MessageId == "init" or "talkXxxx"
            requestBody.talkByMe = (string)jo_reqBody["talkByMe"];

            // AppMaster
            JObject jo_appInfo = (JObject)JsonConvert.DeserializeObject(rbappmc.AppInfo);
            sqlConnString = (string)jo_appInfo["SqlConnString"];
            try
            {
                rinnaApiEndpoint = (string)jo_appInfo["RinnaApiEndpoint"];
                rinnaKey = (string)jo_appInfo["RinnaKey"];
                rinnaId = (string)jo_appInfo["RinnaId"];
            }
            catch
            {
                rinnaApiEndpoint = string.Empty;
                rinnaKey = string.Empty;
                rinnaId = string.Empty;
            }
            luisApiEndpoint = (string)jo_appInfo["LuisApiEndpoint"];
            luisPgmApiEndpoint = (string)jo_appInfo["LuisPgmApiEndpoint"];
            luisKey = (string)jo_appInfo["LuisKey"];
            luisAppId = (string)jo_appInfo["LuisAppId"];

            // Edit Response Message
            var responseBody = new ResBodyTalk();
            responseBody.visitor = requestBody.visitor;
            responseBody.visitor_id = requestBody.visitor_id;
            responseBody.talkByAi = new List<TalkMessage>();

            IntentState intentState = new IntentState();
            string intent = string.Empty;

            // Call LUIS API
            if (rbh.MessageId == typeInit)
            {
                try
                {
                    intentState = GetIntent(requestBody.talkByMe);
                }
                catch(Exception ex)
                {
                    ResBodyWhenError resBodyWhenError = new ResBodyWhenError();
                    resBodyWhenError.success = "false";
                    resBodyWhenError.error_message = ex.Message;
                    RbAppLog.WriteError("E001", ex.ToString());

                    return BuildMessages(jArrayMessages, rbh, resBodyWhenError);
                }
                intentState.processState = stateBegin;
                intent = (string)intentState.topScoringIntent["intent"];

                // set Conversation State
                ConversationState convState = new ConversationState(sqlConnString, rbh.SourceDeviceId, rbh.AppId);
                string conversationStateString = JsonConvert.SerializeObject(intentState);
                ApiResult apiResult = convState.SetState(conversationStateString);
                if (!apiResult.IsSuccessStatusCode)
                {
                    ResBodyWhenError resBodyWhenError = new ResBodyWhenError();
                    resBodyWhenError.success = "false";
                    resBodyWhenError.error_message = "** Error ** Conversation State Save failed !! : " + apiResult.Message;
                    RbAppLog.WriteError("E002", apiResult.Message);

                    return BuildMessages(jArrayMessages, rbh, resBodyWhenError);
                }
            }
            else
            {
                // get Conversation State
                ConversationState convState = new ConversationState(sqlConnString, rbh.SourceDeviceId, rbh.AppId);
                AppResult appResult = convState.GetState();
                if (appResult.apiResult.IsSuccessStatusCode)
                {
                    var joIntentState = (JObject)JsonConvert.DeserializeObject(appResult.conversationStateString);
                    intentState.processState = (string)joIntentState["processState"];
                    intentState.query = (string)joIntentState["query"];
                    intentState.topScoringIntent = (JObject)joIntentState["topScoringIntent"];
                    try
                    {
                        intentState.actionList = (JArray)joIntentState["actionList"];
                    }
                    catch
                    {
                        intentState.actionList = null;
                    }
                }
                else
                {
                    ResBodyWhenError resBodyWhenError = new ResBodyWhenError();
                    resBodyWhenError.success = "false";
                    resBodyWhenError.error_message = "** Error ** Conversation State Get failed !! : " + appResult.apiResult.Message;
                    RbAppLog.WriteError("E003", appResult.apiResult.Message);

                    return BuildMessages(jArrayMessages, rbh, resBodyWhenError);
                }
            }

            // Continue talk session
            bool boolFinishTalk = false;
            if (rbh.MessageId.Substring(0,4) == "talk")
            {
                intent = rbh.MessageId;
                // Check intent of finishing talk
                boolFinishTalk = CheckIntentOfFinishTalk(requestBody.talkByMe);
            }
            // Finish Talk
            if (boolFinishTalk)
            {
                responseBody.visitor = requestBody.visitor;
                responseBody.visitor_id = requestBody.visitor_id;
                responseBody.type = typeFinishTalk;

                var talkMessage = new TalkMessage();
                talkMessage.SayText = "会話を終了します。再度、ご用件をお話しください。";
                responseBody.talkByAi.Add(talkMessage);

                return BuildMessages(jArrayMessages, rbh, responseBody);
            }

            // Call Rinna API
            if (intent == intentTalkRinna || intent == intentNone)
            {
                if (rinnaApiEndpoint != string.Empty)
                {
                    ApiResult apiResult = TalkRinna(rinnaKey, rinnaId, requestBody.talkByMe);
                    if (apiResult.IsSuccessStatusCode)
                    {
                        responseBody.success = "true";
                        responseBody.type = typeTalkRinna;

                        JObject jo_result = (JObject)JsonConvert.DeserializeObject(apiResult.Result);
                        var ja_responses = (JArray)jo_result["Responses"];
                        foreach (var jo_content in ja_responses)
                        {
                            var talkMessage = new TalkMessage();
                            string text = (string)jo_content["Content"]["Text"];
                            // Replace Emoji
                            talkMessage.SayText = ReplaceTalkMessage(text);
                            responseBody.talkByAi.Add(talkMessage);
                        }
                    }
                    else
                    {
                        ResBodyWhenError resBodyWhenError = new ResBodyWhenError();
                        resBodyWhenError.success = "false";
                        resBodyWhenError.error_message = "** Error ** Rinna API failed !! : " + apiResult.Message;
                        RbAppLog.WriteError("E004", apiResult.Message);

                        return BuildMessages(jArrayMessages, rbh, resBodyWhenError);
                    }
                }
                else
                {
                    responseBody.success = "true";
                    responseBody.type = typeFinishTalk;
                    var talkMessage = new TalkMessage();
                    talkMessage.SayText = ReplaceTalkMessage("上手く聞き取ることが出来ませんでした。再度、ご用件をお話しください。");
                    responseBody.talkByAi.Add(talkMessage);
                }
            }
            // Various Talk Service defined by LUIS web service
            else if (intent.Length >= 4 && intent.Substring(0, 4) == "talk")
            {
                var talkMessage = new TalkMessage();

                string sayText = string.Empty;
                if (intentState.processState == stateBegin)
                    sayText = GetNextTalkMessage(ref intentState);
                else
                    sayText = GetNextTalkMessageWithUpdate(ref intentState, requestBody.talkByMe);

                if (sayText == string.Empty)
                {
                    responseBody.type = typeFinishTalk;
                    sayText = CompleteTalkMessage(ref intentState);
                }
                else
                {
                    responseBody.type = intent;
                }
                responseBody.success = "true";
                talkMessage.SayText = sayText;
                responseBody.talkByAi.Add(talkMessage);

                // set Conversation State
                ConversationState convState = new ConversationState(sqlConnString, rbh.SourceDeviceId, rbh.AppId);
                string conversationStateString = JsonConvert.SerializeObject(intentState);
                ApiResult apiResult = convState.SetState(conversationStateString);

                if (!apiResult.IsSuccessStatusCode)
                {
                    ResBodyWhenError resBodyWhenError = new ResBodyWhenError();
                    resBodyWhenError.success = "false";
                    resBodyWhenError.error_message = "** Error ** Conversation State Save(2) failed !! : " + apiResult.Message;
                    RbAppLog.WriteError("E005", apiResult.Message);

                    return BuildMessages(jArrayMessages, rbh, resBodyWhenError);
                }
            }
            else
            {
                responseBody.success = "true";
                responseBody.type = intent;
            }

            return BuildMessages(jArrayMessages, rbh, responseBody);
        }

        private string CompleteTalkMessage(ref IntentState intentState)
        {
            string intent = (string)intentState.topScoringIntent["intent"];
            JArray ja = intentState.actionList;
            string sayText = string.Empty;

            if (ja.Count > 0)
            {
                foreach (JObject jo in ja)
                {
                    JArray jaValue = (JArray)jo["value"];
                    string entity = (string)jaValue[0]["entity"]; 
                    sayText += jo["name"] + "は、" + entity + "、";
                }
                sayText = sayText.Substring(0, sayText.Length - 1);
                sayText += "ですね。";
            }

            if (intent.IndexOf("talkBook") >= 0)
            {
                sayText += "こちらで予約をお取りし、後ほどご連絡を致します。ありがとうございました！";
            }
            else
            {
                sayText += "この情報で確認致しまして、後ほどご連絡を致します。ありがとうございました！";
            }

            intentState.processState = stateEnd;
            return sayText;
        }

        private string GetNextTalkMessage(ref IntentState intentState)
        {
            JArray ja = intentState.actionList;
            string prompt = string.Empty;

            for (int i = 0; i < ja.Count; i++)
            {
                try
                {
                    JArray value = (JArray)ja[i]["value"];
                }
                catch
                {
                    prompt = (string)ja[i]["prompt"];
                    break;
                }
            }

            intentState.processState = stateProcessing;
            return prompt;
        }

        private string GetNextTalkMessageWithUpdate(ref IntentState intentState, string message)
        {
            JArray ja = intentState.actionList;
            string prompt = string.Empty;
            bool loopend = false;

            for (int i = 0; i < ja.Count; i++)
            {
                try
                {
                    JArray value = (JArray)ja[i]["value"];
                }
                catch
                {
                    if (loopend)
                    {
                        prompt = (string)ja[i]["prompt"];
                        break;
                    }
                    var messages = new List<ValueEntity> { new ValueEntity { entity = message }, };
                    var messagesText = JsonConvert.SerializeObject(messages);
                    ja[i]["value"] = JsonConvert.DeserializeObject<JArray>(messagesText);
                    loopend = true;
                }
            }

            intentState.actionList = ja;
            intentState.processState = stateProcessing;
            return prompt;
        }

        private class ValueEntity
        {
            public string entity { set; get; }
        }

        private JArrayString BuildMessages(JArray jArrayMessages, RbHeader rbh, object rbBody)
        {
            RbMessage rbMessage = new RbMessage();
            rbMessage.RbHeader = rbh;
            rbMessage.RbBody = rbBody;

            var jsonRbMessage = JsonConvert.SerializeObject(rbMessage);
            var joRbMessage = (JObject)JsonConvert.DeserializeObject(jsonRbMessage);
            jArrayMessages.Add(joRbMessage);
            JArrayString jArrayString = new JArrayString(jArrayMessages);

            return jArrayString;
        }

        private string ReplaceTalkMessage(string message)
        {
            // Edit sayText
            message = message.Replace("w", "");
            message = message.Replace("爆笑", "");
            message = message.Replace("(笑)", "");
            message = message.Replace("（笑）", "");
            message = message.Replace("(笑", "");
            message = message.Replace("（笑", "");
            message = message.Replace("～", "ー");
            message = message.Replace("~", "ー");
            message = message.Replace("^", "");
            message = message.ToUpper().Replace("LINE", "ライン");
            message = message.ToUpper().Replace("FACEBOOK", "フェイスブック");
            message = message.ToUpper().Replace("TWITTER", "ツイッター");
            string last_char = message.Substring(message.Length - 1, 1);
            switch (last_char)
            {
                case "笑":
                    message = message.Substring(0, message.Length - 1);
                    break;
                default:
                    break;
            }

            if (message == string.Empty || message.Length <= 0)
                message = "うーん、どうかな？";

            return message;
        }

        private bool CheckIntentOfFinishTalk(string message)
        {
            bool boolFinishTalk = false;

            if (message.IndexOf("会話") >= 0)
            {
                if (message.IndexOf("終") >= 0)
                {
                    boolFinishTalk = true;
                }
            }
            else if (message.IndexOf("ばいばい") >= 0)
            {
                boolFinishTalk = true;
            }
            else if (message.IndexOf("バイバイ") >= 0)
            {
                boolFinishTalk = true;
            }
            else if (message.IndexOf("さよなら") >= 0)
            {
                boolFinishTalk = true;
            }
            else if (message.IndexOf("さようなら") >= 0)
            {
                boolFinishTalk = true;
            }
            else if (message.IndexOf("帰るね") >= 0)
            {
                boolFinishTalk = true;
            }
            else if (message.IndexOf("帰るよ") >= 0)
            {
                boolFinishTalk = true;
            }

            return boolFinishTalk;
        }

        private IntentState GetIntent(string message)
        {
            IntentState intentState = new IntentState();
            string intent = string.Empty;

            ApiResult apiResult = CallLuisApi(message);
            if (message == string.Empty)
                return null;

            if (apiResult.IsSuccessStatusCode)
            {
                JObject jo_result = (JObject)JsonConvert.DeserializeObject(apiResult.Result);
                intentState.query = (string)jo_result["query"];
                intentState.topScoringIntent = (JObject)jo_result["topScoringIntent"];
                intent = (string)intentState.topScoringIntent["intent"];

                var actions = (JArray)intentState.topScoringIntent["actions"];
                if (actions != null && actions.Count > 0)
                {
                    var parameters = (JArray)actions[0]["parameters"];
                    if (parameters.Count > 0)
                    {
                        ApiResult apiResult2 = GetActionsThruPgmApi();
                        if (apiResult2.IsSuccessStatusCode)
                        {
                            JArray jaActions = (JArray)JsonConvert.DeserializeObject(apiResult2.Result);

                            for(int i = 0; i < parameters.Count; i++)
                            {
                                var jo = (JObject)parameters[i];
                                var type = (string)jo["type"];
                                var prompt = GetActionPrompt(jaActions, intent, type);
                                jo["prompt"] = prompt;
                                parameters[i] = jo;
                            }

                            intentState.actionList = parameters;
                        }
                        else
                        {
                            ApplicationException ae = new ApplicationException("** Error ** LUIS Programing API failed !! : " + apiResult2.Message);
                            throw ae;
                        }
                    }
                }
            }
            else
            {
                ApplicationException ae = new ApplicationException("** Error ** LUIS API failed !! : " + apiResult.Message);
                throw ae;
            }

            return intentState;
        }

        private string GetActionPrompt(JArray ja_actions, string intent, string type)
        {
            string result = string.Empty;
            int position = 0;

            for (int i = 0; i < ja_actions.Count; i++)
            {
                var intentName = (string)ja_actions[i]["IntentName"];
                if (intent == intentName)
                {
                    position = i;
                    break;
                }
            }

            JArray ja_params = (JArray)ja_actions[position]["ActionParameters"];
            if (ja_params != null && ja_params.Count > 0)
            {
                foreach (var jo in ja_params)
                {
                    var entityName = (string)jo["EntityName"];
                    if (entityName == type)
                    {
                        result = (string)jo["Question"];
                    }
                }
            }

            return result;
        }

        private ApiResult GetActionsThruPgmApi()
        {
            // HTTP Client
            var client = new HttpClient();

            // Request headers
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", luisKey);
            var uri = $"{luisPgmApiEndpoint}{luisAppId}/actions";

            // Call REST API
            var response = client.GetAsync(uri);
            response.Wait();

            ApiResult apiResult = new ApiResult();
            apiResult.IsSuccessStatusCode = response.Result.IsSuccessStatusCode;
            if (apiResult.IsSuccessStatusCode)
            {
                var resdata = response.Result.Content.ReadAsStringAsync();
                resdata.Wait();
                apiResult.Result = resdata.Result.ToString();
            }
            else
            {
                apiResult.Message = response.Result.ToString();
            }

            return apiResult;
        }

        private ApiResult CallLuisApi(string talk)
        {
            // HTTP Client
            var client = new HttpClient();
            var queryString = HttpUtility.ParseQueryString(talk);

            // Request headers
            var uri = $"{luisApiEndpoint}{luisAppId}?subscription-key={luisKey}&q={talk}&verbose=true";

            // Call REST API
            var response = client.GetAsync(uri);
            response.Wait();

            ApiResult apiResult = new ApiResult();
            apiResult.IsSuccessStatusCode = response.Result.IsSuccessStatusCode;
            if (apiResult.IsSuccessStatusCode)
            {
                var resdata = response.Result.Content.ReadAsStringAsync();
                resdata.Wait();
                apiResult.Result = resdata.Result.ToString();
            }
            else
            {
                apiResult.Message = response.Result.ToString();
            }

            return apiResult;
        }

        private ApiResult TalkRinna(string rinnaSubscriptionKey, string rinnaSubscriptionId, string talkByMe)
        {
            // HTTP Client
            var client = new HttpClient();
            var queryString = HttpUtility.ParseQueryString(string.Empty);

            // Request headers
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", rinnaSubscriptionKey);

            var uri = $"{rinnaApiEndpoint}";

            // Request body
            string text = "{\"SubscriptionId\": \"" + rinnaSubscriptionId + "\", \"Content\": {\"Text\":\"" + talkByMe + "\"}, \"NeedsCleanText\": \"true\"}";
            byte[] byteData = Encoding.UTF8.GetBytes(text);

            // Call REST API
            var content = new ByteArrayContent(byteData);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = client.PostAsync(uri, content);
            response.Wait();

            ApiResult apiResult = new ApiResult();
            apiResult.IsSuccessStatusCode = response.Result.IsSuccessStatusCode;
            if (apiResult.IsSuccessStatusCode)
            {
                var resdata = response.Result.Content.ReadAsStringAsync();
                resdata.Wait();
                apiResult.Result = resdata.Result.ToString();
            }
            else
            {
                apiResult.Message = response.Result.ToString();
            }

            return apiResult;
        }

    }

}
