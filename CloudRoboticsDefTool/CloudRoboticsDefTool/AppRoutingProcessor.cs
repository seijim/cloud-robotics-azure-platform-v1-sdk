using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;


namespace CloudRoboticsDefTool
{
    public class AppRoutingProcessor
    {
        private string sqlConnectionString;
        private ApplicationException ae = null;

        public AppRoutingProcessor(string sqlConnectionString)
        {
            this.sqlConnectionString = sqlConnectionString;
        }

        public List<AppRoutingEntity> GetAppRoutings(string appId)
        {
            appId = appId.Replace("*", "%");

            string sqltext = "SELECT AppId,AppProcessingId,BlobContainer,FileName,ClassName,"
                           + "Status,DevMode,DevLocalDir,Description,Registered_DateTime "
                           + "FROM RBFX.AppRouting "
                           + "WHERE AppId LIKE @p1 ORDER BY AppId,AppProcessingId";

            List<AppRoutingEntity> listOfAppRoutings = new List<AppRoutingEntity>();

            SqlConnection conn = new SqlConnection(this.sqlConnectionString);
            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(sqltext, conn);
                AddSqlParameter(ref cmd, "@p1", SqlDbType.NVarChar, appId);
                SqlDataReader reader = cmd.ExecuteReader();

                if (!reader.HasRows)
                {
                    ae = new ApplicationException("No record was found in RBFX.AppRouting");
                    throw ae;
                }

                while (reader.Read())
                {
                    AppRoutingEntity appRoutingEntity = new AppRoutingEntity();
                    appRoutingEntity.AppId = reader.GetString(0);
                    appRoutingEntity.AppProcessingId = reader.GetString(1);
                    appRoutingEntity.BlobContainer = reader.GetString(2);
                    appRoutingEntity.FileName = reader.GetString(3);
                    appRoutingEntity.ClassName = reader.GetString(4);
                    appRoutingEntity.Status = reader.GetString(5);

                    if (!reader.IsDBNull(6))
                    {
                        appRoutingEntity.DevMode = reader.GetString(6);
                    }
                    else
                    {
                        appRoutingEntity.DevMode = string.Empty;
                    }

                    if (!reader.IsDBNull(7))
                    {
                        appRoutingEntity.DevLocalDir = reader.GetString(7);
                    }
                    else
                    {
                        appRoutingEntity.DevLocalDir = string.Empty;
                    }

                    if (!reader.IsDBNull(8))
                    {
                        appRoutingEntity.Description = reader.GetString(8);
                    }
                    else
                    {
                        appRoutingEntity.Description = string.Empty;
                    }

                    if (!reader.IsDBNull(9))
                        appRoutingEntity.Registered_DateTime = reader.GetDateTime(9);

                    listOfAppRoutings.Add(appRoutingEntity);
                }

                reader.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                if (ex.GetType().Equals(ae))
                    conn.Close();
                throw (ex);
            }

            return listOfAppRoutings;

        }

        public void insertAppRouting(AppRoutingEntity appRoutingEntity)
        {
            string sqltext = "INSERT INTO RBFX.AppRouting ("
                + "AppId,AppProcessingId,BlobContainer,FileName,ClassName,"
                + "Status,DevMode,DevLocalDir,Description,Registered_DateTime"
                + ") VALUES ("
                + "@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10)";

            SqlConnection conn = new SqlConnection(this.sqlConnectionString);
            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(sqltext, conn);
                AddSqlParameter(ref cmd, "@p1", SqlDbType.NVarChar, appRoutingEntity.AppId);
                AddSqlParameter(ref cmd, "@p2", SqlDbType.NVarChar, appRoutingEntity.AppProcessingId);
                AddSqlParameter(ref cmd, "@p3", SqlDbType.NVarChar, appRoutingEntity.BlobContainer);
                AddSqlParameter(ref cmd, "@p4", SqlDbType.NVarChar, appRoutingEntity.FileName);
                AddSqlParameter(ref cmd, "@p5", SqlDbType.NVarChar, appRoutingEntity.ClassName);
                AddSqlParameter(ref cmd, "@p6", SqlDbType.NVarChar, appRoutingEntity.Status);
                AddSqlParameter(ref cmd, "@p7", SqlDbType.NVarChar, appRoutingEntity.DevMode);
                AddSqlParameter(ref cmd, "@p8", SqlDbType.NVarChar, appRoutingEntity.DevLocalDir);
                AddSqlParameter(ref cmd, "@p9", SqlDbType.NVarChar, appRoutingEntity.Description);
                AddSqlParameter(ref cmd, "@p10", SqlDbType.DateTime, appRoutingEntity.Registered_DateTime);
                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                throw ex;
            }
        }

        public void updateAppRouting(AppRoutingEntity appRoutingEntity)
        {
            string sqltext = "UPDATE RBFX.AppRouting SET "
                + "BlobContainer = @p3,"
                + "FileName = @p4,"
                + "ClassName = @p5,"
                + "Status = @p6,"
                + "DevMode = @p7,"
                + "DevLocalDir = @p8,"
                + "Description = @p9,"
                + "Registered_DateTime = @p10 "
                + "WHERE AppId = @p1 AND AppProcessingId = @p2";

            SqlConnection conn = new SqlConnection(this.sqlConnectionString);
            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(sqltext, conn);
                AddSqlParameter(ref cmd, "@p1", SqlDbType.NVarChar, appRoutingEntity.AppId);
                AddSqlParameter(ref cmd, "@p2", SqlDbType.NVarChar, appRoutingEntity.AppProcessingId);
                AddSqlParameter(ref cmd, "@p3", SqlDbType.NVarChar, appRoutingEntity.BlobContainer);
                AddSqlParameter(ref cmd, "@p4", SqlDbType.NVarChar, appRoutingEntity.FileName);
                AddSqlParameter(ref cmd, "@p5", SqlDbType.NVarChar, appRoutingEntity.ClassName);
                AddSqlParameter(ref cmd, "@p6", SqlDbType.NVarChar, appRoutingEntity.Status);
                AddSqlParameter(ref cmd, "@p7", SqlDbType.NVarChar, appRoutingEntity.DevMode);
                AddSqlParameter(ref cmd, "@p8", SqlDbType.NVarChar, appRoutingEntity.DevLocalDir);
                AddSqlParameter(ref cmd, "@p9", SqlDbType.NVarChar, appRoutingEntity.Description);
                AddSqlParameter(ref cmd, "@p10", SqlDbType.DateTime, appRoutingEntity.Registered_DateTime);
                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                throw ex;
            }
        }

        public void deleteAppRouting(string appId, string appProcessingId)
        {
            string sqltext = "DELETE FROM RBFX.AppRouting WHERE AppId = @p1 AND AppProcessingId = @p2";

            SqlConnection conn = new SqlConnection(this.sqlConnectionString);
            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(sqltext, conn);
                AddSqlParameter(ref cmd, "@p1", SqlDbType.NVarChar, appId);
                AddSqlParameter(ref cmd, "@p2", SqlDbType.NVarChar, appProcessingId);
                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                throw ex;
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
