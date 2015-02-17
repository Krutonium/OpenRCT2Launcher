Public Class frmOptions
    Private Sub frmOptions_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UpdateGUI()
    End Sub

    Private Sub cmdGamePath_Click(sender As Object, e As EventArgs) Handles cmdGamePath.Click
        FBD.SelectedPath = tbGamePath.Text

        If FBD.ShowDialog() = Windows.Forms.DialogResult.OK Then
            tbGamePath.Text = FBD.SelectedPath
        End If
    End Sub

    Private Sub chkSaveOutput_CheckedChanged(sender As Object, e As EventArgs) Handles chkSaveOutput.CheckedChanged
        'Enable and disable the Output Path field if needed
        tbOutputPath.Enabled = chkSaveOutput.Checked
        cmdOutputPath.Enabled = chkSaveOutput.Checked
    End Sub

    Private Sub cmdOutputPath_Click(sender As Object, e As EventArgs) Handles cmdOutputPath.Click
        SFD.FileName = tbOutputPath.Text

        If SFD.ShowDialog() = Windows.Forms.DialogResult.OK Then
            tbOutputPath.Text = SFD.FileName
        End If
    End Sub

    Private Sub cmdOk_Click(sender As Object, e As EventArgs) Handles cmdOk.Click
        'Save OpenRCT2 config when changed
        If ConfigHasChangedOpenRCT2() Then
            ConfigSaveOpenRCT2()
        End If

        'Save Launcher config when changed
        If ConfigHasChangedLauncher() Then
            ConfigSaveLauncher()
        End If

        Me.Close()
    End Sub

    Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Private Sub cmdApply_Click(sender As Object, e As EventArgs) Handles cmdApply.Click
        If ConfigHasChangedOpenRCT2() Then
            ConfigSaveOpenRCT2()
        End If

        If ConfigHasChangedLauncher() Then
            ConfigSaveLauncher()
        End If
    End Sub

    Private Sub cmdReset_Click(sender As Object, e As EventArgs) Handles cmdReset.Click
        Main.OpenRCT2Config.LoadDefault()
        Main.LauncherConfig.LoadDefault()
        UpdateGUI()
    End Sub

    Private Sub frmOptions_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If ConfigHasChangedOpenRCT2() Or ConfigHasChangedLauncher() Then 'Has the configuration been changed?
            Dim Result As DialogResult = MessageBox.Show("Configuration has been changed. Save Changes?", "Confirm", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information)

            Select Case Result
                Case Windows.Forms.DialogResult.Yes 'Save and close
                    If ConfigHasChangedOpenRCT2() Then
                        ConfigSaveOpenRCT2()
                    End If

                    If ConfigHasChangedLauncher() Then
                        ConfigSaveLauncher()
                    End If
                Case Windows.Forms.DialogResult.Cancel 'Return to options window
                    e.Cancel = True
            End Select
        End If
    End Sub

    Private Sub UpdateGUI()
        'Update all input fields with the current settings

        chkPlayIntro.Checked = Main.OpenRCT2Config.PlayIntro
        chkConfirmationPrompt.Checked = Main.OpenRCT2Config.ConfirmationPrompt
        cbScreenshotFormat.SelectedIndex = Main.OpenRCT2Config.ScreenshotFormat
        tbGamePath.Text = Main.OpenRCT2Config.GamePath
        cbMeasurementFormat.SelectedIndex = Main.OpenRCT2Config.MeasurementFormat
        cbTemperatureFormat.SelectedIndex = Main.OpenRCT2Config.TemperatureFormat
        cbCurrency.SelectedIndex = Main.OpenRCT2Config.CurrencyFormat
        chkEdgeScrolling.Checked = Main.OpenRCT2Config.EdgeScrolling
        chkAlwaysShowGridlines.Checked = Main.OpenRCT2Config.AlwaysShowGridlines
        chkLandscapeSmoothing.Checked = Main.OpenRCT2Config.LandscapeSmoothing

        If Main.OpenRCT2Config.ShowHeightAsUnits Then
            cbShowHeightAsUnits.SelectedIndex = 0
        Else
            cbShowHeightAsUnits.SelectedIndex = 1
        End If

        chkSavePluginData.Checked = Main.OpenRCT2Config.SavePluginData
        cbFullscreenMode.SelectedIndex = Main.OpenRCT2Config.FullscreenMode
        numFullscreenWidth.Value = Main.OpenRCT2Config.FullscreenWidth
        numFullscreenHeight.Value = Main.OpenRCT2Config.FullscreenHeight
        cbLanguage.SelectedIndex = Main.OpenRCT2Config.Language - 1
        cbTitleMusic.SelectedIndex = Main.OpenRCT2Config.TitleMusic
        cbSoundQuality.SelectedIndex = Main.OpenRCT2Config.SoundQuality
        chkForcedSoftwareBuffering.Checked = Main.OpenRCT2Config.ForcedSoftwareBuffering

        chkVerbose.Checked = Main.LauncherConfig.Verbose
        tbArguments.Text = Main.LauncherConfig.Arguments
        chkSaveOutput.Checked = Main.LauncherConfig.SaveOutput
        tbOutputPath.Text = Main.LauncherConfig.OutputPath

        tbOutputPath.Enabled = chkSaveOutput.Checked
        cmdOutputPath.Enabled = chkSaveOutput.Checked
    End Sub

    Private Function ConfigHasChangedOpenRCT2() As Boolean
        'Compare all fields with the current configuration to detect if any changes where made

        If chkPlayIntro.Checked <> Main.OpenRCT2Config.PlayIntro Then
            Return True
        End If

        If chkConfirmationPrompt.Checked <> Main.OpenRCT2Config.ConfirmationPrompt Then
            Return True
        End If

        If cbScreenshotFormat.SelectedIndex <> Main.OpenRCT2Config.ScreenshotFormat Then
            Return True
        End If

        If tbGamePath.Text <> Main.OpenRCT2Config.GamePath Then
            Return True
        End If

        If cbMeasurementFormat.SelectedIndex <> Main.OpenRCT2Config.MeasurementFormat Then
            Return True
        End If

        If cbTemperatureFormat.SelectedIndex <> Main.OpenRCT2Config.TemperatureFormat Then
            Return True
        End If

        If cbCurrency.SelectedIndex <> Main.OpenRCT2Config.CurrencyFormat Then
            Return True
        End If

        If chkEdgeScrolling.Checked <> Main.OpenRCT2Config.EdgeScrolling Then
            Return True
        End If

        If chkAlwaysShowGridlines.Checked <> Main.OpenRCT2Config.AlwaysShowGridlines Then
            Return True
        End If

        If chkLandscapeSmoothing.Checked <> Main.OpenRCT2Config.LandscapeSmoothing Then
            Return True
        End If

        If cbShowHeightAsUnits.SelectedIndex <> 1 - Main.OpenRCT2Config.ShowHeightAsUnits Then
            Return True
        End If

        If chkSavePluginData.Checked <> Main.OpenRCT2Config.SavePluginData Then
            Return True
        End If

        If cbFullscreenMode.SelectedIndex <> Main.OpenRCT2Config.FullscreenMode Then
            Return True
        End If

        If numFullscreenWidth.Value <> Main.OpenRCT2Config.FullscreenWidth Then
            Return True
        End If

        If numFullscreenHeight.Value <> Main.OpenRCT2Config.FullscreenHeight Then
            Return True
        End If

        If cbLanguage.SelectedIndex <> Main.OpenRCT2Config.Language - 1 Then
            Return True
        End If

        If cbTitleMusic.SelectedIndex <> Main.OpenRCT2Config.TitleMusic Then
            Return True
        End If

        If cbSoundQuality.SelectedIndex <> Main.OpenRCT2Config.SoundQuality Then
            Return True
        End If

        If chkForcedSoftwareBuffering.Checked <> Main.OpenRCT2Config.ForcedSoftwareBuffering Then
            Return True
        End If

        Return False
    End Function

    Private Function ConfigHasChangedLauncher() As Boolean
        'Compare all fields with the current configuration to detect if any changes where made

        If chkVerbose.Checked <> Main.LauncherConfig.Verbose Then
            Return True
        End If

        If tbArguments.Text <> Main.LauncherConfig.Arguments Then
            Return True
        End If

        If chkSaveOutput.Checked <> Main.LauncherConfig.SaveOutput Then
            Return True
        End If

        If tbOutputPath.Text <> Main.LauncherConfig.OutputPath Then
            Return True
        End If

        Return False
    End Function

    Private Sub ConfigSaveOpenRCT2()
        Main.OpenRCT2Config.PlayIntro = chkPlayIntro.Checked
        Main.OpenRCT2Config.ConfirmationPrompt = chkConfirmationPrompt.Checked
        Main.OpenRCT2Config.ScreenshotFormat = cbScreenshotFormat.SelectedIndex
        Main.OpenRCT2Config.GamePath = tbGamePath.Text
        Main.OpenRCT2Config.MeasurementFormat = cbMeasurementFormat.SelectedIndex
        Main.OpenRCT2Config.TemperatureFormat = cbTemperatureFormat.SelectedIndex
        Main.OpenRCT2Config.CurrencyFormat = cbCurrency.SelectedIndex
        Main.OpenRCT2Config.EdgeScrolling = chkEdgeScrolling.Checked
        Main.OpenRCT2Config.AlwaysShowGridlines = chkAlwaysShowGridlines.Checked
        Main.OpenRCT2Config.LandscapeSmoothing = chkLandscapeSmoothing.Checked
        Main.OpenRCT2Config.ShowHeightAsUnits = 1 - cbShowHeightAsUnits.SelectedIndex
        Main.OpenRCT2Config.SavePluginData = chkSavePluginData.Checked
        Main.OpenRCT2Config.FullscreenMode = cbFullscreenMode.SelectedIndex
        Main.OpenRCT2Config.FullscreenWidth = numFullscreenWidth.Value
        Main.OpenRCT2Config.FullscreenHeight = numFullscreenHeight.Value
        Main.OpenRCT2Config.Language = cbLanguage.SelectedIndex + 1
        Main.OpenRCT2Config.TitleMusic = cbTitleMusic.SelectedIndex
        Main.OpenRCT2Config.SoundQuality = cbSoundQuality.SelectedIndex
        Main.OpenRCT2Config.ForcedSoftwareBuffering = chkForcedSoftwareBuffering.Checked

        Main.OpenRCT2Config.HasChanged = True 'If this wouldn't be set the application would just ignore the changes and won't save them
    End Sub

    Private Sub ConfigSaveLauncher()
        Main.LauncherConfig.Verbose = chkVerbose.Checked
        Main.LauncherConfig.Arguments = tbArguments.Text
        Main.LauncherConfig.SaveOutput = chkSaveOutput.Checked
        Main.LauncherConfig.OutputPath = tbOutputPath.Text

        Main.LauncherConfig.HasChanged = True  'If this wouldn't be set the application would just ignore the changes and won't save them
    End Sub
End Class