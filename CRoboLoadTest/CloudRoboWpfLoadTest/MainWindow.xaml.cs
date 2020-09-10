using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Threading;
using System.Windows;
using Microsoft.Azure.Devices;
using Microsoft.Azure.Devices.Client;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;


namespace CloudRoboWpfLoadTest
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public static bool stopFlag = false;
        private List<DeviceEntity> listOfDevices;
        private List<string> listOfDeviceNames;
        private ResultWindow resultWindow = null;

        private static string lockObject = "{lockObject}";
        private static int threadCount = 0;
        public static Dictionary<string, ThreadResult> dictionaryOfThreadResult = null;
        public static Dictionary<int, bool> messageCleanupList = null;
        private DispatcherTimer dispatcherTimer;

        private static string queueConnStringDefault = "";

        public MainWindow()
        {
            InitializeComponent();

        }

        private async void buttonStart_Click(object sender, RoutedEventArgs e)
        {
            stopFlag = false;
            buttonStart.IsEnabled = false;
            listOfDevices = null;

            // Save the setting
            Properties.Settings.Default["IoTHubConnectionString"] = textBoxIotHub.Text;
            Properties.Settings.Default["QueueStorageConnectionString"] = textBoxQStorageConnString.Text;
            Properties.Settings.Default["DeviceList"] = textBoxDevices.Text;
            Properties.Settings.Default["NumOfLoops"] = textBoxLoops.Text;
            Properties.Settings.Default["TexBoxJson"] = textBoxJson.Text;
            Properties.Settings.Default["ComboBoxP1"] = comboBoxP1.Text;
            Properties.Settings.Default["ComboBoxP2"] = comboBoxP2.Text;
            Properties.Settings.Default["ComboBoxP3"] = comboBoxP3.Text;
            Properties.Settings.Default["LabelP1"] = labelP1.Content.ToString();
            Properties.Settings.Default["LabelP2"] = labelP2.Content.ToString();
            Properties.Settings.Default["LabelP3"] = labelP3.Content.ToString();
            Properties.Settings.Default["TextBoxIncreP1"] = textBoxIncreP1.Text;
            Properties.Settings.Default["TextBoxIncreP2"] = textBoxIncreP2.Text;
            Properties.Settings.Default["TextBoxIncreP3"] = textBoxIncreP3.Text;
            Properties.Settings.Default["TextBoxStartP1"] = textBoxStartP1.Text;
            Properties.Settings.Default["TextBoxStartP2"] = textBoxStartP2.Text;
            Properties.Settings.Default["TextBoxStartP3"] = textBoxStartP3.Text;
            Properties.Settings.Default["TextBoxEndP1"] = textBoxEndP1.Text;
            Properties.Settings.Default["TextBoxEndP2"] = textBoxEndP2.Text;
            Properties.Settings.Default["TextBoxEndP3"] = textBoxEndP3.Text;
            Properties.Settings.Default.Save();

            string[] deviceNames = textBoxDevices.Text.Split(',');
            listOfDeviceNames = new List<string>();
            threadCount = listOfDeviceNames.Count;

            foreach (string deviceName in deviceNames)
            {
                listOfDeviceNames.Add(deviceName);
            }

            // Get Deivice List
            DeviceInfo devInfo = new DeviceInfo(textBoxIotHub.Text, listOfDeviceNames);
            listOfDevices = await devInfo.GetDevices();

            // Create ThreadInput
            ThreadInput ti = new ThreadInput();
            ti.ThreadCount = listOfDeviceNames.Count;
            ti.Message = textBoxJson.Text;
            ti.ParamDateTimeId = labelDateTime.Content.ToString();
            ti.ParamDateTimeValue = textBoxDateTime.Text;

            List<ReplaceOperator> replaceOperatorList = new List<ReplaceOperator>();
            // param 1
            ReplaceOperator ope = new ReplaceOperator();
            ope.Id = labelParam1.Content.ToString();
            ope.Mode = comboBoxP1.Text;
            ope.Increment = textBoxIncreP1.Text;
            ope.StartValue = textBoxStartP1.Text;
            ope.EndValue = textBoxEndP1.Text;
            replaceOperatorList.Add(ope);
            // param 2
            ope = new ReplaceOperator();
            ope.Id = labelParam2.Content.ToString();
            ope.Mode = comboBoxP2.Text;
            ope.Increment = textBoxIncreP2.Text;
            ope.StartValue = textBoxStartP2.Text;
            ope.EndValue = textBoxEndP2.Text;
            replaceOperatorList.Add(ope);
            // param 3
            ope = new ReplaceOperator();
            ope.Id = labelParam3.Content.ToString();
            ope.Mode = comboBoxP3.Text;
            ope.Increment = textBoxIncreP3.Text;
            ope.StartValue = textBoxStartP3.Text;
            ope.EndValue = textBoxEndP3.Text;
            replaceOperatorList.Add(ope);
            ti.ReplaceOperatorList = replaceOperatorList;

            var builder = Microsoft.Azure.Devices.IotHubConnectionStringBuilder.Create(textBoxIotHub.Text);
            string iotHubHostName = builder.HostName;
            string queueStorageConnString = textBoxQStorageConnString.Text;

            // Launch multi-threads which send and receive message
            dictionaryOfThreadResult = new Dictionary<string, ThreadResult>();
            int threadNum = 0;
            foreach (var device in listOfDevices)
            {
                ti.ThreadNo = threadNum;
                CommunicateAsync(ti, iotHubHostName, device.Id, device.PrimaryKey, queueStorageConnString);
                ++threadNum;
            }

            resultWindow = new ResultWindow();
            resultWindow.Show();
        }

        private async void CommunicateAsync(ThreadInput threadInput, string hostName, 
                                        string deviceId, string deviceKey, string queueStorageConnString)
        {
            try
            {
                string loopsStr = textBoxLoops.Text;
                int loops = 0;
                if (!int.TryParse(loopsStr, out loops))
                    loops = -1;
                int loopCounter = 0;

                int increment = 0;
                int startValue = 0;
                int endValue = 0;
                string templateMessage = threadInput.Message;
                string message;
                List<ValueGenerator> valueGenList = new List<ValueGenerator>();

                foreach (var ope in threadInput.ReplaceOperatorList)
                {
                    if (ope.Mode.ToLower() == "random" || ope.Mode.ToLower() == "addition")
                    {
                        increment = int.Parse(ope.Increment);
                        if (!int.TryParse(ope.StartValue, out startValue))
                            startValue = 0;
                        if (!int.TryParse(ope.EndValue, out endValue))
                            endValue = 0;
                        if (ope.Mode.ToLower() == "addition")
                        {
                            int range = (endValue - startValue + 1) / threadInput.ThreadCount;
                            startValue = startValue + range * threadInput.ThreadNo;
                            endValue = startValue + range - 1;
                        }
                        var valueGen = new ValueGenerator(ope.Id, ope.Mode, increment, startValue, endValue);
                        valueGenList.Add(valueGen);
                    }
                }

                using (var deviceClient = DeviceClient.Create(hostName,
                        new DeviceAuthenticationWithRegistrySymmetricKey(deviceId, deviceKey)))
                {
                    while (true)
                    {
                        message = templateMessage;

                        if (stopFlag)
                        {
                            lock (lockObject)
                            {
                                ThreadResult trStop = new ThreadResult();
                                trStop.DeviceId = deviceId;
                                trStop.ThroughputPer60Sec = 0;
                                trStop.IsEnabled = false;
                                dictionaryOfThreadResult[deviceId] = trStop;
                                --threadCount;
                            }
                            return;
                        }

                        if (threadInput.ParamDateTimeValue != string.Empty)
                        {
                            if (message.Contains(threadInput.ParamDateTimeId))
                            {
                                if (threadInput.ParamDateTimeValue.ToLower() == "datetime.now")
                                {
                                    message = message.Replace(threadInput.ParamDateTimeId, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                                }
                                else
                                {
                                    message = message.Replace(threadInput.ParamDateTimeId, threadInput.ParamDateTimeValue);
                                }
                            }
                        }

                        // Replace $$xxx$$ parameter
                        int size = valueGenList.Count;
                        for (int i = 0; i < size; i++)
                        {
                            message = valueGenList[i].ReplaceValueInMessage(message);
                        }

                        var msg = new Microsoft.Azure.Devices.Client.Message(Encoding.UTF8.GetBytes(message));
                        DateTime dt1 = DateTime.Now;

                        // Send msg to IoT Hub
                        await deviceClient.SendEventAsync(msg);

                        // Receive msg
                        int loopCount = 0;
                        int maxLoopCount = 100;
                        if (queueStorageConnString == null || queueStorageConnString == string.Empty)
                        {
                            // ------------------------------------
                            // Receive msg from IoT Hub
                            // ------------------------------------
                            while (true)
                            {
                                Microsoft.Azure.Devices.Client.Message receivedMessage = await deviceClient.ReceiveAsync();

                                if (receivedMessage == null)
                                {
                                    ++loopCount;
                                    if (loopCount >= maxLoopCount)
                                        break;
                                }
                                else
                                {
                                    string messageContent = Encoding.UTF8.GetString(receivedMessage.GetBytes());
                                    await deviceClient.CompleteAsync(receivedMessage);
                                    break;
                                }
                            }
                        }
                        else
                        {
                            // ------------------------------------
                            // Receive msg from Queue Storage
                            // ------------------------------------

                            // If communicate with the deviceId at first, Cloud Robotics FX creates the queue.
                            // So need to wait for a second
                            if (loopCounter == 0)  
                                Thread.Sleep(1000);

                            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(queueStorageConnString);
                            CloudQueueClient queueClient = storageAccount.CreateCloudQueueClient();
                            CloudQueue queue = queueClient.GetQueueReference(deviceId);
                            while (true)
                            {
                                CloudQueueMessage queueMessage = await queue.GetMessageAsync();
                                if (queueMessage == null)
                                {
                                    ++loopCount;
                                    if (loopCount >= maxLoopCount)
                                        break;
                                    Thread.Sleep(50);
                                }
                                else
                                {
                                    string receivedMessage = queueMessage.AsString;
                                    await queue.DeleteMessageAsync(queueMessage);
                                    break;
                                }
                            }
                        }

                        DateTime dt2 = DateTime.Now;
                        TimeSpan ts = dt2 - dt1;

                        int milliSec = ts.Seconds * 1000 + ts.Milliseconds;
                        double throuput = 60 * 1000 / milliSec;
                        if (loopCount >= maxLoopCount)
                            throuput = 0;
                        ThreadResult tr = new ThreadResult();
                        tr.DeviceId = deviceId;
                        tr.ThroughputPer60Sec = (int)Math.Round(throuput, 0);
                        tr.UpdateTime = dt2;
                        tr.IsEnabled = true;
                        tr.ExceptionMessage = string.Empty;
                        lock (lockObject)
                        {
                            dictionaryOfThreadResult[deviceId] = tr;
                        }

                        ++loopCounter;
                        if (loops != -1 && loopCounter >= loops)
                        {
                            stopLoadTest();
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                ThreadResult tr = new ThreadResult();
                tr.DeviceId = deviceId;
                tr.ThroughputPer60Sec = 0;
                tr.UpdateTime = DateTime.Now;
                tr.IsEnabled = false;
                tr.ExceptionMessage = ex.ToString();
                lock (lockObject)
                {
                    dictionaryOfThreadResult[deviceId] = tr;
                }
                throw;
            }
        }

        private void comboBoxP1_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            string strValue = comboBoxP1.SelectedValue.ToString();

            if (strValue.ToLower().Contains("random"))
                labelP1.Content = "Value:";
            else if (strValue.ToLower().Contains("addition"))
                labelP1.Content = "Increment:";
        }

        private void comboBoxP2_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            string strValue = comboBoxP2.SelectedValue.ToString();

            if (strValue.ToLower().Contains("random"))
                labelP2.Content = "Value:";
            else if (strValue.ToLower().Contains("addition"))
                labelP2.Content = "Increment:";
        }

        private void comboBoxP3_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            string strValue = comboBoxP3.SelectedValue.ToString();

            if (strValue.ToLower().Contains("random"))
                labelP3.Content = "Value:";
            else if (strValue.ToLower().Contains("addition"))
                labelP3.Content = "Increment:";
        }

        private void buttonStop_Click(object sender, RoutedEventArgs e)
        {
            stopLoadTest();
        }

        private void stopLoadTest()
        {
            stopFlag = true;
            buttonStart.IsEnabled = true;
        }

        private void buttonFinish_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            Environment.Exit(0);
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            textBoxJson.Text = (string)Properties.Settings.Default["TexBoxJson"];
            textBoxIotHub.Text = (string)Properties.Settings.Default["IoTHubConnectionString"];
            textBoxQStorageConnString.Text = (string)Properties.Settings.Default["QueueStorageConnectionString"];
            textBoxDevices.Text = (string)Properties.Settings.Default["DeviceList"];
            textBoxLoops.Text = (string)Properties.Settings.Default["NumOfLoops"];
            textBoxDateTime.Text = (string)Properties.Settings.Default["TextBoxDateTime"];
            comboBoxP1.Text = (string)Properties.Settings.Default["ComboBoxP1"];
            comboBoxP2.Text = (string)Properties.Settings.Default["ComboBoxP2"];
            comboBoxP3.Text = (string)Properties.Settings.Default["ComboBoxP3"];
            //string label1 = (string)Properties.Settings.Default["LabelP1"];
            //if (label1 != string.Empty)
            //    labelP1.Content = labelP1;
            //string label2 = (string)Properties.Settings.Default["LabelP2"];
            //if (label2 != string.Empty)
            //    labelP2.Content = labelP2;
            //string label3 = (string)Properties.Settings.Default["LabelP3"];
            //if (label3 != string.Empty)
            //    labelP3.Content = labelP3;
            textBoxIncreP1.Text = (string)Properties.Settings.Default["TextBoxIncreP1"];
            textBoxIncreP2.Text = (string)Properties.Settings.Default["TextBoxIncreP2"];
            textBoxIncreP3.Text = (string)Properties.Settings.Default["TextBoxIncreP3"];
            textBoxStartP1.Text = (string)Properties.Settings.Default["TextBoxStartP1"];
            textBoxStartP2.Text = (string)Properties.Settings.Default["TextBoxStartP2"];
            textBoxStartP3.Text = (string)Properties.Settings.Default["TextBoxStartP3"];
            textBoxEndP1.Text = (string)Properties.Settings.Default["TextBoxEndP1"];
            textBoxEndP2.Text = (string)Properties.Settings.Default["TextBoxEndP2"];
            textBoxEndP3.Text = (string)Properties.Settings.Default["TextBoxEndP3"];
        }

        private async void buttonMessageCleanup_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                buttonMessageCleanup.IsEnabled = false;

                string[] deviceNames = textBoxDevices.Text.Split(',');
                listOfDeviceNames = new List<string>();
                threadCount = listOfDeviceNames.Count;

                foreach (string deviceName in deviceNames)
                {
                    listOfDeviceNames.Add(deviceName);
                }

                // Get Deivice List
                DeviceInfo devInfo = new DeviceInfo(textBoxIotHub.Text, listOfDeviceNames);
                listOfDevices = await devInfo.GetDevices();


                var builder = Microsoft.Azure.Devices.IotHubConnectionStringBuilder.Create(textBoxIotHub.Text);
                string iotHubHostName = builder.HostName;

                // Launch multi-threads which send and receive message
                dictionaryOfThreadResult = new Dictionary<string, ThreadResult>();
                int threadNum = 0;
                messageCleanupList = new Dictionary<int, bool>();

                foreach (var device in listOfDevices)
                {
                    messageCleanupList[threadNum] = false;
                    string queueStorageConnString = textBoxQStorageConnString.Text;
                    if (queueStorageConnString == null || queueStorageConnString == string.Empty)
                    {
                        receiveAsync(threadNum, iotHubHostName, device.Id, device.PrimaryKey);
                    }
                    else
                    {
                        receiveFromQueueAsync(threadNum, queueStorageConnString, device.Id);
                    }
                    ++threadNum;
                }

                dispatcherTimer = new DispatcherTimer(DispatcherPriority.Normal);
                dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
                dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
                dispatcherTimer.Start();
            }
            catch
            {
                buttonMessageCleanup.IsEnabled = true;
            }
        }

        private async void receiveAsync(int threadNum, string iotHubHostName, string deviceId, string deviceKey)
        {
            int maxloop = 10;
            int cnt = 0;
            var deviceClient = DeviceClient.Create(iotHubHostName,
                        new DeviceAuthenticationWithRegistrySymmetricKey(deviceId, deviceKey));

            while (true)
            {
                TimeSpan ts = new TimeSpan(0, 0, 1);
                Microsoft.Azure.Devices.Client.Message receivedMessage = await deviceClient.ReceiveAsync(ts);

                if (receivedMessage == null)
                {
                    ++cnt;
                    if (cnt > maxloop)
                    {
                        messageCleanupList[threadNum] = true;
                        break;
                    }
                }
                else
                {
                    await deviceClient.CompleteAsync(receivedMessage);
                }
            }
        }

        private async void receiveFromQueueAsync(int threadNum, string queueStorageConnString, string deviceId)
        {
            int maxloop = 10;
            int cnt = 0;
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(queueStorageConnString);
            CloudQueueClient queueClient = storageAccount.CreateCloudQueueClient();
            CloudQueue queue = queueClient.GetQueueReference(deviceId);

            while (true)
            {
                CloudQueueMessage queueMessage = await queue.GetMessageAsync();

                if (queueMessage == null)
                {
                    ++cnt;
                    if (cnt > maxloop)
                    {
                        messageCleanupList[threadNum] = true;
                        break;
                    }
                    Thread.Sleep(100);
                }
                else
                {
                    await queue.DeleteMessageAsync(queueMessage);
                }
            }
        }

        void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            bool result = true;

            for (int i = 0; i < messageCleanupList.Count; i++)
            {
                if (!messageCleanupList[i])
                {
                    result = false;
                }
            }
            if (result)
            {
                buttonMessageCleanup.IsEnabled = true;
                dispatcherTimer.Stop();
                MessageBox.Show("Message cleanup completed !!", "Information",MessageBoxButton.OK,MessageBoxImage.Information);
            }
        }
    }
}
