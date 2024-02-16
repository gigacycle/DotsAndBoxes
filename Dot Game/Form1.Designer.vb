<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.GameZone = New System.Windows.Forms.PictureBox()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.btnReset = New System.Windows.Forms.Button()
        Me.Tmr = New System.Windows.Forms.Timer(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.imgList = New System.Windows.Forms.ImageList(Me.components)
        Me.btnAbout = New System.Windows.Forms.Button()
        Me.CIcon = New System.Windows.Forms.PictureBox()
        Me.PIcon = New System.Windows.Forms.PictureBox()
        Me.CScores = New System.Windows.Forms.Label()
        Me.PScores = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnSetting = New System.Windows.Forms.Button()
        CType(Me.GameZone, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CIcon, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PIcon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GameZone
        '
        Me.GameZone.BackColor = System.Drawing.Color.White
        Me.GameZone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GameZone.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.GameZone.Location = New System.Drawing.Point(12, 32)
        Me.GameZone.Name = "GameZone"
        Me.GameZone.Size = New System.Drawing.Size(335, 225)
        Me.GameZone.TabIndex = 0
        Me.GameZone.TabStop = False
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(12, 263)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(79, 29)
        Me.btnExit.TabIndex = 1
        Me.btnExit.Text = "E&xit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'btnReset
        '
        Me.btnReset.Location = New System.Drawing.Point(267, 263)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(80, 29)
        Me.btnReset.TabIndex = 2
        Me.btnReset.Text = "&Reset"
        Me.btnReset.UseVisualStyleBackColor = True
        '
        'Tmr
        '
        Me.Tmr.Enabled = True
        Me.Tmr.Interval = 200
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(163, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(0, 13)
        Me.Label1.TabIndex = 3
        '
        'imgList
        '
        Me.imgList.ImageStream = CType(resources.GetObject("imgList.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgList.TransparentColor = System.Drawing.Color.Transparent
        Me.imgList.Images.SetKeyName(0, "Blank Badge Green.ico")
        Me.imgList.Images.SetKeyName(1, "Blank Disc Red.ico")
        Me.imgList.Images.SetKeyName(2, "1.bmp")
        '
        'btnAbout
        '
        Me.btnAbout.Location = New System.Drawing.Point(97, 263)
        Me.btnAbout.Name = "btnAbout"
        Me.btnAbout.Size = New System.Drawing.Size(79, 29)
        Me.btnAbout.TabIndex = 5
        Me.btnAbout.Text = "A&bout"
        Me.btnAbout.UseVisualStyleBackColor = True
        '
        'CIcon
        '
        Me.CIcon.Location = New System.Drawing.Point(12, 6)
        Me.CIcon.Name = "CIcon"
        Me.CIcon.Size = New System.Drawing.Size(18, 20)
        Me.CIcon.TabIndex = 6
        Me.CIcon.TabStop = False
        '
        'PIcon
        '
        Me.PIcon.Location = New System.Drawing.Point(329, 6)
        Me.PIcon.Name = "PIcon"
        Me.PIcon.Size = New System.Drawing.Size(18, 20)
        Me.PIcon.TabIndex = 7
        Me.PIcon.TabStop = False
        '
        'CScores
        '
        Me.CScores.AutoSize = True
        Me.CScores.Location = New System.Drawing.Point(97, 10)
        Me.CScores.Name = "CScores"
        Me.CScores.Size = New System.Drawing.Size(0, 13)
        Me.CScores.TabIndex = 8
        Me.CScores.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PScores
        '
        Me.PScores.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PScores.Location = New System.Drawing.Point(239, 10)
        Me.PScores.Name = "PScores"
        Me.PScores.Size = New System.Drawing.Size(49, 13)
        Me.PScores.TabIndex = 9
        Me.PScores.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(36, 10)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 13)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Computer:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(294, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(29, 13)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = ":You"
        '
        'btnSetting
        '
        Me.btnSetting.Location = New System.Drawing.Point(182, 263)
        Me.btnSetting.Name = "btnSetting"
        Me.btnSetting.Size = New System.Drawing.Size(79, 29)
        Me.btnSetting.TabIndex = 12
        Me.btnSetting.Text = "&Setting"
        Me.btnSetting.UseVisualStyleBackColor = True
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(359, 301)
        Me.Controls.Add(Me.btnSetting)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.PScores)
        Me.Controls.Add(Me.CScores)
        Me.Controls.Add(Me.PIcon)
        Me.Controls.Add(Me.CIcon)
        Me.Controls.Add(Me.btnAbout)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnReset)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.GameZone)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Dots And Boxes"
        CType(Me.GameZone, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CIcon, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PIcon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GameZone As System.Windows.Forms.PictureBox
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents btnReset As System.Windows.Forms.Button
    Friend WithEvents Tmr As System.Windows.Forms.Timer
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents imgList As System.Windows.Forms.ImageList
    Friend WithEvents btnAbout As System.Windows.Forms.Button
    Friend WithEvents CIcon As System.Windows.Forms.PictureBox
    Friend WithEvents PIcon As System.Windows.Forms.PictureBox
    Friend WithEvents CScores As System.Windows.Forms.Label
    Friend WithEvents PScores As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnSetting As System.Windows.Forms.Button

End Class
