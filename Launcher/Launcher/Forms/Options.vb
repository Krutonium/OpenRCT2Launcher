Imports Launcher.My
Imports Launcher.My.Resources

Namespace Forms
    Public Class FrmOptions
        Private Sub frmOptions_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            chkPlayIntro.Checked              = OpenRCT2Config.PlayIntro
            chkConfirmationPrompt.Checked     = OpenRCT2Config.ConfirmationPrompt
            cbScreenshotFormat.SelectedIndex  = OpenRCT2Config.ScreenshotFormat
            tbGamePath.Text                   = OpenRCT2Config.GamePath
            cbMeasurementFormat.SelectedIndex = OpenRCT2Config.MeasurementFormat
            cbTemperatureFormat.SelectedIndex = OpenRCT2Config.TemperatureFormat
            cbCurrency.SelectedIndex          = OpenRCT2Config.CurrencyFormat
            chkEdgeScrolling.Checked          = OpenRCT2Config.EdgeScrolling
            chkAlwaysShowGridlines.Checked    = OpenRCT2Config.AlwaysShowGridlines
            chkLandscapeSmoothing.Checked     = OpenRCT2Config.LandscapeSmoothing

            If OpenRCT2Config.ShowHeightAsUnits Then
                cbShowHeightAsUnits.SelectedIndex = 0
            Else
                cbShowHeightAsUnits.SelectedIndex = 1
            End If

            chkSavePluginData.Checked          = OpenRCT2Config.SavePluginData
            cbFullscreenMode.SelectedIndex     = OpenRCT2Config.FullscreenMode
            numFullscreenWidth.Value           = OpenRCT2Config.FullscreenWidth
            numFullscreenHeight.Value          = OpenRCT2Config.FullscreenHeight
            cbLanguage.SelectedIndex           = OpenRCT2Config.Language - 1
            cbTitleMusic.SelectedIndex         = OpenRCT2Config.TitleMusic
            cbSoundQuality.SelectedIndex       = OpenRCT2Config.SoundQuality
            chkForcedSoftwareBuffering.Checked = OpenRCT2Config.ForcedSoftwareBuffering

            chkVerbose.Checked    = Settings.Verbose
            tbArguments.Text      = Settings.Arguments
            chkSaveOutput.Checked = Settings.SaveOutput
            tbOutputPath.Text     = Settings.OutputPath

            tbOutputPath.Enabled  = chkSaveOutput.Checked
            cmdOutputPath.Enabled = chkSaveOutput.Checked

            cbAutosave.SelectedIndex                 = OpenRCT2Config.Autosave
            cbConstructionMarkerColour.SelectedIndex = OpenRCT2Config.ConstructionMarkerColour
            numWindowWidth.Value                     = OpenRCT2Config.WindowWidth
            numWindowHeight.Value                    = OpenRCT2Config.WindowHeight
            numWindowSnapProximity.Value             = OpenRCT2Config.WindowSnapProximity
            chkSound.Checked                         = OpenRCT2Config.Sound
            chkRideMusic.Checked                     = OpenRCT2Config.RideMusic

            chkCheckUpdates.Checked   = Settings.CheckUpdates
            chkInstallUpdates.Checked = Settings.InstallUpdates
            chkCheckLauncher.Checked  = Settings.CheckLauncher

            chkInstallUpdates.Enabled = chkCheckUpdates.Checked
        End Sub

        Private Sub cmdGamePath_Click(sender As Object, e As EventArgs) Handles cmdGamePath.Click
            FBD.SelectedPath = tbGamePath.Text

            If FBD.ShowDialog() = Windows.Forms.DialogResult.OK Then
                tbGamePath.Text = FBD.SelectedPath
            End If
        End Sub

        Private Sub chkSaveOutput_CheckedChanged(sender As Object, e As EventArgs) Handles chkSaveOutput.CheckedChanged
            'Enable and disable the Output Path field if needed
            tbOutputPath.Enabled  = chkSaveOutput.Checked
            cmdOutputPath.Enabled = chkSaveOutput.Checked
        End Sub

        Private Sub cmdOutputPath_Click(sender As Object, e As EventArgs) Handles cmdOutputPath.Click
            SFD.FileName = tbOutputPath.Text

            If SFD.ShowDialog() = Windows.Forms.DialogResult.OK Then
                tbOutputPath.Text = SFD.FileName
            End If
        End Sub

        Private Sub chkCheckUpdates_CheckedChanged(sender As Object,  e As EventArgs) Handles chkCheckUpdates.CheckedChanged
            chkInstallUpdates.Enabled = chkCheckUpdates.Checked
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

            Close()
        End Sub

        Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
            Close()
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
            chkPlayIntro.Checked              = OpenRCT2Config.DefPlayIntro
            chkConfirmationPrompt.Checked     = OpenRCT2Config.DefConfirmationPrompt
            cbScreenshotFormat.SelectedIndex  = OpenRCT2Config.DefScreenshotFormat
            tbGamePath.Text                   = OpenRCT2Config.DefGamePath
            cbMeasurementFormat.SelectedIndex = OpenRCT2Config.DefMeasurementFormat
            cbTemperatureFormat.SelectedIndex = OpenRCT2Config.DefTemperatureFormat
            cbCurrency.SelectedIndex          = OpenRCT2Config.DefCurrencyFormat
            chkEdgeScrolling.Checked          = OpenRCT2Config.DefEdgeScrolling
            chkAlwaysShowGridlines.Checked    = OpenRCT2Config.DefAlwaysShowGridlines
            chkLandscapeSmoothing.Checked     = OpenRCT2Config.DefLandscapeSmoothing

            If OpenRCT2Config.DefShowHeightAsUnits Then
                cbShowHeightAsUnits.SelectedIndex = 0
            Else
                cbShowHeightAsUnits.SelectedIndex = 1
            End If

            chkSavePluginData.Checked          = OpenRCT2Config.DefSavePluginData
            cbFullscreenMode.SelectedIndex     = OpenRCT2Config.DefFullscreenMode
            numFullscreenWidth.Value           = OpenRCT2Config.DefFullscreenWidth
            numFullscreenHeight.Value          = OpenRCT2Config.DefFullscreenHeight
            cbLanguage.SelectedIndex           = OpenRCT2Config.DefLanguage - 1
            cbTitleMusic.SelectedIndex         = OpenRCT2Config.DefTitleMusic
            cbSoundQuality.SelectedIndex       = OpenRCT2Config.DefSoundQuality
            chkForcedSoftwareBuffering.Checked = OpenRCT2Config.DefForcedSoftwareBuffering

            chkVerbose.Checked    = My.Settings.PropertyValues("Verbose").Property.DefaultValue
            tbArguments.Text      = My.Settings.PropertyValues("Arguments").Property.DefaultValue
            chkSaveOutput.Checked = My.Settings.PropertyValues("SaveOutput").Property.DefaultValue
            tbOutputPath.Text     = My.Settings.PropertyValues("OutputPath").Property.DefaultValue

            tbOutputPath.Enabled  = chkSaveOutput.Checked
            cmdOutputPath.Enabled = chkSaveOutput.Checked

            cbAutosave.SelectedIndex                 = OpenRCT2Config.DefAutosave
            cbConstructionMarkerColour.SelectedIndex = OpenRCT2Config.DefConstructionMarkerColour
            numWindowWidth.Value                     = OpenRCT2Config.DefWindowWidth
            numWindowHeight.Value                    = OpenRCT2Config.DefWindowHeight
            numWindowSnapProximity.Value             = OpenRCT2Config.DefWindowSnapProximity
            chkSound.Checked                         = OpenRCT2Config.DefSound
            chkRideMusic.Checked                     = OpenRCT2Config.DefRideMusic

            chkCheckUpdates.Checked   = My.Settings.PropertyValues("CheckUpdates").Property.DefaultValue
            chkInstallUpdates.Checked = My.Settings.PropertyValues("InstallUpdates").Property.DefaultValue
            chkCheckLauncher.Checked  = My.Settings.PropertyValues("CheckLauncher").Property.DefaultValue

            chkInstallUpdates.Enabled = chkCheckUpdates.Checked
        End Sub

        Private Sub frmOptions_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
            If ConfigHasChangedOpenRCT2() Or ConfigHasChangedLauncher() Then 'Has the configuration been changed?
                Dim result As DialogResult = MessageBox.Show(frmOptions_closeConfirmation_text, common_confirm, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information)

                Select Case result
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

        Private Function ConfigHasChangedOpenRCT2() As Boolean
            'Compare all fields with the current configuration to detect if any changes where made

            If chkPlayIntro.Checked <> OpenRCT2Config.PlayIntro Then
                Return True
            End If

            If chkConfirmationPrompt.Checked <> OpenRCT2Config.ConfirmationPrompt Then
                Return True
            End If

            If cbScreenshotFormat.SelectedIndex <> OpenRCT2Config.ScreenshotFormat Then
                Return True
            End If

            If tbGamePath.Text <> OpenRCT2Config.GamePath Then
                Return True
            End If

            If cbMeasurementFormat.SelectedIndex <> OpenRCT2Config.MeasurementFormat Then
                Return True
            End If

            If cbTemperatureFormat.SelectedIndex <> OpenRCT2Config.TemperatureFormat Then
                Return True
            End If

            If cbCurrency.SelectedIndex <> OpenRCT2Config.CurrencyFormat Then
                Return True
            End If

            If chkEdgeScrolling.Checked <> OpenRCT2Config.EdgeScrolling Then
                Return True
            End If

            If chkAlwaysShowGridlines.Checked <> OpenRCT2Config.AlwaysShowGridlines Then
                Return True
            End If

            If chkLandscapeSmoothing.Checked <> OpenRCT2Config.LandscapeSmoothing Then
                Return True
            End If

            If cbShowHeightAsUnits.SelectedIndex <> 1 - OpenRCT2Config.ShowHeightAsUnits Then
                Return True
            End If

            If chkSavePluginData.Checked <> OpenRCT2Config.SavePluginData Then
                Return True
            End If

            If cbFullscreenMode.SelectedIndex <> OpenRCT2Config.FullscreenMode Then
                Return True
            End If

            If numFullscreenWidth.Value <> OpenRCT2Config.FullscreenWidth Then
                Return True
            End If

            If numFullscreenHeight.Value <> OpenRCT2Config.FullscreenHeight Then
                Return True
            End If

            If cbLanguage.SelectedIndex <> OpenRCT2Config.Language - 1 Then
                Return True
            End If

            If cbTitleMusic.SelectedIndex <> OpenRCT2Config.TitleMusic Then
                Return True
            End If

            If cbSoundQuality.SelectedIndex <> OpenRCT2Config.SoundQuality Then
                Return True
            End If

            If chkForcedSoftwareBuffering.Checked <> OpenRCT2Config.ForcedSoftwareBuffering Then
                Return True
            End If

            If cbAutosave.SelectedIndex <> OpenRCT2Config.Autosave Then
                Return True
            End If

            If cbConstructionMarkerColour.SelectedIndex <> OpenRCT2Config.ConstructionMarkerColour Then
                Return True
            End If

            If numWindowWidth.Value <> OpenRCT2Config.WindowWidth Then
                Return True
            End If

            If numWindowHeight.Value <> OpenRCT2Config.WindowHeight Then
                Return True
            End If

            If numWindowSnapProximity.Value <> OpenRCT2Config.WindowSnapProximity Then
                Return True
            End If

            If chkSound.Checked <> OpenRCT2Config.Sound Then
                Return True
            End If

            If chkRideMusic.Checked <> OpenRCT2Config.RideMusic Then
                Return True
            End If

            Return False
        End Function

        Private Function ConfigHasChangedLauncher() As Boolean
            'Compare all fields with the current configuration to detect if any changes where made

            If chkVerbose.Checked <> Settings.Verbose Then
                Return True
            End If

            If tbArguments.Text <> Settings.Arguments Then
                Return True
            End If

            If chkSaveOutput.Checked <> Settings.SaveOutput Then
                Return True
            End If

            If tbOutputPath.Text <> Settings.OutputPath Then
                Return True
            End If

            If chkCheckUpdates.Checked <> Settings.CheckUpdates Then
                Return True
            End If

            If chkInstallUpdates.Checked <> Settings.InstallUpdates Then
                Return True
            End If

            If chkCheckLauncher.Checked <> Settings.CheckLauncher Then
                Return True
            End If

            Return False
        End Function

        Private Sub ConfigSaveOpenRCT2()
            OpenRCT2Config.PlayIntro                = chkPlayIntro.Checked
            OpenRCT2Config.ConfirmationPrompt       = chkConfirmationPrompt.Checked
            OpenRCT2Config.ScreenshotFormat         = cbScreenshotFormat.SelectedIndex
            OpenRCT2Config.GamePath                 = tbGamePath.Text
            OpenRCT2Config.MeasurementFormat        = cbMeasurementFormat.SelectedIndex
            OpenRCT2Config.TemperatureFormat        = cbTemperatureFormat.SelectedIndex
            OpenRCT2Config.CurrencyFormat           = cbCurrency.SelectedIndex
            OpenRCT2Config.EdgeScrolling            = chkEdgeScrolling.Checked
            OpenRCT2Config.AlwaysShowGridlines      = chkAlwaysShowGridlines.Checked
            OpenRCT2Config.LandscapeSmoothing       = chkLandscapeSmoothing.Checked
            OpenRCT2Config.ShowHeightAsUnits        = 1 - cbShowHeightAsUnits.SelectedIndex
            OpenRCT2Config.SavePluginData           = chkSavePluginData.Checked
            OpenRCT2Config.FullscreenMode           = cbFullscreenMode.SelectedIndex
            OpenRCT2Config.FullscreenWidth          = numFullscreenWidth.Value
            OpenRCT2Config.FullscreenHeight         = numFullscreenHeight.Value
            OpenRCT2Config.Language                 = cbLanguage.SelectedIndex + 1
            OpenRCT2Config.TitleMusic               = cbTitleMusic.SelectedIndex
            OpenRCT2Config.SoundQuality             = cbSoundQuality.SelectedIndex
            OpenRCT2Config.ForcedSoftwareBuffering  = chkForcedSoftwareBuffering.Checked
            OpenRCT2Config.Autosave                 = cbAutosave.SelectedIndex
            OpenRCT2Config.ConstructionMarkerColour = cbConstructionMarkerColour.SelectedIndex
            OpenRCT2Config.WindowWidth              = numWindowWidth.Value
            OpenRCT2Config.WindowHeight             = numWindowHeight.Value
            OpenRCT2Config.WindowSnapProximity      = numWindowSnapProximity.Value
            OpenRCT2Config.Sound                    = chkSound.Checked
            OpenRCT2Config.RideMusic                = chkRideMusic.Checked

            OpenRCT2Config.HasChanged = True 'If this wouldn't be set the application would just ignore the changes and won't save them
        End Sub

        Private Sub ConfigSaveLauncher()
            Settings.Verbose        = chkVerbose.Checked
            Settings.Arguments      = tbArguments.Text
            Settings.SaveOutput     = chkSaveOutput.Checked
            Settings.OutputPath     = tbOutputPath.Text
            Settings.CheckUpdates   = chkCheckUpdates.Checked
            Settings.InstallUpdates = chkInstallUpdates.Checked
            Settings.CheckLauncher  = chkCheckLauncher.Checked

            Settings.HasChanged = True
        End Sub

    End Class
End Namespace