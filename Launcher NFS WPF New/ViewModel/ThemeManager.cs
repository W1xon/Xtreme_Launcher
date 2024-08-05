using System;
using System.Windows;

namespace Launcher_NFS.ViewModel
{
    enum Theme
    {
        Default,
        Day,
        Night,
        Dark,
        Green,
        Blue,
        SciFi,
        Steam,
        Spotify,
        Phub,
        YouTube,
        Samokat,
        BlackBlue,
        Space,
        Codewars,
        Adrenaline,
        BSOD,
        Ocean,
        Notion,
        BlackCoral
    }
    internal class ThemeManager
    {
        private static string[] xamlColors = new string[]
        {
            "View/DictionaryColor.xaml",
            "View/Res/DictionaryColors/DictionaryColorDay.xaml",
            "View/Res/DictionaryColors/DictionaryColorNight.xaml",
            "View/Res/DictionaryColors/DictionaryColorDark.xaml",
            "View/Res/DictionaryColors/DictionaryColorGreen.xaml",
            "View/Res/DictionaryColors/DictionaryColorBlue.xaml",
            "View/Res/DictionaryColors/DictionaryColorSciFi.xaml",
            "View/Res/DictionaryColors/DictionaryColorSteam.xaml",
            "View/Res/DictionaryColors/DictionaryColorSpotify.xaml",
            "View/Res/DictionaryColors/DictionaryColorPhub.xaml",
            "View/Res/DictionaryColors/DictionaryColorYouTube.xaml",
            "View/Res/DictionaryColors/DictionaryColorSamokat.xaml",
            "View/Res/DictionaryColors/DictionaryColorBlackBlue.xaml",
            "View/Res/DictionaryColors/DictionaryColorSpace.xaml",
            "View/Res/DictionaryColors/DictionaryColorCodewars.xaml",
            "View/Res/DictionaryColors/DictionaryColorAdrenaline.xaml",
            "View/Res/DictionaryColors/DictionaryColorBSOD.xaml",
            "View/Res/DictionaryColors/DictionaryColorOcean.xaml",
            "View/Res/DictionaryColors/DictionaryColorNotion.xaml",
            "View/Res/DictionaryColors/DictionaryColorBlackCoral.xaml"
            };
        public static void Initialise()
        {
            SetTheme(Properties.Settings.Default.styleCode);
        }
        public static void SetTheme(Theme theme)
        {
            SetTheme((int)theme);
        }
        public static void SetTheme(int index)
        {
            SetStyle(xamlColors[index]);
            Properties.Settings.Default.styleCode = (byte)index;
            Properties.Settings.Default.Save();
        }
        private static void SetStyle(string path)
        {
            var uri = new Uri(path, UriKind.Relative);
            ResourceDictionary resourceDictionary = Application.LoadComponent(uri) as ResourceDictionary;

            RemoveOldDictionary();
            Application.Current.Resources.MergedDictionaries.Add(resourceDictionary);
        }

        private static void RemoveOldDictionary()
        {
            ResourceDictionary oldResourceDictionary = null;
            foreach (var dict in Application.Current.Resources.MergedDictionaries)
            {
                if (dict.Source != null && dict.Source.OriginalString.Contains("DictionaryColor"))
                {
                    oldResourceDictionary = dict;
                    break;
                }
            }
            if (oldResourceDictionary != null)
            {
                Application.Current.Resources.MergedDictionaries.Remove(oldResourceDictionary);
            }
        }
    }
}
