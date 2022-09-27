
Imports System.Text
Public Class Form1

    Implements PIEHid32Net.PIEDataHandler
    Implements PIEHid32Net.PIEErrorHandler

    Dim devices() As PIEHid32Net.PIEDevice
    Dim selecteddevice As Integer
    Dim cbotodevice(127) As Integer 'max # of devices = 128 
    Dim wdata() As Byte = New Byte() {} 'write data buffer
    Dim saveabsolutetime As Long  'for timestamp demo

    ' This delegate enables asynchronous calls for setting
    ' the text property on a TextBox control.
    Delegate Sub SetTextCallback(ByVal [text] As String)
    Delegate Sub SetColorCallback(ByVal [color] As Color)
    Dim c As Control
    Dim thisListBox As ListBox
    Dim mouseon As Boolean = False
    Dim lastval3 As Byte 'previous value of the first button
    Dim EnumerationSuccess As Boolean
    Dim lastdata() As Byte = New Byte() {}
    Dim sliders As List(Of TrackBar) = Nothing
    Dim sliderlabels As List(Of Label) = Nothing
    Dim slidertextboxes As List(Of TextBox) = Nothing
    
    Dim donttrigger As Boolean = False
    Dim startaddress As Integer
    Dim ReadLabels As Label() = New Label(7) {}

    Public Sub HandlePIEHidData(ByVal data() As Byte, ByVal sourceDevice As PIEHid32Net.PIEDevice, ByVal perror As Integer) Implements PIEHid32Net.PIEDataHandler.HandlePIEHidData
        'data callback
        'MsgBox("The event handler caught the event.")
        If sourceDevice.Pid = devices(selecteddevice).Pid Then

            Dim output As String
            output = "Callback: " + sourceDevice.Pid.ToString + ", ID: " + selecteddevice.ToString + ", data="
            For i As Integer = 0 To sourceDevice.ReadLength - 1
                output = output + data(i).ToString + " "
            Next

            'Use thread-safe calls to windows forms controls
            thisListBox = ListBox1
            SetListBox(output)

            If (data(2) < 3) Then
                If data(5) And 1 Then
                    c = LblNumLk
                    SetText("NumLock: on")
                Else
                    c = LblNumLk
                    SetText("NumLock: off")
                End If
                If data(5) And 2 Then
                    c = LblCapsLk
                    SetText("CapsLock: on")
                Else
                    c = LblCapsLk
                    SetText("CapsLock: off")
                End If
                If data(5) And 4 Then
                    c = LblScrLk
                    SetText("ScrLock: on")
                Else
                    c = LblScrLk
                    SetText("ScrLock: off")
                End If
                c = LblUnitID
                SetText(data(1).ToString)

                'jacks
                Dim maxcols As Integer = 2
                Dim maxrows As Integer = 8

                For i As Integer = 0 To maxcols - 1
                    For j As Integer = 0 To maxrows - 1
                        Dim temp1 As Integer = CInt(Math.Pow(2, j))
                        Dim keynum As Integer = maxrows * i + j
                        Dim temp2 As Byte = CByte((data(i + 3) And temp1))
                        Dim temp3 As Byte = CByte((lastdata(i + 3) And temp1))
                        Dim state As Integer = 0

                        If temp2 <> 0 AndAlso temp3 = 0 Then
                            state = 1
                        ElseIf temp2 <> 0 AndAlso temp3 <> 0 Then
                            state = 2
                        ElseIf temp2 = 0 AndAlso temp3 <> 0 Then
                            state = 3
                        End If
                        Select Case keynum
                            Case 0
                                If state = 1 Then
                                    btnSW1R.BackColor = Color.Lime
                                ElseIf state = 3 Then
                                    btnSW1R.BackColor = SystemColors.ButtonFace
                                End If
                            Case 1
                                If state = 1 Then
                                    btnSW1L.BackColor = Color.Lime
                                ElseIf state = 3 Then
                                    btnSW1L.BackColor = SystemColors.ButtonFace
                                End If
                            Case 2
                                If state = 1 Then
                                    btnSW2R.BackColor = Color.Lime
                                ElseIf state = 3 Then
                                    btnSW2R.BackColor = SystemColors.ButtonFace
                                End If
                            Case 3
                                If state = 1 Then
                                    btnSW2L.BackColor = Color.Lime
                                ElseIf state = 3 Then
                                    btnSW2L.BackColor = SystemColors.ButtonFace
                                End If
                            Case 4
                                If state = 1 Then
                                    btnSW3R.BackColor = Color.Lime
                                ElseIf state = 3 Then
                                    btnSW3R.BackColor = SystemColors.ButtonFace
                                End If
                            Case 5
                                If state = 1 Then
                                    btnSW3L.BackColor = Color.Lime
                                ElseIf state = 3 Then
                                    btnSW3L.BackColor = SystemColors.ButtonFace
                                End If
                            Case 6
                                If state = 1 Then
                                    btnSW4R.BackColor = Color.Lime
                                ElseIf state = 3 Then
                                    btnSW4R.BackColor = SystemColors.ButtonFace
                                End If
                            Case 7
                                If state = 1 Then
                                    btnSW4L.BackColor = Color.Lime
                                ElseIf state = 3 Then
                                    btnSW4L.BackColor = SystemColors.ButtonFace
                                End If
                        End Select
                    Next
                Next
                For i As Integer = 0 To sourceDevice.ReadLength - 1
                    lastdata(i) = data(i)
                Next

                'Time Stamp
                Dim absolutetime As Long = 16777216 * data(32) + 65536 * data(33) + 256 * data(34) + data(35)  'ms
                Dim absolutetime2 As Long = absolutetime / 1000 'seconds
                c = lblAbsTime
                SetText("absolute time: " + absolutetime2.ToString + " s")
                Dim deltatime As Long = absolutetime - saveabsolutetime
                c = lblDeltaTime
                SetText("delta time: " + deltatime.ToString + " ms")
                saveabsolutetime = absolutetime
            ElseIf (data(2) = 165) Then '&HA5 Incoming DMX Data via Read Once
                Dim count As Integer = data(5) 'number bytes (addresses) to follow
                Dim thisstartaddress As Integer = data(4) * 256 + data(3) 'address of changed DMX data
                thisListBox = listBox3
                For i As Integer = 0 To count - 1
                    output = "Addr: " + (thisstartaddress + i).ToString + " = " + data(6 + i).ToString
                    SetListBox(output)
                Next
            ElseIf (data(2) = 147) Then '&H93 Incoming DMX Data via Start Notification
                Dim count As Integer = data(5) 'number of addresses to follow, always 1 in this case
                Dim address As Integer = data(4) * 256 + data(3) 'address of changed DMX data
                Dim thislabel As Integer = address - startaddress
                If ReadLabels(thislabel) IsNot Nothing Then
                    c = ReadLabels(thislabel)
                    SetText("Addr: " + address.ToString + "=" + data(6).ToString)
                End If
                'Time Stamp-Note if the time stamp is the same, change in DMX value occurred simultaneously
                Dim absolutetime As Long = 16777216 * data(32) + 65536 * data(33) + 256 * data(34) + data(35)  'ms
                Dim absolutetime2 As Long = absolutetime / 1000 'seconds
                c = lblAbsTime
                SetText("absolute time: " + absolutetime2.ToString + " s")
                Dim deltatime As Long = absolutetime - saveabsolutetime
                c = lblDeltaTime
                SetText("delta time: " + deltatime.ToString + " ms")
                saveabsolutetime = absolutetime
            ElseIf (data(2) = 163) Then '&HA3 DMX Length
                c = lblDMXLength
                SetText((data(3) + (256 * data(4))).ToString())
            ElseIf (data(2) = 146) Then '&H92 DMX Read Length
                c = lblDMXReadLength
                SetText((data(3) + (256 * data(4))).ToString())
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
        If Me.thisListBox.InvokeRequired Then
            Dim d As New SetTextCallback(AddressOf SetListBox)
            Me.Invoke(d, New Object() {[text]})
        Else
            Me.thisListBox.Items.Add(text)
            Me.thisListBox.SelectedIndex = Me.ListBox1.Items.Count - 1
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
    Public Sub SetColor(ByVal [color] As Color)

        ' InvokeRequired required compares the thread ID of the
        ' calling thread to the thread ID of the creating thread.
        ' If these threads are different, it returns true.
        If Me.c.InvokeRequired Then
            Dim d As New SetColorCallback(AddressOf SetColor)
            Me.Invoke(d, New Object() {[color]})
        Else
            Me.c.BackColor = color
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

                If devices(i).HidUsagePage = 12 And devices(i).WriteLength = 36 Then

                    Select Case devices(i).Pid
                        Case 1225
                            CboDevices.Items.Add("XC-DMX512T  (" + devices(i).Pid.ToString + ")")
                            cbotodevice(cbocount) = i
                            cbocount = cbocount + 1
                        Case 1324
                            CboDevices.Items.Add("XC-DMX512T (" + devices(i).Pid.ToString + ")")
                            cbotodevice(cbocount) = i
                            cbocount = cbocount + 1
                        Case Else
                            CboDevices.Items.Add("Unknown Device (" + devices(i).Pid.ToString + ") ")
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
            ReDim lastdata(devices(selecteddevice).ReadLength - 1)
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
            wdata(1) = 189 '&HBD
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
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ListBox1.Items.Clear()
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        selecteddevice = -1

        sliders = New List(Of TrackBar)()
        sliderlabels = New List(Of Label)()
        slidertextboxes = New List(Of TextBox)()

        For Each cl As Control In Controls

            If TypeOf cl Is Label Then
                If cl.Name.Contains("lblRead") Then
                    Dim p As Label = CType(cl, Label)
                    Dim k As String = p.Tag.ToString()
                    Dim j As Integer = Convert.ToInt32(k)
                    ReadLabels(j) = p
                End If
            End If
        Next


    End Sub

    Private Sub BtnKBreflect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnKBreflect.Click
        'send some hid codes to the textbox, these will be coming in on the native keyboard endpoint
        If selecteddevice <> -1 Then
            For i As Integer = 0 To devices(selecteddevice).WriteLength - 1
                wdata(i) = 0
            Next
            textBox1.Focus()

            wdata(0) = 0
            wdata(1) = 201 '&HC9

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
            wdata(1) = 177 '&HB1

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
            wdata(1) = 224  '&HE0
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
        'Write version, this is a 2 byte number that is available on enumeration.  You must reboot the device to see the 
        'newly written version!

        If selecteddevice <> -1 Then
            For i As Integer = 0 To devices(selecteddevice).WriteLength - 1
                wdata(i) = 0
            Next
            Me.Cursor = Cursors.WaitCursor
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

            System.Threading.Thread.Sleep(100)

            'reboot device and re-enumerate
            devices(selecteddevice).callNever = True
            wdata(0) = 0
            wdata(1) = 238 '&HEE
            wdata(2) = 0
            wdata(3) = 0

            'Dim result As Integer
            result = 404
            While (result = 404)
                result = devices(selecteddevice).WriteData(wdata)
            End While

            If result <> 0 Then
                LblStatus.Text = "Write Fail: " + result.ToString
            Else
                LblStatus.Text = "Write Success - reboot"
            End If

            'wait for reboot OR use device notification service (see http://www.piengineering.com/developer/mcode/DeviceNotification%20CSharp%20Express.zip)
            System.Threading.Thread.Sleep(5000)
            EnumerationSuccess = False
            Dim countout As Int16 = 0

            While (EnumerationSuccess = False)
                countout = countout + 1
                If (countout > 100) Then
                    Me.Cursor = Cursors.Default
                    Return
                End If
                BtnEnumerate_Click(Me, Nothing)
                System.Threading.Thread.Sleep(1000)
            End While


        End If
    End Sub


    Public Shared Function HexToBin(ByVal value As [String]) As Byte
        value = value.Trim()
        Dim temp As Integer = Convert.ToInt32(value, 16)
        Return CByte(temp)
    End Function




    Private Sub ChkSuppress_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkSuppress.CheckedChanged
        If (ChkSuppress.Checked = True) Then
            devices(selecteddevice).suppressDuplicateReports = True
        Else
            devices(selecteddevice).suppressDuplicateReports = False
        End If

    End Sub



    Private Sub BtnSetDongle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSetDongle.Click
        'Use the Dongle feature to set a 4 byte code into the device
        If selecteddevice <> -1 Then

            'This routine is done once per unit by the developer prior to sale.
            'Pick 4 numbers between 1 and 254.
            Dim K0 As Byte = 7    'pick any number between 1 and 254, 0 and 255 not allowed
            Dim K1 As Byte = 58   'pick any number between 1 and 254, 0 and 255 not allowed
            Dim K2 As Byte = 33   'pick any number between 1 and 254, 0 and 255 not allowed
            Dim K3 As Byte = 243  'pick any number between 1 and 254, 0 and 255 not allowed
            'Save these numbers, they are needed to check the key!

            For i As Integer = 0 To devices(selecteddevice).WriteLength - 1
                wdata(i) = 0
            Next
            wdata(0) = 0
            wdata(1) = 192 '&HC0
            wdata(2) = K0
            wdata(3) = K1
            wdata(4) = K2
            wdata(5) = K3

            Dim result As Integer
            result = 404
            While (result = 404)
                result = devices(selecteddevice).WriteData(wdata)
            End While

            If result <> 0 Then
                LblStatus.Text = "Write Fail: " + result.ToString
            Else
                LblStatus.Text = "Write Success - Set Dongle Key"
            End If
        End If
    End Sub

    Private Sub BtnCheckDongle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCheckDongle.Click
        'This is done within the developer's application to check for the correct
        'hardware.  The K0-K3 values must be the same as those entered in Set Key.
        If selecteddevice <> -1 Then
            'Check hardware

            'IMPORTANT turn off the callback if going so data isn't grabbed there, turn it back on later (not done here)
            devices(selecteddevice).callNever = True

            'pick 4 randomn numbers between 1 and 254
            Randomize()
            Dim N0 As Integer = CInt(Int((254 * Rnd()) + 1)) 'random number between 1 and 254
            Dim N1 As Integer = CInt(Int((254 * Rnd()) + 1)) 'random number between 1 and 254
            Dim N2 As Integer = CInt(Int((254 * Rnd()) + 1)) 'random number between 1 and 254
            Dim N3 As Integer = CInt(Int((254 * Rnd()) + 1)) 'random number between 1 and 254

            'this is the key from the Set Key
            Dim K0 As Integer = 7
            Dim K1 As Integer = 58
            Dim K2 As Integer = 33
            Dim K3 As Integer = 243

            'hash and save these for comparison later
            Dim R0 As Integer
            Dim R1 As Integer
            Dim R2 As Integer
            Dim R3 As Integer
            PIEHid32Net.PIEDevice.DongleCheck2(K0, K1, K2, K3, N0, N1, N2, N3, R0, R1, R2, R3)

            For i As Integer = 0 To devices(selecteddevice).WriteLength - 1
                wdata(i) = 0
            Next
            wdata(0) = 0
            wdata(1) = 193 '&HC1, check key command
            wdata(2) = N0
            wdata(3) = N1
            wdata(4) = N2
            wdata(5) = N3

            Dim result As Integer
            result = 404
            While (result = 404)
                result = devices(selecteddevice).WriteData(wdata)
            End While

            If result <> 0 Then
                LblStatus.Text = "Write Fail: " + result.ToString
            Else
                LblStatus.Text = "Write Success - Check Dongle Key"
            End If

            'after this write the next read with 3rd byte=193 will give 4 values which are used below for comparison

            Dim ddata(devices(selecteddevice).ReadLength) As Byte
            Dim countout As Integer = 0
            result = devices(selecteddevice).BlockingReadData(ddata, 100)
            While (result = 304 Or (result = 0 And ddata(2) <> 193))
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

            If result = 0 And ddata(2) = 193 Then
                Dim fail As Boolean = False
                If R0 <> ddata(3) Then fail = True
                If R1 <> ddata(4) Then fail = True
                If R2 <> ddata(5) Then fail = True
                If R3 <> ddata(6) Then fail = True
                If fail = False Then LblPassFail.Text = "Pass-Correct Hardware Found"
                If fail = True Then LblPassFail.Text = "Fail-Correct Hardware Not Found"
            End If
        End If
    End Sub


    Private Sub BtnDescriptor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDescriptor.Click
        If selecteddevice <> -1 Then

            'IMPORTANT turn off the callback if going so data isn't grabbed there, turn it back on later (not done here)
            Dim savecallback As Boolean
            savecallback = devices(selecteddevice).callNever
            devices(selecteddevice).callNever = True

            For i As Integer = 0 To devices(selecteddevice).WriteLength - 1
                wdata(i) = 0
            Next

            wdata(0) = 0
            wdata(1) = 214 '&HD6

            Dim result As Integer
            result = 404
            While (result = 404)
                result = devices(selecteddevice).WriteData(wdata)
            End While

            If result <> 0 Then
                LblStatus.Text = "Write Fail: " + result.ToString
            Else
                LblStatus.Text = "Write Success - Descriptor, callback off"
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
            listBox2.Items.Add("OutSize=" + ddata(6).ToString)
            listBox2.Items.Add("ReportSize=" + ddata(7).ToString)
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

            listBox2.Items.Add("Firmware Version=" + ddata(11).ToString)
            Dim temp As String = "PID=" + (ddata(13) * 256 + ddata(12)).ToString
            listBox2.Items.Add(temp)

            Dim output1 As String = "Off"
            If (ddata(17) And 1) <> 0 Then
                output1 = "On"
            End If
            listBox2.Items.Add("Output 1=" & output1)
            Dim output2 As String = "Off"
            If (ddata(17) And 2) <> 0 Then
                output2 = "On"
            End If
            listBox2.Items.Add("Output 2=" & output2)
            Dim output3 As String = "Off"
            If (ddata(17) And 4) <> 0 Then
                output3 = "On"
            End If
            listBox2.Items.Add("Output 3=" & output3)
            Dim output4 As String = "Off"
            If (ddata(17) And 8) <> 0 Then
                output3 = "On"
            End If
            listBox2.Items.Add("Output 4=" & output4)

            devices(selecteddevice).callNever = savecallback 'Turn back on callback, if it was on
        End If
    End Sub

    Private Sub btnMakeSliders_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMakeSliders.Click
        'initialize DMX - This will automatically set the DMX Length based on entered start address and span and initialize everything to 0
        'transmission begins at the moment this command is sent

        Me.Cursor = Cursors.WaitCursor

        Dim span As Integer = Convert.ToInt16(txtSpan.Text)
        Dim startaddress As Integer = Convert.ToInt16(txtStartAddress.Text)

        If (startaddress + span) > 512 Then
            span = 512 - startaddress
            txtSpan.Text = span.ToString()
        End If
        'note if startaddress+span>512 then DMX Length will be set to 0 on the next DMX Load Buffer command
        'transmission begins at the moment this command is sent
        For i As Integer = 0 To devices(selecteddevice).WriteLength - 1
            wdata(i) = 0
        Next
        wdata(0) = 0
        wdata(1) = 161 '&HA1
        wdata(2) = CByte(startaddress)
        wdata(3) = CByte(startaddress >> 8)
        wdata(4) = CByte(span)
        For i As Integer = 0 To span - 1
            wdata(5 + i) = 0
        Next

        Dim result As Integer
        result = 404
        While (result = 404)
            result = devices(selecteddevice).WriteData(wdata)
        End While
        'DMX is transmitting all 0s at this point.

        'Creates a trackbar, label, and textbox control for each "slot" or address based on start address and span.
        'When the value of the trackbar control or corresponding textbox is changed, the DMX buffer is updated with the
        'new values, see sliders_ValueChanged event.

        'remove any slider that already exist
        For i As Integer = 0 To sliders.Count - 1
            sliders(i).Dispose()
        Next

        For i As Integer = 0 To sliderlabels.Count - 1
            sliderlabels(i).Dispose()
        Next

        For i As Integer = 0 To slidertextboxes.Count - 1
            slidertextboxes(i).Dispose()
        Next

        Dim left As Integer = txtSpan.Left
        Dim top As Integer = txtSpan.Top + 70

        sliders.Clear()
        sliderlabels.Clear()
        slidertextboxes.Clear()
        For i As Integer = 0 To span - 1
            Dim thistrackbar As TrackBar = New TrackBar()
            thistrackbar.Orientation = Orientation.Vertical
            thistrackbar.Top = top
            thistrackbar.Left = left
            thistrackbar.Maximum = 255
            thistrackbar.TickFrequency = 17
            thistrackbar.Height = 104
            thistrackbar.Tag = i
            thistrackbar.Name = "tkbSlider" & i.ToString()
            thistrackbar.Value = 0
            AddHandler thistrackbar.ValueChanged, AddressOf sliders_ValueChanged

            Me.Controls.Add(thistrackbar)
            sliders.Add(thistrackbar)

            'make a label
            Dim thislabel As Label = New Label()
            thislabel.Text = (i + startaddress).ToString
            thislabel.Left = left
            thislabel.Top = top + thistrackbar.Height + 3
            thislabel.Tag = i
            thislabel.Name = "lblSlider" & i.ToString()
            thislabel.Visible = True
            thislabel.Width = 25
            thislabel.Height = 13

            Me.Controls.Add(thislabel)
            sliderlabels.Add(thislabel)

            'make manual entry textbox
            Dim thistextbox As TextBox = New TextBox()
            thistextbox.Text = "0"
            thistextbox.Left = left
            thistextbox.Top = thislabel.Top + 20
            thistextbox.Tag = i
            thistextbox.Name = "txtSlider" + i.ToString
            thistextbox.Visible = True
            thistextbox.Width = 25
            thistextbox.Height = 13
            AddHandler thistextbox.TextChanged, AddressOf slidertextboxes_TextChanged

            Me.Controls.Add(thistextbox)
            slidertextboxes.Add(thistextbox)

            left = left + 50
        Next
        Me.Cursor = Cursors.[Default]
    End Sub

    Private Sub timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Public Shared Function BinToHex(ByVal value As [Byte]) As [String]
        Dim sb As New StringBuilder("")
        sb.Append(value.ToString("X2"))
        'the 2 means 2 digits
        Return sb.ToString()
    End Function

    Private Sub chkGreen_CheckStateChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkGreen.CheckStateChanged, chkRed.CheckStateChanged, chkDO4.CheckStateChanged, chkDO3.CheckStateChanged, chkDO2.CheckStateChanged, chkDO1.CheckStateChanged
        'control leds
        If selecteddevice <> -1 Then

            Dim thisChk As CheckBox = DirectCast(sender, CheckBox)
            Dim temp As String = thisChk.Tag.ToString()
            Dim LED As Byte = Convert.ToByte(temp)
            '6=green, 7=red, 1=Digital output 1, 2=Digital output 2, 3=Digital ouput 3, 4=Digital output 4
            Dim state As Byte = 0
            state = thisChk.CheckState

            For i As Integer = 0 To devices(selecteddevice).WriteLength - 1
                wdata(i) = 0
            Next
            wdata(0) = 0
            wdata(1) = 179 '&HB3
            wdata(2) = LED
            wdata(3) = state '0=off, 1=on, 2=flash

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

    Private Sub btnSetDMXLength_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetDMXLength.Click
        'Set DMX Length manually. This may be desireable of the DMX Length was set to something higher than is currently desired.
        'Otherwise the Load DMX Buffer command will automatically increase the DMX Length based on the start address and span it receives.
        If selecteddevice <> -1 Then

            Dim length As Integer = -1

            Try
                length = Convert.ToInt16(txtSetDMXLength.Text)
                If length > 512 Then txtSetDMXLength.Text = "0"
                If length < 0 Then txtSetDMXLength.Text = "0"
            Catch
                MessageBox.Show("Invalid entry", "Error", MessageBoxButtons.OK)
                Return
            End Try

            For i As Integer = 0 To devices(selecteddevice).WriteLength - 1
                wdata(i) = 0
            Next
            wdata(0) = 0
            wdata(1) = 162 '&HA2
            wdata(2) = CByte(length)
            wdata(3) = CByte(length >> 8)

            Dim result As Integer
            result = 404
            While (result = 404)
                result = devices(selecteddevice).WriteData(wdata)
            End While

            If result <> 0 Then
                LblStatus.Text = "Write Fail: " + result.ToString
            Else
                LblStatus.Text = "Write Success - Set DMX Length"
            End If
        End If
    End Sub

    Private Sub btnGetDMXLength_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetDMXLength.Click
        If selecteddevice <> -1 Then

            For j As Integer = 0 To devices(selecteddevice).WriteLength - 1
                wdata(j) = 0
            Next

            wdata(0) = 0
            wdata(1) = 163 '&HA3
            Dim result As Integer
            result = 404
            While (result = 404)
                result = devices(selecteddevice).WriteData(wdata)
            End While

            If result <> 0 Then
                LblStatus.Text = "Write Fail: " + result.ToString
            Else
                LblStatus.Text = "Write Success - Get DMX Length"
            End If
            'results in callback
        End If
    End Sub

    Private Sub btnLoadDMXBuffer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoadDMXBuffer.Click
        'Loads the DMX buffer
        'Due to the size of the output report, only 31 addresses can be loaded at a time. 
        'Thus if one wanted to change all 512 addresses, it would require 17 (512/31 rounded up)Load DMX Buffer commands.
        'The X-keys XC-DMX512T however is designed to only call the Load DMX Buffer command when required and only change
        'an address or subset of addresses that need updating.
        'The X-keys XC-DMX512T is continuously transmitting the desired addresses up to the DMX Length.
        If selecteddevice <> -1 Then

            For j As Integer = 0 To devices(selecteddevice).WriteLength - 1
                wdata(j) = 0
            Next

            Dim startaddress As Integer = Convert.ToInt16(txtManualStartAdd.Text)
            Dim span As Integer = Convert.ToInt16(txtManualSpan.Text)
            Dim data1 As Integer = Convert.ToInt16(txtManualData1.Text)
            Dim data2 As Integer = Convert.ToInt16(txtManualData2.Text)
            Dim data3 As Integer = Convert.ToInt16(txtManualData3.Text)
            wdata(0) = 0
            wdata(1) = 161 '&HA1 Load DMX Buffer
            wdata(2) = CByte(startaddress) 'start addr lo
            wdata(3) = CByte(startaddress >> 8) 'start addr hi
            wdata(4) = CByte(span) 'span, max value 30 per WriteData message
            wdata(5) = CByte(data1) 'data 1
            wdata(6) = CByte(data2) 'data 2
            wdata(7) = CByte(data3) 'data 3
            'add more data bytes up ot 31

            Dim result As Integer
            result = 404
            While (result = 404)
                result = devices(selecteddevice).WriteData(wdata)
            End While

            If result <> 0 Then
                LblStatus.Text = "Write Fail: " + result.ToString
            Else
                LblStatus.Text = "Write Success - Load DMX Buffer"
            End If

        End If
    End Sub

    Private Sub btnDMXOff_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDMXOff.Click
        If selecteddevice <> -1 Then

            For j As Integer = 0 To devices(selecteddevice).WriteLength - 1
                wdata(j) = 0
            Next
           
            wdata(0) = 0
            wdata(1) = 164 '&HA4 Clear DMX Buffer
           
            Dim result As Integer
            result = 404
            While (result = 404)
                result = devices(selecteddevice).WriteData(wdata)
            End While

            If result <> 0 Then
                LblStatus.Text = "Write Fail: " + result.ToString
            Else
                LblStatus.Text = "Write Success - Clear DMX Buffer"
            End If

        End If
    End Sub

    Private Sub sliders_ValueChanged(ByVal sender As Object, ByVal e As EventArgs)
        'When a value for one of the trackbars change the DMX buffer is updated here. 
        'The DMX buffer is always transmitting if the DMX Length is greater than 0. The DMX Length starts at 0 on bootup of the X-keys XK-DMT512T unit.
        'When the Load DMX Buffer command is sent, the DMX Length is checked, if it is too small then it is automatically increased to
        '(start address + span). The DMX Length is never decreased since the user may have devices on upper addresses. The DMX Length
        'can be manually changed using the Set DMX Length command and read with the Get DMX Length command.

        If selecteddevice <> -1 Then
            Dim thistrackbar As TrackBar = CType(sender, TrackBar)
            Dim tag As String = thistrackbar.Tag.ToString()
            'Dim startaddress As Integer = Convert.ToInt16(txtStartAddress.Text) + Convert.ToInt16(tag)
            Dim startaddress As Integer = 0
            For i As Integer = 0 To sliderlabels.Count - 1
                Dim labeltag As String = sliderlabels(i).Tag.ToString()
                If tag = labeltag Then
                    startaddress = Convert.ToInt16(sliderlabels(i).Text)
                    Exit For
                End If
            Next

            For j As Integer = 0 To devices(selecteddevice).WriteLength - 1
                wdata(j) = 0
            Next

            wdata(0) = 0
            wdata(1) = 161 '&HA1 Load DMX Buffer
            wdata(2) = CByte(startaddress) 'start addr lo
            wdata(3) = CByte(startaddress >> 8) 'start addr hi
            wdata(4) = 1 'span
            wdata(5) = CByte(thistrackbar.Value) 'data
            Dim result As Integer = 404

            While result = 404
                result = devices(selecteddevice).WriteData(wdata)
            End While

            If result <> 0 Then
                LblStatus.Text = "Write Fail: " & result
            Else
                LblStatus.Text = "Write Success - Load DMX"
            End If

            'change the matching trigger
            For i As Integer = 0 To slidertextboxes.Count - 1

                If slidertextboxes(i).Name = "txtSlider" & tag Then
                    donttrigger = True
                    slidertextboxes(i).Text = thistrackbar.Value.ToString()
                    donttrigger = False
                End If
            Next
        End If
    End Sub

    Private Sub slidertextboxes_TextChanged(ByVal sender As Object, ByVal e As EventArgs)
        If donttrigger = True Then Return
        Dim thistextbox As TextBox = CType(sender, TextBox)
        Dim stag As String = thistextbox.Tag.ToString()
        Dim newvalue As Integer = -1

        Try
            newvalue = Convert.ToInt16(thistextbox.Text)
        Catch
            MessageBox.Show("Value must be 0-255", "Error", MessageBoxButtons.OK)
            Return
        End Try

        For i As Integer = 0 To sliders.Count - 1

            If sliders(i).Name = "tkbSlider" & stag Then
                sliders(i).Value = newvalue
            End If
        Next
    End Sub

    Private Sub Form1_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown


    End Sub

    Private Sub btnModeTrans_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModeTrans.Click
        'Configure device to transmit. Factory default is configured in transmit mode. This command only used if changing between transmit and receive modes.

        If selecteddevice <> -1 Then

            For i As Integer = 0 To devices(selecteddevice).WriteLength - 1
                wdata(i) = 0
            Next
            wdata(0) = 0
            wdata(1) = 169 '0&HA9
            wdata(2) = 0 '0=transmit, 1=receive

            Dim result As Integer
            result = 404
            While (result = 404)
                result = devices(selecteddevice).WriteData(wdata)
            End While

            If result <> 0 Then
                LblStatus.Text = "Write Fail: " + result.ToString
            Else
                LblStatus.Text = "Write Success - Configure to transmit"
            End If
        End If
    End Sub

    Private Sub btnModeRec_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModeRec.Click
        'Configure device to receive. Factory default is configured in transmit mode. This command only used if changing between transmit and receive modes.
        'To make the device default (state on bootup) configured for receive mode, click Receive under "Set default bootup mode", see btnSaveModeRec_Click.
        If selecteddevice <> -1 Then

            For i As Integer = 0 To devices(selecteddevice).WriteLength - 1
                wdata(i) = 0
            Next
            wdata(0) = 0
            wdata(1) = 169 '0&HA9
            wdata(2) = 1 '0=transmit, 1=receive

            Dim result As Integer
            result = 404
            While (result = 404)
                result = devices(selecteddevice).WriteData(wdata)
            End While

            If result <> 0 Then
                LblStatus.Text = "Write Fail: " + result.ToString
            Else
                LblStatus.Text = "Write Success - Configure to receive"
            End If
        End If
    End Sub

    Private Sub btnSaveModeTrans_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveModeTrans.Click
        'Note: Command writes to EEPROM, do not perform this command excessively.
        'Save to device the default bootup mode (transmit or receive). Does not change mode.

        If selecteddevice <> -1 Then

            For i As Integer = 0 To devices(selecteddevice).WriteLength - 1
                wdata(i) = 0
            Next
            wdata(0) = 0
            wdata(1) = 172 '0&HAC
            wdata(2) = 0 '0=transmit, 1=receive

            Dim result As Integer
            result = 404
            While (result = 404)
                result = devices(selecteddevice).WriteData(wdata)
            End While

            If result <> 0 Then
                LblStatus.Text = "Write Fail: " + result.ToString
            Else
                LblStatus.Text = "Write Success - Default bootup mode transmit"
            End If
        End If
    End Sub

    Private Sub btnSaveModeRec_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveModeRec.Click
        'Note: Command writes to EEPROM, do not perform this command excessively.
        'Save to device the default bootup mode (transmit or receive). Does not change mode.

        If selecteddevice <> -1 Then

            For i As Integer = 0 To devices(selecteddevice).WriteLength - 1
                wdata(i) = 0
            Next
            wdata(0) = 0
            wdata(1) = 172 '0&HAC
            wdata(2) = 1 '0=transmit, 1=receive

            Dim result As Integer
            result = 404
            While (result = 404)
                result = devices(selecteddevice).WriteData(wdata)
            End While

            If result <> 0 Then
                LblStatus.Text = "Write Fail: " + result.ToString
            Else
                LblStatus.Text = "Write Success - Default bootup mode receive"
            End If
        End If
    End Sub

    Private Sub btnReadOnlyDMX_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReadOnlyDMX.Click
        'Send this command to setup the XC-DMX512T to receive DMX data instead of transmit. This is the same as clicking Set mode Receive (btnModeRec).
        'If the default mode of the XC-DMX512T has been previously set to receive then this is not necessary.
        'Data can be read in 2 ways; reading 20 bytes from a specified start address (Read Once) or registering to receive notification of any changes (Start Notification).
        If selecteddevice <> -1 Then

            For i As Integer = 0 To devices(selecteddevice).WriteLength - 1
                wdata(i) = 0
            Next
            wdata(0) = 0
            wdata(1) = 171 '0&HAB
           
            Dim result As Integer
            result = 404
            While (result = 404)
                result = devices(selecteddevice).WriteData(wdata)
            End While

            If result <> 0 Then
                LblStatus.Text = "Write Fail: " + result.ToString
            Else
                LblStatus.Text = "Write Success - Configure for Read Only and clear buffers"
            End If
        End If
    End Sub

    Private Sub btnReadDMX_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReadDMX.Click
        'Sending this command will return the current values for 20 bytes of DMX data, starting at the desired start address
        'In this sample, the results will return in the callback (HandlePIEHidData), however the commented out code below shows how to read the 
        'data directly without using the callback.
        If selecteddevice <> -1 Then

            For i As Integer = 0 To devices(selecteddevice).WriteLength - 1
                wdata(i) = 0
            Next
            wdata(0) = 0
            wdata(1) = 165 '0&HA5

            Dim result As Integer
            result = 404
            While (result = 404)
                result = devices(selecteddevice).WriteData(wdata)
            End While

            If result <> 0 Then
                LblStatus.Text = "Write Fail: " + result.ToString
            Else
                LblStatus.Text = "Write Success - Read DMX data"
            End If

            ''This code demonstrates how to directly read the returned results without using the callback
            ''IMPORTANT turn off the callback if going so data isn't grabbed there, turn it back on later (not done here)
            'Dim savecallback As Boolean
            'savecallback = devices(selecteddevice).callNever
            'devices(selecteddevice).callNever = True

            'Dim ddata(devices(selecteddevice).ReadLength) As Byte
            'Dim countout As Integer = 0
            'result = devices(selecteddevice).BlockingReadData(ddata, 100)
            'While (result = 304 Or (result = 0 And ddata(2) <> 165))
            '    If result = 304 Then
            '        'no new data after 100ms, so increment countout extra
            '        countout = countout + 99
            '    End If
            '    countout = countout + 1
            '    If (countout > 1000) Then
            '        Exit While
            '    End If
            '    result = devices(selecteddevice).BlockingReadData(ddata, 100)
            'End While
            ''returned values in data
            ''ddata(1)=unit id
            ''ddata(2)=165
            ''ddata(3)=start address lo (LSB), this equals wData[2] above
            ''ddata(4)=start address hi (MSB), this equals wData[3] above
            ''ddata(5)=count, normally 20 but could be less is start address is over 491
            ''ddata(6)=start of DMX data, this first byte is usually 0
            ''ddata(7)=value of start address
            ''ddata(8)=value of start address + 1
            ''ddata(9)=value of start address + 2
            ''etc.
            ''display results in listBox3
            'Dim count As Integer
            'count = ddata(5)
            'Dim startaddress As Integer
            'startaddress = ddata(4) * 256 + ddata(3)

            'listBox3.Items.Clear()
            'Dim output As String
            'For i As Integer = 0 To count
            '    output = "Addr: " + (startaddress + i).ToString + " = " + ddata(6 + i).ToString
            '    listBox3.Items.Add(output)
            'Next

            'devices(selecteddevice).callNever = savecallback 'Turn back on callback, if it was on


        End If

    End Sub

    Private Sub btnCallbackDMX_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCallbackDMX.Click
        If selecteddevice <> -1 Then

            Dim onoff As Byte
            onoff = 0
            If (btnCallbackDMX.Text.Contains("Start") = True) Then
                onoff = 1
                btnCallbackDMX.Text = "Stop Notification"
            Else
                onoff = 0
                btnCallbackDMX.Text = "Start Notification"
            End If

            'setup to receive notification of DMX changes in desired range. This sample is looking for changes at addresses 1 to 8. If want to be notified of all DMX changes then use 0 to 511
            startaddress = 1 'this is global so know what it is when reading the data back in HandlePIEHidData
            Dim endaddress As Integer = 8

            For i As Integer = 0 To devices(selecteddevice).WriteLength - 1
                wdata(i) = 0
            Next
            wdata(0) = 0
            wdata(1) = 147 '0&H93
            wdata(2) = onoff
            wdata(3) = startaddress 'start address lo (LSB)
            wdata(4) = (startaddress >> 8) 'start address hi (MSB)
            wdata(5) = endaddress 'end address lo (LSB)
            wdata(6) = (endaddress >> 8) 'end address hi (MSB)

            'setup the labels to display results
            Dim numberofaddresses As Integer = endaddress - startaddress + 1
            For i As Integer = 0 To numberofaddresses - 1
                If ReadLabels(i) IsNot Nothing Then
                    Dim thisaddress As String = "Addr: " & (startaddress + i).ToString()
                    ReadLabels(i).Text = thisaddress
                End If
            Next

            Dim result As Integer
            result = 404
            While (result = 404)
                result = devices(selecteddevice).WriteData(wdata)
            End While

            If result <> 0 Then
                LblStatus.Text = "Write Fail: " + result.ToString
            Else
                LblStatus.Text = "Write Success - Setup DMX Notification"
            End If
        End If
    End Sub

    Private Sub btnGetDMXReadLength_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetDMXReadLength.Click
        'Get DMX read length, result will return in callback in this sample but could also read them using BlockingReadData as demonstrated in BtnDescriptor_Click
        If selecteddevice <> -1 Then

            For i As Integer = 0 To devices(selecteddevice).WriteLength - 1
                wdata(i) = 0
            Next
            wdata(0) = 0
            wdata(1) = 146 '&H92
            
            Dim result As Integer
            result = 404
            While (result = 404)
                result = devices(selecteddevice).WriteData(wdata)
            End While

            If result <> 0 Then
                LblStatus.Text = "Write Fail: " + result.ToString
            Else
                LblStatus.Text = "Write Success - Get DMX Read Length"
            End If
        End If
    End Sub

    Private Sub BtnTimeStamp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTimeStamp.Click
        'Sending this command will turn off the 4 bytes of data which assembled give the time in ms from the start of the computer
        If selecteddevice <> -1 Then
            devices(selecteddevice).callNever = False
            For i As Integer = 0 To devices(selecteddevice).WriteLength - 1
                wdata(i) = 0
            Next

            wdata(0) = 0
            wdata(1) = 210 '&HD2
            wdata(2) = 0 '0=off, 1=on

            Dim result As Integer
            result = 404
            While (result = 404)
                result = devices(selecteddevice).WriteData(wdata)
            End While

            If result <> 0 Then
                LblStatus.Text = "Write Fail: " + result.ToString
            Else
                LblStatus.Text = "Write Success - Time Stamp Off"
            End If
        End If
    End Sub

    Private Sub BtnTimeStampOn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTimeStampOn.Click
        'Sending this command will turn on the 4 bytes of data which assembled give the time in ms from the start of the computer
        If selecteddevice <> -1 Then
            devices(selecteddevice).callNever = False
            For i As Integer = 0 To devices(selecteddevice).WriteLength - 1
                wdata(i) = 0
            Next

            wdata(0) = 0
            wdata(1) = 210 '&HD2
            wdata(2) = 1 '0=off, 1=on

            Dim result As Integer
            result = 404
            While (result = 404)
                result = devices(selecteddevice).WriteData(wdata)
            End While

            If result <> 0 Then
                LblStatus.Text = "Write Fail: " + result.ToString
            Else
                LblStatus.Text = "Write Success - Time Stamp On"
            End If
        End If
    End Sub
End Class
