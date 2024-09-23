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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.BtnEnumerate = new System.Windows.Forms.Button();
            this.CboDevices = new System.Windows.Forms.ComboBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.BtnCallback = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label21 = new System.Windows.Forms.Label();
            this.BtnDescriptor = new System.Windows.Forms.Button();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.ChkSuppress = new System.Windows.Forms.CheckBox();
            this.lblUSBCheckState = new System.Windows.Forms.Label();
            this.btnUSBCheckOff = new System.Windows.Forms.Button();
            this.label66 = new System.Windows.Forms.Label();
            this.btnUSBCheckOn = new System.Windows.Forms.Button();
            this.lblReawakeState = new System.Windows.Forms.Label();
            this.btnSleepDisabled = new System.Windows.Forms.Button();
            this.label64 = new System.Windows.Forms.Label();
            this.btnSleepEnabled = new System.Windows.Forms.Button();
            this.lblJsonState = new System.Windows.Forms.Label();
            this.btnJsonOff = new System.Windows.Forms.Button();
            this.btnJsonOn = new System.Windows.Forms.Button();
            this.lblEchoState = new System.Windows.Forms.Label();
            this.btnEchoOff = new System.Windows.Forms.Button();
            this.btnEchoOn = new System.Windows.Forms.Button();
            this.label36 = new System.Windows.Forms.Label();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.txtSendText = new System.Windows.Forms.TextBox();
            this.btnWriteXkeysTx = new System.Windows.Forms.Button();
            this.label51 = new System.Windows.Forms.Label();
            this.cboBaudRate = new System.Windows.Forms.ComboBox();
            this.btnRS232Settings = new System.Windows.Forms.Button();
            this.cboParity = new System.Windows.Forms.ComboBox();
            this.cboDataBits = new System.Windows.Forms.ComboBox();
            this.label52 = new System.Windows.Forms.Label();
            this.label53 = new System.Windows.Forms.Label();
            this.label54 = new System.Windows.Forms.Label();
            this.label56 = new System.Windows.Forms.Label();
            this.cboStopBits = new System.Windows.Forms.ComboBox();
            this.btnReadRS232Settings = new System.Windows.Forms.Button();
            this.label59 = new System.Windows.Forms.Label();
            this.BtnBLToggle = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label49 = new System.Windows.Forms.Label();
            this.lblEncoded = new System.Windows.Forms.Label();
            this.btnCOMPortInternal = new System.Windows.Forms.Button();
            this.txtBase64Encode = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.listBox5 = new System.Windows.Forms.ListBox();
            this.CboPorts = new System.Windows.Forms.ComboBox();
            this.label31 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.btnCOMPortUSB = new System.Windows.Forms.Button();
            this.label46 = new System.Windows.Forms.Label();
            this.txtSendCOMUSB = new System.Windows.Forms.TextBox();
            this.cboCOMBaud = new System.Windows.Forms.ComboBox();
            this.label57 = new System.Windows.Forms.Label();
            this.cboCOMParity = new System.Windows.Forms.ComboBox();
            this.cboCOMData = new System.Windows.Forms.ComboBox();
            this.label68 = new System.Windows.Forms.Label();
            this.label67 = new System.Windows.Forms.Label();
            this.label65 = new System.Windows.Forms.Label();
            this.cboCOMStop = new System.Windows.Forms.ComboBox();
            this.label63 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label55 = new System.Windows.Forms.Label();
            this.label58 = new System.Windows.Forms.Label();
            this.label45 = new System.Windows.Forms.Label();
            this.label50 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnEnableUART = new System.Windows.Forms.Button();
            this.btnDisableUART = new System.Windows.Forms.Button();
            this.lblUART = new System.Windows.Forms.Label();
            this.btnLoopBack = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label48 = new System.Windows.Forms.Label();
            this.cboRGBIndex = new System.Windows.Forms.ComboBox();
            this.txtB = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cboBank = new System.Windows.Forms.ComboBox();
            this.btnSetAllBank2 = new System.Windows.Forms.Button();
            this.btnSetAllBank1 = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.btnSetRGB = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtG = new System.Windows.Forms.TextBox();
            this.txtR = new System.Windows.Forms.TextBox();
            this.chkRGBFlash = new System.Windows.Forms.CheckBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.LblButtons = new System.Windows.Forms.Label();
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
            this.listBox1.Size = new System.Drawing.Size(480, 82);
            this.listBox1.TabIndex = 6;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 712);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 10, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1541, 22);
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
            this.BtnCallback.TabIndex = 10;
            this.BtnCallback.Text = "Setup for Callback";
            this.BtnCallback.UseVisualStyleBackColor = true;
            this.BtnCallback.Click += new System.EventHandler(this.BtnCallback_Click);
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
            this.button1.Location = new System.Drawing.Point(408, 92);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(93, 22);
            this.button1.TabIndex = 21;
            this.button1.Text = "Clear Listbox";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(8, 445);
            this.label21.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(55, 13);
            this.label21.TabIndex = 61;
            this.label21.Text = "Descriptor";
            // 
            // BtnDescriptor
            // 
            this.BtnDescriptor.Location = new System.Drawing.Point(21, 467);
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
            this.listBox2.HorizontalScrollbar = true;
            this.listBox2.Location = new System.Drawing.Point(117, 467);
            this.listBox2.Margin = new System.Windows.Forms.Padding(2);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(327, 82);
            this.listBox2.TabIndex = 63;
            // 
            // ChkSuppress
            // 
            this.ChkSuppress.AutoSize = true;
            this.ChkSuppress.Location = new System.Drawing.Point(148, 96);
            this.ChkSuppress.Name = "ChkSuppress";
            this.ChkSuppress.Size = new System.Drawing.Size(158, 17);
            this.ChkSuppress.TabIndex = 152;
            this.ChkSuppress.Text = "Suppress Duplicate Reports";
            this.ChkSuppress.UseVisualStyleBackColor = true;
            this.ChkSuppress.CheckedChanged += new System.EventHandler(this.ChkSuppress_CheckedChanged);
            // 
            // lblUSBCheckState
            // 
            this.lblUSBCheckState.AutoSize = true;
            this.lblUSBCheckState.Location = new System.Drawing.Point(788, 300);
            this.lblUSBCheckState.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUSBCheckState.Name = "lblUSBCheckState";
            this.lblUSBCheckState.Size = new System.Drawing.Size(83, 13);
            this.lblUSBCheckState.TabIndex = 582;
            this.lblUSBCheckState.Text = "usb check state";
            // 
            // btnUSBCheckOff
            // 
            this.btnUSBCheckOff.Location = new System.Drawing.Point(679, 295);
            this.btnUSBCheckOff.Name = "btnUSBCheckOff";
            this.btnUSBCheckOff.Size = new System.Drawing.Size(104, 23);
            this.btnUSBCheckOff.TabIndex = 581;
            this.btnUSBCheckOff.Text = "Check Disabled";
            this.btnUSBCheckOff.UseVisualStyleBackColor = true;
            this.btnUSBCheckOff.Click += new System.EventHandler(this.btnUSBCheckOff_Click);
            // 
            // label66
            // 
            this.label66.AutoSize = true;
            this.label66.Location = new System.Drawing.Point(562, 276);
            this.label66.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label66.Name = "label66";
            this.label66.Size = new System.Drawing.Size(359, 13);
            this.label66.TabIndex = 580;
            this.label66.Text = "USB Check - set check disable if using the USB connection for power only";
            // 
            // btnUSBCheckOn
            // 
            this.btnUSBCheckOn.Location = new System.Drawing.Point(562, 295);
            this.btnUSBCheckOn.Name = "btnUSBCheckOn";
            this.btnUSBCheckOn.Size = new System.Drawing.Size(104, 23);
            this.btnUSBCheckOn.TabIndex = 579;
            this.btnUSBCheckOn.Text = "Check Enabled";
            this.btnUSBCheckOn.UseVisualStyleBackColor = true;
            this.btnUSBCheckOn.Click += new System.EventHandler(this.btnUSBCheckOn_Click);
            // 
            // lblReawakeState
            // 
            this.lblReawakeState.AutoSize = true;
            this.lblReawakeState.Location = new System.Drawing.Point(788, 234);
            this.lblReawakeState.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblReawakeState.Name = "lblReawakeState";
            this.lblReawakeState.Size = new System.Drawing.Size(58, 13);
            this.lblReawakeState.TabIndex = 578;
            this.lblReawakeState.Text = "sleep state";
            // 
            // btnSleepDisabled
            // 
            this.btnSleepDisabled.Location = new System.Drawing.Point(679, 229);
            this.btnSleepDisabled.Name = "btnSleepDisabled";
            this.btnSleepDisabled.Size = new System.Drawing.Size(104, 23);
            this.btnSleepDisabled.TabIndex = 577;
            this.btnSleepDisabled.Text = "Sleep Disabled";
            this.btnSleepDisabled.UseVisualStyleBackColor = true;
            this.btnSleepDisabled.Click += new System.EventHandler(this.btnSleepDisabled_Click);
            // 
            // label64
            // 
            this.label64.Location = new System.Drawing.Point(562, 197);
            this.label64.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label64.Name = "label64";
            this.label64.Size = new System.Drawing.Size(454, 31);
            this.label64.TabIndex = 576;
            this.label64.Text = "USB Sleep - If sleep enabled  the X-keys will turn off its LEDs and any GPIO outp" +
                "ut pins when a USB suspend condition occurs. To override this behavior set sleep" +
                " disable";
            // 
            // btnSleepEnabled
            // 
            this.btnSleepEnabled.Location = new System.Drawing.Point(562, 229);
            this.btnSleepEnabled.Name = "btnSleepEnabled";
            this.btnSleepEnabled.Size = new System.Drawing.Size(104, 23);
            this.btnSleepEnabled.TabIndex = 575;
            this.btnSleepEnabled.Text = "Sleep Enabled";
            this.btnSleepEnabled.UseVisualStyleBackColor = true;
            this.btnSleepEnabled.Click += new System.EventHandler(this.btnSleepEnabled_Click);
            // 
            // lblJsonState
            // 
            this.lblJsonState.AutoSize = true;
            this.lblJsonState.Location = new System.Drawing.Point(788, 161);
            this.lblJsonState.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblJsonState.Name = "lblJsonState";
            this.lblJsonState.Size = new System.Drawing.Size(30, 13);
            this.lblJsonState.TabIndex = 573;
            this.lblJsonState.Text = "state";
            // 
            // btnJsonOff
            // 
            this.btnJsonOff.Location = new System.Drawing.Point(674, 156);
            this.btnJsonOff.Name = "btnJsonOff";
            this.btnJsonOff.Size = new System.Drawing.Size(103, 23);
            this.btnJsonOff.TabIndex = 572;
            this.btnJsonOff.Text = "Input Reports Off";
            this.btnJsonOff.UseVisualStyleBackColor = true;
            this.btnJsonOff.Click += new System.EventHandler(this.btnJsonOff_Click);
            // 
            // btnJsonOn
            // 
            this.btnJsonOn.Location = new System.Drawing.Point(562, 156);
            this.btnJsonOn.Name = "btnJsonOn";
            this.btnJsonOn.Size = new System.Drawing.Size(104, 23);
            this.btnJsonOn.TabIndex = 570;
            this.btnJsonOn.Text = "Input Reports On";
            this.btnJsonOn.UseVisualStyleBackColor = true;
            this.btnJsonOn.Click += new System.EventHandler(this.btnJsonOn_Click);
            // 
            // lblEchoState
            // 
            this.lblEchoState.AutoSize = true;
            this.lblEchoState.Location = new System.Drawing.Point(788, 87);
            this.lblEchoState.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEchoState.Name = "lblEchoState";
            this.lblEchoState.Size = new System.Drawing.Size(57, 13);
            this.lblEchoState.TabIndex = 569;
            this.lblEchoState.Text = "echo state";
            // 
            // btnEchoOff
            // 
            this.btnEchoOff.Location = new System.Drawing.Point(674, 82);
            this.btnEchoOff.Name = "btnEchoOff";
            this.btnEchoOff.Size = new System.Drawing.Size(104, 23);
            this.btnEchoOff.TabIndex = 568;
            this.btnEchoOff.Text = "Echo Off";
            this.btnEchoOff.UseVisualStyleBackColor = true;
            this.btnEchoOff.Click += new System.EventHandler(this.btnEchoOff_Click);
            // 
            // btnEchoOn
            // 
            this.btnEchoOn.Location = new System.Drawing.Point(562, 82);
            this.btnEchoOn.Name = "btnEchoOn";
            this.btnEchoOn.Size = new System.Drawing.Size(104, 23);
            this.btnEchoOn.TabIndex = 566;
            this.btnEchoOn.Text = "Echo On";
            this.btnEchoOn.UseVisualStyleBackColor = true;
            this.btnEchoOn.Click += new System.EventHandler(this.btnEchoOn_Click);
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(552, 16);
            this.label36.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(113, 13);
            this.label36.TabIndex = 564;
            this.label36.Text = "X-keys UART Settings";
            // 
            // serialPort1
            // 
            this.serialPort1.BaudRate = 230400;
            this.serialPort1.PortName = "COM10";
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // txtSendText
            // 
            this.txtSendText.Location = new System.Drawing.Point(565, 572);
            this.txtSendText.Name = "txtSendText";
            this.txtSendText.Size = new System.Drawing.Size(222, 20);
            this.txtSendText.TabIndex = 609;
            this.txtSendText.Text = "abc";
            // 
            // btnWriteXkeysTx
            // 
            this.btnWriteXkeysTx.Location = new System.Drawing.Point(798, 570);
            this.btnWriteXkeysTx.Name = "btnWriteXkeysTx";
            this.btnWriteXkeysTx.Size = new System.Drawing.Size(118, 22);
            this.btnWriteXkeysTx.TabIndex = 610;
            this.btnWriteXkeysTx.Text = "Write to X-keys TX";
            this.btnWriteXkeysTx.UseVisualStyleBackColor = true;
            this.btnWriteXkeysTx.Click += new System.EventHandler(this.btnWriteXkeysTx_Click);
            // 
            // label51
            // 
            this.label51.AutoSize = true;
            this.label51.Location = new System.Drawing.Point(562, 556);
            this.label51.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(156, 13);
            this.label51.TabIndex = 612;
            this.label51.Text = "Transmit from X-keys Serial Port";
            // 
            // cboBaudRate
            // 
            this.cboBaudRate.FormattingEnabled = true;
            this.cboBaudRate.Items.AddRange(new object[] {
            "300",
            "1200",
            "2400",
            "4800",
            "9600",
            "19200",
            "38400",
            "57600",
            "115200",
            "230400"});
            this.cboBaudRate.Location = new System.Drawing.Point(562, 426);
            this.cboBaudRate.Name = "cboBaudRate";
            this.cboBaudRate.Size = new System.Drawing.Size(83, 21);
            this.cboBaudRate.TabIndex = 613;
            // 
            // btnRS232Settings
            // 
            this.btnRS232Settings.Location = new System.Drawing.Point(889, 425);
            this.btnRS232Settings.Name = "btnRS232Settings";
            this.btnRS232Settings.Size = new System.Drawing.Size(134, 22);
            this.btnRS232Settings.TabIndex = 615;
            this.btnRS232Settings.Text = "Change RS232 Settings";
            this.btnRS232Settings.UseVisualStyleBackColor = true;
            this.btnRS232Settings.Click += new System.EventHandler(this.btnRS232Settings_Click);
            // 
            // cboParity
            // 
            this.cboParity.FormattingEnabled = true;
            this.cboParity.Items.AddRange(new object[] {
            "even",
            "odd",
            "none"});
            this.cboParity.Location = new System.Drawing.Point(651, 426);
            this.cboParity.Name = "cboParity";
            this.cboParity.Size = new System.Drawing.Size(74, 21);
            this.cboParity.TabIndex = 616;
            // 
            // cboDataBits
            // 
            this.cboDataBits.FormattingEnabled = true;
            this.cboDataBits.Items.AddRange(new object[] {
            "5",
            "6",
            "7",
            "8"});
            this.cboDataBits.Location = new System.Drawing.Point(730, 426);
            this.cboDataBits.Name = "cboDataBits";
            this.cboDataBits.Size = new System.Drawing.Size(74, 21);
            this.cboDataBits.TabIndex = 617;
            // 
            // label52
            // 
            this.label52.AutoSize = true;
            this.label52.Location = new System.Drawing.Point(562, 410);
            this.label52.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(58, 13);
            this.label52.TabIndex = 618;
            this.label52.Text = "Baud Rate";
            // 
            // label53
            // 
            this.label53.AutoSize = true;
            this.label53.Location = new System.Drawing.Point(650, 410);
            this.label53.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(33, 13);
            this.label53.TabIndex = 619;
            this.label53.Text = "Parity";
            // 
            // label54
            // 
            this.label54.AutoSize = true;
            this.label54.Location = new System.Drawing.Point(729, 410);
            this.label54.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(50, 13);
            this.label54.TabIndex = 620;
            this.label54.Text = "Data Bits";
            // 
            // label56
            // 
            this.label56.AutoSize = true;
            this.label56.Location = new System.Drawing.Point(808, 410);
            this.label56.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(49, 13);
            this.label56.TabIndex = 622;
            this.label56.Text = "Stop Bits";
            // 
            // cboStopBits
            // 
            this.cboStopBits.FormattingEnabled = true;
            this.cboStopBits.Items.AddRange(new object[] {
            "1",
            "1.5",
            "2"});
            this.cboStopBits.Location = new System.Drawing.Point(809, 426);
            this.cboStopBits.Name = "cboStopBits";
            this.cboStopBits.Size = new System.Drawing.Size(74, 21);
            this.cboStopBits.TabIndex = 621;
            // 
            // btnReadRS232Settings
            // 
            this.btnReadRS232Settings.Location = new System.Drawing.Point(562, 378);
            this.btnReadRS232Settings.Margin = new System.Windows.Forms.Padding(2);
            this.btnReadRS232Settings.Name = "btnReadRS232Settings";
            this.btnReadRS232Settings.Size = new System.Drawing.Size(121, 22);
            this.btnReadRS232Settings.TabIndex = 623;
            this.btnReadRS232Settings.Text = "Read RS232 Settings";
            this.btnReadRS232Settings.UseVisualStyleBackColor = true;
            this.btnReadRS232Settings.Click += new System.EventHandler(this.btnReadRS232Settings_Click);
            // 
            // label59
            // 
            this.label59.Location = new System.Drawing.Point(562, 343);
            this.label59.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(432, 33);
            this.label59.TabIndex = 624;
            this.label59.Text = "Read or change X-keys RS232 Settings - results listed in combo boxes below or sel" +
                "ect desired settings from combo boxes then click Change RS232 Settings";
            // 
            // BtnBLToggle
            // 
            this.BtnBLToggle.Location = new System.Drawing.Point(21, 397);
            this.BtnBLToggle.Margin = new System.Windows.Forms.Padding(2);
            this.BtnBLToggle.Name = "BtnBLToggle";
            this.BtnBLToggle.Size = new System.Drawing.Size(92, 22);
            this.BtnBLToggle.TabIndex = 625;
            this.BtnBLToggle.Text = "Toggle";
            this.BtnBLToggle.UseVisualStyleBackColor = true;
            this.BtnBLToggle.Click += new System.EventHandler(this.BtnBLToggle_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 371);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 13);
            this.label4.TabIndex = 626;
            this.label4.Text = "Toggle Backlights";
            // 
            // label49
            // 
            this.label49.AutoSize = true;
            this.label49.Location = new System.Drawing.Point(1098, 378);
            this.label49.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(202, 13);
            this.label49.TabIndex = 587;
            this.label49.Text = "Bytes in comma separated hex to encode";
            // 
            // lblEncoded
            // 
            this.lblEncoded.AutoSize = true;
            this.lblEncoded.Location = new System.Drawing.Point(1096, 416);
            this.lblEncoded.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEncoded.Name = "lblEncoded";
            this.lblEncoded.Size = new System.Drawing.Size(77, 13);
            this.lblEncoded.TabIndex = 590;
            this.lblEncoded.Text = "encoded bytes";
            // 
            // btnCOMPortInternal
            // 
            this.btnCOMPortInternal.Location = new System.Drawing.Point(1329, 390);
            this.btnCOMPortInternal.Name = "btnCOMPortInternal";
            this.btnCOMPortInternal.Size = new System.Drawing.Size(75, 23);
            this.btnCOMPortInternal.TabIndex = 584;
            this.btnCOMPortInternal.Text = "Write";
            this.btnCOMPortInternal.UseVisualStyleBackColor = true;
            this.btnCOMPortInternal.Click += new System.EventHandler(this.btnCOMPortInternal_Click);
            // 
            // txtBase64Encode
            // 
            this.txtBase64Encode.Location = new System.Drawing.Point(1096, 392);
            this.txtBase64Encode.Name = "txtBase64Encode";
            this.txtBase64Encode.Size = new System.Drawing.Size(222, 20);
            this.txtBase64Encode.TabIndex = 583;
            this.txtBase64Encode.Text = "B8, 00, 00";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(1096, 214);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(108, 13);
            this.label25.TabIndex = 598;
            this.label25.Text = "Incoming Serial Data:";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(1372, 204);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 599;
            this.button3.Text = "Clear";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // listBox5
            // 
            this.listBox5.FormattingEnabled = true;
            this.listBox5.HorizontalScrollbar = true;
            this.listBox5.Location = new System.Drawing.Point(1096, 230);
            this.listBox5.Name = "listBox5";
            this.listBox5.Size = new System.Drawing.Size(349, 69);
            this.listBox5.TabIndex = 600;
            // 
            // CboPorts
            // 
            this.CboPorts.FormattingEnabled = true;
            this.CboPorts.Location = new System.Drawing.Point(1096, 90);
            this.CboPorts.Name = "CboPorts";
            this.CboPorts.Size = new System.Drawing.Size(83, 21);
            this.CboPorts.TabIndex = 601;
            this.CboPorts.SelectedIndexChanged += new System.EventHandler(this.CboPorts_SelectedIndexChanged);
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(1096, 74);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(85, 13);
            this.label31.TabIndex = 602;
            this.label31.Text = "Select COM port";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(1095, 201);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(84, 13);
            this.label35.TabIndex = 603;
            this.label35.Text = "Read UART RX";
            // 
            // btnCOMPortUSB
            // 
            this.btnCOMPortUSB.Location = new System.Drawing.Point(1326, 321);
            this.btnCOMPortUSB.Name = "btnCOMPortUSB";
            this.btnCOMPortUSB.Size = new System.Drawing.Size(75, 23);
            this.btnCOMPortUSB.TabIndex = 605;
            this.btnCOMPortUSB.Text = "Write";
            this.btnCOMPortUSB.UseVisualStyleBackColor = true;
            this.btnCOMPortUSB.Click += new System.EventHandler(this.btnCOMPortUSB_Click);
            // 
            // label46
            // 
            this.label46.Location = new System.Drawing.Point(1096, 39);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(361, 28);
            this.label46.TabIndex = 606;
            this.label46.Text = "The following is for directly communicating with the serial port via a  serial to" +
                " USB converter*";
            // 
            // txtSendCOMUSB
            // 
            this.txtSendCOMUSB.Location = new System.Drawing.Point(1096, 323);
            this.txtSendCOMUSB.Name = "txtSendCOMUSB";
            this.txtSendCOMUSB.Size = new System.Drawing.Size(222, 20);
            this.txtSendCOMUSB.TabIndex = 610;
            this.txtSendCOMUSB.Text = "def";
            // 
            // cboCOMBaud
            // 
            this.cboCOMBaud.FormattingEnabled = true;
            this.cboCOMBaud.Items.AddRange(new object[] {
            "300",
            "1200",
            "2400",
            "4800",
            "9600",
            "19200",
            "38400",
            "57600",
            "115200",
            "230400"});
            this.cboCOMBaud.Location = new System.Drawing.Point(1096, 158);
            this.cboCOMBaud.Name = "cboCOMBaud";
            this.cboCOMBaud.Size = new System.Drawing.Size(83, 21);
            this.cboCOMBaud.TabIndex = 612;
            this.cboCOMBaud.SelectedIndexChanged += new System.EventHandler(this.cboCOMBaud_SelectedIndexChanged);
            // 
            // label57
            // 
            this.label57.AutoSize = true;
            this.label57.Location = new System.Drawing.Point(1096, 123);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(230, 13);
            this.label57.TabIndex = 613;
            this.label57.Text = "Match COM port settings to those of the X-keys";
            // 
            // cboCOMParity
            // 
            this.cboCOMParity.FormattingEnabled = true;
            this.cboCOMParity.Items.AddRange(new object[] {
            "even",
            "odd",
            "none"});
            this.cboCOMParity.Location = new System.Drawing.Point(1188, 158);
            this.cboCOMParity.Name = "cboCOMParity";
            this.cboCOMParity.Size = new System.Drawing.Size(74, 21);
            this.cboCOMParity.TabIndex = 623;
            this.cboCOMParity.SelectedIndexChanged += new System.EventHandler(this.cboCOMParity_SelectedIndexChanged);
            // 
            // cboCOMData
            // 
            this.cboCOMData.FormattingEnabled = true;
            this.cboCOMData.Items.AddRange(new object[] {
            "5",
            "6",
            "7",
            "8"});
            this.cboCOMData.Location = new System.Drawing.Point(1268, 158);
            this.cboCOMData.Name = "cboCOMData";
            this.cboCOMData.Size = new System.Drawing.Size(74, 21);
            this.cboCOMData.TabIndex = 624;
            this.cboCOMData.SelectedIndexChanged += new System.EventHandler(this.cboCOMData_SelectedIndexChanged);
            // 
            // label68
            // 
            this.label68.AutoSize = true;
            this.label68.Location = new System.Drawing.Point(1096, 142);
            this.label68.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label68.Name = "label68";
            this.label68.Size = new System.Drawing.Size(58, 13);
            this.label68.TabIndex = 625;
            this.label68.Text = "Baud Rate";
            // 
            // label67
            // 
            this.label67.AutoSize = true;
            this.label67.Location = new System.Drawing.Point(1188, 142);
            this.label67.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label67.Name = "label67";
            this.label67.Size = new System.Drawing.Size(33, 13);
            this.label67.TabIndex = 626;
            this.label67.Text = "Parity";
            // 
            // label65
            // 
            this.label65.AutoSize = true;
            this.label65.Location = new System.Drawing.Point(1268, 142);
            this.label65.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label65.Name = "label65";
            this.label65.Size = new System.Drawing.Size(50, 13);
            this.label65.TabIndex = 627;
            this.label65.Text = "Data Bits";
            // 
            // cboCOMStop
            // 
            this.cboCOMStop.FormattingEnabled = true;
            this.cboCOMStop.Items.AddRange(new object[] {
            "1",
            "1.5",
            "2"});
            this.cboCOMStop.Location = new System.Drawing.Point(1348, 158);
            this.cboCOMStop.Name = "cboCOMStop";
            this.cboCOMStop.Size = new System.Drawing.Size(74, 21);
            this.cboCOMStop.TabIndex = 628;
            this.cboCOMStop.SelectedIndexChanged += new System.EventHandler(this.cboCOMStop_SelectedIndexChanged);
            // 
            // label63
            // 
            this.label63.AutoSize = true;
            this.label63.Location = new System.Drawing.Point(1348, 142);
            this.label63.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label63.Name = "label63";
            this.label63.Size = new System.Drawing.Size(49, 13);
            this.label63.TabIndex = 629;
            this.label63.Text = "Stop Bits";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1086, 16);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(118, 13);
            this.label5.TabIndex = 630;
            this.label5.Text = "USB COM Port Adapter";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(1096, 453);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(410, 223);
            this.label6.TabIndex = 631;
            this.label6.Text = resources.GetString("label6.Text");
            // 
            // label55
            // 
            this.label55.Location = new System.Drawing.Point(562, 39);
            this.label55.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(455, 40);
            this.label55.TabIndex = 685;
            this.label55.Text = resources.GetString("label55.Text");
            // 
            // label58
            // 
            this.label58.Location = new System.Drawing.Point(562, 114);
            this.label58.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(453, 40);
            this.label58.TabIndex = 686;
            this.label58.Text = "UART PI Base64 Input Report Transmit Messages - If on then any standard input rep" +
                "ort will be accompanied by a corresponding UART PI Base64 Input Report Transmit " +
                "Message sent out on the X-keys TX";
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Location = new System.Drawing.Point(1096, 307);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(395, 13);
            this.label45.TabIndex = 687;
            this.label45.Text = "Write a message to be received by X-keys as a UART Custom Received Message";
            // 
            // label50
            // 
            this.label50.AutoSize = true;
            this.label50.Location = new System.Drawing.Point(1096, 363);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(427, 13);
            this.label50.TabIndex = 688;
            this.label50.Text = "Write a message to be received by X-keys as a UART Output Report Received Message" +
                "";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(562, 472);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(432, 28);
            this.label3.TabIndex = 690;
            this.label3.Text = "Enable or Disable UART for RS232 Communication. The UART should only be enabled i" +
                "f something is connected to the UART port.";
            // 
            // btnEnableUART
            // 
            this.btnEnableUART.Location = new System.Drawing.Point(562, 504);
            this.btnEnableUART.Name = "btnEnableUART";
            this.btnEnableUART.Size = new System.Drawing.Size(118, 23);
            this.btnEnableUART.TabIndex = 691;
            this.btnEnableUART.Text = "Enable UART";
            this.btnEnableUART.UseVisualStyleBackColor = true;
            this.btnEnableUART.Click += new System.EventHandler(this.btnEnableUART_Click);
            // 
            // btnDisableUART
            // 
            this.btnDisableUART.Location = new System.Drawing.Point(689, 504);
            this.btnDisableUART.Name = "btnDisableUART";
            this.btnDisableUART.Size = new System.Drawing.Size(118, 23);
            this.btnDisableUART.TabIndex = 692;
            this.btnDisableUART.Text = "Disable UART";
            this.btnDisableUART.UseVisualStyleBackColor = true;
            this.btnDisableUART.Click += new System.EventHandler(this.btnDisableUART_Click);
            // 
            // lblUART
            // 
            this.lblUART.AutoSize = true;
            this.lblUART.Location = new System.Drawing.Point(813, 509);
            this.lblUART.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUART.Name = "lblUART";
            this.lblUART.Size = new System.Drawing.Size(51, 13);
            this.lblUART.TabIndex = 693;
            this.lblUART.Text = "uart state";
            // 
            // btnLoopBack
            // 
            this.btnLoopBack.Location = new System.Drawing.Point(565, 630);
            this.btnLoopBack.Name = "btnLoopBack";
            this.btnLoopBack.Size = new System.Drawing.Size(118, 23);
            this.btnLoopBack.TabIndex = 694;
            this.btnLoopBack.Text = "Loop Back Test";
            this.btnLoopBack.UseVisualStyleBackColor = true;
            this.btnLoopBack.Click += new System.EventHandler(this.btnLoopBack_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(562, 612);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(293, 13);
            this.label7.TabIndex = 696;
            this.label7.Text = "X-keys loop back test. Connect the X-keys RX to X-keys TX.";
            // 
            // label48
            // 
            this.label48.AutoSize = true;
            this.label48.Location = new System.Drawing.Point(296, 260);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(40, 13);
            this.label48.TabIndex = 715;
            this.label48.Text = "(0-255)";
            // 
            // cboRGBIndex
            // 
            this.cboRGBIndex.FormattingEnabled = true;
            this.cboRGBIndex.Items.AddRange(new object[] {
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
            "95"});
            this.cboRGBIndex.Location = new System.Drawing.Point(21, 301);
            this.cboRGBIndex.Name = "cboRGBIndex";
            this.cboRGBIndex.Size = new System.Drawing.Size(66, 21);
            this.cboRGBIndex.TabIndex = 714;
            // 
            // txtB
            // 
            this.txtB.Location = new System.Drawing.Point(238, 257);
            this.txtB.Name = "txtB";
            this.txtB.Size = new System.Drawing.Size(52, 20);
            this.txtB.TabIndex = 713;
            this.txtB.Text = "3";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(90, 284);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 712;
            this.label8.Text = "Bank:";
            // 
            // cboBank
            // 
            this.cboBank.FormattingEnabled = true;
            this.cboBank.Items.AddRange(new object[] {
            "bank 1 (top)",
            "bank 2 (bottom)",
            "both"});
            this.cboBank.Location = new System.Drawing.Point(93, 300);
            this.cboBank.Name = "cboBank";
            this.cboBank.Size = new System.Drawing.Size(97, 21);
            this.cboBank.TabIndex = 711;
            // 
            // btnSetAllBank2
            // 
            this.btnSetAllBank2.Location = new System.Drawing.Point(121, 327);
            this.btnSetAllBank2.Name = "btnSetAllBank2";
            this.btnSetAllBank2.Size = new System.Drawing.Size(89, 23);
            this.btnSetAllBank2.TabIndex = 710;
            this.btnSetAllBank2.Text = "Set All Bank 2";
            this.btnSetAllBank2.UseVisualStyleBackColor = true;
            this.btnSetAllBank2.Click += new System.EventHandler(this.btnSetAllBank2_Click);
            // 
            // btnSetAllBank1
            // 
            this.btnSetAllBank1.Location = new System.Drawing.Point(21, 327);
            this.btnSetAllBank1.Name = "btnSetAllBank1";
            this.btnSetAllBank1.Size = new System.Drawing.Size(89, 23);
            this.btnSetAllBank1.TabIndex = 709;
            this.btnSetAllBank1.Text = "Set All Bank 1";
            this.btnSetAllBank1.UseVisualStyleBackColor = true;
            this.btnSetAllBank1.Click += new System.EventHandler(this.btnSetAllBank1_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(21, 283);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 13);
            this.label10.TabIndex = 707;
            this.label10.Text = "Button:";
            // 
            // btnSetRGB
            // 
            this.btnSetRGB.Location = new System.Drawing.Point(256, 298);
            this.btnSetRGB.Name = "btnSetRGB";
            this.btnSetRGB.Size = new System.Drawing.Size(89, 23);
            this.btnSetRGB.TabIndex = 701;
            this.btnSetRGB.Text = "Set LED(s)";
            this.btnSetRGB.UseVisualStyleBackColor = true;
            this.btnSetRGB.Click += new System.EventHandler(this.btnSetRGB_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(217, 260);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(14, 13);
            this.label12.TabIndex = 704;
            this.label12.Text = "B";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(138, 260);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(15, 13);
            this.label13.TabIndex = 703;
            this.label13.Text = "G";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(59, 260);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(15, 13);
            this.label14.TabIndex = 702;
            this.label14.Text = "R";
            // 
            // txtG
            // 
            this.txtG.Location = new System.Drawing.Point(159, 257);
            this.txtG.Name = "txtG";
            this.txtG.Size = new System.Drawing.Size(52, 20);
            this.txtG.TabIndex = 700;
            this.txtG.Text = "3";
            // 
            // txtR
            // 
            this.txtR.Location = new System.Drawing.Point(80, 257);
            this.txtR.Name = "txtR";
            this.txtR.Size = new System.Drawing.Size(52, 20);
            this.txtR.TabIndex = 699;
            this.txtR.Text = "3";
            // 
            // chkRGBFlash
            // 
            this.chkRGBFlash.AutoSize = true;
            this.chkRGBFlash.Location = new System.Drawing.Point(200, 301);
            this.chkRGBFlash.Margin = new System.Windows.Forms.Padding(2);
            this.chkRGBFlash.Name = "chkRGBFlash";
            this.chkRGBFlash.Size = new System.Drawing.Size(51, 17);
            this.chkRGBFlash.TabIndex = 698;
            this.chkRGBFlash.Text = "Flash";
            this.chkRGBFlash.UseVisualStyleBackColor = true;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(11, 229);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(121, 13);
            this.label15.TabIndex = 697;
            this.label15.Text = "RGB Backlight Features";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(19, 260);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(34, 13);
            this.label9.TabIndex = 716;
            this.label9.Text = "Color:";
            // 
            // LblButtons
            // 
            this.LblButtons.AutoSize = true;
            this.LblButtons.Location = new System.Drawing.Point(21, 202);
            this.LblButtons.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LblButtons.Name = "LblButtons";
            this.LblButtons.Size = new System.Drawing.Size(46, 13);
            this.LblButtons.TabIndex = 717;
            this.LblButtons.Text = "Buttons:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1541, 734);
            this.Controls.Add(this.LblButtons);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label48);
            this.Controls.Add(this.cboRGBIndex);
            this.Controls.Add(this.txtB);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cboBank);
            this.Controls.Add(this.btnSetAllBank2);
            this.Controls.Add(this.btnSetAllBank1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnSetRGB);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtG);
            this.Controls.Add(this.txtR);
            this.Controls.Add(this.chkRGBFlash);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnLoopBack);
            this.Controls.Add(this.lblUART);
            this.Controls.Add(this.btnDisableUART);
            this.Controls.Add(this.btnEnableUART);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label50);
            this.Controls.Add(this.label45);
            this.Controls.Add(this.label58);
            this.Controls.Add(this.label55);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label63);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cboCOMStop);
            this.Controls.Add(this.BtnBLToggle);
            this.Controls.Add(this.label65);
            this.Controls.Add(this.label59);
            this.Controls.Add(this.label67);
            this.Controls.Add(this.btnReadRS232Settings);
            this.Controls.Add(this.label68);
            this.Controls.Add(this.label56);
            this.Controls.Add(this.cboCOMData);
            this.Controls.Add(this.cboStopBits);
            this.Controls.Add(this.cboCOMParity);
            this.Controls.Add(this.label54);
            this.Controls.Add(this.label57);
            this.Controls.Add(this.label53);
            this.Controls.Add(this.cboCOMBaud);
            this.Controls.Add(this.label52);
            this.Controls.Add(this.cboDataBits);
            this.Controls.Add(this.txtSendCOMUSB);
            this.Controls.Add(this.cboParity);
            this.Controls.Add(this.label46);
            this.Controls.Add(this.btnRS232Settings);
            this.Controls.Add(this.btnCOMPortUSB);
            this.Controls.Add(this.cboBaudRate);
            this.Controls.Add(this.label51);
            this.Controls.Add(this.label35);
            this.Controls.Add(this.label31);
            this.Controls.Add(this.btnWriteXkeysTx);
            this.Controls.Add(this.CboPorts);
            this.Controls.Add(this.txtSendText);
            this.Controls.Add(this.listBox5);
            this.Controls.Add(this.lblUSBCheckState);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btnUSBCheckOff);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.label66);
            this.Controls.Add(this.txtBase64Encode);
            this.Controls.Add(this.btnCOMPortInternal);
            this.Controls.Add(this.btnUSBCheckOn);
            this.Controls.Add(this.lblEncoded);
            this.Controls.Add(this.lblReawakeState);
            this.Controls.Add(this.label49);
            this.Controls.Add(this.btnSleepDisabled);
            this.Controls.Add(this.label64);
            this.Controls.Add(this.btnSleepEnabled);
            this.Controls.Add(this.lblJsonState);
            this.Controls.Add(this.btnJsonOff);
            this.Controls.Add(this.btnJsonOn);
            this.Controls.Add(this.lblEchoState);
            this.Controls.Add(this.btnEchoOff);
            this.Controls.Add(this.btnEchoOn);
            this.Controls.Add(this.label36);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.ChkSuppress);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.BtnDescriptor);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnCallback);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.CboDevices);
            this.Controls.Add(this.BtnEnumerate);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "C# X-keys RS232 Common Sample";
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
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Button BtnCallback;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Button BtnDescriptor;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.CheckBox ChkSuppress;
        private System.Windows.Forms.Label lblUSBCheckState;
        private System.Windows.Forms.Button btnUSBCheckOff;
        private System.Windows.Forms.Label label66;
        private System.Windows.Forms.Button btnUSBCheckOn;
        private System.Windows.Forms.Label lblReawakeState;
        private System.Windows.Forms.Button btnSleepDisabled;
        private System.Windows.Forms.Label label64;
        private System.Windows.Forms.Button btnSleepEnabled;
        private System.Windows.Forms.Label lblJsonState;
        private System.Windows.Forms.Button btnJsonOff;
        private System.Windows.Forms.Button btnJsonOn;
        private System.Windows.Forms.Label lblEchoState;
        private System.Windows.Forms.Button btnEchoOff;
        private System.Windows.Forms.Button btnEchoOn;
        private System.Windows.Forms.Label label36;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.TextBox txtSendText;
        private System.Windows.Forms.Button btnWriteXkeysTx;
        private System.Windows.Forms.Label label51;
        private System.Windows.Forms.ComboBox cboBaudRate;
        private System.Windows.Forms.Button btnRS232Settings;
        private System.Windows.Forms.ComboBox cboParity;
        private System.Windows.Forms.ComboBox cboDataBits;
        private System.Windows.Forms.Label label52;
        private System.Windows.Forms.Label label53;
        private System.Windows.Forms.Label label54;
        private System.Windows.Forms.Label label56;
        private System.Windows.Forms.ComboBox cboStopBits;
        private System.Windows.Forms.Button btnReadRS232Settings;
        private System.Windows.Forms.Label label59;
        private System.Windows.Forms.Button BtnBLToggle;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label49;
        public System.Windows.Forms.Label lblEncoded;
        private System.Windows.Forms.Button btnCOMPortInternal;
        private System.Windows.Forms.TextBox txtBase64Encode;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ListBox listBox5;
        private System.Windows.Forms.ComboBox CboPorts;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Button btnCOMPortUSB;
        private System.Windows.Forms.Label label46;
        private System.Windows.Forms.TextBox txtSendCOMUSB;
        private System.Windows.Forms.ComboBox cboCOMBaud;
        private System.Windows.Forms.Label label57;
        private System.Windows.Forms.ComboBox cboCOMParity;
        private System.Windows.Forms.ComboBox cboCOMData;
        private System.Windows.Forms.Label label68;
        private System.Windows.Forms.Label label67;
        private System.Windows.Forms.Label label65;
        private System.Windows.Forms.ComboBox cboCOMStop;
        private System.Windows.Forms.Label label63;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label55;
        private System.Windows.Forms.Label label58;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.Label label50;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnEnableUART;
        private System.Windows.Forms.Button btnDisableUART;
        private System.Windows.Forms.Label lblUART;
        private System.Windows.Forms.Button btnLoopBack;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label48;
        private System.Windows.Forms.ComboBox cboRGBIndex;
        private System.Windows.Forms.TextBox txtB;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboBank;
        private System.Windows.Forms.Button btnSetAllBank2;
        private System.Windows.Forms.Button btnSetAllBank1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnSetRGB;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtG;
        private System.Windows.Forms.TextBox txtR;
        private System.Windows.Forms.CheckBox chkRGBFlash;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label LblButtons;
    }
}

