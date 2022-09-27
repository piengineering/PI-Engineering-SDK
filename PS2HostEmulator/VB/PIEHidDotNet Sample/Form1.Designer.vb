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
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.BtnCallback = New System.Windows.Forms.Button()
        Me.CboDevices = New System.Windows.Forms.ComboBox()
        Me.LblStatus = New System.Windows.Forms.Label()
        Me.BtnEnumerate = New System.Windows.Forms.Button()
        Me.BtnDefault = New System.Windows.Forms.Button()
        Me.BtnSlow = New System.Windows.Forms.Button()
        Me.label3 = New System.Windows.Forms.Label()
        Me.label2 = New System.Windows.Forms.Label()
        Me.label1 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.VScrollBar1 = New System.Windows.Forms.VScrollBar()
        Me.LblMouse = New System.Windows.Forms.Label()
        Me.LblKeys = New System.Windows.Forms.Label()
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
        'BtnDefault
        '
        Me.BtnDefault.Location = New System.Drawing.Point(172, 293)
        Me.BtnDefault.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.BtnDefault.Name = "BtnDefault"
        Me.BtnDefault.Size = New System.Drawing.Size(153, 20)
        Me.BtnDefault.TabIndex = 21
        Me.BtnDefault.Text = "Default Mouse Message"
        Me.BtnDefault.UseVisualStyleBackColor = True
        '
        'BtnSlow
        '
        Me.BtnSlow.Location = New System.Drawing.Point(11, 293)
        Me.BtnSlow.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.BtnSlow.Name = "BtnSlow"
        Me.BtnSlow.Size = New System.Drawing.Size(156, 20)
        Me.BtnSlow.TabIndex = 20
        Me.BtnSlow.Text = "Slow Down Mouse Message"
        Me.BtnSlow.UseVisualStyleBackColor = True
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Location = New System.Drawing.Point(9, 277)
        Me.label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(157, 13)
        Me.label3.TabIndex = 29
        Me.label3.Text = "3. Adjust mouse message timing"
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
        'VScrollBar1
        '
        Me.VScrollBar1.Location = New System.Drawing.Point(251, 210)
        Me.VScrollBar1.Name = "VScrollBar1"
        Me.VScrollBar1.Size = New System.Drawing.Size(20, 65)
        Me.VScrollBar1.TabIndex = 42
        '
        'LblMouse
        '
        Me.LblMouse.AutoSize = True
        Me.LblMouse.Location = New System.Drawing.Point(9, 242)
        Me.LblMouse.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LblMouse.Name = "LblMouse"
        Me.LblMouse.Size = New System.Drawing.Size(39, 13)
        Me.LblMouse.TabIndex = 44
        Me.LblMouse.Text = "Mouse"
        '
        'LblKeys
        '
        Me.LblKeys.AutoSize = True
        Me.LblKeys.Location = New System.Drawing.Point(9, 210)
        Me.LblKeys.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LblKeys.Name = "LblKeys"
        Me.LblKeys.Size = New System.Drawing.Size(30, 13)
        Me.LblKeys.TabIndex = 43
        Me.LblKeys.Text = "Keys"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(468, 356)
        Me.Controls.Add(Me.LblMouse)
        Me.Controls.Add(Me.LblKeys)
        Me.Controls.Add(Me.VScrollBar1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.label3)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.BtnDefault)
        Me.Controls.Add(Me.BtnSlow)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.BtnCallback)
        Me.Controls.Add(Me.CboDevices)
        Me.Controls.Add(Me.LblStatus)
        Me.Controls.Add(Me.BtnEnumerate)
        Me.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Name = "Form1"
        Me.Text = "VB PS2 Host Emulator Sample"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents BtnCallback As System.Windows.Forms.Button
    Friend WithEvents CboDevices As System.Windows.Forms.ComboBox
    Friend WithEvents LblStatus As System.Windows.Forms.Label
    Friend WithEvents BtnEnumerate As System.Windows.Forms.Button
    Friend WithEvents BtnDefault As System.Windows.Forms.Button
    Friend WithEvents BtnSlow As System.Windows.Forms.Button
    Private WithEvents label3 As System.Windows.Forms.Label
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents label1 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents VScrollBar1 As System.Windows.Forms.VScrollBar
    Friend WithEvents LblMouse As System.Windows.Forms.Label
    Friend WithEvents LblKeys As System.Windows.Forms.Label

End Class
