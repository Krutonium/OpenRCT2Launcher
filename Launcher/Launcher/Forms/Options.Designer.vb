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
            Me.chkMinimizeFullscreenFocusLoss = New System.Windows.Forms.CheckBox()
            Me.chkUncapFPS = New System.Windows.Forms.CheckBox()
            Me.chkHardwareDisplay = New System.Windows.Forms.CheckBox()
            Me.Localisation = New System.Windows.Forms.TabPage()
            Me.cbDateFormat = New System.Windows.Forms.ComboBox()
            Me.laDateFormat = New System.Windows.Forms.Label()
            Me.Sound = New System.Windows.Forms.TabPage()
            Me.numMusicVolume = New System.Windows.Forms.NumericUpDown()
            Me.laMusicVolume = New System.Windows.Forms.Label()
            Me.numMasterVolume = New System.Windows.Forms.NumericUpDown()
            Me.laMasterVolume = New System.Windows.Forms.Label()
            Me.GUI = New System.Windows.Forms.TabPage()
            Me.chkInvertViewportDrag = New System.Windows.Forms.CheckBox()
            Me.chkConsoleSmallFont = New System.Windows.Forms.CheckBox()
            Me.chkToolbarShowCheats = New System.Windows.Forms.CheckBox()
            Me.chkToolbarShowResearch = New System.Windows.Forms.CheckBox()
            Me.chkToolbarShowFinances = New System.Windows.Forms.CheckBox()
            Me.Cheats = New System.Windows.Forms.TabPage()
            Me.chkBuildInPauseMode = New System.Windows.Forms.CheckBox()
            Me.chkUnlockAllPrices = New System.Windows.Forms.CheckBox()
            Me.chkDisableAllBreakdowns = New System.Windows.Forms.CheckBox()
            Me.chkDisableBrakesFailure = New System.Windows.Forms.CheckBox()
            Me.chkFastLiftHill = New System.Windows.Forms.CheckBox()
            Me.Launcher = New System.Windows.Forms.TabPage()
            Me.rdoDevelop = New System.Windows.Forms.RadioButton()
            Me.rdoStable = New System.Windows.Forms.RadioButton()
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
            Me.chkAutoStaff = New System.Windows.Forms.CheckBox()
            Me.chkNoTestCrashes = New System.Windows.Forms.CheckBox()
            Me.chkTestUnfinishedTracks = New System.Windows.Forms.CheckBox()
            Me.chkDebuggingTools = New System.Windows.Forms.CheckBox()
            Me.chkSelectByTrackType = New System.Windows.Forms.CheckBox()
            CType(Me.numFullscreenWidth, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.numFullscreenHeight, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.numWindowHeight, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.numWindowWidth, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.numWindowSnapProximity, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.tcMain.SuspendLayout()
            Me.Graphics.SuspendLayout()
            Me.Localisation.SuspendLayout()
            Me.Sound.SuspendLayout()
            CType(Me.numMusicVolume, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.numMasterVolume, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GUI.SuspendLayout()
            Me.Cheats.SuspendLayout()
            Me.Launcher.SuspendLayout()
            Me.Debugging.SuspendLayout()
            Me.Twitch.SuspendLayout()
            Me.Miscellaneous.SuspendLayout()
            Me.SuspendLayout()
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
            Me.cmdGamePath.UseVisualStyleBackColor = True
            '
            'laGamePath
            '
            Me.laGamePath.AutoSize = True
            Me.laGamePath.Location = New System.Drawing.Point(3, 3)
            Me.laGamePath.Name = "laGamePath"
            Me.laGamePath.Size = New System.Drawing.Size(63, 13)
            Me.laGamePath.TabIndex = 2
            Me.laGamePath.Text = Global.Launcher.My.Resources.Resources.frmOptions_gamePath_label
            '
            'laScreenshotFormat
            '
            Me.laScreenshotFormat.AutoSize = True
            Me.laScreenshotFormat.Location = New System.Drawing.Point(248, 3)
            Me.laScreenshotFormat.Name = "laScreenshotFormat"
            Me.laScreenshotFormat.Size = New System.Drawing.Size(99, 13)
            Me.laScreenshotFormat.TabIndex = 3
            Me.laScreenshotFormat.Text = Global.Launcher.My.Resources.Resources.frmOptions_screenshotFormat_label
            '
            'cbScreenshotFormat
            '
            Me.cbScreenshotFormat.DisplayMember = "1"
            Me.cbScreenshotFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cbScreenshotFormat.FormattingEnabled = True
            Me.cbScreenshotFormat.Items.AddRange(New Object() {"*.bmp", "*.png"})
            Me.cbScreenshotFormat.Location = New System.Drawing.Point(248, 19)
            Me.cbScreenshotFormat.Name = "cbScreenshotFormat"
            Me.cbScreenshotFormat.Size = New System.Drawing.Size(239, 21)
            Me.cbScreenshotFormat.TabIndex = 4
            '
            'chkPlayIntro
            '
            Me.chkPlayIntro.AutoSize = True
            Me.chkPlayIntro.Location = New System.Drawing.Point(248, 92)
            Me.chkPlayIntro.Name = "chkPlayIntro"
            Me.chkPlayIntro.Size = New System.Drawing.Size(70, 17)
            Me.chkPlayIntro.TabIndex = 5
            Me.chkPlayIntro.Text = Global.Launcher.My.Resources.Resources.frmOptions_playIntroButton_label
            Me.chkPlayIntro.UseVisualStyleBackColor = True
            '
            'chkConfirmationPrompt
            '
            Me.chkConfirmationPrompt.AutoSize = True
            Me.chkConfirmationPrompt.Location = New System.Drawing.Point(3, 115)
            Me.chkConfirmationPrompt.Name = "chkConfirmationPrompt"
            Me.chkConfirmationPrompt.Size = New System.Drawing.Size(150, 17)
            Me.chkConfirmationPrompt.TabIndex = 6
            Me.chkConfirmationPrompt.Text = Global.Launcher.My.Resources.Resources.frmOptions_showConfirmationPrompt_label
            Me.chkConfirmationPrompt.UseVisualStyleBackColor = True
            '
            'chkEdgeScrolling
            '
            Me.chkEdgeScrolling.AutoSize = True
            Me.chkEdgeScrolling.Location = New System.Drawing.Point(3, 45)
            Me.chkEdgeScrolling.Name = "chkEdgeScrolling"
            Me.chkEdgeScrolling.Size = New System.Drawing.Size(215, 17)
            Me.chkEdgeScrolling.TabIndex = 7
            Me.chkEdgeScrolling.Text = Global.Launcher.My.Resources.Resources.frmOptions_edgeScrolling_label
            Me.chkEdgeScrolling.UseVisualStyleBackColor = True
            '
            'laCurrency
            '
            Me.laCurrency.AutoSize = True
            Me.laCurrency.Location = New System.Drawing.Point(248, 3)
            Me.laCurrency.Name = "laCurrency"
            Me.laCurrency.Size = New System.Drawing.Size(52, 13)
            Me.laCurrency.TabIndex = 8
            Me.laCurrency.Text = Global.Launcher.My.Resources.Resources.frmOptions_currency_label
            '
            'cbCurrency
            '
            Me.cbCurrency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cbCurrency.FormattingEnabled = True
            Me.cbCurrency.Items.AddRange(New Object() {Global.Launcher.My.Resources.Resources.frmOptions_currency_pound, Global.Launcher.My.Resources.Resources.frmOptions_currency_dollar, Global.Launcher.My.Resources.Resources.frmOptions_currency_franc, Global.Launcher.My.Resources.Resources.frmOptions_currency_deutchmark, Global.Launcher.My.Resources.Resources.frmOptions_currency_yen, Global.Launcher.My.Resources.Resources.frmOptions_currency_peseta, Global.Launcher.My.Resources.Resources.frmOptions_currency_lira, Global.Launcher.My.Resources.Resources.frmOptions_currency_guilder, Global.Launcher.My.Resources.Resources.frmOptions_currency_krona, Global.Launcher.My.Resources.Resources.frmOptions_currency_euro})
            Me.cbCurrency.Location = New System.Drawing.Point(248, 19)
            Me.cbCurrency.Name = "cbCurrency"
            Me.cbCurrency.Size = New System.Drawing.Size(239, 21)
            Me.cbCurrency.TabIndex = 9
            '
            'laMeasurementFormat
            '
            Me.laMeasurementFormat.AutoSize = True
            Me.laMeasurementFormat.Location = New System.Drawing.Point(3, 43)
            Me.laMeasurementFormat.Name = "laMeasurementFormat"
            Me.laMeasurementFormat.Size = New System.Drawing.Size(107, 13)
            Me.laMeasurementFormat.TabIndex = 10
            Me.laMeasurementFormat.Text = Global.Launcher.My.Resources.Resources.frmOptions_distSpeed_label
            '
            'laTemperatureFormat
            '
            Me.laTemperatureFormat.AutoSize = True
            Me.laTemperatureFormat.Location = New System.Drawing.Point(248, 43)
            Me.laTemperatureFormat.Name = "laTemperatureFormat"
            Me.laTemperatureFormat.Size = New System.Drawing.Size(70, 13)
            Me.laTemperatureFormat.TabIndex = 11
            Me.laTemperatureFormat.Text = Global.Launcher.My.Resources.Resources.frmOptions_temperature_label
            '
            'cbMeasurementFormat
            '
            Me.cbMeasurementFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cbMeasurementFormat.FormattingEnabled = True
            Me.cbMeasurementFormat.Items.AddRange(New Object() {Global.Launcher.My.Resources.Resources.frmOptions_distSpeed_imperial, Global.Launcher.My.Resources.Resources.frmOptions_distSpeed_metric})
            Me.cbMeasurementFormat.Location = New System.Drawing.Point(3, 59)
            Me.cbMeasurementFormat.Name = "cbMeasurementFormat"
            Me.cbMeasurementFormat.Size = New System.Drawing.Size(239, 21)
            Me.cbMeasurementFormat.TabIndex = 12
            '
            'cbTemperatureFormat
            '
            Me.cbTemperatureFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cbTemperatureFormat.FormattingEnabled = True
            Me.cbTemperatureFormat.Items.AddRange(New Object() {Global.Launcher.My.Resources.Resources.frmOptions_temperature_celsius, Global.Launcher.My.Resources.Resources.frmOptions_temperature_fahrenheit})
            Me.cbTemperatureFormat.Location = New System.Drawing.Point(248, 59)
            Me.cbTemperatureFormat.Name = "cbTemperatureFormat"
            Me.cbTemperatureFormat.Size = New System.Drawing.Size(239, 21)
            Me.cbTemperatureFormat.TabIndex = 13
            '
            'chkAlwaysShowGridlines
            '
            Me.chkAlwaysShowGridlines.AutoSize = True
            Me.chkAlwaysShowGridlines.Location = New System.Drawing.Point(248, 124)
            Me.chkAlwaysShowGridlines.Name = "chkAlwaysShowGridlines"
            Me.chkAlwaysShowGridlines.Size = New System.Drawing.Size(137, 17)
            Me.chkAlwaysShowGridlines.TabIndex = 14
            Me.chkAlwaysShowGridlines.Text = Global.Launcher.My.Resources.Resources.frmOptions_alwaysGridLines_label
            Me.chkAlwaysShowGridlines.UseVisualStyleBackColor = True
            '
            'chkLandscapeSmoothing
            '
            Me.chkLandscapeSmoothing.AutoSize = True
            Me.chkLandscapeSmoothing.Location = New System.Drawing.Point(3, 124)
            Me.chkLandscapeSmoothing.Name = "chkLandscapeSmoothing"
            Me.chkLandscapeSmoothing.Size = New System.Drawing.Size(132, 17)
            Me.chkLandscapeSmoothing.TabIndex = 15
            Me.chkLandscapeSmoothing.Text = Global.Launcher.My.Resources.Resources.frmOptions_landscapeSmoothing_label
            Me.chkLandscapeSmoothing.UseVisualStyleBackColor = True
            '
            'chkSavePluginData
            '
            Me.chkSavePluginData.AutoSize = True
            Me.chkSavePluginData.Location = New System.Drawing.Point(3, 46)
            Me.chkSavePluginData.Name = "chkSavePluginData"
            Me.chkSavePluginData.Size = New System.Drawing.Size(215, 17)
            Me.chkSavePluginData.TabIndex = 17
            Me.chkSavePluginData.Text = Global.Launcher.My.Resources.Resources.frmOptions_savePluginData_label
            Me.chkSavePluginData.UseVisualStyleBackColor = True
            '
            'laFullscreenMode
            '
            Me.laFullscreenMode.AutoSize = True
            Me.laFullscreenMode.Location = New System.Drawing.Point(3, 3)
            Me.laFullscreenMode.Name = "laFullscreenMode"
            Me.laFullscreenMode.Size = New System.Drawing.Size(87, 13)
            Me.laFullscreenMode.TabIndex = 18
            Me.laFullscreenMode.Text = Global.Launcher.My.Resources.Resources.frmOptions_fullscreenMode_label
            '
            'cbFullscreenMode
            '
            Me.cbFullscreenMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cbFullscreenMode.FormattingEnabled = True
            Me.cbFullscreenMode.Items.AddRange(New Object() {Global.Launcher.My.Resources.Resources.frmOptions_fullscreenMode_windowed, Global.Launcher.My.Resources.Resources.frmOptions_fullscreenMode_fullscreen, Global.Launcher.My.Resources.Resources.frmOptions_fullscreenMode_fullscreenDesktop})
            Me.cbFullscreenMode.Location = New System.Drawing.Point(3, 19)
            Me.cbFullscreenMode.Name = "cbFullscreenMode"
            Me.cbFullscreenMode.Size = New System.Drawing.Size(239, 21)
            Me.cbFullscreenMode.TabIndex = 19
            '
            'laFullscreenWidth
            '
            Me.laFullscreenWidth.AutoSize = True
            Me.laFullscreenWidth.Location = New System.Drawing.Point(3, 43)
            Me.laFullscreenWidth.Name = "laFullscreenWidth"
            Me.laFullscreenWidth.Size = New System.Drawing.Size(86, 13)
            Me.laFullscreenWidth.TabIndex = 20
            Me.laFullscreenWidth.Text = Global.Launcher.My.Resources.Resources.frmOptions_fullscreenWidth_label
            '
            'numFullscreenWidth
            '
            Me.numFullscreenWidth.Increment = New Decimal(New Integer() {100, 0, 0, 0})
            Me.numFullscreenWidth.Location = New System.Drawing.Point(3, 59)
            Me.numFullscreenWidth.Maximum = New Decimal(New Integer() {-2147483648, 0, 0, 0})
            Me.numFullscreenWidth.Minimum = New Decimal(New Integer() {1, 0, 0, -2147483648})
            Me.numFullscreenWidth.Name = "numFullscreenWidth"
            Me.numFullscreenWidth.Size = New System.Drawing.Size(239, 20)
            Me.numFullscreenWidth.TabIndex = 22
            '
            'numFullscreenHeight
            '
            Me.numFullscreenHeight.Increment = New Decimal(New Integer() {100, 0, 0, 0})
            Me.numFullscreenHeight.Location = New System.Drawing.Point(248, 59)
            Me.numFullscreenHeight.Maximum = New Decimal(New Integer() {-2147483648, 0, 0, 0})
            Me.numFullscreenHeight.Minimum = New Decimal(New Integer() {1, 0, 0, -2147483648})
            Me.numFullscreenHeight.Name = "numFullscreenHeight"
            Me.numFullscreenHeight.Size = New System.Drawing.Size(239, 20)
            Me.numFullscreenHeight.TabIndex = 24
            '
            'laFullscreenHeight
            '
            Me.laFullscreenHeight.AutoSize = True
            Me.laFullscreenHeight.Location = New System.Drawing.Point(248, 43)
            Me.laFullscreenHeight.Name = "laFullscreenHeight"
            Me.laFullscreenHeight.Size = New System.Drawing.Size(90, 13)
            Me.laFullscreenHeight.TabIndex = 23
            Me.laFullscreenHeight.Text = Global.Launcher.My.Resources.Resources.frmOptions_fullscreenHeight_label
            '
            'laLanguage
            '
            Me.laLanguage.AutoSize = True
            Me.laLanguage.Location = New System.Drawing.Point(3, 3)
            Me.laLanguage.Name = "laLanguage"
            Me.laLanguage.Size = New System.Drawing.Size(58, 13)
            Me.laLanguage.TabIndex = 25
            Me.laLanguage.Text = Global.Launcher.My.Resources.Resources.frmOptions_language_label
            '
            'cbLanguage
            '
            Me.cbLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cbLanguage.FormattingEnabled = True
            Me.cbLanguage.Items.AddRange(New Object() {"English (UK)", "English (US)", "Deutsch", "Nederlands", "Français", "Magyar", "Polski", "Español", "Svenska"})
            Me.cbLanguage.Location = New System.Drawing.Point(3, 19)
            Me.cbLanguage.Name = "cbLanguage"
            Me.cbLanguage.Size = New System.Drawing.Size(239, 21)
            Me.cbLanguage.TabIndex = 26
            '
            'laTitleMusic
            '
            Me.laTitleMusic.AutoSize = True
            Me.laTitleMusic.Location = New System.Drawing.Point(3, 3)
            Me.laTitleMusic.Name = "laTitleMusic"
            Me.laTitleMusic.Size = New System.Drawing.Size(95, 13)
            Me.laTitleMusic.TabIndex = 27
            Me.laTitleMusic.Text = Global.Launcher.My.Resources.Resources.frmOptions_titleScreenMusic_label
            '
            'cbTitleMusic
            '
            Me.cbTitleMusic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cbTitleMusic.FormattingEnabled = True
            Me.cbTitleMusic.Items.AddRange(New Object() {Global.Launcher.My.Resources.Resources.frmOptions_titleScreenMusic_none, Global.Launcher.My.Resources.Resources.frmOptions_titleScreenMusic_RCT1, Global.Launcher.My.Resources.Resources.frmOptions_titleScreenMusic_RCT2})
            Me.cbTitleMusic.Location = New System.Drawing.Point(3, 19)
            Me.cbTitleMusic.Name = "cbTitleMusic"
            Me.cbTitleMusic.Size = New System.Drawing.Size(484, 21)
            Me.cbTitleMusic.TabIndex = 28
            '
            'cbConstructionMarkerColour
            '
            Me.cbConstructionMarkerColour.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cbConstructionMarkerColour.FormattingEnabled = True
            Me.cbConstructionMarkerColour.Items.AddRange(New Object() {Global.Launcher.My.Resources.Resources.frmOptions_constructionMarkerColour_white, Global.Launcher.My.Resources.Resources.frmOptions_constructionMarkerColour_translucent})
            Me.cbConstructionMarkerColour.Location = New System.Drawing.Point(248, 19)
            Me.cbConstructionMarkerColour.Name = "cbConstructionMarkerColour"
            Me.cbConstructionMarkerColour.Size = New System.Drawing.Size(239, 21)
            Me.cbConstructionMarkerColour.TabIndex = 29
            '
            'laConstructionMarkerColour
            '
            Me.laConstructionMarkerColour.AutoSize = True
            Me.laConstructionMarkerColour.Location = New System.Drawing.Point(248, 3)
            Me.laConstructionMarkerColour.Name = "laConstructionMarkerColour"
            Me.laConstructionMarkerColour.Size = New System.Drawing.Size(105, 13)
            Me.laConstructionMarkerColour.TabIndex = 29
            Me.laConstructionMarkerColour.Text = Global.Launcher.My.Resources.Resources.frmOptions_constructionMarkerColour_label
            '
            'numWindowHeight
            '
            Me.numWindowHeight.Increment = New Decimal(New Integer() {100, 0, 0, 0})
            Me.numWindowHeight.Location = New System.Drawing.Point(248, 98)
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
            Me.numWindowWidth.Size = New System.Drawing.Size(239, 20)
            Me.numWindowWidth.TabIndex = 27
            '
            'laWindowHeight
            '
            Me.laWindowHeight.AutoSize = True
            Me.laWindowHeight.Location = New System.Drawing.Point(248, 82)
            Me.laWindowHeight.Name = "laWindowHeight"
            Me.laWindowHeight.Size = New System.Drawing.Size(81, 13)
            Me.laWindowHeight.TabIndex = 26
            Me.laWindowHeight.Text = Global.Launcher.My.Resources.Resources.frmOptions_windowHeight_label
            '
            'laWindowWidth
            '
            Me.laWindowWidth.AutoSize = True
            Me.laWindowWidth.Location = New System.Drawing.Point(3, 82)
            Me.laWindowWidth.Name = "laWindowWidth"
            Me.laWindowWidth.Size = New System.Drawing.Size(77, 13)
            Me.laWindowWidth.TabIndex = 25
            Me.laWindowWidth.Text = Global.Launcher.My.Resources.Resources.frmOptions_windowWidth_label
            '
            'cbShowHeightAsUnits
            '
            Me.cbShowHeightAsUnits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cbShowHeightAsUnits.FormattingEnabled = True
            Me.cbShowHeightAsUnits.Items.AddRange(New Object() {Global.Launcher.My.Resources.Resources.frmOptions_heightLabels_units, Global.Launcher.My.Resources.Resources.frmOptions_heightLabels_real})
            Me.cbShowHeightAsUnits.Location = New System.Drawing.Point(3, 99)
            Me.cbShowHeightAsUnits.Name = "cbShowHeightAsUnits"
            Me.cbShowHeightAsUnits.Size = New System.Drawing.Size(239, 21)
            Me.cbShowHeightAsUnits.TabIndex = 28
            '
            'laShowHeightAsUnits
            '
            Me.laShowHeightAsUnits.AutoSize = True
            Me.laShowHeightAsUnits.Location = New System.Drawing.Point(3, 83)
            Me.laShowHeightAsUnits.Name = "laShowHeightAsUnits"
            Me.laShowHeightAsUnits.Size = New System.Drawing.Size(75, 13)
            Me.laShowHeightAsUnits.TabIndex = 27
            Me.laShowHeightAsUnits.Text = Global.Launcher.My.Resources.Resources.frmOptions_heightLabels_label
            '
            'chkRideMusic
            '
            Me.chkRideMusic.AutoSize = True
            Me.chkRideMusic.Location = New System.Drawing.Point(248, 85)
            Me.chkRideMusic.Name = "chkRideMusic"
            Me.chkRideMusic.Size = New System.Drawing.Size(79, 17)
            Me.chkRideMusic.TabIndex = 33
            Me.chkRideMusic.Text = Global.Launcher.My.Resources.Resources.frmOptions_rideMusic
            Me.chkRideMusic.UseVisualStyleBackColor = True
            '
            'chkSound
            '
            Me.chkSound.AutoSize = True
            Me.chkSound.Location = New System.Drawing.Point(3, 85)
            Me.chkSound.Name = "chkSound"
            Me.chkSound.Size = New System.Drawing.Size(57, 17)
            Me.chkSound.TabIndex = 32
            Me.chkSound.Text = Global.Launcher.My.Resources.Resources.frmOptions_sound
            Me.chkSound.UseVisualStyleBackColor = True
            '
            'numWindowSnapProximity
            '
            Me.numWindowSnapProximity.Increment = New Decimal(New Integer() {10, 0, 0, 0})
            Me.numWindowSnapProximity.Location = New System.Drawing.Point(3, 19)
            Me.numWindowSnapProximity.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
            Me.numWindowSnapProximity.Name = "numWindowSnapProximity"
            Me.numWindowSnapProximity.Size = New System.Drawing.Size(484, 20)
            Me.numWindowSnapProximity.TabIndex = 28
            '
            'laWindowSnapProximity
            '
            Me.laWindowSnapProximity.AutoSize = True
            Me.laWindowSnapProximity.Location = New System.Drawing.Point(3, 3)
            Me.laWindowSnapProximity.Name = "laWindowSnapProximity"
            Me.laWindowSnapProximity.Size = New System.Drawing.Size(118, 13)
            Me.laWindowSnapProximity.TabIndex = 20
            Me.laWindowSnapProximity.Text = Global.Launcher.My.Resources.Resources.frmOptions_windowSnapProximity
            '
            'cbAutosave
            '
            Me.cbAutosave.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cbAutosave.FormattingEnabled = True
            Me.cbAutosave.Items.AddRange(New Object() {Global.Launcher.My.Resources.Resources.frmOptions_autosave_everyWeek, Global.Launcher.My.Resources.Resources.frmOptions_autosave_everyTwoWeeks, Global.Launcher.My.Resources.Resources.frmOptions_autosave_everyMonth, Global.Launcher.My.Resources.Resources.frmOptions_autosave_everyFourMonths, Global.Launcher.My.Resources.Resources.frmOptions_autosave_everyYear, Global.Launcher.My.Resources.Resources.frmOptions_autosave_never})
            Me.cbAutosave.Location = New System.Drawing.Point(3, 19)
            Me.cbAutosave.Name = "cbAutosave"
            Me.cbAutosave.Size = New System.Drawing.Size(238, 21)
            Me.cbAutosave.TabIndex = 19
            '
            'laAutosave
            '
            Me.laAutosave.AutoSize = True
            Me.laAutosave.Location = New System.Drawing.Point(3, 3)
            Me.laAutosave.Name = "laAutosave"
            Me.laAutosave.Size = New System.Drawing.Size(105, 13)
            Me.laAutosave.TabIndex = 18
            Me.laAutosave.Text = Global.Launcher.My.Resources.Resources.frmOptions_autosave
            '
            'cmdOk
            '
            Me.cmdOk.Location = New System.Drawing.Point(12, 237)
            Me.cmdOk.Name = "cmdOk"
            Me.cmdOk.Size = New System.Drawing.Size(163, 23)
            Me.cmdOk.TabIndex = 36
            Me.cmdOk.Text = Global.Launcher.My.Resources.Resources.common_ok
            Me.cmdOk.UseVisualStyleBackColor = True
            '
            'cmdCancel
            '
            Me.cmdCancel.Location = New System.Drawing.Point(181, 237)
            Me.cmdCancel.Name = "cmdCancel"
            Me.cmdCancel.Size = New System.Drawing.Size(163, 23)
            Me.cmdCancel.TabIndex = 37
            Me.cmdCancel.Text = Global.Launcher.My.Resources.Resources.common_cancel
            Me.cmdCancel.UseVisualStyleBackColor = True
            '
            'cmdReset
            '
            Me.cmdReset.Location = New System.Drawing.Point(350, 237)
            Me.cmdReset.Name = "cmdReset"
            Me.cmdReset.Size = New System.Drawing.Size(162, 23)
            Me.cmdReset.TabIndex = 40
            Me.cmdReset.Text = Global.Launcher.My.Resources.Resources.common_reset
            Me.cmdReset.UseVisualStyleBackColor = True
            '
            'laArguments
            '
            Me.laArguments.AutoSize = True
            Me.laArguments.Location = New System.Drawing.Point(3, 23)
            Me.laArguments.Name = "laArguments"
            Me.laArguments.Size = New System.Drawing.Size(60, 13)
            Me.laArguments.TabIndex = 6
            Me.laArguments.Text = Global.Launcher.My.Resources.Resources.frmOptions_startArguments_label
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
            Me.cmdOutputPath.UseVisualStyleBackColor = True
            '
            'tbOutputPath
            '
            Me.tbOutputPath.Location = New System.Drawing.Point(248, 39)
            Me.tbOutputPath.Name = "tbOutputPath"
            Me.tbOutputPath.Size = New System.Drawing.Size(206, 20)
            Me.tbOutputPath.TabIndex = 3
            '
            'laOutputPath
            '
            Me.laOutputPath.AutoSize = True
            Me.laOutputPath.Location = New System.Drawing.Point(248, 23)
            Me.laOutputPath.Name = "laOutputPath"
            Me.laOutputPath.Size = New System.Drawing.Size(67, 13)
            Me.laOutputPath.TabIndex = 2
            Me.laOutputPath.Text = Global.Launcher.My.Resources.Resources.frmOptions_outputPath_label
            '
            'chkSaveOutput
            '
            Me.chkSaveOutput.AutoSize = True
            Me.chkSaveOutput.Location = New System.Drawing.Point(248, 3)
            Me.chkSaveOutput.Name = "chkSaveOutput"
            Me.chkSaveOutput.Size = New System.Drawing.Size(117, 17)
            Me.chkSaveOutput.TabIndex = 1
            Me.chkSaveOutput.Text = Global.Launcher.My.Resources.Resources.frmOptions_saveOutputFile_label
            Me.chkSaveOutput.UseVisualStyleBackColor = True
            '
            'chkVerbose
            '
            Me.chkVerbose.AutoSize = True
            Me.chkVerbose.Location = New System.Drawing.Point(3, 3)
            Me.chkVerbose.Name = "chkVerbose"
            Me.chkVerbose.Size = New System.Drawing.Size(100, 17)
            Me.chkVerbose.TabIndex = 0
            Me.chkVerbose.Text = Global.Launcher.My.Resources.Resources.frmLauncher_verboseOutputButton_text
            Me.chkVerbose.UseVisualStyleBackColor = True
            '
            'chkInstallUpdates
            '
            Me.chkInstallUpdates.AutoSize = True
            Me.chkInstallUpdates.Location = New System.Drawing.Point(248, 45)
            Me.chkInstallUpdates.Name = "chkInstallUpdates"
            Me.chkInstallUpdates.Size = New System.Drawing.Size(158, 17)
            Me.chkInstallUpdates.TabIndex = 1
            Me.chkInstallUpdates.Text = Global.Launcher.My.Resources.Resources.frmOptions_installUpdates
            Me.chkInstallUpdates.UseVisualStyleBackColor = True
            '
            'chkCheckUpdates
            '
            Me.chkCheckUpdates.AutoSize = True
            Me.chkCheckUpdates.Location = New System.Drawing.Point(3, 45)
            Me.chkCheckUpdates.Name = "chkCheckUpdates"
            Me.chkCheckUpdates.Size = New System.Drawing.Size(177, 17)
            Me.chkCheckUpdates.TabIndex = 0
            Me.chkCheckUpdates.Text = Global.Launcher.My.Resources.Resources.frmOptions_checkUpdates
            Me.chkCheckUpdates.UseVisualStyleBackColor = True
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
            Me.tcMain.ItemSize = New System.Drawing.Size(54, 18)
            Me.tcMain.Location = New System.Drawing.Point(12, 12)
            Me.tcMain.Name = "tcMain"
            Me.tcMain.SelectedIndex = 0
            Me.tcMain.Size = New System.Drawing.Size(500, 219)
            Me.tcMain.TabIndex = 43
            '
            'Graphics
            '
            Me.Graphics.Controls.Add(Me.chkMinimizeFullscreenFocusLoss)
            Me.Graphics.Controls.Add(Me.chkUncapFPS)
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
            Me.Graphics.Size = New System.Drawing.Size(492, 193)
            Me.Graphics.TabIndex = 1
            Me.Graphics.Text = Global.Launcher.My.Resources.Resources.frmOptions_graphics
            Me.Graphics.UseVisualStyleBackColor = True
            '
            'chkMinimizeFullscreenFocusLoss
            '
            Me.chkMinimizeFullscreenFocusLoss.AutoSize = True
            Me.chkMinimizeFullscreenFocusLoss.Location = New System.Drawing.Point(3, 170)
            Me.chkMinimizeFullscreenFocusLoss.Name = "chkMinimizeFullscreenFocusLoss"
            Me.chkMinimizeFullscreenFocusLoss.Size = New System.Drawing.Size(179, 17)
            Me.chkMinimizeFullscreenFocusLoss.TabIndex = 32
            Me.chkMinimizeFullscreenFocusLoss.Text = Global.Launcher.My.Resources.Resources.frmOptions_MinimizeFullscreenFocusLoss
            Me.chkMinimizeFullscreenFocusLoss.UseVisualStyleBackColor = True
            '
            'chkUncapFPS
            '
            Me.chkUncapFPS.AutoSize = True
            Me.chkUncapFPS.Location = New System.Drawing.Point(248, 147)
            Me.chkUncapFPS.Name = "chkUncapFPS"
            Me.chkUncapFPS.Size = New System.Drawing.Size(81, 17)
            Me.chkUncapFPS.TabIndex = 31
            Me.chkUncapFPS.Text = Global.Launcher.My.Resources.Resources.frmOptions_UncapFPS
            Me.chkUncapFPS.UseVisualStyleBackColor = True
            '
            'chkHardwareDisplay
            '
            Me.chkHardwareDisplay.AutoSize = True
            Me.chkHardwareDisplay.Location = New System.Drawing.Point(3, 147)
            Me.chkHardwareDisplay.Name = "chkHardwareDisplay"
            Me.chkHardwareDisplay.Size = New System.Drawing.Size(107, 17)
            Me.chkHardwareDisplay.TabIndex = 30
            Me.chkHardwareDisplay.Text = Global.Launcher.My.Resources.Resources.frmOptions_hardwareDisplay
            Me.chkHardwareDisplay.UseVisualStyleBackColor = True
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
            Me.Localisation.Size = New System.Drawing.Size(492, 193)
            Me.Localisation.TabIndex = 2
            Me.Localisation.Text = Global.Launcher.My.Resources.Resources.frmOptions_localisation
            Me.Localisation.UseVisualStyleBackColor = True
            '
            'cbDateFormat
            '
            Me.cbDateFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cbDateFormat.FormattingEnabled = True
            Me.cbDateFormat.Items.AddRange(New Object() {Global.Launcher.My.Resources.Resources.frmOptions_dateFormat_dmy, Global.Launcher.My.Resources.Resources.frmOptions_dateFormat_mdy})
            Me.cbDateFormat.Location = New System.Drawing.Point(248, 99)
            Me.cbDateFormat.Name = "cbDateFormat"
            Me.cbDateFormat.Size = New System.Drawing.Size(239, 21)
            Me.cbDateFormat.TabIndex = 30
            '
            'laDateFormat
            '
            Me.laDateFormat.AutoSize = True
            Me.laDateFormat.Location = New System.Drawing.Point(248, 83)
            Me.laDateFormat.Name = "laDateFormat"
            Me.laDateFormat.Size = New System.Drawing.Size(65, 13)
            Me.laDateFormat.TabIndex = 29
            Me.laDateFormat.Text = Global.Launcher.My.Resources.Resources.frmOptions_dateFormat
            '
            'Sound
            '
            Me.Sound.Controls.Add(Me.numMusicVolume)
            Me.Sound.Controls.Add(Me.laMusicVolume)
            Me.Sound.Controls.Add(Me.numMasterVolume)
            Me.Sound.Controls.Add(Me.laMasterVolume)
            Me.Sound.Controls.Add(Me.chkRideMusic)
            Me.Sound.Controls.Add(Me.chkSound)
            Me.Sound.Controls.Add(Me.cbTitleMusic)
            Me.Sound.Controls.Add(Me.laTitleMusic)
            Me.Sound.Location = New System.Drawing.Point(4, 22)
            Me.Sound.Name = "Sound"
            Me.Sound.Size = New System.Drawing.Size(492, 193)
            Me.Sound.TabIndex = 3
            Me.Sound.Text = Global.Launcher.My.Resources.Resources.frmOptions_sound
            Me.Sound.UseVisualStyleBackColor = True
            '
            'numMusicVolume
            '
            Me.numMusicVolume.Location = New System.Drawing.Point(248, 59)
            Me.numMusicVolume.Name = "numMusicVolume"
            Me.numMusicVolume.Size = New System.Drawing.Size(239, 20)
            Me.numMusicVolume.TabIndex = 39
            Me.numMusicVolume.Value = New Decimal(New Integer() {100, 0, 0, 0})
            '
            'laMusicVolume
            '
            Me.laMusicVolume.AutoSize = True
            Me.laMusicVolume.Location = New System.Drawing.Point(248, 43)
            Me.laMusicVolume.Name = "laMusicVolume"
            Me.laMusicVolume.Size = New System.Drawing.Size(75, 13)
            Me.laMusicVolume.TabIndex = 38
            Me.laMusicVolume.Text = Global.Launcher.My.Resources.Resources.frmOptions_MusicVolume
            '
            'numMasterVolume
            '
            Me.numMasterVolume.Location = New System.Drawing.Point(3, 59)
            Me.numMasterVolume.Name = "numMasterVolume"
            Me.numMasterVolume.Size = New System.Drawing.Size(239, 20)
            Me.numMasterVolume.TabIndex = 35
            Me.numMasterVolume.Value = New Decimal(New Integer() {100, 0, 0, 0})
            '
            'laMasterVolume
            '
            Me.laMasterVolume.AutoSize = True
            Me.laMasterVolume.Location = New System.Drawing.Point(3, 43)
            Me.laMasterVolume.Name = "laMasterVolume"
            Me.laMasterVolume.Size = New System.Drawing.Size(79, 13)
            Me.laMasterVolume.TabIndex = 34
            Me.laMasterVolume.Text = Global.Launcher.My.Resources.Resources.frmOptions_MasterVolume
            '
            'GUI
            '
            Me.GUI.Controls.Add(Me.chkInvertViewportDrag)
            Me.GUI.Controls.Add(Me.chkConsoleSmallFont)
            Me.GUI.Controls.Add(Me.chkToolbarShowCheats)
            Me.GUI.Controls.Add(Me.numWindowSnapProximity)
            Me.GUI.Controls.Add(Me.chkToolbarShowResearch)
            Me.GUI.Controls.Add(Me.laWindowSnapProximity)
            Me.GUI.Controls.Add(Me.chkToolbarShowFinances)
            Me.GUI.Controls.Add(Me.chkEdgeScrolling)
            Me.GUI.Location = New System.Drawing.Point(4, 22)
            Me.GUI.Name = "GUI"
            Me.GUI.Size = New System.Drawing.Size(492, 193)
            Me.GUI.TabIndex = 4
            Me.GUI.Text = Global.Launcher.My.Resources.Resources.frmOptions_gui
            Me.GUI.UseVisualStyleBackColor = True
            '
            'chkInvertViewportDrag
            '
            Me.chkInvertViewportDrag.AutoSize = True
            Me.chkInvertViewportDrag.Location = New System.Drawing.Point(248, 91)
            Me.chkInvertViewportDrag.Name = "chkInvertViewportDrag"
            Me.chkInvertViewportDrag.Size = New System.Drawing.Size(154, 17)
            Me.chkInvertViewportDrag.TabIndex = 30
            Me.chkInvertViewportDrag.Text = Global.Launcher.My.Resources.Resources.frmOptions_InvertViewportDrag
            Me.chkInvertViewportDrag.UseVisualStyleBackColor = True
            '
            'chkConsoleSmallFont
            '
            Me.chkConsoleSmallFont.AutoSize = True
            Me.chkConsoleSmallFont.Location = New System.Drawing.Point(3, 91)
            Me.chkConsoleSmallFont.Name = "chkConsoleSmallFont"
            Me.chkConsoleSmallFont.Size = New System.Drawing.Size(143, 17)
            Me.chkConsoleSmallFont.TabIndex = 29
            Me.chkConsoleSmallFont.Text = Global.Launcher.My.Resources.Resources.frmOptions_consoleSmallFont
            Me.chkConsoleSmallFont.UseVisualStyleBackColor = True
            '
            'chkToolbarShowCheats
            '
            Me.chkToolbarShowCheats.AutoSize = True
            Me.chkToolbarShowCheats.Location = New System.Drawing.Point(248, 68)
            Me.chkToolbarShowCheats.Name = "chkToolbarShowCheats"
            Me.chkToolbarShowCheats.Size = New System.Drawing.Size(171, 17)
            Me.chkToolbarShowCheats.TabIndex = 10
            Me.chkToolbarShowCheats.Text = Global.Launcher.My.Resources.Resources.frmOptions_toolbarShowCheats
            Me.chkToolbarShowCheats.UseVisualStyleBackColor = True
            '
            'chkToolbarShowResearch
            '
            Me.chkToolbarShowResearch.AutoSize = True
            Me.chkToolbarShowResearch.Location = New System.Drawing.Point(3, 68)
            Me.chkToolbarShowResearch.Name = "chkToolbarShowResearch"
            Me.chkToolbarShowResearch.Size = New System.Drawing.Size(180, 17)
            Me.chkToolbarShowResearch.TabIndex = 9
            Me.chkToolbarShowResearch.Text = Global.Launcher.My.Resources.Resources.frmOptions_toolbarShowResearch
            Me.chkToolbarShowResearch.UseVisualStyleBackColor = True
            '
            'chkToolbarShowFinances
            '
            Me.chkToolbarShowFinances.AutoSize = True
            Me.chkToolbarShowFinances.Location = New System.Drawing.Point(248, 45)
            Me.chkToolbarShowFinances.Name = "chkToolbarShowFinances"
            Me.chkToolbarShowFinances.Size = New System.Drawing.Size(179, 17)
            Me.chkToolbarShowFinances.TabIndex = 8
            Me.chkToolbarShowFinances.Text = Global.Launcher.My.Resources.Resources.frmOptions_toolbarShowFinances
            Me.chkToolbarShowFinances.UseVisualStyleBackColor = True
            '
            'Cheats
            '
            Me.Cheats.Controls.Add(Me.chkBuildInPauseMode)
            Me.Cheats.Controls.Add(Me.chkUnlockAllPrices)
            Me.Cheats.Controls.Add(Me.chkDisableAllBreakdowns)
            Me.Cheats.Controls.Add(Me.chkDisableBrakesFailure)
            Me.Cheats.Controls.Add(Me.chkFastLiftHill)
            Me.Cheats.Location = New System.Drawing.Point(4, 22)
            Me.Cheats.Name = "Cheats"
            Me.Cheats.Size = New System.Drawing.Size(492, 193)
            Me.Cheats.TabIndex = 7
            Me.Cheats.Text = Global.Launcher.My.Resources.Resources.frmOptions_cheats
            Me.Cheats.UseVisualStyleBackColor = True
            '
            'chkBuildInPauseMode
            '
            Me.chkBuildInPauseMode.AutoSize = True
            Me.chkBuildInPauseMode.Location = New System.Drawing.Point(3, 49)
            Me.chkBuildInPauseMode.Name = "chkBuildInPauseMode"
            Me.chkBuildInPauseMode.Size = New System.Drawing.Size(162, 17)
            Me.chkBuildInPauseMode.TabIndex = 4
            Me.chkBuildInPauseMode.Text = Global.Launcher.My.Resources.Resources.frmOptions_BuildInPauseMode
            Me.chkBuildInPauseMode.UseVisualStyleBackColor = True
            '
            'chkUnlockAllPrices
            '
            Me.chkUnlockAllPrices.AutoSize = True
            Me.chkUnlockAllPrices.Location = New System.Drawing.Point(248, 26)
            Me.chkUnlockAllPrices.Name = "chkUnlockAllPrices"
            Me.chkUnlockAllPrices.Size = New System.Drawing.Size(158, 17)
            Me.chkUnlockAllPrices.TabIndex = 3
            Me.chkUnlockAllPrices.Text = Global.Launcher.My.Resources.Resources.frmOptions_unlockAllPrices
            Me.chkUnlockAllPrices.UseVisualStyleBackColor = True
            '
            'chkDisableAllBreakdowns
            '
            Me.chkDisableAllBreakdowns.AutoSize = True
            Me.chkDisableAllBreakdowns.Location = New System.Drawing.Point(3, 26)
            Me.chkDisableAllBreakdowns.Name = "chkDisableAllBreakdowns"
            Me.chkDisableAllBreakdowns.Size = New System.Drawing.Size(122, 17)
            Me.chkDisableAllBreakdowns.TabIndex = 2
            Me.chkDisableAllBreakdowns.Text = Global.Launcher.My.Resources.Resources.frmOptions_disableAllBreakdowns
            Me.chkDisableAllBreakdowns.UseVisualStyleBackColor = True
            '
            'chkDisableBrakesFailure
            '
            Me.chkDisableBrakesFailure.AutoSize = True
            Me.chkDisableBrakesFailure.Location = New System.Drawing.Point(248, 3)
            Me.chkDisableBrakesFailure.Name = "chkDisableBrakesFailure"
            Me.chkDisableBrakesFailure.Size = New System.Drawing.Size(127, 17)
            Me.chkDisableBrakesFailure.TabIndex = 1
            Me.chkDisableBrakesFailure.Text = Global.Launcher.My.Resources.Resources.frmOptions_disableBrakesFailure
            Me.chkDisableBrakesFailure.UseVisualStyleBackColor = True
            '
            'chkFastLiftHill
            '
            Me.chkFastLiftHill.AutoSize = True
            Me.chkFastLiftHill.Location = New System.Drawing.Point(3, 3)
            Me.chkFastLiftHill.Name = "chkFastLiftHill"
            Me.chkFastLiftHill.Size = New System.Drawing.Size(145, 17)
            Me.chkFastLiftHill.TabIndex = 0
            Me.chkFastLiftHill.Text = Global.Launcher.My.Resources.Resources.frmOptions_fastLiftHill
            Me.chkFastLiftHill.UseVisualStyleBackColor = True
            '
            'Launcher
            '
            Me.Launcher.Controls.Add(Me.rdoDevelop)
            Me.Launcher.Controls.Add(Me.rdoStable)
            Me.Launcher.Controls.Add(Me.chkInstallUpdates)
            Me.Launcher.Controls.Add(Me.tbGamePath)
            Me.Launcher.Controls.Add(Me.laGamePath)
            Me.Launcher.Controls.Add(Me.cmdGamePath)
            Me.Launcher.Controls.Add(Me.chkCheckUpdates)
            Me.Launcher.Location = New System.Drawing.Point(4, 22)
            Me.Launcher.Name = "Launcher"
            Me.Launcher.Padding = New System.Windows.Forms.Padding(3)
            Me.Launcher.Size = New System.Drawing.Size(492, 193)
            Me.Launcher.TabIndex = 0
            Me.Launcher.Text = Global.Launcher.My.Resources.Resources.frmOptions_launcher
            Me.Launcher.UseVisualStyleBackColor = True
            '
            'rdoDevelop
            '
            Me.rdoDevelop.AutoSize = True
            Me.rdoDevelop.Location = New System.Drawing.Point(3, 91)
            Me.rdoDevelop.Name = "rdoDevelop"
            Me.rdoDevelop.Size = New System.Drawing.Size(170, 17)
            Me.rdoDevelop.TabIndex = 4
            Me.rdoDevelop.TabStop = True
            Me.rdoDevelop.Text = Global.Launcher.My.Resources.Resources.frmOptions_rdoDevelop
            Me.rdoDevelop.UseVisualStyleBackColor = True
            '
            'rdoStable
            '
            Me.rdoStable.AutoSize = True
            Me.rdoStable.Location = New System.Drawing.Point(3, 68)
            Me.rdoStable.Name = "rdoStable"
            Me.rdoStable.Size = New System.Drawing.Size(161, 17)
            Me.rdoStable.TabIndex = 3
            Me.rdoStable.TabStop = True
            Me.rdoStable.Text = Global.Launcher.My.Resources.Resources.frmOptions_rdoStable
            Me.rdoStable.UseVisualStyleBackColor = True
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
            Me.Debugging.Size = New System.Drawing.Size(492, 193)
            Me.Debugging.TabIndex = 6
            Me.Debugging.Text = Global.Launcher.My.Resources.Resources.frmOptions_debugging
            Me.Debugging.UseVisualStyleBackColor = True
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
            Me.Twitch.Size = New System.Drawing.Size(492, 193)
            Me.Twitch.TabIndex = 8
            Me.Twitch.Text = Global.Launcher.My.Resources.Resources.frmOptions_twitch
            Me.Twitch.UseVisualStyleBackColor = True
            '
            'chkNews
            '
            Me.chkNews.AutoSize = True
            Me.chkNews.Location = New System.Drawing.Point(3, 91)
            Me.chkNews.Name = "chkNews"
            Me.chkNews.Size = New System.Drawing.Size(144, 17)
            Me.chkNews.TabIndex = 6
            Me.chkNews.Text = Global.Launcher.My.Resources.Resources.frmOptions_chkNews
            Me.chkNews.UseVisualStyleBackColor = True
            '
            'chkChatPeepTracking
            '
            Me.chkChatPeepTracking.AutoSize = True
            Me.chkChatPeepTracking.Location = New System.Drawing.Point(248, 68)
            Me.chkChatPeepTracking.Name = "chkChatPeepTracking"
            Me.chkChatPeepTracking.Size = New System.Drawing.Size(110, 17)
            Me.chkChatPeepTracking.TabIndex = 5
            Me.chkChatPeepTracking.Text = Global.Launcher.My.Resources.Resources.frmOptions_chkChatPeepTracking
            Me.chkChatPeepTracking.UseVisualStyleBackColor = True
            '
            'chkChatPeepNames
            '
            Me.chkChatPeepNames.AutoSize = True
            Me.chkChatPeepNames.Location = New System.Drawing.Point(3, 68)
            Me.chkChatPeepNames.Name = "chkChatPeepNames"
            Me.chkChatPeepNames.Size = New System.Drawing.Size(215, 17)
            Me.chkChatPeepNames.TabIndex = 4
            Me.chkChatPeepNames.Text = Global.Launcher.My.Resources.Resources.frmOptions_chkChatPeepNames
            Me.chkChatPeepNames.UseVisualStyleBackColor = True
            '
            'chkFollowerPeepTracking
            '
            Me.chkFollowerPeepTracking.AutoSize = True
            Me.chkFollowerPeepTracking.Location = New System.Drawing.Point(248, 45)
            Me.chkFollowerPeepTracking.Name = "chkFollowerPeepTracking"
            Me.chkFollowerPeepTracking.Size = New System.Drawing.Size(125, 17)
            Me.chkFollowerPeepTracking.TabIndex = 3
            Me.chkFollowerPeepTracking.Text = Global.Launcher.My.Resources.Resources.frmOptions_chkFollowerPeepTracking
            Me.chkFollowerPeepTracking.UseVisualStyleBackColor = True
            '
            'chkFollowerPeepNames
            '
            Me.chkFollowerPeepNames.AutoSize = True
            Me.chkFollowerPeepNames.Location = New System.Drawing.Point(3, 45)
            Me.chkFollowerPeepNames.Name = "chkFollowerPeepNames"
            Me.chkFollowerPeepNames.Size = New System.Drawing.Size(154, 17)
            Me.chkFollowerPeepNames.TabIndex = 2
            Me.chkFollowerPeepNames.Text = Global.Launcher.My.Resources.Resources.frmOptions_chkFollowerPeepNames
            Me.chkFollowerPeepNames.UseVisualStyleBackColor = True
            '
            'tbChannel
            '
            Me.tbChannel.Location = New System.Drawing.Point(3, 19)
            Me.tbChannel.Name = "tbChannel"
            Me.tbChannel.Size = New System.Drawing.Size(484, 20)
            Me.tbChannel.TabIndex = 1
            '
            'laChannel
            '
            Me.laChannel.AutoSize = True
            Me.laChannel.Location = New System.Drawing.Point(3, 3)
            Me.laChannel.Name = "laChannel"
            Me.laChannel.Size = New System.Drawing.Size(110, 13)
            Me.laChannel.TabIndex = 0
            Me.laChannel.Text = Global.Launcher.My.Resources.Resources.frmOptions_laChannel
            '
            'Miscellaneous
            '
            Me.Miscellaneous.Controls.Add(Me.chkAutoStaff)
            Me.Miscellaneous.Controls.Add(Me.chkNoTestCrashes)
            Me.Miscellaneous.Controls.Add(Me.chkConfirmationPrompt)
            Me.Miscellaneous.Controls.Add(Me.chkPlayIntro)
            Me.Miscellaneous.Controls.Add(Me.chkTestUnfinishedTracks)
            Me.Miscellaneous.Controls.Add(Me.chkDebuggingTools)
            Me.Miscellaneous.Controls.Add(Me.laScreenshotFormat)
            Me.Miscellaneous.Controls.Add(Me.cbScreenshotFormat)
            Me.Miscellaneous.Controls.Add(Me.cbAutosave)
            Me.Miscellaneous.Controls.Add(Me.chkSelectByTrackType)
            Me.Miscellaneous.Controls.Add(Me.laAutosave)
            Me.Miscellaneous.Controls.Add(Me.chkSavePluginData)
            Me.Miscellaneous.Location = New System.Drawing.Point(4, 22)
            Me.Miscellaneous.Name = "Miscellaneous"
            Me.Miscellaneous.Size = New System.Drawing.Size(492, 193)
            Me.Miscellaneous.TabIndex = 5
            Me.Miscellaneous.Text = Global.Launcher.My.Resources.Resources.frmOptions_miscellaneous
            Me.Miscellaneous.UseVisualStyleBackColor = True
            '
            'chkAutoStaff
            '
            Me.chkAutoStaff.AutoSize = True
            Me.chkAutoStaff.Location = New System.Drawing.Point(248, 115)
            Me.chkAutoStaff.Name = "chkAutoStaff"
            Me.chkAutoStaff.Size = New System.Drawing.Size(140, 17)
            Me.chkAutoStaff.TabIndex = 22
            Me.chkAutoStaff.Text = Global.Launcher.My.Resources.Resources.frmOptions_AutoStaff
            Me.chkAutoStaff.UseVisualStyleBackColor = True
            '
            'chkNoTestCrashes
            '
            Me.chkNoTestCrashes.AutoSize = True
            Me.chkNoTestCrashes.Location = New System.Drawing.Point(3, 92)
            Me.chkNoTestCrashes.Name = "chkNoTestCrashes"
            Me.chkNoTestCrashes.Size = New System.Drawing.Size(141, 17)
            Me.chkNoTestCrashes.TabIndex = 21
            Me.chkNoTestCrashes.Text = Global.Launcher.My.Resources.Resources.frmOptions_chkNoTestCrashes
            Me.chkNoTestCrashes.UseVisualStyleBackColor = True
            '
            'chkTestUnfinishedTracks
            '
            Me.chkTestUnfinishedTracks.AutoSize = True
            Me.chkTestUnfinishedTracks.Location = New System.Drawing.Point(248, 69)
            Me.chkTestUnfinishedTracks.Name = "chkTestUnfinishedTracks"
            Me.chkTestUnfinishedTracks.Size = New System.Drawing.Size(180, 17)
            Me.chkTestUnfinishedTracks.TabIndex = 20
            Me.chkTestUnfinishedTracks.Text = Global.Launcher.My.Resources.Resources.frmOptions_chkTestUnfinishedTracks
            Me.chkTestUnfinishedTracks.UseVisualStyleBackColor = True
            '
            'chkDebuggingTools
            '
            Me.chkDebuggingTools.AutoSize = True
            Me.chkDebuggingTools.Location = New System.Drawing.Point(3, 69)
            Me.chkDebuggingTools.Name = "chkDebuggingTools"
            Me.chkDebuggingTools.Size = New System.Drawing.Size(137, 17)
            Me.chkDebuggingTools.TabIndex = 19
            Me.chkDebuggingTools.Text = Global.Launcher.My.Resources.Resources.frmOptions_chkDebuggingTools
            Me.chkDebuggingTools.UseVisualStyleBackColor = True
            '
            'chkSelectByTrackType
            '
            Me.chkSelectByTrackType.AutoSize = True
            Me.chkSelectByTrackType.Location = New System.Drawing.Point(248, 46)
            Me.chkSelectByTrackType.Name = "chkSelectByTrackType"
            Me.chkSelectByTrackType.Size = New System.Drawing.Size(226, 17)
            Me.chkSelectByTrackType.TabIndex = 18
            Me.chkSelectByTrackType.Text = Global.Launcher.My.Resources.Resources.frmOptions_chkAllowSubtypeSwitching
            Me.chkSelectByTrackType.UseVisualStyleBackColor = True
            '
            'FrmOptions
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(524, 272)
            Me.Controls.Add(Me.tcMain)
            Me.Controls.Add(Me.cmdReset)
            Me.Controls.Add(Me.cmdCancel)
            Me.Controls.Add(Me.cmdOk)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "FrmOptions"
            Me.ShowIcon = False
            Me.ShowInTaskbar = False
            Me.Text = Global.Launcher.My.Resources.Resources.frmOptions_title
            CType(Me.numFullscreenWidth, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.numFullscreenHeight, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.numWindowHeight, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.numWindowWidth, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.numWindowSnapProximity, System.ComponentModel.ISupportInitialize).EndInit()
            Me.tcMain.ResumeLayout(False)
            Me.Graphics.ResumeLayout(False)
            Me.Graphics.PerformLayout()
            Me.Localisation.ResumeLayout(False)
            Me.Localisation.PerformLayout()
            Me.Sound.ResumeLayout(False)
            Me.Sound.PerformLayout()
            CType(Me.numMusicVolume, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.numMasterVolume, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GUI.ResumeLayout(False)
            Me.GUI.PerformLayout()
            Me.Cheats.ResumeLayout(False)
            Me.Cheats.PerformLayout()
            Me.Launcher.ResumeLayout(False)
            Me.Launcher.PerformLayout()
            Me.Debugging.ResumeLayout(False)
            Me.Debugging.PerformLayout()
            Me.Twitch.ResumeLayout(False)
            Me.Twitch.PerformLayout()
            Me.Miscellaneous.ResumeLayout(False)
            Me.Miscellaneous.PerformLayout()
            Me.ResumeLayout(False)

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
        Friend WithEvents chkToolbarShowCheats As System.Windows.Forms.CheckBox
        Friend WithEvents chkToolbarShowResearch As System.Windows.Forms.CheckBox
        Friend WithEvents chkToolbarShowFinances As System.Windows.Forms.CheckBox
        Friend WithEvents chkTestUnfinishedTracks As System.Windows.Forms.CheckBox
        Friend WithEvents chkDebuggingTools As System.Windows.Forms.CheckBox
        Friend WithEvents chkSelectByTrackType As System.Windows.Forms.CheckBox
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
        Friend WithEvents rdoDevelop As System.Windows.Forms.RadioButton
        Friend WithEvents rdoStable As System.Windows.Forms.RadioButton
        Friend WithEvents chkUncapFPS As System.Windows.Forms.CheckBox
        Friend WithEvents chkMinimizeFullscreenFocusLoss As System.Windows.Forms.CheckBox
        Friend WithEvents numMusicVolume As System.Windows.Forms.NumericUpDown
        Friend WithEvents laMusicVolume As System.Windows.Forms.Label
        Friend WithEvents numMasterVolume As System.Windows.Forms.NumericUpDown
        Friend WithEvents laMasterVolume As System.Windows.Forms.Label
        Friend WithEvents chkInvertViewportDrag As System.Windows.Forms.CheckBox
        Friend WithEvents chkBuildInPauseMode As System.Windows.Forms.CheckBox
        Friend WithEvents chkAutoStaff As System.Windows.Forms.CheckBox
    End Class
End Namespace