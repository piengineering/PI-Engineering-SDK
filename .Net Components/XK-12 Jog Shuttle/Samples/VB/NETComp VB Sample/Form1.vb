Public Class Form1
    
    'Variables to track the device lights, initial states here based on device defaults
    
    Dim AllBlue As Boolean = True
    Dim AllRed As Boolean = True
    Dim saveabsolutetime As Long = -1 'for time stamp demo

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If (Xk12Jog_1.ConnectedDevices.Length > 0) Then
                deviceStatus.Text = "XK-12 Jog && Shuttle Connected"
                deviceStatus.ForeColor = Color.Green

                'Gets the Unit ID from the device
                lblUID.Text = "Unit ID: " & Xk12Jog_1.ConnectedDevices(0).UnitID.ToString()

                'Gets the Product ID from the device
                lblProductID.Text = "Product ID: " & Xk12Jog_1.ConnectedDevices(0).Pid.ToString()
            End If
        Catch ex As Exception
            deviceStatus.Text = "No XK-12 Jog && Shuttle Connected"
            deviceStatus.ForeColor = Color.Red
        End Try
    End Sub

    

    Private Sub btnGreenLED_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub btnRedLED_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub btnGreenLEDFlash_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub btnRedLEDFlash_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

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
        Xk12Jog_1.SetBacklightLED(0, ButtonID, 0, LightState)
    End Sub

    Private Sub btnRed_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRed.Click
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
        Xk12Jog_1.SetBacklightLED(0, ButtonID, 1, LightState)
    End Sub

    Private Sub btnSaveState_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveState.Click
        'Saves backlighting state to the memory of the device, when called the current state of the backlights will be the default state when device is booted
        Xk12Jog_1.SaveBacklightState(0)
    End Sub

    Private Sub btnUID_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUID.Click
        Dim id As Integer = Convert.ToInt32(txtUID.Text)

        'Sets device Unit ID
        Xk12Jog_1.SetDeviceUID(0, id)
        lblUID.Text = "Unit ID: " + Xk12Jog_1.ConnectedDevices(0).UnitID.ToString()
    End Sub

    Private Sub btnIntensity_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIntensity.Click
        Dim Intensity1 As Integer = Convert.ToInt32(spnBlueIntensity.Value)
        Dim Intensity2 As Integer = Convert.ToInt32(spnRedIntensity.Value)

        'Sets the intensity for both backlighting banks
        Xk12Jog_1.SetBacklightIntensity(0, Intensity1, Intensity2)
    End Sub

    Private Sub btnRowsBlue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRowsBlue.Click
        Dim row1, row2, row3 As Boolean

        If (cboRow1.Text = "On") Then
            row1 = True
        Else
            row1 = False
        End If

        If (cboRow2.Text = "On") Then
            row2 = True
        Else
            row2 = False
        End If

        If (cboRow3.Text = "On") Then
            row3 = True
        Else
            row3 = False
        End If

        

        'Sets individual rows of backlights on bank 0
        Xk12Jog_1.SetRowsOfBacklights(0, 0, row1, row2, row3)
    End Sub

    Private Sub btnRowsRed_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRowsRed.Click
        Dim row1, row2, row3 As Boolean

        If (cboRow1.Text = "On") Then
            row1 = True
        Else
            row1 = False
        End If

        If (cboRow2.Text = "On") Then
            row2 = True
        Else
            row2 = False
        End If

        If (cboRow3.Text = "On") Then
            row3 = True
        Else
            row3 = False
        End If

        

        'Sets individual rows of backlights on bank 0
        Xk12Jog_1.SetRowsOfBacklights(0, 1, row1, row2, row3)
    End Sub

    Private Sub btnToggleAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnToggleAll.Click
        'Toggles backlighting on and off
        Xk12Jog_1.ToggleBacklights(0)
    End Sub

    Private Sub btnAllBlue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAllBlue.Click
        'Sets all the blue on or off
        If (AllBlue = True) Then
            Xk12Jog_1.SetAllBlue(0, False)
            AllBlue = False
        Else
            Xk12Jog_1.SetAllBlue(0, True)
            AllBlue = True
        End If
    End Sub

    Private Sub btnAllRed_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAllRed.Click
        'Sets all the red on or off
        If (AllRed = True) Then
            Xk12Jog_1.SetAllRed(0, False)
            AllRed = False
        Else
            Xk12Jog_1.SetAllRed(0, True)
            AllRed = True
        End If
    End Sub

    Private Sub btn1029_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub btn1027_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub btnKeyboard_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnKeyboard.Click
        txtKeyboard.Focus()
        'Sends the letters 'a' 'b' and 'c'
        Xk12Jog_1.SendKeystrokes(0, False, False, False, False, False, False, False, False, 4, 5, 6, 0, 0, 0)
        'Releases all sent keys
        Xk12Jog_1.SendKeystrokes(0, False, False, False, False, False, False, False, False, 0, 0, 0, 0, 0, 0)
    End Sub

    Private Sub btnJoystick_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnJoystick.Click
        'Sends game controller message, open Game Controllers control panel to see
        'Joystick endpoint required
        If (Xk12Jog_1.ConnectedDevices(0).JoystickInterface = True) Then
            Dim buttons As Boolean() = {False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False}
            Xk12Jog_1.SendJoystick(0, 100, 100, 0, 0, 0, 8, buttons)
        Else
            MessageBox.Show("No joystick endpoint available, change to pid 1027")
        End If
    End Sub

    Private Sub btnMouse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMouse.Click
        'Moves mouse cursor right and up from its current position
        'Mouse endpoint required 
        If (Xk12Jog_1.ConnectedDevices(0).MouseInterface = True) Then
            Xk12Jog_1.SendMouse(0, False, False, False, False, False, 20, 20, 0)
        Else
            MessageBox.Show("No mouse endpoint available, change to pid 1029")
        End If
    End Sub

    Private Sub btnSetDongle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub btnCheckDongle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub btnGenerate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerate.Click
        'Use this to generate a report which gives the state of the buttons even if there was no change in their states, this is often useful on start of application to get initial states of the switches (buttons)
        'Sending this command will trigger the _GenerateReportData event
        Xk12Jog_1.GenerateReport(0)
    End Sub

    Private Sub btn1062_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1062.Click
        'Change to this Product ID if you desire Keyboard and Mouse endpoints
        Xk12Jog_1.ChangePID(0, 1062)
    End Sub

    Private Sub btn1064_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1064.Click
        'Change to this Product ID if you desire Joystick and Mouse endpoints
        Xk12Jog_1.ChangePID(0, 1064)
    End Sub

    Private Sub btnFrequency_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFrequency.Click
        Dim flashfreq As Integer
        flashfreq = System.Convert.ToInt16(spnFrequency.Value)
        Xk12Jog_1.SetFlashFrequency(0, flashfreq)
    End Sub

    Private Sub Xk12Jog_1_ButtonChange(ByVal e As Xk12Jog.XKeyEventArgs) Handles Xk12Jog_1.ButtonChange
        'This method handles the button change event for the device

        'Gets the button number (CID) of the button that has changed state
        If e.CID > 1000 Then
            Dim ButtonNum As [String] = (e.CID - 1000).ToString()

            'Logic structure to handle both "press" (true) and "release" (false) states
            If e.PressState = True Then
                lblPress.Text = "Button #" + ButtonNum + " Down"
            ElseIf e.PressState = False Then
                lblRelease.Text = "Button #" + ButtonNum + " Up"
            End If
        End If

        If e.PressState = True Then
            'button press
            Select Case e.CID
                Case 1001
                    lblButton01.BackColor = Color.LimeGreen
                    Exit Select
                Case 1002
                    lblButton02.BackColor = Color.LimeGreen
                    Exit Select
                Case 1003
                    lblButton03.BackColor = Color.LimeGreen
                    Exit Select
                Case 1004
                    lblButton04.BackColor = Color.LimeGreen
                    Exit Select
                Case 1005
                    lblButton05.BackColor = Color.LimeGreen
                    Exit Select
                Case 1006
                    lblButton06.BackColor = Color.LimeGreen
                    Exit Select
                Case 1007
                    lblButton07.BackColor = Color.LimeGreen
                    Exit Select
                Case 1008
                    lblButton08.BackColor = Color.LimeGreen
                    Exit Select
                Case 1009
                    lblButton09.BackColor = Color.LimeGreen
                    Exit Select
                Case 1010
                    lblButton10.BackColor = Color.LimeGreen
                    Exit Select
                Case 1011
                    lblButton11.BackColor = Color.LimeGreen
                    Exit Select
                Case 1012
                    lblButton12.BackColor = Color.LimeGreen
                    Exit Select
                Case 1013
                    lblProgSwitch.BackColor = Color.LimeGreen
                    Exit Select
            End Select
        Else
            'button release
            Select Case e.CID
                Case 1001
                    lblButton01.BackColor = Nothing
                    Exit Select
                Case 1002
                    lblButton02.BackColor = Nothing
                    Exit Select
                Case 1003
                    lblButton03.BackColor = Nothing
                    Exit Select
                Case 1004
                    lblButton04.BackColor = Nothing
                    Exit Select
                Case 1005
                    lblButton05.BackColor = Nothing
                    Exit Select
                Case 1006
                    lblButton06.BackColor = Nothing
                    Exit Select
                Case 1007
                    lblButton07.BackColor = Nothing
                    Exit Select
                Case 1008
                    lblButton08.BackColor = Nothing
                    Exit Select
                Case 1009
                    lblButton09.BackColor = Nothing
                    Exit Select
                Case 1010
                    lblButton10.BackColor = Nothing
                    Exit Select
                Case 1011
                    lblButton11.BackColor = Nothing
                    Exit Select
                Case 1012
                    lblButton12.BackColor = Nothing
                    Exit Select
                Case 1013
                    lblProgSwitch.BackColor = Nothing
                    Exit Select
               
            End Select
        End If
        lblUID.Text = "Unit ID: " + Xk12Jog_1.ConnectedDevices(0).UnitID.ToString()
        'Time Stamp Info
        Dim absolutetime As Long = e.TimeStamp
        'gives time in ms since boot of X-keys unit
        Dim absolutetimesec As Long = absolutetime / 1000
        'convert to seconds
        lblATime.Text = "Absolute Time: " + absolutetimesec.ToString() + " s"
        If saveabsolutetime <> -1 Then
            'this gives the time between button presses or between any generated data reports
            lblDTime.Text = "Delta Time: " + (absolutetime - saveabsolutetime).ToString() + " ms"
        Else
            lblDTime.Text = "Delta Time: "
        End If
        saveabsolutetime = absolutetime

        label8.Text = e.Shift.ToString()
        label9.Text = e.Control.ToString()
        label10.Text = e.Alt.ToString()
    End Sub

    Private Sub Xk12Jog_1_DevicePlug(ByVal e As Xk12Jog.XKeyPlugEventArgs) Handles Xk12Jog_1.DevicePlug
        deviceStatus.Text = "XK-12 Jog & Shuttle Plugged, Unit ID: " + e.UID.ToString() + ", Product ID: " + e.PID.ToString()
        deviceStatus.ForeColor = Color.Green

        'Gets the Unit ID from the device
        lblUID.Text = "Unit ID: " + e.UID.ToString()
        
        'Gets the Product ID from the device
        lblProductID.Text = "Product ID: " + e.PID.ToString()
        saveabsolutetime = -1
    End Sub

    Private Sub Xk12Jog_1_DeviceUnplug(ByVal e As Xk12Jog.XKeyPlugEventArgs) Handles Xk12Jog_1.DeviceUnplug
        deviceStatus.Text = "XK-12 Jog & Shuttle Unplugged, Unit ID: " + e.UID.ToString() + ", Product ID: " + e.PID.ToString()
        deviceStatus.ForeColor = Color.Red

        lblUID.Text = "Unit ID: "
        lblProductID.Text = "Product ID: "
    End Sub

    Private Sub Xk12Jog_1_GenerateReportData(ByVal e As Xk12Jog.XKeyEventArgs) Handles Xk12Jog_1.GenerateReportData
        Xk12Jog_1_ButtonChange(e)
    End Sub

    Private Sub Xk12Jog_1_JogChange(ByVal e As Xk12Jog.XKeyJogArgs) Handles Xk12Jog_1.JogChange
        Select Case e.Jog
            Case 0
                lblJog.Text = "Jog:"
                Exit Select
            Case 1
                lblJog.Text = "Jog: Clockwise"
                Exit Select
            Case 255
                lblJog.Text = "Jog: Counterclockwise"
                Exit Select
        End Select

        'time stamp
        Dim absolutetime As Long = e.TimeStamp
        'gives time in ms since boot of X-keys unit
        Dim absolutetimesec As Long = absolutetime / 1000
        'convert to seconds
        lblATime.Text = "Absolute Time: " + absolutetimesec.ToString() + " s"
        If saveabsolutetime <> -1 Then
            'this gives the time between button presses or between any generated data reports
            lblDTime.Text = "Delta Time: " + (absolutetime - saveabsolutetime).ToString() + " ms"
        Else
            lblDTime.Text = "Delta Time: "
        End If
        saveabsolutetime = absolutetime

        label8.Text = e.Shift.ToString()
        label9.Text = e.Control.ToString()
        label10.Text = e.Alt.ToString()
    End Sub

    Private Sub Xk12Jog_1_ShuttleChange(ByVal e As Xk12Jog.XKeyShuttleArgs) Handles Xk12Jog_1.ShuttleChange
        lblShuttle.Text = "Shuttle: " + e.Shuttle.ToString

        'time stamp
        Dim absolutetime As Long = e.TimeStamp
        'gives time in ms since boot of X-keys unit
        Dim absolutetimesec As Long = absolutetime / 1000
        'convert to seconds
        lblATime.Text = "Absolute Time: " + absolutetimesec.ToString() + " s"
        If saveabsolutetime <> -1 Then
            'this gives the time between button presses or between any generated data reports
            lblDTime.Text = "Delta Time: " + (absolutetime - saveabsolutetime).ToString() + " ms"
        Else
            lblDTime.Text = "Delta Time: "
        End If
        saveabsolutetime = absolutetime

        label8.Text = e.Shift.ToString()
        label9.Text = e.Control.ToString()
        label10.Text = e.Alt.ToString()
    End Sub

    Private Sub chkGreen_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkGreen.CheckedChanged
        If chkGreen.Checked = False Then
            Xk12Jog_1.SetGreenIndicator(0, 0)
        Else
            If (chkGreenFlash.Checked = True) Then
                Xk12Jog_1.SetGreenIndicator(0, 2)
            Else
                Xk12Jog_1.SetGreenIndicator(0, 1)
            End If
        End If
    End Sub

    Private Sub chkRed_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkRed.CheckedChanged
        If chkRed.Checked = False Then
            Xk12Jog_1.SetRedIndicator(0, 0)
        Else
            If (chkRedFlash.Checked = True) Then
                Xk12Jog_1.SetRedIndicator(0, 2)
            Else
                Xk12Jog_1.SetRedIndicator(0, 1)
            End If
        End If
    End Sub

    Private Sub chkGreenFlash_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkGreenFlash.CheckedChanged
        If (chkGreen.Checked = True) Then
            If (chkGreenFlash.Checked = True) Then
                Xk12Jog_1.SetGreenIndicator(0, 2)
            Else
                Xk12Jog_1.SetGreenIndicator(0, 1)
            End If
        End If
    End Sub

    Private Sub chkRedFlash_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkRedFlash.CheckedChanged
        If (chkRed.Checked = True) Then
            If (chkRedFlash.Checked = True) Then
                Xk12Jog_1.SetRedIndicator(0, 2)
            Else
                Xk12Jog_1.SetRedIndicator(0, 1)
            End If
        End If
    End Sub
End Class
