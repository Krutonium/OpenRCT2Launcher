﻿Imports Launcher.My.Resources

Namespace OpenRCTdotNet

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    <Global.System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1726")> _
    Partial Class OpenRCTdotNetLogin
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
        Friend WithEvents UsernameLabel As System.Windows.Forms.Label
        Friend WithEvents PasswordLabel As System.Windows.Forms.Label
        Friend WithEvents UsernameTextBox As System.Windows.Forms.TextBox
        Friend WithEvents PasswordTextBox As System.Windows.Forms.TextBox
        Friend WithEvents OK As System.Windows.Forms.Button
        Friend WithEvents Cancel As System.Windows.Forms.Button

        'Required by the Windows Form Designer
        Private components As System.ComponentModel.IContainer

        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.
        <System.Diagnostics.DebuggerStepThrough()> _
        Private Sub InitializeComponent()
            Me.UsernameLabel = New System.Windows.Forms.Label()
            Me.PasswordLabel = New System.Windows.Forms.Label()
            Me.UsernameTextBox = New System.Windows.Forms.TextBox()
            Me.PasswordTextBox = New System.Windows.Forms.TextBox()
            Me.OK = New System.Windows.Forms.Button()
            Me.Cancel = New System.Windows.Forms.Button()
            Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
            Me.LogoPictureBox = New System.Windows.Forms.PictureBox()
            CType(Me.LogoPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'UsernameLabel
            '
            Me.UsernameLabel.Location = New System.Drawing.Point(167, 24)
            Me.UsernameLabel.Name = "UsernameLabel"
            Me.UsernameLabel.Size = New System.Drawing.Size(220, 23)
            Me.UsernameLabel.TabIndex = 0
            Me.UsernameLabel.Text = "User name"
            Me.UsernameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'PasswordLabel
            '
            Me.PasswordLabel.Location = New System.Drawing.Point(167, 67)
            Me.PasswordLabel.Name = "PasswordLabel"
            Me.PasswordLabel.Size = New System.Drawing.Size(220, 23)
            Me.PasswordLabel.TabIndex = 2
            Me.PasswordLabel.Text = "Password"
            Me.PasswordLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'UsernameTextBox
            '
            Me.UsernameTextBox.Location = New System.Drawing.Point(164, 44)
            Me.UsernameTextBox.Name = "UsernameTextBox"
            Me.UsernameTextBox.Size = New System.Drawing.Size(220, 20)
            Me.UsernameTextBox.TabIndex = 1
            '
            'PasswordTextBox
            '
            Me.PasswordTextBox.Location = New System.Drawing.Point(164, 93)
            Me.PasswordTextBox.Name = "PasswordTextBox"
            Me.PasswordTextBox.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
            Me.PasswordTextBox.Size = New System.Drawing.Size(220, 20)
            Me.PasswordTextBox.TabIndex = 3
            '
            'OK
            '
            Me.OK.Location = New System.Drawing.Point(164, 164)
            Me.OK.Name = "OK"
            Me.OK.Size = New System.Drawing.Size(140, 23)
            Me.OK.TabIndex = 4
            Me.OK.Text = Global.Launcher.My.Resources.Resources.coomon_login
            '
            'Cancel
            '
            Me.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Cancel.Location = New System.Drawing.Point(310, 164)
            Me.Cancel.Name = "Cancel"
            Me.Cancel.Size = New System.Drawing.Size(79, 23)
            Me.Cancel.TabIndex = 5
            Me.Cancel.Text = Global.Launcher.My.Resources.Resources.common_cancel
            '
            'LinkLabel1
            '
            Me.LinkLabel1.AutoSize = True
            Me.LinkLabel1.Location = New System.Drawing.Point(189, 129)
            Me.LinkLabel1.Name = "LinkLabel1"
            Me.LinkLabel1.Size = New System.Drawing.Size(170, 13)
            Me.LinkLabel1.TabIndex = 6
            Me.LinkLabel1.TabStop = True
            Me.LinkLabel1.Text = "Get your account at OpenRCT.net"
            '
            'LogoPictureBox
            '
            Me.LogoPictureBox.Image = Global.Launcher.My.Resources.Resources.login_screen
            Me.LogoPictureBox.Location = New System.Drawing.Point(0, 0)
            Me.LogoPictureBox.Name = "LogoPictureBox"
            Me.LogoPictureBox.Size = New System.Drawing.Size(150, 200)
            Me.LogoPictureBox.TabIndex = 0
            Me.LogoPictureBox.TabStop = False
            '
            'OpenRCTdotNetLogin
            '
            Me.AcceptButton = Me.OK
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.CancelButton = Me.Cancel
            Me.ClientSize = New System.Drawing.Size(401, 199)
            Me.Controls.Add(Me.LinkLabel1)
            Me.Controls.Add(Me.Cancel)
            Me.Controls.Add(Me.OK)
            Me.Controls.Add(Me.PasswordTextBox)
            Me.Controls.Add(Me.UsernameTextBox)
            Me.Controls.Add(Me.PasswordLabel)
            Me.Controls.Add(Me.UsernameLabel)
            Me.Controls.Add(Me.LogoPictureBox)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "OpenRCTdotNetLogin"
            Me.ShowInTaskbar = False
            Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "Login to OpenRCT.NET"
            CType(Me.LogoPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
        Friend WithEvents LogoPictureBox As System.Windows.Forms.PictureBox

    End Class
End Namespace