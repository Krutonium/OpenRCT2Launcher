<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Extras
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
        Me.cmdCSS17 = New System.Windows.Forms.Button()
        Me.OFD1 = New System.Windows.Forms.OpenFileDialog()
        Me.cmdCSS17File = New System.Windows.Forms.Button()
        Me.cmdDebug = New System.Windows.Forms.Button()
        Me.cmdDropboxSync = New System.Windows.Forms.Button()
        Me.cmdSyncAnyFolder = New System.Windows.Forms.Button()
        Me.FBD = New System.Windows.Forms.FolderBrowserDialog()
        Me.SuspendLayout()
        '
        'cmdCSS17
        '
        Me.cmdCSS17.Location = New System.Drawing.Point(12, 12)
        Me.cmdCSS17.Name = "cmdCSS17"
        Me.cmdCSS17.Size = New System.Drawing.Size(165, 23)
        Me.cmdCSS17.TabIndex = 0
        Me.cmdCSS17.Text = "Add RCT 1 Title Music"
        Me.cmdCSS17.UseVisualStyleBackColor = True
        '
        'cmdCSS17File
        '
        Me.cmdCSS17File.Location = New System.Drawing.Point(183, 12)
        Me.cmdCSS17File.Name = "cmdCSS17File"
        Me.cmdCSS17File.Size = New System.Drawing.Size(165, 23)
        Me.cmdCSS17File.TabIndex = 1
        Me.cmdCSS17File.Text = "Add RCT1 Title Music from File"
        Me.cmdCSS17File.UseVisualStyleBackColor = True
        '
        'cmdDebug
        '
        Me.cmdDebug.Location = New System.Drawing.Point(12, 176)
        Me.cmdDebug.Name = "cmdDebug"
        Me.cmdDebug.Size = New System.Drawing.Size(165, 23)
        Me.cmdDebug.TabIndex = 2
        Me.cmdDebug.Text = "Show File Locations (Debug)"
        Me.cmdDebug.UseVisualStyleBackColor = True
        '
        'cmdDropboxSync
        '
        Me.cmdDropboxSync.Location = New System.Drawing.Point(12, 41)
        Me.cmdDropboxSync.Name = "cmdDropboxSync"
        Me.cmdDropboxSync.Size = New System.Drawing.Size(165, 23)
        Me.cmdDropboxSync.TabIndex = 3
        Me.cmdDropboxSync.Text = "Sync Saves to Dropbox"
        Me.cmdDropboxSync.UseVisualStyleBackColor = True
        '
        'cmdSyncAnyFolder
        '
        Me.cmdSyncAnyFolder.Location = New System.Drawing.Point(183, 41)
        Me.cmdSyncAnyFolder.Name = "cmdSyncAnyFolder"
        Me.cmdSyncAnyFolder.Size = New System.Drawing.Size(165, 23)
        Me.cmdSyncAnyFolder.TabIndex = 4
        Me.cmdSyncAnyFolder.Text = "Sync Saves to Any Folder"
        Me.cmdSyncAnyFolder.UseVisualStyleBackColor = True
        '
        'Extras
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(434, 211)
        Me.Controls.Add(Me.cmdSyncAnyFolder)
        Me.Controls.Add(Me.cmdDropboxSync)
        Me.Controls.Add(Me.cmdDebug)
        Me.Controls.Add(Me.cmdCSS17File)
        Me.Controls.Add(Me.cmdCSS17)
        Me.Name = "Extras"
        Me.Text = "Extras"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdCSS17 As System.Windows.Forms.Button
    Friend WithEvents OFD1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents cmdCSS17File As System.Windows.Forms.Button
    Friend WithEvents cmdDebug As System.Windows.Forms.Button
    Friend WithEvents cmdDropboxSync As System.Windows.Forms.Button
    Friend WithEvents cmdSyncAnyFolder As System.Windows.Forms.Button
    Friend WithEvents FBD As System.Windows.Forms.FolderBrowserDialog
End Class
