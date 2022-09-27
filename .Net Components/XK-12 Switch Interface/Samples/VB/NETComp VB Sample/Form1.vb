Public Class Form1

    Dim saveabsolutetime As Long = -1 'for time stamp demo
   
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If IsNothing(Xk12SI_1.ConnectedDevices) Then
            deviceStatus.Text = "No XK-12 Switch Interface Connected"
            deviceStatus.ForeColor = Color.Red
        Else
            deviceStatus.Text = "XK-12 Switch Interface Connected"
            deviceStatus.ForeColor = Color.Green

            'Gets the Unit ID from the device
            lblUID.Text = "Unit ID: " & Xk12SI_1.ConnectedDevices(0).UnitID.ToString()

            'Gets the OEM Version ID from the device
            lblOEM.Text = "OEM Version ID: " & Xk12SI_1.ConnectedDevices(0).OEMVersion.ToString()

            'Gets the Product ID from the device
            lblProductID.Text = "Product ID: " & Xk12SI_1.ConnectedDevices(0).Pid.ToString()
        End If

    End Sub

    Private Sub Xk12SI_1_ButtonChange(ByVal e As Xk12SI.XKeyEventArgs) Handles Xk12SI_1.ButtonChange
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
        lblUID.Text = "Unit ID: " + Xk12SI_1.ConnectedDevices(0).UnitID.ToString()
        'Time Stamp Info
        Dim absolutetime As Long = e.TimeStamp
        Dim absolutetimesec As Long = absolutetime / 1000
        lblATime.Text = "Absolute Time: " + absolutetimesec.ToString() + " s"
        If (saveabsolutetime <> -1) Then
            lblDTime.Text = "Delta Time: " + (absolutetime - saveabsolutetime).ToString() + " ms" 'this gives the time between button presses/releases or between any generated data reports
        End If
        saveabsolutetime = absolutetime

    End Sub


    Private Sub btnUID_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUID.Click
        Dim id As Integer = Convert.ToInt32(txtUID.Text)

        'Sets device Unit ID
        Xk12SI_1.SetDeviceUID(0, id)
        lblUID.Text = "Unit ID: " + Xk12SI_1.ConnectedDevices(0).UnitID.ToString()
    End Sub

    Private Sub btnOEM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOEM.Click
        Dim id = Convert.ToInt32(txtOEM.Text)

        'Sets device OEM Version ID
        Xk12SI_1.SetOEMVersionID(0, id, True)
    End Sub

    Private Sub btn1192_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1192.Click
        'Changes device to the 1192 Product ID (device will "replug" itself)
        'Change to this Product ID if you desire Joystick and Mouse endpoints
        Xk12SI_1.ChangePID(0, 1192)
    End Sub

    Private Sub btn1195_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1195.Click
        'Changes device to the 1195 Product ID (device will "replug" itself)
        'Change to this Product ID if you desire Keyboard and Mouse endpoints
        Xk12SI_1.ChangePID(0, 1195)
    End Sub

    Private Sub btnKeyboard_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnKeyboard.Click
        If (Xk12SI_1.ConnectedDevices(0).KeyboardInterface = True) Then
            txtKeyboard.Focus()
            'Sends the letters 'a' 'b' and 'c'
            Xk12SI_1.SendKeystrokes(0, False, False, False, False, False, False, False, False, 4, 5, 6, 0, 0, 0)
            'Releases all sent keys
            Xk12SI_1.SendKeystrokes(0, False, False, False, False, False, False, False, False, 0, 0, 0, 0, 0, 0)
        Else
            MessageBox.Show("No joystick endpoint available, change to pid 1195")
        End If
    End Sub

    Private Sub btnJoystick_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnJoystick.Click
        'Sends game controller message, open Game Controllers control panel to see
        'Joystick endpoint required therefore must be in Product ID 1027 to work
        If (Xk12SI_1.ConnectedDevices(0).JoystickInterface = True) Then
            Dim buttons As Boolean() = {False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False}
            Xk12SI_1.SendJoystick(0, 100, 100, 0, 0, 0, 8, buttons)
        Else
            MessageBox.Show("No joystick endpoint available, change to pid 1192")
        End If
    End Sub

    Private Sub btnMouse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMouse.Click
        'Moves mouse cursor right and up from its current position
        'Mouse endpoint required therefore must be in Product ID 1029 to work
        If (Xk12SI_1.ConnectedDevices(0).MouseInterface = True) Then
            Xk12SI_1.SendMouse(0, False, False, False, False, False, 20, 20, 0)
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

        Xk12SI_1.SetSecurityKey(0, byte1, byte2, byte3, byte4)
    End Sub

    Private Sub btnCheckDongle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCheckDongle.Click
        'Enter the 4 bytes used when Xk12SI_1.SetSecurityKey was called
        Dim byte1 As Byte = Convert.ToByte(txtByte1.Text)
        Dim byte2 As Byte = Convert.ToByte(txtByte2.Text)
        Dim byte3 As Byte = Convert.ToByte(txtByte3.Text)
        Dim byte4 As Byte = Convert.ToByte(txtByte4.Text)

        'Checks the security key by sending the selected bytes to the device; bytes were valid if it returns true
        Dim dongle As Boolean = Xk12SI_1.GetSecurityKey(0, byte1, byte2, byte3, byte4)

        If (dongle = True) Then
            grpDongle.BackColor = Color.Green
        ElseIf (dongle = False) Then
            grpDongle.BackColor = Color.Red
        End If
    End Sub

    Private Sub Xk12SI_1_DevicePlug(ByVal e As Xk12SI.XKeyPlugEventArgs) Handles Xk12SI_1.DevicePlug
        deviceStatus.Text = "XK-12 Switch Interface Plugged, Unit ID: " + e.UID.ToString() + ", OEM ID: " + e.OEMVersionID.ToString() + ", Product ID: " + e.PID.ToString()
        deviceStatus.ForeColor = Color.Green

        'Gets the Unit ID from the device
        lblUID.Text = "Unit ID: " + e.UID.ToString()

        'Gets the OEM Version ID from the device
        lblOEM.Text = "OEM ID: " + e.OEMVersionID.ToString()

        'Gets the Product ID from the device
        lblProductID.Text = "Product ID: " + e.PID.ToString()
    End Sub

    Private Sub Xk12SI_1_DeviceUnplug(ByVal e As Xk12SI.XKeyPlugEventArgs) Handles Xk12SI_1.DeviceUnplug
        deviceStatus.Text = "XK-12 Switch Interface Unplugged, Unit ID: " + e.UID.ToString() + ", OEM ID: " + e.OEMVersionID.ToString() + ", Product ID: " + e.PID.ToString()
        deviceStatus.ForeColor = Color.Red

        lblUID.Text = "Unit ID: "
        lblOEM.Text = "OEM ID: "
        lblProductID.Text = "Product ID: "
    End Sub

    Private Sub Xk12SI_1_GenerateReportData(ByVal e As Xk12SI.XKeyEventArgs) Handles Xk12SI_1.GenerateReportData
        Xk12SI_1_ButtonChange(e)
    End Sub

    Private Sub btnGenerate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerate.Click
        'Use this to get the state of the buttons even if there was no change in their states. This is often useful on start of application to get initial states of the buttons (switches).
        'Sending this command will trigger the _GenerateReportData event
        Xk12SI_1.GenerateReport(0)
    End Sub

    Private Sub btnFrequency_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFrequency.Click
        Dim flashfreq As Integer
        flashfreq = System.Convert.ToInt16(spnFrequency.Value)
        Xk12SI_1.SetFlashFrequency(0, flashfreq)
    End Sub

    Private Sub chkGreen_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkGreen.CheckedChanged
        If chkGreen.Checked = False Then
            Xk12SI_1.SetGreenIndicator(0, 0)
        Else
            If (chkGreenFlash.Checked = True) Then
                Xk12SI_1.SetGreenIndicator(0, 2)
            Else
                Xk12SI_1.SetGreenIndicator(0, 1)
            End If
        End If
    End Sub

    Private Sub chkRed_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkRed.CheckedChanged
        If chkRed.Checked = False Then
            Xk12SI_1.SetRedIndicator(0, 0)
        Else
            If (chkRedFlash.Checked = True) Then
                Xk12SI_1.SetRedIndicator(0, 2)
            Else
                Xk12SI_1.SetRedIndicator(0, 1)
            End If
        End If
    End Sub

    Private Sub chkGreenFlash_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkGreenFlash.CheckedChanged
        If (chkGreen.Checked = True) Then
            If (chkGreenFlash.Checked = True) Then
                Xk12SI_1.SetGreenIndicator(0, 2)
            Else
                Xk12SI_1.SetGreenIndicator(0, 1)
            End If
        End If
    End Sub

    Private Sub chkRedFlash_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkRedFlash.CheckedChanged
        If (chkRed.Checked = True) Then
            If (chkRedFlash.Checked = True) Then
                Xk12SI_1.SetRedIndicator(0, 2)
            Else
                Xk12SI_1.SetRedIndicator(0, 1)
            End If
        End If
    End Sub
End Class
