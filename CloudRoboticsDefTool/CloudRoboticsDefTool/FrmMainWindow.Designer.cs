namespace CloudRoboticsDefTool
{
    partial class FrmMainWindow
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabConnection = new System.Windows.Forms.TabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.buttonUpdateQStorageConnString = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxQStorageConnString = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonUpdateSqlConn = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxSQLConnectionString = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonGenerateSAS = new System.Windows.Forms.Button();
            this.textBoxSASValue = new System.Windows.Forms.TextBox();
            this.ButtonUpdateIoTConn = new System.Windows.Forms.Button();
            this.numericUpDownTTL = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxSAKey = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxSAPolicyName = new System.Windows.Forms.TextBox();
            this.textBoxEndPoint = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxIoTHubConnString = new System.Windows.Forms.TextBox();
            this.tabDeviceMaster = new System.Windows.Forms.TabPage();
            this.groupBoxDevMView = new System.Windows.Forms.GroupBox();
            this.deviceCountLabel = new System.Windows.Forms.Label();
            this.totalLabel = new System.Windows.Forms.Label();
            this.devicesGridView = new System.Windows.Forms.DataGridView();
            this.devicesGridViewContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.LaunchSimulatorMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.copyAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copySelectedToolMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.getDeviceConnectionStringToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBoxDevMAction = new System.Windows.Forms.GroupBox();
            this.sasTokenButton = new System.Windows.Forms.Button();
            this.createDeviceButton = new System.Windows.Forms.Button();
            this.listDevicesButton = new System.Windows.Forms.Button();
            this.updateDeviceButton = new System.Windows.Forms.Button();
            this.deleteDeviceButton = new System.Windows.Forms.Button();
            this.tabDeviceGroup = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBoxDeviceGroupId = new System.Windows.Forms.TextBox();
            this.listDeviceGrpButton = new System.Windows.Forms.Button();
            this.deviceGroupCountLabel = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.deviceGroupsGridView = new System.Windows.Forms.DataGridView();
            this.deviceGroupsGridViewContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyAllToolStripOnGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.copySelectedToolStripOnGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.createDeviceGrpButton = new System.Windows.Forms.Button();
            this.updateDeviceGrpButton = new System.Windows.Forms.Button();
            this.deleteDeviceGrpButton = new System.Windows.Forms.Button();
            this.tabDeviceRouting = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxRoutingDeviceId = new System.Windows.Forms.TextBox();
            this.listDevRoutingButton = new System.Windows.Forms.Button();
            this.devRoutingCountLabel = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.devRoutingsGridView = new System.Windows.Forms.DataGridView();
            this.deviceRoutingsGridViewContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyAllToolStripOnDevRouting = new System.Windows.Forms.ToolStripMenuItem();
            this.copySelectedToolStripOnDevRouting = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.createDevRoutingButton = new System.Windows.Forms.Button();
            this.updateDevRoutingButton = new System.Windows.Forms.Button();
            this.deleteDevRoutingButton = new System.Windows.Forms.Button();
            this.tabAppMaster = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.saveEncPassphraseButton = new System.Windows.Forms.Button();
            this.textBoxEncPassphrase = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.textBoxAppMasterAppId = new System.Windows.Forms.TextBox();
            this.listAppMasterButton = new System.Windows.Forms.Button();
            this.appMasterCountLabel = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.appMastersGridView = new System.Windows.Forms.DataGridView();
            this.appMastersGridViewContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyAllToolStripOnAppMaster = new System.Windows.Forms.ToolStripMenuItem();
            this.copySelectedToolStripOnAppMaster = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.createAppMasterButton = new System.Windows.Forms.Button();
            this.updateAppMasterButton = new System.Windows.Forms.Button();
            this.deleteAppMasterButton = new System.Windows.Forms.Button();
            this.tabAppRouting = new System.Windows.Forms.TabPage();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.textBoxAppRoutingAppId = new System.Windows.Forms.TextBox();
            this.listAppRoutingButton = new System.Windows.Forms.Button();
            this.appRoutingCountLabel = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.appRoutingsGridView = new System.Windows.Forms.DataGridView();
            this.appRoutingsGridViewContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyAllToolStripOnAppRouting = new System.Windows.Forms.ToolStripMenuItem();
            this.copySelectedToolStripOnAppRouting = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.createAppRoutingButton = new System.Windows.Forms.Button();
            this.updateAppRoutingButton = new System.Windows.Forms.Button();
            this.deleteAppRoutingButton = new System.Windows.Forms.Button();
            this.tabFxTraceLog = new System.Windows.Forms.TabPage();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.checkBoxFxTrcDesc = new System.Windows.Forms.CheckBox();
            this.textBoxFxTrcTableName = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.textBoxFxTrcStorgaKey = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.textBoxFxTrcStorgaAccount = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.textBoxFxTraceLogDate = new System.Windows.Forms.TextBox();
            this.listFxTraceLogButton = new System.Windows.Forms.Button();
            this.fxTraceLogCountLabel = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.fxTraceLogGridView = new System.Windows.Forms.DataGridView();
            this.fxTraceLogGridViewContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyAllToolStripOnFxTraceLog = new System.Windows.Forms.ToolStripMenuItem();
            this.copySelectedToolStripOnFxTraceLog = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1.SuspendLayout();
            this.tabConnection.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTTL)).BeginInit();
            this.tabDeviceMaster.SuspendLayout();
            this.groupBoxDevMView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.devicesGridView)).BeginInit();
            this.devicesGridViewContextMenu.SuspendLayout();
            this.groupBoxDevMAction.SuspendLayout();
            this.tabDeviceGroup.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.deviceGroupsGridView)).BeginInit();
            this.deviceGroupsGridViewContextMenu.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabDeviceRouting.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.devRoutingsGridView)).BeginInit();
            this.deviceRoutingsGridViewContextMenu.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tabAppMaster.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.appMastersGridView)).BeginInit();
            this.appMastersGridViewContextMenu.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.tabAppRouting.SuspendLayout();
            this.groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.appRoutingsGridView)).BeginInit();
            this.appRoutingsGridViewContextMenu.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.tabFxTraceLog.SuspendLayout();
            this.groupBox9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fxTraceLogGridView)).BeginInit();
            this.fxTraceLogGridViewContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabConnection);
            this.tabControl1.Controls.Add(this.tabDeviceMaster);
            this.tabControl1.Controls.Add(this.tabDeviceGroup);
            this.tabControl1.Controls.Add(this.tabDeviceRouting);
            this.tabControl1.Controls.Add(this.tabAppMaster);
            this.tabControl1.Controls.Add(this.tabAppRouting);
            this.tabControl1.Controls.Add(this.tabFxTraceLog);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1807, 1130);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabControl1_Selected);
            // 
            // tabConnection
            // 
            this.tabConnection.Controls.Add(this.panel3);
            this.tabConnection.Controls.Add(this.panel2);
            this.tabConnection.Controls.Add(this.panel1);
            this.tabConnection.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tabConnection.Location = new System.Drawing.Point(8, 44);
            this.tabConnection.Name = "tabConnection";
            this.tabConnection.Padding = new System.Windows.Forms.Padding(3);
            this.tabConnection.Size = new System.Drawing.Size(1791, 1078);
            this.tabConnection.TabIndex = 0;
            this.tabConnection.Text = "Connection";
            this.tabConnection.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.buttonUpdateQStorageConnString);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.textBoxQStorageConnString);
            this.panel3.Location = new System.Drawing.Point(12, 900);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1776, 171);
            this.panel3.TabIndex = 6;
            // 
            // buttonUpdateQStorageConnString
            // 
            this.buttonUpdateQStorageConnString.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonUpdateQStorageConnString.BackColor = System.Drawing.Color.SteelBlue;
            this.buttonUpdateQStorageConnString.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonUpdateQStorageConnString.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonUpdateQStorageConnString.Location = new System.Drawing.Point(1550, 110);
            this.buttonUpdateQStorageConnString.Name = "buttonUpdateQStorageConnString";
            this.buttonUpdateQStorageConnString.Size = new System.Drawing.Size(198, 56);
            this.buttonUpdateQStorageConnString.TabIndex = 8;
            this.buttonUpdateQStorageConnString.Text = "Update";
            this.buttonUpdateQStorageConnString.UseVisualStyleBackColor = false;
            this.buttonUpdateQStorageConnString.Click += new System.EventHandler(this.buttonUpdateQStorageConnString_Click);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label7.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label7.Location = new System.Drawing.Point(20, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(1118, 30);
            this.label7.TabIndex = 7;
            this.label7.Text = "Queue Storage Connection Stirng (**Receive message from queue storage if this val" +
    "ue is set)";
            // 
            // textBoxQStorageConnString
            // 
            this.textBoxQStorageConnString.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxQStorageConnString.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.textBoxQStorageConnString.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.textBoxQStorageConnString.Location = new System.Drawing.Point(19, 54);
            this.textBoxQStorageConnString.Name = "textBoxQStorageConnString";
            this.textBoxQStorageConnString.Size = new System.Drawing.Size(1728, 38);
            this.textBoxQStorageConnString.TabIndex = 6;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.buttonUpdateSqlConn);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.textBoxSQLConnectionString);
            this.panel2.Location = new System.Drawing.Point(11, 606);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1776, 288);
            this.panel2.TabIndex = 5;
            // 
            // buttonUpdateSqlConn
            // 
            this.buttonUpdateSqlConn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonUpdateSqlConn.BackColor = System.Drawing.Color.SteelBlue;
            this.buttonUpdateSqlConn.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonUpdateSqlConn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonUpdateSqlConn.Location = new System.Drawing.Point(1550, 215);
            this.buttonUpdateSqlConn.Name = "buttonUpdateSqlConn";
            this.buttonUpdateSqlConn.Size = new System.Drawing.Size(198, 56);
            this.buttonUpdateSqlConn.TabIndex = 5;
            this.buttonUpdateSqlConn.Text = "Update";
            this.buttonUpdateSqlConn.UseVisualStyleBackColor = false;
            this.buttonUpdateSqlConn.Click += new System.EventHandler(this.buttonUpdateSqlConn_Click);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label6.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label6.Location = new System.Drawing.Point(20, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(393, 30);
            this.label6.TabIndex = 7;
            this.label6.Text = "SQL Database Connection String";
            // 
            // textBoxSQLConnectionString
            // 
            this.textBoxSQLConnectionString.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSQLConnectionString.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.textBoxSQLConnectionString.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.textBoxSQLConnectionString.Location = new System.Drawing.Point(19, 54);
            this.textBoxSQLConnectionString.Multiline = true;
            this.textBoxSQLConnectionString.Name = "textBoxSQLConnectionString";
            this.textBoxSQLConnectionString.Size = new System.Drawing.Size(1730, 144);
            this.textBoxSQLConnectionString.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.buttonGenerateSAS);
            this.panel1.Controls.Add(this.textBoxSASValue);
            this.panel1.Controls.Add(this.ButtonUpdateIoTConn);
            this.panel1.Controls.Add(this.numericUpDownTTL);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.textBoxSAKey);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.textBoxSAPolicyName);
            this.panel1.Controls.Add(this.textBoxEndPoint);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.textBoxIoTHubConnString);
            this.panel1.Location = new System.Drawing.Point(11, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1774, 594);
            this.panel1.TabIndex = 4;
            // 
            // buttonGenerateSAS
            // 
            this.buttonGenerateSAS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonGenerateSAS.BackColor = System.Drawing.Color.SteelBlue;
            this.buttonGenerateSAS.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonGenerateSAS.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonGenerateSAS.Location = new System.Drawing.Point(1491, 421);
            this.buttonGenerateSAS.Name = "buttonGenerateSAS";
            this.buttonGenerateSAS.Size = new System.Drawing.Size(257, 56);
            this.buttonGenerateSAS.TabIndex = 3;
            this.buttonGenerateSAS.Text = "Generate SAS";
            this.buttonGenerateSAS.UseVisualStyleBackColor = false;
            this.buttonGenerateSAS.Click += new System.EventHandler(this.buttonGenerateSAS_Click);
            // 
            // textBoxSASValue
            // 
            this.textBoxSASValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSASValue.BackColor = System.Drawing.SystemColors.HighlightText;
            this.textBoxSASValue.ForeColor = System.Drawing.SystemColors.WindowText;
            this.textBoxSASValue.Location = new System.Drawing.Point(19, 483);
            this.textBoxSASValue.Multiline = true;
            this.textBoxSASValue.Name = "textBoxSASValue";
            this.textBoxSASValue.Size = new System.Drawing.Size(1730, 102);
            this.textBoxSASValue.TabIndex = 5;
            this.textBoxSASValue.TabStop = false;
            // 
            // ButtonUpdateIoTConn
            // 
            this.ButtonUpdateIoTConn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonUpdateIoTConn.BackColor = System.Drawing.Color.SteelBlue;
            this.ButtonUpdateIoTConn.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ButtonUpdateIoTConn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.ButtonUpdateIoTConn.Location = new System.Drawing.Point(1557, 218);
            this.ButtonUpdateIoTConn.Name = "ButtonUpdateIoTConn";
            this.ButtonUpdateIoTConn.Size = new System.Drawing.Size(191, 56);
            this.ButtonUpdateIoTConn.TabIndex = 1;
            this.ButtonUpdateIoTConn.Text = "Update";
            this.ButtonUpdateIoTConn.UseVisualStyleBackColor = false;
            this.ButtonUpdateIoTConn.Click += new System.EventHandler(this.ButtonUpdateIoTConn_Click);
            // 
            // numericUpDownTTL
            // 
            this.numericUpDownTTL.Location = new System.Drawing.Point(385, 414);
            this.numericUpDownTTL.Maximum = new decimal(new int[] {
            365,
            0,
            0,
            0});
            this.numericUpDownTTL.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownTTL.Name = "numericUpDownTTL";
            this.numericUpDownTTL.Size = new System.Drawing.Size(206, 38);
            this.numericUpDownTTL.TabIndex = 2;
            this.numericUpDownTTL.Value = new decimal(new int[] {
            365,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label5.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.label5.Location = new System.Drawing.Point(18, 414);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(144, 30);
            this.label5.TabIndex = 12;
            this.label5.Text = "TTL (Days)";
            // 
            // textBoxSAKey
            // 
            this.textBoxSAKey.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSAKey.Location = new System.Drawing.Point(385, 351);
            this.textBoxSAKey.Name = "textBoxSAKey";
            this.textBoxSAKey.ReadOnly = true;
            this.textBoxSAKey.Size = new System.Drawing.Size(1055, 38);
            this.textBoxSAKey.TabIndex = 11;
            this.textBoxSAKey.TabStop = false;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label4.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.label4.Location = new System.Drawing.Point(18, 354);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(233, 30);
            this.label4.TabIndex = 10;
            this.label4.Text = "Shared Access Key";
            // 
            // textBoxSAPolicyName
            // 
            this.textBoxSAPolicyName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSAPolicyName.Location = new System.Drawing.Point(385, 293);
            this.textBoxSAPolicyName.Name = "textBoxSAPolicyName";
            this.textBoxSAPolicyName.ReadOnly = true;
            this.textBoxSAPolicyName.Size = new System.Drawing.Size(1055, 38);
            this.textBoxSAPolicyName.TabIndex = 9;
            this.textBoxSAPolicyName.TabStop = false;
            // 
            // textBoxEndPoint
            // 
            this.textBoxEndPoint.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxEndPoint.Location = new System.Drawing.Point(385, 237);
            this.textBoxEndPoint.Name = "textBoxEndPoint";
            this.textBoxEndPoint.ReadOnly = true;
            this.textBoxEndPoint.Size = new System.Drawing.Size(1055, 38);
            this.textBoxEndPoint.TabIndex = 7;
            this.textBoxEndPoint.TabStop = false;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label3.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.label3.Location = new System.Drawing.Point(18, 296);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(332, 30);
            this.label3.TabIndex = 8;
            this.label3.Text = "Shared Access Policy Name";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.label2.Location = new System.Drawing.Point(18, 240);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(220, 30);
            this.label2.TabIndex = 6;
            this.label2.Text = "IoT Hub Endpoint";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label1.Location = new System.Drawing.Point(14, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(324, 30);
            this.label1.TabIndex = 5;
            this.label1.Text = "IoT Hub Connection String";
            // 
            // textBoxIoTHubConnString
            // 
            this.textBoxIoTHubConnString.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxIoTHubConnString.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.textBoxIoTHubConnString.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.textBoxIoTHubConnString.Location = new System.Drawing.Point(19, 54);
            this.textBoxIoTHubConnString.Multiline = true;
            this.textBoxIoTHubConnString.Name = "textBoxIoTHubConnString";
            this.textBoxIoTHubConnString.Size = new System.Drawing.Size(1730, 158);
            this.textBoxIoTHubConnString.TabIndex = 0;
            // 
            // tabDeviceMaster
            // 
            this.tabDeviceMaster.Controls.Add(this.groupBoxDevMView);
            this.tabDeviceMaster.Controls.Add(this.groupBoxDevMAction);
            this.tabDeviceMaster.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tabDeviceMaster.Location = new System.Drawing.Point(8, 44);
            this.tabDeviceMaster.Name = "tabDeviceMaster";
            this.tabDeviceMaster.Padding = new System.Windows.Forms.Padding(3);
            this.tabDeviceMaster.Size = new System.Drawing.Size(1791, 1078);
            this.tabDeviceMaster.TabIndex = 1;
            this.tabDeviceMaster.Text = "Device Master";
            this.tabDeviceMaster.UseVisualStyleBackColor = true;
            // 
            // groupBoxDevMView
            // 
            this.groupBoxDevMView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxDevMView.Controls.Add(this.deviceCountLabel);
            this.groupBoxDevMView.Controls.Add(this.totalLabel);
            this.groupBoxDevMView.Controls.Add(this.devicesGridView);
            this.groupBoxDevMView.ForeColor = System.Drawing.SystemColors.Highlight;
            this.groupBoxDevMView.Location = new System.Drawing.Point(6, 149);
            this.groupBoxDevMView.Name = "groupBoxDevMView";
            this.groupBoxDevMView.Size = new System.Drawing.Size(1779, 899);
            this.groupBoxDevMView.TabIndex = 1;
            this.groupBoxDevMView.TabStop = false;
            this.groupBoxDevMView.Text = "IoT Hub Devices | Device Master Table";
            // 
            // deviceCountLabel
            // 
            this.deviceCountLabel.AutoSize = true;
            this.deviceCountLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.deviceCountLabel.Location = new System.Drawing.Point(116, 44);
            this.deviceCountLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.deviceCountLabel.Name = "deviceCountLabel";
            this.deviceCountLabel.Size = new System.Drawing.Size(28, 30);
            this.deviceCountLabel.TabIndex = 15;
            this.deviceCountLabel.Text = "0";
            // 
            // totalLabel
            // 
            this.totalLabel.AutoSize = true;
            this.totalLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.totalLabel.Location = new System.Drawing.Point(12, 44);
            this.totalLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.totalLabel.Name = "totalLabel";
            this.totalLabel.Size = new System.Drawing.Size(78, 30);
            this.totalLabel.TabIndex = 14;
            this.totalLabel.Text = "Total:";
            // 
            // devicesGridView
            // 
            this.devicesGridView.AllowUserToOrderColumns = true;
            this.devicesGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.devicesGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.devicesGridView.ContextMenuStrip = this.devicesGridViewContextMenu;
            this.devicesGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.devicesGridView.Location = new System.Drawing.Point(17, 89);
            this.devicesGridView.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.devicesGridView.MultiSelect = false;
            this.devicesGridView.Name = "devicesGridView";
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black;
            this.devicesGridView.RowsDefaultCellStyle = dataGridViewCellStyle7;
            this.devicesGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.devicesGridView.Size = new System.Drawing.Size(1745, 788);
            this.devicesGridView.TabIndex = 13;
            // 
            // devicesGridViewContextMenu
            // 
            this.devicesGridViewContextMenu.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.devicesGridViewContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LaunchSimulatorMenuItem,
            this.toolStripSeparator2,
            this.copyAllToolStripMenuItem,
            this.copySelectedToolMenuItem,
            this.toolStripSeparator1,
            this.getDeviceConnectionStringToolStripMenuItem});
            this.devicesGridViewContextMenu.Name = "devicesGridViewContextMenu";
            this.devicesGridViewContextMenu.Size = new System.Drawing.Size(547, 160);
            // 
            // LaunchSimulatorMenuItem
            // 
            this.LaunchSimulatorMenuItem.Name = "LaunchSimulatorMenuItem";
            this.LaunchSimulatorMenuItem.Size = new System.Drawing.Size(546, 36);
            this.LaunchSimulatorMenuItem.Text = "Launch Device Simulator";
            this.LaunchSimulatorMenuItem.Click += new System.EventHandler(this.LaunchSimulatorMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(543, 6);
            // 
            // copyAllToolStripMenuItem
            // 
            this.copyAllToolStripMenuItem.Name = "copyAllToolStripMenuItem";
            this.copyAllToolStripMenuItem.Size = new System.Drawing.Size(546, 36);
            this.copyAllToolStripMenuItem.Text = "Copy data for all device";
            this.copyAllToolStripMenuItem.Click += new System.EventHandler(this.copyAllToolStripMenuItem_Click);
            // 
            // copySelectedToolMenuItem
            // 
            this.copySelectedToolMenuItem.Name = "copySelectedToolMenuItem";
            this.copySelectedToolMenuItem.Size = new System.Drawing.Size(546, 36);
            this.copySelectedToolMenuItem.Text = "Copy data for selected device";
            this.copySelectedToolMenuItem.Click += new System.EventHandler(this.copySelectedToolMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(543, 6);
            // 
            // getDeviceConnectionStringToolStripMenuItem
            // 
            this.getDeviceConnectionStringToolStripMenuItem.Name = "getDeviceConnectionStringToolStripMenuItem";
            this.getDeviceConnectionStringToolStripMenuItem.Size = new System.Drawing.Size(546, 36);
            this.getDeviceConnectionStringToolStripMenuItem.Text = "Copy connection string for selected device";
            this.getDeviceConnectionStringToolStripMenuItem.Click += new System.EventHandler(this.getDeviceConnectionStringToolStripMenuItem_Click);
            // 
            // groupBoxDevMAction
            // 
            this.groupBoxDevMAction.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxDevMAction.Controls.Add(this.sasTokenButton);
            this.groupBoxDevMAction.Controls.Add(this.createDeviceButton);
            this.groupBoxDevMAction.Controls.Add(this.listDevicesButton);
            this.groupBoxDevMAction.Controls.Add(this.updateDeviceButton);
            this.groupBoxDevMAction.Controls.Add(this.deleteDeviceButton);
            this.groupBoxDevMAction.ForeColor = System.Drawing.SystemColors.Highlight;
            this.groupBoxDevMAction.Location = new System.Drawing.Point(6, 6);
            this.groupBoxDevMAction.Name = "groupBoxDevMAction";
            this.groupBoxDevMAction.Size = new System.Drawing.Size(1779, 121);
            this.groupBoxDevMAction.TabIndex = 0;
            this.groupBoxDevMAction.TabStop = false;
            this.groupBoxDevMAction.Text = "Actions";
            // 
            // sasTokenButton
            // 
            this.sasTokenButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.sasTokenButton.Location = new System.Drawing.Point(995, 40);
            this.sasTokenButton.Margin = new System.Windows.Forms.Padding(6);
            this.sasTokenButton.Name = "sasTokenButton";
            this.sasTokenButton.Size = new System.Drawing.Size(216, 56);
            this.sasTokenButton.TabIndex = 11;
            this.sasTokenButton.Text = "SAS Token...";
            this.sasTokenButton.UseVisualStyleBackColor = true;
            this.sasTokenButton.Click += new System.EventHandler(this.sasTokenButton_Click);
            // 
            // createDeviceButton
            // 
            this.createDeviceButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.createDeviceButton.Location = new System.Drawing.Point(24, 40);
            this.createDeviceButton.Margin = new System.Windows.Forms.Padding(6);
            this.createDeviceButton.Name = "createDeviceButton";
            this.createDeviceButton.Size = new System.Drawing.Size(216, 56);
            this.createDeviceButton.TabIndex = 7;
            this.createDeviceButton.Text = "Create";
            this.createDeviceButton.UseVisualStyleBackColor = true;
            this.createDeviceButton.Click += new System.EventHandler(this.createDeviceButton_Click);
            // 
            // listDevicesButton
            // 
            this.listDevicesButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.listDevicesButton.Location = new System.Drawing.Point(266, 40);
            this.listDevicesButton.Margin = new System.Windows.Forms.Padding(6);
            this.listDevicesButton.Name = "listDevicesButton";
            this.listDevicesButton.Size = new System.Drawing.Size(216, 56);
            this.listDevicesButton.TabIndex = 8;
            this.listDevicesButton.Text = "List";
            this.listDevicesButton.UseVisualStyleBackColor = true;
            this.listDevicesButton.Click += new System.EventHandler(this.listDevicesButton_Click);
            // 
            // updateDeviceButton
            // 
            this.updateDeviceButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.updateDeviceButton.Location = new System.Drawing.Point(510, 40);
            this.updateDeviceButton.Margin = new System.Windows.Forms.Padding(6);
            this.updateDeviceButton.Name = "updateDeviceButton";
            this.updateDeviceButton.Size = new System.Drawing.Size(216, 56);
            this.updateDeviceButton.TabIndex = 9;
            this.updateDeviceButton.Text = "Update";
            this.updateDeviceButton.UseVisualStyleBackColor = true;
            this.updateDeviceButton.Click += new System.EventHandler(this.updateDeviceButton_Click);
            // 
            // deleteDeviceButton
            // 
            this.deleteDeviceButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.deleteDeviceButton.Location = new System.Drawing.Point(751, 40);
            this.deleteDeviceButton.Margin = new System.Windows.Forms.Padding(6);
            this.deleteDeviceButton.Name = "deleteDeviceButton";
            this.deleteDeviceButton.Size = new System.Drawing.Size(216, 56);
            this.deleteDeviceButton.TabIndex = 10;
            this.deleteDeviceButton.Text = "Delete";
            this.deleteDeviceButton.UseVisualStyleBackColor = true;
            this.deleteDeviceButton.Click += new System.EventHandler(this.deleteDeviceButton_Click);
            // 
            // tabDeviceGroup
            // 
            this.tabDeviceGroup.Controls.Add(this.groupBox1);
            this.tabDeviceGroup.Controls.Add(this.groupBox2);
            this.tabDeviceGroup.Location = new System.Drawing.Point(8, 44);
            this.tabDeviceGroup.Name = "tabDeviceGroup";
            this.tabDeviceGroup.Padding = new System.Windows.Forms.Padding(3);
            this.tabDeviceGroup.Size = new System.Drawing.Size(1791, 1078);
            this.tabDeviceGroup.TabIndex = 2;
            this.tabDeviceGroup.Text = "Device Group";
            this.tabDeviceGroup.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.textBoxDeviceGroupId);
            this.groupBox1.Controls.Add(this.listDeviceGrpButton);
            this.groupBox1.Controls.Add(this.deviceGroupCountLabel);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.deviceGroupsGridView);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.groupBox1.Location = new System.Drawing.Point(7, 153);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1779, 899);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Device Group Table";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label10.Location = new System.Drawing.Point(19, 69);
            this.label10.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(305, 30);
            this.label10.TabIndex = 18;
            this.label10.Text = "Device Group ID (Filter):";
            // 
            // textBoxDeviceGroupId
            // 
            this.textBoxDeviceGroupId.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.textBoxDeviceGroupId.Location = new System.Drawing.Point(366, 66);
            this.textBoxDeviceGroupId.Name = "textBoxDeviceGroupId";
            this.textBoxDeviceGroupId.Size = new System.Drawing.Size(384, 38);
            this.textBoxDeviceGroupId.TabIndex = 17;
            // 
            // listDeviceGrpButton
            // 
            this.listDeviceGrpButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.listDeviceGrpButton.Location = new System.Drawing.Point(768, 56);
            this.listDeviceGrpButton.Margin = new System.Windows.Forms.Padding(6);
            this.listDeviceGrpButton.Name = "listDeviceGrpButton";
            this.listDeviceGrpButton.Size = new System.Drawing.Size(216, 56);
            this.listDeviceGrpButton.TabIndex = 16;
            this.listDeviceGrpButton.Text = "List";
            this.listDeviceGrpButton.UseVisualStyleBackColor = true;
            this.listDeviceGrpButton.Click += new System.EventHandler(this.listDeviceGrpButton_Click);
            // 
            // deviceGroupCountLabel
            // 
            this.deviceGroupCountLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.deviceGroupCountLabel.AutoSize = true;
            this.deviceGroupCountLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.deviceGroupCountLabel.Location = new System.Drawing.Point(1616, 69);
            this.deviceGroupCountLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.deviceGroupCountLabel.Name = "deviceGroupCountLabel";
            this.deviceGroupCountLabel.Size = new System.Drawing.Size(28, 30);
            this.deviceGroupCountLabel.TabIndex = 15;
            this.deviceGroupCountLabel.Text = "0";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label9.Location = new System.Drawing.Point(1512, 69);
            this.label9.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(78, 30);
            this.label9.TabIndex = 14;
            this.label9.Text = "Total:";
            // 
            // deviceGroupsGridView
            // 
            this.deviceGroupsGridView.AllowUserToOrderColumns = true;
            this.deviceGroupsGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.deviceGroupsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.deviceGroupsGridView.ContextMenuStrip = this.deviceGroupsGridViewContextMenu;
            this.deviceGroupsGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.deviceGroupsGridView.Location = new System.Drawing.Point(17, 133);
            this.deviceGroupsGridView.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.deviceGroupsGridView.MultiSelect = false;
            this.deviceGroupsGridView.Name = "deviceGroupsGridView";
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.deviceGroupsGridView.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.deviceGroupsGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.deviceGroupsGridView.Size = new System.Drawing.Size(1745, 749);
            this.deviceGroupsGridView.TabIndex = 13;
            // 
            // deviceGroupsGridViewContextMenu
            // 
            this.deviceGroupsGridViewContextMenu.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.deviceGroupsGridViewContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyAllToolStripOnGroup,
            this.copySelectedToolStripOnGroup});
            this.deviceGroupsGridViewContextMenu.Name = "devicesGridViewContextMenu";
            this.deviceGroupsGridViewContextMenu.Size = new System.Drawing.Size(377, 76);
            // 
            // copyAllToolStripOnGroup
            // 
            this.copyAllToolStripOnGroup.Name = "copyAllToolStripOnGroup";
            this.copyAllToolStripOnGroup.Size = new System.Drawing.Size(376, 36);
            this.copyAllToolStripOnGroup.Text = "Copy data for all rows";
            this.copyAllToolStripOnGroup.Click += new System.EventHandler(this.copyAllToolStripOnGroup_Click);
            // 
            // copySelectedToolStripOnGroup
            // 
            this.copySelectedToolStripOnGroup.Name = "copySelectedToolStripOnGroup";
            this.copySelectedToolStripOnGroup.Size = new System.Drawing.Size(376, 36);
            this.copySelectedToolStripOnGroup.Text = "Copy data for selected row";
            this.copySelectedToolStripOnGroup.Click += new System.EventHandler(this.copySelectedToolStripOnGroup_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.createDeviceGrpButton);
            this.groupBox2.Controls.Add(this.updateDeviceGrpButton);
            this.groupBox2.Controls.Add(this.deleteDeviceGrpButton);
            this.groupBox2.ForeColor = System.Drawing.SystemColors.Highlight;
            this.groupBox2.Location = new System.Drawing.Point(7, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1779, 121);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Actions";
            // 
            // createDeviceGrpButton
            // 
            this.createDeviceGrpButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.createDeviceGrpButton.Location = new System.Drawing.Point(24, 40);
            this.createDeviceGrpButton.Margin = new System.Windows.Forms.Padding(6);
            this.createDeviceGrpButton.Name = "createDeviceGrpButton";
            this.createDeviceGrpButton.Size = new System.Drawing.Size(216, 56);
            this.createDeviceGrpButton.TabIndex = 7;
            this.createDeviceGrpButton.Text = "Create";
            this.createDeviceGrpButton.UseVisualStyleBackColor = true;
            this.createDeviceGrpButton.Click += new System.EventHandler(this.createDeviceGrpButton_Click);
            // 
            // updateDeviceGrpButton
            // 
            this.updateDeviceGrpButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.updateDeviceGrpButton.Location = new System.Drawing.Point(272, 40);
            this.updateDeviceGrpButton.Margin = new System.Windows.Forms.Padding(6);
            this.updateDeviceGrpButton.Name = "updateDeviceGrpButton";
            this.updateDeviceGrpButton.Size = new System.Drawing.Size(216, 56);
            this.updateDeviceGrpButton.TabIndex = 9;
            this.updateDeviceGrpButton.Text = "Update";
            this.updateDeviceGrpButton.UseVisualStyleBackColor = true;
            this.updateDeviceGrpButton.Click += new System.EventHandler(this.updateDeviceGrpButton_Click);
            // 
            // deleteDeviceGrpButton
            // 
            this.deleteDeviceGrpButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.deleteDeviceGrpButton.Location = new System.Drawing.Point(519, 40);
            this.deleteDeviceGrpButton.Margin = new System.Windows.Forms.Padding(6);
            this.deleteDeviceGrpButton.Name = "deleteDeviceGrpButton";
            this.deleteDeviceGrpButton.Size = new System.Drawing.Size(216, 56);
            this.deleteDeviceGrpButton.TabIndex = 10;
            this.deleteDeviceGrpButton.Text = "Delete";
            this.deleteDeviceGrpButton.UseVisualStyleBackColor = true;
            this.deleteDeviceGrpButton.Click += new System.EventHandler(this.deleteDeviceGrpButton_Click);
            // 
            // tabDeviceRouting
            // 
            this.tabDeviceRouting.Controls.Add(this.groupBox3);
            this.tabDeviceRouting.Controls.Add(this.groupBox4);
            this.tabDeviceRouting.Location = new System.Drawing.Point(8, 44);
            this.tabDeviceRouting.Name = "tabDeviceRouting";
            this.tabDeviceRouting.Padding = new System.Windows.Forms.Padding(3);
            this.tabDeviceRouting.Size = new System.Drawing.Size(1791, 1078);
            this.tabDeviceRouting.TabIndex = 3;
            this.tabDeviceRouting.Text = "Device Routing";
            this.tabDeviceRouting.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.textBoxRoutingDeviceId);
            this.groupBox3.Controls.Add(this.listDevRoutingButton);
            this.groupBox3.Controls.Add(this.devRoutingCountLabel);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.devRoutingsGridView);
            this.groupBox3.ForeColor = System.Drawing.SystemColors.Highlight;
            this.groupBox3.Location = new System.Drawing.Point(6, 163);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1779, 899);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Device Routing Table";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label8.Location = new System.Drawing.Point(19, 69);
            this.label8.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(226, 30);
            this.label8.TabIndex = 18;
            this.label8.Text = "Device ID (Filter):";
            // 
            // textBoxRoutingDeviceId
            // 
            this.textBoxRoutingDeviceId.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.textBoxRoutingDeviceId.Location = new System.Drawing.Point(275, 66);
            this.textBoxRoutingDeviceId.Name = "textBoxRoutingDeviceId";
            this.textBoxRoutingDeviceId.Size = new System.Drawing.Size(384, 38);
            this.textBoxRoutingDeviceId.TabIndex = 17;
            // 
            // listDevRoutingButton
            // 
            this.listDevRoutingButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.listDevRoutingButton.Location = new System.Drawing.Point(677, 56);
            this.listDevRoutingButton.Margin = new System.Windows.Forms.Padding(6);
            this.listDevRoutingButton.Name = "listDevRoutingButton";
            this.listDevRoutingButton.Size = new System.Drawing.Size(216, 56);
            this.listDevRoutingButton.TabIndex = 16;
            this.listDevRoutingButton.Text = "List";
            this.listDevRoutingButton.UseVisualStyleBackColor = true;
            this.listDevRoutingButton.Click += new System.EventHandler(this.listDevRoutingButton_Click);
            // 
            // devRoutingCountLabel
            // 
            this.devRoutingCountLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.devRoutingCountLabel.AutoSize = true;
            this.devRoutingCountLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.devRoutingCountLabel.Location = new System.Drawing.Point(1616, 69);
            this.devRoutingCountLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.devRoutingCountLabel.Name = "devRoutingCountLabel";
            this.devRoutingCountLabel.Size = new System.Drawing.Size(28, 30);
            this.devRoutingCountLabel.TabIndex = 15;
            this.devRoutingCountLabel.Text = "0";
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label12.Location = new System.Drawing.Point(1512, 69);
            this.label12.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(78, 30);
            this.label12.TabIndex = 14;
            this.label12.Text = "Total:";
            // 
            // devRoutingsGridView
            // 
            this.devRoutingsGridView.AllowUserToOrderColumns = true;
            this.devRoutingsGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.devRoutingsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.devRoutingsGridView.ContextMenuStrip = this.deviceRoutingsGridViewContextMenu;
            this.devRoutingsGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.devRoutingsGridView.Location = new System.Drawing.Point(17, 133);
            this.devRoutingsGridView.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.devRoutingsGridView.MultiSelect = false;
            this.devRoutingsGridView.Name = "devRoutingsGridView";
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            this.devRoutingsGridView.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.devRoutingsGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.devRoutingsGridView.Size = new System.Drawing.Size(1745, 749);
            this.devRoutingsGridView.TabIndex = 13;
            // 
            // deviceRoutingsGridViewContextMenu
            // 
            this.deviceRoutingsGridViewContextMenu.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.deviceRoutingsGridViewContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyAllToolStripOnDevRouting,
            this.copySelectedToolStripOnDevRouting});
            this.deviceRoutingsGridViewContextMenu.Name = "devicesGridViewContextMenu";
            this.deviceRoutingsGridViewContextMenu.Size = new System.Drawing.Size(377, 76);
            // 
            // copyAllToolStripOnDevRouting
            // 
            this.copyAllToolStripOnDevRouting.Name = "copyAllToolStripOnDevRouting";
            this.copyAllToolStripOnDevRouting.Size = new System.Drawing.Size(376, 36);
            this.copyAllToolStripOnDevRouting.Text = "Copy data for all rows";
            this.copyAllToolStripOnDevRouting.Click += new System.EventHandler(this.copyAllToolStripOnDevRouting_Click);
            // 
            // copySelectedToolStripOnDevRouting
            // 
            this.copySelectedToolStripOnDevRouting.Name = "copySelectedToolStripOnDevRouting";
            this.copySelectedToolStripOnDevRouting.Size = new System.Drawing.Size(376, 36);
            this.copySelectedToolStripOnDevRouting.Text = "Copy data for selected row";
            this.copySelectedToolStripOnDevRouting.Click += new System.EventHandler(this.copySelectedToolStripOnDevRouting_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.createDevRoutingButton);
            this.groupBox4.Controls.Add(this.updateDevRoutingButton);
            this.groupBox4.Controls.Add(this.deleteDevRoutingButton);
            this.groupBox4.ForeColor = System.Drawing.SystemColors.Highlight;
            this.groupBox4.Location = new System.Drawing.Point(6, 16);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(1779, 121);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Actions";
            // 
            // createDevRoutingButton
            // 
            this.createDevRoutingButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.createDevRoutingButton.Location = new System.Drawing.Point(24, 40);
            this.createDevRoutingButton.Margin = new System.Windows.Forms.Padding(6);
            this.createDevRoutingButton.Name = "createDevRoutingButton";
            this.createDevRoutingButton.Size = new System.Drawing.Size(216, 56);
            this.createDevRoutingButton.TabIndex = 7;
            this.createDevRoutingButton.Text = "Create";
            this.createDevRoutingButton.UseVisualStyleBackColor = true;
            this.createDevRoutingButton.Click += new System.EventHandler(this.createDevRoutingButton_Click);
            // 
            // updateDevRoutingButton
            // 
            this.updateDevRoutingButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.updateDevRoutingButton.Location = new System.Drawing.Point(272, 40);
            this.updateDevRoutingButton.Margin = new System.Windows.Forms.Padding(6);
            this.updateDevRoutingButton.Name = "updateDevRoutingButton";
            this.updateDevRoutingButton.Size = new System.Drawing.Size(216, 56);
            this.updateDevRoutingButton.TabIndex = 9;
            this.updateDevRoutingButton.Text = "Update";
            this.updateDevRoutingButton.UseVisualStyleBackColor = true;
            this.updateDevRoutingButton.Click += new System.EventHandler(this.updateDevRoutingButton_Click);
            // 
            // deleteDevRoutingButton
            // 
            this.deleteDevRoutingButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.deleteDevRoutingButton.Location = new System.Drawing.Point(519, 40);
            this.deleteDevRoutingButton.Margin = new System.Windows.Forms.Padding(6);
            this.deleteDevRoutingButton.Name = "deleteDevRoutingButton";
            this.deleteDevRoutingButton.Size = new System.Drawing.Size(216, 56);
            this.deleteDevRoutingButton.TabIndex = 10;
            this.deleteDevRoutingButton.Text = "Delete";
            this.deleteDevRoutingButton.UseVisualStyleBackColor = true;
            this.deleteDevRoutingButton.Click += new System.EventHandler(this.deleteDevRoutingButton_Click);
            // 
            // tabAppMaster
            // 
            this.tabAppMaster.Controls.Add(this.groupBox5);
            this.tabAppMaster.Controls.Add(this.groupBox6);
            this.tabAppMaster.Location = new System.Drawing.Point(8, 44);
            this.tabAppMaster.Name = "tabAppMaster";
            this.tabAppMaster.Padding = new System.Windows.Forms.Padding(3);
            this.tabAppMaster.Size = new System.Drawing.Size(1791, 1078);
            this.tabAppMaster.TabIndex = 4;
            this.tabAppMaster.Text = "App Master";
            this.tabAppMaster.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Controls.Add(this.saveEncPassphraseButton);
            this.groupBox5.Controls.Add(this.textBoxEncPassphrase);
            this.groupBox5.Controls.Add(this.label11);
            this.groupBox5.Controls.Add(this.label16);
            this.groupBox5.Controls.Add(this.textBoxAppMasterAppId);
            this.groupBox5.Controls.Add(this.listAppMasterButton);
            this.groupBox5.Controls.Add(this.appMasterCountLabel);
            this.groupBox5.Controls.Add(this.label14);
            this.groupBox5.Controls.Add(this.appMastersGridView);
            this.groupBox5.ForeColor = System.Drawing.SystemColors.Highlight;
            this.groupBox5.Location = new System.Drawing.Point(6, 163);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(1779, 899);
            this.groupBox5.TabIndex = 7;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "App Master Table";
            // 
            // saveEncPassphraseButton
            // 
            this.saveEncPassphraseButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.saveEncPassphraseButton.Location = new System.Drawing.Point(1002, 40);
            this.saveEncPassphraseButton.Margin = new System.Windows.Forms.Padding(6);
            this.saveEncPassphraseButton.Name = "saveEncPassphraseButton";
            this.saveEncPassphraseButton.Size = new System.Drawing.Size(216, 55);
            this.saveEncPassphraseButton.TabIndex = 19;
            this.saveEncPassphraseButton.Text = "Save";
            this.saveEncPassphraseButton.UseVisualStyleBackColor = true;
            this.saveEncPassphraseButton.Click += new System.EventHandler(this.saveEncPassphraseButton_Click);
            // 
            // textBoxEncPassphrase
            // 
            this.textBoxEncPassphrase.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.textBoxEncPassphrase.Location = new System.Drawing.Point(341, 49);
            this.textBoxEncPassphrase.Name = "textBoxEncPassphrase";
            this.textBoxEncPassphrase.PasswordChar = '●';
            this.textBoxEncPassphrase.Size = new System.Drawing.Size(641, 38);
            this.textBoxEncPassphrase.TabIndex = 18;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label11.Location = new System.Drawing.Point(23, 124);
            this.label11.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(194, 30);
            this.label11.TabIndex = 18;
            this.label11.Text = "App ID (Filter):";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label16.Location = new System.Drawing.Point(23, 52);
            this.label16.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(287, 30);
            this.label16.TabIndex = 16;
            this.label16.Text = "Encryption Passphrase:";
            // 
            // textBoxAppMasterAppId
            // 
            this.textBoxAppMasterAppId.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.textBoxAppMasterAppId.Location = new System.Drawing.Point(242, 121);
            this.textBoxAppMasterAppId.Name = "textBoxAppMasterAppId";
            this.textBoxAppMasterAppId.Size = new System.Drawing.Size(384, 38);
            this.textBoxAppMasterAppId.TabIndex = 17;
            // 
            // listAppMasterButton
            // 
            this.listAppMasterButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.listAppMasterButton.Location = new System.Drawing.Point(645, 112);
            this.listAppMasterButton.Margin = new System.Windows.Forms.Padding(6);
            this.listAppMasterButton.Name = "listAppMasterButton";
            this.listAppMasterButton.Size = new System.Drawing.Size(216, 55);
            this.listAppMasterButton.TabIndex = 16;
            this.listAppMasterButton.Text = "List";
            this.listAppMasterButton.UseVisualStyleBackColor = true;
            this.listAppMasterButton.Click += new System.EventHandler(this.listAppMasterButton_Click);
            // 
            // appMasterCountLabel
            // 
            this.appMasterCountLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.appMasterCountLabel.AutoSize = true;
            this.appMasterCountLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.appMasterCountLabel.Location = new System.Drawing.Point(1666, 124);
            this.appMasterCountLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.appMasterCountLabel.Name = "appMasterCountLabel";
            this.appMasterCountLabel.Size = new System.Drawing.Size(28, 30);
            this.appMasterCountLabel.TabIndex = 15;
            this.appMasterCountLabel.Text = "0";
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.AutoSize = true;
            this.label14.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label14.Location = new System.Drawing.Point(1562, 124);
            this.label14.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(78, 30);
            this.label14.TabIndex = 14;
            this.label14.Text = "Total:";
            // 
            // appMastersGridView
            // 
            this.appMastersGridView.AllowUserToOrderColumns = true;
            this.appMastersGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.appMastersGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.appMastersGridView.ContextMenuStrip = this.appMastersGridViewContextMenu;
            this.appMastersGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.appMastersGridView.Location = new System.Drawing.Point(17, 185);
            this.appMastersGridView.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.appMastersGridView.MultiSelect = false;
            this.appMastersGridView.Name = "appMastersGridView";
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            this.appMastersGridView.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.appMastersGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.appMastersGridView.Size = new System.Drawing.Size(1745, 697);
            this.appMastersGridView.TabIndex = 13;
            // 
            // appMastersGridViewContextMenu
            // 
            this.appMastersGridViewContextMenu.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.appMastersGridViewContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyAllToolStripOnAppMaster,
            this.copySelectedToolStripOnAppMaster});
            this.appMastersGridViewContextMenu.Name = "devicesGridViewContextMenu";
            this.appMastersGridViewContextMenu.Size = new System.Drawing.Size(377, 76);
            // 
            // copyAllToolStripOnAppMaster
            // 
            this.copyAllToolStripOnAppMaster.Name = "copyAllToolStripOnAppMaster";
            this.copyAllToolStripOnAppMaster.Size = new System.Drawing.Size(376, 36);
            this.copyAllToolStripOnAppMaster.Text = "Copy data for all rows";
            this.copyAllToolStripOnAppMaster.Click += new System.EventHandler(this.copyAllToolStripOnAppMaster_Click);
            // 
            // copySelectedToolStripOnAppMaster
            // 
            this.copySelectedToolStripOnAppMaster.Name = "copySelectedToolStripOnAppMaster";
            this.copySelectedToolStripOnAppMaster.Size = new System.Drawing.Size(376, 36);
            this.copySelectedToolStripOnAppMaster.Text = "Copy data for selected row";
            this.copySelectedToolStripOnAppMaster.Click += new System.EventHandler(this.copySelectedToolStripOnAppMaster_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox6.Controls.Add(this.createAppMasterButton);
            this.groupBox6.Controls.Add(this.updateAppMasterButton);
            this.groupBox6.Controls.Add(this.deleteAppMasterButton);
            this.groupBox6.ForeColor = System.Drawing.SystemColors.Highlight;
            this.groupBox6.Location = new System.Drawing.Point(6, 16);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(1779, 121);
            this.groupBox6.TabIndex = 6;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Actions";
            // 
            // createAppMasterButton
            // 
            this.createAppMasterButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.createAppMasterButton.Location = new System.Drawing.Point(24, 40);
            this.createAppMasterButton.Margin = new System.Windows.Forms.Padding(6);
            this.createAppMasterButton.Name = "createAppMasterButton";
            this.createAppMasterButton.Size = new System.Drawing.Size(216, 56);
            this.createAppMasterButton.TabIndex = 7;
            this.createAppMasterButton.Text = "Create";
            this.createAppMasterButton.UseVisualStyleBackColor = true;
            this.createAppMasterButton.Click += new System.EventHandler(this.createAppMasterButton_Click);
            // 
            // updateAppMasterButton
            // 
            this.updateAppMasterButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.updateAppMasterButton.Location = new System.Drawing.Point(272, 40);
            this.updateAppMasterButton.Margin = new System.Windows.Forms.Padding(6);
            this.updateAppMasterButton.Name = "updateAppMasterButton";
            this.updateAppMasterButton.Size = new System.Drawing.Size(216, 56);
            this.updateAppMasterButton.TabIndex = 9;
            this.updateAppMasterButton.Text = "Update";
            this.updateAppMasterButton.UseVisualStyleBackColor = true;
            this.updateAppMasterButton.Click += new System.EventHandler(this.updateAppMasterButton_Click);
            // 
            // deleteAppMasterButton
            // 
            this.deleteAppMasterButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.deleteAppMasterButton.Location = new System.Drawing.Point(519, 40);
            this.deleteAppMasterButton.Margin = new System.Windows.Forms.Padding(6);
            this.deleteAppMasterButton.Name = "deleteAppMasterButton";
            this.deleteAppMasterButton.Size = new System.Drawing.Size(216, 56);
            this.deleteAppMasterButton.TabIndex = 10;
            this.deleteAppMasterButton.Text = "Delete";
            this.deleteAppMasterButton.UseVisualStyleBackColor = true;
            this.deleteAppMasterButton.Click += new System.EventHandler(this.deleteAppMasterButton_Click);
            // 
            // tabAppRouting
            // 
            this.tabAppRouting.Controls.Add(this.groupBox7);
            this.tabAppRouting.Controls.Add(this.groupBox8);
            this.tabAppRouting.Location = new System.Drawing.Point(8, 44);
            this.tabAppRouting.Name = "tabAppRouting";
            this.tabAppRouting.Padding = new System.Windows.Forms.Padding(3);
            this.tabAppRouting.Size = new System.Drawing.Size(1791, 1078);
            this.tabAppRouting.TabIndex = 5;
            this.tabAppRouting.Text = "App Routing";
            this.tabAppRouting.UseVisualStyleBackColor = true;
            // 
            // groupBox7
            // 
            this.groupBox7.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox7.Controls.Add(this.label13);
            this.groupBox7.Controls.Add(this.textBoxAppRoutingAppId);
            this.groupBox7.Controls.Add(this.listAppRoutingButton);
            this.groupBox7.Controls.Add(this.appRoutingCountLabel);
            this.groupBox7.Controls.Add(this.label18);
            this.groupBox7.Controls.Add(this.appRoutingsGridView);
            this.groupBox7.ForeColor = System.Drawing.SystemColors.Highlight;
            this.groupBox7.Location = new System.Drawing.Point(6, 163);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(1779, 899);
            this.groupBox7.TabIndex = 9;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "App Routing Table";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label13.Location = new System.Drawing.Point(23, 59);
            this.label13.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(194, 30);
            this.label13.TabIndex = 18;
            this.label13.Text = "App ID (Filter):";
            // 
            // textBoxAppRoutingAppId
            // 
            this.textBoxAppRoutingAppId.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.textBoxAppRoutingAppId.Location = new System.Drawing.Point(242, 56);
            this.textBoxAppRoutingAppId.Name = "textBoxAppRoutingAppId";
            this.textBoxAppRoutingAppId.Size = new System.Drawing.Size(384, 38);
            this.textBoxAppRoutingAppId.TabIndex = 17;
            // 
            // listAppRoutingButton
            // 
            this.listAppRoutingButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.listAppRoutingButton.Location = new System.Drawing.Point(645, 47);
            this.listAppRoutingButton.Margin = new System.Windows.Forms.Padding(6);
            this.listAppRoutingButton.Name = "listAppRoutingButton";
            this.listAppRoutingButton.Size = new System.Drawing.Size(216, 55);
            this.listAppRoutingButton.TabIndex = 16;
            this.listAppRoutingButton.Text = "List";
            this.listAppRoutingButton.UseVisualStyleBackColor = true;
            this.listAppRoutingButton.Click += new System.EventHandler(this.listAppRoutingButton_Click);
            // 
            // appRoutingCountLabel
            // 
            this.appRoutingCountLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.appRoutingCountLabel.AutoSize = true;
            this.appRoutingCountLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.appRoutingCountLabel.Location = new System.Drawing.Point(1666, 59);
            this.appRoutingCountLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.appRoutingCountLabel.Name = "appRoutingCountLabel";
            this.appRoutingCountLabel.Size = new System.Drawing.Size(28, 30);
            this.appRoutingCountLabel.TabIndex = 15;
            this.appRoutingCountLabel.Text = "0";
            // 
            // label18
            // 
            this.label18.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label18.AutoSize = true;
            this.label18.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label18.Location = new System.Drawing.Point(1562, 59);
            this.label18.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(78, 30);
            this.label18.TabIndex = 14;
            this.label18.Text = "Total:";
            // 
            // appRoutingsGridView
            // 
            this.appRoutingsGridView.AllowUserToOrderColumns = true;
            this.appRoutingsGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.appRoutingsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.appRoutingsGridView.ContextMenuStrip = this.appRoutingsGridViewContextMenu;
            this.appRoutingsGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.appRoutingsGridView.Location = new System.Drawing.Point(17, 125);
            this.appRoutingsGridView.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.appRoutingsGridView.MultiSelect = false;
            this.appRoutingsGridView.Name = "appRoutingsGridView";
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            this.appRoutingsGridView.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.appRoutingsGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.appRoutingsGridView.Size = new System.Drawing.Size(1745, 757);
            this.appRoutingsGridView.TabIndex = 13;
            // 
            // appRoutingsGridViewContextMenu
            // 
            this.appRoutingsGridViewContextMenu.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.appRoutingsGridViewContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyAllToolStripOnAppRouting,
            this.copySelectedToolStripOnAppRouting});
            this.appRoutingsGridViewContextMenu.Name = "devicesGridViewContextMenu";
            this.appRoutingsGridViewContextMenu.Size = new System.Drawing.Size(377, 76);
            // 
            // copyAllToolStripOnAppRouting
            // 
            this.copyAllToolStripOnAppRouting.Name = "copyAllToolStripOnAppRouting";
            this.copyAllToolStripOnAppRouting.Size = new System.Drawing.Size(376, 36);
            this.copyAllToolStripOnAppRouting.Text = "Copy data for all rows";
            this.copyAllToolStripOnAppRouting.Click += new System.EventHandler(this.copyAllToolStripOnAppRouting_Click);
            // 
            // copySelectedToolStripOnAppRouting
            // 
            this.copySelectedToolStripOnAppRouting.Name = "copySelectedToolStripOnAppRouting";
            this.copySelectedToolStripOnAppRouting.Size = new System.Drawing.Size(376, 36);
            this.copySelectedToolStripOnAppRouting.Text = "Copy data for selected row";
            this.copySelectedToolStripOnAppRouting.Click += new System.EventHandler(this.copySelectedToolStripOnAppRouting_Click);
            // 
            // groupBox8
            // 
            this.groupBox8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox8.Controls.Add(this.createAppRoutingButton);
            this.groupBox8.Controls.Add(this.updateAppRoutingButton);
            this.groupBox8.Controls.Add(this.deleteAppRoutingButton);
            this.groupBox8.ForeColor = System.Drawing.SystemColors.Highlight;
            this.groupBox8.Location = new System.Drawing.Point(6, 16);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(1779, 121);
            this.groupBox8.TabIndex = 8;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Actions";
            // 
            // createAppRoutingButton
            // 
            this.createAppRoutingButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.createAppRoutingButton.Location = new System.Drawing.Point(24, 40);
            this.createAppRoutingButton.Margin = new System.Windows.Forms.Padding(6);
            this.createAppRoutingButton.Name = "createAppRoutingButton";
            this.createAppRoutingButton.Size = new System.Drawing.Size(216, 56);
            this.createAppRoutingButton.TabIndex = 7;
            this.createAppRoutingButton.Text = "Create";
            this.createAppRoutingButton.UseVisualStyleBackColor = true;
            this.createAppRoutingButton.Click += new System.EventHandler(this.createAppRoutingButton_Click);
            // 
            // updateAppRoutingButton
            // 
            this.updateAppRoutingButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.updateAppRoutingButton.Location = new System.Drawing.Point(272, 40);
            this.updateAppRoutingButton.Margin = new System.Windows.Forms.Padding(6);
            this.updateAppRoutingButton.Name = "updateAppRoutingButton";
            this.updateAppRoutingButton.Size = new System.Drawing.Size(216, 56);
            this.updateAppRoutingButton.TabIndex = 9;
            this.updateAppRoutingButton.Text = "Update";
            this.updateAppRoutingButton.UseVisualStyleBackColor = true;
            this.updateAppRoutingButton.Click += new System.EventHandler(this.updateAppRoutingButton_Click);
            // 
            // deleteAppRoutingButton
            // 
            this.deleteAppRoutingButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.deleteAppRoutingButton.Location = new System.Drawing.Point(519, 40);
            this.deleteAppRoutingButton.Margin = new System.Windows.Forms.Padding(6);
            this.deleteAppRoutingButton.Name = "deleteAppRoutingButton";
            this.deleteAppRoutingButton.Size = new System.Drawing.Size(216, 56);
            this.deleteAppRoutingButton.TabIndex = 10;
            this.deleteAppRoutingButton.Text = "Delete";
            this.deleteAppRoutingButton.UseVisualStyleBackColor = true;
            this.deleteAppRoutingButton.Click += new System.EventHandler(this.deleteAppRoutingButton_Click);
            // 
            // tabFxTraceLog
            // 
            this.tabFxTraceLog.Controls.Add(this.groupBox9);
            this.tabFxTraceLog.Location = new System.Drawing.Point(8, 44);
            this.tabFxTraceLog.Name = "tabFxTraceLog";
            this.tabFxTraceLog.Padding = new System.Windows.Forms.Padding(3);
            this.tabFxTraceLog.Size = new System.Drawing.Size(1791, 1078);
            this.tabFxTraceLog.TabIndex = 6;
            this.tabFxTraceLog.Text = "FX Trace Log";
            this.tabFxTraceLog.UseVisualStyleBackColor = true;
            // 
            // groupBox9
            // 
            this.groupBox9.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox9.Controls.Add(this.checkBoxFxTrcDesc);
            this.groupBox9.Controls.Add(this.textBoxFxTrcTableName);
            this.groupBox9.Controls.Add(this.label22);
            this.groupBox9.Controls.Add(this.textBoxFxTrcStorgaKey);
            this.groupBox9.Controls.Add(this.label21);
            this.groupBox9.Controls.Add(this.label20);
            this.groupBox9.Controls.Add(this.textBoxFxTrcStorgaAccount);
            this.groupBox9.Controls.Add(this.label15);
            this.groupBox9.Controls.Add(this.textBoxFxTraceLogDate);
            this.groupBox9.Controls.Add(this.listFxTraceLogButton);
            this.groupBox9.Controls.Add(this.fxTraceLogCountLabel);
            this.groupBox9.Controls.Add(this.label19);
            this.groupBox9.Controls.Add(this.fxTraceLogGridView);
            this.groupBox9.ForeColor = System.Drawing.SystemColors.Highlight;
            this.groupBox9.Location = new System.Drawing.Point(6, 6);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(1779, 1066);
            this.groupBox9.TabIndex = 10;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Cloud Robotics FX Trace Log";
            // 
            // checkBoxFxTrcDesc
            // 
            this.checkBoxFxTrcDesc.AutoSize = true;
            this.checkBoxFxTrcDesc.Checked = true;
            this.checkBoxFxTrcDesc.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxFxTrcDesc.Location = new System.Drawing.Point(1065, 173);
            this.checkBoxFxTrcDesc.Name = "checkBoxFxTrcDesc";
            this.checkBoxFxTrcDesc.Size = new System.Drawing.Size(256, 34);
            this.checkBoxFxTrcDesc.TabIndex = 26;
            this.checkBoxFxTrcDesc.Text = "Descending Order";
            this.checkBoxFxTrcDesc.UseVisualStyleBackColor = true;
            // 
            // textBoxFxTrcTableName
            // 
            this.textBoxFxTrcTableName.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.textBoxFxTrcTableName.Location = new System.Drawing.Point(1305, 42);
            this.textBoxFxTrcTableName.Name = "textBoxFxTrcTableName";
            this.textBoxFxTrcTableName.Size = new System.Drawing.Size(328, 38);
            this.textBoxFxTrcTableName.TabIndex = 24;
            this.textBoxFxTrcTableName.Text = "RbTraceLog";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label22.Location = new System.Drawing.Point(1106, 45);
            this.label22.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(161, 30);
            this.label22.TabIndex = 23;
            this.label22.Text = "Table Name:";
            // 
            // textBoxFxTrcStorgaKey
            // 
            this.textBoxFxTrcStorgaKey.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.textBoxFxTrcStorgaKey.Location = new System.Drawing.Point(278, 95);
            this.textBoxFxTrcStorgaKey.Name = "textBoxFxTrcStorgaKey";
            this.textBoxFxTrcStorgaKey.PasswordChar = '●';
            this.textBoxFxTrcStorgaKey.Size = new System.Drawing.Size(755, 38);
            this.textBoxFxTrcStorgaKey.TabIndex = 22;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label21.Location = new System.Drawing.Point(21, 98);
            this.label21.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(165, 30);
            this.label21.TabIndex = 21;
            this.label21.Text = "Storage Key:";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label20.Location = new System.Drawing.Point(21, 45);
            this.label20.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(215, 30);
            this.label20.TabIndex = 20;
            this.label20.Text = "Storage Account:";
            // 
            // textBoxFxTrcStorgaAccount
            // 
            this.textBoxFxTrcStorgaAccount.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.textBoxFxTrcStorgaAccount.Location = new System.Drawing.Point(278, 42);
            this.textBoxFxTrcStorgaAccount.Name = "textBoxFxTrcStorgaAccount";
            this.textBoxFxTrcStorgaAccount.Size = new System.Drawing.Size(755, 38);
            this.textBoxFxTrcStorgaAccount.TabIndex = 19;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label15.Location = new System.Drawing.Point(21, 176);
            this.label15.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(394, 30);
            this.label15.TabIndex = 18;
            this.label15.Text = "UTC Date Filter (ex. 20160925):";
            // 
            // textBoxFxTraceLogDate
            // 
            this.textBoxFxTraceLogDate.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.textBoxFxTraceLogDate.Location = new System.Drawing.Point(446, 171);
            this.textBoxFxTraceLogDate.Name = "textBoxFxTraceLogDate";
            this.textBoxFxTraceLogDate.Size = new System.Drawing.Size(341, 38);
            this.textBoxFxTraceLogDate.TabIndex = 17;
            // 
            // listFxTraceLogButton
            // 
            this.listFxTraceLogButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.listFxTraceLogButton.Location = new System.Drawing.Point(817, 164);
            this.listFxTraceLogButton.Margin = new System.Windows.Forms.Padding(6);
            this.listFxTraceLogButton.Name = "listFxTraceLogButton";
            this.listFxTraceLogButton.Size = new System.Drawing.Size(216, 55);
            this.listFxTraceLogButton.TabIndex = 16;
            this.listFxTraceLogButton.Text = "List";
            this.listFxTraceLogButton.UseVisualStyleBackColor = true;
            this.listFxTraceLogButton.Click += new System.EventHandler(this.listFxTraceLogButton_Click);
            // 
            // fxTraceLogCountLabel
            // 
            this.fxTraceLogCountLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.fxTraceLogCountLabel.AutoSize = true;
            this.fxTraceLogCountLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.fxTraceLogCountLabel.Location = new System.Drawing.Point(1619, 181);
            this.fxTraceLogCountLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.fxTraceLogCountLabel.Name = "fxTraceLogCountLabel";
            this.fxTraceLogCountLabel.Size = new System.Drawing.Size(28, 30);
            this.fxTraceLogCountLabel.TabIndex = 15;
            this.fxTraceLogCountLabel.Text = "0";
            // 
            // label19
            // 
            this.label19.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label19.AutoSize = true;
            this.label19.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label19.Location = new System.Drawing.Point(1515, 181);
            this.label19.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(78, 30);
            this.label19.TabIndex = 14;
            this.label19.Text = "Total:";
            // 
            // fxTraceLogGridView
            // 
            this.fxTraceLogGridView.AllowUserToOrderColumns = true;
            this.fxTraceLogGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fxTraceLogGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.fxTraceLogGridView.ContextMenuStrip = this.fxTraceLogGridViewContextMenu;
            this.fxTraceLogGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.fxTraceLogGridView.Location = new System.Drawing.Point(17, 245);
            this.fxTraceLogGridView.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.fxTraceLogGridView.MultiSelect = false;
            this.fxTraceLogGridView.Name = "fxTraceLogGridView";
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            this.fxTraceLogGridView.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.fxTraceLogGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.fxTraceLogGridView.Size = new System.Drawing.Size(1745, 804);
            this.fxTraceLogGridView.TabIndex = 13;
            // 
            // fxTraceLogGridViewContextMenu
            // 
            this.fxTraceLogGridViewContextMenu.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.fxTraceLogGridViewContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyAllToolStripOnFxTraceLog,
            this.copySelectedToolStripOnFxTraceLog});
            this.fxTraceLogGridViewContextMenu.Name = "devicesGridViewContextMenu";
            this.fxTraceLogGridViewContextMenu.Size = new System.Drawing.Size(377, 76);
            // 
            // copyAllToolStripOnFxTraceLog
            // 
            this.copyAllToolStripOnFxTraceLog.Name = "copyAllToolStripOnFxTraceLog";
            this.copyAllToolStripOnFxTraceLog.Size = new System.Drawing.Size(376, 36);
            this.copyAllToolStripOnFxTraceLog.Text = "Copy data for all rows";
            this.copyAllToolStripOnFxTraceLog.Click += new System.EventHandler(this.copyAllToolStripOnFxTraceLog_Click);
            // 
            // copySelectedToolStripOnFxTraceLog
            // 
            this.copySelectedToolStripOnFxTraceLog.Name = "copySelectedToolStripOnFxTraceLog";
            this.copySelectedToolStripOnFxTraceLog.Size = new System.Drawing.Size(376, 36);
            this.copySelectedToolStripOnFxTraceLog.Text = "Copy data for selected row";
            this.copySelectedToolStripOnFxTraceLog.Click += new System.EventHandler(this.copySelectedToolStripOnFxTraceLog_Click);
            // 
            // FrmMainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1807, 1130);
            this.Controls.Add(this.tabControl1);
            this.Name = "FrmMainWindow";
            this.Text = "Cloud Robotics Definition & Management Tool - v1.5";
            this.Activated += new System.EventHandler(this.FrmMainWindow_Activated);
            this.Load += new System.EventHandler(this.FrmMainWindow_Load);
            this.Shown += new System.EventHandler(this.FrmMainWindow_Shown);
            this.tabControl1.ResumeLayout(false);
            this.tabConnection.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTTL)).EndInit();
            this.tabDeviceMaster.ResumeLayout(false);
            this.groupBoxDevMView.ResumeLayout(false);
            this.groupBoxDevMView.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.devicesGridView)).EndInit();
            this.devicesGridViewContextMenu.ResumeLayout(false);
            this.groupBoxDevMAction.ResumeLayout(false);
            this.tabDeviceGroup.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.deviceGroupsGridView)).EndInit();
            this.deviceGroupsGridViewContextMenu.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.tabDeviceRouting.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.devRoutingsGridView)).EndInit();
            this.deviceRoutingsGridViewContextMenu.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.tabAppMaster.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.appMastersGridView)).EndInit();
            this.appMastersGridViewContextMenu.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.tabAppRouting.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.appRoutingsGridView)).EndInit();
            this.appRoutingsGridViewContextMenu.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.tabFxTraceLog.ResumeLayout(false);
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fxTraceLogGridView)).EndInit();
            this.fxTraceLogGridViewContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabConnection;
        private System.Windows.Forms.TabPage tabDeviceMaster;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBoxEndPoint;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxIoTHubConnString;
        private System.Windows.Forms.TextBox textBoxSAKey;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxSAPolicyName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDownTTL;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button ButtonUpdateIoTConn;
        private System.Windows.Forms.Button buttonGenerateSAS;
        private System.Windows.Forms.TextBox textBoxSASValue;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxSQLConnectionString;
        private System.Windows.Forms.Button buttonUpdateSqlConn;
        private System.Windows.Forms.TabPage tabDeviceGroup;
        private System.Windows.Forms.TabPage tabDeviceRouting;
        private System.Windows.Forms.TabPage tabAppMaster;
        private System.Windows.Forms.TabPage tabAppRouting;
        private System.Windows.Forms.GroupBox groupBoxDevMAction;
        private System.Windows.Forms.Button sasTokenButton;
        private System.Windows.Forms.Button createDeviceButton;
        private System.Windows.Forms.Button listDevicesButton;
        private System.Windows.Forms.Button updateDeviceButton;
        private System.Windows.Forms.Button deleteDeviceButton;
        private System.Windows.Forms.GroupBox groupBoxDevMView;
        private System.Windows.Forms.Label deviceCountLabel;
        private System.Windows.Forms.Label totalLabel;
        private System.Windows.Forms.DataGridView devicesGridView;
        private System.Windows.Forms.ContextMenuStrip devicesGridViewContextMenu;
        private System.Windows.Forms.ToolStripMenuItem copySelectedToolMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem getDeviceConnectionStringToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem LaunchSimulatorMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button buttonUpdateQStorageConnString;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxQStorageConnString;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxDeviceGroupId;
        private System.Windows.Forms.Button listDeviceGrpButton;
        private System.Windows.Forms.Label deviceGroupCountLabel;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView deviceGroupsGridView;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button createDeviceGrpButton;
        private System.Windows.Forms.Button updateDeviceGrpButton;
        private System.Windows.Forms.Button deleteDeviceGrpButton;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxRoutingDeviceId;
        private System.Windows.Forms.Button listDevRoutingButton;
        private System.Windows.Forms.Label devRoutingCountLabel;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DataGridView devRoutingsGridView;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button createDevRoutingButton;
        private System.Windows.Forms.Button updateDevRoutingButton;
        private System.Windows.Forms.Button deleteDevRoutingButton;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBoxAppMasterAppId;
        private System.Windows.Forms.Button listAppMasterButton;
        private System.Windows.Forms.Label appMasterCountLabel;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DataGridView appMastersGridView;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox textBoxEncPassphrase;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button createAppMasterButton;
        private System.Windows.Forms.Button updateAppMasterButton;
        private System.Windows.Forms.Button deleteAppMasterButton;
        private System.Windows.Forms.Button saveEncPassphraseButton;
        private System.Windows.Forms.ContextMenuStrip deviceGroupsGridViewContextMenu;
        private System.Windows.Forms.ToolStripMenuItem copyAllToolStripOnGroup;
        private System.Windows.Forms.ToolStripMenuItem copySelectedToolStripOnGroup;
        private System.Windows.Forms.ContextMenuStrip deviceRoutingsGridViewContextMenu;
        private System.Windows.Forms.ToolStripMenuItem copyAllToolStripOnDevRouting;
        private System.Windows.Forms.ToolStripMenuItem copySelectedToolStripOnDevRouting;
        private System.Windows.Forms.ContextMenuStrip appMastersGridViewContextMenu;
        private System.Windows.Forms.ToolStripMenuItem copyAllToolStripOnAppMaster;
        private System.Windows.Forms.ToolStripMenuItem copySelectedToolStripOnAppMaster;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox textBoxAppRoutingAppId;
        private System.Windows.Forms.Button listAppRoutingButton;
        private System.Windows.Forms.Label appRoutingCountLabel;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.DataGridView appRoutingsGridView;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Button createAppRoutingButton;
        private System.Windows.Forms.Button updateAppRoutingButton;
        private System.Windows.Forms.Button deleteAppRoutingButton;
        private System.Windows.Forms.ContextMenuStrip appRoutingsGridViewContextMenu;
        private System.Windows.Forms.ToolStripMenuItem copyAllToolStripOnAppRouting;
        private System.Windows.Forms.ToolStripMenuItem copySelectedToolStripOnAppRouting;
        private System.Windows.Forms.TabPage tabFxTraceLog;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox textBoxFxTraceLogDate;
        private System.Windows.Forms.Button listFxTraceLogButton;
        private System.Windows.Forms.Label fxTraceLogCountLabel;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.DataGridView fxTraceLogGridView;
        private System.Windows.Forms.CheckBox checkBoxFxTrcDesc;
        private System.Windows.Forms.TextBox textBoxFxTrcTableName;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox textBoxFxTrcStorgaKey;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox textBoxFxTrcStorgaAccount;
        private System.Windows.Forms.ContextMenuStrip fxTraceLogGridViewContextMenu;
        private System.Windows.Forms.ToolStripMenuItem copyAllToolStripOnFxTraceLog;
        private System.Windows.Forms.ToolStripMenuItem copySelectedToolStripOnFxTraceLog;
    }
}

