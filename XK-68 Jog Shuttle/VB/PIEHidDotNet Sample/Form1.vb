Imports System
Imports System.Text

Public Class Form1
    Implements PIEHid32Net.PIEDataHandler
    Implements PIEHid32Net.PIEErrorHandler

    Dim devices() As PIEHid32Net.PIEDevice
    Dim selecteddevice As Integer
    Dim cbotodevice(127) As Integer 'max # of devices = 128 
    Dim wdata() As Byte = New Byte() {} 'write data buffer

    Dim lastdata() As Byte = New Byte() {} 'keeps track of the previous input report

    Dim saveabsolutetime As Long
    ' This delegate enables asynchronous calls for setting
    ' the text property on a TextBox control.
    Delegate Sub SetTextCallback(ByVal [text] As String)
    Dim c As Control
    Dim mouseon As Boolean = False

    Public Sub HandlePIEHidData(ByVal data() As Byte, ByVal sourceDevice As PIEHid32Net.PIEDevice, ByVal perror As Integer) Implements PIEHid32Net.PIEDataHandler.HandlePIEHidData
        'data callback
        'MsgBox("The event handler caught the event.")
        If sourceDevice.Pid = devices(selecteddevice).Pid Then

            Dim output As String
            output = "Callback: " + sourceDevice.Pid.ToString + ", ID: " + selecteddevice.ToString + ", data="
            For i As Integer = 0 To sourceDevice.ReadLength - 1
                output = output + BinToHex(data(i)) + " "
            Next

            'Use thread-safe calls to windows forms controls
            SetListBox(output)

            If data(2) And 1 Then
                c = LblSwitchPos
                SetText("Switch Down")
            Else
                c = LblSwitchPos
                SetText("Switch Up")
            End If
            c = LblUnitID
            SetText(data(1).ToString)


            If (data(2) < 2) Then
                'Buttons
                Dim maxcols As Integer = 10 'number of columns of Xkeys digital button data, labeled "Keys" in P.I. Engineering SDK - General Incoming Data Input Report
                Dim maxrows As Integer = 8 'constant, 8 bits per byte
                c = LblButtons
                Dim buttonsdown As String = "Buttons: "
                SetText(buttonsdown)
                For i As Integer = 0 To maxcols - 1 'loop through digital button bytes 
                    If i = 3 OrElse i = 4 OrElse i = 5 OrElse i = 6 Then 'take out the jog shuttle bits, they are handled below
                        maxrows = 5
                    Else
                        maxrows = 8
                    End If
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

                            Case 2

                                If state = 1 Then
                                ElseIf state = 3 Then
                                End If

                            Case 3

                                If state = 1 Then
                                ElseIf state = 3 Then
                                End If

                            Case 4

                                If state = 1 Then
                                ElseIf state = 3 Then
                                End If

                            Case 5

                                If state = 1 Then
                                ElseIf state = 3 Then
                                End If

                            Case 6

                                If state = 1 Then
                                ElseIf state = 3 Then
                                End If

                            Case 7

                                If state = 1 Then
                                ElseIf state = 3 Then
                                End If
                                'End of column.
                            Case 8

                                If state = 1 Then
                                ElseIf state = 3 Then
                                End If

                            Case 9

                                If state = 1 Then
                                ElseIf state = 3 Then
                                End If

                            Case 10

                                If state = 1 Then
                                ElseIf state = 3 Then
                                End If

                            Case 11

                                If state = 1 Then
                                ElseIf state = 3 Then
                                End If

                            Case 12

                                If state = 1 Then
                                ElseIf state = 3 Then
                                End If

                            Case 13

                                If state = 1 Then
                                ElseIf state = 3 Then
                                End If

                            Case 14

                                If state = 1 Then
                                ElseIf state = 3 Then
                                End If

                            Case 15

                                If state = 1 Then
                                ElseIf state = 3 Then
                                End If
                                'End of column.
                            Case 16

                                If state = 1 Then
                                ElseIf state = 3 Then
                                End If

                            Case 17

                                If state = 1 Then
                                ElseIf state = 3 Then
                                End If

                            Case 18

                                If state = 1 Then
                                ElseIf state = 3 Then
                                End If

                            Case 19

                                If state = 1 Then
                                ElseIf state = 3 Then
                                End If

                            Case 20

                                If state = 1 Then
                                ElseIf state = 3 Then
                                End If

                            Case 21

                                If state = 1 Then
                                ElseIf state = 3 Then
                                End If

                            Case 22

                                If state = 1 Then
                                ElseIf state = 3 Then
                                End If

                            Case 23

                                If state = 1 Then
                                ElseIf state = 3 Then
                                End If
                                'End of column.
                            Case 24

                                If state = 1 Then
                                ElseIf state = 3 Then
                                End If

                            Case 25

                                If state = 1 Then
                                ElseIf state = 3 Then
                                End If

                            Case 26

                                If state = 1 Then
                                ElseIf state = 3 Then
                                End If

                            Case 27

                                If state = 1 Then
                                ElseIf state = 3 Then
                                End If

                            Case 28

                                If state = 1 Then
                                ElseIf state = 3 Then
                                End If
                                'End of column.
                                'Buttons 29-31 covered by Jog Shuttle.

                            Case 32

                                If state = 1 Then
                                ElseIf state = 3 Then
                                End If

                            Case 33

                                If state = 1 Then
                                ElseIf state = 3 Then
                                End If

                            Case 34

                                If state = 1 Then
                                ElseIf state = 3 Then
                                End If

                            Case 35

                                If state = 1 Then
                                ElseIf state = 3 Then
                                End If

                            Case 36

                                If state = 1 Then
                                ElseIf state = 3 Then
                                End If
                                'End of column.
                                'Buttons 37-39 are covered by Jog Shuttle.

                            Case 40

                                If state = 1 Then
                                ElseIf state = 3 Then
                                End If

                            Case 41

                                If state = 1 Then
                                ElseIf state = 3 Then
                                End If

                            Case 42

                                If state = 1 Then
                                ElseIf state = 3 Then
                                End If

                            Case 43

                                If state = 1 Then
                                ElseIf state = 3 Then
                                End If

                            Case 44

                                If state = 1 Then
                                ElseIf state = 3 Then
                                End If
                                'End of column.
                                'Buttons 45-47 covered by Jog Shuttle.

                            Case 48

                                If state = 1 Then
                                ElseIf state = 3 Then
                                End If

                            Case 49

                                If state = 1 Then
                                ElseIf state = 3 Then
                                End If

                            Case 50

                                If state = 1 Then
                                ElseIf state = 3 Then
                                End If

                            Case 51

                                If state = 1 Then
                                ElseIf state = 3 Then
                                End If

                            Case 52

                                If state = 1 Then
                                ElseIf state = 3 Then
                                End If
                                'End of column.
                                'Buttons 53-55 covered by Jog Shuttle.

                            Case 56

                                If state = 1 Then
                                ElseIf state = 3 Then
                                End If

                            Case 57

                                If state = 1 Then
                                ElseIf state = 3 Then
                                End If

                            Case 58

                                If state = 1 Then
                                ElseIf state = 3 Then
                                End If

                            Case 59

                                If state = 1 Then
                                ElseIf state = 3 Then
                                End If

                            Case 60

                                If state = 1 Then
                                ElseIf state = 3 Then
                                End If

                            Case 61

                                If state = 1 Then
                                ElseIf state = 3 Then
                                End If

                            Case 62

                                If state = 1 Then
                                ElseIf state = 3 Then
                                End If

                            Case 63

                                If state = 1 Then
                                ElseIf state = 3 Then
                                End If
                                'End of column.
                            Case 64

                                If state = 1 Then
                                ElseIf state = 3 Then
                                End If

                            Case 65

                                If state = 1 Then
                                ElseIf state = 3 Then
                                End If

                            Case 66

                                If state = 1 Then
                                ElseIf state = 3 Then
                                End If

                            Case 67

                                If state = 1 Then
                                ElseIf state = 3 Then
                                End If

                            Case 68

                                If state = 1 Then
                                ElseIf state = 3 Then
                                End If

                            Case 69

                                If state = 1 Then
                                ElseIf state = 3 Then
                                End If

                            Case 70

                                If state = 1 Then
                                ElseIf state = 3 Then
                                End If

                            Case 71

                                If state = 1 Then
                                ElseIf state = 3 Then
                                End If
                                'End of column.

                            Case 72

                                If state = 1 Then
                                ElseIf state = 3 Then
                                End If

                            Case 73

                                If state = 1 Then
                                ElseIf state = 3 Then
                                End If

                            Case 74

                                If state = 1 Then
                                ElseIf state = 3 Then
                                End If

                            Case 75

                                If state = 1 Then
                                ElseIf state = 3 Then
                                End If

                            Case 76

                                If state = 1 Then
                                ElseIf state = 3 Then
                                End If

                            Case 77

                                If state = 1 Then
                                ElseIf state = 3 Then
                                End If

                            Case 78

                                If state = 1 Then
                                ElseIf state = 3 Then
                                End If

                            Case 79

                                If state = 1 Then
                                ElseIf state = 3 Then
                                End If
                                'End of column.

                        End Select
                    Next
                Next
                'end buttons

                'Keyboard States
                Dim kstate As String = "States: "
                If data(15) And 4 Then
                    kstate = kstate + "NumLk"
                End If
                If data(15) And 8 Then
                    kstate = kstate + " CapsLk"
                End If
                If data(15) And 16 Then
                    kstate = kstate + " ScrLk"
                End If

                c = LblStates
                SetText(kstate)

                'Shuttle Digital
                For i As Integer = 0 To 2
                    For j As Integer = 0 To 7

                        Dim temp1 As Integer = CInt(Math.Pow(2, j))
                        Dim keynum As Integer = 8 * i + j
                        Dim temp2 As Byte = CByte(data(i + 13) And temp1)
                        'this time
                        Dim temp3 As Byte = CByte(lastdata(i + 13) And temp1)
                        'last time
                        Dim state As Integer = 0
                        '0=was up, now up, 1=was up, now down, 2= was down, still down, 3= was down, now up
                        If temp2 <> 0 AndAlso temp3 = 0 Then
                            state = 1
                            'press
                        ElseIf temp2 <> 0 AndAlso temp3 <> 0 Then
                            state = 2
                            'held down
                        ElseIf temp2 = 0 AndAlso temp3 <> 0 Then
                            state = 3
                        End If
                        'release
                        Dim printthis As String = ""
                        Select Case keynum

                            Case 0
                                'shuttle +1
                                printthis = "Shuttle Digital: +1"
                                Exit Select
                            Case 1
                                'shuttl +2
                                printthis = "Shuttle Digital: +2"
                                Exit Select
                            Case 2
                                'shuttle +3
                                printthis = "Shuttle Digital: +3"
                                Exit Select
                            Case 3
                                'shuttle +4
                                printthis = "Shuttle Digital: +4"
                                Exit Select
                            Case 4
                                'shuttle +5
                                printthis = "Shuttle Digital: +5"
                                Exit Select
                            Case 5
                                'shuttle +6
                                printthis = "Shuttle Digital: +6"
                                Exit Select
                            Case 6
                                'shuttle +7
                                printthis = "Shuttle Digital: +7"
                                Exit Select
                            Case 7
                                'Shuttle 0
                                printthis = "Shuttle At Rest"
                                Exit Select
                            Case 8
                                'shuttle -1
                                printthis = "Shuttle Digital: -1"
                                Exit Select
                            Case 9
                                'shuttl -2
                                printthis = "Shuttle Digital: -2"
                                Exit Select
                            Case 10
                                'shuttle -3
                                printthis = "Shuttle Digital: -3"
                                Exit Select
                            Case 11
                                'shuttle -4
                                printthis = "Shuttle Digital: -4"
                                Exit Select
                            Case 12
                                'shuttle -5
                                printthis = "Shuttle Digital: -5"
                                Exit Select
                            Case 13
                                'shuttle -6
                                printthis = "Shuttle Digital: -6"
                                Exit Select
                            Case 14
                                'shuttle -7
                                printthis = "Shuttle Digital: -7"
                                Exit Select
                        End Select

                        If state = 1 Then
                            If keynum <> 7 AndAlso keynum <> 15 Then
                                c = LblShuttleD
                                SetText(printthis)
                                c = LblShuttleD

                                SetText(printthis)
                            End If
                        End If

                    Next
                Next

                'More Jog & Shuttle Digital
                If data(8) And 128 Then
                    c = LblShuttleD
                    SetText("Shuttle Digital: At rest")
                End If
                If data(6) And 128 Then
                    c = LblJogD
                    SetText("Jog Digital: Clockwise")
                End If
                If data(7) And 128 Then
                    c = LblJogD
                    SetText("Jog Digital: Counter Clockwise")
                End If

                'Jog Analog
                If (data(17) = 1) Then
                    c = LblJog
                    SetText("Jog Analog: Clockwise")
                ElseIf (data(17) = 255) Then
                    c = LblJog
                    SetText("Jog Analog: Counter Clockwise")
                End If

                'Shuttle Analog
                c = LblShuttle
                SetText("Shuttle Analog: " + data(18).ToString())



                'time stamp info 4 bytes
                Dim absolutetime As Long = 16777216 * data(19) + 65536 * data(20) + 256 * data(21) + data(22) 'ms
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

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ListBox1.Items.Clear()
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        selecteddevice = -1
        CboKeyIndex.SelectedIndex = 0
        CboColor.SelectedIndex = 0
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

                If devices(i).HidUsagePage = 12 Then

                    Select Case devices(i).Pid
                        Case 1114
                            CboDevices.Items.Add("XK-68 Jog & Shuttle (" + devices(i).Pid.ToString + "=PID #1): " + i.ToString)
                            cbotodevice(cbocount) = i
                            cbocount = cbocount + 1
                        Case 1115
                            CboDevices.Items.Add("XK-68 Jog & Shuttle(" + devices(i).Pid.ToString + "): " + i.ToString)
                            cbotodevice(cbocount) = i
                            cbocount = cbocount + 1
                        Case 1116
                            CboDevices.Items.Add("XK-68 Jog & Shuttle (" + devices(i).Pid.ToString + "=PID #2): " + i.ToString)
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
            ReDim lastdata(devices(selecteddevice).ReadLength - 1)
            LblVersion.Text = devices(selecteddevice).Version.ToString()
        End If
    End Sub


    Private Sub BtnRed_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub BtnGreen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub BtnNoLEDS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub BtnFlashLEDs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub BtnStopFlash_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

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

    Private Sub BtnBL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBL.Click

        If selecteddevice <> -1 Then

            For i As Integer = 0 To devices(selecteddevice).WriteLength - 1
                wdata(i) = 0
            Next

            wdata(0) = 0
            wdata(1) = 187
            wdata(2) = TextBox12.Text '0-255 for bank 1 backlight intensity
            wdata(3) = TextBox13.Text '0-255 for bank 2 backlight intensity

            Dim result As Integer
            result = 404
            While (result = 404)
                result = devices(selecteddevice).WriteData(wdata)
            End While

            If result <> 0 Then
                LblStatus.Text = "Write Fail: " + result.ToString
            Else
                LblStatus.Text = "Write Success - Intensity"
            End If
        End If
    End Sub
    Private Sub BtnBLToggle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBLToggle.Click
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
                LblStatus.Text = "Write Success - Backlight Toggle"
            End If
        End If
    End Sub

    Private Sub ChkScrollLock_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub ChkGreenOnOff_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkGreenOnOff.CheckedChanged
        'turns on or off, depending on value of ChkGreenOnOff, ALL bank 1 BLs using current intensity
        Dim s1 As Byte
        s1 = 0

        If (ChkGreenOnOff.Checked = True) Then s1 = 255

        If selecteddevice <> -1 Then
            For i As Integer = 0 To devices(selecteddevice).WriteLength - 1
                wdata(i) = 0
            Next

            wdata(0) = 0
            wdata(1) = 182
            wdata(2) = 0  '0 for bank 1, 1 for bank 2
            wdata(3) = s1 'OR turn individual rows on or off using bits.  1st bit=row 1, 2nd bit=row 2, 3rd bit =row 3, etc

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

    Private Sub ChkRedOnOff_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkRedOnOff.CheckedChanged
        'turns on or off, depending on value of ChkRedOnOff, ALL bank 2 BLs using current intensity
        Dim s1 As Byte
        s1 = 0

        If (ChkRedOnOff.Checked = True) Then s1 = 255

        If selecteddevice <> -1 Then
            For i As Integer = 0 To devices(selecteddevice).WriteLength - 1
                wdata(i) = 0
            Next

            wdata(0) = 0
            wdata(1) = 182
            wdata(2) = 1  '0 for bank 1, 1 for bank 2
            wdata(3) = s1

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
        'same frequency for both LEDs and Backlighting
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
                LblStatus.Text = "Write Success - Set Flash Frequency"
            End If
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
            wdata(1) = 199
            wdata(2) = 1 'anything other than 0 will save bl state to eeprom, default is 0

            Dim result As Integer
            result = 404
            While (result = 404)
                result = devices(selecteddevice).WriteData(wdata)
            End While

            If result <> 0 Then
                LblStatus.Text = "Write Fail: " + result.ToString
            Else
                LblStatus.Text = "Write Success - Save Backlighting"
            End If
        End If
    End Sub

    Private Sub BtnTimeStamp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTimeStamp.Click
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
                LblStatus.Text = "Write Success - time stamp"
            End If
        End If
    End Sub
    Private Sub BtnTimeStampOn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTimeStampOn.Click
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
                LblStatus.Text = "Write Success - time stamp"
            End If
        End If
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

    Private Sub BtnJoyreflect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnJoyreflect.Click
        'open up the game controller control panel to test these features, after clicking this button
        'go and make active the control panel properties and change will be seen
        If selecteddevice <> -1 Then

            For i As Integer = 0 To devices(selecteddevice).WriteLength - 1
                wdata(i) = 0
            Next

            wdata(0) = 0
            wdata(1) = 202
            wdata(2) = System.Math.Abs((Convert.ToByte(textBox2.Text) Xor 127) - 255) 'X, in raw form 0 to 127 from center to right, 255 to 128 from center to left but I like to use 0-255 where 0 is max left, 255 is max right
            wdata(3) = (Convert.ToByte(textBox3.Text) Xor 127) 'Y, raw data 0 to 127 from center down, 255 to 128 from center up, I convert so I can enter 0-255
            wdata(4) = (Convert.ToByte(TextBox8.Text) Xor 127) 'Z rot, raw data 0 to 127 from center down, 255 to 128 from center up, I convert so I can enter 0-255
            wdata(5) = (Convert.ToByte(textBox4.Text) Xor 127) 'Z, raw data 0 to 127 from center down, 255 to 128 from center up, I convert so I can enter 0-255
            wdata(6) = (Convert.ToByte(TextBox7.Text) Xor 127) 'Slider, raw data 0 to 127 from center down, 255 to 128 from center up, I convert so I can enter 0-255

            wdata(7) = Convert.ToByte(textBox5.Text) 'buttons as a bitmap, 0-255, 1=button 1, 2=button 2, 4=button 3, etc.. ex:  3=button 1 and button 2 down
            wdata(8) = Convert.ToByte(TextBox9.Text) 'buttons as a bitmap, 0-255, 1=button 9, 2=button 10, 4=button 11, etc..
            wdata(9) = Convert.ToByte(TextBox10.Text) 'buttons as a bitmap, 0-255, 1=button 17, 2=button 18, 4=button 19, etc..
            wdata(10) = Convert.ToByte(TextBox11.Text) 'buttons as a bitmap, 0-255, 1=button 25, 2=button 26, 4=button 27, etc..

            wdata(11) = 0

            wdata(12) = Convert.ToByte(textBox6.Text) 'hat, 0-8 where 8 is no hat

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
                If (countout > 500) Then
                    Exit While
                End If
                result = devices(selecteddevice).BlockingReadData(ddata, 100)
            End While
            listBox2.Items.Clear()
            If (ddata(3) = 0) Then
                listBox2.Items.Add("PID #1")
            ElseIf (ddata(3) = 2) Then
                listBox2.Items.Add("PID #2")
            End If
            listBox2.Items.Add("Keymapstart=" + ddata(4).ToString)
            listBox2.Items.Add("Layer2offset=" + ddata(5).ToString)
            listBox2.Items.Add("OutSize" + ddata(6).ToString)
            listBox2.Items.Add("ReportSize=" + ddata(7).ToString)
            listBox2.Items.Add("MaxCol=" + ddata(8).ToString)
            listBox2.Items.Add("MaxRow=" + ddata(9).ToString)
            Dim ledon As String = ""
            If (ddata(10) And 64) Then
                ledon = "Green LED "
            End If
            If (ddata(10) And 128) Then
                ledon = "Red LED "
            End If

            If (ledon = "") Then
                ledon = "None"
            End If
            listBox2.Items.Add("LEDs=" + ledon)
            listBox2.Items.Add("Version=" + ddata(11).ToString)
            Dim temp As String = "PID=" + (ddata(13) * 256 + ddata(12)).ToString
            listBox2.Items.Add(temp)
        End If
    End Sub

    Private Sub BtnSetKey_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub BtnCheckKey_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub BtnReflector_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If selecteddevice <> -1 Then
            For i As Integer = 0 To devices(selecteddevice).WriteLength - 1
                wdata(i) = 0
            Next

            wdata(0) = 0
            wdata(1) = 204
            wdata(2) = 0

            Dim result As Integer
            result = 404
            While (result = 404)
                result = devices(selecteddevice).WriteData(wdata)
            End While

            If result <> 0 Then
                LblStatus.Text = "Write Fail: " + result.ToString
            Else
                LblStatus.Text = "Write Success - to PID 1027"
            End If
        End If
    End Sub

    Private Sub BtnSplat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If selecteddevice <> -1 Then
            For i As Integer = 0 To devices(selecteddevice).WriteLength - 1
                wdata(i) = 0
            Next

            wdata(0) = 0
            wdata(1) = 204
            wdata(2) = 2

            Dim result As Integer
            result = 404
            While (result = 404)
                result = devices(selecteddevice).WriteData(wdata)
            End While

            If result <> 0 Then
                LblStatus.Text = "Write Fail: " + result.ToString
            Else
                LblStatus.Text = "Write Success - to PID 1029"
            End If
        End If

    End Sub

    Private Sub ChkGreenLED_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkGreenLED.CheckedChanged
        'turn on the green LED
        If selecteddevice <> -1 Then
            Dim saveled As Integer = wdata(2)

            For i As Integer = 0 To devices(selecteddevice).WriteLength - 1
                wdata(i) = 0
            Next

            wdata(1) = 179
            wdata(2) = 6 '6 for green, 7 for red

            If ChkGreenLED.Checked = True Then
                wdata(3) = 1 '0=off, 1=on, 2=flash
                If ChkFGreenLED.Checked = True Then
                    wdata(3) = 2
                End If
            End If

            Dim result As Integer
            result = 404
            While (result = 404)
                result = devices(selecteddevice).WriteData(wdata)
            End While

            If result <> 0 Then
                LblStatus.Text = "Write Fail: " + result.ToString
            Else
                LblStatus.Text = "Write Success - Green LED"
            End If
        End If
    End Sub

    Private Sub ChkRedLED_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkRedLED.CheckedChanged
        'turn on the red LED
        If selecteddevice <> -1 Then
            Dim saveled As Integer = wdata(2)

            For i As Integer = 0 To devices(selecteddevice).WriteLength - 1
                wdata(i) = 0
            Next

            wdata(1) = 179
            wdata(2) = 7 '6 for green, 7 for red

            If ChkRedLED.Checked = True Then
                wdata(3) = 1 '0=off, 1=on, 2=flash
                If ChkFRedLED.Checked = True Then
                    wdata(3) = 2
                End If
            End If

            Dim result As Integer
            result = 404
            While (result = 404)
                result = devices(selecteddevice).WriteData(wdata)
            End While

            If result <> 0 Then
                LblStatus.Text = "Write Fail: " + result.ToString
            Else
                LblStatus.Text = "Write Success - Red LED"
            End If
        End If
    End Sub

    Private Sub ChkFGreenLED_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkFGreenLED.CheckedChanged
        'flash the green LED
        If selecteddevice <> -1 Then
            Dim saveled As Integer = wdata(2)

            For i As Integer = 0 To devices(selecteddevice).WriteLength - 1
                wdata(i) = 0
            Next

            wdata(1) = 179
            wdata(2) = 6 '6 for green, 7 for red

            If ChkFGreenLED.Checked = True Then
                wdata(3) = 2 '0=off, 1=on, 2=flash
            Else
                If ChkGreenLED.Checked = True Then
                    wdata(3) = 1
                End If
            End If

            Dim result As Integer
            result = 404
            While (result = 404)
                result = devices(selecteddevice).WriteData(wdata)
            End While

            If result <> 0 Then
                LblStatus.Text = "Write Fail: " + result.ToString
            Else
                LblStatus.Text = "Write Success - Green LED"
            End If
        End If
    End Sub

    Private Sub ChkFRedLED_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkFRedLED.CheckedChanged
        'flash the red LED
        If selecteddevice <> -1 Then
            Dim saveled As Integer = wdata(2)

            For i As Integer = 0 To devices(selecteddevice).WriteLength - 1
                wdata(i) = 0
            Next

            wdata(1) = 179
            wdata(2) = 7 '6 for green, 7 for red

            If ChkFRedLED.Checked = True Then
                wdata(3) = 2 '0=off, 1=on, 2=flash
            Else
                If ChkRedLED.Checked = True Then
                    wdata(3) = 1
                End If
            End If

            Dim result As Integer
            result = 404
            While (result = 404)
                result = devices(selecteddevice).WriteData(wdata)
            End While

            If result <> 0 Then
                LblStatus.Text = "Write Fail: " + result.ToString
            Else
                LblStatus.Text = "Write Success - Red LED"
            End If
        End If
    End Sub

    Private Sub ChkBLOnOff_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkBLOnOff.CheckedChanged
        'use the Set Flash Freq to control frequency of blink
        'Key Index for XK-68 Jog (in decimal)
        'Columns-->
        ' 0  8 16 24 32 40 48 56 64 72
        ' 1  9 17 25 33 41 49 57 65 73
        ' 2 10 18 26 34 42 50 58 66 74
        ' 3 11 19 27 35 43 51 59 67 75
        ' 4 12 20 28 36 44 52 60 68 76
        ' 5 13 21 -- -- -- -- 61 69 77
        ' 6 14 22 -- -- -- -- 62 70 78
        ' 7 15 23 -- -- -- -- 63 71 79


        If selecteddevice <> -1 Then

            'get selected index from the combobox
            Dim sindex As String = CboKeyIndex.Text
            Dim iindex As Integer
            If (CboColor.SelectedIndex = 0) Then  'bank 1
                iindex = Convert.ToInt32(sindex)
            Else
                iindex = Convert.ToInt32(sindex) + 80 'add 80 to the bank 1 index to get the corresponding bank 2 index
            End If


            For i As Integer = 0 To devices(selecteddevice).WriteLength - 1
                wdata(i) = 0
            Next
            wdata(0) = 0
            wdata(1) = 181
            wdata(2) = iindex

            If (ChkBLOnOff.Checked = True) Then
                wdata(3) = 1
                If (ChkFlash.Checked = True) Then
                    wdata(3) = 2
                End If
            End If

            Dim result As Integer
            result = 404
            While (result = 404)
                result = devices(selecteddevice).WriteData(wdata)
            End While

            If result <> 0 Then
                LblStatus.Text = "Write Fail: " + result.ToString
            Else
                LblStatus.Text = "Write Success - Backlight"
            End If
            
        End If
    End Sub

    Private Sub ChkFlash_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkFlash.CheckedChanged
        'use the Set Flash Freq to control frequency of blink
        'Key Index for XK-68 Jog (in decimal)
        'Columns-->
        ' 0  8 16 24 32 40 48 56 64 72
        ' 1  9 17 25 33 41 49 57 65 73
        ' 2 10 18 26 34 42 50 58 66 74
        ' 3 11 19 27 35 43 51 59 67 75
        ' 4 12 20 28 36 44 52 60 68 76
        ' 5 13 21 -- -- -- -- 61 69 77
        ' 6 14 22 -- -- -- -- 62 70 78
        ' 7 15 23 -- -- -- -- 63 71 79

        If selecteddevice <> -1 Then

            'get selected index from the combobox
            Dim sindex As String = CboKeyIndex.Text
            Dim iindex As Integer
            If (CboColor.SelectedIndex = 0) Then  'bank 1
                iindex = Convert.ToInt32(sindex)
            Else
                iindex = Convert.ToInt32(sindex) + 80 'add 80 to the bank 1 index to get the corresponding bank 2 index
            End If


            For i As Integer = 0 To devices(selecteddevice).WriteLength - 1
                wdata(i) = 0
            Next
            wdata(0) = 0
            wdata(1) = 181
            wdata(2) = iindex

            If (ChkBLOnOff.Checked = True) Then
                wdata(3) = 1
                If (ChkFlash.Checked = True) Then
                    wdata(3) = 2
                End If
            End If

            Dim result As Integer
            result = 404
            While (result = 404)
                result = devices(selecteddevice).WriteData(wdata)
            End While

            If result <> 0 Then
                LblStatus.Text = "Write Fail: " + result.ToString
            Else
                LblStatus.Text = "Write Success - Backlight"
            End If
            
        End If
    End Sub

    Private Sub BtnGetDataNow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGetDataNow.Click

        'After sending this command a general incoming data report will be given with
        'the 3rd byte (Data Type) 2nd bit set.  If program switch is up byte 3 will be 2
        'and if it is pressed byte 3 will be 3.  This is useful for getting the initial state
        'or unit id of the device before it sends any data.
        If selecteddevice <> -1 Then

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
            wdata(5) = Convert.ToByte(TxtWheelX.Text)
            wdata(6) = Convert.ToByte(TxtWheel.Text) 'Wheel Y. 128=0 no motion, 1-127 is up, 255-129=down, finest inc (1 and 255) to coarsest (127 and 129).

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
            wdata(5) = 0 'Wheel X
            wdata(6) = 0 'Wheel Y

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

    Private Sub BtnToPID2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnToPID2.Click
        If selecteddevice <> -1 Then
            For i As Integer = 0 To devices(selecteddevice).WriteLength - 1
                wdata(i) = 0
            Next

            wdata(0) = 0
            wdata(1) = 204
            wdata(2) = 2 '0=PID #2, 2=PID #1

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

    Private Sub ToPID1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToPID1.Click
        If selecteddevice <> -1 Then
            For i As Integer = 0 To devices(selecteddevice).WriteLength - 1
                wdata(i) = 0
            Next

            wdata(0) = 0
            wdata(1) = 204
            wdata(2) = 0 '0=PID #2, 2=PID #1

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
    Public Shared Function BinToHex(ByVal value As [Byte]) As [String]
        Dim sb As New StringBuilder("")
        sb.Append(value.ToString("X2"))
        'the 2 means 2 digits
        Return sb.ToString()
    End Function

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If selecteddevice <> -1 Then

            For i As Integer = 0 To devices(selecteddevice).WriteLength - 1
                wdata(i) = 0
            Next

            'first turn on bank 1
            wdata(0) = 0
            wdata(1) = 182 'B6h
            wdata(2) = 0 'bank, 0=bank 1, 1=bank 2
            wdata(3) = 255

            Dim result As Integer
            result = 404
            While (result = 404)
                result = devices(selecteddevice).WriteData(wdata)
            End While

            wdata(0) = 0
            wdata(1) = 173 'ADh
            wdata(2) = 0 'bank, 0=bank 1, 1=bank 2
            wdata(3) = 1 '0=decrease, 1=increase
            wdata(4) = 0 '0=wrap, 1=no wrap

            result = 404
            While (result = 404)
                result = devices(selecteddevice).WriteData(wdata)
            End While

            If result <> 0 Then
                LblStatus.Text = "Write Fail: " + result.ToString
            Else
                LblStatus.Text = "Write Success - Incremental Intensity"
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

    Private Sub BtnCustom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCustom.Click
        'After sending this command a custom incoming data report will be given with
        'the 3rd byte (Data Type) set to 0xE0, the 4th byte set to the count given below when the command was sent
        'and the following bytes whatever the user wishes.  In this example we are send 3 bytes; 1, 2, 3

        If selecteddevice <> -1 Then
            'do nothing if not enumerated
            devices(selecteddevice).callNever = False
            For j As Integer = 0 To devices(selecteddevice).WriteLength - 1
                wdata(j) = 0
            Next

            wdata(0) = 0
            wdata(1) = 224
            '0xe0
            wdata(2) = 3
            'count of bytes to follow
            wdata(3) = 1
            '1st custom byte
            wdata(4) = 2
            '2nd custom byte
            wdata(5) = 3
            '3rd custom byte

            Dim result As Integer
            result = 404
            While (result = 404)
                result = devices(selecteddevice).WriteData(wdata)
            End While

            If result <> 0 Then
                LblStatus.Text = "Write Fail: " + result
            Else
                LblStatus.Text = "Write Success - Custom Data"
            End If
        End If
    End Sub

    Private Sub BtnVersion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnVersion.Click
        'Write version, this is a 2 byte number that is available on enumeration.  You must reboot the device to see the 
        'newly written version!
        If selecteddevice <> -1 Then
            'do nothing if not enumerated
            For j As Integer = 0 To devices(selecteddevice).WriteLength - 1
                wdata(j) = 0
            Next

            wdata(0) = 0
            wdata(1) = 195 'c3
            wdata(2) = CByte(Convert.ToInt16(TxtVersion.Text))
            wdata(3) = CByte((Convert.ToInt16(TxtVersion.Text)) >> 8)

            Dim result As Integer
            result = 404
            While (result = 404)
                result = devices(selecteddevice).WriteData(wdata)
            End While

            If result <> 0 Then
                LblStatus.Text = "Write Fail: " + result
            Else
                LblStatus.Text = "Write Success - Write Version"
            End If
            'reboot device either manually with a hotplug or using the command below, to use this uncomment out the WriteData line,
            'must re-enumerate after sending
            devices(selecteddevice).callNever = True
            wdata(0) = 0
            wdata(1) = 238  '0xee
            wdata(2) = 0
            wdata(3) = 0

            'result = 404
            'While (result = 404)
            '    result = devices(selecteddevice).WriteData(wdata)
            'End While

            'If result <> 0 Then
            '    LblStatus.Text = "Write Fail: " + result
            'Else
            '    LblStatus.Text = "Write Success - Reboot"
            'End If
        End If
    End Sub

    Private Sub BtnSetDongle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSetDongle.Click
        'Use the Dongle feature to set a 4 byte code into the device
        If selecteddevice <> -1 Then 'do nothing if not enumerated
            'This routine is done once per unit by the developer prior to sale.
            'Pick 4 numbers between 1 and 254.
            Dim K0 As Integer = 7 'pick any number between 1 and 254, 0 and 255 not allowed
            Dim K1 As Integer = 58 'pick any number between 1 and 254, 0 and 255 not allowed
            Dim K2 As Integer = 33 'pick any number between 1 and 254, 0 and 255 not allowed
            Dim K3 As Integer = 243 'pick any number between 1 and 254, 0 and 255 not allowed
            'Save these numbers, they are needed to check the key!
            'Write these to the device
            For j As Integer = 0 To devices(selecteddevice).WriteLength - 1
                wdata(j) = 0
            Next
            wdata(0) = 0
            wdata(1) = 192
            wdata(2) = CByte(K0)
            wdata(3) = CByte(K1)
            wdata(4) = CByte(K2)
            wdata(5) = CByte(K3)

            Dim result As Integer
            result = 404
            While (result = 404)
                result = devices(selecteddevice).WriteData(wdata)
            End While

            If result <> 0 Then
                LblStatus.Text = "Write Fail: " + result
            Else
                LblStatus.Text = "Write Success-Set Dongle Key"
            End If
        End If
    End Sub

    Private Sub BtnCheckDongle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCheckDongle.Click
        'Reads the secret key set in Set Key
        'This is done within the developer's application to check for the correct
        'hardware.  The K0-K3 values must be the same as those entered in Set Key.
        If selecteddevice <> -1 Then
            'check hardware

            'IMPORTANT turn off the callback if going so data isn't grabbed there, turn it back on later (not done here)
            devices(selecteddevice).callNever = True

            'these will be returned from the hash
            Dim R0 As Integer = 0
            Dim R1 As Integer = 0
            Dim R2 As Integer = 0
            Dim R3 As Integer = 0

            'this is the key from set key
            Dim K0 As Integer = 7
            Dim K1 As Integer = 58
            Dim K2 As Integer = 33
            Dim K3 As Integer = 243

            'randomn numbers, use different numbers every check, we use the time to generate some random numbers below
            Dim rnd As New Random()
            Dim N0 As Integer = rnd.[Next](1, 254) 'pick any number between 1 and 254, 0 and 255 not allowed
            Dim N1 As Integer = rnd.[Next](1, 254) 'pick any number between 1 and 254, 0 and 255 not allowed
            Dim N2 As Integer = rnd.[Next](1, 254) 'pick any number between 1 and 254, 0 and 255 not allowed
            Dim N3 As Integer = rnd.[Next](1, 254) 'pick any number between 1 and 254, 0 and 255 not allowed
            PIEHid32Net.PIEDevice.DongleCheck2(K0, K1, K2, K3, N0, N1, N2, N3, R0, R1, R2, R3)

            For j As Integer = 0 To devices(selecteddevice).WriteLength - 1
                wdata(j) = 0
            Next
            wdata(0) = 0
            wdata(1) = 193 'c1  
            wdata(2) = CByte(N0)
            wdata(3) = CByte(N1)
            wdata(4) = CByte(N2)
            wdata(5) = CByte(N3)

            Dim result As Integer
            result = 404
            While (result = 404)
                result = devices(selecteddevice).WriteData(wdata)
            End While

            If result <> 0 Then
                LblStatus.Text = "Write Fail: " + result
            Else
                LblStatus.Text = "Write Success-Check Dongle Key"
            End If

            'after this write the next read with the 3rd byte=193 will give 4 values which are used below for comparison
            Dim data As Byte() = New Byte(99) {}
            Dim countout As Integer = 0
            Dim ret As Integer = devices(selecteddevice).BlockingReadData(data, 100)
            While (ret = 0 AndAlso data(2) <> 193) OrElse ret = 304
                If ret = 304 Then  'Didn't get any data for 100ms, increment the countout extra
                    countout += 99
                End If
                countout += 1
                If countout > 1000 Then 'increase this if have to check more than once
                    Exit While
                End If
                ret = devices(selecteddevice).BlockingReadData(data, 100)
            End While

            If ret = 0 AndAlso data(2) = 193 Then
                Dim fail As Boolean = False
                If R0 <> data(3) Then
                    fail = True
                End If
                If R1 <> data(4) Then
                    fail = True
                End If
                If R2 <> data(5) Then
                    fail = True
                End If
                If R3 <> data(6) Then
                    fail = True
                End If

                If fail = False Then
                    LblPassFail.Text = "Pass-Correct Hardware Found"
                Else
                    LblPassFail.Text = "Fail-Correct Hardward Not Found"
                End If
            End If
        End If
    End Sub
End Class
