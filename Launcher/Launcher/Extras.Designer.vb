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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Extras))
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
        resources.ApplyResources(Me.cmdCSS17, "cmdCSS17")
        Me.cmdCSS17.Name = "cmdCSS17"
        Me.cmdCSS17.UseVisualStyleBackColor = True
        '
        'OFD1
        '
        resources.ApplyResources(Me.OFD1, "OFD1")
        '
        'cmdCSS17File
        '
        resources.ApplyResources(Me.cmdCSS17File, "cmdCSS17File")
        Me.cmdCSS17File.Name = "cmdCSS17File"
        Me.cmdCSS17File.UseVisualStyleBackColor = True
        '
        'cmdDebug
        '
        resources.ApplyResources(Me.cmdDebug, "cmdDebug")
        Me.cmdDebug.Name = "cmdDebug"
        Me.cmdDebug.UseVisualStyleBackColor = True
        '
        'cmdDropboxSync
        '
        resources.ApplyResources(Me.cmdDropboxSync, "cmdDropboxSync")
        Me.cmdDropboxSync.Name = "cmdDropboxSync"
        Me.cmdDropboxSync.UseVisualStyleBackColor = True
        '
        'cmdSyncAnyFolder
        '
        resources.ApplyResources(Me.cmdSyncAnyFolder, "cmdSyncAnyFolder")
        Me.cmdSyncAnyFolder.Name = "cmdSyncAnyFolder"
        Me.cmdSyncAnyFolder.UseVisualStyleBackColor = True
        '
        'FBD
        '
        resources.ApplyResources(Me.FBD, "FBD")
        '
        'Extras
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.cmdSyncAnyFolder)
        Me.Controls.Add(Me.cmdDropboxSync)
        Me.Controls.Add(Me.cmdDebug)
        Me.Controls.Add(Me.cmdCSS17File)
        Me.Controls.Add(Me.cmdCSS17)
        Me.Name = "Extras"
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
