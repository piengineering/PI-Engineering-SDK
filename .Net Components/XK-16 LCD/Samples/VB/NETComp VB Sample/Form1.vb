Public Class Form1
    'The following is a sample showing how to interact with an XK-16 LCD device using the X-keys XK-16 LCD .NET component.

    'Variables to track the device lights, initial states here based on device defaults
    Dim AllBlue As Boolean = True
    Dim AllRed As Boolean = True
    Dim saveabsolutetime As Long = -1 'for time stamp demo

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If (Xk16LCD_1.ConnectedDevices.Length > 0) Then
                deviceStatus.Text = "XK-16 LCD Connected"
                deviceStatus.ForeColor = Color.Green

                'Gets the Unit ID from the device
                lblUID.Text = "Unit ID: " & Xk16LCD_1.ConnectedDevices(0).UnitID.ToString()

                'Gets the OEM Version ID from the device
                lblOEM.Text = "OEM Version ID: " & Xk16LCD_1.ConnectedDevices(0).OEMVersion.ToString()

                'Gets the Product ID from the device
                lblProductID.Text = "Product ID: " & Xk16LCD_1.ConnectedDevices(0).Pid.ToString()

                'Set the PID in the cboPIDS
                cboPIDs.SelectedIndex = Xk16LCD_1.ConnectedDevices(0).Pid - 1316

            End If
        Catch ex As Exception
            deviceStatus.Text = "No XK-16 LCD Connected"
            deviceStatus.ForeColor = Color.Red
        End Try
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
        Xk16LCD_1.SetBacklightLED(0, ButtonID, 0, LightState)
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
        Xk16LCD_1.SetBacklightLED(0, ButtonID, 1, LightState)
    End Sub

    Private Sub btnSaveState_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveState.Click
        'Saves backlighting state to the memory of the device, when called the current state of the backlights will be the default state when device is booted
        Xk16LCD_1.SaveBacklightState(0)
    End Sub

    Private Sub btnUID_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUID.Click
        Dim id As Integer = Convert.ToInt32(txtUID.Text)

        'Sets device Unit ID
        Xk16LCD_1.SetDeviceUID(0, id)
        lblUID.Text = "Unit ID: " + Xk16LCD_1.ConnectedDevices(0).UnitID.ToString()

    End Sub

    Private Sub btnOEM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOEM.Click
        Dim id = Convert.ToInt32(txtOEM.Text)

        'Sets device OEM Version ID
        Xk16LCD_1.SetOEMVersionID(0, id, True)
    End Sub

    Private Sub btnIntensity_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIntensity.Click
        Dim Intensity1 As Integer = Convert.ToInt32(spnBlueIntensity.Value)
        Dim Intensity2 As Integer = Convert.ToInt32(spnRedIntensity.Value)

        'Sets the intensity for both backlighting banks, valid values 0-255
        Xk16LCD_1.SetBacklightIntensity(0, Intensity1, Intensity2)
    End Sub

    Private Sub btnRowsBlue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRowsBlue.Click
        Dim row1, row2, row3, row4 As Boolean

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

        'Sets individual rows of backlights on bank 0
        Xk16LCD_1.SetRowsOfBacklights(0, 0, row1, row2, row3, row4)
    End Sub

    Private Sub btnRowsRed_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRowsRed.Click
        Dim row1, row2, row3, row4 As Boolean

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

        'Sets individual rows of backlights on bank 0
        Xk16LCD_1.SetRowsOfBacklights(0, 1, row1, row2, row3, row4)
    End Sub

    Private Sub btnToggleAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnToggleAll.Click
        'Toggles backlighting on and off
        Xk16LCD_1.ToggleBacklights(0)
    End Sub

    Private Sub btnAllBlue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAllBlue.Click
        'Sets all the blue on or off
        If (AllBlue = True) Then
            Xk16LCD_1.SetAllBlue(0, False)
            AllBlue = False
        Else
            Xk16LCD_1.SetAllBlue(0, True)
            AllBlue = True
        End If
    End Sub

    Private Sub btnAllRed_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAllRed.Click
        'Sets all the red on or off
        If (AllRed = True) Then
            Xk16LCD_1.SetAllRed(0, False)
            AllRed = False
        Else
            Xk16LCD_1.SetAllRed(0, True)
            AllRed = True
        End If
    End Sub

    Private Sub btnKeyboard_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnKeyboard.Click
        'Keyboard endpoint required
        If (Xk16LCD_1.ConnectedDevices(0).KeyboardInterface = True) Then
            txtKeyboard.Focus()
            'Sends the letters 'a' 'b' and 'c'
            Xk16LCD_1.SendKeystrokes(0, False, False, False, False, False, False, False, False, 4, 5, 6, 0, 0, 0)
            'Releases all sent keys
            Xk16LCD_1.SendKeystrokes(0, False, False, False, False, False, False, False, False, 0, 0, 0, 0, 0, 0)
        Else
            MessageBox.Show("No keyboard endpoint available")
        End If
    End Sub

    Private Sub btnJoystick_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnJoystick.Click
        'Sends game controller message, open Game Controllers control panel to see
        'Joystick endpoint required
        If (Xk16LCD_1.ConnectedDevices(0).JoystickInterface = True) Then
            Dim buttons As Boolean() = {False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False}
            Xk16LCD_1.SendJoystick(0, 100, 100, 0, 0, 0, 8, buttons)
        Else
            MessageBox.Show("No joystick endpoint available")
        End If
    End Sub

    Private Sub btnMouse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMouse.Click
        'Moves mouse cursor right and up from its current position
        'Mouse endpoint required
        If (Xk16LCD_1.ConnectedDevices(0).MouseInterface = True) Then
            Xk16LCD_1.SendMouse(0, False, False, False, False, False, 20, 20, 0)
        Else
            MessageBox.Show("No mouse endpoint available")
        End If
    End Sub

    Private Sub btnMultimedia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMultimedia.Click
        'Enter in high and low bytes of the multimedia code
        'Many multimedia commands require the app to have focus to work.  Some that don't are Mute (00E2), Volume Increment (00E9), Volume Decrement (00EA)
        'The Multimedia reflector is mainly designed to be used as hardware mode macros.
        'Some common multimedia codes
        'Scan Next Track	00B5
        'Scan Previous Track	00B6
        'Stop	00B7
        'Play/Pause	00CD
        'Mute	00E2
        'Bass Boost	00E5
        'Loudness	00E7
        'Volume Up	00E9
        'Volume Down	00EA
        'Bass Up	0152
        'Bass Down	0153
        'Treble Up	0154
        'Treble Down	0155
        'Media Select	0183
        'Mail	018A
        'Calculator	0192
        'My Computer	0194
        'Search	0221
        'Home	0223
        'Back	0224
        'Forward	0225
        'Stop	0226
        'Refresh	0227
        'Favorites	022A
        If Xk16LCD_1.ConnectedDevices(0).MultimediaInterface = True Then
            'IMPORTANT must send a terminate command

            Xk16LCD_1.SendMultimedia(0, txtMMCode.Text.Substring(0, 2), txtMMCode.Text.Substring(2, 2))

            '//IMPORTANT must send a terminate command
            '//note when the "terminate" command is sent can sometimes have an effect on the behavior of the command,
            '//for example in volume decrement (EA=lo byte, 00=hi byte) if you send the terminate immediately after the first SendMultimedia command it will
            '//decrement the volume one step, if you send the SendMultimedia("00 "EA") on the press and the terminate SendMultimedia("00 "00") on the release the volume will continuously
            '//decrement until the key is released.
            Xk16LCD_1.SendMultimedia(0, "00", "00")
        Else
            MessageBox.Show("No multimedia endpoint available")
        End If
    End Sub

    Private Sub btnSetDongle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetDongle.Click
        'Enter in 4 bytes. REMEMBER these 4 bytes they will be required to check the dongle
        Dim byte1 As Byte = Convert.ToByte(txtByte1.Text)
        Dim byte2 As Byte = Convert.ToByte(txtByte2.Text)
        Dim byte3 As Byte = Convert.ToByte(txtByte3.Text)
        Dim byte4 As Byte = Convert.ToByte(txtByte4.Text)

        Xk16LCD_1.SetSecurityKey(0, byte1, byte2, byte3, byte4)
    End Sub

    Private Sub btnCheckDongle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCheckDongle.Click
        'Enter the 4 bytes used when Xk16LCD_1.SetSecurityKey was called
        Dim byte1 As Byte = Convert.ToByte(txtByte1.Text)
        Dim byte2 As Byte = Convert.ToByte(txtByte2.Text)
        Dim byte3 As Byte = Convert.ToByte(txtByte3.Text)
        Dim byte4 As Byte = Convert.ToByte(txtByte4.Text)

        'Checks the security key by sending the selected bytes to the device; bytes were valid if it returns true
        Dim dongle As Boolean = Xk16LCD_1.GetSecurityKey(0, byte1, byte2, byte3, byte4)

        If (dongle = True) Then
            grpDongle.BackColor = Color.Green
        ElseIf (dongle = False) Then
            grpDongle.BackColor = Color.Red
        End If
    End Sub

    Private Sub btnGenerate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerate.Click
        'Use this to generate a report which gives the state of the buttons even if there was no change in their states, this is often useful on start of application to get initial states of the switches (buttons)
        'Sending this command will trigger the _GenerateReportData event
        Xk16LCD_1.GenerateReport(0)
    End Sub

    Private Sub btnFrequency_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFrequency.Click
        Dim flashfreq As Integer
        flashfreq = System.Convert.ToInt16(spnFrequency.Value)
        Xk16LCD_1.SetFlashFrequency(0, flashfreq)
    End Sub

    Private Sub Xk16LCD_1_ButtonChange(ByVal e As Xk16LCD.XKeyEventArgs) Handles Xk16LCD_1.ButtonChange
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
                    lblProgSwitch.Text = "Prog. Switch-dn"
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
                    lblProgSwitch.Text = "Prog. Switch-up"
                    Exit Select
            End Select
        End If
        lblUID.Text = "Unit ID: " + Xk16LCD_1.ConnectedDevices(0).UnitID.ToString()

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

    Private Sub Xk16LCD_1_DevicePlug(ByVal e As Xk16LCD.XKeyPlugEventArgs) Handles Xk16LCD_1.DevicePlug
        deviceStatus.Text = "XK-16 LCD Plugged, Unit ID: " + e.UID.ToString() + ", OEM ID: " + e.OEMVersionID.ToString() + ", Product ID: " + e.PID.ToString()
        deviceStatus.ForeColor = Color.Green

        'Gets the Unit ID from the device
        lblUID.Text = "Unit ID: " + e.UID.ToString()

        'Gets the OEM Version ID from the device
        lblOEM.Text = "OEM ID: " + e.OEMVersionID.ToString()

        'Gets the Product ID from the device
        lblProductID.Text = "Product ID: " + e.PID.ToString()

        saveabsolutetime = -1
    End Sub

    Private Sub Xk16LCD_1_DeviceUnplug(ByVal e As Xk16LCD.XKeyPlugEventArgs) Handles Xk16LCD_1.DeviceUnplug
        deviceStatus.Text = "XK-16 LCD Unplugged, Unit ID: " + e.UID.ToString() + ", OEM ID: " + e.OEMVersionID.ToString() + ", Product ID: " + e.PID.ToString()
        deviceStatus.ForeColor = Color.Red

        lblUID.Text = "Unit ID: "
        lblOEM.Text = "OEM ID: "
        lblProductID.Text = "Product ID: "
    End Sub

    Private Sub Xk16LCD_1_GenerateReportData(ByVal e As Xk16LCD.XKeyEventArgs) Handles Xk16LCD_1.GenerateReportData
        Xk16LCD_1_ButtonChange(e)
    End Sub

    Private Sub btnChangePID_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChangePID.Click
        'Changes device to the selected Product ID
        Dim newpid As Integer = -1
        Select Case cboPIDs.SelectedIndex
            Case 0
                newpid = 1316
                Exit Select
            Case 1
                newpid = 1317
                Exit Select
            Case 2
                newpid = 1318
                Exit Select
            Case 3
                newpid = 1319
                Exit Select
            Case 4
                newpid = 1320
                Exit Select
            Case 5
                newpid = 1321
                Exit Select
            Case 6
                newpid = 1322
                Exit Select
        End Select
        If newpid <> -1 Then
            Xk16LCD_1.ChangePID(0, newpid)
        End If
    End Sub

    Private Sub btnWriteLCD1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWriteLCD1.Click
        Dim blstate As Integer = 1
        If chkBacklight.Checked = False Then
            blstate = 0
        End If
        Xk16LCD_1.SetLCDRow(0, 0, blstate, txtWriteLCD1.Text)
    End Sub

    Private Sub btnWriteLCD2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWriteLCD2.Click
        Dim blstate As Integer = 1
        If chkBacklight.Checked = False Then
            blstate = 0
        End If
        Xk16LCD_1.SetLCDRow(0, 1, blstate, txtWriteLCD2.Text)
    End Sub

    Private Sub btnClearLCD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearLCD.Click
        Dim blstate As Integer = 1
        If chkBacklight.Checked = False Then
            blstate = 0
        End If
        Xk16LCD_1.SetLCDRow(0, 0, blstate, "")
        Xk16LCD_1.SetLCDRow(0, 1, blstate, "")
    End Sub

    Private Sub chkGreen_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkGreen.CheckedChanged
        If chkGreen.Checked = False Then
            Xk16LCD_1.SetGreenIndicator(0, 0)
        Else
            If (chkGreenFlash.Checked = True) Then
                Xk16LCD_1.SetGreenIndicator(0, 2)
            Else
                Xk16LCD_1.SetGreenIndicator(0, 1)
            End If
        End If
    End Sub

    Private Sub chkRed_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkRed.CheckedChanged
        If chkRed.Checked = False Then
            Xk16LCD_1.SetRedIndicator(0, 0)
        Else
            If (chkRedFlash.Checked = True) Then
                Xk16LCD_1.SetRedIndicator(0, 2)
            Else
                Xk16LCD_1.SetRedIndicator(0, 1)
            End If
        End If
    End Sub

    Private Sub chkGreenFlash_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkGreenFlash.CheckedChanged
        If (chkGreen.Checked = True) Then
            If (chkGreenFlash.Checked = True) Then
                Xk16LCD_1.SetGreenIndicator(0, 2)
            Else
                Xk16LCD_1.SetGreenIndicator(0, 1)
            End If
        End If
    End Sub

    Private Sub chkRedFlash_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkRedFlash.CheckedChanged
        If (chkRed.Checked = True) Then
            If (chkRedFlash.Checked = True) Then
                Xk16LCD_1.SetRedIndicator(0, 2)
            Else
                Xk16LCD_1.SetRedIndicator(0, 1)
            End If
        End If
    End Sub
End Class
