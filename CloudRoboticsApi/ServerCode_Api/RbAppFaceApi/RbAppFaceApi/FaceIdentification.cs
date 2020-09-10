using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Web;
using System.Text;

namespace RbAppFaceApi
{
    public class FaceIdentification
    {
        private string faceApiEndpoint;
        private string faceApiKey;
        private double faceConfidence;

        public FaceIdentification(string faceApiEndpoint, string faceApiKey, double faceConfidence)
        {
            this.faceApiEndpoint = faceApiEndpoint;
            this.faceApiKey = faceApiKey;
            this.faceConfidence = faceConfidence;
        }

        public AppResult IdentifyFace(AppBodyFaceInfo appbody)
        {
            AppResult appResult = new AppResult();
            ApiResult apiResult = new ApiResult();

            // Request parameters
            var client = new HttpClient();

            // Request headers
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", faceApiKey);

            var uri = $"{faceApiEndpoint}/identify";

            // Request body
            JObject jo_reqest = new JObject();
            jo_reqest["personGroupId"] = appbody.groupId;
            JArray ja_faceIds = new JArray();
            ja_faceIds.Add(appbody.visitor_faceId);
            jo_reqest["faceIds"] = ja_faceIds;
            jo_reqest["maxNumOfCandidatesReturned"] = 1;

            byte[] byteData = Encoding.UTF8.GetBytes((string)JsonConvert.SerializeObject(jo_reqest));

            // Call REST API
            var content = new ByteArrayContent(byteData);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = client.PostAsync(uri, content);
            response.Wait();

            apiResult = new ApiResult();
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
                appResult.apiResult = apiResult;
                appResult.appBody = appbody;
                return appResult;
            }

            string result = apiResult.Result;
            JArray ja_result = (JArray)JsonConvert.DeserializeObject(result);
            JArray candidates = (JArray)ja_result[0]["candidates"];

            if (candidates.Count > 0)
            {
                double confidence = (double)candidates[0]["confidence"];
                string s_personId = (string)candidates[0]["personId"];
                confidence = Math.Floor(confidence * 100) / 100;
                string s_condidence = confidence.ToString();

                ApiResult apiResult2 = getPerson(appbody.groupId, s_personId);
                if (apiResult2.IsSuccessStatusCode)
                {
                    JObject jo_result = (JObject)JsonConvert.DeserializeObject(apiResult2.Result);
                    appbody.visitor_name = (string)jo_result["name"];
                }

                appbody.visitor_id = s_personId;
                appbody.face_confidence = s_condidence;
            }

            appResult.apiResult = apiResult;
            appResult.appBody = appbody;

            return appResult;
        }

        private ApiResult getPerson(string personGroupId, string personId)
        {
            // HTTP Client
            var client = new HttpClient();
            var queryString = HttpUtility.ParseQueryString(string.Empty);

            // Request headers
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", faceApiKey);

            var uri = $"{faceApiEndpoint}/persongroups/{personGroupId}/persons/{personId}";

            // Request body
            byte[] byteData = Encoding.UTF8.GetBytes("{ \"name\":\"" + personId + "\",\"userData\":\"\" }");

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

    }
}
