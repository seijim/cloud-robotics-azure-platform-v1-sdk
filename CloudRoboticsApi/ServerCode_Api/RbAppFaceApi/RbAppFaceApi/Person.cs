using System.Net.Http.Headers;
using System.Net.Http;
using System.Web;
using System.Text;


namespace RbAppFaceApi
{
    public class Person
    {
        private string faceApiEndpoint;
        private string faceApiKey;
        private string personGroupId;

        public Person(string faceApiEndpoint, string faceApiKey, string personGroupId)
        {
            this.faceApiEndpoint = faceApiEndpoint;
            this.faceApiKey = faceApiKey;
            this.personGroupId = personGroupId;
        }

        public ApiResult GetPerson(string personId)
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

        public ApiResult CreatePerson(string personName)
        {
            // HTTP Client
            var client = new HttpClient();
            var queryString = HttpUtility.ParseQueryString(string.Empty);

            // Request headers
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", faceApiKey);

            var uri = $"{faceApiEndpoint}/persongroups/{personGroupId}/persons";

            // Request body
            byte[] byteData = Encoding.UTF8.GetBytes("{\"name\":\"" + personName + "\"}");

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

        public ApiResult DeletePerson(string personId)
        {
            // HTTP Client
            var client = new HttpClient();
            var queryString = HttpUtility.ParseQueryString(string.Empty);

            // Request headers
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", faceApiKey);

            var uri = $"{faceApiEndpoint}/persongroups/{personGroupId}/persons/{personId}";

            // Call REST API
            var response = client.DeleteAsync(uri);
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

        public ApiResult AddPersonFace(string personId, byte[] buffer)
        {
            // HTTP Client
            var client = new HttpClient();
            var queryString = HttpUtility.ParseQueryString(string.Empty);

            // Request headers
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", faceApiKey);

            // Request parameters
            //queryString["userData"] = "";
            //queryString["targetFace"] = "";
            var uri = $"{faceApiEndpoint}/persongroups/{personGroupId}/persons/{personId}/persistedFaces?"
                    + queryString;

            // Call REST API
            var content = new ByteArrayContent(buffer);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
            var response = client.PostAsync(uri, content);
            response.Wait();

            ApiResult apiResult = new ApiResult();
            apiResult.IsSuccessStatusCode = response.Result.IsSuccessStatusCode;
            if (!apiResult.IsSuccessStatusCode)
            {
                apiResult.Message = response.Result.ToString();
            }

            return apiResult;
        }

    }
}
