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
            lblSwitchPosition = new Label();
            lblButtons = new Label();
            lblUnitID = new Label();
            btnClear = new Button();
            label3 = new Label();
            chkRed = new CheckBox();
            chkGreen = new CheckBox();
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
            btnToPID2 = new Button();
            btnToPID3 = new Button();
            btnToPID4 = new Button();
            label33 = new Label();
            label34 = new Label();
            label35 = new Label();
            label36 = new Label();
            txtVersion = new TextBox();
            btnWriteVersion = new Button();
            label37 = new Label();
            lblVersion = new Label();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // btnEnumerate
            // 
            btnEnumerate.Location = new Point(38, 25);
            btnEnumerate.Name = "btnEnumerate";
            btnEnumerate.Size = new Size(75, 23);
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
            statusStrip1.Location = new Point(0, 680);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(1199, 22);
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
            lblDeltaTime.Location = new Point(355, 650);
            lblDeltaTime.Name = "lblDeltaTime";
            lblDeltaTime.Size = new Size(60, 15);
            lblDeltaTime.TabIndex = 7;
            lblDeltaTime.Text = "delta time";
            // 
            // lblAbsTime
            // 
            lblAbsTime.AutoSize = true;
            lblAbsTime.Location = new Point(355, 631);
            lblAbsTime.Name = "lblAbsTime";
            lblAbsTime.Size = new Size(79, 15);
            lblAbsTime.TabIndex = 8;
            lblAbsTime.Text = "absolute time";
            // 
            // lblSwitchPosition
            // 
            lblSwitchPosition.AutoSize = true;
            lblSwitchPosition.Location = new Point(41, 238);
            lblSwitchPosition.Name = "lblSwitchPosition";
            lblSwitchPosition.Size = new Size(91, 15);
            lblSwitchPosition.TabIndex = 9;
            lblSwitchPosition.Text = "Switch Position:";
            // 
            // lblButtons
            // 
            lblButtons.AutoSize = true;
            lblButtons.Location = new Point(41, 253);
            lblButtons.Name = "lblButtons";
            lblButtons.Size = new Size(51, 15);
            lblButtons.TabIndex = 10;
            lblButtons.Text = "Buttons:";
            // 
            // lblUnitID
            // 
            lblUnitID.AutoSize = true;
            lblUnitID.Location = new Point(259, 371);
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
            label3.Location = new Point(12, 297);
            label3.Name = "label3";
            label3.Size = new Size(70, 15);
            label3.TabIndex = 13;
            label3.Text = "LED Control";
            // 
            // chkRed
            // 
            chkRed.AutoSize = true;
            chkRed.Location = new Point(104, 315);
            chkRed.Name = "chkRed";
            chkRed.Size = new Size(46, 19);
            chkRed.TabIndex = 14;
            chkRed.Text = "Red";
            chkRed.ThreeState = true;
            chkRed.UseVisualStyleBackColor = true;
            chkRed.CheckStateChanged += chkRed_CheckStateChanged;
            // 
            // chkGreen
            // 
            chkGreen.AutoSize = true;
            chkGreen.Location = new Point(41, 315);
            chkGreen.Name = "chkGreen";
            chkGreen.Size = new Size(57, 19);
            chkGreen.TabIndex = 15;
            chkGreen.Text = "Green";
            chkGreen.ThreeState = true;
            chkGreen.UseVisualStyleBackColor = true;
            chkGreen.CheckStateChanged += chkGreen_CheckStateChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 349);
            label4.Name = "label4";
            label4.Size = new Size(74, 15);
            label4.TabIndex = 16;
            label4.Text = "Write Unit ID";
            // 
            // btnUnitID
            // 
            btnUnitID.Location = new Point(41, 367);
            btnUnitID.Name = "btnUnitID";
            btnUnitID.Size = new Size(133, 23);
            btnUnitID.TabIndex = 17;
            btnUnitID.Text = "Write Unit ID";
            btnUnitID.UseVisualStyleBackColor = true;
            btnUnitID.Click += btnUnitID_Click;
            // 
            // txtUnitID
            // 
            txtUnitID.Location = new Point(180, 367);
            txtUnitID.Name = "txtUnitID";
            txtUnitID.Size = new Size(73, 23);
            txtUnitID.TabIndex = 18;
            txtUnitID.Text = "1";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 405);
            label5.Name = "label5";
            label5.Size = new Size(158, 15);
            label5.TabIndex = 19;
            label5.Text = "Individual Backlight Features";
            // 
            // cboBacklightIndex
            // 
            cboBacklightIndex.FormattingEnabled = true;
            cboBacklightIndex.Items.AddRange(new object[] { "0-b1", "1-b1", "2-b1", "3-b1", "4-b1", "5-b1", "8-b1", "9-b1", "10-b1", "11-b1", "12-b1", "13-b1", "16-b1", "17-b1", "18-b1", "19-b1", "20-b1", "21-b1", "24-b1", "25-b1", "26-b1", "27-b1", "28-b1", "29-b1", "0-b2", "1-b2", "2-b2", "3-b2", "4-b2", "5-b2", "8-b2", "9-b2", "10-b2", "11-b2", "12-b2", "13-b2", "16-b2", "17-b2", "18-b2", "19-b2", "20-b2", "21-b2", "24-b2", "25-b2", "26-b2", "27-b2", "28-b2", "29-b2" });
            cboBacklightIndex.Location = new Point(41, 423);
            cboBacklightIndex.Name = "cboBacklightIndex";
            cboBacklightIndex.Size = new Size(72, 23);
            cboBacklightIndex.TabIndex = 20;
            // 
            // chkBacklightOnOff
            // 
            chkBacklightOnOff.AutoSize = true;
            chkBacklightOnOff.Location = new Point(119, 425);
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
            chkAllBank1OnOff.Location = new Point(221, 425);
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
            chkAllBank2OnOff.Location = new Point(346, 424);
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
            label6.Location = new Point(12, 467);
            label6.Name = "label6";
            label6.Size = new Size(140, 15);
            label6.TabIndex = 24;
            label6.Text = "Global Backlight Features";
            // 
            // btnToggleBacklights
            // 
            btnToggleBacklights.Location = new Point(41, 485);
            btnToggleBacklights.Name = "btnToggleBacklights";
            btnToggleBacklights.Size = new Size(133, 23);
            btnToggleBacklights.TabIndex = 25;
            btnToggleBacklights.Text = "Toggle Backlights";
            btnToggleBacklights.UseVisualStyleBackColor = true;
            btnToggleBacklights.Click += btnToggleBacklights_Click;
            // 
            // btnSetIntensity
            // 
            btnSetIntensity.Location = new Point(207, 485);
            btnSetIntensity.Name = "btnSetIntensity";
            btnSetIntensity.Size = new Size(133, 23);
            btnSetIntensity.TabIndex = 26;
            btnSetIntensity.Text = "Set Intensity";
            btnSetIntensity.UseVisualStyleBackColor = true;
            btnSetIntensity.Click += btnSetIntensity_Click;
            // 
            // txtIntensityBank1
            // 
            txtIntensityBank1.Location = new Point(346, 485);
            txtIntensityBank1.Name = "txtIntensityBank1";
            txtIntensityBank1.Size = new Size(46, 23);
            txtIntensityBank1.TabIndex = 27;
            txtIntensityBank1.Text = "1";
            // 
            // txtIntensityBank2
            // 
            txtIntensityBank2.Location = new Point(398, 485);
            txtIntensityBank2.Name = "txtIntensityBank2";
            txtIntensityBank2.Size = new Size(46, 23);
            txtIntensityBank2.TabIndex = 28;
            txtIntensityBank2.Text = "1";
            // 
            // btnSaveBacklights
            // 
            btnSaveBacklights.Location = new Point(41, 514);
            btnSaveBacklights.Name = "btnSaveBacklights";
            btnSaveBacklights.Size = new Size(133, 23);
            btnSaveBacklights.TabIndex = 29;
            btnSaveBacklights.Text = "Save Backlights";
            btnSaveBacklights.UseVisualStyleBackColor = true;
            btnSaveBacklights.Click += btnSaveBacklights_Click;
            // 
            // btnCustomData
            // 
            btnCustomData.Location = new Point(202, 575);
            btnCustomData.Name = "btnCustomData";
            btnCustomData.Size = new Size(133, 23);
            btnCustomData.TabIndex = 32;
            btnCustomData.Text = "Custom Data";
            btnCustomData.UseVisualStyleBackColor = true;
            btnCustomData.Click += btnCustomData_Click;
            // 
            // btnGenerateData
            // 
            btnGenerateData.Location = new Point(41, 575);
            btnGenerateData.Name = "btnGenerateData";
            btnGenerateData.Size = new Size(133, 23);
            btnGenerateData.TabIndex = 31;
            btnGenerateData.Text = "Generate Data";
            btnGenerateData.UseVisualStyleBackColor = true;
            btnGenerateData.Click += btnGenerateData_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(12, 557);
            label7.Name = "label7";
            label7.Size = new Size(383, 15);
            label7.TabIndex = 30;
            label7.Text = "Stimulate a general incoming data report or send a custom input report";
            // 
            // btnTimeStampOn
            // 
            btnTimeStampOn.Location = new Point(202, 631);
            btnTimeStampOn.Name = "btnTimeStampOn";
            btnTimeStampOn.Size = new Size(133, 23);
            btnTimeStampOn.TabIndex = 35;
            btnTimeStampOn.Text = "Time Stamp On";
            btnTimeStampOn.UseVisualStyleBackColor = true;
            btnTimeStampOn.Click += btnTimeStampOn_Click;
            // 
            // btnTimeStampOff
            // 
            btnTimeStampOff.Location = new Point(41, 631);
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
            label8.Location = new Point(12, 613);
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
            textBox1.Text = "1";
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
            btnJoystickReflector.Location = new Point(676, 86);
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
            label10.Location = new Point(647, 68);
            label10.Name = "label10";
            label10.Size = new Size(98, 15);
            label10.TabIndex = 39;
            label10.Text = "Joystick Reflector";
            // 
            // txtJoyX
            // 
            txtJoyX.Location = new Point(815, 87);
            txtJoyX.Name = "txtJoyX";
            txtJoyX.Size = new Size(35, 23);
            txtJoyX.TabIndex = 41;
            txtJoyX.Text = "0";
            // 
            // txt
            // 
            txt.Location = new Point(855, 87);
            txt.Name = "txt";
            txt.Size = new Size(35, 23);
            txt.TabIndex = 42;
            txt.Text = "0";
            // 
            // txtJoyZ
            // 
            txtJoyZ.Location = new Point(895, 87);
            txtJoyZ.Name = "txtJoyZ";
            txtJoyZ.Size = new Size(35, 23);
            txtJoyZ.TabIndex = 43;
            txtJoyZ.Text = "0";
            // 
            // txtJoyZrot
            // 
            txtJoyZrot.Location = new Point(935, 87);
            txtJoyZrot.Name = "txtJoyZrot";
            txtJoyZrot.Size = new Size(35, 23);
            txtJoyZrot.TabIndex = 44;
            txtJoyZrot.Text = "0";
            // 
            // txtJoySlider
            // 
            txtJoySlider.Location = new Point(975, 87);
            txtJoySlider.Name = "txtJoySlider";
            txtJoySlider.Size = new Size(35, 23);
            txtJoySlider.TabIndex = 45;
            txtJoySlider.Text = "0";
            // 
            // txtJoyButton1
            // 
            txtJoyButton1.Location = new Point(815, 132);
            txtJoyButton1.Name = "txtJoyButton1";
            txtJoyButton1.Size = new Size(35, 23);
            txtJoyButton1.TabIndex = 46;
            txtJoyButton1.Text = "0";
            // 
            // txtJoyButton2
            // 
            txtJoyButton2.Location = new Point(855, 132);
            txtJoyButton2.Name = "txtJoyButton2";
            txtJoyButton2.Size = new Size(35, 23);
            txtJoyButton2.TabIndex = 47;
            txtJoyButton2.Text = "0";
            // 
            // txtJoyButton3
            // 
            txtJoyButton3.Location = new Point(895, 132);
            txtJoyButton3.Name = "txtJoyButton3";
            txtJoyButton3.Size = new Size(35, 23);
            txtJoyButton3.TabIndex = 48;
            txtJoyButton3.Text = "0";
            // 
            // txtJoyButton4
            // 
            txtJoyButton4.Location = new Point(935, 132);
            txtJoyButton4.Name = "txtJoyButton4";
            txtJoyButton4.Size = new Size(35, 23);
            txtJoyButton4.TabIndex = 49;
            txtJoyButton4.Text = "0";
            // 
            // txtJoyHat
            // 
            txtJoyHat.Location = new Point(976, 132);
            txtJoyHat.Name = "txtJoyHat";
            txtJoyHat.Size = new Size(35, 23);
            txtJoyHat.TabIndex = 50;
            txtJoyHat.Text = "0";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(815, 68);
            label11.Name = "label11";
            label11.Size = new Size(14, 15);
            label11.TabIndex = 51;
            label11.Text = "X";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(855, 68);
            label12.Name = "label12";
            label12.Size = new Size(14, 15);
            label12.TabIndex = 52;
            label12.Text = "Y";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(895, 68);
            label13.Name = "label13";
            label13.Size = new Size(14, 15);
            label13.TabIndex = 53;
            label13.Text = "Z";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(935, 68);
            label14.Name = "label14";
            label14.Size = new Size(29, 15);
            label14.TabIndex = 54;
            label14.Text = "Zrot";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(975, 68);
            label15.Name = "label15";
            label15.Size = new Size(36, 15);
            label15.TabIndex = 55;
            label15.Text = "Slider";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(1016, 90);
            label16.Name = "label16";
            label16.Size = new Size(44, 15);
            label16.TabIndex = 56;
            label16.Text = "(0-255)";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(882, 114);
            label17.Name = "label17";
            label17.Size = new Size(48, 15);
            label17.TabIndex = 57;
            label17.Text = "Buttons";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new Point(976, 114);
            label18.Name = "label18";
            label18.Size = new Size(26, 15);
            label18.TabIndex = 58;
            label18.Text = "Hat";
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Location = new Point(676, 116);
            label19.Name = "label19";
            label19.Size = new Size(106, 15);
            label19.TabIndex = 59;
            label19.Text = "PID #2 and #3 only";
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Location = new Point(895, 226);
            label20.Name = "label20";
            label20.Size = new Size(40, 15);
            label20.TabIndex = 69;
            label20.Text = "Wheel";
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Location = new Point(855, 226);
            label21.Name = "label21";
            label21.Size = new Size(21, 15);
            label21.TabIndex = 68;
            label21.Text = "dY";
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Location = new Point(815, 226);
            label22.Name = "label22";
            label22.Size = new Size(21, 15);
            label22.TabIndex = 67;
            label22.Text = "dX";
            // 
            // label23
            // 
            label23.AutoSize = true;
            label23.Location = new Point(815, 181);
            label23.Name = "label23";
            label23.Size = new Size(43, 15);
            label23.TabIndex = 66;
            label23.Text = "Button";
            // 
            // txtMouseWheel
            // 
            txtMouseWheel.Location = new Point(895, 245);
            txtMouseWheel.Name = "txtMouseWheel";
            txtMouseWheel.Size = new Size(35, 23);
            txtMouseWheel.TabIndex = 65;
            txtMouseWheel.Text = "0";
            // 
            // txtMouseY
            // 
            txtMouseY.Location = new Point(855, 245);
            txtMouseY.Name = "txtMouseY";
            txtMouseY.Size = new Size(35, 23);
            txtMouseY.TabIndex = 64;
            txtMouseY.Text = "20";
            // 
            // txtMouseX
            // 
            txtMouseX.Location = new Point(815, 245);
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
            txtMouseButton.Location = new Point(815, 200);
            txtMouseButton.Name = "txtMouseButton";
            txtMouseButton.Size = new Size(35, 23);
            txtMouseButton.TabIndex = 70;
            txtMouseButton.Text = "0";
            // 
            // label25
            // 
            label25.AutoSize = true;
            label25.Location = new Point(856, 203);
            label25.Name = "label25";
            label25.Size = new Size(280, 15);
            label25.TabIndex = 71;
            label25.Text = "1=left, 2=right, 4=center, 8=XButton1, 16=XButton2";
            // 
            // label26
            // 
            label26.AutoSize = true;
            label26.Location = new Point(676, 226);
            label26.Name = "label26";
            label26.Size = new Size(131, 15);
            label26.TabIndex = 72;
            label26.Text = "PID #1, #2,  and #4 only";
            // 
            // label27
            // 
            label27.AutoSize = true;
            label27.Location = new Point(674, 327);
            label27.Name = "label27";
            label27.Size = new Size(67, 15);
            label27.TabIndex = 79;
            label27.Text = "PID #4 only";
            // 
            // label28
            // 
            label28.AutoSize = true;
            label28.Location = new Point(893, 279);
            label28.Name = "label28";
            label28.Size = new Size(59, 15);
            label28.TabIndex = 78;
            label28.Text = "Low (hex)";
            // 
            // label29
            // 
            label29.AutoSize = true;
            label29.Location = new Point(813, 279);
            label29.Name = "label29";
            label29.Size = new Size(63, 15);
            label29.TabIndex = 77;
            label29.Text = "High (hex)";
            // 
            // txtMultimediaLo
            // 
            txtMultimediaLo.Location = new Point(893, 298);
            txtMultimediaLo.Name = "txtMultimediaLo";
            txtMultimediaLo.Size = new Size(35, 23);
            txtMultimediaLo.TabIndex = 76;
            txtMultimediaLo.Text = "E2";
            // 
            // txtMultimediaHi
            // 
            txtMultimediaHi.Location = new Point(813, 298);
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
            label30.Location = new Point(645, 279);
            label30.Name = "label30";
            label30.Size = new Size(118, 15);
            label30.TabIndex = 73;
            label30.Text = "Multimedia Reflector";
            // 
            // btnMyComputer
            // 
            btnMyComputer.Location = new Point(975, 298);
            btnMyComputer.Name = "btnMyComputer";
            btnMyComputer.Size = new Size(133, 23);
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
            btnToPID1.Location = new Point(676, 497);
            btnToPID1.Name = "btnToPID1";
            btnToPID1.Size = new Size(133, 23);
            btnToPID1.TabIndex = 85;
            btnToPID1.Tag = "0";
            btnToPID1.Text = "To PID #1";
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
            // btnToPID2
            // 
            btnToPID2.Location = new Point(676, 526);
            btnToPID2.Name = "btnToPID2";
            btnToPID2.Size = new Size(133, 23);
            btnToPID2.TabIndex = 86;
            btnToPID2.Tag = "1";
            btnToPID2.Text = "To PID #2";
            btnToPID2.UseVisualStyleBackColor = true;
            btnToPID2.Click += btnToPID1_Click;
            // 
            // btnToPID3
            // 
            btnToPID3.Location = new Point(676, 555);
            btnToPID3.Name = "btnToPID3";
            btnToPID3.Size = new Size(133, 23);
            btnToPID3.TabIndex = 87;
            btnToPID3.Tag = "2";
            btnToPID3.Text = "To PID #3";
            btnToPID3.UseVisualStyleBackColor = true;
            btnToPID3.Click += btnToPID1_Click;
            // 
            // btnToPID4
            // 
            btnToPID4.Location = new Point(676, 584);
            btnToPID4.Name = "btnToPID4";
            btnToPID4.Size = new Size(133, 23);
            btnToPID4.TabIndex = 88;
            btnToPID4.Tag = "3";
            btnToPID4.Text = "To PID #4";
            btnToPID4.UseVisualStyleBackColor = true;
            btnToPID4.Click += btnToPID1_Click;
            // 
            // label33
            // 
            label33.AutoSize = true;
            label33.Location = new Point(815, 501);
            label33.Name = "label33";
            label33.Size = new Size(241, 15);
            label33.TabIndex = 89;
            label33.Text = "Endpoints: Keyboard, Joystick, Input, Output";
            // 
            // label34
            // 
            label34.AutoSize = true;
            label34.Location = new Point(815, 530);
            label34.Name = "label34";
            label34.Size = new Size(202, 15);
            label34.TabIndex = 90;
            label34.Text = "Endpoints: Keyboard, Mouse, Output";
            // 
            // label35
            // 
            label35.AutoSize = true;
            label35.Location = new Point(815, 559);
            label35.Name = "label35";
            label35.Size = new Size(327, 15);
            label35.TabIndex = 91;
            label35.Text = "Endpoints: Keyboard, Mouse, Input, Output (Factory Default)";
            // 
            // label36
            // 
            label36.AutoSize = true;
            label36.Location = new Point(815, 588);
            label36.Name = "label36";
            label36.Size = new Size(269, 15);
            label36.TabIndex = 92;
            label36.Text = "Endpoints: Keyboard, Mouse, Multimedia, Output";
            // 
            // txtVersion
            // 
            txtVersion.Location = new Point(815, 642);
            txtVersion.Name = "txtVersion";
            txtVersion.Size = new Size(73, 23);
            txtVersion.TabIndex = 96;
            txtVersion.Text = "1";
            // 
            // btnWriteVersion
            // 
            btnWriteVersion.Location = new Point(676, 642);
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
            label37.Location = new Point(647, 624);
            label37.Name = "label37";
            label37.Size = new Size(128, 15);
            label37.TabIndex = 94;
            label37.Text = "Write Version (0-65535)";
            // 
            // lblVersion
            // 
            lblVersion.AutoSize = true;
            lblVersion.Location = new Point(894, 646);
            lblVersion.Name = "lblVersion";
            lblVersion.Size = new Size(45, 15);
            lblVersion.TabIndex = 93;
            lblVersion.Text = "version";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1199, 702);
            Controls.Add(txtVersion);
            Controls.Add(btnWriteVersion);
            Controls.Add(label37);
            Controls.Add(lblVersion);
            Controls.Add(label36);
            Controls.Add(label35);
            Controls.Add(label34);
            Controls.Add(label33);
            Controls.Add(btnToPID4);
            Controls.Add(btnToPID3);
            Controls.Add(btnToPID2);
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
            Controls.Add(chkGreen);
            Controls.Add(chkRed);
            Controls.Add(label3);
            Controls.Add(btnClear);
            Controls.Add(lblUnitID);
            Controls.Add(lblButtons);
            Controls.Add(lblSwitchPosition);
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
            Text = "C# .NET 7.0 Sample for XK-24";
            FormClosed += Form1_FormClosed;
            Load += Form1_Load;
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
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
        private Label lblSwitchPosition;
        private Label lblButtons;
        private Label lblUnitID;
        private Button btnClear;
        private Label label3;
        private CheckBox chkRed;
        private CheckBox chkGreen;
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
        private Button btnToPID2;
        private Button btnToPID3;
        private Button btnToPID4;
        private Label label33;
        private Label label34;
        private Label label35;
        private Label label36;
        private TextBox txtVersion;
        private Button btnWriteVersion;
        private Label label37;
        private Label lblVersion;
    }
}