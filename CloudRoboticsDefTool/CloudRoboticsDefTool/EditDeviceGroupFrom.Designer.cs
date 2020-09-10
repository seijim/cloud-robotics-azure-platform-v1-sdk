namespace CloudRoboticsDefTool
{
    partial class EditDeviceGroupFrom
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
            this.comboBoxDeviceGroupId = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.createButton = new System.Windows.Forms.Button();
            this.updateButton = new System.Windows.Forms.Button();
            this.listBoxDevices = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.listBoxSelectedDevices = new System.Windows.Forms.ListBox();
            this.joinListButton = new System.Windows.Forms.Button();
            this.removeListButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBoxDeviceGroupId
            // 
            this.comboBoxDeviceGroupId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxDeviceGroupId.FormattingEnabled = true;
            this.comboBoxDeviceGroupId.Location = new System.Drawing.Point(284, 28);
            this.comboBoxDeviceGroupId.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.comboBoxDeviceGroupId.Name = "comboBoxDeviceGroupId";
            this.comboBoxDeviceGroupId.Size = new System.Drawing.Size(602, 32);
            this.comboBoxDeviceGroupId.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(26, 28);
            this.label6.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(216, 30);
            this.label6.TabIndex = 37;
            this.label6.Text = "Device Group ID:";
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cancelButton.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cancelButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cancelButton.Location = new System.Drawing.Point(581, 724);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(4);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(154, 50);
            this.cancelButton.TabIndex = 7;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // createButton
            // 
            this.createButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.createButton.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.createButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.createButton.Location = new System.Drawing.Point(176, 724);
            this.createButton.Margin = new System.Windows.Forms.Padding(4);
            this.createButton.Name = "createButton";
            this.createButton.Size = new System.Drawing.Size(154, 50);
            this.createButton.TabIndex = 5;
            this.createButton.Text = "Create";
            this.createButton.UseVisualStyleBackColor = true;
            this.createButton.Click += new System.EventHandler(this.createButton_Click);
            // 
            // updateButton
            // 
            this.updateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.updateButton.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.updateButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.updateButton.Location = new System.Drawing.Point(379, 724);
            this.updateButton.Margin = new System.Windows.Forms.Padding(4);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(154, 50);
            this.updateButton.TabIndex = 6;
            this.updateButton.Text = "Update";
            this.updateButton.UseVisualStyleBackColor = true;
            this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
            // 
            // listBoxDevices
            // 
            this.listBoxDevices.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listBoxDevices.FormattingEnabled = true;
            this.listBoxDevices.ItemHeight = 24;
            this.listBoxDevices.Location = new System.Drawing.Point(30, 140);
            this.listBoxDevices.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.listBoxDevices.Name = "listBoxDevices";
            this.listBoxDevices.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBoxDevices.Size = new System.Drawing.Size(357, 556);
            this.listBoxDevices.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(130, 98);
            this.label1.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 30);
            this.label1.TabIndex = 41;
            this.label1.Text = "Device List";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(581, 98);
            this.label2.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(246, 30);
            this.label2.TabIndex = 42;
            this.label2.Text = "Selected Device List";
            // 
            // listBoxSelectedDevices
            // 
            this.listBoxSelectedDevices.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxSelectedDevices.FormattingEnabled = true;
            this.listBoxSelectedDevices.ItemHeight = 24;
            this.listBoxSelectedDevices.Location = new System.Drawing.Point(527, 140);
            this.listBoxSelectedDevices.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.listBoxSelectedDevices.Name = "listBoxSelectedDevices";
            this.listBoxSelectedDevices.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBoxSelectedDevices.Size = new System.Drawing.Size(357, 556);
            this.listBoxSelectedDevices.TabIndex = 3;
            // 
            // joinListButton
            // 
            this.joinListButton.Location = new System.Drawing.Point(414, 358);
            this.joinListButton.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.joinListButton.Name = "joinListButton";
            this.joinListButton.Size = new System.Drawing.Size(91, 42);
            this.joinListButton.TabIndex = 2;
            this.joinListButton.Text = ">>";
            this.joinListButton.UseVisualStyleBackColor = true;
            this.joinListButton.Click += new System.EventHandler(this.joinListButton_Click);
            // 
            // removeListButton
            // 
            this.removeListButton.Location = new System.Drawing.Point(414, 478);
            this.removeListButton.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.removeListButton.Name = "removeListButton";
            this.removeListButton.Size = new System.Drawing.Size(91, 42);
            this.removeListButton.TabIndex = 4;
            this.removeListButton.Text = "<<";
            this.removeListButton.UseVisualStyleBackColor = true;
            this.removeListButton.Click += new System.EventHandler(this.removeListButton_Click);
            // 
            // EditDeviceGroupFrom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(921, 796);
            this.Controls.Add(this.removeListButton);
            this.Controls.Add(this.joinListButton);
            this.Controls.Add(this.listBoxSelectedDevices);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBoxDevices);
            this.Controls.Add(this.updateButton);
            this.Controls.Add(this.comboBoxDeviceGroupId);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.createButton);
            this.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.Name = "EditDeviceGroupFrom";
            this.Text = "Edit Device Group";
            this.Activated += new System.EventHandler(this.EditDeviceGroupFrom_Activated);
            this.Load += new System.EventHandler(this.EditDeviceGroupFrom_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxDeviceGroupId;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button createButton;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.ListBox listBoxDevices;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listBoxSelectedDevices;
        private System.Windows.Forms.Button joinListButton;
        private System.Windows.Forms.Button removeListButton;
    }
}