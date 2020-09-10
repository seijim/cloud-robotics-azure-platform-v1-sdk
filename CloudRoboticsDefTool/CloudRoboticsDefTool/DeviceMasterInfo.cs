using System;
using System.Data.SqlClient;
using System.Data;

namespace CloudRoboticsDefTool
{
    public class DeviceMasterInfo
    {
        private string sqlConnectionString;
        private DeviceEntity deviceEntity;
        private ApplicationException ae;

        public DeviceMasterInfo(string sqlConnectionString, DeviceEntity deviceEntity)
        {
            this.sqlConnectionString = sqlConnectionString;
            this.deviceEntity = deviceEntity;
        }

        public void CreateDevice()
        {
            string sqltext = "INSERT INTO RBFX.DeviceMaster "
                           + "(DeviceId,DeviceType,[Status],ResourceGroupId,[Description],Registered_DateTime) "
                           + "VALUES (@p1,@p2,@p3,@p4,@p5,@p6)";
            SqlConnection conn = new SqlConnection(this.sqlConnectionString);
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sqltext, conn);
                AddSqlParameter(ref cmd, "@p1", SqlDbType.NVarChar, deviceEntity.Id);
                AddSqlParameter(ref cmd, "@p2", SqlDbType.NVarChar, deviceEntity.DevM_DeviceType);
                AddSqlParameter(ref cmd, "@p3", SqlDbType.VarChar, deviceEntity.DevM_Status);
                AddSqlParameter(ref cmd, "@p4", SqlDbType.VarChar, deviceEntity.DevM_ResourceGroupId);
                AddSqlParameter(ref cmd, "@p5", SqlDbType.NVarChar, deviceEntity.DevM_Description);
                AddSqlParameter(ref cmd, "@p6", SqlDbType.DateTime, deviceEntity.DevM_Registered_DateTime);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch(Exception ex)
            {
                ApplicationException ae = new ApplicationException("** Error ** Operation --> INSERT INTO RBFX.DeviceMaster", ex);
                throw ae;
            }
        }

        public void RemoveDevice()
        {
            string sqltext = "DELETE FROM RBFX.DeviceMaster WHERE DeviceId = @p1";

            SqlConnection conn = new SqlConnection(this.sqlConnectionString);
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sqltext, conn);
                AddSqlParameter(ref cmd, "@p1", SqlDbType.NVarChar, deviceEntity.Id);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                ApplicationException ae = new ApplicationException("** Error ** Operation --> DELETE FROM RBFX.DeviceMaster", ex);
                throw ae;
            }
        }

        public void UpdateDevice()
        {
            string sqltext = "SELECT DeviceId "
                           + "FROM RBFX.DeviceMaster WHERE DeviceId = @p1";

            string sqltext2 = "UPDATE RBFX.DeviceMaster SET "
                    + "DeviceType = @p2,[Status] = @p3,ResourceGroupId = @p4,[Description] = @p5,Registered_DateTime = @p6 "
                    + "WHERE DeviceId = @p1";

            SqlConnection conn = new SqlConnection(this.sqlConnectionString);
            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(sqltext, conn);
                AddSqlParameter(ref cmd, "@p1", SqlDbType.NVarChar, deviceEntity.Id);
                SqlDataReader reader = cmd.ExecuteReader();

                if (!reader.HasRows)
                {
                    reader.Close();
                    conn.Close();
                    CreateDevice();
                    return;
                }
                reader.Close();

                SqlCommand cmd2 = new SqlCommand(sqltext2, conn);
                AddSqlParameter(ref cmd2, "@p1", SqlDbType.NVarChar, deviceEntity.Id);
                AddSqlParameter(ref cmd2, "@p2", SqlDbType.NVarChar, deviceEntity.DevM_DeviceType);
                AddSqlParameter(ref cmd2, "@p3", SqlDbType.VarChar, deviceEntity.DevM_Status);
                AddSqlParameter(ref cmd2, "@p4", SqlDbType.VarChar, deviceEntity.DevM_ResourceGroupId);
                AddSqlParameter(ref cmd2, "@p5", SqlDbType.NVarChar, deviceEntity.DevM_Description);
                AddSqlParameter(ref cmd2, "@p6", SqlDbType.DateTime, deviceEntity.DevM_Registered_DateTime);
                cmd2.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                throw ex;
            }
        }

        public DeviceEntity FillDeviceMasterInfo()
        {
            string sqltext = "SELECT DeviceType,[Status],ResourceGroupId,[Description],Registered_DateTime "
                           + "FROM RBFX.DeviceMaster WHERE DeviceId = @p1";

            SqlConnection conn = new SqlConnection(this.sqlConnectionString);
            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(sqltext, conn);
                AddSqlParameter(ref cmd, "@p1", SqlDbType.NVarChar, deviceEntity.Id);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();

                    if (reader.IsDBNull(0))
                    {
                        deviceEntity.DevM_DeviceType = string.Empty;
                    }
                    else
                    {
                        deviceEntity.DevM_DeviceType = reader.GetString(0);
                    }

                    deviceEntity.DevM_Status = reader.GetString(1);

                    if (reader.IsDBNull(2))
                    {
                        deviceEntity.DevM_ResourceGroupId = string.Empty;
                    }
                    else
                    {
                        deviceEntity.DevM_ResourceGroupId = reader.GetString(2);
                    }

                    if (reader.IsDBNull(3))
                    {
                        deviceEntity.DevM_Description = string.Empty;
                    }
                    else
                    {
                        deviceEntity.DevM_Description = reader.GetString(3);
                    }

                    if (!reader.IsDBNull(4))
                    {
                        deviceEntity.DevM_Registered_DateTime = reader.GetDateTime(4);
                    }

                    reader.Close();
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

            return deviceEntity;
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
