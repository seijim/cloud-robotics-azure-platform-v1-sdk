using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CloudRoboticsUtil
{
    public class CustomerInfo
    {
        private ApplicationException ae;
        private string _resourceGroupId = null;
        private string _passPhrase = null;
        private string _sqlConnString = null;
        private int _expiredSecond = RbAppCacheType.DefaultCachingTimeSec;

        public CustomerInfo(string resourceGroupId, string passPhrase, string sqlConnString)
        {
            _resourceGroupId = resourceGroupId;
            _passPhrase = passPhrase;
            _sqlConnString = sqlConnString;
        }
        public CustomerInfo(string resourceGroupId, string passPhrase, string sqlConnString, int expiredSecond)
        {
            _resourceGroupId = resourceGroupId;
            _passPhrase = passPhrase;
            _sqlConnString = sqlConnString;
            _expiredSecond = expiredSecond;
        }
        public RbCustomerRescCache GetCustomerResource()
        {
            RbCustomerRescCache custresc = new RbCustomerRescCache();
            string sqltext = "SELECT CustomerId,ResourceGroupId,"
                + "CONVERT(NVARCHAR(1000),DecryptByPassphrase(@passPhrase,SqlConnectionStringEnc,1,CONVERT(varbinary,ResourceGroupId))) AS SqlConnectionString,"
                + "[Description],Registered_DateTime "
                + "FROM RBFX.CustomerResource WHERE ResourceGroupId = @p1";
            SqlConnection conn = new SqlConnection(_sqlConnString);
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sqltext, conn);
                AddSqlParameter(ref cmd, "@p1", SqlDbType.NVarChar, _resourceGroupId);
                AddSqlParameter(ref cmd, "@passPhrase", SqlDbType.NVarChar, _passPhrase);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    custresc.CustomerId = reader.GetString(0);
                    custresc.ResourceGroupId = reader.GetString(1);
                    custresc.SqlConnectionString = reader.GetString(2);
                    custresc.Description = reader.GetString(3);
                    custresc.Registered_DateTime = reader.GetDateTime(4);
                    TimeSpan ts = new TimeSpan(0, 0, _expiredSecond);
                    custresc.CacheExpiredDatetime = DateTime.Now + ts;
                    reader.Close();
                }
                else
                {
                    ae = new ApplicationException("Error ** No record found in RBFX.CustomerResource");
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
            return custresc;
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
