Public Class Form1
   
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If IsNothing(XkDMXT_1.ConnectedDevices) Then
            deviceStatus.Text = "No XC-DMX512T Connected"
            deviceStatus.ForeColor = Color.Red
        Else
            deviceStatus.Text = "XC-DMX512T Connected"
            deviceStatus.ForeColor = Color.Green

            'Gets the Unit ID from the device
            lblUID.Text = "Unit ID: " & XkDMXT_1.ConnectedDevices(0).UnitID.ToString()

            'Gets the OEM Version ID from the device
            lblOEM.Text = "OEM Version ID: " & XkDMXT_1.ConnectedDevices(0).OEMVersion.ToString()

            'Gets the Product ID from the device
            lblProductID.Text = "Product ID: " & XkDMXT_1.ConnectedDevices(0).Pid.ToString()
        End If

    End Sub

    Private Sub Xk12SI_1_ButtonChange(ByVal e As XkDMXT.XKeyEventArgs) Handles XkDMXT_1.ButtonChange
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
        lblUID.Text = "Unit ID: " + XkDMXT_1.ConnectedDevices(0).UnitID.ToString()
       

    End Sub


    Private Sub btnUID_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUID.Click
        Dim id As Integer = Convert.ToInt32(txtUID.Text)

        'Sets device Unit ID
        XkDMXT_1.SetDeviceUID(0, id)
        lblUID.Text = "Unit ID: " + XkDMXT_1.ConnectedDevices(0).UnitID.ToString()
    End Sub

    Private Sub btnOEM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOEM.Click
        Dim id = Convert.ToInt32(txtOEM.Text)

        'Sets device OEM Version ID
        XkDMXT_1.SetOEMVersionID(0, id, True)
    End Sub

    

    Private Sub btnKeyboard_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnKeyboard.Click
        If (XkDMXT_1.ConnectedDevices(0).KeyboardInterface = True) Then
            txtKeyboard.Focus()
            'Sends the letters 'a' 'b' and 'c'
            XkDMXT_1.SendKeystrokes(0, False, False, False, False, False, False, False, False, 4, 5, 6, 0, 0, 0)
            'Releases all sent keys
            XkDMXT_1.SendKeystrokes(0, False, False, False, False, False, False, False, False, 0, 0, 0, 0, 0, 0)
        Else
            MessageBox.Show("No joystick endpoint available, change to pid 1195")
        End If
    End Sub

    Private Sub btnSetDongle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetDongle.Click
        'Enter in 4 bytes. REMEMBER these 4 bytes they will be required to check the dongle
        Dim byte1 As Byte = Convert.ToByte(txtByte1.Text)
        Dim byte2 As Byte = Convert.ToByte(txtByte2.Text)
        Dim byte3 As Byte = Convert.ToByte(txtByte3.Text)
        Dim byte4 As Byte = Convert.ToByte(txtByte4.Text)

        XkDMXT_1.SetSecurityKey(0, byte1, byte2, byte3, byte4)
    End Sub

    Private Sub btnCheckDongle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCheckDongle.Click
        'Enter the 4 bytes used when XkDMXT_1.SetSecurityKey was called
        Dim byte1 As Byte = Convert.ToByte(txtByte1.Text)
        Dim byte2 As Byte = Convert.ToByte(txtByte2.Text)
        Dim byte3 As Byte = Convert.ToByte(txtByte3.Text)
        Dim byte4 As Byte = Convert.ToByte(txtByte4.Text)

        'Checks the security key by sending the selected bytes to the device; bytes were valid if it returns true
        Dim dongle As Boolean = XkDMXT_1.GetSecurityKey(0, byte1, byte2, byte3, byte4)

        If (dongle = True) Then
            grpDongle.BackColor = Color.Green
        ElseIf (dongle = False) Then
            grpDongle.BackColor = Color.Red
        End If
    End Sub

    Private Sub btnGenerate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerate.Click
        'Use this to get the state of the buttons even if there was no change in their states. This is often useful on start of application to get initial states of the buttons (switches).
        'Sending this command will trigger the _GenerateReportData event
        XkDMXT_1.GenerateReport(0)
    End Sub

    Private Sub btnFirmwareVersion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFirmwareVersion.Click
        lblFirmwareVersion.Text = XkDMXT_1.ConnectedDevices(0).FirmwareVersion.ToString()

    End Sub
    Private Sub XkDMXT_1_ButtonChange(ByVal e As XkDMXT.XKeyEventArgs) Handles XkDMXT_1.ButtonChange

    End Sub

    Private Sub XkDMXT_1_DevicePlug(ByVal e As XkDMXT.XKeyPlugEventArgs) Handles XkDMXT_1.DevicePlug
        deviceStatus.Text = "XC-DMX512T Plugged, Unit ID: " + e.UID.ToString() + ", OEM ID: " + e.OEMVersionID.ToString() + ", Product ID: " + e.PID.ToString()
        deviceStatus.ForeColor = Color.Green

        'Gets the Unit ID from the device
        lblUID.Text = "Unit ID: " + e.UID.ToString()

        'Gets the OEM Version ID from the device
        lblOEM.Text = "OEM ID: " + e.OEMVersionID.ToString()

        'Gets the Product ID from the device
        lblProductID.Text = "Product ID: " + e.PID.ToString()
    End Sub

    Private Sub XkDMXT_1_DeviceUnplug(ByVal e As XkDMXT.XKeyPlugEventArgs) Handles XkDMXT_1.DeviceUnplug
        deviceStatus.Text = "XC-DMX512T Unplugged, Unit ID: " + e.UID.ToString() + ", OEM ID: " + e.OEMVersionID.ToString() + ", Product ID: " + e.PID.ToString()
        deviceStatus.ForeColor = Color.Red

        lblUID.Text = "Unit ID: "
        lblOEM.Text = "OEM ID: "
        lblProductID.Text = "Product ID: "
    End Sub

    Private Sub XkDMXT_1_GenerateReportData(ByVal e As XkDMXT.XKeyEventArgs) Handles XkDMXT_1.GenerateReportData
        XkDMXT_1_ButtonChange(e)
    End Sub

    Private Sub btnSetSlots_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetSlots.Click
        XkDMXT_1.SetNumberOfSlots(0, Convert.ToInt32(txtMaxSlots.Text))

    End Sub

    Private Sub btnSetSlotVals_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetSlotVals.Click
        'example of setting all of the values of the slots
        Dim numberslots As Integer = XkDMXT_1.GetNumberOfSlots(0)
        For i As Integer = 0 To numberslots - 1
            'setting them all with a value of 128
            XkDMXT_1.SetSlotValue(0, i + 1, 128)
        Next
        'set the trackbar so it reflects the same value
        trackBar1.Value = XkDMXT_1.GetSlotValue(0, Convert.ToInt16(txtSlot.Text))
    End Sub

    Private Sub btnStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStart.Click
        If btnStart.Text = "Start" Then
            btnStart.Text = "Stop"
            XkDMXT_1.TransmitContinuous(0, True)
        Else
            btnStart.Text = "Start"
            XkDMXT_1.TransmitContinuous(0, False)
        End If
    End Sub

    Private Sub trackBar1_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles trackBar1.Scroll
        Dim slot As Integer = Convert.ToInt16(txtSlot.Text)
        Dim val As Byte = CByte(trackBar1.Value)
        lblSlotVal.Text = val.ToString()
        XkDMXT_1.SetSlotValue(0, slot, val)
    End Sub

    Private Sub btnTransmitOnce_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTransmitOnce.Click
        'sending only 3 channels for this example
        XkDMXT_1.SetNumberOfSlots(0, 3)
        XkDMXT_1.SetSlotValue(0, 1, 0)
        'slot 1 = 0
        XkDMXT_1.SetSlotValue(0, 2, 255)
        'slot 2 = 255
        XkDMXT_1.SetSlotValue(0, 3, 0)
        'slot 3 = 0
        XkDMXT_1.Transmit(0)
    End Sub

    Private Sub chkGreen_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkGreen.CheckedChanged
        If chkGreen.Checked = False Then
            XkDMXT_1.SetGreenIndicator(0, 0)
        Else
            XkDMXT_1.SetGreenIndicator(0, 1)
        End If
    End Sub
End Class
