using System;

namespace HelperLibrary.Classes {
    public static class Constants {

        public static string OpenRCT2Folder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\OpenRCT2";
        public static string OpenRCT2Bin = OpenRCT2Folder + @"\bin";
        public static string OpenRCT2ConfigFile = OpenRCT2Folder + @"\config.ini";
        public static string OpenRCT2Exe = OpenRCT2Bin + @"\openrct2.exe";
        public static string OpenRCT2Dll = OpenRCT2Bin + @"\openrct2.dll";

        public static string UpdateDevelopURL = "https://openrct.net/latest.zip";
        public static string UpdateVersionDevelopURL = "https://openrct.net/latest.zip?a=version";
        public static string UpdateStableURL = "https://openrct.net/latest-stable.zip";
        public static string UpdateVersionStableURL = "https://openrct.net/latest-stable.zip?a=version";
    }

    [Serializable]
    public enum ScreenshotFormat {
        BMP = 1,
        PNG = 2
    }

    [Serializable]
    public enum MeasurementFormat {
        Imperial = 1,
        Metric = 2
    }

    [Serializable]
    public enum TemperatureFormat {
        Celsius = 1,
        Fahrenheit = 2
    }

    [Serializable]
    public enum CurrencyFormat {
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

    [Serializable]
    public enum FullscreenMode {
        Window = 1,
        Fullscreen = 2,
        BorderlessFullscreen = 3
    }

    [Serializable]
    public enum Language {
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

    [Serializable]
    public enum TitleMusic {
        None = 0,
        RCT1 = 1,
        RCT2 = 2
    }

    [Serializable]
    public enum SoundQuality {
        Low = 1,
        Medium = 2,
        High = 3
    }
}