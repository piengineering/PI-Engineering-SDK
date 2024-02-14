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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.BtnEnumerate = new System.Windows.Forms.Button();
            this.CboDevices = new System.Windows.Forms.ComboBox();
            this.LblSwitchPos = new System.Windows.Forms.Label();
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
            this.BtnBL = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.BtnKBreflect = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.BtnTimeStamp = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.BtnDescriptor = new System.Windows.Forms.Button();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.ChkScrollLock = new System.Windows.Forms.CheckBox();
            this.label23 = new System.Windows.Forms.Label();
            this.BtnSaveBL = new System.Windows.Forms.Button();
            this.BtnBLToggle = new System.Windows.Forms.Button();
            this.BtnTimeStampOn = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.ChkGreenOnOff = new System.Windows.Forms.CheckBox();
            this.BtnSetFlash = new System.Windows.Forms.Button();
            this.TxtFlashFreq = new System.Windows.Forms.TextBox();
            this.ChkRedLED = new System.Windows.Forms.CheckBox();
            this.ChkGreenLED = new System.Windows.Forms.CheckBox();
            this.ChkBLOnOff = new System.Windows.Forms.CheckBox();
            this.CboBL = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.BtnGetDataNow = new System.Windows.Forms.Button();
            this.ChkSuppress = new System.Windows.Forms.CheckBox();
            this.myBtn0 = new System.Windows.Forms.Label();
            this.myBtn1 = new System.Windows.Forms.Label();
            this.myBtn2 = new System.Windows.Forms.Label();
            this.myBtn3 = new System.Windows.Forms.Label();
            this.myBtn11 = new System.Windows.Forms.Label();
            this.myBtn10 = new System.Windows.Forms.Label();
            this.myBtn9 = new System.Windows.Forms.Label();
            this.myBtn8 = new System.Windows.Forms.Label();
            this.myBtn19 = new System.Windows.Forms.Label();
            this.myBtn18 = new System.Windows.Forms.Label();
            this.myBtn17 = new System.Windows.Forms.Label();
            this.myBtn16 = new System.Windows.Forms.Label();
            this.myBtn27 = new System.Windows.Forms.Label();
            this.myBtn26 = new System.Windows.Forms.Label();
            this.myBtn25 = new System.Windows.Forms.Label();
            this.myBtn24 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.TxtMouseY = new System.Windows.Forms.TextBox();
            this.TxtMouseX = new System.Windows.Forms.TextBox();
            this.label36 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.TxtMouseWheel = new System.Windows.Forms.TextBox();
            this.label32 = new System.Windows.Forms.Label();
            this.TxtMouseButton = new System.Windows.Forms.TextBox();
            this.BtnMousereflect = new System.Windows.Forms.Button();
            this.label43 = new System.Windows.Forms.Label();
            this.LblVersion = new System.Windows.Forms.Label();
            this.TxtVersion = new System.Windows.Forms.TextBox();
            this.BtnVersion = new System.Windows.Forms.Button();
            this.BtnCustom = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnEnumerate
            // 
            this.BtnEnumerate.Location = new System.Drawing.Point(9, 31);
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
            this.CboDevices.Location = new System.Drawing.Point(116, 30);
            this.CboDevices.Margin = new System.Windows.Forms.Padding(2);
            this.CboDevices.Name = "CboDevices";
            this.CboDevices.Size = new System.Drawing.Size(376, 21);
            this.CboDevices.TabIndex = 1;
            this.CboDevices.SelectedIndexChanged += new System.EventHandler(this.CboDevices_SelectedIndexChanged);
            // 
            // LblSwitchPos
            // 
            this.LblSwitchPos.Location = new System.Drawing.Point(11, 191);
            this.LblSwitchPos.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LblSwitchPos.Name = "LblSwitchPos";
            this.LblSwitchPos.Size = new System.Drawing.Size(153, 18);
            this.LblSwitchPos.TabIndex = 5;
            this.LblSwitchPos.Text = "Switch Position";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.HorizontalScrollbar = true;
            this.listBox1.Location = new System.Drawing.Point(12, 118);
            this.listBox1.Margin = new System.Windows.Forms.Padding(2);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(480, 69);
            this.listBox1.TabIndex = 6;
            // 
            // BtnUnitID
            // 
            this.BtnUnitID.Location = new System.Drawing.Point(9, 319);
            this.BtnUnitID.Margin = new System.Windows.Forms.Padding(2);
            this.BtnUnitID.Name = "BtnUnitID";
            this.BtnUnitID.Size = new System.Drawing.Size(92, 22);
            this.BtnUnitID.TabIndex = 7;
            this.BtnUnitID.Text = "Write Unit ID";
            this.BtnUnitID.UseVisualStyleBackColor = true;
            this.BtnUnitID.Click += new System.EventHandler(this.BtnUnitID_Click);
            // 
            // TxtSetUnitID
            // 
            this.TxtSetUnitID.Location = new System.Drawing.Point(115, 319);
            this.TxtSetUnitID.Margin = new System.Windows.Forms.Padding(2);
            this.TxtSetUnitID.Name = "TxtSetUnitID";
            this.TxtSetUnitID.Size = new System.Drawing.Size(30, 20);
            this.TxtSetUnitID.TabIndex = 8;
            this.TxtSetUnitID.Text = "1";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 619);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 10, 0);
            this.statusStrip1.Size = new System.Drawing.Size(987, 22);
            this.statusStrip1.TabIndex = 9;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // BtnCallback
            // 
            this.BtnCallback.Location = new System.Drawing.Point(9, 92);
            this.BtnCallback.Margin = new System.Windows.Forms.Padding(2);
            this.BtnCallback.Name = "BtnCallback";
            this.BtnCallback.Size = new System.Drawing.Size(122, 22);
            this.BtnCallback.TabIndex = 10;
            this.BtnCallback.Text = "Setup for Callback";
            this.BtnCallback.UseVisualStyleBackColor = true;
            this.BtnCallback.Click += new System.EventHandler(this.BtnCallback_Click);
            // 
            // LblUnitID
            // 
            this.LblUnitID.AutoSize = true;
            this.LblUnitID.Location = new System.Drawing.Point(158, 323);
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
            this.label3.Location = new System.Drawing.Point(11, 234);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "LED Control";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(399, 92);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(93, 22);
            this.button1.TabIndex = 21;
            this.button1.Text = "Clear Listbox";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // BtnBL
            // 
            this.BtnBL.Location = new System.Drawing.Point(299, 448);
            this.BtnBL.Margin = new System.Windows.Forms.Padding(2);
            this.BtnBL.Name = "BtnBL";
            this.BtnBL.Size = new System.Drawing.Size(92, 22);
            this.BtnBL.TabIndex = 22;
            this.BtnBL.Text = "Set Intensity";
            this.BtnBL.UseVisualStyleBackColor = true;
            this.BtnBL.Click += new System.EventHandler(this.BtnBL_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(508, 9);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(98, 13);
            this.label7.TabIndex = 30;
            this.label7.Text = "Keyboard Reflector";
            // 
            // BtnKBreflect
            // 
            this.BtnKBreflect.Location = new System.Drawing.Point(523, 31);
            this.BtnKBreflect.Margin = new System.Windows.Forms.Padding(2);
            this.BtnKBreflect.Name = "BtnKBreflect";
            this.BtnKBreflect.Size = new System.Drawing.Size(122, 22);
            this.BtnKBreflect.TabIndex = 31;
            this.BtnKBreflect.Text = "Keyboard Reflector";
            this.BtnKBreflect.UseVisualStyleBackColor = true;
            this.BtnKBreflect.Click += new System.EventHandler(this.BtnKBreflect_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(649, 31);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(191, 20);
            this.textBox1.TabIndex = 32;
            // 
            // BtnTimeStamp
            // 
            this.BtnTimeStamp.Location = new System.Drawing.Point(10, 518);
            this.BtnTimeStamp.Margin = new System.Windows.Forms.Padding(2);
            this.BtnTimeStamp.Name = "BtnTimeStamp";
            this.BtnTimeStamp.Size = new System.Drawing.Size(92, 22);
            this.BtnTimeStamp.TabIndex = 58;
            this.BtnTimeStamp.Text = "Time Stamp Off";
            this.BtnTimeStamp.UseVisualStyleBackColor = true;
            this.BtnTimeStamp.Click += new System.EventHandler(this.BtnTimeStamp_Click);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(226, 518);
            this.label19.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(69, 13);
            this.label19.TabIndex = 59;
            this.label19.Text = "absolute time";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(226, 537);
            this.label20.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(52, 13);
            this.label20.TabIndex = 60;
            this.label20.Text = "delta time";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(509, 191);
            this.label21.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(55, 13);
            this.label21.TabIndex = 61;
            this.label21.Text = "Descriptor";
            // 
            // BtnDescriptor
            // 
            this.BtnDescriptor.Location = new System.Drawing.Point(523, 207);
            this.BtnDescriptor.Margin = new System.Windows.Forms.Padding(2);
            this.BtnDescriptor.Name = "BtnDescriptor";
            this.BtnDescriptor.Size = new System.Drawing.Size(92, 22);
            this.BtnDescriptor.TabIndex = 62;
            this.BtnDescriptor.Text = "Descriptor";
            this.BtnDescriptor.UseVisualStyleBackColor = true;
            this.BtnDescriptor.Click += new System.EventHandler(this.BtnDescriptor_Click);
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point(632, 208);
            this.listBox2.Margin = new System.Windows.Forms.Padding(2);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(232, 121);
            this.listBox2.TabIndex = 63;
            // 
            // ChkScrollLock
            // 
            this.ChkScrollLock.AutoSize = true;
            this.ChkScrollLock.Location = new System.Drawing.Point(216, 452);
            this.ChkScrollLock.Margin = new System.Windows.Forms.Padding(2);
            this.ChkScrollLock.Name = "ChkScrollLock";
            this.ChkScrollLock.Size = new System.Drawing.Size(79, 17);
            this.ChkScrollLock.TabIndex = 64;
            this.ChkScrollLock.Text = "Scroll Lock";
            this.ChkScrollLock.UseVisualStyleBackColor = true;
            this.ChkScrollLock.CheckedChanged += new System.EventHandler(this.ChkScrollLock_CheckedChanged);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(11, 493);
            this.label23.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(99, 13);
            this.label23.TabIndex = 67;
            this.label23.Text = "Enable Time Stamp";
            // 
            // BtnSaveBL
            // 
            this.BtnSaveBL.Location = new System.Drawing.Point(400, 448);
            this.BtnSaveBL.Margin = new System.Windows.Forms.Padding(2);
            this.BtnSaveBL.Name = "BtnSaveBL";
            this.BtnSaveBL.Size = new System.Drawing.Size(92, 22);
            this.BtnSaveBL.TabIndex = 68;
            this.BtnSaveBL.Text = "Save Backlights";
            this.BtnSaveBL.UseVisualStyleBackColor = true;
            this.BtnSaveBL.Click += new System.EventHandler(this.BtnSaveBL_Click);
            // 
            // BtnBLToggle
            // 
            this.BtnBLToggle.Location = new System.Drawing.Point(154, 448);
            this.BtnBLToggle.Margin = new System.Windows.Forms.Padding(2);
            this.BtnBLToggle.Name = "BtnBLToggle";
            this.BtnBLToggle.Size = new System.Drawing.Size(54, 22);
            this.BtnBLToggle.TabIndex = 70;
            this.BtnBLToggle.Text = "Toggle";
            this.BtnBLToggle.UseVisualStyleBackColor = true;
            this.BtnBLToggle.Click += new System.EventHandler(this.BtnBLToggle_Click);
            // 
            // BtnTimeStampOn
            // 
            this.BtnTimeStampOn.Location = new System.Drawing.Point(116, 518);
            this.BtnTimeStampOn.Margin = new System.Windows.Forms.Padding(2);
            this.BtnTimeStampOn.Name = "BtnTimeStampOn";
            this.BtnTimeStampOn.Size = new System.Drawing.Size(92, 22);
            this.BtnTimeStampOn.TabIndex = 71;
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
            // ChkGreenOnOff
            // 
            this.ChkGreenOnOff.AutoSize = true;
            this.ChkGreenOnOff.Location = new System.Drawing.Point(177, 380);
            this.ChkGreenOnOff.Margin = new System.Windows.Forms.Padding(2);
            this.ChkGreenOnOff.Name = "ChkGreenOnOff";
            this.ChkGreenOnOff.Size = new System.Drawing.Size(110, 17);
            this.ChkGreenOnOff.TabIndex = 88;
            this.ChkGreenOnOff.Text = "All Bank 1 On/Off";
            this.ChkGreenOnOff.UseVisualStyleBackColor = true;
            this.ChkGreenOnOff.CheckedChanged += new System.EventHandler(this.ChkGreenOnOff_CheckedChanged);
            // 
            // BtnSetFlash
            // 
            this.BtnSetFlash.Location = new System.Drawing.Point(9, 448);
            this.BtnSetFlash.Margin = new System.Windows.Forms.Padding(2);
            this.BtnSetFlash.Name = "BtnSetFlash";
            this.BtnSetFlash.Size = new System.Drawing.Size(92, 22);
            this.BtnSetFlash.TabIndex = 91;
            this.BtnSetFlash.Text = "Set Flash Freq";
            this.BtnSetFlash.UseVisualStyleBackColor = true;
            this.BtnSetFlash.Click += new System.EventHandler(this.BtnSetFlash_Click);
            // 
            // TxtFlashFreq
            // 
            this.TxtFlashFreq.Location = new System.Drawing.Point(105, 447);
            this.TxtFlashFreq.Margin = new System.Windows.Forms.Padding(2);
            this.TxtFlashFreq.Name = "TxtFlashFreq";
            this.TxtFlashFreq.Size = new System.Drawing.Size(30, 20);
            this.TxtFlashFreq.TabIndex = 90;
            this.TxtFlashFreq.Text = "10";
            // 
            // ChkRedLED
            // 
            this.ChkRedLED.AutoSize = true;
            this.ChkRedLED.Location = new System.Drawing.Point(79, 259);
            this.ChkRedLED.Margin = new System.Windows.Forms.Padding(2);
            this.ChkRedLED.Name = "ChkRedLED";
            this.ChkRedLED.Size = new System.Drawing.Size(46, 17);
            this.ChkRedLED.TabIndex = 100;
            this.ChkRedLED.Text = "Red";
            this.ChkRedLED.ThreeState = true;
            this.ChkRedLED.UseVisualStyleBackColor = true;
            this.ChkRedLED.CheckStateChanged += new System.EventHandler(this.ChkRedLED_CheckStateChanged);
            // 
            // ChkGreenLED
            // 
            this.ChkGreenLED.AutoSize = true;
            this.ChkGreenLED.Location = new System.Drawing.Point(12, 259);
            this.ChkGreenLED.Margin = new System.Windows.Forms.Padding(2);
            this.ChkGreenLED.Name = "ChkGreenLED";
            this.ChkGreenLED.Size = new System.Drawing.Size(55, 17);
            this.ChkGreenLED.TabIndex = 99;
            this.ChkGreenLED.Text = "Green";
            this.ChkGreenLED.ThreeState = true;
            this.ChkGreenLED.UseVisualStyleBackColor = true;
            this.ChkGreenLED.CheckStateChanged += new System.EventHandler(this.ChkGreenLED_CheckStateChanged);
            // 
            // ChkBLOnOff
            // 
            this.ChkBLOnOff.AutoSize = true;
            this.ChkBLOnOff.Location = new System.Drawing.Point(84, 380);
            this.ChkBLOnOff.Margin = new System.Windows.Forms.Padding(2);
            this.ChkBLOnOff.Name = "ChkBLOnOff";
            this.ChkBLOnOff.Size = new System.Drawing.Size(89, 17);
            this.ChkBLOnOff.TabIndex = 117;
            this.ChkBLOnOff.Text = "On/Off/Flash";
            this.ChkBLOnOff.ThreeState = true;
            this.ChkBLOnOff.UseVisualStyleBackColor = true;
            this.ChkBLOnOff.CheckStateChanged += new System.EventHandler(this.ChkBLOnOff_CheckStateChanged);
            // 
            // CboBL
            // 
            this.CboBL.FormattingEnabled = true;
            this.CboBL.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "16",
            "17",
            "18",
            "19"});
            this.CboBL.Location = new System.Drawing.Point(10, 380);
            this.CboBL.Name = "CboBL";
            this.CboBL.Size = new System.Drawing.Size(68, 21);
            this.CboBL.TabIndex = 116;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 355);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(141, 13);
            this.label6.TabIndex = 115;
            this.label6.Text = "Indivdual Backlight Features";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(11, 423);
            this.label17.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(128, 13);
            this.label17.TabIndex = 119;
            this.label17.Text = "Global Backlight Features";
            // 
            // BtnGetDataNow
            // 
            this.BtnGetDataNow.Location = new System.Drawing.Point(523, 380);
            this.BtnGetDataNow.Margin = new System.Windows.Forms.Padding(2);
            this.BtnGetDataNow.Name = "BtnGetDataNow";
            this.BtnGetDataNow.Size = new System.Drawing.Size(98, 22);
            this.BtnGetDataNow.TabIndex = 121;
            this.BtnGetDataNow.Text = "Generate Data";
            this.BtnGetDataNow.UseVisualStyleBackColor = true;
            this.BtnGetDataNow.Click += new System.EventHandler(this.BtnGetDataNow_Click);
            // 
            // ChkSuppress
            // 
            this.ChkSuppress.AutoSize = true;
            this.ChkSuppress.Location = new System.Drawing.Point(146, 99);
            this.ChkSuppress.Name = "ChkSuppress";
            this.ChkSuppress.Size = new System.Drawing.Size(158, 17);
            this.ChkSuppress.TabIndex = 152;
            this.ChkSuppress.Text = "Suppress Duplicate Reports";
            this.ChkSuppress.UseVisualStyleBackColor = true;
            this.ChkSuppress.CheckedChanged += new System.EventHandler(this.ChkSuppress_CheckedChanged);
            // 
            // myBtn0
            // 
            this.myBtn0.AutoSize = true;
            this.myBtn0.Location = new System.Drawing.Point(158, 216);
            this.myBtn0.Name = "myBtn0";
            this.myBtn0.Size = new System.Drawing.Size(13, 13);
            this.myBtn0.TabIndex = 153;
            this.myBtn0.Tag = "0";
            this.myBtn0.Text = "0";
            // 
            // myBtn1
            // 
            this.myBtn1.AutoSize = true;
            this.myBtn1.Location = new System.Drawing.Point(301, 216);
            this.myBtn1.Name = "myBtn1";
            this.myBtn1.Size = new System.Drawing.Size(13, 13);
            this.myBtn1.TabIndex = 154;
            this.myBtn1.Tag = "1";
            this.myBtn1.Text = "4";
            // 
            // myBtn2
            // 
            this.myBtn2.AutoSize = true;
            this.myBtn2.Location = new System.Drawing.Point(158, 234);
            this.myBtn2.Name = "myBtn2";
            this.myBtn2.Size = new System.Drawing.Size(13, 13);
            this.myBtn2.TabIndex = 155;
            this.myBtn2.Tag = "2";
            this.myBtn2.Text = "8";
            // 
            // myBtn3
            // 
            this.myBtn3.AutoSize = true;
            this.myBtn3.Location = new System.Drawing.Point(301, 234);
            this.myBtn3.Name = "myBtn3";
            this.myBtn3.Size = new System.Drawing.Size(19, 13);
            this.myBtn3.TabIndex = 156;
            this.myBtn3.Tag = "3";
            this.myBtn3.Text = "12";
            // 
            // myBtn11
            // 
            this.myBtn11.AutoSize = true;
            this.myBtn11.Location = new System.Drawing.Point(340, 234);
            this.myBtn11.Name = "myBtn11";
            this.myBtn11.Size = new System.Drawing.Size(19, 13);
            this.myBtn11.TabIndex = 162;
            this.myBtn11.Tag = "11";
            this.myBtn11.Text = "13";
            // 
            // myBtn10
            // 
            this.myBtn10.AutoSize = true;
            this.myBtn10.Location = new System.Drawing.Point(185, 234);
            this.myBtn10.Name = "myBtn10";
            this.myBtn10.Size = new System.Drawing.Size(13, 13);
            this.myBtn10.TabIndex = 161;
            this.myBtn10.Tag = "10";
            this.myBtn10.Text = "9";
            // 
            // myBtn9
            // 
            this.myBtn9.AutoSize = true;
            this.myBtn9.Location = new System.Drawing.Point(340, 216);
            this.myBtn9.Name = "myBtn9";
            this.myBtn9.Size = new System.Drawing.Size(13, 13);
            this.myBtn9.TabIndex = 160;
            this.myBtn9.Tag = "9";
            this.myBtn9.Text = "5";
            // 
            // myBtn8
            // 
            this.myBtn8.AutoSize = true;
            this.myBtn8.Location = new System.Drawing.Point(185, 216);
            this.myBtn8.Name = "myBtn8";
            this.myBtn8.Size = new System.Drawing.Size(13, 13);
            this.myBtn8.TabIndex = 159;
            this.myBtn8.Tag = "8";
            this.myBtn8.Text = "1";
            // 
            // myBtn19
            // 
            this.myBtn19.AutoSize = true;
            this.myBtn19.Location = new System.Drawing.Point(378, 234);
            this.myBtn19.Name = "myBtn19";
            this.myBtn19.Size = new System.Drawing.Size(19, 13);
            this.myBtn19.TabIndex = 168;
            this.myBtn19.Tag = "19";
            this.myBtn19.Text = "14";
            // 
            // myBtn18
            // 
            this.myBtn18.AutoSize = true;
            this.myBtn18.Location = new System.Drawing.Point(221, 234);
            this.myBtn18.Name = "myBtn18";
            this.myBtn18.Size = new System.Drawing.Size(19, 13);
            this.myBtn18.TabIndex = 167;
            this.myBtn18.Tag = "18";
            this.myBtn18.Text = "10";
            // 
            // myBtn17
            // 
            this.myBtn17.AutoSize = true;
            this.myBtn17.Location = new System.Drawing.Point(378, 216);
            this.myBtn17.Name = "myBtn17";
            this.myBtn17.Size = new System.Drawing.Size(13, 13);
            this.myBtn17.TabIndex = 166;
            this.myBtn17.Tag = "17";
            this.myBtn17.Text = "6";
            // 
            // myBtn16
            // 
            this.myBtn16.AutoSize = true;
            this.myBtn16.Location = new System.Drawing.Point(221, 216);
            this.myBtn16.Name = "myBtn16";
            this.myBtn16.Size = new System.Drawing.Size(13, 13);
            this.myBtn16.TabIndex = 165;
            this.myBtn16.Tag = "16";
            this.myBtn16.Text = "2";
            // 
            // myBtn27
            // 
            this.myBtn27.AutoSize = true;
            this.myBtn27.Location = new System.Drawing.Point(424, 234);
            this.myBtn27.Name = "myBtn27";
            this.myBtn27.Size = new System.Drawing.Size(19, 13);
            this.myBtn27.TabIndex = 174;
            this.myBtn27.Tag = "27";
            this.myBtn27.Text = "15";
            // 
            // myBtn26
            // 
            this.myBtn26.AutoSize = true;
            this.myBtn26.Location = new System.Drawing.Point(259, 234);
            this.myBtn26.Name = "myBtn26";
            this.myBtn26.Size = new System.Drawing.Size(19, 13);
            this.myBtn26.TabIndex = 173;
            this.myBtn26.Tag = "26";
            this.myBtn26.Text = "11";
            // 
            // myBtn25
            // 
            this.myBtn25.AutoSize = true;
            this.myBtn25.Location = new System.Drawing.Point(424, 216);
            this.myBtn25.Name = "myBtn25";
            this.myBtn25.Size = new System.Drawing.Size(13, 13);
            this.myBtn25.TabIndex = 172;
            this.myBtn25.Tag = "25";
            this.myBtn25.Text = "7";
            // 
            // myBtn24
            // 
            this.myBtn24.AutoSize = true;
            this.myBtn24.Location = new System.Drawing.Point(259, 216);
            this.myBtn24.Name = "myBtn24";
            this.myBtn24.Size = new System.Drawing.Size(13, 13);
            this.myBtn24.TabIndex = 171;
            this.myBtn24.Tag = "24";
            this.myBtn24.Text = "3";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(539, 504);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(325, 54);
            this.label4.TabIndex = 203;
            this.label4.Text = resources.GetString("label4.Text");
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(513, 423);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(282, 13);
            this.label5.TabIndex = 202;
            this.label5.Text = "To Convert between PIDs (KVM mode v. developer mode)";
            // 
            // label24
            // 
            this.label24.Location = new System.Drawing.Point(537, 450);
            this.label24.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(315, 54);
            this.label24.TabIndex = 201;
            this.label24.Text = "To convert device to PID #2 or KVM mode, slide program switch on left side of dev" +
                "ice down or away from the usb cord then replug the device.";
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(732, 125);
            this.label37.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(61, 13);
            this.label37.TabIndex = 249;
            this.label37.Text = "1=finest inc";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(660, 138);
            this.label29.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(23, 13);
            this.label29.TabIndex = 248;
            this.label29.Text = "dY:";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(660, 114);
            this.label31.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(23, 13);
            this.label31.TabIndex = 247;
            this.label31.Text = "dX:";
            // 
            // TxtMouseY
            // 
            this.TxtMouseY.Location = new System.Drawing.Point(687, 135);
            this.TxtMouseY.Margin = new System.Windows.Forms.Padding(2);
            this.TxtMouseY.Name = "TxtMouseY";
            this.TxtMouseY.Size = new System.Drawing.Size(41, 20);
            this.TxtMouseY.TabIndex = 246;
            this.TxtMouseY.Text = "5";
            // 
            // TxtMouseX
            // 
            this.TxtMouseX.Location = new System.Drawing.Point(687, 111);
            this.TxtMouseX.Margin = new System.Windows.Forms.Padding(2);
            this.TxtMouseX.Name = "TxtMouseX";
            this.TxtMouseX.Size = new System.Drawing.Size(41, 20);
            this.TxtMouseX.TabIndex = 245;
            this.TxtMouseX.Text = "5";
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(732, 90);
            this.label36.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(249, 13);
            this.label36.TabIndex = 244;
            this.label36.Text = "1=left, 2=right, 4=center, 8=XButton1, 16=XButton2";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(508, 69);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(85, 13);
            this.label8.TabIndex = 243;
            this.label8.Text = "Mouse Reflector";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(632, 162);
            this.label30.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(51, 13);
            this.label30.TabIndex = 242;
            this.label30.Text = "Wheel Y:";
            // 
            // TxtMouseWheel
            // 
            this.TxtMouseWheel.Location = new System.Drawing.Point(687, 159);
            this.TxtMouseWheel.Margin = new System.Windows.Forms.Padding(2);
            this.TxtMouseWheel.Name = "TxtMouseWheel";
            this.TxtMouseWheel.Size = new System.Drawing.Size(41, 20);
            this.TxtMouseWheel.TabIndex = 241;
            this.TxtMouseWheel.Text = "0";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(644, 90);
            this.label32.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(41, 13);
            this.label32.TabIndex = 240;
            this.label32.Text = "Button:";
            // 
            // TxtMouseButton
            // 
            this.TxtMouseButton.Location = new System.Drawing.Point(686, 87);
            this.TxtMouseButton.Margin = new System.Windows.Forms.Padding(2);
            this.TxtMouseButton.Name = "TxtMouseButton";
            this.TxtMouseButton.Size = new System.Drawing.Size(41, 20);
            this.TxtMouseButton.TabIndex = 239;
            this.TxtMouseButton.Text = "0";
            // 
            // BtnMousereflect
            // 
            this.BtnMousereflect.Location = new System.Drawing.Point(523, 92);
            this.BtnMousereflect.Margin = new System.Windows.Forms.Padding(2);
            this.BtnMousereflect.Name = "BtnMousereflect";
            this.BtnMousereflect.Size = new System.Drawing.Size(122, 22);
            this.BtnMousereflect.TabIndex = 238;
            this.BtnMousereflect.Text = "Mouse Reflector";
            this.BtnMousereflect.UseVisualStyleBackColor = true;
            this.BtnMousereflect.Click += new System.EventHandler(this.BtnMousereflect_Click_1);
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Location = new System.Drawing.Point(513, 573);
            this.label43.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(195, 13);
            this.label43.TabIndex = 287;
            this.label43.Text = "Write Version (0-65535), reboot required";
            // 
            // LblVersion
            // 
            this.LblVersion.AutoSize = true;
            this.LblVersion.Location = new System.Drawing.Point(680, 602);
            this.LblVersion.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LblVersion.Name = "LblVersion";
            this.LblVersion.Size = new System.Drawing.Size(41, 13);
            this.LblVersion.TabIndex = 286;
            this.LblVersion.Text = "version";
            // 
            // TxtVersion
            // 
            this.TxtVersion.Location = new System.Drawing.Point(626, 597);
            this.TxtVersion.Margin = new System.Windows.Forms.Padding(2);
            this.TxtVersion.Name = "TxtVersion";
            this.TxtVersion.Size = new System.Drawing.Size(49, 20);
            this.TxtVersion.TabIndex = 285;
            this.TxtVersion.Text = "100";
            // 
            // BtnVersion
            // 
            this.BtnVersion.Location = new System.Drawing.Point(523, 595);
            this.BtnVersion.Margin = new System.Windows.Forms.Padding(2);
            this.BtnVersion.Name = "BtnVersion";
            this.BtnVersion.Size = new System.Drawing.Size(92, 22);
            this.BtnVersion.TabIndex = 284;
            this.BtnVersion.Text = "Write Version";
            this.BtnVersion.UseVisualStyleBackColor = true;
            this.BtnVersion.Click += new System.EventHandler(this.BtnVersion_Click);
            // 
            // BtnCustom
            // 
            this.BtnCustom.Location = new System.Drawing.Point(632, 380);
            this.BtnCustom.Margin = new System.Windows.Forms.Padding(2);
            this.BtnCustom.Name = "BtnCustom";
            this.BtnCustom.Size = new System.Drawing.Size(92, 22);
            this.BtnCustom.TabIndex = 288;
            this.BtnCustom.Text = "Custom Data";
            this.BtnCustom.UseVisualStyleBackColor = true;
            this.BtnCustom.Click += new System.EventHandler(this.BtnCustom_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(513, 355);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(311, 13);
            this.label14.TabIndex = 289;
            this.label14.Text = "Stimulate a general incoming data report or a custom data report.";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(987, 641);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.BtnCustom);
            this.Controls.Add(this.label43);
            this.Controls.Add(this.LblVersion);
            this.Controls.Add(this.TxtVersion);
            this.Controls.Add(this.BtnVersion);
            this.Controls.Add(this.label37);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.label31);
            this.Controls.Add(this.TxtMouseY);
            this.Controls.Add(this.TxtMouseX);
            this.Controls.Add(this.label36);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label30);
            this.Controls.Add(this.TxtMouseWheel);
            this.Controls.Add(this.label32);
            this.Controls.Add(this.TxtMouseButton);
            this.Controls.Add(this.BtnMousereflect);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.myBtn27);
            this.Controls.Add(this.myBtn26);
            this.Controls.Add(this.myBtn25);
            this.Controls.Add(this.myBtn24);
            this.Controls.Add(this.myBtn19);
            this.Controls.Add(this.myBtn18);
            this.Controls.Add(this.myBtn17);
            this.Controls.Add(this.myBtn16);
            this.Controls.Add(this.myBtn11);
            this.Controls.Add(this.myBtn10);
            this.Controls.Add(this.myBtn9);
            this.Controls.Add(this.myBtn8);
            this.Controls.Add(this.myBtn3);
            this.Controls.Add(this.myBtn2);
            this.Controls.Add(this.myBtn1);
            this.Controls.Add(this.myBtn0);
            this.Controls.Add(this.ChkSuppress);
            this.Controls.Add(this.BtnGetDataNow);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.ChkBLOnOff);
            this.Controls.Add(this.CboBL);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.ChkRedLED);
            this.Controls.Add(this.ChkGreenLED);
            this.Controls.Add(this.BtnSetFlash);
            this.Controls.Add(this.TxtFlashFreq);
            this.Controls.Add(this.ChkGreenOnOff);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.BtnTimeStampOn);
            this.Controls.Add(this.BtnBLToggle);
            this.Controls.Add(this.BtnSaveBL);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.ChkScrollLock);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.BtnDescriptor);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.BtnTimeStamp);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.BtnKBreflect);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.BtnBL);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LblUnitID);
            this.Controls.Add(this.BtnCallback);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.TxtSetUnitID);
            this.Controls.Add(this.BtnUnitID);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.LblSwitchPos);
            this.Controls.Add(this.CboDevices);
            this.Controls.Add(this.BtnEnumerate);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "XK-16 Stick KVM C# Sample";
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
        private System.Windows.Forms.Label LblSwitchPos;
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
        private System.Windows.Forms.Button BtnBL;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button BtnKBreflect;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button BtnTimeStamp;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Button BtnDescriptor;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.CheckBox ChkScrollLock;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Button BtnSaveBL;
        private System.Windows.Forms.Button BtnBLToggle;
        private System.Windows.Forms.Button BtnTimeStampOn;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.CheckBox ChkGreenOnOff;
        private System.Windows.Forms.Button BtnSetFlash;
        private System.Windows.Forms.TextBox TxtFlashFreq;
        private System.Windows.Forms.CheckBox ChkRedLED;
        private System.Windows.Forms.CheckBox ChkGreenLED;
        private System.Windows.Forms.CheckBox ChkBLOnOff;
        private System.Windows.Forms.ComboBox CboBL;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button BtnGetDataNow;
        private System.Windows.Forms.CheckBox ChkSuppress;
        private System.Windows.Forms.Label myBtn0;
        private System.Windows.Forms.Label myBtn1;
        private System.Windows.Forms.Label myBtn2;
        private System.Windows.Forms.Label myBtn3;
        private System.Windows.Forms.Label myBtn11;
        private System.Windows.Forms.Label myBtn10;
        private System.Windows.Forms.Label myBtn9;
        private System.Windows.Forms.Label myBtn8;
        private System.Windows.Forms.Label myBtn19;
        private System.Windows.Forms.Label myBtn18;
        private System.Windows.Forms.Label myBtn17;
        private System.Windows.Forms.Label myBtn16;
        private System.Windows.Forms.Label myBtn27;
        private System.Windows.Forms.Label myBtn26;
        private System.Windows.Forms.Label myBtn25;
        private System.Windows.Forms.Label myBtn24;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.TextBox TxtMouseY;
        private System.Windows.Forms.TextBox TxtMouseX;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.TextBox TxtMouseWheel;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.TextBox TxtMouseButton;
        private System.Windows.Forms.Button BtnMousereflect;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.Label LblVersion;
        private System.Windows.Forms.TextBox TxtVersion;
        private System.Windows.Forms.Button BtnVersion;
        private System.Windows.Forms.Button BtnCustom;
        private System.Windows.Forms.Label label14;
    }
}

