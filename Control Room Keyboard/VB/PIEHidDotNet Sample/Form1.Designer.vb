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
        Me.Label13 = New System.Windows.Forms.Label()
        Me.ChkGreen = New System.Windows.Forms.CheckBox()
        Me.BtnTimeStampOn = New System.Windows.Forms.Button()
        Me.BtnCustom = New System.Windows.Forms.Button()
        Me.label14 = New System.Windows.Forms.Label()
        Me.label41 = New System.Windows.Forms.Label()
        Me.LblVersion = New System.Windows.Forms.Label()
        Me.TxtVersion = New System.Windows.Forms.TextBox()
        Me.BtnVersion = New System.Windows.Forms.Button()
        Me.BtnSleep = New System.Windows.Forms.Button()
        Me.BtnMyComputer = New System.Windows.Forms.Button()
        Me.label39 = New System.Windows.Forms.Label()
        Me.label40 = New System.Windows.Forms.Label()
        Me.TxtMMHigh = New System.Windows.Forms.TextBox()
        Me.TxtMMLow = New System.Windows.Forms.TextBox()
        Me.BtnMultiMedia = New System.Windows.Forms.Button()
        Me.label38 = New System.Windows.Forms.Label()
        Me.ChkSuppress = New System.Windows.Forms.CheckBox()
        Me.LblButtons = New System.Windows.Forms.Label()
        Me.CboLED = New System.Windows.Forms.ComboBox()
        Me.label47 = New System.Windows.Forms.Label()
        Me.cboPIDs = New System.Windows.Forms.ComboBox()
        Me.btnChangePID = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.BtnChange = New System.Windows.Forms.Button()
        Me.BtnNoChange = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblSiliconGeneratedID = New System.Windows.Forms.Label()
        Me.label57 = New System.Windows.Forms.Label()
        Me.btnSiliconGeneratedID = New System.Windows.Forms.Button()
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
        Me.LblStatus.Location = New System.Drawing.Point(67, 686)
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
        Me.LblUnitID.Location = New System.Drawing.Point(150, 251)
        Me.LblUnitID.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LblUnitID.Name = "LblUnitID"
        Me.LblUnitID.Size = New System.Drawing.Size(38, 20)
        Me.LblUnitID.TabIndex = 26
        Me.LblUnitID.Text = "Unit ID"
        '
        'TxtUnitID
        '
        Me.TxtUnitID.Location = New System.Drawing.Point(122, 248)
        Me.TxtUnitID.Margin = New System.Windows.Forms.Padding(2)
        Me.TxtUnitID.Name = "TxtUnitID"
        Me.TxtUnitID.Size = New System.Drawing.Size(25, 20)
        Me.TxtUnitID.TabIndex = 25
        Me.TxtUnitID.Text = "1"
        '
        'BtnWriteUnitID
        '
        Me.BtnWriteUnitID.Location = New System.Drawing.Point(11, 246)
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
        Me.label3.Location = New System.Drawing.Point(9, 231)
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
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 686)
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
        Me.textBox1.Location = New System.Drawing.Point(660, 20)
        Me.textBox1.Margin = New System.Windows.Forms.Padding(2)
        Me.textBox1.Name = "textBox1"
        Me.textBox1.Size = New System.Drawing.Size(191, 20)
        Me.textBox1.TabIndex = 45
        '
        'BtnKBreflect
        '
        Me.BtnKBreflect.Location = New System.Drawing.Point(522, 20)
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
        Me.label7.Location = New System.Drawing.Point(520, 2)
        Me.label7.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.label7.Name = "label7"
        Me.label7.Size = New System.Drawing.Size(98, 13)
        Me.label7.TabIndex = 43
        Me.label7.Text = "Keyboard Reflector"
        '
        'label23
        '
        Me.label23.AutoSize = True
        Me.label23.Location = New System.Drawing.Point(14, 560)
        Me.label23.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.label23.Name = "label23"
        Me.label23.Size = New System.Drawing.Size(99, 13)
        Me.label23.TabIndex = 72
        Me.label23.Text = "Enable Time Stamp"
        '
        'lbldeltatime
        '
        Me.lbldeltatime.AutoSize = True
        Me.lbldeltatime.Location = New System.Drawing.Point(243, 594)
        Me.lbldeltatime.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbldeltatime.Name = "lbldeltatime"
        Me.lbldeltatime.Size = New System.Drawing.Size(52, 13)
        Me.lbldeltatime.TabIndex = 71
        Me.lbldeltatime.Text = "delta time"
        '
        'lblabstime
        '
        Me.lblabstime.AutoSize = True
        Me.lblabstime.Location = New System.Drawing.Point(243, 580)
        Me.lblabstime.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblabstime.Name = "lblabstime"
        Me.lblabstime.Size = New System.Drawing.Size(69, 13)
        Me.lblabstime.TabIndex = 70
        Me.lblabstime.Text = "absolute time"
        '
        'BtnTimeStamp
        '
        Me.BtnTimeStamp.Location = New System.Drawing.Point(16, 585)
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
        Me.listBox2.Location = New System.Drawing.Point(122, 369)
        Me.listBox2.Margin = New System.Windows.Forms.Padding(2)
        Me.listBox2.Name = "listBox2"
        Me.listBox2.Size = New System.Drawing.Size(232, 108)
        Me.listBox2.TabIndex = 75
        '
        'BtnDescriptor
        '
        Me.BtnDescriptor.Location = New System.Drawing.Point(15, 368)
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
        Me.label21.Location = New System.Drawing.Point(13, 349)
        Me.label21.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.label21.Name = "label21"
        Me.label21.Size = New System.Drawing.Size(55, 13)
        Me.label21.TabIndex = 73
        Me.label21.Text = "Descriptor"
        '
        'BtnGetDataNow
        '
        Me.BtnGetDataNow.Location = New System.Drawing.Point(15, 521)
        Me.BtnGetDataNow.Margin = New System.Windows.Forms.Padding(2)
        Me.BtnGetDataNow.Name = "BtnGetDataNow"
        Me.BtnGetDataNow.Size = New System.Drawing.Size(98, 22)
        Me.BtnGetDataNow.TabIndex = 124
        Me.BtnGetDataNow.Text = "Generate Data"
        Me.BtnGetDataNow.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(12, 290)
        Me.Label13.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(77, 13)
        Me.Label13.TabIndex = 233
        Me.Label13.Text = "Indicator LEDs"
        '
        'ChkGreen
        '
        Me.ChkGreen.AutoSize = True
        Me.ChkGreen.Location = New System.Drawing.Point(86, 310)
        Me.ChkGreen.Name = "ChkGreen"
        Me.ChkGreen.Size = New System.Drawing.Size(89, 17)
        Me.ChkGreen.TabIndex = 234
        Me.ChkGreen.Tag = ""
        Me.ChkGreen.Text = "On/Off/Flash"
        Me.ChkGreen.ThreeState = True
        Me.ChkGreen.UseVisualStyleBackColor = True
        '
        'BtnTimeStampOn
        '
        Me.BtnTimeStampOn.Location = New System.Drawing.Point(127, 585)
        Me.BtnTimeStampOn.Margin = New System.Windows.Forms.Padding(2)
        Me.BtnTimeStampOn.Name = "BtnTimeStampOn"
        Me.BtnTimeStampOn.Size = New System.Drawing.Size(99, 22)
        Me.BtnTimeStampOn.TabIndex = 291
        Me.BtnTimeStampOn.Text = "Time Stamp On"
        Me.BtnTimeStampOn.UseVisualStyleBackColor = True
        '
        'BtnCustom
        '
        Me.BtnCustom.Location = New System.Drawing.Point(127, 521)
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
        Me.label14.Location = New System.Drawing.Point(14, 497)
        Me.label14.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.label14.Name = "label14"
        Me.label14.Size = New System.Drawing.Size(313, 13)
        Me.label14.TabIndex = 293
        Me.label14.Text = "Stimulate a general incoming data report or a custom input report."
        '
        'label41
        '
        Me.label41.AutoSize = True
        Me.label41.Location = New System.Drawing.Point(13, 624)
        Me.label41.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.label41.Name = "label41"
        Me.label41.Size = New System.Drawing.Size(195, 13)
        Me.label41.TabIndex = 297
        Me.label41.Text = "Write Version (0-65535), reboot required"
        '
        'LblVersion
        '
        Me.LblVersion.AutoSize = True
        Me.LblVersion.Location = New System.Drawing.Point(183, 651)
        Me.LblVersion.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LblVersion.Name = "LblVersion"
        Me.LblVersion.Size = New System.Drawing.Size(41, 13)
        Me.LblVersion.TabIndex = 296
        Me.LblVersion.Text = "version"
        '
        'TxtVersion
        '
        Me.TxtVersion.Location = New System.Drawing.Point(122, 648)
        Me.TxtVersion.Margin = New System.Windows.Forms.Padding(2)
        Me.TxtVersion.Name = "TxtVersion"
        Me.TxtVersion.Size = New System.Drawing.Size(49, 20)
        Me.TxtVersion.TabIndex = 295
        Me.TxtVersion.Text = "100"
        '
        'BtnVersion
        '
        Me.BtnVersion.Location = New System.Drawing.Point(15, 646)
        Me.BtnVersion.Margin = New System.Windows.Forms.Padding(2)
        Me.BtnVersion.Name = "BtnVersion"
        Me.BtnVersion.Size = New System.Drawing.Size(92, 22)
        Me.BtnVersion.TabIndex = 294
        Me.BtnVersion.Text = "Write Version"
        Me.BtnVersion.UseVisualStyleBackColor = True
        '
        'BtnSleep
        '
        Me.BtnSleep.Location = New System.Drawing.Point(858, 90)
        Me.BtnSleep.Name = "BtnSleep"
        Me.BtnSleep.Size = New System.Drawing.Size(80, 22)
        Me.BtnSleep.TabIndex = 304
        Me.BtnSleep.Text = "Sleep"
        Me.BtnSleep.UseVisualStyleBackColor = True
        '
        'BtnMyComputer
        '
        Me.BtnMyComputer.Location = New System.Drawing.Point(773, 91)
        Me.BtnMyComputer.Margin = New System.Windows.Forms.Padding(2)
        Me.BtnMyComputer.Name = "BtnMyComputer"
        Me.BtnMyComputer.Size = New System.Drawing.Size(80, 22)
        Me.BtnMyComputer.TabIndex = 303
        Me.BtnMyComputer.Text = "My Computer"
        Me.BtnMyComputer.UseVisualStyleBackColor = True
        '
        'label39
        '
        Me.label39.AutoSize = True
        Me.label39.Location = New System.Drawing.Point(657, 77)
        Me.label39.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.label39.Name = "label39"
        Me.label39.Size = New System.Drawing.Size(55, 13)
        Me.label39.TabIndex = 308
        Me.label39.Text = "High (hex)"
        '
        'label40
        '
        Me.label40.AutoSize = True
        Me.label40.Location = New System.Drawing.Point(718, 77)
        Me.label40.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.label40.Name = "label40"
        Me.label40.Size = New System.Drawing.Size(45, 13)
        Me.label40.TabIndex = 307
        Me.label40.Text = "Lo (hex)"
        '
        'TxtMMHigh
        '
        Me.TxtMMHigh.Location = New System.Drawing.Point(660, 92)
        Me.TxtMMHigh.Margin = New System.Windows.Forms.Padding(2)
        Me.TxtMMHigh.Name = "TxtMMHigh"
        Me.TxtMMHigh.Size = New System.Drawing.Size(30, 20)
        Me.TxtMMHigh.TabIndex = 306
        Me.TxtMMHigh.Text = "00"
        '
        'TxtMMLow
        '
        Me.TxtMMLow.Location = New System.Drawing.Point(721, 92)
        Me.TxtMMLow.Margin = New System.Windows.Forms.Padding(2)
        Me.TxtMMLow.Name = "TxtMMLow"
        Me.TxtMMLow.Size = New System.Drawing.Size(30, 20)
        Me.TxtMMLow.TabIndex = 305
        Me.TxtMMLow.Text = "E2"
        '
        'BtnMultiMedia
        '
        Me.BtnMultiMedia.Location = New System.Drawing.Point(522, 92)
        Me.BtnMultiMedia.Margin = New System.Windows.Forms.Padding(2)
        Me.BtnMultiMedia.Name = "BtnMultiMedia"
        Me.BtnMultiMedia.Size = New System.Drawing.Size(122, 22)
        Me.BtnMultiMedia.TabIndex = 302
        Me.BtnMultiMedia.Text = "Multimedia Reflector"
        Me.BtnMultiMedia.UseVisualStyleBackColor = True
        '
        'label38
        '
        Me.label38.AutoSize = True
        Me.label38.Location = New System.Drawing.Point(520, 71)
        Me.label38.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.label38.Name = "label38"
        Me.label38.Size = New System.Drawing.Size(57, 13)
        Me.label38.TabIndex = 301
        Me.label38.Text = "Multimedia"
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
        'LblButtons
        '
        Me.LblButtons.AutoSize = True
        Me.LblButtons.Location = New System.Drawing.Point(9, 203)
        Me.LblButtons.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LblButtons.Name = "LblButtons"
        Me.LblButtons.Size = New System.Drawing.Size(46, 13)
        Me.LblButtons.TabIndex = 353
        Me.LblButtons.Text = "Buttons:"
        '
        'CboLED
        '
        Me.CboLED.FormattingEnabled = True
        Me.CboLED.Items.AddRange(New Object() {"1", "2", "3", "4"})
        Me.CboLED.Location = New System.Drawing.Point(12, 306)
        Me.CboLED.Name = "CboLED"
        Me.CboLED.Size = New System.Drawing.Size(68, 21)
        Me.CboLED.TabIndex = 354
        '
        'label47
        '
        Me.label47.AutoSize = True
        Me.label47.Location = New System.Drawing.Point(520, 165)
        Me.label47.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.label47.Name = "label47"
        Me.label47.Size = New System.Drawing.Size(123, 13)
        Me.label47.TabIndex = 358
        Me.label47.Text = "Select desired endpoints"
        '
        'cboPIDs
        '
        Me.cboPIDs.FormattingEnabled = True
        Me.cboPIDs.Items.AddRange(New Object() {"PID 1: Keyboard, PI Consumer, Output", "PID 2: Keyboard (boot) for KVM users"})
        Me.cboPIDs.Location = New System.Drawing.Point(522, 181)
        Me.cboPIDs.Name = "cboPIDs"
        Me.cboPIDs.Size = New System.Drawing.Size(258, 21)
        Me.cboPIDs.TabIndex = 356
        '
        'btnChangePID
        '
        Me.btnChangePID.Location = New System.Drawing.Point(522, 212)
        Me.btnChangePID.Margin = New System.Windows.Forms.Padding(2)
        Me.btnChangePID.Name = "btnChangePID"
        Me.btnChangePID.Size = New System.Drawing.Size(91, 22)
        Me.btnChangePID.TabIndex = 357
        Me.btnChangePID.Text = "Change"
        Me.btnChangePID.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(520, 141)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(272, 13)
        Me.Label4.TabIndex = 355
        Me.Label4.Text = "Change PID/Endpoints (must enumerate after changing)"
        '
        'BtnChange
        '
        Me.BtnChange.Location = New System.Drawing.Point(697, 279)
        Me.BtnChange.Name = "BtnChange"
        Me.BtnChange.Size = New System.Drawing.Size(225, 23)
        Me.BtnChange.TabIndex = 360
        Me.BtnChange.Text = "Always change to PID #2 (KVM) on reboot"
        Me.BtnChange.UseVisualStyleBackColor = True
        '
        'BtnNoChange
        '
        Me.BtnNoChange.Location = New System.Drawing.Point(522, 279)
        Me.BtnNoChange.Name = "BtnNoChange"
        Me.BtnNoChange.Size = New System.Drawing.Size(163, 23)
        Me.BtnNoChange.TabIndex = 359
        Me.BtnNoChange.Text = "Do not change PID on reboot"
        Me.BtnNoChange.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(521, 258)
        Me.Label6.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(243, 13)
        Me.Label6.TabIndex = 361
        Me.Label6.Text = "KVM Reboot Mode (for users of the KVM Pid only)"
        '
        'lblSiliconGeneratedID
        '
        Me.lblSiliconGeneratedID.AutoSize = True
        Me.lblSiliconGeneratedID.Location = New System.Drawing.Point(603, 347)
        Me.lblSiliconGeneratedID.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblSiliconGeneratedID.Name = "lblSiliconGeneratedID"
        Me.lblSiliconGeneratedID.Size = New System.Drawing.Size(99, 13)
        Me.lblSiliconGeneratedID.TabIndex = 515
        Me.lblSiliconGeneratedID.Text = "Silicon Generate ID"
        '
        'label57
        '
        Me.label57.AutoSize = True
        Me.label57.Location = New System.Drawing.Point(521, 322)
        Me.label57.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.label57.Name = "label57"
        Me.label57.Size = New System.Drawing.Size(128, 13)
        Me.label57.TabIndex = 514
        Me.label57.Text = "Read Silicon Generate ID"
        '
        'btnSiliconGeneratedID
        '
        Me.btnSiliconGeneratedID.Location = New System.Drawing.Point(522, 342)
        Me.btnSiliconGeneratedID.Name = "btnSiliconGeneratedID"
        Me.btnSiliconGeneratedID.Size = New System.Drawing.Size(75, 23)
        Me.btnSiliconGeneratedID.TabIndex = 513
        Me.btnSiliconGeneratedID.Text = "Read ID"
        Me.btnSiliconGeneratedID.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(996, 708)
        Me.Controls.Add(Me.lblSiliconGeneratedID)
        Me.Controls.Add(Me.label57)
        Me.Controls.Add(Me.btnSiliconGeneratedID)
        Me.Controls.Add(Me.BtnChange)
        Me.Controls.Add(Me.BtnNoChange)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.label47)
        Me.Controls.Add(Me.cboPIDs)
        Me.Controls.Add(Me.btnChangePID)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.CboLED)
        Me.Controls.Add(Me.LblButtons)
        Me.Controls.Add(Me.ChkSuppress)
        Me.Controls.Add(Me.BtnSleep)
        Me.Controls.Add(Me.BtnMyComputer)
        Me.Controls.Add(Me.label39)
        Me.Controls.Add(Me.label40)
        Me.Controls.Add(Me.TxtMMHigh)
        Me.Controls.Add(Me.TxtMMLow)
        Me.Controls.Add(Me.BtnMultiMedia)
        Me.Controls.Add(Me.label38)
        Me.Controls.Add(Me.label41)
        Me.Controls.Add(Me.LblVersion)
        Me.Controls.Add(Me.TxtVersion)
        Me.Controls.Add(Me.BtnVersion)
        Me.Controls.Add(Me.label14)
        Me.Controls.Add(Me.BtnCustom)
        Me.Controls.Add(Me.BtnTimeStampOn)
        Me.Controls.Add(Me.ChkGreen)
        Me.Controls.Add(Me.Label13)
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
        Me.Text = "VB X-keys Control Room Keyboard"
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
    Private WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents ChkGreen As System.Windows.Forms.CheckBox
    Private WithEvents BtnTimeStampOn As System.Windows.Forms.Button
    Private WithEvents BtnCustom As System.Windows.Forms.Button
    Private WithEvents label14 As System.Windows.Forms.Label
    Private WithEvents label41 As System.Windows.Forms.Label
    Private WithEvents LblVersion As System.Windows.Forms.Label
    Private WithEvents TxtVersion As System.Windows.Forms.TextBox
    Private WithEvents BtnVersion As System.Windows.Forms.Button
    Private WithEvents BtnSleep As System.Windows.Forms.Button
    Private WithEvents BtnMyComputer As System.Windows.Forms.Button
    Private WithEvents label39 As System.Windows.Forms.Label
    Private WithEvents label40 As System.Windows.Forms.Label
    Private WithEvents TxtMMHigh As System.Windows.Forms.TextBox
    Private WithEvents TxtMMLow As System.Windows.Forms.TextBox
    Private WithEvents BtnMultiMedia As System.Windows.Forms.Button
    Private WithEvents label38 As System.Windows.Forms.Label
    Friend WithEvents ChkSuppress As System.Windows.Forms.CheckBox
    Private WithEvents LblButtons As System.Windows.Forms.Label
    Private WithEvents CboLED As System.Windows.Forms.ComboBox
    Private WithEvents label47 As System.Windows.Forms.Label
    Private WithEvents cboPIDs As System.Windows.Forms.ComboBox
    Private WithEvents btnChangePID As System.Windows.Forms.Button
    Private WithEvents Label4 As System.Windows.Forms.Label
    Private WithEvents BtnChange As System.Windows.Forms.Button
    Private WithEvents BtnNoChange As System.Windows.Forms.Button
    Private WithEvents Label6 As System.Windows.Forms.Label
    Private WithEvents lblSiliconGeneratedID As System.Windows.Forms.Label
    Private WithEvents label57 As System.Windows.Forms.Label
    Private WithEvents btnSiliconGeneratedID As System.Windows.Forms.Button

End Class
