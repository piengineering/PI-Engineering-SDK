namespace PIHidDotName_Csharp_Sample
{
    partial class Form1
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
            this.BtnEnumerate = new System.Windows.Forms.Button();
            this.CboDevices = new System.Windows.Forms.ComboBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.BtnUnitID = new System.Windows.Forms.Button();
            this.TxtSetUnitID = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.BtnCallback = new System.Windows.Forms.Button();
            this.LblUnitID = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.BtnPID3 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.BtnKBreflect = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.BtnTimeStamp = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.BtnDescriptor = new System.Windows.Forms.Button();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.label23 = new System.Windows.Forms.Label();
            this.BtnTimeStampOn = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.BtnGetDataNow = new System.Windows.Forms.Button();
            this.ChkSuppress = new System.Windows.Forms.CheckBox();
            this.BtnCustom = new System.Windows.Forms.Button();
            this.label43 = new System.Windows.Forms.Label();
            this.LblVersion = new System.Windows.Forms.Label();
            this.TxtVersion = new System.Windows.Forms.TextBox();
            this.BtnVersion = new System.Windows.Forms.Button();
            this.lblAESPassFail = new System.Windows.Forms.Label();
            this.BtnCheckDongle = new System.Windows.Forms.Button();
            this.BtnSetDongle = new System.Windows.Forms.Button();
            this.label44 = new System.Windows.Forms.Label();
            this.cboPIDs = new System.Windows.Forms.ComboBox();
            this.label47 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.BtnChange = new System.Windows.Forms.Button();
            this.BtnNoChange = new System.Windows.Forms.Button();
            this.LblScrLk = new System.Windows.Forms.Label();
            this.LblCapsLk = new System.Windows.Forms.Label();
            this.LblNumLk = new System.Windows.Forms.Label();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.ChkLEDOnOff = new System.Windows.Forms.CheckBox();
            this.CboLED = new System.Windows.Forms.ComboBox();
            this.lblSiliconGeneratedID = new System.Windows.Forms.Label();
            this.label57 = new System.Windows.Forms.Label();
            this.btnSiliconGeneratedID = new System.Windows.Forms.Button();
            this.BtnSleep = new System.Windows.Forms.Button();
            this.BtnMyComputer = new System.Windows.Forms.Button();
            this.label40 = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.TxtMMHigh = new System.Windows.Forms.TextBox();
            this.TxtMMLow = new System.Windows.Forms.TextBox();
            this.BtnMultiMedia = new System.Windows.Forms.Button();
            this.label42 = new System.Windows.Forms.Label();
            this.lblXkeysDecrypt = new System.Windows.Forms.Label();
            this.btnXkeysDecrypt = new System.Windows.Forms.Button();
            this.lblXkeysEncrypt = new System.Windows.Forms.Label();
            this.txtXkeysEncrypt = new System.Windows.Forms.TextBox();
            this.label62 = new System.Windows.Forms.Label();
            this.btnAESEncrypt = new System.Windows.Forms.Button();
            this.btnRawAESSetKey = new System.Windows.Forms.Button();
            this.lblButtons = new System.Windows.Forms.Label();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnEnumerate
            // 
            this.BtnEnumerate.Location = new System.Drawing.Point(21, 31);
            this.BtnEnumerate.Margin = new System.Windows.Forms.Padding(2);
            this.BtnEnumerate.Name = "BtnEnumerate";
            this.BtnEnumerate.Size = new System.Drawing.Size(92, 22);
            this.BtnEnumerate.TabIndex = 0;
            this.BtnEnumerate.Text = "Enumerate";
            this.BtnEnumerate.UseVisualStyleBackColor = true;
            this.BtnEnumerate.Click += new System.EventHandler(this.BtnEnumerate_Click);
            // 
            // CboDevices
            // 
            this.CboDevices.FormattingEnabled = true;
            this.CboDevices.Location = new System.Drawing.Point(116, 32);
            this.CboDevices.Margin = new System.Windows.Forms.Padding(2);
            this.CboDevices.Name = "CboDevices";
            this.CboDevices.Size = new System.Drawing.Size(376, 21);
            this.CboDevices.TabIndex = 1;
            this.CboDevices.SelectedIndexChanged += new System.EventHandler(this.CboDevices_SelectedIndexChanged);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.HorizontalScrollbar = true;
            this.listBox1.Location = new System.Drawing.Point(21, 118);
            this.listBox1.Margin = new System.Windows.Forms.Padding(2);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(882, 82);
            this.listBox1.TabIndex = 6;
            // 
            // BtnUnitID
            // 
            this.BtnUnitID.Location = new System.Drawing.Point(21, 319);
            this.BtnUnitID.Margin = new System.Windows.Forms.Padding(2);
            this.BtnUnitID.Name = "BtnUnitID";
            this.BtnUnitID.Size = new System.Drawing.Size(92, 22);
            this.BtnUnitID.TabIndex = 8;
            this.BtnUnitID.Text = "Write Unit ID";
            this.BtnUnitID.UseVisualStyleBackColor = true;
            this.BtnUnitID.Click += new System.EventHandler(this.BtnUnitID_Click);
            // 
            // TxtSetUnitID
            // 
            this.TxtSetUnitID.Location = new System.Drawing.Point(122, 320);
            this.TxtSetUnitID.Margin = new System.Windows.Forms.Padding(2);
            this.TxtSetUnitID.Name = "TxtSetUnitID";
            this.TxtSetUnitID.Size = new System.Drawing.Size(30, 20);
            this.TxtSetUnitID.TabIndex = 7;
            this.TxtSetUnitID.Text = "1";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 901);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 10, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1000, 22);
            this.statusStrip1.TabIndex = 9;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(132, 17);
            this.toolStripStatusLabel1.Text = "No devices enumerated";
            // 
            // BtnCallback
            // 
            this.BtnCallback.Location = new System.Drawing.Point(21, 92);
            this.BtnCallback.Margin = new System.Windows.Forms.Padding(2);
            this.BtnCallback.Name = "BtnCallback";
            this.BtnCallback.Size = new System.Drawing.Size(122, 22);
            this.BtnCallback.TabIndex = 2;
            this.BtnCallback.Text = "Setup for Callback";
            this.BtnCallback.UseVisualStyleBackColor = true;
            this.BtnCallback.Click += new System.EventHandler(this.BtnCallback_Click);
            // 
            // LblUnitID
            // 
            this.LblUnitID.AutoSize = true;
            this.LblUnitID.Location = new System.Drawing.Point(159, 323);
            this.LblUnitID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LblUnitID.Name = "LblUnitID";
            this.LblUnitID.Size = new System.Drawing.Size(38, 13);
            this.LblUnitID.TabIndex = 12;
            this.LblUnitID.Text = "unit ID";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Do this first";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 69);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(174, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Set for data callback and read data";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 230);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Indicator LED Control";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(810, 91);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(93, 22);
            this.button1.TabIndex = 4;
            this.button1.Text = "Clear Listbox";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(535, 439);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(272, 13);
            this.label5.TabIndex = 23;
            this.label5.Text = "Change PID/Endpoints (must enumerate after changing)";
            // 
            // BtnPID3
            // 
            this.BtnPID3.Location = new System.Drawing.Point(549, 511);
            this.BtnPID3.Margin = new System.Windows.Forms.Padding(2);
            this.BtnPID3.Name = "BtnPID3";
            this.BtnPID3.Size = new System.Drawing.Size(91, 22);
            this.BtnPID3.TabIndex = 33;
            this.BtnPID3.Text = "Change";
            this.BtnPID3.UseVisualStyleBackColor = true;
            this.BtnPID3.Click += new System.EventHandler(this.BtnPID3_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(535, 294);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(237, 13);
            this.label7.TabIndex = 30;
            this.label7.Text = "Keyboard Reflector (Keyboard endpoint required)";
            // 
            // BtnKBreflect
            // 
            this.BtnKBreflect.Location = new System.Drawing.Point(549, 319);
            this.BtnKBreflect.Margin = new System.Windows.Forms.Padding(2);
            this.BtnKBreflect.Name = "BtnKBreflect";
            this.BtnKBreflect.Size = new System.Drawing.Size(122, 22);
            this.BtnKBreflect.TabIndex = 30;
            this.BtnKBreflect.Text = "Keyboard Reflector";
            this.BtnKBreflect.UseVisualStyleBackColor = true;
            this.BtnKBreflect.Click += new System.EventHandler(this.BtnKBreflect_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(675, 319);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(191, 20);
            this.textBox1.TabIndex = 32;
            // 
            // BtnTimeStamp
            // 
            this.BtnTimeStamp.Location = new System.Drawing.Point(21, 602);
            this.BtnTimeStamp.Margin = new System.Windows.Forms.Padding(2);
            this.BtnTimeStamp.Name = "BtnTimeStamp";
            this.BtnTimeStamp.Size = new System.Drawing.Size(98, 22);
            this.BtnTimeStamp.TabIndex = 22;
            this.BtnTimeStamp.Text = "Time Stamp Off";
            this.BtnTimeStamp.UseVisualStyleBackColor = true;
            this.BtnTimeStamp.Click += new System.EventHandler(this.BtnTimeStamp_Click);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(244, 604);
            this.label19.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(69, 13);
            this.label19.TabIndex = 59;
            this.label19.Text = "absolute time";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(244, 623);
            this.label20.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(52, 13);
            this.label20.TabIndex = 60;
            this.label20.Text = "delta time";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(8, 363);
            this.label21.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(55, 13);
            this.label21.TabIndex = 61;
            this.label21.Text = "Descriptor";
            // 
            // BtnDescriptor
            // 
            this.BtnDescriptor.Location = new System.Drawing.Point(21, 388);
            this.BtnDescriptor.Margin = new System.Windows.Forms.Padding(2);
            this.BtnDescriptor.Name = "BtnDescriptor";
            this.BtnDescriptor.Size = new System.Drawing.Size(92, 22);
            this.BtnDescriptor.TabIndex = 31;
            this.BtnDescriptor.Text = "Descriptor";
            this.BtnDescriptor.UseVisualStyleBackColor = true;
            this.BtnDescriptor.Click += new System.EventHandler(this.BtnDescriptor_Click);
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point(132, 388);
            this.listBox2.Margin = new System.Windows.Forms.Padding(2);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(232, 147);
            this.listBox2.TabIndex = 63;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(11, 577);
            this.label23.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(99, 13);
            this.label23.TabIndex = 67;
            this.label23.Text = "Enable Time Stamp";
            // 
            // BtnTimeStampOn
            // 
            this.BtnTimeStampOn.Location = new System.Drawing.Point(133, 602);
            this.BtnTimeStampOn.Margin = new System.Windows.Forms.Padding(2);
            this.BtnTimeStampOn.Name = "BtnTimeStampOn";
            this.BtnTimeStampOn.Size = new System.Drawing.Size(92, 22);
            this.BtnTimeStampOn.TabIndex = 23;
            this.BtnTimeStampOn.Text = "Time Stamp On";
            this.BtnTimeStampOn.UseVisualStyleBackColor = true;
            this.BtnTimeStampOn.Click += new System.EventHandler(this.BtnTimeStampOn_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(11, 294);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(68, 13);
            this.label13.TabIndex = 87;
            this.label13.Text = "Write Unit ID";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(11, 650);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(339, 13);
            this.label14.TabIndex = 120;
            this.label14.Text = "Stimulate a general incoming data report or send a custom input report.";
            // 
            // BtnGetDataNow
            // 
            this.BtnGetDataNow.Location = new System.Drawing.Point(21, 672);
            this.BtnGetDataNow.Margin = new System.Windows.Forms.Padding(2);
            this.BtnGetDataNow.Name = "BtnGetDataNow";
            this.BtnGetDataNow.Size = new System.Drawing.Size(98, 22);
            this.BtnGetDataNow.TabIndex = 24;
            this.BtnGetDataNow.Text = "Generate Data";
            this.BtnGetDataNow.UseVisualStyleBackColor = true;
            this.BtnGetDataNow.Click += new System.EventHandler(this.BtnGetDataNow_Click);
            // 
            // ChkSuppress
            // 
            this.ChkSuppress.AutoSize = true;
            this.ChkSuppress.Location = new System.Drawing.Point(148, 96);
            this.ChkSuppress.Name = "ChkSuppress";
            this.ChkSuppress.Size = new System.Drawing.Size(158, 17);
            this.ChkSuppress.TabIndex = 3;
            this.ChkSuppress.Text = "Suppress Duplicate Reports";
            this.ChkSuppress.UseVisualStyleBackColor = true;
            this.ChkSuppress.CheckedChanged += new System.EventHandler(this.ChkSuppress_CheckedChanged);
            // 
            // BtnCustom
            // 
            this.BtnCustom.Location = new System.Drawing.Point(133, 672);
            this.BtnCustom.Margin = new System.Windows.Forms.Padding(2);
            this.BtnCustom.Name = "BtnCustom";
            this.BtnCustom.Size = new System.Drawing.Size(92, 22);
            this.BtnCustom.TabIndex = 25;
            this.BtnCustom.Text = "Custom Data";
            this.BtnCustom.UseVisualStyleBackColor = true;
            this.BtnCustom.Click += new System.EventHandler(this.BtnCustom_Click);
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Location = new System.Drawing.Point(12, 718);
            this.label43.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(195, 13);
            this.label43.TabIndex = 279;
            this.label43.Text = "Write Version (0-65535), reboot required";
            // 
            // LblVersion
            // 
            this.LblVersion.AutoSize = true;
            this.LblVersion.Location = new System.Drawing.Point(177, 743);
            this.LblVersion.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LblVersion.Name = "LblVersion";
            this.LblVersion.Size = new System.Drawing.Size(41, 13);
            this.LblVersion.TabIndex = 278;
            this.LblVersion.Text = "version";
            // 
            // TxtVersion
            // 
            this.TxtVersion.Location = new System.Drawing.Point(124, 740);
            this.TxtVersion.Margin = new System.Windows.Forms.Padding(2);
            this.TxtVersion.Name = "TxtVersion";
            this.TxtVersion.Size = new System.Drawing.Size(49, 20);
            this.TxtVersion.TabIndex = 28;
            this.TxtVersion.Text = "100";
            // 
            // BtnVersion
            // 
            this.BtnVersion.Location = new System.Drawing.Point(21, 738);
            this.BtnVersion.Margin = new System.Windows.Forms.Padding(2);
            this.BtnVersion.Name = "BtnVersion";
            this.BtnVersion.Size = new System.Drawing.Size(98, 22);
            this.BtnVersion.TabIndex = 29;
            this.BtnVersion.Text = "Write Version";
            this.BtnVersion.UseVisualStyleBackColor = true;
            this.BtnVersion.Click += new System.EventHandler(this.BtnVersion_Click);
            // 
            // lblAESPassFail
            // 
            this.lblAESPassFail.AutoSize = true;
            this.lblAESPassFail.Location = new System.Drawing.Point(816, 664);
            this.lblAESPassFail.Name = "lblAESPassFail";
            this.lblAESPassFail.Size = new System.Drawing.Size(51, 13);
            this.lblAESPassFail.TabIndex = 297;
            this.lblAESPassFail.Text = "Pass/Fail";
            // 
            // BtnCheckDongle
            // 
            this.BtnCheckDongle.Location = new System.Drawing.Point(679, 659);
            this.BtnCheckDongle.Margin = new System.Windows.Forms.Padding(2);
            this.BtnCheckDongle.Name = "BtnCheckDongle";
            this.BtnCheckDongle.Size = new System.Drawing.Size(132, 23);
            this.BtnCheckDongle.TabIndex = 27;
            this.BtnCheckDongle.Text = "Check AES Key";
            this.BtnCheckDongle.UseVisualStyleBackColor = true;
            this.BtnCheckDongle.Click += new System.EventHandler(this.BtnCheckDongle_Click);
            // 
            // BtnSetDongle
            // 
            this.BtnSetDongle.Location = new System.Drawing.Point(543, 659);
            this.BtnSetDongle.Margin = new System.Windows.Forms.Padding(2);
            this.BtnSetDongle.Name = "BtnSetDongle";
            this.BtnSetDongle.Size = new System.Drawing.Size(132, 23);
            this.BtnSetDongle.TabIndex = 26;
            this.BtnSetDongle.Text = "Set AES Key";
            this.BtnSetDongle.UseVisualStyleBackColor = true;
            this.BtnSetDongle.Click += new System.EventHandler(this.BtnSetDongle_Click);
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Location = new System.Drawing.Point(529, 638);
            this.label44.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(65, 13);
            this.label44.TabIndex = 294;
            this.label44.Text = "AES Dongle";
            // 
            // cboPIDs
            // 
            this.cboPIDs.FormattingEnabled = true;
            this.cboPIDs.Items.AddRange(new object[] {
            "PID 1: Keyboard, PI Consumer, Output",
            "PID 2: Keyboard (boot) for KVM users"});
            this.cboPIDs.Location = new System.Drawing.Point(549, 480);
            this.cboPIDs.Name = "cboPIDs";
            this.cboPIDs.Size = new System.Drawing.Size(258, 21);
            this.cboPIDs.TabIndex = 32;
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.Location = new System.Drawing.Point(547, 464);
            this.label47.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(123, 13);
            this.label47.TabIndex = 336;
            this.label47.Text = "Select desired endpoints";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(529, 563);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(243, 13);
            this.label4.TabIndex = 339;
            this.label4.Text = "KVM Reboot Mode (for users of the KVM Pid only)";
            // 
            // BtnChange
            // 
            this.BtnChange.Location = new System.Drawing.Point(716, 590);
            this.BtnChange.Name = "BtnChange";
            this.BtnChange.Size = new System.Drawing.Size(225, 23);
            this.BtnChange.TabIndex = 35;
            this.BtnChange.Text = "Always change to PID #2 (KVM) on reboot";
            this.BtnChange.UseVisualStyleBackColor = true;
            this.BtnChange.Click += new System.EventHandler(this.BtnChange_Click);
            // 
            // BtnNoChange
            // 
            this.BtnNoChange.Location = new System.Drawing.Point(543, 590);
            this.BtnNoChange.Name = "BtnNoChange";
            this.BtnNoChange.Size = new System.Drawing.Size(163, 23);
            this.BtnNoChange.TabIndex = 34;
            this.BtnNoChange.Text = "Do not change PID on reboot";
            this.BtnNoChange.UseVisualStyleBackColor = true;
            this.BtnNoChange.Click += new System.EventHandler(this.BtnNoChange_Click);
            // 
            // LblScrLk
            // 
            this.LblScrLk.AutoSize = true;
            this.LblScrLk.Location = new System.Drawing.Point(762, 230);
            this.LblScrLk.Name = "LblScrLk";
            this.LblScrLk.Size = new System.Drawing.Size(53, 13);
            this.LblScrLk.TabIndex = 344;
            this.LblScrLk.Text = "ScrLock: ";
            // 
            // LblCapsLk
            // 
            this.LblCapsLk.AutoSize = true;
            this.LblCapsLk.Location = new System.Drawing.Point(762, 216);
            this.LblCapsLk.Name = "LblCapsLk";
            this.LblCapsLk.Size = new System.Drawing.Size(61, 13);
            this.LblCapsLk.TabIndex = 343;
            this.LblCapsLk.Text = "CapsLock: ";
            // 
            // LblNumLk
            // 
            this.LblNumLk.AutoSize = true;
            this.LblNumLk.Location = new System.Drawing.Point(762, 201);
            this.LblNumLk.Name = "LblNumLk";
            this.LblNumLk.Size = new System.Drawing.Size(59, 13);
            this.LblNumLk.TabIndex = 342;
            this.LblNumLk.Text = "NumLock: ";
            // 
            // ChkLEDOnOff
            // 
            this.ChkLEDOnOff.AutoSize = true;
            this.ChkLEDOnOff.Location = new System.Drawing.Point(96, 254);
            this.ChkLEDOnOff.Margin = new System.Windows.Forms.Padding(2);
            this.ChkLEDOnOff.Name = "ChkLEDOnOff";
            this.ChkLEDOnOff.Size = new System.Drawing.Size(89, 17);
            this.ChkLEDOnOff.TabIndex = 6;
            this.ChkLEDOnOff.Text = "On/Off/Flash";
            this.ChkLEDOnOff.ThreeState = true;
            this.ChkLEDOnOff.UseVisualStyleBackColor = true;
            this.ChkLEDOnOff.CheckStateChanged += new System.EventHandler(this.ChkLEDOnOff_CheckStateChanged);
            // 
            // CboLED
            // 
            this.CboLED.FormattingEnabled = true;
            this.CboLED.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.CboLED.Location = new System.Drawing.Point(21, 252);
            this.CboLED.Name = "CboLED";
            this.CboLED.Size = new System.Drawing.Size(68, 21);
            this.CboLED.TabIndex = 5;
            // 
            // lblSiliconGeneratedID
            // 
            this.lblSiliconGeneratedID.AutoSize = true;
            this.lblSiliconGeneratedID.Location = new System.Drawing.Point(101, 809);
            this.lblSiliconGeneratedID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSiliconGeneratedID.Name = "lblSiliconGeneratedID";
            this.lblSiliconGeneratedID.Size = new System.Drawing.Size(99, 13);
            this.lblSiliconGeneratedID.TabIndex = 512;
            this.lblSiliconGeneratedID.Text = "Silicon Generate ID";
            // 
            // label57
            // 
            this.label57.AutoSize = true;
            this.label57.Location = new System.Drawing.Point(12, 786);
            this.label57.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(128, 13);
            this.label57.TabIndex = 511;
            this.label57.Text = "Read Silicon Generate ID";
            // 
            // btnSiliconGeneratedID
            // 
            this.btnSiliconGeneratedID.Location = new System.Drawing.Point(21, 804);
            this.btnSiliconGeneratedID.Name = "btnSiliconGeneratedID";
            this.btnSiliconGeneratedID.Size = new System.Drawing.Size(75, 23);
            this.btnSiliconGeneratedID.TabIndex = 510;
            this.btnSiliconGeneratedID.Text = "Read ID";
            this.btnSiliconGeneratedID.UseVisualStyleBackColor = true;
            this.btnSiliconGeneratedID.Click += new System.EventHandler(this.btnSiliconGeneratedID_Click);
            // 
            // BtnSleep
            // 
            this.BtnSleep.Location = new System.Drawing.Point(898, 388);
            this.BtnSleep.Name = "BtnSleep";
            this.BtnSleep.Size = new System.Drawing.Size(75, 22);
            this.BtnSleep.TabIndex = 516;
            this.BtnSleep.Text = "Sleep";
            this.BtnSleep.UseVisualStyleBackColor = true;
            this.BtnSleep.Click += new System.EventHandler(this.BtnSleep_Click);
            // 
            // BtnMyComputer
            // 
            this.BtnMyComputer.Location = new System.Drawing.Point(813, 388);
            this.BtnMyComputer.Margin = new System.Windows.Forms.Padding(2);
            this.BtnMyComputer.Name = "BtnMyComputer";
            this.BtnMyComputer.Size = new System.Drawing.Size(80, 22);
            this.BtnMyComputer.TabIndex = 515;
            this.BtnMyComputer.Text = "My Computer";
            this.BtnMyComputer.UseVisualStyleBackColor = true;
            this.BtnMyComputer.Click += new System.EventHandler(this.BtnMyComputer_Click);
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(682, 375);
            this.label40.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(55, 13);
            this.label40.TabIndex = 520;
            this.label40.Text = "High (hex)";
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(743, 375);
            this.label41.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(45, 13);
            this.label41.TabIndex = 519;
            this.label41.Text = "Lo (hex)";
            // 
            // TxtMMHigh
            // 
            this.TxtMMHigh.Location = new System.Drawing.Point(685, 390);
            this.TxtMMHigh.Margin = new System.Windows.Forms.Padding(2);
            this.TxtMMHigh.Name = "TxtMMHigh";
            this.TxtMMHigh.Size = new System.Drawing.Size(30, 20);
            this.TxtMMHigh.TabIndex = 518;
            this.TxtMMHigh.Text = "00";
            // 
            // TxtMMLow
            // 
            this.TxtMMLow.Location = new System.Drawing.Point(746, 390);
            this.TxtMMLow.Margin = new System.Windows.Forms.Padding(2);
            this.TxtMMLow.Name = "TxtMMLow";
            this.TxtMMLow.Size = new System.Drawing.Size(30, 20);
            this.TxtMMLow.TabIndex = 517;
            this.TxtMMLow.Text = "E2";
            // 
            // BtnMultiMedia
            // 
            this.BtnMultiMedia.Location = new System.Drawing.Point(550, 388);
            this.BtnMultiMedia.Margin = new System.Windows.Forms.Padding(2);
            this.BtnMultiMedia.Name = "BtnMultiMedia";
            this.BtnMultiMedia.Size = new System.Drawing.Size(122, 22);
            this.BtnMultiMedia.TabIndex = 514;
            this.BtnMultiMedia.Text = "Multimedia Reflector";
            this.BtnMultiMedia.UseVisualStyleBackColor = true;
            this.BtnMultiMedia.Click += new System.EventHandler(this.BtnMultiMedia_Click);
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Location = new System.Drawing.Point(537, 363);
            this.label42.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(201, 13);
            this.label42.TabIndex = 513;
            this.label42.Text = "Multimedia (Multimedia endpoint required)";
            // 
            // lblXkeysDecrypt
            // 
            this.lblXkeysDecrypt.AutoSize = true;
            this.lblXkeysDecrypt.Location = new System.Drawing.Point(680, 774);
            this.lblXkeysDecrypt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblXkeysDecrypt.Name = "lblXkeysDecrypt";
            this.lblXkeysDecrypt.Size = new System.Drawing.Size(70, 13);
            this.lblXkeysDecrypt.TabIndex = 578;
            this.lblXkeysDecrypt.Text = "decrypt result";
            // 
            // btnXkeysDecrypt
            // 
            this.btnXkeysDecrypt.Location = new System.Drawing.Point(543, 769);
            this.btnXkeysDecrypt.Name = "btnXkeysDecrypt";
            this.btnXkeysDecrypt.Size = new System.Drawing.Size(132, 23);
            this.btnXkeysDecrypt.TabIndex = 577;
            this.btnXkeysDecrypt.Text = "AES Decrypt";
            this.btnXkeysDecrypt.UseVisualStyleBackColor = true;
            this.btnXkeysDecrypt.Click += new System.EventHandler(this.btnXkeysDecrypt_Click);
            // 
            // lblXkeysEncrypt
            // 
            this.lblXkeysEncrypt.Location = new System.Drawing.Point(773, 745);
            this.lblXkeysEncrypt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblXkeysEncrypt.Name = "lblXkeysEncrypt";
            this.lblXkeysEncrypt.Size = new System.Drawing.Size(150, 47);
            this.lblXkeysEncrypt.TabIndex = 576;
            this.lblXkeysEncrypt.Text = "encrypt result";
            // 
            // txtXkeysEncrypt
            // 
            this.txtXkeysEncrypt.Location = new System.Drawing.Point(678, 742);
            this.txtXkeysEncrypt.Name = "txtXkeysEncrypt";
            this.txtXkeysEncrypt.Size = new System.Drawing.Size(83, 20);
            this.txtXkeysEncrypt.TabIndex = 575;
            this.txtXkeysEncrypt.Text = "Encrypt Me";
            // 
            // label62
            // 
            this.label62.AutoSize = true;
            this.label62.Location = new System.Drawing.Point(533, 697);
            this.label62.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label62.Name = "label62";
            this.label62.Size = new System.Drawing.Size(109, 13);
            this.label62.TabIndex = 574;
            this.label62.Text = "AES Encrypt/Decrypt";
            // 
            // btnAESEncrypt
            // 
            this.btnAESEncrypt.Location = new System.Drawing.Point(543, 740);
            this.btnAESEncrypt.Margin = new System.Windows.Forms.Padding(2);
            this.btnAESEncrypt.Name = "btnAESEncrypt";
            this.btnAESEncrypt.Size = new System.Drawing.Size(132, 23);
            this.btnAESEncrypt.TabIndex = 573;
            this.btnAESEncrypt.Text = "AES Encrypt";
            this.btnAESEncrypt.UseVisualStyleBackColor = true;
            this.btnAESEncrypt.Click += new System.EventHandler(this.btnAESEncrypt_Click);
            // 
            // btnRawAESSetKey
            // 
            this.btnRawAESSetKey.Location = new System.Drawing.Point(543, 712);
            this.btnRawAESSetKey.Margin = new System.Windows.Forms.Padding(2);
            this.btnRawAESSetKey.Name = "btnRawAESSetKey";
            this.btnRawAESSetKey.Size = new System.Drawing.Size(132, 23);
            this.btnRawAESSetKey.TabIndex = 572;
            this.btnRawAESSetKey.Text = "Set AES Key";
            this.btnRawAESSetKey.UseVisualStyleBackColor = true;
            this.btnRawAESSetKey.Click += new System.EventHandler(this.btnRawAESSetKey_Click);
            // 
            // lblButtons
            // 
            this.lblButtons.AutoSize = true;
            this.lblButtons.Location = new System.Drawing.Point(21, 201);
            this.lblButtons.Name = "lblButtons";
            this.lblButtons.Size = new System.Drawing.Size(49, 13);
            this.lblButtons.TabIndex = 579;
            this.lblButtons.Text = "Buttons: ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1000, 923);
            this.Controls.Add(this.lblButtons);
            this.Controls.Add(this.lblXkeysDecrypt);
            this.Controls.Add(this.btnXkeysDecrypt);
            this.Controls.Add(this.lblXkeysEncrypt);
            this.Controls.Add(this.txtXkeysEncrypt);
            this.Controls.Add(this.label62);
            this.Controls.Add(this.btnAESEncrypt);
            this.Controls.Add(this.btnRawAESSetKey);
            this.Controls.Add(this.BtnSleep);
            this.Controls.Add(this.BtnMyComputer);
            this.Controls.Add(this.label40);
            this.Controls.Add(this.label41);
            this.Controls.Add(this.TxtMMHigh);
            this.Controls.Add(this.TxtMMLow);
            this.Controls.Add(this.BtnMultiMedia);
            this.Controls.Add(this.label42);
            this.Controls.Add(this.lblSiliconGeneratedID);
            this.Controls.Add(this.label57);
            this.Controls.Add(this.btnSiliconGeneratedID);
            this.Controls.Add(this.ChkLEDOnOff);
            this.Controls.Add(this.CboLED);
            this.Controls.Add(this.LblScrLk);
            this.Controls.Add(this.LblCapsLk);
            this.Controls.Add(this.LblNumLk);
            this.Controls.Add(this.BtnChange);
            this.Controls.Add(this.BtnNoChange);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.label47);
            this.Controls.Add(this.cboPIDs);
            this.Controls.Add(this.lblAESPassFail);
            this.Controls.Add(this.BtnCheckDongle);
            this.Controls.Add(this.BtnSetDongle);
            this.Controls.Add(this.label44);
            this.Controls.Add(this.label43);
            this.Controls.Add(this.LblVersion);
            this.Controls.Add(this.TxtVersion);
            this.Controls.Add(this.BtnVersion);
            this.Controls.Add(this.BtnCustom);
            this.Controls.Add(this.ChkSuppress);
            this.Controls.Add(this.BtnGetDataNow);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.BtnTimeStampOn);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.BtnDescriptor);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.BtnTimeStamp);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.BtnKBreflect);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.BtnPID3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LblUnitID);
            this.Controls.Add(this.BtnCallback);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.TxtSetUnitID);
            this.Controls.Add(this.BtnUnitID);
            this.Controls.Add(this.CboDevices);
            this.Controls.Add(this.BtnEnumerate);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "C# X-keys Control Room Keyboard";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnEnumerate;
        private System.Windows.Forms.ComboBox CboDevices;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button BtnUnitID;
        private System.Windows.Forms.TextBox TxtSetUnitID;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Button BtnCallback;
        private System.Windows.Forms.Label LblUnitID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button BtnPID3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button BtnKBreflect;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button BtnTimeStamp;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Button BtnDescriptor;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Button BtnTimeStampOn;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button BtnGetDataNow;
        private System.Windows.Forms.CheckBox ChkSuppress;
        private System.Windows.Forms.Button BtnCustom;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.Label LblVersion;
        private System.Windows.Forms.TextBox TxtVersion;
        private System.Windows.Forms.Button BtnVersion;
        private System.Windows.Forms.Label lblAESPassFail;
        private System.Windows.Forms.Button BtnCheckDongle;
        private System.Windows.Forms.Button BtnSetDongle;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.ComboBox cboPIDs;
        private System.Windows.Forms.Label label47;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button BtnChange;
        private System.Windows.Forms.Button BtnNoChange;
        private System.Windows.Forms.Label LblScrLk;
        private System.Windows.Forms.Label LblCapsLk;
        private System.Windows.Forms.Label LblNumLk;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.CheckBox ChkLEDOnOff;
        private System.Windows.Forms.ComboBox CboLED;
        private System.Windows.Forms.Label lblSiliconGeneratedID;
        private System.Windows.Forms.Label label57;
        private System.Windows.Forms.Button btnSiliconGeneratedID;
        private System.Windows.Forms.Button BtnSleep;
        private System.Windows.Forms.Button BtnMyComputer;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.TextBox TxtMMHigh;
        private System.Windows.Forms.TextBox TxtMMLow;
        private System.Windows.Forms.Button BtnMultiMedia;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.Label lblXkeysDecrypt;
        private System.Windows.Forms.Button btnXkeysDecrypt;
        private System.Windows.Forms.Label lblXkeysEncrypt;
        private System.Windows.Forms.TextBox txtXkeysEncrypt;
        private System.Windows.Forms.Label label62;
        private System.Windows.Forms.Button btnAESEncrypt;
        private System.Windows.Forms.Button btnRawAESSetKey;
        private System.Windows.Forms.Label lblButtons;
    }
}

