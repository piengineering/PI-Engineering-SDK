Imports System.Text
Imports System
Imports System.IO
Imports System.Security.Cryptography


Public Class Form1
    Implements PIEHid32Net.PIEDataHandler
    Implements PIEHid32Net.PIEErrorHandler
    Dim devices() As PIEHid32Net.PIEDevice
    Dim selecteddevice As Integer
    Dim cbotodevice(127) As Integer 'max # of devices = 128 
    Dim wdata() As Byte = New Byte() {} 'write data buffer
    Dim lastdata() As Byte = New Byte() {} 'write data buffer
    Dim saveabsolutetime As Long
    ' This delegate enables asynchronous calls for setting
    ' the text property on a TextBox control.
    Delegate Sub SetTextCallback(ByVal [text] As String)
    Dim c As Control
    Dim mouseon As Boolean = False
    Dim lastval3 As Byte 'previous value of the first button
    Dim EnumerationSuccess As Boolean
    Dim sctokey As Integer() = New Integer(255) {} 'map byte/bit "scan code" to key number listed in SDK documentation

    Dim myAes As Aes
    Dim myKey As Byte()
    Dim myIV As Byte()
   
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        selecteddevice = -1


        For i As Integer = 0 To 256 - 1
            sctokey(i) = -1
        Next

        sctokey(0) = 1
        sctokey(2) = 2
        sctokey(3) = 3
        sctokey(4) = 4
        sctokey(5) = 5
        sctokey(6) = 6
        sctokey(8) = 7
        sctokey(9) = 8
        sctokey(10) = 9
        sctokey(11) = 10
        sctokey(12) = 11
        sctokey(13) = 12
        sctokey(16) = 13
        sctokey(17) = 14
        sctokey(18) = 15
        sctokey(19) = 16
        sctokey(20) = 17
        sctokey(21) = 18
        sctokey(24) = 19
        sctokey(25) = 20
        sctokey(26) = 21
        sctokey(27) = 22
        sctokey(28) = 23
        sctokey(29) = 180
        sctokey(32) = 24
        sctokey(33) = 25
        sctokey(34) = 26
        sctokey(35) = 27
        sctokey(36) = 28
        sctokey(40) = 29
        sctokey(41) = 30
        sctokey(42) = 31
        sctokey(43) = 32
        sctokey(44) = 33
        sctokey(45) = 34
        sctokey(48) = 35
        sctokey(49) = 36
        sctokey(50) = 37
        sctokey(51) = 38
        sctokey(52) = 39
        sctokey(56) = 40
        sctokey(57) = 41
        sctokey(58) = 42
        sctokey(59) = 43
        sctokey(60) = 44
        sctokey(64) = 45
        sctokey(65) = 46
        sctokey(66) = 47
        sctokey(67) = 48
        sctokey(68) = 49
        sctokey(72) = 50
        sctokey(73) = 51
        sctokey(74) = 52
        sctokey(75) = 53
        sctokey(76) = 54
        sctokey(77) = 55
        sctokey(80) = 56
        sctokey(81) = 57
        sctokey(82) = 58
        sctokey(83) = 59
        sctokey(84) = 60
        sctokey(85) = 61
        sctokey(88) = 62
        sctokey(89) = 63
        sctokey(90) = 64
        sctokey(91) = 65
        sctokey(96) = 66
        sctokey(97) = 67
        sctokey(98) = 68
        sctokey(104) = 69
        sctokey(105) = 70
        sctokey(106) = 71
        sctokey(107) = 72
        sctokey(108) = 73
        sctokey(109) = 74
        sctokey(112) = 75
        sctokey(113) = 76
        sctokey(116) = 185
        sctokey(117) = 77
        sctokey(120) = 78
        sctokey(121) = 79
        sctokey(122) = 80
        sctokey(123) = 81
        sctokey(124) = 82
        sctokey(125) = 83
        sctokey(128) = 84
        sctokey(129) = 85
        sctokey(130) = 86
        sctokey(131) = 87
        sctokey(132) = 88
        sctokey(133) = 89
        sctokey(136) = 90
        sctokey(137) = 91
        sctokey(138) = 92
        sctokey(139) = 93
        sctokey(140) = 94
        sctokey(141) = 95
        sctokey(144) = 96
        sctokey(145) = 97
        sctokey(146) = 98
        sctokey(147) = 99
        sctokey(148) = 100
        sctokey(149) = 101
        sctokey(152) = 102
        sctokey(153) = 103
        sctokey(154) = 104
        sctokey(155) = 105
        sctokey(156) = 106
        sctokey(157) = 107
        sctokey(160) = 108
        sctokey(161) = 109
        sctokey(162) = 110
        sctokey(163) = 111
        sctokey(164) = 112
        sctokey(165) = 113
        sctokey(168) = 114
        sctokey(169) = 115
        sctokey(170) = 116
        sctokey(171) = 117
        sctokey(172) = 118
        sctokey(173) = 119
        sctokey(176) = 120
        sctokey(177) = 121
        sctokey(178) = 122
        sctokey(179) = 123
        sctokey(180) = 124
        sctokey(181) = 125
        sctokey(184) = 126
        sctokey(185) = 127
        sctokey(186) = 128
        sctokey(187) = 129
        sctokey(188) = 130
        sctokey(189) = 131
        sctokey(192) = 132
        sctokey(193) = 133
        sctokey(194) = 134
        sctokey(195) = 135
        sctokey(196) = 136
        sctokey(197) = 137
        sctokey(198) = 138
        sctokey(200) = 139
        sctokey(201) = 140
        sctokey(202) = 141
        sctokey(203) = 142
        sctokey(204) = 143
        sctokey(205) = 144
        sctokey(206) = 145
        sctokey(208) = 146
        sctokey(209) = 147
        sctokey(210) = 148
        sctokey(211) = 149
        sctokey(212) = 150
        sctokey(213) = 151
        sctokey(214) = 152
        sctokey(216) = 153
        sctokey(217) = 154
        sctokey(218) = 155
        sctokey(219) = 156
        sctokey(220) = 157
        sctokey(221) = 158
        sctokey(222) = 159
        sctokey(224) = 160
        sctokey(225) = 161
        sctokey(226) = 162
        sctokey(227) = 163
        sctokey(228) = 164
        sctokey(229) = 165
        sctokey(230) = 166
        sctokey(232) = 167
        sctokey(233) = 168
        sctokey(234) = 169
        sctokey(235) = 170
        sctokey(236) = 171
        sctokey(237) = 172
        sctokey(238) = 173
        sctokey(240) = 174
        sctokey(241) = 175
        sctokey(242) = 176
        sctokey(243) = 177
        sctokey(244) = 178
        sctokey(245) = 179



    End Sub

    Public Sub HandlePIEHidData(ByVal data() As Byte, ByVal sourceDevice As PIEHid32Net.PIEDevice, ByVal perror As Integer) Implements PIEHid32Net.PIEDataHandler.HandlePIEHidData
        'data callback
        'MsgBox("The event handler caught the event.")
        If sourceDevice.Pid = devices(selecteddevice).Pid Then

            Dim output As String
            output = "Callback: " + sourceDevice.Pid.ToString + ", ID: " + selecteddevice.ToString + ", data="
            For i As Integer = 0 To sourceDevice.ReadLength - 1
                output = output + BinToHex(data(i)).ToString + " "
            Next

            'Use thread-safe calls to windows forms controls
            SetListBox(output)

            'read unit id
            c = LblUnitID
            SetText(data(1).ToString)

            If (data(2) < 2) Then 'General Incoming Data

                'Buttons
                Dim maxcols As Integer = 31 'number of bytes of digital button data
                Dim maxrows As Integer = 8 'number of bits
                c = LblButtons
                Dim buttonsdown As String = "Buttons: "
                SetText(buttonsdown)
                For i As Integer = 0 To maxcols - 1 'loop through digital button bytes 

                    For j As Integer = 0 To maxrows - 1 'loop through each bit in the button byte
                        Dim temp1 As Integer = CInt(Math.Pow(2, j)) '1, 2, 4, 8, 16, 32, 64, 128
                        Dim bitnum As Integer = 8 * i + j 'byte/bit "scan code"
                        Dim temp2 As Byte = CByte((data(i + 3) And temp1)) 'check using bitwise AND the current value of this bit. The + 3 is because the 1st button byte starts 3 bytes in at data[3]
                        Dim temp3 As Byte = CByte((lastdata(i + 3) And temp1)) 'check using bitwise AND the previous value of this bit
                        Dim state As Integer = 0
                        '0=was up, now up, 1=was up, now down, 2= was down, still down, 3= was down, now up
                        If temp2 <> 0 AndAlso temp3 = 0 Then
                            state = 1
                        ElseIf temp2 <> 0 AndAlso temp3 <> 0 Then
                            state = 2
                        ElseIf temp2 = 0 AndAlso temp3 <> 0 Then
                            state = 3
                        End If

                        Select Case state
                            Case 1
                                buttonsdown = buttonsdown & sctokey(bitnum).ToString() & " "
                                SetText(buttonsdown)
                            Case 2
                                buttonsdown = buttonsdown & sctokey(bitnum).ToString() & " "
                                SetText(buttonsdown)
                            Case 3
                        End Select

                    Next
                Next

                For i As Integer = 0 To sourceDevice.ReadLength - 1
                    lastdata(i) = data(i)
                Next
                'end buttons

                'time stamp info 4 bytes
                Dim absolutetime As Long = 16777216 * data(13) + 65536 * data(14) + 256 * data(15) + data(16) 'ms
                Dim absolutetime2 As Long = absolutetime / 1000 'in seconds
                c = lblabstime
                SetText("absolute time: " + absolutetime2.ToString + " s")
                Dim deltatime As Long = absolutetime - saveabsolutetime
                c = lbldeltatime
                SetText("delta time: " + deltatime.ToString + " ms")
                saveabsolutetime = absolutetime
            ElseIf (data(2) = 139) Then 'encrypt result
                c = lblXkeysEncrypt
                Dim encryptedbytes As String = ""
                For i As Integer = 0 To 32 - 1
                    encryptedbytes = encryptedbytes + BinToHex(data(3 + i)) + ", "
                Next
                SetText(encryptedbytes)
            ElseIf (data(2) = 140) Then 'decrypt result
                c = lblXkeysDecrypt
                Dim decryptedbytes As String = ""
                For i As Integer = 0 To 32 - 1
                    decryptedbytes = decryptedbytes + BinToHex(data(3 + i)) + ", "
                Next
                SetText(decryptedbytes)
            End If
        End If


    End Sub
    Public Sub HandlePIEHidError(ByVal sourceDevice As PIEHid32Net.PIEDevice, ByVal perror As Integer) Implements PIEHid32Net.PIEErrorHandler.HandlePIEHidError
        'error callback
        Dim output As String
        output = "Error: " + perror.ToString + " " + sourceDevice.GetErrorString(perror)
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
    Private Sub BtnEnumerate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEnumerate.Click
        'do this first to get the devices connected
        EnumerationSuccess = False
        selecteddevice = -1 'means no device is selected
        CboDevices.Items.Clear()
        devices = PIEHid32Net.PIEDevice.EnumeratePIE()
        If devices.Length = 0 Then
            LblStatus.Text = "No Devices Found"
        Else
            Dim cbocount As Integer = 0
            For i As Integer = 0 To devices.Length - 1

                If devices(i).HidUsagePage = 12 And devices(i).WriteLength > 1 Then

                    Select Case devices(i).Pid
                        Case 1573
                            CboDevices.Items.Add(devices(i).ProductString + " (" + devices(i).Pid.ToString + "=PID #1)")
                            cbotodevice(cbocount) = i
                            cbocount = cbocount + 1
                        Case 1583
                            CboDevices.Items.Add(devices(i).ProductString + " (" + devices(i).Pid.ToString + "=PID #1)")
                            cbotodevice(cbocount) = i
                            cbocount = cbocount + 1
                        Case 1585
                            CboDevices.Items.Add(devices(i).ProductString + " (" + devices(i).Pid.ToString + "=PID #1)")
                            cbotodevice(cbocount) = i
                            cbocount = cbocount + 1
                        Case Else
                            CboDevices.Items.Add("Unknown Device (" + devices(i).Pid.ToString + ")")
                            cbotodevice(cbocount) = i
                            cbocount = cbocount + 1
                    End Select
                    Dim result As Integer = devices(i).SetupInterface()
                    devices(i).suppressDuplicateReports = ChkSuppress.Checked

                    If result <> 0 Then
                        LblStatus.Text = "Failed SetupInterface on device: " + i.ToString
                    Else
                        LblStatus.Text = "Success SetupInterface"
                    End If
                End If
                'break()
            Next
        End If

        If CboDevices.Items.Count > 0 Then
            CboDevices.SelectedIndex = 0
            selecteddevice = cbotodevice(CboDevices.SelectedIndex)
            ReDim wdata(devices(selecteddevice).WriteLength - 1) 'initialize length of write buffer
            ReDim lastdata(devices(selecteddevice).ReadLength - 1) 'initialize length of read buffer
            'fill in version

            LblVersion.Text = devices(selecteddevice).Version.ToString
            EnumerationSuccess = True
            Me.Cursor = Cursors.Default
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

    Private Sub BtnWriteUnitID_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnWriteUnitID.Click
        'change the device's unit id
        If selecteddevice <> -1 Then

            For i As Integer = 0 To devices(selecteddevice).WriteLength - 1
                wdata(i) = 0
            Next
            wdata(0) = 0
            wdata(1) = 189
            wdata(2) = TxtUnitID.Text

            Dim result As Integer
            result = 404
            While (result = 404)
                result = devices(selecteddevice).WriteData(wdata)
            End While

            If result <> 0 Then
                LblStatus.Text = "Write Fail: " + result.ToString
            Else
                LblStatus.Text = "Write Success - Unit ID"
            End If
        End If
    End Sub

    Private Sub CboDevices_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboDevices.SelectedIndexChanged
        'update selecteddevice with that chosen and redim the write array
        selecteddevice = cbotodevice(CboDevices.SelectedIndex)
        ReDim wdata(devices(selecteddevice).WriteLength - 1) 'initialize length of write buffer
        ReDim lastdata(devices(selecteddevice).ReadLength - 1)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ListBox1.Items.Clear()
    End Sub



    Private Sub BtnKBreflect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnKBreflect.Click
        'send some hid codes to the textbox, these will be coming in on the native keyboard endpoint
        If selecteddevice <> -1 Then
            For i As Integer = 0 To devices(selecteddevice).WriteLength - 1
                wdata(i) = 0
            Next
            textBox1.Focus()

            wdata(0) = 0
            wdata(1) = 201

            wdata(2) = 2 'modifiers
            wdata(3) = 0 'always 0
            wdata(4) = 4 'hid code for a, down
            wdata(5) = 0 'can send a total of 6 hidcodes at one time
            wdata(6) = 0
            wdata(7) = 0
            wdata(8) = 0
            wdata(9) = 0

            'use this method to ensure done writing data before executing the next write command
            Dim result As Integer
            result = 404
            While (result = 404)
                result = devices(selecteddevice).WriteData(wdata)
            End While

            wdata(2) = 0 'modifiers
            wdata(3) = 0 'always 0
            wdata(4) = 0 'a up
            wdata(5) = 5 'b down
            wdata(6) = 6 'c down
            wdata(7) = 7 'd down
            wdata(8) = 0
            wdata(9) = 0

            result = 404
            While (result = 404)
                result = devices(selecteddevice).WriteData(wdata)
            End While

            wdata(2) = 0 'modifiers
            wdata(3) = 0 'always 0
            wdata(4) = 0
            wdata(5) = 0 'b up
            wdata(6) = 0 'c up
            wdata(7) = 0 'd up
            wdata(8) = 0
            wdata(9) = 0

            result = 404
            While (result = 404)
                result = devices(selecteddevice).WriteData(wdata)
            End While

        End If
    End Sub



    Private Sub BtnTimeStamp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTimeStamp.Click
        'turns off the time stamp feature
        If selecteddevice <> -1 Then
            For i As Integer = 0 To devices(selecteddevice).WriteLength - 1
                wdata(i) = 0
            Next

            wdata(0) = 0
            wdata(1) = 210
            wdata(2) = 0

            Dim result As Integer
            result = 404
            While (result = 404)
                result = devices(selecteddevice).WriteData(wdata)
            End While

            If result <> 0 Then
                LblStatus.Text = "Write Fail: " + result.ToString
            Else
                LblStatus.Text = "Write Success - time stamp on"
            End If
        End If
    End Sub
    Private Sub BtnTimeStampOn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTimeStampOn.Click
        ' Sending this command will turn off the 4 bytes of data which assembled give the time in ms from the start of the computer

        If selecteddevice <> -1 Then
            For i As Integer = 0 To devices(selecteddevice).WriteLength - 1
                wdata(i) = 0
            Next

            wdata(0) = 0
            wdata(1) = 210
            wdata(2) = 1

            Dim result As Integer
            result = 404
            While (result = 404)
                result = devices(selecteddevice).WriteData(wdata)
            End While

            If result <> 0 Then
                LblStatus.Text = "Write Fail: " + result.ToString
            Else
                LblStatus.Text = "Write Success - time stamp on"
            End If
        End If
    End Sub

    Private Sub BtnDescriptor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDescriptor.Click
        If selecteddevice <> -1 Then

            'IMPORTANT turn off the callback if going so data isn't grabbed there, turn it back on later (not done here)
            devices(selecteddevice).callNever = True

            For i As Integer = 0 To devices(selecteddevice).WriteLength - 1
                wdata(i) = 0
            Next

            wdata(0) = 0
            wdata(1) = 214

            Dim result As Integer
            result = 404
            While (result = 404)
                result = devices(selecteddevice).WriteData(wdata)
            End While

            If result <> 0 Then
                LblStatus.Text = "Write Fail: " + result.ToString
            Else
                LblStatus.Text = "Write Success - Descriptor"
            End If
            'after this write the next read with 3rd byte = 214 gives descriptor data
            Dim ddata(devices(selecteddevice).ReadLength) As Byte
            Dim countout As Integer = 0
            result = devices(selecteddevice).BlockingReadData(ddata, 100)
            While (result = 304 Or (result = 0 And ddata(2) <> 214))
                If result = 304 Then
                    'no new data after 100ms, so increment countout extra
                    countout = countout + 99
                End If
                countout = countout + 1
                If (countout > 1000) Then
                    Exit While
                End If
                result = devices(selecteddevice).BlockingReadData(ddata, 100)
            End While
            listBox2.Items.Clear()
            If (ddata(3) = 0) Then
                listBox2.Items.Add("PID #1")
            ElseIf (ddata(3) = 1) Then
                listBox2.Items.Add("PID #2")
            ElseIf (ddata(3) = 2) Then
                listBox2.Items.Add("PID #3")
            ElseIf (ddata(3) = 3) Then
                listBox2.Items.Add("PID #4")
            End If
            listBox2.Items.Add("Keymapstart=" + ddata(4).ToString)
            listBox2.Items.Add("Layer2offset=" + ddata(5).ToString)
            listBox2.Items.Add("Constant=" + ddata(6).ToString)
            listBox2.Items.Add("Constant=" + ddata(7).ToString)
            listBox2.Items.Add("MaxCol=" + ddata(8).ToString)
            listBox2.Items.Add("MaxRow=" + ddata(9).ToString)
            Dim greenled As String = "Off"
            If (ddata(10) And 64) <> 0 Then
                greenled = "On"
            End If
            Dim redled As String = "Off"
            If (ddata(10) And 128) <> 0 Then
                redled = "On"
            End If

            listBox2.Items.Add("Green LED=" & greenled)
            listBox2.Items.Add("Red LED=" & redled)

            listBox2.Items.Add("Version=" + ddata(11).ToString)
            Dim temp As String = "PID=" + (ddata(13) * 256 + ddata(12)).ToString
            listBox2.Items.Add(temp)
        End If
    End Sub

    Private Sub BtnGetDataNow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGetDataNow.Click
        'After sending this command a general incoming data report will be given with
        'the 3rd byte (Data Type) 2nd bit set.  If program switch is up byte 3 will be 2
        'and if it is pressed byte 3 will be 3.  This is useful for getting the initial state
        'or unit id of the device before it sends any data.
        If selecteddevice <> -1 Then
            devices(selecteddevice).callNever = False
            For i As Integer = 0 To devices(selecteddevice).WriteLength - 1
                wdata(i) = 0
            Next

            wdata(0) = 0
            wdata(1) = 177 'b1h

            Dim result As Integer
            result = 404
            While (result = 404)
                result = devices(selecteddevice).WriteData(wdata)
            End While

            If result <> 0 Then
                LblStatus.Text = "Write Fail: " + result.ToString
            Else
                LblStatus.Text = "Write Success - Generate Data"
            End If
        End If
    End Sub

    Private Sub BtnJoyreflect_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub BtnCustom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCustom.Click

        'After sending this command a custom incoming data report will be given with
        'the 3rd byte (Data Type) set to 0xE0, the 4th byte set to the count given below when the command was sent
        'and the following bytes whatever the user wishes.  In this example we are send 3 bytes; 1, 2, 3

        If selecteddevice <> -1 Then
            devices(selecteddevice).callNever = False
            For i As Integer = 0 To devices(selecteddevice).WriteLength - 1
                wdata(i) = 0
            Next

            wdata(0) = 0
            wdata(1) = 224  'e0h
            wdata(2) = 3 'count of bytes to follow
            wdata(3) = 1 '1st custom byte
            wdata(4) = 2 '2nd custom byte
            wdata(5) = 3 '3rd custom byte

            Dim result As Integer
            result = 404
            While (result = 404)
                result = devices(selecteddevice).WriteData(wdata)
            End While

            If result <> 0 Then
                LblStatus.Text = "Write Fail: " + result.ToString
            Else
                LblStatus.Text = "Write Success - Custom Data"
            End If
        End If
    End Sub

    Private Sub BtnVersion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnVersion.Click

        'This report available on v5 firmware or above.
        'Write version, this is a 2 byte number that is available on enumeration.  You must reboot the device to see the 
        'newly written version!

        If selecteddevice <> -1 Then
            For i As Integer = 0 To devices(selecteddevice).WriteLength - 1
                wdata(i) = 0
            Next

            wdata(0) = 0
            wdata(1) = 195 'c3h
            Dim version As Integer = TxtVersion.Text
            Dim lowbyte As Byte = version
            Dim hibyte As Byte = version >> 8
            wdata(2) = lowbyte
            wdata(3) = hibyte

            Dim result As Integer
            result = 404
            While (result = 404)
                result = devices(selecteddevice).WriteData(wdata)
            End While

            If result <> 0 Then
                LblStatus.Text = "Write Fail: " + result.ToString
            Else
                LblStatus.Text = "Write Success - version"
            End If


            'reboot device either manually with a hotplug or using the command below, to use this uncomment out the WriteData line,
            'must re-enumerate after sending
            'System.Threading.Thread.Sleep(100)
            'devices(selecteddevice).callNever = True
            wdata(0) = 0
            wdata(1) = 238 'eeh
            wdata(2) = 0
            wdata(3) = 0

            'result = 404
            'While (result = 404)
            '    result = devices(selecteddevice).WriteData(wdata)
            'End While

            'If result <> 0 Then
            '    LblStatus.Text = "Write Fail: " + result.ToString
            'Else
            '    LblStatus.Text = "Write Success - reboot"
            'End If

            'wait for reboot OR use device notification service (see http://www.piengineering.com/developer/mcode/DeviceNotification%20CSharp%20Express.zip)
            'System.Threading.Thread.Sleep(5000)
            'EnumerationSuccess = False
            'Dim countout As Int16 = 0

            'While (EnumerationSuccess = False)
            '    countout = countout + 1
            '    If (countout > 100) Then
            '        Me.Cursor = Cursors.Default
            '        Return
            '    End If
            '    BtnEnumerate_Click(Me, Nothing)
            '    System.Threading.Thread.Sleep(1000)
            'End While


        End If
    End Sub

    Private Sub BtnMousereflect_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)



    End Sub

    Private Sub BtnMultiMedia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnMultiMedia.Click

        '   //Many multimedia commands require the app to have focus to work.  Some that don't are Mute (E2), Volume Increment (E9), Volume Decrement (EA)
        '   //The Multimedia reflector is mainly designed to be used as hardware mode macros.
        '   //Some common multimedia codes
        '   //Scan Next Track	00B5
        '   //Scan Previous Track	00B6
        '   //Stop	00B7
        '   //Play/Pause	00CD
        '   //Mute	00E2
        '   //Bass Boost	00E5
        '   //Loudness	00E7
        '   //Volume Up	00E9
        '   //Volume Down	00EA
        '   //Bass Up	0152
        '   //Bass Down	0153
        '   //Treble Up	0154
        '   //Treble Down	0155
        '   //Media Select	0183
        '   //Mail	018A
        '   //Calculator	0192
        '   //My Computer	0194
        '   //Search	0221
        '   //Home	0223
        '   //Back	0224
        '   //Forward	0225
        '   //Stop	0226
        '   //Refresh	0227
        '   //Favorites	022A
        If selecteddevice <> -1 Then

            For i As Integer = 0 To devices(selecteddevice).WriteLength - 1
                wdata(i) = 0
            Next

            wdata(0) = 0
            wdata(1) = 225  'e1h
            wdata(2) = HexToBin(TxtMMLow.Text) 'Usage ID lo byte see hut1_12.pdf, pages 75-85 Consumer Page
            wdata(3) = HexToBin(TxtMMHigh.Text) 'Usage ID hi byte see hut1_12.pdf, pages 75-85 Consumer Page

            Dim result As Integer
            result = 404
            While (result = 404)
                result = devices(selecteddevice).WriteData(wdata)
            End While

            wdata(0) = 0
            wdata(1) = 225  'e1h
            wdata(2) = 0 'terminate
            wdata(3) = 0 'terminate

            result = 404
            While (result = 404)
                result = devices(selecteddevice).WriteData(wdata)
            End While
            '   //note that when the "terminate" command is sent can sometimes have an effect on the behavior of the command
            '   //for example in volume decrement (EA=lo byte, 00=hi byte) if you send the terminate immediately after the e1 command it will
            '   //decrement the volume one step, if you send the e1 on the press and the terminate on the release the volume will continuously
            '   //decrement until the key is released.

            If result <> 0 Then
                LblStatus.Text = "Write Fail: " + result.ToString
            Else
                LblStatus.Text = "Write Success - Multimedia"
            End If
        End If
    End Sub
    Public Shared Function HexToBin(ByVal value As [String]) As Byte
        value = value.Trim()
        Dim temp As Integer = Convert.ToInt32(value, 16)
        Return CByte(temp)
    End Function
    Public Shared Function BinToHex(ByVal value As [Byte]) As [String]
        Dim sb As New StringBuilder("")
        sb.Append(value.ToString("X2"))
        'the 2 means 2 digits
        Return sb.ToString()
    End Function

    Private Sub BtnMyComputer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnMyComputer.Click

        If selecteddevice <> -1 Then

            For i As Integer = 0 To devices(selecteddevice).WriteLength - 1
                wdata(i) = 0
            Next

            wdata(0) = 0
            wdata(1) = 225  'e1h
            wdata(2) = HexToBin("94") 'Usage ID lo byte see hut1_12.pdf, pages 75-85 Consumer Page
            wdata(3) = HexToBin("01") 'Usage ID hi byte see hut1_12.pdf, pages 75-85 Consumer Page

            Dim result As Integer
            result = 404
            While (result = 404)
                result = devices(selecteddevice).WriteData(wdata)
            End While

            wdata(0) = 0
            wdata(1) = 225  'e1h
            wdata(2) = 0 'terminate
            wdata(3) = 0 'terminate

            result = 404
            While (result = 404)
                result = devices(selecteddevice).WriteData(wdata)
            End While
            '   //note that when the "terminate" command is sent can sometimes have an effect on the behavior of the command
            '   //for example in volume decrement (EA=lo byte, 00=hi byte) if you send the terminate immediately after the e1 command it will
            '   //decrement the volume one step, if you send the e1 on the press and the terminate on the release the volume will continuously
            '   //decrement until the key is released.
            If result <> 0 Then
                LblStatus.Text = "Write Fail: " + result.ToString
            Else
                LblStatus.Text = "Write Success - Multimedia"
            End If
        End If
    End Sub

    Private Sub BtnSleep_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSleep.Click

        If selecteddevice <> -1 Then

            For i As Integer = 0 To devices(selecteddevice).WriteLength - 1
                wdata(i) = 0
            Next

            wdata(0) = 0
            wdata(1) = 226  'e2h
            wdata(2) = 2 '1=power down, 2=sleep, 4=wake up

            Dim result As Integer
            result = 404
            While (result = 404)
                result = devices(selecteddevice).WriteData(wdata)
            End While

            wdata(0) = 0
            wdata(1) = 226  'e2h
            wdata(2) = 0 'terminate

            result = 404
            While (result = 404)
                result = devices(selecteddevice).WriteData(wdata)
            End While

            If result <> 0 Then
                LblStatus.Text = "Write Fail: " + result.ToString
            Else
                LblStatus.Text = "Write Success - Multimedia"
            End If
        End If
    End Sub

    Private Sub ChkSuppress_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkSuppress.CheckedChanged
        If (ChkSuppress.Checked = True) Then
            devices(selecteddevice).suppressDuplicateReports = True
        Else
            devices(selecteddevice).suppressDuplicateReports = False
        End If

    End Sub


    Private Sub ChkGreen_CheckStateChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkGreen.CheckStateChanged
        'control leds
        If selecteddevice <> -1 Then


            For i As Integer = 0 To devices(selecteddevice).WriteLength - 1
                wdata(i) = 0
            Next
            wdata(0) = 0
            wdata(1) = 179
            wdata(2) = CboLED.SelectedIndex
            wdata(3) = ChkGreen.CheckState

            Dim result As Integer
            result = 404
            While (result = 404)
                result = devices(selecteddevice).WriteData(wdata)
            End While

            If result <> 0 Then
                LblStatus.Text = "Write Fail: " + result.ToString
            Else
                LblStatus.Text = "Write Success - LEDs and Output"
            End If
        End If
    End Sub


    Private Sub btnChangePID_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChangePID.Click

        'Change between available PIDs/Endpoints
        If selecteddevice <> -1 Then
            For i As Integer = 0 To devices(selecteddevice).WriteLength - 1
                wdata(i) = 0
            Next

            wdata(0) = 0
            wdata(1) = 204 'cc
            wdata(2) = cboPIDs.SelectedIndex '0=1573, 1=1574 (kvm)

            Dim result As Integer
            result = 404
            While (result = 404)
                result = devices(selecteddevice).WriteData(wdata)
            End While

            If result <> 0 Then
                LblStatus.Text = "Write Fail: " + result.ToString
            Else
                LblStatus.Text = "Write Success - Change endpoints"
            End If
        End If
    End Sub

    Private Sub BtnNoChange_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNoChange.Click
        'Do not change PID on reboot
        If selecteddevice <> -1 Then
            For i As Integer = 0 To devices(selecteddevice).WriteLength - 1
                wdata(i) = 0
            Next

            wdata(0) = 0
            wdata(1) = 196 'c4h

            wdata(2) = 0 'stay on pid #1 (device 0) on reboot

            Dim result As Integer
            result = 404
            While (result = 404)
                result = devices(selecteddevice).WriteData(wdata)
            End While

            If result <> 0 Then
                LblStatus.Text = "Write Fail: " + result.ToString
            Else
                LblStatus.Text = "Write Success"
            End If

        End If
    End Sub

    Private Sub BtnChange_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnChange.Click
        'Always change to PID #2 on reboot
        If selecteddevice <> -1 Then
            For i As Integer = 0 To devices(selecteddevice).WriteLength - 1
                wdata(i) = 0
            Next

            wdata(0) = 0
            wdata(1) = 196 'c4h

            wdata(2) = 1 'change to pid #2 (device 1) on reboot

            Dim result As Integer
            result = 404
            While (result = 404)
                result = devices(selecteddevice).WriteData(wdata)
            End While

            If result <> 0 Then
                LblStatus.Text = "Write Fail: " + result.ToString
            Else
                LblStatus.Text = "Write Success"
            End If

        End If
    End Sub

    Private Sub btnSiliconGeneratedID_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSiliconGeneratedID.Click
        'After sending this command, the device will return the .SerialNumberString
        If selecteddevice <> -1 Then
            For i As Integer = 0 To devices(selecteddevice).WriteLength - 1
                wdata(i) = 0
            Next

            wdata(0) = 0
            wdata(1) = 196 '9dh

            wdata(2) = 1 'change to pid #2 (device 1) on reboot

            Dim result As Integer
            result = 404
            While (result = 404)
                result = devices(selecteddevice).WriteData(wdata)
            End While

            If result <> 0 Then
                LblStatus.Text = "Write Fail: " + result.ToString
            Else
                LblStatus.Text = "Write Success"
            End If

        End If
    End Sub


    Private Sub BtnSetDongle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSetDongle.Click
        If selecteddevice <> -1 Then

            'pick a secret 16 byte key and save this Key!!
            myKey(0) = 7
            myKey(1) = 58
            myKey(2) = 33
            myKey(3) = 243
            myKey(4) = 7
            myKey(5) = 58
            myKey(6) = 33
            myKey(7) = 243
            myKey(8) = 7
            myKey(9) = 58
            myKey(10) = 33
            myKey(11) = 243
            myKey(12) = 7
            myKey(13) = 58
            myKey(14) = 33
            myKey(15) = 243

            'Write AES key to X-keys, this key is stored in eeprom
            For i As Integer = 0 To devices(selecteddevice).WriteLength - 1
                wdata(i) = 0
            Next

            wdata(0) = 0
            wdata(1) = 137 '&H89 set AES key

            For i As Integer = 0 To 15
                wdata(2 + i) = myKey(i)
            Next

            Dim result As Integer
            result = 404
            While (result = 404)
                result = devices(selecteddevice).WriteData(wdata)
            End While

            If result <> 0 Then
                LblStatus.Text = "Write Fail: " + result.ToString
            Else
                LblStatus.Text = "Write Success - set AES Dongle"
            End If
        End If
    End Sub

    Private Sub BtnCheckDongle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCheckDongle.Click
        If selecteddevice <> -1 Then 'do nothing if not enumerated

            'Before each encryption, you MUST set the initialization vector. The initialzation vector is set to all 0s after each encryption and decryption in the X-keys.
            Dim rnd As Random = New Random()
            For i As Integer = 0 To 15
                myIV(i) = CByte(rnd.Next(0, 254)) 'valid values are 0-255 HOWEVER all 0s is not allowed because that is interpreted as an non-initialized IV
            Next

            For i As Integer = 0 To devices(selecteddevice).WriteLength - 1
                wdata(i) = 0
            Next

            wdata(0) = 0
            wdata(1) = 138 '&H8A set AES IV

            For i As Integer = 0 To 15
                wdata(2 + i) = myIV(i)
            Next

            Dim result As Integer = 404
            While result = 404
                result = devices(selecteddevice).WriteData(wdata)
            End While

            'Encrypt
            Dim savecallbackstate As Boolean = devices(selecteddevice).callNever
            devices(selecteddevice).callNever = True

            Dim mymessage As String = "Enter any phrase"

            For i As Integer = 0 To devices(selecteddevice).WriteLength - 1
                wdata(i) = 0
            Next

            wdata(0) = 0
            wdata(1) = 139 '&H8B Encrypt
            For i As Integer = 0 To mymessage.Length - 1
                wdata(2 + i) = CByte(AscW(mymessage(i)))
            Next

            result = 404
            While result = 404
                result = devices(selecteddevice).WriteData(wdata)
            End While
            If result <> 0 Then
                LblStatus.Text = "Write Fail: " + result.ToString
            Else
                LblStatus.Text = "Write Success - check AES Dongle"
            End If

            'read back the encrypted data
            Dim encrypteddata As Byte() = New Byte(31) {}
            Dim data As Byte() = Nothing
            Dim countout As Integer = 0
            data = New Byte(79) {}
            Dim ret As Integer = devices(selecteddevice).BlockingReadData(data, 100)

            While (ret = 0 AndAlso data(2) <> 139) OrElse ret = 304

                If ret = 304 Then
                    countout += 99
                End If

                countout += 1
                If countout > 1000 Then Exit While
                ret = devices(selecteddevice).BlockingReadData(data, 100)
            End While

            For i As Integer = 0 To 32 - 1
                encrypteddata(i) = data(i + 3)
            Next

            devices(selecteddevice).callNever = savecallbackstate

            'Decrypt
            'use the same secret 16 byte key that was used in Set Dongle and the same IV as used above to encrypt
            myKey(0) = 7
            myKey(1) = 58
            myKey(2) = 33
            myKey(3) = 243
            myKey(4) = 7
            myKey(5) = 58
            myKey(6) = 33
            myKey(7) = 243
            myKey(8) = 7
            myKey(9) = 58
            myKey(10) = 33
            myKey(11) = 243
            myKey(12) = 7
            myKey(13) = 58
            myKey(14) = 33
            myKey(15) = 243

            Dim decryptresults As String = DecryptStringFromBytes_Aes(encrypteddata, myKey, myIV, CipherMode.CBC, PaddingMode.Zeros)
            'remove padded 0s
            decryptresults = decryptresults.Replace("\0", String.Empty)

            TextBox2.Visible = True
            TextBox2.Text = decryptresults 'must do this for comparison??? otherwise it fails - compiler bug??
            decryptresults = TextBox2.Text
            TextBox2.Visible = False

            If (mymessage = decryptresults) Then
                lblAESPassFail.Text = "Pass"
                lblAESPassFail.BackColor = Color.Lime
            Else
                lblAESPassFail.Text = "Fail"
                lblAESPassFail.BackColor = Color.Red
            End If

        End If
    End Sub

    Private Shared Function DecryptStringFromBytes_Aes(ByVal cipherText As Byte(), ByVal Key As Byte(), ByVal IV As Byte(), ByVal thismode As CipherMode, ByVal thispadding As PaddingMode) As String
        If cipherText Is Nothing OrElse cipherText.Length <= 0 Then Throw New ArgumentNullException("cipherText")
        If Key Is Nothing OrElse Key.Length <= 0 Then Throw New ArgumentNullException("Key")
        If IV Is Nothing OrElse IV.Length <= 0 Then Throw New ArgumentNullException("IV")
        Dim plaintext As String = Nothing

        Using aesAlg As Aes = Aes.Create()
            aesAlg.Key = Key
            aesAlg.IV = IV
            aesAlg.Mode = thismode
            aesAlg.Padding = thispadding
            Dim decryptor As ICryptoTransform = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV)

            Using msDecrypt As MemoryStream = New MemoryStream(cipherText)

                Using csDecrypt As CryptoStream = New CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read)

                    Using srDecrypt As StreamReader = New StreamReader(csDecrypt)
                        plaintext = srDecrypt.ReadToEnd()
                    End Using
                End Using
            End Using
        End Using

        Return plaintext
    End Function

    Private Shared Function EncryptStringToBytes_Aes(ByVal plainText As String, ByVal Key As Byte(), ByVal IV As Byte(), ByVal thismode As CipherMode, ByVal thispadding As PaddingMode) As Byte()
        If plainText Is Nothing OrElse plainText.Length <= 0 Then Throw New ArgumentNullException("plainText")
        If Key Is Nothing OrElse Key.Length <= 0 Then Throw New ArgumentNullException("Key")
        If IV Is Nothing OrElse IV.Length <= 0 Then Throw New ArgumentNullException("IV")
        Dim encrypted As Byte()

        Using aesAlg As Aes = Aes.Create()
            aesAlg.Key = Key
            aesAlg.IV = IV
            aesAlg.Mode = thismode
            aesAlg.Padding = thispadding
            Dim encryptor As ICryptoTransform = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV)

            Using msEncrypt As MemoryStream = New MemoryStream()

                Using csEncrypt As CryptoStream = New CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write)

                    Using swEncrypt As StreamWriter = New StreamWriter(csEncrypt)
                        swEncrypt.Write(plainText)
                    End Using

                    encrypted = msEncrypt.ToArray()
                End Using
            End Using
        End Using

        Return encrypted
    End Function



    Private Sub btnRawAESSetKey_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRawAESSetKey.Click
        'Sets the 16 byte AES key in the X-keys, keep track of this key, it is are required for decryption
        If selecteddevice <> -1 Then 'do nothing if not enumerated

            myAes.GenerateKey()
            'save this key!
            For j As Integer = 0 To 15
                myKey(j) = myAes.Key(j)
            Next
            'Write Key to X-keys, this key is stored in eeprom
            For j As Integer = 0 To devices(selecteddevice).WriteLength - 1
                wdata(j) = 0
            Next

            wdata(0) = 0
            wdata(1) = 137 '&H89 Set AES Key
            For j As Integer = 0 To 15
                wdata(2 + j) = myKey(j)
            Next

            Dim result As Integer = 404
            While result = 404
                result = devices(selecteddevice).WriteData(wdata)
            End While
            If result <> 0 Then
                LblStatus.Text = "Write Fail: " + result
            Else
                LblStatus.Text = "Write Success - Set AES Key"
            End If
        End If
    End Sub

    Private Sub btnAESEncrypt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAESEncrypt.Click
        'Encrypt AES
        If selecteddevice <> -1 Then 'do nothing if not enumerated

            'input data (up to 32 bytes), outputs encryption
            'AES Key should have been previously set and recorded (if decrypting)

            'Before each encryption MUST set the initialization vector. The initialzation vector is set to all 0s after each encryption and decryption in the X-keys.   
            Dim rnd As Random = New Random()
            For i As Integer = 0 To 15
                myIV(i) = CByte(rnd.Next(0, 254)) 'valid values are 0-255 HOWEVER all 0s is not allowed because that is interpreted as an non-initialized IV
            Next

            'set initialization vector
            For i As Integer = 0 To devices(selecteddevice).WriteLength - 1
                wdata(i) = 0
            Next

            wdata(0) = 0
            wdata(1) = 138 '&H8A Set AES IV
            For i As Integer = 0 To 15
                wdata(2 + i) = myIV(i)
            Next

            Dim result As Integer = 404
            While result = 404
                result = devices(selecteddevice).WriteData(wdata)
            End While

            Dim mymessage As String = txtXkeysEncrypt.Text
            For i As Integer = 0 To devices(selecteddevice).WriteLength - 1
                wdata(i) = 0
            Next

            wdata(0) = 0
            wdata(1) = 139 '&H8B Set AES Encrypt
            For i As Integer = 0 To mymessage.Length - 1
                wdata(2 + i) = CByte(AscW(mymessage(i)))
            Next

            result = 404
            While result = 404
                result = devices(selecteddevice).WriteData(wdata)
            End While


            If result <> 0 Then
                LblStatus.Text = "Write Fail: " + result
            Else
                LblStatus.Text = "Write Success - AES Encrypt"
            End If

            'results in callback

        End If
    End Sub

    Private Sub btnXkeysDecrypt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnXkeysDecrypt.Click
        If selecteddevice <> -1 Then
            'input encrypted data (up to 32 bytes), outputs decryption
            'AES Key and IV should have been previously set and recorded

            'Before each decryption MUST set the initialization vector with that used for the encryption.

            For i As Integer = 0 To devices(selecteddevice).WriteLength - 1
                wdata(i) = 0
            Next

            wdata(0) = 0
            wdata(1) = 138 '&H8A Set AES IV
            For i As Integer = 0 To 15
                wdata(2 + i) = myIV(i)
            Next

            Dim result As Integer
            result = 404
            While (result = 404)
                result = devices(selecteddevice).WriteData(wdata)
            End While

            'Decrypt
            Dim decryptthis = lblXkeysEncrypt.Text
            If decryptthis = "encrypt result" Then
                MessageBox.Show("invalid encryption results, make sure callback is on before encrypting")
                Return
            End If


            Dim encryptedbytes As Byte() = New Byte(31) {}
            Dim count As Integer = 0
            While (decryptthis.Length > 0)
                Dim pos As Integer = decryptthis.IndexOf(",")
                If (pos <> -1) Then
                    encryptedbytes(count) = HexToBin(decryptthis.Substring(0, 2))
                    decryptthis = decryptthis.Remove(0, pos + 1).Trim()
                    count = count + 1
                End If
            End While

            'input encrypted data (up to 32 bytes), outputs decryption
            For i As Integer = 0 To devices(selecteddevice).WriteLength - 1
                wdata(i) = 0
            Next
            wdata(0) = 0
            wdata(1) = 140 '&H8C 
            For i As Integer = 0 To 32 - 1
                wdata(2 + i) = encryptedbytes(i)
            Next
            result = 404
            While (result = 404)
                result = devices(selecteddevice).WriteData(wdata)
            End While


            If result <> 0 Then
                LblStatus.Text = "Write Fail: " + result.ToString
            Else
                LblStatus.Text = "Write Success - AES Decrypt"
            End If
            'results in callback
        End If
    End Sub

    Private Sub btnBeep_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBeep.Click
        '//For units with optional annunciator feature, sounds a beep for the desired volume, desired frequency, and desired duration.
        '//The desired frequency of the beep sound is determined by entering a 2 byte divider value, the higher this value, the lower the frequency of the sound.
        If selecteddevice <> -1 Then
            For i As Integer = 0 To devices(selecteddevice).WriteLength - 1
                wdata(i) = 0
            Next

            wdata(0) = 0
            wdata(1) = 200 'c8h
            wdata(2) = txtVol.Text
            Dim newdivider As Integer = txtDivider.Text
            wdata(3) = CByte((newdivider And &HFF))
            wdata(4) = CByte(newdivider >> 8)
            wdata(5) = txtBeepDuration.Text '0 means never turn off beep, user must manually turn it off with a volume=0 command. 1-255 is ms duration /10 so actual durations are 10ms-2550ms

            Dim result As Integer
            result = 404
            While (result = 404)
                result = devices(selecteddevice).WriteData(wdata)
            End While

            If result <> 0 Then
                LblStatus.Text = "Write Fail: " + result.ToString
            Else
                LblStatus.Text = "Write Success"
            End If

        End If
    End Sub

    Private Sub btnBeepOff_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBeepOff.Click
        '//For units with optional annunciator feature, sounds a beep for the desired volume, desired frequency, and desired duration.
        '//The desired frequency of the beep sound is determined by entering a 2 byte divider value, the higher this value, the lower the frequency of the sound.
        If selecteddevice <> -1 Then
            For i As Integer = 0 To devices(selecteddevice).WriteLength - 1
                wdata(i) = 0
            Next

            wdata(0) = 0
            wdata(1) = 200 'c8h
            wdata(2) = 0

            Dim result As Integer
            result = 404
            While (result = 404)
                result = devices(selecteddevice).WriteData(wdata)
            End While

            If result <> 0 Then
                LblStatus.Text = "Write Fail: " + result.ToString
            Else
                LblStatus.Text = "Write Success"
            End If

        End If
    End Sub

    Private Sub btnBeepContinuous_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBeepContinuous.Click
        '//For units with optional annunciator feature, sounds a beep for the desired volume, desired frequency, and desired duration.
        '//The desired frequency of the beep sound is determined by entering a 2 byte divider value, the higher this value, the lower the frequency of the sound.
        If selecteddevice <> -1 Then
            For i As Integer = 0 To devices(selecteddevice).WriteLength - 1
                wdata(i) = 0
            Next

            wdata(0) = 0
            wdata(1) = 200 'c8h
            wdata(2) = txtVol.Text
            Dim newdivider As Integer = txtDivider.Text
            wdata(3) = CByte((newdivider And &HFF))
            wdata(4) = CByte(newdivider >> 8)
            wdata(5) = 0 '0 means never turn off beep, user must manually turn it off with a volume=0 command. 1-255 is ms duration /10 so actual durations are 10ms-2550ms

            Dim result As Integer
            result = 404
            While (result = 404)
                result = devices(selecteddevice).WriteData(wdata)
            End While

            If result <> 0 Then
                LblStatus.Text = "Write Fail: " + result.ToString
            Else
                LblStatus.Text = "Write Success"
            End If

        End If
    End Sub
End Class
