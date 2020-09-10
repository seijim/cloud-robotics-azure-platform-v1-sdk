using System.Net.Http.Headers;
using System.Net.Http;
using System.Web;
using System.Text;


namespace RbAppFaceApi
{
    public class PersonGroup
    {
        private string faceApiEndpoint;
        private string faceApiKey;
        private string personGroupId;

        public PersonGroup(string faceApiEndpoint, string faceApiKey, string personGroupId)
        {
            this.faceApiEndpoint = faceApiEndpoint;
            this.faceApiKey = faceApiKey;
            this.personGroupId = personGroupId.ToLower();
        }

        public bool GetGroupExistence()
        {
            ApiResult apiResult = GetPersonGroup();
            if (apiResult.IsSuccessStatusCode)
                return true;
            else
                return false;
        }

        public ApiResult GetPersonGroup()
        {
            // HTTP Client
            var client = new HttpClient();
            var queryString = HttpUtility.ParseQueryString(string.Empty);

            // Request headers
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", faceApiKey);

            var uri = $"{faceApiEndpoint}/persongroups/{personGroupId}";

            // Request body
            byte[] byteData = Encoding.UTF8.GetBytes("{ \"name\":\"" + personGroupId + "\",\"userData\":\"\" }");

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

        public ApiResult CreatePersonGroup()
        {
            // HTTP Client
            var client = new HttpClient();
            var queryString = HttpUtility.ParseQueryString(string.Empty);

            // Request headers
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", faceApiKey);

            var uri = $"{faceApiEndpoint}/persongroups/{personGroupId}";

            // Request body
            byte[] byteData = Encoding.UTF8.GetBytes("{ \"name\":\"" + personGroupId + "\",\"userData\":\"\" }");

            // Call REST API
            var content = new ByteArrayContent(byteData);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = client.PutAsync(uri, content);
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

        private ApiResult DeletePersonGroup()
        {
            // HTTP Client
            var client = new HttpClient();
            var queryString = HttpUtility.ParseQueryString(string.Empty);

            // Request headers
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", faceApiKey);

            var uri = $"{faceApiEndpoint}/persongroups/{personGroupId}";

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

        public ApiResult TrainPersonGroup()
        {
            // HTTP Client
            var client = new HttpClient();
            var queryString = HttpUtility.ParseQueryString(string.Empty);

            // Request headers
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", faceApiKey);

            var uri = $"{faceApiEndpoint}/persongroups/{personGroupId}/train";

            // Request body
            byte[] byteData = Encoding.UTF8.GetBytes("");

            // Call REST API
            var content = new ByteArrayContent(byteData);
            //content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
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
