using Microsoft.Azure.Devices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CloudRoboticsDefTool
{
    public class DevicesProcessor
    {
        private List<DeviceEntity> listOfDevices;
        private RegistryManager registryManager;
        private String iotHubConnectionString;
        private String sqlConnectionString;
        private int maxCountOfDevices;
        private String protocolGatewayHostName;

        public DevicesProcessor(string iotHubConnenctionString, string sqlConnectionString,int devicesCount, string protocolGatewayName)
        {
            this.listOfDevices = new List<DeviceEntity>();
            this.iotHubConnectionString = iotHubConnenctionString;
            this.sqlConnectionString = sqlConnectionString;
            this.maxCountOfDevices = devicesCount;
            this.protocolGatewayHostName = protocolGatewayName;
            this.registryManager = RegistryManager.CreateFromConnectionString(iotHubConnectionString);
        }

        public async Task<List<DeviceEntity>> GetDevices()
        {
            try
            {
                DeviceEntity deviceEntity;
                var devices = await registryManager.GetDevicesAsync(maxCountOfDevices);

                if (devices != null)
                {
                    foreach (var device in devices)
                    {
                        deviceEntity = new DeviceEntity()
                        {
                            Id = device.Id,
                            ConnectionState = device.ConnectionState.ToString(),
                            ConnectionString = CreateDeviceConnectionString(device),
                            LastActivityTime = device.LastActivityTime,
                            LastConnectionStateUpdatedTime = device.ConnectionStateUpdatedTime,
                            LastStateUpdatedTime = device.StatusUpdatedTime,
                            MessageCount = device.CloudToDeviceMessageCount,
                            State = device.Status.ToString(),
                            SuspensionReason = device.StatusReason
                        };

                        if (device.Authentication != null &&
                            device.Authentication.SymmetricKey != null)
                        {
                            deviceEntity.PrimaryKey = device.Authentication.SymmetricKey.PrimaryKey;
                            deviceEntity.SecondaryKey = device.Authentication.SymmetricKey.SecondaryKey;
                        }

                        DeviceMasterInfo dmi = new DeviceMasterInfo(sqlConnectionString, deviceEntity);
                        try
                        {
                            deviceEntity = dmi.FillDeviceMasterInfo();
                        }
                        catch(Exception ex)
                        {
                            deviceEntity.DevM_DeviceType = "*****";
                            deviceEntity.DevM_Status = "*****";
                            deviceEntity.DevM_ResourceGroupId = "*****";
                            deviceEntity.DevM_Description = "*****";
                        }

                        listOfDevices.Add(deviceEntity);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return listOfDevices;
        }

        private String CreateDeviceConnectionString(Device device)
        {
            StringBuilder deviceConnectionString = new StringBuilder();

            var hostName = String.Empty;
            var tokenArray = iotHubConnectionString.Split(';');
            for (int i = 0; i < tokenArray.Length; i++)
            {
                var keyValueArray = tokenArray[i].Split('=');
                if (keyValueArray[0] == "HostName")
                {
                    hostName = tokenArray[i] + ';';
                    break;
                }
            }

            if (!String.IsNullOrWhiteSpace(hostName))
            {
                deviceConnectionString.Append(hostName);
                deviceConnectionString.AppendFormat("DeviceId={0}", device.Id);

                if (device.Authentication != null &&
                    device.Authentication.SymmetricKey != null)
                {
                    deviceConnectionString.AppendFormat(";SharedAccessKey={0}", device.Authentication.SymmetricKey.PrimaryKey);
                }

                if (this.protocolGatewayHostName.Length > 0)
                {
                    deviceConnectionString.AppendFormat(";GatewayHostName=ssl://{0}:8883", this.protocolGatewayHostName);
                }
            }

            return deviceConnectionString.ToString();
        }
        // For testing without connecting to a live service
    }
}
