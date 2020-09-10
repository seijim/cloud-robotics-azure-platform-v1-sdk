using System;
using System.Threading;
using System.IO;
using System.Windows.Forms;
using System.Data.SqlClient;
using CloudRoboticsUtil;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CloudRoboticsTestDriver
{
    public partial class TestDriverForm : Form
    {
        private static int constTimeOutSec = 0;
        private static string activeEncPassPhrase;
        private static string activeSqlConnectionString;
        private static string activeFilePath;
        private static string activeFileName;

        public TestDriverForm()
        {
            InitializeComponent();
        }

        private void TestDriverForm_Load(object sender, EventArgs e)
        {
            Properties.Settings.Default.Reload();
            activeEncPassPhrase 
                = textBoxEncPassphrase.Text = (string)Properties.Settings.Default["Microsoft_SqlDb_EncPassphrase"];
            activeSqlConnectionString 
                = textBoxSQLConnectionString.Text = (string)Properties.Settings.Default["Microsoft_SqlDb_ConnectionString"];

            textBoxDllFilePath.Text = (string)Properties.Settings.Default["Previous_AppDllPath"];

            textBoxDeviceId.Text = (string)Properties.Settings.Default["Previous_TextBoxDeviceId"];
            if (textBoxDeviceId.Text == string.Empty)
            {
                textBoxDeviceId.Text = "pepper01";
                textBoxClassName.Text = "RbSampleApp.SayHello";
            }
            else
            {
                textBoxClassName.Text = (string)Properties.Settings.Default["Previous_TextBoxClassName"];
                textBoxInput.Text = (string)Properties.Settings.Default["Previous_TextBoxInput"];
            }
            
            if (checkBoxSkipAppRouter.Checked)
            {
                textBoxClassName.Enabled = true;
            }
            else
            {
                textBoxClassName.Text = string.Empty;
                textBoxClassName.Enabled = false;
            }

            //this.Size = new System.Drawing.Size(800, 600);

        }

        private void saveEncPassphraseButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Passphrase of SQL Encryption Function
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

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void saveSqlConnStringButton_Click(object sender, EventArgs e)
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

        private void searchButton_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.FileName = string.Empty;
            dialog.Filter = "DLLファイル(*.dll)|*.dll|すべてのファイル(*.*)|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                activeFilePath = textBoxDllFilePath.Text = dialog.FileName;
                activeFileName = dialog.SafeFileName;
                Properties.Settings.Default["Previous_AppDllPath"] = textBoxDllFilePath.Text;
                Properties.Settings.Default.Save();
            }

        }

        private void callAppButton_Click(object sender, EventArgs e)
        {
            if (textBoxDllFilePath.Text == string.Empty)
            {
                MessageBox.Show("** Error ** DLL File Local Path must be set !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (textBoxDeviceId.Text == string.Empty)
            {
                MessageBox.Show("** Error ** Device ID must be set !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (checkBoxSkipAppRouter.Checked && textBoxClassName.Text == string.Empty)
            {
                MessageBox.Show("** Error ** Class Name must be set !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Save the TextBox content
            saveTextBoxContent();

            JObject jo_message = JsonConvert.DeserializeObject<JObject>(textBoxInput.Text);

            // Check RbHeader in detail
            RbHeaderBuilder hdBuilder = new RbHeaderBuilder(jo_message, textBoxDeviceId.Text);
            RbHeader rbh = hdBuilder.ValidateJsonSchema();
            // RbBody
            JObject jo_temp = (JObject)jo_message[RbFormatType.RbBody];
            string rbBodyString = JsonConvert.SerializeObject(jo_temp);

            // App Master Cache (RBFX.AppMaster)
            AppMaster am = new AppMaster(rbh.AppId, activeEncPassPhrase, activeSqlConnectionString, constTimeOutSec);
            RbAppMasterCache rbappmc = am.GetAppMaster();

            // App Router Cache (RBFX.AppRouting)
            RbAppRouterCache rbapprc;
            if (checkBoxSkipAppRouter.Checked)
            {
                rbapprc = new RbAppRouterCache();
                rbapprc.AppId = rbh.AppId;
                rbapprc.AppProcessingId = rbh.AppProcessingId;
                rbapprc.ClassName = textBoxClassName.Text;
                rbapprc.FileName = textBoxDllFilePath.Text;
            }
            else
            {
                AppRouter ar = new AppRouter(rbh.AppId, rbh.AppProcessingId, activeSqlConnectionString, constTimeOutSec);
                rbapprc = ar.GetAppRouting();
            }

            // Load DLL
            //Assembly assembly = null;
            AppDomain appDomain = null;
            IAppRouterDll routedAppDll = null;
            try
            {
                //assembly = System.Reflection.Assembly.LoadFrom(textBoxDllFilePath.Text);
                //routedAppDll = assembly.CreateInstance(rbapprc.ClassName) as IAppRouterDll;
                string pid = Thread.CurrentThread.ManagedThreadId.ToString();
                string appDomainName = "AppDomain_P" + pid;
                string cachedDirectory = Path.GetDirectoryName(textBoxDllFilePath.Text);
                string cachedFileName = Path.GetFileName(textBoxDllFilePath.Text);
                string cachedFileNameWithoutExt = Path.GetFileNameWithoutExtension(textBoxDllFilePath.Text);
                appDomain = createAppDomain(appDomainName, cachedDirectory);
                routedAppDll = appDomain.CreateInstanceAndUnwrap(cachedFileNameWithoutExt, rbapprc.ClassName) as IAppRouterDll;

            }
            catch (Exception ex)
            {
                MessageBox.Show("** Application (DLL) Load Error ** Check File Path or Class Name \n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Process Message
            try
            {
                rbh.ProcessingStack = activeFileName;
                JArrayString ja_messagesString = routedAppDll.ProcessMessage(rbappmc, rbapprc, rbh, rbBodyString);
                JArray ja_messages = ja_messagesString.ConvertToJArray();
                textBoxOutput.Text = JsonConvert.SerializeObject(ja_messages);
                AppDomain.Unload(appDomain);
            }
            catch (Exception ex)
            {
                MessageBox.Show("** Error occured in Application (DLL) **\n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                AppDomain.Unload(appDomain);
                return;
            }

        }

        private void saveTextBoxContent()
        {
            try
            {
                // Save the setting
                Properties.Settings.Default["Previous_TextBoxDeviceId"] = textBoxDeviceId.Text;
                Properties.Settings.Default["Previous_TextBoxClassName"] = textBoxClassName.Text;
                Properties.Settings.Default["Previous_TextBoxInput"] = textBoxInput.Text;

                Properties.Settings.Default.Save();
            }
            catch
            {
                return;
            }
        }

        private AppDomain createAppDomain(string appName, string baseDirectory)
        {
            AppDomainSetup setup = new AppDomainSetup();
            setup.ApplicationName = appName;
            setup.ApplicationBase = baseDirectory;

            AppDomain appDomain = AppDomain.CreateDomain(appName, null, setup);

            return appDomain;
        }

        private void checkBoxSkipAppRouter_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxSkipAppRouter.Checked)
            {
                textBoxClassName.Enabled = true;
            }
            else
            {
                textBoxClassName.Text = string.Empty;
                textBoxClassName.Enabled = false;
            }
                
        }

        private void exitAppButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
