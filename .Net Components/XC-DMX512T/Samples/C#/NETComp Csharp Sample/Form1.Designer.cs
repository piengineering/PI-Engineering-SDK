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
            this.txtKeyboard = new System.Windows.Forms.TextBox();
            this.btnKeyboard = new System.Windows.Forms.Button();
            this.txtByte3 = new System.Windows.Forms.TextBox();
            this.txtByte2 = new System.Windows.Forms.TextBox();
            this.grpDongle = new System.Windows.Forms.GroupBox();
            this.txtByte4 = new System.Windows.Forms.TextBox();
            this.btnCheckDongle = new System.Windows.Forms.Button();
            this.btnSetDongle = new System.Windows.Forms.Button();
            this.txtByte1 = new System.Windows.Forms.TextBox();
            this.lblButton08 = new System.Windows.Forms.Label();
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
            this.lblButton12 = new System.Windows.Forms.Label();
            this.lblButton11 = new System.Windows.Forms.Label();
            this.lblButton10 = new System.Windows.Forms.Label();
            this.lblButton09 = new System.Windows.Forms.Label();
            this.lblButton06 = new System.Windows.Forms.Label();
            this.lblButton05 = new System.Windows.Forms.Label();
            this.lblButton04 = new System.Windows.Forms.Label();
            this.lblButton03 = new System.Windows.Forms.Label();
            this.lblButton02 = new System.Windows.Forms.Label();
            this.lblButton01 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.btnFirmwareVersion = new System.Windows.Forms.Button();
            this.lblFirmwareVersion = new System.Windows.Forms.Label();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnTransmitOnce = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblSlotVal = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSlot = new System.Windows.Forms.TextBox();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.label4 = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSetSlotVals = new System.Windows.Forms.Button();
            this.txtMaxSlots = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSetSlots = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.xkDMXT_1 = new XkDMXT.XkDMXT_(this.components);
            this.groupBox11.SuspendLayout();
            this.grpDongle.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(6, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(168, 72);
            this.label6.TabIndex = 4;
            this.label6.Text = "Reflector messages send into the hardware, then back into the OS. Device must be " +
                "in a configuration that supports the kind of input one is expecting to reflect.";
            // 
            // groupBox6
            // 
            this.groupBox6.Location = new System.Drawing.Point(12, 88);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(120, 55);
            this.groupBox6.TabIndex = 43;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Indicators";
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.txtKeyboard);
            this.groupBox11.Controls.Add(this.btnKeyboard);
            this.groupBox11.Controls.Add(this.label6);
            this.groupBox11.Location = new System.Drawing.Point(478, 151);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(181, 163);
            this.groupBox11.TabIndex = 47;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "Reflector";
            // 
            // txtKeyboard
            // 
            this.txtKeyboard.Location = new System.Drawing.Point(113, 91);
            this.txtKeyboard.Name = "txtKeyboard";
            this.txtKeyboard.Size = new System.Drawing.Size(49, 20);
            this.txtKeyboard.TabIndex = 1;
            // 
            // btnKeyboard
            // 
            this.btnKeyboard.Location = new System.Drawing.Point(10, 89);
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
            this.grpDongle.Location = new System.Drawing.Point(145, 88);
            this.grpDongle.Name = "grpDongle";
            this.grpDongle.Size = new System.Drawing.Size(327, 55);
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
            // lblButton08
            // 
            this.lblButton08.AutoSize = true;
            this.lblButton08.Location = new System.Drawing.Point(98, 40);
            this.lblButton08.Name = "lblButton08";
            this.lblButton08.Size = new System.Drawing.Size(45, 13);
            this.lblButton08.TabIndex = 7;
            this.lblButton08.Tag = "8";
            this.lblButton08.Text = "Jack 4L";
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
            this.lblButton07.Location = new System.Drawing.Point(98, 21);
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
            this.groupBox1.Size = new System.Drawing.Size(181, 150);
            this.groupBox1.TabIndex = 36;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Button Activity";
            // 
            // lblButton12
            // 
            this.lblButton12.AutoSize = true;
            this.lblButton12.Location = new System.Drawing.Point(98, 121);
            this.lblButton12.Name = "lblButton12";
            this.lblButton12.Size = new System.Drawing.Size(45, 13);
            this.lblButton12.TabIndex = 11;
            this.lblButton12.Tag = "11";
            this.lblButton12.Text = "Jack 6L";
            // 
            // lblButton11
            // 
            this.lblButton11.AutoSize = true;
            this.lblButton11.Location = new System.Drawing.Point(98, 101);
            this.lblButton11.Name = "lblButton11";
            this.lblButton11.Size = new System.Drawing.Size(47, 13);
            this.lblButton11.TabIndex = 10;
            this.lblButton11.Tag = "10";
            this.lblButton11.Text = "Jack 6R";
            // 
            // lblButton10
            // 
            this.lblButton10.AutoSize = true;
            this.lblButton10.Location = new System.Drawing.Point(98, 81);
            this.lblButton10.Name = "lblButton10";
            this.lblButton10.Size = new System.Drawing.Size(45, 13);
            this.lblButton10.TabIndex = 9;
            this.lblButton10.Tag = "9";
            this.lblButton10.Text = "Jack 5L";
            // 
            // lblButton09
            // 
            this.lblButton09.AutoSize = true;
            this.lblButton09.Location = new System.Drawing.Point(98, 61);
            this.lblButton09.Name = "lblButton09";
            this.lblButton09.Size = new System.Drawing.Size(47, 13);
            this.lblButton09.TabIndex = 8;
            this.lblButton09.Tag = "8";
            this.lblButton09.Text = "Jack 5R";
            // 
            // lblButton06
            // 
            this.lblButton06.AutoSize = true;
            this.lblButton06.Location = new System.Drawing.Point(7, 121);
            this.lblButton06.Name = "lblButton06";
            this.lblButton06.Size = new System.Drawing.Size(45, 13);
            this.lblButton06.TabIndex = 5;
            this.lblButton06.Tag = "6";
            this.lblButton06.Text = "Jack 3L";
            // 
            // lblButton05
            // 
            this.lblButton05.AutoSize = true;
            this.lblButton05.Location = new System.Drawing.Point(7, 101);
            this.lblButton05.Name = "lblButton05";
            this.lblButton05.Size = new System.Drawing.Size(47, 13);
            this.lblButton05.TabIndex = 4;
            this.lblButton05.Tag = "5";
            this.lblButton05.Text = "Jack 3R";
            // 
            // lblButton04
            // 
            this.lblButton04.AutoSize = true;
            this.lblButton04.Location = new System.Drawing.Point(7, 81);
            this.lblButton04.Name = "lblButton04";
            this.lblButton04.Size = new System.Drawing.Size(45, 13);
            this.lblButton04.TabIndex = 3;
            this.lblButton04.Tag = "4";
            this.lblButton04.Text = "Jack 2L";
            // 
            // lblButton03
            // 
            this.lblButton03.AutoSize = true;
            this.lblButton03.Location = new System.Drawing.Point(7, 61);
            this.lblButton03.Name = "lblButton03";
            this.lblButton03.Size = new System.Drawing.Size(47, 13);
            this.lblButton03.TabIndex = 2;
            this.lblButton03.Tag = "3";
            this.lblButton03.Text = "Jack 2R";
            // 
            // lblButton02
            // 
            this.lblButton02.AutoSize = true;
            this.lblButton02.Location = new System.Drawing.Point(7, 41);
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
            this.groupBox10.Controls.Add(this.btnFirmwareVersion);
            this.groupBox10.Controls.Add(this.lblFirmwareVersion);
            this.groupBox10.Controls.Add(this.btnGenerate);
            this.groupBox10.Location = new System.Drawing.Point(303, 2);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(169, 80);
            this.groupBox10.TabIndex = 48;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Other";
            // 
            // btnFirmwareVersion
            // 
            this.btnFirmwareVersion.Location = new System.Drawing.Point(6, 48);
            this.btnFirmwareVersion.Name = "btnFirmwareVersion";
            this.btnFirmwareVersion.Size = new System.Drawing.Size(117, 23);
            this.btnFirmwareVersion.TabIndex = 27;
            this.btnFirmwareVersion.Text = "Get Firmware Version";
            this.btnFirmwareVersion.UseVisualStyleBackColor = true;
            this.btnFirmwareVersion.Click += new System.EventHandler(this.btnFirmwareVersion_Click);
            // 
            // lblFirmwareVersion
            // 
            this.lblFirmwareVersion.AutoSize = true;
            this.lblFirmwareVersion.Location = new System.Drawing.Point(129, 53);
            this.lblFirmwareVersion.Name = "lblFirmwareVersion";
            this.lblFirmwareVersion.Size = new System.Drawing.Size(13, 13);
            this.lblFirmwareVersion.TabIndex = 26;
            this.lblFirmwareVersion.Tag = "4";
            this.lblFirmwareVersion.Text = "--";
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(6, 17);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(117, 25);
            this.btnGenerate.TabIndex = 24;
            this.btnGenerate.Text = "Generate Report";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnTransmitOnce);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.lblSlotVal);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.txtSlot);
            this.groupBox3.Controls.Add(this.trackBar1);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.btnStart);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.btnSetSlotVals);
            this.groupBox3.Controls.Add(this.txtMaxSlots);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.btnSetSlots);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Location = new System.Drawing.Point(12, 151);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(460, 163);
            this.groupBox3.TabIndex = 49;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "DMX Transmission";
            // 
            // btnTransmitOnce
            // 
            this.btnTransmitOnce.Location = new System.Drawing.Point(168, 123);
            this.btnTransmitOnce.Name = "btnTransmitOnce";
            this.btnTransmitOnce.Size = new System.Drawing.Size(89, 23);
            this.btnTransmitOnce.TabIndex = 20;
            this.btnTransmitOnce.Text = "Transmit Once";
            this.btnTransmitOnce.UseVisualStyleBackColor = true;
            this.btnTransmitOnce.Click += new System.EventHandler(this.btnTransmitOnce_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 105);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 13);
            this.label9.TabIndex = 19;
            this.label9.Tag = "4";
            this.label9.Text = "--OR--";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 128);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 13);
            this.label8.TabIndex = 18;
            this.label8.Tag = "4";
            this.label8.Text = "Transmit once:";
            // 
            // lblSlotVal
            // 
            this.lblSlotVal.AutoSize = true;
            this.lblSlotVal.Location = new System.Drawing.Point(383, 59);
            this.lblSlotVal.Name = "lblSlotVal";
            this.lblSlotVal.Size = new System.Drawing.Size(13, 13);
            this.lblSlotVal.TabIndex = 17;
            this.lblSlotVal.Tag = "4";
            this.lblSlotVal.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(277, 131);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 13);
            this.label5.TabIndex = 16;
            this.label5.Tag = "4";
            this.label5.Text = "Slot (1-512):";
            // 
            // txtSlot
            // 
            this.txtSlot.Location = new System.Drawing.Point(347, 128);
            this.txtSlot.Name = "txtSlot";
            this.txtSlot.Size = new System.Drawing.Size(45, 20);
            this.txtSlot.TabIndex = 15;
            this.txtSlot.Text = "1";
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(351, 18);
            this.trackBar1.Maximum = 255;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBar1.Size = new System.Drawing.Size(45, 104);
            this.trackBar1.TabIndex = 14;
            this.trackBar1.TickFrequency = 17;
            this.trackBar1.ValueChanged += new System.EventHandler(this.trackBar1_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(263, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 13);
            this.label4.TabIndex = 13;
            this.label4.Tag = "4";
            this.label4.Text = "or set with slider";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(209, 76);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(48, 23);
            this.btnStart.TabIndex = 12;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Set values for the slots:";
            // 
            // btnSetSlotVals
            // 
            this.btnSetSlotVals.Location = new System.Drawing.Point(209, 47);
            this.btnSetSlotVals.Name = "btnSetSlotVals";
            this.btnSetSlotVals.Size = new System.Drawing.Size(48, 23);
            this.btnSetSlotVals.TabIndex = 10;
            this.btnSetSlotVals.Text = "Set";
            this.btnSetSlotVals.UseVisualStyleBackColor = true;
            this.btnSetSlotVals.Click += new System.EventHandler(this.btnSetSlotVals_Click);
            // 
            // txtMaxSlots
            // 
            this.txtMaxSlots.Location = new System.Drawing.Point(161, 21);
            this.txtMaxSlots.Name = "txtMaxSlots";
            this.txtMaxSlots.Size = new System.Drawing.Size(42, 20);
            this.txtMaxSlots.TabIndex = 9;
            this.txtMaxSlots.Text = "32";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Set number of slots (512 max):";
            // 
            // btnSetSlots
            // 
            this.btnSetSlots.Location = new System.Drawing.Point(209, 18);
            this.btnSetSlots.Name = "btnSetSlots";
            this.btnSetSlots.Size = new System.Drawing.Size(48, 23);
            this.btnSetSlots.TabIndex = 5;
            this.btnSetSlots.Text = "Set";
            this.btnSetSlots.UseVisualStyleBackColor = true;
            this.btnSetSlots.Click += new System.EventHandler(this.btnSetSlots_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(182, 13);
            this.label1.TabIndex = 4;
            this.label1.Tag = "4";
            this.label1.Text = "Start or stop continuous transmission:";
            // 
            // xkDMXT_1
            // 
            this.xkDMXT_1.ContainerControl = this;
            this.xkDMXT_1.Tag = null;
            this.xkDMXT_1.ButtonChange += new XkDMXT.XkDMXT_.OnButtonHandler(this.xkDMXT_1_ButtonChange);
            this.xkDMXT_1.DevicePlug += new XkDMXT.XkDMXT_.OnDeviceChangeHandler(this.xkDMXT_1_DevicePlug);
            this.xkDMXT_1.DeviceUnplug += new XkDMXT.XkDMXT_.OnDeviceChangeHandler(this.xkDMXT_1_DeviceUnplug);
            this.xkDMXT_1.GenerateReportData += new XkDMXT.XkDMXT_.OnGenerateReportData(this.xkDMXT_1_GenerateReportData);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(669, 356);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox10);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox11);
            this.Controls.Add(this.grpDongle);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.statusStrip1);
            this.Name = "Form1";
            this.Text = "DMX512T-RJ45 and XC-DMX512T-ST .NET Component C# Sample";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
            this.grpDongle.ResumeLayout(false);
            this.grpDongle.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.GroupBox groupBox11;
        private System.Windows.Forms.TextBox txtKeyboard;
        private System.Windows.Forms.Button btnKeyboard;
        private System.Windows.Forms.TextBox txtByte3;
        private System.Windows.Forms.TextBox txtByte2;
        private System.Windows.Forms.GroupBox grpDongle;
        private System.Windows.Forms.TextBox txtByte4;
        private System.Windows.Forms.Button btnCheckDongle;
        private System.Windows.Forms.Button btnSetDongle;
        private System.Windows.Forms.TextBox txtByte1;
        private System.Windows.Forms.Label lblButton08;
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
        private System.Windows.Forms.TextBox txtMaxSlots;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSetSlots;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSetSlotVals;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSlot;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label lblFirmwareVersion;
        private System.Windows.Forms.Button btnFirmwareVersion;
        private System.Windows.Forms.Label lblSlotVal;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnTransmitOnce;
        private XkDMXT.XkDMXT_ xkDMXT_1;
        private System.Windows.Forms.Label lblButton12;
        private System.Windows.Forms.Label lblButton11;
        private System.Windows.Forms.Label lblButton10;
        private System.Windows.Forms.Label lblButton09;
    }
}

