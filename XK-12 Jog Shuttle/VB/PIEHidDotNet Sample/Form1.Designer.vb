<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.BtnCallback = New System.Windows.Forms.Button()
        Me.CboDevices = New System.Windows.Forms.ComboBox()
        Me.LblStatus = New System.Windows.Forms.Label()
        Me.BtnEnumerate = New System.Windows.Forms.Button()
        Me.LblSwitchPos = New System.Windows.Forms.Label()
        Me.LblUnitID = New System.Windows.Forms.Label()
        Me.TxtUnitID = New System.Windows.Forms.TextBox()
        Me.BtnWriteUnitID = New System.Windows.Forms.Button()
        Me.label3 = New System.Windows.Forms.Label()
        Me.label2 = New System.Windows.Forms.Label()
        Me.label1 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.BtnBL = New System.Windows.Forms.Button()
        Me.ChkScrollLock = New System.Windows.Forms.CheckBox()
        Me.BtnSaveBL = New System.Windows.Forms.Button()
        Me.BtnToPID2 = New System.Windows.Forms.Button()
        Me.ToPID1 = New System.Windows.Forms.Button()
        Me.textBox1 = New System.Windows.Forms.TextBox()
        Me.BtnKBreflect = New System.Windows.Forms.Button()
        Me.label7 = New System.Windows.Forms.Label()
        Me.label12 = New System.Windows.Forms.Label()
        Me.textBox6 = New System.Windows.Forms.TextBox()
        Me.textBox5 = New System.Windows.Forms.TextBox()
        Me.label11 = New System.Windows.Forms.Label()
        Me.label10 = New System.Windows.Forms.Label()
        Me.label9 = New System.Windows.Forms.Label()
        Me.label8 = New System.Windows.Forms.Label()
        Me.textBox4 = New System.Windows.Forms.TextBox()
        Me.textBox3 = New System.Windows.Forms.TextBox()
        Me.textBox2 = New System.Windows.Forms.TextBox()
        Me.BtnJoyreflect = New System.Windows.Forms.Button()
        Me.label23 = New System.Windows.Forms.Label()
        Me.lbldeltatime = New System.Windows.Forms.Label()
        Me.lblabstime = New System.Windows.Forms.Label()
        Me.BtnTimeStamp = New System.Windows.Forms.Button()
        Me.listBox2 = New System.Windows.Forms.ListBox()
        Me.BtnDescriptor = New System.Windows.Forms.Button()
        Me.label21 = New System.Windows.Forms.Label()
        Me.BtnBLToggle = New System.Windows.Forms.Button()
        Me.BtnTimeStampOn = New System.Windows.Forms.Button()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.BtnSetFlash = New System.Windows.Forms.Button()
        Me.TxtFlashFreq = New System.Windows.Forms.TextBox()
        Me.ChkRedOnOff = New System.Windows.Forms.CheckBox()
        Me.ChkGreenOnOff = New System.Windows.Forms.CheckBox()
        Me.ChkGreenLED = New System.Windows.Forms.CheckBox()
        Me.ChkFRedLED = New System.Windows.Forms.CheckBox()
        Me.ChkFGreenLED = New System.Windows.Forms.CheckBox()
        Me.ChkRedLED = New System.Windows.Forms.CheckBox()
        Me.CboKeyIndex = New System.Windows.Forms.ComboBox()
        Me.ChkFlash = New System.Windows.Forms.CheckBox()
        Me.ChkBLOnOff = New System.Windows.Forms.CheckBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.BtnGetDataNow = New System.Windows.Forms.Button()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.TextBox7 = New System.Windows.Forms.TextBox()
        Me.TextBox8 = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.TextBox9 = New System.Windows.Forms.TextBox()
        Me.TextBox10 = New System.Windows.Forms.TextBox()
        Me.TextBox11 = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.label29 = New System.Windows.Forms.Label()
        Me.BtnMousereflect = New System.Windows.Forms.Button()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.label28 = New System.Windows.Forms.Label()
        Me.LblShuttle = New System.Windows.Forms.Label()
        Me.LblJog = New System.Windows.Forms.Label()
        Me.LblJogD = New System.Windows.Forms.Label()
        Me.LblShuttleD = New System.Windows.Forms.Label()
        Me.LblButtons = New System.Windows.Forms.Label()
        Me.ChkSuppress = New System.Windows.Forms.CheckBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.label37 = New System.Windows.Forms.Label()
        Me.TxtWheelX = New System.Windows.Forms.TextBox()
        Me.label31 = New System.Windows.Forms.Label()
        Me.label30 = New System.Windows.Forms.Label()
        Me.TxtWheel = New System.Windows.Forms.TextBox()
        Me.label32 = New System.Windows.Forms.Label()
        Me.label33 = New System.Windows.Forms.Label()
        Me.label34 = New System.Windows.Forms.Label()
        Me.TxtMouseButtons = New System.Windows.Forms.TextBox()
        Me.TxtMouseY = New System.Windows.Forms.TextBox()
        Me.TxtMouseX = New System.Windows.Forms.TextBox()
        Me.BtnCustom = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.Location = New System.Drawing.Point(9, 119)
        Me.ListBox1.Margin = New System.Windows.Forms.Padding(2)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(435, 82)
        Me.ListBox1.TabIndex = 19
        '
        'BtnCallback
        '
        Me.BtnCallback.Location = New System.Drawing.Point(9, 93)
        Me.BtnCallback.Margin = New System.Windows.Forms.Padding(2)
        Me.BtnCallback.Name = "BtnCallback"
        Me.BtnCallback.Size = New System.Drawing.Size(122, 22)
        Me.BtnCallback.TabIndex = 18
        Me.BtnCallback.Text = "Setup for Callback"
        Me.BtnCallback.UseVisualStyleBackColor = True
        '
        'CboDevices
        '
        Me.CboDevices.FormattingEnabled = True
        Me.CboDevices.Location = New System.Drawing.Point(9, 43)
        Me.CboDevices.Margin = New System.Windows.Forms.Padding(2)
        Me.CboDevices.Name = "CboDevices"
        Me.CboDevices.Size = New System.Drawing.Size(435, 21)
        Me.CboDevices.TabIndex = 17
        '
        'LblStatus
        '
        Me.LblStatus.Location = New System.Drawing.Point(52, 569)
        Me.LblStatus.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LblStatus.Name = "LblStatus"
        Me.LblStatus.Size = New System.Drawing.Size(264, 19)
        Me.LblStatus.TabIndex = 16
        Me.LblStatus.Text = "No Device Enumerated"
        '
        'BtnEnumerate
        '
        Me.BtnEnumerate.Location = New System.Drawing.Point(9, 18)
        Me.BtnEnumerate.Margin = New System.Windows.Forms.Padding(2)
        Me.BtnEnumerate.Name = "BtnEnumerate"
        Me.BtnEnumerate.Size = New System.Drawing.Size(122, 22)
        Me.BtnEnumerate.TabIndex = 15
        Me.BtnEnumerate.Text = "Enumerate"
        Me.BtnEnumerate.UseVisualStyleBackColor = True
        '
        'LblSwitchPos
        '
        Me.LblSwitchPos.AutoSize = True
        Me.LblSwitchPos.Location = New System.Drawing.Point(11, 203)
        Me.LblSwitchPos.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LblSwitchPos.Name = "LblSwitchPos"
        Me.LblSwitchPos.Size = New System.Drawing.Size(79, 13)
        Me.LblSwitchPos.TabIndex = 23
        Me.LblSwitchPos.Text = "Switch Position"
        '
        'LblUnitID
        '
        Me.LblUnitID.Location = New System.Drawing.Point(129, 318)
        Me.LblUnitID.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LblUnitID.Name = "LblUnitID"
        Me.LblUnitID.Size = New System.Drawing.Size(54, 20)
        Me.LblUnitID.TabIndex = 26
        Me.LblUnitID.Text = "Unit ID"
        '
        'TxtUnitID
        '
        Me.TxtUnitID.Location = New System.Drawing.Point(100, 315)
        Me.TxtUnitID.Margin = New System.Windows.Forms.Padding(2)
        Me.TxtUnitID.Name = "TxtUnitID"
        Me.TxtUnitID.Size = New System.Drawing.Size(25, 20)
        Me.TxtUnitID.TabIndex = 25
        Me.TxtUnitID.Text = "1"
        '
        'BtnWriteUnitID
        '
        Me.BtnWriteUnitID.Location = New System.Drawing.Point(9, 313)
        Me.BtnWriteUnitID.Margin = New System.Windows.Forms.Padding(2)
        Me.BtnWriteUnitID.Name = "BtnWriteUnitID"
        Me.BtnWriteUnitID.Size = New System.Drawing.Size(88, 22)
        Me.BtnWriteUnitID.TabIndex = 24
        Me.BtnWriteUnitID.Text = "Write Unit ID"
        Me.BtnWriteUnitID.UseVisualStyleBackColor = True
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Location = New System.Drawing.Point(6, 242)
        Me.label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(76, 13)
        Me.label3.TabIndex = 29
        Me.label3.Text = "3. LED Control"
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(7, 77)
        Me.label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(186, 13)
        Me.label2.TabIndex = 28
        Me.label2.Text = "2. Set for data callback and read data"
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(7, 2)
        Me.label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(71, 13)
        Me.label1.TabIndex = 27
        Me.label1.Text = "1. Do this first"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(7, 569)
        Me.Label5.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(40, 13)
        Me.Label5.TabIndex = 34
        Me.Label5.Text = "Status:"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(358, 93)
        Me.Button1.Margin = New System.Windows.Forms.Padding(2)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(86, 19)
        Me.Button1.TabIndex = 36
        Me.Button1.Text = "Clear Listbox"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(465, 505)
        Me.Label6.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(83, 13)
        Me.Label6.TabIndex = 37
        Me.Label6.Text = "11. Change PID"
        '
        'BtnBL
        '
        Me.BtnBL.Location = New System.Drawing.Point(292, 443)
        Me.BtnBL.Margin = New System.Windows.Forms.Padding(2)
        Me.BtnBL.Name = "BtnBL"
        Me.BtnBL.Size = New System.Drawing.Size(83, 22)
        Me.BtnBL.TabIndex = 38
        Me.BtnBL.Text = "Set Intensity"
        Me.BtnBL.UseVisualStyleBackColor = True
        '
        'ChkScrollLock
        '
        Me.ChkScrollLock.AutoSize = True
        Me.ChkScrollLock.Location = New System.Drawing.Point(209, 459)
        Me.ChkScrollLock.Margin = New System.Windows.Forms.Padding(2)
        Me.ChkScrollLock.Name = "ChkScrollLock"
        Me.ChkScrollLock.Size = New System.Drawing.Size(79, 17)
        Me.ChkScrollLock.TabIndex = 39
        Me.ChkScrollLock.Text = "Scroll Lock"
        Me.ChkScrollLock.UseVisualStyleBackColor = True
        '
        'BtnSaveBL
        '
        Me.BtnSaveBL.Location = New System.Drawing.Point(292, 469)
        Me.BtnSaveBL.Margin = New System.Windows.Forms.Padding(2)
        Me.BtnSaveBL.Name = "BtnSaveBL"
        Me.BtnSaveBL.Size = New System.Drawing.Size(85, 22)
        Me.BtnSaveBL.TabIndex = 40
        Me.BtnSaveBL.Text = "Save BL State"
        Me.BtnSaveBL.UseVisualStyleBackColor = True
        '
        'BtnToPID2
        '
        Me.BtnToPID2.Location = New System.Drawing.Point(466, 560)
        Me.BtnToPID2.Margin = New System.Windows.Forms.Padding(2)
        Me.BtnToPID2.Name = "BtnToPID2"
        Me.BtnToPID2.Size = New System.Drawing.Size(104, 22)
        Me.BtnToPID2.TabIndex = 41
        Me.BtnToPID2.Text = "To PID #2"
        Me.BtnToPID2.UseVisualStyleBackColor = True
        '
        'ToPID1
        '
        Me.ToPID1.Location = New System.Drawing.Point(466, 525)
        Me.ToPID1.Margin = New System.Windows.Forms.Padding(2)
        Me.ToPID1.Name = "ToPID1"
        Me.ToPID1.Size = New System.Drawing.Size(104, 22)
        Me.ToPID1.TabIndex = 42
        Me.ToPID1.Text = "To PID #1"
        Me.ToPID1.UseVisualStyleBackColor = True
        '
        'textBox1
        '
        Me.textBox1.Location = New System.Drawing.Point(604, 20)
        Me.textBox1.Margin = New System.Windows.Forms.Padding(2)
        Me.textBox1.Name = "textBox1"
        Me.textBox1.Size = New System.Drawing.Size(191, 20)
        Me.textBox1.TabIndex = 45
        '
        'BtnKBreflect
        '
        Me.BtnKBreflect.Location = New System.Drawing.Point(466, 20)
        Me.BtnKBreflect.Margin = New System.Windows.Forms.Padding(2)
        Me.BtnKBreflect.Name = "BtnKBreflect"
        Me.BtnKBreflect.Size = New System.Drawing.Size(122, 22)
        Me.BtnKBreflect.TabIndex = 44
        Me.BtnKBreflect.Text = "Keyboard Reflector"
        Me.BtnKBreflect.UseVisualStyleBackColor = True
        '
        'label7
        '
        Me.label7.AutoSize = True
        Me.label7.Location = New System.Drawing.Point(464, 2)
        Me.label7.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.label7.Name = "label7"
        Me.label7.Size = New System.Drawing.Size(67, 13)
        Me.label7.TabIndex = 43
        Me.label7.Text = "8. Reflectors"
        '
        'label12
        '
        Me.label12.AutoSize = True
        Me.label12.Location = New System.Drawing.Point(591, 150)
        Me.label12.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.label12.Name = "label12"
        Me.label12.Size = New System.Drawing.Size(27, 13)
        Me.label12.TabIndex = 56
        Me.label12.Text = "Hat:"
        '
        'textBox6
        '
        Me.textBox6.Location = New System.Drawing.Point(622, 147)
        Me.textBox6.Margin = New System.Windows.Forms.Padding(2)
        Me.textBox6.Name = "textBox6"
        Me.textBox6.Size = New System.Drawing.Size(41, 20)
        Me.textBox6.TabIndex = 55
        Me.textBox6.Text = "8"
        '
        'textBox5
        '
        Me.textBox5.Location = New System.Drawing.Point(623, 123)
        Me.textBox5.Margin = New System.Windows.Forms.Padding(2)
        Me.textBox5.Name = "textBox5"
        Me.textBox5.Size = New System.Drawing.Size(38, 20)
        Me.textBox5.TabIndex = 54
        Me.textBox5.Text = "0"
        '
        'label11
        '
        Me.label11.AutoSize = True
        Me.label11.Location = New System.Drawing.Point(573, 129)
        Me.label11.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.label11.Name = "label11"
        Me.label11.Size = New System.Drawing.Size(46, 13)
        Me.label11.TabIndex = 53
        Me.label11.Text = "Buttons:"
        '
        'label10
        '
        Me.label10.AutoSize = True
        Me.label10.Location = New System.Drawing.Point(734, 77)
        Me.label10.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.label10.Name = "label10"
        Me.label10.Size = New System.Drawing.Size(17, 13)
        Me.label10.TabIndex = 52
        Me.label10.Text = "Z:"
        '
        'label9
        '
        Me.label9.AutoSize = True
        Me.label9.Location = New System.Drawing.Point(665, 76)
        Me.label9.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.label9.Name = "label9"
        Me.label9.Size = New System.Drawing.Size(17, 13)
        Me.label9.TabIndex = 51
        Me.label9.Text = "Y:"
        '
        'label8
        '
        Me.label8.AutoSize = True
        Me.label8.Location = New System.Drawing.Point(604, 77)
        Me.label8.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.label8.Name = "label8"
        Me.label8.Size = New System.Drawing.Size(17, 13)
        Me.label8.TabIndex = 50
        Me.label8.Text = "X:"
        '
        'textBox4
        '
        Me.textBox4.Location = New System.Drawing.Point(754, 74)
        Me.textBox4.Margin = New System.Windows.Forms.Padding(2)
        Me.textBox4.Name = "textBox4"
        Me.textBox4.Size = New System.Drawing.Size(38, 20)
        Me.textBox4.TabIndex = 49
        Me.textBox4.Text = "0"
        '
        'textBox3
        '
        Me.textBox3.Location = New System.Drawing.Point(686, 74)
        Me.textBox3.Margin = New System.Windows.Forms.Padding(2)
        Me.textBox3.Name = "textBox3"
        Me.textBox3.Size = New System.Drawing.Size(38, 20)
        Me.textBox3.TabIndex = 48
        Me.textBox3.Text = "0"
        '
        'textBox2
        '
        Me.textBox2.Location = New System.Drawing.Point(621, 75)
        Me.textBox2.Margin = New System.Windows.Forms.Padding(2)
        Me.textBox2.Name = "textBox2"
        Me.textBox2.Size = New System.Drawing.Size(38, 20)
        Me.textBox2.TabIndex = 47
        Me.textBox2.Text = "0"
        '
        'BtnJoyreflect
        '
        Me.BtnJoyreflect.Location = New System.Drawing.Point(466, 76)
        Me.BtnJoyreflect.Margin = New System.Windows.Forms.Padding(2)
        Me.BtnJoyreflect.Name = "BtnJoyreflect"
        Me.BtnJoyreflect.Size = New System.Drawing.Size(122, 22)
        Me.BtnJoyreflect.TabIndex = 46
        Me.BtnJoyreflect.Text = "Joystick Reflector*"
        Me.BtnJoyreflect.UseVisualStyleBackColor = True
        '
        'label23
        '
        Me.label23.AutoSize = True
        Me.label23.Location = New System.Drawing.Point(6, 505)
        Me.label23.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.label23.Name = "label23"
        Me.label23.Size = New System.Drawing.Size(111, 13)
        Me.label23.TabIndex = 72
        Me.label23.Text = "7. Enable Time Stamp"
        '
        'lbldeltatime
        '
        Me.lbldeltatime.AutoSize = True
        Me.lbldeltatime.Location = New System.Drawing.Point(210, 544)
        Me.lbldeltatime.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbldeltatime.Name = "lbldeltatime"
        Me.lbldeltatime.Size = New System.Drawing.Size(52, 13)
        Me.lbldeltatime.TabIndex = 71
        Me.lbldeltatime.Text = "delta time"
        '
        'lblabstime
        '
        Me.lblabstime.AutoSize = True
        Me.lblabstime.Location = New System.Drawing.Point(210, 530)
        Me.lblabstime.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblabstime.Name = "lblabstime"
        Me.lblabstime.Size = New System.Drawing.Size(69, 13)
        Me.lblabstime.TabIndex = 70
        Me.lblabstime.Text = "absolute time"
        '
        'BtnTimeStamp
        '
        Me.BtnTimeStamp.Location = New System.Drawing.Point(9, 530)
        Me.BtnTimeStamp.Margin = New System.Windows.Forms.Padding(2)
        Me.BtnTimeStamp.Name = "BtnTimeStamp"
        Me.BtnTimeStamp.Size = New System.Drawing.Size(92, 22)
        Me.BtnTimeStamp.TabIndex = 69
        Me.BtnTimeStamp.Text = "Time Stamp Off"
        Me.BtnTimeStamp.UseVisualStyleBackColor = True
        '
        'listBox2
        '
        Me.listBox2.FormattingEnabled = True
        Me.listBox2.Location = New System.Drawing.Point(577, 346)
        Me.listBox2.Margin = New System.Windows.Forms.Padding(2)
        Me.listBox2.Name = "listBox2"
        Me.listBox2.Size = New System.Drawing.Size(232, 82)
        Me.listBox2.TabIndex = 75
        '
        'BtnDescriptor
        '
        Me.BtnDescriptor.Location = New System.Drawing.Point(468, 345)
        Me.BtnDescriptor.Margin = New System.Windows.Forms.Padding(2)
        Me.BtnDescriptor.Name = "BtnDescriptor"
        Me.BtnDescriptor.Size = New System.Drawing.Size(98, 22)
        Me.BtnDescriptor.TabIndex = 74
        Me.BtnDescriptor.Text = "Descriptor"
        Me.BtnDescriptor.UseVisualStyleBackColor = True
        '
        'label21
        '
        Me.label21.AutoSize = True
        Me.label21.Location = New System.Drawing.Point(466, 327)
        Me.label21.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.label21.Name = "label21"
        Me.label21.Size = New System.Drawing.Size(67, 13)
        Me.label21.TabIndex = 73
        Me.label21.Text = "9. Descriptor"
        '
        'BtnBLToggle
        '
        Me.BtnBLToggle.Location = New System.Drawing.Point(141, 455)
        Me.BtnBLToggle.Margin = New System.Windows.Forms.Padding(2)
        Me.BtnBLToggle.Name = "BtnBLToggle"
        Me.BtnBLToggle.Size = New System.Drawing.Size(64, 22)
        Me.BtnBLToggle.TabIndex = 76
        Me.BtnBLToggle.Text = "Toggle"
        Me.BtnBLToggle.UseVisualStyleBackColor = True
        '
        'BtnTimeStampOn
        '
        Me.BtnTimeStampOn.Location = New System.Drawing.Point(106, 530)
        Me.BtnTimeStampOn.Margin = New System.Windows.Forms.Padding(2)
        Me.BtnTimeStampOn.Name = "BtnTimeStampOn"
        Me.BtnTimeStampOn.Size = New System.Drawing.Size(92, 22)
        Me.BtnTimeStampOn.TabIndex = 77
        Me.BtnTimeStampOn.Text = "Time Stamp On"
        Me.BtnTimeStampOn.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(6, 295)
        Me.Label13.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(80, 13)
        Me.Label13.TabIndex = 89
        Me.Label13.Text = "4. Write Unit ID"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(6, 360)
        Me.Label14.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(107, 13)
        Me.Label14.TabIndex = 90
        Me.Label14.Text = "5. Backlight Features"
        '
        'BtnSetFlash
        '
        Me.BtnSetFlash.Location = New System.Drawing.Point(9, 457)
        Me.BtnSetFlash.Margin = New System.Windows.Forms.Padding(2)
        Me.BtnSetFlash.Name = "BtnSetFlash"
        Me.BtnSetFlash.Size = New System.Drawing.Size(92, 22)
        Me.BtnSetFlash.TabIndex = 98
        Me.BtnSetFlash.Text = "Set Flash Freq"
        Me.BtnSetFlash.UseVisualStyleBackColor = True
        '
        'TxtFlashFreq
        '
        Me.TxtFlashFreq.Location = New System.Drawing.Point(103, 457)
        Me.TxtFlashFreq.Margin = New System.Windows.Forms.Padding(2)
        Me.TxtFlashFreq.Name = "TxtFlashFreq"
        Me.TxtFlashFreq.Size = New System.Drawing.Size(30, 20)
        Me.TxtFlashFreq.TabIndex = 97
        Me.TxtFlashFreq.Text = "10"
        '
        'ChkRedOnOff
        '
        Me.ChkRedOnOff.AutoSize = True
        Me.ChkRedOnOff.Location = New System.Drawing.Point(312, 381)
        Me.ChkRedOnOff.Margin = New System.Windows.Forms.Padding(2)
        Me.ChkRedOnOff.Name = "ChkRedOnOff"
        Me.ChkRedOnOff.Size = New System.Drawing.Size(110, 17)
        Me.ChkRedOnOff.TabIndex = 96
        Me.ChkRedOnOff.Text = "All Bank 2 On/Off"
        Me.ChkRedOnOff.UseVisualStyleBackColor = True
        '
        'ChkGreenOnOff
        '
        Me.ChkGreenOnOff.AutoSize = True
        Me.ChkGreenOnOff.Location = New System.Drawing.Point(196, 381)
        Me.ChkGreenOnOff.Margin = New System.Windows.Forms.Padding(2)
        Me.ChkGreenOnOff.Name = "ChkGreenOnOff"
        Me.ChkGreenOnOff.Size = New System.Drawing.Size(110, 17)
        Me.ChkGreenOnOff.TabIndex = 95
        Me.ChkGreenOnOff.Text = "All Bank 1 On/Off"
        Me.ChkGreenOnOff.UseVisualStyleBackColor = True
        '
        'ChkGreenLED
        '
        Me.ChkGreenLED.AutoSize = True
        Me.ChkGreenLED.Location = New System.Drawing.Point(14, 263)
        Me.ChkGreenLED.Margin = New System.Windows.Forms.Padding(2)
        Me.ChkGreenLED.Name = "ChkGreenLED"
        Me.ChkGreenLED.Size = New System.Drawing.Size(55, 17)
        Me.ChkGreenLED.TabIndex = 102
        Me.ChkGreenLED.Text = "Green"
        Me.ChkGreenLED.UseVisualStyleBackColor = True
        '
        'ChkFRedLED
        '
        Me.ChkFRedLED.AutoSize = True
        Me.ChkFRedLED.Location = New System.Drawing.Point(218, 263)
        Me.ChkFRedLED.Margin = New System.Windows.Forms.Padding(2)
        Me.ChkFRedLED.Name = "ChkFRedLED"
        Me.ChkFRedLED.Size = New System.Drawing.Size(98, 17)
        Me.ChkFRedLED.TabIndex = 105
        Me.ChkFRedLED.Text = "Flash Red LED"
        Me.ChkFRedLED.UseVisualStyleBackColor = True
        '
        'ChkFGreenLED
        '
        Me.ChkFGreenLED.AutoSize = True
        Me.ChkFGreenLED.Location = New System.Drawing.Point(131, 263)
        Me.ChkFGreenLED.Margin = New System.Windows.Forms.Padding(2)
        Me.ChkFGreenLED.Name = "ChkFGreenLED"
        Me.ChkFGreenLED.Size = New System.Drawing.Size(83, 17)
        Me.ChkFGreenLED.TabIndex = 104
        Me.ChkFGreenLED.Text = "Flash Green"
        Me.ChkFGreenLED.UseVisualStyleBackColor = True
        '
        'ChkRedLED
        '
        Me.ChkRedLED.AutoSize = True
        Me.ChkRedLED.Location = New System.Drawing.Point(73, 263)
        Me.ChkRedLED.Margin = New System.Windows.Forms.Padding(2)
        Me.ChkRedLED.Name = "ChkRedLED"
        Me.ChkRedLED.Size = New System.Drawing.Size(46, 17)
        Me.ChkRedLED.TabIndex = 103
        Me.ChkRedLED.Text = "Red"
        Me.ChkRedLED.UseVisualStyleBackColor = True
        '
        'CboKeyIndex
        '
        Me.CboKeyIndex.FormattingEnabled = True
        Me.CboKeyIndex.Items.AddRange(New Object() {"0-b1", "1-b1", "2-b1", "8-b1", "9-b1", "10-b1", "16-b1", "17-b1", "18-b1", "24-b1", "25-b1", "26-b1", "0-b2", "1-b2", "2-b2", "8-b2", "9-b2", "10-b2", "16-b2", "17-b2", "18-b2", "24-b2", "25-b2", "26-b2"})
        Me.CboKeyIndex.Location = New System.Drawing.Point(10, 379)
        Me.CboKeyIndex.Name = "CboKeyIndex"
        Me.CboKeyIndex.Size = New System.Drawing.Size(63, 21)
        Me.CboKeyIndex.TabIndex = 106
        '
        'ChkFlash
        '
        Me.ChkFlash.AutoSize = True
        Me.ChkFlash.Location = New System.Drawing.Point(141, 381)
        Me.ChkFlash.Margin = New System.Windows.Forms.Padding(2)
        Me.ChkFlash.Name = "ChkFlash"
        Me.ChkFlash.Size = New System.Drawing.Size(51, 17)
        Me.ChkFlash.TabIndex = 120
        Me.ChkFlash.Text = "Flash"
        Me.ChkFlash.UseVisualStyleBackColor = True
        '
        'ChkBLOnOff
        '
        Me.ChkBLOnOff.AutoSize = True
        Me.ChkBLOnOff.Location = New System.Drawing.Point(78, 381)
        Me.ChkBLOnOff.Margin = New System.Windows.Forms.Padding(2)
        Me.ChkBLOnOff.Name = "ChkBLOnOff"
        Me.ChkBLOnOff.Size = New System.Drawing.Size(59, 17)
        Me.ChkBLOnOff.TabIndex = 119
        Me.ChkBLOnOff.Text = "On/Off"
        Me.ChkBLOnOff.UseVisualStyleBackColor = True
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(465, 443)
        Me.Label15.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(171, 13)
        Me.Label15.TabIndex = 121
        Me.Label15.Text = "10. Generate Data or Custom Data"
        '
        'BtnGetDataNow
        '
        Me.BtnGetDataNow.Location = New System.Drawing.Point(466, 462)
        Me.BtnGetDataNow.Margin = New System.Windows.Forms.Padding(2)
        Me.BtnGetDataNow.Name = "BtnGetDataNow"
        Me.BtnGetDataNow.Size = New System.Drawing.Size(98, 22)
        Me.BtnGetDataNow.TabIndex = 122
        Me.BtnGetDataNow.Text = "Generate Data"
        Me.BtnGetDataNow.UseVisualStyleBackColor = True
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(799, 130)
        Me.Label16.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(34, 13)
        Me.Label16.TabIndex = 123
        Me.Label16.Text = "0-255"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(799, 78)
        Me.Label17.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(34, 13)
        Me.Label17.TabIndex = 124
        Me.Label17.Text = "0-255"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(667, 150)
        Me.Label18.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(22, 13)
        Me.Label18.TabIndex = 125
        Me.Label18.Text = "0-8"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(710, 101)
        Me.Label19.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(36, 13)
        Me.Label19.TabIndex = 129
        Me.Label19.Text = "Slider:"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(583, 102)
        Me.Label20.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(35, 13)
        Me.Label20.TabIndex = 128
        Me.Label20.Text = "Z rot.:"
        '
        'TextBox7
        '
        Me.TextBox7.Location = New System.Drawing.Point(754, 98)
        Me.TextBox7.Margin = New System.Windows.Forms.Padding(2)
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.Size = New System.Drawing.Size(38, 20)
        Me.TextBox7.TabIndex = 127
        Me.TextBox7.Text = "0"
        '
        'TextBox8
        '
        Me.TextBox8.Location = New System.Drawing.Point(622, 99)
        Me.TextBox8.Margin = New System.Windows.Forms.Padding(2)
        Me.TextBox8.Name = "TextBox8"
        Me.TextBox8.Size = New System.Drawing.Size(38, 20)
        Me.TextBox8.TabIndex = 126
        Me.TextBox8.Text = "0"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(799, 102)
        Me.Label22.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(34, 13)
        Me.Label22.TabIndex = 130
        Me.Label22.Text = "0-255"
        '
        'TextBox9
        '
        Me.TextBox9.Location = New System.Drawing.Point(665, 123)
        Me.TextBox9.Margin = New System.Windows.Forms.Padding(2)
        Me.TextBox9.Name = "TextBox9"
        Me.TextBox9.Size = New System.Drawing.Size(38, 20)
        Me.TextBox9.TabIndex = 131
        Me.TextBox9.Text = "0"
        '
        'TextBox10
        '
        Me.TextBox10.Location = New System.Drawing.Point(708, 122)
        Me.TextBox10.Margin = New System.Windows.Forms.Padding(2)
        Me.TextBox10.Name = "TextBox10"
        Me.TextBox10.Size = New System.Drawing.Size(38, 20)
        Me.TextBox10.TabIndex = 132
        Me.TextBox10.Text = "0"
        '
        'TextBox11
        '
        Me.TextBox11.Location = New System.Drawing.Point(754, 123)
        Me.TextBox11.Margin = New System.Windows.Forms.Padding(2)
        Me.TextBox11.Name = "TextBox11"
        Me.TextBox11.Size = New System.Drawing.Size(38, 20)
        Me.TextBox11.TabIndex = 133
        Me.TextBox11.Text = "0"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(6, 430)
        Me.Label24.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(140, 13)
        Me.Label24.TabIndex = 134
        Me.Label24.Text = "6. Global Backlight Features"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(464, 173)
        Me.Label25.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(131, 13)
        Me.Label25.TabIndex = 138
        Me.Label25.Text = "* Available for PID #2 only"
        '
        'label29
        '
        Me.label29.AutoSize = True
        Me.label29.Location = New System.Drawing.Point(465, 295)
        Me.label29.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.label29.Name = "label29"
        Me.label29.Size = New System.Drawing.Size(133, 13)
        Me.label29.TabIndex = 162
        Me.label29.Text = "+Available for PID #1 only."
        '
        'BtnMousereflect
        '
        Me.BtnMousereflect.Location = New System.Drawing.Point(466, 194)
        Me.BtnMousereflect.Margin = New System.Windows.Forms.Padding(2)
        Me.BtnMousereflect.Name = "BtnMousereflect"
        Me.BtnMousereflect.Size = New System.Drawing.Size(122, 22)
        Me.BtnMousereflect.TabIndex = 152
        Me.BtnMousereflect.Text = "Mouse Reflector"
        Me.BtnMousereflect.UseVisualStyleBackColor = True
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(574, 565)
        Me.Label26.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(235, 13)
        Me.Label26.TabIndex = 164
        Me.Label26.Text = "Endpoints: Keyboard, Joystick, Input and Output"
        '
        'label28
        '
        Me.label28.Location = New System.Drawing.Point(574, 525)
        Me.label28.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.label28.Name = "label28"
        Me.label28.Size = New System.Drawing.Size(234, 32)
        Me.label28.TabIndex = 165
        Me.label28.Text = "Endpoints: Keyboard, Mouse, Input and Output (Factory Default)"
        '
        'LblShuttle
        '
        Me.LblShuttle.AutoSize = True
        Me.LblShuttle.Location = New System.Drawing.Point(308, 201)
        Me.LblShuttle.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LblShuttle.Name = "LblShuttle"
        Me.LblShuttle.Size = New System.Drawing.Size(79, 13)
        Me.LblShuttle.TabIndex = 167
        Me.LblShuttle.Text = "Shuttle Analog:"
        '
        'LblJog
        '
        Me.LblJog.AutoSize = True
        Me.LblJog.Location = New System.Drawing.Point(151, 203)
        Me.LblJog.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LblJog.Name = "LblJog"
        Me.LblJog.Size = New System.Drawing.Size(63, 13)
        Me.LblJog.TabIndex = 166
        Me.LblJog.Text = "Jog Analog:"
        '
        'LblJogD
        '
        Me.LblJogD.AutoSize = True
        Me.LblJogD.Location = New System.Drawing.Point(151, 220)
        Me.LblJogD.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LblJogD.Name = "LblJogD"
        Me.LblJogD.Size = New System.Drawing.Size(59, 13)
        Me.LblJogD.TabIndex = 168
        Me.LblJogD.Text = "Jog Digital:"
        '
        'LblShuttleD
        '
        Me.LblShuttleD.AutoSize = True
        Me.LblShuttleD.Location = New System.Drawing.Point(309, 220)
        Me.LblShuttleD.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LblShuttleD.Name = "LblShuttleD"
        Me.LblShuttleD.Size = New System.Drawing.Size(75, 13)
        Me.LblShuttleD.TabIndex = 169
        Me.LblShuttleD.Text = "Shuttle Digital:"
        '
        'LblButtons
        '
        Me.LblButtons.AutoSize = True
        Me.LblButtons.Location = New System.Drawing.Point(11, 220)
        Me.LblButtons.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LblButtons.Name = "LblButtons"
        Me.LblButtons.Size = New System.Drawing.Size(46, 13)
        Me.LblButtons.TabIndex = 170
        Me.LblButtons.Text = "Buttons:"
        '
        'ChkSuppress
        '
        Me.ChkSuppress.AutoSize = True
        Me.ChkSuppress.Location = New System.Drawing.Point(141, 95)
        Me.ChkSuppress.Name = "ChkSuppress"
        Me.ChkSuppress.Size = New System.Drawing.Size(151, 17)
        Me.ChkSuppress.TabIndex = 315
        Me.ChkSuppress.Text = "Suppress duplicate reports"
        Me.ChkSuppress.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(699, 221)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(61, 13)
        Me.Label4.TabIndex = 347
        Me.Label4.Text = "1=finest inc"
        '
        'label37
        '
        Me.label37.Location = New System.Drawing.Point(693, 188)
        Me.label37.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.label37.Name = "label37"
        Me.label37.Size = New System.Drawing.Size(140, 33)
        Me.label37.TabIndex = 346
        Me.label37.Text = "1=left, 2=right, 4=center, 8=XButton1, 16=XButton2"
        '
        'TxtWheelX
        '
        Me.TxtWheelX.Location = New System.Drawing.Point(767, 266)
        Me.TxtWheelX.Margin = New System.Windows.Forms.Padding(2)
        Me.TxtWheelX.Name = "TxtWheelX"
        Me.TxtWheelX.Size = New System.Drawing.Size(41, 20)
        Me.TxtWheelX.TabIndex = 345
        Me.TxtWheelX.Text = "0"
        '
        'label31
        '
        Me.label31.AutoSize = True
        Me.label31.Location = New System.Drawing.Point(706, 269)
        Me.label31.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.label31.Name = "label31"
        Me.label31.Size = New System.Drawing.Size(51, 13)
        Me.label31.TabIndex = 344
        Me.label31.Text = "Wheel X:"
        '
        'label30
        '
        Me.label30.AutoSize = True
        Me.label30.Location = New System.Drawing.Point(594, 269)
        Me.label30.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.label30.Name = "label30"
        Me.label30.Size = New System.Drawing.Size(51, 13)
        Me.label30.TabIndex = 343
        Me.label30.Text = "Wheel Y:"
        '
        'TxtWheel
        '
        Me.TxtWheel.Location = New System.Drawing.Point(648, 266)
        Me.TxtWheel.Margin = New System.Windows.Forms.Padding(2)
        Me.TxtWheel.Name = "TxtWheel"
        Me.TxtWheel.Size = New System.Drawing.Size(41, 20)
        Me.TxtWheel.TabIndex = 342
        Me.TxtWheel.Text = "0"
        '
        'label32
        '
        Me.label32.AutoSize = True
        Me.label32.Location = New System.Drawing.Point(603, 197)
        Me.label32.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.label32.Name = "label32"
        Me.label32.Size = New System.Drawing.Size(41, 13)
        Me.label32.TabIndex = 341
        Me.label32.Text = "Button:"
        '
        'label33
        '
        Me.label33.AutoSize = True
        Me.label33.Location = New System.Drawing.Point(621, 246)
        Me.label33.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.label33.Name = "label33"
        Me.label33.Size = New System.Drawing.Size(23, 13)
        Me.label33.TabIndex = 340
        Me.label33.Text = "dY:"
        '
        'label34
        '
        Me.label34.AutoSize = True
        Me.label34.Location = New System.Drawing.Point(621, 221)
        Me.label34.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.label34.Name = "label34"
        Me.label34.Size = New System.Drawing.Size(23, 13)
        Me.label34.TabIndex = 339
        Me.label34.Text = "dX:"
        '
        'TxtMouseButtons
        '
        Me.TxtMouseButtons.Location = New System.Drawing.Point(648, 194)
        Me.TxtMouseButtons.Margin = New System.Windows.Forms.Padding(2)
        Me.TxtMouseButtons.Name = "TxtMouseButtons"
        Me.TxtMouseButtons.Size = New System.Drawing.Size(41, 20)
        Me.TxtMouseButtons.TabIndex = 338
        Me.TxtMouseButtons.Text = "0"
        '
        'TxtMouseY
        '
        Me.TxtMouseY.Location = New System.Drawing.Point(648, 243)
        Me.TxtMouseY.Margin = New System.Windows.Forms.Padding(2)
        Me.TxtMouseY.Name = "TxtMouseY"
        Me.TxtMouseY.Size = New System.Drawing.Size(41, 20)
        Me.TxtMouseY.TabIndex = 337
        Me.TxtMouseY.Text = "5"
        '
        'TxtMouseX
        '
        Me.TxtMouseX.Location = New System.Drawing.Point(648, 218)
        Me.TxtMouseX.Margin = New System.Windows.Forms.Padding(2)
        Me.TxtMouseX.Name = "TxtMouseX"
        Me.TxtMouseX.Size = New System.Drawing.Size(41, 20)
        Me.TxtMouseX.TabIndex = 336
        Me.TxtMouseX.Text = "5"
        '
        'BtnCustom
        '
        Me.BtnCustom.Location = New System.Drawing.Point(577, 462)
        Me.BtnCustom.Margin = New System.Windows.Forms.Padding(2)
        Me.BtnCustom.Name = "BtnCustom"
        Me.BtnCustom.Size = New System.Drawing.Size(98, 22)
        Me.BtnCustom.TabIndex = 348
        Me.BtnCustom.Text = "Custom Data"
        Me.BtnCustom.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(843, 597)
        Me.Controls.Add(Me.BtnCustom)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.label37)
        Me.Controls.Add(Me.TxtWheelX)
        Me.Controls.Add(Me.label31)
        Me.Controls.Add(Me.label30)
        Me.Controls.Add(Me.TxtWheel)
        Me.Controls.Add(Me.label32)
        Me.Controls.Add(Me.label33)
        Me.Controls.Add(Me.label34)
        Me.Controls.Add(Me.TxtMouseButtons)
        Me.Controls.Add(Me.TxtMouseY)
        Me.Controls.Add(Me.TxtMouseX)
        Me.Controls.Add(Me.ChkSuppress)
        Me.Controls.Add(Me.LblButtons)
        Me.Controls.Add(Me.LblShuttleD)
        Me.Controls.Add(Me.LblJogD)
        Me.Controls.Add(Me.LblShuttle)
        Me.Controls.Add(Me.LblJog)
        Me.Controls.Add(Me.label28)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.label29)
        Me.Controls.Add(Me.BtnMousereflect)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.TextBox11)
        Me.Controls.Add(Me.TextBox10)
        Me.Controls.Add(Me.TextBox9)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.TextBox7)
        Me.Controls.Add(Me.TextBox8)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.BtnGetDataNow)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.ChkFlash)
        Me.Controls.Add(Me.ChkBLOnOff)
        Me.Controls.Add(Me.CboKeyIndex)
        Me.Controls.Add(Me.ChkFRedLED)
        Me.Controls.Add(Me.ChkFGreenLED)
        Me.Controls.Add(Me.ChkRedLED)
        Me.Controls.Add(Me.ChkGreenLED)
        Me.Controls.Add(Me.BtnSetFlash)
        Me.Controls.Add(Me.TxtFlashFreq)
        Me.Controls.Add(Me.ChkRedOnOff)
        Me.Controls.Add(Me.ChkGreenOnOff)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.BtnTimeStampOn)
        Me.Controls.Add(Me.BtnBLToggle)
        Me.Controls.Add(Me.listBox2)
        Me.Controls.Add(Me.BtnDescriptor)
        Me.Controls.Add(Me.label21)
        Me.Controls.Add(Me.label23)
        Me.Controls.Add(Me.lbldeltatime)
        Me.Controls.Add(Me.lblabstime)
        Me.Controls.Add(Me.BtnTimeStamp)
        Me.Controls.Add(Me.label12)
        Me.Controls.Add(Me.textBox6)
        Me.Controls.Add(Me.textBox5)
        Me.Controls.Add(Me.label11)
        Me.Controls.Add(Me.label10)
        Me.Controls.Add(Me.label9)
        Me.Controls.Add(Me.label8)
        Me.Controls.Add(Me.textBox4)
        Me.Controls.Add(Me.textBox3)
        Me.Controls.Add(Me.textBox2)
        Me.Controls.Add(Me.BtnJoyreflect)
        Me.Controls.Add(Me.textBox1)
        Me.Controls.Add(Me.BtnKBreflect)
        Me.Controls.Add(Me.label7)
        Me.Controls.Add(Me.ToPID1)
        Me.Controls.Add(Me.BtnToPID2)
        Me.Controls.Add(Me.BtnSaveBL)
        Me.Controls.Add(Me.ChkScrollLock)
        Me.Controls.Add(Me.BtnBL)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.label3)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.LblUnitID)
        Me.Controls.Add(Me.TxtUnitID)
        Me.Controls.Add(Me.BtnWriteUnitID)
        Me.Controls.Add(Me.LblSwitchPos)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.BtnCallback)
        Me.Controls.Add(Me.CboDevices)
        Me.Controls.Add(Me.LblStatus)
        Me.Controls.Add(Me.BtnEnumerate)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "Form1"
        Me.Text = "VB X-keys XK-12 Jog & Shuttle Sample"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents BtnCallback As System.Windows.Forms.Button
    Friend WithEvents CboDevices As System.Windows.Forms.ComboBox
    Friend WithEvents LblStatus As System.Windows.Forms.Label
    Friend WithEvents BtnEnumerate As System.Windows.Forms.Button
    Friend WithEvents LblSwitchPos As System.Windows.Forms.Label
    Friend WithEvents LblUnitID As System.Windows.Forms.Label
    Friend WithEvents TxtUnitID As System.Windows.Forms.TextBox
    Friend WithEvents BtnWriteUnitID As System.Windows.Forms.Button
    Private WithEvents label3 As System.Windows.Forms.Label
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents label1 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Private WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents BtnBL As System.Windows.Forms.Button
    Friend WithEvents ChkScrollLock As System.Windows.Forms.CheckBox
    Friend WithEvents BtnSaveBL As System.Windows.Forms.Button
    Friend WithEvents BtnToPID2 As System.Windows.Forms.Button
    Friend WithEvents ToPID1 As System.Windows.Forms.Button
    Private WithEvents textBox1 As System.Windows.Forms.TextBox
    Private WithEvents BtnKBreflect As System.Windows.Forms.Button
    Private WithEvents label7 As System.Windows.Forms.Label
    Private WithEvents label12 As System.Windows.Forms.Label
    Private WithEvents textBox6 As System.Windows.Forms.TextBox
    Private WithEvents textBox5 As System.Windows.Forms.TextBox
    Private WithEvents label11 As System.Windows.Forms.Label
    Private WithEvents label10 As System.Windows.Forms.Label
    Private WithEvents label9 As System.Windows.Forms.Label
    Private WithEvents label8 As System.Windows.Forms.Label
    Private WithEvents textBox4 As System.Windows.Forms.TextBox
    Private WithEvents textBox3 As System.Windows.Forms.TextBox
    Private WithEvents textBox2 As System.Windows.Forms.TextBox
    Private WithEvents BtnJoyreflect As System.Windows.Forms.Button
    Private WithEvents label23 As System.Windows.Forms.Label
    Private WithEvents lbldeltatime As System.Windows.Forms.Label
    Private WithEvents lblabstime As System.Windows.Forms.Label
    Private WithEvents BtnTimeStamp As System.Windows.Forms.Button
    Private WithEvents listBox2 As System.Windows.Forms.ListBox
    Private WithEvents BtnDescriptor As System.Windows.Forms.Button
    Private WithEvents label21 As System.Windows.Forms.Label
    Friend WithEvents BtnBLToggle As System.Windows.Forms.Button
    Private WithEvents BtnTimeStampOn As System.Windows.Forms.Button
    Private WithEvents Label13 As System.Windows.Forms.Label
    Private WithEvents Label14 As System.Windows.Forms.Label
    Private WithEvents BtnSetFlash As System.Windows.Forms.Button
    Private WithEvents TxtFlashFreq As System.Windows.Forms.TextBox
    Private WithEvents ChkRedOnOff As System.Windows.Forms.CheckBox
    Private WithEvents ChkGreenOnOff As System.Windows.Forms.CheckBox
    Private WithEvents ChkGreenLED As System.Windows.Forms.CheckBox
    Private WithEvents ChkFRedLED As System.Windows.Forms.CheckBox
    Private WithEvents ChkFGreenLED As System.Windows.Forms.CheckBox
    Private WithEvents ChkRedLED As System.Windows.Forms.CheckBox
    Friend WithEvents CboKeyIndex As System.Windows.Forms.ComboBox
    Private WithEvents ChkFlash As System.Windows.Forms.CheckBox
    Private WithEvents ChkBLOnOff As System.Windows.Forms.CheckBox
    Private WithEvents Label15 As System.Windows.Forms.Label
    Private WithEvents BtnGetDataNow As System.Windows.Forms.Button
    Private WithEvents Label16 As System.Windows.Forms.Label
    Private WithEvents Label17 As System.Windows.Forms.Label
    Private WithEvents Label18 As System.Windows.Forms.Label
    Private WithEvents Label19 As System.Windows.Forms.Label
    Private WithEvents Label20 As System.Windows.Forms.Label
    Private WithEvents TextBox7 As System.Windows.Forms.TextBox
    Private WithEvents TextBox8 As System.Windows.Forms.TextBox
    Private WithEvents Label22 As System.Windows.Forms.Label
    Private WithEvents TextBox9 As System.Windows.Forms.TextBox
    Private WithEvents TextBox10 As System.Windows.Forms.TextBox
    Private WithEvents TextBox11 As System.Windows.Forms.TextBox
    Private WithEvents Label24 As System.Windows.Forms.Label
    Private WithEvents Label25 As System.Windows.Forms.Label
    Private WithEvents label29 As System.Windows.Forms.Label
    Private WithEvents BtnMousereflect As System.Windows.Forms.Button
    Private WithEvents Label26 As System.Windows.Forms.Label
    Private WithEvents label28 As System.Windows.Forms.Label
    Private WithEvents LblShuttle As System.Windows.Forms.Label
    Private WithEvents LblJog As System.Windows.Forms.Label
    Private WithEvents LblJogD As System.Windows.Forms.Label
    Private WithEvents LblShuttleD As System.Windows.Forms.Label
    Friend WithEvents LblButtons As System.Windows.Forms.Label
    Friend WithEvents ChkSuppress As System.Windows.Forms.CheckBox
    Private WithEvents Label4 As System.Windows.Forms.Label
    Private WithEvents label37 As System.Windows.Forms.Label
    Private WithEvents TxtWheelX As System.Windows.Forms.TextBox
    Private WithEvents label31 As System.Windows.Forms.Label
    Private WithEvents label30 As System.Windows.Forms.Label
    Private WithEvents TxtWheel As System.Windows.Forms.TextBox
    Private WithEvents label32 As System.Windows.Forms.Label
    Private WithEvents label33 As System.Windows.Forms.Label
    Private WithEvents label34 As System.Windows.Forms.Label
    Private WithEvents TxtMouseButtons As System.Windows.Forms.TextBox
    Private WithEvents TxtMouseY As System.Windows.Forms.TextBox
    Private WithEvents TxtMouseX As System.Windows.Forms.TextBox
    Private WithEvents BtnCustom As System.Windows.Forms.Button

End Class
