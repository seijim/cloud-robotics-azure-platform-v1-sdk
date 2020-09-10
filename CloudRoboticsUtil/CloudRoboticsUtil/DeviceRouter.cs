using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CloudRoboticsUtil
{
    public class DeviceRouter
    {
        private ApplicationException ae;
        private RbHeader _rbh = null;
        private string _sqlConnString = null;

        public DeviceRouter(RbHeader rbh, string sqlConnString)
        {
            _rbh = rbh;
            _sqlConnString = sqlConnString;
        }
        public RbHeader GetDeviceRouting()
        {
            string sqltext1 = "SELECT DeviceType,ResourceGroupId FROM RBFX.DeviceMaster WHERE DeviceId = @p1 "
                + "AND Status = 'Active'";
            string sqltext2 = "SELECT TargetType,TargetDeviceGroupId,TargetDeviceId Status "
                + "FROM RBFX.DeviceRouting WHERE DeviceId = @p1 AND RoutingKeyword = @p2 "
                + "AND Status = 'Active'";
            SqlConnection conn = new SqlConnection(_sqlConnString);
            try
            {
                conn.Open();
                SqlCommand cmd1 = new SqlCommand(sqltext1, conn);
                AddSqlParameter(ref cmd1, "@p1", SqlDbType.NVarChar, _rbh.SourceDeviceId);
                SqlDataReader reader1 = cmd1.ExecuteReader();
                if (reader1.HasRows)
                {
                    reader1.Read();
                    _rbh.SourceDeviceType = reader1.GetString(0);
                    if (reader1.IsDBNull(1))
                    {
                        _rbh.SourceDevRescGroupId = string.Empty;
                    }
                    else
                    {
                        _rbh.SourceDevRescGroupId = reader1.GetString(1);
                    }
                    reader1.Close();

                    SqlCommand cmd2 = new SqlCommand(sqltext2, conn);
                    AddSqlParameter(ref cmd2, "@p1", SqlDbType.NVarChar, _rbh.SourceDeviceId);
                    AddSqlParameter(ref cmd2, "@p2", SqlDbType.NVarChar, _rbh.RoutingKeyword);
                    SqlDataReader reader2 = cmd2.ExecuteReader();
                    if (reader2.HasRows)
                    {
                        reader2.Read();
                        _rbh.TargetType = reader2.GetString(0);
                        if (_rbh.TargetType == "DeviceGroup")
                        {
                            _rbh.TargetDeviceGroupId = reader2.GetString(1);
                            _rbh.TargetDeviceId = string.Empty;
                        }
                        else
                        {
                            _rbh.TargetDeviceGroupId = string.Empty;
                            _rbh.TargetDeviceId = reader2.GetString(2);
                        }
                    }
                    else
                    {
                        ae = new ApplicationException("Error ** No record found in RBFX.DeviceRouter");
                        throw (ae);
                    }
                }
                else
                {
                    ae = new ApplicationException("Error ** No record found in RBFX.DeviceMaster");
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
            return _rbh;
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
