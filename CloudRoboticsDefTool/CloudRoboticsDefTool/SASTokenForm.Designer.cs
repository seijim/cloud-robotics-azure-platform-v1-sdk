namespace CloudRoboticsDefTool
{
    partial class SASTokenForm
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
            this.deviceKeyComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.sasRichTextBox = new System.Windows.Forms.RichTextBox();
            this.deviceIDComboBox = new System.Windows.Forms.ComboBox();
            this.doneButton = new System.Windows.Forms.Button();
            this.generateButton = new System.Windows.Forms.Button();
            this.deviceIDLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // deviceKeyComboBox
            // 
            this.deviceKeyComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.deviceKeyComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.deviceKeyComboBox.FormattingEnabled = true;
            this.deviceKeyComboBox.Location = new System.Drawing.Point(205, 122);
            this.deviceKeyComboBox.Margin = new System.Windows.Forms.Padding(8);
            this.deviceKeyComboBox.Name = "deviceKeyComboBox";
            this.deviceKeyComboBox.Size = new System.Drawing.Size(765, 38);
            this.deviceKeyComboBox.TabIndex = 1;
            this.deviceKeyComboBox.SelectedIndexChanged += new System.EventHandler(this.deviceKeyComboBox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 129);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(146, 30);
            this.label2.TabIndex = 33;
            this.label2.Text = "DeviceKeys";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(198, 221);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 30);
            this.label1.TabIndex = 32;
            this.label1.Text = "TTL (Days)";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDown1.Location = new System.Drawing.Point(423, 205);
            this.numericUpDown1.Margin = new System.Windows.Forms.Padding(5);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            365,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(548, 38);
            this.numericUpDown1.TabIndex = 2;
            // 
            // sasRichTextBox
            // 
            this.sasRichTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sasRichTextBox.Location = new System.Drawing.Point(70, 319);
            this.sasRichTextBox.Margin = new System.Windows.Forms.Padding(5);
            this.sasRichTextBox.Name = "sasRichTextBox";
            this.sasRichTextBox.ReadOnly = true;
            this.sasRichTextBox.Size = new System.Drawing.Size(900, 170);
            this.sasRichTextBox.TabIndex = 31;
            this.sasRichTextBox.TabStop = false;
            this.sasRichTextBox.Text = "";
            // 
            // deviceIDComboBox
            // 
            this.deviceIDComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.deviceIDComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.deviceIDComboBox.FormattingEnabled = true;
            this.deviceIDComboBox.Location = new System.Drawing.Point(205, 44);
            this.deviceIDComboBox.Margin = new System.Windows.Forms.Padding(8);
            this.deviceIDComboBox.Name = "deviceIDComboBox";
            this.deviceIDComboBox.Size = new System.Drawing.Size(765, 38);
            this.deviceIDComboBox.TabIndex = 0;
            this.deviceIDComboBox.SelectedIndexChanged += new System.EventHandler(this.deviceIDComboBox_SelectedIndexChanged);
            // 
            // doneButton
            // 
            this.doneButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.doneButton.Location = new System.Drawing.Point(579, 522);
            this.doneButton.Margin = new System.Windows.Forms.Padding(5);
            this.doneButton.Name = "doneButton";
            this.doneButton.Size = new System.Drawing.Size(195, 60);
            this.doneButton.TabIndex = 4;
            this.doneButton.Text = "Done";
            this.doneButton.UseVisualStyleBackColor = true;
            this.doneButton.Click += new System.EventHandler(this.doneButton_Click);
            // 
            // generateButton
            // 
            this.generateButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.generateButton.Location = new System.Drawing.Point(240, 522);
            this.generateButton.Margin = new System.Windows.Forms.Padding(5);
            this.generateButton.Name = "generateButton";
            this.generateButton.Size = new System.Drawing.Size(195, 60);
            this.generateButton.TabIndex = 3;
            this.generateButton.Text = "Generate";
            this.generateButton.UseVisualStyleBackColor = true;
            this.generateButton.Click += new System.EventHandler(this.generateButton_Click);
            // 
            // deviceIDLabel
            // 
            this.deviceIDLabel.AutoSize = true;
            this.deviceIDLabel.Location = new System.Drawing.Point(63, 50);
            this.deviceIDLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.deviceIDLabel.Name = "deviceIDLabel";
            this.deviceIDLabel.Size = new System.Drawing.Size(119, 30);
            this.deviceIDLabel.TabIndex = 30;
            this.deviceIDLabel.Text = "DeviceID";
            // 
            // SASTokenForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1013, 598);
            this.Controls.Add(this.deviceKeyComboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.sasRichTextBox);
            this.Controls.Add(this.deviceIDComboBox);
            this.Controls.Add(this.doneButton);
            this.Controls.Add(this.generateButton);
            this.Controls.Add(this.deviceIDLabel);
            this.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "SASTokenForm";
            this.Text = "SASTokenForm";
            this.Activated += new System.EventHandler(this.SASTokenForm_Activated);
            this.Load += new System.EventHandler(this.SASTokenForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox deviceKeyComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.RichTextBox sasRichTextBox;
        private System.Windows.Forms.ComboBox deviceIDComboBox;
        private System.Windows.Forms.Button doneButton;
        private System.Windows.Forms.Button generateButton;
        private System.Windows.Forms.Label deviceIDLabel;
    }
}