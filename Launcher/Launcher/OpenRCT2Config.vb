Imports HelperLibrary.Utils

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

    Dim INIConfig As New IniConfiguration

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

        Try
            INIConfig = New IniConfiguration(File)
        Catch ex As Exception
            Return
        End Try

        PlayIntro = INIConfig.GetPropertyBoolean("general", "play_intro")

        ConfirmationPrompt = INIConfig.GetPropertyInt32("general", "confirmation_prompt")

        Select Case INIConfig.GetProperty("general", "screenshot_format", "PNG")
            Case "BMP"
                ScreenshotFormat = EnumScreenshotFormat.BMP
            Case "PNG"
                ScreenshotFormat = EnumScreenshotFormat.PNG
        End Select

        Value = INIConfig.GetProperty("general", "game_path")

        If Not String.IsNullOrEmpty(Value) Then
            GamePath = Value
        End If

        Select Case INIConfig.GetProperty("general", "measurement_format")
            Case "IMPERIAL"
                MeasurementFormat = EnumMeasurementFormat.Imperial
            Case "METRIC"
                MeasurementFormat = EnumMeasurementFormat.Metric
        End Select

        Select Case INIConfig.GetProperty("general", "temperature_format")
            Case "CELSIUS"
                TemperatureFormat = EnumTemperatureFormat.Celsius
            Case "FAHRENHEIT"
                TemperatureFormat = EnumTemperatureFormat.Fahrenheit
        End Select

        Select Case INIConfig.GetProperty("general", "currency_format")
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

        EdgeScrolling = INIConfig.GetPropertyBoolean("general", "edge_scrolling", True)

        AlwaysShowGridlines = INIConfig.GetPropertyBoolean("general", "always_show_gridlines")

        LandscapeSmoothing = INIConfig.GetPropertyBoolean("general", "landscape_smoothing", True)

        ShowHeightAsUnits = INIConfig.GetPropertyBoolean("general", "show_height_as_units")

        SavePluginData = INIConfig.GetPropertyBoolean("general", "save_plugin_data")

        Number = INIConfig.GetPropertyInt32("general", "fullscreen_mode")

        If Number >= 0 And Number <= 2 Then
            FullscreenMode = Number
        End If

        FullscreenWidth = INIConfig.GetPropertyInt32("general", "fullscreen_width", -1)

        FullscreenHeight = INIConfig.GetPropertyInt32("general", "fullscreen_height", -1)

        Select Case INIConfig.GetProperty("general", "language")
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

        Number = INIConfig.GetPropertyInt32("sound", "title_music", 2)

        If Number >= 0 And Number <= 2 Then
            TitleMusic = Number
        End If

        Number = INIConfig.GetPropertyInt32("sound", "sound_quality", 2)

        If Number >= 0 And Number <= 2 Then
            SoundQuality = Number
        End If

        ForcedSoftwareBuffering = INIConfig.GetPropertyBoolean("sound", "forced_software_buffering")
    End Sub

    Public Async Function SaveINI(File As String) As Task
        If PlayIntro Then
            INIConfig.SetProperty("general", "play_intro", "true")
        Else
            INIConfig.SetProperty("general", "play_intro", "false")
        End If

        INIConfig.SetProperty("general", "confirmation_prompt", Convert.ToInt32(ConfirmationPrompt))

        Select Case ScreenshotFormat
            Case EnumScreenshotFormat.BMP
                INIConfig.SetProperty("general", "screenshot_format", "BMP")
            Case EnumScreenshotFormat.PNG
                INIConfig.SetProperty("general", "screenshot_format", "PNG")
        End Select

        INIConfig.SetProperty("general", "game_path", GamePath)

        Select Case MeasurementFormat
            Case EnumMeasurementFormat.Imperial
                INIConfig.SetProperty("general", "measurement_format", "IMPERIAL")
            Case EnumMeasurementFormat.Metric
                INIConfig.SetProperty("general", "measurement_format", "METRIC")
        End Select

        Select Case TemperatureFormat
            Case EnumTemperatureFormat.Celsius
                INIConfig.SetProperty("general", "temperature_format", "CELSIUS")
            Case EnumTemperatureFormat.Fahrenheit
                INIConfig.SetProperty("general", "temperature_format", "FAHRENHEIT")
        End Select

        Select Case CurrencyFormat
            Case EnumCurrencyFormat.Pounds
                INIConfig.SetProperty("general", "currency_format", "GBP")
            Case EnumCurrencyFormat.Dollars
                INIConfig.SetProperty("general", "currency_format", "USD")
            Case EnumCurrencyFormat.Franc
                INIConfig.SetProperty("general", "currency_format", "FRF")
            Case EnumCurrencyFormat.Deutschmark
                INIConfig.SetProperty("general", "currency_format", "DEM")
            Case EnumCurrencyFormat.Yen
                INIConfig.SetProperty("general", "currency_format", "YEN")
            Case EnumCurrencyFormat.Peseta
                INIConfig.SetProperty("general", "currency_format", "ESP")
            Case EnumCurrencyFormat.Lira
                INIConfig.SetProperty("general", "currency_format", "ITL")
            Case EnumCurrencyFormat.Guilders
                INIConfig.SetProperty("general", "currency_format", "NLG")
            Case EnumCurrencyFormat.Krona
                INIConfig.SetProperty("general", "currency_format", "NOK")
            Case EnumCurrencyFormat.Euros
                INIConfig.SetProperty("general", "currency_format", "EUR")
        End Select

        If EdgeScrolling Then
            INIConfig.SetProperty("general", "edge_scrolling", "true")
        Else
            INIConfig.SetProperty("general", "edge_scrolling", "false")
        End If

        If AlwaysShowGridlines Then
            INIConfig.SetProperty("general", "always_show_gridlines", "true")
        Else
            INIConfig.SetProperty("general", "always_show_gridlines", "false")
        End If

        If LandscapeSmoothing Then
            INIConfig.SetProperty("general", "landscape_smoothing", "true")
        Else
            INIConfig.SetProperty("general", "landscape_smoothing", "false")
        End If

        If ShowHeightAsUnits Then
            INIConfig.SetProperty("general", "show_height_as_units", "true")
        Else
            INIConfig.SetProperty("general", "show_height_as_units", "false")
        End If

        If SavePluginData Then
            INIConfig.SetProperty("general", "save_plugin_data", "true")
        Else
            INIConfig.SetProperty("general", "save_plugin_data", "false")
        End If

        INIConfig.SetProperty("general", "fullscreen_mode", FullscreenMode)

        INIConfig.SetProperty("general", "fullscreen_width", FullscreenWidth.ToString())

        INIConfig.SetProperty("general", "fullscreen_height", FullscreenHeight.ToString())

        Select Case Language
            Case EnumLanguage.EnglishUK
                INIConfig.SetProperty("general", "language", "en-GB")
            Case EnumLanguage.EnglishUS
                INIConfig.SetProperty("general", "language", "en-US")
            Case EnumLanguage.German
                INIConfig.SetProperty("general", "language", "de-DE")
            Case EnumLanguage.Dutch
                INIConfig.SetProperty("general", "language", "nl-NL")
            Case EnumLanguage.French
                INIConfig.SetProperty("general", "language", "fr-FR")
            Case EnumLanguage.Hungarian
                INIConfig.SetProperty("general", "language", "hu-HU")
            Case EnumLanguage.Polish
                INIConfig.SetProperty("general", "language", "pl-PL")
            Case EnumLanguage.Spanish
                INIConfig.SetProperty("general", "language", "es-ES")
            Case EnumLanguage.Swedish
                INIConfig.SetProperty("general", "language", "sv-SE")
        End Select

        INIConfig.SetProperty("sound", "title_music", TitleMusic)

        INIConfig.SetProperty("sound", "sound_quality", SoundQuality)

        If ForcedSoftwareBuffering Then
            INIConfig.SetProperty("sound", "forced_software_buffering", "true")
        Else
            INIConfig.SetProperty("sound", "forced_software_buffering", "false")
        End If

        Try
            Await INIConfig.Save(File)
        Catch ex As Exception
        End Try
    End Function
End Class