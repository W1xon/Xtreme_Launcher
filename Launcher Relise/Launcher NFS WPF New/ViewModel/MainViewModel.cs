using GalaSoft.MvvmLight.Command;
using Launcher_NFS_WPF_New.View;
using System.Windows.Controls;
using System.Windows.Input;

namespace Launcher_NFS_WPF_New.ViewModel
{
    internal class MainViewModel : ViewModedBase
    {
        private Page PlayPage = new PlayPage();
        private Page AuthorPage = new AuthorPage();
        public static Page SettingsLauncherPage = new SettingsLauncherPage();
        public static Page SettingsGamePage = new SettingsGamePage();
        public static Page UpdatePage = new UpdatePage();
        private Page _CurPage = new PlayPage();
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

        public ICommand OpenSettingsLauncherPage
        {
            get
            {
                return new RelayCommand(() => CurPage = SettingsLauncherPage);
            }
        }
        public ICommand OpenUpdatePage
        {
            get
            {
                return new RelayCommand(() => CurPage = UpdatePage);
            }
        }
    }
}
