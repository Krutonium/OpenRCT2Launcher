Imports Launcher.My.Resources

Namespace Forms

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class FrmOptions
        Inherits System.Windows.Forms.Form

        'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
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

        'Wird vom Windows Form-Designer benötigt.
        Private components As System.ComponentModel.IContainer

        'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
        'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
        'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
        <System.Diagnostics.DebuggerStepThrough()> _
        Private Sub InitializeComponent()
        Me.tbGamePath = New System.Windows.Forms.TextBox()
        Me.cmdGamePath = New System.Windows.Forms.Button()
        Me.laGamePath = New System.Windows.Forms.Label()
        Me.laScreenshotFormat = New System.Windows.Forms.Label()
        Me.cbScreenshotFormat = New System.Windows.Forms.ComboBox()
        Me.chkPlayIntro = New System.Windows.Forms.CheckBox()
        Me.chkConfirmationPrompt = New System.Windows.Forms.CheckBox()
        Me.chkEdgeScrolling = New System.Windows.Forms.CheckBox()
        Me.laCurrency = New System.Windows.Forms.Label()
        Me.cbCurrency = New System.Windows.Forms.ComboBox()
        Me.laMeasurementFormat = New System.Windows.Forms.Label()
        Me.laTemperatureFormat = New System.Windows.Forms.Label()
        Me.cbMeasurementFormat = New System.Windows.Forms.ComboBox()
        Me.cbTemperatureFormat = New System.Windows.Forms.ComboBox()
        Me.chkAlwaysShowGridlines = New System.Windows.Forms.CheckBox()
        Me.chkLandscapeSmoothing = New System.Windows.Forms.CheckBox()
        Me.chkSavePluginData = New System.Windows.Forms.CheckBox()
        Me.laFullscreenMode = New System.Windows.Forms.Label()
        Me.cbFullscreenMode = New System.Windows.Forms.ComboBox()
        Me.laFullscreenWidth = New System.Windows.Forms.Label()
        Me.numFullscreenWidth = New System.Windows.Forms.NumericUpDown()
        Me.numFullscreenHeight = New System.Windows.Forms.NumericUpDown()
        Me.laFullscreenHeight = New System.Windows.Forms.Label()
        Me.laLanguage = New System.Windows.Forms.Label()
        Me.cbLanguage = New System.Windows.Forms.ComboBox()
        Me.laTitleMusic = New System.Windows.Forms.Label()
        Me.cbTitleMusic = New System.Windows.Forms.ComboBox()
        Me.laSoundQuality = New System.Windows.Forms.Label()
        Me.cbSoundQuality = New System.Windows.Forms.ComboBox()
        Me.chkForcedSoftwareBuffering = New System.Windows.Forms.CheckBox()
        Me.cbConstructionMarkerColour = New System.Windows.Forms.ComboBox()
        Me.laConstructionMarkerColour = New System.Windows.Forms.Label()
        Me.numWindowHeight = New System.Windows.Forms.NumericUpDown()
        Me.numWindowWidth = New System.Windows.Forms.NumericUpDown()
        Me.laWindowHeight = New System.Windows.Forms.Label()
        Me.laWindowWidth = New System.Windows.Forms.Label()
        Me.cbShowHeightAsUnits = New System.Windows.Forms.ComboBox()
        Me.laShowHeightAsUnits = New System.Windows.Forms.Label()
        Me.chkRideMusic = New System.Windows.Forms.CheckBox()
        Me.chkSound = New System.Windows.Forms.CheckBox()
        Me.numWindowSnapProximity = New System.Windows.Forms.NumericUpDown()
        Me.laWindowSnapProximity = New System.Windows.Forms.Label()
        Me.cbAutosave = New System.Windows.Forms.ComboBox()
        Me.laAutosave = New System.Windows.Forms.Label()
        Me.cmdOk = New System.Windows.Forms.Button()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdReset = New System.Windows.Forms.Button()
        Me.FBD = New System.Windows.Forms.FolderBrowserDialog()
        Me.laArguments = New System.Windows.Forms.Label()
        Me.tbArguments = New System.Windows.Forms.TextBox()
        Me.cmdOutputPath = New System.Windows.Forms.Button()
        Me.tbOutputPath = New System.Windows.Forms.TextBox()
        Me.laOutputPath = New System.Windows.Forms.Label()
        Me.chkSaveOutput = New System.Windows.Forms.CheckBox()
        Me.chkVerbose = New System.Windows.Forms.CheckBox()
        Me.SFD = New System.Windows.Forms.SaveFileDialog()
        Me.chkInstallUpdates = New System.Windows.Forms.CheckBox()
        Me.chkCheckUpdates = New System.Windows.Forms.CheckBox()
        Me.tcMain = New System.Windows.Forms.TabControl()
        Me.Graphics = New System.Windows.Forms.TabPage()
        Me.chkHardwareDisplay = New System.Windows.Forms.CheckBox()
        Me.Localisation = New System.Windows.Forms.TabPage()
        Me.cbDateFormat = New System.Windows.Forms.ComboBox()
        Me.laDateFormat = New System.Windows.Forms.Label()
        Me.Sound = New System.Windows.Forms.TabPage()
        Me.GUI = New System.Windows.Forms.TabPage()
        Me.chkConsoleSmallFont = New System.Windows.Forms.CheckBox()
        Me.chkRCT1ColourScheme = New System.Windows.Forms.CheckBox()
        Me.chkToolbarShowCheats = New System.Windows.Forms.CheckBox()
        Me.chkToolbarShowResearch = New System.Windows.Forms.CheckBox()
        Me.chkToolbarShowFinances = New System.Windows.Forms.CheckBox()
        Me.Cheats = New System.Windows.Forms.TabPage()
        Me.chkUnlockAllPrices = New System.Windows.Forms.CheckBox()
        Me.chkDisableAllBreakdowns = New System.Windows.Forms.CheckBox()
        Me.chkDisableBrakesFailure = New System.Windows.Forms.CheckBox()
        Me.chkFastLiftHill = New System.Windows.Forms.CheckBox()
        Me.Launcher = New System.Windows.Forms.TabPage()
        Me.Debugging = New System.Windows.Forms.TabPage()
        Me.Twitch = New System.Windows.Forms.TabPage()
        Me.chkNews = New System.Windows.Forms.CheckBox()
        Me.chkChatPeepTracking = New System.Windows.Forms.CheckBox()
        Me.chkChatPeepNames = New System.Windows.Forms.CheckBox()
        Me.chkFollowerPeepTracking = New System.Windows.Forms.CheckBox()
        Me.chkFollowerPeepNames = New System.Windows.Forms.CheckBox()
        Me.tbChannel = New System.Windows.Forms.TextBox()
        Me.laChannel = New System.Windows.Forms.Label()
        Me.Miscellaneous = New System.Windows.Forms.TabPage()
        Me.chkNoTestCrashes = New System.Windows.Forms.CheckBox()
        Me.chkTestUnfinishedTracks = New System.Windows.Forms.CheckBox()
        Me.chkDebuggingTools = New System.Windows.Forms.CheckBox()
        Me.chkAllowSubtypeSwitching = New System.Windows.Forms.CheckBox()
        CType(Me.numFullscreenWidth,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.numFullscreenHeight,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.numWindowHeight,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.numWindowWidth,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.numWindowSnapProximity,System.ComponentModel.ISupportInitialize).BeginInit
        Me.tcMain.SuspendLayout
        Me.Graphics.SuspendLayout
        Me.Localisation.SuspendLayout
        Me.Sound.SuspendLayout
        Me.GUI.SuspendLayout
        Me.Cheats.SuspendLayout
        Me.Launcher.SuspendLayout
        Me.Debugging.SuspendLayout
        Me.Twitch.SuspendLayout
        Me.Miscellaneous.SuspendLayout
        Me.SuspendLayout
        '
        'tbGamePath
        '
        Me.tbGamePath.Location = New System.Drawing.Point(3, 19)
        Me.tbGamePath.Name = "tbGamePath"
        Me.tbGamePath.Size = New System.Drawing.Size(447, 20)
        Me.tbGamePath.TabIndex = 0
        '
        'cmdGamePath
        '
        Me.cmdGamePath.Location = New System.Drawing.Point(456, 17)
        Me.cmdGamePath.Name = "cmdGamePath"
        Me.cmdGamePath.Size = New System.Drawing.Size(30, 23)
        Me.cmdGamePath.TabIndex = 1
        Me.cmdGamePath.Text = "..."
        Me.cmdGamePath.UseVisualStyleBackColor = true
        '
        'laGamePath
        '
        Me.laGamePath.AutoSize = true
        Me.laGamePath.Location = New System.Drawing.Point(3, 3)
        Me.laGamePath.Name = "laGamePath"
        Me.laGamePath.Size = New System.Drawing.Size(63, 13)
        Me.laGamePath.TabIndex = 2
        Me.laGamePath.Text = "Game Path:"
        '
        'laScreenshotFormat
        '
        Me.laScreenshotFormat.AutoSize = true
        Me.laScreenshotFormat.Location = New System.Drawing.Point(247, 3)
        Me.laScreenshotFormat.Name = "laScreenshotFormat"
        Me.laScreenshotFormat.Size = New System.Drawing.Size(99, 13)
        Me.laScreenshotFormat.TabIndex = 3
        Me.laScreenshotFormat.Text = "Screenshot Format:"
        '
        'cbScreenshotFormat
        '
        Me.cbScreenshotFormat.DisplayMember = "1"
        Me.cbScreenshotFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbScreenshotFormat.FormattingEnabled = true
        Me.cbScreenshotFormat.Items.AddRange(New Object() {"*.bmp", "*.png"})
        Me.cbScreenshotFormat.Location = New System.Drawing.Point(247, 19)
        Me.cbScreenshotFormat.Name = "cbScreenshotFormat"
        Me.cbScreenshotFormat.Size = New System.Drawing.Size(242, 21)
        Me.cbScreenshotFormat.TabIndex = 4
        '
        'chkPlayIntro
        '
        Me.chkPlayIntro.AutoSize = true
        Me.chkPlayIntro.Location = New System.Drawing.Point(247, 92)
        Me.chkPlayIntro.Name = "chkPlayIntro"
        Me.chkPlayIntro.Size = New System.Drawing.Size(70, 17)
        Me.chkPlayIntro.TabIndex = 5
        Me.chkPlayIntro.Text = Global.Launcher.My.Resources.Resources.frmOptions_playIntroButton_label
        Me.chkPlayIntro.UseVisualStyleBackColor = true
        '
        'chkConfirmationPrompt
        '
        Me.chkConfirmationPrompt.AutoSize = true
        Me.chkConfirmationPrompt.Location = New System.Drawing.Point(3, 115)
        Me.chkConfirmationPrompt.Name = "chkConfirmationPrompt"
        Me.chkConfirmationPrompt.Size = New System.Drawing.Size(150, 17)
        Me.chkConfirmationPrompt.TabIndex = 6
        Me.chkConfirmationPrompt.Text = Global.Launcher.My.Resources.Resources.frmOptions_showConfirmationPrompt_label
        Me.chkConfirmationPrompt.UseVisualStyleBackColor = true
        '
        'chkEdgeScrolling
        '
        Me.chkEdgeScrolling.AutoSize = true
        Me.chkEdgeScrolling.Location = New System.Drawing.Point(3, 45)
        Me.chkEdgeScrolling.Name = "chkEdgeScrolling"
        Me.chkEdgeScrolling.Size = New System.Drawing.Size(215, 17)
        Me.chkEdgeScrolling.TabIndex = 7
        Me.chkEdgeScrolling.Text = Global.Launcher.My.Resources.Resources.frmOptions_edgeScrolling_label
        Me.chkEdgeScrolling.UseVisualStyleBackColor = true
        '
        'laCurrency
        '
        Me.laCurrency.AutoSize = true
        Me.laCurrency.Location = New System.Drawing.Point(247, 3)
        Me.laCurrency.Name = "laCurrency"
        Me.laCurrency.Size = New System.Drawing.Size(52, 13)
        Me.laCurrency.TabIndex = 8
        Me.laCurrency.Text = "Currency:"
        '
        'cbCurrency
        '
        Me.cbCurrency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbCurrency.FormattingEnabled = true
        Me.cbCurrency.Items.AddRange(New Object() {Global.Launcher.My.Resources.Resources.frmOptions_currency_pound, Global.Launcher.My.Resources.Resources.frmOptions_currency_dollar, Global.Launcher.My.Resources.Resources.frmOptions_currency_franc, Global.Launcher.My.Resources.Resources.frmOptions_currency_deutchmark, Global.Launcher.My.Resources.Resources.frmOptions_currency_yen, Global.Launcher.My.Resources.Resources.frmOptions_currency_peseta, Global.Launcher.My.Resources.Resources.frmOptions_currency_lira, Global.Launcher.My.Resources.Resources.frmOptions_currency_guilder, Global.Launcher.My.Resources.Resources.frmOptions_currency_krona, Global.Launcher.My.Resources.Resources.frmOptions_currency_euro})
        Me.cbCurrency.Location = New System.Drawing.Point(247, 19)
        Me.cbCurrency.Name = "cbCurrency"
        Me.cbCurrency.Size = New System.Drawing.Size(242, 21)
        Me.cbCurrency.TabIndex = 9
        '
        'laMeasurementFormat
        '
        Me.laMeasurementFormat.AutoSize = true
        Me.laMeasurementFormat.Location = New System.Drawing.Point(3, 43)
        Me.laMeasurementFormat.Name = "laMeasurementFormat"
        Me.laMeasurementFormat.Size = New System.Drawing.Size(107, 13)
        Me.laMeasurementFormat.TabIndex = 10
        Me.laMeasurementFormat.Text = "Distance and Speed:"
        '
        'laTemperatureFormat
        '
        Me.laTemperatureFormat.AutoSize = true
        Me.laTemperatureFormat.Location = New System.Drawing.Point(247, 43)
        Me.laTemperatureFormat.Name = "laTemperatureFormat"
        Me.laTemperatureFormat.Size = New System.Drawing.Size(70, 13)
        Me.laTemperatureFormat.TabIndex = 11
        Me.laTemperatureFormat.Text = "Temperature:"
        '
        'cbMeasurementFormat
        '
        Me.cbMeasurementFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbMeasurementFormat.FormattingEnabled = true
        Me.cbMeasurementFormat.Items.AddRange(New Object() {Global.Launcher.My.Resources.Resources.frmOptions_distSpeed_imperial, Global.Launcher.My.Resources.Resources.frmOptions_distSpeed_metric})
        Me.cbMeasurementFormat.Location = New System.Drawing.Point(3, 59)
        Me.cbMeasurementFormat.Name = "cbMeasurementFormat"
        Me.cbMeasurementFormat.Size = New System.Drawing.Size(237, 21)
        Me.cbMeasurementFormat.TabIndex = 12
        '
        'cbTemperatureFormat
        '
        Me.cbTemperatureFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbTemperatureFormat.FormattingEnabled = true
        Me.cbTemperatureFormat.Items.AddRange(New Object() {Global.Launcher.My.Resources.Resources.frmOptions_temperature_celsius, Global.Launcher.My.Resources.Resources.frmOptions_temperature_fahrenheit})
        Me.cbTemperatureFormat.Location = New System.Drawing.Point(247, 59)
        Me.cbTemperatureFormat.Name = "cbTemperatureFormat"
        Me.cbTemperatureFormat.Size = New System.Drawing.Size(242, 21)
        Me.cbTemperatureFormat.TabIndex = 13
        '
        'chkAlwaysShowGridlines
        '
        Me.chkAlwaysShowGridlines.AutoSize = true
        Me.chkAlwaysShowGridlines.Location = New System.Drawing.Point(247, 124)
        Me.chkAlwaysShowGridlines.Name = "chkAlwaysShowGridlines"
        Me.chkAlwaysShowGridlines.Size = New System.Drawing.Size(137, 17)
        Me.chkAlwaysShowGridlines.TabIndex = 14
        Me.chkAlwaysShowGridlines.Text = Global.Launcher.My.Resources.Resources.frmOptions_alwaysGridLines_label
        Me.chkAlwaysShowGridlines.UseVisualStyleBackColor = true
        '
        'chkLandscapeSmoothing
        '
        Me.chkLandscapeSmoothing.AutoSize = true
        Me.chkLandscapeSmoothing.Location = New System.Drawing.Point(3, 124)
        Me.chkLandscapeSmoothing.Name = "chkLandscapeSmoothing"
        Me.chkLandscapeSmoothing.Size = New System.Drawing.Size(132, 17)
        Me.chkLandscapeSmoothing.TabIndex = 15
        Me.chkLandscapeSmoothing.Text = Global.Launcher.My.Resources.Resources.frmOptions_landscapeSmoothing_label
        Me.chkLandscapeSmoothing.UseVisualStyleBackColor = true
        '
        'chkSavePluginData
        '
        Me.chkSavePluginData.AutoSize = true
        Me.chkSavePluginData.Location = New System.Drawing.Point(3, 46)
        Me.chkSavePluginData.Name = "chkSavePluginData"
        Me.chkSavePluginData.Size = New System.Drawing.Size(215, 17)
        Me.chkSavePluginData.TabIndex = 17
        Me.chkSavePluginData.Text = Global.Launcher.My.Resources.Resources.frmOptions_savePluginData_label
        Me.chkSavePluginData.UseVisualStyleBackColor = true
        '
        'laFullscreenMode
        '
        Me.laFullscreenMode.AutoSize = true
        Me.laFullscreenMode.Location = New System.Drawing.Point(3, 3)
        Me.laFullscreenMode.Name = "laFullscreenMode"
        Me.laFullscreenMode.Size = New System.Drawing.Size(87, 13)
        Me.laFullscreenMode.TabIndex = 18
        Me.laFullscreenMode.Text = "Fullscreen mode:"
        '
        'cbFullscreenMode
        '
        Me.cbFullscreenMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbFullscreenMode.FormattingEnabled = true
        Me.cbFullscreenMode.Items.AddRange(New Object() {Global.Launcher.My.Resources.Resources.frmOptions_fullscreenMode_windowed, Global.Launcher.My.Resources.Resources.frmOptions_fullscreenMode_fullscreen, Global.Launcher.My.Resources.Resources.frmOptions_fullscreenMode_fullscreenDesktop})
        Me.cbFullscreenMode.Location = New System.Drawing.Point(3, 19)
        Me.cbFullscreenMode.Name = "cbFullscreenMode"
        Me.cbFullscreenMode.Size = New System.Drawing.Size(238, 21)
        Me.cbFullscreenMode.TabIndex = 19
        '
        'laFullscreenWidth
        '
        Me.laFullscreenWidth.AutoSize = true
        Me.laFullscreenWidth.Location = New System.Drawing.Point(3, 43)
        Me.laFullscreenWidth.Name = "laFullscreenWidth"
        Me.laFullscreenWidth.Size = New System.Drawing.Size(86, 13)
        Me.laFullscreenWidth.TabIndex = 20
        Me.laFullscreenWidth.Text = "Fullscreen width:"
        '
        'numFullscreenWidth
        '
        Me.numFullscreenWidth.Increment = New Decimal(New Integer() {100, 0, 0, 0})
        Me.numFullscreenWidth.Location = New System.Drawing.Point(3, 59)
        Me.numFullscreenWidth.Maximum = New Decimal(New Integer() {-2147483648, 0, 0, 0})
        Me.numFullscreenWidth.Minimum = New Decimal(New Integer() {1, 0, 0, -2147483648})
        Me.numFullscreenWidth.Name = "numFullscreenWidth"
        Me.numFullscreenWidth.Size = New System.Drawing.Size(238, 20)
        Me.numFullscreenWidth.TabIndex = 22
        '
        'numFullscreenHeight
        '
        Me.numFullscreenHeight.Increment = New Decimal(New Integer() {100, 0, 0, 0})
        Me.numFullscreenHeight.Location = New System.Drawing.Point(247, 59)
        Me.numFullscreenHeight.Maximum = New Decimal(New Integer() {-2147483648, 0, 0, 0})
        Me.numFullscreenHeight.Minimum = New Decimal(New Integer() {1, 0, 0, -2147483648})
        Me.numFullscreenHeight.Name = "numFullscreenHeight"
        Me.numFullscreenHeight.Size = New System.Drawing.Size(239, 20)
        Me.numFullscreenHeight.TabIndex = 24
        '
        'laFullscreenHeight
        '
        Me.laFullscreenHeight.AutoSize = true
        Me.laFullscreenHeight.Location = New System.Drawing.Point(247, 43)
        Me.laFullscreenHeight.Name = "laFullscreenHeight"
        Me.laFullscreenHeight.Size = New System.Drawing.Size(90, 13)
        Me.laFullscreenHeight.TabIndex = 23
        Me.laFullscreenHeight.Text = "Fullscreen height:"
        '
        'laLanguage
        '
        Me.laLanguage.AutoSize = true
        Me.laLanguage.Location = New System.Drawing.Point(3, 3)
        Me.laLanguage.Name = "laLanguage"
        Me.laLanguage.Size = New System.Drawing.Size(58, 13)
        Me.laLanguage.TabIndex = 25
        Me.laLanguage.Text = "Language:"
        '
        'cbLanguage
        '
        Me.cbLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbLanguage.FormattingEnabled = true
        Me.cbLanguage.Items.AddRange(New Object() {"English (UK)", "English (US)", "Deutsch", "Nederlands", "Français", "Magyar", "Polski", "Español", "Svenska"})
        Me.cbLanguage.Location = New System.Drawing.Point(3, 19)
        Me.cbLanguage.Name = "cbLanguage"
        Me.cbLanguage.Size = New System.Drawing.Size(238, 21)
        Me.cbLanguage.TabIndex = 26
        '
        'laTitleMusic
        '
        Me.laTitleMusic.AutoSize = true
        Me.laTitleMusic.Location = New System.Drawing.Point(246, 3)
        Me.laTitleMusic.Name = "laTitleMusic"
        Me.laTitleMusic.Size = New System.Drawing.Size(95, 13)
        Me.laTitleMusic.TabIndex = 27
        Me.laTitleMusic.Text = "Title screen music:"
        '
        'cbTitleMusic
        '
        Me.cbTitleMusic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbTitleMusic.FormattingEnabled = true
        Me.cbTitleMusic.Items.AddRange(New Object() {Global.Launcher.My.Resources.Resources.frmOptions_titleScreenMusic_none, Global.Launcher.My.Resources.Resources.frmOptions_titleScreenMusic_RCT1, Global.Launcher.My.Resources.Resources.frmOptions_titleScreenMusic_RCT2})
        Me.cbTitleMusic.Location = New System.Drawing.Point(247, 19)
        Me.cbTitleMusic.Name = "cbTitleMusic"
        Me.cbTitleMusic.Size = New System.Drawing.Size(242, 21)
        Me.cbTitleMusic.TabIndex = 28
        '
        'laSoundQuality
        '
        Me.laSoundQuality.AutoSize = true
        Me.laSoundQuality.Location = New System.Drawing.Point(3, 3)
        Me.laSoundQuality.Name = "laSoundQuality"
        Me.laSoundQuality.Size = New System.Drawing.Size(76, 13)
        Me.laSoundQuality.TabIndex = 29
        Me.laSoundQuality.Text = "Sound Quality:"
        '
        'cbSoundQuality
        '
        Me.cbSoundQuality.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbSoundQuality.FormattingEnabled = true
        Me.cbSoundQuality.Items.AddRange(New Object() {Global.Launcher.My.Resources.Resources.frmOptions_soundQuality_low, Global.Launcher.My.Resources.Resources.frmOptions_soundQuality_medium, Global.Launcher.My.Resources.Resources.frmOptions_soundQuality_high})
        Me.cbSoundQuality.Location = New System.Drawing.Point(3, 19)
        Me.cbSoundQuality.Name = "cbSoundQuality"
        Me.cbSoundQuality.Size = New System.Drawing.Size(238, 21)
        Me.cbSoundQuality.TabIndex = 30
        '
        'chkForcedSoftwareBuffering
        '
        Me.chkForcedSoftwareBuffering.AutoSize = true
        Me.chkForcedSoftwareBuffering.Location = New System.Drawing.Point(3, 69)
        Me.chkForcedSoftwareBuffering.Name = "chkForcedSoftwareBuffering"
        Me.chkForcedSoftwareBuffering.Size = New System.Drawing.Size(168, 17)
        Me.chkForcedSoftwareBuffering.TabIndex = 31
        Me.chkForcedSoftwareBuffering.Text = Global.Launcher.My.Resources.Resources.frmOptions_forcedSoftwareBuffering_label
        Me.chkForcedSoftwareBuffering.UseVisualStyleBackColor = true
        '
        'cbConstructionMarkerColour
        '
        Me.cbConstructionMarkerColour.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbConstructionMarkerColour.FormattingEnabled = true
        Me.cbConstructionMarkerColour.Items.AddRange(New Object() {"White", "Translucent"})
        Me.cbConstructionMarkerColour.Location = New System.Drawing.Point(247, 19)
        Me.cbConstructionMarkerColour.Name = "cbConstructionMarkerColour"
        Me.cbConstructionMarkerColour.Size = New System.Drawing.Size(239, 21)
        Me.cbConstructionMarkerColour.TabIndex = 29
        '
        'laConstructionMarkerColour
        '
        Me.laConstructionMarkerColour.AutoSize = true
        Me.laConstructionMarkerColour.Location = New System.Drawing.Point(247, 3)
        Me.laConstructionMarkerColour.Name = "laConstructionMarkerColour"
        Me.laConstructionMarkerColour.Size = New System.Drawing.Size(105, 13)
        Me.laConstructionMarkerColour.TabIndex = 29
        Me.laConstructionMarkerColour.Text = "Construction Marker:"
        '
        'numWindowHeight
        '
        Me.numWindowHeight.Increment = New Decimal(New Integer() {100, 0, 0, 0})
        Me.numWindowHeight.Location = New System.Drawing.Point(247, 98)
        Me.numWindowHeight.Maximum = New Decimal(New Integer() {-2147483648, 0, 0, 0})
        Me.numWindowHeight.Minimum = New Decimal(New Integer() {1, 0, 0, -2147483648})
        Me.numWindowHeight.Name = "numWindowHeight"
        Me.numWindowHeight.Size = New System.Drawing.Size(239, 20)
        Me.numWindowHeight.TabIndex = 28
        '
        'numWindowWidth
        '
        Me.numWindowWidth.Increment = New Decimal(New Integer() {100, 0, 0, 0})
        Me.numWindowWidth.Location = New System.Drawing.Point(3, 98)
        Me.numWindowWidth.Maximum = New Decimal(New Integer() {-2147483648, 0, 0, 0})
        Me.numWindowWidth.Minimum = New Decimal(New Integer() {1, 0, 0, -2147483648})
        Me.numWindowWidth.Name = "numWindowWidth"
        Me.numWindowWidth.Size = New System.Drawing.Size(238, 20)
        Me.numWindowWidth.TabIndex = 27
        '
        'laWindowHeight
        '
        Me.laWindowHeight.AutoSize = true
        Me.laWindowHeight.Location = New System.Drawing.Point(247, 82)
        Me.laWindowHeight.Name = "laWindowHeight"
        Me.laWindowHeight.Size = New System.Drawing.Size(81, 13)
        Me.laWindowHeight.TabIndex = 26
        Me.laWindowHeight.Text = "Window height:"
        '
        'laWindowWidth
        '
        Me.laWindowWidth.AutoSize = true
        Me.laWindowWidth.Location = New System.Drawing.Point(3, 82)
        Me.laWindowWidth.Name = "laWindowWidth"
        Me.laWindowWidth.Size = New System.Drawing.Size(77, 13)
        Me.laWindowWidth.TabIndex = 25
        Me.laWindowWidth.Text = "Window width:"
        '
        'cbShowHeightAsUnits
        '
        Me.cbShowHeightAsUnits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbShowHeightAsUnits.FormattingEnabled = true
        Me.cbShowHeightAsUnits.Items.AddRange(New Object() {Global.Launcher.My.Resources.Resources.frmOptions_heightLabels_units, Global.Launcher.My.Resources.Resources.frmOptions_heightLabels_real})
        Me.cbShowHeightAsUnits.Location = New System.Drawing.Point(3, 99)
        Me.cbShowHeightAsUnits.Name = "cbShowHeightAsUnits"
        Me.cbShowHeightAsUnits.Size = New System.Drawing.Size(237, 21)
        Me.cbShowHeightAsUnits.TabIndex = 28
        '
        'laShowHeightAsUnits
        '
        Me.laShowHeightAsUnits.AutoSize = true
        Me.laShowHeightAsUnits.Location = New System.Drawing.Point(3, 83)
        Me.laShowHeightAsUnits.Name = "laShowHeightAsUnits"
        Me.laShowHeightAsUnits.Size = New System.Drawing.Size(75, 13)
        Me.laShowHeightAsUnits.TabIndex = 27
        Me.laShowHeightAsUnits.Text = "Height Labels:"
        '
        'chkRideMusic
        '
        Me.chkRideMusic.AutoSize = true
        Me.chkRideMusic.Location = New System.Drawing.Point(3, 46)
        Me.chkRideMusic.Name = "chkRideMusic"
        Me.chkRideMusic.Size = New System.Drawing.Size(79, 17)
        Me.chkRideMusic.TabIndex = 33
        Me.chkRideMusic.Text = "Ride Music"
        Me.chkRideMusic.UseVisualStyleBackColor = true
        '
        'chkSound
        '
        Me.chkSound.AutoSize = true
        Me.chkSound.Location = New System.Drawing.Point(246, 46)
        Me.chkSound.Name = "chkSound"
        Me.chkSound.Size = New System.Drawing.Size(57, 17)
        Me.chkSound.TabIndex = 32
        Me.chkSound.Text = "Sound"
        Me.chkSound.UseVisualStyleBackColor = true
        '
        'numWindowSnapProximity
        '
        Me.numWindowSnapProximity.Increment = New Decimal(New Integer() {10, 0, 0, 0})
        Me.numWindowSnapProximity.Location = New System.Drawing.Point(3, 19)
        Me.numWindowSnapProximity.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        Me.numWindowSnapProximity.Name = "numWindowSnapProximity"
        Me.numWindowSnapProximity.Size = New System.Drawing.Size(486, 20)
        Me.numWindowSnapProximity.TabIndex = 28
        '
        'laWindowSnapProximity
        '
        Me.laWindowSnapProximity.AutoSize = true
        Me.laWindowSnapProximity.Location = New System.Drawing.Point(3, 3)
        Me.laWindowSnapProximity.Name = "laWindowSnapProximity"
        Me.laWindowSnapProximity.Size = New System.Drawing.Size(118, 13)
        Me.laWindowSnapProximity.TabIndex = 20
        Me.laWindowSnapProximity.Text = "Window snap proximity:"
        '
        'cbAutosave
        '
        Me.cbAutosave.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbAutosave.FormattingEnabled = true
        Me.cbAutosave.Items.AddRange(New Object() {"Every week", "Every 2 weeks", "Every month", "Every 4 months", "Every year", "Never"})
        Me.cbAutosave.Location = New System.Drawing.Point(3, 19)
        Me.cbAutosave.Name = "cbAutosave"
        Me.cbAutosave.Size = New System.Drawing.Size(238, 21)
        Me.cbAutosave.TabIndex = 19
        '
        'laAutosave
        '
        Me.laAutosave.AutoSize = true
        Me.laAutosave.Location = New System.Drawing.Point(3, 3)
        Me.laAutosave.Name = "laAutosave"
        Me.laAutosave.Size = New System.Drawing.Size(105, 13)
        Me.laAutosave.TabIndex = 18
        Me.laAutosave.Text = "Autosave frequency:"
        '
        'cmdOk
        '
        Me.cmdOk.Location = New System.Drawing.Point(12, 214)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.Size = New System.Drawing.Size(163, 23)
        Me.cmdOk.TabIndex = 36
        Me.cmdOk.Text = Global.Launcher.My.Resources.Resources.common_ok
        Me.cmdOk.UseVisualStyleBackColor = true
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(181, 214)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(163, 23)
        Me.cmdCancel.TabIndex = 37
        Me.cmdCancel.Text = Global.Launcher.My.Resources.Resources.common_cancel
        Me.cmdCancel.UseVisualStyleBackColor = true
        '
        'cmdReset
        '
        Me.cmdReset.Location = New System.Drawing.Point(350, 214)
        Me.cmdReset.Name = "cmdReset"
        Me.cmdReset.Size = New System.Drawing.Size(162, 23)
        Me.cmdReset.TabIndex = 40
        Me.cmdReset.Text = Global.Launcher.My.Resources.Resources.common_reset
        Me.cmdReset.UseVisualStyleBackColor = true
        '
        'laArguments
        '
        Me.laArguments.AutoSize = true
        Me.laArguments.Location = New System.Drawing.Point(3, 23)
        Me.laArguments.Name = "laArguments"
        Me.laArguments.Size = New System.Drawing.Size(60, 13)
        Me.laArguments.TabIndex = 6
        Me.laArguments.Text = "Arguments:"
        '
        'tbArguments
        '
        Me.tbArguments.Location = New System.Drawing.Point(3, 39)
        Me.tbArguments.Name = "tbArguments"
        Me.tbArguments.Size = New System.Drawing.Size(238, 20)
        Me.tbArguments.TabIndex = 5
        '
        'cmdOutputPath
        '
        Me.cmdOutputPath.Location = New System.Drawing.Point(459, 37)
        Me.cmdOutputPath.Name = "cmdOutputPath"
        Me.cmdOutputPath.Size = New System.Drawing.Size(30, 23)
        Me.cmdOutputPath.TabIndex = 4
        Me.cmdOutputPath.Text = "..."
        Me.cmdOutputPath.UseVisualStyleBackColor = true
        '
        'tbOutputPath
        '
        Me.tbOutputPath.Location = New System.Drawing.Point(247, 39)
        Me.tbOutputPath.Name = "tbOutputPath"
        Me.tbOutputPath.Size = New System.Drawing.Size(206, 20)
        Me.tbOutputPath.TabIndex = 3
        '
        'laOutputPath
        '
        Me.laOutputPath.AutoSize = true
        Me.laOutputPath.Location = New System.Drawing.Point(247, 23)
        Me.laOutputPath.Name = "laOutputPath"
        Me.laOutputPath.Size = New System.Drawing.Size(67, 13)
        Me.laOutputPath.TabIndex = 2
        Me.laOutputPath.Text = "Output Path:"
        '
        'chkSaveOutput
        '
        Me.chkSaveOutput.AutoSize = true
        Me.chkSaveOutput.Location = New System.Drawing.Point(247, 3)
        Me.chkSaveOutput.Name = "chkSaveOutput"
        Me.chkSaveOutput.Size = New System.Drawing.Size(117, 17)
        Me.chkSaveOutput.TabIndex = 1
        Me.chkSaveOutput.Text = Global.Launcher.My.Resources.Resources.frmOptions_saveOutputFile_label
        Me.chkSaveOutput.UseVisualStyleBackColor = true
        '
        'chkVerbose
        '
        Me.chkVerbose.AutoSize = true
        Me.chkVerbose.Location = New System.Drawing.Point(3, 3)
        Me.chkVerbose.Name = "chkVerbose"
        Me.chkVerbose.Size = New System.Drawing.Size(100, 17)
        Me.chkVerbose.TabIndex = 0
        Me.chkVerbose.Text = Global.Launcher.My.Resources.Resources.frmLauncher_verboseOutputButton_text
        Me.chkVerbose.UseVisualStyleBackColor = true
        '
        'chkInstallUpdates
        '
        Me.chkInstallUpdates.AutoSize = true
        Me.chkInstallUpdates.Location = New System.Drawing.Point(247, 45)
        Me.chkInstallUpdates.Name = "chkInstallUpdates"
        Me.chkInstallUpdates.Size = New System.Drawing.Size(158, 17)
        Me.chkInstallUpdates.TabIndex = 1
        Me.chkInstallUpdates.Text = "Install updates automatically"
        Me.chkInstallUpdates.UseVisualStyleBackColor = true
        '
        'chkCheckUpdates
        '
        Me.chkCheckUpdates.AutoSize = true
        Me.chkCheckUpdates.Location = New System.Drawing.Point(3, 45)
        Me.chkCheckUpdates.Name = "chkCheckUpdates"
        Me.chkCheckUpdates.Size = New System.Drawing.Size(177, 17)
        Me.chkCheckUpdates.TabIndex = 0
        Me.chkCheckUpdates.Text = "Check for updates automatically"
        Me.chkCheckUpdates.UseVisualStyleBackColor = true
        '
        'tcMain
        '
        Me.tcMain.Controls.Add(Me.Graphics)
        Me.tcMain.Controls.Add(Me.Localisation)
        Me.tcMain.Controls.Add(Me.Sound)
        Me.tcMain.Controls.Add(Me.GUI)
        Me.tcMain.Controls.Add(Me.Cheats)
        Me.tcMain.Controls.Add(Me.Launcher)
        Me.tcMain.Controls.Add(Me.Debugging)
        Me.tcMain.Controls.Add(Me.Twitch)
        Me.tcMain.Controls.Add(Me.Miscellaneous)
        Me.tcMain.Location = New System.Drawing.Point(12, 12)
        Me.tcMain.Name = "tcMain"
        Me.tcMain.SelectedIndex = 0
        Me.tcMain.Size = New System.Drawing.Size(500, 196)
        Me.tcMain.TabIndex = 43
        '
        'Graphics
        '
        Me.Graphics.Controls.Add(Me.chkHardwareDisplay)
        Me.Graphics.Controls.Add(Me.cbConstructionMarkerColour)
        Me.Graphics.Controls.Add(Me.laFullscreenMode)
        Me.Graphics.Controls.Add(Me.cbFullscreenMode)
        Me.Graphics.Controls.Add(Me.laConstructionMarkerColour)
        Me.Graphics.Controls.Add(Me.numFullscreenWidth)
        Me.Graphics.Controls.Add(Me.numFullscreenHeight)
        Me.Graphics.Controls.Add(Me.numWindowHeight)
        Me.Graphics.Controls.Add(Me.laFullscreenHeight)
        Me.Graphics.Controls.Add(Me.laFullscreenWidth)
        Me.Graphics.Controls.Add(Me.numWindowWidth)
        Me.Graphics.Controls.Add(Me.laWindowHeight)
        Me.Graphics.Controls.Add(Me.chkAlwaysShowGridlines)
        Me.Graphics.Controls.Add(Me.laWindowWidth)
        Me.Graphics.Controls.Add(Me.chkLandscapeSmoothing)
        Me.Graphics.Location = New System.Drawing.Point(4, 22)
        Me.Graphics.Name = "Graphics"
        Me.Graphics.Padding = New System.Windows.Forms.Padding(3)
        Me.Graphics.Size = New System.Drawing.Size(492, 170)
        Me.Graphics.TabIndex = 1
        Me.Graphics.Text = "Graphics"
        Me.Graphics.UseVisualStyleBackColor = true
        '
        'chkHardwareDisplay
        '
        Me.chkHardwareDisplay.AutoSize = true
        Me.chkHardwareDisplay.Location = New System.Drawing.Point(3, 147)
        Me.chkHardwareDisplay.Name = "chkHardwareDisplay"
        Me.chkHardwareDisplay.Size = New System.Drawing.Size(107, 17)
        Me.chkHardwareDisplay.TabIndex = 30
        Me.chkHardwareDisplay.Text = "Hardware display"
        Me.chkHardwareDisplay.UseVisualStyleBackColor = true
        '
        'Localisation
        '
        Me.Localisation.Controls.Add(Me.cbDateFormat)
        Me.Localisation.Controls.Add(Me.laDateFormat)
        Me.Localisation.Controls.Add(Me.cbShowHeightAsUnits)
        Me.Localisation.Controls.Add(Me.laLanguage)
        Me.Localisation.Controls.Add(Me.cbLanguage)
        Me.Localisation.Controls.Add(Me.laShowHeightAsUnits)
        Me.Localisation.Controls.Add(Me.laCurrency)
        Me.Localisation.Controls.Add(Me.cbCurrency)
        Me.Localisation.Controls.Add(Me.laMeasurementFormat)
        Me.Localisation.Controls.Add(Me.laTemperatureFormat)
        Me.Localisation.Controls.Add(Me.cbTemperatureFormat)
        Me.Localisation.Controls.Add(Me.cbMeasurementFormat)
        Me.Localisation.Location = New System.Drawing.Point(4, 22)
        Me.Localisation.Name = "Localisation"
        Me.Localisation.Size = New System.Drawing.Size(492, 170)
        Me.Localisation.TabIndex = 2
        Me.Localisation.Text = "Localisation"
        Me.Localisation.UseVisualStyleBackColor = true
        '
        'cbDateFormat
        '
        Me.cbDateFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbDateFormat.FormattingEnabled = true
        Me.cbDateFormat.Items.AddRange(New Object() {"Day/Month/Year", "Month/Day/Year"})
        Me.cbDateFormat.Location = New System.Drawing.Point(247, 99)
        Me.cbDateFormat.Name = "cbDateFormat"
        Me.cbDateFormat.Size = New System.Drawing.Size(242, 21)
        Me.cbDateFormat.TabIndex = 30
        '
        'laDateFormat
        '
        Me.laDateFormat.AutoSize = true
        Me.laDateFormat.Location = New System.Drawing.Point(247, 83)
        Me.laDateFormat.Name = "laDateFormat"
        Me.laDateFormat.Size = New System.Drawing.Size(65, 13)
        Me.laDateFormat.TabIndex = 29
        Me.laDateFormat.Text = "Date Format"
        '
        'Sound
        '
        Me.Sound.Controls.Add(Me.chkRideMusic)
        Me.Sound.Controls.Add(Me.chkSound)
        Me.Sound.Controls.Add(Me.laSoundQuality)
        Me.Sound.Controls.Add(Me.cbSoundQuality)
        Me.Sound.Controls.Add(Me.cbTitleMusic)
        Me.Sound.Controls.Add(Me.laTitleMusic)
        Me.Sound.Controls.Add(Me.chkForcedSoftwareBuffering)
        Me.Sound.Location = New System.Drawing.Point(4, 22)
        Me.Sound.Name = "Sound"
        Me.Sound.Size = New System.Drawing.Size(492, 170)
        Me.Sound.TabIndex = 3
        Me.Sound.Text = "Sound"
        Me.Sound.UseVisualStyleBackColor = true
        '
        'GUI
        '
        Me.GUI.Controls.Add(Me.chkConsoleSmallFont)
        Me.GUI.Controls.Add(Me.chkRCT1ColourScheme)
        Me.GUI.Controls.Add(Me.chkToolbarShowCheats)
        Me.GUI.Controls.Add(Me.numWindowSnapProximity)
        Me.GUI.Controls.Add(Me.chkToolbarShowResearch)
        Me.GUI.Controls.Add(Me.laWindowSnapProximity)
        Me.GUI.Controls.Add(Me.chkToolbarShowFinances)
        Me.GUI.Controls.Add(Me.chkEdgeScrolling)
        Me.GUI.Location = New System.Drawing.Point(4, 22)
        Me.GUI.Name = "GUI"
        Me.GUI.Size = New System.Drawing.Size(492, 170)
        Me.GUI.TabIndex = 4
        Me.GUI.Text = "GUI"
        Me.GUI.UseVisualStyleBackColor = true
        '
        'chkConsoleSmallFont
        '
        Me.chkConsoleSmallFont.AutoSize = true
        Me.chkConsoleSmallFont.Location = New System.Drawing.Point(247, 91)
        Me.chkConsoleSmallFont.Name = "chkConsoleSmallFont"
        Me.chkConsoleSmallFont.Size = New System.Drawing.Size(143, 17)
        Me.chkConsoleSmallFont.TabIndex = 29
        Me.chkConsoleSmallFont.Text = "Use small font in console"
        Me.chkConsoleSmallFont.UseVisualStyleBackColor = true
        '
        'chkRCT1ColourScheme
        '
        Me.chkRCT1ColourScheme.AutoSize = true
        Me.chkRCT1ColourScheme.Location = New System.Drawing.Point(3, 91)
        Me.chkRCT1ColourScheme.Name = "chkRCT1ColourScheme"
        Me.chkRCT1ColourScheme.Size = New System.Drawing.Size(120, 17)
        Me.chkRCT1ColourScheme.TabIndex = 11
        Me.chkRCT1ColourScheme.Text = "RCT1 colour sheme"
        Me.chkRCT1ColourScheme.UseVisualStyleBackColor = true
        '
        'chkToolbarShowCheats
        '
        Me.chkToolbarShowCheats.AutoSize = true
        Me.chkToolbarShowCheats.Location = New System.Drawing.Point(247, 68)
        Me.chkToolbarShowCheats.Name = "chkToolbarShowCheats"
        Me.chkToolbarShowCheats.Size = New System.Drawing.Size(171, 17)
        Me.chkToolbarShowCheats.TabIndex = 10
        Me.chkToolbarShowCheats.Text = "Show cheats button on toolbar"
        Me.chkToolbarShowCheats.UseVisualStyleBackColor = true
        '
        'chkToolbarShowResearch
        '
        Me.chkToolbarShowResearch.AutoSize = true
        Me.chkToolbarShowResearch.Location = New System.Drawing.Point(3, 68)
        Me.chkToolbarShowResearch.Name = "chkToolbarShowResearch"
        Me.chkToolbarShowResearch.Size = New System.Drawing.Size(180, 17)
        Me.chkToolbarShowResearch.TabIndex = 9
        Me.chkToolbarShowResearch.Text = "Show research button on toolbar"
        Me.chkToolbarShowResearch.UseVisualStyleBackColor = true
        '
        'chkToolbarShowFinances
        '
        Me.chkToolbarShowFinances.AutoSize = true
        Me.chkToolbarShowFinances.Location = New System.Drawing.Point(247, 45)
        Me.chkToolbarShowFinances.Name = "chkToolbarShowFinances"
        Me.chkToolbarShowFinances.Size = New System.Drawing.Size(179, 17)
        Me.chkToolbarShowFinances.TabIndex = 8
        Me.chkToolbarShowFinances.Text = "Show finances button on toolbar"
        Me.chkToolbarShowFinances.UseVisualStyleBackColor = true
        '
        'Cheats
        '
        Me.Cheats.Controls.Add(Me.chkUnlockAllPrices)
        Me.Cheats.Controls.Add(Me.chkDisableAllBreakdowns)
        Me.Cheats.Controls.Add(Me.chkDisableBrakesFailure)
        Me.Cheats.Controls.Add(Me.chkFastLiftHill)
        Me.Cheats.Location = New System.Drawing.Point(4, 22)
        Me.Cheats.Name = "Cheats"
        Me.Cheats.Size = New System.Drawing.Size(492, 170)
        Me.Cheats.TabIndex = 7
        Me.Cheats.Text = "Cheats"
        Me.Cheats.UseVisualStyleBackColor = true
        '
        'chkUnlockAllPrices
        '
        Me.chkUnlockAllPrices.AutoSize = true
        Me.chkUnlockAllPrices.Location = New System.Drawing.Point(247, 26)
        Me.chkUnlockAllPrices.Name = "chkUnlockAllPrices"
        Me.chkUnlockAllPrices.Size = New System.Drawing.Size(158, 17)
        Me.chkUnlockAllPrices.TabIndex = 3
        Me.chkUnlockAllPrices.Text = "Unlock entry and ride prices"
        Me.chkUnlockAllPrices.UseVisualStyleBackColor = true
        '
        'chkDisableAllBreakdowns
        '
        Me.chkDisableAllBreakdowns.AutoSize = true
        Me.chkDisableAllBreakdowns.Location = New System.Drawing.Point(3, 26)
        Me.chkDisableAllBreakdowns.Name = "chkDisableAllBreakdowns"
        Me.chkDisableAllBreakdowns.Size = New System.Drawing.Size(125, 17)
        Me.chkDisableAllBreakdowns.TabIndex = 2
        Me.chkDisableAllBreakdowns.Text = "Disable breakdowns "
        Me.chkDisableAllBreakdowns.UseVisualStyleBackColor = true
        '
        'chkDisableBrakesFailure
        '
        Me.chkDisableBrakesFailure.AutoSize = true
        Me.chkDisableBrakesFailure.Location = New System.Drawing.Point(247, 3)
        Me.chkDisableBrakesFailure.Name = "chkDisableBrakesFailure"
        Me.chkDisableBrakesFailure.Size = New System.Drawing.Size(127, 17)
        Me.chkDisableBrakesFailure.TabIndex = 1
        Me.chkDisableBrakesFailure.Text = "Disable brakes failure"
        Me.chkDisableBrakesFailure.UseVisualStyleBackColor = true
        '
        'chkFastLiftHill
        '
        Me.chkFastLiftHill.AutoSize = true
        Me.chkFastLiftHill.Location = New System.Drawing.Point(3, 3)
        Me.chkFastLiftHill.Name = "chkFastLiftHill"
        Me.chkFastLiftHill.Size = New System.Drawing.Size(145, 17)
        Me.chkFastLiftHill.TabIndex = 0
        Me.chkFastLiftHill.Text = "Allow faster lift hill speeds"
        Me.chkFastLiftHill.UseVisualStyleBackColor = true
        '
        'Launcher
        '
        Me.Launcher.Controls.Add(Me.chkInstallUpdates)
        Me.Launcher.Controls.Add(Me.tbGamePath)
        Me.Launcher.Controls.Add(Me.laGamePath)
        Me.Launcher.Controls.Add(Me.cmdGamePath)
        Me.Launcher.Controls.Add(Me.chkCheckUpdates)
        Me.Launcher.Location = New System.Drawing.Point(4, 22)
        Me.Launcher.Name = "Launcher"
        Me.Launcher.Padding = New System.Windows.Forms.Padding(3)
        Me.Launcher.Size = New System.Drawing.Size(492, 170)
        Me.Launcher.TabIndex = 0
        Me.Launcher.Text = "Launcher"
        Me.Launcher.UseVisualStyleBackColor = true
        '
        'Debugging
        '
        Me.Debugging.Controls.Add(Me.laArguments)
        Me.Debugging.Controls.Add(Me.cmdOutputPath)
        Me.Debugging.Controls.Add(Me.tbArguments)
        Me.Debugging.Controls.Add(Me.chkVerbose)
        Me.Debugging.Controls.Add(Me.tbOutputPath)
        Me.Debugging.Controls.Add(Me.chkSaveOutput)
        Me.Debugging.Controls.Add(Me.laOutputPath)
        Me.Debugging.Location = New System.Drawing.Point(4, 22)
        Me.Debugging.Name = "Debugging"
        Me.Debugging.Size = New System.Drawing.Size(492, 170)
        Me.Debugging.TabIndex = 6
        Me.Debugging.Text = "Debugging"
        Me.Debugging.UseVisualStyleBackColor = true
        '
        'Twitch
        '
        Me.Twitch.Controls.Add(Me.chkNews)
        Me.Twitch.Controls.Add(Me.chkChatPeepTracking)
        Me.Twitch.Controls.Add(Me.chkChatPeepNames)
        Me.Twitch.Controls.Add(Me.chkFollowerPeepTracking)
        Me.Twitch.Controls.Add(Me.chkFollowerPeepNames)
        Me.Twitch.Controls.Add(Me.tbChannel)
        Me.Twitch.Controls.Add(Me.laChannel)
        Me.Twitch.Location = New System.Drawing.Point(4, 22)
        Me.Twitch.Name = "Twitch"
        Me.Twitch.Size = New System.Drawing.Size(492, 170)
        Me.Twitch.TabIndex = 8
        Me.Twitch.Text = "Twitch"
        Me.Twitch.UseVisualStyleBackColor = true
        '
        'chkNews
        '
        Me.chkNews.AutoSize = true
        Me.chkNews.Location = New System.Drawing.Point(3, 91)
        Me.chkNews.Name = "chkNews"
        Me.chkNews.Size = New System.Drawing.Size(144, 17)
        Me.chkNews.TabIndex = 6
        Me.chkNews.Text = "Pull Twitch chat as news"
        Me.chkNews.UseVisualStyleBackColor = true
        '
        'chkChatPeepTracking
        '
        Me.chkChatPeepTracking.AutoSize = true
        Me.chkChatPeepTracking.Location = New System.Drawing.Point(247, 68)
        Me.chkChatPeepTracking.Name = "chkChatPeepTracking"
        Me.chkChatPeepTracking.Size = New System.Drawing.Size(110, 17)
        Me.chkChatPeepTracking.TabIndex = 5
        Me.chkChatPeepTracking.Text = "Track chat peeps"
        Me.chkChatPeepTracking.UseVisualStyleBackColor = true
        '
        'chkChatPeepNames
        '
        Me.chkChatPeepNames.AutoSize = true
        Me.chkChatPeepNames.Location = New System.Drawing.Point(3, 68)
        Me.chkChatPeepNames.Name = "chkChatPeepNames"
        Me.chkChatPeepNames.Size = New System.Drawing.Size(215, 17)
        Me.chkChatPeepNames.TabIndex = 4
        Me.chkChatPeepNames.Text = "Name peeps after people in Twitch chat"
        Me.chkChatPeepNames.UseVisualStyleBackColor = true
        '
        'chkFollowerPeepTracking
        '
        Me.chkFollowerPeepTracking.AutoSize = true
        Me.chkFollowerPeepTracking.Location = New System.Drawing.Point(247, 45)
        Me.chkFollowerPeepTracking.Name = "chkFollowerPeepTracking"
        Me.chkFollowerPeepTracking.Size = New System.Drawing.Size(125, 17)
        Me.chkFollowerPeepTracking.TabIndex = 3
        Me.chkFollowerPeepTracking.Text = "Track follower peeps"
        Me.chkFollowerPeepTracking.UseVisualStyleBackColor = true
        '
        'chkFollowerPeepNames
        '
        Me.chkFollowerPeepNames.AutoSize = true
        Me.chkFollowerPeepNames.Location = New System.Drawing.Point(3, 45)
        Me.chkFollowerPeepNames.Name = "chkFollowerPeepNames"
        Me.chkFollowerPeepNames.Size = New System.Drawing.Size(154, 17)
        Me.chkFollowerPeepNames.TabIndex = 2
        Me.chkFollowerPeepNames.Text = "Name peeps after followers"
        Me.chkFollowerPeepNames.UseVisualStyleBackColor = true
        '
        'tbChannel
        '
        Me.tbChannel.Location = New System.Drawing.Point(3, 19)
        Me.tbChannel.Name = "tbChannel"
        Me.tbChannel.Size = New System.Drawing.Size(486, 20)
        Me.tbChannel.TabIndex = 1
        '
        'laChannel
        '
        Me.laChannel.AutoSize = true
        Me.laChannel.Location = New System.Drawing.Point(3, 3)
        Me.laChannel.Name = "laChannel"
        Me.laChannel.Size = New System.Drawing.Size(110, 13)
        Me.laChannel.TabIndex = 0
        Me.laChannel.Text = "Twitch Channel name"
        '
        'Miscellaneous
        '
        Me.Miscellaneous.Controls.Add(Me.chkNoTestCrashes)
        Me.Miscellaneous.Controls.Add(Me.chkConfirmationPrompt)
        Me.Miscellaneous.Controls.Add(Me.chkPlayIntro)
        Me.Miscellaneous.Controls.Add(Me.chkTestUnfinishedTracks)
        Me.Miscellaneous.Controls.Add(Me.chkDebuggingTools)
        Me.Miscellaneous.Controls.Add(Me.laScreenshotFormat)
        Me.Miscellaneous.Controls.Add(Me.cbScreenshotFormat)
        Me.Miscellaneous.Controls.Add(Me.cbAutosave)
        Me.Miscellaneous.Controls.Add(Me.chkAllowSubtypeSwitching)
        Me.Miscellaneous.Controls.Add(Me.laAutosave)
        Me.Miscellaneous.Controls.Add(Me.chkSavePluginData)
        Me.Miscellaneous.Location = New System.Drawing.Point(4, 22)
        Me.Miscellaneous.Name = "Miscellaneous"
        Me.Miscellaneous.Size = New System.Drawing.Size(492, 170)
        Me.Miscellaneous.TabIndex = 5
        Me.Miscellaneous.Text = "Miscellaneous"
        Me.Miscellaneous.UseVisualStyleBackColor = true
        '
        'chkNoTestCrashes
        '
        Me.chkNoTestCrashes.AutoSize = true
        Me.chkNoTestCrashes.Location = New System.Drawing.Point(3, 92)
        Me.chkNoTestCrashes.Name = "chkNoTestCrashes"
        Me.chkNoTestCrashes.Size = New System.Drawing.Size(141, 17)
        Me.chkNoTestCrashes.TabIndex = 21
        Me.chkNoTestCrashes.Text = "No crashes while testing"
        Me.chkNoTestCrashes.UseVisualStyleBackColor = true
        '
        'chkTestUnfinishedTracks
        '
        Me.chkTestUnfinishedTracks.AutoSize = true
        Me.chkTestUnfinishedTracks.Location = New System.Drawing.Point(247, 69)
        Me.chkTestUnfinishedTracks.Name = "chkTestUnfinishedTracks"
        Me.chkTestUnfinishedTracks.Size = New System.Drawing.Size(180, 17)
        Me.chkTestUnfinishedTracks.TabIndex = 20
        Me.chkTestUnfinishedTracks.Text = "Allow testing of unfinished tracks"
        Me.chkTestUnfinishedTracks.UseVisualStyleBackColor = true
        '
        'chkDebuggingTools
        '
        Me.chkDebuggingTools.AutoSize = true
        Me.chkDebuggingTools.Location = New System.Drawing.Point(3, 69)
        Me.chkDebuggingTools.Name = "chkDebuggingTools"
        Me.chkDebuggingTools.Size = New System.Drawing.Size(137, 17)
        Me.chkDebuggingTools.TabIndex = 19
        Me.chkDebuggingTools.Text = "Enable debugging tools"
        Me.chkDebuggingTools.UseVisualStyleBackColor = true
        '
        'chkAllowSubtypeSwitching
        '
        Me.chkAllowSubtypeSwitching.AutoSize = true
        Me.chkAllowSubtypeSwitching.Location = New System.Drawing.Point(247, 46)
        Me.chkAllowSubtypeSwitching.Name = "chkAllowSubtypeSwitching"
        Me.chkAllowSubtypeSwitching.Size = New System.Drawing.Size(226, 17)
        Me.chkAllowSubtypeSwitching.TabIndex = 18
        Me.chkAllowSubtypeSwitching.Text = "Show all vehicles sharing a track/ride type"
        Me.chkAllowSubtypeSwitching.UseVisualStyleBackColor = true
        '
        'FrmOptions
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(524, 249)
        Me.Controls.Add(Me.tcMain)
        Me.Controls.Add(Me.cmdReset)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOk)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "FrmOptions"
        Me.ShowIcon = false
        Me.ShowInTaskbar = false
        Me.Text = "Options"
        CType(Me.numFullscreenWidth,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.numFullscreenHeight,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.numWindowHeight,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.numWindowWidth,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.numWindowSnapProximity,System.ComponentModel.ISupportInitialize).EndInit
        Me.tcMain.ResumeLayout(false)
        Me.Graphics.ResumeLayout(false)
        Me.Graphics.PerformLayout
        Me.Localisation.ResumeLayout(false)
        Me.Localisation.PerformLayout
        Me.Sound.ResumeLayout(false)
        Me.Sound.PerformLayout
        Me.GUI.ResumeLayout(false)
        Me.GUI.PerformLayout
        Me.Cheats.ResumeLayout(false)
        Me.Cheats.PerformLayout
        Me.Launcher.ResumeLayout(false)
        Me.Launcher.PerformLayout
        Me.Debugging.ResumeLayout(false)
        Me.Debugging.PerformLayout
        Me.Twitch.ResumeLayout(false)
        Me.Twitch.PerformLayout
        Me.Miscellaneous.ResumeLayout(false)
        Me.Miscellaneous.PerformLayout
        Me.ResumeLayout(false)

End Sub
        Friend WithEvents tbGamePath As System.Windows.Forms.TextBox
        Friend WithEvents cmdGamePath As System.Windows.Forms.Button
        Friend WithEvents laGamePath As System.Windows.Forms.Label
        Friend WithEvents laScreenshotFormat As System.Windows.Forms.Label
        Friend WithEvents cbScreenshotFormat As System.Windows.Forms.ComboBox
        Friend WithEvents chkPlayIntro As System.Windows.Forms.CheckBox
        Friend WithEvents chkConfirmationPrompt As System.Windows.Forms.CheckBox
        Friend WithEvents chkEdgeScrolling As System.Windows.Forms.CheckBox
        Friend WithEvents laCurrency As System.Windows.Forms.Label
        Friend WithEvents cbCurrency As System.Windows.Forms.ComboBox
        Friend WithEvents laMeasurementFormat As System.Windows.Forms.Label
        Friend WithEvents laTemperatureFormat As System.Windows.Forms.Label
        Friend WithEvents cbMeasurementFormat As System.Windows.Forms.ComboBox
        Friend WithEvents cbTemperatureFormat As System.Windows.Forms.ComboBox
        Friend WithEvents chkAlwaysShowGridlines As System.Windows.Forms.CheckBox
        Friend WithEvents chkLandscapeSmoothing As System.Windows.Forms.CheckBox
        Friend WithEvents chkSavePluginData As System.Windows.Forms.CheckBox
        Friend WithEvents laFullscreenMode As System.Windows.Forms.Label
        Friend WithEvents cbFullscreenMode As System.Windows.Forms.ComboBox
        Friend WithEvents laFullscreenWidth As System.Windows.Forms.Label
        Friend WithEvents numFullscreenWidth As System.Windows.Forms.NumericUpDown
        Friend WithEvents numFullscreenHeight As System.Windows.Forms.NumericUpDown
        Friend WithEvents laFullscreenHeight As System.Windows.Forms.Label
        Friend WithEvents laLanguage As System.Windows.Forms.Label
        Friend WithEvents cbLanguage As System.Windows.Forms.ComboBox
        Friend WithEvents laTitleMusic As System.Windows.Forms.Label
        Friend WithEvents cbTitleMusic As System.Windows.Forms.ComboBox
        Friend WithEvents laSoundQuality As System.Windows.Forms.Label
        Friend WithEvents cbSoundQuality As System.Windows.Forms.ComboBox
        Friend WithEvents chkForcedSoftwareBuffering As System.Windows.Forms.CheckBox
        Friend WithEvents cbShowHeightAsUnits As System.Windows.Forms.ComboBox
        Friend WithEvents laShowHeightAsUnits As System.Windows.Forms.Label
        Friend WithEvents cmdOk As System.Windows.Forms.Button
        Friend WithEvents cmdCancel As System.Windows.Forms.Button
        Friend WithEvents cmdReset As System.Windows.Forms.Button
        Friend WithEvents FBD As System.Windows.Forms.FolderBrowserDialog
        Friend WithEvents cmdOutputPath As System.Windows.Forms.Button
        Friend WithEvents tbOutputPath As System.Windows.Forms.TextBox
        Friend WithEvents laOutputPath As System.Windows.Forms.Label
        Friend WithEvents chkSaveOutput As System.Windows.Forms.CheckBox
        Friend WithEvents chkVerbose As System.Windows.Forms.CheckBox
        Friend WithEvents laArguments As System.Windows.Forms.Label
        Friend WithEvents tbArguments As System.Windows.Forms.TextBox
        Friend WithEvents SFD As System.Windows.Forms.SaveFileDialog
        Friend WithEvents laAutosave As System.Windows.Forms.Label
        Friend WithEvents laConstructionMarkerColour As System.Windows.Forms.Label
        Friend WithEvents numWindowHeight As System.Windows.Forms.NumericUpDown
        Friend WithEvents numWindowWidth As System.Windows.Forms.NumericUpDown
        Friend WithEvents laWindowHeight As System.Windows.Forms.Label
        Friend WithEvents laWindowWidth As System.Windows.Forms.Label
        Friend WithEvents cbAutosave As System.Windows.Forms.ComboBox
        Friend WithEvents cbConstructionMarkerColour As System.Windows.Forms.ComboBox
        Friend WithEvents numWindowSnapProximity As System.Windows.Forms.NumericUpDown
        Friend WithEvents laWindowSnapProximity As System.Windows.Forms.Label
        Friend WithEvents chkRideMusic As System.Windows.Forms.CheckBox
        Friend WithEvents chkSound As System.Windows.Forms.CheckBox
        Friend WithEvents chkInstallUpdates As System.Windows.Forms.CheckBox
        Friend WithEvents chkCheckUpdates As System.Windows.Forms.CheckBox
        Friend WithEvents tcMain As System.Windows.Forms.TabControl
        Friend WithEvents Launcher As System.Windows.Forms.TabPage
        Friend WithEvents Graphics As System.Windows.Forms.TabPage
        Friend WithEvents Localisation As System.Windows.Forms.TabPage
        Friend WithEvents Sound As System.Windows.Forms.TabPage
        Friend WithEvents GUI As System.Windows.Forms.TabPage
        Friend WithEvents Miscellaneous As System.Windows.Forms.TabPage
        Friend WithEvents chkHardwareDisplay As System.Windows.Forms.CheckBox
        Friend WithEvents chkRCT1ColourScheme As System.Windows.Forms.CheckBox
        Friend WithEvents chkToolbarShowCheats As System.Windows.Forms.CheckBox
        Friend WithEvents chkToolbarShowResearch As System.Windows.Forms.CheckBox
        Friend WithEvents chkToolbarShowFinances As System.Windows.Forms.CheckBox
        Friend WithEvents chkTestUnfinishedTracks As System.Windows.Forms.CheckBox
        Friend WithEvents chkDebuggingTools As System.Windows.Forms.CheckBox
        Friend WithEvents chkAllowSubtypeSwitching As System.Windows.Forms.CheckBox
        Friend WithEvents Debugging As System.Windows.Forms.TabPage
        Friend WithEvents chkConsoleSmallFont As System.Windows.Forms.CheckBox
        Friend WithEvents Cheats As System.Windows.Forms.TabPage
        Friend WithEvents chkUnlockAllPrices As System.Windows.Forms.CheckBox
        Friend WithEvents chkDisableAllBreakdowns As System.Windows.Forms.CheckBox
        Friend WithEvents chkDisableBrakesFailure As System.Windows.Forms.CheckBox
        Friend WithEvents chkFastLiftHill As System.Windows.Forms.CheckBox
        Friend WithEvents chkNoTestCrashes As System.Windows.Forms.CheckBox
        Friend WithEvents cbDateFormat As System.Windows.Forms.ComboBox
        Friend WithEvents laDateFormat As System.Windows.Forms.Label
        Friend WithEvents Twitch As System.Windows.Forms.TabPage
        Friend WithEvents tbChannel As System.Windows.Forms.TextBox
        Friend WithEvents laChannel As System.Windows.Forms.Label
        Friend WithEvents chkNews As System.Windows.Forms.CheckBox
        Friend WithEvents chkChatPeepTracking As System.Windows.Forms.CheckBox
        Friend WithEvents chkChatPeepNames As System.Windows.Forms.CheckBox
        Friend WithEvents chkFollowerPeepTracking As System.Windows.Forms.CheckBox
        Friend WithEvents chkFollowerPeepNames As System.Windows.Forms.CheckBox
    End Class
End Namespace