namespace NETComp_Csharp_Sample
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
            this.components = new System.ComponentModel.Container();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.btnFrequency = new System.Windows.Forms.Button();
            this.spnFrequency = new System.Windows.Forms.NumericUpDown();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.btnJoystick = new System.Windows.Forms.Button();
            this.btnMouse = new System.Windows.Forms.Button();
            this.txtKeyboard = new System.Windows.Forms.TextBox();
            this.btnKeyboard = new System.Windows.Forms.Button();
            this.txtByte3 = new System.Windows.Forms.TextBox();
            this.txtByte2 = new System.Windows.Forms.TextBox();
            this.grpDongle = new System.Windows.Forms.GroupBox();
            this.txtByte4 = new System.Windows.Forms.TextBox();
            this.btnCheckDongle = new System.Windows.Forms.Button();
            this.btnSetDongle = new System.Windows.Forms.Button();
            this.txtByte1 = new System.Windows.Forms.TextBox();
            this.btn1192 = new System.Windows.Forms.Button();
            this.btn1195 = new System.Windows.Forms.Button();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.lblButton12 = new System.Windows.Forms.Label();
            this.lblButton11 = new System.Windows.Forms.Label();
            this.lblButton08 = new System.Windows.Forms.Label();
            this.lblButton10 = new System.Windows.Forms.Label();
            this.lblButton09 = new System.Windows.Forms.Label();
            this.deviceStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblButton07 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblProductID = new System.Windows.Forms.Label();
            this.btnOEM = new System.Windows.Forms.Button();
            this.btnUID = new System.Windows.Forms.Button();
            this.txtUID = new System.Windows.Forms.TextBox();
            this.txtOEM = new System.Windows.Forms.TextBox();
            this.lblOEM = new System.Windows.Forms.Label();
            this.lblUID = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblButton06 = new System.Windows.Forms.Label();
            this.lblButton05 = new System.Windows.Forms.Label();
            this.lblButton04 = new System.Windows.Forms.Label();
            this.lblButton03 = new System.Windows.Forms.Label();
            this.lblButton02 = new System.Windows.Forms.Label();
            this.lblButton01 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblDTime = new System.Windows.Forms.Label();
            this.lblATime = new System.Windows.Forms.Label();
            this.xk12SI_1 = new Xk12SI.Xk12SI_(this.components);
            this.chkRedFlash = new System.Windows.Forms.CheckBox();
            this.chkGreenFlash = new System.Windows.Forms.CheckBox();
            this.chkRed = new System.Windows.Forms.CheckBox();
            this.chkGreen = new System.Windows.Forms.CheckBox();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spnFrequency)).BeginInit();
            this.groupBox11.SuspendLayout();
            this.grpDongle.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(6, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(168, 72);
            this.label6.TabIndex = 4;
            this.label6.Text = "Reflector messages send into the hardware, then back into the OS. Device must be " +
                "in a configuration that supports the kind of input one is expecting to reflect.";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.chkRedFlash);
            this.groupBox6.Controls.Add(this.chkGreenFlash);
            this.groupBox6.Controls.Add(this.chkRed);
            this.groupBox6.Controls.Add(this.chkGreen);
            this.groupBox6.Location = new System.Drawing.Point(301, 2);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(164, 80);
            this.groupBox6.TabIndex = 43;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Indicators";
            // 
            // btnFrequency
            // 
            this.btnFrequency.Location = new System.Drawing.Point(75, 17);
            this.btnFrequency.Name = "btnFrequency";
            this.btnFrequency.Size = new System.Drawing.Size(75, 23);
            this.btnFrequency.TabIndex = 11;
            this.btnFrequency.Text = "Set";
            this.btnFrequency.UseVisualStyleBackColor = true;
            this.btnFrequency.Click += new System.EventHandler(this.btnFrequency_Click);
            // 
            // spnFrequency
            // 
            this.spnFrequency.Location = new System.Drawing.Point(15, 18);
            this.spnFrequency.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.spnFrequency.Name = "spnFrequency";
            this.spnFrequency.Size = new System.Drawing.Size(54, 20);
            this.spnFrequency.TabIndex = 5;
            this.spnFrequency.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.btnJoystick);
            this.groupBox11.Controls.Add(this.btnMouse);
            this.groupBox11.Controls.Add(this.txtKeyboard);
            this.groupBox11.Controls.Add(this.btnKeyboard);
            this.groupBox11.Controls.Add(this.label6);
            this.groupBox11.Location = new System.Drawing.Point(478, 149);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(181, 177);
            this.groupBox11.TabIndex = 47;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "Reflector";
            // 
            // btnJoystick
            // 
            this.btnJoystick.Location = new System.Drawing.Point(10, 148);
            this.btnJoystick.Name = "btnJoystick";
            this.btnJoystick.Size = new System.Drawing.Size(97, 23);
            this.btnJoystick.TabIndex = 3;
            this.btnJoystick.Text = "Send Joystick";
            this.btnJoystick.UseVisualStyleBackColor = true;
            this.btnJoystick.Click += new System.EventHandler(this.btnJoystick_Click);
            // 
            // btnMouse
            // 
            this.btnMouse.Location = new System.Drawing.Point(10, 91);
            this.btnMouse.Name = "btnMouse";
            this.btnMouse.Size = new System.Drawing.Size(97, 23);
            this.btnMouse.TabIndex = 2;
            this.btnMouse.Text = "Send Mouse";
            this.btnMouse.UseVisualStyleBackColor = true;
            this.btnMouse.Click += new System.EventHandler(this.btnMouse_Click);
            // 
            // txtKeyboard
            // 
            this.txtKeyboard.Location = new System.Drawing.Point(113, 121);
            this.txtKeyboard.Name = "txtKeyboard";
            this.txtKeyboard.Size = new System.Drawing.Size(49, 20);
            this.txtKeyboard.TabIndex = 1;
            // 
            // btnKeyboard
            // 
            this.btnKeyboard.Location = new System.Drawing.Point(10, 119);
            this.btnKeyboard.Name = "btnKeyboard";
            this.btnKeyboard.Size = new System.Drawing.Size(97, 23);
            this.btnKeyboard.TabIndex = 0;
            this.btnKeyboard.Text = "Send Keyboard";
            this.btnKeyboard.UseVisualStyleBackColor = true;
            this.btnKeyboard.Click += new System.EventHandler(this.btnKeyboard_Click);
            // 
            // txtByte3
            // 
            this.txtByte3.Location = new System.Drawing.Point(114, 19);
            this.txtByte3.Name = "txtByte3";
            this.txtByte3.Size = new System.Drawing.Size(45, 20);
            this.txtByte3.TabIndex = 4;
            // 
            // txtByte2
            // 
            this.txtByte2.Location = new System.Drawing.Point(63, 19);
            this.txtByte2.Name = "txtByte2";
            this.txtByte2.Size = new System.Drawing.Size(45, 20);
            this.txtByte2.TabIndex = 5;
            // 
            // grpDongle
            // 
            this.grpDongle.Controls.Add(this.txtByte2);
            this.grpDongle.Controls.Add(this.txtByte3);
            this.grpDongle.Controls.Add(this.txtByte4);
            this.grpDongle.Controls.Add(this.btnCheckDongle);
            this.grpDongle.Controls.Add(this.btnSetDongle);
            this.grpDongle.Controls.Add(this.txtByte1);
            this.grpDongle.Location = new System.Drawing.Point(12, 149);
            this.grpDongle.Name = "grpDongle";
            this.grpDongle.Size = new System.Drawing.Size(327, 47);
            this.grpDongle.TabIndex = 46;
            this.grpDongle.TabStop = false;
            this.grpDongle.Text = "Security Key";
            // 
            // txtByte4
            // 
            this.txtByte4.Location = new System.Drawing.Point(165, 19);
            this.txtByte4.Name = "txtByte4";
            this.txtByte4.Size = new System.Drawing.Size(45, 20);
            this.txtByte4.TabIndex = 3;
            // 
            // btnCheckDongle
            // 
            this.btnCheckDongle.Location = new System.Drawing.Point(271, 17);
            this.btnCheckDongle.Name = "btnCheckDongle";
            this.btnCheckDongle.Size = new System.Drawing.Size(50, 23);
            this.btnCheckDongle.TabIndex = 2;
            this.btnCheckDongle.Text = "Check";
            this.btnCheckDongle.UseVisualStyleBackColor = true;
            this.btnCheckDongle.Click += new System.EventHandler(this.btnCheckDongle_Click);
            // 
            // btnSetDongle
            // 
            this.btnSetDongle.Location = new System.Drawing.Point(216, 17);
            this.btnSetDongle.Name = "btnSetDongle";
            this.btnSetDongle.Size = new System.Drawing.Size(50, 23);
            this.btnSetDongle.TabIndex = 1;
            this.btnSetDongle.Text = "Set";
            this.btnSetDongle.UseVisualStyleBackColor = true;
            this.btnSetDongle.Click += new System.EventHandler(this.btnSetDongle_Click);
            // 
            // txtByte1
            // 
            this.txtByte1.Location = new System.Drawing.Point(12, 19);
            this.txtByte1.Name = "txtByte1";
            this.txtByte1.Size = new System.Drawing.Size(45, 20);
            this.txtByte1.TabIndex = 0;
            // 
            // btn1192
            // 
            this.btn1192.Location = new System.Drawing.Point(7, 17);
            this.btn1192.Name = "btn1192";
            this.btn1192.Size = new System.Drawing.Size(53, 23);
            this.btn1192.TabIndex = 34;
            this.btn1192.Text = "1192";
            this.btn1192.UseVisualStyleBackColor = true;
            this.btn1192.Click += new System.EventHandler(this.btn1192_Click);
            // 
            // btn1195
            // 
            this.btn1195.Location = new System.Drawing.Point(66, 17);
            this.btn1195.Name = "btn1195";
            this.btn1195.Size = new System.Drawing.Size(51, 23);
            this.btn1195.TabIndex = 33;
            this.btn1195.Text = "1195";
            this.btn1195.UseVisualStyleBackColor = true;
            this.btn1195.Click += new System.EventHandler(this.btn1195_Click);
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.btn1195);
            this.groupBox9.Controls.Add(this.btn1192);
            this.groupBox9.Location = new System.Drawing.Point(342, 149);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(123, 47);
            this.groupBox9.TabIndex = 45;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "PID";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnFrequency);
            this.groupBox5.Controls.Add(this.spnFrequency);
            this.groupBox5.Location = new System.Drawing.Point(301, 88);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(164, 55);
            this.groupBox5.TabIndex = 40;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Flash Freq";
            // 
            // lblButton12
            // 
            this.lblButton12.AutoSize = true;
            this.lblButton12.Location = new System.Drawing.Point(88, 115);
            this.lblButton12.Name = "lblButton12";
            this.lblButton12.Size = new System.Drawing.Size(47, 13);
            this.lblButton12.TabIndex = 11;
            this.lblButton12.Tag = "12";
            this.lblButton12.Text = "Jack 6R";
            // 
            // lblButton11
            // 
            this.lblButton11.AutoSize = true;
            this.lblButton11.Location = new System.Drawing.Point(88, 96);
            this.lblButton11.Name = "lblButton11";
            this.lblButton11.Size = new System.Drawing.Size(45, 13);
            this.lblButton11.TabIndex = 10;
            this.lblButton11.Tag = "11";
            this.lblButton11.Text = "Jack 6L";
            // 
            // lblButton08
            // 
            this.lblButton08.AutoSize = true;
            this.lblButton08.Location = new System.Drawing.Point(88, 39);
            this.lblButton08.Name = "lblButton08";
            this.lblButton08.Size = new System.Drawing.Size(45, 13);
            this.lblButton08.TabIndex = 7;
            this.lblButton08.Tag = "8";
            this.lblButton08.Text = "Jack 4L";
            // 
            // lblButton10
            // 
            this.lblButton10.AutoSize = true;
            this.lblButton10.Location = new System.Drawing.Point(88, 77);
            this.lblButton10.Name = "lblButton10";
            this.lblButton10.Size = new System.Drawing.Size(45, 13);
            this.lblButton10.TabIndex = 9;
            this.lblButton10.Tag = "10";
            this.lblButton10.Text = "Jack 5L";
            // 
            // lblButton09
            // 
            this.lblButton09.AutoSize = true;
            this.lblButton09.Location = new System.Drawing.Point(88, 58);
            this.lblButton09.Name = "lblButton09";
            this.lblButton09.Size = new System.Drawing.Size(47, 13);
            this.lblButton09.TabIndex = 8;
            this.lblButton09.Tag = "9";
            this.lblButton09.Text = "Jack 5R";
            // 
            // deviceStatus
            // 
            this.deviceStatus.Name = "deviceStatus";
            this.deviceStatus.Size = new System.Drawing.Size(118, 17);
            this.deviceStatus.Text = "toolStripStatusLabel1";
            // 
            // lblButton07
            // 
            this.lblButton07.AutoSize = true;
            this.lblButton07.Location = new System.Drawing.Point(88, 22);
            this.lblButton07.Name = "lblButton07";
            this.lblButton07.Size = new System.Drawing.Size(47, 13);
            this.lblButton07.TabIndex = 6;
            this.lblButton07.Tag = "7";
            this.lblButton07.Text = "Jack 4R";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblProductID);
            this.groupBox2.Controls.Add(this.btnOEM);
            this.groupBox2.Controls.Add(this.btnUID);
            this.groupBox2.Controls.Add(this.txtUID);
            this.groupBox2.Controls.Add(this.txtOEM);
            this.groupBox2.Controls.Add(this.lblOEM);
            this.groupBox2.Controls.Add(this.lblUID);
            this.groupBox2.Location = new System.Drawing.Point(12, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(281, 80);
            this.groupBox2.TabIndex = 37;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Device IDs";
            // 
            // lblProductID
            // 
            this.lblProductID.AutoSize = true;
            this.lblProductID.Location = new System.Drawing.Point(6, 58);
            this.lblProductID.Name = "lblProductID";
            this.lblProductID.Size = new System.Drawing.Size(61, 13);
            this.lblProductID.TabIndex = 10;
            this.lblProductID.Text = "Product ID:";
            // 
            // btnOEM
            // 
            this.btnOEM.Location = new System.Drawing.Point(216, 35);
            this.btnOEM.Name = "btnOEM";
            this.btnOEM.Size = new System.Drawing.Size(49, 23);
            this.btnOEM.TabIndex = 9;
            this.btnOEM.Text = "Set";
            this.btnOEM.UseVisualStyleBackColor = true;
            this.btnOEM.Click += new System.EventHandler(this.btnOEM_Click);
            // 
            // btnUID
            // 
            this.btnUID.Location = new System.Drawing.Point(216, 12);
            this.btnUID.Name = "btnUID";
            this.btnUID.Size = new System.Drawing.Size(49, 23);
            this.btnUID.TabIndex = 7;
            this.btnUID.Text = "Set";
            this.btnUID.UseVisualStyleBackColor = true;
            this.btnUID.Click += new System.EventHandler(this.btnUID_Click);
            // 
            // txtUID
            // 
            this.txtUID.Location = new System.Drawing.Point(168, 15);
            this.txtUID.Name = "txtUID";
            this.txtUID.Size = new System.Drawing.Size(42, 20);
            this.txtUID.TabIndex = 7;
            // 
            // txtOEM
            // 
            this.txtOEM.Location = new System.Drawing.Point(136, 36);
            this.txtOEM.Name = "txtOEM";
            this.txtOEM.Size = new System.Drawing.Size(74, 20);
            this.txtOEM.TabIndex = 8;
            // 
            // lblOEM
            // 
            this.lblOEM.AutoSize = true;
            this.lblOEM.Location = new System.Drawing.Point(6, 39);
            this.lblOEM.Name = "lblOEM";
            this.lblOEM.Size = new System.Drawing.Size(48, 13);
            this.lblOEM.TabIndex = 6;
            this.lblOEM.Text = "OEM ID:";
            // 
            // lblUID
            // 
            this.lblUID.AutoSize = true;
            this.lblUID.Location = new System.Drawing.Point(6, 18);
            this.lblUID.Name = "lblUID";
            this.lblUID.Size = new System.Drawing.Size(43, 13);
            this.lblUID.TabIndex = 5;
            this.lblUID.Text = "Unit ID:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblButton12);
            this.groupBox1.Controls.Add(this.lblButton11);
            this.groupBox1.Controls.Add(this.lblButton10);
            this.groupBox1.Controls.Add(this.lblButton09);
            this.groupBox1.Controls.Add(this.lblButton08);
            this.groupBox1.Controls.Add(this.lblButton07);
            this.groupBox1.Controls.Add(this.lblButton06);
            this.groupBox1.Controls.Add(this.lblButton05);
            this.groupBox1.Controls.Add(this.lblButton04);
            this.groupBox1.Controls.Add(this.lblButton03);
            this.groupBox1.Controls.Add(this.lblButton02);
            this.groupBox1.Controls.Add(this.lblButton01);
            this.groupBox1.Location = new System.Drawing.Point(478, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(181, 141);
            this.groupBox1.TabIndex = 36;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Button Activity";
            // 
            // lblButton06
            // 
            this.lblButton06.AutoSize = true;
            this.lblButton06.Location = new System.Drawing.Point(7, 116);
            this.lblButton06.Name = "lblButton06";
            this.lblButton06.Size = new System.Drawing.Size(45, 13);
            this.lblButton06.TabIndex = 5;
            this.lblButton06.Tag = "6";
            this.lblButton06.Text = "Jack 3L";
            // 
            // lblButton05
            // 
            this.lblButton05.AutoSize = true;
            this.lblButton05.Location = new System.Drawing.Point(7, 97);
            this.lblButton05.Name = "lblButton05";
            this.lblButton05.Size = new System.Drawing.Size(47, 13);
            this.lblButton05.TabIndex = 4;
            this.lblButton05.Tag = "5";
            this.lblButton05.Text = "Jack 3R";
            // 
            // lblButton04
            // 
            this.lblButton04.AutoSize = true;
            this.lblButton04.Location = new System.Drawing.Point(7, 78);
            this.lblButton04.Name = "lblButton04";
            this.lblButton04.Size = new System.Drawing.Size(45, 13);
            this.lblButton04.TabIndex = 3;
            this.lblButton04.Tag = "4";
            this.lblButton04.Text = "Jack 2L";
            // 
            // lblButton03
            // 
            this.lblButton03.AutoSize = true;
            this.lblButton03.Location = new System.Drawing.Point(7, 59);
            this.lblButton03.Name = "lblButton03";
            this.lblButton03.Size = new System.Drawing.Size(47, 13);
            this.lblButton03.TabIndex = 2;
            this.lblButton03.Tag = "3";
            this.lblButton03.Text = "Jack 2R";
            // 
            // lblButton02
            // 
            this.lblButton02.AutoSize = true;
            this.lblButton02.Location = new System.Drawing.Point(7, 40);
            this.lblButton02.Name = "lblButton02";
            this.lblButton02.Size = new System.Drawing.Size(45, 13);
            this.lblButton02.TabIndex = 1;
            this.lblButton02.Tag = "2";
            this.lblButton02.Text = "Jack 1L";
            // 
            // lblButton01
            // 
            this.lblButton01.AutoSize = true;
            this.lblButton01.Location = new System.Drawing.Point(7, 21);
            this.lblButton01.Name = "lblButton01";
            this.lblButton01.Size = new System.Drawing.Size(47, 13);
            this.lblButton01.TabIndex = 0;
            this.lblButton01.Tag = "1";
            this.lblButton01.Text = "Jack 1R";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deviceStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 334);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(669, 22);
            this.statusStrip1.TabIndex = 35;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.btnGenerate);
            this.groupBox10.Location = new System.Drawing.Point(12, 88);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(110, 55);
            this.groupBox10.TabIndex = 48;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Other";
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(6, 17);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(98, 25);
            this.btnGenerate.TabIndex = 24;
            this.btnGenerate.Text = "Generate Report";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblDTime);
            this.groupBox3.Controls.Add(this.lblATime);
            this.groupBox3.Location = new System.Drawing.Point(129, 88);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(164, 55);
            this.groupBox3.TabIndex = 49;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Time Stamp";
            // 
            // lblDTime
            // 
            this.lblDTime.AutoSize = true;
            this.lblDTime.Location = new System.Drawing.Point(7, 34);
            this.lblDTime.Name = "lblDTime";
            this.lblDTime.Size = new System.Drawing.Size(61, 13);
            this.lblDTime.TabIndex = 1;
            this.lblDTime.Text = "Delta Time:";
            // 
            // lblATime
            // 
            this.lblATime.AutoSize = true;
            this.lblATime.Location = new System.Drawing.Point(7, 18);
            this.lblATime.Name = "lblATime";
            this.lblATime.Size = new System.Drawing.Size(77, 13);
            this.lblATime.TabIndex = 0;
            this.lblATime.Text = "Absolute Time:";
            // 
            // xk12SI_1
            // 
            this.xk12SI_1.ContainerControl = this;
            this.xk12SI_1.Tag = null;
            this.xk12SI_1.ButtonChange += new Xk12SI.Xk12SI_.OnButtonHandler(this.xk12SI_1_ButtonChange);
            this.xk12SI_1.DevicePlug += new Xk12SI.Xk12SI_.OnDeviceChangeHandler(this.xk12SI_1_DevicePlug);
            this.xk12SI_1.DeviceUnplug += new Xk12SI.Xk12SI_.OnDeviceChangeHandler(this.xk12SI_1_DeviceUnplug);
            this.xk12SI_1.GenerateReportData += new Xk12SI.Xk12SI_.OnGenerateReportData(this.xk12SI_1_GenerateReportData);
            // 
            // chkRedFlash
            // 
            this.chkRedFlash.AutoSize = true;
            this.chkRedFlash.Location = new System.Drawing.Point(71, 44);
            this.chkRedFlash.Name = "chkRedFlash";
            this.chkRedFlash.Size = new System.Drawing.Size(51, 17);
            this.chkRedFlash.TabIndex = 28;
            this.chkRedFlash.Text = "Flash";
            this.chkRedFlash.UseVisualStyleBackColor = true;
            this.chkRedFlash.CheckedChanged += new System.EventHandler(this.chkRedFlash_CheckedChanged);
            // 
            // chkGreenFlash
            // 
            this.chkGreenFlash.AutoSize = true;
            this.chkGreenFlash.Location = new System.Drawing.Point(71, 21);
            this.chkGreenFlash.Name = "chkGreenFlash";
            this.chkGreenFlash.Size = new System.Drawing.Size(51, 17);
            this.chkGreenFlash.TabIndex = 27;
            this.chkGreenFlash.Text = "Flash";
            this.chkGreenFlash.UseVisualStyleBackColor = true;
            this.chkGreenFlash.CheckedChanged += new System.EventHandler(this.chkGreenFlash_CheckedChanged);
            // 
            // chkRed
            // 
            this.chkRed.AutoSize = true;
            this.chkRed.Location = new System.Drawing.Point(6, 44);
            this.chkRed.Name = "chkRed";
            this.chkRed.Size = new System.Drawing.Size(46, 17);
            this.chkRed.TabIndex = 26;
            this.chkRed.Text = "Red";
            this.chkRed.UseVisualStyleBackColor = true;
            this.chkRed.CheckedChanged += new System.EventHandler(this.chkRed_CheckedChanged);
            // 
            // chkGreen
            // 
            this.chkGreen.AutoSize = true;
            this.chkGreen.Location = new System.Drawing.Point(6, 21);
            this.chkGreen.Name = "chkGreen";
            this.chkGreen.Size = new System.Drawing.Size(55, 17);
            this.chkGreen.TabIndex = 25;
            this.chkGreen.Text = "Green";
            this.chkGreen.UseVisualStyleBackColor = true;
            this.chkGreen.CheckedChanged += new System.EventHandler(this.chkGreen_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(669, 356);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox10);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox11);
            this.Controls.Add(this.grpDongle);
            this.Controls.Add(this.groupBox9);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.statusStrip1);
            this.Name = "Form1";
            this.Text = "XK-12 Switch Interface .NET Component C# Sample";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spnFrequency)).EndInit();
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
            this.grpDongle.ResumeLayout(false);
            this.grpDongle.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox10.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button btnFrequency;
        private System.Windows.Forms.NumericUpDown spnFrequency;
        private System.Windows.Forms.GroupBox groupBox11;
        private System.Windows.Forms.Button btnJoystick;
        private System.Windows.Forms.Button btnMouse;
        private System.Windows.Forms.TextBox txtKeyboard;
        private System.Windows.Forms.Button btnKeyboard;
        private System.Windows.Forms.TextBox txtByte3;
        private System.Windows.Forms.TextBox txtByte2;
        private System.Windows.Forms.GroupBox grpDongle;
        private System.Windows.Forms.TextBox txtByte4;
        private System.Windows.Forms.Button btnCheckDongle;
        private System.Windows.Forms.Button btnSetDongle;
        private System.Windows.Forms.TextBox txtByte1;
        private System.Windows.Forms.Button btn1192;
        private System.Windows.Forms.Button btn1195;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label lblButton12;
        private System.Windows.Forms.Label lblButton11;
        private System.Windows.Forms.Label lblButton08;
        private System.Windows.Forms.Label lblButton10;
        private System.Windows.Forms.Label lblButton09;
        private System.Windows.Forms.ToolStripStatusLabel deviceStatus;
        private System.Windows.Forms.Label lblButton07;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblProductID;
        private System.Windows.Forms.Button btnOEM;
        private System.Windows.Forms.Button btnUID;
        private System.Windows.Forms.TextBox txtUID;
        private System.Windows.Forms.TextBox txtOEM;
        private System.Windows.Forms.Label lblOEM;
        private System.Windows.Forms.Label lblUID;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblButton06;
        private System.Windows.Forms.Label lblButton05;
        private System.Windows.Forms.Label lblButton04;
        private System.Windows.Forms.Label lblButton03;
        private System.Windows.Forms.Label lblButton02;
        private System.Windows.Forms.Label lblButton01;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.Button btnGenerate;
        private Xk12SI.Xk12SI_ xk12SI_1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lblATime;
        private System.Windows.Forms.Label lblDTime;
        private System.Windows.Forms.CheckBox chkRedFlash;
        private System.Windows.Forms.CheckBox chkGreenFlash;
        private System.Windows.Forms.CheckBox chkRed;
        private System.Windows.Forms.CheckBox chkGreen;
    }
}

