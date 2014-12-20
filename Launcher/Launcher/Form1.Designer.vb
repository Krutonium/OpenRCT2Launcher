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
        Me.components = New System.ComponentModel.Container()
        Me.tmrCheckIfDone = New System.Windows.Forms.Timer(Me.components)
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.cmdLaunchGame = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'tmrCheckIfDone
        '
        Me.tmrCheckIfDone.Enabled = True
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Location = New System.Drawing.Point(12, 9)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(158, 13)
        Me.lblStatus.TabIndex = 0
        Me.lblStatus.Text = "Checking if you are up to date..."
        '
        'cmdLaunchGame
        '
        Me.cmdLaunchGame.Location = New System.Drawing.Point(15, 50)
        Me.cmdLaunchGame.Name = "cmdLaunchGame"
        Me.cmdLaunchGame.Size = New System.Drawing.Size(157, 59)
        Me.cmdLaunchGame.TabIndex = 1
        Me.cmdLaunchGame.Text = "Launch OpenRCT2"
        Me.cmdLaunchGame.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(226, 127)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(156, 92)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "TestUpdate"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'frmLauncher
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(484, 261)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.cmdLaunchGame)
        Me.Controls.Add(Me.lblStatus)
        Me.Name = "frmLauncher"
        Me.Text = "OpenRCT2 Launcher"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tmrCheckIfDone As System.Windows.Forms.Timer
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents cmdLaunchGame As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button

End Class
