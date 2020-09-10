using System;
using System.IO;
using System.Windows.Forms;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;


namespace CloudRoboticsDefTool
{
    public partial class EditAppRoutingForm : Form
    {
        private string sqlConnectionString;
        private string encPassPhrase;
        private AppRoutingEntity appRoutingEntity;
        private bool createStatus;

        public EditAppRoutingForm(string sqlConnectionString, string encPassPhrase)
        {
            InitializeComponent();

            this.sqlConnectionString = sqlConnectionString;
            this.encPassPhrase = encPassPhrase;
            appRoutingEntity = new AppRoutingEntity();

            this.createStatus = true;
        }
        public EditAppRoutingForm(string sqlConnectionString, string encPassPhrase, AppRoutingEntity appRoutingEntity)
        {
            InitializeComponent();

            this.sqlConnectionString = sqlConnectionString;
            this.encPassPhrase = encPassPhrase;
            this.appRoutingEntity = appRoutingEntity;
            if (appRoutingEntity.AppId == string.Empty)
            {
                throw (new ApplicationException("App ID is nothing !!"));
            }
            if (appRoutingEntity.AppProcessingId == string.Empty)
            {
                throw (new ApplicationException("App Processing ID is nothing !!"));
            }

            this.createStatus = false;
        }

        private void EditAppRoutingForm_Load(object sender, EventArgs e)
        {
            if (createStatus)
            {
                createButton.Enabled = true;
                updateButton.Enabled = false;

                textBoxClassName.Text = "<NameSpace>.<ClassName>";
                comboBoxStatus.DataSource = CRoboticsConst.StatusList;
                comboBoxDevMode.DataSource = CRoboticsConst.DevModeList;
                comboBoxDevMode.Text = CRoboticsConst.TypeFalse;
            }
            else
            {
                createButton.Enabled = false;
                updateButton.Enabled = true;

                textBoxAppId.Text = appRoutingEntity.AppId;
                textBoxAppProcessingId.Text = appRoutingEntity.AppProcessingId;
                textBoxBlobContainer.Text = appRoutingEntity.BlobContainer;
                textBoxFileName.Text = appRoutingEntity.FileName;
                textBoxClassName.Text = appRoutingEntity.ClassName;
                comboBoxStatus.DataSource = CRoboticsConst.StatusList;
                comboBoxStatus.Text = appRoutingEntity.Status;
                comboBoxDevMode.DataSource = CRoboticsConst.DevModeList;
                comboBoxDevMode.Text = appRoutingEntity.DevMode;
                textBoxDevLocalDir.Text = appRoutingEntity.DevLocalDir;
                textBoxDesc.Text = appRoutingEntity.Description;
            }

        }

        private void createButton_Click(object sender, EventArgs e)
        {
            if (!checkInputData())
                return;

            // Upload DLL file
            if (checkBoxUploadToBlob.Checked)
            {
                if (!uploadDllFileToBlob())
                    return;
            }

            try
            {
                AppRoutingEntity appRoutingEntity = getAppRoutingEntity();
                AppRoutingProcessor appRoutingProcessor = new AppRoutingProcessor(sqlConnectionString);
                appRoutingProcessor.insertAppRouting(appRoutingEntity);

                MessageBox.Show("App Routing created successfully!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

            // Upload DLL file
            if (checkBoxUploadToBlob.Checked)
            {
                if (!uploadDllFileToBlob())
                    return;
            }

            try
            {
                AppRoutingEntity appRoutingEntity = getAppRoutingEntity();
                AppRoutingProcessor appRoutingProcessor = new AppRoutingProcessor(sqlConnectionString);
                appRoutingProcessor.updateAppRouting(appRoutingEntity);

                MessageBox.Show("App Routing updated successfully!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            this.Close();

        }

        private AppRoutingEntity getAppRoutingEntity()
        {
            AppRoutingEntity appRoutingEntity = new AppRoutingEntity();
            appRoutingEntity.AppId = textBoxAppId.Text;
            appRoutingEntity.AppProcessingId = textBoxAppProcessingId.Text;
            appRoutingEntity.BlobContainer = textBoxBlobContainer.Text;
            appRoutingEntity.FileName = textBoxFileName.Text;
            appRoutingEntity.ClassName = textBoxClassName.Text;
            appRoutingEntity.Status = comboBoxStatus.Text;
            appRoutingEntity.DevMode = comboBoxDevMode.Text;
            appRoutingEntity.DevLocalDir = textBoxDevLocalDir.Text;
            appRoutingEntity.Description = textBoxDesc.Text;
            appRoutingEntity.Registered_DateTime = DateTime.Now;

            return appRoutingEntity;
        }
        private bool checkInputData()
        {
            if (textBoxAppId.Text == string.Empty)
            {
                MessageBox.Show("App ID is nothing !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (textBoxAppProcessingId.Text == string.Empty)
            {
                MessageBox.Show("App Processing ID is nothing !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (textBoxBlobContainer.Text == string.Empty)
            {
                MessageBox.Show("BLOB Container Name is nothing !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (textBoxFileName.Text == string.Empty)
            {
                MessageBox.Show("DLL File Name is nothing !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (textBoxClassName.Text == string.Empty)
            {
                MessageBox.Show("Class Name is nothing !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (comboBoxStatus.Text == string.Empty)
            {
                MessageBox.Show("Status is nothing !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (comboBoxDevMode.Text == string.Empty)
            {
                MessageBox.Show("Development Mode is nothing !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (comboBoxDevMode.Text == CRoboticsConst.TypeTrue)
            {
                if (textBoxDevLocalDir.Text == string.Empty)
                {
                    MessageBox.Show("DLL File Local Path (for Development) is nothing !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            if (checkBoxUploadToBlob.Checked)
            {
                if (textBoxUploadFilePath.Text == string.Empty)
                {
                    MessageBox.Show("DLL File Local Path is nothing !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            return true;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.FileName = string.Empty;
            dialog.Filter = "DLLファイル(*.dll)|*.dll|すべてのファイル(*.*)|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                textBoxUploadFilePath.Text = dialog.FileName;
                textBoxFileName.Text = dialog.SafeFileName;
            }

        }

        private void uploadOnlyButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (!uploadDllFileToBlob())
                    return;
                MessageBox.Show($"DLL file ({textBoxFileName.Text}) uploaded successfully!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unable to upload DLL file to BLOB storage !!\n{ex.ToString()}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool uploadDllFileToBlob()
        {
            if (textBoxAppId.Text == string.Empty)
            {
                MessageBox.Show("App ID is nothing !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (textBoxBlobContainer.Text == string.Empty)
            {
                MessageBox.Show("BLOB Container Name is nothing !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (textBoxFileName.Text == string.Empty)
            {
                MessageBox.Show("DLL File Name is nothing !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (textBoxUploadFilePath.Text == string.Empty)
            {
                MessageBox.Show("DLL File Local Path is nothing !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Get App Master data
            var appMasterProcessor = new AppMasterProcessor(sqlConnectionString, encPassPhrase);
            var appMasterEntity = appMasterProcessor.GetAppMaster(textBoxAppId.Text);

            // Download DLL from BLOB
            string blobStorageConnString = "DefaultEndpointsProtocol=https;AccountName="
                + appMasterEntity.StorageAccount + ";AccountKey=" + appMasterEntity.StorageKey;
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(blobStorageConnString);
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
            CloudBlobContainer container = blobClient.GetContainerReference(textBoxBlobContainer.Text);

            CloudBlockBlob blockBlob = container.GetBlockBlobReference(textBoxFileName.Text);
            using (var fileStream = File.OpenRead(textBoxUploadFilePath.Text))
            {
                blockBlob.UploadFromStream(fileStream);
            }

            return true;
        }

        private void checkBoxUploadToBlob_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxUploadToBlob.Checked)
            {
                if (textBoxUploadFilePath.Text == string.Empty)
                {
                    MessageBox.Show("DLL File Local Path is nothing !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        private void EditAppRoutingForm_Activated(object sender, EventArgs e)
        {
            textBoxAppId.Focus();
        }
    }
}
