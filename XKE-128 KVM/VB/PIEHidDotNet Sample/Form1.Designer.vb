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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.BtnCallback = New System.Windows.Forms.Button()
        Me.CboDevices = New System.Windows.Forms.ComboBox()
        Me.LblStatus = New System.Windows.Forms.Label()
        Me.BtnEnumerate = New System.Windows.Forms.Button()
        Me.LblUnitID = New System.Windows.Forms.Label()
        Me.TxtUnitID = New System.Windows.Forms.TextBox()
        Me.BtnWriteUnitID = New System.Windows.Forms.Button()
        Me.label3 = New System.Windows.Forms.Label()
        Me.label2 = New System.Windows.Forms.Label()
        Me.label1 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.textBox1 = New System.Windows.Forms.TextBox()
        Me.BtnKBreflect = New System.Windows.Forms.Button()
        Me.label7 = New System.Windows.Forms.Label()
        Me.label23 = New System.Windows.Forms.Label()
        Me.lbldeltatime = New System.Windows.Forms.Label()
        Me.lblabstime = New System.Windows.Forms.Label()
        Me.BtnTimeStamp = New System.Windows.Forms.Button()
        Me.listBox2 = New System.Windows.Forms.ListBox()
        Me.BtnDescriptor = New System.Windows.Forms.Button()
        Me.label21 = New System.Windows.Forms.Label()
        Me.BtnGetDataNow = New System.Windows.Forms.Button()
        Me.label30 = New System.Windows.Forms.Label()
        Me.TxtWheel = New System.Windows.Forms.TextBox()
        Me.label32 = New System.Windows.Forms.Label()
        Me.label33 = New System.Windows.Forms.Label()
        Me.label34 = New System.Windows.Forms.Label()
        Me.TxtMouseButtons = New System.Windows.Forms.TextBox()
        Me.TxtMouseY = New System.Windows.Forms.TextBox()
        Me.TxtMouseX = New System.Windows.Forms.TextBox()
        Me.BtnPID2 = New System.Windows.Forms.Button()
        Me.LblScrLk = New System.Windows.Forms.Label()
        Me.LblCapsLk = New System.Windows.Forms.Label()
        Me.LblNumLk = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.ChkGreen = New System.Windows.Forms.CheckBox()
        Me.ChkRed = New System.Windows.Forms.CheckBox()
        Me.BtnTimeStampOn = New System.Windows.Forms.Button()
        Me.BtnCustom = New System.Windows.Forms.Button()
        Me.label14 = New System.Windows.Forms.Label()
        Me.label41 = New System.Windows.Forms.Label()
        Me.LblVersion = New System.Windows.Forms.Label()
        Me.TxtVersion = New System.Windows.Forms.TextBox()
        Me.BtnVersion = New System.Windows.Forms.Button()
        Me.BtnMousereflect = New System.Windows.Forms.Button()
        Me.label24 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.ChkSuppress = New System.Windows.Forms.CheckBox()
        Me.ChkBLOnOff = New System.Windows.Forms.CheckBox()
        Me.CboKeyIndex = New System.Windows.Forms.ComboBox()
        Me.label42 = New System.Windows.Forms.Label()
        Me.ChkRedOnOff = New System.Windows.Forms.CheckBox()
        Me.ChkBlueOnOff = New System.Windows.Forms.CheckBox()
        Me.BtnIncIntensity = New System.Windows.Forms.Button()
        Me.label43 = New System.Windows.Forms.Label()
        Me.BtnSetFlash = New System.Windows.Forms.Button()
        Me.TxtFlashFreq = New System.Windows.Forms.TextBox()
        Me.BtnBLToggle = New System.Windows.Forms.Button()
        Me.BtnSaveBL = New System.Windows.Forms.Button()
        Me.BtnBL = New System.Windows.Forms.Button()
        Me.CboColor = New System.Windows.Forms.ComboBox()
        Me.LblPassFail = New System.Windows.Forms.Label()
        Me.BtnCheckDongle = New System.Windows.Forms.Button()
        Me.BtnSetDongle = New System.Windows.Forms.Button()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.TxtIntensity1 = New System.Windows.Forms.TextBox()
        Me.TxtIntensity2 = New System.Windows.Forms.TextBox()
        Me.BtnIncIntensity2 = New System.Windows.Forms.Button()
        Me.BtnChange = New System.Windows.Forms.Button()
        Me.BtnNoChange = New System.Windows.Forms.Button()
        Me.label6 = New System.Windows.Forms.Label()
        Me.label25 = New System.Windows.Forms.Label()
        Me.label8 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.HorizontalScrollbar = True
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
        Me.BtnCallback.Size = New System.Drawing.Size(118, 22)
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
        Me.LblStatus.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LblStatus.Location = New System.Drawing.Point(69, 665)
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
        Me.BtnEnumerate.Size = New System.Drawing.Size(118, 22)
        Me.BtnEnumerate.TabIndex = 15
        Me.BtnEnumerate.Text = "Enumerate"
        Me.BtnEnumerate.UseVisualStyleBackColor = True
        '
        'LblUnitID
        '
        Me.LblUnitID.Location = New System.Drawing.Point(148, 237)
        Me.LblUnitID.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LblUnitID.Name = "LblUnitID"
        Me.LblUnitID.Size = New System.Drawing.Size(38, 20)
        Me.LblUnitID.TabIndex = 26
        Me.LblUnitID.Text = "Unit ID"
        '
        'TxtUnitID
        '
        Me.TxtUnitID.Location = New System.Drawing.Point(120, 234)
        Me.TxtUnitID.Margin = New System.Windows.Forms.Padding(2)
        Me.TxtUnitID.Name = "TxtUnitID"
        Me.TxtUnitID.Size = New System.Drawing.Size(25, 20)
        Me.TxtUnitID.TabIndex = 25
        Me.TxtUnitID.Text = "1"
        '
        'BtnWriteUnitID
        '
        Me.BtnWriteUnitID.Location = New System.Drawing.Point(9, 232)
        Me.BtnWriteUnitID.Margin = New System.Windows.Forms.Padding(2)
        Me.BtnWriteUnitID.Name = "BtnWriteUnitID"
        Me.BtnWriteUnitID.Size = New System.Drawing.Size(104, 22)
        Me.BtnWriteUnitID.TabIndex = 24
        Me.BtnWriteUnitID.Text = "Write Unit ID"
        Me.BtnWriteUnitID.UseVisualStyleBackColor = True
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Location = New System.Drawing.Point(7, 217)
        Me.label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(68, 13)
        Me.label3.TabIndex = 29
        Me.label3.Text = "Write Unit ID"
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(7, 77)
        Me.label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(174, 13)
        Me.label2.TabIndex = 28
        Me.label2.Text = "Set for data callback and read data"
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(7, 2)
        Me.label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(59, 13)
        Me.label1.TabIndex = 27
        Me.label1.Text = "Do this first"
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(14, 665)
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
        Me.Button1.Size = New System.Drawing.Size(86, 22)
        Me.Button1.TabIndex = 36
        Me.Button1.Text = "Clear Listbox"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'textBox1
        '
        Me.textBox1.Location = New System.Drawing.Point(662, 32)
        Me.textBox1.Margin = New System.Windows.Forms.Padding(2)
        Me.textBox1.Name = "textBox1"
        Me.textBox1.Size = New System.Drawing.Size(191, 20)
        Me.textBox1.TabIndex = 45
        '
        'BtnKBreflect
        '
        Me.BtnKBreflect.Location = New System.Drawing.Point(520, 32)
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
        Me.label7.Location = New System.Drawing.Point(518, 14)
        Me.label7.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.label7.Name = "label7"
        Me.label7.Size = New System.Drawing.Size(98, 13)
        Me.label7.TabIndex = 43
        Me.label7.Text = "Keyboard Reflector"
        '
        'label23
        '
        Me.label23.AutoSize = True
        Me.label23.Location = New System.Drawing.Point(8, 457)
        Me.label23.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.label23.Name = "label23"
        Me.label23.Size = New System.Drawing.Size(99, 13)
        Me.label23.TabIndex = 72
        Me.label23.Text = "Enable Time Stamp"
        '
        'lbldeltatime
        '
        Me.lbldeltatime.AutoSize = True
        Me.lbldeltatime.Location = New System.Drawing.Point(236, 481)
        Me.lbldeltatime.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbldeltatime.Name = "lbldeltatime"
        Me.lbldeltatime.Size = New System.Drawing.Size(52, 13)
        Me.lbldeltatime.TabIndex = 71
        Me.lbldeltatime.Text = "delta time"
        '
        'lblabstime
        '
        Me.lblabstime.AutoSize = True
        Me.lblabstime.Location = New System.Drawing.Point(236, 467)
        Me.lblabstime.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblabstime.Name = "lblabstime"
        Me.lblabstime.Size = New System.Drawing.Size(69, 13)
        Me.lblabstime.TabIndex = 70
        Me.lblabstime.Text = "absolute time"
        '
        'BtnTimeStamp
        '
        Me.BtnTimeStamp.Location = New System.Drawing.Point(9, 472)
        Me.BtnTimeStamp.Margin = New System.Windows.Forms.Padding(2)
        Me.BtnTimeStamp.Name = "BtnTimeStamp"
        Me.BtnTimeStamp.Size = New System.Drawing.Size(99, 22)
        Me.BtnTimeStamp.TabIndex = 69
        Me.BtnTimeStamp.Text = "Time Stamp Off"
        Me.BtnTimeStamp.UseVisualStyleBackColor = True
        '
        'listBox2
        '
        Me.listBox2.FormattingEnabled = True
        Me.listBox2.Location = New System.Drawing.Point(116, 315)
        Me.listBox2.Margin = New System.Windows.Forms.Padding(2)
        Me.listBox2.Name = "listBox2"
        Me.listBox2.Size = New System.Drawing.Size(232, 56)
        Me.listBox2.TabIndex = 75
        '
        'BtnDescriptor
        '
        Me.BtnDescriptor.Location = New System.Drawing.Point(9, 314)
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
        Me.label21.Location = New System.Drawing.Point(7, 299)
        Me.label21.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.label21.Name = "label21"
        Me.label21.Size = New System.Drawing.Size(55, 13)
        Me.label21.TabIndex = 73
        Me.label21.Text = "Descriptor"
        '
        'BtnGetDataNow
        '
        Me.BtnGetDataNow.Location = New System.Drawing.Point(8, 408)
        Me.BtnGetDataNow.Margin = New System.Windows.Forms.Padding(2)
        Me.BtnGetDataNow.Name = "BtnGetDataNow"
        Me.BtnGetDataNow.Size = New System.Drawing.Size(98, 22)
        Me.BtnGetDataNow.TabIndex = 124
        Me.BtnGetDataNow.Text = "Generate Data"
        Me.BtnGetDataNow.UseVisualStyleBackColor = True
        '
        'label30
        '
        Me.label30.AutoSize = True
        Me.label30.Location = New System.Drawing.Point(643, 164)
        Me.label30.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.label30.Name = "label30"
        Me.label30.Size = New System.Drawing.Size(51, 13)
        Me.label30.TabIndex = 223
        Me.label30.Text = "Wheel Y:"
        '
        'TxtWheel
        '
        Me.TxtWheel.Location = New System.Drawing.Point(697, 161)
        Me.TxtWheel.Margin = New System.Windows.Forms.Padding(2)
        Me.TxtWheel.Name = "TxtWheel"
        Me.TxtWheel.Size = New System.Drawing.Size(41, 20)
        Me.TxtWheel.TabIndex = 222
        Me.TxtWheel.Text = "0"
        '
        'label32
        '
        Me.label32.AutoSize = True
        Me.label32.Location = New System.Drawing.Point(652, 92)
        Me.label32.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.label32.Name = "label32"
        Me.label32.Size = New System.Drawing.Size(41, 13)
        Me.label32.TabIndex = 220
        Me.label32.Text = "Button:"
        '
        'label33
        '
        Me.label33.AutoSize = True
        Me.label33.Location = New System.Drawing.Point(670, 141)
        Me.label33.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.label33.Name = "label33"
        Me.label33.Size = New System.Drawing.Size(23, 13)
        Me.label33.TabIndex = 219
        Me.label33.Text = "dY:"
        '
        'label34
        '
        Me.label34.AutoSize = True
        Me.label34.Location = New System.Drawing.Point(670, 116)
        Me.label34.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.label34.Name = "label34"
        Me.label34.Size = New System.Drawing.Size(23, 13)
        Me.label34.TabIndex = 218
        Me.label34.Text = "dX:"
        '
        'TxtMouseButtons
        '
        Me.TxtMouseButtons.Location = New System.Drawing.Point(697, 89)
        Me.TxtMouseButtons.Margin = New System.Windows.Forms.Padding(2)
        Me.TxtMouseButtons.Name = "TxtMouseButtons"
        Me.TxtMouseButtons.Size = New System.Drawing.Size(41, 20)
        Me.TxtMouseButtons.TabIndex = 217
        Me.TxtMouseButtons.Text = "0"
        '
        'TxtMouseY
        '
        Me.TxtMouseY.Location = New System.Drawing.Point(697, 138)
        Me.TxtMouseY.Margin = New System.Windows.Forms.Padding(2)
        Me.TxtMouseY.Name = "TxtMouseY"
        Me.TxtMouseY.Size = New System.Drawing.Size(41, 20)
        Me.TxtMouseY.TabIndex = 216
        Me.TxtMouseY.Text = "5"
        '
        'TxtMouseX
        '
        Me.TxtMouseX.Location = New System.Drawing.Point(697, 113)
        Me.TxtMouseX.Margin = New System.Windows.Forms.Padding(2)
        Me.TxtMouseX.Name = "TxtMouseX"
        Me.TxtMouseX.Size = New System.Drawing.Size(41, 20)
        Me.TxtMouseX.TabIndex = 215
        Me.TxtMouseX.Text = "5"
        '
        'BtnPID2
        '
        Me.BtnPID2.Location = New System.Drawing.Point(520, 310)
        Me.BtnPID2.Margin = New System.Windows.Forms.Padding(2)
        Me.BtnPID2.Name = "BtnPID2"
        Me.BtnPID2.Size = New System.Drawing.Size(65, 22)
        Me.BtnPID2.TabIndex = 227
        Me.BtnPID2.Text = "To PID #2"
        Me.BtnPID2.UseVisualStyleBackColor = True
        '
        'LblScrLk
        '
        Me.LblScrLk.AutoSize = True
        Me.LblScrLk.Location = New System.Drawing.Point(374, 231)
        Me.LblScrLk.Name = "LblScrLk"
        Me.LblScrLk.Size = New System.Drawing.Size(53, 13)
        Me.LblScrLk.TabIndex = 232
        Me.LblScrLk.Text = "ScrLock: "
        '
        'LblCapsLk
        '
        Me.LblCapsLk.AutoSize = True
        Me.LblCapsLk.Location = New System.Drawing.Point(374, 217)
        Me.LblCapsLk.Name = "LblCapsLk"
        Me.LblCapsLk.Size = New System.Drawing.Size(61, 13)
        Me.LblCapsLk.TabIndex = 231
        Me.LblCapsLk.Text = "CapsLock: "
        '
        'LblNumLk
        '
        Me.LblNumLk.AutoSize = True
        Me.LblNumLk.Location = New System.Drawing.Point(374, 202)
        Me.LblNumLk.Name = "LblNumLk"
        Me.LblNumLk.Size = New System.Drawing.Size(59, 13)
        Me.LblNumLk.TabIndex = 230
        Me.LblNumLk.Text = "NumLock: "
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(7, 266)
        Me.Label13.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(33, 13)
        Me.Label13.TabIndex = 233
        Me.Label13.Text = "LEDs"
        '
        'ChkGreen
        '
        Me.ChkGreen.AutoSize = True
        Me.ChkGreen.Location = New System.Drawing.Point(59, 265)
        Me.ChkGreen.Name = "ChkGreen"
        Me.ChkGreen.Size = New System.Drawing.Size(55, 17)
        Me.ChkGreen.TabIndex = 234
        Me.ChkGreen.Tag = "6"
        Me.ChkGreen.Text = "Green"
        Me.ChkGreen.ThreeState = True
        Me.ChkGreen.UseVisualStyleBackColor = True
        '
        'ChkRed
        '
        Me.ChkRed.AutoSize = True
        Me.ChkRed.Location = New System.Drawing.Point(120, 265)
        Me.ChkRed.Name = "ChkRed"
        Me.ChkRed.Size = New System.Drawing.Size(46, 17)
        Me.ChkRed.TabIndex = 235
        Me.ChkRed.Tag = "7"
        Me.ChkRed.Text = "Red"
        Me.ChkRed.ThreeState = True
        Me.ChkRed.UseVisualStyleBackColor = True
        '
        'BtnTimeStampOn
        '
        Me.BtnTimeStampOn.Location = New System.Drawing.Point(120, 472)
        Me.BtnTimeStampOn.Margin = New System.Windows.Forms.Padding(2)
        Me.BtnTimeStampOn.Name = "BtnTimeStampOn"
        Me.BtnTimeStampOn.Size = New System.Drawing.Size(99, 22)
        Me.BtnTimeStampOn.TabIndex = 291
        Me.BtnTimeStampOn.Text = "Time Stamp On"
        Me.BtnTimeStampOn.UseVisualStyleBackColor = True
        '
        'BtnCustom
        '
        Me.BtnCustom.Location = New System.Drawing.Point(120, 408)
        Me.BtnCustom.Margin = New System.Windows.Forms.Padding(2)
        Me.BtnCustom.Name = "BtnCustom"
        Me.BtnCustom.Size = New System.Drawing.Size(98, 22)
        Me.BtnCustom.TabIndex = 292
        Me.BtnCustom.Text = "Custom Data"
        Me.BtnCustom.UseVisualStyleBackColor = True
        '
        'label14
        '
        Me.label14.AutoSize = True
        Me.label14.Location = New System.Drawing.Point(7, 393)
        Me.label14.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.label14.Name = "label14"
        Me.label14.Size = New System.Drawing.Size(310, 13)
        Me.label14.TabIndex = 293
        Me.label14.Text = "Stimulate a general incoming data report or a custom input report"
        '
        'label41
        '
        Me.label41.AutoSize = True
        Me.label41.Location = New System.Drawing.Point(518, 413)
        Me.label41.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.label41.Name = "label41"
        Me.label41.Size = New System.Drawing.Size(294, 13)
        Me.label41.TabIndex = 297
        Me.label41.Text = "Write Version (0-65535), reboot required, may take some time"
        '
        'LblVersion
        '
        Me.LblVersion.AutoSize = True
        Me.LblVersion.Location = New System.Drawing.Point(688, 433)
        Me.LblVersion.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LblVersion.Name = "LblVersion"
        Me.LblVersion.Size = New System.Drawing.Size(41, 13)
        Me.LblVersion.TabIndex = 296
        Me.LblVersion.Text = "version"
        '
        'TxtVersion
        '
        Me.TxtVersion.Location = New System.Drawing.Point(627, 430)
        Me.TxtVersion.Margin = New System.Windows.Forms.Padding(2)
        Me.TxtVersion.Name = "TxtVersion"
        Me.TxtVersion.Size = New System.Drawing.Size(49, 20)
        Me.TxtVersion.TabIndex = 295
        Me.TxtVersion.Text = "100"
        '
        'BtnVersion
        '
        Me.BtnVersion.Location = New System.Drawing.Point(520, 428)
        Me.BtnVersion.Margin = New System.Windows.Forms.Padding(2)
        Me.BtnVersion.Name = "BtnVersion"
        Me.BtnVersion.Size = New System.Drawing.Size(92, 22)
        Me.BtnVersion.TabIndex = 294
        Me.BtnVersion.Text = "Write Version"
        Me.BtnVersion.UseVisualStyleBackColor = True
        '
        'BtnMousereflect
        '
        Me.BtnMousereflect.Location = New System.Drawing.Point(519, 94)
        Me.BtnMousereflect.Margin = New System.Windows.Forms.Padding(2)
        Me.BtnMousereflect.Name = "BtnMousereflect"
        Me.BtnMousereflect.Size = New System.Drawing.Size(122, 22)
        Me.BtnMousereflect.TabIndex = 300
        Me.BtnMousereflect.Text = "Mouse Reflector"
        Me.BtnMousereflect.UseVisualStyleBackColor = True
        '
        'label24
        '
        Me.label24.AutoSize = True
        Me.label24.Location = New System.Drawing.Point(517, 79)
        Me.label24.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.label24.Name = "label24"
        Me.label24.Size = New System.Drawing.Size(85, 13)
        Me.label24.TabIndex = 299
        Me.label24.Text = "Mouse Reflector"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(518, 295)
        Me.Label15.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(65, 13)
        Me.Label15.TabIndex = 309
        Me.Label15.Text = "Change PID"
        '
        'ChkSuppress
        '
        Me.ChkSuppress.AutoSize = True
        Me.ChkSuppress.Location = New System.Drawing.Point(137, 97)
        Me.ChkSuppress.Name = "ChkSuppress"
        Me.ChkSuppress.Size = New System.Drawing.Size(151, 17)
        Me.ChkSuppress.TabIndex = 314
        Me.ChkSuppress.Text = "Suppress duplicate reports"
        Me.ChkSuppress.UseVisualStyleBackColor = True
        '
        'ChkBLOnOff
        '
        Me.ChkBLOnOff.AutoSize = True
        Me.ChkBLOnOff.Location = New System.Drawing.Point(151, 528)
        Me.ChkBLOnOff.Margin = New System.Windows.Forms.Padding(2)
        Me.ChkBLOnOff.Name = "ChkBLOnOff"
        Me.ChkBLOnOff.Size = New System.Drawing.Size(89, 17)
        Me.ChkBLOnOff.TabIndex = 319
        Me.ChkBLOnOff.Text = "On/Off/Flash"
        Me.ChkBLOnOff.ThreeState = True
        Me.ChkBLOnOff.UseVisualStyleBackColor = True
        '
        'CboKeyIndex
        '
        Me.CboKeyIndex.FormattingEnabled = True
        Me.CboKeyIndex.Items.AddRange(New Object() {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "55", "56", "57", "58", "59", "60", "61", "62", "63", "64", "65", "66", "67", "68", "69", "70", "71", "72", "73", "74", "75", "76", "77", "78", "79", "80", "81", "82", "83", "84", "85", "86", "87", "88", "89", "90", "91", "92", "93", "94", "95", "96", "97", "98", "99", "100", "101", "102", "103", "104", "105", "106", "107", "108", "109", "110", "111", "112", "113", "114", "115", "116", "117", "118", "119", "120", "121", "122", "123", "124", "125", "126", "127"})
        Me.CboKeyIndex.Location = New System.Drawing.Point(17, 527)
        Me.CboKeyIndex.Name = "CboKeyIndex"
        Me.CboKeyIndex.Size = New System.Drawing.Size(46, 21)
        Me.CboKeyIndex.TabIndex = 318
        '
        'label42
        '
        Me.label42.AutoSize = True
        Me.label42.Location = New System.Drawing.Point(7, 511)
        Me.label42.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.label42.Name = "label42"
        Me.label42.Size = New System.Drawing.Size(141, 13)
        Me.label42.TabIndex = 317
        Me.label42.Text = "Indivdual Backlight Features"
        '
        'ChkRedOnOff
        '
        Me.ChkRedOnOff.AutoSize = True
        Me.ChkRedOnOff.Location = New System.Drawing.Point(358, 528)
        Me.ChkRedOnOff.Margin = New System.Windows.Forms.Padding(2)
        Me.ChkRedOnOff.Name = "ChkRedOnOff"
        Me.ChkRedOnOff.Size = New System.Drawing.Size(110, 17)
        Me.ChkRedOnOff.TabIndex = 316
        Me.ChkRedOnOff.Text = "All Bank 2 On/Off"
        Me.ChkRedOnOff.UseVisualStyleBackColor = True
        '
        'ChkBlueOnOff
        '
        Me.ChkBlueOnOff.AutoSize = True
        Me.ChkBlueOnOff.Location = New System.Drawing.Point(244, 528)
        Me.ChkBlueOnOff.Margin = New System.Windows.Forms.Padding(2)
        Me.ChkBlueOnOff.Name = "ChkBlueOnOff"
        Me.ChkBlueOnOff.Size = New System.Drawing.Size(110, 17)
        Me.ChkBlueOnOff.TabIndex = 315
        Me.ChkBlueOnOff.Text = "All Bank 1 On/Off"
        Me.ChkBlueOnOff.UseVisualStyleBackColor = True
        '
        'BtnIncIntensity
        '
        Me.BtnIncIntensity.Location = New System.Drawing.Point(188, 586)
        Me.BtnIncIntensity.Margin = New System.Windows.Forms.Padding(2)
        Me.BtnIncIntensity.Name = "BtnIncIntensity"
        Me.BtnIncIntensity.Size = New System.Drawing.Size(147, 22)
        Me.BtnIncIntensity.TabIndex = 327
        Me.BtnIncIntensity.Text = "Incremental Intensity Bank1"
        Me.BtnIncIntensity.UseVisualStyleBackColor = True
        '
        'label43
        '
        Me.label43.AutoSize = True
        Me.label43.Location = New System.Drawing.Point(7, 571)
        Me.label43.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.label43.Name = "label43"
        Me.label43.Size = New System.Drawing.Size(128, 13)
        Me.label43.TabIndex = 326
        Me.label43.Text = "Global Backlight Features"
        '
        'BtnSetFlash
        '
        Me.BtnSetFlash.Location = New System.Drawing.Point(9, 586)
        Me.BtnSetFlash.Margin = New System.Windows.Forms.Padding(2)
        Me.BtnSetFlash.Name = "BtnSetFlash"
        Me.BtnSetFlash.Size = New System.Drawing.Size(92, 22)
        Me.BtnSetFlash.TabIndex = 325
        Me.BtnSetFlash.Text = "Set Flash Freq"
        Me.BtnSetFlash.UseVisualStyleBackColor = True
        '
        'TxtFlashFreq
        '
        Me.TxtFlashFreq.Location = New System.Drawing.Point(112, 588)
        Me.TxtFlashFreq.Margin = New System.Windows.Forms.Padding(2)
        Me.TxtFlashFreq.Name = "TxtFlashFreq"
        Me.TxtFlashFreq.Size = New System.Drawing.Size(30, 20)
        Me.TxtFlashFreq.TabIndex = 324
        Me.TxtFlashFreq.Text = "10"
        '
        'BtnBLToggle
        '
        Me.BtnBLToggle.Location = New System.Drawing.Point(352, 586)
        Me.BtnBLToggle.Margin = New System.Windows.Forms.Padding(2)
        Me.BtnBLToggle.Name = "BtnBLToggle"
        Me.BtnBLToggle.Size = New System.Drawing.Size(92, 22)
        Me.BtnBLToggle.TabIndex = 323
        Me.BtnBLToggle.Text = "Toggle"
        Me.BtnBLToggle.UseVisualStyleBackColor = True
        '
        'BtnSaveBL
        '
        Me.BtnSaveBL.Location = New System.Drawing.Point(352, 612)
        Me.BtnSaveBL.Margin = New System.Windows.Forms.Padding(2)
        Me.BtnSaveBL.Name = "BtnSaveBL"
        Me.BtnSaveBL.Size = New System.Drawing.Size(92, 22)
        Me.BtnSaveBL.TabIndex = 322
        Me.BtnSaveBL.Text = "Save Backlights"
        Me.BtnSaveBL.UseVisualStyleBackColor = True
        '
        'BtnBL
        '
        Me.BtnBL.Location = New System.Drawing.Point(9, 612)
        Me.BtnBL.Margin = New System.Windows.Forms.Padding(2)
        Me.BtnBL.Name = "BtnBL"
        Me.BtnBL.Size = New System.Drawing.Size(92, 22)
        Me.BtnBL.TabIndex = 321
        Me.BtnBL.Text = "Set Intensity"
        Me.BtnBL.UseVisualStyleBackColor = True
        '
        'CboColor
        '
        Me.CboColor.FormattingEnabled = True
        Me.CboColor.Items.AddRange(New Object() {"Bank 1", "Bank 2"})
        Me.CboColor.Location = New System.Drawing.Point(79, 527)
        Me.CboColor.Name = "CboColor"
        Me.CboColor.Size = New System.Drawing.Size(63, 21)
        Me.CboColor.TabIndex = 328
        '
        'LblPassFail
        '
        Me.LblPassFail.AutoSize = True
        Me.LblPassFail.Location = New System.Drawing.Point(763, 486)
        Me.LblPassFail.Name = "LblPassFail"
        Me.LblPassFail.Size = New System.Drawing.Size(51, 13)
        Me.LblPassFail.TabIndex = 350
        Me.LblPassFail.Text = "Pass/Fail"
        '
        'BtnCheckDongle
        '
        Me.BtnCheckDongle.Location = New System.Drawing.Point(646, 481)
        Me.BtnCheckDongle.Margin = New System.Windows.Forms.Padding(2)
        Me.BtnCheckDongle.Name = "BtnCheckDongle"
        Me.BtnCheckDongle.Size = New System.Drawing.Size(112, 22)
        Me.BtnCheckDongle.TabIndex = 349
        Me.BtnCheckDongle.Text = "Check Dongle Key"
        Me.BtnCheckDongle.UseVisualStyleBackColor = True
        '
        'BtnSetDongle
        '
        Me.BtnSetDongle.Location = New System.Drawing.Point(520, 481)
        Me.BtnSetDongle.Margin = New System.Windows.Forms.Padding(2)
        Me.BtnSetDongle.Name = "BtnSetDongle"
        Me.BtnSetDongle.Size = New System.Drawing.Size(112, 22)
        Me.BtnSetDongle.TabIndex = 348
        Me.BtnSetDongle.Text = "Set Dongle Key"
        Me.BtnSetDongle.UseVisualStyleBackColor = True
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(518, 467)
        Me.Label29.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(41, 13)
        Me.Label29.TabIndex = 347
        Me.Label29.Text = "Dongle"
        '
        'TxtIntensity1
        '
        Me.TxtIntensity1.Location = New System.Drawing.Point(112, 612)
        Me.TxtIntensity1.Margin = New System.Windows.Forms.Padding(2)
        Me.TxtIntensity1.Name = "TxtIntensity1"
        Me.TxtIntensity1.Size = New System.Drawing.Size(30, 20)
        Me.TxtIntensity1.TabIndex = 351
        Me.TxtIntensity1.Text = "255"
        '
        'TxtIntensity2
        '
        Me.TxtIntensity2.Location = New System.Drawing.Point(146, 612)
        Me.TxtIntensity2.Margin = New System.Windows.Forms.Padding(2)
        Me.TxtIntensity2.Name = "TxtIntensity2"
        Me.TxtIntensity2.Size = New System.Drawing.Size(30, 20)
        Me.TxtIntensity2.TabIndex = 352
        Me.TxtIntensity2.Text = "255"
        '
        'BtnIncIntensity2
        '
        Me.BtnIncIntensity2.Location = New System.Drawing.Point(188, 612)
        Me.BtnIncIntensity2.Margin = New System.Windows.Forms.Padding(2)
        Me.BtnIncIntensity2.Name = "BtnIncIntensity2"
        Me.BtnIncIntensity2.Size = New System.Drawing.Size(147, 22)
        Me.BtnIncIntensity2.TabIndex = 353
        Me.BtnIncIntensity2.Text = "Incremental Intensity Bank2"
        Me.BtnIncIntensity2.UseVisualStyleBackColor = True
        '
        'BtnChange
        '
        Me.BtnChange.Location = New System.Drawing.Point(733, 232)
        Me.BtnChange.Name = "BtnChange"
        Me.BtnChange.Size = New System.Drawing.Size(228, 23)
        Me.BtnChange.TabIndex = 356
        Me.BtnChange.Text = "Always change to PID #2 (KVM) on reboot"
        Me.BtnChange.UseVisualStyleBackColor = True
        '
        'BtnNoChange
        '
        Me.BtnNoChange.Location = New System.Drawing.Point(519, 232)
        Me.BtnNoChange.Name = "BtnNoChange"
        Me.BtnNoChange.Size = New System.Drawing.Size(209, 23)
        Me.BtnNoChange.TabIndex = 355
        Me.BtnNoChange.Text = "Do not change PID #2 (KVM) on reboot"
        Me.BtnNoChange.UseVisualStyleBackColor = True
        '
        'label6
        '
        Me.label6.AutoSize = True
        Me.label6.Location = New System.Drawing.Point(517, 216)
        Me.label6.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.label6.Name = "label6"
        Me.label6.Size = New System.Drawing.Size(72, 13)
        Me.label6.TabIndex = 354
        Me.label6.Text = "Reboot Mode"
        '
        'label25
        '
        Me.label25.AutoSize = True
        Me.label25.Location = New System.Drawing.Point(594, 315)
        Me.label25.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.label25.Name = "label25"
        Me.label25.Size = New System.Drawing.Size(214, 13)
        Me.label25.TabIndex = 358
        Me.label25.Text = "Endpoints: Keyboard only for use with KVM*"
        '
        'label8
        '
        Me.label8.Location = New System.Drawing.Point(518, 339)
        Me.label8.Name = "label8"
        Me.label8.Size = New System.Drawing.Size(445, 67)
        Me.label8.TabIndex = 359
        Me.label8.Text = resources.GetString("label8.Text")
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(967, 686)
        Me.Controls.Add(Me.label8)
        Me.Controls.Add(Me.label25)
        Me.Controls.Add(Me.BtnChange)
        Me.Controls.Add(Me.BtnNoChange)
        Me.Controls.Add(Me.label6)
        Me.Controls.Add(Me.BtnIncIntensity2)
        Me.Controls.Add(Me.TxtIntensity2)
        Me.Controls.Add(Me.TxtIntensity1)
        Me.Controls.Add(Me.LblPassFail)
        Me.Controls.Add(Me.BtnCheckDongle)
        Me.Controls.Add(Me.BtnSetDongle)
        Me.Controls.Add(Me.Label29)
        Me.Controls.Add(Me.CboColor)
        Me.Controls.Add(Me.BtnIncIntensity)
        Me.Controls.Add(Me.label43)
        Me.Controls.Add(Me.BtnSetFlash)
        Me.Controls.Add(Me.TxtFlashFreq)
        Me.Controls.Add(Me.BtnBLToggle)
        Me.Controls.Add(Me.BtnSaveBL)
        Me.Controls.Add(Me.BtnBL)
        Me.Controls.Add(Me.ChkBLOnOff)
        Me.Controls.Add(Me.CboKeyIndex)
        Me.Controls.Add(Me.label42)
        Me.Controls.Add(Me.ChkRedOnOff)
        Me.Controls.Add(Me.ChkBlueOnOff)
        Me.Controls.Add(Me.ChkSuppress)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.BtnMousereflect)
        Me.Controls.Add(Me.label24)
        Me.Controls.Add(Me.label41)
        Me.Controls.Add(Me.LblVersion)
        Me.Controls.Add(Me.TxtVersion)
        Me.Controls.Add(Me.BtnVersion)
        Me.Controls.Add(Me.label14)
        Me.Controls.Add(Me.BtnCustom)
        Me.Controls.Add(Me.BtnTimeStampOn)
        Me.Controls.Add(Me.ChkRed)
        Me.Controls.Add(Me.ChkGreen)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.LblScrLk)
        Me.Controls.Add(Me.LblCapsLk)
        Me.Controls.Add(Me.LblNumLk)
        Me.Controls.Add(Me.BtnPID2)
        Me.Controls.Add(Me.label30)
        Me.Controls.Add(Me.TxtWheel)
        Me.Controls.Add(Me.label32)
        Me.Controls.Add(Me.label33)
        Me.Controls.Add(Me.label34)
        Me.Controls.Add(Me.TxtMouseButtons)
        Me.Controls.Add(Me.TxtMouseY)
        Me.Controls.Add(Me.TxtMouseX)
        Me.Controls.Add(Me.BtnGetDataNow)
        Me.Controls.Add(Me.listBox2)
        Me.Controls.Add(Me.BtnDescriptor)
        Me.Controls.Add(Me.label21)
        Me.Controls.Add(Me.label23)
        Me.Controls.Add(Me.lbldeltatime)
        Me.Controls.Add(Me.lblabstime)
        Me.Controls.Add(Me.BtnTimeStamp)
        Me.Controls.Add(Me.textBox1)
        Me.Controls.Add(Me.BtnKBreflect)
        Me.Controls.Add(Me.label7)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.label3)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.LblUnitID)
        Me.Controls.Add(Me.TxtUnitID)
        Me.Controls.Add(Me.BtnWriteUnitID)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.BtnCallback)
        Me.Controls.Add(Me.CboDevices)
        Me.Controls.Add(Me.LblStatus)
        Me.Controls.Add(Me.BtnEnumerate)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "Form1"
        Me.Text = "VB X-keys XKE-128 KVM"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents BtnCallback As System.Windows.Forms.Button
    Friend WithEvents CboDevices As System.Windows.Forms.ComboBox
    Friend WithEvents LblStatus As System.Windows.Forms.Label
    Friend WithEvents BtnEnumerate As System.Windows.Forms.Button
    Friend WithEvents LblUnitID As System.Windows.Forms.Label
    Friend WithEvents TxtUnitID As System.Windows.Forms.TextBox
    Friend WithEvents BtnWriteUnitID As System.Windows.Forms.Button
    Private WithEvents label3 As System.Windows.Forms.Label
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents label1 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Private WithEvents textBox1 As System.Windows.Forms.TextBox
    Private WithEvents BtnKBreflect As System.Windows.Forms.Button
    Private WithEvents label7 As System.Windows.Forms.Label
    Private WithEvents label23 As System.Windows.Forms.Label
    Private WithEvents lbldeltatime As System.Windows.Forms.Label
    Private WithEvents lblabstime As System.Windows.Forms.Label
    Private WithEvents BtnTimeStamp As System.Windows.Forms.Button
    Private WithEvents listBox2 As System.Windows.Forms.ListBox
    Private WithEvents BtnDescriptor As System.Windows.Forms.Button
    Private WithEvents label21 As System.Windows.Forms.Label
    Private WithEvents BtnGetDataNow As System.Windows.Forms.Button
    Private WithEvents label30 As System.Windows.Forms.Label
    Private WithEvents TxtWheel As System.Windows.Forms.TextBox
    Private WithEvents label32 As System.Windows.Forms.Label
    Private WithEvents label33 As System.Windows.Forms.Label
    Private WithEvents label34 As System.Windows.Forms.Label
    Private WithEvents TxtMouseButtons As System.Windows.Forms.TextBox
    Private WithEvents TxtMouseY As System.Windows.Forms.TextBox
    Private WithEvents TxtMouseX As System.Windows.Forms.TextBox
    Friend WithEvents BtnPID2 As System.Windows.Forms.Button
    Private WithEvents LblScrLk As System.Windows.Forms.Label
    Private WithEvents LblCapsLk As System.Windows.Forms.Label
    Private WithEvents LblNumLk As System.Windows.Forms.Label
    Private WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents ChkGreen As System.Windows.Forms.CheckBox
    Friend WithEvents ChkRed As System.Windows.Forms.CheckBox
    Private WithEvents BtnTimeStampOn As System.Windows.Forms.Button
    Private WithEvents BtnCustom As System.Windows.Forms.Button
    Private WithEvents label14 As System.Windows.Forms.Label
    Private WithEvents label41 As System.Windows.Forms.Label
    Private WithEvents LblVersion As System.Windows.Forms.Label
    Private WithEvents TxtVersion As System.Windows.Forms.TextBox
    Private WithEvents BtnVersion As System.Windows.Forms.Button
    Private WithEvents BtnMousereflect As System.Windows.Forms.Button
    Private WithEvents label24 As System.Windows.Forms.Label
    Private WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents ChkSuppress As System.Windows.Forms.CheckBox
    Private WithEvents ChkBLOnOff As System.Windows.Forms.CheckBox
    Private WithEvents CboKeyIndex As System.Windows.Forms.ComboBox
    Private WithEvents label42 As System.Windows.Forms.Label
    Private WithEvents ChkRedOnOff As System.Windows.Forms.CheckBox
    Private WithEvents ChkBlueOnOff As System.Windows.Forms.CheckBox
    Private WithEvents BtnIncIntensity As System.Windows.Forms.Button
    Private WithEvents label43 As System.Windows.Forms.Label
    Private WithEvents BtnSetFlash As System.Windows.Forms.Button
    Private WithEvents TxtFlashFreq As System.Windows.Forms.TextBox
    Private WithEvents BtnBLToggle As System.Windows.Forms.Button
    Private WithEvents BtnSaveBL As System.Windows.Forms.Button
    Private WithEvents BtnBL As System.Windows.Forms.Button
    Friend WithEvents CboColor As System.Windows.Forms.ComboBox
    Private WithEvents LblPassFail As System.Windows.Forms.Label
    Private WithEvents BtnCheckDongle As System.Windows.Forms.Button
    Private WithEvents BtnSetDongle As System.Windows.Forms.Button
    Private WithEvents Label29 As System.Windows.Forms.Label
    Private WithEvents TxtIntensity1 As System.Windows.Forms.TextBox
    Private WithEvents TxtIntensity2 As System.Windows.Forms.TextBox
    Private WithEvents BtnIncIntensity2 As System.Windows.Forms.Button
    Private WithEvents BtnChange As System.Windows.Forms.Button
    Private WithEvents BtnNoChange As System.Windows.Forms.Button
    Private WithEvents label6 As System.Windows.Forms.Label
    Private WithEvents label25 As System.Windows.Forms.Label
    Private WithEvents label8 As System.Windows.Forms.Label

End Class
