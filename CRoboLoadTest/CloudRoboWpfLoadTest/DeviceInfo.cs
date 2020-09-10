using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.Devices;

namespace CloudRoboWpfLoadTest
{
    public class DeviceInfo
    {
        private List<DeviceEntity> listOfDevices;
        private string iotHubConnectionString;
        private List<string> listOfDeviceNames;

        public DeviceInfo(string iotHubConnectionString, List<string> listOfDeviceNames)
        {
            this.listOfDevices = new List<DeviceEntity>();
            this.iotHubConnectionString = iotHubConnectionString;
            this.listOfDeviceNames = listOfDeviceNames;
        }

        public async Task<List<DeviceEntity>> GetDevices()
        {
            int maxCountOfDevices = 100;
            var registryManager = RegistryManager.CreateFromConnectionString(iotHubConnectionString);

            try
            {
                DeviceEntity deviceEntity;
                var deviceStr = await registryManager.GetDeviceAsync("dev01");
                var devices = await registryManager.GetDevicesAsync(maxCountOfDevices);

                if (devices != null)
                {
                    foreach (var device in devices)
                    {
                        if (listOfDeviceNames.Contains(device.Id))
                        {
                            deviceEntity = new DeviceEntity()
                            {
                                Id = device.Id,
                                ConnectionState = device.ConnectionState.ToString(),
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


                            listOfDevices.Add(deviceEntity);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            listOfDevices.Sort();
            return listOfDevices;
        }
    }
}
