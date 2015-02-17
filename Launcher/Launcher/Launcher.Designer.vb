Imports Launcher.My.Resources

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLauncher
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
        Me.cmdLaunchGame = New System.Windows.Forms.Button()
        Me.cmdUpdate = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.cmdOptions = New System.Windows.Forms.Button()
        Me.cmdExtras = New System.Windows.Forms.Button()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdLaunchGame
        '
        Me.cmdLaunchGame.Enabled = False
        Me.cmdLaunchGame.Location = New System.Drawing.Point(12, 158)
        Me.cmdLaunchGame.Name = "cmdLaunchGame"
        Me.cmdLaunchGame.Size = New System.Drawing.Size(110, 37)
        Me.cmdLaunchGame.TabIndex = 1
        Me.cmdLaunchGame.Text = frmLauncher_launchGameButton_text
        Me.cmdLaunchGame.UseVisualStyleBackColor = True
        '
        'cmdUpdate
        '
        Me.cmdUpdate.Enabled = False
        Me.cmdUpdate.Location = New System.Drawing.Point(128, 158)
        Me.cmdUpdate.Name = "cmdUpdate"
        Me.cmdUpdate.Size = New System.Drawing.Size(110, 37)
        Me.cmdUpdate.TabIndex = 2
        Me.cmdUpdate.Text = frmLauncher_updateButton_text
        Me.cmdUpdate.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(12, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(458, 140)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox1.TabIndex = 3
        Me.PictureBox1.TabStop = False
        '
        'cmdOptions
        '
        Me.cmdOptions.Location = New System.Drawing.Point(244, 158)
        Me.cmdOptions.Name = "cmdOptions"
        Me.cmdOptions.Size = New System.Drawing.Size(110, 37)
        Me.cmdOptions.TabIndex = 5
        Me.cmdOptions.Text = frmLauncher_optionsButton_title
        Me.cmdOptions.UseVisualStyleBackColor = True
        '
        'cmdExtras
        '
        Me.cmdExtras.Location = New System.Drawing.Point(360, 158)
        Me.cmdExtras.Name = "cmdExtras"
        Me.cmdExtras.Size = New System.Drawing.Size(110, 37)
        Me.cmdExtras.TabIndex = 6
        Me.cmdExtras.Text = frmLauncher_extrasButton_text
        Me.cmdExtras.UseVisualStyleBackColor = True
        '
        'frmLauncher
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(482, 207)
        Me.Controls.Add(Me.cmdExtras)
        Me.Controls.Add(Me.cmdOptions)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.cmdUpdate)
        Me.Controls.Add(Me.cmdLaunchGame)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.Name = "frmLauncher"
        Me.Text = frmLauncher_title
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdLaunchGame As System.Windows.Forms.Button
    Friend WithEvents cmdUpdate As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents cmdOptions As System.Windows.Forms.Button
    Friend WithEvents cmdExtras As System.Windows.Forms.Button

End Class
