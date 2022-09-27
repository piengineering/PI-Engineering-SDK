Imports System.Text 'for StringBuilder
Public Class Form1
    'The following is a sample showing how to interact with an XK-80/60 device using the X-keys XK-80/60 .NET component.

    'Variables to track the device lights, initial states here based on device defaults
    Dim AllBlue As Boolean = True
    Dim AllRed As Boolean = True
    Dim saveabsolutetime As Long = -1 'for time stamp demo

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If (XkGEN_1.ConnectedDevices.Length > 0) Then
                deviceStatus.Text = XkGEN_1.ConnectedDevices(0).ProductString + " Connected"
                deviceStatus.ForeColor = Color.Green

                'Gets the Unit ID from the device
                lblUID.Text = "Unit ID: " & XkGEN_1.ConnectedDevices(0).UnitID.ToString()

                'Gets the OEM Version ID from the device
                lblOEM.Text = "OEM Version ID: " & XkGEN_1.ConnectedDevices(0).OEMVersion.ToString()

                'Gets the Product ID from the device
                lblProductID.Text = "Product ID: " & XkGEN_1.ConnectedDevices(0).Pid.ToString()
            End If
        Catch ex As Exception
            deviceStatus.Text = "No X-keys Connected"
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

        Dim BacklightIndex As Integer = Convert.ToInt32(txtBacklightIndex.Text)

        'Sets an individual LED based on chosen BacklightIndex and LightState-reference PIEngineeringSDK.chm for BacklightIndex for specific products
        XkGEN_1.SetBacklightLED(0, BacklightIndex, LightState)
    End Sub

    Private Sub btnSaveState_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveState.Click
        'Saves backlighting state to the memory of the device, when called the current state of the backlights will be the default state when device is booted
        XkGEN_1.SaveBacklightState(0)
    End Sub

    Private Sub btnUID_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUID.Click
        Dim id As Integer = Convert.ToInt32(txtUID.Text)

        'Sets device Unit ID
        XkGEN_1.SetDeviceUID(0, id)
        lblUID.Text = "Unit ID: " + XkGEN_1.ConnectedDevices(0).UnitID.ToString()
    End Sub

    Private Sub btnOEM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOEM.Click
        Dim id = Convert.ToInt32(txtOEM.Text)

        'Sets device OEM Version ID
        XkGEN_1.SetOEMVersionID(0, id, True)
    End Sub

    Private Sub btnIntensity_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIntensity.Click
        Dim Intensity1 As Integer = Convert.ToInt32(spnBlueIntensity.Value)
        Dim Intensity2 As Integer = Convert.ToInt32(spnRedIntensity.Value)

        'Sets the intensity for both backlighting banks
        XkGEN_1.SetBacklightIntensity(0, Intensity1, Intensity2)
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
        XkGEN_1.SetRowsOfBacklights(0, 0, row1, row2, row3, row4, row5, row6, row7, row8)
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
        XkGEN_1.SetRowsOfBacklights(0, 1, row1, row2, row3, row4, row5, row6, row7, row8)
    End Sub

    Private Sub btnToggleAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnToggleAll.Click
        'Toggles backlighting on and off
        XkGEN_1.ToggleBacklights(0)
    End Sub

    Private Sub btnAllBlue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAllBlue.Click
        'Sets all the blue on or off
        If (AllBlue = True) Then
            XkGEN_1.SetAllBlue(0, False)
            AllBlue = False
        Else
            XkGEN_1.SetAllBlue(0, True)
            AllBlue = True
        End If
    End Sub

    Private Sub btnAllRed_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAllRed.Click
        'Sets all the red on or off
        If (AllRed = True) Then
            XkGEN_1.SetAllRed(0, False)
            AllRed = False
        Else
            XkGEN_1.SetAllRed(0, True)
            AllRed = True
        End If
    End Sub



    Private Sub btnKeyboard_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnKeyboard.Click
        txtKeyboard.Focus()
        'Sends the letters 'a' 'b' and 'c'
        XkGEN_1.SendKeystrokes(0, False, False, False, False, False, False, False, False, 4, 5, 6, 0, 0, 0)
        'Releases all sent keys
        XkGEN_1.SendKeystrokes(0, False, False, False, False, False, False, False, False, 0, 0, 0, 0, 0, 0)
    End Sub

    Private Sub btnJoystick_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnJoystick.Click
        'Sends game controller message, open Game Controllers control panel to see
        'Joystick endpoint required

        Dim buttons As Boolean() = {False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False, False}
        XkGEN_1.SendJoystick(0, 100, 100, 0, 0, 0, 8, buttons)

    End Sub

    Private Sub btnMouse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMouse.Click
        'Moves mouse cursor right and up from its current position
        'Mouse endpoint required 

        XkGEN_1.SendMouse(0, False, False, False, False, False, 20, 20, 0)

    End Sub

    Private Sub btnSetDongle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetDongle.Click
        'Enter in 4 bytes. REMEMBER these 4 bytes they will be required to check the dongle
        Dim byte1 As Byte = Convert.ToByte(txtByte1.Text)
        Dim byte2 As Byte = Convert.ToByte(txtByte2.Text)
        Dim byte3 As Byte = Convert.ToByte(txtByte3.Text)
        Dim byte4 As Byte = Convert.ToByte(txtByte4.Text)

        XkGEN_1.SetSecurityKey(0, byte1, byte2, byte3, byte4)
    End Sub

    Private Sub btnCheckDongle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCheckDongle.Click
        'Enter the 4 bytes used when xk24_1.SetSecurityKey was called
        Dim byte1 As Byte = Convert.ToByte(txtByte1.Text)
        Dim byte2 As Byte = Convert.ToByte(txtByte2.Text)
        Dim byte3 As Byte = Convert.ToByte(txtByte3.Text)
        Dim byte4 As Byte = Convert.ToByte(txtByte4.Text)

        'Checks the security key by sending the selected bytes to the device; bytes were valid if it returns true
        Dim dongle As Boolean = XkGEN_1.GetSecurityKey(0, byte1, byte2, byte3, byte4)

        If (dongle = True) Then
            grpDongle.BackColor = Color.Green
        ElseIf (dongle = False) Then
            grpDongle.BackColor = Color.Red
        End If
    End Sub

    Private Sub btnGenerate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerate.Click
        'Use this to generate a report which gives the state of the buttons even if there was no change in their states, this is often useful on start of application to get initial states of the switches (buttons)
        'Sending this command will trigger the _GenerateReportData event
        XkGEN_1.GenerateReport(0)
    End Sub

    Private Sub btnPIDChange_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPIDChange.Click
        'Changes device to PID selected based on its index (device will "replug" itself), PID #1 has index=0, PID#2=1, etc.
        'consult PIEngineeringSDK.chm for available PIDs and their endpoints

        Dim PIDIndex As Integer = Convert.ToInt32(txtPIDIndex.Text)
        XkGEN_1.ChangePID(0, PIDIndex)

    End Sub

    Private Sub btnFrequency_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFrequency.Click
        Dim flashfreq As Integer
        flashfreq = System.Convert.ToInt16(spnFrequency.Value)
        XkGEN_1.SetFlashFrequency(0, flashfreq)
    End Sub

    Private Sub chkGreen_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkGreen.CheckedChanged
        If chkGreen.Checked = False Then
            XkGEN_1.SetGreenIndicator(0, 0)
        Else
            If (chkGreenFlash.Checked = True) Then
                XkGEN_1.SetGreenIndicator(0, 2)
            Else
                XkGEN_1.SetGreenIndicator(0, 1)
            End If
        End If
    End Sub

    Private Sub chkRed_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkRed.CheckedChanged
        If chkRed.Checked = False Then
            XkGEN_1.SetRedIndicator(0, 0)
        Else
            If (chkRedFlash.Checked = True) Then
                XkGEN_1.SetRedIndicator(0, 2)
            Else
                XkGEN_1.SetRedIndicator(0, 1)
            End If
        End If
    End Sub

    Private Sub chkGreenFlash_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkGreenFlash.CheckedChanged
        If (chkGreen.Checked = True) Then
            If (chkGreenFlash.Checked = True) Then
                XkGEN_1.SetGreenIndicator(0, 2)
            Else
                XkGEN_1.SetGreenIndicator(0, 1)
            End If
        End If
    End Sub

    Private Sub chkRedFlash_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkRedFlash.CheckedChanged
        If (chkRed.Checked = True) Then
            If (chkRedFlash.Checked = True) Then
                XkGEN_1.SetRedIndicator(0, 2)
            Else
                XkGEN_1.SetRedIndicator(0, 1)
            End If
        End If
    End Sub

    Private Sub btnRegisterAnalog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRegisterAnalog.Click
        'If you don't want to receive an AnalogChange event then unregister it, 
        'AnalogByte is the byte position of the desired analog value, see PIEngineeringSDK.chm for specific products
        XkGEN_1.RegisterAnalog(0, 16) 'XK-68 Joystick X
        XkGEN_1.RegisterAnalog(0, 17) 'XK-68 Joystick Y
        XkGEN_1.RegisterAnalog(0, 18) 'XK-68 Joystick Z
    End Sub

    Private Sub btnUnregisterAnalog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUnregisterAnalog.Click
        'In order to receive an AnalogChange event user must first register the desired analog byte or bytes
        XkGEN_1.UnRegisterAnalog(0, 18) 'XK-68 Joystick Z
    End Sub

    Private Sub btnGenericWriteData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenericWriteData.Click
        Dim wData() As Byte = New Byte((XkGEN_1.ConnectedDevices(0).WriteLength) - 1) {}
        Dim j As Integer = 0
        Do While (j < XkGEN_1.ConnectedDevices(0).WriteLength)
            wData(j) = 0
            j = (j + 1)
        Loop

        wData(0) = 0
        wData(1) = 184 'toggle backlights

        XkGEN_1.GenericWriteData(0, wData)
    End Sub

    Private Sub button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles button1.Click
        listBox1.Items.Clear()
    End Sub

    Private Sub XkGEN_1_AnalogChange(ByVal e As XkGEN.XKeyAnalogArgs) Handles XkGEN_1.AnalogChange
        lblAnalogs.Text = ("byte " _
            + (e.AnalogByte.ToString + (" = " + e.AnalogVal.ToString)))
        'specific example for XK-68 Joystick
        Select Case (e.AnalogByte)
            Case 15
                lblJoyX.Text = ("X: " + e.AnalogVal.ToString)
            Case 16
                lblJoyY.Text = ("Y: " + e.AnalogVal.ToString)
            Case 17
                lblJoyZ.Text = ("Z: " + e.AnalogVal.ToString)
        End Select

        'Time Stamp-user must know the time stamp byte positions for the specific device being used, this sample for XK-68 Joystick
        Dim absolutetime As Long = ((16777216 * e.RawData(19)) _
                    + ((65536 * e.RawData(20)) _
                    + ((256 * e.RawData(21)) _
                    + e.RawData(22))))
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

    Private Sub XkGEN_1_ButtonChange(ByVal e As XkGEN.XKeyEventArgs) Handles XkGEN_1.ButtonChange
        'This method handles the button change event for the device

        'Gets the button number (CID) of the button that has changed state

        Dim ButtonNum As [String] = (e.CID - 1000).ToString()

        'Logic structure to handle both "press" (true) and "release" (false) states
        If e.PressState = True Then
            lblButton.Text = e.CID.ToString() + " press"
        ElseIf e.PressState = False Then
            lblButton.Text = e.CID.ToString() + " release"
        End If


        lblUID.Text = "Unit ID: " + XkGEN_1.ConnectedDevices(0).UnitID.ToString()


        'Time Stamp Info - NOTE this sample is using the XK-68 Joystick as an example, other product's time stamp's may be in different byte positions.
        Dim absolutetime As Long = ((16777216 * e.RawData(19)) _
            + ((65536 * e.RawData(20)) _
            + ((256 * e.RawData(21)) _
            + e.RawData(22))))

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

    Private Sub XkGEN_1_DevicePlug(ByVal e As XkGEN.XKeyPlugEventArgs) Handles XkGEN_1.DevicePlug
        deviceStatus.Text = e.ProductString + " Plugged, Unit ID: " + e.UID.ToString() + ", OEM ID: " + e.OEMVersionID.ToString() + ", Product ID: " + e.PID.ToString()
        deviceStatus.ForeColor = Color.Green

        'Gets the Unit ID from the device
        lblUID.Text = "Unit ID: " + e.UID.ToString()

        'Gets the OEM Version ID from the device
        lblOEM.Text = "OEM ID: " + e.OEMVersionID.ToString()

        'Gets the Product ID from the device
        lblProductID.Text = "Product ID: " + e.PID.ToString()
        saveabsolutetime = -1
    End Sub

    Private Sub XkGEN_1_DeviceUnplug(ByVal e As XkGEN.XKeyPlugEventArgs) Handles XkGEN_1.DeviceUnplug
        deviceStatus.Text = e.ProductString + " Unplugged, Unit ID: " + e.UID.ToString() + ", OEM ID: " + e.OEMVersionID.ToString() + ", Product ID: " + e.PID.ToString()
        deviceStatus.ForeColor = Color.Red

        lblUID.Text = "Unit ID: "
        lblOEM.Text = "OEM ID: "
        lblProductID.Text = "Product ID: "
    End Sub

    Private Sub XkGEN_1_GenerateReportData(ByVal e As XkGEN.XKeyEventArgs) Handles XkGEN_1.GenerateReportData
        XkGEN_1_ButtonChange(e)
    End Sub

    Private Sub XkGEN_1_RawDataChange(ByVal e As XkGEN.XKeyRawDataArgs) Handles XkGEN_1.RawDataChange
        Dim output As String = ("Unit ID: " _
            + (e.UID.ToString + (", OEM ID: " _
            + (e.OEMVersionID.ToString + (", Product ID: " _
            + (e.PID.ToString + ", data="))))))
        Dim i As Integer = 0
        Do While (i < e.RawData.Length)
            output = (output _
                        + (BinToHex(CType(e.RawData(i), Byte)) + " "))
            i = (i + 1)
        Loop

        listBox1.Items.Add(output)
        listBox1.SelectedIndex = (listBox1.Items.Count - 1)
    End Sub

    Public Shared Function BinToHex(ByVal value As Byte) As String
        Dim sb As StringBuilder = New StringBuilder("")
        sb.Append(value.ToString("X2"))
        'the 2 means 2 digits
        Return sb.ToString
    End Function

End Class
