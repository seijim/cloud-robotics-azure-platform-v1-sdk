using System;
using System.Data;
using System.Data.SqlClient;

namespace RbAppFaceApi
{
    public class PersonDbData
    {
        private string sqlConnString;
        private string appId;

        public PersonDbData(string sqlConnString, string appId)
        {
            this.sqlConnString = sqlConnString;
            this.appId = appId;
        }

        public AppResult GetInfo(AppBodyFaceInfo appbody)
        {
            AppResult appResult = new AppResult();
            ApiResult apiResult = new ApiResult();

            string sqltext = "SELECT PersonId,PersonName,PersonNameKana,VisitCount "
                           + "FROM RBApp.PersonVisitInfo WHERE GroupId = @p1 AND PersonId = @p2 AND LocationId = @p3";
            SqlConnection conn = new SqlConnection(sqlConnString);
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sqltext, conn);
                AddSqlParameter(ref cmd, "@p1", SqlDbType.NVarChar, appbody.groupId);
                AddSqlParameter(ref cmd, "@p2", SqlDbType.NVarChar, appbody.visitor_id);
                AddSqlParameter(ref cmd, "@p3", SqlDbType.NVarChar, appbody.locationId);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    appbody.visitor_name_kana = reader.GetString(2);
                    int visitCount = reader.GetInt32(3);
                    reader.Close();
                    conn.Close();
                    appbody.visit_count = (visitCount + 1).ToString();
                    UpdateInfo(appbody);
                }
                else
                {
                    reader.Close();
                    conn.Close();
                    appbody.visit_count = "1";
                    InsertInfo(appbody);
                }

                apiResult.IsSuccessStatusCode = true;

            }
            catch (Exception ex)
            {
                conn.Close();
                apiResult.IsSuccessStatusCode = false;
                apiResult.Message = ex.Message;
            }

            appResult.apiResult = apiResult;
            appResult.appBody = appbody;

            return appResult;
        }
        public void InsertInfo(AppBodyFaceInfo appbody)
        {
            string sqltext = "INSERT INTO RBApp.PersonVisitInfo (GroupId,PersonId,PersonName,PersonNameKana,LocationId,VisitCount) "
                           + "VALUES (@p1,@p2,@p3,@p4,@p5,@p6)";
            SqlConnection conn = new SqlConnection(sqlConnString);
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sqltext, conn);
                AddSqlParameter(ref cmd, "@p1", SqlDbType.NVarChar, appbody.groupId);
                AddSqlParameter(ref cmd, "@p2", SqlDbType.NVarChar, appbody.visitor_id);
                AddSqlParameter(ref cmd, "@p3", SqlDbType.NVarChar, appbody.visitor_name);
                AddSqlParameter(ref cmd, "@p4", SqlDbType.NVarChar, appbody.visitor_name_kana);
                AddSqlParameter(ref cmd, "@p5", SqlDbType.NVarChar, appbody.locationId);
                AddSqlParameter(ref cmd, "@p6", SqlDbType.Int, int.Parse(appbody.visit_count));
                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception)
            {
                conn.Close();
            }
        }
        public void UpdateInfo(AppBodyFaceInfo appbody)
        {
            string sqltext = "UPDATE RBApp.PersonVisitInfo SET VisitCount = @p4 "
                           + "WHERE GroupId = @p1 AND PersonId = @p2 AND LocationId = @p3";
            SqlConnection conn = new SqlConnection(sqlConnString);
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sqltext, conn);
                AddSqlParameter(ref cmd, "@p1", SqlDbType.NVarChar, appbody.groupId);
                AddSqlParameter(ref cmd, "@p2", SqlDbType.NVarChar, appbody.visitor_id);
                AddSqlParameter(ref cmd, "@p3", SqlDbType.NVarChar, appbody.locationId);
                AddSqlParameter(ref cmd, "@p4", SqlDbType.Int, int.Parse(appbody.visit_count));
                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception)
            {
                conn.Close();
            }
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
