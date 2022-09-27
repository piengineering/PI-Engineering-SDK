Public Class Form1
   
    Dim saveabsolutetime As Long = -1 'for time stamp demo
   
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If IsNothing(Xk3FP_1.ConnectedDevices) Then
            deviceStatus.Text = "No XK-3 Foot Pedal Connected"
            deviceStatus.ForeColor = Color.Red
        Else
            deviceStatus.Text = "XK-3 Foot Pedal Connected"
            deviceStatus.ForeColor = Color.Green

            'Gets the Unit ID from the device
            lblUID.Text = "Unit ID: " & Xk3FP_1.ConnectedDevices(0).UnitID.ToString()

            'Gets the OEM Version ID from the device
            lblOEM.Text = "OEM Version ID: " & Xk3FP_1.ConnectedDevices(0).OEMVersion.ToString()

            'Gets the Product ID from the device
            lblProductID.Text = "Product ID: " & Xk3FP_1.ConnectedDevices(0).Pid.ToString()
        End If

    End Sub

    Private Sub btnUID_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUID.Click
        Dim id As Integer = Convert.ToInt32(txtUID.Text)

        'Sets device Unit ID
        Xk3FP_1.SetDeviceUID(0, id)
        lblUID.Text = "Unit ID: " + Xk3FP_1.ConnectedDevices(0).UnitID.ToString()
    End Sub

    Private Sub btnOEM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOEM.Click
        Dim id = Convert.ToInt32(txtOEM.Text)

        'Sets device OEM Version ID
        Xk3FP_1.SetOEMVersionID(0, id, True)
    End Sub

    Private Sub btn1080_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1080.Click
        'Changes device to the 1221 Product ID (device will "replug" itself)
        'Change to this Product ID if you desire Joystick and Mouse endpoints
        Xk3FP_1.ChangePID(0, 1080)
    End Sub

    Private Sub btn1082_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1082.Click
        'Changes device to the 1224 Product ID (device will "replug" itself)
        'Change to this Product ID if you desire Keyboard and Mouse endpoints
        Xk3FP_1.ChangePID(0, 1082)
    End Sub

    Private Sub btnKeyboard_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnKeyboard.Click
        txtKeyboard.Focus()
        'Sends the letters 'a' 'b' and 'c'
        Xk3FP_1.SendKeystrokes(0, False, False, False, False, False, False, False, False, 4, 5, 6, 0, 0, 0)
        'Releases all sent keys
        Xk3FP_1.SendKeystrokes(0, False, False, False, False, False, False, False, False, 0, 0, 0, 0, 0, 0)
    End Sub

    Private Sub btnJoystick_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnJoystick.Click
        'Sends game controller message, open Game Controllers control panel to see
        'Joystick endpoint required therefore must be in Product ID 1027 to work
        If (Xk3FP_1.ConnectedDevices(0).JoystickInterface = True) Then
            Dim buttons As Boolean() = {False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False}
            Xk3FP_1.SendJoystick(0, 100, 100, 0, 0, 0, 8, buttons)
        Else
            MessageBox.Show("No joystick endpoint available, change to pid 1082")
        End If
    End Sub

    Private Sub btnMouse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMouse.Click
        'Moves mouse cursor right and up from its current position
        'Mouse endpoint required therefore must be in Product ID 1029 to work
        If (Xk3FP_1.ConnectedDevices(0).MouseInterface = True) Then
            Xk3FP_1.SendMouse(0, False, False, False, False, False, 20, 20, 0)
        Else
            MessageBox.Show("No mouse endpoint available, change to pid 1080")
        End If
    End Sub

    Private Sub btnSetDongle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetDongle.Click
        'Enter in 4 bytes. REMEMBER these 4 bytes they will be required to check the dongle
        Dim byte1 As Byte = Convert.ToByte(txtByte1.Text)
        Dim byte2 As Byte = Convert.ToByte(txtByte2.Text)
        Dim byte3 As Byte = Convert.ToByte(txtByte3.Text)
        Dim byte4 As Byte = Convert.ToByte(txtByte4.Text)

        Xk3FP_1.SetSecurityKey(0, byte1, byte2, byte3, byte4)
    End Sub

    Private Sub btnCheckDongle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCheckDongle.Click
        'Enter the 4 bytes used when Xk12SI_1.SetSecurityKey was called
        Dim byte1 As Byte = Convert.ToByte(txtByte1.Text)
        Dim byte2 As Byte = Convert.ToByte(txtByte2.Text)
        Dim byte3 As Byte = Convert.ToByte(txtByte3.Text)
        Dim byte4 As Byte = Convert.ToByte(txtByte4.Text)

        'Checks the security key by sending the selected bytes to the device; bytes were valid if it returns true
        Dim dongle As Boolean = Xk3FP_1.GetSecurityKey(0, byte1, byte2, byte3, byte4)

        If (dongle = True) Then
            grpDongle.BackColor = Color.Green
        ElseIf (dongle = False) Then
            grpDongle.BackColor = Color.Red
        End If
    End Sub

   

    Private Sub btnGenerate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerate.Click
        'Use this to get the state of the buttons even if there was no change in their states. This is often useful on start of application to get initial states of the buttons (switches).
        'Sending this command will trigger the _GenerateReportData event
        Xk3FP_1.GenerateReport(0)
    End Sub

    Private Sub Xk3FP_1_ButtonChange(ByVal e As Xk3FP.XKeyEventArgs) Handles Xk3FP_1.ButtonChange
        'This method handles the button change event for the device

        If e.PressState = True Then
            'button press
            Select Case e.CID
              
                Case 1002
                    lblButton01.Text = "left pedal-closed"
                    Exit Select
                Case 1003
                    lblButton02.Text = "middle pedal-closed"
                    Exit Select
                Case 1004
                    lblButton03.Text = "right pedal-closed"
                    Exit Select


            End Select
        Else
            'button release
            Select Case e.CID
                Case 1002
                    lblButton01.Text = "left pedal-open"
                    Exit Select
                Case 1003
                    lblButton02.Text = "middle pedal-open"
                    Exit Select
                Case 1004
                    lblButton03.Text = "right pedal-open"
                    Exit Select

            End Select
        End If
        lblUID.Text = "Unit ID: " + Xk3FP_1.ConnectedDevices(0).UnitID.ToString()
        'Time Stamp Info
        Dim absolutetime As Long = e.TimeStamp
        Dim absolutetimesec As Long = absolutetime / 1000
        lblATime.Text = "Absolute Time: " + absolutetimesec.ToString() + " s"
        If (saveabsolutetime <> -1) Then
            lblDTime.Text = "Delta Time: " + (absolutetime - saveabsolutetime).ToString() + " ms" 'this gives the time between button presses/releases or between any generated data reports
        End If
        saveabsolutetime = absolutetime
    End Sub

    Private Sub Xk3FP_1_DevicePlug(ByVal e As Xk3FP.XKeyPlugEventArgs) Handles Xk3FP_1.DevicePlug
        deviceStatus.Text = "XK-3 Foot Pedal Plugged, Unit ID: " + e.UID.ToString() + ", OEM ID: " + e.OEMVersionID.ToString() + ", Product ID: " + e.PID.ToString()
        deviceStatus.ForeColor = Color.Green

        'Gets the Unit ID from the device
        lblUID.Text = "Unit ID: " + e.UID.ToString()

        'Gets the OEM Version ID from the device
        lblOEM.Text = "OEM ID: " + e.OEMVersionID.ToString()

        'Gets the Product ID from the device
        lblProductID.Text = "Product ID: " + e.PID.ToString()
    End Sub

    Private Sub Xk3FP_1_DeviceUnplug(ByVal e As Xk3FP.XKeyPlugEventArgs) Handles Xk3FP_1.DeviceUnplug
        deviceStatus.Text = "XK-3 Foot Pedal Unplugged, Unit ID: " + e.UID.ToString() + ", OEM ID: " + e.OEMVersionID.ToString() + ", Product ID: " + e.PID.ToString()
        deviceStatus.ForeColor = Color.Red

        lblUID.Text = "Unit ID: "
        lblOEM.Text = "OEM ID: "
        lblProductID.Text = "Product ID: "
    End Sub

    Private Sub Xk3FP_1_GenerateReportData(ByVal e As Xk3FP.XKeyEventArgs) Handles Xk3FP_1.GenerateReportData
        Xk3FP_1_ButtonChange(e)
    End Sub

    Private Sub chkGreen_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkGreen.CheckedChanged
        If chkGreen.Checked = False Then
            Xk3FP_1.SetGreenIndicator(0, 0)
        Else
            If (chkGreenFlash.Checked = True) Then
                Xk3FP_1.SetGreenIndicator(0, 2)
            Else
                Xk3FP_1.SetGreenIndicator(0, 1)
            End If
        End If
    End Sub

    Private Sub chkRed_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkRed.CheckedChanged
        If chkRed.Checked = False Then
            Xk3FP_1.SetRedIndicator(0, 0)
        Else
            If (chkRedFlash.Checked = True) Then
                Xk3FP_1.SetRedIndicator(0, 2)
            Else
                Xk3FP_1.SetRedIndicator(0, 1)
            End If
        End If
    End Sub

    Private Sub chkGreenFlash_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkGreenFlash.CheckedChanged
        If (chkGreen.Checked = True) Then
            If (chkGreenFlash.Checked = True) Then
                Xk3FP_1.SetGreenIndicator(0, 2)
            Else
                Xk3FP_1.SetGreenIndicator(0, 1)
            End If
        End If
    End Sub

    Private Sub chkRedFlash_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkRedFlash.CheckedChanged
        If (chkRed.Checked = True) Then
            If (chkRedFlash.Checked = True) Then
                Xk3FP_1.SetRedIndicator(0, 2)
            Else
                Xk3FP_1.SetRedIndicator(0, 1)
            End If
        End If
    End Sub
End Class
