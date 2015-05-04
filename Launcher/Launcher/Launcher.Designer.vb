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
        Me.cmdOptions = New System.Windows.Forms.Button()
        Me.cmdExtras = New System.Windows.Forms.Button()
        Me.wbSlideshow = New System.Windows.Forms.WebBrowser()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdLaunchGame
        '
        Me.cmdLaunchGame.Enabled = False
        Me.cmdLaunchGame.Location = New System.Drawing.Point(12, 258)
        Me.cmdLaunchGame.Name = "cmdLaunchGame"
        Me.cmdLaunchGame.Size = New System.Drawing.Size(155, 37)
        Me.cmdLaunchGame.TabIndex = 0
        Me.cmdLaunchGame.Text = Global.Launcher.My.Resources.Resources.frmLauncher_launchGameButton_text
        Me.cmdLaunchGame.UseVisualStyleBackColor = True
        '
        'cmdUpdate
        '
        Me.cmdUpdate.Location = New System.Drawing.Point(173, 258)
        Me.cmdUpdate.Name = "cmdUpdate"
        Me.cmdUpdate.Size = New System.Drawing.Size(87, 37)
        Me.cmdUpdate.TabIndex = 1
        Me.cmdUpdate.Text = Global.Launcher.My.Resources.Resources.frmLauncher_updateButton_text
        Me.cmdUpdate.UseVisualStyleBackColor = True
        '
        'cmdOptions
        '
        Me.cmdOptions.Location = New System.Drawing.Point(266, 258)
        Me.cmdOptions.Name = "cmdOptions"
        Me.cmdOptions.Size = New System.Drawing.Size(87, 37)
        Me.cmdOptions.TabIndex = 2
        Me.cmdOptions.Text = Global.Launcher.My.Resources.Resources.frmLauncher_optionsButton_title
        Me.cmdOptions.UseVisualStyleBackColor = True
        '
        'cmdExtras
        '
        Me.cmdExtras.Location = New System.Drawing.Point(359, 258)
        Me.cmdExtras.Name = "cmdExtras"
        Me.cmdExtras.Size = New System.Drawing.Size(87, 37)
        Me.cmdExtras.TabIndex = 3
        Me.cmdExtras.Text = Global.Launcher.My.Resources.Resources.frmLauncher_extrasButton_text
        Me.cmdExtras.UseVisualStyleBackColor = True
        '
        'wbSlideshow
        '
        Me.wbSlideshow.AllowWebBrowserDrop = False
        Me.wbSlideshow.IsWebBrowserContextMenuEnabled = False
        Me.wbSlideshow.Location = New System.Drawing.Point(0, 0)
        Me.wbSlideshow.MinimumSize = New System.Drawing.Size(20, 20)
        Me.wbSlideshow.Name = "wbSlideshow"
        Me.wbSlideshow.ScriptErrorsSuppressed = True
        Me.wbSlideshow.ScrollBarsEnabled = False
        Me.wbSlideshow.Size = New System.Drawing.Size(458, 240)
        Me.wbSlideshow.TabIndex = 5
        Me.wbSlideshow.TabStop = False
        Me.wbSlideshow.Url = New System.Uri("https://openrct.net/inLauncher/launcher.html", System.UriKind.Absolute)
        Me.wbSlideshow.WebBrowserShortcutsEnabled = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Launcher.My.Resources.Resources.offline
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(458, 240)
        Me.PictureBox1.TabIndex = 6
        Me.PictureBox1.TabStop = False
        '
        'frmLauncher
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(458, 307)
        Me.Controls.Add(Me.cmdExtras)
        Me.Controls.Add(Me.cmdOptions)
        Me.Controls.Add(Me.cmdUpdate)
        Me.Controls.Add(Me.cmdLaunchGame)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.wbSlideshow)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmLauncher"
        Me.Text = "OpenRCT2 Launcher"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdLaunchGame As System.Windows.Forms.Button
    Friend WithEvents cmdUpdate As System.Windows.Forms.Button
    Friend WithEvents cmdOptions As System.Windows.Forms.Button
    Friend WithEvents cmdExtras As System.Windows.Forms.Button
    Friend WithEvents wbSlideshow As System.Windows.Forms.WebBrowser
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox

End Class
