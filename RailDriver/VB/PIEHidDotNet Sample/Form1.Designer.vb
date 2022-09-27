<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.BtnCallback = New System.Windows.Forms.Button()
        Me.CboDevices = New System.Windows.Forms.ComboBox()
        Me.LblStatus = New System.Windows.Forms.Label()
        Me.BtnEnumerate = New System.Windows.Forms.Button()
        Me.label3 = New System.Windows.Forms.Label()
        Me.label2 = New System.Windows.Forms.Label()
        Me.label1 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.BtnWriteDisplay = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.label4 = New System.Windows.Forms.Label()
        Me.BtnSpeakerOff = New System.Windows.Forms.Button()
        Me.BtnSpeakerOn = New System.Windows.Forms.Button()
        Me.timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.Location = New System.Drawing.Point(9, 119)
        Me.ListBox1.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(451, 82)
        Me.ListBox1.TabIndex = 19
        '
        'BtnCallback
        '
        Me.BtnCallback.Location = New System.Drawing.Point(9, 93)
        Me.BtnCallback.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.BtnCallback.Name = "BtnCallback"
        Me.BtnCallback.Size = New System.Drawing.Size(56, 20)
        Me.BtnCallback.TabIndex = 18
        Me.BtnCallback.Text = "Callback"
        Me.BtnCallback.UseVisualStyleBackColor = True
        '
        'CboDevices
        '
        Me.CboDevices.FormattingEnabled = True
        Me.CboDevices.Location = New System.Drawing.Point(9, 43)
        Me.CboDevices.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.CboDevices.Name = "CboDevices"
        Me.CboDevices.Size = New System.Drawing.Size(336, 21)
        Me.CboDevices.TabIndex = 17
        '
        'LblStatus
        '
        Me.LblStatus.Location = New System.Drawing.Point(50, 332)
        Me.LblStatus.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LblStatus.Name = "LblStatus"
        Me.LblStatus.Size = New System.Drawing.Size(264, 19)
        Me.LblStatus.TabIndex = 16
        Me.LblStatus.Text = "No Device Enumerated"
        '
        'BtnEnumerate
        '
        Me.BtnEnumerate.Location = New System.Drawing.Point(9, 18)
        Me.BtnEnumerate.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.BtnEnumerate.Name = "BtnEnumerate"
        Me.BtnEnumerate.Size = New System.Drawing.Size(122, 20)
        Me.BtnEnumerate.TabIndex = 15
        Me.BtnEnumerate.Text = "Enumerate"
        Me.BtnEnumerate.UseVisualStyleBackColor = True
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Location = New System.Drawing.Point(7, 206)
        Me.label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(93, 13)
        Me.label3.TabIndex = 29
        Me.label3.Text = "3. Write to Display"
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(7, 77)
        Me.label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(186, 13)
        Me.label2.TabIndex = 28
        Me.label2.Text = "2. Set for data callback and read data"
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(7, 2)
        Me.label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(71, 13)
        Me.label1.TabIndex = 27
        Me.label1.Text = "1. Do this first"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 332)
        Me.Label5.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(40, 13)
        Me.Label5.TabIndex = 34
        Me.Label5.Text = "Status:"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(334, 93)
        Me.Button1.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(117, 20)
        Me.Button1.TabIndex = 36
        Me.Button1.Text = "Clear Listbox"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'BtnWriteDisplay
        '
        Me.BtnWriteDisplay.Location = New System.Drawing.Point(191, 222)
        Me.BtnWriteDisplay.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.BtnWriteDisplay.Name = "BtnWriteDisplay"
        Me.BtnWriteDisplay.Size = New System.Drawing.Size(100, 20)
        Me.BtnWriteDisplay.TabIndex = 37
        Me.BtnWriteDisplay.Text = "Write to Display"
        Me.BtnWriteDisplay.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(9, 223)
        Me.TextBox1.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(57, 20)
        Me.TextBox1.TabIndex = 38
        Me.TextBox1.Text = "110"
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(70, 223)
        Me.TextBox2.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(57, 20)
        Me.TextBox2.TabIndex = 39
        Me.TextBox2.Text = "121"
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(130, 223)
        Me.TextBox3.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(57, 20)
        Me.TextBox3.TabIndex = 40
        Me.TextBox3.Text = "118"
        '
        'label4
        '
        Me.label4.AutoSize = True
        Me.label4.Location = New System.Drawing.Point(7, 262)
        Me.label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(130, 13)
        Me.label4.TabIndex = 41
        Me.label4.Text = "4. Turn Speaker On or Off"
        '
        'BtnSpeakerOff
        '
        Me.BtnSpeakerOff.Location = New System.Drawing.Point(116, 279)
        Me.BtnSpeakerOff.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.BtnSpeakerOff.Name = "BtnSpeakerOff"
        Me.BtnSpeakerOff.Size = New System.Drawing.Size(103, 20)
        Me.BtnSpeakerOff.TabIndex = 43
        Me.BtnSpeakerOff.Text = "Speaker Off"
        Me.BtnSpeakerOff.UseVisualStyleBackColor = True
        '
        'BtnSpeakerOn
        '
        Me.BtnSpeakerOn.Location = New System.Drawing.Point(8, 279)
        Me.BtnSpeakerOn.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.BtnSpeakerOn.Name = "BtnSpeakerOn"
        Me.BtnSpeakerOn.Size = New System.Drawing.Size(103, 20)
        Me.BtnSpeakerOn.TabIndex = 42
        Me.BtnSpeakerOn.Text = "Speaker On"
        Me.BtnSpeakerOn.UseVisualStyleBackColor = True
        '
        'timer1
        '
        Me.timer1.Interval = 500
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(468, 356)
        Me.Controls.Add(Me.BtnSpeakerOff)
        Me.Controls.Add(Me.BtnSpeakerOn)
        Me.Controls.Add(Me.label4)
        Me.Controls.Add(Me.TextBox3)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.BtnWriteDisplay)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.label3)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.BtnCallback)
        Me.Controls.Add(Me.CboDevices)
        Me.Controls.Add(Me.LblStatus)
        Me.Controls.Add(Me.BtnEnumerate)
        Me.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Name = "Form1"
        Me.Text = "VB RailDriver Sample"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents BtnCallback As System.Windows.Forms.Button
    Friend WithEvents CboDevices As System.Windows.Forms.ComboBox
    Friend WithEvents LblStatus As System.Windows.Forms.Label
    Friend WithEvents BtnEnumerate As System.Windows.Forms.Button
    Private WithEvents label3 As System.Windows.Forms.Label
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents label1 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents BtnWriteDisplay As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Private WithEvents label4 As System.Windows.Forms.Label
    Private WithEvents BtnSpeakerOff As System.Windows.Forms.Button
    Private WithEvents BtnSpeakerOn As System.Windows.Forms.Button
    Private WithEvents timer1 As System.Windows.Forms.Timer

End Class
