namespace CloudRoboticsTestDriver
{
    partial class TestDriverForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TestDriverForm));
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.saveSqlConnStringButton = new System.Windows.Forms.Button();
            this.saveEncPassphraseButton = new System.Windows.Forms.Button();
            this.textBoxSQLConnectionString = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxEncPassphrase = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxClassName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.checkBoxSkipAppRouter = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxOutput = new System.Windows.Forms.TextBox();
            this.textBoxDeviceId = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.searchButton = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.textBoxDllFilePath = new System.Windows.Forms.TextBox();
            this.textBoxInput = new System.Windows.Forms.TextBox();
            this.exitAppButton = new System.Windows.Forms.Button();
            this.CallAppButton = new System.Windows.Forms.Button();
            this.groupBox5.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Controls.Add(this.saveSqlConnStringButton);
            this.groupBox5.Controls.Add(this.saveEncPassphraseButton);
            this.groupBox5.Controls.Add(this.textBoxSQLConnectionString);
            this.groupBox5.Controls.Add(this.label1);
            this.groupBox5.Controls.Add(this.textBoxEncPassphrase);
            this.groupBox5.Controls.Add(this.label16);
            this.groupBox5.Font = new System.Drawing.Font("Segoe UI Symbol", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.ForeColor = System.Drawing.SystemColors.Highlight;
            this.groupBox5.Location = new System.Drawing.Point(20, 12);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.groupBox5.Size = new System.Drawing.Size(1333, 192);
            this.groupBox5.TabIndex = 8;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Configuration";
            // 
            // saveSqlConnStringButton
            // 
            this.saveSqlConnStringButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.saveSqlConnStringButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.saveSqlConnStringButton.Location = new System.Drawing.Point(1073, 116);
            this.saveSqlConnStringButton.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.saveSqlConnStringButton.Name = "saveSqlConnStringButton";
            this.saveSqlConnStringButton.Size = new System.Drawing.Size(217, 56);
            this.saveSqlConnStringButton.TabIndex = 22;
            this.saveSqlConnStringButton.Text = "Save";
            this.saveSqlConnStringButton.UseVisualStyleBackColor = true;
            this.saveSqlConnStringButton.Click += new System.EventHandler(this.saveSqlConnStringButton_Click);
            // 
            // saveEncPassphraseButton
            // 
            this.saveEncPassphraseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.saveEncPassphraseButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.saveEncPassphraseButton.Location = new System.Drawing.Point(1073, 40);
            this.saveEncPassphraseButton.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.saveEncPassphraseButton.Name = "saveEncPassphraseButton";
            this.saveEncPassphraseButton.Size = new System.Drawing.Size(217, 56);
            this.saveEncPassphraseButton.TabIndex = 19;
            this.saveEncPassphraseButton.Text = "Save";
            this.saveEncPassphraseButton.UseVisualStyleBackColor = true;
            this.saveEncPassphraseButton.Click += new System.EventHandler(this.saveEncPassphraseButton_Click);
            // 
            // textBoxSQLConnectionString
            // 
            this.textBoxSQLConnectionString.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSQLConnectionString.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.textBoxSQLConnectionString.Location = new System.Drawing.Point(340, 126);
            this.textBoxSQLConnectionString.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.textBoxSQLConnectionString.Name = "textBoxSQLConnectionString";
            this.textBoxSQLConnectionString.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.textBoxSQLConnectionString.Size = new System.Drawing.Size(713, 39);
            this.textBoxSQLConnectionString.TabIndex = 21;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(24, 126);
            this.label1.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(262, 32);
            this.label1.TabIndex = 20;
            this.label1.Text = "SQL Connection String:";
            // 
            // textBoxEncPassphrase
            // 
            this.textBoxEncPassphrase.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxEncPassphrase.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.textBoxEncPassphrase.Location = new System.Drawing.Point(340, 48);
            this.textBoxEncPassphrase.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.textBoxEncPassphrase.Name = "textBoxEncPassphrase";
            this.textBoxEncPassphrase.PasswordChar = '●';
            this.textBoxEncPassphrase.Size = new System.Drawing.Size(713, 39);
            this.textBoxEncPassphrase.TabIndex = 18;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label16.Location = new System.Drawing.Point(24, 52);
            this.label16.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(256, 32);
            this.label16.TabIndex = 16;
            this.label16.Text = "Encryption Passphrase:";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.textBoxClassName);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.checkBoxSkipAppRouter);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBoxOutput);
            this.groupBox1.Controls.Add(this.textBoxDeviceId);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.searchButton);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.textBoxDllFilePath);
            this.groupBox1.Controls.Add(this.textBoxInput);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI Symbol", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.groupBox1.Location = new System.Drawing.Point(15, 204);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.groupBox1.Size = new System.Drawing.Size(1338, 610);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Application (DLL) Call Setting";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Symbol", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(887, 164);
            this.label6.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(364, 32);
            this.label6.TabIndex = 45;
            this.label6.Text = "ex. <NameSpace>.<ClassName>";
            // 
            // textBoxClassName
            // 
            this.textBoxClassName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxClassName.ForeColor = System.Drawing.SystemColors.ControlText;
            this.textBoxClassName.Location = new System.Drawing.Point(345, 160);
            this.textBoxClassName.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.textBoxClassName.Name = "textBoxClassName";
            this.textBoxClassName.Size = new System.Drawing.Size(517, 39);
            this.textBoxClassName.TabIndex = 41;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Symbol", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(26, 164);
            this.label5.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(144, 32);
            this.label5.TabIndex = 41;
            this.label5.Text = "Class Name:";
            // 
            // checkBoxSkipAppRouter
            // 
            this.checkBoxSkipAppRouter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxSkipAppRouter.AutoSize = true;
            this.checkBoxSkipAppRouter.Checked = true;
            this.checkBoxSkipAppRouter.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxSkipAppRouter.Location = new System.Drawing.Point(918, 108);
            this.checkBoxSkipAppRouter.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.checkBoxSkipAppRouter.Name = "checkBoxSkipAppRouter";
            this.checkBoxSkipAppRouter.Size = new System.Drawing.Size(392, 36);
            this.checkBoxSkipAppRouter.TabIndex = 44;
            this.checkBoxSkipAppRouter.Text = "Skip creating App Router Cache ";
            this.checkBoxSkipAppRouter.UseVisualStyleBackColor = true;
            this.checkBoxSkipAppRouter.CheckedChanged += new System.EventHandler(this.checkBoxSkipAppRouter_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Symbol", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(29, 489);
            this.label4.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 32);
            this.label4.TabIndex = 43;
            this.label4.Text = "Output:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Symbol", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(29, 287);
            this.label3.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 32);
            this.label3.TabIndex = 42;
            this.label3.Text = "Input:";
            // 
            // textBoxOutput
            // 
            this.textBoxOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxOutput.Location = new System.Drawing.Point(346, 419);
            this.textBoxOutput.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxOutput.Multiline = true;
            this.textBoxOutput.Name = "textBoxOutput";
            this.textBoxOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxOutput.Size = new System.Drawing.Size(954, 176);
            this.textBoxOutput.TabIndex = 41;
            // 
            // textBoxDeviceId
            // 
            this.textBoxDeviceId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxDeviceId.ForeColor = System.Drawing.SystemColors.ControlText;
            this.textBoxDeviceId.Location = new System.Drawing.Point(345, 104);
            this.textBoxDeviceId.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.textBoxDeviceId.Name = "textBoxDeviceId";
            this.textBoxDeviceId.Size = new System.Drawing.Size(517, 39);
            this.textBoxDeviceId.TabIndex = 40;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Symbol", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(26, 108);
            this.label2.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 32);
            this.label2.TabIndex = 39;
            this.label2.Text = "Device ID:";
            // 
            // searchButton
            // 
            this.searchButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.searchButton.Font = new System.Drawing.Font("Meiryo UI", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.searchButton.ForeColor = System.Drawing.SystemColors.Desktop;
            this.searchButton.Location = new System.Drawing.Point(1186, 52);
            this.searchButton.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(113, 44);
            this.searchButton.TabIndex = 38;
            this.searchButton.Text = "search";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Segoe UI Symbol", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label15.Location = new System.Drawing.Point(26, 56);
            this.label15.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(218, 32);
            this.label15.TabIndex = 37;
            this.label15.Text = "DLL File Local Path:";
            // 
            // textBoxDllFilePath
            // 
            this.textBoxDllFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxDllFilePath.ForeColor = System.Drawing.SystemColors.ControlText;
            this.textBoxDllFilePath.Location = new System.Drawing.Point(345, 54);
            this.textBoxDllFilePath.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.textBoxDllFilePath.Name = "textBoxDllFilePath";
            this.textBoxDllFilePath.Size = new System.Drawing.Size(813, 39);
            this.textBoxDllFilePath.TabIndex = 36;
            // 
            // textBoxInput
            // 
            this.textBoxInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxInput.Location = new System.Drawing.Point(345, 216);
            this.textBoxInput.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxInput.Multiline = true;
            this.textBoxInput.Name = "textBoxInput";
            this.textBoxInput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxInput.Size = new System.Drawing.Size(954, 195);
            this.textBoxInput.TabIndex = 23;
            this.textBoxInput.Text = resources.GetString("textBoxInput.Text");
            // 
            // exitAppButton
            // 
            this.exitAppButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.exitAppButton.Font = new System.Drawing.Font("Segoe UI Symbol", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitAppButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.exitAppButton.Location = new System.Drawing.Point(1136, 824);
            this.exitAppButton.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.exitAppButton.Name = "exitAppButton";
            this.exitAppButton.Size = new System.Drawing.Size(217, 56);
            this.exitAppButton.TabIndex = 39;
            this.exitAppButton.Text = "Exit";
            this.exitAppButton.UseVisualStyleBackColor = true;
            this.exitAppButton.Click += new System.EventHandler(this.exitAppButton_Click);
            // 
            // CallAppButton
            // 
            this.CallAppButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CallAppButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CallAppButton.Location = new System.Drawing.Point(875, 824);
            this.CallAppButton.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.CallAppButton.Name = "CallAppButton";
            this.CallAppButton.Size = new System.Drawing.Size(217, 56);
            this.CallAppButton.TabIndex = 40;
            this.CallAppButton.Text = "Call App";
            this.CallAppButton.UseVisualStyleBackColor = true;
            this.CallAppButton.Click += new System.EventHandler(this.callAppButton_Click);
            // 
            // TestDriverForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1387, 983);
            this.Controls.Add(this.CallAppButton);
            this.Controls.Add(this.exitAppButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox5);
            this.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.Name = "TestDriverForm";
            this.Text = "Cloud Robotics FX Test Driver for App(DLL) Development";
            this.Load += new System.EventHandler(this.TestDriverForm_Load);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button saveEncPassphraseButton;
        private System.Windows.Forms.TextBox textBoxEncPassphrase;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button saveSqlConnStringButton;
        private System.Windows.Forms.TextBox textBoxSQLConnectionString;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox textBoxDllFilePath;
        private System.Windows.Forms.TextBox textBoxInput;
        private System.Windows.Forms.Button exitAppButton;
        private System.Windows.Forms.TextBox textBoxDeviceId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxOutput;
        private System.Windows.Forms.Button CallAppButton;
        private System.Windows.Forms.CheckBox checkBoxSkipAppRouter;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxClassName;
        private System.Windows.Forms.Label label5;
    }
}

