using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Net.Http;
using System.Xml;
using System.Collections.Generic;
using CloudRoboticsUtil;
using System.IO;
using System.Net;

namespace RbAppTranslatorApi
{
    public class RbTranslator : MarshalByRefObject, IAppRouterDll
    {
        private string languageCode = "en"; //set english as the default
        private string[] friendlyName = { " " }; //Array for passing languages codes to get friendly name
        private List<string> speakLanguages; //List of langauges for speech
        private string headerValue; //used for auth in http header
        private Dictionary<string, string> languageCodesAndTitles = new Dictionary<string, string>();

        public JArrayString ProcessMessage(RbAppMasterCache rbappmc, RbAppRouterCache rbapprc, RbHeader rbh, string rbBodyString)
        {
            string translatorAccountKey = string.Empty;

            // RbAppLog
            var appName = Path.GetFileNameWithoutExtension(this.GetType().Assembly.Location);
            string storageConnectionString = string.Format("DefaultEndpointsProtocol=https;AccountName={0};AccountKey={1}",
                        rbappmc.StorageAccount, rbappmc.StorageKey);
            RbAppLog RbAppLog = new RbAppLog();
            RbAppLog.Initialize(storageConnectionString, "RbAppLog", appName);

            // Request Message
            var requestBody = new ReqBody();
            var jo_reqBody = (JObject)JsonConvert.DeserializeObject(rbBodyString);
            try
            {
                requestBody.visitor = (string)jo_reqBody["visitor"];
                requestBody.visitor_id = (string)jo_reqBody["visitor_id"];
            }
            catch
            {
                requestBody.visitor = string.Empty;
                requestBody.visitor_id = string.Empty;
            }
            requestBody.text = (string)jo_reqBody["text"];
            requestBody.tolang = (string)jo_reqBody["tolang"];

            // Response Message
            JArray ja_messages = new JArray();
            RbMessage message = new RbMessage();
            string json_message = string.Empty;
            var responseBody = new ResBody();
            responseBody.translated_text = string.Empty;
            var responseBodyWhenError = new ResBodyWhenError();

            if (requestBody.tolang == null || requestBody.tolang == string.Empty)  //in case no language is selected.
            {
                requestBody.tolang = languageCode;
            }

            // Set cognitive service account key
            JObject jo_appInfo = (JObject)JsonConvert.DeserializeObject(rbappmc.AppInfo);
            var p1 = jo_appInfo["TranslatorApiKey"];
            if (p1 != null)
                if ((string)p1 != "")
                    translatorAccountKey = (string)p1;

            if (translatorAccountKey == string.Empty)
            {
                // Send Error to device
                responseBodyWhenError.error_message = "[TranslatorApiKey] not found in RBFX.AppMaster !!";
                responseBodyWhenError.success = "false";
                RbAppLog.WriteError("E001", responseBodyWhenError.error_message);

                message.RbHeader = rbh;
                message.RbBody = responseBodyWhenError;
                json_message = JsonConvert.SerializeObject(message);
                JObject jo1 = (JObject)JsonConvert.DeserializeObject(json_message);
                ja_messages.Add(jo1);

                return new JArrayString(ja_messages);
            }

            ApiResult apiResult = TranslateText(requestBody.text, translatorAccountKey, requestBody.tolang);

            // Respond to device
            message = new RbMessage();
            message.RbHeader = rbh;
            if (apiResult.IsSuccessStatusCode)
            {
                responseBody.success = "true";
                responseBody.visitor = requestBody.visitor;
                responseBody.visitor_id = requestBody.visitor_id;
                responseBody.translated_text = apiResult.Result;
                message.RbBody = responseBody;
            }
            else
            {
                responseBodyWhenError.success = "false";
                responseBodyWhenError.error_message = apiResult.Message;
                message.RbBody = responseBodyWhenError;
                RbAppLog.WriteError("E002", apiResult.Message);
            }

            json_message = JsonConvert.SerializeObject(message);
            JObject jo = (JObject)JsonConvert.DeserializeObject(json_message);
            ja_messages.Add(jo);
            JArrayString jaString = new JArrayString(ja_messages);

            return jaString;
        }

        private ApiResult TranslateText(string text, string translatorAccountKey, string tolang = "en")
        {
            ApiResult apiResult = new ApiResult();

            //---------------------------------------------------------------------------------------
            // Get a token
            //---------------------------------------------------------------------------------------
            // define http client
            var client = new HttpClient();
            // Set request headers
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", translatorAccountKey);
            // Set uri
            var issueTokenUrl = "https://api.cognitive.microsoft.com/sts/v1.0/issueToken";

            // Call REST API
            JObject jo_reqest = new JObject();
            byte[] byteData = Encoding.UTF8.GetBytes((string)JsonConvert.SerializeObject(jo_reqest));
            var content = new ByteArrayContent(byteData);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var tokenResponse = client.PostAsync(issueTokenUrl, content);
            tokenResponse.Wait();

            //GetLanguagesForTranslate(); //List of languages that can be translated
            //GetLanguageNamesMethod(headerValue, friendlyName); //Friendly name of languages that can be translated

            //
            // If success, trying to translate the contents
            //
            if (tokenResponse.Result.IsSuccessStatusCode)
            {
                // Read a token
                var responseData = tokenResponse.Result.Content.ReadAsStringAsync();
                responseData.Wait();
                string token = responseData.Result.ToString();

                //---------------------------------------------------------------------------------------
                // Call Translator API
                //---------------------------------------------------------------------------------------

                // Prepare request body
                // FIXME: It seems to be useless. variables can be assigned directly.
                string escapeText = Uri.EscapeDataString(text);
                string translateUrl = "https://api.microsofttranslator.com/v2/http.svc/Translate";

                // request
                var request = new HttpRequestMessage();
                request.Method = HttpMethod.Get;
                //string dnn = "generalnn";
                //request.RequestUri = new Uri(translateUrl + $"?category={dnn}&text={escapeText}&to={tolang}");
                request.RequestUri = new Uri(translateUrl + $"?text={escapeText}&to={tolang}");
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var translationResponse = client.SendAsync(request);

                if (translationResponse.Result.IsSuccessStatusCode)
                {
                    // If translation was succeeded
                    var translationContent = translationResponse.Result.Content.ReadAsStringAsync();
                    translationContent.Wait();

                    // TODO: Parse error
                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml(translationContent.Result.ToString());
                    string translated_text = doc.InnerText;
                    apiResult.Result = translated_text;
                    apiResult.IsSuccessStatusCode = true;
                }
                else
                {
                    // If translation failed
                    apiResult.Message = "Error occured in translation process !! : " + translationResponse.Result.ToString();
                    apiResult.IsSuccessStatusCode = false;
                }
            }
            else
            {
                // If obtaining token failed
                apiResult.Message = "Error occured in authentication process !! : " + tokenResponse.Result.ToString();
                apiResult.IsSuccessStatusCode = false;
            }

            return apiResult;
        }

        private void GetLanguagesForTranslate()
        {

            string uri = "https://api.microsofttranslator.com/v2/http.svc/GetLanguagesForTranslate";
            WebRequest WebRequest = WebRequest.Create(uri);
            WebRequest.Headers.Add("Authorization", headerValue);

            WebResponse response = null;

            try
            {
                response = WebRequest.GetResponse();
                using (Stream stream = response.GetResponseStream())
                {

                    System.Runtime.Serialization.DataContractSerializer dcs = new System.Runtime.Serialization.DataContractSerializer(typeof(List<string>));
                    List<string> languagesForTranslate = (List<string>)dcs.ReadObject(stream);
                    friendlyName = languagesForTranslate.ToArray(); //put the list of language codes into an array to pass to the method to get the friendly name.

                }
            }
            catch
            {
                throw;
            }
            finally
            {
                if (response != null)
                {
                    response.Close();
                    response = null;
                }
            }
        }

        //*****CODE TO GET TRANSLATABLE LANGAUGE FRIENDLY NAMES FROM THE TWO CHARACTER CODES*****
        private void GetLanguageNamesMethod(string authToken, string[] languageCodes)
        {
            string uri = "https://api.microsofttranslator.com/v2/http.svc/GetLanguageNames?locale=en";
            // create the request
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.Headers.Add("Authorization", headerValue);
            request.ContentType = "text/xml";
            request.Method = "POST";
            System.Runtime.Serialization.DataContractSerializer dcs = new System.Runtime.Serialization.DataContractSerializer(Type.GetType("System.String[]"));
            using (System.IO.Stream stream = request.GetRequestStream())
            {
                dcs.WriteObject(stream, languageCodes);
            }
            WebResponse response = null;
            try
            {
                response = request.GetResponse();

                using (Stream stream = response.GetResponseStream())
                {
                    string[] languageNames = (string[])dcs.ReadObject(stream);

                    for (int i = 0; i < languageNames.Length; i++)
                    {

                        languageCodesAndTitles.Add(languageNames[i], languageCodes[i]); //load the dictionary for the combo box

                    }
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                if (response != null)
                {
                    response.Close();
                    response = null;
                }
            }
        }

    }

}
