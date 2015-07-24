Imports HelperLibrary.Utils

Public Structure GameConfigValues
    Enum Constructor
        NullValues    = 0 'Don't assign any values (same as not calling the constructor)
        DefaultValues = 1 'Create structure with default values
    End Enum

    Sub New(c As Constructor)
        If c = Constructor.DefaultValues
            AlwaysShowGridlines         = False
            Autosave                    = GameConfig.EnumAutosave.EveryMonth
            AutoStaff                   = False
            BuildInPauseMode            = False
            Channel                     = ""
            ChatPeepNames               = True
            ChatPeepTracking            = True
            ConfirmationPrompt          = False
            ConsoleSmallFont            = False
            ConstructionMarkerColour    = 0
            DateFormat                  = GameConfig.EnumDateFormat.DMY
            DebuggingTools              = False
            DisableAllBreakdowns        = False
            DisableBrakesFailure        = False
            EdgeScrolling               = True
            FastLiftHill                = False
            FollowerPeepNames           = True
            FollowerPeepTracking        = False
            FullscreenHeight            = -1
            FullscreenMode              = GameConfig.EnumFullscreenMode.Window
            FullscreenWidth             = -1
            HardwareDisplay             = False
            InvertViewportDrag          = False
            LandscapeSmoothing          = True
            MasterVolume                = 100
            MinimizeFullscreenFocusLoss = True
            MusicVolume                 = 100
            News                        = False
            NoTestCrashes               = False
            PlayIntro                   = False
            RideMusic                   = True
            SavePluginData              = False
            ScreenshotFormat            = GameConfig.EnumScreenshotFormat.PNG
            SelectByTrackType           = False
            ShowHeightAsUnits           = False
            Sound                       = True
            TestUnfinishedTracks        = False
            TitleMusic                  = GameConfig.EnumTitleMusic.RCT2
            ToolbarShowCheats           = False
            ToolbarShowFinances         = False
            ToolbarShowRecentMessages   = False
            ToolbarShowResearch         = True
            UncapFPS                    = False
            UnlockAllPrices             = False
            WindowHeight                = -1
            WindowSnapProximity         = 5
            WindowWidth                 = -1

            Dim ri As New Globalization.RegionInfo(Globalization.CultureInfo.CurrentCulture.LCID)

            Select Case ri.ISOCurrencySymbol
                Case "GBP"
                    CurrencyFormat = GameConfig.EnumCurrencyFormat.Pounds
                Case "USD"
                    CurrencyFormat = GameConfig.EnumCurrencyFormat.Dollars
                Case "EUR"
                    CurrencyFormat = GameConfig.EnumCurrencyFormat.Euros
                Case "SEK"
                    CurrencyFormat = GameConfig.EnumCurrencyFormat.Krona
                Case "DEM"
                    CurrencyFormat = GameConfig.EnumCurrencyFormat.Deutschmark
                Case "ITL"
                    CurrencyFormat = GameConfig.EnumCurrencyFormat.Lira
                Case "JPY"
                    CurrencyFormat = GameConfig.EnumCurrencyFormat.Yen
                Case "ESP"
                    CurrencyFormat = GameConfig.EnumCurrencyFormat.Peseta
                Case "FRF"
                    CurrencyFormat = GameConfig.EnumCurrencyFormat.Franc
                Case "NLG"
                    CurrencyFormat = GameConfig.EnumCurrencyFormat.Guilders
                Case Else
                    CurrencyFormat = GameConfig.EnumCurrencyFormat.Pounds
            End Select

            Try
                GamePath = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("Software\Infogrames\rollercoaster tycoon 2 setup").GetValue("Path")
            Catch ex As Exception
                GamePath = ""
            End Try

            Select Case ri.ThreeLetterWindowsRegionName
                Case "ENG"
                    Language = GameConfig.EnumLanguage.EnglishUK
                Case "ENU"
                    Language = GameConfig.EnumLanguage.EnglishUS
                Case "DEU"
                    Language = GameConfig.EnumLanguage.German
                Case "NLD"
                    Language = GameConfig.EnumLanguage.Dutch
                Case "FRA"
                    Language = GameConfig.EnumLanguage.French
                Case "HUN"
                    Language = GameConfig.EnumLanguage.Hungarian
                Case "PLK"
                    Language = GameConfig.EnumLanguage.Polish
                Case "ESP"
                    Language = GameConfig.EnumLanguage.Spanish
                Case "SVE"
                    Language = GameConfig.EnumLanguage.Swedish
                Case "ITA"
                    Language = GameConfig.EnumLanguage.Italian
                Case "BRA"
                    Language = GameConfig.EnumLanguage.PortugueseBR
                Case Else
                    Language = GameConfig.EnumLanguage.EnglishUK
            End Select

            If ri.IsMetric
                MeasurementFormat = GameConfig.EnumMeasurementFormat.Imperial
            Else
                MeasurementFormat = GameConfig.EnumMeasurementFormat.Metric
            End If

            Select Case ri.ThreeLetterWindowsRegionName
                Case "ENU" 'I know there are more countrys using Fahrenheit but I'm too lazy to look them all up
                           'Also OpenRCT2 uses Country Codes instead of these strings. However I couldn't find
                           'a way to get them in VB (I could use GetLocaleInfo however I dont't want to)
                           ' - Falki147
                    TemperatureFormat = GameConfig.EnumTemperatureFormat.Fahrenheit
                Case Else
                    TemperatureFormat = GameConfig.EnumTemperatureFormat.Celsius
            End Select
        End If
    End Sub

    Dim AlwaysShowGridlines         As Boolean
    Dim AutoStaff                   As Boolean
    Dim Autosave                    As Integer
    Dim Channel                     As String
    Dim ChatPeepNames               As Boolean
    Dim ChatPeepTracking            As Boolean
    Dim ConfirmationPrompt          As Integer
    Dim ConsoleSmallFont            As Boolean
    Dim ConstructionMarkerColour    As Integer
    Dim CurrencyFormat              As Integer
    Dim DateFormat                  As Integer
    Dim DebuggingTools              As Boolean
    Dim DisableAllBreakdowns        As Boolean
    Dim DisableBrakesFailure        As Boolean
    Dim EdgeScrolling               As Boolean
    Dim FastLiftHill                As Boolean
    Dim FollowerPeepNames           As Boolean
    Dim FollowerPeepTracking        As Boolean
    Dim FullscreenHeight            As Integer
    Dim FullscreenMode              As Integer
    Dim FullscreenWidth             As Integer
    Dim GamePath                    As String
    Dim HardwareDisplay             As Boolean
    Dim InvertViewportDrag          As Boolean
    Dim LandscapeSmoothing          As Boolean
    Dim Language                    As Integer
    Dim MasterVolume                As Integer
    Dim MeasurementFormat           As Integer
    Dim MinimizeFullscreenFocusLoss As Boolean
    Dim MusicVolume                 As Integer
    Dim News                        As Boolean
    Dim NoTestCrashes               As Boolean
    Dim BuildInPauseMode            As Boolean
    Dim PlayIntro                   As Boolean
    Dim RideMusic                   As Boolean
    Dim SavePluginData              As Boolean
    Dim ScreenshotFormat            As Integer
    Dim SelectByTrackType           As Boolean
    Dim ShowHeightAsUnits           As Boolean
    Dim Sound                       As Boolean
    Dim TemperatureFormat           As Integer
    Dim TestUnfinishedTracks        As Boolean
    Dim TitleMusic                  As Integer
    Dim ToolbarShowCheats           As Boolean
    Dim ToolbarShowFinances         As Boolean
    Dim ToolbarShowRecentMessages   As Boolean
    Dim ToolbarShowResearch         As Boolean
    Dim UncapFPS                    As Boolean
    Dim UnlockAllPrices             As Boolean
    Dim WindowHeight                As Integer
    Dim WindowSnapProximity         As Integer
    Dim WindowWidth                 As Integer
End Structure

Public Class GameConfig
    Enum EnumAutosave
		EveryWeek = 0
		Every2Weeks
		EveryMonth
		Every4Months
		EveryYear
		Never
	End Enum

    Enum EnumCurrencyFormat
		Pounds = 0
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

    Enum EnumDateFormat
        DMY = 0
        MDY
    End Enum

    Enum EnumFullscreenMode
		Window = 0
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
        Italian
        PortugueseBR
	End Enum

    Enum EnumMeasurementFormat
		Imperial = 0
		Metric
	End Enum

    Enum EnumScreenshotFormat
		BMP = 0
		PNG
	End Enum

	Enum EnumTemperatureFormat
		Celsius = 0
		Fahrenheit
	End Enum

	Enum EnumTitleMusic
		None = 0
		RCT1
		RCT2
	End Enum

    Shared Public values As GameConfigValues
    Shared Private origValues As GameConfigValues

    Shared Private INIConfig As IniConfiguration

    Shared Public DictCurrencyFormat As New Dictionary(Of String, Integer)
    Shared Public DictDateFormat As New Dictionary(Of String, Integer)
    Shared Public DictLanguage As New Dictionary(Of String, Integer)
    Shared Public DictMeasurementFormat As New Dictionary(Of String, Integer)
    Shared Public DictScreenshotFormat As New Dictionary(Of String, Integer)
    Shared Public DictTemperatureFormat As New Dictionary(Of String, Integer)

    Shared Sub New()
        DictDateFormat.Add("DD/MM/YY", EnumDateFormat.DMY)
        DictDateFormat.Add("MM/DD/YY", EnumDateFormat.MDY)

        DictCurrencyFormat.Add("GBP", EnumCurrencyFormat.Pounds)
        DictCurrencyFormat.Add("USD", EnumCurrencyFormat.Dollars)
        DictCurrencyFormat.Add("FRF", EnumCurrencyFormat.Franc)
        DictCurrencyFormat.Add("DEM", EnumCurrencyFormat.Deutschmark)
        DictCurrencyFormat.Add("JPY", EnumCurrencyFormat.Yen)
        DictCurrencyFormat.Add("ESP", EnumCurrencyFormat.Peseta)
        DictCurrencyFormat.Add("ITL", EnumCurrencyFormat.Lira)
        DictCurrencyFormat.Add("NLG", EnumCurrencyFormat.Guilders)
        DictCurrencyFormat.Add("SEK", EnumCurrencyFormat.Krona)
        DictCurrencyFormat.Add("EUR", EnumCurrencyFormat.Euros)

        DictLanguage.Add("en-GB", EnumLanguage.EnglishUK)
        DictLanguage.Add("en-US", EnumLanguage.EnglishUS)
        DictLanguage.Add("de-DE", EnumLanguage.German)
        DictLanguage.Add("nl-NL", EnumLanguage.Dutch)
        DictLanguage.Add("fr-FR", EnumLanguage.French)
        DictLanguage.Add("hu-HU", EnumLanguage.Hungarian)
        DictLanguage.Add("pl-PL", EnumLanguage.Polish)
        DictLanguage.Add("es-ES", EnumLanguage.Spanish)
        DictLanguage.Add("sv-SE", EnumLanguage.Swedish)
        DictLanguage.Add("it-IT", EnumLanguage.Italian)
        DictLanguage.Add("pt-BR", EnumLanguage.PortugueseBR)

        DictMeasurementFormat.Add("IMPERIAL", EnumMeasurementFormat.Imperial)
        DictMeasurementFormat.Add("METRIC", EnumMeasurementFormat.Metric)

        DictScreenshotFormat.Add("BMP", EnumScreenshotFormat.BMP)
        DictScreenshotFormat.Add("PNG", EnumScreenshotFormat.PNG)

        DictTemperatureFormat.Add("CELSIUS", EnumTemperatureFormat.Celsius)
        DictTemperatureFormat.Add("FAHRENHEIT", EnumTemperatureFormat.Fahrenheit)
    End Sub

    Shared Sub load(file As String)
        values = New GameConfigValues(GameConfigValues.Constructor.DefaultValues)

        Try
            INIConfig = New IniConfiguration(file)
        Catch ex As Exception
            origValues = values
            Return
        End Try

        getProp("cheat", "build_in_pause_mode", values.BuildInPauseMode)
        getProp("cheat", "disable_all_breakdowns", values.DisableAllBreakdowns)
        getProp("cheat", "disable_brakes_failure", values.DisableBrakesFailure)
        getProp("cheat", "fast_lift_hill", values.FastLiftHill)
        getProp("cheat", "unlock_all_prices", values.UnlockAllPrices)
        
        getProp("general", "always_show_gridlines", values.AlwaysShowGridlines)
        getPropRange("general", "autosave", values.Autosave, 0, 5)
        getProp("general", "auto_staff", values.AutoStaff)
        getProp("general", "confirmation_prompt", values.ConfirmationPrompt)
        getPropRange("general", "construction_marker_colour", values.ConstructionMarkerColour, 0, 1)
        getPropDictionary("general", "currency_format", values.CurrencyFormat, DictCurrencyFormat)
        getPropDictionary("general", "date_format", values.DateFormat, DictDateFormat)
        getProp("general", "debugging_tools", values.DebuggingTools)
        getProp("general", "edge_scrolling", values.EdgeScrolling)
        getPropRange("general", "fullscreen_height", values.FullscreenHeight, -1, 2147483647)
        getPropRange("general", "fullscreen_mode", values.FullscreenMode, 0, 2)
        getPropRange("general", "fullscreen_width", values.FullscreenWidth, -1, 2147483647)
        getProp("general", "game_path", values.GamePath)
        getProp("general", "hardware_display", values.HardwareDisplay)
        getProp("general", "invert_viewport_drag", values.InvertViewportDrag)
        getProp("general", "landscape_smoothing", values.LandscapeSmoothing)
        getPropDictionary("general", "language", values.Language, DictLanguage)
        getPropDictionary("general", "measurement_format", values.MeasurementFormat, DictMeasurementFormat)
        getProp("general", "minimize_fullscreen_focus_loss", values.MinimizeFullscreenFocusLoss)
        getProp("general", "no_test_crashes", values.NoTestCrashes)
        getProp("general", "play_intro", values.PlayIntro)
        getProp("general", "save_plugin_data", values.SavePluginData)
        getPropDictionary("general", "screenshot_format", values.ScreenshotFormat, DictScreenshotFormat)
        getProp("general", "show_height_as_units", values.ShowHeightAsUnits)
        getPropDictionary("general", "temperature_format", values.TemperatureFormat, DictTemperatureFormat)
        getProp("general", "test_unfinished_tracks", values.TestUnfinishedTracks)
        getProp("general", "uncap_fps", values.UncapFPS)
        getPropRange("general", "window_height", values.WindowHeight, -1, 2147483647)
        getPropRange("general", "window_snap_proximity", values.WindowSnapProximity, 0, 255)
        getPropRange("general", "window_width", values.WindowWidth, -1, 2147483647)
        
        getProp("interface", "console_small_font", values.ConsoleSmallFont)
        getProp("interface", "select_by_track_type", values.SelectByTrackType)
        getProp("interface", "toolbar_show_cheats", values.ToolbarShowCheats)
        getProp("interface", "toolbar_show_finances", values.ToolbarShowFinances)
        getProp("interface", "toolbar_show_news", values.ToolbarShowRecentMessages)
        getProp("interface", "toolbar_show_research", values.ToolbarShowResearch)

        getPropRange("sound", "master_volume", values.MasterVolume, 0, 100)
        getPropRange("sound", "music_volume", values.MusicVolume, 0, 100)
        getProp("sound", "ride_music", values.RideMusic)
        getProp("sound", "sound", values.Sound)
        getPropRange("sound", "title_music", values.TitleMusic, 0, 2)

        getProp("twitch", "channel", values.Channel)
        getProp("twitch", "chat_peep_names", values.ChatPeepNames)
        getProp("twitch", "chat_peep_tracking", values.ChatPeepTracking)
        getProp("twitch", "follower_peep_names", values.FollowerPeepNames)
        getProp("twitch", "follower_peep_tracking", values.FollowerPeepTracking)
        getProp("twitch", "news", values.News)
        
        origValues = values 'Make a copy of the original values (to compare them for changes later)
    End Sub

    Shared Sub save(file As String)
        If values.Equals(origValues) And IO.File.Exists(file)
            Return
        End If

        If IsNothing(INIConfig)
            INIConfig = New IniConfiguration()
        End If

        setProp("cheat", "build_in_pause_mode", values.BuildInPauseMode)
        setProp("cheat", "disable_all_breakdowns", values.DisableAllBreakdowns)
        setProp("cheat", "disable_brakes_failure", values.DisableBrakesFailure)
        setProp("cheat", "fast_lift_hill", values.FastLiftHill)
        setProp("cheat", "unlock_all_prices", values.UnlockAllPrices)

        setProp("general", "always_show_gridlines", values.AlwaysShowGridlines)
        setProp("general", "autosave", values.Autosave)
        setProp("general", "auto_staff", values.AutoStaff)
        setProp("general", "confirmation_prompt", values.ConfirmationPrompt)
        setProp("general", "construction_marker_colour", values.ConstructionMarkerColour)
        setPropDictionary("general", "currency_format", values.CurrencyFormat, DictCurrencyFormat)
        setPropDictionary("general", "date_format", values.DateFormat, DictDateFormat)
        setProp("general", "debugging_tools", values.DebuggingTools)
        setProp("general", "edge_scrolling", values.EdgeScrolling)
        setProp("general", "fullscreen_height", values.FullscreenHeight)
        setProp("general", "fullscreen_mode", values.FullscreenMode)
        setProp("general", "fullscreen_width", values.FullscreenWidth)
        setProp("general", "game_path", values.GamePath)
        setProp("general", "hardware_display", values.HardwareDisplay)
        setProp("general", "invert_viewport_drag", values.InvertViewportDrag)
        setProp("general", "landscape_smoothing", values.LandscapeSmoothing)
        setPropDictionary("general", "language", values.Language, DictLanguage)
        setPropDictionary("general", "measurement_format", values.MeasurementFormat, DictMeasurementFormat)
        setProp("general", "minimize_fullscreen_focus_loss", values.MinimizeFullscreenFocusLoss)
        setProp("general", "no_test_crashes", values.NoTestCrashes)
        setProp("general", "play_intro", values.PlayIntro)
        setProp("general", "save_plugin_data", values.SavePluginData)
        setPropDictionary("general", "screenshot_format", values.ScreenshotFormat, DictScreenshotFormat)
        setProp("general", "show_height_as_units", values.ShowHeightAsUnits)
        setPropDictionary("general", "temperature_format", values.TemperatureFormat, DictTemperatureFormat)
        setProp("general", "test_unfinished_tracks", values.TestUnfinishedTracks)
        setProp("general", "uncap_fps", values.UncapFPS)
        setProp("general", "window_height", values.WindowHeight)
        setProp("general", "window_snap_proximity", values.WindowSnapProximity)
        setProp("general", "window_width", values.WindowWidth)

        setProp("interface", "console_small_font", values.ConsoleSmallFont)
        setProp("interface", "select_by_track_type", values.SelectByTrackType)
        setProp("interface", "toolbar_show_cheats", values.ToolbarShowCheats)
        setProp("interface", "toolbar_show_finances", values.ToolbarShowFinances)
        setProp("interface", "toolbar_show_news", values.ToolbarShowRecentMessages)
        setProp("interface", "toolbar_show_research", values.ToolbarShowResearch)
        
        setProp("sound", "master_volume", values.MasterVolume)
        setProp("sound", "music_volume", values.MusicVolume)
        setProp("sound", "ride_music", values.RideMusic)
        setProp("sound", "sound", values.Sound)
        setProp("sound", "title_music", values.TitleMusic)

        setProp("twitch", "channel", values.Channel)
        setProp("twitch", "chat_peep_names", values.ChatPeepNames)
        setProp("twitch", "chat_peep_tracking", values.ChatPeepTracking)
        setProp("twitch", "follower_peep_names", values.FollowerPeepNames)
        setProp("twitch", "follower_peep_tracking", values.FollowerPeepTracking)
        setProp("twitch", "news", values.News)

        INIConfig.Save(file)

        origValues = values
    End Sub

    Shared Private Sub getProp(section As String, prop As String, ByRef val As String)
        If Not INIConfig.PropertyExists(section, prop)
            Return
        End If

        val = INIConfig.GetProperty(section, prop)
    End Sub

    Shared Private Sub getProp(section As String, prop As String, ByRef val As Int32)
        If Not INIConfig.PropertyExists(section, prop)
            Return
        End If

        val = INIConfig.GetPropertyInt32(section, prop)
    End Sub

    Shared Private Sub getProp(section As String, prop As String, ByRef val As Boolean)
        If Not INIConfig.PropertyExists(section, prop)
            Return
        End If

        val = INIConfig.GetPropertyBoolean(section, prop)
    End Sub

    Shared Private Sub getPropRange(section As String, prop As String, ByRef val As Int32, min As Integer, max As Integer)
        If Not INIConfig.PropertyExists(section, prop)
            Return
        End If

        Dim t As Integer = INIConfig.GetPropertyInt32(section, prop)

        If t < min Or t > max
            Return
        End If

        val = t
    End Sub

    Shared Private Sub getPropDictionary(section As String, prop As String, ByRef val As Integer, dict As Dictionary(Of String, Integer))
        If Not INIConfig.PropertyExists(section, prop)
            Return
        End If

        Dim str As String = INIConfig.GetProperty(section, prop)

        If dict.ContainsKey(str)
            val = dict.Item(str)
        End If
    End Sub

    Shared Private Sub setProp(section As String, prop As String, val As String)
        INIConfig.SetProperty(section, prop, Chr(34) + val + Chr(34))
    End Sub

    Shared Private Sub setProp(section As String, prop As String, val As Int32)
        INIConfig.SetProperty(section, prop, val.ToString())
    End Sub

    Shared Private Sub setProp(section As String, prop As String, val As Boolean)
        If val
            INIConfig.SetProperty(section, prop, "true")
        Else
            INIConfig.SetProperty(section, prop, "false")
        End If
    End Sub

    Shared Private Sub setPropDictionary(section As String, prop As String, val As Integer, dict As Dictionary(Of String, Integer))
        'Couldn't find a better solution
        For Each pair In dict
            If pair.Value = val
                INIConfig.SetProperty(section, prop, pair.Key)
                Return
            End If
        Next
    End Sub
End Class