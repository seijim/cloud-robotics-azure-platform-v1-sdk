namespace CloudRoboticsDefTool
{
    partial class DeviceUpdateForm
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
            this.restoreButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.updateButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.deviceIDComboBox = new System.Windows.Forms.ComboBox();
            this.secondaryKeyTextBox = new System.Windows.Forms.TextBox();
            this.primaryKeyTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.deviceIDLabel = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.comboBoxDevMDeviceType = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBoxDevMStatus = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxDevMDesc = new System.Windows.Forms.TextBox();
            this.textBoxDevMRescGrpId = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // restoreButton
            // 
            this.restoreButton.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.restoreButton.Location = new System.Drawing.Point(350, 535);
            this.restoreButton.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.restoreButton.Name = "restoreButton";
            this.restoreButton.Size = new System.Drawing.Size(159, 48);
            this.restoreButton.TabIndex = 8;
            this.restoreButton.Text = "Restore";
            this.restoreButton.UseVisualStyleBackColor = true;
            this.restoreButton.Click += new System.EventHandler(this.restoreButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cancelButton.Location = new System.Drawing.Point(630, 535);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(4);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(159, 48);
            this.cancelButton.TabIndex = 9;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // updateButton
            // 
            this.updateButton.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.updateButton.Location = new System.Drawing.Point(77, 535);
            this.updateButton.Margin = new System.Windows.Forms.Padding(4);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(159, 48);
            this.updateButton.TabIndex = 7;
            this.updateButton.Text = "Update";
            this.updateButton.UseVisualStyleBackColor = true;
            this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.deviceIDComboBox);
            this.groupBox1.Controls.Add(this.secondaryKeyTextBox);
            this.groupBox1.Controls.Add(this.primaryKeyTextBox);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.deviceIDLabel);
            this.groupBox1.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(864, 193);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "IoT Hub Device";
            // 
            // deviceIDComboBox
            // 
            this.deviceIDComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.deviceIDComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.deviceIDComboBox.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.deviceIDComboBox.FormattingEnabled = true;
            this.deviceIDComboBox.Location = new System.Drawing.Point(277, 45);
            this.deviceIDComboBox.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.deviceIDComboBox.Name = "deviceIDComboBox";
            this.deviceIDComboBox.Size = new System.Drawing.Size(567, 38);
            this.deviceIDComboBox.TabIndex = 0;
            this.deviceIDComboBox.DropDownClosed += new System.EventHandler(this.deviceIDComboBox_DropDownClosed);
            // 
            // secondaryKeyTextBox
            // 
            this.secondaryKeyTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.secondaryKeyTextBox.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.secondaryKeyTextBox.Location = new System.Drawing.Point(277, 139);
            this.secondaryKeyTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.secondaryKeyTextBox.Name = "secondaryKeyTextBox";
            this.secondaryKeyTextBox.Size = new System.Drawing.Size(567, 38);
            this.secondaryKeyTextBox.TabIndex = 2;
            // 
            // primaryKeyTextBox
            // 
            this.primaryKeyTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.primaryKeyTextBox.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.primaryKeyTextBox.Location = new System.Drawing.Point(277, 93);
            this.primaryKeyTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.primaryKeyTextBox.Name = "primaryKeyTextBox";
            this.primaryKeyTextBox.Size = new System.Drawing.Size(567, 38);
            this.primaryKeyTextBox.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(27, 142);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(197, 30);
            this.label4.TabIndex = 16;
            this.label4.Text = "Secondary Key:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(27, 96);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(165, 30);
            this.label3.TabIndex = 15;
            this.label3.Text = "Primary Key:";
            // 
            // deviceIDLabel
            // 
            this.deviceIDLabel.AutoSize = true;
            this.deviceIDLabel.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.deviceIDLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.deviceIDLabel.Location = new System.Drawing.Point(27, 48);
            this.deviceIDLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.deviceIDLabel.Name = "deviceIDLabel";
            this.deviceIDLabel.Size = new System.Drawing.Size(137, 30);
            this.deviceIDLabel.TabIndex = 14;
            this.deviceIDLabel.Text = "Device ID:";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.comboBoxDevMDeviceType);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.comboBoxDevMStatus);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.textBoxDevMDesc);
            this.groupBox2.Controls.Add(this.textBoxDevMRescGrpId);
            this.groupBox2.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.groupBox2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.groupBox2.Location = new System.Drawing.Point(12, 240);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(864, 277);
            this.groupBox2.TabIndex = 27;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "RBFX Device Master Table";
            // 
            // comboBoxDevMDeviceType
            // 
            this.comboBoxDevMDeviceType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxDevMDeviceType.FormattingEnabled = true;
            this.comboBoxDevMDeviceType.ItemHeight = 30;
            this.comboBoxDevMDeviceType.Location = new System.Drawing.Point(277, 43);
            this.comboBoxDevMDeviceType.Name = "comboBoxDevMDeviceType";
            this.comboBoxDevMDeviceType.Size = new System.Drawing.Size(567, 38);
            this.comboBoxDevMDeviceType.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label7.Location = new System.Drawing.Point(29, 203);
            this.label7.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(154, 30);
            this.label7.TabIndex = 33;
            this.label7.Text = "Description:";
            // 
            // comboBoxDevMStatus
            // 
            this.comboBoxDevMStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxDevMStatus.FormattingEnabled = true;
            this.comboBoxDevMStatus.ItemHeight = 30;
            this.comboBoxDevMStatus.Location = new System.Drawing.Point(277, 87);
            this.comboBoxDevMStatus.Name = "comboBoxDevMStatus";
            this.comboBoxDevMStatus.Size = new System.Drawing.Size(567, 38);
            this.comboBoxDevMStatus.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(29, 137);
            this.label1.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(245, 30);
            this.label1.TabIndex = 31;
            this.label1.Text = "Resource Group ID:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(29, 90);
            this.label5.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 30);
            this.label5.TabIndex = 30;
            this.label5.Text = "Status:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(29, 46);
            this.label6.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(165, 30);
            this.label6.TabIndex = 29;
            this.label6.Text = "Device Type:";
            // 
            // textBoxDevMDesc
            // 
            this.textBoxDevMDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxDevMDesc.ForeColor = System.Drawing.SystemColors.ControlText;
            this.textBoxDevMDesc.Location = new System.Drawing.Point(277, 179);
            this.textBoxDevMDesc.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.textBoxDevMDesc.Multiline = true;
            this.textBoxDevMDesc.Name = "textBoxDevMDesc";
            this.textBoxDevMDesc.Size = new System.Drawing.Size(567, 89);
            this.textBoxDevMDesc.TabIndex = 6;
            // 
            // textBoxDevMRescGrpId
            // 
            this.textBoxDevMRescGrpId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxDevMRescGrpId.ForeColor = System.Drawing.SystemColors.ControlText;
            this.textBoxDevMRescGrpId.Location = new System.Drawing.Point(277, 134);
            this.textBoxDevMRescGrpId.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.textBoxDevMRescGrpId.Name = "textBoxDevMRescGrpId";
            this.textBoxDevMRescGrpId.Size = new System.Drawing.Size(567, 38);
            this.textBoxDevMRescGrpId.TabIndex = 5;
            // 
            // DeviceUpdateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(888, 606);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.restoreButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.updateButton);
            this.Font = new System.Drawing.Font("MS UI Gothic", 9F);
            this.Name = "DeviceUpdateForm";
            this.Text = "DeviceUpdateForm";
            this.Activated += new System.EventHandler(this.DeviceUpdateForm_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DeviceUpdateForm_FormClosing);
            this.Load += new System.EventHandler(this.DeviceUpdateForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button restoreButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox deviceIDComboBox;
        private System.Windows.Forms.TextBox secondaryKeyTextBox;
        private System.Windows.Forms.TextBox primaryKeyTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label deviceIDLabel;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox comboBoxDevMDeviceType;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBoxDevMStatus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxDevMDesc;
        private System.Windows.Forms.TextBox textBoxDevMRescGrpId;
    }
}