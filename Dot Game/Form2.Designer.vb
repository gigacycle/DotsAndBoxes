<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ftmSettings
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.txtY = New System.Windows.Forms.NumericUpDown
        Me.txtX = New System.Windows.Forms.NumericUpDown
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.Panel1.SuspendLayout()
        CType(Me.txtY, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtX, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.txtY)
        Me.Panel1.Controls.Add(Me.txtX)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(12, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(236, 88)
        Me.Panel1.TabIndex = 1
        '
        'txtY
        '
        Me.txtY.Location = New System.Drawing.Point(162, 48)
        Me.txtY.Maximum = New Decimal(New Integer() {13, 0, 0, 0})
        Me.txtY.Minimum = New Decimal(New Integer() {2, 0, 0, 0})
        Me.txtY.Name = "txtY"
        Me.txtY.Size = New System.Drawing.Size(43, 20)
        Me.txtY.TabIndex = 5
        Me.txtY.Value = New Decimal(New Integer() {10, 0, 0, 0})
        '
        'txtX
        '
        Me.txtX.Location = New System.Drawing.Point(162, 22)
        Me.txtX.Maximum = New Decimal(New Integer() {20, 0, 0, 0})
        Me.txtX.Minimum = New Decimal(New Integer() {2, 0, 0, 0})
        Me.txtX.Name = "txtX"
        Me.txtX.Size = New System.Drawing.Size(43, 20)
        Me.txtX.TabIndex = 3
        Me.txtX.Value = New Decimal(New Integer() {10, 0, 0, 0})
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(34, 50)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(122, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Number of Vertical Dots:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(22, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(134, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Number of Horizontal Dots:"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(87, 114)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(85, 23)
        Me.Button1.TabIndex = 6
        Me.Button1.Text = "&OK"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'ftmSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(260, 149)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "ftmSettings"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Game Settings"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.txtY, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtX, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents txtY As System.Windows.Forms.NumericUpDown
    Friend WithEvents txtX As System.Windows.Forms.NumericUpDown
End Class
