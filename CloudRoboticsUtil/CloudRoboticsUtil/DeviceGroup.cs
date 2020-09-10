using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace CloudRoboticsUtil
{
    public class DeviceGroup
    {
        private string _sqlConnString = null;
        private string _deviceGroupId = null;
        private ApplicationException ae = null;

        public DeviceGroup(string deviceGroupId, string sqlConnString)
        {
            _deviceGroupId = deviceGroupId;
            _sqlConnString = sqlConnString;
        }
        public List<string> GetDeviceGroupList()
        {
            List<string> deviceList = new List<string>();
            string sqltext = "SELECT DeviceId FROM RBFX.DeviceGroup WHERE DeviceGroupId = @p1";

            SqlConnection conn = new SqlConnection(_sqlConnString);
            try
            {
                conn.Open();
                SqlCommand cmd1 = new SqlCommand(sqltext, conn);
                AddSqlParameter(ref cmd1, "@p1", SqlDbType.NVarChar, _deviceGroupId);
                SqlDataReader reader = cmd1.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        deviceList.Add(reader.GetString(0));
                    }
                    reader.Close();
                }
                else
                {
                    ae = new ApplicationException("Error ** No record found in RBFX.DeviceGroup");
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

            return deviceList;
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
