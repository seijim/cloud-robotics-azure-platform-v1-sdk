using System;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace CloudRoboticsDefTool
{
    public partial class EditMessageForm : Form
    {
        private string jsonMessages;

        public EditMessageForm(string jsonMessages)
        {
            InitializeComponent();

            this.jsonMessages = jsonMessages;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Save the setting
                Properties.Settings.Default["CloudRobotics_JsonMessages"] = textBoxJsonMessage.Text;
                var joMessage = JsonConvert.DeserializeObject<JObject>(textBoxJsonMessage.Text);
                Properties.Settings.Default.Save();

                MessageBox.Show("JSON Message saved successfully!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unable to save JSON Messages\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            DeviceSimulatorForm.jsonMessages = jsonMessages = textBoxJsonMessage.Text;
        }

        private void EditMessageForm_Load(object sender, EventArgs e)
        {
            this.Size = new System.Drawing.Size(640, 480);

            textBoxJsonMessage.Text = jsonMessages;
        }

        private void EditMessageForm_Activated(object sender, EventArgs e)
        {
            textBoxJsonMessage.Focus();
        }
    }
}
