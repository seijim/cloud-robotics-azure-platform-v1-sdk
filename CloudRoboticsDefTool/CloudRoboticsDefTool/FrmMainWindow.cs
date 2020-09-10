using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Azure.Devices;
using Microsoft.Azure.Devices.Common.Security;
using System.Data.SqlClient;

namespace CloudRoboticsDefTool
{
    public partial class FrmMainWindow : Form
    {
        private const int MAX_TTL_VALUE = 365;
        private const int MAX_COUNT_OF_DEVICES = 5000;

        private bool devicesListed = false;
        private static string activeIoTHubConnectionString;
        private string iotHubHostName;
        private static string activeSqlConnectionString;
        private static string activeQStorageConnString;
        private static string activeEncPassPhrase;

        public FrmMainWindow()
        {
            InitializeComponent();
            try
            {
                Properties.Settings.Default.Reload();
                textBoxIoTHubConnString.Text = (string)Properties.Settings.Default["Microsoft_IoTHub_ConnectionString"];
            }
            catch
            {
                textBoxIoTHubConnString.Text = string.Empty;
            }
            try
            {
                Properties.Settings.Default.Reload();
                textBoxSQLConnectionString.Text = (string)Properties.Settings.Default["Microsoft_SqlDb_ConnectionString"];
            }
            catch
            {
                textBoxSQLConnectionString.Text = string.Empty;
            }
            try
            {
                Properties.Settings.Default.Reload();
                textBoxQStorageConnString.Text = (string)Properties.Settings.Default["Microsoft_QStorage_ConnectionString"];
            }
            catch
            {
                textBoxQStorageConnString.Text = string.Empty;
            }

            numericUpDownTTL.Value = MAX_TTL_VALUE;
            numericUpDownTTL.Maximum = MAX_TTL_VALUE;
        }

        private void FrmMainWindow_Shown(object sender, EventArgs e)
        {
            try
            {
                //Setting the second optional parameter to false will prevent the parsing functions from processing empty strings
                parseIoTHubConnectionString(textBoxIoTHubConnString.Text, true);
                activeSqlConnectionString = textBoxSQLConnectionString.Text;
                activeQStorageConnString = textBoxQStorageConnString.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Device Explorer does not yet contain valid connection strings.\nPlease provide valid connection strings then hit [Update].", $"Attention: {ex.Message}", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void FrmMainWindow_Load(object sender, EventArgs e)
        {
            this.Size = new System.Drawing.Size(800, 600);
        }

        #region Tab Switch
        //-----------------------------------------------------------------------------------
        // Tab Control (Tab Switch)
        //-----------------------------------------------------------------------------------

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            try
            {
                if (e.TabPage == tabDeviceMaster)
                {
                    UpdateListOfDevices();
                }
                else if(e.TabPage == tabDeviceGroup)
                {
                    if (textBoxDeviceGroupId.Text == string.Empty)
                        textBoxDeviceGroupId.Text = "*";

                    updateDeviceGroupsGridView(textBoxDeviceGroupId.Text);
                }
                else if (e.TabPage == tabDeviceRouting)
                {
                    if (textBoxRoutingDeviceId.Text == string.Empty)
                        textBoxRoutingDeviceId.Text = "*";

                    updateDevRoutingsGridView(textBoxRoutingDeviceId.Text);
                }
                else if (e.TabPage == tabAppMaster)
                {
                    if (textBoxAppMasterAppId.Text == string.Empty)
                        textBoxAppMasterAppId.Text = "*";

                    Properties.Settings.Default.Reload();

                    if (Properties.Settings.Default["Microsoft_SqlDb_EncPassphrase"] != null)
                    {
                        activeEncPassPhrase = textBoxEncPassphrase.Text = Properties.Settings.Default["Microsoft_SqlDb_EncPassphrase"].ToString();
                        if (textBoxEncPassphrase.Text != string.Empty)
                            updateAppMastersGridView(textBoxAppMasterAppId.Text, textBoxEncPassphrase.Text);
                    }
                    else
                    {
                        textBoxEncPassphrase.Text = string.Empty;
                    }
                }
                else if (e.TabPage == tabAppRouting)
                {
                    Properties.Settings.Default.Reload();

                    if (Properties.Settings.Default["Microsoft_SqlDb_EncPassphrase"] != null)
                    {
                        activeEncPassPhrase = Properties.Settings.Default["Microsoft_SqlDb_EncPassphrase"].ToString();
                    }

                    if (textBoxAppRoutingAppId.Text == string.Empty)
                        textBoxAppRoutingAppId.Text = "*";

                    updateAppRoutingsGridView(textBoxAppRoutingAppId.Text);
                }
                else if (e.TabPage == tabFxTraceLog)
                {
                    Properties.Settings.Default.Reload();

                    if (Properties.Settings.Default["CloudRoboticsFx_TraceStorageAccount"] != null)
                    {
                        textBoxFxTrcStorgaAccount.Text = Properties.Settings.Default["CloudRoboticsFx_TraceStorageAccount"].ToString();
                    }
                    if (Properties.Settings.Default["CloudRoboticsFx_TraceStorageKey"] != null)
                    {
                        textBoxFxTrcStorgaKey.Text = Properties.Settings.Default["CloudRoboticsFx_TraceStorageKey"].ToString();
                    }
                    if (Properties.Settings.Default["CloudRoboticsFx_TraceTableName"] != null)
                    {
                        textBoxFxTrcTableName.Text = Properties.Settings.Default["CloudRoboticsFx_TraceTableName"].ToString();
                    }

                    if (textBoxFxTraceLogDate.Text == string.Empty)
                        textBoxFxTraceLogDate.Text = System.DateTime.Now.ToString("yyyyMMdd");

                    //updateAppRoutingsGridView(textBoxAppRoutingAppId.Text);
                }
            }
            catch (Exception ex)
            {
                if (!ex.Message.Contains("No record was found"))
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion Tab Switch

        #region Connection Tab
        //-----------------------------------------------------------------------------------
        // Connection Tab
        //-----------------------------------------------------------------------------------

        private void ButtonUpdateIoTConn_Click(object sender, EventArgs e)
        {
            try
            {
                textBoxEndPoint.Text = string.Empty;
                textBoxSAPolicyName.Text = string.Empty;
                textBoxSAKey.Text = string.Empty;
                
                // IoT Hub Connection String
                textBoxIoTHubConnString.Text = sanitizeConnectionString(textBoxIoTHubConnString.Text);
                parseIoTHubConnectionString(textBoxIoTHubConnString.Text);

                // Save the setting
                Properties.Settings.Default["Microsoft_IoTHub_ConnectionString"] = textBoxIoTHubConnString.Text;
                Properties.Settings.Default.Save();

                MessageBox.Show("IoT Hub Connection String saved successfully!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Referesh the device grid if devices were arleady listed:
                if (devicesListed)
                {
                    UpdateListOfDevices();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private string sanitizeConnectionString(string connectionString)
        {
            return connectionString.Trim().Replace("\r", "").Replace("\n", "");
        }

        private void parseIoTHubConnectionString(string connectionString, bool skipException = false)
        {
            try
            {
                var builder = IotHubConnectionStringBuilder.Create(connectionString);
                iotHubHostName = builder.HostName;

                textBoxEndPoint.Text = builder.HostName;
                textBoxSAPolicyName.Text = builder.SharedAccessKeyName;
                textBoxSAKey.Text = builder.SharedAccessKey;

                activeIoTHubConnectionString = connectionString;
            }
            catch (Exception ex)
            {
                if (!skipException)
                {
                    throw new ArgumentException("Invalid IoTHub connection string. " + ex.Message);
                }
            }
        }

        private void buttonUpdateSqlConn_Click(object sender, EventArgs e)
        {
            try
            {
                // SQL Database Connection String
                using (SqlConnection conn = new SqlConnection(textBoxSQLConnectionString.Text))
                {
                    conn.Open();
                }

                // Save the setting
                Properties.Settings.Default["Microsoft_SqlDb_ConnectionString"] = textBoxSQLConnectionString.Text;
                Properties.Settings.Default.Save();

                activeSqlConnectionString = textBoxSQLConnectionString.Text;
                MessageBox.Show("SQL Connection String saved successfully!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void buttonGenerateSAS_Click(object sender, EventArgs e)
        {
            try
            {
                var builder = new SharedAccessSignatureBuilder()
                {
                    KeyName = textBoxSAPolicyName.Text,
                    Key = textBoxSAKey.Text,
                    Target = textBoxEndPoint.Text,
                    TimeToLive = TimeSpan.FromDays(Convert.ToDouble(numericUpDownTTL.Value))
                }.ToSignature();

                textBoxSASValue.Text = builder + Environment.NewLine;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unable to generate SAS. Verify connection strings.\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonUpdateQStorageConnString_Click(object sender, EventArgs e)
        {
            try
            {
                // Device Simulator Exe File Path
                // Save the setting
                Properties.Settings.Default["Microsoft_QStorage_ConnectionString"] = textBoxQStorageConnString.Text;
                Properties.Settings.Default.Save();

                activeQStorageConnString = textBoxQStorageConnString.Text;
                MessageBox.Show("Queue Storage Connection String saved successfully!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }


        #endregion Connection Tab

        #region Device Master Tab
        //-----------------------------------------------------------------------------------
        // Device Master Tab
        //-----------------------------------------------------------------------------------
        private void createDeviceButton_Click(object sender, EventArgs e)
        {
            try
            {
                CreateDeviceForm createForm = new CreateDeviceForm(activeIoTHubConnectionString, activeSqlConnectionString, activeQStorageConnString, MAX_COUNT_OF_DEVICES);
                createForm.ShowDialog();    // Modal window
                UpdateListOfDevices();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unable to create new device. Please verify your connection strings.\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private async void UpdateListOfDevices()
        {
            try
            {
                await updateDevicesGridView();
                devicesListed = true;
                listDevicesButton.Text = "Refresh";
            }
            catch (Exception ex)
            {
                listDevicesButton.Text = "List";
                devicesListed = false;
                MessageBox.Show($"Unable to retrieve list of devices. Please verify your connection strings.\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task updateDevicesGridView()
        {
            var devicesProcessor = new DevicesProcessor(activeIoTHubConnectionString, activeSqlConnectionString, MAX_COUNT_OF_DEVICES, "");
            var devicesList = await devicesProcessor.GetDevices();
            devicesList.Sort();
            var sortableDevicesBindingList = new SortableBindingList<DeviceEntity>(devicesList);

            devicesGridView.DataSource = sortableDevicesBindingList;
            devicesGridView.ReadOnly = true;
            devicesGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            if (devicesList.Count() > MAX_COUNT_OF_DEVICES)
            {
                deviceCountLabel.Text = MAX_COUNT_OF_DEVICES + "+";
            }
            else
            {
                deviceCountLabel.Text = devicesList.Count().ToString();
            }
        }

        private void listDevicesButton_Click(object sender, EventArgs e)
        {
            UpdateListOfDevices();
        }

        private async void updateDeviceButton_Click(object sender, EventArgs e)
        {
            try
            {
                string selectedDeviceId = devicesGridView.CurrentRow.Cells[0].Value.ToString();
                RegistryManager registryManager = RegistryManager.CreateFromConnectionString(activeIoTHubConnectionString);
                DeviceUpdateForm updateForm = new DeviceUpdateForm(registryManager, MAX_COUNT_OF_DEVICES, selectedDeviceId, activeSqlConnectionString);
                updateForm.ShowDialog(this);
                updateForm.Dispose();
                await updateDevicesGridView();
                await registryManager.CloseAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void deleteDeviceButton_Click(object sender, EventArgs e)
        {
            try
            {
                RegistryManager registryManager = RegistryManager.CreateFromConnectionString(activeIoTHubConnectionString);
                string selectedDeviceId = devicesGridView.CurrentRow.Cells[0].Value.ToString();
                var dialogResult = MessageBox.Show($"Are you sure you want to delete the following device?\n[{selectedDeviceId}]", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    // IoT Hub Device
                    await registryManager.RemoveDeviceAsync(selectedDeviceId);
                    MessageBox.Show("Device deleted successfully!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // RBFX Device Master
                    var deviceEntity = new DeviceEntity();
                    deviceEntity.Id = selectedDeviceId;
                    var dmi = new DeviceMasterInfo(activeSqlConnectionString, deviceEntity);
                    dmi.RemoveDevice();

                    await updateDevicesGridView();
                    await registryManager.CloseAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private async void sasTokenButton_Click(object sender, EventArgs e)
        {
            try
            {
                RegistryManager registryManager = RegistryManager.CreateFromConnectionString(activeIoTHubConnectionString);
                SASTokenForm sasForm = new SASTokenForm(registryManager, MAX_COUNT_OF_DEVICES, iotHubHostName);
                sasForm.ShowDialog(this);
                sasForm.Dispose();
                await updateDevicesGridView();
                await registryManager.CloseAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void LaunchSimulatorMenuItem_Click(object sender, EventArgs e)
        {
            string selectedDeviceId = devicesGridView.CurrentRow.Cells[0].Value.ToString();
            string selectedDeviceKey = devicesGridView.CurrentRow.Cells[1].Value.ToString();
            string selectedDeviceType = devicesGridView.CurrentRow.Cells[11].Value.ToString();

            DeviceSimulatorForm deviceSimulatorForm =
                new DeviceSimulatorForm(activeIoTHubConnectionString, iotHubHostName,
                        selectedDeviceId, selectedDeviceKey, selectedDeviceType, activeQStorageConnString);
            deviceSimulatorForm.Show();
        }

        private void copyAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StringBuilder str = new StringBuilder();

            List<string> content = new List<string>();

            for (int i = 0; i < devicesGridView.Columns.Count; i++)
            {
                content.Add(devicesGridView.Columns[i].Name);
            }

            str.Append(String.Join("\t", content));

            for (int i = 0; i < (devicesGridView.Rows.Count - 1); i++)
            {
                content.Clear();

                for (int j = 0; j < devicesGridView.Rows[i].Cells.Count; j++)
                {
                    object obj = devicesGridView.Rows[i].Cells[j].Value;
                    content.Add(obj != null ? obj.ToString() : String.Empty);
                }

                str.AppendLine();
                str.Append(String.Join("\t", content));
            }

            if (str.Length > 0)
            {
                Clipboard.SetText(str.ToString());
            }
        }

        private void copySelectedToolMenuItem_Click(object sender, EventArgs e)
        {
            StringBuilder str = new StringBuilder();

            List<string> content = new List<string>();

            for (int i = 0; i < devicesGridView.Columns.Count; i++)
            {
                content.Add(devicesGridView.Columns[i].Name);
            }

            str.Append(String.Join("\t", content));

            for (int i = 0; i < devicesGridView.SelectedRows.Count; i++)
            {
                content.Clear();

                for (int j = 0; j < devicesGridView.Rows[i].Cells.Count; j++)
                {
                    object obj = devicesGridView.Rows[devicesGridView.SelectedRows[0].Index].Cells[j].Value;
                    content.Add(obj != null ? obj.ToString() : String.Empty);
                }

                str.AppendLine();
                str.Append(String.Join("\t", content));
            }

            if (str.Length > 0)
            {
                Clipboard.SetText(str.ToString());
            }
        }

        private void getDeviceConnectionStringToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (devicesGridView.SelectedRows.Count > 0)
            {
                Clipboard.SetText(devicesGridView.Rows[devicesGridView.SelectedRows[0].Index].Cells[3].Value.ToString());
            }
        }

        #endregion Device Master Tab

        #region Device Group Tab
        //-----------------------------------------------------------------------------------
        // Device Group Tab
        //-----------------------------------------------------------------------------------
        private void listDeviceGrpButton_Click(object sender, EventArgs e)
        {
            string deviceGroupId = textBoxDeviceGroupId.Text;
            if (deviceGroupId == string.Empty)
                textBoxDeviceGroupId.Text = deviceGroupId = "*";

            updateDeviceGroupsGridView(deviceGroupId);
        }

        private void updateDeviceGroupsGridView(string deviceGroupId)
        {
            try
            {
                var deviceGroupProcessor = new DeviceGroupProcessor(activeSqlConnectionString);
                var deviceGroupList = deviceGroupProcessor.GetDeviceGroups(deviceGroupId);

                deviceGroupList.Sort();
                var sortableBindingList = new SortableBindingList<DeviceGroupEntity>(deviceGroupList);

                deviceGroupsGridView.DataSource = sortableBindingList;
                deviceGroupsGridView.ReadOnly = true;
                deviceGroupsGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                deviceGroupCountLabel.Text = deviceGroupList.Count().ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void createDeviceGrpButton_Click(object sender, EventArgs e)
        {
            try
            {
                EditDeviceGroupFrom editForm = new EditDeviceGroupFrom(activeSqlConnectionString);
                editForm.ShowDialog();    // Modal window

                updateDeviceGroupsGridView(textBoxDeviceGroupId.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unable to create new device group.\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void updateDeviceGrpButton_Click(object sender, EventArgs e)
        {
            try
            {
                string selectedDeviceGroupId = deviceGroupsGridView.CurrentRow.Cells[0].Value.ToString();
                EditDeviceGroupFrom editForm = new EditDeviceGroupFrom(activeSqlConnectionString, selectedDeviceGroupId);
                editForm.ShowDialog();    // Modal window

                updateDeviceGroupsGridView(textBoxDeviceGroupId.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unable to update selected device group.\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void deleteDeviceGrpButton_Click(object sender, EventArgs e)
        {
            try
            {
                string selectedDeviceGroupId = deviceGroupsGridView.CurrentRow.Cells[0].Value.ToString();
                DialogResult result = MessageBox.Show($"Do you really delete the device group (\"{selectedDeviceGroupId}\")?", "Information", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.Cancel)
                    return;

                var deviceGroupProcessor = new DeviceGroupProcessor(activeSqlConnectionString);
                deviceGroupProcessor.deleteDeviceGroup(selectedDeviceGroupId);

                updateDeviceGroupsGridView(textBoxDeviceGroupId.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unable to delete selected device group.\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void copyAllToolStripOnGroup_Click(object sender, EventArgs e)
        {
            StringBuilder str = new StringBuilder();

            List<string> content = new List<string>();

            for (int i = 0; i < deviceGroupsGridView.Columns.Count; i++)
            {
                content.Add(deviceGroupsGridView.Columns[i].Name);
            }

            str.Append(String.Join("\t", content));

            for (int i = 0; i < (deviceGroupsGridView.Rows.Count - 1); i++)
            {
                content.Clear();

                for (int j = 0; j < deviceGroupsGridView.Rows[i].Cells.Count; j++)
                {
                    object obj = deviceGroupsGridView.Rows[i].Cells[j].Value;
                    content.Add(obj != null ? obj.ToString() : String.Empty);
                }

                str.AppendLine();
                str.Append(String.Join("\t", content));
            }

            if (str.Length > 0)
            {
                Clipboard.SetText(str.ToString());
            }

        }

        private void copySelectedToolStripOnGroup_Click(object sender, EventArgs e)
        {
            StringBuilder str = new StringBuilder();

            List<string> content = new List<string>();

            for (int i = 0; i < deviceGroupsGridView.Columns.Count; i++)
            {
                content.Add(deviceGroupsGridView.Columns[i].Name);
            }

            str.Append(String.Join("\t", content));

            for (int i = 0; i < deviceGroupsGridView.SelectedRows.Count; i++)
            {
                content.Clear();

                for (int j = 0; j < deviceGroupsGridView.Rows[i].Cells.Count; j++)
                {
                    object obj = deviceGroupsGridView.Rows[deviceGroupsGridView.SelectedRows[0].Index].Cells[j].Value;
                    content.Add(obj != null ? obj.ToString() : String.Empty);
                }

                str.AppendLine();
                str.Append(String.Join("\t", content));
            }

            if (str.Length > 0)
            {
                Clipboard.SetText(str.ToString());
            }
        }

        #endregion Device Group Tab

        #region Device Routing Tab
        //-----------------------------------------------------------------------------------
        // Device Routing Tab
        //-----------------------------------------------------------------------------------
        private void listDevRoutingButton_Click(object sender, EventArgs e)
        {
            string deviceId = textBoxRoutingDeviceId.Text;
            if (deviceId == string.Empty)
                textBoxRoutingDeviceId.Text = deviceId = "*";

            updateDevRoutingsGridView(deviceId);

        }
        private void updateDevRoutingsGridView(string deviceId)
        {
            try
            {
                var devRoutingProcessor = new DeviceRoutingProcessor(activeSqlConnectionString);
                var deviceRoutingList = devRoutingProcessor.GetDeviceRoutings(deviceId);

                deviceRoutingList.Sort();
                var sortableBindingList = new SortableBindingList<DeviceRoutingEntity>(deviceRoutingList);

                devRoutingsGridView.DataSource = sortableBindingList;
                devRoutingsGridView.ReadOnly = true;
                devRoutingsGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                devRoutingCountLabel.Text = deviceRoutingList.Count().ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void createDevRoutingButton_Click(object sender, EventArgs e)
        {
            try
            {
                EditDevRoutingForm editForm = new EditDevRoutingForm(activeSqlConnectionString);
                editForm.ShowDialog();    // Modal window

                string deviceId = textBoxRoutingDeviceId.Text;
                if (deviceId == string.Empty)
                    textBoxRoutingDeviceId.Text = deviceId = "*";
                updateDevRoutingsGridView(deviceId);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unable to create new device routing.\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void updateDevRoutingButton_Click(object sender, EventArgs e)
        {
            try
            {
                DeviceRoutingEntity devRoutingEntity = new DeviceRoutingEntity();
                devRoutingEntity.DeviceId = devRoutingsGridView.CurrentRow.Cells[0].Value.ToString();
                devRoutingEntity.RoutingKeyword = devRoutingsGridView.CurrentRow.Cells[1].Value.ToString();
                devRoutingEntity.TargetType = devRoutingsGridView.CurrentRow.Cells[2].Value.ToString();
                devRoutingEntity.TargetDeviceGroupId = devRoutingsGridView.CurrentRow.Cells[3].Value.ToString();
                devRoutingEntity.TargetDeviceId = devRoutingsGridView.CurrentRow.Cells[4].Value.ToString();
                devRoutingEntity.Status = devRoutingsGridView.CurrentRow.Cells[5].Value.ToString();
                devRoutingEntity.Description = devRoutingsGridView.CurrentRow.Cells[6].Value.ToString();
                if (devRoutingsGridView.CurrentRow.Cells[7].Value != null)
                    devRoutingEntity.Registered_DateTime = (DateTime)devRoutingsGridView.CurrentRow.Cells[7].Value;

                EditDevRoutingForm editForm = new EditDevRoutingForm(activeSqlConnectionString, devRoutingEntity);
                editForm.ShowDialog();    // Modal window

                string deviceId = textBoxRoutingDeviceId.Text;
                if (deviceId == string.Empty)
                    textBoxRoutingDeviceId.Text = deviceId = "*";
                updateDevRoutingsGridView(deviceId);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unable to update selected device routing.\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void deleteDevRoutingButton_Click(object sender, EventArgs e)
        {
            try
            {
                string selectedDeviceId = devRoutingsGridView.CurrentRow.Cells[0].Value.ToString();
                string selectedRoutingKeyword = devRoutingsGridView.CurrentRow.Cells[1].Value.ToString();
                DialogResult result = MessageBox.Show($"Do you really delete the device routing (\"{selectedDeviceId}\",\"{selectedRoutingKeyword}\")?"
                    , "Information", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.Cancel)
                    return;

                var devRoutingProcessor = new DeviceRoutingProcessor(activeSqlConnectionString);
                devRoutingProcessor.deleteDeviceRouting(selectedDeviceId, selectedRoutingKeyword);

                string deviceId = textBoxRoutingDeviceId.Text;
                if (deviceId == string.Empty)
                    textBoxRoutingDeviceId.Text = deviceId = "%";
                updateDevRoutingsGridView(deviceId);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unable to delete selected device routing.\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void copyAllToolStripOnDevRouting_Click(object sender, EventArgs e)
        {
            StringBuilder str = new StringBuilder();

            List<string> content = new List<string>();

            for (int i = 0; i < devRoutingsGridView.Columns.Count; i++)
            {
                content.Add(devRoutingsGridView.Columns[i].Name);
            }

            str.Append(String.Join("\t", content));

            for (int i = 0; i < (devRoutingsGridView.Rows.Count - 1); i++)
            {
                content.Clear();

                for (int j = 0; j < devRoutingsGridView.Rows[i].Cells.Count; j++)
                {
                    object obj = devRoutingsGridView.Rows[i].Cells[j].Value;
                    content.Add(obj != null ? obj.ToString() : String.Empty);
                }

                str.AppendLine();
                str.Append(String.Join("\t", content));
            }

            if (str.Length > 0)
            {
                Clipboard.SetText(str.ToString());
            }
        }

        private void copySelectedToolStripOnDevRouting_Click(object sender, EventArgs e)
        {
            StringBuilder str = new StringBuilder();

            List<string> content = new List<string>();

            for (int i = 0; i < devRoutingsGridView.Columns.Count; i++)
            {
                content.Add(devRoutingsGridView.Columns[i].Name);
            }

            str.Append(String.Join("\t", content));

            for (int i = 0; i < devRoutingsGridView.SelectedRows.Count; i++)
            {
                content.Clear();

                for (int j = 0; j < devRoutingsGridView.Rows[i].Cells.Count; j++)
                {
                    object obj = devRoutingsGridView.Rows[devRoutingsGridView.SelectedRows[0].Index].Cells[j].Value;
                    content.Add(obj != null ? obj.ToString() : String.Empty);
                }

                str.AppendLine();
                str.Append(String.Join("\t", content));
            }

            if (str.Length > 0)
            {
                Clipboard.SetText(str.ToString());
            }
        }

        #endregion Device Routing Tab


        #region App Master Tab
        //-----------------------------------------------------------------------------------
        // App Master Tab
        //-----------------------------------------------------------------------------------

        private void saveEncPassphraseButton_Click(object sender, EventArgs e)
        {
            // Passphrase of SQL Encryption Function
            try
            {
                if (textBoxEncPassphrase.Text == string.Empty)
                {
                    MessageBox.Show("Encryption Passphrase must be set !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Save the setting
                Properties.Settings.Default["Microsoft_SqlDb_EncPassphrase"] = textBoxEncPassphrase.Text;
                Properties.Settings.Default.Save();
                activeEncPassPhrase = textBoxEncPassphrase.Text;

                MessageBox.Show("Passphrase saved successfully!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Referesh the device grid
                if (devicesListed)
                {
                    UpdateListOfDevices();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void listAppMasterButton_Click(object sender, EventArgs e)
        {
            if (textBoxAppMasterAppId.Text == string.Empty)
                textBoxAppMasterAppId.Text = "*";
            updateAppMastersGridView(textBoxAppMasterAppId.Text, textBoxEncPassphrase.Text);

        }

        private void updateAppMastersGridView(string appId, string encPassPhrase)
        {
            try
            {
                var appMasterProcessor = new AppMasterProcessor(activeSqlConnectionString, encPassPhrase);
                var appMasterList = appMasterProcessor.GetAppMasters(appId);

                appMasterList.Sort();
                var sortableBindingList = new SortableBindingList<AppMasterEntity>(appMasterList);

                appMastersGridView.DataSource = sortableBindingList;
                appMastersGridView.ReadOnly = true;
                appMastersGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                appMasterCountLabel.Text = appMasterList.Count().ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void createAppMasterButton_Click(object sender, EventArgs e)
        {
            try
            {
                EditAppMasterForm editForm = new EditAppMasterForm(activeSqlConnectionString, textBoxEncPassphrase.Text);
                editForm.ShowDialog();    // Modal window

                if (textBoxAppMasterAppId.Text == string.Empty)
                    textBoxAppMasterAppId.Text = "*";
                updateAppMastersGridView(textBoxAppMasterAppId.Text, textBoxEncPassphrase.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unable to create new app master.\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void updateAppMasterButton_Click(object sender, EventArgs e)
        {
            try
            {
                AppMasterEntity appMasterEntity = new AppMasterEntity();
                appMasterEntity.AppId = appMastersGridView.CurrentRow.Cells[0].Value.ToString();
                appMasterEntity.StorageAccount = appMastersGridView.CurrentRow.Cells[1].Value.ToString();
                appMasterEntity.StorageKey = appMastersGridView.CurrentRow.Cells[2].Value.ToString();
                appMasterEntity.AppInfo = appMastersGridView.CurrentRow.Cells[3].Value.ToString();
                appMasterEntity.AppInfoDevice = appMastersGridView.CurrentRow.Cells[4].Value.ToString();
                appMasterEntity.Status = appMastersGridView.CurrentRow.Cells[5].Value.ToString();
                appMasterEntity.Description = appMastersGridView.CurrentRow.Cells[6].Value.ToString();
                if (appMastersGridView.CurrentRow.Cells[7].Value != null)
                    appMasterEntity.Registered_DateTime = (DateTime)appMastersGridView.CurrentRow.Cells[7].Value;

                EditAppMasterForm editForm = new EditAppMasterForm(activeSqlConnectionString, textBoxEncPassphrase.Text, appMasterEntity);
                editForm.ShowDialog();    // Modal window

                if (textBoxAppMasterAppId.Text == string.Empty)
                    textBoxAppMasterAppId.Text = "*";
                updateAppMastersGridView(textBoxAppMasterAppId.Text, textBoxEncPassphrase.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unable to update selected app master.\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void deleteAppMasterButton_Click(object sender, EventArgs e)
        {
            try
            {
                string selectedAppId = appMastersGridView.CurrentRow.Cells[0].Value.ToString();
                DialogResult result = MessageBox.Show($"Do you really delete the device routing (\"{selectedAppId}\")?"
                    , "Information", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.Cancel)
                    return;

                var appMasterProcessor = new AppMasterProcessor(activeSqlConnectionString, string.Empty);
                appMasterProcessor.deleteAppMaster(selectedAppId);

                if (textBoxAppMasterAppId.Text == string.Empty)
                    textBoxAppMasterAppId.Text = "*";
                updateAppMastersGridView(textBoxAppMasterAppId.Text, textBoxEncPassphrase.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unable to delete selected app master.\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void copyAllToolStripOnAppMaster_Click(object sender, EventArgs e)
        {
            StringBuilder str = new StringBuilder();

            List<string> content = new List<string>();

            for (int i = 0; i < appMastersGridView.Columns.Count; i++)
            {
                content.Add(appMastersGridView.Columns[i].Name);
            }

            str.Append(String.Join("\t", content));

            for (int i = 0; i < (appMastersGridView.Rows.Count - 1); i++)
            {
                content.Clear();

                for (int j = 0; j < appMastersGridView.Rows[i].Cells.Count; j++)
                {
                    object obj = appMastersGridView.Rows[i].Cells[j].Value;
                    content.Add(obj != null ? obj.ToString() : String.Empty);
                }

                str.AppendLine();
                str.Append(String.Join("\t", content));
            }

            if (str.Length > 0)
            {
                Clipboard.SetText(str.ToString());
            }

        }

        private void copySelectedToolStripOnAppMaster_Click(object sender, EventArgs e)
        {
            StringBuilder str = new StringBuilder();

            List<string> content = new List<string>();

            for (int i = 0; i < appMastersGridView.Columns.Count; i++)
            {
                content.Add(appMastersGridView.Columns[i].Name);
            }

            str.Append(String.Join("\t", content));

            for (int i = 0; i < appMastersGridView.SelectedRows.Count; i++)
            {
                content.Clear();

                for (int j = 0; j < appMastersGridView.Rows[i].Cells.Count; j++)
                {
                    object obj = appMastersGridView.Rows[appMastersGridView.SelectedRows[0].Index].Cells[j].Value;
                    content.Add(obj != null ? obj.ToString() : String.Empty);
                }

                str.AppendLine();
                str.Append(String.Join("\t", content));
            }

            if (str.Length > 0)
            {
                Clipboard.SetText(str.ToString());
            }

        }

        #endregion App Master Tab


        #region App Routing Tab
        //-----------------------------------------------------------------------------------
        // App Routing Tab
        //-----------------------------------------------------------------------------------

        private void listAppRoutingButton_Click(object sender, EventArgs e)
        {
            if (textBoxAppRoutingAppId.Text == string.Empty)
                textBoxAppRoutingAppId.Text = "*";
            updateAppRoutingsGridView(textBoxAppRoutingAppId.Text);

        }

        private void updateAppRoutingsGridView(string appId)
        {
            try
            {
                var appRoutingProcessor = new AppRoutingProcessor(activeSqlConnectionString);
                var appRoutingList = appRoutingProcessor.GetAppRoutings(appId);

                appRoutingList.Sort();
                var sortableBindingList = new SortableBindingList<AppRoutingEntity>(appRoutingList);

                appRoutingsGridView.DataSource = sortableBindingList;
                appRoutingsGridView.ReadOnly = true;
                appRoutingsGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                appRoutingCountLabel.Text = appRoutingList.Count().ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void createAppRoutingButton_Click(object sender, EventArgs e)
        {
            try
            {
                EditAppRoutingForm editForm = new EditAppRoutingForm(activeSqlConnectionString, activeEncPassPhrase);
                editForm.ShowDialog();    // Modal window

                if (textBoxAppRoutingAppId.Text == string.Empty)
                    textBoxAppRoutingAppId.Text = "*";
                updateAppRoutingsGridView(textBoxAppRoutingAppId.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unable to create new app routing.\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void updateAppRoutingButton_Click(object sender, EventArgs e)
        {
            try
            {
                AppRoutingEntity appRoutingEntity = new AppRoutingEntity();
                appRoutingEntity.AppId = appRoutingsGridView.CurrentRow.Cells[0].Value.ToString();
                appRoutingEntity.AppProcessingId = appRoutingsGridView.CurrentRow.Cells[1].Value.ToString();
                appRoutingEntity.BlobContainer = appRoutingsGridView.CurrentRow.Cells[2].Value.ToString();
                appRoutingEntity.FileName = appRoutingsGridView.CurrentRow.Cells[3].Value.ToString();
                appRoutingEntity.ClassName = appRoutingsGridView.CurrentRow.Cells[4].Value.ToString();
                appRoutingEntity.Status = appRoutingsGridView.CurrentRow.Cells[5].Value.ToString();
                appRoutingEntity.DevMode = appRoutingsGridView.CurrentRow.Cells[6].Value.ToString();
                appRoutingEntity.DevLocalDir = appRoutingsGridView.CurrentRow.Cells[7].Value.ToString();
                appRoutingEntity.Description = appRoutingsGridView.CurrentRow.Cells[8].Value.ToString();
                if (appRoutingsGridView.CurrentRow.Cells[9].Value != null)
                    appRoutingEntity.Registered_DateTime = (DateTime)appRoutingsGridView.CurrentRow.Cells[9].Value;

                EditAppRoutingForm editForm = new EditAppRoutingForm(activeSqlConnectionString, activeEncPassPhrase, appRoutingEntity);
                editForm.ShowDialog();    // Modal window

                if (textBoxAppRoutingAppId.Text == string.Empty)
                    textBoxAppRoutingAppId.Text = "*";
                updateAppRoutingsGridView(textBoxAppRoutingAppId.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unable to update selected app routing.\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void deleteAppRoutingButton_Click(object sender, EventArgs e)
        {
            try
            {
                string selectedAppId = appRoutingsGridView.CurrentRow.Cells[0].Value.ToString();
                string selectedAppProcessingId = appRoutingsGridView.CurrentRow.Cells[1].Value.ToString();
                DialogResult result = MessageBox.Show($"Do you really delete the device routing (\"{selectedAppId}\",\"{selectedAppProcessingId}\")?"
                    , "Information", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.Cancel)
                    return;

                var appRoutingProcessor = new AppRoutingProcessor(activeSqlConnectionString);
                appRoutingProcessor.deleteAppRouting(selectedAppId, selectedAppProcessingId);

                if (textBoxAppRoutingAppId.Text == string.Empty)
                    textBoxAppRoutingAppId.Text = "*";
                updateAppRoutingsGridView(textBoxAppRoutingAppId.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unable to delete selected app routing.\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void copyAllToolStripOnAppRouting_Click(object sender, EventArgs e)
        {
            StringBuilder str = new StringBuilder();

            List<string> content = new List<string>();

            for (int i = 0; i < appRoutingsGridView.Columns.Count; i++)
            {
                content.Add(appRoutingsGridView.Columns[i].Name);
            }

            str.Append(String.Join("\t", content));

            for (int i = 0; i < (appRoutingsGridView.Rows.Count - 1); i++)
            {
                content.Clear();

                for (int j = 0; j < appRoutingsGridView.Rows[i].Cells.Count; j++)
                {
                    object obj = appRoutingsGridView.Rows[i].Cells[j].Value;
                    content.Add(obj != null ? obj.ToString() : String.Empty);
                }

                str.AppendLine();
                str.Append(String.Join("\t", content));
            }

            if (str.Length > 0)
            {
                Clipboard.SetText(str.ToString());
            }
        }

        private void copySelectedToolStripOnAppRouting_Click(object sender, EventArgs e)
        {
            StringBuilder str = new StringBuilder();

            List<string> content = new List<string>();

            for (int i = 0; i < appRoutingsGridView.Columns.Count; i++)
            {
                content.Add(appRoutingsGridView.Columns[i].Name);
            }

            str.Append(String.Join("\t", content));

            for (int i = 0; i < appRoutingsGridView.SelectedRows.Count; i++)
            {
                content.Clear();

                for (int j = 0; j < appRoutingsGridView.Rows[i].Cells.Count; j++)
                {
                    object obj = appRoutingsGridView.Rows[appRoutingsGridView.SelectedRows[0].Index].Cells[j].Value;
                    content.Add(obj != null ? obj.ToString() : String.Empty);
                }

                str.AppendLine();
                str.Append(String.Join("\t", content));
            }

            if (str.Length > 0)
            {
                Clipboard.SetText(str.ToString());
            }
        }


        #endregion App Routing Tab

        #region Cloud Robotics FX Trace Log Tab
        //-----------------------------------------------------------------------------------
        // Device Master Tab
        //-----------------------------------------------------------------------------------

        private void listFxTraceLogButton_Click(object sender, EventArgs e)
        {
            // Save the setting
            Properties.Settings.Default["CloudRoboticsFx_TraceStorageAccount"] = textBoxFxTrcStorgaAccount.Text;
            Properties.Settings.Default["CloudRoboticsFx_TraceStorageKey"] = textBoxFxTrcStorgaKey.Text;
            Properties.Settings.Default["CloudRoboticsFx_TraceTableName"] = textBoxFxTrcTableName.Text;
            Properties.Settings.Default.Save();

            updateFxTraceLogGridView(textBoxFxTraceLogDate.Text);
        }

        private void updateFxTraceLogGridView(string dateString)
        {
            try
            {
                var fxTraceLogProcessor =
                    new FxTraceLogProcessor(textBoxFxTrcStorgaAccount.Text, textBoxFxTrcStorgaKey.Text, textBoxFxTrcTableName.Text);
                var fxTraceLogsList = fxTraceLogProcessor.GetFxTraceLogs(dateString);

                SortableBindingList<FxTraceLogDsiplayEntity> sortableBindingList;

                if (checkBoxFxTrcDesc.Checked)
                {
                    var entities = from a in fxTraceLogsList
                                   orderby a.RowKey descending
                                   select a;
                    sortableBindingList = new SortableBindingList<FxTraceLogDsiplayEntity>(entities);
                }
                else
                {
                    var entities = from a in fxTraceLogsList
                                   orderby a.RowKey
                                   select a;
                    sortableBindingList = new SortableBindingList<FxTraceLogDsiplayEntity>(entities);
                }

                fxTraceLogGridView.DataSource = sortableBindingList;
                fxTraceLogGridView.ReadOnly = true;
                fxTraceLogGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                fxTraceLogCountLabel.Text = fxTraceLogsList.Count().ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void copyAllToolStripOnFxTraceLog_Click(object sender, EventArgs e)
        {
            StringBuilder str = new StringBuilder();

            List<string> content = new List<string>();

            for (int i = 0; i < fxTraceLogGridView.Columns.Count; i++)
            {
                content.Add(fxTraceLogGridView.Columns[i].Name);
            }

            str.Append(String.Join("\t", content));

            for (int i = 0; i < (fxTraceLogGridView.Rows.Count - 1); i++)
            {
                content.Clear();

                for (int j = 0; j < fxTraceLogGridView.Rows[i].Cells.Count; j++)
                {
                    object obj = fxTraceLogGridView.Rows[i].Cells[j].Value;
                    content.Add(obj != null ? obj.ToString() : String.Empty);
                }

                str.AppendLine();
                str.Append(String.Join("\t", content));
            }

            if (str.Length > 0)
            {
                Clipboard.SetText(str.ToString());
            }
        }

        private void copySelectedToolStripOnFxTraceLog_Click(object sender, EventArgs e)
        {
            StringBuilder str = new StringBuilder();

            List<string> content = new List<string>();

            for (int i = 0; i < fxTraceLogGridView.Columns.Count; i++)
            {
                content.Add(fxTraceLogGridView.Columns[i].Name);
            }

            str.Append(String.Join("\t", content));

            for (int i = 0; i < fxTraceLogGridView.SelectedRows.Count; i++)
            {
                content.Clear();

                for (int j = 0; j < fxTraceLogGridView.Rows[i].Cells.Count; j++)
                {
                    object obj = fxTraceLogGridView.Rows[fxTraceLogGridView.SelectedRows[0].Index].Cells[j].Value;
                    content.Add(obj != null ? obj.ToString() : String.Empty);
                }

                str.AppendLine();
                str.Append(String.Join("\t", content));
            }

            if (str.Length > 0)
            {
                Clipboard.SetText(str.ToString());
            }
        }


        #endregion Cloud Robotics FX Trace Log Tab

        private void FrmMainWindow_Activated(object sender, EventArgs e)
        {
            textBoxIoTHubConnString.Focus();
        }
    }
}
