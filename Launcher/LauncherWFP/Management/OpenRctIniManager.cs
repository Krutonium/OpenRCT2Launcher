using IniParser;
using IniParser.Model;
using System;
using System.IO;

namespace LauncherWPF.Management
{

    /*
        I'm not documenting these enums. There's no real reason, in code, to document these enumerations. They are very self explanatory
        and really only exist for a few reasons:
            1) They make the code look nicer (no magic numbers or values).
            2) For debugging purposes, they look friendlier.
            3) Data binding in WPF actually will make this really simple to build a UI around the INI file.
            4) Read them. It's not rocket science to figure out what the hell "CurrencyFormat" really means!
    */
    namespace Enums
    {
        public enum ScreenshotFormat
        {
            BMP = 1,
            PNG = 2
        }

        public enum MeasurementFormat
        {
            Imperial = 1,
            Metric = 2
        }

        public enum TemperatureFormat
        {
            Celsius = 1,
            Fahrenheit = 2
        }

        public enum CurrencyFormat
        {
            Pounds = 1,
            Dollars = 2,
            Franc = 3,
            Deutschmark = 4,
            Yen = 5,
            Peseta = 6,
            Lira = 7,
            Guilders = 8,
            Krona = 9,
            Euros = 10
        }

        public enum FullscreenMode
        {
            Window = 1,
            Fullscreen = 2,
            BorderlessFullscreen = 3
        }

        public enum Language
        {
            EnglishUK = 1,
            EnglishUS = 2,
            German = 3,
            Dutch = 4,
            French = 5,
            Hungarian = 6,
            Polish = 7,
            Spanish = 8,
            Swedish = 9
        }

        public enum TitleMusic
        {
            None = 0,
            RCT1 = 1,
            RCT2 = 2
        }

        public enum SoundQuality
        {
            Low = 1,
            Medium = 2,
            High = 3
        }

    }


    /// <summary>
    ///     Manages the INI file that OpenRCT2 relies on.
    /// </summary>
    /// <remarks>
    ///     <see cref="OpenRctIniManager"/> is a pass-through layer to the INI file object. However, every time you make a change, you need to invoke 
    /// </remarks>
    public sealed class OpenRctIniManager
    {
        private readonly FileIniDataParser _iniParser;
        private readonly string _iniFile;

        private const string OpenRct2IniFileName = "config.ini";
        private static readonly string DefaultOpenRct2Cfg = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "OpenRCT2");
        private static readonly string DefaultOpenRct2Ini = Path.Combine(DefaultOpenRct2Cfg, OpenRct2IniFileName);
        private IniData _iniData;



        /// <summary>
        ///     Gets or sets the folder path to Roller Coaster Tycoon 2.
        /// </summary>
        /// <remarks>
        ///     Please make sure <see cref="GamePath"/> starts and ends with <![CDATA["]]>.
        /// </remarks>
        public string GamePath
        {
            get
            {
                return _iniData["general"]["game_path"].Trim('\"');
            }
            set
            {
                _iniData["general"]["game_path"] = $"\"{value.Trim('\"')}\"";
            }
        }



        /// <summary>
        ///     Creates a new instance of the <see cref="OpenRctIniManager"/> pointing to the default file location.
        /// </summary>
        public OpenRctIniManager() : this(DefaultOpenRct2Ini) { }

        /// <summary>
        ///     Creates a new instance of the <see cref="OpenRctIniManager"/>.
        /// </summary>
        /// <param name="file">The INI file to load</param>
        public OpenRctIniManager(string file)
        {
            _iniFile = file;
            _iniParser = new FileIniDataParser();
            Load();
        }

        /// <summary>
        ///     Saves all pending changes to the INI file.
        /// </summary>
        public void Save()
        {
            _iniParser.WriteFile(_iniFile, _iniData);
        }

        /// <summary>
        ///     Loads (or reloads) the INI file from disk.
        /// </summary>
        public void Load()
        {
            _iniData = _iniParser.ReadFile(_iniFile);
        }

        /// <summary>
        ///     Creates a blank INI file in the default location for the <see cref="OpenRctIniManager"/> to consume.
        /// </summary>
        public static void Create()
        {
            Create(DefaultOpenRct2Cfg);
        }

        /// <summary>
        ///     Creates a blank INI file in the specified directory.
        /// </summary>
        /// <param name="directory">The directory for which to create the INI file in.</param>
        /// <remarks>
        ///     This will create the directory if the directory does not exist.
        /// </remarks>
        public static void Create(string directory)
        {
            if (!Directory.Exists(directory)) Directory.CreateDirectory(directory);
            var iniFilePath = Path.Combine(directory, OpenRct2IniFileName);
            if (File.Exists(iniFilePath)) return;
#pragma warning disable CS0642 // Possible mistaken empty statement
            using (var fs = File.Create(iniFilePath)) ; // :)
#pragma warning restore CS0642 // Possible mistaken empty statement
        }

    }

}