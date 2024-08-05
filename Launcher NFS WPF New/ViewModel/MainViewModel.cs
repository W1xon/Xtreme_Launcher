using GalaSoft.MvvmLight.Command;
using Launcher_NFS.View;
using System.Windows.Controls;
using System.Windows.Input;

namespace Launcher_NFS.ViewModel
{
    public class MainViewModel : ViewModedBase
    {
        public Page PlayPage;
        public Page AuthorPage;
        public static Page SettingsLauncherPage;
        public static Page SettingsGamePage;
        public Page UpdatePage;
        private Page _CurPage;
        private static MainViewModel _instance;
        public static MainViewModel Instance
        {
            get
            {
                return _instance;
            }
            set
            {
                if (_instance == null)
                {
                    _instance = value;
                }
            }
        }
        public void InitializePage()
        {
            SettingsLauncherPage = new SettingsLauncherPage();
            AuthorPage = new AuthorPage();
            SettingsGamePage = new SettingsGamePage();
            UpdatePage = new UpdatePage();
            PlayPage = new PlayPage();
        }
        public Page CurPage
        {
            get => _CurPage;
            set => Set(ref _CurPage, value);
        }
        public ICommand OpenPlayPage
        {
            get
            {
                return new RelayCommand(() => CurPage = PlayPage);
            }
        }
        public ICommand OpenAuthorPage
        {
            get
            {
                return new RelayCommand(() => CurPage = AuthorPage);
            }
        }

        public ICommand OpenSettingsGamePage
        {
            get
            {
                return new RelayCommand(() => CurPage = SettingsGamePage);
            }
        }

        //public ICommand OpenSettingsLauncherPage
        //{
        //    get
        //    {
        //        return new RelayCommand(() => CurPage = SettingsLauncherPage);
        //    }
        //}
        public ICommand OpenUpdatePage
        {
            get
            {
                return new RelayCommand(() => CurPage = UpdatePage);
            }
        }
        public void OpenSettingsLauncherPage()
        {
            CurPage = SettingsLauncherPage;
        }

        public void OpenSettingsGame()
        {
            CurPage = SettingsGamePage;
        }
    }
}
