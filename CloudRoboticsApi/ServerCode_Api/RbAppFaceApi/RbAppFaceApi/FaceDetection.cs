using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Web;

namespace RbAppFaceApi
{
    public class FaceDetection
    {
        private string faceApiEndpoint;
        private string faceApiKey;
        private double smileConfidence;
        private double facialHairConfidence;

        public FaceDetection(string faceApiEndpoint, string faceApiKey, double smileConfidence, double facialHairConfidence)
        {
            this.faceApiEndpoint = faceApiEndpoint;
            this.faceApiKey = faceApiKey;
            this.smileConfidence = smileConfidence;
            this.facialHairConfidence = facialHairConfidence;
        }
        public AppResult DetectFace(byte[] buffer, AppBodyFaceInfo appbody)
        {
            AppResult appResult = new AppResult();
            ApiResult apiResult = new ApiResult();

            // HTTP Client
            var client = new HttpClient();
            var queryString = HttpUtility.ParseQueryString(string.Empty);

            // Request headers
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", faceApiKey);

            // Request parameters
            queryString["returnFaceId"] = "true";
            queryString["returnFaceLandmarks"] = "false";
            queryString["returnFaceAttributes"] = "age,gender,smile,glasses,headPose,facialHair";
            var uri = $"{faceApiEndpoint}/detect?" + queryString;

            // Call REST API
            var content = new ByteArrayContent(buffer);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
            var response = client.PostAsync(uri, content);
            response.Wait();

            apiResult.IsSuccessStatusCode = response.Result.IsSuccessStatusCode;
            if (apiResult.IsSuccessStatusCode)
            {
                var resdata = response.Result.Content.ReadAsStringAsync();
                resdata.Wait();
                apiResult.Result = resdata.Result.ToString();

                JArray ja_result = (JArray)JsonConvert.DeserializeObject(apiResult.Result);
                JObject faceAttributes = null;

                if (ja_result.Count > 0)
                {
                    appbody.visitor_faceId = (string)ja_result[0]["faceId"];
                    faceAttributes = (JObject)ja_result[0]["faceAttributes"];

                    int age = (int)faceAttributes["age"];
                    appbody.age = age.ToString();
                    appbody.gender = (string)faceAttributes["gender"];
                    double smile = (double)faceAttributes["smile"];
                    if (smile >= smileConfidence)
                        appbody.smile = "true";
                    else
                        appbody.smile = "false";
                    string glasses = (string)faceAttributes["glasses"];
                    if (glasses == "NoGlasses")
                        appbody.glasses = "false";
                    else if (glasses.Length > 0)
                        appbody.glasses = "true";
                    else
                        appbody.glasses = "false";
                    double facialHair_moustache = (double)faceAttributes["facialHair"]["moustache"];
                    double facialHair_beard = (double)faceAttributes["facialHair"]["beard"];
                    double facialHair_sideburns = (double)faceAttributes["facialHair"]["sideburns"];
                    if (facialHair_moustache >= facialHairConfidence || facialHair_beard >= facialHairConfidence)
                        appbody.facialHair = "true";
                    else
                        appbody.facialHair = "false";
                }
                else
                {
                    appbody.age = "";
                    appbody.gender = "";
                    appbody.smile = "";
                    appbody.glasses = "";
                    appbody.facialHair = "";
                }
            }
            else
            {
                apiResult.Message = response.Result.ToString();
            }

            appResult.apiResult = apiResult;
            appResult.appBody = appbody;

            return appResult;
        }
    }
}
