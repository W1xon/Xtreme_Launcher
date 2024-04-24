using System;
using System.Windows;

namespace Launcher_NFS_WPF_New.ViewModel
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
        Phub
    }
    internal class ThemeManager
    {
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
            switch (index)
            {
                case 0:
                    SetStyle("View/DictionaryColor.xaml");
                    break;
                case 1:
                    SetStyle("View/Res/DictionaryColors/DictionaryColorDay.xaml");
                    break;
                case 2:
                    SetStyle("View/Res/DictionaryColors/DictionaryColorNight.xaml");
                    break;
                case 3:
                    SetStyle("View/Res/DictionaryColors/DictionaryColorDark.xaml");
                    break;
                case 4:
                    SetStyle("View/Res/DictionaryColors/DictionaryColorGreen.xaml");
                    break;
                case 5:
                    SetStyle("View/Res/DictionaryColors/DictionaryColorBlue.xaml");
                    break;
                case 6:
                    SetStyle("View/Res/DictionaryColors/DictionaryColorSciFi.xaml");
                    break;
                case 7:
                    SetStyle("View/Res/DictionaryColors/DictionaryColorSteam.xaml");
                    break;
                case 8:
                    SetStyle("View/Res/DictionaryColors/DictionaryColorSpotify.xaml");
                    break;
                case 9:
                    SetStyle("View/Res/DictionaryColors/DictionaryColorPhub.xaml");
                    break;

            }
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
