Public Class Form1
    Implements PIEHid32Net.PIEDataHandler
    Implements PIEHid32Net.PIEErrorHandler
    Dim devices() As PIEHid32Net.PIEDevice
    Dim selecteddevice As Integer
    Dim cbotodevice(127) As Integer 'max # of devices = 128 
    Dim wdata() As Byte = New Byte() {} 'write data buffer

    Dim saveabsolutetime As Long
    ' This delegate enables asynchronous calls for setting
    ' the text property on a TextBox control.
    Delegate Sub SetTextCallback(ByVal [text] As String)
    Dim c As Control
    Dim mouseon As Boolean = False
    Dim lastval3 As Byte 'previous value of the first button
    Dim EnumerationSuccess As Boolean

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
            SetListBox(output)

            If data(7) And 1 Then
                c = LblNumLk
                SetText("NumLock: on")

            Else
                c = LblNumLk
                SetText("NumLock: off")
            End If
            If data(7) And 2 Then
                c = LblCapsLk
                SetText("CapsLock: on")

            Else
                c = LblCapsLk
                SetText("CapsLock: off")
            End If
            If data(7) And 4 Then
                c = LblScrLk
                SetText("ScrLock: on")

            Else
                c = LblScrLk
                SetText("ScrLock: off")
            End If
            c = LblUnitID
            SetText(data(1).ToString)


            'time stamp info 4 bytes
            Dim absolutetime As Long = 16777216 * data(sourceDevice.ReadLength - 5) + 65536 * data(sourceDevice.ReadLength - 4) + 256 * data(sourceDevice.ReadLength - 3) + data(sourceDevice.ReadLength - 2) 'ms
            Dim absolutetime2 As Long = absolutetime / 1000 'in seconds
            c = lblabstime
            SetText("absolute time: " + absolutetime2.ToString + " s")
            Dim deltatime As Long = absolutetime - saveabsolutetime
            c = lbldeltatime
            SetText("delta time: " + deltatime.ToString + " ms")
            saveabsolutetime = absolutetime

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
    Private Sub BtnEnumerate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEnumerate.Click
        'do this first to get the devices connected
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
                        Case 1351
                            CboDevices.Items.Add("HD15 GPIO (" + devices(i).Pid.ToString + "=PID #1): " + i.ToString)
                            cbotodevice(cbocount) = i
                            cbocount = cbocount + 1
                        Case 1352
                            CboDevices.Items.Add("HD15 GPIO (" + devices(i).Pid.ToString + "=PID #2): " + i.ToString)
                            cbotodevice(cbocount) = i
                            cbocount = cbocount + 1
                        Case 1353
                            CboDevices.Items.Add("HD15 GPIO (" + devices(i).Pid.ToString + "=PID #3): " + i.ToString)
                            cbotodevice(cbocount) = i
                            cbocount = cbocount + 1
                        Case 1354
                            CboDevices.Items.Add("HD15 GPIO (" + devices(i).Pid.ToString + "=PID #4): " + i.ToString)
                            cbotodevice(cbocount) = i
                            cbocount = cbocount + 1
                        
                        Case Else
                            CboDevices.Items.Add("Unknown Device (" + devices(i).Pid.ToString + "): " + i.ToString)
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
            'fill in version
            LblVersion.Text = devices(selecteddevice).Version.ToString
            EnumerationSuccess = True
            btnGetInOut_Click(Me, Nothing)
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
    End Sub

   
    Private Sub BtnSetKey_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub BtnCheckKey_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ListBox1.Items.Clear()
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        selecteddevice = -1
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
            listBox2.Items.Add("Size of Eeprom MSB" + ddata(6).ToString)
            listBox2.Items.Add("Size of Eeprom LSB=" + ddata(7).ToString)
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
            Dim out1 As String = "Off"
            If (ddata(10) And 1) <> 0 Then
                out1 = "On"
            End If
            Dim out2 As String = "Off"
            If (ddata(10) And 2) <> 0 Then
                out2 = "On"
            End If
            listBox2.Items.Add("Green LED=" & greenled)
            listBox2.Items.Add("Red LED=" & redled)
            listBox2.Items.Add("Out 1=" & out1)
            listBox2.Items.Add("Out 2=" & out2)
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
            wdata(1) = 177

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

    Private Sub BtnJoyreflect_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnJoyreflect.Click
        'open up the game controller control panel to test these features, after clicking this button
        'go and make active the control panel properties and change will be seen
        If selecteddevice <> -1 Then

            For i As Integer = 0 To devices(selecteddevice).WriteLength - 1
                wdata(i) = 0
            Next

            wdata(0) = 0
            wdata(1) = 202
            wdata(2) = System.Math.Abs((Convert.ToByte(TxtJoyX.Text) Xor 127) - 255) 'X, in raw form 0 to 127 from center to right, 255 to 128 from center to left but I like to use 0-255 where 0 is max left, 255 is max right
            wdata(3) = (Convert.ToByte(TxtJoyY.Text) Xor 127) 'Y, raw data 0 to 127 from center down, 255 to 128 from center up, I convert so I can enter 0-255
            wdata(4) = (Convert.ToByte(TxtJoyZr.Text) Xor 127) 'Z rot, raw data 0 to 127 from center down, 255 to 128 from center up, I convert so I can enter 0-255
            wdata(5) = (Convert.ToByte(TxtJoyZ.Text) Xor 127) 'Z, raw data 0 to 127 from center down, 255 to 128 from center up, I convert so I can enter 0-255
            wdata(6) = (Convert.ToByte(TxtJoySlider.Text) Xor 127) 'Slider, raw data 0 to 127 from center down, 255 to 128 from center up, I convert so I can enter 0-255

            wdata(7) = Convert.ToByte(TxtJoyGame1.Text) 'buttons as a bitmap, 0-255, 1=button 1, 2=button 2, 4=button 3, etc.. ex:  3=button 1 and button 2 down
            wdata(8) = Convert.ToByte(TxtJoyGame2.Text) 'buttons as a bitmap, 0-255, 1=button 9, 2=button 10, 4=button 11, etc..
            wdata(9) = Convert.ToByte(TxtJoyGame3.Text) 'buttons as a bitmap, 0-255, 1=button 17, 2=button 18, 4=button 19, etc..
            wdata(10) = Convert.ToByte(TxtJoyGame4.Text) 'buttons as a bitmap, 0-255, 1=button 25, 2=button 26, 4=button 27, etc..

            wdata(11) = 0

            wdata(12) = Convert.ToByte(TxtJoyHat.Text) 'hat, 0-8 where 8 is no hat

            Dim result As Integer
            result = 404
            While (result = 404)
                result = devices(selecteddevice).WriteData(wdata)
            End While

            If result <> 0 Then
                LblStatus.Text = "Write Fail: " + result.ToString
            Else
                LblStatus.Text = "Write Success - joystick reflect"
            End If
        End If
    End Sub

   

    Private Sub BtnPID1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)


    End Sub

    Private Sub BtnPID2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub


    Private Sub ChkGreen_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkGreen.CheckedChanged, ChkRed.CheckedChanged, ChkOut1.CheckedChanged, ChkOut2.CheckedChanged
        'change the device's unit id
        If selecteddevice <> -1 Then

            Dim thisChk As CheckBox = DirectCast(sender, CheckBox)
            Dim temp As String = thisChk.Tag.ToString()
            Dim LED As Byte = Convert.ToByte(temp)
            '6=green, 7=red, 0=out1, 1=out2
            Dim state As Byte = 0
            If thisChk.Checked = True Then
                state = 1
                If (chkFlashLED.Checked = True) Then
                    state = 2
                End If
            End If
            

            For i As Integer = 0 To devices(selecteddevice).WriteLength - 1
                wdata(i) = 0
            Next
            wdata(0) = 0
            wdata(1) = 179
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
            wdata(1) = 238 'eeh
            wdata(2) = 0
            wdata(3) = 0

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

            'Dim result As Integer
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

    Private Sub BtnPID1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPID1.Click
        If selecteddevice <> -1 Then
            For i As Integer = 0 To devices(selecteddevice).WriteLength - 1
                wdata(i) = 0
            Next

            wdata(0) = 0
            wdata(1) = 204 'cc
            wdata(2) = 0  '0=pid1, 1=pid2, 2=pid3, 3=pid4

            Dim result As Integer
            result = 404
            While (result = 404)
                result = devices(selecteddevice).WriteData(wdata)
            End While

            If result <> 0 Then
                LblStatus.Text = "Write Fail: " + result.ToString
            Else
                LblStatus.Text = "Write Success - to PID #1"
            End If
        End If
    End Sub

    Private Sub BtnPID2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPID2.Click
        If selecteddevice <> -1 Then
            For i As Integer = 0 To devices(selecteddevice).WriteLength - 1
                wdata(i) = 0
            Next

            wdata(0) = 0
            wdata(1) = 204 'cc
            wdata(2) = 1  '0=pid1, 1=pid2, 2=pid3, 3=pid4

            Dim result As Integer
            result = 404
            While (result = 404)
                result = devices(selecteddevice).WriteData(wdata)
            End While

            If result <> 0 Then
                LblStatus.Text = "Write Fail: " + result.ToString
            Else
                LblStatus.Text = "Write Success - to PID #2"
            End If
        End If
    End Sub

    Private Sub BtnPID3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPID3.Click
        If selecteddevice <> -1 Then
            For i As Integer = 0 To devices(selecteddevice).WriteLength - 1
                wdata(i) = 0
            Next

            wdata(0) = 0
            wdata(1) = 204 'cc
            wdata(2) = 2  '0=pid1, 1=pid2, 2=pid3, 3=pid4

            Dim result As Integer
            result = 404
            While (result = 404)
                result = devices(selecteddevice).WriteData(wdata)
            End While

            If result <> 0 Then
                LblStatus.Text = "Write Fail: " + result.ToString
            Else
                LblStatus.Text = "Write Success - to PID #3"
            End If
        End If
    End Sub

    Private Sub BtnPID4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPID4.Click
        If selecteddevice <> -1 Then
            For i As Integer = 0 To devices(selecteddevice).WriteLength - 1
                wdata(i) = 0
            Next

            wdata(0) = 0
            wdata(1) = 204 'cc
            wdata(2) = 3  '0=pid1, 1=pid2, 2=pid3, 3=pid4

            Dim result As Integer
            result = 404
            While (result = 404)
                result = devices(selecteddevice).WriteData(wdata)
            End While

            If result <> 0 Then
                LblStatus.Text = "Write Fail: " + result.ToString
            Else
                LblStatus.Text = "Write Success - to PID #4"
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
            wdata(1) = 192
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
            wdata(1) = 193 'c1, check key command
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

    Private Sub BtnMousereflect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnMousereflect.Click
        If selecteddevice <> -1 Then

            For i As Integer = 0 To devices(selecteddevice).WriteLength - 1
                wdata(i) = 0
            Next

            wdata(0) = 0
            wdata(1) = 203  'cbh
            wdata(2) = Convert.ToByte(TxtMouseButtons.Text) 'Buttons; 1=Left, 2=Right, 4=Center, 8=XButton1, 16=XButton2
            wdata(3) = Convert.ToByte(TxtMouseX.Text) 'Mouse X motion. 128=0 no motion, 1-127 is right, 255-129=left, finest inc (1 and 255) to coarsest (127 and 129).
            wdata(4) = Convert.ToByte(TxtMouseY.Text) 'Mouse Y motion. 128=0 no motion, 1-127 is down, 255-129=up, finest inc (1 and 255) to coarsest (127 and 129).
            wdata(5) = Convert.ToByte(TxtWheel.Text) 'Wheel Y. 128=0 no motion, 1-127 is up, 255-129=down, finest inc (1 and 255) to coarsest (127 and 129).

            Dim result As Integer
            result = 404
            While (result = 404)
                result = devices(selecteddevice).WriteData(wdata)
            End While

            'now send all 0s
            wdata(0) = 0
            wdata(1) = 203  'cbh
            wdata(2) = 0 'buttons
            wdata(3) = 0 'X
            wdata(4) = 0 'Y
            wdata(5) = 0 'Wheel Y

            result = 404
            While (result = 404)
                result = devices(selecteddevice).WriteData(wdata)
            End While

            If result <> 0 Then
                LblStatus.Text = "Write Fail: " + result.ToString
            Else
                LblStatus.Text = "Write Success - Mouse Reflector"
            End If
        End If
    End Sub

    Private Sub btnSetInOut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetInOut.Click
        If CboDevices.SelectedIndex <> -1 Then

            Dim config1 As Byte = 255 '0=output, 1=input for pins 1-4
            Dim config2 As Byte = 255 '0=output, 1=input for pins 5-12
            Dim inputconfig1 As Byte = 0 '0=resistive pull up (short to ground), 1=resistive pull down (drive high) for pins 1-4
            Dim inputconfig2 As Byte = 0 '0=resistive pull up (short to ground), 1=resistive pull down (drive high) for pins 5-12

            If rb1O.Checked = True Then
                config1 = CByte((config1 And Not 1))
            Else
                If rb1ID.Checked = True Then
                    inputconfig1 = CByte((inputconfig1 Or 1))
                End If
            End If
            If rb2O.Checked = True Then
                config1 = CByte((config1 And Not 2))
            Else
                If rb2ID.Checked = True Then
                    inputconfig1 = CByte((inputconfig1 Or 2))
                End If
            End If
            If rb3O.Checked = True Then
                config1 = CByte((config1 And Not 4))
            Else
                If rb3ID.Checked = True Then
                    inputconfig1 = CByte((inputconfig1 Or 4))
                End If
            End If
            If rb4O.Checked = True Then
                config1 = CByte((config1 And Not 8))
            Else
                If rb4ID.Checked = True Then
                    inputconfig1 = CByte((inputconfig1 Or 8))
                End If
            End If

            
            If rb5O.Checked = True Then
                config2 = CByte((config2 And Not 1))
            Else
                If rb5ID.Checked = True Then
                    inputconfig2 = CByte((inputconfig2 Or 1))
                End If
            End If
            If rb6O.Checked = True Then
                config2 = CByte((config2 And Not 2))
            Else
                If rb6ID.Checked = True Then
                    inputconfig2 = CByte((inputconfig2 Or 2))
                End If
            End If
            If rb7O.Checked = True Then
                config2 = CByte((config2 And Not 4))
            Else
                If rb7ID.Checked = True Then
                    inputconfig2 = CByte((inputconfig2 Or 4))
                End If
            End If
            If rb8O.Checked = True Then
                config2 = CByte((config2 And Not 8))
            Else
                If rb8ID.Checked = True Then
                    inputconfig2 = CByte((inputconfig2 Or 8))
                End If
            End If
            If rb11O.Checked = True Then
                config2 = CByte((config2 And Not 16))
            Else
                If rb11ID.Checked = True Then
                    inputconfig2 = CByte((inputconfig2 Or 16))
                End If
            End If
            If rb12O.Checked = True Then
                config2 = CByte((config2 And Not 32))
            Else
                If rb12ID.Checked = True Then
                    inputconfig2 = CByte((inputconfig2 Or 32))
                End If
            End If


            For j As Integer = 0 To devices(selecteddevice).WriteLength - 1
                wdata(j) = 0
            Next
            'this sample sets everything tp output
            wdata(0) = 0
            wdata(1) = 160 'A0
            wdata(2) = config1 'pins 1, 2, 3, 4 MSB 0-0-0-0-4-3-2-1 LSB 0=output, 1=input
            wdata(3) = config2 'pins 5, 6, 7, 8, 11, 12 MSB 0-0-12-11-8-7-6-5 LSB 0=output, 1=input
            wdata(4) = inputconfig1 '//pins 1, 2, 3, 4 MSB 0-0-0-0-4-3-2-1 LSB 0=resistive pull up, 1=resistive pull down for inputs
            wdata(5) = inputconfig2 '//pins 5, 6, 7, 8, 11, 12 MSB 0-0-12-11-8-7-6-5 LSB 0=resistive pull up, 1=resistive pull down for inputs

            Dim result As Integer = 404


            While (result = 404)
                result = devices(selecteddevice).WriteData(wdata)
            End While

            If result <> 0 Then
                LblStatus.Text = "Write Fail: " + result.ToString
            Else
                LblStatus.Text = "Write Success - Set GPIO"
            End If
        End If
    End Sub

    Private Sub btnSaveInOut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveInOut.Click
        If CboDevices.SelectedIndex <> -1 Then
            'do nothing if not enumerated
            For j As Integer = 0 To devices(selecteddevice).WriteLength - 1
                wdata(j) = 0
            Next

            wdata(0) = 0
            wdata(1) = 162 'A2
            Dim result As Integer = 404

            While result = 404
                result = devices(selecteddevice).WriteData(wdata)
            End While
            If result <> 0 Then
                LblStatus.Text = "Write Fail: " + result
            Else
                LblStatus.Text = "Write Success - Save GPIO"
            End If
        End If


    End Sub

    Private Sub btnGetInOut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetInOut.Click
        If CboDevices.SelectedIndex <> -1 Then
            Dim savecallbackstate As Boolean = devices(selecteddevice).callNever
            devices(selecteddevice).callNever = True

            For j As Integer = 0 To devices(selecteddevice).WriteLength - 1
                wdata(j) = 0
            Next
            wdata(0) = 0
            wdata(1) = 161
            '0xa1
            Dim result As Integer = 404

            While result = 404
                result = devices(selecteddevice).WriteData(wdata)
            End While
            If result <> 0 Then
                LblStatus.Text = "Write Fail: " + result
            Else
                LblStatus.Text = "Write Success-Read GPIO configuration"
            End If

            Dim data As Byte() = Nothing
            Dim countout As Integer = 0
            data = New Byte(79) {}
            data(1) = 0
            Dim ret As Integer = devices(selecteddevice).BlockingReadData(data, 100)
            While (ret = 0 AndAlso data(2) <> 161) OrElse ret = 304
                If ret = 304 Then
                    ' Didn't get any data for 100ms, increment the countout extra
                    countout += 99
                End If
                countout += 1

                If countout > 1000 Then
                    'increase this if have to check more than once
                    'System.Media.SystemSounds.Beep.Play();
                    Exit While
                End If
                ret = devices(selecteddevice).BlockingReadData(data, 100)
            End While

            listBox3.Items.Clear()
            'data[6] is Pins 1, 2, 3, 4 and data[8] gives Pins 1, 2, 3, 4 input resistive pull up or pull down where 0=resistive pull up (short to ground), 1=resistive pull down (drive high)
            Dim thispin As String = ""
            Dim val2 As Byte = CByte((data(6) And 1))
            Dim val3 As Byte = CByte((data(8) And 1))
            If val2 = 0 Then
                thispin = "1 = Output"
                rb11O.Checked = True
            Else
                If (val3 = 0) Then
                    thispin = "1 = Input - STG"
                    rb1ID.Checked = True
                Else
                    thispin = "1 = Input - DH"
                    rb1I.Checked = True
                End If
            End If
            listBox3.Items.Add(thispin)
            val2 = CByte((data(6) And 2))
            val3 = CByte((data(8) And 2))
            If val2 = 0 Then
                thispin = "2 = Output"
                rb2O.Checked = True
            Else
                If (val3 = 0) Then
                    thispin = "2 = Input - STG"
                    rb2I.Checked = True
                Else
                    thispin = "2 = Input - DH"
                    rb2ID.Checked = True
                End If
            End If
            listBox3.Items.Add(thispin)
            val2 = CByte((data(6) And 4))
            val3 = CByte((data(8) And 4))
            If val2 = 0 Then
                thispin = "3 = Output"
                rb3O.Checked = True
            Else
                If (val3 = 0) Then
                    thispin = "3 = Input - STG"
                    rb3ID.Checked = True
                Else
                    thispin = "3 = Input - DH"
                    rb3I.Checked = True
                End If
            End If
            listBox3.Items.Add(thispin)
            val2 = CByte((data(6) And 8))
            val3 = CByte((data(8) And 8))
            If val2 = 0 Then
                thispin = "4 = Output"
                rb4O.Checked = True
            Else
                If (val3 = 0) Then
                    thispin = "4 = Input - STG"
                    rb4ID.Checked = True
                Else
                    thispin = "4 = input - DH"
                    rb4I.Checked = True
                End If
            End If
            listBox3.Items.Add(thispin)
            'data[7] is Pins 5, 6, 7, 8, 11, 12 and data[9] gives Pins 5, 6, 7, 8, 11, 12 input resistive pull up or pull down where 0=resistive pull up (short to ground), 1=resistive pull down (drive high)
            val2 = CByte((data(7) And 1))
            val3 = CByte((data(9) And 1))
            If val2 = 0 Then
                thispin = "5 = Output"
                rb5O.Checked = True
            Else
                If (val3 = 0) Then
                    thispin = "5 = Input - STG"
                    rb5ID.Checked = True
                Else
                    thispin = "5 = input - DH"
                    rb5I.Checked = True
                End If
            End If
            listBox3.Items.Add(thispin)
            val2 = CByte((data(7) And 2))
            val3 = CByte((data(9) And 2))
            If val2 = 0 Then
                thispin = "6 = Output"
                rb6O.Checked = True
            Else
                If (val3 = 0) Then
                    thispin = "6 = Input - STG"
                    rb6ID.Checked = True
                Else
                    thispin = "6 = Input - DH"
                    rb6I.Checked = True
                End If
            End If
            listBox3.Items.Add(thispin)
            val2 = CByte((data(7) And 4))
            val3 = CByte((data(9) And 4))
            If val2 = 0 Then
                thispin = "7 = Output"
                rb7O.Checked = True
            Else
                If (val3 = 0) Then
                    thispin = "7 = Input - STG"
                    rb7ID.Checked = True
                Else
                    thispin = "7 = Input - DH"
                    rb7I.Checked = True
                End If
            End If
            listBox3.Items.Add(thispin)
            val2 = CByte((data(7) And 8))
            val3 = CByte((data(9) And 8))
            If val2 = 0 Then
                thispin = "8 = Output"
                rb8O.Checked = True
            Else
                If ((data(9) And 8) = 0) Then
                    thispin = "8 = Input - STG"
                    rb8ID.Checked = True
                Else
                    thispin = "8 = Input - DH"
                    rb8I.Checked = True
                End If
            End If
            listBox3.Items.Add(thispin)
            val2 = CByte((data(7) And 16))
            val3 = CByte((data(9) And 16))
            If val2 = 0 Then
                thispin = "11 = Output"
                rb11O.Checked = True
            Else
                If (val3 = 0) Then
                    thispin = "11 = Input - STG"
                    rb11ID.Checked = True
                Else
                    thispin = "11 = Input - DH"
                    rb11I.Checked = True
                End If
            End If
            listBox3.Items.Add(thispin)
            val2 = CByte((data(7) And 32))
            val3 = CByte((data(9) And 32))
            If val2 = 0 Then
                thispin = "12 = Output"
                rb12O.Checked = True
            Else
                If ((data(9) And 32) = 0) Then
                    thispin = "12 = Input - STG"
                    rb12ID.Checked = True
                Else
                    thispin = "12 = input - DH"
                    rb12I.Checked = True
                End If
            End If

            listBox3.Items.Add(thispin)
            devices(selecteddevice).callNever = savecallbackstate
        End If
    End Sub

    Private Sub btnGetStates_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetStates.Click
        If CboDevices.SelectedIndex <> -1 Then
            'do nothing if not enumerated
            Dim savecallbackstate As Boolean = devices(selecteddevice).callNever
            devices(selecteddevice).callNever = True

            For j As Integer = 0 To devices(selecteddevice).WriteLength - 1
                wdata(j) = 0
            Next

            wdata(0) = 0
            wdata(1) = 174 '0ae return state of the outputs
            Dim result As Integer = 404

            While result = 404
                result = devices(selecteddevice).WriteData(wdata)
            End While
            If result <> 0 Then
                LblStatus.Text = "Write Fail: " + result
            Else
                LblStatus.Text = "Write Success - Save GPIO"
            End If

            Dim data As Byte() = Nothing
            Dim countout As Integer = 0
            data = New Byte(79) {}
            data(1) = 0
            Dim ret As Integer = devices(selecteddevice).BlockingReadData(data, 100)
            While (ret = 0 AndAlso data(2) <> 174) OrElse ret = 304
                If ret = 304 Then
                    ' Didn't get any data for 100ms, increment the countout extra
                    countout += 99
                End If
                countout += 1

                If countout > 1000 Then
                    'increase this if have to check more than once
                    'System.Media.SystemSounds.Beep.Play();
                    Exit While
                End If
                ret = devices(selecteddevice).BlockingReadData(data, 100)
            End While

            listBox4.Items.Clear()
            'data[3] : 0
            'data[4] : 0
            'data[5] : Pins 13, 14 and green and red leds
            'data[6] : Pins 1, 2, 3, 4
            'data[7] : Pins 5, 6, 7, 8, 11, 12

            Dim thispin As String = ""
            Dim val2 As Byte = CByte((data(5) And 1))
            If val2 = 0 Then
                thispin = "13 = off"
            Else
                thispin = "13 = on"
            End If
            listBox4.Items.Add(thispin)
            val2 = CByte((data(5) And 2))
            If val2 = 0 Then
                thispin = "14 = off"
            Else
                thispin = "14 = on"
            End If
            listBox4.Items.Add(thispin)
            val2 = CByte((data(5) And 64))
            If val2 = 0 Then
                thispin = "G = off"
                'Green LED
            Else
                thispin = "G = on"
            End If
            listBox4.Items.Add(thispin)
            val2 = CByte((data(5) And 128))
            If val2 = 0 Then
                thispin = "R = off"
                'Red LED
            Else
                thispin = "R = on"
            End If

            listBox4.Items.Add(thispin)
            'data[6] is Pins 1, 2, 3, 4
            val2 = CByte((data(6) And 1))
            If val2 = 0 Then
                thispin = "1 = off"
            Else
                thispin = "1 = on"
            End If
            listBox4.Items.Add(thispin)
            val2 = CByte((data(6) And 2))
            If val2 = 0 Then
                thispin = "2 = off"
            Else
                thispin = "2 = on"
            End If
            listBox4.Items.Add(thispin)
            val2 = CByte((data(6) And 4))
            If val2 = 0 Then
                thispin = "3 = off"
            Else
                thispin = "3 = on"
            End If

            listBox4.Items.Add(thispin)
            val2 = CByte((data(6) And 8))
            If val2 = 0 Then
                thispin = "4 = off"
            Else
                thispin = "4 = on"
            End If
            listBox5.Items.Add(thispin)
            'data[7] is pins 5, 6, 7, 8, 11, 12
            val2 = CByte((data(7) And 1))
            If val2 = 0 Then
                thispin = "5 = off"
            Else
                thispin = "5 = on"
            End If
            listBox4.Items.Add(thispin)
            val2 = CByte((data(7) And 2))
            If val2 = 0 Then
                thispin = "6 = off"
            Else
                thispin = "6 = on"
            End If
            listBox4.Items.Add(thispin)
            val2 = CByte((data(7) And 4))
            If val2 = 0 Then
                thispin = "7 = off"
            Else
                thispin = "7 = on"
            End If
            listBox4.Items.Add(thispin)
            val2 = CByte((data(7) And 8))

            If val2 = 0 Then
                thispin = "8 = off"
            Else
                thispin = "8 = on"
            End If
            listBox4.Items.Add(thispin)
            val2 = CByte((data(7) And 16))
            If val2 = 0 Then
                thispin = "11 = off"
            Else
                thispin = "11 = on"
            End If
            listBox4.Items.Add(thispin)
            val2 = CByte((data(7) And 32))
            If val2 = 0 Then
                thispin = "12 = off"
            Else
                thispin = "12 = on"
            End If
            listBox4.Items.Add(thispin)
            'end of on/off state


            'Flash state
            For j As Integer = 0 To devices(selecteddevice).WriteLength - 1
                wdata(j) = 0
            Next

            wdata(0) = 0
            wdata(1) = 175 '0xaf return flash state of the outputs
            result = 404

            While result = 404
                result = devices(selecteddevice).WriteData(wdata)
            End While
            If result <> 0 Then
                LblStatus.Text = "Write Fail: " + result
            Else
                LblStatus.Text = "Write Success - Save GPIO"
            End If


            countout = 0
            data = New Byte(79) {}
            data(1) = 0
            ret = devices(selecteddevice).BlockingReadData(data, 100)
            While (ret = 0 AndAlso data(2) <> 174) OrElse ret = 304
                If ret = 304 Then
                    ' Didn't get any data for 100ms, increment the countout extra
                    countout += 99
                End If
                countout += 1

                If countout > 1000 Then
                    'increase this if have to check more than once
                    'System.Media.SystemSounds.Beep.Play();
                    Exit While
                End If
                ret = devices(selecteddevice).BlockingReadData(data, 100)
            End While

            listBox5.Items.Clear()
            'data[3] : Pins 13, 14 and green and red leds
            'data[4] : Flash frequency
            'data[5] : Pins 13, 14 and green and red leds
            'data[6] : Pins 1, 2, 3, 4
            'data[7] : Pins 5, 6, 7, 8, 11, 12

            thispin = ""
            val2 = CByte((data(5) And 1))
            If val2 = 0 Then
                thispin = "13 = off"
            Else
                thispin = "13 = flash"
            End If
            listBox5.Items.Add(thispin)
            val2 = CByte((data(5) And 2))
            If val2 = 0 Then
                thispin = "14 = off"
            Else
                thispin = "14 = flash"
            End If
            listBox5.Items.Add(thispin)
            val2 = CByte((data(5) And 64))
            If val2 = 0 Then
                thispin = "G = off"
                'Green LED
            Else
                thispin = "G = flash"
            End If
            listBox5.Items.Add(thispin)
            val2 = CByte((data(5) And 128))
            If val2 = 0 Then
                thispin = "R = off"
                'Red LED
            Else
                thispin = "R = flash"
            End If

            listBox5.Items.Add(thispin)
            'data[6] is Pins 1, 2, 3, 4
            val2 = CByte((data(6) And 1))
            If val2 = 0 Then
                thispin = "1 = off"
            Else
                thispin = "1 = flash"
            End If
            listBox5.Items.Add(thispin)
            val2 = CByte((data(6) And 2))
            If val2 = 0 Then
                thispin = "2 = off"
            Else
                thispin = "2 = Flash"
            End If
            listBox5.Items.Add(thispin)
            val2 = CByte((data(6) And 4))
            If val2 = 0 Then
                thispin = "3 = off"
            Else
                thispin = "3 = flash"
            End If

            listBox5.Items.Add(thispin)
            val2 = CByte((data(6) And 8))
            If val2 = 0 Then
                thispin = "4 = off"
            Else
                thispin = "4 = flash"
            End If
            listBox5.Items.Add(thispin)
            'data[7] is pins 5, 6, 7, 8, 11, 12
            val2 = CByte((data(7) And 1))
            If val2 = 0 Then
                thispin = "5 = off"
            Else
                thispin = "5 = flash"
            End If
            listBox5.Items.Add(thispin)
            val2 = CByte((data(7) And 2))
            If val2 = 0 Then
                thispin = "6 = off"
            Else
                thispin = "6 = flash"
            End If
            listBox5.Items.Add(thispin)
            val2 = CByte((data(7) And 4))
            If val2 = 0 Then
                thispin = "7 = off"
            Else
                thispin = "7 = flash"
            End If
            listBox5.Items.Add(thispin)
            val2 = CByte((data(7) And 8))

            If val2 = 0 Then
                thispin = "8 = off"
            Else
                thispin = "8 = flash"
            End If
            listBox5.Items.Add(thispin)
            val2 = CByte((data(7) And 16))
            If val2 = 0 Then
                thispin = "11 = off"
            Else
                thispin = "11 = flash"
            End If
            listBox5.Items.Add(thispin)
            val2 = CByte((data(7) And 32))
            If val2 = 0 Then
                thispin = "12 = off"
            Else
                thispin = "12 = flash"
            End If
            listBox4.Items.Add(thispin)
            'end of on/off state

            devices(selecteddevice).callNever = savecallbackstate


        End If
    End Sub

    Private Sub checkBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles checkBox1.CheckedChanged, checkBox9.CheckedChanged, checkBox8.CheckedChanged, checkBox7.CheckedChanged, checkBox6.CheckedChanged, checkBox5.CheckedChanged, checkBox4.CheckedChanged, checkBox3.CheckedChanged, checkBox2.CheckedChanged, checkBox10.CheckedChanged
        Dim thischeckbox As CheckBox = DirectCast(sender, CheckBox)
        Dim tags As String = thischeckbox.Tag.ToString()
        Dim s As Byte = 0
        If thischeckbox.Checked = True Then
            s = 1
            If checkBox11.Checked = True Then
                s = 2
            End If
        End If

        For j As Integer = 0 To devices(selecteddevice).WriteLength - 1
            wdata(j) = 0
        Next

        wdata(0) = 0
        wdata(1) = 181
        '0xb5
        wdata(2) = Convert.ToByte(thischeckbox.Tag)
        '1=pin 1, 2=pin 2, 3=pin 3, 4=pin 4, 5=pin 5, 6=pin 6, 7=pin 7, 8=pin 8, 11=pin 11, 12=pin 12
        wdata(3) = s
        ' Convert.ToByte(thischeckbox.Checked); 
        Dim result As Integer = 404

        While result = 404
            result = devices(selecteddevice).WriteData(wdata)
        End While

    End Sub

   
    Private Sub BtnSetFlash_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSetFlash.Click
        If CboDevices.SelectedIndex <> -1 Then
            'do nothing if not enumerated
            For j As Integer = 0 To devices(selecteddevice).WriteLength - 1
                wdata(j) = 0
            Next

            wdata(0) = 0
            wdata(1) = 180
            ' 0xb4
            wdata(2) = CByte((Convert.ToInt16(TxtFlashFreq.Text)))

            Dim result As Integer = 404
            While result = 404
                result = devices(selecteddevice).WriteData(wdata)
            End While

            If result <> 0 Then
                LblStatus.Text = "Write Fail: " + result
            Else
                LblStatus.Text = "Write Success - Set Flash Frequency"
            End If
        End If

    End Sub
End Class
