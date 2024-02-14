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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.BtnUnitID = new System.Windows.Forms.Button();
            this.TxtSetUnitID = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.BtnCallback = new System.Windows.Forms.Button();
            this.LblUnitID = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
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
            this.BtnGetDataNow = new System.Windows.Forms.Button();
            this.label30 = new System.Windows.Forms.Label();
            this.TxtMouseWheel = new System.Windows.Forms.TextBox();
            this.label32 = new System.Windows.Forms.Label();
            this.TxtMouseButton = new System.Windows.Forms.TextBox();
            this.BtnMousereflect = new System.Windows.Forms.Button();
            this.LblNumLk = new System.Windows.Forms.Label();
            this.LblCapsLk = new System.Windows.Forms.Label();
            this.LblScrLk = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ChkGreen = new System.Windows.Forms.CheckBox();
            this.ChkRed = new System.Windows.Forms.CheckBox();
            this.BtnPID2 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.TxtMouseY = new System.Windows.Forms.TextBox();
            this.TxtMouseX = new System.Windows.Forms.TextBox();
            this.label37 = new System.Windows.Forms.Label();
            this.BtnCustom = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.LblVersion = new System.Windows.Forms.Label();
            this.TxtVersion = new System.Windows.Forms.TextBox();
            this.BtnVersion = new System.Windows.Forms.Button();
            this.ChkBLOnOff = new System.Windows.Forms.CheckBox();
            this.CboBL = new System.Windows.Forms.ComboBox();
            this.label42 = new System.Windows.Forms.Label();
            this.ChkRedOnOff = new System.Windows.Forms.CheckBox();
            this.ChkBlueOnOff = new System.Windows.Forms.CheckBox();
            this.label43 = new System.Windows.Forms.Label();
            this.BtnSetFlash = new System.Windows.Forms.Button();
            this.TxtFlashFreq = new System.Windows.Forms.TextBox();
            this.BtnBLToggle = new System.Windows.Forms.Button();
            this.BtnSaveBL = new System.Windows.Forms.Button();
            this.BtnBL = new System.Windows.Forms.Button();
            this.BtnIncIntensity = new System.Windows.Forms.Button();
            this.ChkSuppress = new System.Windows.Forms.CheckBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.CboColor = new System.Windows.Forms.ComboBox();
            this.TxtIntensity2 = new System.Windows.Forms.TextBox();
            this.TxtIntensity = new System.Windows.Forms.TextBox();
            this.BtnIncIntensity2 = new System.Windows.Forms.Button();
            this.LblPassFail = new System.Windows.Forms.Label();
            this.BtnCheckDongleKey = new System.Windows.Forms.Button();
            this.BtnSetDongleKey = new System.Windows.Forms.Button();
            this.label34 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.BtnChange = new System.Windows.Forms.Button();
            this.BtnNoChange = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnEnumerate
            // 
            this.BtnEnumerate.Location = new System.Drawing.Point(24, 31);
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
            this.CboDevices.Location = new System.Drawing.Point(120, 31);
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
            this.listBox1.Location = new System.Drawing.Point(24, 118);
            this.listBox1.Margin = new System.Windows.Forms.Padding(2);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(480, 69);
            this.listBox1.TabIndex = 6;
            // 
            // BtnUnitID
            // 
            this.BtnUnitID.Location = new System.Drawing.Point(24, 223);
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
            this.TxtSetUnitID.Location = new System.Drawing.Point(130, 223);
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
            this.statusStrip1.Location = new System.Drawing.Point(0, 685);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 10, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1001, 22);
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
            this.BtnCallback.Location = new System.Drawing.Point(24, 92);
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
            this.LblUnitID.Location = new System.Drawing.Point(173, 227);
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
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(411, 92);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(93, 22);
            this.button1.TabIndex = 21;
            this.button1.Text = "Clear Listbox";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(510, 350);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 13);
            this.label5.TabIndex = 23;
            this.label5.Text = "Change PID";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(509, 16);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(98, 13);
            this.label7.TabIndex = 30;
            this.label7.Text = "Keyboard Reflector";
            // 
            // BtnKBreflect
            // 
            this.BtnKBreflect.Location = new System.Drawing.Point(524, 40);
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
            this.textBox1.Location = new System.Drawing.Point(650, 41);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(191, 20);
            this.textBox1.TabIndex = 32;
            // 
            // BtnTimeStamp
            // 
            this.BtnTimeStamp.Location = new System.Drawing.Point(21, 495);
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
            this.label19.Location = new System.Drawing.Point(237, 491);
            this.label19.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(69, 13);
            this.label19.TabIndex = 59;
            this.label19.Text = "absolute time";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(237, 504);
            this.label20.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(52, 13);
            this.label20.TabIndex = 60;
            this.label20.Text = "delta time";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(11, 305);
            this.label21.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(55, 13);
            this.label21.TabIndex = 61;
            this.label21.Text = "Descriptor";
            // 
            // BtnDescriptor
            // 
            this.BtnDescriptor.Location = new System.Drawing.Point(82, 300);
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
            this.listBox2.Location = new System.Drawing.Point(191, 300);
            this.listBox2.Margin = new System.Windows.Forms.Padding(2);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(232, 82);
            this.listBox2.TabIndex = 63;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(11, 469);
            this.label23.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(99, 13);
            this.label23.TabIndex = 67;
            this.label23.Text = "Enable Time Stamp";
            // 
            // BtnTimeStampOn
            // 
            this.BtnTimeStampOn.Location = new System.Drawing.Point(130, 495);
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
            this.label13.Location = new System.Drawing.Point(11, 199);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(68, 13);
            this.label13.TabIndex = 87;
            this.label13.Text = "Write Unit ID";
            // 
            // BtnGetDataNow
            // 
            this.BtnGetDataNow.Location = new System.Drawing.Point(21, 425);
            this.BtnGetDataNow.Margin = new System.Windows.Forms.Padding(2);
            this.BtnGetDataNow.Name = "BtnGetDataNow";
            this.BtnGetDataNow.Size = new System.Drawing.Size(92, 22);
            this.BtnGetDataNow.TabIndex = 121;
            this.BtnGetDataNow.Text = "Generate Data";
            this.BtnGetDataNow.UseVisualStyleBackColor = true;
            this.BtnGetDataNow.Click += new System.EventHandler(this.BtnGetDataNow_Click);
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(633, 208);
            this.label30.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(51, 13);
            this.label30.TabIndex = 149;
            this.label30.Text = "Wheel Y:";
            // 
            // TxtMouseWheel
            // 
            this.TxtMouseWheel.Location = new System.Drawing.Point(688, 205);
            this.TxtMouseWheel.Margin = new System.Windows.Forms.Padding(2);
            this.TxtMouseWheel.Name = "TxtMouseWheel";
            this.TxtMouseWheel.Size = new System.Drawing.Size(41, 20);
            this.TxtMouseWheel.TabIndex = 148;
            this.TxtMouseWheel.Text = "0";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(645, 136);
            this.label32.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(41, 13);
            this.label32.TabIndex = 146;
            this.label32.Text = "Button:";
            // 
            // TxtMouseButton
            // 
            this.TxtMouseButton.Location = new System.Drawing.Point(687, 133);
            this.TxtMouseButton.Margin = new System.Windows.Forms.Padding(2);
            this.TxtMouseButton.Name = "TxtMouseButton";
            this.TxtMouseButton.Size = new System.Drawing.Size(41, 20);
            this.TxtMouseButton.TabIndex = 143;
            this.TxtMouseButton.Text = "0";
            // 
            // BtnMousereflect
            // 
            this.BtnMousereflect.Location = new System.Drawing.Point(524, 138);
            this.BtnMousereflect.Margin = new System.Windows.Forms.Padding(2);
            this.BtnMousereflect.Name = "BtnMousereflect";
            this.BtnMousereflect.Size = new System.Drawing.Size(122, 22);
            this.BtnMousereflect.TabIndex = 140;
            this.BtnMousereflect.Text = "Mouse Reflector";
            this.BtnMousereflect.UseVisualStyleBackColor = true;
            this.BtnMousereflect.Click += new System.EventHandler(this.BtnMousereflect_Click);
            // 
            // LblNumLk
            // 
            this.LblNumLk.AutoSize = true;
            this.LblNumLk.Location = new System.Drawing.Point(382, 189);
            this.LblNumLk.Name = "LblNumLk";
            this.LblNumLk.Size = new System.Drawing.Size(59, 13);
            this.LblNumLk.TabIndex = 156;
            this.LblNumLk.Text = "NumLock: ";
            // 
            // LblCapsLk
            // 
            this.LblCapsLk.AutoSize = true;
            this.LblCapsLk.Location = new System.Drawing.Point(382, 204);
            this.LblCapsLk.Name = "LblCapsLk";
            this.LblCapsLk.Size = new System.Drawing.Size(61, 13);
            this.LblCapsLk.TabIndex = 157;
            this.LblCapsLk.Text = "CapsLock: ";
            // 
            // LblScrLk
            // 
            this.LblScrLk.AutoSize = true;
            this.LblScrLk.Location = new System.Drawing.Point(382, 218);
            this.LblScrLk.Name = "LblScrLk";
            this.LblScrLk.Size = new System.Drawing.Size(53, 13);
            this.LblScrLk.TabIndex = 158;
            this.LblScrLk.Text = "ScrLock: ";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(509, 110);
            this.label24.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(85, 13);
            this.label24.TabIndex = 205;
            this.label24.Text = "Mouse Reflector";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 270);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 206;
            this.label3.Text = "Write LEDs";
            // 
            // ChkGreen
            // 
            this.ChkGreen.AutoSize = true;
            this.ChkGreen.Location = new System.Drawing.Point(91, 269);
            this.ChkGreen.Name = "ChkGreen";
            this.ChkGreen.Size = new System.Drawing.Size(55, 17);
            this.ChkGreen.TabIndex = 207;
            this.ChkGreen.Tag = "6";
            this.ChkGreen.Text = "Green";
            this.ChkGreen.ThreeState = true;
            this.ChkGreen.UseVisualStyleBackColor = true;
            this.ChkGreen.CheckStateChanged += new System.EventHandler(this.ChkGreen_CheckStateChanged);
            // 
            // ChkRed
            // 
            this.ChkRed.AutoSize = true;
            this.ChkRed.Location = new System.Drawing.Point(152, 269);
            this.ChkRed.Name = "ChkRed";
            this.ChkRed.Size = new System.Drawing.Size(46, 17);
            this.ChkRed.TabIndex = 208;
            this.ChkRed.Tag = "7";
            this.ChkRed.Text = "Red";
            this.ChkRed.ThreeState = true;
            this.ChkRed.UseVisualStyleBackColor = true;
            this.ChkRed.CheckStateChanged += new System.EventHandler(this.ChkGreen_CheckStateChanged);
            // 
            // BtnPID2
            // 
            this.BtnPID2.Location = new System.Drawing.Point(524, 376);
            this.BtnPID2.Margin = new System.Windows.Forms.Padding(2);
            this.BtnPID2.Name = "BtnPID2";
            this.BtnPID2.Size = new System.Drawing.Size(91, 22);
            this.BtnPID2.TabIndex = 211;
            this.BtnPID2.Text = "To PID #2";
            this.BtnPID2.UseVisualStyleBackColor = true;
            this.BtnPID2.Click += new System.EventHandler(this.BtnPID2_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(851, 136);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 13);
            this.label4.TabIndex = 216;
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(733, 136);
            this.label36.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(249, 13);
            this.label36.TabIndex = 217;
            this.label36.Text = "1=left, 2=right, 4=center, 8=XButton1, 16=XButton2";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(661, 184);
            this.label29.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(23, 13);
            this.label29.TabIndex = 223;
            this.label29.Text = "dY:";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(661, 160);
            this.label31.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(23, 13);
            this.label31.TabIndex = 222;
            this.label31.Text = "dX:";
            // 
            // TxtMouseY
            // 
            this.TxtMouseY.Location = new System.Drawing.Point(688, 181);
            this.TxtMouseY.Margin = new System.Windows.Forms.Padding(2);
            this.TxtMouseY.Name = "TxtMouseY";
            this.TxtMouseY.Size = new System.Drawing.Size(41, 20);
            this.TxtMouseY.TabIndex = 221;
            this.TxtMouseY.Text = "5";
            // 
            // TxtMouseX
            // 
            this.TxtMouseX.Location = new System.Drawing.Point(688, 157);
            this.TxtMouseX.Margin = new System.Windows.Forms.Padding(2);
            this.TxtMouseX.Name = "TxtMouseX";
            this.TxtMouseX.Size = new System.Drawing.Size(41, 20);
            this.TxtMouseX.TabIndex = 220;
            this.TxtMouseX.Text = "5";
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(733, 171);
            this.label37.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(61, 13);
            this.label37.TabIndex = 224;
            this.label37.Text = "1=finest inc";
            // 
            // BtnCustom
            // 
            this.BtnCustom.Location = new System.Drawing.Point(130, 425);
            this.BtnCustom.Margin = new System.Windows.Forms.Padding(2);
            this.BtnCustom.Name = "BtnCustom";
            this.BtnCustom.Size = new System.Drawing.Size(92, 22);
            this.BtnCustom.TabIndex = 258;
            this.BtnCustom.Text = "Custom Data";
            this.BtnCustom.UseVisualStyleBackColor = true;
            this.BtnCustom.Click += new System.EventHandler(this.BtnCustom_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(11, 397);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(313, 13);
            this.label14.TabIndex = 259;
            this.label14.Text = "Stimulate a general incoming data report or a custom input report.";
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(510, 484);
            this.label41.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(294, 13);
            this.label41.TabIndex = 267;
            this.label41.Text = "Write Version (0-65535), reboot required, may take some time";
            // 
            // LblVersion
            // 
            this.LblVersion.AutoSize = true;
            this.LblVersion.Location = new System.Drawing.Point(680, 511);
            this.LblVersion.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LblVersion.Name = "LblVersion";
            this.LblVersion.Size = new System.Drawing.Size(41, 13);
            this.LblVersion.TabIndex = 266;
            this.LblVersion.Text = "version";
            // 
            // TxtVersion
            // 
            this.TxtVersion.Location = new System.Drawing.Point(626, 506);
            this.TxtVersion.Margin = new System.Windows.Forms.Padding(2);
            this.TxtVersion.Name = "TxtVersion";
            this.TxtVersion.Size = new System.Drawing.Size(49, 20);
            this.TxtVersion.TabIndex = 265;
            this.TxtVersion.Text = "100";
            // 
            // BtnVersion
            // 
            this.BtnVersion.Location = new System.Drawing.Point(524, 504);
            this.BtnVersion.Margin = new System.Windows.Forms.Padding(2);
            this.BtnVersion.Name = "BtnVersion";
            this.BtnVersion.Size = new System.Drawing.Size(92, 22);
            this.BtnVersion.TabIndex = 264;
            this.BtnVersion.Text = "Write Version";
            this.BtnVersion.UseVisualStyleBackColor = true;
            this.BtnVersion.Click += new System.EventHandler(this.BtnVersion_Click);
            // 
            // ChkBLOnOff
            // 
            this.ChkBLOnOff.AutoSize = true;
            this.ChkBLOnOff.Location = new System.Drawing.Point(163, 557);
            this.ChkBLOnOff.Margin = new System.Windows.Forms.Padding(2);
            this.ChkBLOnOff.Name = "ChkBLOnOff";
            this.ChkBLOnOff.Size = new System.Drawing.Size(89, 17);
            this.ChkBLOnOff.TabIndex = 272;
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
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "32",
            "33",
            "34",
            "35",
            "36",
            "37",
            "38",
            "39",
            "40",
            "41",
            "42",
            "43",
            "44",
            "45",
            "46",
            "47",
            "48",
            "49",
            "50",
            "51",
            "52",
            "53",
            "54",
            "55",
            "56",
            "57",
            "58",
            "59",
            "60",
            "61",
            "62",
            "63",
            "64",
            "65",
            "66",
            "67",
            "68",
            "69",
            "70",
            "71",
            "72",
            "73",
            "74",
            "75",
            "76",
            "77",
            "78",
            "79",
            "80",
            "81",
            "82",
            "83",
            "84",
            "85",
            "86",
            "87",
            "88",
            "89",
            "90",
            "91",
            "92",
            "93",
            "94",
            "95",
            "96",
            "97",
            "98",
            "99",
            "100",
            "101",
            "102",
            "103",
            "104",
            "105",
            "106",
            "107",
            "108",
            "109",
            "110",
            "111",
            "112",
            "113",
            "114",
            "115",
            "116",
            "117",
            "118",
            "119",
            "120",
            "121",
            "122",
            "123",
            "124",
            "125",
            "126",
            "127"});
            this.CboBL.Location = new System.Drawing.Point(14, 555);
            this.CboBL.Name = "CboBL";
            this.CboBL.Size = new System.Drawing.Size(68, 21);
            this.CboBL.TabIndex = 271;
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Location = new System.Drawing.Point(11, 533);
            this.label42.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(141, 13);
            this.label42.TabIndex = 270;
            this.label42.Text = "Indivdual Backlight Features";
            // 
            // ChkRedOnOff
            // 
            this.ChkRedOnOff.AutoSize = true;
            this.ChkRedOnOff.Location = new System.Drawing.Point(369, 557);
            this.ChkRedOnOff.Margin = new System.Windows.Forms.Padding(2);
            this.ChkRedOnOff.Name = "ChkRedOnOff";
            this.ChkRedOnOff.Size = new System.Drawing.Size(110, 17);
            this.ChkRedOnOff.TabIndex = 269;
            this.ChkRedOnOff.Text = "All Bank 2 On/Off";
            this.ChkRedOnOff.UseVisualStyleBackColor = true;
            this.ChkRedOnOff.CheckedChanged += new System.EventHandler(this.ChkRedOnOff_CheckedChanged);
            // 
            // ChkBlueOnOff
            // 
            this.ChkBlueOnOff.AutoSize = true;
            this.ChkBlueOnOff.Location = new System.Drawing.Point(255, 557);
            this.ChkBlueOnOff.Margin = new System.Windows.Forms.Padding(2);
            this.ChkBlueOnOff.Name = "ChkBlueOnOff";
            this.ChkBlueOnOff.Size = new System.Drawing.Size(110, 17);
            this.ChkBlueOnOff.TabIndex = 268;
            this.ChkBlueOnOff.Text = "All Bank 1 On/Off";
            this.ChkBlueOnOff.UseVisualStyleBackColor = true;
            this.ChkBlueOnOff.CheckedChanged += new System.EventHandler(this.ChkBlueOnOff_CheckedChanged);
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Location = new System.Drawing.Point(11, 595);
            this.label43.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(128, 13);
            this.label43.TabIndex = 280;
            this.label43.Text = "Global Backlight Features";
            // 
            // BtnSetFlash
            // 
            this.BtnSetFlash.Location = new System.Drawing.Point(21, 620);
            this.BtnSetFlash.Margin = new System.Windows.Forms.Padding(2);
            this.BtnSetFlash.Name = "BtnSetFlash";
            this.BtnSetFlash.Size = new System.Drawing.Size(92, 22);
            this.BtnSetFlash.TabIndex = 279;
            this.BtnSetFlash.Text = "Set Flash Freq";
            this.BtnSetFlash.UseVisualStyleBackColor = true;
            this.BtnSetFlash.Click += new System.EventHandler(this.BtnSetFlash_Click);
            // 
            // TxtFlashFreq
            // 
            this.TxtFlashFreq.Location = new System.Drawing.Point(117, 622);
            this.TxtFlashFreq.Margin = new System.Windows.Forms.Padding(2);
            this.TxtFlashFreq.Name = "TxtFlashFreq";
            this.TxtFlashFreq.Size = new System.Drawing.Size(30, 20);
            this.TxtFlashFreq.TabIndex = 278;
            this.TxtFlashFreq.Text = "10";
            // 
            // BtnBLToggle
            // 
            this.BtnBLToggle.Location = new System.Drawing.Point(369, 620);
            this.BtnBLToggle.Margin = new System.Windows.Forms.Padding(2);
            this.BtnBLToggle.Name = "BtnBLToggle";
            this.BtnBLToggle.Size = new System.Drawing.Size(92, 22);
            this.BtnBLToggle.TabIndex = 277;
            this.BtnBLToggle.Text = "Toggle";
            this.BtnBLToggle.UseVisualStyleBackColor = true;
            this.BtnBLToggle.Click += new System.EventHandler(this.BtnBLToggle_Click);
            // 
            // BtnSaveBL
            // 
            this.BtnSaveBL.Location = new System.Drawing.Point(369, 646);
            this.BtnSaveBL.Margin = new System.Windows.Forms.Padding(2);
            this.BtnSaveBL.Name = "BtnSaveBL";
            this.BtnSaveBL.Size = new System.Drawing.Size(92, 22);
            this.BtnSaveBL.TabIndex = 276;
            this.BtnSaveBL.Text = "Save Backlights";
            this.BtnSaveBL.UseVisualStyleBackColor = true;
            this.BtnSaveBL.Click += new System.EventHandler(this.BtnSaveBL_Click);
            // 
            // BtnBL
            // 
            this.BtnBL.Location = new System.Drawing.Point(21, 646);
            this.BtnBL.Margin = new System.Windows.Forms.Padding(2);
            this.BtnBL.Name = "BtnBL";
            this.BtnBL.Size = new System.Drawing.Size(92, 22);
            this.BtnBL.TabIndex = 274;
            this.BtnBL.Text = "Set Intensity";
            this.BtnBL.UseVisualStyleBackColor = true;
            this.BtnBL.Click += new System.EventHandler(this.BtnBL_Click);
            // 
            // BtnIncIntensity
            // 
            this.BtnIncIntensity.Location = new System.Drawing.Point(213, 620);
            this.BtnIncIntensity.Margin = new System.Windows.Forms.Padding(2);
            this.BtnIncIntensity.Name = "BtnIncIntensity";
            this.BtnIncIntensity.Size = new System.Drawing.Size(152, 22);
            this.BtnIncIntensity.TabIndex = 282;
            this.BtnIncIntensity.Text = "Incremental Intensity Bank1";
            this.BtnIncIntensity.UseVisualStyleBackColor = true;
            this.BtnIncIntensity.Click += new System.EventHandler(this.BtnIncIntesity_Click);
            // 
            // ChkSuppress
            // 
            this.ChkSuppress.AutoSize = true;
            this.ChkSuppress.Location = new System.Drawing.Point(159, 94);
            this.ChkSuppress.Name = "ChkSuppress";
            this.ChkSuppress.Size = new System.Drawing.Size(158, 17);
            this.ChkSuppress.TabIndex = 283;
            this.ChkSuppress.Text = "Suppress Duplicate Reports";
            this.ChkSuppress.UseVisualStyleBackColor = true;
            this.ChkSuppress.CheckedChanged += new System.EventHandler(this.ChkSuppress_CheckedChanged);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // CboColor
            // 
            this.CboColor.FormattingEnabled = true;
            this.CboColor.Items.AddRange(new object[] {
            "Bank 1",
            "Bank 2"});
            this.CboColor.Location = new System.Drawing.Point(95, 555);
            this.CboColor.Name = "CboColor";
            this.CboColor.Size = new System.Drawing.Size(57, 21);
            this.CboColor.TabIndex = 284;
            // 
            // TxtIntensity2
            // 
            this.TxtIntensity2.Location = new System.Drawing.Point(151, 648);
            this.TxtIntensity2.Margin = new System.Windows.Forms.Padding(2);
            this.TxtIntensity2.Name = "TxtIntensity2";
            this.TxtIntensity2.Size = new System.Drawing.Size(30, 20);
            this.TxtIntensity2.TabIndex = 293;
            this.TxtIntensity2.Text = "255";
            // 
            // TxtIntensity
            // 
            this.TxtIntensity.Location = new System.Drawing.Point(117, 648);
            this.TxtIntensity.Margin = new System.Windows.Forms.Padding(2);
            this.TxtIntensity.Name = "TxtIntensity";
            this.TxtIntensity.Size = new System.Drawing.Size(30, 20);
            this.TxtIntensity.TabIndex = 292;
            this.TxtIntensity.Text = "255";
            // 
            // BtnIncIntensity2
            // 
            this.BtnIncIntensity2.Location = new System.Drawing.Point(213, 646);
            this.BtnIncIntensity2.Margin = new System.Windows.Forms.Padding(2);
            this.BtnIncIntensity2.Name = "BtnIncIntensity2";
            this.BtnIncIntensity2.Size = new System.Drawing.Size(152, 22);
            this.BtnIncIntensity2.TabIndex = 294;
            this.BtnIncIntensity2.Text = "Incremental Intensity Bank2";
            this.BtnIncIntensity2.UseVisualStyleBackColor = true;
            this.BtnIncIntensity2.Click += new System.EventHandler(this.BtnIncIntensity2_Click);
            // 
            // LblPassFail
            // 
            this.LblPassFail.AutoSize = true;
            this.LblPassFail.Location = new System.Drawing.Point(749, 580);
            this.LblPassFail.Name = "LblPassFail";
            this.LblPassFail.Size = new System.Drawing.Size(51, 13);
            this.LblPassFail.TabIndex = 298;
            this.LblPassFail.Text = "Pass/Fail";
            // 
            // BtnCheckDongleKey
            // 
            this.BtnCheckDongleKey.Location = new System.Drawing.Point(626, 575);
            this.BtnCheckDongleKey.Margin = new System.Windows.Forms.Padding(2);
            this.BtnCheckDongleKey.Name = "BtnCheckDongleKey";
            this.BtnCheckDongleKey.Size = new System.Drawing.Size(112, 22);
            this.BtnCheckDongleKey.TabIndex = 297;
            this.BtnCheckDongleKey.Text = "Check Dongle Key";
            this.BtnCheckDongleKey.UseVisualStyleBackColor = true;
            this.BtnCheckDongleKey.Click += new System.EventHandler(this.BtnCheckDongleKey_Click);
            // 
            // BtnSetDongleKey
            // 
            this.BtnSetDongleKey.Location = new System.Drawing.Point(524, 575);
            this.BtnSetDongleKey.Margin = new System.Windows.Forms.Padding(2);
            this.BtnSetDongleKey.Name = "BtnSetDongleKey";
            this.BtnSetDongleKey.Size = new System.Drawing.Size(92, 22);
            this.BtnSetDongleKey.TabIndex = 296;
            this.BtnSetDongleKey.Text = "Set Dongle Key";
            this.BtnSetDongleKey.UseVisualStyleBackColor = true;
            this.BtnSetDongleKey.Click += new System.EventHandler(this.BtnSetDongleKey_Click);
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(510, 554);
            this.label34.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(41, 13);
            this.label34.TabIndex = 295;
            this.label34.Text = "Dongle";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(623, 381);
            this.label25.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(214, 13);
            this.label25.TabIndex = 300;
            this.label25.Text = "Endpoints: Keyboard only for use with KVM*";
            // 
            // BtnChange
            // 
            this.BtnChange.Location = new System.Drawing.Point(752, 277);
            this.BtnChange.Name = "BtnChange";
            this.BtnChange.Size = new System.Drawing.Size(220, 23);
            this.BtnChange.TabIndex = 303;
            this.BtnChange.Text = "Always change to PID #2 (KVM) on reboot";
            this.BtnChange.UseVisualStyleBackColor = true;
            this.BtnChange.Click += new System.EventHandler(this.BtnChange_Click);
            // 
            // BtnNoChange
            // 
            this.BtnNoChange.Location = new System.Drawing.Point(524, 277);
            this.BtnNoChange.Name = "BtnNoChange";
            this.BtnNoChange.Size = new System.Drawing.Size(220, 23);
            this.BtnNoChange.TabIndex = 302;
            this.BtnNoChange.Text = "Do not change PID #2 (KVM) on reboot";
            this.BtnNoChange.UseVisualStyleBackColor = true;
            this.BtnNoChange.Click += new System.EventHandler(this.BtnNoChange_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(510, 254);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 13);
            this.label6.TabIndex = 301;
            this.label6.Text = "Reboot Mode";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(524, 404);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(445, 67);
            this.label8.TabIndex = 304;
            this.label8.Text = resources.GetString("label8.Text");
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1001, 707);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.BtnChange);
            this.Controls.Add(this.BtnNoChange);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.LblPassFail);
            this.Controls.Add(this.BtnCheckDongleKey);
            this.Controls.Add(this.BtnSetDongleKey);
            this.Controls.Add(this.label34);
            this.Controls.Add(this.BtnIncIntensity2);
            this.Controls.Add(this.TxtIntensity2);
            this.Controls.Add(this.TxtIntensity);
            this.Controls.Add(this.CboColor);
            this.Controls.Add(this.ChkSuppress);
            this.Controls.Add(this.BtnIncIntensity);
            this.Controls.Add(this.label43);
            this.Controls.Add(this.BtnSetFlash);
            this.Controls.Add(this.TxtFlashFreq);
            this.Controls.Add(this.BtnBLToggle);
            this.Controls.Add(this.BtnSaveBL);
            this.Controls.Add(this.BtnBL);
            this.Controls.Add(this.ChkBLOnOff);
            this.Controls.Add(this.CboBL);
            this.Controls.Add(this.label42);
            this.Controls.Add(this.ChkRedOnOff);
            this.Controls.Add(this.ChkBlueOnOff);
            this.Controls.Add(this.label41);
            this.Controls.Add(this.LblVersion);
            this.Controls.Add(this.TxtVersion);
            this.Controls.Add(this.BtnVersion);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.BtnCustom);
            this.Controls.Add(this.label37);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.label31);
            this.Controls.Add(this.TxtMouseY);
            this.Controls.Add(this.TxtMouseX);
            this.Controls.Add(this.label36);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.BtnPID2);
            this.Controls.Add(this.ChkRed);
            this.Controls.Add(this.ChkGreen);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.LblScrLk);
            this.Controls.Add(this.LblCapsLk);
            this.Controls.Add(this.LblNumLk);
            this.Controls.Add(this.label30);
            this.Controls.Add(this.TxtMouseWheel);
            this.Controls.Add(this.label32);
            this.Controls.Add(this.TxtMouseButton);
            this.Controls.Add(this.BtnMousereflect);
            this.Controls.Add(this.BtnGetDataNow);
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
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LblUnitID);
            this.Controls.Add(this.BtnCallback);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.TxtSetUnitID);
            this.Controls.Add(this.BtnUnitID);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.CboDevices);
            this.Controls.Add(this.BtnEnumerate);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "C# X-keys XK-128 KVM";
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
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label5;
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
        private System.Windows.Forms.Button BtnGetDataNow;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.TextBox TxtMouseWheel;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.TextBox TxtMouseButton;
        private System.Windows.Forms.Button BtnMousereflect;
        private System.Windows.Forms.Label LblNumLk;
        private System.Windows.Forms.Label LblCapsLk;
        private System.Windows.Forms.Label LblScrLk;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox ChkGreen;
        private System.Windows.Forms.CheckBox ChkRed;
        private System.Windows.Forms.Button BtnPID2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.TextBox TxtMouseY;
        private System.Windows.Forms.TextBox TxtMouseX;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.Button BtnCustom;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.Label LblVersion;
        private System.Windows.Forms.TextBox TxtVersion;
        private System.Windows.Forms.Button BtnVersion;
        private System.Windows.Forms.CheckBox ChkBLOnOff;
        private System.Windows.Forms.ComboBox CboBL;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.CheckBox ChkRedOnOff;
        private System.Windows.Forms.CheckBox ChkBlueOnOff;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.Button BtnSetFlash;
        private System.Windows.Forms.TextBox TxtFlashFreq;
        private System.Windows.Forms.Button BtnBLToggle;
        private System.Windows.Forms.Button BtnSaveBL;
        private System.Windows.Forms.Button BtnBL;
        private System.Windows.Forms.Button BtnIncIntensity;
        private System.Windows.Forms.CheckBox ChkSuppress;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ComboBox CboColor;
        private System.Windows.Forms.TextBox TxtIntensity2;
        private System.Windows.Forms.TextBox TxtIntensity;
        private System.Windows.Forms.Button BtnIncIntensity2;
        private System.Windows.Forms.Label LblPassFail;
        private System.Windows.Forms.Button BtnCheckDongleKey;
        private System.Windows.Forms.Button BtnSetDongleKey;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Button BtnChange;
        private System.Windows.Forms.Button BtnNoChange;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
    }
}

