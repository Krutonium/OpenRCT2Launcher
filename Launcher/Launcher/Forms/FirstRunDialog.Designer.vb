<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FirstRunDialog
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.StableButton = New System.Windows.Forms.Button()
        Me.DevelopmentButton = New System.Windows.Forms.Button()
        Me.FirstRun_label = New System.Windows.Forms.Label()
        Me.FirstRun_pictureBox = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.FirstRun_pictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.AutoSize = True
        Me.TableLayoutPanel1.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.StableButton, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.DevelopmentButton, 1, 0)
        Me.TableLayoutPanel1.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(8, 128)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(462, 29)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'StableButton
        '
        Me.StableButton.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.StableButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.StableButton.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.StableButton.Location = New System.Drawing.Point(4, 3)
        Me.StableButton.Name = "StableButton"
        Me.StableButton.Size = New System.Drawing.Size(223, 23)
        Me.StableButton.TabIndex = 0
        Me.StableButton.Text = Global.Launcher.My.Resources.Resources.frmFirstRunDialog_StableButton
        '
        'DevelopmentButton
        '
        Me.DevelopmentButton.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.DevelopmentButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.DevelopmentButton.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.DevelopmentButton.Location = New System.Drawing.Point(235, 3)
        Me.DevelopmentButton.Name = "DevelopmentButton"
        Me.DevelopmentButton.Size = New System.Drawing.Size(223, 23)
        Me.DevelopmentButton.TabIndex = 1
        Me.DevelopmentButton.Text = Global.Launcher.My.Resources.Resources.frmFirstRunDialog_DevelopmentButton
        '
        'FirstRun_label
        '
        Me.FirstRun_label.AutoSize = True
        Me.FirstRun_label.Location = New System.Drawing.Point(99, 29)
        Me.FirstRun_label.MaximumSize = New System.Drawing.Size(350, 58)
        Me.FirstRun_label.Name = "FirstRun_label"
        Me.FirstRun_label.Size = New System.Drawing.Size(350, 26)
        Me.FirstRun_label.TabIndex = 1
        Me.FirstRun_label.Text = Global.Launcher.My.Resources.Resources.frmFirstRunDialog_stableOrDevFirstRun_text
        '
        'FirstRun_pictureBox
        '
        Me.FirstRun_pictureBox.Image = Global.Launcher.My.Resources.Resources.Icon_64_
        Me.FirstRun_pictureBox.Location = New System.Drawing.Point(26, 26)
        Me.FirstRun_pictureBox.Name = "FirstRun_pictureBox"
        Me.FirstRun_pictureBox.Size = New System.Drawing.Size(64, 64)
        Me.FirstRun_pictureBox.TabIndex = 2
        Me.FirstRun_pictureBox.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox2.BackColor = System.Drawing.SystemColors.Control
        Me.PictureBox2.Location = New System.Drawing.Point(0, 116)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(478, 49)
        Me.PictureBox2.TabIndex = 3
        Me.PictureBox2.TabStop = False
        '
        'FirstRunDialog
        '
        Me.AcceptButton = Me.DevelopmentButton
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.CancelButton = Me.StableButton
        Me.ClientSize = New System.Drawing.Size(478, 165)
        Me.ControlBox = False
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.FirstRun_pictureBox)
        Me.Controls.Add(Me.FirstRun_label)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FirstRunDialog"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = Global.Launcher.My.Resources.Resources.frmFirstRunDialog_stableOrDevFirstRun_title
        Me.TopMost = True
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.FirstRun_pictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents StableButton As System.Windows.Forms.Button
    Friend WithEvents DevelopmentButton As System.Windows.Forms.Button
    Friend WithEvents FirstRun_label As System.Windows.Forms.Label
    Friend WithEvents FirstRun_pictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox

End Class
