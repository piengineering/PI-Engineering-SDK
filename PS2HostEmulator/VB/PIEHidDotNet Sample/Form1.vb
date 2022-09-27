Public Class Form1
    Implements PIEHid32Net.PIEDataHandler
    Implements PIEHid32Net.PIEErrorHandler
    Dim devices() As PIEHid32Net.PIEDevice
    Dim selecteddevice As Integer
    Dim cbotodevice(127) As Integer 'max # of devices = 128 
    Dim wdata() As Byte = New Byte() {} 'write data buffer
    ' This delegate enables asynchronous calls for setting
    ' the text property on a TextBox control.
    Delegate Sub SetTextCallback(ByVal [text] As String)
    Delegate Sub SetIntCallback(ByVal [text] As Integer)
    Dim c As Control
    Dim mouseport As Integer
    Dim hidtochar(255) As String

    Public Sub HandlePIEHidData(ByVal data() As Byte, ByVal sourceDevice As PIEHid32Net.PIEDevice, ByVal perror As Integer) Implements PIEHid32Net.PIEDataHandler.HandlePIEHidData
        'data callback

        If sourceDevice.Pid = devices(selecteddevice).Pid Then
           
                Dim output As String
                output = "Callback: " + sourceDevice.Pid.ToString + ", ID: " + selecteddevice.ToString + ", data="
                For i As Integer = 0 To 5
                output = output + data(i).ToString + " "
                Next

                'Use thread-safe calls to windows forms controls
                SetListBox(output)

                'mouse data
                Dim mousedata As String
            If (data(1) = 4 Or data(1) = 8) Then
                If (data(1) = 4) Then mouseport = 0 'mouse on Device 2
                If (data(1) = 8) Then mouseport = 1 'mouse on Device 1
                mousedata = "X: " + data(3).ToString() + "  Y: " + data(4).ToString() + "  "
                If (data(2) And 1) Then
                    mousedata = mousedata + "Left Click  "
                End If
                If (data(2) And 2) Then
                    mousedata = mousedata + "Right Click  "
                End If
                If (data(2) And 4) Then
                    mousedata = mousedata + "Center Click  "
                End If

                c = LblMouse
                SetText(mousedata)
                If (data(5) = 1) Then
                    SetScrollBar(-10)
                ElseIf (data(5) = 255) Then
                    SetScrollBar(10)
                End If
            End If
                'keyboard data
                Dim keysdown As String = ""
            If (data(1) = 1 Or data(1) = 5) Then
                For i As Integer = 2 To 5
                    keysdown = keysdown + hidtochar(data(i)) + "  "
                Next
                c = LblKeys
                SetText(keysdown)

            End If
           
        End If
    End Sub
    Public Sub HandlePIEHidError(ByVal sourceDevice As PIEHid32Net.PIEDevice, ByVal perror As Integer) Implements PIEHid32Net.PIEErrorHandler.HandlePIEHidError
        'error callback
        Dim output As String
        output = "Error: " + perror.ToString
        c = LblStatus
        SetText(output)
        Beep()
    End Sub
    Public Sub SetListBox(ByVal [text] As String)

        ' InvokeRequired required compares the thread ID of the
        ' calling thread to the thread ID of the creating thread.
        ' If these threads are different, it returns true.
        If Me.ListBox1.InvokeRequired Then
            Dim d As New SetTextCallback(AddressOf SetListBox)
            Me.Invoke(d, New Object() {[text]})
        Else
            Me.ListBox1.Items.Add(text)
            Me.ListBox1.SelectedIndex = Me.ListBox1.Items.Count - 1
        End If
    End Sub
    Public Sub SetText(ByVal [text] As String)

        ' InvokeRequired required compares the thread ID of the
        ' calling thread to the thread ID of the creating thread.
        ' If these threads are different, it returns true.
        If Me.c.InvokeRequired Then
            Dim d As New SetTextCallback(AddressOf SetText)
            Me.Invoke(d, New Object() {[text]})
        Else
            Me.c.Text = text
        End If
    End Sub
    Public Sub SetScrollBar(ByVal [text] As Integer)

        ' InvokeRequired required compares the thread ID of the
        ' calling thread to the thread ID of the creating thread.
        ' If these threads are different, it returns true.
        If Me.VScrollBar1.InvokeRequired Then
            Dim d As New SetIntCallback(AddressOf SetScrollBar)
            Me.Invoke(d, New Object() {[text]})
        Else
            Me.VScrollBar1.Value = Me.VScrollBar1.Value + text
        End If
    End Sub
    Private Sub BtnEnumerate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEnumerate.Click
        'do this first to get the devices connected
        CboDevices.Items.Clear()
        selecteddevice = -1 'means no device is selected
        devices = PIEHid32Net.PIEDevice.EnumeratePIE()
        If devices.Length = 0 Then
            LblStatus.Text = "No Devices Found"
        Else
            Dim cbocount As Integer = 0
            For i As Integer = 0 To devices.Length - 1

                If devices(i).HidUsagePage = 12 Then

                    Select Case devices(i).Pid
                        Case 525
                            CboDevices.Items.Add("PS2 Host Emulator (" + devices(i).Pid.ToString + "): " + i.ToString)
                            cbotodevice(cbocount) = i
                            cbocount = cbocount + 1
                        Case 514
                            CboDevices.Items.Add("PS2 Host Emulator (" + devices(i).Pid.ToString + "): " + i.ToString)
                            cbotodevice(cbocount) = i
                            cbocount = cbocount + 1
                        Case 515
                            CboDevices.Items.Add("PS2 Host Emulator (" + devices(i).Pid.ToString + "): " + i.ToString)
                            cbotodevice(cbocount) = i
                            cbocount = cbocount + 1
                        Case Else
                            CboDevices.Items.Add("Unknown Device (" + devices(i).Pid.ToString + "): " + i.ToString)
                            cbotodevice(cbocount) = i
                            cbocount = cbocount + 1
                    End Select
                    Dim result As Integer = devices(i).SetupInterface()
                    If result <> 0 Then
                        LblStatus.Text = "Failed SetupInterface on device: " + i.ToString
                    Else
                        LblStatus.Text = "Success SetupInterface"
                    End If
                End If

            Next
        End If

        If CboDevices.Items.Count > 0 Then
            CboDevices.SelectedIndex = 0
            selecteddevice = cbotodevice(CboDevices.SelectedIndex)
            ReDim wdata(devices(selecteddevice).WriteLength - 1) 'initialize length of write buffer
        End If
    End Sub
    Private Sub Form1_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        'close devices
        For i As Integer = 0 To CboDevices.Items.Count - 1
            devices(cbotodevice(i)).CloseInterface()
        Next
        System.Environment.Exit(0)
    End Sub

    Private Sub BtnCallback_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCallback.Click
        'setup devices for data and error callbacks
        If CboDevices.SelectedIndex <> -1 Then
            For i As Integer = 0 To CboDevices.Items.Count - 1
                devices(cbotodevice(i)).SetDataCallback(Me)
                devices(cbotodevice(i)).SetErrorCallback(Me)
                devices(cbotodevice(i)).callNever = False
            Next
            selecteddevice = cbotodevice(CboDevices.SelectedIndex)
        End If
    End Sub


    Private Sub CboDevices_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboDevices.SelectedIndexChanged
        'update selecteddevice with that chosen and redim the write array
        selecteddevice = cbotodevice(CboDevices.SelectedIndex)
        ReDim wdata(devices(selecteddevice).WriteLength - 1) 'initialize length of write buffer
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ListBox1.Items.Clear()
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        selecteddevice = -1

        For i As Integer = 0 To 255
            hidtochar(i) = ""
        Next
        hidtochar(4) = "a"
        hidtochar(5) = "b"
        hidtochar(6) = "c"
        hidtochar(7) = "d"
        hidtochar(8) = "e"
        hidtochar(9) = "f"
        hidtochar(10) = "g"
        hidtochar(11) = "h"
        hidtochar(12) = "i"
        hidtochar(13) = "j"
        hidtochar(14) = "k"
        hidtochar(15) = "l"
        hidtochar(16) = "m"
        hidtochar(17) = "n"
        hidtochar(18) = "o"
        hidtochar(19) = "p"
        hidtochar(20) = "q"
        hidtochar(21) = "r"
        hidtochar(22) = "s"
        hidtochar(23) = "t"
        hidtochar(24) = "u"
        hidtochar(25) = "v"
        hidtochar(26) = "w"
        hidtochar(27) = "x"
        hidtochar(28) = "y"
        hidtochar(29) = "z"
        hidtochar(30) = "1"
        hidtochar(31) = "2"
        hidtochar(32) = "3"
        hidtochar(33) = "4"
        hidtochar(34) = "5"
        hidtochar(35) = "6"
        hidtochar(36) = "7"
        hidtochar(37) = "8"
        hidtochar(38) = "9"
        hidtochar(39) = "0"
        hidtochar(40) = "Return"
        hidtochar(41) = "Escape"
        hidtochar(42) = "Backspace"
        hidtochar(43) = "Tab"
        hidtochar(44) = "Space"
        hidtochar(45) = "-_"
        hidtochar(46) = "=+"
        hidtochar(47) = "[{"
        hidtochar(48) = "]}"
        hidtochar(49) = "'\'"
        hidtochar(50) = "Europe 1"
        hidtochar(51) = ":"
        hidtochar(52) = "'"
        hidtochar(53) = "`~"
        hidtochar(54) = ",<"
        hidtochar(55) = ".>"
        hidtochar(56) = "/?"
        hidtochar(57) = "Capslock"
        hidtochar(58) = "F1"
        hidtochar(59) = "F2"
        hidtochar(60) = "F3"
        hidtochar(61) = "F4"
        hidtochar(62) = "F5"
        hidtochar(63) = "F6"
        hidtochar(64) = "F7"
        hidtochar(65) = "F8"
        hidtochar(66) = "F9"
        hidtochar(67) = "F10"
        hidtochar(68) = "F11"
        hidtochar(69) = "F12"
        hidtochar(70) = "Print Screen"
        hidtochar(71) = "Scroll Lock"
        hidtochar(72) = "Break"
        hidtochar(73) = "Insert"
        hidtochar(74) = "Home"
        hidtochar(75) = "Page Up"
        hidtochar(76) = "Delete"
        hidtochar(77) = "End"
        hidtochar(78) = "Page Down"
        hidtochar(79) = "Right Arrow"
        hidtochar(80) = "Left Arrow"
        hidtochar(81) = "Down Arrow"
        hidtochar(82) = "Up Arrow"
        hidtochar(83) = "Num Lock"
        hidtochar(84) = "Keypad /"
        hidtochar(85) = "Keypad *"
        hidtochar(86) = "Keypad -"
        hidtochar(87) = "Keypad +"
        hidtochar(88) = "Keypad Enter"
        hidtochar(89) = "Keypad 1 End"
        hidtochar(90) = "Keypad 2 Down"
        hidtochar(91) = "Keypad 3 PageDn"
        hidtochar(92) = "Keypad 4 Left"
        hidtochar(93) = "Keypad 5"
        hidtochar(94) = "Keypad 6 Right"
        hidtochar(95) = "Keypad 7 Home"
        hidtochar(96) = "Keypad 8 Up"
        hidtochar(97) = "Keypad 9 PageUp"
        hidtochar(98) = "Keypad 0 Insert"
        hidtochar(99) = "Keypad . Delete"
        hidtochar(100) = "Europe 2"
        hidtochar(101) = "App"
        hidtochar(102) = "Pause/Break"  'unique to PS2 Host Emulator
        hidtochar(103) = "Keypad ="
        hidtochar(104) = "F13"
        hidtochar(105) = "F14"
        hidtochar(106) = "F15"
        hidtochar(107) = "F16"
        hidtochar(108) = "F17"
        hidtochar(109) = "F18"
        hidtochar(110) = "F19"
        hidtochar(111) = "F20"
        hidtochar(112) = "F21"
        hidtochar(113) = "F22"
        hidtochar(114) = "F23"
        hidtochar(115) = "F24"
        hidtochar(116) = "Keyboard Execute"
        hidtochar(117) = "Keyboard Help"
        hidtochar(118) = "Keyboard Menu"
        hidtochar(119) = "Keyboard Select"
        hidtochar(120) = "Keyboard Stop"
        hidtochar(121) = "Keyboard Again"
        hidtochar(122) = "Keyboard Undo"
        hidtochar(123) = "Keyboard Cut"
        hidtochar(124) = "Keyboard Copy"
        hidtochar(125) = "Keyboard Paste"
        hidtochar(126) = "Keyboard Find"
        hidtochar(127) = "Keyboard Mute"
        hidtochar(128) = "Keyboard Volume Up"
        hidtochar(129) = "Keyboard Volume Dn"
        hidtochar(130) = "Keyboard Locking Caps Lock"
        hidtochar(131) = "Keyboard Locking Num Lock"
        hidtochar(132) = "Keyboard Locking Scroll Lock"
        hidtochar(133) = "Keyboard ,"
        hidtochar(134) = "Keyboard Equal Sign"
        hidtochar(135) = "Keyboard Int'l 1"
        hidtochar(136) = "Keyboard Int'l 2"
        hidtochar(137) = "Keyboard Int'l 2 Yen"
        hidtochar(138) = "Keyboard Int'l 4"
        hidtochar(139) = "Keyboard Int'l 5"
        hidtochar(140) = "Keyboard Int'l 6"
        hidtochar(141) = "Keyboard Int'l 7"
        hidtochar(142) = "Keyboard Int'l 8"
        hidtochar(143) = "Keyboard Int'l 9"
        hidtochar(144) = "Keyboard Lang 1"
        hidtochar(145) = "Keyboard Lang 2"
        hidtochar(146) = "Keyboard Lang 3"
        hidtochar(147) = "Keyboard Lang 4"
        hidtochar(148) = "Keyboard Lang 5"
        hidtochar(149) = "Keyboard Lang 6"
        hidtochar(150) = "Keyboard Lang 7"
        hidtochar(151) = "Keyboard Lang 8"
        hidtochar(152) = "Keyboard Lang 9"
        'note modifier keys do not follow the HID code standard
        hidtochar(160) = "Left Control"
        hidtochar(161) = "Left Shift"
        hidtochar(162) = "Left Alt"
        hidtochar(163) = "Left GUI"
        hidtochar(164) = "Right Control"
        hidtochar(165) = "Right Shift"
        hidtochar(166) = "Right Alt"
        hidtochar(167) = "Right GUI"
    End Sub

    Private Sub BtnDefault_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDefault.Click
        'This code is for returning the mouse messages to the default setting.
        If selecteddevice <> -1 Then

            Dim portdes As String = "Device 2"
            If (mouseport = 1) Then
                portdes = "Device 1"
            End If
            Dim msg As String = "Is mouse plugged into " + portdes + "?  If so click Yes.  To change to the other port click No. To do nothing click Cancel."
            Dim dlgresult As DialogResult = MessageBox.Show(msg, "PS2 Host Emulator Demo", MessageBoxButtons.YesNoCancel)
            If (dlgresult = Windows.Forms.DialogResult.Cancel) Then
                Return
            ElseIf (dlgresult = Windows.Forms.DialogResult.No) Then
                mouseport = (mouseport) ^ 1
            End If

            For i As Integer = 0 To devices(selecteddevice).WriteLength - 1
                wdata(i) = 0
            Next
            wdata(1) = mouseport
            wdata(2) = &HF3

            Dim result As Integer
            result = 404
            While (result = 404)
                result = devices(selecteddevice).WriteData(wdata)
            End While

            If result <> 0 Then
                LblStatus.Text = "1st Write Fail: " + result.ToString
            Else
                LblStatus.Text = "Write Success"
            End If

            System.Threading.Thread.Sleep(50)
            wdata(1) = mouseport
            wdata(2) = &H3C

            result = 404
            While (result = 404)
                result = devices(selecteddevice).WriteData(wdata)
            End While

            If result <> 0 Then
                LblStatus.Text = "2nd Write Fail: " + result.ToString
            Else
                LblStatus.Text = "Write Success"
            End If
        End If
    End Sub

    Private Sub BtnSlow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSlow.Click
        'This code is for slowing down the mouse messages if there is too much "lag" .
        If selecteddevice <> -1 Then

            Dim portdes As String = "Device 2"
            If (mouseport = 1) Then
                portdes = "Device 1"
            End If
            Dim msg As String = "Is mouse plugged into " + portdes + "?  If so click Yes.  To change to the other port click No. To do nothing click Cancel."
            Dim dlgresult As DialogResult = MessageBox.Show(msg, "PS2 Host Emulator Demo", MessageBoxButtons.YesNoCancel)
            If (dlgresult = Windows.Forms.DialogResult.Cancel) Then
                Return
            ElseIf (dlgresult = Windows.Forms.DialogResult.No) Then
                mouseport = (mouseport) ^ 1
            End If

            For i As Integer = 0 To devices(selecteddevice).WriteLength - 1
                wdata(i) = 0
            Next
            wdata(1) = mouseport
            wdata(2) = &HF3

            Dim result As Integer
            result = 404
            While (result = 404)
                result = devices(selecteddevice).WriteData(wdata)
            End While

            If result <> 0 Then
                LblStatus.Text = "1st Write Fail: " + result.ToString
            Else
                LblStatus.Text = "Write Success"
            End If

            System.Threading.Thread.Sleep(50)
            wdata(1) = mouseport
            wdata(2) = &H14

            result = 404
            While (result = 404)
                result = devices(selecteddevice).WriteData(wdata)
            End While

            If result <> 0 Then
                LblStatus.Text = "2nd Write Fail: " + result.ToString
            Else
                LblStatus.Text = "Write Success"
            End If
        End If
    End Sub
End Class
