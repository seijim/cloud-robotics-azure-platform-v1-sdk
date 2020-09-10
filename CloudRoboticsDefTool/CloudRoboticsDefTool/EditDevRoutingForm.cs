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
    public partial class EditDevRoutingForm : Form
    {
        private string sqlConnectionString;
        private DeviceRoutingEntity devRoutingEntity;
        private bool createStatus;

        public EditDevRoutingForm(string sqlConnectionString)
        {
            InitializeComponent();

            this.sqlConnectionString = sqlConnectionString;
            devRoutingEntity = new DeviceRoutingEntity();
            devRoutingEntity.DeviceId = string.Empty;
            devRoutingEntity.RoutingKeyword = CRoboticsConst.RoutingKeywordDefault;
            this.createStatus = true;
        }
        public EditDevRoutingForm(string sqlConnectionString, DeviceRoutingEntity devRoutingEntity)
        {
            InitializeComponent();

            this.sqlConnectionString = sqlConnectionString;
            this.devRoutingEntity = devRoutingEntity;
            if (devRoutingEntity.DeviceId == string.Empty)
            {
                throw (new ApplicationException("Device ID is nothing !!"));
            }

            if (devRoutingEntity.RoutingKeyword == string.Empty)
            {
                throw (new ApplicationException("Routing Keyword is nothing !!"));
            }

            this.createStatus = false;
        }

        private void EditDevRoutingForm_Load(object sender, EventArgs e)
        {
            if (createStatus)
            {
                createButton.Enabled = true;
                updateButton.Enabled = false;

                textBoxDeviceId.Text = devRoutingEntity.DeviceId;
                textBoxRoutingKeyword.Text = devRoutingEntity.RoutingKeyword;
                comboBoxTargetDeviceType.DataSource = CRoboticsConst.TargetDeviceTypeList;
                comboBoxTargetDeviceType.Text = CRoboticsConst.TypeDevice;
                comboBoxStatus.DataSource = CRoboticsConst.StatusList;
            }
            else
            {
                createButton.Enabled = false;
                updateButton.Enabled = true;

                textBoxDeviceId.Text = devRoutingEntity.DeviceId;
                textBoxRoutingKeyword.Text = devRoutingEntity.RoutingKeyword;
                comboBoxTargetDeviceType.DataSource = CRoboticsConst.TargetDeviceTypeList;
                comboBoxTargetDeviceType.Text = devRoutingEntity.TargetType;
                textBoxTargetDevGroupId.Text = devRoutingEntity.TargetDeviceGroupId;
                textBoxTargetDeviceId.Text = devRoutingEntity.TargetDeviceId;
                comboBoxStatus.DataSource = CRoboticsConst.StatusList;
                comboBoxStatus.Text = devRoutingEntity.Status;
                textBoxDesc.Text = devRoutingEntity.Description;
            }
        }

        private void comboBoxTargetDeviceType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxTargetDeviceType.Text.ToUpper().IndexOf("GROUP") >= 0)
            {
                textBoxTargetDevGroupId.Enabled = true;
                textBoxTargetDeviceId.Enabled = false;
            }
            else
            {
                textBoxTargetDevGroupId.Enabled = false;
                textBoxTargetDeviceId.Enabled = true;
            }
        }

        private void createButton_Click(object sender, EventArgs e)
        {
            if (!checkInputData())
                return;

            try
            {
                DeviceRoutingEntity devRoutingEntity = getDeviceRoutingEntity();
                DeviceRoutingProcessor devRouteProcessor = new DeviceRoutingProcessor(sqlConnectionString);
                devRouteProcessor.insertDeviceRouting(devRoutingEntity);

                MessageBox.Show("Device Routing created successfully!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                DeviceRoutingEntity devRoutingEntity = getDeviceRoutingEntity();
                DeviceRoutingProcessor devRouteProcessor = new DeviceRoutingProcessor(sqlConnectionString);
                devRouteProcessor.updateDeviceRouting(devRoutingEntity);

                MessageBox.Show("Device Routing updated successfully!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            this.Close();
        }

        private DeviceRoutingEntity getDeviceRoutingEntity()
        {
            DeviceRoutingEntity devRoutingEntity = new DeviceRoutingEntity();
            devRoutingEntity.DeviceId = textBoxDeviceId.Text;
            devRoutingEntity.RoutingKeyword = textBoxRoutingKeyword.Text;
            devRoutingEntity.TargetType = comboBoxTargetDeviceType.Text;
            devRoutingEntity.TargetDeviceGroupId = textBoxTargetDevGroupId.Text;
            devRoutingEntity.TargetDeviceId = textBoxTargetDeviceId.Text;
            devRoutingEntity.Status = comboBoxStatus.Text;
            devRoutingEntity.Description = textBoxDesc.Text;
            devRoutingEntity.Registered_DateTime = DateTime.Now;

            return devRoutingEntity;
        }
        private bool checkInputData()
        {
            if (textBoxDeviceId.Text == string.Empty)
            {
                MessageBox.Show("Device ID is nothing !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (textBoxRoutingKeyword.Text == string.Empty)
            {
                MessageBox.Show("Routing Keyword is nothing !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (comboBoxTargetDeviceType.Text == string.Empty)
            {
                MessageBox.Show("Target Device Type is nothing !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (comboBoxTargetDeviceType.Text == CRoboticsConst.TypeDeviceGroup && textBoxTargetDevGroupId.Text == string.Empty)
            {
                MessageBox.Show("Target Device Group is nothing !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (comboBoxTargetDeviceType.Text == CRoboticsConst.TypeDevice && textBoxDeviceId.Text == string.Empty)
            {
                MessageBox.Show("Target Device ID is nothing !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void EditDevRoutingForm_Activated(object sender, EventArgs e)
        {
            textBoxDeviceId.Focus();
        }
    }
}
