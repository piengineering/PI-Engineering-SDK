Public Class Form1
    'The following is a sample showing how to interact with an XK-80/60 device using the X-keys XK-80/60 .NET component.

    'Variables to track the device lights, initial states here based on device defaults
    Dim AllBlue As Boolean = True
    Dim AllRed As Boolean = True
    Dim saveabsolutetime As Long = -1 'for time stamp demo

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If (Xk60_80_1.ConnectedDevices.Length > 0) Then
                deviceStatus.Text = "XK-80/XK-60 Connected"
                deviceStatus.ForeColor = Color.Green

                'Gets the Unit ID from the device
                lblUID.Text = "Unit ID: " & Xk60_80_1.ConnectedDevices(0).UnitID.ToString()

                'Gets the OEM Version ID from the device
                lblOEM.Text = "OEM Version ID: " & Xk60_80_1.ConnectedDevices(0).OEMVersion.ToString()

                'Gets the Product ID from the device
                lblProductID.Text = "Product ID: " & Xk60_80_1.ConnectedDevices(0).Pid.ToString()
            End If
        Catch ex As Exception
            deviceStatus.Text = "No XK-80/XK-60 Connected"
            deviceStatus.ForeColor = Color.Red
        End Try
    End Sub

    Private Sub Xk60_80_1_ButtonChange(ByVal e As XK_60_80.XKeyEventArgs) Handles Xk60_80_1.ButtonChange
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
                    lblButton13.BackColor = Color.LimeGreen
                    Exit Select
                Case 1014
                    lblButton14.BackColor = Color.LimeGreen
                    Exit Select
                Case 1015
                    lblButton15.BackColor = Color.LimeGreen
                    Exit Select
                Case 1016
                    lblButton16.BackColor = Color.LimeGreen
                    Exit Select
                Case 1017
                    lblButton17.BackColor = Color.LimeGreen
                    Exit Select
                Case 1018
                    lblButton18.BackColor = Color.LimeGreen
                    Exit Select
                Case 1019
                    lblButton19.BackColor = Color.LimeGreen
                    Exit Select
                Case 1020
                    lblButton20.BackColor = Color.LimeGreen
                    Exit Select
                Case 1021
                    lblButton21.BackColor = Color.LimeGreen
                    Exit Select
                Case 1022
                    lblButton22.BackColor = Color.LimeGreen
                    Exit Select
                Case 1023
                    lblButton23.BackColor = Color.LimeGreen
                    Exit Select
                Case 1024
                    lblButton24.BackColor = Color.LimeGreen
                    Exit Select
                Case 1025
                    lblButton25.BackColor = Color.LimeGreen
                    Exit Select
                Case 1026
                    lblButton26.BackColor = Color.LimeGreen
                    Exit Select
                Case 1027
                    lblButton27.BackColor = Color.LimeGreen
                    Exit Select
                Case 1028
                    lblButton28.BackColor = Color.LimeGreen
                    Exit Select
                Case 1029
                    lblButton29.BackColor = Color.LimeGreen
                    Exit Select
                Case 1030
                    lblButton30.BackColor = Color.LimeGreen
                    Exit Select
                Case 1031
                    lblButton31.BackColor = Color.LimeGreen
                    Exit Select
                Case 1032
                    lblButton32.BackColor = Color.LimeGreen
                    Exit Select
                Case 1033
                    lblButton33.BackColor = Color.LimeGreen
                    Exit Select
                Case 1034
                    lblButton34.BackColor = Color.LimeGreen
                    Exit Select
                Case 1035
                    lblButton35.BackColor = Color.LimeGreen
                    Exit Select
                Case 1036
                    lblButton36.BackColor = Color.LimeGreen
                    Exit Select
                Case 1037
                    lblButton37.BackColor = Color.LimeGreen
                    Exit Select
                Case 1038
                    lblButton38.BackColor = Color.LimeGreen
                    Exit Select
                Case 1039
                    lblButton39.BackColor = Color.LimeGreen
                    Exit Select
                Case 1040
                    lblButton40.BackColor = Color.LimeGreen
                    Exit Select
                Case 1041
                    lblButton41.BackColor = Color.LimeGreen
                    Exit Select
                Case 1042
                    lblButton42.BackColor = Color.LimeGreen
                    Exit Select
                Case 1043
                    lblButton43.BackColor = Color.LimeGreen
                    Exit Select
                Case 1044
                    lblButton44.BackColor = Color.LimeGreen
                    Exit Select
                Case 1045
                    lblButton45.BackColor = Color.LimeGreen
                    Exit Select
                Case 1046
                    lblButton46.BackColor = Color.LimeGreen
                    Exit Select
                Case 1047
                    lblButton47.BackColor = Color.LimeGreen
                    Exit Select
                Case 1048
                    lblButton48.BackColor = Color.LimeGreen
                    Exit Select
                Case 1049
                    lblButton49.BackColor = Color.LimeGreen
                    Exit Select
                Case 1050
                    lblButton50.BackColor = Color.LimeGreen
                    Exit Select
                Case 1051
                    lblButton51.BackColor = Color.LimeGreen
                    Exit Select
                Case 1052
                    lblButton52.BackColor = Color.LimeGreen
                    Exit Select
                Case 1053
                    lblButton53.BackColor = Color.LimeGreen
                    Exit Select
                Case 1054
                    lblButton54.BackColor = Color.LimeGreen
                    Exit Select
                Case 1055
                    lblButton55.BackColor = Color.LimeGreen
                    Exit Select
                Case 1056
                    lblButton56.BackColor = Color.LimeGreen
                    Exit Select
                Case 1057
                    lblButton57.BackColor = Color.LimeGreen
                    Exit Select
                Case 1058
                    lblButton58.BackColor = Color.LimeGreen
                    Exit Select
                Case 1059
                    lblButton59.BackColor = Color.LimeGreen
                    Exit Select
                Case 1060
                    lblButton60.BackColor = Color.LimeGreen
                    Exit Select
                Case 1061
                    lblButton61.BackColor = Color.LimeGreen
                    Exit Select
                Case 1062
                    lblButton62.BackColor = Color.LimeGreen
                    Exit Select
                Case 1063
                    lblButton63.BackColor = Color.LimeGreen
                    Exit Select
                Case 1064
                    lblButton64.BackColor = Color.LimeGreen
                    Exit Select
                Case 1065
                    lblButton65.BackColor = Color.LimeGreen
                    Exit Select
                Case 1066
                    lblButton66.BackColor = Color.LimeGreen
                    Exit Select
                Case 1067
                    lblButton67.BackColor = Color.LimeGreen
                    Exit Select
                Case 1068
                    lblButton68.BackColor = Color.LimeGreen
                    Exit Select
                Case 1069
                    lblButton69.BackColor = Color.LimeGreen
                    Exit Select
                Case 1070
                    lblButton70.BackColor = Color.LimeGreen
                    Exit Select
                Case 1071
                    lblButton71.BackColor = Color.LimeGreen
                    Exit Select
                Case 1072
                    lblButton72.BackColor = Color.LimeGreen
                    Exit Select
                Case 1073
                    lblButton73.BackColor = Color.LimeGreen
                    Exit Select
                Case 1074
                    lblButton74.BackColor = Color.LimeGreen
                    Exit Select
                Case 1075
                    lblButton75.BackColor = Color.LimeGreen
                    Exit Select
                Case 1076
                    lblButton76.BackColor = Color.LimeGreen
                    Exit Select
                Case 1077
                    lblButton77.BackColor = Color.LimeGreen
                    Exit Select
                Case 1078
                    lblButton78.BackColor = Color.LimeGreen
                    Exit Select
                Case 1079
                    lblButton79.BackColor = Color.LimeGreen
                    Exit Select
                Case 1080
                    lblButton80.BackColor = Color.LimeGreen
                    Exit Select
                Case 1081
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
                    lblButton13.BackColor = Nothing
                    Exit Select
                Case 1014
                    lblButton14.BackColor = Nothing
                    Exit Select
                Case 1015
                    lblButton15.BackColor = Nothing
                    Exit Select
                Case 1016
                    lblButton16.BackColor = Nothing
                    Exit Select
                Case 1017
                    lblButton17.BackColor = Nothing
                    Exit Select
                Case 1018
                    lblButton18.BackColor = Nothing
                    Exit Select
                Case 1019
                    lblButton19.BackColor = Nothing
                    Exit Select
                Case 1020
                    lblButton20.BackColor = Nothing
                    Exit Select
                Case 1021
                    lblButton21.BackColor = Nothing
                    Exit Select
                Case 1022
                    lblButton22.BackColor = Nothing
                    Exit Select
                Case 1023
                    lblButton23.BackColor = Nothing
                    Exit Select
                Case 1024
                    lblButton24.BackColor = Nothing
                    Exit Select
                Case 1025
                    lblButton25.BackColor = Nothing
                    Exit Select
                Case 1026
                    lblButton26.BackColor = Nothing
                    Exit Select
                Case 1027
                    lblButton27.BackColor = Nothing
                    Exit Select
                Case 1028
                    lblButton28.BackColor = Nothing
                    Exit Select
                Case 1029
                    lblButton29.BackColor = Nothing
                    Exit Select
                Case 1030
                    lblButton30.BackColor = Nothing
                    Exit Select
                Case 1031
                    lblButton31.BackColor = Nothing
                    Exit Select
                Case 1032
                    lblButton32.BackColor = Nothing
                    Exit Select
                Case 1033
                    lblButton33.BackColor = Nothing
                    Exit Select
                Case 1034
                    lblButton34.BackColor = Nothing
                    Exit Select
                Case 1035
                    lblButton35.BackColor = Nothing
                    Exit Select
                Case 1036
                    lblButton36.BackColor = Nothing
                    Exit Select
                Case 1037
                    lblButton37.BackColor = Nothing
                    Exit Select
                Case 1038
                    lblButton38.BackColor = Nothing
                    Exit Select
                Case 1039
                    lblButton39.BackColor = Nothing
                    Exit Select
                Case 1040
                    lblButton40.BackColor = Nothing
                    Exit Select
                Case 1041
                    lblButton41.BackColor = Nothing
                    Exit Select
                Case 1042
                    lblButton42.BackColor = Nothing
                    Exit Select
                Case 1043
                    lblButton43.BackColor = Nothing
                    Exit Select
                Case 1044
                    lblButton44.BackColor = Nothing
                    Exit Select
                Case 1045
                    lblButton45.BackColor = Nothing
                    Exit Select
                Case 1046
                    lblButton46.BackColor = Nothing
                    Exit Select
                Case 1047
                    lblButton47.BackColor = Nothing
                    Exit Select
                Case 1048
                    lblButton48.BackColor = Nothing
                    Exit Select
                Case 1049
                    lblButton49.BackColor = Nothing
                    Exit Select
                Case 1050
                    lblButton50.BackColor = Nothing
                    Exit Select
                Case 1051
                    lblButton51.BackColor = Nothing
                    Exit Select
                Case 1052
                    lblButton52.BackColor = Nothing
                    Exit Select
                Case 1053
                    lblButton53.BackColor = Nothing
                    Exit Select
                Case 1054
                    lblButton54.BackColor = Nothing
                    Exit Select
                Case 1055
                    lblButton55.BackColor = Nothing
                    Exit Select
                Case 1056
                    lblButton56.BackColor = Nothing
                    Exit Select
                Case 1057
                    lblButton57.BackColor = Nothing
                    Exit Select
                Case 1058
                    lblButton58.BackColor = Nothing
                    Exit Select
                Case 1059
                    lblButton59.BackColor = Nothing
                    Exit Select
                Case 1060
                    lblButton60.BackColor = Nothing
                    Exit Select
                Case 1061
                    lblButton61.BackColor = Nothing
                    Exit Select
                Case 1062
                    lblButton62.BackColor = Nothing
                    Exit Select
                Case 1063
                    lblButton63.BackColor = Nothing
                    Exit Select
                Case 1064
                    lblButton64.BackColor = Nothing
                    Exit Select
                Case 1065
                    lblButton65.BackColor = Nothing
                    Exit Select
                Case 1066
                    lblButton66.BackColor = Nothing
                    Exit Select
                Case 1067
                    lblButton67.BackColor = Nothing
                    Exit Select
                Case 1068
                    lblButton68.BackColor = Nothing
                    Exit Select
                Case 1069
                    lblButton69.BackColor = Nothing
                    Exit Select
                Case 1070
                    lblButton70.BackColor = Nothing
                    Exit Select
                Case 1071
                    lblButton71.BackColor = Nothing
                    Exit Select
                Case 1072
                    lblButton72.BackColor = Nothing
                    Exit Select
                Case 1073
                    lblButton73.BackColor = Nothing
                    Exit Select
                Case 1074
                    lblButton74.BackColor = Nothing
                    Exit Select
                Case 1075
                    lblButton75.BackColor = Nothing
                    Exit Select
                Case 1076
                    lblButton76.BackColor = Nothing
                    Exit Select
                Case 1077
                    lblButton77.BackColor = Nothing
                    Exit Select
                Case 1078
                    lblButton78.BackColor = Nothing
                    Exit Select
                Case 1079
                    lblButton79.BackColor = Nothing
                    Exit Select
                Case 1080
                    lblButton80.BackColor = Nothing
                    Exit Select
                Case 1081
                    lblProgSwitch.BackColor = Nothing
                    Exit Select
            End Select
        End If
        lblUID.Text = "Unit ID: " + Xk60_80_1.ConnectedDevices(0).UnitID.ToString()
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
        Xk60_80_1.SetBacklightLED(0, ButtonID, 0, LightState)
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
        Xk60_80_1.SetBacklightLED(0, ButtonID, 1, LightState)
    End Sub

    Private Sub btnSaveState_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveState.Click
        'Saves backlighting state to the memory of the device, when called the current state of the backlights will be the default state when device is booted
        Xk60_80_1.SaveBacklightState(0)
    End Sub

    Private Sub btnUID_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUID.Click
        Dim id As Integer = Convert.ToInt32(txtUID.Text)

        'Sets device Unit ID
        Xk60_80_1.SetDeviceUID(0, id)
        lblUID.Text = "Unit ID: " + Xk60_80_1.ConnectedDevices(0).UnitID.ToString()
    End Sub

    Private Sub btnOEM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOEM.Click
        Dim id = Convert.ToInt32(txtOEM.Text)

        'Sets device OEM Version ID
        Xk60_80_1.SetOEMVersionID(0, id, True)
    End Sub

    Private Sub btnIntensity_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIntensity.Click
        Dim Intensity1 As Integer = Convert.ToInt32(spnBlueIntensity.Value)
        Dim Intensity2 As Integer = Convert.ToInt32(spnRedIntensity.Value)

        'Sets the intensity for both backlighting banks
        Xk60_80_1.SetBacklightIntensity(0, Intensity1, Intensity2)
    End Sub

    Private Sub btnRowsBlue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRowsBlue.Click
        Dim row1, row2, row3, row4, row5, row6, row7, row8 As Boolean

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

        If (cboRow4.Text = "On") Then
            row4 = True
        Else
            row4 = False
        End If

        If (cboRow5.Text = "On") Then
            row5 = True
        Else
            row5 = False
        End If

        If (cboRow6.Text = "On") Then
            row6 = True
        Else
            row6 = False
        End If

        If (cboRow7.Text = "On") Then
            row7 = True
        Else
            row7 = False
        End If

        If (cboRow8.Text = "On") Then
            row8 = True
        Else
            row8 = False
        End If

        'Sets individual rows of backlights on bank 0
        Xk60_80_1.SetRowsOfBacklights(0, 0, row1, row2, row3, row4, row5, row6, row7, row8)
    End Sub

    Private Sub btnRowsRed_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRowsRed.Click
        Dim row1, row2, row3, row4, row5, row6, row7, row8 As Boolean

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

        If (cboRow4.Text = "On") Then
            row4 = True
        Else
            row4 = False
        End If

        If (cboRow5.Text = "On") Then
            row5 = True
        Else
            row5 = False
        End If

        If (cboRow6.Text = "On") Then
            row6 = True
        Else
            row6 = False
        End If

        If (cboRow7.Text = "On") Then
            row7 = True
        Else
            row7 = False
        End If

        If (cboRow8.Text = "On") Then
            row8 = True
        Else
            row8 = False
        End If

        'Sets individual rows of backlights on bank 0
        Xk60_80_1.SetRowsOfBacklights(0, 1, row1, row2, row3, row4, row5, row6, row7, row8)
    End Sub

    Private Sub btnToggleAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnToggleAll.Click
        'Toggles backlighting on and off
        Xk60_80_1.ToggleBacklights(0)
    End Sub

    Private Sub btnAllBlue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAllBlue.Click
        'Sets all the blue on or off
        If (AllBlue = True) Then
            Xk60_80_1.SetAllBlue(0, False)
            AllBlue = False
        Else
            Xk60_80_1.SetAllBlue(0, True)
            AllBlue = True
        End If
    End Sub

    Private Sub btnAllRed_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAllRed.Click
        'Sets all the red on or off
        If (AllRed = True) Then
            Xk60_80_1.SetAllRed(0, False)
            AllRed = False
        Else
            Xk60_80_1.SetAllRed(0, True)
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
        Xk60_80_1.SendKeystrokes(0, False, False, False, False, False, False, False, False, 4, 5, 6, 0, 0, 0)
        'Releases all sent keys
        Xk60_80_1.SendKeystrokes(0, False, False, False, False, False, False, False, False, 0, 0, 0, 0, 0, 0)
    End Sub

    Private Sub btnJoystick_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnJoystick.Click
        'Sends game controller message, open Game Controllers control panel to see
        'Joystick endpoint required
        If (Xk60_80_1.ConnectedDevices(0).JoystickInterface = True) Then
            Dim buttons As Boolean() = {False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False}
            Xk60_80_1.SendJoystick(0, 100, 100, 0, 0, 0, 8, buttons)
        Else
            MessageBox.Show("No joystick endpoint available, change to pid 1027")
        End If
    End Sub

    Private Sub btnMouse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMouse.Click
        'Moves mouse cursor right and up from its current position
        'Mouse endpoint required 
        If (Xk60_80_1.ConnectedDevices(0).MouseInterface = True) Then
            Xk60_80_1.SendMouse(0, False, False, False, False, False, 20, 20, 0)
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

        Xk60_80_1.SetSecurityKey(0, byte1, byte2, byte3, byte4)
    End Sub

    Private Sub btnCheckDongle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCheckDongle.Click
        'Enter the 4 bytes used when xk24_1.SetSecurityKey was called
        Dim byte1 As Byte = Convert.ToByte(txtByte1.Text)
        Dim byte2 As Byte = Convert.ToByte(txtByte2.Text)
        Dim byte3 As Byte = Convert.ToByte(txtByte3.Text)
        Dim byte4 As Byte = Convert.ToByte(txtByte4.Text)

        'Checks the security key by sending the selected bytes to the device; bytes were valid if it returns true
        Dim dongle As Boolean = Xk60_80_1.GetSecurityKey(0, byte1, byte2, byte3, byte4)

        If (dongle = True) Then
            grpDongle.BackColor = Color.Green
        ElseIf (dongle = False) Then
            grpDongle.BackColor = Color.Red
        End If
    End Sub

    Private Sub btnGenerate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerate.Click
        'Use this to generate a report which gives the state of the buttons even if there was no change in their states, this is often useful on start of application to get initial states of the switches (buttons)
        'Sending this command will trigger the _GenerateReportData event
        Xk60_80_1.GenerateReport(0)
    End Sub

    Private Sub Xk60_80_1_DevicePlug(ByVal e As XK_60_80.XKeyPlugEventArgs) Handles Xk60_80_1.DevicePlug
        deviceStatus.Text = "XK-80/XK-60 Plugged, Unit ID: " + e.UID.ToString() + ", OEM ID: " + e.OEMVersionID.ToString() + ", Product ID: " + e.PID.ToString()
        deviceStatus.ForeColor = Color.Green

        'Gets the Unit ID from the device
        lblUID.Text = "Unit ID: " + e.UID.ToString()

        'Gets the OEM Version ID from the device
        lblOEM.Text = "OEM ID: " + e.OEMVersionID.ToString()

        'Gets the Product ID from the device
        lblProductID.Text = "Product ID: " + e.PID.ToString()
        saveabsolutetime = -1
    End Sub

    Private Sub Xk60_80_1_DeviceUnplug(ByVal e As XK_60_80.XKeyPlugEventArgs) Handles Xk60_80_1.DeviceUnplug
        deviceStatus.Text = "XK-80/XK-60 Unplugged, Unit ID: " + e.UID.ToString() + ", OEM ID: " + e.OEMVersionID.ToString() + ", Product ID: " + e.PID.ToString()
        deviceStatus.ForeColor = Color.Red

        lblUID.Text = "Unit ID: "
        lblOEM.Text = "OEM ID: "
        lblProductID.Text = "Product ID: "
    End Sub

    Private Sub Xk60_80_1_GenerateReportData(ByVal e As XK_60_80.XKeyEventArgs) Handles Xk60_80_1.GenerateReportData
        Xk60_80_1_ButtonChange(e)
    End Sub

    Private Sub btn1089_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1089.Click
        'Changes device to the 1089 (XK-80 only) Product ID (device will "replug" itself)
        'Change to this Product ID if you desire Keyboard and Mouse endpoints
        Xk60_80_1.ChangePID(0, 1089)
    End Sub

    Private Sub btn1091_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1091.Click
        'Changes device to the 1091 (XK-80 only) Product ID (device will "replug" itself)
        'Change to this Product ID if you desire Joystick and Mouse endpoints
        Xk60_80_1.ChangePID(0, 1091)
    End Sub

    Private Sub btn1121_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1121.Click
        'Changes device to the 1121 (XK-60 only) Product ID (device will "replug" itself)
        'Change to this Product ID if you desire Keyboard and Mouse endpoints
        Xk60_80_1.ChangePID(0, 1121)
    End Sub

    Private Sub btn1123_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1123.Click
        'Changes device to the 1123 (XK-60 only) Product ID (device will "replug" itself)
        'Change to this Product ID if you desire Joystick and Mouse endpoints
        Xk60_80_1.ChangePID(0, 1123)
    End Sub

    Private Sub btnFrequency_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFrequency.Click
        Dim flashfreq As Integer
        flashfreq = System.Convert.ToInt16(spnFrequency.Value)
        Xk60_80_1.SetFlashFrequency(0, flashfreq)
    End Sub

    Private Sub chkGreen_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkGreen.CheckedChanged
        If chkGreen.Checked = False Then
            Xk60_80_1.SetGreenIndicator(0, 0)
        Else
            If (chkGreenFlash.Checked = True) Then
                Xk60_80_1.SetGreenIndicator(0, 2)
            Else
                Xk60_80_1.SetGreenIndicator(0, 1)
            End If
        End If
    End Sub

    Private Sub chkRed_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkRed.CheckedChanged
        If chkRed.Checked = False Then
            Xk60_80_1.SetRedIndicator(0, 0)
        Else
            If (chkRedFlash.Checked = True) Then
                Xk60_80_1.SetRedIndicator(0, 2)
            Else
                Xk60_80_1.SetRedIndicator(0, 1)
            End If
        End If
    End Sub

    Private Sub chkGreenFlash_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkGreenFlash.CheckedChanged
        If (chkGreen.Checked = True) Then
            If (chkGreenFlash.Checked = True) Then
                Xk60_80_1.SetGreenIndicator(0, 2)
            Else
                Xk60_80_1.SetGreenIndicator(0, 1)
            End If
        End If
    End Sub

    Private Sub chkRedFlash_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkRedFlash.CheckedChanged
        If (chkRed.Checked = True) Then
            If (chkRedFlash.Checked = True) Then
                Xk60_80_1.SetRedIndicator(0, 2)
            Else
                Xk60_80_1.SetRedIndicator(0, 1)
            End If
        End If
    End Sub
End Class
