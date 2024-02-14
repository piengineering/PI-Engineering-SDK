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
            this.BtnMousereflect = new System.Windows.Forms.Button();
            this.LblJack1R = new System.Windows.Forms.Label();
            this.LblJack1L = new System.Windows.Forms.Label();
            this.LblJack2L = new System.Windows.Forms.Label();
            this.LblJack2R = new System.Windows.Forms.Label();
            this.LblJack3L = new System.Windows.Forms.Label();
            this.LblJack3R = new System.Windows.Forms.Label();
            this.LblJack6L = new System.Windows.Forms.Label();
            this.LblJack6R = new System.Windows.Forms.Label();
            this.LblJack5L = new System.Windows.Forms.Label();
            this.LblJack5R = new System.Windows.Forms.Label();
            this.LblJack4L = new System.Windows.Forms.Label();
            this.LblJack4R = new System.Windows.Forms.Label();
            this.ChkSuppress = new System.Windows.Forms.CheckBox();
            this.LblPassFail = new System.Windows.Forms.Label();
            this.BtnCheckDongle = new System.Windows.Forms.Button();
            this.BtnSetDongle = new System.Windows.Forms.Button();
            this.label44 = new System.Windows.Forms.Label();
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
            this.statusStrip1.Location = new System.Drawing.Point(0, 585);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 10, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1020, 22);
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
            this.label5.Location = new System.Drawing.Point(510, 375);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 13);
            this.label5.TabIndex = 23;
            this.label5.Text = "Change PID";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(510, 9);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(98, 13);
            this.label7.TabIndex = 30;
            this.label7.Text = "Keyboard Reflector";
            // 
            // BtnKBreflect
            // 
            this.BtnKBreflect.Location = new System.Drawing.Point(525, 33);
            this.BtnKBreflect.Margin = new System.Windows.Forms.Padding(2);
            this.BtnKBreflect.Name = "BtnKBreflect";
            this.BtnKBreflect.Size = new System.Drawing.Size(98, 22);
            this.BtnKBreflect.TabIndex = 31;
            this.BtnKBreflect.Text = "Keyboard Reflector";
            this.BtnKBreflect.UseVisualStyleBackColor = true;
            this.BtnKBreflect.Click += new System.EventHandler(this.BtnKBreflect_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(651, 34);
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
            this.BtnDescriptor.Location = new System.Drawing.Point(84, 306);
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
            this.listBox2.Location = new System.Drawing.Point(193, 306);
            this.listBox2.Margin = new System.Windows.Forms.Padding(2);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(232, 82);
            this.listBox2.TabIndex = 63;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(8, 469);
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
            this.BtnGetDataNow.Location = new System.Drawing.Point(21, 429);
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
            this.label30.Location = new System.Drawing.Point(652, 173);
            this.label30.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(51, 13);
            this.label30.TabIndex = 149;
            this.label30.Text = "Wheel Y:";
            // 
            // TxtMouseWheel
            // 
            this.TxtMouseWheel.Location = new System.Drawing.Point(707, 170);
            this.TxtMouseWheel.Margin = new System.Windows.Forms.Padding(2);
            this.TxtMouseWheel.Name = "TxtMouseWheel";
            this.TxtMouseWheel.Size = new System.Drawing.Size(41, 20);
            this.TxtMouseWheel.TabIndex = 148;
            this.TxtMouseWheel.Text = "0";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(665, 97);
            this.label32.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(41, 13);
            this.label32.TabIndex = 146;
            this.label32.Text = "Button:";
            // 
            // TxtMouseButton
            // 
            this.TxtMouseButton.Location = new System.Drawing.Point(707, 94);
            this.TxtMouseButton.Margin = new System.Windows.Forms.Padding(2);
            this.TxtMouseButton.Name = "TxtMouseButton";
            this.TxtMouseButton.Size = new System.Drawing.Size(41, 20);
            this.TxtMouseButton.TabIndex = 143;
            this.TxtMouseButton.Text = "0";
            // 
            // LblNumLk
            // 
            this.LblNumLk.AutoSize = true;
            this.LblNumLk.Location = new System.Drawing.Point(396, 194);
            this.LblNumLk.Name = "LblNumLk";
            this.LblNumLk.Size = new System.Drawing.Size(59, 13);
            this.LblNumLk.TabIndex = 156;
            this.LblNumLk.Text = "NumLock: ";
            // 
            // LblCapsLk
            // 
            this.LblCapsLk.AutoSize = true;
            this.LblCapsLk.Location = new System.Drawing.Point(396, 209);
            this.LblCapsLk.Name = "LblCapsLk";
            this.LblCapsLk.Size = new System.Drawing.Size(61, 13);
            this.LblCapsLk.TabIndex = 157;
            this.LblCapsLk.Text = "CapsLock: ";
            // 
            // LblScrLk
            // 
            this.LblScrLk.AutoSize = true;
            this.LblScrLk.Location = new System.Drawing.Point(396, 223);
            this.LblScrLk.Name = "LblScrLk";
            this.LblScrLk.Size = new System.Drawing.Size(53, 13);
            this.LblScrLk.TabIndex = 158;
            this.LblScrLk.Text = "ScrLock: ";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(510, 74);
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
            this.BtnPID2.Location = new System.Drawing.Point(525, 401);
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
            this.label4.Location = new System.Drawing.Point(760, 97);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 13);
            this.label4.TabIndex = 216;
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(760, 97);
            this.label36.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(249, 13);
            this.label36.TabIndex = 217;
            this.label36.Text = "1=left, 2=right, 4=center, 8=XButton1, 16=XButton2";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(680, 149);
            this.label29.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(23, 13);
            this.label29.TabIndex = 223;
            this.label29.Text = "dY:";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(680, 125);
            this.label31.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(23, 13);
            this.label31.TabIndex = 222;
            this.label31.Text = "dX:";
            // 
            // TxtMouseY
            // 
            this.TxtMouseY.Location = new System.Drawing.Point(707, 146);
            this.TxtMouseY.Margin = new System.Windows.Forms.Padding(2);
            this.TxtMouseY.Name = "TxtMouseY";
            this.TxtMouseY.Size = new System.Drawing.Size(41, 20);
            this.TxtMouseY.TabIndex = 221;
            this.TxtMouseY.Text = "5";
            // 
            // TxtMouseX
            // 
            this.TxtMouseX.Location = new System.Drawing.Point(707, 122);
            this.TxtMouseX.Margin = new System.Windows.Forms.Padding(2);
            this.TxtMouseX.Name = "TxtMouseX";
            this.TxtMouseX.Size = new System.Drawing.Size(41, 20);
            this.TxtMouseX.TabIndex = 220;
            this.TxtMouseX.Text = "5";
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(760, 135);
            this.label37.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(61, 13);
            this.label37.TabIndex = 224;
            this.label37.Text = "1=finest inc";
            // 
            // BtnCustom
            // 
            this.BtnCustom.Location = new System.Drawing.Point(130, 429);
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
            this.label14.Location = new System.Drawing.Point(8, 401);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(313, 13);
            this.label14.TabIndex = 259;
            this.label14.Text = "Stimulate a general incoming data report or a custom input report.";
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(8, 531);
            this.label41.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(294, 13);
            this.label41.TabIndex = 263;
            this.label41.Text = "Write Version (0-65535), reboot required, may take some time";
            // 
            // LblVersion
            // 
            this.LblVersion.AutoSize = true;
            this.LblVersion.Location = new System.Drawing.Point(181, 560);
            this.LblVersion.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LblVersion.Name = "LblVersion";
            this.LblVersion.Size = new System.Drawing.Size(41, 13);
            this.LblVersion.TabIndex = 262;
            this.LblVersion.Text = "version";
            // 
            // TxtVersion
            // 
            this.TxtVersion.Location = new System.Drawing.Point(127, 555);
            this.TxtVersion.Margin = new System.Windows.Forms.Padding(2);
            this.TxtVersion.Name = "TxtVersion";
            this.TxtVersion.Size = new System.Drawing.Size(49, 20);
            this.TxtVersion.TabIndex = 261;
            this.TxtVersion.Text = "100";
            // 
            // BtnVersion
            // 
            this.BtnVersion.Location = new System.Drawing.Point(21, 555);
            this.BtnVersion.Margin = new System.Windows.Forms.Padding(2);
            this.BtnVersion.Name = "BtnVersion";
            this.BtnVersion.Size = new System.Drawing.Size(92, 22);
            this.BtnVersion.TabIndex = 260;
            this.BtnVersion.Text = "Write Version";
            this.BtnVersion.UseVisualStyleBackColor = true;
            this.BtnVersion.Click += new System.EventHandler(this.BtnVersion_Click);
            // 
            // BtnMousereflect
            // 
            this.BtnMousereflect.Location = new System.Drawing.Point(525, 94);
            this.BtnMousereflect.Margin = new System.Windows.Forms.Padding(2);
            this.BtnMousereflect.Name = "BtnMousereflect";
            this.BtnMousereflect.Size = new System.Drawing.Size(98, 22);
            this.BtnMousereflect.TabIndex = 264;
            this.BtnMousereflect.Text = "Mouse Reflector";
            this.BtnMousereflect.UseVisualStyleBackColor = true;
            this.BtnMousereflect.Click += new System.EventHandler(this.BtnMousereflect_Click);
            // 
            // LblJack1R
            // 
            this.LblJack1R.AutoSize = true;
            this.LblJack1R.Location = new System.Drawing.Point(320, 193);
            this.LblJack1R.Name = "LblJack1R";
            this.LblJack1R.Size = new System.Drawing.Size(13, 13);
            this.LblJack1R.TabIndex = 266;
            this.LblJack1R.Text = "1";
            // 
            // LblJack1L
            // 
            this.LblJack1L.AutoSize = true;
            this.LblJack1L.Location = new System.Drawing.Point(364, 193);
            this.LblJack1L.Name = "LblJack1L";
            this.LblJack1L.Size = new System.Drawing.Size(13, 13);
            this.LblJack1L.TabIndex = 267;
            this.LblJack1L.Text = "2";
            // 
            // LblJack2L
            // 
            this.LblJack2L.AutoSize = true;
            this.LblJack2L.Location = new System.Drawing.Point(364, 208);
            this.LblJack2L.Name = "LblJack2L";
            this.LblJack2L.Size = new System.Drawing.Size(13, 13);
            this.LblJack2L.TabIndex = 269;
            this.LblJack2L.Text = "4";
            // 
            // LblJack2R
            // 
            this.LblJack2R.AutoSize = true;
            this.LblJack2R.Location = new System.Drawing.Point(320, 208);
            this.LblJack2R.Name = "LblJack2R";
            this.LblJack2R.Size = new System.Drawing.Size(13, 13);
            this.LblJack2R.TabIndex = 268;
            this.LblJack2R.Text = "3";
            // 
            // LblJack3L
            // 
            this.LblJack3L.AutoSize = true;
            this.LblJack3L.Location = new System.Drawing.Point(364, 222);
            this.LblJack3L.Name = "LblJack3L";
            this.LblJack3L.Size = new System.Drawing.Size(13, 13);
            this.LblJack3L.TabIndex = 271;
            this.LblJack3L.Text = "6";
            // 
            // LblJack3R
            // 
            this.LblJack3R.AutoSize = true;
            this.LblJack3R.Location = new System.Drawing.Point(320, 222);
            this.LblJack3R.Name = "LblJack3R";
            this.LblJack3R.Size = new System.Drawing.Size(13, 13);
            this.LblJack3R.TabIndex = 270;
            this.LblJack3R.Text = "5";
            // 
            // LblJack6L
            // 
            this.LblJack6L.AutoSize = true;
            this.LblJack6L.Location = new System.Drawing.Point(364, 265);
            this.LblJack6L.Name = "LblJack6L";
            this.LblJack6L.Size = new System.Drawing.Size(19, 13);
            this.LblJack6L.TabIndex = 277;
            this.LblJack6L.Text = "12";
            // 
            // LblJack6R
            // 
            this.LblJack6R.AutoSize = true;
            this.LblJack6R.Location = new System.Drawing.Point(320, 265);
            this.LblJack6R.Name = "LblJack6R";
            this.LblJack6R.Size = new System.Drawing.Size(19, 13);
            this.LblJack6R.TabIndex = 276;
            this.LblJack6R.Text = "11";
            // 
            // LblJack5L
            // 
            this.LblJack5L.AutoSize = true;
            this.LblJack5L.Location = new System.Drawing.Point(364, 251);
            this.LblJack5L.Name = "LblJack5L";
            this.LblJack5L.Size = new System.Drawing.Size(19, 13);
            this.LblJack5L.TabIndex = 275;
            this.LblJack5L.Text = "10";
            // 
            // LblJack5R
            // 
            this.LblJack5R.AutoSize = true;
            this.LblJack5R.Location = new System.Drawing.Point(320, 251);
            this.LblJack5R.Name = "LblJack5R";
            this.LblJack5R.Size = new System.Drawing.Size(13, 13);
            this.LblJack5R.TabIndex = 274;
            this.LblJack5R.Text = "9";
            // 
            // LblJack4L
            // 
            this.LblJack4L.AutoSize = true;
            this.LblJack4L.Location = new System.Drawing.Point(364, 236);
            this.LblJack4L.Name = "LblJack4L";
            this.LblJack4L.Size = new System.Drawing.Size(13, 13);
            this.LblJack4L.TabIndex = 273;
            this.LblJack4L.Text = "8";
            // 
            // LblJack4R
            // 
            this.LblJack4R.AutoSize = true;
            this.LblJack4R.Location = new System.Drawing.Point(320, 236);
            this.LblJack4R.Name = "LblJack4R";
            this.LblJack4R.Size = new System.Drawing.Size(13, 13);
            this.LblJack4R.TabIndex = 272;
            this.LblJack4R.Text = "7";
            // 
            // ChkSuppress
            // 
            this.ChkSuppress.AutoSize = true;
            this.ChkSuppress.Location = new System.Drawing.Point(156, 94);
            this.ChkSuppress.Name = "ChkSuppress";
            this.ChkSuppress.Size = new System.Drawing.Size(158, 17);
            this.ChkSuppress.TabIndex = 278;
            this.ChkSuppress.Text = "Suppress Duplicate Reports";
            this.ChkSuppress.UseVisualStyleBackColor = true;
            this.ChkSuppress.CheckedChanged += new System.EventHandler(this.ChkSuppress_CheckedChanged);
            // 
            // LblPassFail
            // 
            this.LblPassFail.AutoSize = true;
            this.LblPassFail.Location = new System.Drawing.Point(751, 228);
            this.LblPassFail.Name = "LblPassFail";
            this.LblPassFail.Size = new System.Drawing.Size(51, 13);
            this.LblPassFail.TabIndex = 309;
            this.LblPassFail.Text = "Pass/Fail";
            // 
            // BtnCheckDongle
            // 
            this.BtnCheckDongle.Location = new System.Drawing.Point(634, 223);
            this.BtnCheckDongle.Margin = new System.Windows.Forms.Padding(2);
            this.BtnCheckDongle.Name = "BtnCheckDongle";
            this.BtnCheckDongle.Size = new System.Drawing.Size(112, 22);
            this.BtnCheckDongle.TabIndex = 308;
            this.BtnCheckDongle.Text = "Check Dongle Key";
            this.BtnCheckDongle.UseVisualStyleBackColor = true;
            this.BtnCheckDongle.Click += new System.EventHandler(this.BtnCheckDongle_Click);
            // 
            // BtnSetDongle
            // 
            this.BtnSetDongle.Location = new System.Drawing.Point(525, 223);
            this.BtnSetDongle.Margin = new System.Windows.Forms.Padding(2);
            this.BtnSetDongle.Name = "BtnSetDongle";
            this.BtnSetDongle.Size = new System.Drawing.Size(98, 22);
            this.BtnSetDongle.TabIndex = 307;
            this.BtnSetDongle.Text = "Set Dongle Key";
            this.BtnSetDongle.UseVisualStyleBackColor = true;
            this.BtnSetDongle.Click += new System.EventHandler(this.BtnSetDongle_Click);
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Location = new System.Drawing.Point(510, 206);
            this.label44.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(41, 13);
            this.label44.TabIndex = 306;
            this.label44.Text = "Dongle";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(625, 406);
            this.label25.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(214, 13);
            this.label25.TabIndex = 310;
            this.label25.Text = "Endpoints: Keyboard only for use with KVM*";
            // 
            // BtnChange
            // 
            this.BtnChange.Location = new System.Drawing.Point(715, 314);
            this.BtnChange.Name = "BtnChange";
            this.BtnChange.Size = new System.Drawing.Size(239, 23);
            this.BtnChange.TabIndex = 313;
            this.BtnChange.Text = "Always change to PID #2 (KVM) on reboot";
            this.BtnChange.UseVisualStyleBackColor = true;
            this.BtnChange.Click += new System.EventHandler(this.BtnChange_Click);
            // 
            // BtnNoChange
            // 
            this.BtnNoChange.Location = new System.Drawing.Point(524, 316);
            this.BtnNoChange.Name = "BtnNoChange";
            this.BtnNoChange.Size = new System.Drawing.Size(183, 23);
            this.BtnNoChange.TabIndex = 312;
            this.BtnNoChange.Text = "Do not change PID on reboot";
            this.BtnNoChange.UseVisualStyleBackColor = true;
            this.BtnNoChange.Click += new System.EventHandler(this.BtnNoChange_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(510, 293);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 13);
            this.label6.TabIndex = 311;
            this.label6.Text = "Reboot Mode";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(522, 429);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(445, 67);
            this.label8.TabIndex = 314;
            this.label8.Text = resources.GetString("label8.Text");
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1020, 607);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.BtnChange);
            this.Controls.Add(this.BtnNoChange);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.LblPassFail);
            this.Controls.Add(this.BtnCheckDongle);
            this.Controls.Add(this.BtnSetDongle);
            this.Controls.Add(this.label44);
            this.Controls.Add(this.ChkSuppress);
            this.Controls.Add(this.LblJack6L);
            this.Controls.Add(this.LblJack6R);
            this.Controls.Add(this.LblJack5L);
            this.Controls.Add(this.LblJack5R);
            this.Controls.Add(this.LblJack4L);
            this.Controls.Add(this.LblJack4R);
            this.Controls.Add(this.LblJack3L);
            this.Controls.Add(this.LblJack3R);
            this.Controls.Add(this.LblJack2L);
            this.Controls.Add(this.LblJack2R);
            this.Controls.Add(this.LblJack1L);
            this.Controls.Add(this.LblJack1R);
            this.Controls.Add(this.BtnMousereflect);
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
            this.Text = "C# X-keys XK-12 Switch Interface/XK-3 Switch Interface KVM";
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
        private System.Windows.Forms.Button BtnMousereflect;
        private System.Windows.Forms.Label LblJack1R;
        private System.Windows.Forms.Label LblJack1L;
        private System.Windows.Forms.Label LblJack2L;
        private System.Windows.Forms.Label LblJack2R;
        private System.Windows.Forms.Label LblJack3L;
        private System.Windows.Forms.Label LblJack3R;
        private System.Windows.Forms.Label LblJack6L;
        private System.Windows.Forms.Label LblJack6R;
        private System.Windows.Forms.Label LblJack5L;
        private System.Windows.Forms.Label LblJack5R;
        private System.Windows.Forms.Label LblJack4L;
        private System.Windows.Forms.Label LblJack4R;
        private System.Windows.Forms.CheckBox ChkSuppress;
        private System.Windows.Forms.Label LblPassFail;
        private System.Windows.Forms.Button BtnCheckDongle;
        private System.Windows.Forms.Button BtnSetDongle;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Button BtnChange;
        private System.Windows.Forms.Button BtnNoChange;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
    }
}

