using Microsoft.Azure.Devices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CloudRoboticsDefTool
{
    public partial class DeviceUpdateForm : Form
    {
        private RegistryManager registryManager;
        private string selectedDeviceID;
        private int devicesMaxCount;
        private string sqlConnectionString;

        private string lastValidPrimaryKey;
        private string lastValidSecondaryKey;

        public DeviceUpdateForm(RegistryManager manager, int maxDevices, string deviceID, string sqlConnectionString)
        {
            InitializeComponent();
            this.registryManager = manager;
            this.devicesMaxCount = maxDevices;
            this.selectedDeviceID = deviceID;
            this.sqlConnectionString = sqlConnectionString;
            updateControls(deviceID);
        }

        private async void updateControls(string selectedDevice)
        {
            List<string> deviceIds = new List<string>();
            try
            {
                var devices = await registryManager.GetDevicesAsync(devicesMaxCount);
                foreach (var device in devices)
                {
                    deviceIds.Add(device.Id);
                }
                this.deviceIDComboBox.DataSource = deviceIds.OrderBy(c => c).ToList();

                // To capture the deviceId highlighted in the DataGridView
                foreach (var item in this.deviceIDComboBox.Items)
                {
                    if (item.ToString() == selectedDevice)
                    {
                        deviceIDComboBox.SelectedItem = item;
                        break;
                    }
                }
                foreach (var device in devices)
                {
                    if (device.Id == selectedDevice)
                    {
                        primaryKeyTextBox.Text = device.Authentication.SymmetricKey.PrimaryKey;
                        secondaryKeyTextBox.Text = device.Authentication.SymmetricKey.SecondaryKey;
                        lastValidPrimaryKey = primaryKeyTextBox.Text;
                        lastValidSecondaryKey = secondaryKeyTextBox.Text;
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void updateButton_Click(object sender, EventArgs e)
        {
            try
            {
                var devices = await registryManager.GetDevicesAsync(devicesMaxCount);
                Device updatedDevice = null;
                foreach (var device in devices)
                {
                    if (device.Id == selectedDeviceID)
                    {
                        updatedDevice = device;
                        break;
                    }
                }

                if (updatedDevice != null)
                {
                    // IoT Hub Device
                    updatedDevice.Authentication.SymmetricKey.PrimaryKey = primaryKeyTextBox.Text;
                    updatedDevice.Authentication.SymmetricKey.SecondaryKey = secondaryKeyTextBox.Text;
                    await registryManager.UpdateDeviceAsync(updatedDevice, true);
                    MessageBox.Show("Device updated successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // RBFX Device Master
                    var deviceEntity = new DeviceEntity();
                    deviceEntity.Id = updatedDevice.Id;
                    deviceEntity.DevM_DeviceType = comboBoxDevMDeviceType.Text;
                    deviceEntity.DevM_Status = comboBoxDevMStatus.Text;
                    deviceEntity.DevM_ResourceGroupId = textBoxDevMRescGrpId.Text;
                    deviceEntity.DevM_Description = textBoxDevMDesc.Text;
                    deviceEntity.DevM_Registered_DateTime = DateTime.Now;
                    var dmi = new DeviceMasterInfo(sqlConnectionString,deviceEntity);
                    dmi.UpdateDevice();

                    this.Close();
                }
                else
                {
                    MessageBox.Show("Device not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void deviceIDComboBox_DropDownClosed(object sender, EventArgs e)
        {
            updateControls(this.deviceIDComboBox.SelectedItem.ToString());
        }

        private async void DeviceUpdateForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            await registryManager.CloseAsync();
        }

        private void restoreButton_Click(object sender, EventArgs e)
        {
            primaryKeyTextBox.Text = lastValidPrimaryKey;
            secondaryKeyTextBox.Text = lastValidSecondaryKey;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DeviceUpdateForm_Load(object sender, EventArgs e)
        {
            var deviceEntity = new DeviceEntity();
            deviceEntity.Id = selectedDeviceID;
            var dmi = new DeviceMasterInfo(sqlConnectionString, deviceEntity);
            deviceEntity = dmi.FillDeviceMasterInfo();

            comboBoxDevMDeviceType.DataSource = CRoboticsConst.DeviceTypeList;
            comboBoxDevMDeviceType.Text = deviceEntity.DevM_DeviceType;
            comboBoxDevMStatus.DataSource = CRoboticsConst.StatusList;
            comboBoxDevMStatus.Text = deviceEntity.DevM_Status;
            textBoxDevMRescGrpId.Text = deviceEntity.DevM_ResourceGroupId;
            textBoxDevMDesc.Text = deviceEntity.DevM_Description;
        }

        private void DeviceUpdateForm_Activated(object sender, EventArgs e)
        {
            deviceIDComboBox.Focus();
        }
    }
}
