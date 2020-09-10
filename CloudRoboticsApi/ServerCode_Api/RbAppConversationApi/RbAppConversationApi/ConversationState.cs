using System;
using System.Data;
using System.Data.SqlClient;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace RbAppConversationApi
{
    public class ConversationState
    {
        private string sqlConnString = string.Empty;
        private string deviceId = string.Empty;
        private string appId = string.Empty;

        public ConversationState(string sqlConnString, string deviceId, string appId)
        {
            this.sqlConnString = sqlConnString;
            this.deviceId = deviceId;
            this.appId = appId;
        }

        public AppResult GetState()
        {
            AppResult appResult = new AppResult();
            ApiResult apiResult = new ApiResult();
            string conversationStateString = string.Empty;

            string sqltext = "SELECT DeviceId,AppId,State "
                           + "FROM RBApp.ConversationState WHERE DeviceId = @p1 AND AppId = @p2";
            SqlConnection conn = new SqlConnection(sqlConnString);
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sqltext, conn);
                AddSqlParameter(ref cmd, "@p1", SqlDbType.NVarChar, deviceId);
                AddSqlParameter(ref cmd, "@p2", SqlDbType.NVarChar, appId);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    conversationStateString = reader.GetString(2);
                    reader.Close();
                    conn.Close();
                    appResult.conversationStateString = conversationStateString;
                    apiResult.IsSuccessStatusCode = true;
                }
                else
                {
                    reader.Close();
                    conn.Close();
                    apiResult.IsSuccessStatusCode = false;
                    apiResult.Message = "** Error ** State Record not found in RBApp.ConversationState.";
                }
            }
            catch (Exception ex)
            {
                conn.Close();
                apiResult.IsSuccessStatusCode = false;
                apiResult.Message = ex.Message;
            }

            appResult.apiResult = apiResult;

            return appResult;
        }

        public ApiResult SetState(string conversationStateString)
        {
            ApiResult apiResult = new ApiResult();

            string sqltext = "UPDATE RBApp.ConversationState SET State = @p3, Registered_DateTime = @p4 "
                           + "WHERE DeviceId = @p1 AND AppId = @p2";
            SqlConnection conn = new SqlConnection(sqlConnString);
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sqltext, conn);
                AddSqlParameter(ref cmd, "@p1", SqlDbType.NVarChar, deviceId);
                AddSqlParameter(ref cmd, "@p2", SqlDbType.NVarChar, appId);
                AddSqlParameter(ref cmd, "@p3", SqlDbType.NVarChar, conversationStateString);
                AddSqlParameter(ref cmd, "@p4", SqlDbType.DateTime, System.DateTime.Now);

                int countRows = cmd.ExecuteNonQuery();
                if (countRows == 0)
                {
                    sqltext = "INSERT INTO RBApp.ConversationState "
                            + "(DeviceId,AppId,State,Description,Registered_DateTime) "
                            + "VALUES (@p1,@p2,@p3,'created by RbAppConversationApi',@p4)";
                    cmd = new SqlCommand(sqltext, conn);
                    AddSqlParameter(ref cmd, "@p1", SqlDbType.NVarChar, deviceId);
                    AddSqlParameter(ref cmd, "@p2", SqlDbType.NVarChar, appId);
                    AddSqlParameter(ref cmd, "@p3", SqlDbType.NVarChar, conversationStateString);
                    AddSqlParameter(ref cmd, "@p4", SqlDbType.DateTime, System.DateTime.Now);

                    countRows = cmd.ExecuteNonQuery();
                }
                conn.Close();
                apiResult.IsSuccessStatusCode = true;
            }
            catch (Exception ex)
            {
                conn.Close();
                apiResult.IsSuccessStatusCode = false;
                apiResult.Message = ex.Message;
            }

            return apiResult;
        }

        private void AddSqlParameter(ref SqlCommand cmd, string ParameterName, SqlDbType type, Object value)
        {
            SqlParameter param = cmd.CreateParameter();
            param.ParameterName = ParameterName;
            param.SqlDbType = type;
            param.Direction = ParameterDirection.Input;
            param.Value = value;
            cmd.Parameters.Add(param);
        }

    }
}
