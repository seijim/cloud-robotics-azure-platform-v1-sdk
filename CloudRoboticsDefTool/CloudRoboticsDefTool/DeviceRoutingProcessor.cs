using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;

namespace CloudRoboticsDefTool
{
    class DeviceRoutingProcessor
    {
        private string sqlConnectionString;
        private ApplicationException ae = null;

        public DeviceRoutingProcessor(string sqlConnectionString)
        {
            this.sqlConnectionString = sqlConnectionString;
        }

        public List<DeviceRoutingEntity> GetDeviceRoutings(string deviceId)
        {
            deviceId = deviceId.Replace("*", "%");

            string sqltext = "SELECT DeviceId,RoutingKeyword,TargetType,TargetDeviceGroupId,TargetDeviceId,"
                           + "Status,Description,Registered_DateTime "
                           + "FROM RBFX.DeviceRouting "
                           + "WHERE DeviceId LIKE @p1 ORDER BY DeviceId,RoutingKeyword";

            List<DeviceRoutingEntity> listOfDeviceRoutings = new List<DeviceRoutingEntity>();

            SqlConnection conn = new SqlConnection(this.sqlConnectionString);
            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(sqltext, conn);
                AddSqlParameter(ref cmd, "@p1", SqlDbType.NVarChar, deviceId);
                SqlDataReader reader = cmd.ExecuteReader();

                if (!reader.HasRows)
                {
                    ae = new ApplicationException("No record was found in RBFX.DeviceRouting");
                    throw ae;
                }

                while (reader.Read())
                {
                    DeviceRoutingEntity devRoutingEntity = new DeviceRoutingEntity();
                    devRoutingEntity.DeviceId = reader.GetString(0);
                    devRoutingEntity.RoutingKeyword = reader.GetString(1);
                    devRoutingEntity.TargetType = reader.GetString(2);
                    if (!reader.IsDBNull(3))
                    {
                        devRoutingEntity.TargetDeviceGroupId = reader.GetString(3);
                    }
                    else
                    {
                        devRoutingEntity.TargetDeviceGroupId = string.Empty;
                    }

                    if (!reader.IsDBNull(4))
                    {
                        devRoutingEntity.TargetDeviceId = reader.GetString(4);
                    }
                    else
                    {
                        devRoutingEntity.TargetDeviceId = string.Empty;
                    }

                    devRoutingEntity.Status = reader.GetString(5);

                    if (!reader.IsDBNull(6))
                    {
                        devRoutingEntity.Description = reader.GetString(6);
                    }
                    else
                    {
                        devRoutingEntity.Description = string.Empty;
                    }

                    if (!reader.IsDBNull(7))
                    {
                        devRoutingEntity.Registered_DateTime = reader.GetDateTime(7);
                    }

                    listOfDeviceRoutings.Add(devRoutingEntity);
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

            return listOfDeviceRoutings;

        }

        public void insertDeviceRouting(DeviceRoutingEntity devRoutingEntity)
        {
            validateTargetId(devRoutingEntity);

            string sqltext = "INSERT INTO RBFX.DeviceRouting ("
                + "DeviceId,RoutingKeyword,TargetType,TargetDeviceGroupId,TargetDeviceId,"
                + "Status,Description,Registered_DateTime"
                + ") VALUES "
                + "(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8)";

            SqlConnection conn = new SqlConnection(this.sqlConnectionString);
            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(sqltext, conn);
                AddSqlParameter(ref cmd, "@p1", SqlDbType.NVarChar, devRoutingEntity.DeviceId);
                AddSqlParameter(ref cmd, "@p2", SqlDbType.NVarChar, devRoutingEntity.RoutingKeyword);
                AddSqlParameter(ref cmd, "@p3", SqlDbType.NVarChar, devRoutingEntity.TargetType);
                AddSqlParameter(ref cmd, "@p4", SqlDbType.NVarChar, devRoutingEntity.TargetDeviceGroupId);
                AddSqlParameter(ref cmd, "@p5", SqlDbType.NVarChar, devRoutingEntity.TargetDeviceId);
                AddSqlParameter(ref cmd, "@p6", SqlDbType.NVarChar, devRoutingEntity.Status);
                AddSqlParameter(ref cmd, "@p7", SqlDbType.NVarChar, devRoutingEntity.Description);
                AddSqlParameter(ref cmd, "@p8", SqlDbType.DateTime, devRoutingEntity.Registered_DateTime);
                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                throw ex;
            }
        }

        public void updateDeviceRouting(DeviceRoutingEntity devRoutingEntity)
        {
            validateTargetId(devRoutingEntity);

            string sqltext = "UPDATE RBFX.DeviceRouting SET "
                + "TargetType = @p3,"
                + "TargetDeviceGroupId = @p4,"
                + "TargetDeviceId = @p5,"
                + "Status = @p6,"
                + "Description = @p7,"
                + "Registered_DateTime = @p8 "
                + "WHERE DeviceId = @p1 AND RoutingKeyword = @p2";

            SqlConnection conn = new SqlConnection(this.sqlConnectionString);
            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(sqltext, conn);
                AddSqlParameter(ref cmd, "@p1", SqlDbType.NVarChar, devRoutingEntity.DeviceId);
                AddSqlParameter(ref cmd, "@p2", SqlDbType.NVarChar, devRoutingEntity.RoutingKeyword);
                AddSqlParameter(ref cmd, "@p3", SqlDbType.NVarChar, devRoutingEntity.TargetType);
                AddSqlParameter(ref cmd, "@p4", SqlDbType.NVarChar, devRoutingEntity.TargetDeviceGroupId);
                AddSqlParameter(ref cmd, "@p5", SqlDbType.NVarChar, devRoutingEntity.TargetDeviceId);
                AddSqlParameter(ref cmd, "@p6", SqlDbType.NVarChar, devRoutingEntity.Status);
                AddSqlParameter(ref cmd, "@p7", SqlDbType.NVarChar, devRoutingEntity.Description);
                AddSqlParameter(ref cmd, "@p8", SqlDbType.DateTime, devRoutingEntity.Registered_DateTime);
                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                throw ex;
            }
        }

        public void deleteDeviceRouting(string deviceId, string routingKeyword)
        {
            string sqltext = "DELETE FROM RBFX.DeviceRouting WHERE DeviceId = @p1 AND RoutingKeyword = @p2";

            SqlConnection conn = new SqlConnection(this.sqlConnectionString);
            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(sqltext, conn);
                AddSqlParameter(ref cmd, "@p1", SqlDbType.NVarChar, deviceId);
                AddSqlParameter(ref cmd, "@p2", SqlDbType.NVarChar, routingKeyword);
                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                throw ex;
            }
        }

        private void validateTargetId(DeviceRoutingEntity devRoutingEntity)
        {
            if (devRoutingEntity.TargetType == CRoboticsConst.TypeDeviceGroup)
            {
                if (!existDeviceGroupId(devRoutingEntity.TargetDeviceGroupId))
                {
                    ae = new ApplicationException("Input Device Group ID not exist in RBFX.DeviceGroup");
                    throw ae;
                }
            }
            else if (devRoutingEntity.TargetType == CRoboticsConst.TypeDevice)
            {
                if (!existDeviceId(devRoutingEntity.TargetDeviceId))
                {
                    ae = new ApplicationException("Input Device ID not exist in RBFX.DeviceMaster");
                    throw ae;
                }
            }
            else
            {
                ae = new ApplicationException($"Input Target Type must be \"{CRoboticsConst.TypeDeviceGroup}\" or \"{CRoboticsConst.TypeDevice}\"");
                throw ae;
            }
        }

        private bool existDeviceGroupId(string deviceGroupId)
        {
            string sqltext = "SELECT DeviceGroupId FROM RBFX.DeviceGroup WHERE DeviceGroupId = @p1";

            SqlConnection conn = new SqlConnection(this.sqlConnectionString);
            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(sqltext, conn);
                AddSqlParameter(ref cmd, "@p1", SqlDbType.NVarChar, deviceGroupId);
                SqlDataReader reader = cmd.ExecuteReader();

                if (!reader.HasRows)
                {
                    return false;
                }

                reader.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                throw ex;
            }

            return true;
        }

        private bool existDeviceId(string deviceId)
        {
            string sqltext = "SELECT DeviceId FROM RBFX.DeviceMaster WHERE DeviceId = @p1";

            SqlConnection conn = new SqlConnection(this.sqlConnectionString);
            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(sqltext, conn);
                AddSqlParameter(ref cmd, "@p1", SqlDbType.NVarChar, deviceId);
                SqlDataReader reader = cmd.ExecuteReader();

                if (!reader.HasRows)
                {
                    return false;
                }

                reader.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                throw ex;
            }

            return true;
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
