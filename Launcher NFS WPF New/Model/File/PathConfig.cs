using System;

namespace Launcher_NFS.Model
{
    internal class PathConfig
    {
        private string _directory = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
        private string _exe;
        private string _folder = "Need For Speed - Extreme Terrex";
        private string _loadFolder = "testtest-main";
        private string _settingsOne;
        private string _settingsTwo;
        private string _updateFileInfo = "UpdateInfo.txt";
        private string _zip = "Need For Speed - Extreme Terrex.zip";
        private string _bubenUltra = "bubenultra.conf";
        public string Directory
        {
            get
            {
                return _directory;
            }
            set
            {
                _directory = value;
                Properties.Settings.Default.path = value;
                Properties.Settings.Default.Save();
            }
        }
        public string Exe
        {
            get
            {
                return $@"{Folder}\{_exe}";
            }
            set
            {
                _exe = value;
            }
        }
        public string Folder
        {
            get
            {
                return $@"{Directory}\{_folder}";
            }
        }
        public string LoadFolder
        {
            get
            {
                return $@"{Directory}\{_loadFolder}";
            }
        }
        public string SettingsOne
        {
            get
            {
                return $@"{Folder}\{_settingsOne}";
            }
            set
            {
                _settingsOne = value;
            }
        }
        public string SettingsTwo
        {
            get
            {
                return $@"{Folder}\{_settingsTwo}";
            }
            set
            {
                _settingsTwo = value;
            }
        }
        public string UpdateFileInfo
        {
            get
            {
                return $@"{Directory}\{_updateFileInfo}";
            }
        }
        public string Zip
        {
            get
            {
                return $@"{Directory}\{_zip}";
            }
        }
        public string BubenUltra
        {
            get
            {
                return $@"{Folder}\{_bubenUltra}";
            }
        }
    }
}
