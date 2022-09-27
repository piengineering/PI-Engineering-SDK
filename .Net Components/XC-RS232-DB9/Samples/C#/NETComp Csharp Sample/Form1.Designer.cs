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
            this.btn1257 = new System.Windows.Forms.Button();
            this.btn1260 = new System.Windows.Forms.Button();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
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
            this.label34 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.btnParity = new System.Windows.Forms.Button();
            this.cboParity = new System.Windows.Forms.ComboBox();
            this.btnBaud = new System.Windows.Forms.Button();
            this.cboBaud = new System.Windows.Forms.ComboBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.lblSendAscii = new System.Windows.Forms.Label();
            this.btnSendAscii = new System.Windows.Forms.Button();
            this.lblPassThrough = new System.Windows.Forms.Label();
            this.btnCmdPass = new System.Windows.Forms.Button();
            this.chkSetRTS = new System.Windows.Forms.CheckBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.btnWrite = new System.Windows.Forms.Button();
            this.txtAsciiCommand = new System.Windows.Forms.TextBox();
            this.xkRS232_1 = new XkRS232.XkRS232_(this.components);
            this.chkGreen = new System.Windows.Forms.CheckBox();
            this.groupBox6.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.grpDongle.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox8.SuspendLayout();
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
            this.groupBox6.Controls.Add(this.chkGreen);
            this.groupBox6.Location = new System.Drawing.Point(301, 2);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(81, 80);
            this.groupBox6.TabIndex = 43;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Indicators";
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
            // btn1257
            // 
            this.btn1257.Location = new System.Drawing.Point(7, 18);
            this.btn1257.Name = "btn1257";
            this.btn1257.Size = new System.Drawing.Size(53, 23);
            this.btn1257.TabIndex = 34;
            this.btn1257.Text = "1257";
            this.btn1257.UseVisualStyleBackColor = true;
            this.btn1257.Click += new System.EventHandler(this.btn1257_Click);
            // 
            // btn1260
            // 
            this.btn1260.Location = new System.Drawing.Point(66, 18);
            this.btn1260.Name = "btn1260";
            this.btn1260.Size = new System.Drawing.Size(51, 23);
            this.btn1260.TabIndex = 33;
            this.btn1260.Text = "1260";
            this.btn1260.UseVisualStyleBackColor = true;
            this.btn1260.Click += new System.EventHandler(this.btn1260_Click);
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.btn1260);
            this.groupBox9.Controls.Add(this.btn1257);
            this.groupBox9.Location = new System.Drawing.Point(148, 88);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(123, 55);
            this.groupBox9.TabIndex = 45;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "PID";
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
            this.groupBox2.TabIndex = 0;
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
            this.statusStrip1.Location = new System.Drawing.Point(0, 433);
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
            this.groupBox3.Controls.Add(this.label34);
            this.groupBox3.Controls.Add(this.label33);
            this.groupBox3.Controls.Add(this.btnParity);
            this.groupBox3.Controls.Add(this.cboParity);
            this.groupBox3.Controls.Add(this.btnBaud);
            this.groupBox3.Controls.Add(this.cboBaud);
            this.groupBox3.Location = new System.Drawing.Point(12, 202);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(342, 89);
            this.groupBox3.TabIndex = 49;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Setup RS232 (device will reboot)";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(221, 50);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(113, 13);
            this.label34.TabIndex = 289;
            this.label34.Text = "factory default is None";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(221, 23);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(111, 13);
            this.label33.TabIndex = 288;
            this.label33.Text = "factory default is 9600";
            // 
            // btnParity
            // 
            this.btnParity.Location = new System.Drawing.Point(133, 44);
            this.btnParity.Name = "btnParity";
            this.btnParity.Size = new System.Drawing.Size(86, 25);
            this.btnParity.TabIndex = 27;
            this.btnParity.Text = "Set Parity";
            this.btnParity.UseVisualStyleBackColor = true;
            this.btnParity.Click += new System.EventHandler(this.btnParity_Click);
            // 
            // cboParity
            // 
            this.cboParity.FormattingEnabled = true;
            this.cboParity.Items.AddRange(new object[] {
            "None",
            "Even",
            "Odd"});
            this.cboParity.Location = new System.Drawing.Point(6, 47);
            this.cboParity.Name = "cboParity";
            this.cboParity.Size = new System.Drawing.Size(121, 21);
            this.cboParity.TabIndex = 26;
            // 
            // btnBaud
            // 
            this.btnBaud.Location = new System.Drawing.Point(133, 17);
            this.btnBaud.Name = "btnBaud";
            this.btnBaud.Size = new System.Drawing.Size(86, 25);
            this.btnBaud.TabIndex = 25;
            this.btnBaud.Text = "Set Baud Rate";
            this.btnBaud.UseVisualStyleBackColor = true;
            this.btnBaud.Click += new System.EventHandler(this.btnBaud_Click);
            // 
            // cboBaud
            // 
            this.cboBaud.FormattingEnabled = true;
            this.cboBaud.Items.AddRange(new object[] {
            "1200",
            "2400",
            "4800",
            "9600",
            "19200",
            "38400",
            "57600",
            "115400"});
            this.cboBaud.Location = new System.Drawing.Point(6, 20);
            this.cboBaud.Name = "cboBaud";
            this.cboBaud.Size = new System.Drawing.Size(121, 21);
            this.cboBaud.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.listBox1);
            this.groupBox4.Location = new System.Drawing.Point(12, 297);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(342, 124);
            this.groupBox4.TabIndex = 50;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "RS232 Activity";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.HorizontalScrollbar = true;
            this.listBox1.Location = new System.Drawing.Point(9, 19);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(325, 95);
            this.listBox1.TabIndex = 0;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.lblSendAscii);
            this.groupBox7.Controls.Add(this.btnSendAscii);
            this.groupBox7.Controls.Add(this.lblPassThrough);
            this.groupBox7.Controls.Add(this.btnCmdPass);
            this.groupBox7.Controls.Add(this.chkSetRTS);
            this.groupBox7.Location = new System.Drawing.Point(357, 332);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(302, 89);
            this.groupBox7.TabIndex = 51;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Other RS232 Settings";
            // 
            // lblSendAscii
            // 
            this.lblSendAscii.AutoSize = true;
            this.lblSendAscii.Location = new System.Drawing.Point(7, 67);
            this.lblSendAscii.Name = "lblSendAscii";
            this.lblSendAscii.Size = new System.Drawing.Size(118, 13);
            this.lblSendAscii.TabIndex = 295;
            this.lblSendAscii.Text = "Send ascii to keyboard:";
            // 
            // btnSendAscii
            // 
            this.btnSendAscii.Location = new System.Drawing.Point(225, 62);
            this.btnSendAscii.Name = "btnSendAscii";
            this.btnSendAscii.Size = new System.Drawing.Size(52, 23);
            this.btnSendAscii.TabIndex = 294;
            this.btnSendAscii.Text = "Toggle";
            this.btnSendAscii.UseVisualStyleBackColor = true;
            this.btnSendAscii.Click += new System.EventHandler(this.btnSendAscii_Click);
            // 
            // lblPassThrough
            // 
            this.lblPassThrough.AutoSize = true;
            this.lblPassThrough.Location = new System.Drawing.Point(7, 43);
            this.lblPassThrough.Name = "lblPassThrough";
            this.lblPassThrough.Size = new System.Drawing.Size(181, 13);
            this.lblPassThrough.TabIndex = 293;
            this.lblPassThrough.Text = "Pass through data from COM device:";
            // 
            // btnCmdPass
            // 
            this.btnCmdPass.Location = new System.Drawing.Point(225, 38);
            this.btnCmdPass.Name = "btnCmdPass";
            this.btnCmdPass.Size = new System.Drawing.Size(52, 23);
            this.btnCmdPass.TabIndex = 292;
            this.btnCmdPass.Text = "Toggle";
            this.btnCmdPass.UseVisualStyleBackColor = true;
            this.btnCmdPass.Click += new System.EventHandler(this.btnCmdPass_Click);
            // 
            // chkSetRTS
            // 
            this.chkSetRTS.AutoSize = true;
            this.chkSetRTS.Location = new System.Drawing.Point(10, 18);
            this.chkSetRTS.Name = "chkSetRTS";
            this.chkSetRTS.Size = new System.Drawing.Size(67, 17);
            this.chkSetRTS.TabIndex = 278;
            this.chkSetRTS.Text = "Set RTS";
            this.chkSetRTS.UseVisualStyleBackColor = true;
            this.chkSetRTS.CheckedChanged += new System.EventHandler(this.chkSetRTS_CheckedChanged);
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.btnWrite);
            this.groupBox8.Controls.Add(this.txtAsciiCommand);
            this.groupBox8.Location = new System.Drawing.Point(357, 202);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(108, 89);
            this.groupBox8.TabIndex = 52;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Write to COM";
            // 
            // btnWrite
            // 
            this.btnWrite.Location = new System.Drawing.Point(6, 55);
            this.btnWrite.Name = "btnWrite";
            this.btnWrite.Size = new System.Drawing.Size(52, 23);
            this.btnWrite.TabIndex = 293;
            this.btnWrite.Text = "Write";
            this.btnWrite.UseVisualStyleBackColor = true;
            this.btnWrite.Click += new System.EventHandler(this.btnWrite_Click);
            // 
            // txtAsciiCommand
            // 
            this.txtAsciiCommand.Location = new System.Drawing.Point(6, 29);
            this.txtAsciiCommand.Name = "txtAsciiCommand";
            this.txtAsciiCommand.Size = new System.Drawing.Size(94, 20);
            this.txtAsciiCommand.TabIndex = 2;
            this.txtAsciiCommand.Text = "B8;";
            // 
            // xkRS232_1
            // 
            this.xkRS232_1.ContainerControl = this;
            this.xkRS232_1.Tag = null;
            this.xkRS232_1.ButtonChange += new XkRS232.XkRS232_.OnButtonHandler(this.xkRS232_1_ButtonChange);
            this.xkRS232_1.DataReceived += new XkRS232.XkRS232_.OnRS232ReceivedHandler(this.xkRS232_1_DataReceived);
            this.xkRS232_1.PinChange += new XkRS232.XkRS232_.OnRS232PinChangedHandler(this.xkRS232_1_PinChange);
            this.xkRS232_1.DevicePlug += new XkRS232.XkRS232_.OnDeviceChangeHandler(this.xkRS232_1_DevicePlug);
            this.xkRS232_1.DeviceUnplug += new XkRS232.XkRS232_.OnDeviceChangeHandler(this.xkRS232_1_DeviceUnplug);
            this.xkRS232_1.GenerateReportData += new XkRS232.XkRS232_.OnGenerateReportData(this.xkRS232_1_GenerateReportData);
            // 
            // chkGreen
            // 
            this.chkGreen.AutoSize = true;
            this.chkGreen.Location = new System.Drawing.Point(6, 22);
            this.chkGreen.Name = "chkGreen";
            this.chkGreen.Size = new System.Drawing.Size(55, 17);
            this.chkGreen.TabIndex = 22;
            this.chkGreen.Text = "Green";
            this.chkGreen.UseVisualStyleBackColor = true;
            this.chkGreen.CheckedChanged += new System.EventHandler(this.chkGreen_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(669, 455);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox10);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox11);
            this.Controls.Add(this.grpDongle);
            this.Controls.Add(this.groupBox9);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.statusStrip1);
            this.Name = "Form1";
            this.Text = "XC-RS232-DB9 .NET Component C# Sample";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
            this.grpDongle.ResumeLayout(false);
            this.grpDongle.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox10.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox6;
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
        private System.Windows.Forms.Button btn1257;
        private System.Windows.Forms.Button btn1260;
        private System.Windows.Forms.GroupBox groupBox9;
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
        private System.Windows.Forms.GroupBox groupBox3;
        private XkRS232.XkRS232_ xkRS232_1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Button btnParity;
        private System.Windows.Forms.ComboBox cboParity;
        private System.Windows.Forms.Button btnBaud;
        private System.Windows.Forms.ComboBox cboBaud;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.CheckBox chkSetRTS;
        private System.Windows.Forms.Label lblSendAscii;
        private System.Windows.Forms.Button btnSendAscii;
        private System.Windows.Forms.Label lblPassThrough;
        private System.Windows.Forms.Button btnCmdPass;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Button btnWrite;
        private System.Windows.Forms.TextBox txtAsciiCommand;
        private System.Windows.Forms.CheckBox chkGreen;
    }
}

