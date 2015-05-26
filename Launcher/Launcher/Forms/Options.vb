Imports Launcher.My
Imports Launcher.My.Resources

Namespace Forms
    Public Class FrmOptions
        Private Sub chkCheckUpdates_CheckedChanged(sender As Object,  e As EventArgs) Handles chkCheckUpdates.CheckedChanged
            chkInstallUpdates.Enabled = chkCheckUpdates.Checked
        End Sub

        Private Sub chkSaveOutput_CheckedChanged(sender As Object, e As EventArgs) Handles chkSaveOutput.CheckedChanged
            'Enable and disable the Output Path field if needed
            tbOutputPath.Enabled  = chkSaveOutput.Checked
            cmdOutputPath.Enabled = chkSaveOutput.Checked
        End Sub

        Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
            Close()
        End Sub

        Private Sub cmdGamePath_Click(sender As Object, e As EventArgs) Handles cmdGamePath.Click
            FBD.SelectedPath = tbGamePath.Text

            If FBD.ShowDialog() = Windows.Forms.DialogResult.OK Then
                tbGamePath.Text = FBD.SelectedPath
            End If
        End Sub

        Private Sub cmdOk_Click(sender As Object, e As EventArgs) Handles cmdOk.Click
            'Save OpenRCT2 config when changed
            If configHasChangedGame() Then
                GameConfig.values = toGameConfigValues()
            End If

            'Save Launcher config when changed
            If configHasChangedLauncher() Then
                configSaveLauncher()
            End If

            Close()
        End Sub

        Private Sub cmdOutputPath_Click(sender As Object, e As EventArgs) Handles cmdOutputPath.Click
            SFD.FileName = tbOutputPath.Text

            If SFD.ShowDialog() = Windows.Forms.DialogResult.OK Then
                tbOutputPath.Text = SFD.FileName
            End If
        End Sub

        Private Sub cmdReset_Click(sender As Object, e As EventArgs) Handles cmdReset.Click
            fromGameConfigValues(New GameConfigValues(GameConfigValues.Constructor.DefaultValues))

            chkVerbose.Checked        = My.Settings.PropertyValues("Verbose").Property.DefaultValue
            tbArguments.Text          = My.Settings.PropertyValues("Arguments").Property.DefaultValue
            chkSaveOutput.Checked     = My.Settings.PropertyValues("SaveOutput").Property.DefaultValue
            tbOutputPath.Text         = My.Settings.PropertyValues("OutputPath").Property.DefaultValue
            chkCheckUpdates.Checked   = My.Settings.PropertyValues("CheckUpdates").Property.DefaultValue
            chkInstallUpdates.Checked = My.Settings.PropertyValues("InstallUpdates").Property.DefaultValue
            chkCheckLauncher.Checked  = My.Settings.PropertyValues("CheckLauncher").Property.DefaultValue

            tbOutputPath.Enabled      = chkSaveOutput.Checked
            cmdOutputPath.Enabled     = chkSaveOutput.Checked
            chkInstallUpdates.Enabled = chkCheckUpdates.Checked
        End Sub

        Private Function configHasChangedGame() As Boolean
            Return Not toGameConfigValues().Equals(GameConfig.values)
        End Function

        Private Function configHasChangedLauncher() As Boolean
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

        Private Sub configSaveLauncher()
            Settings.Verbose        = chkVerbose.Checked
            Settings.Arguments      = tbArguments.Text
            Settings.SaveOutput     = chkSaveOutput.Checked
            Settings.OutputPath     = tbOutputPath.Text
            Settings.CheckUpdates   = chkCheckUpdates.Checked
            Settings.InstallUpdates = chkInstallUpdates.Checked
            Settings.CheckLauncher  = chkCheckLauncher.Checked

            Settings.HasChanged = True
        End Sub

        Private Sub frmOptions_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
            If configHasChangedGame() Or configHasChangedLauncher() Then 'Has the configuration been changed?
                Dim result As DialogResult = MessageBox.Show(frmOptions_closeConfirmation_text, common_confirm, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information)

                Select Case result
                    Case Windows.Forms.DialogResult.Yes 'Save and close
                        If configHasChangedGame() Then
                            GameConfig.values = toGameConfigValues()
                        End If

                        If configHasChangedLauncher() Then
                            configSaveLauncher()
                        End If
                    Case Windows.Forms.DialogResult.Cancel 'Return to options window
                        e.Cancel = True
                End Select
            End If
        End Sub

        Private Sub frmOptions_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            fromGameConfigValues(GameConfig.values)

            chkVerbose.Checked        = Settings.Verbose
            tbArguments.Text          = Settings.Arguments
            chkSaveOutput.Checked     = Settings.SaveOutput
            tbOutputPath.Text         = Settings.OutputPath
            chkCheckUpdates.Checked   = Settings.CheckUpdates
            chkInstallUpdates.Checked = Settings.InstallUpdates
            chkCheckLauncher.Checked  = Settings.CheckLauncher

            tbOutputPath.Enabled      = chkSaveOutput.Checked
            cmdOutputPath.Enabled     = chkSaveOutput.Checked
            chkInstallUpdates.Enabled = chkCheckUpdates.Checked
        End Sub

        Private Sub fromGameConfigValues(c As GameConfigValues)
            chkAllowSubtypeSwitching.Checked         = c.AllowSubtypeSwitching
            chkAlwaysShowGridlines.Checked           = c.AlwaysShowGridlines
            cbAutosave.SelectedIndex                 = c.Autosave
            tbChannel.Text                           = c.Channel
            chkChatPeepNames.Checked                 = c.ChatPeepNames
            chkChatPeepTracking.Checked              = c.ChatPeepTracking
            chkConfirmationPrompt.Checked            = c.ConfirmationPrompt
            chkConsoleSmallFont.Checked              = c.ConsoleSmallFont
            cbConstructionMarkerColour.SelectedIndex = c.ConstructionMarkerColour
            cbCurrency.SelectedIndex                 = c.CurrencyFormat
            cbDateFormat.SelectedIndex               = c.DateFormat
            chkDebuggingTools.Checked                = c.DebuggingTools
            chkDisableAllBreakdowns.Checked          = c.DisableAllBreakdowns
            chkDisableBrakesFailure.Checked          = c.DisableBrakesFailure
            chkEdgeScrolling.Checked                 = c.EdgeScrolling
            chkFastLiftHill.Checked                  = c.FastLiftHill
            chkFollowerPeepNames.Checked             = c.FollowerPeepNames
            chkFollowerPeepTracking.Checked          = c.FollowerPeepTracking
            chkForcedSoftwareBuffering.Checked       = c.ForcedSoftwareBuffering
            numFullscreenHeight.Value                = c.FullscreenHeight
            cbFullscreenMode.SelectedIndex           = c.FullscreenMode
            numFullscreenWidth.Value                 = c.FullscreenWidth
            tbGamePath.Text                          = c.GamePath
            chkHardwareDisplay.Checked               = c.HardwareDisplay
            chkLandscapeSmoothing.Checked            = c.LandscapeSmoothing
            cbLanguage.SelectedIndex                 = c.Language - 1
            cbMeasurementFormat.SelectedIndex        = c.MeasurementFormat
            chkNews.Checked                          = c.News
            chkNoTestCrashes.Checked                 = c.NoTestCrashes
            chkPlayIntro.Checked                     = c.PlayIntro
            chkRCT1ColourScheme.Checked              = c.RCT1ColourScheme
            chkRideMusic.Checked                     = c.RideMusic
            chkSavePluginData.Checked                = c.SavePluginData
            cbScreenshotFormat.SelectedIndex         = c.ScreenshotFormat
            cbShowHeightAsUnits.SelectedIndex        = 1 + c.ShowHeightAsUnits
            chkSound.Checked                         = c.Sound
            cbSoundQuality.SelectedIndex             = c.SoundQuality
            cbTemperatureFormat.SelectedIndex        = c.TemperatureFormat
            chkTestUnfinishedTracks.Checked          = c.TestUnfinishedTracks
            cbTitleMusic.SelectedIndex               = c.TitleMusic
            chkToolbarShowCheats.Checked             = c.ToolbarShowCheats
            chkToolbarShowFinances.Checked           = c.ToolbarShowFinances
            chkToolbarShowResearch.Checked           = c.ToolbarShowResearch
            chkUnlockAllPrices.Checked               = c.UnlockAllPrices
            numWindowHeight.Value                    = c.WindowHeight
            numWindowSnapProximity.Value             = c.WindowSnapProximity
            numWindowWidth.Value                     = c.WindowWidth
        End Sub

        Private Function toGameConfigValues() As GameConfigValues
            Dim c As New GameConfigValues()

            c.AllowSubtypeSwitching    = chkAllowSubtypeSwitching.Checked
            c.AlwaysShowGridlines      = chkAlwaysShowGridlines.Checked
            c.Autosave                 = cbAutosave.SelectedIndex
            c.Channel                  = tbChannel.Text
            c.ChatPeepNames            = chkChatPeepNames.Checked
            c.ChatPeepTracking         = chkChatPeepTracking.Checked
            c.ConfirmationPrompt       = chkConfirmationPrompt.Checked
            c.ConsoleSmallFont         = chkConsoleSmallFont.Checked
            c.ConstructionMarkerColour = cbConstructionMarkerColour.SelectedIndex
            c.CurrencyFormat           = cbCurrency.SelectedIndex
            c.DateFormat               = cbDateFormat.SelectedIndex
            c.DebuggingTools           = chkDebuggingTools.Checked
            c.DisableAllBreakdowns     = chkDisableAllBreakdowns.Checked
            c.DisableBrakesFailure     = chkDisableBrakesFailure.Checked
            c.EdgeScrolling            = chkEdgeScrolling.Checked
            c.FastLiftHill             = chkFastLiftHill.Checked
            c.FollowerPeepNames        = chkFollowerPeepNames.Checked
            c.FollowerPeepTracking     = chkFollowerPeepTracking.Checked
            c.ForcedSoftwareBuffering  = chkForcedSoftwareBuffering.Checked
            c.FullscreenHeight         = numFullscreenHeight.Value
            c.FullscreenMode           = cbFullscreenMode.SelectedIndex
            c.FullscreenWidth          = numFullscreenWidth.Value
            c.GamePath                 = tbGamePath.Text
            c.HardwareDisplay          = chkHardwareDisplay.Checked
            c.LandscapeSmoothing       = chkLandscapeSmoothing.Checked
            c.Language                 = cbLanguage.SelectedIndex + 1
            c.MeasurementFormat        = cbMeasurementFormat.SelectedIndex
            c.News                     = chkNews.Checked
            c.NoTestCrashes            = chkNoTestCrashes.Checked
            c.PlayIntro                = chkPlayIntro.Checked
            c.RCT1ColourScheme         = chkRCT1ColourScheme.Checked
            c.RideMusic                = chkRideMusic.Checked
            c.SavePluginData           = chkSavePluginData.Checked
            c.ScreenshotFormat         = cbScreenshotFormat.SelectedIndex
            c.ShowHeightAsUnits        = 1 - cbShowHeightAsUnits.SelectedIndex
            c.Sound                    = chkSound.Checked
            c.SoundQuality             = cbSoundQuality.SelectedIndex
            c.TemperatureFormat        = cbTemperatureFormat.SelectedIndex
            c.TestUnfinishedTracks     = chkTestUnfinishedTracks.Checked
            c.TitleMusic               = cbTitleMusic.SelectedIndex
            c.ToolbarShowCheats        = chkToolbarShowCheats.Checked
            c.ToolbarShowFinances      = chkToolbarShowFinances.Checked
            c.ToolbarShowResearch      = chkToolbarShowResearch.Checked
            c.UnlockAllPrices          = chkUnlockAllPrices.Checked
            c.WindowHeight             = numWindowHeight.Value
            c.WindowSnapProximity      = numWindowSnapProximity.Value
            c.WindowWidth              = numWindowWidth.Value

            Return c
        End Function
    End Class
End Namespace