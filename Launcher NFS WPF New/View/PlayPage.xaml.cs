using Launcher_NFS.Model;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Application = System.Windows.Application;

namespace Launcher_NFS.View
{
    /// <summary>
    /// Логика взаимодействия для PlayPage.xaml
    /// </summary>
    public partial class PlayPage : Page
    {
        private GameDownloader _gameDownloader;
        private UpdateInfoProvider _updateInfoProvider = new UpdateInfoProvider();
        public PlayPage playPage;
        public PlayPage()
        {
            InitializeComponent();
            InitializeGameDownloader();
            SetStatusGame();
            playPage = this;
        }
        private void InitializeGameDownloader()
        {
            _gameDownloader = new GameDownloader();
            _gameDownloader.LoadProcess += (string loadInfo, long loadSize) =>
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    btnPlay.Content = Properties.Langs.Lang.networkLoading;
                    InfoUpdateText.Text = loadInfo;
                    UpdateProgressBar.Value = loadSize;
                });
            };
            _gameDownloader.LoadStart += () =>
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    UpdateProgressBar.Visibility = Visibility.Visible;
                    UpdateProgressBar.Maximum = UpdateModificationInfo.Weight;
                });
            };
            _gameDownloader.LoadCompleted += () =>
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    UpdateProgressBar.Value = UpdateProgressBar.Maximum;
                    InfoUpdateText.Text = Properties.Langs.Lang.networkInstallation;
                });
            };
        }
        public void SetStatusGame()
        {
            if (!UpdateModificationInfo.IsLoad)
                btnPlay.Content = Properties.Langs.Lang.networkDownload;
            else
                btnPlay.Content = Properties.Langs.Lang.gameStart;
        }
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            if (UpdateModificationInfo.IsLoad)
            {
                RunGame();
                return;
            }
            await DownloadGame();
        }
        private void RunGame()
        {
            Sound.PlayStart();
            var procInfo = new ProcessStartInfo(Properties.Settings.Default.path);
            procInfo.WorkingDirectory = System.IO.Path.GetDirectoryName(Properties.Settings.Default.path);
            Process.Start(procInfo);
            Thread.Sleep(1000);
            Application.Current.Shutdown();
        }
        private async Task DownloadGame()
        {
            PathProvider.Config.Directory = PathProvider.OpenInstalDirectory();
            await _updateInfoProvider.LoadGameInfo(new Uri("https://github.com/W1xon/testtest/raw/main/UpdateInfo.txt"));
            _gameDownloader.LoadGame(new Uri("https://github.com/W1xon/testtest/archive/refs/heads/main.zip"));
        }
    }
}
