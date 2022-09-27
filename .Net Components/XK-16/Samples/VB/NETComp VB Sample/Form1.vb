Public Class Form1
    'The following is a sample showing how to interact with an XK-24 device using the X-keys XK-24 .NET component.

    'Variables to track the device lights, initial states here based on device defaults
    Dim AllBlue As Boolean = True
    Dim AllRed As Boolean = True
    Dim saveabsolutetime As Long = -1 'for time stamp demo

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If (Xk16_8_4_1.ConnectedDevices.Length > 0) Then
                deviceStatus.Text = "XK-16/8/4 Connected"
                deviceStatus.ForeColor = Color.Green

                'Gets the Unit ID from the device
                lblUID.Text = "Unit ID: " & Xk16_8_4_1.ConnectedDevices(0).UnitID.ToString()

                'Gets the OEM Version ID from the device
                lblOEM.Text = "OEM Version ID: " & Xk16_8_4_1.ConnectedDevices(0).OEMVersion.ToString()

                'Gets the Product ID from the device
                lblProductID.Text = "Product ID: " & Xk16_8_4_1.ConnectedDevices(0).Pid.ToString()
            End If
        Catch ex As Exception
            deviceStatus.Text = "No XK-16/8/4 Connected"
            deviceStatus.ForeColor = Color.Red
        End Try
    End Sub

    Private Sub Xk16_8_4_1_ButtonChange(ByVal e As XK16_8_4.XKeyEventArgs) Handles Xk16_8_4_1.ButtonChange
        'This method handles the button change event for the device

        If e.PressState = True Then
            'button press
            Select Case e.CID
                Case 1001
                    lblButton01.Text = "01-dn"
                    Exit Select
                Case 1002
                    lblButton02.Text = "02-dn"
                    Exit Select
                Case 1003
                    lblButton03.Text = "03-dn"
                    Exit Select
                Case 1004
                    lblButton04.Text = "04-dn"
                    Exit Select
                Case 1005
                    lblButton05.Text = "05-dn"
                    Exit Select
                Case 1006
                    lblButton06.Text = "06-dn"
                    Exit Select
                Case 1007
                    lblButton07.Text = "07-dn"
                    Exit Select
                Case 1008
                    lblButton08.Text = "08-dn"
                    Exit Select
                Case 1009
                    lblButton09.Text = "09-dn"
                    Exit Select
                Case 1010
                    lblButton10.Text = "10-dn"
                    Exit Select
                Case 1011
                    lblButton11.Text = "11-dn"
                    Exit Select
                Case 1012
                    lblButton12.Text = "12-dn"
                    Exit Select
                Case 1013
                    lblButton13.Text = "13-dn"
                    Exit Select
                Case 1014
                    lblButton14.Text = "14-dn"
                    Exit Select
                Case 1015
                    lblButton15.Text = "15-dn"
                    Exit Select
                Case 1016
                    lblButton16.Text = "16-dn"
                    Exit Select
                Case 1017
                    lblProgSw.Text = "Prog. Switch-set"
                    Exit Select
            End Select
        Else
            'button release
            Select Case e.CID
                Case 1001
                    lblButton01.Text = "01-up"
                    Exit Select
                Case 1002
                    lblButton02.Text = "02-up"
                    Exit Select
                Case 1003
                    lblButton03.Text = "03-up"
                    Exit Select
                Case 1004
                    lblButton04.Text = "04-up"
                    Exit Select
                Case 1005
                    lblButton05.Text = "05-up"
                    Exit Select
                Case 1006
                    lblButton06.Text = "06-up"
                    Exit Select
                Case 1007
                    lblButton07.Text = "07-up"
                    Exit Select
                Case 1008
                    lblButton08.Text = "08-up"
                    Exit Select
                Case 1009
                    lblButton09.Text = "09-up"
                    Exit Select
                Case 1010
                    lblButton10.Text = "10-up"
                    Exit Select
                Case 1011
                    lblButton11.Text = "11-up"
                    Exit Select
                Case 1012
                    lblButton12.Text = "12-up"
                    Exit Select
                Case 1013
                    lblButton13.Text = "13-up"
                    Exit Select
                Case 1014
                    lblButton14.Text = "14-up"
                    Exit Select
                Case 1015
                    lblButton15.Text = "15-up"
                    Exit Select
                Case 1016
                    lblButton16.Text = "16-up"
                    Exit Select
                Case 1017
                    lblProgSw.Text = "Prog. Switch-unset"
                    Exit Select
                
            End Select
        End If
        lblUID.Text = "Unit ID: " + Xk16_8_4_1.ConnectedDevices(0).UnitID.ToString()
        'Time Stamp Info
        Dim absolutetime As Long = e.TimeStamp
        Dim absolutetimesec As Long = absolutetime / 1000
        lblATime.Text = "Absolute Time: " + absolutetimesec.ToString() + " s"
        If (saveabsolutetime <> -1) Then
            lblDTime.Text = "Delta Time: " + (absolutetime - saveabsolutetime).ToString() + " ms" 'this gives the time between button presses/releases or between any generated data reports
        Else
            lblDTime.Text = "Delta Time: "
        End If
        saveabsolutetime = absolutetime

    End Sub

    Private Sub btnBlue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBlue.Click
        Dim LightState As Integer

        If (cboBacklightStatus.Text = "On") Then
            LightState = 1
        ElseIf (cboBacklightStatus.Text = "Off") Then
            LightState = 0
        ElseIf (cboBacklightStatus.Text = "Flash") Then
            LightState = 2
        Else
            LightState = 1
        End If

        Dim ButtonID As Integer = Convert.ToInt32(spnButton.Value)

        'Sets an individual LED (on bank 0) based on chosen ButtonID and LightState
        Xk16_8_4_1.SetBacklightLED(0, ButtonID, 0)
    End Sub

    Private Sub btnRed_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub btnSaveState_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveState.Click
        'Saves backlighting state to the memory of the device, when called the current state of the backlights will be the default state when device is booted
        Xk16_8_4_1.SaveBacklightState(0)
    End Sub

    Private Sub btnUID_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUID.Click
        Dim id As Integer = Convert.ToInt32(txtUID.Text)

        'Sets device Unit ID
        Xk16_8_4_1.SetDeviceUID(0, id)
        lblUID.Text = "Unit ID: " + Xk16_8_4_1.ConnectedDevices(0).UnitID.ToString()

    End Sub

    Private Sub btnOEM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOEM.Click
        Dim id = Convert.ToInt32(txtOEM.Text)

        'Sets device OEM Version ID
        Xk16_8_4_1.SetOEMVersionID(0, id, True)
    End Sub

    Private Sub btnIntensity_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIntensity.Click
        Dim Intensity1 As Integer = Convert.ToInt32(spnBlueIntensity.Value)
        
        'Sets the intensity for both backlighting banks
        Xk16_8_4_1.SetBacklightIntensity(0, Intensity1)
    End Sub

    Private Sub btnToggleAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnToggleAll.Click
        'Toggles backlighting on and off
        Xk16_8_4_1.ToggleBacklights(0)
    End Sub

    Private Sub btnAllBlue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAllBlue.Click
        'Sets all the blue on or off
        If (AllBlue = True) Then
            Xk16_8_4_1.SetAllBlue(0, False)
            AllBlue = False
        Else
            Xk16_8_4_1.SetAllBlue(0, True)
            AllBlue = True
        End If
    End Sub

    Private Sub btn1029_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub btn1027_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub btnKeyboard_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnKeyboard.Click
        txtKeyboard.Focus()
        'Sends the letters 'a' 'b' and 'c'
        Xk16_8_4_1.SendKeystrokes(0, False, False, False, False, False, False, False, False, 4, 5, 6, 0, 0, 0)
        'Releases all sent keys
        Xk16_8_4_1.SendKeystrokes(0, False, False, False, False, False, False, False, False, 0, 0, 0, 0, 0, 0)
    End Sub

    Private Sub btnJoystick_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnJoystick.Click
        'Sends game controller message, open Game Controllers control panel to see
        'Joystick endpoint required therefore must be in Product ID 1027 to work
        If (Xk16_8_4_1.ConnectedDevices(0).JoystickInterface = True) Then
            Dim buttons As Boolean() = {False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False}
            Xk16_8_4_1.SendJoystick(0, 100, 100, 0, 0, 0, 8, buttons)
        Else
            MessageBox.Show("No joystick endpoint available, change to pid 1027")
        End If
    End Sub

    Private Sub btnMouse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMouse.Click
        'Moves mouse cursor right and up from its current position
        'Mouse endpoint required therefore must be in Product ID 1029 to work
        If (Xk16_8_4_1.ConnectedDevices(0).MouseInterface = True) Then
            Xk16_8_4_1.SendMouse(0, False, False, False, False, False, 20, 20, 0)
        Else
            MessageBox.Show("No mouse endpoint available, change to pid 1029")
        End If
    End Sub

    Private Sub btnSetDongle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetDongle.Click
        'Enter in 4 bytes. REMEMBER these 4 bytes they will be required to check the dongle
        Dim byte1 As Byte = Convert.ToByte(txtByte1.Text)
        Dim byte2 As Byte = Convert.ToByte(txtByte2.Text)
        Dim byte3 As Byte = Convert.ToByte(txtByte3.Text)
        Dim byte4 As Byte = Convert.ToByte(txtByte4.Text)

        Xk16_8_4_1.SetSecurityKey(0, byte1, byte2, byte3, byte4)
    End Sub

    Private Sub btnCheckDongle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCheckDongle.Click
        'Enter the 4 bytes used when Xk16_8_4_1.SetSecurityKey was called
        Dim byte1 As Byte = Convert.ToByte(txtByte1.Text)
        Dim byte2 As Byte = Convert.ToByte(txtByte2.Text)
        Dim byte3 As Byte = Convert.ToByte(txtByte3.Text)
        Dim byte4 As Byte = Convert.ToByte(txtByte4.Text)

        'Checks the security key by sending the selected bytes to the device; bytes were valid if it returns true
        Dim dongle As Boolean = Xk16_8_4_1.GetSecurityKey(0, byte1, byte2, byte3, byte4)

        If (dongle = True) Then
            grpDongle.BackColor = Color.Green
        ElseIf (dongle = False) Then
            grpDongle.BackColor = Color.Red
        End If
    End Sub

    Private Sub Xk16_8_4_1_DevicePlug(ByVal e As XK16_8_4.XKeyPlugEventArgs) Handles Xk16_8_4_1.DevicePlug
        deviceStatus.Text = "XK-16/8/4 Plugged, Unit ID: " + e.UID.ToString() + ", OEM ID: " + e.OEMVersionID.ToString() + ", Product ID: " + e.PID.ToString()
        deviceStatus.ForeColor = Color.Green

        'Gets the Unit ID from the device
        lblUID.Text = "Unit ID: " + e.UID.ToString()

        'Gets the OEM Version ID from the device
        lblOEM.Text = "OEM ID: " + e.OEMVersionID.ToString()

        'Gets the Product ID from the device
        lblProductID.Text = "Product ID: " + e.PID.ToString()
        saveabsolutetime = -1
    End Sub

    Private Sub Xk16_8_4_1_DeviceUnplug(ByVal e As XK16_8_4.XKeyPlugEventArgs) Handles Xk16_8_4_1.DeviceUnplug
        deviceStatus.Text = "XK-16/8/4 Unplugged, Unit ID: " + e.UID.ToString() + ", OEM ID: " + e.OEMVersionID.ToString() + ", Product ID: " + e.PID.ToString()
        deviceStatus.ForeColor = Color.Red

        lblUID.Text = "Unit ID: "
        lblOEM.Text = "OEM ID: "
        lblProductID.Text = "Product ID: "
    End Sub

    Private Sub Xk16_8_4_1_GenerateReportData(ByVal e As XK16_8_4.XKeyEventArgs) Handles Xk16_8_4_1.GenerateReportData
        Xk16_8_4_1_ButtonChange(e)
    End Sub

    Private Sub btnGenerate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerate.Click
        'Use this to generate a report which gives the state of the buttons even if there was no change in their states, this is often useful on start of application to get initial states of the switches (buttons)
        'Sending this command will trigger the _GenerateReportData event
        Xk16_8_4_1.GenerateReport(0)
    End Sub

    Private Sub btn1049_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1049.Click
        'Changes device to the 1049 (XK-16) Product ID (device will "replug" itself)
        'Change to this Product ID if you desire Keyboard and Mouse endpoints
        Xk16_8_4_1.ChangePID(0, 1049)
    End Sub

    Private Sub btn1051_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1051.Click
        'Changes device to the 1051 (XK-16) Product ID (device will "replug" itself)
        'Change to this Product ID if you desire Keyboard and Mouse endpoints
        Xk16_8_4_1.ChangePID(0, 1051)
    End Sub

    Private Sub btn1130_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1130.Click
        'Changes device to the 1130 (XK-8) Product ID (device will "replug" itself)
        'Change to this Product ID if you desire Keyboard and Mouse endpoints
        Xk16_8_4_1.ChangePID(0, 1130)
    End Sub

    Private Sub btn1132_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1132.Click
        'Changes device to the 1132 (XK-8) Product ID (device will "replug" itself)
        'Change to this Product ID if you desire Keyboard and Mouse endpoints
        Xk16_8_4_1.ChangePID(0, 1132)
    End Sub

    Private Sub btn1127_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1127.Click
        'Changes device to the 1127 (XK-4) Product ID (device will "replug" itself)
        'Change to this Product ID if you desire Keyboard and Mouse endpoints
        Xk16_8_4_1.ChangePID(0, 1127)
    End Sub

    Private Sub btn1129_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1129.Click
        'Changes device to the 1129 (XK-4) Product ID (device will "replug" itself)
        'Change to this Product ID if you desire Keyboard and Mouse endpoints
        Xk16_8_4_1.ChangePID(0, 1129)
    End Sub

    Private Sub btnFrequency_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFrequency.Click
        Dim flashfreq As Integer
        flashfreq = System.Convert.ToInt16(spnFrequency.Value)
        Xk16_8_4_1.SetFlashFrequency(0, flashfreq)
    End Sub

    Private Sub chkGreen_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkGreen.CheckedChanged
        If chkGreen.Checked = False Then
            Xk16_8_4_1.SetGreenIndicator(0, 0)
        Else
            If (chkGreenFlash.Checked = True) Then
                Xk16_8_4_1.SetGreenIndicator(0, 2)
            Else
                Xk16_8_4_1.SetGreenIndicator(0, 1)
            End If
        End If
    End Sub

    Private Sub chkRed_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkRed.CheckedChanged
        If chkRed.Checked = False Then
            Xk16_8_4_1.SetRedIndicator(0, 0)
        Else
            If (chkRedFlash.Checked = True) Then
                Xk16_8_4_1.SetRedIndicator(0, 2)
            Else
                Xk16_8_4_1.SetRedIndicator(0, 1)
            End If
        End If
    End Sub

    Private Sub chkGreenFlash_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkGreenFlash.CheckedChanged
        If (chkGreen.Checked = True) Then
            If (chkGreenFlash.Checked = True) Then
                Xk16_8_4_1.SetGreenIndicator(0, 2)
            Else
                Xk16_8_4_1.SetGreenIndicator(0, 1)
            End If
        End If
    End Sub

    Private Sub chkRedFlash_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkRedFlash.CheckedChanged
        If (chkRed.Checked = True) Then
            If (chkRedFlash.Checked = True) Then
                Xk16_8_4_1.SetRedIndicator(0, 2)
            Else
                Xk16_8_4_1.SetRedIndicator(0, 1)
            End If
        End If
    End Sub
End Class
