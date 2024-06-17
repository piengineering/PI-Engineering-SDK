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
        Me.components = New System.ComponentModel.Container()
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
        Me.listBox2 = New System.Windows.Forms.ListBox()
        Me.BtnDescriptor = New System.Windows.Forms.Button()
        Me.label21 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.ChkGreen = New System.Windows.Forms.CheckBox()
        Me.ChkRed = New System.Windows.Forms.CheckBox()
        Me.ChkSuppress = New System.Windows.Forms.CheckBox()
        Me.LblScrLk = New System.Windows.Forms.Label()
        Me.LblCapsLk = New System.Windows.Forms.Label()
        Me.LblNumLk = New System.Windows.Forms.Label()
        Me.LblSwitchPos = New System.Windows.Forms.Label()
        Me.LblButtons = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.btnReadRS232Settings = New System.Windows.Forms.Button()
        Me.label51 = New System.Windows.Forms.Label()
        Me.btnWriteXkeysTx = New System.Windows.Forms.Button()
        Me.txtSendText = New System.Windows.Forms.TextBox()
        Me.lblUSBCheckState = New System.Windows.Forms.Label()
        Me.btnUSBCheckOff = New System.Windows.Forms.Button()
        Me.btnUSBCheckOn = New System.Windows.Forms.Button()
        Me.lblReawakeState = New System.Windows.Forms.Label()
        Me.btnSleepEnabled = New System.Windows.Forms.Button()
        Me.btnSleepDisabled = New System.Windows.Forms.Button()
        Me.lblJsonState = New System.Windows.Forms.Label()
        Me.btnJsonOff = New System.Windows.Forms.Button()
        Me.btnJsonOn = New System.Windows.Forms.Button()
        Me.lblEchoState = New System.Windows.Forms.Label()
        Me.btnEchoOff = New System.Windows.Forms.Button()
        Me.btnEchoOn = New System.Windows.Forms.Button()
        Me.label36 = New System.Windows.Forms.Label()
        Me.label56 = New System.Windows.Forms.Label()
        Me.cboStopBits = New System.Windows.Forms.ComboBox()
        Me.label54 = New System.Windows.Forms.Label()
        Me.label53 = New System.Windows.Forms.Label()
        Me.label52 = New System.Windows.Forms.Label()
        Me.cboDataBits = New System.Windows.Forms.ComboBox()
        Me.cboParity = New System.Windows.Forms.ComboBox()
        Me.btnRS232Settings = New System.Windows.Forms.Button()
        Me.label48 = New System.Windows.Forms.Label()
        Me.cboBaudRate = New System.Windows.Forms.ComboBox()
        Me.serialPort1 = New System.IO.Ports.SerialPort(Me.components)
        Me.BtnBLToggle = New System.Windows.Forms.Button()
        Me.label43 = New System.Windows.Forms.Label()
        Me.label63 = New System.Windows.Forms.Label()
        Me.cboCOMStop = New System.Windows.Forms.ComboBox()
        Me.label65 = New System.Windows.Forms.Label()
        Me.label67 = New System.Windows.Forms.Label()
        Me.label68 = New System.Windows.Forms.Label()
        Me.cboCOMData = New System.Windows.Forms.ComboBox()
        Me.cboCOMParity = New System.Windows.Forms.ComboBox()
        Me.label57 = New System.Windows.Forms.Label()
        Me.cboCOMBaud = New System.Windows.Forms.ComboBox()
        Me.label50 = New System.Windows.Forms.Label()
        Me.txtSendCOMUSB = New System.Windows.Forms.TextBox()
        Me.btnCOMPortUSB = New System.Windows.Forms.Button()
        Me.label45 = New System.Windows.Forms.Label()
        Me.label35 = New System.Windows.Forms.Label()
        Me.label31 = New System.Windows.Forms.Label()
        Me.CboPorts = New System.Windows.Forms.ComboBox()
        Me.listBox5 = New System.Windows.Forms.ListBox()
        Me.button3 = New System.Windows.Forms.Button()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.txtBase64Encode = New System.Windows.Forms.TextBox()
        Me.btnCOMPortInternal = New System.Windows.Forms.Button()
        Me.lblEncoded = New System.Windows.Forms.Label()
        Me.label49 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.label46 = New System.Windows.Forms.Label()
        Me.label55 = New System.Windows.Forms.Label()
        Me.label58 = New System.Windows.Forms.Label()
        Me.label64 = New System.Windows.Forms.Label()
        Me.label66 = New System.Windows.Forms.Label()
        Me.label6 = New System.Windows.Forms.Label()
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
        Me.LblStatus.Location = New System.Drawing.Point(69, 689)
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
        Me.LblUnitID.Location = New System.Drawing.Point(156, 339)
        Me.LblUnitID.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LblUnitID.Name = "LblUnitID"
        Me.LblUnitID.Size = New System.Drawing.Size(52, 20)
        Me.LblUnitID.TabIndex = 26
        Me.LblUnitID.Text = "Unit ID"
        '
        'TxtUnitID
        '
        Me.TxtUnitID.Location = New System.Drawing.Point(128, 336)
        Me.TxtUnitID.Margin = New System.Windows.Forms.Padding(2)
        Me.TxtUnitID.Name = "TxtUnitID"
        Me.TxtUnitID.Size = New System.Drawing.Size(25, 20)
        Me.TxtUnitID.TabIndex = 25
        Me.TxtUnitID.Text = "1"
        '
        'BtnWriteUnitID
        '
        Me.BtnWriteUnitID.Location = New System.Drawing.Point(17, 334)
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
        Me.label3.Location = New System.Drawing.Point(7, 315)
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
        Me.Label5.Location = New System.Drawing.Point(14, 689)
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
        'listBox2
        '
        Me.listBox2.FormattingEnabled = True
        Me.listBox2.HorizontalScrollbar = True
        Me.listBox2.Location = New System.Drawing.Point(127, 508)
        Me.listBox2.Margin = New System.Windows.Forms.Padding(2)
        Me.listBox2.Name = "listBox2"
        Me.listBox2.Size = New System.Drawing.Size(232, 134)
        Me.listBox2.TabIndex = 75
        '
        'BtnDescriptor
        '
        Me.BtnDescriptor.Location = New System.Drawing.Point(20, 507)
        Me.BtnDescriptor.Margin = New System.Windows.Forms.Padding(2)
        Me.BtnDescriptor.Name = "BtnDescriptor"
        Me.BtnDescriptor.Size = New System.Drawing.Size(104, 22)
        Me.BtnDescriptor.TabIndex = 74
        Me.BtnDescriptor.Text = "Descriptor"
        Me.BtnDescriptor.UseVisualStyleBackColor = True
        '
        'label21
        '
        Me.label21.AutoSize = True
        Me.label21.Location = New System.Drawing.Point(6, 484)
        Me.label21.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.label21.Name = "label21"
        Me.label21.Size = New System.Drawing.Size(55, 13)
        Me.label21.TabIndex = 73
        Me.label21.Text = "Descriptor"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(7, 285)
        Me.Label13.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(33, 13)
        Me.Label13.TabIndex = 233
        Me.Label13.Text = "LEDs"
        '
        'ChkGreen
        '
        Me.ChkGreen.AutoSize = True
        Me.ChkGreen.Location = New System.Drawing.Point(59, 284)
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
        Me.ChkRed.Location = New System.Drawing.Point(120, 284)
        Me.ChkRed.Name = "ChkRed"
        Me.ChkRed.Size = New System.Drawing.Size(46, 17)
        Me.ChkRed.TabIndex = 235
        Me.ChkRed.Tag = "7"
        Me.ChkRed.Text = "Red"
        Me.ChkRed.ThreeState = True
        Me.ChkRed.UseVisualStyleBackColor = True
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
        'LblScrLk
        '
        Me.LblScrLk.AutoSize = True
        Me.LblScrLk.Location = New System.Drawing.Point(325, 234)
        Me.LblScrLk.Name = "LblScrLk"
        Me.LblScrLk.Size = New System.Drawing.Size(53, 13)
        Me.LblScrLk.TabIndex = 364
        Me.LblScrLk.Text = "ScrLock: "
        '
        'LblCapsLk
        '
        Me.LblCapsLk.AutoSize = True
        Me.LblCapsLk.Location = New System.Drawing.Point(325, 220)
        Me.LblCapsLk.Name = "LblCapsLk"
        Me.LblCapsLk.Size = New System.Drawing.Size(61, 13)
        Me.LblCapsLk.TabIndex = 363
        Me.LblCapsLk.Text = "CapsLock: "
        '
        'LblNumLk
        '
        Me.LblNumLk.AutoSize = True
        Me.LblNumLk.Location = New System.Drawing.Point(325, 205)
        Me.LblNumLk.Name = "LblNumLk"
        Me.LblNumLk.Size = New System.Drawing.Size(59, 13)
        Me.LblNumLk.TabIndex = 362
        Me.LblNumLk.Text = "NumLock: "
        '
        'LblSwitchPos
        '
        Me.LblSwitchPos.Location = New System.Drawing.Point(10, 205)
        Me.LblSwitchPos.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LblSwitchPos.Name = "LblSwitchPos"
        Me.LblSwitchPos.Size = New System.Drawing.Size(104, 14)
        Me.LblSwitchPos.TabIndex = 371
        Me.LblSwitchPos.Text = "Switch Position"
        '
        'LblButtons
        '
        Me.LblButtons.AutoSize = True
        Me.LblButtons.Location = New System.Drawing.Point(11, 220)
        Me.LblButtons.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LblButtons.Name = "LblButtons"
        Me.LblButtons.Size = New System.Drawing.Size(46, 13)
        Me.LblButtons.TabIndex = 384
        Me.LblButtons.Text = "Buttons:"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(500, 334)
        Me.Label27.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(145, 13)
        Me.Label27.TabIndex = 646
        Me.Label27.Text = "Read X-keys RS232 Settings"
        '
        'btnReadRS232Settings
        '
        Me.btnReadRS232Settings.Location = New System.Drawing.Point(500, 349)
        Me.btnReadRS232Settings.Margin = New System.Windows.Forms.Padding(2)
        Me.btnReadRS232Settings.Name = "btnReadRS232Settings"
        Me.btnReadRS232Settings.Size = New System.Drawing.Size(121, 22)
        Me.btnReadRS232Settings.TabIndex = 645
        Me.btnReadRS232Settings.Text = "Read RS232 Settings"
        Me.btnReadRS232Settings.UseVisualStyleBackColor = True
        '
        'label51
        '
        Me.label51.AutoSize = True
        Me.label51.Location = New System.Drawing.Point(499, 462)
        Me.label51.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.label51.Name = "label51"
        Me.label51.Size = New System.Drawing.Size(156, 13)
        Me.label51.TabIndex = 644
        Me.label51.Text = "Transmit from X-keys Serial Port"
        '
        'btnWriteXkeysTx
        '
        Me.btnWriteXkeysTx.Location = New System.Drawing.Point(728, 484)
        Me.btnWriteXkeysTx.Name = "btnWriteXkeysTx"
        Me.btnWriteXkeysTx.Size = New System.Drawing.Size(118, 22)
        Me.btnWriteXkeysTx.TabIndex = 643
        Me.btnWriteXkeysTx.Text = "Write to X-keys TX"
        Me.btnWriteXkeysTx.UseVisualStyleBackColor = True
        '
        'txtSendText
        '
        Me.txtSendText.Location = New System.Drawing.Point(500, 484)
        Me.txtSendText.Name = "txtSendText"
        Me.txtSendText.Size = New System.Drawing.Size(222, 20)
        Me.txtSendText.TabIndex = 642
        Me.txtSendText.Text = "abc"
        '
        'lblUSBCheckState
        '
        Me.lblUSBCheckState.AutoSize = True
        Me.lblUSBCheckState.Location = New System.Drawing.Point(731, 295)
        Me.lblUSBCheckState.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblUSBCheckState.Name = "lblUSBCheckState"
        Me.lblUSBCheckState.Size = New System.Drawing.Size(119, 13)
        Me.lblUSBCheckState.TabIndex = 641
        Me.lblUSBCheckState.Text = "usb check disable state"
        '
        'btnUSBCheckOff
        '
        Me.btnUSBCheckOff.Location = New System.Drawing.Point(610, 290)
        Me.btnUSBCheckOff.Name = "btnUSBCheckOff"
        Me.btnUSBCheckOff.Size = New System.Drawing.Size(104, 23)
        Me.btnUSBCheckOff.TabIndex = 640
        Me.btnUSBCheckOff.Text = "Check Disabled"
        Me.btnUSBCheckOff.UseVisualStyleBackColor = True
        '
        'btnUSBCheckOn
        '
        Me.btnUSBCheckOn.Location = New System.Drawing.Point(500, 290)
        Me.btnUSBCheckOn.Name = "btnUSBCheckOn"
        Me.btnUSBCheckOn.Size = New System.Drawing.Size(103, 23)
        Me.btnUSBCheckOn.TabIndex = 638
        Me.btnUSBCheckOn.Text = "Check Enabled"
        Me.btnUSBCheckOn.UseVisualStyleBackColor = True
        '
        'lblReawakeState
        '
        Me.lblReawakeState.AutoSize = True
        Me.lblReawakeState.Location = New System.Drawing.Point(726, 234)
        Me.lblReawakeState.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblReawakeState.Name = "lblReawakeState"
        Me.lblReawakeState.Size = New System.Drawing.Size(94, 13)
        Me.lblReawakeState.TabIndex = 637
        Me.lblReawakeState.Text = "sleep disable state"
        '
        'btnSleepEnabled
        '
        Me.btnSleepEnabled.Location = New System.Drawing.Point(500, 229)
        Me.btnSleepEnabled.Name = "btnSleepEnabled"
        Me.btnSleepEnabled.Size = New System.Drawing.Size(104, 23)
        Me.btnSleepEnabled.TabIndex = 636
        Me.btnSleepEnabled.Text = "Sleep Enabled"
        Me.btnSleepEnabled.UseVisualStyleBackColor = True
        '
        'btnSleepDisabled
        '
        Me.btnSleepDisabled.Location = New System.Drawing.Point(610, 229)
        Me.btnSleepDisabled.Name = "btnSleepDisabled"
        Me.btnSleepDisabled.Size = New System.Drawing.Size(103, 23)
        Me.btnSleepDisabled.TabIndex = 634
        Me.btnSleepDisabled.Text = "Sleep Disabled"
        Me.btnSleepDisabled.UseVisualStyleBackColor = True
        '
        'lblJsonState
        '
        Me.lblJsonState.AutoSize = True
        Me.lblJsonState.Location = New System.Drawing.Point(726, 167)
        Me.lblJsonState.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblJsonState.Name = "lblJsonState"
        Me.lblJsonState.Size = New System.Drawing.Size(30, 13)
        Me.lblJsonState.TabIndex = 633
        Me.lblJsonState.Text = "state"
        '
        'btnJsonOff
        '
        Me.btnJsonOff.Location = New System.Drawing.Point(610, 162)
        Me.btnJsonOff.Name = "btnJsonOff"
        Me.btnJsonOff.Size = New System.Drawing.Size(103, 23)
        Me.btnJsonOff.TabIndex = 632
        Me.btnJsonOff.Text = "Input Reports Off"
        Me.btnJsonOff.UseVisualStyleBackColor = True
        '
        'btnJsonOn
        '
        Me.btnJsonOn.Location = New System.Drawing.Point(500, 162)
        Me.btnJsonOn.Name = "btnJsonOn"
        Me.btnJsonOn.Size = New System.Drawing.Size(104, 23)
        Me.btnJsonOn.TabIndex = 630
        Me.btnJsonOn.Text = "Input Reports On"
        Me.btnJsonOn.UseVisualStyleBackColor = True
        '
        'lblEchoState
        '
        Me.lblEchoState.AutoSize = True
        Me.lblEchoState.Location = New System.Drawing.Point(725, 83)
        Me.lblEchoState.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblEchoState.Name = "lblEchoState"
        Me.lblEchoState.Size = New System.Drawing.Size(57, 13)
        Me.lblEchoState.TabIndex = 629
        Me.lblEchoState.Text = "echo state"
        '
        'btnEchoOff
        '
        Me.btnEchoOff.Location = New System.Drawing.Point(610, 78)
        Me.btnEchoOff.Name = "btnEchoOff"
        Me.btnEchoOff.Size = New System.Drawing.Size(103, 23)
        Me.btnEchoOff.TabIndex = 628
        Me.btnEchoOff.Text = "Echo Off"
        Me.btnEchoOff.UseVisualStyleBackColor = True
        '
        'btnEchoOn
        '
        Me.btnEchoOn.Location = New System.Drawing.Point(500, 78)
        Me.btnEchoOn.Name = "btnEchoOn"
        Me.btnEchoOn.Size = New System.Drawing.Size(104, 23)
        Me.btnEchoOn.TabIndex = 626
        Me.btnEchoOn.Text = "Echo On"
        Me.btnEchoOn.UseVisualStyleBackColor = True
        '
        'label36
        '
        Me.label36.AutoSize = True
        Me.label36.Location = New System.Drawing.Point(490, 14)
        Me.label36.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.label36.Name = "label36"
        Me.label36.Size = New System.Drawing.Size(113, 13)
        Me.label36.TabIndex = 625
        Me.label36.Text = "X-keys UART Settings"
        '
        'label56
        '
        Me.label56.AutoSize = True
        Me.label56.Location = New System.Drawing.Point(746, 409)
        Me.label56.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.label56.Name = "label56"
        Me.label56.Size = New System.Drawing.Size(49, 13)
        Me.label56.TabIndex = 656
        Me.label56.Text = "Stop Bits"
        '
        'cboStopBits
        '
        Me.cboStopBits.FormattingEnabled = True
        Me.cboStopBits.Items.AddRange(New Object() {"1", "1.5", "2"})
        Me.cboStopBits.Location = New System.Drawing.Point(746, 425)
        Me.cboStopBits.Name = "cboStopBits"
        Me.cboStopBits.Size = New System.Drawing.Size(74, 21)
        Me.cboStopBits.TabIndex = 655
        '
        'label54
        '
        Me.label54.AutoSize = True
        Me.label54.Location = New System.Drawing.Point(667, 409)
        Me.label54.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.label54.Name = "label54"
        Me.label54.Size = New System.Drawing.Size(50, 13)
        Me.label54.TabIndex = 654
        Me.label54.Text = "Data Bits"
        '
        'label53
        '
        Me.label53.AutoSize = True
        Me.label53.Location = New System.Drawing.Point(588, 409)
        Me.label53.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.label53.Name = "label53"
        Me.label53.Size = New System.Drawing.Size(33, 13)
        Me.label53.TabIndex = 653
        Me.label53.Text = "Parity"
        '
        'label52
        '
        Me.label52.AutoSize = True
        Me.label52.Location = New System.Drawing.Point(498, 409)
        Me.label52.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.label52.Name = "label52"
        Me.label52.Size = New System.Drawing.Size(58, 13)
        Me.label52.TabIndex = 652
        Me.label52.Text = "Baud Rate"
        '
        'cboDataBits
        '
        Me.cboDataBits.FormattingEnabled = True
        Me.cboDataBits.Items.AddRange(New Object() {"5", "6", "7", "8"})
        Me.cboDataBits.Location = New System.Drawing.Point(667, 425)
        Me.cboDataBits.Name = "cboDataBits"
        Me.cboDataBits.Size = New System.Drawing.Size(74, 21)
        Me.cboDataBits.TabIndex = 651
        '
        'cboParity
        '
        Me.cboParity.FormattingEnabled = True
        Me.cboParity.Items.AddRange(New Object() {"even", "odd", "none"})
        Me.cboParity.Location = New System.Drawing.Point(588, 425)
        Me.cboParity.Name = "cboParity"
        Me.cboParity.Size = New System.Drawing.Size(74, 21)
        Me.cboParity.TabIndex = 650
        '
        'btnRS232Settings
        '
        Me.btnRS232Settings.Location = New System.Drawing.Point(826, 424)
        Me.btnRS232Settings.Name = "btnRS232Settings"
        Me.btnRS232Settings.Size = New System.Drawing.Size(134, 22)
        Me.btnRS232Settings.TabIndex = 649
        Me.btnRS232Settings.Text = "Change RS232 Settings"
        Me.btnRS232Settings.UseVisualStyleBackColor = True
        '
        'label48
        '
        Me.label48.AutoSize = True
        Me.label48.Location = New System.Drawing.Point(500, 390)
        Me.label48.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.label48.Name = "label48"
        Me.label48.Size = New System.Drawing.Size(156, 13)
        Me.label48.TabIndex = 648
        Me.label48.Text = "Change X-keys RS232 Settings"
        '
        'cboBaudRate
        '
        Me.cboBaudRate.FormattingEnabled = True
        Me.cboBaudRate.Items.AddRange(New Object() {"300", "1200", "2400", "4800", "9600", "19200", "38400", "57600", "115200", "230400"})
        Me.cboBaudRate.Location = New System.Drawing.Point(500, 425)
        Me.cboBaudRate.Name = "cboBaudRate"
        Me.cboBaudRate.Size = New System.Drawing.Size(83, 21)
        Me.cboBaudRate.TabIndex = 647
        '
        'serialPort1
        '
        Me.serialPort1.BaudRate = 230400
        Me.serialPort1.PortName = "COM10"
        '
        'BtnBLToggle
        '
        Me.BtnBLToggle.Location = New System.Drawing.Point(17, 415)
        Me.BtnBLToggle.Margin = New System.Windows.Forms.Padding(2)
        Me.BtnBLToggle.Name = "BtnBLToggle"
        Me.BtnBLToggle.Size = New System.Drawing.Size(104, 22)
        Me.BtnBLToggle.TabIndex = 323
        Me.BtnBLToggle.Text = "Toggle"
        Me.BtnBLToggle.UseVisualStyleBackColor = True
        '
        'label43
        '
        Me.label43.AutoSize = True
        Me.label43.Location = New System.Drawing.Point(6, 391)
        Me.label43.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.label43.Name = "label43"
        Me.label43.Size = New System.Drawing.Size(92, 13)
        Me.label43.TabIndex = 326
        Me.label43.Text = "Toggle Backlights"
        '
        'label63
        '
        Me.label63.AutoSize = True
        Me.label63.Location = New System.Drawing.Point(1319, 146)
        Me.label63.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.label63.Name = "label63"
        Me.label63.Size = New System.Drawing.Size(49, 13)
        Me.label63.TabIndex = 681
        Me.label63.Text = "Stop Bits"
        '
        'cboCOMStop
        '
        Me.cboCOMStop.FormattingEnabled = True
        Me.cboCOMStop.Items.AddRange(New Object() {"1", "1.5", "2"})
        Me.cboCOMStop.Location = New System.Drawing.Point(1319, 162)
        Me.cboCOMStop.Name = "cboCOMStop"
        Me.cboCOMStop.Size = New System.Drawing.Size(74, 21)
        Me.cboCOMStop.TabIndex = 680
        '
        'label65
        '
        Me.label65.AutoSize = True
        Me.label65.Location = New System.Drawing.Point(1239, 146)
        Me.label65.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.label65.Name = "label65"
        Me.label65.Size = New System.Drawing.Size(50, 13)
        Me.label65.TabIndex = 679
        Me.label65.Text = "Data Bits"
        '
        'label67
        '
        Me.label67.AutoSize = True
        Me.label67.Location = New System.Drawing.Point(1159, 146)
        Me.label67.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.label67.Name = "label67"
        Me.label67.Size = New System.Drawing.Size(33, 13)
        Me.label67.TabIndex = 678
        Me.label67.Text = "Parity"
        '
        'label68
        '
        Me.label68.AutoSize = True
        Me.label68.Location = New System.Drawing.Point(1071, 146)
        Me.label68.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.label68.Name = "label68"
        Me.label68.Size = New System.Drawing.Size(58, 13)
        Me.label68.TabIndex = 677
        Me.label68.Text = "Baud Rate"
        '
        'cboCOMData
        '
        Me.cboCOMData.FormattingEnabled = True
        Me.cboCOMData.Items.AddRange(New Object() {"5", "6", "7", "8"})
        Me.cboCOMData.Location = New System.Drawing.Point(1239, 162)
        Me.cboCOMData.Name = "cboCOMData"
        Me.cboCOMData.Size = New System.Drawing.Size(74, 21)
        Me.cboCOMData.TabIndex = 676
        '
        'cboCOMParity
        '
        Me.cboCOMParity.FormattingEnabled = True
        Me.cboCOMParity.Items.AddRange(New Object() {"even", "odd", "none"})
        Me.cboCOMParity.Location = New System.Drawing.Point(1159, 162)
        Me.cboCOMParity.Name = "cboCOMParity"
        Me.cboCOMParity.Size = New System.Drawing.Size(74, 21)
        Me.cboCOMParity.TabIndex = 675
        '
        'label57
        '
        Me.label57.AutoSize = True
        Me.label57.Location = New System.Drawing.Point(1069, 127)
        Me.label57.Name = "label57"
        Me.label57.Size = New System.Drawing.Size(184, 13)
        Me.label57.TabIndex = 674
        Me.label57.Text = "Match Settings to those of the X-keys"
        '
        'cboCOMBaud
        '
        Me.cboCOMBaud.FormattingEnabled = True
        Me.cboCOMBaud.Items.AddRange(New Object() {"300", "1200", "2400", "4800", "9600", "19200", "38400", "57600", "115200", "230400"})
        Me.cboCOMBaud.Location = New System.Drawing.Point(1070, 162)
        Me.cboCOMBaud.Name = "cboCOMBaud"
        Me.cboCOMBaud.Size = New System.Drawing.Size(83, 21)
        Me.cboCOMBaud.TabIndex = 673
        '
        'label50
        '
        Me.label50.AutoSize = True
        Me.label50.Location = New System.Drawing.Point(1066, 381)
        Me.label50.Name = "label50"
        Me.label50.Size = New System.Drawing.Size(427, 13)
        Me.label50.TabIndex = 672
        Me.label50.Text = "Write a message to be received by X-keys as a UART Output Report Received Message" & _
            ""
        '
        'txtSendCOMUSB
        '
        Me.txtSendCOMUSB.Location = New System.Drawing.Point(1069, 339)
        Me.txtSendCOMUSB.Name = "txtSendCOMUSB"
        Me.txtSendCOMUSB.Size = New System.Drawing.Size(222, 20)
        Me.txtSendCOMUSB.TabIndex = 671
        Me.txtSendCOMUSB.Text = "def"
        '
        'btnCOMPortUSB
        '
        Me.btnCOMPortUSB.Location = New System.Drawing.Point(1294, 337)
        Me.btnCOMPortUSB.Name = "btnCOMPortUSB"
        Me.btnCOMPortUSB.Size = New System.Drawing.Size(75, 23)
        Me.btnCOMPortUSB.TabIndex = 669
        Me.btnCOMPortUSB.Text = "Write"
        Me.btnCOMPortUSB.UseVisualStyleBackColor = True
        '
        'label45
        '
        Me.label45.AutoSize = True
        Me.label45.Location = New System.Drawing.Point(1066, 323)
        Me.label45.Name = "label45"
        Me.label45.Size = New System.Drawing.Size(395, 13)
        Me.label45.TabIndex = 668
        Me.label45.Text = "Write a message to be received by X-keys as a UART Custom Received Message"
        '
        'label35
        '
        Me.label35.AutoSize = True
        Me.label35.Location = New System.Drawing.Point(1066, 205)
        Me.label35.Name = "label35"
        Me.label35.Size = New System.Drawing.Size(84, 13)
        Me.label35.TabIndex = 667
        Me.label35.Text = "Read UART RX"
        '
        'label31
        '
        Me.label31.AutoSize = True
        Me.label31.Location = New System.Drawing.Point(1067, 78)
        Me.label31.Name = "label31"
        Me.label31.Size = New System.Drawing.Size(86, 13)
        Me.label31.TabIndex = 666
        Me.label31.Text = "Select COM Port"
        '
        'CboPorts
        '
        Me.CboPorts.FormattingEnabled = True
        Me.CboPorts.Location = New System.Drawing.Point(1070, 94)
        Me.CboPorts.Name = "CboPorts"
        Me.CboPorts.Size = New System.Drawing.Size(83, 21)
        Me.CboPorts.TabIndex = 665
        '
        'listBox5
        '
        Me.listBox5.FormattingEnabled = True
        Me.listBox5.HorizontalScrollbar = True
        Me.listBox5.Location = New System.Drawing.Point(1069, 234)
        Me.listBox5.Name = "listBox5"
        Me.listBox5.Size = New System.Drawing.Size(349, 69)
        Me.listBox5.TabIndex = 664
        '
        'button3
        '
        Me.button3.Location = New System.Drawing.Point(1343, 208)
        Me.button3.Name = "button3"
        Me.button3.Size = New System.Drawing.Size(75, 23)
        Me.button3.TabIndex = 663
        Me.button3.Text = "Clear"
        Me.button3.UseVisualStyleBackColor = True
        '
        'Label44
        '
        Me.Label44.AutoSize = True
        Me.Label44.Location = New System.Drawing.Point(1066, 218)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(108, 13)
        Me.Label44.TabIndex = 662
        Me.Label44.Text = "Incoming Serial Data:"
        '
        'txtBase64Encode
        '
        Me.txtBase64Encode.Location = New System.Drawing.Point(1069, 408)
        Me.txtBase64Encode.Name = "txtBase64Encode"
        Me.txtBase64Encode.Size = New System.Drawing.Size(222, 20)
        Me.txtBase64Encode.TabIndex = 658
        Me.txtBase64Encode.Text = "B8, 00, 00"
        '
        'btnCOMPortInternal
        '
        Me.btnCOMPortInternal.Location = New System.Drawing.Point(1297, 406)
        Me.btnCOMPortInternal.Name = "btnCOMPortInternal"
        Me.btnCOMPortInternal.Size = New System.Drawing.Size(75, 23)
        Me.btnCOMPortInternal.TabIndex = 659
        Me.btnCOMPortInternal.Text = "Write"
        Me.btnCOMPortInternal.UseVisualStyleBackColor = True
        '
        'lblEncoded
        '
        Me.lblEncoded.AutoSize = True
        Me.lblEncoded.Location = New System.Drawing.Point(1066, 432)
        Me.lblEncoded.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblEncoded.Name = "lblEncoded"
        Me.lblEncoded.Size = New System.Drawing.Size(77, 13)
        Me.lblEncoded.TabIndex = 661
        Me.lblEncoded.Text = "encoded bytes"
        '
        'label49
        '
        Me.label49.AutoSize = True
        Me.label49.Location = New System.Drawing.Point(1066, 394)
        Me.label49.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.label49.Name = "label49"
        Me.label49.Size = New System.Drawing.Size(202, 13)
        Me.label49.TabIndex = 660
        Me.label49.Text = "Bytes in comma separated hex to encode"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(1044, 14)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(118, 13)
        Me.Label4.TabIndex = 682
        Me.Label4.Text = "USB COM Port Adapter"
        '
        'label46
        '
        Me.label46.Location = New System.Drawing.Point(1063, 46)
        Me.label46.Name = "label46"
        Me.label46.Size = New System.Drawing.Size(361, 28)
        Me.label46.TabIndex = 683
        Me.label46.Text = "The following is for directly communicating with the serial port via a  serial to" & _
            " USB converter*"
        '
        'label55
        '
        Me.label55.Location = New System.Drawing.Point(500, 35)
        Me.label55.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.label55.Name = "label55"
        Me.label55.Size = New System.Drawing.Size(455, 40)
        Me.label55.TabIndex = 684
        Me.label55.Text = resources.GetString("label55.Text")
        '
        'label58
        '
        Me.label58.Location = New System.Drawing.Point(500, 119)
        Me.label58.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.label58.Name = "label58"
        Me.label58.Size = New System.Drawing.Size(453, 40)
        Me.label58.TabIndex = 685
        Me.label58.Text = "UART PI Base64 Input Report Transmit Messages - If on then any standard input rep" & _
            "ort will be accompanied by a corresponding UART PI Base64 Input Report Transmit " & _
            "Message sent out on the X-keys TX"
        '
        'label64
        '
        Me.label64.Location = New System.Drawing.Point(500, 200)
        Me.label64.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.label64.Name = "label64"
        Me.label64.Size = New System.Drawing.Size(454, 26)
        Me.label64.TabIndex = 686
        Me.label64.Text = "USB Sleep - If sleep enabled  the X-keys will turn off its LEDs and any GPIO outp" & _
            "ut pins when a USB suspend condition occurs. To override this behavior set sleep" & _
            " disable"
        '
        'label66
        '
        Me.label66.AutoSize = True
        Me.label66.Location = New System.Drawing.Point(500, 269)
        Me.label66.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.label66.Name = "label66"
        Me.label66.Size = New System.Drawing.Size(359, 13)
        Me.label66.TabIndex = 687
        Me.label66.Text = "USB Check - set check disable if using the USB connection for power only"
        '
        'label6
        '
        Me.label6.Location = New System.Drawing.Point(1066, 474)
        Me.label6.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.label6.Name = "label6"
        Me.label6.Size = New System.Drawing.Size(349, 223)
        Me.label6.TabIndex = 688
        Me.label6.Text = resources.GetString("label6.Text")
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(1535, 711)
        Me.Controls.Add(Me.label6)
        Me.Controls.Add(Me.label66)
        Me.Controls.Add(Me.label64)
        Me.Controls.Add(Me.label58)
        Me.Controls.Add(Me.label55)
        Me.Controls.Add(Me.label46)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.label63)
        Me.Controls.Add(Me.cboCOMStop)
        Me.Controls.Add(Me.label65)
        Me.Controls.Add(Me.label67)
        Me.Controls.Add(Me.label68)
        Me.Controls.Add(Me.cboCOMData)
        Me.Controls.Add(Me.cboCOMParity)
        Me.Controls.Add(Me.label57)
        Me.Controls.Add(Me.cboCOMBaud)
        Me.Controls.Add(Me.label50)
        Me.Controls.Add(Me.txtSendCOMUSB)
        Me.Controls.Add(Me.btnCOMPortUSB)
        Me.Controls.Add(Me.label45)
        Me.Controls.Add(Me.label35)
        Me.Controls.Add(Me.label31)
        Me.Controls.Add(Me.CboPorts)
        Me.Controls.Add(Me.listBox5)
        Me.Controls.Add(Me.button3)
        Me.Controls.Add(Me.Label44)
        Me.Controls.Add(Me.txtBase64Encode)
        Me.Controls.Add(Me.btnCOMPortInternal)
        Me.Controls.Add(Me.lblEncoded)
        Me.Controls.Add(Me.label49)
        Me.Controls.Add(Me.label56)
        Me.Controls.Add(Me.cboStopBits)
        Me.Controls.Add(Me.label54)
        Me.Controls.Add(Me.label53)
        Me.Controls.Add(Me.label52)
        Me.Controls.Add(Me.cboDataBits)
        Me.Controls.Add(Me.cboParity)
        Me.Controls.Add(Me.btnRS232Settings)
        Me.Controls.Add(Me.label48)
        Me.Controls.Add(Me.cboBaudRate)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.btnReadRS232Settings)
        Me.Controls.Add(Me.label51)
        Me.Controls.Add(Me.btnWriteXkeysTx)
        Me.Controls.Add(Me.txtSendText)
        Me.Controls.Add(Me.lblUSBCheckState)
        Me.Controls.Add(Me.btnUSBCheckOff)
        Me.Controls.Add(Me.btnUSBCheckOn)
        Me.Controls.Add(Me.lblReawakeState)
        Me.Controls.Add(Me.btnSleepEnabled)
        Me.Controls.Add(Me.btnSleepDisabled)
        Me.Controls.Add(Me.lblJsonState)
        Me.Controls.Add(Me.btnJsonOff)
        Me.Controls.Add(Me.btnJsonOn)
        Me.Controls.Add(Me.lblEchoState)
        Me.Controls.Add(Me.btnEchoOff)
        Me.Controls.Add(Me.btnEchoOn)
        Me.Controls.Add(Me.label36)
        Me.Controls.Add(Me.LblButtons)
        Me.Controls.Add(Me.LblSwitchPos)
        Me.Controls.Add(Me.LblScrLk)
        Me.Controls.Add(Me.LblCapsLk)
        Me.Controls.Add(Me.LblNumLk)
        Me.Controls.Add(Me.label43)
        Me.Controls.Add(Me.BtnBLToggle)
        Me.Controls.Add(Me.ChkSuppress)
        Me.Controls.Add(Me.ChkRed)
        Me.Controls.Add(Me.ChkGreen)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.listBox2)
        Me.Controls.Add(Me.BtnDescriptor)
        Me.Controls.Add(Me.label21)
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
        Me.Text = "VB X-keys RS232 Common Sample"
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
    Private WithEvents listBox2 As System.Windows.Forms.ListBox
    Private WithEvents BtnDescriptor As System.Windows.Forms.Button
    Private WithEvents label21 As System.Windows.Forms.Label
    Private WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents ChkGreen As System.Windows.Forms.CheckBox
    Friend WithEvents ChkRed As System.Windows.Forms.CheckBox
    Friend WithEvents ChkSuppress As System.Windows.Forms.CheckBox
    Private WithEvents LblScrLk As System.Windows.Forms.Label
    Private WithEvents LblCapsLk As System.Windows.Forms.Label
    Private WithEvents LblNumLk As System.Windows.Forms.Label
    Private WithEvents LblSwitchPos As System.Windows.Forms.Label
    Private WithEvents LblButtons As System.Windows.Forms.Label
    Private WithEvents Label27 As System.Windows.Forms.Label
    Private WithEvents btnReadRS232Settings As System.Windows.Forms.Button
    Private WithEvents label51 As System.Windows.Forms.Label
    Private WithEvents btnWriteXkeysTx As System.Windows.Forms.Button
    Private WithEvents txtSendText As System.Windows.Forms.TextBox
    Private WithEvents lblUSBCheckState As System.Windows.Forms.Label
    Private WithEvents btnUSBCheckOff As System.Windows.Forms.Button
    Private WithEvents btnUSBCheckOn As System.Windows.Forms.Button
    Private WithEvents lblReawakeState As System.Windows.Forms.Label
    Private WithEvents btnSleepEnabled As System.Windows.Forms.Button
    Private WithEvents btnSleepDisabled As System.Windows.Forms.Button
    Private WithEvents lblJsonState As System.Windows.Forms.Label
    Private WithEvents btnJsonOff As System.Windows.Forms.Button
    Private WithEvents btnJsonOn As System.Windows.Forms.Button
    Private WithEvents lblEchoState As System.Windows.Forms.Label
    Private WithEvents btnEchoOff As System.Windows.Forms.Button
    Private WithEvents btnEchoOn As System.Windows.Forms.Button
    Private WithEvents label36 As System.Windows.Forms.Label
    Private WithEvents label56 As System.Windows.Forms.Label
    Private WithEvents cboStopBits As System.Windows.Forms.ComboBox
    Private WithEvents label54 As System.Windows.Forms.Label
    Private WithEvents label53 As System.Windows.Forms.Label
    Private WithEvents label52 As System.Windows.Forms.Label
    Private WithEvents cboDataBits As System.Windows.Forms.ComboBox
    Private WithEvents cboParity As System.Windows.Forms.ComboBox
    Private WithEvents btnRS232Settings As System.Windows.Forms.Button
    Private WithEvents label48 As System.Windows.Forms.Label
    Private WithEvents cboBaudRate As System.Windows.Forms.ComboBox
    Private WithEvents serialPort1 As System.IO.Ports.SerialPort
    Private WithEvents BtnBLToggle As System.Windows.Forms.Button
    Private WithEvents label43 As System.Windows.Forms.Label
    Private WithEvents label63 As System.Windows.Forms.Label
    Private WithEvents cboCOMStop As System.Windows.Forms.ComboBox
    Private WithEvents label65 As System.Windows.Forms.Label
    Private WithEvents label67 As System.Windows.Forms.Label
    Private WithEvents label68 As System.Windows.Forms.Label
    Private WithEvents cboCOMData As System.Windows.Forms.ComboBox
    Private WithEvents cboCOMParity As System.Windows.Forms.ComboBox
    Private WithEvents label57 As System.Windows.Forms.Label
    Private WithEvents cboCOMBaud As System.Windows.Forms.ComboBox
    Private WithEvents label50 As System.Windows.Forms.Label
    Private WithEvents txtSendCOMUSB As System.Windows.Forms.TextBox
    Private WithEvents btnCOMPortUSB As System.Windows.Forms.Button
    Private WithEvents label45 As System.Windows.Forms.Label
    Private WithEvents label35 As System.Windows.Forms.Label
    Private WithEvents label31 As System.Windows.Forms.Label
    Private WithEvents CboPorts As System.Windows.Forms.ComboBox
    Private WithEvents listBox5 As System.Windows.Forms.ListBox
    Private WithEvents button3 As System.Windows.Forms.Button
    Private WithEvents Label44 As System.Windows.Forms.Label
    Private WithEvents txtBase64Encode As System.Windows.Forms.TextBox
    Private WithEvents btnCOMPortInternal As System.Windows.Forms.Button
    Public WithEvents lblEncoded As System.Windows.Forms.Label
    Private WithEvents label49 As System.Windows.Forms.Label
    Private WithEvents Label4 As System.Windows.Forms.Label
    Private WithEvents label46 As System.Windows.Forms.Label
    Private WithEvents label55 As System.Windows.Forms.Label
    Private WithEvents label58 As System.Windows.Forms.Label
    Private WithEvents label64 As System.Windows.Forms.Label
    Private WithEvents label66 As System.Windows.Forms.Label
    Public WithEvents label6 As System.Windows.Forms.Label

End Class
