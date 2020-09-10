namespace CloudRoboticsDefTool
{
    partial class DeviceSimulatorForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkBoxSendLoop = new System.Windows.Forms.CheckBox();
            this.textBoxQueStorageConnString = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxOutput = new System.Windows.Forms.TextBox();
            this.textBoxDeviceKey = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxDeviceId = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxIotHubHostName = new System.Windows.Forms.TextBox();
            this.buttonReceive = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonSend = new System.Windows.Forms.Button();
            this.buttonMessageEditForm = new System.Windows.Forms.Button();
            this.comboBoxJson = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textBoxInput = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.Controls.Add(this.checkBoxSendLoop);
            this.panel1.Controls.Add(this.textBoxQueStorageConnString);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.textBoxOutput);
            this.panel1.Controls.Add(this.textBoxDeviceKey);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.comboBoxDeviceId);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.textBoxIotHubHostName);
            this.panel1.Controls.Add(this.buttonReceive);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.buttonSend);
            this.panel1.Controls.Add(this.buttonMessageEditForm);
            this.panel1.Controls.Add(this.comboBoxJson);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.textBoxInput);
            this.panel1.Location = new System.Drawing.Point(31, 19);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1300, 857);
            this.panel1.TabIndex = 22;
            // 
            // checkBoxSendLoop
            // 
            this.checkBoxSendLoop.AutoSize = true;
            this.checkBoxSendLoop.Font = new System.Drawing.Font("Segoe UI Symbol", 9F);
            this.checkBoxSendLoop.Location = new System.Drawing.Point(739, 481);
            this.checkBoxSendLoop.Name = "checkBoxSendLoop";
            this.checkBoxSendLoop.Size = new System.Drawing.Size(161, 36);
            this.checkBoxSendLoop.TabIndex = 29;
            this.checkBoxSendLoop.Text = "Send Loop";
            this.checkBoxSendLoop.UseVisualStyleBackColor = true;
            this.checkBoxSendLoop.CheckedChanged += new System.EventHandler(this.checkBoxSendLoop_CheckedChanged);
            // 
            // textBoxQueStorageConnString
            // 
            this.textBoxQueStorageConnString.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxQueStorageConnString.Location = new System.Drawing.Point(820, 552);
            this.textBoxQueStorageConnString.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.textBoxQueStorageConnString.Name = "textBoxQueStorageConnString";
            this.textBoxQueStorageConnString.Size = new System.Drawing.Size(461, 31);
            this.textBoxQueStorageConnString.TabIndex = 28;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Symbol", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(516, 550);
            this.label4.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(290, 32);
            this.label4.TabIndex = 27;
            this.label4.Text = "Queue Storage (Option) : ";
            // 
            // textBoxOutput
            // 
            this.textBoxOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxOutput.Location = new System.Drawing.Point(4, 666);
            this.textBoxOutput.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.textBoxOutput.Multiline = true;
            this.textBoxOutput.Name = "textBoxOutput";
            this.textBoxOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxOutput.Size = new System.Drawing.Size(1276, 183);
            this.textBoxOutput.TabIndex = 26;
            // 
            // textBoxDeviceKey
            // 
            this.textBoxDeviceKey.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxDeviceKey.Location = new System.Drawing.Point(674, 609);
            this.textBoxDeviceKey.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.textBoxDeviceKey.Name = "textBoxDeviceKey";
            this.textBoxDeviceKey.Size = new System.Drawing.Size(607, 31);
            this.textBoxDeviceKey.TabIndex = 25;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Symbol", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(516, 607);
            this.label2.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(145, 32);
            this.label2.TabIndex = 24;
            this.label2.Text = "DeviceKey : ";
            // 
            // comboBoxDeviceId
            // 
            this.comboBoxDeviceId.FormattingEnabled = true;
            this.comboBoxDeviceId.Location = new System.Drawing.Point(143, 607);
            this.comboBoxDeviceId.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.comboBoxDeviceId.Name = "comboBoxDeviceId";
            this.comboBoxDeviceId.Size = new System.Drawing.Size(342, 32);
            this.comboBoxDeviceId.TabIndex = 23;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Symbol", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(7, 550);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(168, 32);
            this.label3.TabIndex = 22;
            this.label3.Text = "IoT Hub Host :";
            // 
            // textBoxIotHubHostName
            // 
            this.textBoxIotHubHostName.Location = new System.Drawing.Point(195, 552);
            this.textBoxIotHubHostName.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.textBoxIotHubHostName.Name = "textBoxIotHubHostName";
            this.textBoxIotHubHostName.Size = new System.Drawing.Size(290, 31);
            this.textBoxIotHubHostName.TabIndex = 21;
            // 
            // buttonReceive
            // 
            this.buttonReceive.Font = new System.Drawing.Font("Segoe UI Symbol", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonReceive.Location = new System.Drawing.Point(4, 470);
            this.buttonReceive.Margin = new System.Windows.Forms.Padding(4);
            this.buttonReceive.Name = "buttonReceive";
            this.buttonReceive.Size = new System.Drawing.Size(444, 57);
            this.buttonReceive.TabIndex = 19;
            this.buttonReceive.Text = "Receive from IoT Hub or Queue";
            this.buttonReceive.UseVisualStyleBackColor = true;
            this.buttonReceive.Click += new System.EventHandler(this.buttonReceive_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Symbol", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 606);
            this.label1.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 32);
            this.label1.TabIndex = 10;
            this.label1.Text = "DeviceId : ";
            // 
            // buttonSend
            // 
            this.buttonSend.Font = new System.Drawing.Font("Segoe UI Symbol", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSend.Location = new System.Drawing.Point(472, 470);
            this.buttonSend.Margin = new System.Windows.Forms.Padding(4);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(243, 57);
            this.buttonSend.TabIndex = 18;
            this.buttonSend.Text = "Send to IoT Hub";
            this.buttonSend.UseVisualStyleBackColor = true;
            this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // buttonMessageEditForm
            // 
            this.buttonMessageEditForm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonMessageEditForm.Font = new System.Drawing.Font("Segoe UI Symbol", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonMessageEditForm.Location = new System.Drawing.Point(932, 467);
            this.buttonMessageEditForm.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.buttonMessageEditForm.Name = "buttonMessageEditForm";
            this.buttonMessageEditForm.Size = new System.Drawing.Size(351, 63);
            this.buttonMessageEditForm.TabIndex = 17;
            this.buttonMessageEditForm.Text = "Launch Message Edit Form";
            this.buttonMessageEditForm.UseVisualStyleBackColor = true;
            this.buttonMessageEditForm.Click += new System.EventHandler(this.buttonMessageEditForm_Click);
            // 
            // comboBoxJson
            // 
            this.comboBoxJson.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxJson.FormattingEnabled = true;
            this.comboBoxJson.Location = new System.Drawing.Point(783, 417);
            this.comboBoxJson.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.comboBoxJson.Name = "comboBoxJson";
            this.comboBoxJson.Size = new System.Drawing.Size(498, 32);
            this.comboBoxJson.TabIndex = 16;
            this.comboBoxJson.SelectedIndexChanged += new System.EventHandler(this.comboBoxJson_SelectedIndexChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.ErrorImage = null;
            this.pictureBox1.Image = global::CloudRoboticsDefTool.Properties.Resources.pepperS;
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(783, 4);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(498, 378);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            // 
            // textBoxInput
            // 
            this.textBoxInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxInput.Location = new System.Drawing.Point(4, 4);
            this.textBoxInput.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxInput.Multiline = true;
            this.textBoxInput.Name = "textBoxInput";
            this.textBoxInput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxInput.Size = new System.Drawing.Size(741, 445);
            this.textBoxInput.TabIndex = 4;
            // 
            // DeviceSimulatorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1363, 894);
            this.Controls.Add(this.panel1);
            this.Name = "DeviceSimulatorForm";
            this.Text = "Device Simulator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DeviceSimulatorForm_FormClosing);
            this.Load += new System.EventHandler(this.DeviceSimulatorForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBoxOutput;
        private System.Windows.Forms.TextBox textBoxDeviceKey;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxDeviceId;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxIotHubHostName;
        private System.Windows.Forms.Button buttonReceive;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonSend;
        private System.Windows.Forms.Button buttonMessageEditForm;
        private System.Windows.Forms.ComboBox comboBoxJson;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox textBoxInput;
        private System.Windows.Forms.CheckBox checkBoxSendLoop;
        private System.Windows.Forms.TextBox textBoxQueStorageConnString;
        private System.Windows.Forms.Label label4;
    }
}