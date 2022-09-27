Public Class Form1
    
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If IsNothing(XkRS232_1.ConnectedDevices) Then
            deviceStatus.Text = "No XC-RS232-DB9 Connected"
            deviceStatus.ForeColor = Color.Red
        Else
            deviceStatus.Text = "XC-RS232-DB9 Connected"
            deviceStatus.ForeColor = Color.Green

            'Gets the Unit ID from the device
            lblUID.Text = "Unit ID: " & XkRS232_1.ConnectedDevices(0).UnitID.ToString()

            'Gets the OEM Version ID from the device
            lblOEM.Text = "OEM Version ID: " & XkRS232_1.ConnectedDevices(0).OEMVersion.ToString()

            'Gets the Product ID from the device
            lblProductID.Text = "Product ID: " & XkRS232_1.ConnectedDevices(0).Pid.ToString()
        End If

    End Sub

    Private Sub btnUID_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUID.Click
        Dim id As Integer = Convert.ToInt32(txtUID.Text)

        'Sets device Unit ID
        XkRS232_1.SetDeviceUID(0, id)
        lblUID.Text = "Unit ID: " + XkRS232_1.ConnectedDevices(0).UnitID.ToString()
    End Sub

    Private Sub btnOEM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOEM.Click
        Dim id = Convert.ToInt32(txtOEM.Text)

        'Sets device OEM Version ID
        XkRS232_1.SetOEMVersionID(0, id, True)
    End Sub
    Private Sub btn1260_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1260.Click
        'Changes device to the 1260 Product ID (device will "replug" itself)
        'Change to this Product ID if you desire Joystick and Mouse endpoints
        XkRS232_1.ChangePID(0, 1260)
    End Sub

    Private Sub btn1257_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1257.Click
        'Changes device to the 1257 Product ID (device will "replug" itself)
        'Change to this Product ID if you desire Keyboard and Mouse endpoints
        XkRS232_1.ChangePID(0, 1257)
    End Sub

    Private Sub btnKeyboard_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnKeyboard.Click
        If (XkRS232_1.ConnectedDevices(0).KeyboardInterface = True) Then
            txtKeyboard.Focus()
            'Sends the letters 'a' 'b' and 'c'
            XkRS232_1.SendKeystrokes(0, False, False, False, False, False, False, False, False, 4, 5, 6, 0, 0, 0)
            'Releases all sent keys
            XkRS232_1.SendKeystrokes(0, False, False, False, False, False, False, False, False, 0, 0, 0, 0, 0, 0)
        Else
            MessageBox.Show("No joystick endpoint available, change to pid 1260")
        End If
    End Sub

    Private Sub btnJoystick_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnJoystick.Click
        'Sends game controller message, open Game Controllers control panel to see
        'Joystick endpoint required therefore must be in Product ID 1027 to work
        If (XkRS232_1.ConnectedDevices(0).JoystickInterface = True) Then
            Dim buttons As Boolean() = {False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False}
            XkRS232_1.SendJoystick(0, 100, 100, 0, 0, 0, 8, buttons)
        Else
            MessageBox.Show("No joystick endpoint available, change to pid 1257")
        End If
    End Sub

    Private Sub btnMouse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMouse.Click
        'Moves mouse cursor right and up from its current position
        If (XkRS232_1.ConnectedDevices(0).MouseInterface = True) Then
            XkRS232_1.SendMouse(0, False, False, False, False, False, 20, 20, 0)
        Else
            MessageBox.Show("No mouse endpoint available")
        End If
    End Sub

    Private Sub btnSetDongle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetDongle.Click
        'Enter in 4 bytes. REMEMBER these 4 bytes they will be required to check the dongle
        Dim byte1 As Byte = Convert.ToByte(txtByte1.Text)
        Dim byte2 As Byte = Convert.ToByte(txtByte2.Text)
        Dim byte3 As Byte = Convert.ToByte(txtByte3.Text)
        Dim byte4 As Byte = Convert.ToByte(txtByte4.Text)

        XkRS232_1.SetSecurityKey(0, byte1, byte2, byte3, byte4)
    End Sub

    Private Sub btnCheckDongle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCheckDongle.Click
        'Enter the 4 bytes used when XkRS232_1.SetSecurityKey was called
        Dim byte1 As Byte = Convert.ToByte(txtByte1.Text)
        Dim byte2 As Byte = Convert.ToByte(txtByte2.Text)
        Dim byte3 As Byte = Convert.ToByte(txtByte3.Text)
        Dim byte4 As Byte = Convert.ToByte(txtByte4.Text)

        'Checks the security key by sending the selected bytes to the device; bytes were valid if it returns true
        Dim dongle As Boolean = XkRS232_1.GetSecurityKey(0, byte1, byte2, byte3, byte4)

        If (dongle = True) Then
            grpDongle.BackColor = Color.Green
        ElseIf (dongle = False) Then
            grpDongle.BackColor = Color.Red
        End If
    End Sub

    Private Sub btnGenerate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerate.Click
        'Use this to get the state of the buttons even if there was no change in their states. This is often useful on start of application to get initial states of the buttons (switches).
        'Sending this command will trigger the _GenerateReportData event
        XkRS232_1.GenerateReport(0)
    End Sub

    Private Sub XkRS232_1_ButtonChange(ByVal e As XkRS232.XKeyEventArgs) Handles XkRS232_1.ButtonChange
        'This method handles the button change event for the device

        If e.PressState = True Then
            'button press
            Select Case e.CID
                Case 1001
                    lblButton01.Text = "Jack 1R-dn"
                    Exit Select
                Case 1002
                    lblButton02.Text = "Jack 1L-dn"
                    Exit Select
                Case 1003
                    lblButton03.Text = "Jack 2R-dn"
                    Exit Select
                Case 1004
                    lblButton04.Text = "Jack 2L-dn"
                    Exit Select
                Case 1005
                    lblButton05.Text = "Jack 3R-dn"
                    Exit Select
                Case 1006
                    lblButton06.Text = "Jack 3L-dn"
                    Exit Select
                Case 1007
                    lblButton07.Text = "Jack 4R-dn"
                    Exit Select
                Case 1008
                    lblButton08.Text = "Jack 4L-dn"
                    Exit Select
                Case 1009
                    lblButton09.Text = "Jack 5R-dn"
                    Exit Select
                Case 1010
                    lblButton10.Text = "Jack 5L-dn"
                    Exit Select
                Case 1011
                    lblButton11.Text = "Jack 6R-dn"
                    Exit Select
                Case 1012
                    lblButton12.Text = "Jack 6L-dn"
                    Exit Select
            End Select
        Else
            'button release
            Select Case e.CID
                Case 1001
                    lblButton01.Text = "Jack 1R-up"
                    Exit Select
                Case 1002
                    lblButton02.Text = "Jack 1L-up"
                    Exit Select
                Case 1003
                    lblButton03.Text = "Jack 2R-up"
                    Exit Select
                Case 1004
                    lblButton04.Text = "Jack 2L-up"
                    Exit Select
                Case 1005
                    lblButton05.Text = "Jack 3R-up"
                    Exit Select
                Case 1006
                    lblButton06.Text = "Jack 3L-up"
                    Exit Select
                Case 1007
                    lblButton07.Text = "Jack 4R-up"
                    Exit Select
                Case 1008
                    lblButton08.Text = "Jack 4L-up"
                    Exit Select
                Case 1009
                    lblButton09.Text = "Jack 5R-up"
                    Exit Select
                Case 1010
                    lblButton10.Text = "Jack 5L-up"
                    Exit Select
                Case 1011
                    lblButton11.Text = "Jack 6R-up"
                    Exit Select
                Case 1012
                    lblButton12.Text = "Jack 6L-up"
                    Exit Select
            End Select
        End If
        lblUID.Text = "Unit ID: " + XkRS232_1.ConnectedDevices(0).UnitID.ToString()
    End Sub

    Private Sub XkRS232_1_DataReceived(ByVal e As XkRS232.XKeyRS232EventArgs) Handles XkRS232_1.DataReceived
        listBox1.Focus()
        listBox1.Items.Add(e.AsciiReceived)
        listBox1.SelectedIndex = listBox1.Items.Count - 1
    End Sub

    Private Sub XkRS232_1_DevicePlug(ByVal e As XkRS232.XKeyPlugEventArgs) Handles XkRS232_1.DevicePlug
        deviceStatus.Text = "XC-RS232-DB9 Plugged, Unit ID: " + e.UID.ToString() + ", OEM ID: " + e.OEMVersionID.ToString() + ", Product ID: " + e.PID.ToString()
        deviceStatus.ForeColor = Color.Green

        'Gets the Unit ID from the device
        lblUID.Text = "Unit ID: " + e.UID.ToString()

        'Gets the OEM Version ID from the device
        lblOEM.Text = "OEM ID: " + e.OEMVersionID.ToString()

        'Gets the Product ID from the device
        lblProductID.Text = "Product ID: " + e.PID.ToString()
    End Sub

    Private Sub XkRS232_1_DeviceUnplug(ByVal e As XkRS232.XKeyPlugEventArgs) Handles XkRS232_1.DeviceUnplug
        deviceStatus.Text = "XC-RS232-DB9 Unplugged, Unit ID: " + e.UID.ToString() + ", OEM ID: " + e.OEMVersionID.ToString() + ", Product ID: " + e.PID.ToString()
        deviceStatus.ForeColor = Color.Red

        lblUID.Text = "Unit ID: "
        lblOEM.Text = "OEM ID: "
        lblProductID.Text = "Product ID: "
    End Sub

    Private Sub XkRS232_1_GenerateReportData(ByVal e As XkRS232.XKeyEventArgs) Handles XkRS232_1.GenerateReportData
        XkRS232_1_ButtonChange(e)
    End Sub

    Private Sub XkRS232_1_PinChange(ByVal e As XkRS232.XKeyRS232PinChangedEventArgs) Handles XkRS232_1.PinChange
        If e.ClearToSend = True Then
            listBox1.Items.Add("CTS clear")
        Else
            listBox1.Items.Add("CTS wait")
        End If
        listBox1.SelectedIndex = listBox1.Items.Count - 1

    End Sub

   
    Private Sub btnBaud_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBaud.Click
        'Will cause a reboot if the desired baud is different from the current baud.
        Dim baudrate As Integer = Convert.ToInt32(cboBaud.Text)
        XkRS232_1.SetBaudRate(0, baudrate)
    End Sub

    Private Sub btnWrite_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWrite.Click
        XkRS232_1.WriteString(0, txtAsciiCommand.Text, False, False)

    End Sub

    Private Sub chkSetRTS_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSetRTS.CheckedChanged
        Dim ClearWait As Integer = 0
        'clear
        If chkSetRTS.Checked = True Then
            'wait
            ClearWait = 1
        End If
        XkRS232_1.SetRTS(0, ClearWait)
    End Sub

    Private Sub btnCmdPass_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCmdPass.Click
        'Toggles the option for passing through COM data, if this is 
        If XkRS232_1.ConnectedDevices(0).PassThrough = False Then
            XkRS232_1.SetPassThrough(0, True)
        Else
            XkRS232_1.SetPassThrough(0, False)
        End If
        lblPassThrough.Text = "Pass through data from COM device: " + XkRS232_1.ConnectedDevices(0).PassThrough.ToString()
    End Sub

    Private Sub btnSendAscii_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSendAscii.Click
        'Toggles the option for sending any incoming ascii data to the keyboard, PID 1260 only. Note: it recommended to exit the sdk sample and set focus on a text application such as Notepad for this feature.
        If XkRS232_1.ConnectedDevices(0).SendAsciiToKeyboard = False Then
            XkRS232_1.SetSendAsciiToKeyboard(0, True)
        Else
            XkRS232_1.SetSendAsciiToKeyboard(0, False)
        End If
        lblSendAscii.Text = "Send Ascii to keyboard: " + XkRS232_1.ConnectedDevices(0).SendAsciiToKeyboard.ToString()
    End Sub

    Private Sub btnParity_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnParity.Click
        'Will cause a reboot if desired parity is different from the current parity
        If cboParity.SelectedIndex = 0 Then
            XkRS232_1.SetParity(0, XkRS232.XkRS232_.XkeysParityType.None)
        ElseIf cboParity.SelectedIndex = 1 Then
            XkRS232_1.SetParity(0, XkRS232.XkRS232_.XkeysParityType.Even)
        ElseIf cboParity.SelectedIndex = 2 Then
            XkRS232_1.SetParity(0, XkRS232.XkRS232_.XkeysParityType.Odd)
        End If
    End Sub

    Private Sub chkGreen_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkGreen.CheckedChanged
        If chkGreen.Checked = False Then
            XkRS232_1.SetGreenIndicator(0, 0)
        Else
            XkRS232_1.SetGreenIndicator(0, 1)
        End If
    End Sub
End Class
