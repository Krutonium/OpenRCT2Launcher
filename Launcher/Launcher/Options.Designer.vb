<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOptions
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
        Me.label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbScreenshotFormat = New System.Windows.Forms.ComboBox()
        Me.chkPlayIntro = New System.Windows.Forms.CheckBox()
        Me.chkConfirmationPrompt = New System.Windows.Forms.CheckBox()
        Me.chkEdgeScrolling = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbCurrency = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cbMeasurementFormat = New System.Windows.Forms.ComboBox()
        Me.cbTemperatureFormat = New System.Windows.Forms.ComboBox()
        Me.chkAlwaysShowGridlines = New System.Windows.Forms.CheckBox()
        Me.chkLandscapeSmoothing = New System.Windows.Forms.CheckBox()
        Me.chkSavePluginData = New System.Windows.Forms.CheckBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cbFullscreenMode = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.numFullscreenWidth = New System.Windows.Forms.NumericUpDown()
        Me.numFullscreenHeight = New System.Windows.Forms.NumericUpDown()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cbLanguage = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cbTitleMusic = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cbSoundQuality = New System.Windows.Forms.ComboBox()
        Me.chkForcedSoftwareBuffering = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cbShowHeightAsUnits = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.cmdOk = New System.Windows.Forms.Button()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdApply = New System.Windows.Forms.Button()
        Me.cmdReset = New System.Windows.Forms.Button()
        Me.FBD = New System.Windows.Forms.FolderBrowserDialog()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.tbArguments = New System.Windows.Forms.TextBox()
        Me.cmdOutputPath = New System.Windows.Forms.Button()
        Me.tbOutputPath = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.chkSaveOutput = New System.Windows.Forms.CheckBox()
        Me.chkVerbose = New System.Windows.Forms.CheckBox()
        Me.SFD = New System.Windows.Forms.SaveFileDialog()
        CType(Me.numFullscreenWidth, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numFullscreenHeight, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.SuspendLayout()
        '
        'tbGamePath
        '
        Me.tbGamePath.Location = New System.Drawing.Point(6, 32)
        Me.tbGamePath.Name = "tbGamePath"
        Me.tbGamePath.Size = New System.Drawing.Size(210, 20)
        Me.tbGamePath.TabIndex = 0
        '
        'cmdGamePath
        '
        Me.cmdGamePath.Location = New System.Drawing.Point(222, 30)
        Me.cmdGamePath.Name = "cmdGamePath"
        Me.cmdGamePath.Size = New System.Drawing.Size(30, 23)
        Me.cmdGamePath.TabIndex = 1
        Me.cmdGamePath.Text = "..."
        Me.cmdGamePath.UseVisualStyleBackColor = True
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(6, 16)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(63, 13)
        Me.label1.TabIndex = 2
        Me.label1.Text = "Game Path:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(270, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(99, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Screenshot Format:"
        '
        'cbScreenshotFormat
        '
        Me.cbScreenshotFormat.DisplayMember = "1"
        Me.cbScreenshotFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbScreenshotFormat.FormattingEnabled = True
        Me.cbScreenshotFormat.Items.AddRange(New Object() {"*.bmp", "*.png"})
        Me.cbScreenshotFormat.Location = New System.Drawing.Point(270, 32)
        Me.cbScreenshotFormat.Name = "cbScreenshotFormat"
        Me.cbScreenshotFormat.Size = New System.Drawing.Size(246, 21)
        Me.cbScreenshotFormat.TabIndex = 4
        '
        'chkPlayIntro
        '
        Me.chkPlayIntro.AutoSize = True
        Me.chkPlayIntro.Location = New System.Drawing.Point(6, 58)
        Me.chkPlayIntro.Name = "chkPlayIntro"
        Me.chkPlayIntro.Size = New System.Drawing.Size(70, 17)
        Me.chkPlayIntro.TabIndex = 5
        Me.chkPlayIntro.Text = "Play Intro"
        Me.chkPlayIntro.UseVisualStyleBackColor = True
        '
        'chkConfirmationPrompt
        '
        Me.chkConfirmationPrompt.AutoSize = True
        Me.chkConfirmationPrompt.Location = New System.Drawing.Point(270, 59)
        Me.chkConfirmationPrompt.Name = "chkConfirmationPrompt"
        Me.chkConfirmationPrompt.Size = New System.Drawing.Size(150, 17)
        Me.chkConfirmationPrompt.TabIndex = 6
        Me.chkConfirmationPrompt.Text = "Show Confirmation Prompt"
        Me.chkConfirmationPrompt.UseVisualStyleBackColor = True
        '
        'chkEdgeScrolling
        '
        Me.chkEdgeScrolling.AutoSize = True
        Me.chkEdgeScrolling.Location = New System.Drawing.Point(6, 81)
        Me.chkEdgeScrolling.Name = "chkEdgeScrolling"
        Me.chkEdgeScrolling.Size = New System.Drawing.Size(215, 17)
        Me.chkEdgeScrolling.TabIndex = 7
        Me.chkEdgeScrolling.Text = "Scroll view when pointer at screen edge"
        Me.chkEdgeScrolling.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(132, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(52, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Currency:"
        '
        'cbCurrency
        '
        Me.cbCurrency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbCurrency.FormattingEnabled = True
        Me.cbCurrency.Items.AddRange(New Object() {"Pounds (£)", "Dollars ($)", "Franc (F)", "Deutschmark (DM)", "Yen (¥)", "Peseta (Pts)", "Lira (L)", "Guilders (Dfl.)", "Krona (kr)", "Euro (€)"})
        Me.cbCurrency.Location = New System.Drawing.Point(131, 32)
        Me.cbCurrency.Name = "cbCurrency"
        Me.cbCurrency.Size = New System.Drawing.Size(121, 21)
        Me.cbCurrency.TabIndex = 9
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 57)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(107, 13)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Distance and Speed:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(132, 57)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(70, 13)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Temperature:"
        '
        'cbMeasurementFormat
        '
        Me.cbMeasurementFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbMeasurementFormat.FormattingEnabled = True
        Me.cbMeasurementFormat.Items.AddRange(New Object() {"Imperial", "Metric"})
        Me.cbMeasurementFormat.Location = New System.Drawing.Point(6, 73)
        Me.cbMeasurementFormat.Name = "cbMeasurementFormat"
        Me.cbMeasurementFormat.Size = New System.Drawing.Size(121, 21)
        Me.cbMeasurementFormat.TabIndex = 12
        '
        'cbTemperatureFormat
        '
        Me.cbTemperatureFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbTemperatureFormat.FormattingEnabled = True
        Me.cbTemperatureFormat.Items.AddRange(New Object() {"Celsius (°C)", "Fahrenheit (F)"})
        Me.cbTemperatureFormat.Location = New System.Drawing.Point(131, 73)
        Me.cbTemperatureFormat.Name = "cbTemperatureFormat"
        Me.cbTemperatureFormat.Size = New System.Drawing.Size(121, 21)
        Me.cbTemperatureFormat.TabIndex = 13
        '
        'chkAlwaysShowGridlines
        '
        Me.chkAlwaysShowGridlines.AutoSize = True
        Me.chkAlwaysShowGridlines.Location = New System.Drawing.Point(6, 121)
        Me.chkAlwaysShowGridlines.Name = "chkAlwaysShowGridlines"
        Me.chkAlwaysShowGridlines.Size = New System.Drawing.Size(137, 17)
        Me.chkAlwaysShowGridlines.TabIndex = 14
        Me.chkAlwaysShowGridlines.Text = "Gridlines on Landscape"
        Me.chkAlwaysShowGridlines.UseVisualStyleBackColor = True
        '
        'chkLandscapeSmoothing
        '
        Me.chkLandscapeSmoothing.AutoSize = True
        Me.chkLandscapeSmoothing.Location = New System.Drawing.Point(6, 98)
        Me.chkLandscapeSmoothing.Name = "chkLandscapeSmoothing"
        Me.chkLandscapeSmoothing.Size = New System.Drawing.Size(132, 17)
        Me.chkLandscapeSmoothing.TabIndex = 15
        Me.chkLandscapeSmoothing.Text = "Landscape Smoothing"
        Me.chkLandscapeSmoothing.UseVisualStyleBackColor = True
        '
        'chkSavePluginData
        '
        Me.chkSavePluginData.AutoSize = True
        Me.chkSavePluginData.Location = New System.Drawing.Point(270, 82)
        Me.chkSavePluginData.Name = "chkSavePluginData"
        Me.chkSavePluginData.Size = New System.Drawing.Size(215, 17)
        Me.chkSavePluginData.TabIndex = 17
        Me.chkSavePluginData.Text = "Export plug-in objects with saved games"
        Me.chkSavePluginData.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 55)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(87, 13)
        Me.Label6.TabIndex = 18
        Me.Label6.Text = "Fullscreen mode:"
        '
        'cbFullscreenMode
        '
        Me.cbFullscreenMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbFullscreenMode.FormattingEnabled = True
        Me.cbFullscreenMode.Items.AddRange(New Object() {"Windowed", "Fullscreen", "Fullscreen (desktop)"})
        Me.cbFullscreenMode.Location = New System.Drawing.Point(6, 71)
        Me.cbFullscreenMode.Name = "cbFullscreenMode"
        Me.cbFullscreenMode.Size = New System.Drawing.Size(246, 21)
        Me.cbFullscreenMode.TabIndex = 19
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 16)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(86, 13)
        Me.Label7.TabIndex = 20
        Me.Label7.Text = "Fullscreen width:"
        '
        'numFullscreenWidth
        '
        Me.numFullscreenWidth.Increment = New Decimal(New Integer() {100, 0, 0, 0})
        Me.numFullscreenWidth.Location = New System.Drawing.Point(6, 32)
        Me.numFullscreenWidth.Maximum = New Decimal(New Integer() {-2147483648, 0, 0, 0})
        Me.numFullscreenWidth.Minimum = New Decimal(New Integer() {1, 0, 0, -2147483648})
        Me.numFullscreenWidth.Name = "numFullscreenWidth"
        Me.numFullscreenWidth.Size = New System.Drawing.Size(120, 20)
        Me.numFullscreenWidth.TabIndex = 22
        '
        'numFullscreenHeight
        '
        Me.numFullscreenHeight.Increment = New Decimal(New Integer() {100, 0, 0, 0})
        Me.numFullscreenHeight.Location = New System.Drawing.Point(132, 32)
        Me.numFullscreenHeight.Maximum = New Decimal(New Integer() {-2147483648, 0, 0, 0})
        Me.numFullscreenHeight.Minimum = New Decimal(New Integer() {1, 0, 0, -2147483648})
        Me.numFullscreenHeight.Name = "numFullscreenHeight"
        Me.numFullscreenHeight.Size = New System.Drawing.Size(120, 20)
        Me.numFullscreenHeight.TabIndex = 24
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(132, 16)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(90, 13)
        Me.Label8.TabIndex = 23
        Me.Label8.Text = "Fullscreen height:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(6, 16)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(58, 13)
        Me.Label9.TabIndex = 25
        Me.Label9.Text = "Language:"
        '
        'cbLanguage
        '
        Me.cbLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbLanguage.FormattingEnabled = True
        Me.cbLanguage.Items.AddRange(New Object() {"English (UK)", "English (US)", "Deutsch", "Nederlands", "Français", "Magyar", "Polski", "Español", "Svenska"})
        Me.cbLanguage.Location = New System.Drawing.Point(6, 32)
        Me.cbLanguage.Name = "cbLanguage"
        Me.cbLanguage.Size = New System.Drawing.Size(121, 21)
        Me.cbLanguage.TabIndex = 26
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(6, 56)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(95, 13)
        Me.Label10.TabIndex = 27
        Me.Label10.Text = "Title screen music:"
        '
        'cbTitleMusic
        '
        Me.cbTitleMusic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbTitleMusic.FormattingEnabled = True
        Me.cbTitleMusic.Items.AddRange(New Object() {"None", "RollerCoaster Tycoon 1", "RollerCoaster Tycoon 2"})
        Me.cbTitleMusic.Location = New System.Drawing.Point(6, 72)
        Me.cbTitleMusic.Name = "cbTitleMusic"
        Me.cbTitleMusic.Size = New System.Drawing.Size(246, 21)
        Me.cbTitleMusic.TabIndex = 28
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(6, 16)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(76, 13)
        Me.Label11.TabIndex = 29
        Me.Label11.Text = "Sound Quality:"
        '
        'cbSoundQuality
        '
        Me.cbSoundQuality.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbSoundQuality.FormattingEnabled = True
        Me.cbSoundQuality.Items.AddRange(New Object() {"Low", "Medium", "High"})
        Me.cbSoundQuality.Location = New System.Drawing.Point(6, 32)
        Me.cbSoundQuality.Name = "cbSoundQuality"
        Me.cbSoundQuality.Size = New System.Drawing.Size(246, 21)
        Me.cbSoundQuality.TabIndex = 30
        '
        'chkForcedSoftwareBuffering
        '
        Me.chkForcedSoftwareBuffering.AutoSize = True
        Me.chkForcedSoftwareBuffering.Location = New System.Drawing.Point(6, 99)
        Me.chkForcedSoftwareBuffering.Name = "chkForcedSoftwareBuffering"
        Me.chkForcedSoftwareBuffering.Size = New System.Drawing.Size(168, 17)
        Me.chkForcedSoftwareBuffering.TabIndex = 31
        Me.chkForcedSoftwareBuffering.Text = "Forced Software Buffer Mixing"
        Me.chkForcedSoftwareBuffering.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.numFullscreenWidth)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.numFullscreenHeight)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.cbFullscreenMode)
        Me.GroupBox1.Controls.Add(Me.chkLandscapeSmoothing)
        Me.GroupBox1.Controls.Add(Me.chkAlwaysShowGridlines)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 122)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(258, 144)
        Me.GroupBox1.TabIndex = 32
        Me.GroupBox1.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cbShowHeightAsUnits)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.cbLanguage)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.cbCurrency)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.cbMeasurementFormat)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.cbTemperatureFormat)
        Me.GroupBox2.Location = New System.Drawing.Point(276, 122)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(258, 144)
        Me.GroupBox2.TabIndex = 33
        Me.GroupBox2.TabStop = False
        '
        'cbShowHeightAsUnits
        '
        Me.cbShowHeightAsUnits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbShowHeightAsUnits.FormattingEnabled = True
        Me.cbShowHeightAsUnits.Items.AddRange(New Object() {"Units", "Real Values"})
        Me.cbShowHeightAsUnits.Location = New System.Drawing.Point(6, 113)
        Me.cbShowHeightAsUnits.Name = "cbShowHeightAsUnits"
        Me.cbShowHeightAsUnits.Size = New System.Drawing.Size(121, 21)
        Me.cbShowHeightAsUnits.TabIndex = 28
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(3, 97)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(75, 13)
        Me.Label12.TabIndex = 27
        Me.Label12.Text = "Height Labels:"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label11)
        Me.GroupBox3.Controls.Add(Me.cbSoundQuality)
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Controls.Add(Me.chkForcedSoftwareBuffering)
        Me.GroupBox3.Controls.Add(Me.cbTitleMusic)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 272)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(258, 146)
        Me.GroupBox3.TabIndex = 34
        Me.GroupBox3.TabStop = False
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.label1)
        Me.GroupBox4.Controls.Add(Me.tbGamePath)
        Me.GroupBox4.Controls.Add(Me.cmdGamePath)
        Me.GroupBox4.Controls.Add(Me.Label2)
        Me.GroupBox4.Controls.Add(Me.chkSavePluginData)
        Me.GroupBox4.Controls.Add(Me.cbScreenshotFormat)
        Me.GroupBox4.Controls.Add(Me.chkEdgeScrolling)
        Me.GroupBox4.Controls.Add(Me.chkPlayIntro)
        Me.GroupBox4.Controls.Add(Me.chkConfirmationPrompt)
        Me.GroupBox4.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(522, 104)
        Me.GroupBox4.TabIndex = 35
        Me.GroupBox4.TabStop = False
        '
        'cmdOk
        '
        Me.cmdOk.Location = New System.Drawing.Point(12, 424)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.Size = New System.Drawing.Size(126, 23)
        Me.cmdOk.TabIndex = 36
        Me.cmdOk.Text = "Ok"
        Me.cmdOk.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(144, 424)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(126, 23)
        Me.cmdCancel.TabIndex = 37
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdApply
        '
        Me.cmdApply.Location = New System.Drawing.Point(276, 424)
        Me.cmdApply.Name = "cmdApply"
        Me.cmdApply.Size = New System.Drawing.Size(126, 23)
        Me.cmdApply.TabIndex = 38
        Me.cmdApply.Text = "Apply"
        Me.cmdApply.UseVisualStyleBackColor = True
        '
        'cmdReset
        '
        Me.cmdReset.Location = New System.Drawing.Point(408, 424)
        Me.cmdReset.Name = "cmdReset"
        Me.cmdReset.Size = New System.Drawing.Size(126, 23)
        Me.cmdReset.TabIndex = 40
        Me.cmdReset.Text = "Reset"
        Me.cmdReset.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.Label14)
        Me.GroupBox5.Controls.Add(Me.tbArguments)
        Me.GroupBox5.Controls.Add(Me.cmdOutputPath)
        Me.GroupBox5.Controls.Add(Me.tbOutputPath)
        Me.GroupBox5.Controls.Add(Me.Label13)
        Me.GroupBox5.Controls.Add(Me.chkSaveOutput)
        Me.GroupBox5.Controls.Add(Me.chkVerbose)
        Me.GroupBox5.Location = New System.Drawing.Point(276, 272)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(258, 146)
        Me.GroupBox5.TabIndex = 41
        Me.GroupBox5.TabStop = False
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(6, 39)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(60, 13)
        Me.Label14.TabIndex = 6
        Me.Label14.Text = "Arguments:"
        '
        'tbArguments
        '
        Me.tbArguments.Location = New System.Drawing.Point(6, 55)
        Me.tbArguments.Name = "tbArguments"
        Me.tbArguments.Size = New System.Drawing.Size(246, 20)
        Me.tbArguments.TabIndex = 5
        '
        'cmdOutputPath
        '
        Me.cmdOutputPath.Location = New System.Drawing.Point(222, 117)
        Me.cmdOutputPath.Name = "cmdOutputPath"
        Me.cmdOutputPath.Size = New System.Drawing.Size(30, 23)
        Me.cmdOutputPath.TabIndex = 4
        Me.cmdOutputPath.Text = "..."
        Me.cmdOutputPath.UseVisualStyleBackColor = True
        '
        'tbOutputPath
        '
        Me.tbOutputPath.Location = New System.Drawing.Point(6, 119)
        Me.tbOutputPath.Name = "tbOutputPath"
        Me.tbOutputPath.Size = New System.Drawing.Size(210, 20)
        Me.tbOutputPath.TabIndex = 3
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(6, 101)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(67, 13)
        Me.Label13.TabIndex = 2
        Me.Label13.Text = "Output Path:"
        '
        'chkSaveOutput
        '
        Me.chkSaveOutput.AutoSize = True
        Me.chkSaveOutput.Location = New System.Drawing.Point(6, 81)
        Me.chkSaveOutput.Name = "chkSaveOutput"
        Me.chkSaveOutput.Size = New System.Drawing.Size(117, 17)
        Me.chkSaveOutput.TabIndex = 1
        Me.chkSaveOutput.Text = "Save Output to File"
        Me.chkSaveOutput.UseVisualStyleBackColor = True
        '
        'chkVerbose
        '
        Me.chkVerbose.AutoSize = True
        Me.chkVerbose.Location = New System.Drawing.Point(6, 19)
        Me.chkVerbose.Name = "chkVerbose"
        Me.chkVerbose.Size = New System.Drawing.Size(100, 17)
        Me.chkVerbose.TabIndex = 0
        Me.chkVerbose.Text = "Verbose Output"
        Me.chkVerbose.UseVisualStyleBackColor = True
        '
        'frmOptions
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(546, 455)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.cmdReset)
        Me.Controls.Add(Me.cmdApply)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmOptions"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Text = "Options"
        CType(Me.numFullscreenWidth, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numFullscreenHeight, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tbGamePath As System.Windows.Forms.TextBox
    Friend WithEvents cmdGamePath As System.Windows.Forms.Button
    Friend WithEvents label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cbScreenshotFormat As System.Windows.Forms.ComboBox
    Friend WithEvents chkPlayIntro As System.Windows.Forms.CheckBox
    Friend WithEvents chkConfirmationPrompt As System.Windows.Forms.CheckBox
    Friend WithEvents chkEdgeScrolling As System.Windows.Forms.CheckBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cbCurrency As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cbMeasurementFormat As System.Windows.Forms.ComboBox
    Friend WithEvents cbTemperatureFormat As System.Windows.Forms.ComboBox
    Friend WithEvents chkAlwaysShowGridlines As System.Windows.Forms.CheckBox
    Friend WithEvents chkLandscapeSmoothing As System.Windows.Forms.CheckBox
    Friend WithEvents chkSavePluginData As System.Windows.Forms.CheckBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cbFullscreenMode As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents numFullscreenWidth As System.Windows.Forms.NumericUpDown
    Friend WithEvents numFullscreenHeight As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cbLanguage As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cbTitleMusic As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cbSoundQuality As System.Windows.Forms.ComboBox
    Friend WithEvents chkForcedSoftwareBuffering As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cbShowHeightAsUnits As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdApply As System.Windows.Forms.Button
    Friend WithEvents cmdReset As System.Windows.Forms.Button
    Friend WithEvents FBD As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdOutputPath As System.Windows.Forms.Button
    Friend WithEvents tbOutputPath As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents chkSaveOutput As System.Windows.Forms.CheckBox
    Friend WithEvents chkVerbose As System.Windows.Forms.CheckBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents tbArguments As System.Windows.Forms.TextBox
    Friend WithEvents SFD As System.Windows.Forms.SaveFileDialog
End Class
