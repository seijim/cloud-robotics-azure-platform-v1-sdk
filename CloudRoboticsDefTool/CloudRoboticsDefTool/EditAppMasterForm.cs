using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CloudRoboticsDefTool
{
    public partial class EditAppMasterForm : Form
    {
        private string sqlConnectionString;
        private AppMasterEntity appMasterEntity;
        private string encPassPhrase;
        private bool createStatus;

        public EditAppMasterForm(string sqlConnectionString, string encPassPhrase)
        {
            InitializeComponent();

            this.sqlConnectionString = sqlConnectionString;
            this.encPassPhrase = encPassPhrase;
            appMasterEntity = new AppMasterEntity();
            if (encPassPhrase == string.Empty)
            {
                throw (new ApplicationException("Encryption Passphrase is nothing !!"));
            }

            this.createStatus = true;
        }
        public EditAppMasterForm(string sqlConnectionString, string encPassPhrase, AppMasterEntity appMasterEntity)
        {
            InitializeComponent();

            this.sqlConnectionString = sqlConnectionString;
            this.encPassPhrase = encPassPhrase;
            this.appMasterEntity = appMasterEntity;
            if (encPassPhrase == string.Empty)
            {
                throw (new ApplicationException("Encryption Passphrase is nothing !!"));
            }
            if (appMasterEntity.AppId == string.Empty)
            {
                throw (new ApplicationException("App ID is nothing !!"));
            }

            this.createStatus = false;
        }

        private void EditAppMasterForm_Load(object sender, EventArgs e)
        {
            if (createStatus)
            {
                createButton.Enabled = true;
                updateButton.Enabled = false;

                comboBoxStatus.DataSource = CRoboticsConst.StatusList;
            }
            else
            {
                createButton.Enabled = false;
                updateButton.Enabled = true;

                textBoxAppId.Text = appMasterEntity.AppId;
                textBoxStorageAccount.Text = appMasterEntity.StorageAccount;
                textBoxStorageKey.Text = appMasterEntity.StorageKey;
                textBoxAppInfo.Text = appMasterEntity.AppInfo;
                textBoxAppInfoDevice.Text = appMasterEntity.AppInfoDevice;
                comboBoxStatus.DataSource = CRoboticsConst.StatusList;
                comboBoxStatus.Text = appMasterEntity.Status;
                textBoxDesc.Text = appMasterEntity.Description;
            }

        }

        private void createButton_Click(object sender, EventArgs e)
        {
            if (!checkInputData())
                return;

            try
            {
                AppMasterEntity appMasterEntity = getAppMasterEntity();
                AppMasterProcessor appMasterProcessor = new AppMasterProcessor(sqlConnectionString, this.encPassPhrase);
                appMasterProcessor.insertAppMaster(appMasterEntity);

                MessageBox.Show("App Master created successfully!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            this.Close();
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            if (!checkInputData())
                return;

            try
            {
                AppMasterEntity appMasterEntity = getAppMasterEntity();
                AppMasterProcessor appMasterProcessor = new AppMasterProcessor(sqlConnectionString, this.encPassPhrase);
                appMasterProcessor.updateAppMaster(appMasterEntity);

                MessageBox.Show("App Master updated successfully!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            this.Close();
        }

        private AppMasterEntity getAppMasterEntity()
        {
            AppMasterEntity appMasterEntity = new AppMasterEntity();
            appMasterEntity.AppId = textBoxAppId.Text;
            appMasterEntity.StorageAccount = textBoxStorageAccount.Text;
            appMasterEntity.StorageKey = textBoxStorageKey.Text;
            appMasterEntity.AppInfo = textBoxAppInfo.Text;
            appMasterEntity.AppInfoDevice = textBoxAppInfoDevice.Text;
            appMasterEntity.Status = comboBoxStatus.Text;
            appMasterEntity.Description = textBoxDesc.Text;
            appMasterEntity.Registered_DateTime = DateTime.Now;

            return appMasterEntity;
        }
        private bool checkInputData()
        {
            if (textBoxAppId.Text == string.Empty)
            {
                MessageBox.Show("App ID is nothing !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (textBoxStorageAccount.Text == string.Empty)
            {
                MessageBox.Show("Storage Account is nothing !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (textBoxStorageKey.Text == string.Empty)
            {
                MessageBox.Show("Storage Key is nothing !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (comboBoxStatus.Text == string.Empty)
            {
                MessageBox.Show("Status is nothing !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EditAppMasterForm_Activated(object sender, EventArgs e)
        {
            textBoxAppId.Focus();
        }
    }
}
