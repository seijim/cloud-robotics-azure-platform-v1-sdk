using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using CloudRoboticsUtil;
using System.IO;

namespace RbAppFaceApi
{
    //public class WebApiMapper : MarshalByRefObject, IAppRouterDll
    public class RbFaceInfo : MarshalByRefObject, IAppRouterDll
    {
        public JArrayString ProcessMessage(RbAppMasterCache rbappmc, RbAppRouterCache rbapprc, RbHeader rbh, string rbBodyString)
        {
            string sqlConnString = string.Empty;
            string storageAccount = string.Empty;
            string storageKey = string.Empty;
            string storageContainer = string.Empty;
            string faceApiEndpoint = string.Empty;
            string faceApiKey = string.Empty;
            bool success = true;

            JArray ja_messages = new JArray();
            RbMessage message = new RbMessage();

            // RbAppLog
            var appName = Path.GetFileNameWithoutExtension(this.GetType().Assembly.Location);
            string storageConnectionString = string.Format("DefaultEndpointsProtocol=https;AccountName={0};AccountKey={1}",
                        rbappmc.StorageAccount, rbappmc.StorageKey);
            RbAppLog RbAppLog = new RbAppLog();
            RbAppLog.Initialize(storageConnectionString, "RbAppLog", appName);

            // Get appinfo 
            JObject jo_appInfo = (JObject)JsonConvert.DeserializeObject(rbappmc.AppInfo);
            var p1 = jo_appInfo["SqlConnString"];
            if (p1 != null)
                sqlConnString = (string)p1;
            var p2 = jo_appInfo["StorageAccount"];
            if (p2 != null)
                storageAccount = (string)p2;
            var p3 = jo_appInfo["StorageKey"];
            if (p3 != null)
                storageKey = (string)p3;
            var p4 = jo_appInfo["FaceStorageContainer"];
            if (p4 != null)
                storageContainer = (string)p4;
            var p5 = jo_appInfo["FaceApiEndpoint"];
            if (p5 != null)
                faceApiEndpoint = (string)p5;
            var p6 = jo_appInfo["FaceApiKey"];
            if (p6 != null)
                faceApiKey = (string)p6;

            JObject jo_input = (JObject)JsonConvert.DeserializeObject(rbBodyString);
            AppBodyWhenError appBodyWhenError = new AppBodyWhenError();

            if (rbh.MessageId == "init")
            {
                AppBodyInit appBody = new AppBodyInit();
                appBody.storageAccount = storageAccount; 
                appBody.storageContainer = storageContainer;
                appBody.storageKey = storageKey;
                message.RbBody = appBody;
            }
            else if (rbh.MessageId == "getFaceInfo")
            {
                AppBodyFaceInfo appBody = new AppBodyFaceInfo();
                appBody.visitor = (string)jo_input["visitor"];
                appBody.groupId = (string)jo_input["groupId"];
                appBody.locationId = (string)jo_input["locationId"];
                if (appBody.locationId == null || appBody.locationId == string.Empty)
                    appBody.locationId = "all";

                // Get image data stream
                string fileName = (string)jo_input["blobFileName"];
                string deleteFile = (string)jo_input["deleteFile"];
                BlobData blobData = new BlobData(storageAccount, storageKey, storageContainer);
                try
                {
                    byte[] buffer = blobData.GetStream(fileName);

                    // Delete File
                    if (deleteFile == "true")
                        blobData.Delete(fileName);

                    // Get Confidence threshold
                    double faceConfidence = 0;
                    try
                    {
                        faceConfidence = (double)jo_appInfo["FaceConfidence"];
                    }
                    catch
                    {
                        faceConfidence = 0.5;
                    }
                    double smileConfidence = 0;
                    try
                    {
                        smileConfidence = (double)jo_appInfo["SmileConfidence"];
                    }
                    catch
                    {
                        smileConfidence = 0.5;
                    }
                    double facialHairConfidence = 0;
                    try
                    {
                        facialHairConfidence = (double)jo_appInfo["FacialHairConfidence"];
                    }
                    catch
                    {
                        facialHairConfidence = 0.5;
                    }

                    // Call Face API (Detection)
                    FaceDetection fd = new FaceDetection(faceApiEndpoint, faceApiKey, smileConfidence, facialHairConfidence);
                    AppResult appResult1 = fd.DetectFace(buffer, appBody);
                    appBody = appResult1.appBody;
                    if (appResult1.apiResult.IsSuccessStatusCode)
                    {
                        // Call Face API (Identification)
                        FaceIdentification fi = new FaceIdentification(faceApiEndpoint, faceApiKey, faceConfidence);
                        AppResult appResult2 = fi.IdentifyFace(appBody);
                        appBody = appResult2.appBody;

                        if (appResult2.apiResult.IsSuccessStatusCode)
                        {
                            if (appBody.visitor_id != string.Empty)
                            {
                                PersonDbData personDbData = new PersonDbData(sqlConnString, rbh.AppId);
                                AppResult appResult3 = personDbData.GetInfo(appBody);
                                if (appResult3.apiResult.IsSuccessStatusCode)
                                {
                                    appBody = appResult3.appBody;
                                }
                                else
                                {
                                    success = false;
                                    appBodyWhenError.error_message = appResult3.apiResult.Message;
                                    RbAppLog.WriteError("E001", appResult3.apiResult.Message);
                                }
                            }
                        }
                        else
                        {
                            // Set success "true" even if identification doesn't succeed 
                            rbh.ProcessingStack = "** Notice ** Face identification missed.";
                            RbAppLog.WriteError("E002", appResult2.apiResult.Message);
                        }
                    }
                    else
                    {
                        success = false;
                        appBodyWhenError.error_message = appResult1.apiResult.Message;
                        RbAppLog.WriteError("E003", appResult1.apiResult.Message);
                    }

                    if (success)
                    {
                        appBody.success = "true";
                        message.RbBody = appBody;
                    }
                    else
                    {
                        appBodyWhenError.success = "false";
                        message.RbBody = appBodyWhenError;
                    }
                }
                catch (Exception ex)
                {
                    appBodyWhenError.error_message = ex.Message;
                    RbAppLog.WriteError("E004", ex.ToString());
                    
                    appBodyWhenError.success = "false";
                    message.RbBody = appBodyWhenError;
                }
            }
            else if (rbh.MessageId == "registerFace")
            {
                AppBodyRegResult appBody = new AppBodyRegResult();
                appBody.visitor = (string)jo_input["visitor"];
                appBody.groupId = (string)jo_input["groupId"];
                appBody.locationId = (string)jo_input["locationId"];
                if (appBody.locationId == null || appBody.locationId == string.Empty)
                    appBody.locationId = "all";
                appBody.visitor_name = (string)jo_input["visitor_name"];
                appBody.visitor_name_kana = (string)jo_input["visitor_name_kana"];

                // Check Person Group existence
                ApiResult apiResult1 = new ApiResult();
                apiResult1.IsSuccessStatusCode = true;

                PersonGroup personGroup = new PersonGroup(faceApiEndpoint, faceApiKey, appBody.groupId);
                if (!personGroup.GetGroupExistence())
                {
                    // Create Person Group
                    apiResult1 = personGroup.CreatePersonGroup();
                }

                if (apiResult1.IsSuccessStatusCode)
                {
                    // Create Person
                    Person person = new Person(faceApiEndpoint, faceApiKey, appBody.groupId);
                    ApiResult apiResult2 = person.CreatePerson(appBody.visitor_name);

                    if (apiResult2.IsSuccessStatusCode)
                    {
                        // Extract PersonId
                        JObject joRsult2 = (JObject)JsonConvert.DeserializeObject(apiResult2.Result);
                        appBody.visitor_id = (string)joRsult2["personId"];

                        // Get image data stream
                        string fileName = (string)jo_input["blobFileName"];
                        string deleteFile = (string)jo_input["deleteFile"];
                        BlobData blobData = new BlobData(storageAccount, storageKey, storageContainer);
                        try
                        {
                            byte[] buffer = blobData.GetStream(fileName);

                            // Delete File
                            if (deleteFile == "true")
                                blobData.Delete(fileName);

                            // Add Face to the Person
                            ApiResult apiResult3 = person.AddPersonFace(appBody.visitor_id, buffer);
                            if (apiResult3.IsSuccessStatusCode)
                            {
                                appBody.success = "true";
                                personGroup.TrainPersonGroup();

                                AppBodyFaceInfo appBodyFaceInfo = new AppBodyFaceInfo();
                                appBodyFaceInfo.visitor = appBody.visitor;
                                appBodyFaceInfo.groupId = appBody.groupId;
                                appBodyFaceInfo.locationId = appBody.locationId;
                                appBodyFaceInfo.visitor_id = appBody.visitor_id;
                                appBodyFaceInfo.visitor_name = appBody.visitor_name;
                                appBodyFaceInfo.visitor_name_kana = appBody.visitor_name_kana;
                                appBodyFaceInfo.visit_count = "1";
                                PersonDbData personDbData = new PersonDbData(sqlConnString, rbh.AppId);
                                personDbData.InsertInfo(appBodyFaceInfo);
                            }
                            else
                            {
                                success = false;
                                appBodyWhenError.error_message = apiResult3.Message;
                                RbAppLog.WriteError("E005", apiResult3.Message);
                            }
                        }
                        catch (Exception ex)
                        {
                            if (ex.Message.Length > 100)
                                appBodyWhenError.error_message = ex.Message.Substring(0, 100);
                            else
                                appBodyWhenError.error_message = ex.Message;

                            appBodyWhenError.success = "false";
                            message.RbBody = appBodyWhenError;
                            RbAppLog.WriteError("E006", ex.ToString());
                        }
                    }
                    else
                    {
                        success = false;
                        appBodyWhenError.error_message = apiResult2.Message;
                        RbAppLog.WriteError("E007", apiResult2.Message);
                    }
                }
                else
                {
                    success = false;
                    appBodyWhenError.error_message = apiResult1.Message;
                    RbAppLog.WriteError("E008", apiResult1.Message);
                }

                if (success)
                {
                    appBody.success = "true";
                    message.RbBody = appBody;
                }
                else
                {
                    appBodyWhenError.success = "false";
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
    }

}
