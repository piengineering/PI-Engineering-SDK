namespace PIEHidNetCore_Csharp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnEnumerate = new Button();
            cboDevices = new ComboBox();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            label1 = new Label();
            label2 = new Label();
            btnCallback = new Button();
            listBox1 = new ListBox();
            lblDeltaTime = new Label();
            lblAbsTime = new Label();
            lblButtons = new Label();
            lblUnitID = new Label();
            btnClear = new Button();
            label3 = new Label();
            chkPin2 = new CheckBox();
            chkPin1 = new CheckBox();
            label4 = new Label();
            btnUnitID = new Button();
            txtUnitID = new TextBox();
            label5 = new Label();
            cboBacklightIndex = new ComboBox();
            chkBacklightOnOff = new CheckBox();
            chkAllBank1OnOff = new CheckBox();
            chkAllBank2OnOff = new CheckBox();
            label6 = new Label();
            btnToggleBacklights = new Button();
            btnSetIntensity = new Button();
            txtIntensityBank1 = new TextBox();
            txtIntensityBank2 = new TextBox();
            btnSaveBacklights = new Button();
            btnCustomData = new Button();
            btnGenerateData = new Button();
            label7 = new Label();
            btnTimeStampOn = new Button();
            btnTimeStampOff = new Button();
            label8 = new Label();
            textBox1 = new TextBox();
            btnKeyboardReflector = new Button();
            label9 = new Label();
            btnJoystickReflector = new Button();
            label10 = new Label();
            txtJoyX = new TextBox();
            txt = new TextBox();
            txtJoyZ = new TextBox();
            txtJoyZrot = new TextBox();
            txtJoySlider = new TextBox();
            txtJoyButton1 = new TextBox();
            txtJoyButton2 = new TextBox();
            txtJoyButton3 = new TextBox();
            txtJoyButton4 = new TextBox();
            txtJoyHat = new TextBox();
            label11 = new Label();
            label12 = new Label();
            label13 = new Label();
            label14 = new Label();
            label15 = new Label();
            label16 = new Label();
            label17 = new Label();
            label18 = new Label();
            label19 = new Label();
            label20 = new Label();
            label21 = new Label();
            label22 = new Label();
            label23 = new Label();
            txtMouseWheel = new TextBox();
            txtMouseY = new TextBox();
            txtMouseX = new TextBox();
            btnMouseReflector = new Button();
            label24 = new Label();
            txtMouseButton = new TextBox();
            label25 = new Label();
            label26 = new Label();
            label27 = new Label();
            label28 = new Label();
            label29 = new Label();
            txtMultimediaLo = new TextBox();
            txtMultimediaHi = new TextBox();
            btnMultimedia = new Button();
            label30 = new Label();
            btnMyComputer = new Button();
            btnDescriptor = new Button();
            label31 = new Label();
            listBox2 = new ListBox();
            btnToPID1 = new Button();
            label32 = new Label();
            txtVersion = new TextBox();
            btnWriteVersion = new Button();
            label37 = new Label();
            lblVersion = new Label();
            cboPIDs = new ComboBox();
            button1 = new Button();
            label33 = new Label();
            lblSiliconGeneratedID = new Label();
            lblNumLock = new Label();
            label35 = new Label();
            lblCapsLock = new Label();
            lblScrLock = new Label();
            lblGPIOs = new Label();
            lblVirtualButtons = new Label();
            chkPin3 = new CheckBox();
            chkPin4 = new CheckBox();
            listBox3 = new ListBox();
            label34 = new Label();
            cboColor = new ComboBox();
            label36 = new Label();
            txtRed = new TextBox();
            txtGreen = new TextBox();
            txtBlue = new TextBox();
            label38 = new Label();
            label39 = new Label();
            label40 = new Label();
            cboRGBLEDIndex = new ComboBox();
            label41 = new Label();
            cboBank = new ComboBox();
            label42 = new Label();
            chkFlash = new CheckBox();
            btnSetRGBLED = new Button();
            cboBankLegacy = new ComboBox();
            txtRGBDimBank2 = new TextBox();
            txtRGBDimBank1 = new TextBox();
            btnRGBDimFactors = new Button();
            label43 = new Label();
            label44 = new Label();
            txtFlashFreq = new TextBox();
            btnFlashFreq = new Button();
            label45 = new Label();
            cboRGBLEDIndex2 = new ComboBox();
            btnGetLEDState = new Button();
            label46 = new Label();
            btnAlwaysChangetoKVM = new Button();
            btnNoChangetoKVM = new Button();
            label47 = new Label();
            btnVirtualButton = new Button();
            txtVirtualButton = new TextBox();
            rbPress = new RadioButton();
            rbRelease = new RadioButton();
            btnSaveGPIOConfiguration = new Button();
            btnSetGPIOConfiguration = new Button();
            label48 = new Label();
            groupBox1 = new GroupBox();
            rbPin1Output = new RadioButton();
            rbPin1STG = new RadioButton();
            rbPin1DH = new RadioButton();
            groupBox2 = new GroupBox();
            rbPin2Output = new RadioButton();
            rbPin2STG = new RadioButton();
            rbPin2DH = new RadioButton();
            groupBox3 = new GroupBox();
            rbPin3Output = new RadioButton();
            rbPin3STG = new RadioButton();
            rbPin3DH = new RadioButton();
            groupBox4 = new GroupBox();
            rbPin4Output = new RadioButton();
            rbPin4STG = new RadioButton();
            rbPin4DH = new RadioButton();
            statusStrip1.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            SuspendLayout();
            // 
            // btnEnumerate
            // 
            btnEnumerate.Location = new Point(38, 25);
            btnEnumerate.Name = "btnEnumerate";
            btnEnumerate.Size = new Size(133, 23);
            btnEnumerate.TabIndex = 0;
            btnEnumerate.Text = "Enumerate";
            btnEnumerate.UseVisualStyleBackColor = true;
            btnEnumerate.Click += btnEnumerate_Click;
            // 
            // cboDevices
            // 
            cboDevices.FormattingEnabled = true;
            cboDevices.Location = new Point(38, 54);
            cboDevices.Name = "cboDevices";
            cboDevices.Size = new Size(414, 23);
            cboDevices.TabIndex = 1;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1 });
            statusStrip1.Location = new Point(0, 736);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(1664, 22);
            statusStrip1.TabIndex = 2;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(118, 17);
            toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 7);
            label1.Name = "label1";
            label1.Size = new Size(67, 15);
            label1.TabIndex = 3;
            label1.Text = "Do this first";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 94);
            label2.Name = "label2";
            label2.Size = new Size(188, 15);
            label2.TabIndex = 4;
            label2.Text = "Set for data callback and read data";
            // 
            // btnCallback
            // 
            btnCallback.Location = new Point(38, 112);
            btnCallback.Name = "btnCallback";
            btnCallback.Size = new Size(133, 23);
            btnCallback.TabIndex = 5;
            btnCallback.Text = "Setup for Callback";
            btnCallback.UseVisualStyleBackColor = true;
            btnCallback.Click += btnCallback_Click;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(38, 141);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(582, 94);
            listBox1.TabIndex = 6;
            // 
            // lblDeltaTime
            // 
            lblDeltaTime.AutoSize = true;
            lblDeltaTime.Location = new Point(1482, 150);
            lblDeltaTime.Name = "lblDeltaTime";
            lblDeltaTime.Size = new Size(60, 15);
            lblDeltaTime.TabIndex = 7;
            lblDeltaTime.Text = "delta time";
            // 
            // lblAbsTime
            // 
            lblAbsTime.AutoSize = true;
            lblAbsTime.Location = new Point(1482, 131);
            lblAbsTime.Name = "lblAbsTime";
            lblAbsTime.Size = new Size(79, 15);
            lblAbsTime.TabIndex = 8;
            lblAbsTime.Text = "absolute time";
            // 
            // lblButtons
            // 
            lblButtons.AutoSize = true;
            lblButtons.Location = new Point(38, 238);
            lblButtons.Name = "lblButtons";
            lblButtons.Size = new Size(51, 15);
            lblButtons.TabIndex = 10;
            lblButtons.Text = "Buttons:";
            // 
            // lblUnitID
            // 
            lblUnitID.AutoSize = true;
            lblUnitID.Location = new Point(228, 350);
            lblUnitID.Name = "lblUnitID";
            lblUnitID.Size = new Size(43, 15);
            lblUnitID.TabIndex = 11;
            lblUnitID.Text = "Unit ID";
            // 
            // btnClear
            // 
            btnClear.Location = new Point(487, 112);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(133, 23);
            btnClear.TabIndex = 12;
            btnClear.Text = "Clear Listbox";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(15, 276);
            label3.Name = "label3";
            label3.Size = new Size(118, 15);
            label3.TabIndex = 13;
            label3.Text = "GPIO Output Control";
            // 
            // chkPin2
            // 
            chkPin2.AutoSize = true;
            chkPin2.Location = new Point(107, 294);
            chkPin2.Name = "chkPin2";
            chkPin2.Size = new Size(52, 19);
            chkPin2.TabIndex = 14;
            chkPin2.Tag = "2";
            chkPin2.Text = "Pin 2";
            chkPin2.ThreeState = true;
            chkPin2.UseVisualStyleBackColor = true;
            chkPin2.CheckStateChanged += chkPin1_CheckStateChanged;
            // 
            // chkPin1
            // 
            chkPin1.AutoSize = true;
            chkPin1.Location = new Point(44, 294);
            chkPin1.Name = "chkPin1";
            chkPin1.Size = new Size(52, 19);
            chkPin1.TabIndex = 15;
            chkPin1.Tag = "1";
            chkPin1.Text = "Pin 1";
            chkPin1.ThreeState = true;
            chkPin1.UseVisualStyleBackColor = true;
            chkPin1.CheckStateChanged += chkPin1_CheckStateChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(15, 328);
            label4.Name = "label4";
            label4.Size = new Size(74, 15);
            label4.TabIndex = 16;
            label4.Text = "Write Unit ID";
            // 
            // btnUnitID
            // 
            btnUnitID.Location = new Point(44, 346);
            btnUnitID.Name = "btnUnitID";
            btnUnitID.Size = new Size(133, 23);
            btnUnitID.TabIndex = 17;
            btnUnitID.Text = "Write Unit ID";
            btnUnitID.UseVisualStyleBackColor = true;
            btnUnitID.Click += btnUnitID_Click;
            // 
            // txtUnitID
            // 
            txtUnitID.Location = new Point(183, 346);
            txtUnitID.Name = "txtUnitID";
            txtUnitID.Size = new Size(40, 23);
            txtUnitID.TabIndex = 18;
            txtUnitID.Text = "1";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 644);
            label5.Name = "label5";
            label5.Size = new Size(143, 15);
            label5.TabIndex = 19;
            label5.Text = "Legacy Backlight Features";
            // 
            // cboBacklightIndex
            // 
            cboBacklightIndex.FormattingEnabled = true;
            cboBacklightIndex.Items.AddRange(new object[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23" });
            cboBacklightIndex.Location = new Point(41, 665);
            cboBacklightIndex.Name = "cboBacklightIndex";
            cboBacklightIndex.Size = new Size(72, 23);
            cboBacklightIndex.TabIndex = 20;
            // 
            // chkBacklightOnOff
            // 
            chkBacklightOnOff.AutoSize = true;
            chkBacklightOnOff.Location = new Point(206, 669);
            chkBacklightOnOff.Name = "chkBacklightOnOff";
            chkBacklightOnOff.Size = new Size(96, 19);
            chkBacklightOnOff.TabIndex = 21;
            chkBacklightOnOff.Text = "On/Off/Flash";
            chkBacklightOnOff.ThreeState = true;
            chkBacklightOnOff.UseVisualStyleBackColor = true;
            chkBacklightOnOff.CheckStateChanged += chkBacklightOnOff_CheckStateChanged;
            // 
            // chkAllBank1OnOff
            // 
            chkAllBank1OnOff.AutoSize = true;
            chkAllBank1OnOff.Location = new Point(308, 669);
            chkAllBank1OnOff.Name = "chkAllBank1OnOff";
            chkAllBank1OnOff.Size = new Size(119, 19);
            chkAllBank1OnOff.TabIndex = 22;
            chkAllBank1OnOff.Text = "All Bank 1 On/Off";
            chkAllBank1OnOff.UseVisualStyleBackColor = true;
            chkAllBank1OnOff.CheckedChanged += chkAllBank1OnOff_CheckedChanged;
            // 
            // chkAllBank2OnOff
            // 
            chkAllBank2OnOff.AutoSize = true;
            chkAllBank2OnOff.Location = new Point(308, 688);
            chkAllBank2OnOff.Name = "chkAllBank2OnOff";
            chkAllBank2OnOff.Size = new Size(119, 19);
            chkAllBank2OnOff.TabIndex = 23;
            chkAllBank2OnOff.Text = "All Bank 2 On/Off";
            chkAllBank2OnOff.UseVisualStyleBackColor = true;
            chkAllBank2OnOff.CheckedChanged += chkAllBank2OnOff_CheckedChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(12, 494);
            label6.Name = "label6";
            label6.Size = new Size(140, 15);
            label6.TabIndex = 24;
            label6.Text = "Global Backlight Features";
            // 
            // btnToggleBacklights
            // 
            btnToggleBacklights.Location = new Point(41, 512);
            btnToggleBacklights.Name = "btnToggleBacklights";
            btnToggleBacklights.Size = new Size(111, 23);
            btnToggleBacklights.TabIndex = 25;
            btnToggleBacklights.Text = "Toggle Backlights";
            btnToggleBacklights.UseVisualStyleBackColor = true;
            btnToggleBacklights.Click += btnToggleBacklights_Click;
            // 
            // btnSetIntensity
            // 
            btnSetIntensity.Location = new Point(38, 694);
            btnSetIntensity.Name = "btnSetIntensity";
            btnSetIntensity.Size = new Size(81, 23);
            btnSetIntensity.TabIndex = 26;
            btnSetIntensity.Text = "Set Intensity";
            btnSetIntensity.UseVisualStyleBackColor = true;
            btnSetIntensity.Click += btnSetIntensity_Click;
            // 
            // txtIntensityBank1
            // 
            txtIntensityBank1.Location = new Point(125, 694);
            txtIntensityBank1.Name = "txtIntensityBank1";
            txtIntensityBank1.Size = new Size(46, 23);
            txtIntensityBank1.TabIndex = 27;
            txtIntensityBank1.Text = "255";
            // 
            // txtIntensityBank2
            // 
            txtIntensityBank2.Location = new Point(177, 694);
            txtIntensityBank2.Name = "txtIntensityBank2";
            txtIntensityBank2.Size = new Size(46, 23);
            txtIntensityBank2.TabIndex = 28;
            txtIntensityBank2.Text = "255";
            // 
            // btnSaveBacklights
            // 
            btnSaveBacklights.Location = new Point(158, 512);
            btnSaveBacklights.Name = "btnSaveBacklights";
            btnSaveBacklights.Size = new Size(98, 23);
            btnSaveBacklights.TabIndex = 29;
            btnSaveBacklights.Text = "Save Backlights";
            btnSaveBacklights.UseVisualStyleBackColor = true;
            btnSaveBacklights.Click += btnSaveBacklights_Click;
            // 
            // btnCustomData
            // 
            btnCustomData.Location = new Point(1292, 25);
            btnCustomData.Name = "btnCustomData";
            btnCustomData.Size = new Size(96, 23);
            btnCustomData.TabIndex = 32;
            btnCustomData.Text = "Custom Data";
            btnCustomData.UseVisualStyleBackColor = true;
            btnCustomData.Click += btnCustomData_Click;
            // 
            // btnGenerateData
            // 
            btnGenerateData.Location = new Point(1190, 25);
            btnGenerateData.Name = "btnGenerateData";
            btnGenerateData.Size = new Size(96, 23);
            btnGenerateData.TabIndex = 31;
            btnGenerateData.Text = "Generate Data";
            btnGenerateData.UseVisualStyleBackColor = true;
            btnGenerateData.Click += btnGenerateData_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(1161, 7);
            label7.Name = "label7";
            label7.Size = new Size(450, 15);
            label7.TabIndex = 30;
            label7.Text = "Stimulate a general incoming data report, send a custom input report, virtual button";
            // 
            // btnTimeStampOn
            // 
            btnTimeStampOn.Location = new Point(1329, 131);
            btnTimeStampOn.Name = "btnTimeStampOn";
            btnTimeStampOn.Size = new Size(133, 23);
            btnTimeStampOn.TabIndex = 35;
            btnTimeStampOn.Text = "Time Stamp On";
            btnTimeStampOn.UseVisualStyleBackColor = true;
            btnTimeStampOn.Click += btnTimeStampOn_Click;
            // 
            // btnTimeStampOff
            // 
            btnTimeStampOff.Location = new Point(1190, 131);
            btnTimeStampOff.Name = "btnTimeStampOff";
            btnTimeStampOff.Size = new Size(133, 23);
            btnTimeStampOff.TabIndex = 34;
            btnTimeStampOff.Text = "Time Stamp Off";
            btnTimeStampOff.UseVisualStyleBackColor = true;
            btnTimeStampOff.Click += btnTimeStampOff_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(1161, 113);
            label8.Name = "label8";
            label8.Size = new Size(108, 15);
            label8.TabIndex = 33;
            label8.Text = "Enable Time Stamp";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(815, 25);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(73, 23);
            textBox1.TabIndex = 38;
            // 
            // btnKeyboardReflector
            // 
            btnKeyboardReflector.Location = new Point(676, 25);
            btnKeyboardReflector.Name = "btnKeyboardReflector";
            btnKeyboardReflector.Size = new Size(133, 23);
            btnKeyboardReflector.TabIndex = 37;
            btnKeyboardReflector.Text = "Keyboard Reflector";
            btnKeyboardReflector.UseVisualStyleBackColor = true;
            btnKeyboardReflector.Click += btnKeyboardReflector_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(647, 7);
            label9.Name = "label9";
            label9.Size = new Size(107, 15);
            label9.TabIndex = 36;
            label9.Text = "Keyboard Reflector";
            // 
            // btnJoystickReflector
            // 
            btnJoystickReflector.Location = new Point(676, 103);
            btnJoystickReflector.Name = "btnJoystickReflector";
            btnJoystickReflector.Size = new Size(133, 23);
            btnJoystickReflector.TabIndex = 40;
            btnJoystickReflector.Text = "Joystick Reflector";
            btnJoystickReflector.UseVisualStyleBackColor = true;
            btnJoystickReflector.Click += btnJoystickReflector_Click;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(647, 85);
            label10.Name = "label10";
            label10.Size = new Size(98, 15);
            label10.TabIndex = 39;
            label10.Text = "Joystick Reflector";
            // 
            // txtJoyX
            // 
            txtJoyX.Location = new Point(815, 104);
            txtJoyX.Name = "txtJoyX";
            txtJoyX.Size = new Size(35, 23);
            txtJoyX.TabIndex = 41;
            txtJoyX.Text = "0";
            // 
            // txt
            // 
            txt.Location = new Point(855, 104);
            txt.Name = "txt";
            txt.Size = new Size(35, 23);
            txt.TabIndex = 42;
            txt.Text = "0";
            // 
            // txtJoyZ
            // 
            txtJoyZ.Location = new Point(895, 104);
            txtJoyZ.Name = "txtJoyZ";
            txtJoyZ.Size = new Size(35, 23);
            txtJoyZ.TabIndex = 43;
            txtJoyZ.Text = "0";
            // 
            // txtJoyZrot
            // 
            txtJoyZrot.Location = new Point(935, 104);
            txtJoyZrot.Name = "txtJoyZrot";
            txtJoyZrot.Size = new Size(35, 23);
            txtJoyZrot.TabIndex = 44;
            txtJoyZrot.Text = "0";
            // 
            // txtJoySlider
            // 
            txtJoySlider.Location = new Point(975, 104);
            txtJoySlider.Name = "txtJoySlider";
            txtJoySlider.Size = new Size(35, 23);
            txtJoySlider.TabIndex = 45;
            txtJoySlider.Text = "0";
            // 
            // txtJoyButton1
            // 
            txtJoyButton1.Location = new Point(815, 149);
            txtJoyButton1.Name = "txtJoyButton1";
            txtJoyButton1.Size = new Size(35, 23);
            txtJoyButton1.TabIndex = 46;
            txtJoyButton1.Text = "0";
            // 
            // txtJoyButton2
            // 
            txtJoyButton2.Location = new Point(855, 149);
            txtJoyButton2.Name = "txtJoyButton2";
            txtJoyButton2.Size = new Size(35, 23);
            txtJoyButton2.TabIndex = 47;
            txtJoyButton2.Text = "0";
            // 
            // txtJoyButton3
            // 
            txtJoyButton3.Location = new Point(895, 149);
            txtJoyButton3.Name = "txtJoyButton3";
            txtJoyButton3.Size = new Size(35, 23);
            txtJoyButton3.TabIndex = 48;
            txtJoyButton3.Text = "0";
            // 
            // txtJoyButton4
            // 
            txtJoyButton4.Location = new Point(935, 149);
            txtJoyButton4.Name = "txtJoyButton4";
            txtJoyButton4.Size = new Size(35, 23);
            txtJoyButton4.TabIndex = 49;
            txtJoyButton4.Text = "0";
            // 
            // txtJoyHat
            // 
            txtJoyHat.Location = new Point(976, 149);
            txtJoyHat.Name = "txtJoyHat";
            txtJoyHat.Size = new Size(35, 23);
            txtJoyHat.TabIndex = 50;
            txtJoyHat.Text = "0";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(815, 85);
            label11.Name = "label11";
            label11.Size = new Size(14, 15);
            label11.TabIndex = 51;
            label11.Text = "X";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(855, 85);
            label12.Name = "label12";
            label12.Size = new Size(14, 15);
            label12.TabIndex = 52;
            label12.Text = "Y";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(895, 85);
            label13.Name = "label13";
            label13.Size = new Size(14, 15);
            label13.TabIndex = 53;
            label13.Text = "Z";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(935, 85);
            label14.Name = "label14";
            label14.Size = new Size(29, 15);
            label14.TabIndex = 54;
            label14.Text = "Zrot";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(975, 85);
            label15.Name = "label15";
            label15.Size = new Size(36, 15);
            label15.TabIndex = 55;
            label15.Text = "Slider";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(1016, 107);
            label16.Name = "label16";
            label16.Size = new Size(44, 15);
            label16.TabIndex = 56;
            label16.Text = "(0-255)";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(882, 131);
            label17.Name = "label17";
            label17.Size = new Size(48, 15);
            label17.TabIndex = 57;
            label17.Text = "Buttons";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new Point(976, 131);
            label18.Name = "label18";
            label18.Size = new Size(26, 15);
            label18.TabIndex = 58;
            label18.Text = "Hat";
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Location = new Point(676, 129);
            label19.Name = "label19";
            label19.Size = new Size(146, 15);
            label19.TabIndex = 59;
            label19.Text = "Joystick endpoint required";
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Location = new Point(914, 226);
            label20.Name = "label20";
            label20.Size = new Size(40, 15);
            label20.TabIndex = 69;
            label20.Text = "Wheel";
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Location = new Point(874, 226);
            label21.Name = "label21";
            label21.Size = new Size(21, 15);
            label21.TabIndex = 68;
            label21.Text = "dY";
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Location = new Point(834, 226);
            label22.Name = "label22";
            label22.Size = new Size(21, 15);
            label22.TabIndex = 67;
            label22.Text = "dX";
            // 
            // label23
            // 
            label23.AutoSize = true;
            label23.Location = new Point(834, 181);
            label23.Name = "label23";
            label23.Size = new Size(43, 15);
            label23.TabIndex = 66;
            label23.Text = "Button";
            // 
            // txtMouseWheel
            // 
            txtMouseWheel.Location = new Point(914, 245);
            txtMouseWheel.Name = "txtMouseWheel";
            txtMouseWheel.Size = new Size(35, 23);
            txtMouseWheel.TabIndex = 65;
            txtMouseWheel.Text = "0";
            // 
            // txtMouseY
            // 
            txtMouseY.Location = new Point(874, 245);
            txtMouseY.Name = "txtMouseY";
            txtMouseY.Size = new Size(35, 23);
            txtMouseY.TabIndex = 64;
            txtMouseY.Text = "20";
            // 
            // txtMouseX
            // 
            txtMouseX.Location = new Point(834, 245);
            txtMouseX.Name = "txtMouseX";
            txtMouseX.Size = new Size(35, 23);
            txtMouseX.TabIndex = 63;
            txtMouseX.Text = "20";
            // 
            // btnMouseReflector
            // 
            btnMouseReflector.Location = new Point(676, 199);
            btnMouseReflector.Name = "btnMouseReflector";
            btnMouseReflector.Size = new Size(133, 23);
            btnMouseReflector.TabIndex = 61;
            btnMouseReflector.Text = "Mouse Reflector";
            btnMouseReflector.UseVisualStyleBackColor = true;
            btnMouseReflector.Click += btnMouseReflector_Click;
            // 
            // label24
            // 
            label24.AutoSize = true;
            label24.Location = new Point(647, 181);
            label24.Name = "label24";
            label24.Size = new Size(93, 15);
            label24.TabIndex = 60;
            label24.Text = "Mouse Reflector";
            // 
            // txtMouseButton
            // 
            txtMouseButton.Location = new Point(834, 200);
            txtMouseButton.Name = "txtMouseButton";
            txtMouseButton.Size = new Size(35, 23);
            txtMouseButton.TabIndex = 70;
            txtMouseButton.Text = "0";
            // 
            // label25
            // 
            label25.AutoSize = true;
            label25.Location = new Point(875, 203);
            label25.Name = "label25";
            label25.Size = new Size(280, 15);
            label25.TabIndex = 71;
            label25.Text = "1=left, 2=right, 4=center, 8=XButton1, 16=XButton2";
            // 
            // label26
            // 
            label26.AutoSize = true;
            label26.Location = new Point(676, 225);
            label26.Name = "label26";
            label26.Size = new Size(141, 15);
            label26.TabIndex = 72;
            label26.Text = "Mouse endpoint required";
            // 
            // label27
            // 
            label27.AutoSize = true;
            label27.Location = new Point(676, 323);
            label27.Name = "label27";
            label27.Size = new Size(166, 15);
            label27.TabIndex = 79;
            label27.Text = "Multimedia endpoint required";
            // 
            // label28
            // 
            label28.AutoSize = true;
            label28.Location = new Point(882, 278);
            label28.Name = "label28";
            label28.Size = new Size(59, 15);
            label28.TabIndex = 78;
            label28.Text = "Low (hex)";
            // 
            // label29
            // 
            label29.AutoSize = true;
            label29.Location = new Point(814, 279);
            label29.Name = "label29";
            label29.Size = new Size(63, 15);
            label29.TabIndex = 77;
            label29.Text = "High (hex)";
            // 
            // txtMultimediaLo
            // 
            txtMultimediaLo.Location = new Point(882, 297);
            txtMultimediaLo.Name = "txtMultimediaLo";
            txtMultimediaLo.Size = new Size(35, 23);
            txtMultimediaLo.TabIndex = 76;
            txtMultimediaLo.Text = "E2";
            // 
            // txtMultimediaHi
            // 
            txtMultimediaHi.Location = new Point(813, 297);
            txtMultimediaHi.Name = "txtMultimediaHi";
            txtMultimediaHi.Size = new Size(35, 23);
            txtMultimediaHi.TabIndex = 75;
            txtMultimediaHi.Text = "00";
            // 
            // btnMultimedia
            // 
            btnMultimedia.Location = new Point(674, 297);
            btnMultimedia.Name = "btnMultimedia";
            btnMultimedia.Size = new Size(133, 23);
            btnMultimedia.TabIndex = 74;
            btnMultimedia.Text = "Multimedia Reflector";
            btnMultimedia.UseVisualStyleBackColor = true;
            btnMultimedia.Click += btnMultimedia_Click;
            // 
            // label30
            // 
            label30.AutoSize = true;
            label30.Location = new Point(647, 279);
            label30.Name = "label30";
            label30.Size = new Size(118, 15);
            label30.TabIndex = 73;
            label30.Text = "Multimedia Reflector";
            // 
            // btnMyComputer
            // 
            btnMyComputer.Location = new Point(976, 297);
            btnMyComputer.Name = "btnMyComputer";
            btnMyComputer.Size = new Size(116, 23);
            btnMyComputer.TabIndex = 80;
            btnMyComputer.Text = "My Computer";
            btnMyComputer.UseVisualStyleBackColor = true;
            btnMyComputer.Click += btnMyComputer_Click;
            // 
            // btnDescriptor
            // 
            btnDescriptor.Location = new Point(676, 371);
            btnDescriptor.Name = "btnDescriptor";
            btnDescriptor.Size = new Size(133, 23);
            btnDescriptor.TabIndex = 82;
            btnDescriptor.Text = "Descriptor";
            btnDescriptor.UseVisualStyleBackColor = true;
            btnDescriptor.Click += btnDescriptor_Click;
            // 
            // label31
            // 
            label31.AutoSize = true;
            label31.Location = new Point(647, 353);
            label31.Name = "label31";
            label31.Size = new Size(61, 15);
            label31.TabIndex = 81;
            label31.Text = "Descriptor";
            // 
            // listBox2
            // 
            listBox2.FormattingEnabled = true;
            listBox2.ItemHeight = 15;
            listBox2.Location = new Point(815, 371);
            listBox2.Name = "listBox2";
            listBox2.Size = new Size(293, 94);
            listBox2.TabIndex = 83;
            // 
            // btnToPID1
            // 
            btnToPID1.Location = new Point(674, 526);
            btnToPID1.Name = "btnToPID1";
            btnToPID1.Size = new Size(133, 23);
            btnToPID1.TabIndex = 85;
            btnToPID1.Tag = "0";
            btnToPID1.Text = "Change";
            btnToPID1.UseVisualStyleBackColor = true;
            btnToPID1.Click += btnToPID1_Click;
            // 
            // label32
            // 
            label32.AutoSize = true;
            label32.Location = new Point(647, 479);
            label32.Name = "label32";
            label32.Size = new Size(69, 15);
            label32.TabIndex = 84;
            label32.Text = "Change PID";
            // 
            // txtVersion
            // 
            txtVersion.Location = new Point(1329, 81);
            txtVersion.Name = "txtVersion";
            txtVersion.Size = new Size(73, 23);
            txtVersion.TabIndex = 96;
            txtVersion.Text = "100";
            // 
            // btnWriteVersion
            // 
            btnWriteVersion.Location = new Point(1190, 81);
            btnWriteVersion.Name = "btnWriteVersion";
            btnWriteVersion.Size = new Size(133, 23);
            btnWriteVersion.TabIndex = 95;
            btnWriteVersion.Text = "Write Version";
            btnWriteVersion.UseVisualStyleBackColor = true;
            btnWriteVersion.Click += btnWriteVersion_Click;
            // 
            // label37
            // 
            label37.AutoSize = true;
            label37.Location = new Point(1161, 63);
            label37.Name = "label37";
            label37.Size = new Size(128, 15);
            label37.TabIndex = 94;
            label37.Text = "Write Version (0-65535)";
            // 
            // lblVersion
            // 
            lblVersion.AutoSize = true;
            lblVersion.Location = new Point(1408, 85);
            lblVersion.Name = "lblVersion";
            lblVersion.Size = new Size(45, 15);
            lblVersion.TabIndex = 93;
            lblVersion.Text = "version";
            // 
            // cboPIDs
            // 
            cboPIDs.FormattingEnabled = true;
            cboPIDs.Items.AddRange(new object[] { "PID 1: Keyboard, Multimedia, PI Consumer, Output", "PID 2: Keyboard (boot), Multimedia, PI Consumer, Output", "PID 3: Keyboard, Joystick, PI Consumer, Output", "PID 4: Mouse, Joystick, PI Consumer, Output", "PID 5: Keyboard (boot), Mouse, PI Consumer, Output", "PID 6: PI Consumer, Output", "PID 7:  Keyboard, Joystick, Mouse, Multimedia, PI Consumer, Output", "PID 8: Keyboard (boot) for KVM users" });
            cboPIDs.Location = new Point(676, 497);
            cboPIDs.Name = "cboPIDs";
            cboPIDs.Size = new Size(321, 23);
            cboPIDs.TabIndex = 97;
            // 
            // button1
            // 
            button1.Location = new Point(1190, 328);
            button1.Name = "button1";
            button1.Size = new Size(133, 23);
            button1.TabIndex = 100;
            button1.Text = "Read ID";
            button1.UseVisualStyleBackColor = true;
            // 
            // label33
            // 
            label33.AutoSize = true;
            label33.Location = new Point(1161, 310);
            label33.Name = "label33";
            label33.Size = new Size(142, 15);
            label33.TabIndex = 99;
            label33.Text = "Read Silicon Generated ID";
            // 
            // lblSiliconGeneratedID
            // 
            lblSiliconGeneratedID.AutoSize = true;
            lblSiliconGeneratedID.Location = new Point(1331, 332);
            lblSiliconGeneratedID.Name = "lblSiliconGeneratedID";
            lblSiliconGeneratedID.Size = new Size(111, 15);
            lblSiliconGeneratedID.TabIndex = 98;
            lblSiliconGeneratedID.Text = "silicon generated ID";
            // 
            // lblNumLock
            // 
            lblNumLock.AutoSize = true;
            lblNumLock.Location = new Point(391, 238);
            lblNumLock.Name = "lblNumLock";
            lblNumLock.Size = new Size(62, 15);
            lblNumLock.TabIndex = 101;
            lblNumLock.Text = "NumLock:";
            // 
            // label35
            // 
            label35.AutoSize = true;
            label35.Location = new Point(674, 51);
            label35.Name = "label35";
            label35.Size = new Size(155, 15);
            label35.TabIndex = 102;
            label35.Text = "Keyboard endpoint required";
            // 
            // lblCapsLock
            // 
            lblCapsLock.AutoSize = true;
            lblCapsLock.Location = new Point(391, 253);
            lblCapsLock.Name = "lblCapsLock";
            lblCapsLock.Size = new Size(61, 15);
            lblCapsLock.TabIndex = 103;
            lblCapsLock.Text = "CapsLock:";
            // 
            // lblScrLock
            // 
            lblScrLock.AutoSize = true;
            lblScrLock.Location = new Point(391, 268);
            lblScrLock.Name = "lblScrLock";
            lblScrLock.Size = new Size(51, 15);
            lblScrLock.TabIndex = 104;
            lblScrLock.Text = "ScrLock:";
            // 
            // lblGPIOs
            // 
            lblGPIOs.AutoSize = true;
            lblGPIOs.Location = new Point(391, 283);
            lblGPIOs.Name = "lblGPIOs";
            lblGPIOs.Size = new Size(42, 15);
            lblGPIOs.TabIndex = 105;
            lblGPIOs.Text = "GPIOs:";
            // 
            // lblVirtualButtons
            // 
            lblVirtualButtons.AutoSize = true;
            lblVirtualButtons.Location = new Point(391, 298);
            lblVirtualButtons.Name = "lblVirtualButtons";
            lblVirtualButtons.Size = new Size(88, 15);
            lblVirtualButtons.TabIndex = 106;
            lblVirtualButtons.Text = "Virtual Buttons:";
            // 
            // chkPin3
            // 
            chkPin3.AutoSize = true;
            chkPin3.Location = new Point(165, 294);
            chkPin3.Name = "chkPin3";
            chkPin3.Size = new Size(52, 19);
            chkPin3.TabIndex = 108;
            chkPin3.Tag = "3";
            chkPin3.Text = "Pin 3";
            chkPin3.ThreeState = true;
            chkPin3.UseVisualStyleBackColor = true;
            chkPin3.CheckStateChanged += chkPin1_CheckStateChanged;
            // 
            // chkPin4
            // 
            chkPin4.AutoSize = true;
            chkPin4.Location = new Point(228, 294);
            chkPin4.Name = "chkPin4";
            chkPin4.Size = new Size(52, 19);
            chkPin4.TabIndex = 107;
            chkPin4.Tag = "4";
            chkPin4.Text = "Pin 4";
            chkPin4.ThreeState = true;
            chkPin4.UseVisualStyleBackColor = true;
            chkPin4.CheckStateChanged += chkPin1_CheckStateChanged;
            // 
            // listBox3
            // 
            listBox3.FormattingEnabled = true;
            listBox3.ItemHeight = 15;
            listBox3.Location = new Point(293, 559);
            listBox3.Name = "listBox3";
            listBox3.Size = new Size(222, 64);
            listBox3.TabIndex = 109;
            // 
            // label34
            // 
            label34.AutoSize = true;
            label34.Location = new Point(15, 393);
            label34.Name = "label34";
            label34.Size = new Size(128, 15);
            label34.TabIndex = 110;
            label34.Text = "RGB Backlight Features";
            // 
            // cboColor
            // 
            cboColor.FormattingEnabled = true;
            cboColor.Items.AddRange(new object[] { "Off", "Red", "Orange", "Yellow", "Green", "Turquoise", "Blue", "Pink", "Purple", "White" });
            cboColor.Location = new Point(41, 411);
            cboColor.Name = "cboColor";
            cboColor.Size = new Size(121, 23);
            cboColor.TabIndex = 111;
            cboColor.SelectedIndexChanged += cboColor_SelectedIndexChanged;
            // 
            // label36
            // 
            label36.AutoSize = true;
            label36.Location = new Point(165, 414);
            label36.Name = "label36";
            label36.Size = new Size(18, 15);
            label36.TabIndex = 112;
            label36.Text = "or";
            // 
            // txtRed
            // 
            txtRed.Location = new Point(183, 411);
            txtRed.Name = "txtRed";
            txtRed.Size = new Size(43, 23);
            txtRed.TabIndex = 113;
            txtRed.Text = "0";
            // 
            // txtGreen
            // 
            txtGreen.Location = new Point(232, 411);
            txtGreen.Name = "txtGreen";
            txtGreen.Size = new Size(43, 23);
            txtGreen.TabIndex = 114;
            txtGreen.Text = "0";
            // 
            // txtBlue
            // 
            txtBlue.Location = new Point(281, 411);
            txtBlue.Name = "txtBlue";
            txtBlue.Size = new Size(43, 23);
            txtBlue.TabIndex = 115;
            txtBlue.Text = "0";
            // 
            // label38
            // 
            label38.AutoSize = true;
            label38.Location = new Point(183, 393);
            label38.Name = "label38";
            label38.Size = new Size(14, 15);
            label38.TabIndex = 116;
            label38.Text = "R";
            // 
            // label39
            // 
            label39.AutoSize = true;
            label39.Location = new Point(232, 393);
            label39.Name = "label39";
            label39.Size = new Size(15, 15);
            label39.TabIndex = 117;
            label39.Text = "G";
            // 
            // label40
            // 
            label40.AutoSize = true;
            label40.Location = new Point(281, 393);
            label40.Name = "label40";
            label40.Size = new Size(14, 15);
            label40.TabIndex = 118;
            label40.Text = "B";
            // 
            // cboRGBLEDIndex
            // 
            cboRGBLEDIndex.FormattingEnabled = true;
            cboRGBLEDIndex.Items.AddRange(new object[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23" });
            cboRGBLEDIndex.Location = new Point(41, 453);
            cboRGBLEDIndex.Name = "cboRGBLEDIndex";
            cboRGBLEDIndex.Size = new Size(43, 23);
            cboRGBLEDIndex.TabIndex = 119;
            // 
            // label41
            // 
            label41.AutoSize = true;
            label41.Location = new Point(41, 437);
            label41.Name = "label41";
            label41.Size = new Size(43, 15);
            label41.TabIndex = 120;
            label41.Text = "Button";
            // 
            // cboBank
            // 
            cboBank.FormattingEnabled = true;
            cboBank.Items.AddRange(new object[] { "bank 1 (top)", "bank 2 (bottom)", "both" });
            cboBank.Location = new Point(86, 453);
            cboBank.Name = "cboBank";
            cboBank.Size = new Size(104, 23);
            cboBank.TabIndex = 121;
            // 
            // label42
            // 
            label42.AutoSize = true;
            label42.Location = new Point(86, 437);
            label42.Name = "label42";
            label42.Size = new Size(33, 15);
            label42.TabIndex = 122;
            label42.Text = "Bank";
            // 
            // chkFlash
            // 
            chkFlash.AutoSize = true;
            chkFlash.Location = new Point(196, 455);
            chkFlash.Name = "chkFlash";
            chkFlash.Size = new Size(53, 19);
            chkFlash.TabIndex = 123;
            chkFlash.Text = "Flash";
            chkFlash.UseVisualStyleBackColor = true;
            // 
            // btnSetRGBLED
            // 
            btnSetRGBLED.Location = new Point(249, 452);
            btnSetRGBLED.Name = "btnSetRGBLED";
            btnSetRGBLED.Size = new Size(75, 23);
            btnSetRGBLED.TabIndex = 124;
            btnSetRGBLED.Text = "Set LED(s)";
            btnSetRGBLED.UseVisualStyleBackColor = true;
            btnSetRGBLED.Click += btnSetRGBLED_Click;
            // 
            // cboBankLegacy
            // 
            cboBankLegacy.FormattingEnabled = true;
            cboBankLegacy.Items.AddRange(new object[] { "bank 1 (blue)", "bank 2 (red)" });
            cboBankLegacy.Location = new Point(119, 665);
            cboBankLegacy.Name = "cboBankLegacy";
            cboBankLegacy.Size = new Size(72, 23);
            cboBankLegacy.TabIndex = 125;
            // 
            // txtRGBDimBank2
            // 
            txtRGBDimBank2.Location = new Point(210, 550);
            txtRGBDimBank2.Name = "txtRGBDimBank2";
            txtRGBDimBank2.Size = new Size(46, 23);
            txtRGBDimBank2.TabIndex = 128;
            txtRGBDimBank2.Text = "255";
            // 
            // txtRGBDimBank1
            // 
            txtRGBDimBank1.Location = new Point(158, 550);
            txtRGBDimBank1.Name = "txtRGBDimBank1";
            txtRGBDimBank1.Size = new Size(46, 23);
            txtRGBDimBank1.TabIndex = 127;
            txtRGBDimBank1.Text = "255";
            // 
            // btnRGBDimFactors
            // 
            btnRGBDimFactors.Location = new Point(41, 550);
            btnRGBDimFactors.Name = "btnRGBDimFactors";
            btnRGBDimFactors.Size = new Size(111, 23);
            btnRGBDimFactors.TabIndex = 126;
            btnRGBDimFactors.Text = "Set Dim Factors";
            btnRGBDimFactors.UseVisualStyleBackColor = true;
            btnRGBDimFactors.Click += btnRGBDimFactors_Click;
            // 
            // label43
            // 
            label43.AutoSize = true;
            label43.Location = new Point(158, 534);
            label43.Name = "label43";
            label43.Size = new Size(42, 15);
            label43.TabIndex = 129;
            label43.Text = "Bank 1";
            // 
            // label44
            // 
            label44.AutoSize = true;
            label44.Location = new Point(209, 534);
            label44.Name = "label44";
            label44.Size = new Size(42, 15);
            label44.TabIndex = 130;
            label44.Text = "Bank 2";
            // 
            // txtFlashFreq
            // 
            txtFlashFreq.Location = new Point(158, 579);
            txtFlashFreq.Name = "txtFlashFreq";
            txtFlashFreq.Size = new Size(46, 23);
            txtFlashFreq.TabIndex = 132;
            txtFlashFreq.Text = "10";
            // 
            // btnFlashFreq
            // 
            btnFlashFreq.Location = new Point(41, 579);
            btnFlashFreq.Name = "btnFlashFreq";
            btnFlashFreq.Size = new Size(111, 23);
            btnFlashFreq.TabIndex = 131;
            btnFlashFreq.Text = "Set Flash Freq";
            btnFlashFreq.UseVisualStyleBackColor = true;
            btnFlashFreq.Click += btnFlashFreq_Click;
            // 
            // label45
            // 
            label45.AutoSize = true;
            label45.Location = new Point(293, 515);
            label45.Name = "label45";
            label45.Size = new Size(43, 15);
            label45.TabIndex = 134;
            label45.Text = "Button";
            // 
            // cboRGBLEDIndex2
            // 
            cboRGBLEDIndex2.FormattingEnabled = true;
            cboRGBLEDIndex2.Items.AddRange(new object[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23" });
            cboRGBLEDIndex2.Location = new Point(293, 531);
            cboRGBLEDIndex2.Name = "cboRGBLEDIndex2";
            cboRGBLEDIndex2.Size = new Size(43, 23);
            cboRGBLEDIndex2.TabIndex = 133;
            // 
            // btnGetLEDState
            // 
            btnGetLEDState.Location = new Point(341, 530);
            btnGetLEDState.Name = "btnGetLEDState";
            btnGetLEDState.Size = new Size(111, 23);
            btnGetLEDState.TabIndex = 135;
            btnGetLEDState.Text = "Get LED State*";
            btnGetLEDState.UseVisualStyleBackColor = true;
            btnGetLEDState.Click += btnGetLEDState_Click;
            // 
            // label46
            // 
            label46.AutoSize = true;
            label46.Location = new Point(293, 626);
            label46.Name = "label46";
            label46.Size = new Size(117, 15);
            label46.TabIndex = 136;
            label46.Text = "*requires callback on";
            // 
            // btnAlwaysChangetoKVM
            // 
            btnAlwaysChangetoKVM.Location = new Point(874, 597);
            btnAlwaysChangetoKVM.Name = "btnAlwaysChangetoKVM";
            btnAlwaysChangetoKVM.Size = new Size(193, 23);
            btnAlwaysChangetoKVM.TabIndex = 139;
            btnAlwaysChangetoKVM.Text = "Always change to PID #8 (KVM)";
            btnAlwaysChangetoKVM.UseVisualStyleBackColor = true;
            btnAlwaysChangetoKVM.Click += btnAlwaysChangetoKVM_Click;
            // 
            // btnNoChangetoKVM
            // 
            btnNoChangetoKVM.Location = new Point(676, 597);
            btnNoChangetoKVM.Name = "btnNoChangetoKVM";
            btnNoChangetoKVM.Size = new Size(193, 23);
            btnNoChangetoKVM.TabIndex = 138;
            btnNoChangetoKVM.Text = "Do not change PID on reboot";
            btnNoChangetoKVM.UseVisualStyleBackColor = true;
            btnNoChangetoKVM.Click += btnNoChangetoKVM_Click;
            // 
            // label47
            // 
            label47.AutoSize = true;
            label47.Location = new Point(647, 579);
            label47.Name = "label47";
            label47.Size = new Size(272, 15);
            label47.TabIndex = 137;
            label47.Text = "KVM Reboot Mode (for users of the KVM PID only)";
            // 
            // btnVirtualButton
            // 
            btnVirtualButton.Location = new Point(1394, 25);
            btnVirtualButton.Name = "btnVirtualButton";
            btnVirtualButton.Size = new Size(96, 23);
            btnVirtualButton.TabIndex = 140;
            btnVirtualButton.Text = "Virtual Button";
            btnVirtualButton.UseVisualStyleBackColor = true;
            btnVirtualButton.Click += btnVirtualButton_Click;
            // 
            // txtVirtualButton
            // 
            txtVirtualButton.Location = new Point(1496, 26);
            txtVirtualButton.Name = "txtVirtualButton";
            txtVirtualButton.Size = new Size(34, 23);
            txtVirtualButton.TabIndex = 141;
            txtVirtualButton.Text = "104";
            // 
            // rbPress
            // 
            rbPress.AutoSize = true;
            rbPress.Location = new Point(1536, 25);
            rbPress.Name = "rbPress";
            rbPress.Size = new Size(52, 19);
            rbPress.TabIndex = 142;
            rbPress.TabStop = true;
            rbPress.Text = "Press";
            rbPress.UseVisualStyleBackColor = true;
            // 
            // rbRelease
            // 
            rbRelease.AutoSize = true;
            rbRelease.Location = new Point(1536, 41);
            rbRelease.Name = "rbRelease";
            rbRelease.Size = new Size(64, 19);
            rbRelease.TabIndex = 143;
            rbRelease.TabStop = true;
            rbRelease.Text = "Release";
            rbRelease.UseVisualStyleBackColor = true;
            // 
            // btnSaveGPIOConfiguration
            // 
            btnSaveGPIOConfiguration.Location = new Point(1329, 264);
            btnSaveGPIOConfiguration.Name = "btnSaveGPIOConfiguration";
            btnSaveGPIOConfiguration.Size = new Size(133, 23);
            btnSaveGPIOConfiguration.TabIndex = 146;
            btnSaveGPIOConfiguration.Text = "Save Configuration";
            btnSaveGPIOConfiguration.UseVisualStyleBackColor = true;
            btnSaveGPIOConfiguration.Click += btnSaveGPIOConfiguration_Click;
            // 
            // btnSetGPIOConfiguration
            // 
            btnSetGPIOConfiguration.Location = new Point(1190, 264);
            btnSetGPIOConfiguration.Name = "btnSetGPIOConfiguration";
            btnSetGPIOConfiguration.Size = new Size(133, 23);
            btnSetGPIOConfiguration.TabIndex = 145;
            btnSetGPIOConfiguration.Text = "Set Configuration";
            btnSetGPIOConfiguration.UseVisualStyleBackColor = true;
            btnSetGPIOConfiguration.Click += btnSetGPIOConfiguration_Click;
            // 
            // label48
            // 
            label48.AutoSize = true;
            label48.Location = new Point(1161, 163);
            label48.Name = "label48";
            label48.Size = new Size(111, 15);
            label48.TabIndex = 144;
            label48.Text = "GPIO Configuration";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(rbPin1Output);
            groupBox1.Controls.Add(rbPin1STG);
            groupBox1.Controls.Add(rbPin1DH);
            groupBox1.Location = new Point(1188, 182);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(98, 76);
            groupBox1.TabIndex = 147;
            groupBox1.TabStop = false;
            groupBox1.Text = "Pin 1";
            // 
            // rbPin1Output
            // 
            rbPin1Output.AutoSize = true;
            rbPin1Output.Location = new Point(6, 54);
            rbPin1Output.Name = "rbPin1Output";
            rbPin1Output.Size = new Size(63, 19);
            rbPin1Output.TabIndex = 2;
            rbPin1Output.TabStop = true;
            rbPin1Output.Text = "Output";
            rbPin1Output.UseVisualStyleBackColor = true;
            // 
            // rbPin1STG
            // 
            rbPin1STG.AutoSize = true;
            rbPin1STG.Location = new Point(6, 37);
            rbPin1STG.Name = "rbPin1STG";
            rbPin1STG.Size = new Size(80, 19);
            rbPin1STG.TabIndex = 1;
            rbPin1STG.TabStop = true;
            rbPin1STG.Text = "Input -STG";
            rbPin1STG.UseVisualStyleBackColor = true;
            // 
            // rbPin1DH
            // 
            rbPin1DH.AutoSize = true;
            rbPin1DH.Location = new Point(6, 19);
            rbPin1DH.Name = "rbPin1DH";
            rbPin1DH.Size = new Size(78, 19);
            rbPin1DH.TabIndex = 0;
            rbPin1DH.TabStop = true;
            rbPin1DH.Text = "Input -DH";
            rbPin1DH.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(rbPin2Output);
            groupBox2.Controls.Add(rbPin2STG);
            groupBox2.Controls.Add(rbPin2DH);
            groupBox2.Location = new Point(1292, 182);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(96, 76);
            groupBox2.TabIndex = 148;
            groupBox2.TabStop = false;
            groupBox2.Text = "Pin 2";
            // 
            // rbPin2Output
            // 
            rbPin2Output.AutoSize = true;
            rbPin2Output.Location = new Point(6, 54);
            rbPin2Output.Name = "rbPin2Output";
            rbPin2Output.Size = new Size(63, 19);
            rbPin2Output.TabIndex = 2;
            rbPin2Output.TabStop = true;
            rbPin2Output.Text = "Output";
            rbPin2Output.UseVisualStyleBackColor = true;
            // 
            // rbPin2STG
            // 
            rbPin2STG.AutoSize = true;
            rbPin2STG.Location = new Point(6, 37);
            rbPin2STG.Name = "rbPin2STG";
            rbPin2STG.Size = new Size(80, 19);
            rbPin2STG.TabIndex = 1;
            rbPin2STG.TabStop = true;
            rbPin2STG.Text = "Input -STG";
            rbPin2STG.UseVisualStyleBackColor = true;
            // 
            // rbPin2DH
            // 
            rbPin2DH.AutoSize = true;
            rbPin2DH.Location = new Point(6, 19);
            rbPin2DH.Name = "rbPin2DH";
            rbPin2DH.Size = new Size(78, 19);
            rbPin2DH.TabIndex = 0;
            rbPin2DH.TabStop = true;
            rbPin2DH.Text = "Input -DH";
            rbPin2DH.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(rbPin3Output);
            groupBox3.Controls.Add(rbPin3STG);
            groupBox3.Controls.Add(rbPin3DH);
            groupBox3.Location = new Point(1394, 182);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(96, 76);
            groupBox3.TabIndex = 149;
            groupBox3.TabStop = false;
            groupBox3.Text = "Pin 3";
            // 
            // rbPin3Output
            // 
            rbPin3Output.AutoSize = true;
            rbPin3Output.Location = new Point(6, 54);
            rbPin3Output.Name = "rbPin3Output";
            rbPin3Output.Size = new Size(63, 19);
            rbPin3Output.TabIndex = 2;
            rbPin3Output.TabStop = true;
            rbPin3Output.Text = "Output";
            rbPin3Output.UseVisualStyleBackColor = true;
            // 
            // rbPin3STG
            // 
            rbPin3STG.AutoSize = true;
            rbPin3STG.Location = new Point(6, 37);
            rbPin3STG.Name = "rbPin3STG";
            rbPin3STG.Size = new Size(80, 19);
            rbPin3STG.TabIndex = 1;
            rbPin3STG.TabStop = true;
            rbPin3STG.Text = "Input -STG";
            rbPin3STG.UseVisualStyleBackColor = true;
            // 
            // rbPin3DH
            // 
            rbPin3DH.AutoSize = true;
            rbPin3DH.Location = new Point(6, 19);
            rbPin3DH.Name = "rbPin3DH";
            rbPin3DH.Size = new Size(78, 19);
            rbPin3DH.TabIndex = 0;
            rbPin3DH.TabStop = true;
            rbPin3DH.Text = "Input -DH";
            rbPin3DH.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(rbPin4Output);
            groupBox4.Controls.Add(rbPin4STG);
            groupBox4.Controls.Add(rbPin4DH);
            groupBox4.Location = new Point(1496, 182);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(96, 76);
            groupBox4.TabIndex = 149;
            groupBox4.TabStop = false;
            groupBox4.Text = "Pin 4";
            // 
            // rbPin4Output
            // 
            rbPin4Output.AutoSize = true;
            rbPin4Output.Location = new Point(6, 54);
            rbPin4Output.Name = "rbPin4Output";
            rbPin4Output.Size = new Size(63, 19);
            rbPin4Output.TabIndex = 2;
            rbPin4Output.TabStop = true;
            rbPin4Output.Text = "Output";
            rbPin4Output.UseVisualStyleBackColor = true;
            // 
            // rbPin4STG
            // 
            rbPin4STG.AutoSize = true;
            rbPin4STG.Location = new Point(6, 37);
            rbPin4STG.Name = "rbPin4STG";
            rbPin4STG.Size = new Size(80, 19);
            rbPin4STG.TabIndex = 1;
            rbPin4STG.TabStop = true;
            rbPin4STG.Text = "Input -STG";
            rbPin4STG.UseVisualStyleBackColor = true;
            // 
            // rbPin4DH
            // 
            rbPin4DH.AutoSize = true;
            rbPin4DH.Location = new Point(6, 19);
            rbPin4DH.Name = "rbPin4DH";
            rbPin4DH.Size = new Size(78, 19);
            rbPin4DH.TabIndex = 0;
            rbPin4DH.TabStop = true;
            rbPin4DH.Text = "Input -DH";
            rbPin4DH.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1664, 758);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(btnSaveGPIOConfiguration);
            Controls.Add(btnSetGPIOConfiguration);
            Controls.Add(label48);
            Controls.Add(rbRelease);
            Controls.Add(rbPress);
            Controls.Add(txtVirtualButton);
            Controls.Add(btnVirtualButton);
            Controls.Add(btnAlwaysChangetoKVM);
            Controls.Add(btnNoChangetoKVM);
            Controls.Add(label47);
            Controls.Add(label46);
            Controls.Add(btnGetLEDState);
            Controls.Add(label45);
            Controls.Add(cboRGBLEDIndex2);
            Controls.Add(txtFlashFreq);
            Controls.Add(btnFlashFreq);
            Controls.Add(label44);
            Controls.Add(label43);
            Controls.Add(txtRGBDimBank2);
            Controls.Add(txtRGBDimBank1);
            Controls.Add(btnRGBDimFactors);
            Controls.Add(cboBankLegacy);
            Controls.Add(btnSetRGBLED);
            Controls.Add(chkFlash);
            Controls.Add(label42);
            Controls.Add(cboBank);
            Controls.Add(label41);
            Controls.Add(cboRGBLEDIndex);
            Controls.Add(label40);
            Controls.Add(label39);
            Controls.Add(label38);
            Controls.Add(txtBlue);
            Controls.Add(txtGreen);
            Controls.Add(txtRed);
            Controls.Add(label36);
            Controls.Add(cboColor);
            Controls.Add(label34);
            Controls.Add(listBox3);
            Controls.Add(chkPin3);
            Controls.Add(chkPin4);
            Controls.Add(lblVirtualButtons);
            Controls.Add(lblGPIOs);
            Controls.Add(lblScrLock);
            Controls.Add(lblCapsLock);
            Controls.Add(label35);
            Controls.Add(lblNumLock);
            Controls.Add(button1);
            Controls.Add(label33);
            Controls.Add(lblSiliconGeneratedID);
            Controls.Add(cboPIDs);
            Controls.Add(txtVersion);
            Controls.Add(btnWriteVersion);
            Controls.Add(label37);
            Controls.Add(lblVersion);
            Controls.Add(btnToPID1);
            Controls.Add(label32);
            Controls.Add(listBox2);
            Controls.Add(btnDescriptor);
            Controls.Add(label31);
            Controls.Add(btnMyComputer);
            Controls.Add(label27);
            Controls.Add(label28);
            Controls.Add(label29);
            Controls.Add(txtMultimediaLo);
            Controls.Add(txtMultimediaHi);
            Controls.Add(btnMultimedia);
            Controls.Add(label30);
            Controls.Add(label26);
            Controls.Add(label25);
            Controls.Add(txtMouseButton);
            Controls.Add(label20);
            Controls.Add(label21);
            Controls.Add(label22);
            Controls.Add(label23);
            Controls.Add(txtMouseWheel);
            Controls.Add(txtMouseY);
            Controls.Add(txtMouseX);
            Controls.Add(btnMouseReflector);
            Controls.Add(label24);
            Controls.Add(label19);
            Controls.Add(label18);
            Controls.Add(label17);
            Controls.Add(label16);
            Controls.Add(label15);
            Controls.Add(label14);
            Controls.Add(label13);
            Controls.Add(label12);
            Controls.Add(label11);
            Controls.Add(txtJoyHat);
            Controls.Add(txtJoyButton4);
            Controls.Add(txtJoyButton3);
            Controls.Add(txtJoyButton2);
            Controls.Add(txtJoyButton1);
            Controls.Add(txtJoySlider);
            Controls.Add(txtJoyZrot);
            Controls.Add(txtJoyZ);
            Controls.Add(txt);
            Controls.Add(txtJoyX);
            Controls.Add(btnJoystickReflector);
            Controls.Add(label10);
            Controls.Add(textBox1);
            Controls.Add(btnKeyboardReflector);
            Controls.Add(label9);
            Controls.Add(btnTimeStampOn);
            Controls.Add(btnTimeStampOff);
            Controls.Add(label8);
            Controls.Add(btnCustomData);
            Controls.Add(btnGenerateData);
            Controls.Add(label7);
            Controls.Add(btnSaveBacklights);
            Controls.Add(txtIntensityBank2);
            Controls.Add(txtIntensityBank1);
            Controls.Add(btnSetIntensity);
            Controls.Add(btnToggleBacklights);
            Controls.Add(label6);
            Controls.Add(chkAllBank2OnOff);
            Controls.Add(chkAllBank1OnOff);
            Controls.Add(chkBacklightOnOff);
            Controls.Add(cboBacklightIndex);
            Controls.Add(label5);
            Controls.Add(txtUnitID);
            Controls.Add(btnUnitID);
            Controls.Add(label4);
            Controls.Add(chkPin1);
            Controls.Add(chkPin2);
            Controls.Add(label3);
            Controls.Add(btnClear);
            Controls.Add(lblUnitID);
            Controls.Add(lblButtons);
            Controls.Add(lblAbsTime);
            Controls.Add(lblDeltaTime);
            Controls.Add(listBox1);
            Controls.Add(btnCallback);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(statusStrip1);
            Controls.Add(cboDevices);
            Controls.Add(btnEnumerate);
            Name = "Form1";
            Text = "C# .NET 7.0 Sample for XBM-24 Module/XBE-24";
            FormClosed += Form1_FormClosed;
            Load += Form1_Load;
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnEnumerate;
        private ComboBox cboDevices;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private Label label1;
        private Label label2;
        private Button btnCallback;
        private ListBox listBox1;
        private Label lblDeltaTime;
        private Label lblAbsTime;
        private Label lblButtons;
        private Label lblUnitID;
        private Button btnClear;
        private Label label3;
        private CheckBox chkPin2;
        private CheckBox chkPin1;
        private Label label4;
        private Button btnUnitID;
        private TextBox txtUnitID;
        private Label label5;
        private ComboBox cboBacklightIndex;
        private CheckBox chkBacklightOnOff;
        private CheckBox chkAllBank1OnOff;
        private CheckBox chkAllBank2OnOff;
        private Label label6;
        private Button btnToggleBacklights;
        private Button btnSetIntensity;
        private TextBox txtIntensityBank1;
        private TextBox txtIntensityBank2;
        private Button btnSaveBacklights;
        private Button btnCustomData;
        private Button btnGenerateData;
        private Label label7;
        private Button btnTimeStampOn;
        private Button btnTimeStampOff;
        private Label label8;
        private TextBox textBox1;
        private Button btnKeyboardReflector;
        private Label label9;
        private Button btnJoystickReflector;
        private Label label10;
        private TextBox txtJoyX;
        private TextBox txt;
        private TextBox txtJoyZ;
        private TextBox txtJoyZrot;
        private TextBox txtJoySlider;
        private TextBox txtJoyButton1;
        private TextBox txtJoyButton2;
        private TextBox txtJoyButton3;
        private TextBox txtJoyButton4;
        private TextBox txtJoyHat;
        private Label label11;
        private Label label12;
        private Label label13;
        private Label label14;
        private Label label15;
        private Label label16;
        private Label label17;
        private Label label18;
        private Label label19;
        private Label label20;
        private Label label21;
        private Label label22;
        private Label label23;
        private TextBox txtMouseWheel;
        private TextBox txtMouseY;
        private TextBox txtMouseX;
        private Button btnMouseReflector;
        private Label label24;
        private TextBox txtMouseButton;
        private Label label25;
        private Label label26;
        private Label label27;
        private Label label28;
        private Label label29;
        private TextBox txtMultimediaLo;
        private TextBox txtMultimediaHi;
        private Button btnMultimedia;
        private Label label30;
        private Button btnMyComputer;
        private Button btnDescriptor;
        private Label label31;
        private ListBox listBox2;
        private Button btnToPID1;
        private Label label32;
        private TextBox txtVersion;
        private Button btnWriteVersion;
        private Label label37;
        private Label lblVersion;
        private ComboBox cboPIDs;
        private Button button1;
        private Label label33;
        private Label lblSiliconGeneratedID;
        private Label lblNumLock;
        private Label label35;
        private Label lblCapsLock;
        private Label lblScrLock;
        private Label lblGPIOs;
        private Label lblVirtualButtons;
        private CheckBox chkPin3;
        private CheckBox chkPin4;
        private ListBox listBox3;
        private Label label34;
        private ComboBox cboColor;
        private Label label36;
        private TextBox txtRed;
        private TextBox txtGreen;
        private TextBox txtBlue;
        private Label label38;
        private Label label39;
        private Label label40;
        private ComboBox cboRGBLEDIndex;
        private Label label41;
        private ComboBox cboBank;
        private Label label42;
        private CheckBox chkFlash;
        private Button btnSetRGBLED;
        private ComboBox cboBankLegacy;
        private TextBox txtRGBDimBank2;
        private TextBox txtRGBDimBank1;
        private Button btnRGBDimFactors;
        private Label label43;
        private Label label44;
        private TextBox txtFlashFreq;
        private Button btnFlashFreq;
        private Label label45;
        private ComboBox cboRGBLEDIndex2;
        private Button btnGetLEDState;
        private Label label46;
        private Button btnAlwaysChangetoKVM;
        private Button btnNoChangetoKVM;
        private Label label47;
        private Button btnVirtualButton;
        private TextBox txtVirtualButton;
        private RadioButton rbPress;
        private RadioButton rbRelease;
        private Button btnSaveGPIOConfiguration;
        private Button btnSetGPIOConfiguration;
        private Label label48;
        private GroupBox groupBox1;
        private RadioButton rbPin1DH;
        private RadioButton rbPin1Output;
        private RadioButton rbPin1STG;
        private GroupBox groupBox2;
        private RadioButton rbPin2Output;
        private RadioButton rbPin2STG;
        private RadioButton rbPin2DH;
        private GroupBox groupBox3;
        private RadioButton rbPin3Output;
        private RadioButton rbPin3STG;
        private RadioButton rbPin3DH;
        private GroupBox groupBox4;
        private RadioButton rbPin4Output;
        private RadioButton rbPin4STG;
        private RadioButton rbPin4DH;
    }
}