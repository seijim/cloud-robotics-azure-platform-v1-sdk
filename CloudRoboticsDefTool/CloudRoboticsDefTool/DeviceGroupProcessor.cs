using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;

namespace CloudRoboticsDefTool
{
    public class DeviceGroupProcessor
    {
        private string sqlConnectionString;

        public DeviceGroupProcessor(string sqlConnectionString)
        {
            this.sqlConnectionString = sqlConnectionString;
        }

        public List<DeviceGroupEntity> GetDeviceGroups(string deviceGroupId)
        {
            deviceGroupId = deviceGroupId.Replace("*", "%");

            string sqltext = "SELECT DeviceGroupId,DeviceId,Registered_DateTime FROM RBFX.DeviceGroup "
                           + "WHERE DeviceGroupId LIKE @p1 ORDER BY DeviceGroupId,DeviceId";

            ApplicationException ae = null;
            List<DeviceGroupEntity> listOfDeviceGroups = new List<DeviceGroupEntity>();

            SqlConnection conn = new SqlConnection(this.sqlConnectionString);
            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(sqltext, conn);
                AddSqlParameter(ref cmd, "@p1", SqlDbType.NVarChar, deviceGroupId);
                SqlDataReader reader = cmd.ExecuteReader();

                if (!reader.HasRows)
                {
                    ae = new ApplicationException("No record was found in RBFX.DeviceGroup");
                    throw ae;                 
                }

                while(reader.Read())
                {
                    DeviceGroupEntity deviceGroupEntity = new DeviceGroupEntity();
                    deviceGroupEntity.DeviceGroupId = reader.GetString(0);
                    deviceGroupEntity.DeviceId = reader.GetString(1);

                    if (!reader.IsDBNull(2))
                    {
                        deviceGroupEntity.Registered_DateTime = reader.GetDateTime(2);
                    }

                    listOfDeviceGroups.Add(deviceGroupEntity);
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

            return listOfDeviceGroups;
            
        }

        public void deleteDeviceGroup(string deviceGroupId)
        {
            string sqltext = "DELETE FROM RBFX.DeviceGroup WHERE DeviceGroupId = @p1";

            SqlConnection conn = new SqlConnection(this.sqlConnectionString);
            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(sqltext, conn);
                AddSqlParameter(ref cmd, "@p1", SqlDbType.NVarChar, deviceGroupId);
                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch(Exception ex)
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
