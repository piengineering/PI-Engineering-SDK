Imports System.Text
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
    Delegate Sub SetClearCallback()
    Dim c As Control
    Dim thisListBox As ListBox

    Dim lastval3 As Byte 'previous value of the first button
    Dim EnumerationSuccess As Boolean

    Dim lastdata() As Byte = New Byte() {}

    Dim RxString As String
    Dim RxByte As Integer




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
            thisListBox = ListBox1
            SetListBox(output)
            If (data(2) < 4) Then
                'Unit ID
                c = LblUnitID
                SetText(data(1).ToString)

                If (data(2) < 4) Then 'general incoming data 

                    'Program Switch
                    Dim val2 As Byte = CByte(data(2) And 1)
                    If val2 = 0 Then
                        c = Me.LblSwitchPos
                        Me.SetText("switch up")
                    Else
                        c = Me.LblSwitchPos
                        Me.SetText("switch down")
                    End If

                    'Keyboard states
                    'check the keyboard state byte 
                    val2 = CByte(data(8) And 1)
                    If val2 = 0 Then
                        c = Me.LblNumLk
                        Me.SetText("NumLock: off")
                    Else
                        c = Me.LblNumLk
                        Me.SetText("NumLock: on")
                    End If
                    val2 = CByte(data(8) And 2)
                    If val2 = 0 Then
                        c = Me.LblCapsLk
                        Me.SetText("CapsLock: off")
                    Else
                        c = Me.LblCapsLk
                        Me.SetText("CapsLock: on")
                    End If
                    val2 = CByte(data(8) And 4)
                    If val2 = 0 Then
                        c = Me.LblScrLk
                        Me.SetText("ScrLock: off")
                    Else
                        c = Me.LblScrLk
                        Me.SetText("ScrLock: on")
                    End If

                   
                    If (data(2) < 2) Then

                        'Buttons
                        Dim maxcols As Integer = 5 'number of columns of Xkeys digital button data, labeled "Keys" in P.I. Engineering SDK - General Incoming Data Input Report
                        Dim maxrows As Integer = 8 'constant, 8 bits per byte
                        c = LblButtons
                        Dim buttonsdown As String = "Buttons: "
                        SetText(buttonsdown)
                        For i As Integer = 0 To maxcols - 1 'loop through digital button bytes 

                            For j As Integer = 0 To maxrows - 1 'loop through each bit in the button byte
                                Dim temp1 As Integer = CInt(Math.Pow(2, j)) '1, 2, 4, 8, 16, 32, 64, 128
                                Dim keynum As Integer = 8 * i + j 'using key numbering in sdk; column 1 = 0,1,2... column 2 = 8,9,10... column 3 = 16,17,18... column 4 = 24,25,26... etc
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
                                        buttonsdown = buttonsdown & keynum.ToString() & " "
                                        SetText(buttonsdown)
                                    Case 2
                                        buttonsdown = buttonsdown & keynum.ToString() & " "
                                        SetText(buttonsdown)
                                    Case 3
                                End Select
                                'Perform action based on key number, consult P.I. Engineering SDK documentation for the key numbers
                                Select Case keynum
                                    Case 0

                                        If state = 1 Then
                                        ElseIf state = 3 Then
                                        End If

                                    Case 1

                                        If state = 1 Then
                                        ElseIf state = 3 Then
                                        End If
                                        'End of column
                                    Case 2

                                        If state = 1 Then
                                        ElseIf state = 3 Then
                                        End If

                                    Case 3

                                        If state = 1 Then
                                        ElseIf state = 3 Then
                                        End If
                                        'End of column
                                    Case 4

                                        If state = 1 Then
                                        ElseIf state = 3 Then
                                        End If

                                    Case 5

                                        If state = 1 Then
                                        ElseIf state = 3 Then
                                        End If
                                        'End of column
                                    Case 6

                                        If state = 1 Then
                                        ElseIf state = 3 Then
                                        End If

                                    Case 7

                                        If state = 1 Then
                                        ElseIf state = 3 Then
                                        End If
                                        'End of column
                                    Case 8

                                        If state = 1 Then
                                        ElseIf state = 3 Then
                                        End If

                                    Case 9

                                        If state = 1 Then
                                        ElseIf state = 3 Then
                                        End If
                                        'End of column
                                    Case 10

                                        If state = 1 Then
                                        ElseIf state = 3 Then
                                        End If

                                    Case 11

                                        If state = 1 Then
                                        ElseIf state = 3 Then
                                        End If
                                        'End of column
                                    Case 12

                                        If state = 1 Then
                                        ElseIf state = 3 Then
                                        End If

                                    Case 13

                                        If state = 1 Then
                                        ElseIf state = 3 Then
                                        End If
                                        'End of column
                                    Case 14

                                        If state = 1 Then
                                        ElseIf state = 3 Then
                                        End If

                                    Case 15

                                        If state = 1 Then
                                        ElseIf state = 3 Then
                                        End If
                                        'End of column
                                    Case 16

                                        If state = 1 Then
                                        ElseIf state = 3 Then
                                        End If

                                    Case 17

                                        If state = 1 Then
                                        ElseIf state = 3 Then
                                        End If
                                        'End of column
                                    Case 18

                                        If state = 1 Then
                                        ElseIf state = 3 Then
                                        End If

                                    Case 19

                                        If state = 1 Then
                                        ElseIf state = 3 Then
                                        End If
                                        'End of column
                                    Case 20

                                        If state = 1 Then
                                        ElseIf state = 3 Then
                                        End If

                                    Case 21

                                        If state = 1 Then
                                        ElseIf state = 3 Then
                                        End If
                                        'End of column
                                    Case 22

                                        If state = 1 Then
                                        ElseIf state = 3 Then
                                        End If

                                    Case 23

                                        If state = 1 Then
                                        ElseIf state = 3 Then
                                        End If
                                        'End of column
                                    Case 24

                                        If state = 1 Then
                                        ElseIf state = 3 Then
                                        End If

                                    Case 25

                                        If state = 1 Then
                                        ElseIf state = 3 Then
                                        End If
                                        'End of column
                                    Case 26

                                        If state = 1 Then
                                        ElseIf state = 3 Then
                                        End If

                                    Case 27

                                        If state = 1 Then
                                        ElseIf state = 3 Then
                                        End If
                                        'End of column
                                    Case 28

                                        If state = 1 Then
                                        ElseIf state = 3 Then
                                        End If

                                    Case 29

                                        If state = 1 Then
                                        ElseIf state = 3 Then
                                        End If
                                        'End of column
                                    Case 30

                                        If state = 1 Then
                                        ElseIf state = 3 Then
                                        End If

                                    Case 31

                                        If state = 1 Then
                                        ElseIf state = 3 Then
                                        End If
                                        'End of column

                                    Case 32

                                        If state = 1 Then
                                        ElseIf state = 3 Then
                                        End If

                                    Case 33

                                        If state = 1 Then
                                        ElseIf state = 3 Then
                                        End If
                                        'End of column

                                    Case 34

                                        If state = 1 Then
                                        ElseIf state = 3 Then
                                        End If

                                    Case 35

                                        If state = 1 Then
                                        ElseIf state = 3 Then
                                        End If
                                        'End of column

                                    Case 36

                                        If state = 1 Then
                                        ElseIf state = 3 Then
                                        End If

                                    Case 37

                                        If state = 1 Then
                                        ElseIf state = 3 Then
                                        End If
                                        'End of column

                                    Case 38

                                        If state = 1 Then
                                        ElseIf state = 3 Then
                                        End If

                                    Case 39

                                        If state = 1 Then
                                        ElseIf state = 3 Then
                                        End If
                                        'End of column

                                End Select
                            Next
                        Next

                        For i As Integer = 0 To sourceDevice.ReadLength - 1
                            lastdata(i) = data(i)
                        Next
                        'end buttons
                    End If

                  
                End If
                For i As Integer = 0 To sourceDevice.ReadLength - 1
                    lastdata(i) = data(i)
                Next

            ElseIf (data(2) = 174) Then 'backlight states
                
            ElseIf (data(2) = 175) Then 'backlight flash states
               
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
            Me.thisListBox.SelectedIndex = Me.thisListBox.Items.Count - 1
        End If
    End Sub
    'for threadsafe setting of Windows Forms control
    Private Sub ClearListBox()
        ' InvokeRequired required compares the thread ID of the
        ' calling thread to the thread ID of the creating thread.
        ' If these threads are different, it returns true.
        If Me.thisListBox.InvokeRequired Then
            Dim d As New SetClearCallback(AddressOf ClearListBox)
            Me.Invoke(d, New Object() {})
        Else
            Me.thisListBox.Items.Clear()
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

                If devices(i).HidUsagePage = 12 And devices(i).WriteLength = 36 Then

                    CboDevices.Items.Add(devices(i).ProductString + " (" + devices(i).Pid.ToString + "=PID #1)")
                    cbotodevice(cbocount) = i
                    cbocount = cbocount + 1

                    devices(i).SetupInterface()
                    devices(i).suppressDuplicateReports = ChkSuppress.Checked
                    EnableAllControls()

                Else
                    If (devices(i).Pid = 1292) Then
                        CboDevices.Items.Add("Bootload device (" + devices(i).Pid.ToString + ")")
                        cbotodevice(cbocount) = i
                        cbocount = cbocount + 1
                        DisableAllControls(devices(i).Pid)
                        MessageBox.Show("Device in bootloader mode. Contact P.I. Engineering.")
                 
                    End If

                End If

            Next
        End If

        If CboDevices.Items.Count > 0 Then
            CboDevices.SelectedIndex = 0
            selecteddevice = cbotodevice(CboDevices.SelectedIndex)
            ReDim wdata(devices(selecteddevice).WriteLength - 1) 'initialize length of write buffer
            ReDim lastdata(devices(selecteddevice).ReadLength - 1)
            'fill in version, note this is NOTE the firmware version which is given in the descriptor
           
            LblStatus.Text = devices(selecteddevice).ProductString + " found"

            EnumerationSuccess = True
            Me.Cursor = Cursors.Default
        End If
    End Sub
    Private Sub EnableAllControls()
        For Each cl As Control In Controls
            If cl.Name <> "BtnEnumerate" Then

                cl.Enabled = True
            End If
        Next
    End Sub
    Private Sub DisableAllControls(ByVal thispid As Integer)
        For Each cl As Control In Controls
            If cl.Name <> "BtnEnumerate" Then

                cl.Enabled = False
            End If
        Next
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
            LblStatus.Text = "Callback on"
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

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        selecteddevice = -1


        For i As Integer = 1 To 20 - 1
            If serialPort1.IsOpen = True Then serialPort1.Close()
            serialPort1.PortName = "COM" & i.ToString()

            Try
                serialPort1.Open()
                CboPorts.Items.Add(serialPort1.PortName)
            Catch ex As System.Exception
                LblStatus.Text = ex.ToString()
            End Try
        Next

        If (CboPorts.Items.Count = 0) Then
            LblStatus.Text = "No available COM Ports"
        Else
            CboPorts.SelectedIndex = CboPorts.Items.Count - 1 'pick last one in the list
        End If

        If (CboPorts.SelectedIndex <> -1) Then
            cboCOMBaud.SelectedIndex = 9 'default to highest baud which is the X-keys factory default
            Dim thisbaud As String = cboCOMBaud.SelectedItem
            serialPort1.BaudRate = Convert.ToInt32(thisbaud)

            cboCOMParity.SelectedIndex = 2 'default to none
            serialPort1.Parity = System.IO.Ports.Parity.None

            cboCOMData.SelectedIndex = 8 - 5 'default to 8
            serialPort1.DataBits = 8

            cboCOMStop.SelectedIndex = 0 'default to 1
            serialPort1.StopBits = System.IO.Ports.StopBits.One


        End If

        Dim stoppp As Integer = 4
    End Sub

    



    Private Sub BtnTimeStamp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
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
    Private Sub BtnTimeStampOn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
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
            Dim savecallbackstate As Boolean = devices(selecteddevice).callNever
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

            listBox2.Items.Add("PID #" + (ddata(3) + 1).ToString)
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

            'uart stuff
            If CByte(ddata(21) And 1) = 1 Then
                listBox2.Items.Add("UART PI Base64 Input Report Transmit Messages=enabled")
                lblJsonState.Text = "on"
            Else
                listBox2.Items.Add("UART PI Base64 Input Report Transmit Messages=disabled")
                lblJsonState.Text = "off"
            End If

            If CByte(ddata(21) And 2) = 2 Then
                listBox2.Items.Add("echo op code=enabled")
                lblEchoState.Text = "on"
            Else
                listBox2.Items.Add("echo op code=disabled")
                lblEchoState.Text = "off"
            End If

            If CByte(ddata(21) And 4) = 4 Then
                listBox2.Items.Add("USB sleep=disabled")
                lblReawakeState.Text = "disabled"
            Else
                listBox2.Items.Add("USB sleep=enabled")
                lblReawakeState.Text = "enabled"
            End If

            If CByte(ddata(21) And 8) = 8 Then
                listBox2.Items.Add("usb check=disabled")
                lblUSBCheckState.Text = "disabled"
            Else
                listBox2.Items.Add("usb check=enabled")
                lblUSBCheckState.Text = "enabled"
            End If

            listBox2.Items.Add("start byte opcode" & ddata(23).ToString())
            listBox2.Items.Add("stop byte opcode=" & ddata(24).ToString())
            listBox2.Items.Add("start byte PI Base64=" & ddata(25).ToString())
            listBox2.Items.Add("stop byte PI Base64=" & ddata(26).ToString())

            devices(selecteddevice).callNever = savecallbackstate


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


  


    Private Sub ChkSuppress_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkSuppress.CheckedChanged
        If (ChkSuppress.Checked = True) Then
            devices(selecteddevice).suppressDuplicateReports = True
        Else
            devices(selecteddevice).suppressDuplicateReports = False
        End If

    End Sub

   
    

   

    

    Private Sub BtnBLToggle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBLToggle.Click
        'Sending this command toggles the backlights
        If selecteddevice <> -1 Then

            For i As Integer = 0 To devices(selecteddevice).WriteLength - 1
                wdata(i) = 0
            Next
            wdata(0) = 0
            wdata(1) = 184 'b8

            Dim result As Integer
            result = 404
            While (result = 404)
                result = devices(selecteddevice).WriteData(wdata)
            End While

            If result <> 0 Then
                LblStatus.Text = "Write Fail: " + result.ToString
            Else
                LblStatus.Text = "Write Success - Toggle BL"
            End If
        End If
    End Sub

  

  


  


    Private Sub ChkGreen_CheckStateChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkGreen.CheckStateChanged, ChkRed.CheckStateChanged
        'control leds
        If selecteddevice <> -1 Then

            Dim thisChk As CheckBox = DirectCast(sender, CheckBox)
            Dim temp As String = thisChk.Tag.ToString()
            Dim LED As Byte = Convert.ToByte(temp)
            Dim state As Byte = thisChk.CheckState

            For i As Integer = 0 To devices(selecteddevice).WriteLength - 1
                wdata(i) = 0
            Next
            wdata(0) = 0
            wdata(1) = 179
            wdata(2) = LED '6=green, 7=red
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


    Private Sub btnEchoOn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEchoOn.Click
        'If echo is on then when a UART Output Report Received Message is received an Incoming UART Data - Echo UART input report will be generated
        If selecteddevice <> -1 Then

            For i As Integer = 0 To devices(selecteddevice).WriteLength - 1
                wdata(i) = 0
            Next
            wdata(0) = 0
            wdata(1) = 217 'd9
            wdata(2) = 1 'echo on

            Dim result As Integer
            result = 404
            While (result = 404)
                result = devices(selecteddevice).WriteData(wdata)
            End While

            If result <> 0 Then
                LblStatus.Text = "Write Fail: " + result.ToString
            Else
                LblStatus.Text = "Write Success - Echo output command"
            End If
        End If
    End Sub

    Private Sub btnEchoOff_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEchoOff.Click
        'If echo is on then when a UART Output Report Received Message is received an Incoming UART Data - Echo UART input report will be generated
        If selecteddevice <> -1 Then

            For i As Integer = 0 To devices(selecteddevice).WriteLength - 1
                wdata(i) = 0
            Next
            wdata(0) = 0
            wdata(1) = 217 'd9
            wdata(2) = 0 'echo off (factory default)

            Dim result As Integer
            result = 404
            While (result = 404)
                result = devices(selecteddevice).WriteData(wdata)
            End While

            If result <> 0 Then
                LblStatus.Text = "Write Fail: " + result.ToString
            Else
                LblStatus.Text = "Write Success - Echo output command"
            End If
        End If
    End Sub

    Private Sub btnJsonOn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnJsonOn.Click
        'If enabled then any standard input report will be accompanied by a corresponding UART PI Base64 Input Report Transmit Message sent out on the X-keys TX
        'The message is in a special format, see the UART Port Information section of the documentation for details
        If selecteddevice <> -1 Then

            For i As Integer = 0 To devices(selecteddevice).WriteLength - 1
                wdata(i) = 0
            Next
            wdata(0) = 0
            wdata(1) = 215 'd7
            wdata(2) = 1 '0=off (factory default, 1=on)

            Dim result As Integer
            result = 404
            While (result = 404)
                result = devices(selecteddevice).WriteData(wdata)
            End While

            If result <> 0 Then
                LblStatus.Text = "Write Fail: " + result.ToString
            Else
                LblStatus.Text = "Write Success - Json message on off"
            End If
        End If
    End Sub

    Private Sub btnJsonOff_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnJsonOff.Click
        'If enabled then any standard input report will be accompanied by a corresponding UART PI Base64 Input Report Transmit Message sent out on the X-keys TX
        'The message is in a special format, see the UART Port Information section of the documentation for details
        If selecteddevice <> -1 Then

            For i As Integer = 0 To devices(selecteddevice).WriteLength - 1
                wdata(i) = 0
            Next
            wdata(0) = 0
            wdata(1) = 215 'd7
            wdata(2) = 0 '0=off (factory default, 1=on)

            Dim result As Integer
            result = 404
            While (result = 404)
                result = devices(selecteddevice).WriteData(wdata)
            End While

            If result <> 0 Then
                LblStatus.Text = "Write Fail: " + result.ToString
            Else
                LblStatus.Text = "Write Success - Json message on off"
            End If
        End If
    End Sub

    Private Sub btnSleepEnabled_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSleepEnabled.Click
        '//If sleep enabled  the X-keys will turn off its LEDs and any GPIO output pins when a USB suspend condition occurs. To override this behavior set sleep disable
        '//UART users may want to disable the sleep feature by setting this to 1
        If selecteddevice <> -1 Then

            For i As Integer = 0 To devices(selecteddevice).WriteLength - 1
                wdata(i) = 0
            Next
            wdata(0) = 0
            wdata(1) = 218 'da
            wdata(2) = 0 '0=enabled (factory default), 1=disabled

            Dim result As Integer
            result = 404
            While (result = 404)
                result = devices(selecteddevice).WriteData(wdata)
            End While

            If result <> 0 Then
                LblStatus.Text = "Write Fail: " + result.ToString
            Else
                LblStatus.Text = "Write Success - Enable Reawake"
            End If
        End If

    End Sub

    Private Sub btnSleepDisabled_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSleepDisabled.Click
        '//If sleep enabled  the X-keys will turn off its LEDs and any GPIO output pins when a USB suspend condition occurs. To override this behavior set sleep disable
        '//UART users may want to disable the sleep feature by setting this to 1
        If selecteddevice <> -1 Then

            For i As Integer = 0 To devices(selecteddevice).WriteLength - 1
                wdata(i) = 0
            Next
            wdata(0) = 0
            wdata(1) = 218 'da
            wdata(2) = 0 '0=enabled (factory default), 1=disabled

            Dim result As Integer
            result = 404
            While (result = 404)
                result = devices(selecteddevice).WriteData(wdata)
            End While

            If result <> 0 Then
                LblStatus.Text = "Write Fail: " + result.ToString
            Else
                LblStatus.Text = "Write Success - Disable Reawake"
            End If
        End If
    End Sub

    Private Sub btnUSBCheckOff_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUSBCheckOff.Click

        'If no USB detected and this is 0 then device will periodically check to see if USB has been connected. If this is 1 then it will not check to see if the USB was connected. 
        'Set to 1 if using the USB connection for power only to the UART.
        If selecteddevice <> -1 Then

            For i As Integer = 0 To devices(selecteddevice).WriteLength - 1
                wdata(i) = 0
            Next
            wdata(0) = 0
            wdata(1) = 143 '8f
            wdata(2) = 1 '0=enabled (factory default), 1=disabled

            Dim result As Integer
            result = 404
            While (result = 404)
                result = devices(selecteddevice).WriteData(wdata)
            End While

            If result <> 0 Then
                LblStatus.Text = "Write Fail: " + result.ToString
            Else
                LblStatus.Text = "Write Success - Disable USB check"
            End If
        End If

    End Sub

    Private Sub btnUSBCheckOn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUSBCheckOn.Click
        'If no USB detected and this is 0 then device will periodically check to see if USB has been connected. If this is 1 then it will not check to see if the USB was connected. 
        'Set to 1 if using the USB connection for power only.
        If selecteddevice <> -1 Then

            For i As Integer = 0 To devices(selecteddevice).WriteLength - 1
                wdata(i) = 0
            Next
            wdata(0) = 0
            wdata(1) = 143 '8f
            wdata(2) = 0 '0=enabled (factory default), 1=disabled

            Dim result As Integer
            result = 404
            While (result = 404)
                result = devices(selecteddevice).WriteData(wdata)
            End While

            If result <> 0 Then
                LblStatus.Text = "Write Fail: " + result.ToString
            Else
                LblStatus.Text = "Write Success - Enable USB check"
            End If
        End If
    End Sub

    Private Sub btnWriteXkeysTx_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWriteXkeysTx.Click
        'Send data to the TX port, ie X-keys transmits this data to connected RS232 device

        If selecteddevice <> -1 Then

            Dim sendthis As String = txtSendText.Text
            Dim length As Integer = sendthis.Length

            For i As Integer = 0 To devices(selecteddevice).WriteLength - 1
                wdata(i) = 0
            Next
            wdata(0) = 0
            wdata(1) = 216 'd8
            wdata(2) = CByte((length))

            For i As Integer = 0 To length - 1
                wdata(i + 3) = AscW(sendthis(i))
            Next

            Dim result As Integer
            result = 404
            While (result = 404)
                result = devices(selecteddevice).WriteData(wdata)
            End While

            If result <> 0 Then
                LblStatus.Text = "Write Fail: " + result.ToString
            Else
                LblStatus.Text = "Write Success - Write to UART"
            End If
        End If
    End Sub

    Private Sub btnReadRS232Settings_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReadRS232Settings.Click
        If selecteddevice <> -1 Then

            'IMPORTANT turn off the callback if going so data isn't grabbed there, turn it back on later (not done here)
            Dim savecallbackstate As Boolean = devices(selecteddevice).callNever
            devices(selecteddevice).callNever = True

            For i As Integer = 0 To devices(selecteddevice).WriteLength - 1
                wdata(i) = 0
            Next

            wdata(0) = 0
            wdata(1) = 141 '8d

            Dim result As Integer
            result = 404
            While (result = 404)
                result = devices(selecteddevice).WriteData(wdata)
            End While

            If result <> 0 Then
                LblStatus.Text = "Write Fail: " + result.ToString
            Else
                LblStatus.Text = "Write Success - Read RS232 Settings, callback off"
            End If
            'after this write the next read with 3rd byte = 214 gives descriptor data
            Dim ddata(devices(selecteddevice).ReadLength) As Byte
            Dim countout As Integer = 0
            result = devices(selecteddevice).BlockingReadData(ddata, 100)
            While (result = 304 Or (result = 0 And ddata(2) <> 141))
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

            cboBaudRate.SelectedIndex = ddata(3)
            cboParity.SelectedIndex = ddata(4)
            cboDataBits.SelectedIndex = ddata(5) - 5
            cboStopBits.SelectedIndex = ddata(6) - 2
            Dim temp As String = "Divider=" & (ddata(8) * 256 + ddata(7)).ToString()

            devices(selecteddevice).callNever = savecallbackstate

        End If
    End Sub

    Private Sub serialPort1_DataReceived(ByVal sender As System.Object, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs) Handles serialPort1.DataReceived
        'Read raw data as it comes in ASCII
        'RxString = serialPort1.ReadExisting();
        'this.Invoke(new EventHandler(DisplayText));

        Dim tmp As String = "" 'bytes
        Dim tmp2 As String = "" 'ascii characters

        While serialPort1.BytesToRead <> 0
            RxByte = serialPort1.ReadByte()
            tmp = tmp + BinToHex(CByte(RxByte))
            Dim bytelist As Byte() = Nothing
            bytelist = New Byte(0) {}
            bytelist(0) = CType(RxByte, Byte)
            tmp2 = tmp2 & System.Text.Encoding.ASCII.GetString(bytelist)
        End While
        RxString = tmp + " (" + tmp2 + ")"
        ' Me.Invoke(New EventHandler(DisplayText))

        thisListBox = listBox5
        SetListBox(RxString)

    End Sub
    Private Sub DisplayText(ByVal sender As Object, ByVal e As EventArgs)
        listBox5.Items.Add(RxString)
        listBox5.SelectedIndex = listBox5.Items.Count - 1
    End Sub

    Private Sub button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles button3.Click
        listBox5.Items.Clear()
    End Sub

    Private Sub btnCOMPortUSB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCOMPortUSB.Click
        'Serial messages received by the X-keys in this format will cause the X-keys to generate an Incoming UART Data - UART Custom Received Message input report
        'This is an input report with 00 UID 0xD8 02 Byte1 Byte2 ... 03 00 00 00 ...
        Dim data As Byte() = Nothing
        data = New Byte(serialPort1.WriteBufferSize - 1) {}
        Dim sendthis As String = txtSendCOMUSB.Text
        Dim length As Integer = sendthis.Length
        Dim count As Integer = length + 2
        'Must add start byte of 2 and stop byte of 3 to send message to USB
        data(0) = 2
        'data(1 to length)=Byte1, Byte2, etc.
        For i As Integer = 0 To length - 1
            data(i + 1) = AscW(sendthis(i))
        Next

        data(length + 1) = 3 'stop byte
        serialPort1.Write(data, 0, count)
    End Sub

    Private Sub btnCOMPortInternal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCOMPortInternal.Click
        'Serial messages received by the X-keys in this format will cause the X-keys to execute output reports
        'In this example we want to toggle the backlights which has a command byte of 0xB8, the trailing 0s are included only for format demonstration for longer reports
        'Encode the output report bytes to base64, in this example 0xB8, 00, 00 encodes to UAAA
        'Add start and stop bytes for 4 and 5, respectively
        'If Echo UART messages is on then an Incoming UART Data - Echo of UART Output Report Received Message input report will also be generated

        Dim encodethis As String = txtBase64Encode.Text 'encode these bytes
        lblEncoded.Text = Base64Encode(encodethis)

        Dim sendthis As String = lblEncoded.Text

        Dim length As Integer = sendthis.Length
        Dim data As Byte() = Nothing
        data = New Byte(serialPort1.WriteBufferSize - 1) {}
        Dim count As Integer = length + 2 'number of bytes to send
        data(0) = 4 'start byte
        For i As Integer = 0 To length - 1
            data(i + 1) = AscW(sendthis(i))
        Next

        data(length + 1) = 5 'stop byte
        serialPort1.Write(data, 0, count)



    End Sub

    Public Shared Function Base64Encode(ByVal plainText As String) As String
        Try
            Dim baseType As Integer = 16
            Dim csvInString As String = plainText
            Dim byteText As String = csvInString.Replace(" ", "")
            If baseType <> 16 Then baseType = 10
            Dim stringbytes As String() = byteText.Split(","c)
            Dim dataArray As Byte() = New Byte(stringbytes.Length - 1) {}

            For i As Integer = 0 To stringbytes.Length - 1
                dataArray(i) = Convert.ToByte(stringbytes(i), baseType)
            Next

            Dim bytesBase64 As String = Convert.ToBase64String(dataArray)
            Return bytesBase64
        Catch
            Return ""
        End Try
    End Function

    Private Function Base64Decode(ByVal base64EncodedData As String) As String
        Try
            Dim base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData)
            Dim thesebytes As String = ""

            For i As Integer = 0 To base64EncodedBytes.Length - 1
                thesebytes = thesebytes & BinToHex(base64EncodedBytes(i)) & ", "
            Next

            Return thesebytes
        Catch
            Return ""
        End Try
    End Function


    Private Sub btnRS232Settings_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRS232Settings.Click
        'Write RS232 settings to the device
        If selecteddevice <> -1 Then

            For i As Integer = 0 To devices(selecteddevice).WriteLength - 1
                wdata(i) = 0
            Next
            wdata(0) = 0
            wdata(1) = 142 '8e
            wdata(2) = CByte((cboBaudRate.SelectedIndex))
            wdata(3) = CByte((cboParity.SelectedIndex))
            wdata(4) = CByte((cboDataBits.SelectedIndex + 5))
            wdata(5) = CByte((cboStopBits.SelectedIndex + 2))

            Dim result As Integer
            result = 404
            While (result = 404)
                result = devices(selecteddevice).WriteData(wdata)
            End While

            If result <> 0 Then
                LblStatus.Text = "Write Fail: " + result.ToString
            Else
                LblStatus.Text = "Write Success - Change RS232 Settings"
            End If
        End If
    End Sub

    Private Sub CboPorts_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If (serialPort1.IsOpen = True) Then serialPort1.Close()
        serialPort1.PortName = CboPorts.Items(CboPorts.SelectedIndex)
        Try
            serialPort1.Open()
            LblStatus.Text = "Opened COM port successful"
        Catch ex As System.Exception
            LblStatus.Text = ex.Message
        End Try


    End Sub

    Private Sub cboCOMBaud_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Change port baud rate
        If cboCOMBaud.SelectedIndex <> -1 Then
            If serialPort1.IsOpen Then
                serialPort1.BaudRate = Convert.ToInt32(cboCOMBaud.GetItemText(cboCOMBaud.SelectedItem))
            End If
        End If
    End Sub

    Private Sub cboCOMParity_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'change port parity
        If cboCOMParity.SelectedIndex <> -1 Then
            If serialPort1.IsOpen Then
                Select Case cboCOMParity.SelectedIndex
                    Case 0 'even
                        serialPort1.Parity = IO.Ports.Parity.Even
                    Case 1 'odd
                        serialPort1.Parity = IO.Ports.Parity.Odd
                    Case 2 'none
                        serialPort1.Parity = IO.Ports.Parity.None
                End Select
            End If
        End If


    End Sub

    Private Sub cboCOMData_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If cboCOMData.SelectedIndex <> -1 Then
            If serialPort1.IsOpen Then
                Select Case cboCOMData.SelectedIndex
                    Case 0
                        serialPort1.DataBits = 5 'crash, if enter in properties won't find any com port at all
                    Case 1
                        serialPort1.DataBits = 6 'crash
                    Case 2
                        serialPort1.DataBits = 7
                    Case 3
                        serialPort1.DataBits = 8
                End Select
            End If
        End If


    End Sub

    Private Sub cboCOMStop_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If cboCOMStop.SelectedIndex <> -1 Then
            If serialPort1.IsOpen Then
                Select Case cboCOMStop.SelectedIndex
                    Case 0 'One
                        serialPort1.StopBits = IO.Ports.StopBits.One
                    Case 1 'One Point Five
                        serialPort1.StopBits = IO.Ports.StopBits.OnePointFive
                    Case 2 'Two
                        serialPort1.StopBits = IO.Ports.StopBits.Two
                End Select
            End If
        End If


    End Sub

    Private Sub CboPorts_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboPorts.SelectedIndexChanged
        If (serialPort1.IsOpen = True) Then serialPort1.Close()
        serialPort1.PortName = CboPorts.Items(CboPorts.SelectedIndex)
        Try
            serialPort1.Open()
            LblStatus.Text = "Opened COM port successful"
        Catch ex As System.Exception
            LblStatus.Text = ex.Message
        End Try
    End Sub

    Private Sub cboCOMBaud_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCOMBaud.SelectedIndexChanged
        'Change port baud rate
        If cboCOMBaud.SelectedIndex <> -1 Then
            If serialPort1.IsOpen Then
                serialPort1.BaudRate = Convert.ToInt32(cboCOMBaud.GetItemText(cboCOMBaud.SelectedItem))
            End If
        End If
    End Sub

    Private Sub cboCOMParity_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCOMParity.SelectedIndexChanged
        'change port parity
        If cboCOMParity.SelectedIndex <> -1 Then
            If serialPort1.IsOpen Then
                Select Case cboCOMParity.SelectedIndex
                    Case 0 'even
                        serialPort1.Parity = IO.Ports.Parity.Even
                    Case 1 'odd
                        serialPort1.Parity = IO.Ports.Parity.Odd
                    Case 2 'none
                        serialPort1.Parity = IO.Ports.Parity.None
                End Select
            End If
        End If
    End Sub

    Private Sub cboCOMData_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCOMData.SelectedIndexChanged
        If cboCOMData.SelectedIndex <> -1 Then
            If serialPort1.IsOpen Then
                Select Case cboCOMData.SelectedIndex
                    Case 0
                        serialPort1.DataBits = 5 'crash, if enter in properties won't find any com port at all
                    Case 1
                        serialPort1.DataBits = 6 'crash
                    Case 2
                        serialPort1.DataBits = 7
                    Case 3
                        serialPort1.DataBits = 8
                End Select
            End If
        End If

    End Sub

    Private Sub cboCOMStop_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCOMStop.SelectedIndexChanged
        If cboCOMStop.SelectedIndex <> -1 Then
            If serialPort1.IsOpen Then
                Select Case cboCOMStop.SelectedIndex
                    Case 0 'One
                        serialPort1.StopBits = IO.Ports.StopBits.One
                    Case 1 'One Point Five
                        serialPort1.StopBits = IO.Ports.StopBits.OnePointFive
                    Case 2 'Two
                        serialPort1.StopBits = IO.Ports.StopBits.Two
                End Select
            End If
        End If
    End Sub

   
   
End Class
