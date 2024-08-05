using Launcher_NFS.View;
using Launcher_NFS.ViewModel;
namespace Launcher_NFS.Model.SettingsConfiguration
{
    internal class LauncherInitialization
    {
        public static void Initialize()
        {
            GameConfigurator.Initialize();
            MainViewModel.Instance = new MainViewModel();
            MainViewModel.Instance.InitializePage();
            PathProvider.Initialize();
            ThemeManager.Initialise();
            ((PlayPage)MainViewModel.Instance.PlayPage).SetStatusGame();
        }
    }
}
