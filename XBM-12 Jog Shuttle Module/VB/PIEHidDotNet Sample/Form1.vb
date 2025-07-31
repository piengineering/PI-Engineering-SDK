﻿Imports System.Text
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
    Dim printthis As String = ""
    Dim lastprintthis As String = ""

    Dim myAes As Aes
    Dim myKey As Byte()
    Dim myIV As Byte()

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

                Dim val2 As Byte = CByte(data(2) And 1)

                'Keyboard states (keyboard endpoints only)
                'check the keyboard state byte 
                val2 = CByte(data(7) And 1)
                If val2 = 0 Then
                    c = Me.LblNumLk
                    Me.SetText("NumLock: off")
                Else
                    c = Me.LblNumLk
                    Me.SetText("NumLock: on")
                End If
                val2 = CByte(data(7) And 2)
                If val2 = 0 Then
                    c = Me.LblCapsLk
                    Me.SetText("CapsLock: off")
                Else
                    c = Me.LblCapsLk
                    Me.SetText("CapsLock: on")
                End If
                val2 = CByte(data(7) And 4)
                If val2 = 0 Then
                    c = Me.LblScrLk
                    Me.SetText("ScrLock: off")
                Else
                    c = Me.LblScrLk
                    Me.SetText("ScrLock: on")
                End If

                'Buttons
                Dim maxcols As Integer = 4 'number of columns of Xkeys digital button data
                Dim maxrows As Integer = 3 'number of rows of Xkeys digital button data
                c = Me.LblButtons
                Dim buttonsdown As String = "Buttons: " 'for demonstration, reset this every time a new input report received

                For i As Integer = 0 To maxcols - 1
                    For j As Integer = 0 To maxrows - 1
                        Dim temp1 As Integer = CInt(Math.Pow(2, j)) '1, 2, 4, 8, 16, 32, 64, 128
                        Dim keynum As Integer = maxrows * i + j 'column 1 = 0,1,2... column 2 = 3,4,5... column 3 = 6,7,8... column 4 = 9,10,11... etc
                        Dim temp2 As Byte = CByte((data(i + 3) And temp1)) 'check using bitwise AND the current value of this bit. The + 3 is because the 1st button byte starts 3 bytes in at data[3]
                        Dim temp3 As Byte = CByte((lastdata(i + 3) And temp1)) 'check using bitwise AND the previous value of this bit
                        Dim state As Integer = 0 '0=was up, now up, 1=was up, now down, 2= was down, still down, 3= was down, now up

                        If temp2 <> 0 AndAlso temp3 = 0 Then
                            state = 1
                        ElseIf temp2 <> 0 AndAlso temp3 <> 0 Then
                            state = 2
                        ElseIf temp2 = 0 AndAlso temp3 <> 0 Then
                            state = 3
                        End If

                        Select Case state
                            Case 1 'key was up and now is pressed
                                buttonsdown = buttonsdown + keynum.ToString() + " "
                                c = Me.LblButtons
                                SetText(buttonsdown)
                            Case 2 'key was pressed and still is pressed
                                buttonsdown = buttonsdown + keynum.ToString() + " "
                                c = Me.LblButtons
                                SetText(buttonsdown)
                            Case 3 'key was pressed and now released
                        End Select

                        'Perform action based on key number, consult P.I. Engineering SDK documentation for the key numbers
                        Select Case keynum
                            Case 0 'button 0 (top left)
                                If state = 1 Then 'key was pressed
                                ElseIf state = 3 Then 'key was released
                                End If
                            Case 1 'button 1
                                If state = 1 Then 'key was pressed
                                ElseIf state = 3 Then 'key was released
                                End If
                            Case 2 'button 2
                                If state = 1 Then 'key was pressed
                                ElseIf state = 3 Then 'key was released
                                End If
                                'Next column of buttons
                            Case 3 'button 3
                                If state = 1 Then 'key was pressed
                                ElseIf state = 3 Then 'key was released
                                End If
                            Case 4 'button 4
                                If state = 1 Then 'key was pressed
                                ElseIf state = 3 Then 'key was released
                                End If
                            Case 5 'button 5
                                If state = 1 Then 'key was pressed
                                ElseIf state = 3 Then 'key was released
                                End If
                                'Next column of buttons
                            Case 6 'button 6
                                If state = 1 Then 'key was pressed
                                ElseIf state = 3 Then 'key was released
                                End If
                            Case 7 'button 7
                                If state = 1 Then 'key was pressed
                                ElseIf state = 3 Then 'key was released
                                End If
                            Case 8 'button 8
                                If state = 1 Then 'key was pressed
                                ElseIf state = 3 Then 'key was released
                                End If
                                'Next column of buttons
                            Case 9 'button 9
                                If state = 1 Then 'key was pressed
                                ElseIf state = 3 Then 'key was released
                                End If
                            Case 10 'button 10
                                If state = 1 Then 'key was pressed
                                ElseIf state = 3 Then 'key was released
                                End If
                            Case 11 'button 11
                                If state = 1 Then 'key was pressed
                                ElseIf state = 3 Then 'key was released
                                End If
                        End Select
                    Next
                Next
                'end Buttons

                'Jog Digital, Shuttle AT REST digital
                Dim val As Byte = CByte((data(12) And &H80))
                If val <> 0 Then
                    c = Me.LblJogD
                    SetText("Jog Digital: CW")
                End If

                val = CByte((data(11) And &H80))
                If val <> 0 Then
                    c = Me.LblJogD
                    SetText("Jog Digital: CCW")
                End If

                val = CByte((data(9) And &H80))
                If val <> 0 Then
                    c = Me.LblShuttleD
                    SetText("Shuttle Digital: 0 CW")
                End If

                val = CByte((data(10) And &H80))
                If val <> 0 Then
                    c = Me.LblShuttleD
                    SetText("Shuttle Digital: 0 CCW")
                End If

                'Shuttle Digital
                For i As Integer = 0 To 3
                    For j As Integer = 0 To 7
                        Dim temp1 As Integer = CInt(Math.Pow(2, j))
                        Dim keynum As Integer = 8 * i + j
                        Dim temp2 As Byte = CByte((data(i + 9) And temp1))
                        Dim temp3 As Byte = CByte((lastdata(i + 9) And temp1))
                        Dim state As Integer = 0

                        If temp2 <> 0 AndAlso temp3 = 0 Then
                            state = 1
                        ElseIf temp2 <> 0 AndAlso temp3 <> 0 Then
                            state = 2
                        ElseIf temp2 = 0 AndAlso temp3 <> 0 Then
                            state = 3
                        End If

                        If (state = 1) Then
                            Select Case keynum
                                Case 0
                                    printthis = "Shuttle Digital: 1 CW"
                                Case 1
                                    printthis = "Shuttle Digital: 2 CW"
                                Case 2
                                    printthis = "Shuttle Digital: 3 CW"
                                Case 3
                                    printthis = "Shuttle Digital: 4 CW"
                                Case 4
                                    printthis = "Shuttle Digital: 5 CW"
                                Case 5
                                    printthis = "Shuttle Digital: 6 CW"
                                Case 6
                                    printthis = "Shuttle Digital: 7 CW"
                                Case 8
                                    printthis = "Shuttle Digital: 1 CCW"
                                Case 9
                                    printthis = "Shuttle Digital: 2 CCW"
                                Case 10
                                    printthis = "Shuttle Digital: 3 CCW"
                                Case 11
                                    printthis = "Shuttle Digital: 4 CCW"
                                Case 12
                                    printthis = "Shuttle Digital: 5 CCW"
                                Case 13
                                    printthis = "Shuttle Digital: 6 CCW"
                                Case 16
                                    printthis = "Shuttle Digital: -1 CCW"
                                Case 17
                                    printthis = "Shuttle Digital: -2 CCW"
                                Case 18
                                    printthis = "Shuttle Digital: -3 CCW"
                                Case 19
                                    printthis = "Shuttle Digital: -4 CCW"
                                Case 20
                                    printthis = "Shuttle Digital: -5 CCW"
                                Case 21
                                    printthis = "Shuttle Digital: -6 CCW"
                                Case 22
                                    printthis = "Shuttle Digital: -7 CCW"
                                Case 24
                                    printthis = "Shuttle Digital: -1 CW"
                                Case 25
                                    printthis = "Shuttle Digital: -2 CW"
                                Case 26
                                    printthis = "Shuttle Digital: -3 CW"
                                Case 27
                                    printthis = "Shuttle Digital: -4 CW"
                                Case 28
                                    printthis = "Shuttle Digital: -5 CW"
                                Case 29
                                    printthis = "Shuttle Digital: -6 CW"

                            End Select
                        End If
                        If (printthis <> lastprintthis) Then
                            c = LblShuttleD
                            SetText(printthis)
                            lastprintthis = printthis
                        End If
                        If state = 1 Then
                            'enter of region
                        ElseIf state = 3 Then
                            'exit of region
                        End If
                    Next
                Next
                

                'Jog Analog
                If data(13) = 1 Then
                    c = Me.LblJog
                    Me.SetText("Jog Analog: CW")
                ElseIf data(13) = 255 Then
                    c = Me.LblJog
                    Me.SetText("Jog Analog: CCW")
                End If

                'Shuttle Analog
                c = Me.LblShuttle
                Me.SetText("Shuttle Analog: " & data(14).ToString)

                'Jog Raw Count
                c = Me.lblJogRaw
                Me.SetText("Jog Raw Count: " + (data(15) * 256 + data(16)).ToString())

                'GPIO Inputs
                val2 = CByte(data(3) And 8)
                If val2 = 0 Then
                    c = Me.lblPin1
                    Me.SetText("GPIO pin 1: off")
                Else
                    c = Me.lblPin1
                    Me.SetText("GPIO pin 1: on")
                End If

                val2 = CByte(data(4) And 8)
                If val2 = 0 Then
                    c = Me.lblPin2
                    Me.SetText("GPIO pin 2: off")
                Else
                    c = Me.lblPin2
                    Me.SetText("GPIO pin 2: on")
                End If

                val2 = CByte(data(5) And 8)
                If val2 = 0 Then
                    c = Me.lblPin3
                    Me.SetText("GPIO pin 3: off")
                Else
                    c = Me.lblPin3
                    Me.SetText("GPIO pin 3: on")
                End If

                val2 = CByte(data(6) And 8)
                If val2 = 0 Then
                    c = Me.lblPin4
                    Me.SetText("GPIO pin 4: off")
                Else
                    c = Me.lblPin4
                    Me.SetText("GPIO pin 4: on")
                End If

                'Time stamp info 4 bytes
                Dim absolutetime As Long = 16777216 * data(sourceDevice.ReadLength - 5) + 65536 * data(sourceDevice.ReadLength - 4) + 256 * data(sourceDevice.ReadLength - 3) + data(sourceDevice.ReadLength - 2) 'ms
                Dim absolutetime2 As Long = absolutetime / 1000 'in seconds
                c = lblabstime
                SetText("absolute time: " + absolutetime2.ToString + " s")
                Dim deltatime As Long = absolutetime - saveabsolutetime
                c = lbldeltatime
                SetText("delta time: " + deltatime.ToString + " ms")
                saveabsolutetime = absolutetime

                For i As Integer = 0 To sourceDevice.ReadLength - 1
                    lastdata(i) = data(i)
                Next
            ElseIf (data(2) = 167) Then 'backlight LED state request
                thisListBox = listBox3
                ClearListBox()

                SetListBox("Button=" + data(3).ToString)
                'bank 1
                SetListBox("Bank 1 Red=" + data(4).ToString)
                SetListBox("Bank 1 Green=" + data(5).ToString)
                SetListBox("Bank 1 Blue=" + data(6).ToString)
                SetListBox("Bank 1 Dim Factor=" + data(14).ToString) '255=100%
                If (data(10) = 1) Then '0=no flash, 1=flashing Then
                    SetListBox("Flash Bank 1=flashing")
                Else
                    SetListBox("Flash Bank 1=not flashing")
                End If
                'bank 2
                SetListBox("Bank 2 Red=" + data(7).ToString)
                SetListBox("Bank 2 Green=" + data(8).ToString)
                SetListBox("Bank 2 Blue=" + data(9).ToString)
                SetListBox("Bank 2 Dim Factor=" + data(15).ToString) '255=100%
                If (data(11) = 1) Then '0=no flash, 1=flashing Then
                    SetListBox("Flash Bank 2=flashing")
                Else
                    SetListBox("Flash Bank 2=not flashing")
                End If

                SetListBox("Flash Frequency=" + data(13).ToString)
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

                    Select Case devices(i).Pid
                        Case 1388
                            CboDevices.Items.Add(devices(i).ProductString + " (" + devices(i).Pid.ToString + "=PID #1)")
                            cbotodevice(cbocount) = i
                            cbocount = cbocount + 1
                            cboPIDs.SelectedIndex = 0
                        Case 1389
                            CboDevices.Items.Add(devices(i).ProductString + " (" + devices(i).Pid.ToString + "=PID #2)")
                            cbotodevice(cbocount) = i
                            cbocount = cbocount + 1
                            cboPIDs.SelectedIndex = 1
                        Case 1390
                            CboDevices.Items.Add(devices(i).ProductString + " (" + devices(i).Pid.ToString + "=PID #3)")
                            cbotodevice(cbocount) = i
                            cbocount = cbocount + 1
                            cboPIDs.SelectedIndex = 2
                        Case 1391
                            CboDevices.Items.Add(devices(i).ProductString + " (" + devices(i).Pid.ToString + "=PID #4)")
                            cbotodevice(cbocount) = i
                            cbocount = cbocount + 1
                            cboPIDs.SelectedIndex = 3
                        Case 1392
                            CboDevices.Items.Add(devices(i).ProductString + " (" + devices(i).Pid.ToString + "=PID #5)")
                            cbotodevice(cbocount) = i
                            cbocount = cbocount + 1
                            cboPIDs.SelectedIndex = 4
                        Case 1393
                            CboDevices.Items.Add(devices(i).ProductString + " (" + devices(i).Pid.ToString + "=PID #6)")
                            cbotodevice(cbocount) = i
                            cbocount = cbocount + 1
                            cboPIDs.SelectedIndex = 5
                        Case 1394
                            CboDevices.Items.Add(devices(i).ProductString + " (" + devices(i).Pid.ToString + "=PID #7)")
                            cbotodevice(cbocount) = i
                            cbocount = cbocount + 1
                            cboPIDs.SelectedIndex = 6
                        Case Else
                            CboDevices.Items.Add("Unknown Device (" + devices(i).Pid.ToString + ")")
                            cbotodevice(cbocount) = i
                            cbocount = cbocount + 1
                            cboPIDs.SelectedIndex = 0
                    End Select
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
                    ElseIf (devices(i).Pid = 1395) Then
                        CboDevices.Items.Add(devices(i).ProductString + " for KVM (" + devices(i).Pid.ToString + "=PID #8)")
                        cbotodevice(cbocount) = i
                        cbocount = cbocount + 1
                        cboPIDs.SelectedIndex = 7
                        DisableAllControls(devices(i).Pid)
                        MessageBox.Show("Device in PID #8 (KVM), no input or output reports are available. To exit KVM mode, replug device into usb port and immediately after press Scroll Lock 10-15 times.")
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
            'fill in version, note this is NOTE the firmware version which is given in the descriptor
            LblVersion.Text = devices(selecteddevice).Version.ToString
            lblSiliconGeneratedID.Text = devices(selecteddevice).SerialNumberString
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
        CboBL.SelectedIndex = 0
        CboBankLegacy.SelectedIndex = 0
        cboColor.SelectedIndex = 1
        cboLEDIndexGet.SelectedIndex = 0
        cboIndex.SelectedIndex = 0
        cboBank.SelectedIndex = 0

        myAes = Aes.Create()
        myAes.Mode = CipherMode.CBC
        myAes.Padding = PaddingMode.Zeros
        myAes.KeySize = 128
        myKey = New Byte(15) {}
        myIV = New Byte(15) {}
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

            'IMPORTANT turn off the callback so data isn't grabbed there, turn it back on later
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

            listBox2.Items.Add("PID " + (ddata(3) + 1).ToString)
            listBox2.Items.Add("Keymapstart=" + ddata(4).ToString)
            listBox2.Items.Add("Layer2offset=" + ddata(5).ToString)
            listBox2.Items.Add("OutSize=" + ddata(6).ToString)
            listBox2.Items.Add("ReportSize=" + ddata(7).ToString)
            listBox2.Items.Add("MaxCol=" + ddata(8).ToString)
            listBox2.Items.Add("MaxRow=" + ddata(9).ToString)
            Dim pinson As String = ""
            If (ddata(10) And 1) <> 0 Then
                pinson = "NumLock, "
            End If
            If (ddata(10) And 2) <> 0 Then
                pinson = pinson + "CapsLock, "
            End If
            If (ddata(10) And 4) <> 0 Then
                pinson = pinson + "ScrLock, "
            End If
            If (ddata(10) And 16) <> 0 Then
                pinson = pinson + "GPIO Pin 1, "
            End If
            If (ddata(10) And 32) <> 0 Then
                pinson = pinson + "GPIO Pin 2, "
            End If
            If (ddata(10) And 64) <> 0 Then
                pinson = pinson + "GPIO Pin 3, "
            End If
            If (ddata(10) And 128) <> 0 Then
                pinson = pinson + "GPIO Pin 4, "
            End If

            listBox2.Items.Add("Pins On =" & pinson)

            listBox2.Items.Add("Firmware Version=" + ddata(11).ToString)
            Dim temp As String = "PID=" + (ddata(13) * 256 + ddata(12)).ToString
            listBox2.Items.Add(temp)

            listBox2.Items.Add("Dim Factor Bank 1=" + ddata(17).ToString)
            listBox2.Items.Add("Dim Factor Bank 2=" + ddata(18).ToString)
            txtBank1.Text = ddata(17).ToString
            txtBank2.Text = ddata(18).ToString

            listBox2.Items.Add("GPIO Input/Output Configuration=" + ddata(19).ToString)
            listBox2.Items.Add("GPIO Input Configuration=" + ddata(20).ToString)
            rb1O.Checked = True
            rb2O.Checked = True
            rb3O.Checked = True
            rb4O.Checked = True

            Dim val2 As Byte = CByte(ddata(19) And 1)
            If (val2 = 1) Then 'pin is input, check which type of input
                rb1ID.Checked = True
                val2 = CByte(ddata(20) And 1)
                If (val2 = 1) Then
                    rb1I.Checked = True
                End If
            End If

            val2 = CByte(ddata(19) And 2)
            If (val2 = 2) Then 'pin is input, check which type of input
                rb2ID.Checked = True
                val2 = CByte(ddata(20) And 2)
                If (val2 = 2) Then
                    rb2I.Checked = True
                End If
            End If

            val2 = CByte(ddata(19) And 4)
            If (val2 = 4) Then 'pin is input, check which type of input
                rb3ID.Checked = True
                val2 = CByte(ddata(20) And 4)
                If (val2 = 4) Then
                    rb3I.Checked = True
                End If
            End If

            val2 = CByte(ddata(19) And 8)
            If (val2 = 8) Then 'pin is input, check which type of input
                rb4ID.Checked = True
                val2 = CByte(ddata(20) And 8)
                If (val2 = 8) Then
                    rb4I.Checked = True
                End If
            End If
            devices(selecteddevice).callNever = savecallbackstate
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
                LblStatus.Text = "Write Success - Joystick Reflector"
            End If
        End If
    End Sub

    Private Sub BtnMousereflect_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub




    Private Sub ChkGreen_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'control leds
        If selecteddevice <> -1 Then

            Dim thisChk As CheckBox = DirectCast(sender, CheckBox)
            Dim temp As String = thisChk.Tag.ToString()
            Dim LED As Byte = Convert.ToByte(temp)
            '6=green, 7=red, 0=out1, 1=out2
            Dim state As Byte = 0
            If thisChk.Checked = True Then
                state = 1
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

    Private Sub ChkFlash_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)


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
            wdata(1) = 224
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

            wdata(0) = 0
            wdata(1) = 195
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
            wdata(1) = 238
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
            wdata(1) = 225
            wdata(2) = HexToBin(TxtMMLow.Text) 'Usage ID lo byte see hut1_12.pdf, pages 75-85 Consumer Page
            wdata(3) = HexToBin(TxtMMHigh.Text) 'Usage ID hi byte see hut1_12.pdf, pages 75-85 Consumer Page

            Dim result As Integer
            result = 404
            While (result = 404)
                result = devices(selecteddevice).WriteData(wdata)
            End While

            wdata(0) = 0
            wdata(1) = 225
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
            wdata(1) = 225
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
            wdata(1) = 226
            wdata(2) = 2 '1=power down, 2=sleep, 4=wake up

            Dim result As Integer
            result = 404
            While (result = 404)
                result = devices(selecteddevice).WriteData(wdata)
            End While

            wdata(0) = 0
            wdata(1) = 226
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



    Private Sub BtnPID3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPID3.Click
        If selecteddevice <> -1 Then
            For i As Integer = 0 To devices(selecteddevice).WriteLength - 1
                wdata(i) = 0
            Next

            wdata(0) = 0
            wdata(1) = 204
            wdata(2) = CByte(cboPIDs.SelectedIndex)

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

    Private Sub BtnPID4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub


    Private Sub ChkSuppress_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkSuppress.CheckedChanged
        If (ChkSuppress.Checked = True) Then
            devices(selecteddevice).suppressDuplicateReports = True
        Else
            devices(selecteddevice).suppressDuplicateReports = False
        End If

    End Sub


    Private Sub ChkBank1OnOff_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkBank1OnOff.CheckedChanged
        'Turns on or off ALL bank 1 BLs using current intensity
        If selecteddevice <> -1 Then
            Dim sl As Byte = 0

            If ChkBank1OnOff.Checked = True Then
                sl = 255
            End If

            For i As Integer = 0 To devices(selecteddevice).WriteLength - 1
                wdata(i) = 0
            Next
            wdata(0) = 0
            wdata(1) = 182 '&Hb6
            wdata(2) = 0 '0 for bank1, 1 for bank 2
            wdata(3) = sl

            Dim result As Integer
            result = 404
            While (result = 404)
                result = devices(selecteddevice).WriteData(wdata)
            End While

            If result <> 0 Then
                LblStatus.Text = "Write Fail: " + result.ToString
            Else
                LblStatus.Text = "Write Success - All bank 1 BL on/off"
            End If
        End If
    End Sub

    Private Sub ChkBank2OnOff_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkBank2OnOff.CheckedChanged
        'Turns on or off ALL bank 2 BLs using current intensity
        If selecteddevice <> -1 Then
            Dim sl As Byte = 0

            If ChkBank2OnOff.Checked = True Then
                sl = 255
            End If

            For i As Integer = 0 To devices(selecteddevice).WriteLength - 1
                wdata(i) = 0
            Next
            wdata(0) = 0
            wdata(1) = 182 '&Hb6
            wdata(2) = 1 '0 for bank1, 1 for bank 2
            wdata(3) = sl

            Dim result As Integer
            result = 404
            While (result = 404)
                result = devices(selecteddevice).WriteData(wdata)
            End While

            If result <> 0 Then
                LblStatus.Text = "Write Fail: " + result.ToString
            Else
                LblStatus.Text = "Write Success - All bank 2 BL on/off"
            End If
        End If
    End Sub

    Private Sub BtnSetFlash_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSetFlash.Click
        'Sets the frequency of flashing for both the LEDs and backlighting
        If selecteddevice <> -1 Then

            For i As Integer = 0 To devices(selecteddevice).WriteLength - 1
                wdata(i) = 0
            Next
            wdata(0) = 0
            wdata(1) = 180
            wdata(2) = TxtFlashFreq.Text

            Dim result As Integer
            result = 404
            While (result = 404)
                result = devices(selecteddevice).WriteData(wdata)
            End While

            If result <> 0 Then
                LblStatus.Text = "Write Fail: " + result.ToString
            Else
                LblStatus.Text = "Write Success - Set Flash Freq"
            End If
        End If
    End Sub

    Private Sub BtnBLToggle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBLToggle.Click
        'Sending this command toggles the backlights
        If selecteddevice <> -1 Then

            For i As Integer = 0 To devices(selecteddevice).WriteLength - 1
                wdata(i) = 0
            Next
            wdata(0) = 0
            wdata(1) = 184

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

    Private Sub BtnBL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBL.Click

        If selecteddevice <> -1 Then

            For i As Integer = 0 To devices(selecteddevice).WriteLength - 1
                wdata(i) = 0
            Next
            wdata(0) = 0
            wdata(1) = 187 '&HBB
            wdata(2) = TxtIntensity1.Text
            wdata(3) = TxtIntensity2.Text

            Dim result As Integer
            result = 404
            While (result = 404)
                result = devices(selecteddevice).WriteData(wdata)
            End While

            If result <> 0 Then
                LblStatus.Text = "Write Fail: " + result.ToString
            Else
                LblStatus.Text = "Write Success - Backlighting Intensity"
            End If
            txtBank1.Text = TxtIntensity1.Text
            txtBank2.Text = TxtIntensity2.Text
        End If
    End Sub

    Private Sub BtnSaveBL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSaveBL.Click
        'Write current state of backlighting to EEPROM. 
        'NOTE: Is it not recommended to do this frequently as there are a finite number of writes to the EEPROM allowed
        If selecteddevice <> -1 Then

            For i As Integer = 0 To devices(selecteddevice).WriteLength - 1
                wdata(i) = 0
            Next
            wdata(0) = 0
            wdata(1) = 199 '&Hc7
            wdata(2) = 1 'anything other than 0 will save bl state to eeprom

            Dim result As Integer
            result = 404
            While (result = 404)
                result = devices(selecteddevice).WriteData(wdata)
            End While

            If result <> 0 Then
                LblStatus.Text = "Write Fail: " + result.ToString
            Else
                LblStatus.Text = "Write Success - Save Backlight to EEPROM"
            End If
        End If
    End Sub


    Private Sub BtnMousereflect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnMousereflect.Click
        If selecteddevice <> -1 Then

            For i As Integer = 0 To devices(selecteddevice).WriteLength - 1
                wdata(i) = 0
            Next

            wdata(0) = 0
            wdata(1) = 203
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
            wdata(1) = 203
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

    Private Sub BtnNoChange_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNoChange.Click
        If selecteddevice <> -1 Then
            For i As Integer = 0 To devices(selecteddevice).WriteLength - 1
                wdata(i) = 0
            Next

            wdata(0) = 0
            wdata(1) = 196
            wdata(2) = 0

            Dim result As Integer
            result = 404
            While (result = 404)
                result = devices(selecteddevice).WriteData(wdata)
            End While

            If result <> 0 Then
                LblStatus.Text = "Write Fail: " + result.ToString
            Else
                LblStatus.Text = "Write Success - KVM setting"
            End If
        End If
    End Sub

    Private Sub BtnChange_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnChange.Click
        If selecteddevice <> -1 Then
            For i As Integer = 0 To devices(selecteddevice).WriteLength - 1
                wdata(i) = 0
            Next

            wdata(0) = 0
            wdata(1) = 196
            wdata(2) = 7

            Dim result As Integer
            result = 404
            While (result = 404)
                result = devices(selecteddevice).WriteData(wdata)
            End While

            If result <> 0 Then
                LblStatus.Text = "Write Fail: " + result.ToString
            Else
                LblStatus.Text = "Write Success - KVM setting"
            End If
        End If
    End Sub

    Private Sub btnGetBLState_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetBLState.Click
        'Sending this command will make the device return information about it, in this sample the returned information is
        'expected in the HandlePIEHidData callback routine. It is also possible to use the BlockingReadData command to 
        'get the returned data as demonstrated in BtnDescriptor_Click
        'Index (in decimal)
        'Columns-->
        '  0   3  6   9
        '  1   4  7   10
        '  2   5  8   11
        If (selecteddevice <> -1) Then
            wdata(0) = 0
            wdata(1) = 167 '&HA7
            wdata(2) = cboLEDIndexGet.SelectedIndex

            Dim result As Integer = 404

            While (result = 404)
                result = devices(selecteddevice).WriteData(wdata)

            End While

            If (result <> 0) Then
                LblStatus.Text = ("Write Fail: " + result)
            Else
                LblStatus.Text = "Write Success - Get BL state"
            End If

            'see HandlePIEHidData for handling of the returned data
        End If
    End Sub

    Private Sub chkLED1_CheckStateChanged(ByVal sender As Object, ByVal e As EventArgs) Handles chkLED4.CheckStateChanged, chkLED3.CheckStateChanged, chkLED2.CheckStateChanged, chkLED1.CheckStateChanged
        If CboDevices.SelectedIndex <> -1 Then
            Dim thischkbox As CheckBox = CType(sender, CheckBox)
            Dim ledindex As Byte = Convert.ToByte(thischkbox.Tag.ToString())

            For j As Integer = 0 To devices(selecteddevice).WriteLength - 1
                wdata(j) = 0
            Next

            wdata(1) = 179
            wdata(2) = ledindex
            wdata(3) = CByte(thischkbox.CheckState)
            Dim result As Integer = 404

            While result = 404
                result = devices(selecteddevice).WriteData(wdata)
            End While

            If result <> 0 Then
                LblStatus.Text = "Write Fail: " & result
            Else
                LblStatus.Text = "Write Success - Set LED"
            End If
        End If
    End Sub

    Private Sub cboColor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboColor.SelectedIndexChanged
        Select Case cboColor.SelectedIndex
            Case 0
                txtR.Text = "0"
                txtG.Text = "0"
                txtB.Text = "0"
            Case 1
                txtR.Text = "255"
                txtG.Text = "0"
                txtB.Text = "0"
            Case 2
                txtR.Text = "255"
                txtG.Text = "20"
                txtB.Text = "0"
            Case 3
                txtR.Text = "255"
                txtG.Text = "129"
                txtB.Text = "0"
            Case 4
                txtR.Text = "0"
                txtG.Text = "255"
                txtB.Text = "0"
            Case 5
                txtR.Text = "0"
                txtG.Text = "255"
                txtB.Text = "129"
            Case 6
                txtR.Text = "0"
                txtG.Text = "0"
                txtB.Text = "255"
            Case 7
                txtR.Text = "255"
                txtG.Text = "8"
                txtB.Text = "40"
            Case 8
                txtR.Text = "150"
                txtG.Text = "0"
                txtB.Text = "255"
            Case 9
                txtR.Text = "255"
                txtG.Text = "255"
                txtB.Text = "255"
        End Select
    End Sub

    Private Sub btnSetRGB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetRGB.Click
        'Set individual led 
        'Index (in decimal)
        'Columns-->
        '  0   3  6   9
        '  1   4  7   10
        '  2   5  8   11

        'Upper LEDs are bank 1, bankindex = 0
        'Lower LEDs are bank 2, bankindex = 1

        If selecteddevice <> -1 Then 'do nothing if not enumerated
            Dim index As Byte = Convert.ToByte(cboIndex.Text)
            Dim bank As Byte = CByte(cboBank.SelectedIndex)

            Dim result As Integer = 0

            For j As Integer = 0 To devices(selecteddevice).WriteLength - 1
                wdata(j) = 0
            Next

            If (bank = 0) OrElse (bank = 1) Then
                wdata(1) = 165 '&HA5
                wdata(2) = index
                wdata(3) = bank '0=bank 1 (top), 1=bank 2 (bottom)
                wdata(4) = Convert.ToByte(txtR.Text)
                wdata(5) = Convert.ToByte(txtG.Text)
                wdata(6) = Convert.ToByte(txtB.Text)
                wdata(7) = chkRGBFlash.CheckState '0=no flash, 1=flash

                result = 404
                While (result = 404)
                    result = devices(selecteddevice).WriteData(wdata)
                End While

                If result <> 0 Then
                    LblStatus.Text = "Write Fail: " & result
                Else
                    LblStatus.Text = "Write Success - Set LED"
                End If
            ElseIf bank = 2 Then 'do both
                'bank 1
                wdata(1) = 165 '&HA5
                wdata(2) = index
                wdata(3) = 0 '0=bank 1 (top), 1=bank 2 (bottom)
                wdata(4) = Convert.ToByte(txtR.Text)
                wdata(5) = Convert.ToByte(txtG.Text)
                wdata(6) = Convert.ToByte(txtB.Text)
                wdata(7) = chkRGBFlash.CheckState '0=no flash, 1=flash

                result = 404
                While (result = 404)
                    result = devices(selecteddevice).WriteData(wdata)
                End While

                If result <> 0 Then
                    LblStatus.Text = "Write Fail: " & result
                Else
                    LblStatus.Text = "Write Success - Set LED"
                End If

                'bank 2
                wdata(3) = 1 '0=bank 1 (top), 1=bank 2 (bottom)
                result = 404
                While (result = 404)
                    result = devices(selecteddevice).WriteData(wdata)
                End While

                If result <> 0 Then
                    LblStatus.Text = "Write Fail: " & result
                Else
                    LblStatus.Text = "Write Success - Set LED"
                End If

            End If
        End If
    End Sub

    Private Sub btnSetAllBank1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetAllBank1.Click

        If selecteddevice <> -1 Then 'do nothing if not enumerated
            Dim result As Integer = 0

            For j As Integer = 0 To devices(selecteddevice).WriteLength - 1
                wdata(j) = 0
            Next

            wdata(1) = 166 '&HA6
            wdata(2) = 0 '0=bank 1 (upper LEDs), 1=bank 2 (lower LEDs)
            wdata(3) = Convert.ToByte(txtR.Text)
            wdata(4) = Convert.ToByte(txtG.Text)
            wdata(5) = Convert.ToByte(txtB.Text)

            result = 404
            While (result = 404)
                result = devices(selecteddevice).WriteData(wdata)
            End While

            If result <> 0 Then
                LblStatus.Text = "Write Fail: " & result
            Else
                LblStatus.Text = "Write Success"
            End If
        End If
    End Sub

    Private Sub btnSetAllBank2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetAllBank2.Click

        If selecteddevice <> -1 Then 'do nothing if not enumerated
            Dim result As Integer = 0

            For j As Integer = 0 To devices(selecteddevice).WriteLength - 1
                wdata(j) = 0
            Next

            wdata(1) = 166 '&HA6
            wdata(2) = 1 '0=bank 1 (upper LEDs), 1=bank 2 (lower LEDs)
            wdata(3) = Convert.ToByte(txtR.Text)
            wdata(4) = Convert.ToByte(txtG.Text)
            wdata(5) = Convert.ToByte(txtB.Text)

            result = 404
            While (result = 404)
                result = devices(selecteddevice).WriteData(wdata)
            End While

            If result <> 0 Then
                LblStatus.Text = "Write Fail: " & result
            Else
                LblStatus.Text = "Write Success"
            End If
        End If
    End Sub

    Private Sub btnRGBIntensity_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRGBIntensity.Click
        'RGB global (per bank) dimming control - this command is meant to be used once the banks of LEDs have been configured to the desired colors. 255 is the brightest or 100% on and 0 is the dimmest.
        'Use caution if set a dim factor to 0, LEDs will be off and will not be able to be turned on without changing the dim factor to a non-0 value.
        If selecteddevice <> -1 Then 'do nothing if not enumerated
            Dim result As Integer = 0

            For j As Integer = 0 To devices(selecteddevice).WriteLength - 1
                wdata(j) = 0
            Next

            wdata(1) = 164 '&HA4
            wdata(2) = Convert.ToByte(txtBank1.Text)
            wdata(3) = Convert.ToByte(txtBank2.Text)

            result = 404
            While (result = 404)
                result = devices(selecteddevice).WriteData(wdata)
            End While

            If result <> 0 Then
                LblStatus.Text = "Write Fail: " & result
            Else
                LblStatus.Text = "Write Success"
            End If
        End If
    End Sub

    Private Sub ChkBLOnOff_CheckStateChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkBLOnOff.CheckStateChanged
        'Use the Set Flash Freq to control frequency of blink
        'Index (in decimal)
        'Columns-->
        'Bank 1 (Upper) LEDs
        '  0   3   6  9  
        '  1   4   7  10  
        '  2   5   8  11  
        'Bank 2 (Lower) LEDs
        '  12   15   18  21 
        '  13   16   19  22  
        '  14   17   20  23  

        If selecteddevice <> -1 Then
            'first get selected index
            Dim bank As Integer
            bank = CboBankLegacy.SelectedIndex
            Dim iindex As Integer
            iindex = CboBL.SelectedIndex
            If CboBankLegacy.SelectedIndex = 1 Then
                iindex = iindex + 12
            End If

            'now get state
            Dim state As Integer = 0
            state = ChkBLOnOff.CheckState

            For i As Integer = 0 To devices(selecteddevice).WriteLength - 1
                wdata(i) = 0
            Next

            wdata(1) = 181
            wdata(2) = CByte(iindex) 'Key Index
            wdata(3) = CByte(state) '0=off, 1=on, 2=flash

            Dim result As Integer
            result = 404
            While (result = 404)
                result = devices(selecteddevice).WriteData(wdata)
            End While

            If result <> 0 Then
                LblStatus.Text = "Write Fail: " + result.ToString
            Else
                LblStatus.Text = "Write Success - Legacy Backlight"
            End If
        End If
    End Sub

    Private Sub btnSetInOut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetInOut.Click
        If selecteddevice <> -1 Then
            Dim gpioconfig As Byte = &HFF
            Dim inputconfig As Byte = 0
            If rb1O.Checked = True Then
                gpioconfig = CByte((gpioconfig And Not 1))
            Else
                If rb1I.Checked = True Then
                    inputconfig = CByte((inputconfig Or 1))
                End If
            End If

            If rb2O.Checked = True Then
                gpioconfig = CByte((gpioconfig And Not 2))
            Else
                If rb2I.Checked = True Then
                    inputconfig = CByte((inputconfig Or 2))
                End If
            End If

            If rb3O.Checked = True Then
                gpioconfig = CByte((gpioconfig And Not 4))
            Else
                If rb3I.Checked = True Then
                    inputconfig = CByte((inputconfig Or 4))
                End If
            End If

            If rb4O.Checked = True Then
                gpioconfig = CByte((gpioconfig And Not 8))
            Else
                If rb4I.Checked = True Then
                    inputconfig = CByte((inputconfig Or 8))
                End If
            End If

            wdata(0) = 0
            wdata(1) = 147
            wdata(2) = gpioconfig 'pins 1, 2, 3, 4 MSB 0-0-0-0-4-3-2-1 LSB 0=output, 1=input
            wdata(3) = inputconfig 'pins 5, 6, 7, 8, 11, 12 MSB 0-0-12-11-8-7-6-5 LSB 0=output, 1=input

            Dim result As Integer = 404

            While (result = 404)
                result = devices(selecteddevice).WriteData(wdata)
            End While

            If result <> 0 Then
                LblStatus.Text = "Write Fail: " + result.ToString
            Else
                LblStatus.Text = "Write Success - Configure GPIO"
            End If

        End If
    End Sub

    Private Sub btnSaveInOut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveInOut.Click
        If selecteddevice <> -1 Then
            'do nothing if not enumerated
            For j As Integer = 0 To devices(selecteddevice).WriteLength - 1
                wdata(j) = 0
            Next

            wdata(0) = 0
            wdata(1) = 148
            Dim result As Integer = 404

            While result = 404
                result = devices(selecteddevice).WriteData(wdata)
            End While
            If result <> 0 Then
                LblStatus.Text = "Write Fail: " + result
            Else
                LblStatus.Text = "Write Success - Save GPIO Configuration"
            End If
        End If
    End Sub

    Private Sub btnSiliconGeneratedID_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSiliconGeneratedID.Click
        If selecteddevice <> -1 Then

            ' //This command is only necessary if devices[].SerialNumberString is not available on enumerate
            ' //Sending the command will make the device return information about it
            Dim savecallbackstate As Boolean = devices(selecteddevice).callNever
            devices(selecteddevice).callNever = True

            For i As Integer = 0 To devices(selecteddevice).WriteLength - 1
                wdata(i) = 0
            Next

            wdata(0) = 0
            wdata(1) = 157

            Dim result As Integer
            result = 404
            While (result = 404)
                result = devices(selecteddevice).WriteData(wdata)
            End While

            If result <> 0 Then
                LblStatus.Text = "Write Fail: " + result.ToString
            Else
                LblStatus.Text = "Write Success - Silicon Generated ID"
            End If
            'after this write the next read with 3rd byte = 214 gives descriptor data
            Dim ddata(devices(selecteddevice).ReadLength) As Byte
            Dim countout As Integer = 0
            result = devices(selecteddevice).BlockingReadData(ddata, 100)
            While (result = 304 Or (result = 0 And ddata(2) <> 157))
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

            Dim uniqueID As String = ""
            For i As Integer = 0 To 7
                uniqueID = uniqueID + BinToHex(ddata(i + 3))
            Next
            lblSiliconGeneratedID.Text = uniqueID
            devices(selecteddevice).callNever = savecallbackstate
        End If
    End Sub

    Private Sub btnVirtualButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVirtualButton.Click
        '   //Virtually press or release a button
        '    //for physical buttons use the index shown below for the ID
        '    //Index (in decimal)
        '    //Columns-->
        '    //  0   3  6   9
        '    //  1   4  7   10
        '    //  2   5  8   11
        '    //for GPIO Pin 1 ID =100, GPIO Pin 2 ID =101, GPIO Pin 3 ID=102, GPIO Pin 4 ID=103
        '    //for the 8 virtual buttons use ID 104-111
        '    //to clear ALL virtual buttons, ie all virtual buttons pressed are released, use ID=255, if using 255 then state is ignored

        If selecteddevice <> -1 Then 'do nothing if not enumerated

            Dim state As Integer = 1
            If rbRelease.Checked = True Then
                state = 2
            End If

            Dim ID As Integer = Convert.ToInt16(txtVirtualButton.Text)

            For j As Integer = 0 To devices(selecteddevice).WriteLength - 1
                wdata(j) = 0
            Next

            wdata(0) = 0
            wdata(1) = 220 '&HDC
            wdata(2) = CByte(ID) 'Index
            wdata(3) = CByte(state) '1=press (bit set), 2=release (bit unset)

            Dim result As Integer = 404

            While result = 404
                result = devices(selecteddevice).WriteData(wdata)
            End While
            If result <> 0 Then
                LblStatus.Text = "Write Fail: " + result
            Else
                LblStatus.Text = "Write Success - Virtual Button"
            End If
        End If
    End Sub

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
End Class
