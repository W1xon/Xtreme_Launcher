using Launcher_NFS.View;
using Launcher_NFS.ViewModel;
using System.IO;
using System.Windows.Forms;


namespace Launcher_NFS.Model
{
    internal class PathProvider
    {
        public static PathConfig Config
        {
            get
            {
                return _config;
            }
        }
        private static FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
        private static PathConfig _config = new PathConfig();
        public static void Initialize()
        {
            SetConfig();
            UpdateModificationInfo.IsLoad = FileProvider.HasFileConfig();
        }
        private static void SetConfig()
        {
            Config.Directory = Properties.Settings.Default.path;
            Config.Exe = "speed.exe";
            Config.SettingsOne = "PROFILE\\NFS Most Wanted\\Settings.ini";
            Config.SettingsTwo = "PROFILE\\NFS Most Wanted\\Settings_lowend.ini";
        }
        public static string OpenInstalDirectory()
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                return folderBrowserDialog.SelectedPath;
            }
            return Config.Directory;
        }
        //public static void SetRootDirectory()
        //{
        //    if (Properties.Settings.Default.path == "")
        //    {
        //        MessageWindow.Show("Установка игры", $"Игра будет установлена: {Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}");

        //        Properties.Settings.Default.path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        //        DirectoryStr = Properties.Settings.Default.path;
        //        Properties.Settings.Default.Save();
        //    }
        //    Initialise();
        //}
        public static void CreateFolder(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }
    }
}
