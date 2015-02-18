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
        Me.SuspendLayout()
        '
        'ChkUploadTime
        '
        Me.ChkUploadTime.AutoSize = True
        Me.ChkUploadTime.Location = New System.Drawing.Point(12, 12)
        Me.ChkUploadTime.Name = "ChkUploadTime"
        Me.ChkUploadTime.Size = New System.Drawing.Size(150, 17)
        Me.ChkUploadTime.TabIndex = 0
        Me.ChkUploadTime.Text = "Upload play time to Server"
        Me.ChkUploadTime.UseVisualStyleBackColor = True
        '
        'chkUploadSaves
        '
        Me.chkUploadSaves.AutoSize = True
        Me.chkUploadSaves.Enabled = False
        Me.chkUploadSaves.Location = New System.Drawing.Point(12, 35)
        Me.chkUploadSaves.Name = "chkUploadSaves"
        Me.chkUploadSaves.Size = New System.Drawing.Size(139, 17)
        Me.chkUploadSaves.TabIndex = 1
        Me.chkUploadSaves.Text = "Upload Saves to Server"
        Me.chkUploadSaves.UseVisualStyleBackColor = True
        '
        'OpenRCTdotNetConfigure
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(371, 226)
        Me.Controls.Add(Me.chkUploadSaves)
        Me.Controls.Add(Me.ChkUploadTime)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Name = "OpenRCTdotNetConfigure"
        Me.Text = "OpenRCT.net Configuration"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ChkUploadTime As System.Windows.Forms.CheckBox
    Friend WithEvents chkUploadSaves As System.Windows.Forms.CheckBox
End Class
