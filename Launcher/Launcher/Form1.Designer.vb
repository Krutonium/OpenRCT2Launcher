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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLauncher))
        Me.tmrCheckIfDone = New System.Windows.Forms.Timer(Me.components)
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.cmdLaunchGame = New System.Windows.Forms.Button()
        Me.cmdForceUpdate = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.chkVerbose = New System.Windows.Forms.CheckBox()
        Me.cmdExtras = New System.Windows.Forms.Button()
        Me.chkLogToFile = New System.Windows.Forms.CheckBox()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tmrCheckIfDone
        '
        Me.tmrCheckIfDone.Enabled = True
        '
        'lblStatus
        '
        resources.ApplyResources(Me.lblStatus, "lblStatus")
        Me.lblStatus.Name = "lblStatus"
        '
        'cmdLaunchGame
        '
        resources.ApplyResources(Me.cmdLaunchGame, "cmdLaunchGame")
        Me.cmdLaunchGame.Name = "cmdLaunchGame"
        Me.cmdLaunchGame.UseVisualStyleBackColor = True
        '
        'cmdForceUpdate
        '
        resources.ApplyResources(Me.cmdForceUpdate, "cmdForceUpdate")
        Me.cmdForceUpdate.Name = "cmdForceUpdate"
        Me.cmdForceUpdate.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        resources.ApplyResources(Me.PictureBox1, "PictureBox1")
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.TabStop = False
        '
        'chkVerbose
        '
        resources.ApplyResources(Me.chkVerbose, "chkVerbose")
        Me.chkVerbose.Name = "chkVerbose"
        Me.chkVerbose.UseVisualStyleBackColor = True
        '
        'cmdExtras
        '
        resources.ApplyResources(Me.cmdExtras, "cmdExtras")
        Me.cmdExtras.Name = "cmdExtras"
        Me.cmdExtras.UseVisualStyleBackColor = True
        '
        'chkLogToFile
        '
        resources.ApplyResources(Me.chkLogToFile, "chkLogToFile")
        Me.chkLogToFile.Name = "chkLogToFile"
        Me.chkLogToFile.UseVisualStyleBackColor = True
        '
        'frmLauncher
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.chkLogToFile)
        Me.Controls.Add(Me.cmdExtras)
        Me.Controls.Add(Me.chkVerbose)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.cmdForceUpdate)
        Me.Controls.Add(Me.cmdLaunchGame)
        Me.Controls.Add(Me.lblStatus)
        Me.Name = "frmLauncher"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tmrCheckIfDone As System.Windows.Forms.Timer
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents cmdLaunchGame As System.Windows.Forms.Button
    Friend WithEvents cmdForceUpdate As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents chkVerbose As System.Windows.Forms.CheckBox
    Friend WithEvents cmdExtras As System.Windows.Forms.Button
    Friend WithEvents chkLogToFile As System.Windows.Forms.CheckBox

End Class
