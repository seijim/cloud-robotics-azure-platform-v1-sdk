using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;

namespace CloudRoboticsDefTool
{
    public class AppMasterProcessor
    {
        private string sqlConnectionString;
        private string encPassPhrase;
        private ApplicationException ae = null;

        public AppMasterProcessor(string sqlConnectionString, string encPassPhrase)
        {
            this.sqlConnectionString = sqlConnectionString;
            this.encPassPhrase = encPassPhrase;
        }

        public List<AppMasterEntity> GetAppMasters(string appId)
        {
            appId = appId.Replace("*", "%");

            string sqltext = "SELECT AppId,StorageAccount,"
                           + "CONVERT(NVARCHAR(1000),DecryptByPassphrase(@passPhrase,StorageKeyEnc,1,CONVERT(varbinary,AppId))) AS StorageKey,"
                           + "CONVERT(NVARCHAR(4000),DecryptByPassphrase(@passPhrase,AppInfoEnc,1,CONVERT(varbinary,AppId))) AS AppInfo,"
                           + "CONVERT(NVARCHAR(4000),DecryptByPassphrase(@passPhrase,AppInfoDeviceEnc,1,CONVERT(varbinary,AppId))) AS AppInfoDevice,"
                           + "Status,Description,Registered_DateTime "
                           + "FROM RBFX.AppMaster "
                           + "WHERE AppId LIKE @p1 ORDER BY AppId";

            List<AppMasterEntity> listOfAppMasters = new List<AppMasterEntity>();

            SqlConnection conn = new SqlConnection(this.sqlConnectionString);
            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(sqltext, conn);
                AddSqlParameter(ref cmd, "@p1", SqlDbType.NVarChar, appId);
                AddSqlParameter(ref cmd, "@passPhrase", SqlDbType.NVarChar, encPassPhrase);
                SqlDataReader reader = cmd.ExecuteReader();

                if (!reader.HasRows)
                {
                    ae = new ApplicationException("No record was found in RBFX.AppMaster");
                    throw ae;
                }

                while (reader.Read())
                {
                    AppMasterEntity appMasterEntity = new AppMasterEntity();
                    appMasterEntity.AppId = reader.GetString(0);
                    appMasterEntity.StorageAccount = reader.GetString(1);
                    if (!reader.IsDBNull(2))
                    {
                        appMasterEntity.StorageKey = reader.GetString(2);
                    }
                    else
                    {
                        ae = new ApplicationException("Storage key can't be decrypted. Encryption Passphrase may be wrong.");
                        throw ae;
                    }

                    if (!reader.IsDBNull(3))
                    {
                        appMasterEntity.AppInfo = reader.GetString(3);
                    }
                    else
                    {
                        appMasterEntity.AppInfo = string.Empty;
                    }

                    if (!reader.IsDBNull(4))
                    {
                        appMasterEntity.AppInfoDevice = reader.GetString(4);
                    }
                    else
                    {
                        appMasterEntity.AppInfoDevice = string.Empty;
                    }

                    appMasterEntity.Status = reader.GetString(5);

                    if (!reader.IsDBNull(6))
                    {
                        appMasterEntity.Description = reader.GetString(6);
                    }
                    else
                    {
                        appMasterEntity.Description = string.Empty;
                    }

                    if (!reader.IsDBNull(7))
                        appMasterEntity.Registered_DateTime = reader.GetDateTime(7);

                    listOfAppMasters.Add(appMasterEntity);
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

            return listOfAppMasters;

        }

        public AppMasterEntity GetAppMaster(string appId)
        {
            AppMasterEntity appMasterEntity = new AppMasterEntity();

            string sqltext = "SELECT AppId,StorageAccount,"
                           + "CONVERT(NVARCHAR(1000),DecryptByPassphrase(@passPhrase,StorageKeyEnc,1,CONVERT(varbinary,AppId))) AS StorageKey,"
                           + "CONVERT(NVARCHAR(4000),DecryptByPassphrase(@passPhrase,AppInfoEnc,1,CONVERT(varbinary,AppId))) AS AppInfo,"
                           + "CONVERT(NVARCHAR(4000),DecryptByPassphrase(@passPhrase,AppInfoDeviceEnc,1,CONVERT(varbinary,AppId))) AS AppInfoDevice,"
                           + "Status,Description,Registered_DateTime "
                           + "FROM RBFX.AppMaster "
                           + "WHERE AppId = @p1";

            SqlConnection conn = new SqlConnection(this.sqlConnectionString);
            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(sqltext, conn);
                AddSqlParameter(ref cmd, "@p1", SqlDbType.NVarChar, appId);
                AddSqlParameter(ref cmd, "@passPhrase", SqlDbType.NVarChar, encPassPhrase);
                SqlDataReader reader = cmd.ExecuteReader();

                if (!reader.HasRows)
                {
                    ae = new ApplicationException("No record was found in RBFX.AppMaster");
                    throw ae;
                }

                reader.Read();
                
                appMasterEntity.AppId = reader.GetString(0);
                appMasterEntity.StorageAccount = reader.GetString(1);
                appMasterEntity.StorageKey = reader.GetString(2);

                if (!reader.IsDBNull(3))
                {
                    appMasterEntity.AppInfo = reader.GetString(3);
                }
                else
                {
                    appMasterEntity.AppInfo = string.Empty;
                }

                if (!reader.IsDBNull(4))
                {
                    appMasterEntity.AppInfoDevice = reader.GetString(4);
                }
                else
                {
                    appMasterEntity.AppInfoDevice = string.Empty;
                }

                appMasterEntity.Status = reader.GetString(5);

                if (!reader.IsDBNull(6))
                {
                    appMasterEntity.Description = reader.GetString(6);
                }
                else
                {
                    appMasterEntity.Description = string.Empty;
                }

                if (!reader.IsDBNull(7))
                    appMasterEntity.Registered_DateTime = reader.GetDateTime(7);
                

                reader.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                if (ex.GetType().Equals(ae))
                    conn.Close();
                throw (ex);
            }

            return appMasterEntity;

        }

        public void insertAppMaster(AppMasterEntity appMasterEntity)
        {
            string sqltext = "INSERT INTO RBFX.AppMaster ("
                + "AppId,StorageAccount,"
                + "StorageKeyEnc,"
                + "AppInfoEnc,"
                + "AppInfoDeviceEnc,"
                + "Status,Description,Registered_DateTime"
                + ") VALUES ("
                + "@p1,@p2,"
                + "EncryptByPassPhrase(@passPhrase, @p3, 1, CONVERT(varbinary, @p1)),"
                + "EncryptByPassPhrase(@passPhrase, @p4, 1, CONVERT(varbinary, @p1)),"
                + "EncryptByPassPhrase(@passPhrase, @p5, 1, CONVERT(varbinary, @p1)),"
                + "@p6,@p7,@p8)";

            SqlConnection conn = new SqlConnection(this.sqlConnectionString);
            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(sqltext, conn);
                AddSqlParameter(ref cmd, "@p1", SqlDbType.NVarChar, appMasterEntity.AppId);
                AddSqlParameter(ref cmd, "@p2", SqlDbType.NVarChar, appMasterEntity.StorageAccount);
                AddSqlParameter(ref cmd, "@p3", SqlDbType.NVarChar, appMasterEntity.StorageKey);
                AddSqlParameter(ref cmd, "@p4", SqlDbType.NVarChar, appMasterEntity.AppInfo);
                AddSqlParameter(ref cmd, "@p5", SqlDbType.NVarChar, appMasterEntity.AppInfoDevice);
                AddSqlParameter(ref cmd, "@p6", SqlDbType.NVarChar, appMasterEntity.Status);
                AddSqlParameter(ref cmd, "@p7", SqlDbType.NVarChar, appMasterEntity.Description);
                AddSqlParameter(ref cmd, "@p8", SqlDbType.DateTime, appMasterEntity.Registered_DateTime);
                AddSqlParameter(ref cmd, "@passPhrase", SqlDbType.NVarChar, encPassPhrase);
                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                throw ex;
            }
        }

        public void updateAppMaster(AppMasterEntity appMasterEntity)
        {
            string sqltext = "UPDATE RBFX.AppMaster SET "
                + "StorageAccount = @p2,"
                + "StorageKeyEnc = EncryptByPassPhrase(@passPhrase, @p3, 1, CONVERT(varbinary, @p1)),"
                + "AppInfoEnc = EncryptByPassPhrase(@passPhrase, @p4, 1, CONVERT(varbinary, @p1)),"
                + "AppInfoDeviceEnc = EncryptByPassPhrase(@passPhrase, @p5, 1, CONVERT(varbinary, @p1)),"
                + "Status = @p6,"
                + "Description = @p7,"
                + "Registered_DateTime = @p8 "
                + "WHERE AppId = @p1";

            SqlConnection conn = new SqlConnection(this.sqlConnectionString);
            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(sqltext, conn);
                AddSqlParameter(ref cmd, "@p1", SqlDbType.NVarChar, appMasterEntity.AppId);
                AddSqlParameter(ref cmd, "@p2", SqlDbType.NVarChar, appMasterEntity.StorageAccount);
                AddSqlParameter(ref cmd, "@p3", SqlDbType.NVarChar, appMasterEntity.StorageKey);
                AddSqlParameter(ref cmd, "@p4", SqlDbType.NVarChar, appMasterEntity.AppInfo);
                AddSqlParameter(ref cmd, "@p5", SqlDbType.NVarChar, appMasterEntity.AppInfoDevice);
                AddSqlParameter(ref cmd, "@p6", SqlDbType.NVarChar, appMasterEntity.Status);
                AddSqlParameter(ref cmd, "@p7", SqlDbType.NVarChar, appMasterEntity.Description);
                AddSqlParameter(ref cmd, "@p8", SqlDbType.DateTime, appMasterEntity.Registered_DateTime);
                AddSqlParameter(ref cmd, "@passPhrase", SqlDbType.NVarChar, encPassPhrase);
                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                throw ex;
            }
        }

        public void deleteAppMaster(string appId)
        {
            string sqltext = "DELETE FROM RBFX.AppMaster WHERE AppId = @p1";

            SqlConnection conn = new SqlConnection(this.sqlConnectionString);
            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(sqltext, conn);
                AddSqlParameter(ref cmd, "@p1", SqlDbType.NVarChar, appId);
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
