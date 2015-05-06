Imports Launcher.My.Resources

Namespace OpenRCTdotNet

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class OpenRCTdotNetConfigure
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
            Me.ChkUploadTime = New System.Windows.Forms.CheckBox()
            Me.chkUploadSaves = New System.Windows.Forms.CheckBox()
            Me.lblUsername = New System.Windows.Forms.Label()
            Me.lblWarning = New System.Windows.Forms.Label()
            Me.LogoPictureBox = New System.Windows.Forms.PictureBox()
            CType(Me.LogoPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'ChkUploadTime
            '
            Me.ChkUploadTime.AutoSize = True
            Me.ChkUploadTime.Location = New System.Drawing.Point(155, 36)
            Me.ChkUploadTime.Name = "ChkUploadTime"
            Me.ChkUploadTime.Size = New System.Drawing.Size(150, 17)
            Me.ChkUploadTime.TabIndex = 0
            Me.ChkUploadTime.Text = Global.Launcher.My.Resources.Resources.OpenRCTdotNetConfigure_uploadPlayTime_label
            Me.ChkUploadTime.UseVisualStyleBackColor = True
            '
            'chkUploadSaves
            '
            Me.chkUploadSaves.AutoSize = True
            Me.chkUploadSaves.Location = New System.Drawing.Point(155, 59)
            Me.chkUploadSaves.Name = "chkUploadSaves"
            Me.chkUploadSaves.Size = New System.Drawing.Size(139, 17)
            Me.chkUploadSaves.TabIndex = 1
            Me.chkUploadSaves.Text = Global.Launcher.My.Resources.Resources.OpenRCTdotNetConfigure_uploadSaves_label
            Me.chkUploadSaves.UseVisualStyleBackColor = True
            '
            'lblUsername
            '
            Me.lblUsername.AutoSize = True
            Me.lblUsername.Location = New System.Drawing.Point(155, 17)
            Me.lblUsername.Name = "lblUsername"
            Me.lblUsername.Size = New System.Drawing.Size(0, 13)
            Me.lblUsername.TabIndex = 2
            '
            'lblWarning
            '
            Me.lblWarning.AutoSize = True
            Me.lblWarning.Location = New System.Drawing.Point(155, 79)
            Me.lblWarning.Name = "lblWarning"
            Me.lblWarning.Size = New System.Drawing.Size(0, 13)
            Me.lblWarning.TabIndex = 3
            '
            'LogoPictureBox
            '
            Me.LogoPictureBox.Image = Global.Launcher.My.Resources.Resources.logo_icon
            Me.LogoPictureBox.Location = New System.Drawing.Point(12, 12)
            Me.LogoPictureBox.Name = "LogoPictureBox"
            Me.LogoPictureBox.Size = New System.Drawing.Size(128, 128)
            Me.LogoPictureBox.TabIndex = 4
            Me.LogoPictureBox.TabStop = False
            '
            'OpenRCTdotNetConfigure
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(438, 154)
            Me.Controls.Add(Me.LogoPictureBox)
            Me.Controls.Add(Me.lblWarning)
            Me.Controls.Add(Me.lblUsername)
            Me.Controls.Add(Me.chkUploadSaves)
            Me.Controls.Add(Me.ChkUploadTime)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
            Me.Name = "OpenRCTdotNetConfigure"
            Me.ShowInTaskbar = False
            Me.Text = "OpenRCT.net Configuration"
            CType(Me.LogoPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents ChkUploadTime As System.Windows.Forms.CheckBox
        Friend WithEvents chkUploadSaves As System.Windows.Forms.CheckBox
        Friend WithEvents lblUsername As System.Windows.Forms.Label
        Friend WithEvents lblWarning As System.Windows.Forms.Label
        Friend WithEvents LogoPictureBox As System.Windows.Forms.PictureBox
    End Class
End Namespace