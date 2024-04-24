using Launcher_NFS_WPF_New.View;
using Launcher_NFS_WPF_New.ViewModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows;

namespace Launcher_NFS_WPF_New.Model
{
    internal class PathManager
    {
        private static string game;
        public static string settings;
        public static void Initialise()
        {
            if (string.IsNullOrEmpty(Properties.Settings.Default.path))
                SetDefault();
            else
            {
                if (!IsCorrectFileSettings(Properties.Settings.Default.path))
                    SetDefault();
                else
                    SetFileSettings(Properties.Settings.Default.path);
            }
        }
        public static bool IsCorrectFileSettings(string path)
        {
            if (File.Exists(path) && path.Contains(".exe") && File.Exists(path.Replace("\\speed.exe", "") + "\\PROFILE\\NFS Most Wanted\\Settings.ini"))
                return true;
            return false;
        }
        private static void SetDefault()
        {
            //временный
            //game = "C:\\Users\\Wixon\\OneDrive\\Рабочий стол\\NFS - Speed Champions (DEMO)\\speed.exe";
            //на релизе
            game = string.Join("\\", Assembly.GetExecutingAssembly().Location.Split('\\').Where(x => !x.Contains(".exe")).ToList()) + "\\speed.exe";

            settings = string.Join("\\", game.Split('\\').Where(x => !x.Contains("exe")).ToList()) + "\\PROFILE\\NFS Most Wanted\\Settings.ini";
            Properties.Settings.Default.path = game;
            ((SettingsLauncherPage)MainViewModel.SettingsLauncherPage).TextPathGameText = game;
            Properties.Settings.Default.Save();

        }
        public static void SetFileSettings(string pathGame)
        {
            game = pathGame;

            if (!IsCorrectFileSettings(game))
            {
                MessageBox.Show("No Correct Path");
                return;
            }
            settings = string.Join("\\", game.Split('\\').Where(x => !x.Contains("exe")).ToList()) + "\\PROFILE\\NFS Most Wanted\\Settings.ini";
            Properties.Settings.Default.path = game;
            ((SettingsLauncherPage)MainViewModel.SettingsLauncherPage).TextPathGameText = game;
            Properties.Settings.Default.Save();
        }
    }
}
