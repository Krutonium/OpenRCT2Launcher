﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OpenRCTdotNetStoreBrowser
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
        Me.WebBrowser1 = New System.Windows.Forms.WebBrowser()
        Me.ssStrip = New System.Windows.Forms.StatusStrip()
        Me.tsslState = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ssStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'WebBrowser1
        '
        Me.WebBrowser1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.WebBrowser1.Location = New System.Drawing.Point(0, 0)
        Me.WebBrowser1.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WebBrowser1.Name = "WebBrowser1"
        Me.WebBrowser1.Size = New System.Drawing.Size(1009, 559)
        Me.WebBrowser1.TabIndex = 0
        Me.WebBrowser1.Url = New System.Uri("https://openrct.net/store.php", System.UriKind.Absolute)
        '
        'ssStrip
        '
        Me.ssStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsslState})
        Me.ssStrip.Location = New System.Drawing.Point(0, 537)
        Me.ssStrip.Name = "ssStrip"
        Me.ssStrip.Size = New System.Drawing.Size(1009, 22)
        Me.ssStrip.TabIndex = 1
        Me.ssStrip.Text = "StatusStrip1"
        '
        'tsslState
        '
        Me.tsslState.Name = "tsslState"
        Me.tsslState.Size = New System.Drawing.Size(0, 17)
        '
        'OpenRCTdotNetStoreBrowser
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1009, 559)
        Me.Controls.Add(Me.ssStrip)
        Me.Controls.Add(Me.WebBrowser1)
        Me.Name = "OpenRCTdotNetStoreBrowser"
        Me.Text = "OpenRCTdotNetStoreBrowser"
        Me.ssStrip.ResumeLayout(False)
        Me.ssStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents WebBrowser1 As System.Windows.Forms.WebBrowser
    Friend WithEvents ssStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents tsslState As System.Windows.Forms.ToolStripStatusLabel
End Class
