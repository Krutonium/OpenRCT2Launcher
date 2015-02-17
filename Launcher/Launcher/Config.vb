'Stores the configuration of OpenRCT2
Public Class OpenRCT2Config
    Enum EnumScreenshotFormat
        BMP
        PNG
    End Enum

    Enum EnumMeasurementFormat
        Imperial
        Metric
    End Enum

    Enum EnumTemperatureFormat
        Celsius
        Fahrenheit
    End Enum

    Enum EnumCurrencyFormat
        Pounds
        Dollars
        Franc
        Deutschmark
        Yen
        Peseta
        Lira
        Guilders
        Krona
        Euros
    End Enum

    Enum EnumFullscreenMode
        Window
        Fullscreen
        BorderlessFullscreen
    End Enum

    Enum EnumLanguage
        EnglishUK = 1
        EnglishUS
        German
        Dutch
        French
        Hungarian
        Polish
        Spanish
        Swedish
    End Enum

    Enum EnumTitleMusic
        None
        RCT1
        RCT2
    End Enum

    Enum EnumSoundQuality
        Low
        Medium
        High
    End Enum

    Public HasChanged As Boolean = False

    Public PlayIntro As Boolean
    Public ConfirmationPrompt As Boolean
    Public ScreenshotFormat As EnumScreenshotFormat
    Public GamePath As String
    Public MeasurementFormat As EnumMeasurementFormat
    Public TemperatureFormat As EnumTemperatureFormat
    Public CurrencyFormat As EnumCurrencyFormat
    Public EdgeScrolling As Boolean
    Public AlwaysShowGridlines As Boolean
    Public LandscapeSmoothing As Boolean
    Public ShowHeightAsUnits As Boolean
    Public SavePluginData As Boolean
    Public FullscreenMode As EnumFullscreenMode
    Public FullscreenWidth As Integer
    Public FullscreenHeight As Integer
    Public Language As EnumLanguage
    Public TitleMusic As EnumTitleMusic
    Public SoundQuality As EnumSoundQuality
    Public ForcedSoftwareBuffering As Boolean

    Dim INIConfig As New INI

    Public Sub LoadDefault()
        PlayIntro = False
        ConfirmationPrompt = False
        ScreenshotFormat = EnumScreenshotFormat.PNG
        GamePath = ""
        MeasurementFormat = EnumMeasurementFormat.Imperial
        TemperatureFormat = EnumTemperatureFormat.Celsius
        CurrencyFormat = EnumCurrencyFormat.Pounds
        EdgeScrolling = True
        AlwaysShowGridlines = False
        LandscapeSmoothing = True
        ShowHeightAsUnits = False
        SavePluginData = True
        FullscreenMode = EnumFullscreenMode.Window
        FullscreenWidth = -1
        FullscreenHeight = -1
        Language = EnumLanguage.EnglishUK
        TitleMusic = EnumTitleMusic.RCT2
        SoundQuality = EnumSoundQuality.Low
        ForcedSoftwareBuffering = False
    End Sub

    Public Sub LoadINI(File As String)
        Dim Value As String
        Dim Number As Integer

        INIConfig.Clear()

        Try
            INIConfig.Load(File)
        Catch ex As Exception
            Return
        End Try

        Value = INIConfig.FindValue("general", "play_intro")

        Select Case Value
            Case "true"
                PlayIntro = True
            Case "false"
                PlayIntro = False
        End Select

        Value = INIConfig.FindValue("general", "screenshot_format")

        Select Case Value
            Case "BMP"
                ScreenshotFormat = EnumScreenshotFormat.BMP
            Case "PNG"
                ScreenshotFormat = EnumScreenshotFormat.PNG
        End Select

        Value = INIConfig.FindValue("general", "game_path")

        If Value <> Nothing Then
            GamePath = Value
        End If

        Value = INIConfig.FindValue("general", "measurement_format")

        Select Case Value
            Case "IMPERIAL"
                MeasurementFormat = EnumMeasurementFormat.Imperial
            Case "METRIC"
                MeasurementFormat = EnumMeasurementFormat.Metric
        End Select

        Value = INIConfig.FindValue("general", "temperature_format")

        Select Case Value
            Case "CELSIUS"
                TemperatureFormat = EnumTemperatureFormat.Celsius
            Case "FAHRENHEIT"
                TemperatureFormat = EnumTemperatureFormat.Fahrenheit
        End Select

        Value = INIConfig.FindValue("general", "currency_format")

        Select Case Value
            Case "GBP"
                CurrencyFormat = EnumCurrencyFormat.Pounds
            Case "USD"
                CurrencyFormat = EnumCurrencyFormat.Dollars
            Case "FRF"
                CurrencyFormat = EnumCurrencyFormat.Franc
            Case "DEM"
                CurrencyFormat = EnumCurrencyFormat.Deutschmark
            Case "YEN"
                CurrencyFormat = EnumCurrencyFormat.Yen
            Case "ESP"
                CurrencyFormat = EnumCurrencyFormat.Peseta
            Case "ITL"
                CurrencyFormat = EnumCurrencyFormat.Lira
            Case "NLG"
                CurrencyFormat = EnumCurrencyFormat.Guilders
            Case "NOK"
                CurrencyFormat = EnumCurrencyFormat.Krona
            Case "SEK"
                CurrencyFormat = EnumCurrencyFormat.Krona
            Case "DEK"
                CurrencyFormat = EnumCurrencyFormat.Krona
            Case Chr(163)
                CurrencyFormat = EnumCurrencyFormat.Pounds
            Case Chr(36)
                CurrencyFormat = EnumCurrencyFormat.Dollars
            Case Chr(165)
                CurrencyFormat = EnumCurrencyFormat.Yen
            Case Chr(181)
                CurrencyFormat = EnumCurrencyFormat.Euros
        End Select

        Value = INIConfig.FindValue("general", "edge_scrolling")

        Select Case Value
            Case "true"
                EdgeScrolling = True
            Case "false"
                EdgeScrolling = False
        End Select

        Value = INIConfig.FindValue("general", "always_show_gridlines")

        Select Case Value
            Case "true"
                AlwaysShowGridlines = True
            Case "false"
                AlwaysShowGridlines = False
        End Select

        Value = INIConfig.FindValue("general", "landscape_smoothing")

        Select Case Value
            Case "true"
                LandscapeSmoothing = True
            Case "false"
                LandscapeSmoothing = False
        End Select

        Value = INIConfig.FindValue("general", "show_height_as_units")

        Select Case Value
            Case "true"
                ShowHeightAsUnits = True
            Case "false"
                ShowHeightAsUnits = False
        End Select

        Value = INIConfig.FindValue("general", "save_plugin_data")

        Select Case Value
            Case "true"
                SavePluginData = True
            Case "false"
                SavePluginData = False
        End Select

        Value = INIConfig.FindValue("general", "fullscreen_mode")

        If Int32.TryParse(Value, Number) Then
            If Number >= 0 And Number <= 2 Then
                FullscreenMode = Number
            End If
        End If

        Value = INIConfig.FindValue("general", "fullscreen_width")

        If Int32.TryParse(Value, Number) Then
            FullscreenWidth = Number
        End If

        Value = INIConfig.FindValue("general", "fullscreen_height")

        If Int32.TryParse(Value, Number) Then
            FullscreenHeight = Number
        End If

        Value = INIConfig.FindValue("general", "language")

        Select Case Value
            Case "en-GB"
                Language = EnumLanguage.EnglishUK
            Case "en-US"
                Language = EnumLanguage.EnglishUS
            Case "de-DE"
                Language = EnumLanguage.German
            Case "nl-NL"
                Language = EnumLanguage.Dutch
            Case "fr-FR"
                Language = EnumLanguage.French
            Case "hu-HU"
                Language = EnumLanguage.Hungarian
            Case "pl-PL"
                Language = EnumLanguage.Polish
            Case "es-ES"
                Language = EnumLanguage.Spanish
            Case "sv-SE"
                Language = EnumLanguage.Swedish
        End Select

        Value = INIConfig.FindValue("general", "title_music")

        If Int32.TryParse(Value, Number) Then
            If Number >= 0 And Number <= 2 Then
                TitleMusic = Number
            End If
        End If

        Value = INIConfig.FindValue("sound", "sound_quality")

        If Int32.TryParse(Value, Number) Then
            If Number >= 0 And Number <= 2 Then
                SoundQuality = Number
            End If
        End If

        Value = INIConfig.FindValue("sound", "forced_software_buffering")

        Select Case Value
            Case "true"
                ForcedSoftwareBuffering = True
            Case "false"
                ForcedSoftwareBuffering = False
        End Select
    End Sub

    Public Sub SaveINI(File As String)
        If ConfirmationPrompt Then
            INIConfig.SetValue("general", "confirmation_prompt", "true")
        Else
            INIConfig.SetValue("general", "confirmation_prompt", "false")
        End If

        Select Case ScreenshotFormat
            Case EnumScreenshotFormat.BMP
                INIConfig.SetValue("general", "screenshot_format", "BMP")
            Case EnumScreenshotFormat.PNG
                INIConfig.SetValue("general", "screenshot_format", "PNG")
        End Select

        INIConfig.SetValue("general", "game_path", GamePath)

        Select Case MeasurementFormat
            Case EnumMeasurementFormat.Imperial
                INIConfig.SetValue("general", "measurement_format", "IMPERIAL")
            Case EnumMeasurementFormat.Metric
                INIConfig.SetValue("general", "measurement_format", "METRIC")
        End Select

        Select Case TemperatureFormat
            Case EnumTemperatureFormat.Celsius
                INIConfig.SetValue("general", "temperature_format", "CELSIUS")
            Case EnumTemperatureFormat.Fahrenheit
                INIConfig.SetValue("general", "temperature_format", "FAHRENHEIT")
        End Select

        Select Case CurrencyFormat
            Case EnumCurrencyFormat.Pounds
                INIConfig.SetValue("general", "currency_format", "GBP")
            Case EnumCurrencyFormat.Dollars
                INIConfig.SetValue("general", "currency_format", "USD")
            Case EnumCurrencyFormat.Franc
                INIConfig.SetValue("general", "currency_format", "FRF")
            Case EnumCurrencyFormat.Deutschmark
                INIConfig.SetValue("general", "currency_format", "DEM")
            Case EnumCurrencyFormat.Yen
                INIConfig.SetValue("general", "currency_format", "YEN")
            Case EnumCurrencyFormat.Peseta
                INIConfig.SetValue("general", "currency_format", "ESP")
            Case EnumCurrencyFormat.Lira
                INIConfig.SetValue("general", "currency_format", "ITL")
            Case EnumCurrencyFormat.Guilders
                INIConfig.SetValue("general", "currency_format", "NLG")
            Case EnumCurrencyFormat.Krona
                INIConfig.SetValue("general", "currency_format", "NOK")
            Case EnumCurrencyFormat.Euros
                INIConfig.SetValue("general", "currency_format", "EUR")
        End Select

        If EdgeScrolling Then
            INIConfig.SetValue("general", "edge_scrolling", "true")
        Else
            INIConfig.SetValue("general", "edge_scrolling", "false")
        End If

        If AlwaysShowGridlines Then
            INIConfig.SetValue("general", "always_show_gridlines", "true")
        Else
            INIConfig.SetValue("general", "always_show_gridlines", "false")
        End If

        If LandscapeSmoothing Then
            INIConfig.SetValue("general", "landscape_smoothing", "true")
        Else
            INIConfig.SetValue("general", "landscape_smoothing", "false")
        End If

        If ShowHeightAsUnits Then
            INIConfig.SetValue("general", "show_height_as_units", "true")
        Else
            INIConfig.SetValue("general", "show_height_as_units", "false")
        End If

        If SavePluginData Then
            INIConfig.SetValue("general", "save_plugin_data", "true")
        Else
            INIConfig.SetValue("general", "save_plugin_data", "false")
        End If

        INIConfig.SetValue("general", "fullscreen_mode", FullscreenMode)

        INIConfig.SetValue("general", "fullscreen_width", FullscreenWidth.ToString())

        INIConfig.SetValue("general", "fullscreen_height", FullscreenHeight.ToString())

        Select Case Language
            Case EnumLanguage.EnglishUK
                INIConfig.SetValue("general", "language", "en-GB")
            Case EnumLanguage.EnglishUS
                INIConfig.SetValue("general", "language", "en-US")
            Case EnumLanguage.German
                INIConfig.SetValue("general", "language", "de-DE")
            Case EnumLanguage.Dutch
                INIConfig.SetValue("general", "language", "nl-NL")
            Case EnumLanguage.French
                INIConfig.SetValue("general", "language", "fr-FR")
            Case EnumLanguage.Hungarian
                INIConfig.SetValue("general", "language", "hu-HU")
            Case EnumLanguage.Polish
                INIConfig.SetValue("general", "language", "pl-PL")
            Case EnumLanguage.Spanish
                INIConfig.SetValue("general", "language", "es-ES")
            Case EnumLanguage.Swedish
                INIConfig.SetValue("general", "language", "sv-SE")
        End Select

        INIConfig.SetValue("general", "title_music", TitleMusic)

        INIConfig.SetValue("sound", "sound_quality", SoundQuality)

        If ForcedSoftwareBuffering Then
            INIConfig.SetValue("sound", "forced_software_buffering", "true")
        Else
            INIConfig.SetValue("sound", "forced_software_buffering", "false")
        End If

        Try
            INIConfig.Save(File)
        Catch ex As Exception
        End Try
    End Sub
End Class

'Stores the configuration of the Launcher
Public Class LauncherConfig
    Public HasChanged As Boolean = False

    Public LocalVersion As String
    Public Verbose As Boolean
    Public Arguments As String
    Public SaveOutput As Boolean
    Public OutputPath As String

    Dim INIConfig As New INI

    Public Sub LoadDefault()
        LocalVersion = ""
        Verbose = False
        Arguments = ""
        SaveOutput = False
        OutputPath = Main.OpenRCT2Folder + "\log.txt"
    End Sub

    Public Sub LoadINI(File As String)
        Dim Value As String

        INIConfig.Clear()

        Try
            INIConfig.Load(File)
        Catch ex As Exception
            Return
        End Try

        Value = INIConfig.FindValue("general", "local_version")

        If Value <> Nothing Then
            LocalVersion = Value
        End If

        Value = INIConfig.FindValue("general", "verbose")

        Select Case Value
            Case "true"
                Verbose = True
            Case "false"
                Verbose = False
        End Select

        Value = INIConfig.FindValue("general", "arguments")

        If Value <> Nothing Then
            Arguments = Value
        End If

        Value = INIConfig.FindValue("general", "save_output")

        Select Case Value
            Case "true"
                SaveOutput = True
            Case "false"
                SaveOutput = False
        End Select

        Value = INIConfig.FindValue("general", "output_path")

        If Value <> Nothing Then
            OutputPath = Value
        End If
    End Sub

    Public Sub SaveINI(File As String)
        INIConfig.SetValue("general", "local_version", LocalVersion)

        If Verbose Then
            INIConfig.SetValue("general", "verbose", "true")
        Else
            INIConfig.SetValue("general", "verbose", "false")
        End If

        INIConfig.SetValue("general", "arguments", Arguments)

        If SaveOutput Then
            INIConfig.SetValue("general", "save_output", "true")
        Else
            INIConfig.SetValue("general", "save_output", "false")
        End If

        INIConfig.SetValue("general", "output_path", OutputPath)

        Try
            INIConfig.Save(File)
        Catch ex As Exception
        End Try
    End Sub
End Class