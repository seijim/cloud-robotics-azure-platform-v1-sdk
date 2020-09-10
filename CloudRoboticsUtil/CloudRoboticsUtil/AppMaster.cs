using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace CloudRoboticsUtil
{
    public class AppMaster
    {
        private ApplicationException ae;
        private string _appId = null;
        private string _passPhrase = null;
        private string _sqlConnString = null;
        private int _expiredSecond = RbAppCacheType.DefaultCachingTimeSec;

        public AppMaster(string appId, string passPhrase, string sqlConnString)
        {
            _appId = appId;
            _passPhrase = passPhrase;
            _sqlConnString = sqlConnString;
        }
        public AppMaster(string appId, string passPhrase, string sqlConnString, int expiredSecond)
        {
            _appId = appId;
            _passPhrase = passPhrase;
            _sqlConnString = sqlConnString;
            _expiredSecond = expiredSecond;
        }
        public RbAppMasterCache GetAppMaster()
        {
            RbAppMasterCache appmc = new RbAppMasterCache();
            string sqltext = "SELECT AppId,StorageAccount,"
                + "CONVERT(NVARCHAR(1000),DecryptByPassphrase(@passPhrase,StorageKeyEnc,1,CONVERT(varbinary,AppId))) AS StorageKey,"
                + "CONVERT(NVARCHAR(4000),DecryptByPassphrase(@passPhrase,AppInfoEnc,1,CONVERT(varbinary,AppId))) AS AppInfo,"
                + "CONVERT(NVARCHAR(4000),DecryptByPassphrase(@passPhrase,AppInfoDeviceEnc,1,CONVERT(varbinary,AppId))) AS AppInfoDevice,"
                + "[Status],[Description],Registered_DateTime "
                + "FROM RBFX.AppMaster WHERE AppId = @p1 "
                + "AND Status = 'Active'";
            SqlConnection conn = new SqlConnection(_sqlConnString);
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sqltext, conn);
                AddSqlParameter(ref cmd, "@p1", SqlDbType.NVarChar, _appId);
                AddSqlParameter(ref cmd, "@passPhrase", SqlDbType.NVarChar, _passPhrase);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    appmc.AppId = reader.GetString(0);
                    appmc.StorageAccount = reader.GetString(1);
                    appmc.StorageKey = reader.GetString(2);
                    appmc.AppInfo = reader.GetString(3);
                    appmc.AppInfoDevice = reader.GetString(4);
                    appmc.Status = reader.GetString(5);
                    appmc.Description = reader.GetString(6);
                    appmc.Registered_DateTime = reader.GetDateTime(7);
                    TimeSpan ts = new TimeSpan(0, 0, _expiredSecond);
                    appmc.CacheExpiredDatetime = DateTime.Now + ts;
                    reader.Close();
                }
                else
                {
                    ae = new ApplicationException("Error ** No record found in RBFX.AppMaster");
                    throw (ae);
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                if (ex.GetType().Equals(ae))
                    conn.Close();
                throw (ex);
            }
            return appmc;
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