using System;
using System.Windows.Forms;

namespace CloudRoboticsDefTool
{
    public partial class DeviceCreatedForm : Form
    {
        public DeviceCreatedForm(string deviceID, string primaryKey, string secondaryKey)
        {
            InitializeComponent();
            richTextBox.Text = $"ID={deviceID}\nPrimaryKey={primaryKey}\nSecondaryKey={secondaryKey}";
        }

        private void doneButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void richTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void DeviceCreatedForm_Load(object sender, EventArgs e)
        {

        }

        private void DeviceCreatedForm_Activated(object sender, EventArgs e)
        {
            doneButton.Focus();
        }
    }
}
