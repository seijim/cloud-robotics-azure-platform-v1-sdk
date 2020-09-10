using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Net.Http;
using CloudRoboticsUtil;
using System.IO;
using System.Xml;
using System.Collections.Generic;

namespace RbAppVisionApi
{
    public class RbVisionInfo : MarshalByRefObject, IAppRouterDll
    {
        public JArrayString ProcessMessage(RbAppMasterCache rbappmc, RbAppRouterCache rbapprc, RbHeader rbh, string rbBodyString)
        {

            // Prepare variables for storage account.
            string storageAccount = string.Empty;
            string storageKey = string.Empty;
            string storageContainer = string.Empty;
            string translatorAccountKey = string.Empty;
            string languageCode = "en"; //set english as the default
            string visionApiKey = string.Empty;
            string visionApiEndpoint = string.Empty;
            string facesOption = string.Empty;

            JArray ja_messages = new JArray();
            RbMessage message = new RbMessage();

            // RbAppLog
            var appName = Path.GetFileNameWithoutExtension(this.GetType().Assembly.Location);
            string storageConnectionString = string.Format("DefaultEndpointsProtocol=https;AccountName={0};AccountKey={1}",
                        rbappmc.StorageAccount, rbappmc.StorageKey);
            RbAppLog RbAppLog = new RbAppLog();
            RbAppLog.Initialize(storageConnectionString, "RbAppLog", appName);

            // Set cognitive service account key
            JObject jo_appInfo = (JObject)JsonConvert.DeserializeObject(rbappmc.AppInfo);
            JObject jo_input = (JObject)JsonConvert.DeserializeObject(rbBodyString);

            var p1 = jo_appInfo["StorageAccount"];
            if (p1 != null)
                storageAccount = (string)p1;
            var p2 = jo_appInfo["StorageKey"];
            if (p2 != null)
                storageKey = (string)p2;
            var p3 = jo_appInfo["VisionStorageContainer"];
            if (p3 != null)
                storageContainer = (string)p3;
            var p4 = jo_appInfo["VisionTranslatorToLang"];
            if (p4 != null)
                languageCode = (string)p4;
            var p5 = jo_appInfo["VisionTranslatorApiKey"];
            if (p5 != null)
                translatorAccountKey = (string)p5;
            var p6 = jo_appInfo["VisionApiEndpoint"];
            if (p6 != null)
                visionApiEndpoint = (string)p6;
            var p7 = jo_appInfo["VisionApiKey"];
            if (p7 != null)
                visionApiKey = (string)p7;

            if (rbh.MessageId == "init")
            {
                InitBody initBody = new InitBody();
                initBody.storageAccount = storageAccount;
                initBody.storageContainer = storageContainer;
                initBody.storageKey = storageKey;
                message.RbBody = initBody;

            }
            else if (rbh.MessageId == "analyze")
            {
                // Prepare response body
                AnalyzeBody analyzeBody = new AnalyzeBody();
                if ((string)jo_input["visitor"] != null)
                    if ((string)jo_input["visitor"] != "")
                        analyzeBody.visitor = (string)jo_input["visitor"];

                if ((string)jo_input["visitor_id"] != null)
                    if ((string)jo_input["visitor_id"] != "")
                        analyzeBody.visitor = (string)jo_input["visitor_id"];

                // Set http client
                var client = new HttpClient();
                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", visionApiKey);
                var visionDescribeUrl = $"{visionApiEndpoint}/analyze?visualFeatures=Tags,Description,Faces,Adult";


                try
                {
                // Prepare target file data
                    BlobData blobData = new BlobData(storageAccount, storageKey, storageContainer);
                    string fileName = (string)jo_input["blobFileName"];
                    byte[] buffer = blobData.GetStream(fileName);
                    var content = new ByteArrayContent(buffer);
                    content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");

                    // Get result which describe the image.
                    DateTime dt1 = DateTime.Now;
                    var visionDescribeResult = client.PostAsync(visionDescribeUrl, content);
                    visionDescribeResult.Wait();
                    DateTime dt2 = DateTime.Now;
                    TimeSpan ts = dt2 - dt1;


                    if (visionDescribeResult.Result.IsSuccessStatusCode)
                    {
                        // If success, convert to the response body form and translate messages.
                        analyzeBody.success = "true";
                        var responseBody = visionDescribeResult.Result.Content.ReadAsStringAsync();
                        var resultBody = JObject.Parse(responseBody.Result.ToString());

                        // combine text and tags to make one sentence
                        string descriptionText = (string)resultBody["description"]["captions"][0]["text"];
                        string baseTextTags = joinTags((JArray)resultBody["tags"]);

                        // translate text.
                        DateTime dt3 = DateTime.Now;
                        string translatedDescription = translateText(descriptionText, translatorAccountKey, languageCode);
                        string translatedTags = translateText(baseTextTags, translatorAccountKey, languageCode);
                        DateTime dt4 = DateTime.Now;
                        TimeSpan ts2 = dt4 - dt3;

                        // reform the translated result.
                        var resultTextTags = convertTextTags(translatedTags, (JArray)resultBody["tags"]);

                        // set results
                        analyzeBody.Description = (string)resultBody["description"]["captions"][0]["text"];
                        analyzeBody.IsAdultContent = ((string)resultBody["adult"]["isAdultContent"]).ToLower();
                        analyzeBody.IsRacyContent = ((string)resultBody["adult"]["isRacyContent"]).ToLower();
                        analyzeBody.Faces = convertFaces((JArray)resultBody["faces"]);
                        analyzeBody.Description_jp = translatedDescription;
                        analyzeBody.Tags = resultTextTags;

                        message.RbBody = analyzeBody;
                    }
                    else
                    {
                        // If failure, convert to the response body form and translate messages.
                        AppBodyWhenError appBodyWhenError = new AppBodyWhenError();
                        appBodyWhenError.success = "false";
                        appBodyWhenError.error_message = visionDescribeResult.Result.ToString();
                        RbAppLog.WriteError("E001", appBodyWhenError.error_message);

                        message.RbBody = appBodyWhenError;
                    }

                    // if deleteFile value is true, delete data from blob container.
                    if ((string)jo_input["deleteFile"] == "true"){
                        blobData.Delete(fileName);
                    }

                }
                // catch (ApplicationException ex)
                catch (Exception ex)
                {
                    AppBodyWhenError appBodyWhenError = new AppBodyWhenError();
                    appBodyWhenError.success = "false";
                    appBodyWhenError.error_message = ex.Message;
                    RbAppLog.WriteError("E002", ex.ToString());

                    message.RbBody = appBodyWhenError;
                }
            }

            message.RbHeader = rbh;

            string json_message = JsonConvert.SerializeObject(message);
            JObject jo = (JObject)JsonConvert.DeserializeObject(json_message);
            ja_messages.Add(jo);

            JArrayString jaString = new JArrayString(ja_messages);

            return jaString;
        }


        /// <summary>
        /// join text and tags for translation. It's necessary to resolve latency problems caused by http request
        /// </summary>
        /// <param name="text"></param>
        /// <param name="tags"></param>
        /// <returns></returns>
        private string joinTags(JArray tags)
        {
            // tagNames
            List<string> tagNames = new List<string>();
            foreach (JObject tag in tags)
            {
                tagNames.Add((string)tag["name"]);
            }

            return (String.Join("|", tagNames));
        }


        /// <summary>
        /// convert format of faces result generated by cognitive service into pepper form 
        /// </summary>
        /// <param name="baseFaces"></param>
        /// <returns></returns>
        private List<Object> convertFaces(JArray baseFaces)
        {
            List<Object> faces = new List<Object>();
            foreach (JObject face in baseFaces)
            {
                var gender = "";
                if ((string)face["gender"] == "Male")
                {
                    gender = "male";
                }
                else if ((string)face["gender"] == "Female")
                {
                    gender = "female";
                }

                faces.Add(
                    new Dictionary<string, string>() { { "age", (string)face["age"] }, { "gender", gender } }
                );
            }
            return faces;
        }


        /// <summary>
        /// convert format of tag and text result generated by cognitive service into pepper format
        /// </summary>
        /// <param name="translatedTagsArray"></param>
        /// <param name="baseTags"></param>
        /// <returns></returns>
        private List<Object> convertTextTags(string translatedTags, JArray baseTags)
        {
            //convert text and tags
            string[] translatedTagsArray = translatedTags.Split('|');
            int index = 0;
            List<Object> tags = new List<Object>();
            foreach (JObject tag in baseTags)
            {
                // if error, put "" for variables
                var translatedText = "";
                if (translatedTagsArray.Length > index)
                {
                    translatedText = translatedTagsArray[index];
                }
                double confidence = (double)tag["confidence"];
                confidence = Math.Round(confidence * 1000, 0) / 1000;
                tags.Add(
                    new Dictionary<string, string>() { { "name", (string)tag["name"] }, { "name_jp", translatedText.Trim() }, { "confidence", confidence.ToString() } }
                );
                index++;
            }
            return tags;
        }


        /// <summary>
        /// translate text 
        /// </summary>
        /// <param name="text"></param>
        /// <param name="translatorAccountKey"></param>
        /// <param name="tolang"></param>
        /// <returns></returns>
        private string translateText(string text, string translatorAccountKey, string tolang = "en")
        {
            //
            // Get a token
            //

            string translatedText = "";
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

            //
            // If success, trying to translate the contents
            //
            if (tokenResponse.Result.IsSuccessStatusCode)
            {
                // Read a token
                var responseData = tokenResponse.Result.Content.ReadAsStringAsync();
                responseData.Wait();
                string token = responseData.Result.ToString();

                //
                // Call Translator API
                //

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
                    translatedText = doc.InnerText;
                }
                else
                {
                    // If translation failed
                    //translatedText = translationResponse.Result.ToString();
                    translatedText = "";
                }

            }
            else
            {
                // If obtaining token failed
                translatedText = "";
            }

            return translatedText;
        }


    }
}
