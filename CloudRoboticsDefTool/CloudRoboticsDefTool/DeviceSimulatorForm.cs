using System;
using System.Windows.Forms;
using System.Text;
using Microsoft.Azure.Devices.Client;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Threading;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;

namespace CloudRoboticsDefTool
{
    public partial class DeviceSimulatorForm : Form
    {
        private DeviceClient deviceClient = null;
        private string iotHubHostName = string.Empty;
        private string iotHubConnectionString = string.Empty;
        private string deviceId = string.Empty;
        private string deviceKey = string.Empty;
        private string deviceType = string.Empty;
        private string deviceMessageType = string.Empty;
        private string queueStorageConnString = string.Empty;
        private bool sendLoopChecked = false;
        private bool receiveLoopChecked = false;

        public static string jsonMessages;
        private int sendCount = 0;

        public DeviceSimulatorForm()
        {
            InitializeComponent();
        }

        public DeviceSimulatorForm(string p_iotHubConnectionString, string p_iotHubHostName, 
            string p_deviceId, string p_deviceKey, string p_deviceType, string p_QueueStorageConnString)
        {
            InitializeComponent();

            iotHubConnectionString = p_iotHubConnectionString;
            iotHubHostName = p_iotHubHostName;
            deviceId = p_deviceId;
            deviceKey = p_deviceKey;
            deviceType = p_deviceType;
            queueStorageConnString = p_QueueStorageConnString;
        }

        private void DeviceSimulatorForm_Load(object sender, EventArgs e)
        {
            this.Size = new System.Drawing.Size(640, 480);
            
            comboBoxDeviceId.Text = deviceId;
            textBoxDeviceKey.Text = deviceKey;
            textBoxIotHubHostName.Text = iotHubHostName;
            textBoxQueStorageConnString.Text = queueStorageConnString;

            if (deviceType.ToUpper() == "PEPPER")
            {
                pictureBox1.Image = CloudRoboticsDefTool.Properties.Resources.pepperS;
                deviceMessageType = "PEPPER";
            }
            else if (deviceType.ToUpper() == "SURFACE HUB")
            {
                pictureBox1.Image = CloudRoboticsDefTool.Properties.Resources.surface_hub1;
                deviceMessageType = "SURFACE";
            }
            else if (deviceType.ToUpper() == "SURFACE")
            {
                pictureBox1.Image = CloudRoboticsDefTool.Properties.Resources.Surface;
                deviceMessageType = "SURFACE";
            }

            try
            {
                Properties.Settings.Default.Reload();
                jsonMessages = (string)Properties.Settings.Default["CloudRobotics_JsonMessages"];
            }
            catch
            {
                jsonMessages = string.Empty;
            }

            if (jsonMessages != string.Empty)
            {
                updateJsonComboBox();
            }

            deviceClient = DeviceClient.Create(textBoxIotHubHostName.Text,
                new DeviceAuthenticationWithRegistrySymmetricKey(comboBoxDeviceId.Text, textBoxDeviceKey.Text));

        }

        private void buttonMessageEditForm_Click(object sender, EventArgs e)
        {
            EditMessageForm editMessageForm = new EditMessageForm(jsonMessages);
            editMessageForm.ShowDialog();
            updateJsonComboBox();
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            if (textBoxInput.Text == "")
            {
                MessageBox.Show("Send message is nothing !!", "** Error **", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string msg = textBoxInput.Text;

            if (checkBoxSendLoop.Checked)
            {
                sendLoopChecked = true;
                SendDeviceToCloudMessagesLoopAsync(msg);
            }
            else
            {
                SendDeviceToCloudMessagesAsync(msg);
            }
        }

        private async void SendDeviceToCloudMessagesAsync(string msg)
        {
            // Set deviceId to RbHeader
            JObject jo_message = JsonConvert.DeserializeObject<JObject>(msg);
            jo_message["RbHeader"]["SourceDeviceId"] = comboBoxDeviceId.Text;
            jo_message["RbHeader"]["MessageSeqno"] = "1";
            jo_message["RbHeader"]["SendDateTime"] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
            msg = JsonConvert.SerializeObject(jo_message);
            var message = new Microsoft.Azure.Devices.Client.Message(Encoding.UTF8.GetBytes(msg));

            await deviceClient.SendEventAsync(message);
        }

        private async void SendDeviceToCloudMessagesLoopAsync(string msg)
        {
            int i = 0;
            // Set deviceId to RbHeader
            JObject jo_message = JsonConvert.DeserializeObject<JObject>(msg);

            while (true)
            {
                if (!sendLoopChecked)
                    break;

                jo_message["RbHeader"]["SourceDeviceId"] = comboBoxDeviceId.Text;
                ++i;
                jo_message["RbHeader"]["MessageSeqno"] = i.ToString();
                jo_message["RbHeader"]["SendDateTime"] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                msg = JsonConvert.SerializeObject(jo_message);
                var message = new Microsoft.Azure.Devices.Client.Message(Encoding.UTF8.GetBytes(msg));
                // 
                await deviceClient.SendEventAsync(message);
                Thread.Sleep(200);
            }
        }

        private void buttonReceive_Click(object sender, EventArgs e)
        {
            if (comboBoxDeviceId.Text == "")
            {
                MessageBox.Show("Device information is nothing !!", "** Error **", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (queueStorageConnString == null || queueStorageConnString == string.Empty)
            {
                ReceiveC2dAsync();
            }
            else
            {
                ReceiveC2dFromQueueAsync();
            }
        }

        private async void ReceiveC2dAsync()
        {
            while (deviceClient != null)
            {
                try
                {
                    Microsoft.Azure.Devices.Client.Message receivedMessage = await deviceClient.ReceiveAsync();
                    if (receivedMessage == null) continue;

                    textBoxOutput.Text = string.Format("** Received from IoT Hub ** (Datetime:{0})", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                    textBoxOutput.Text += Environment.NewLine;
                    textBoxOutput.Text += Encoding.UTF8.GetString(receivedMessage.GetBytes());

                    await deviceClient.CompleteAsync(receivedMessage);
                }
                catch(Exception ex)
                {
                    if (deviceClient != null)
                        throw ex;
                }
            }
        }

        private async void ReceiveC2dFromQueueAsync()
        {
            receiveLoopChecked = true;
            // Retrieve storage account from connection string.
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(queueStorageConnString);
            // Create the queue client.
            CloudQueueClient queueClient = storageAccount.CreateCloudQueueClient();
            // Retrieve a reference to a container.
            CloudQueue queue = queueClient.GetQueueReference(deviceId);

            while (receiveLoopChecked)
            {
                CloudQueueMessage queueMessage = await queue.GetMessageAsync();
                if (queueMessage == null)
                {
                    Thread.Sleep(100);
                }
                else
                {
                    string receivedMessage = queueMessage.AsString;
                    textBoxOutput.Text = string.Format("** Received from Queue Storage ** (Datetime:{0})", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                    textBoxOutput.Text += Environment.NewLine;
                    textBoxOutput.Text += receivedMessage;
                    await queue.DeleteMessageAsync(queueMessage);
                }
            }
        }

        private void comboBoxJson_SelectedIndexChanged(object sender, EventArgs e)
        {
            string searchWord = comboBoxJson.SelectedItem.ToString();

            try
            {
                JObject joMessage = JsonConvert.DeserializeObject<JObject>(jsonMessages);
                JArray ja = (JArray)joMessage["Messages"];

                foreach (JObject jo in ja)
                {
                    string tytle = jo["Tytle"].ToString();

                    if (tytle == searchWord)
                    {
                        JObject joRbMessage = (JObject)jo["RbMessage"];
                        sendCount += 1;
                        joRbMessage["RbHeader"]["MessageSeqno"] = sendCount.ToString();
                        joRbMessage["RbHeader"]["SendDateTime"] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");

                        textBoxInput.Text = joRbMessage.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Saved JSON Message is invalid !! \n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void updateJsonComboBox()
        {
            try
            {
                if (jsonMessages == string.Empty)
                    return;

                JObject joMessage = JsonConvert.DeserializeObject<JObject>(jsonMessages);
                JArray ja = (JArray)joMessage["Messages"];

                comboBoxJson.Items.Clear();

                foreach (JObject jo in ja)
                {
                    string tytle = jo["Tytle"].ToString();
                    string messageType = jo["MessageType"].ToString();

                    if (messageType == deviceMessageType)
                    {
                        comboBoxJson.Items.Add(tytle);
                    }
                    else if (messageType == "CONTROL" || messageType == "CALL")
                    {
                        comboBoxJson.Items.Add(tytle);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Saved JSON Message is invalid !! \n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void DeviceSimulatorForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            sendLoopChecked = false;
            receiveLoopChecked = false;
            Thread.Sleep(500);

            if (deviceClient != null)
            {
                deviceClient.Dispose();
                deviceClient = null;
            }
        }

        private void checkBoxSendLoop_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxSendLoop.Checked)
            {
                sendLoopChecked = true;
            }
            else
            {
                sendLoopChecked = false;
            }

        }
    }
}
