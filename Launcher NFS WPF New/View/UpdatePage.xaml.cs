using Launcher_NFS.Model;
using System;
using System.Windows;

namespace Launcher_NFS.View
{
    /// <summary>
    /// Логика взаимодействия для UpdatePage.xaml
    /// </summary>
    public partial class UpdatePage
    {
        private UpdateDownloader _updateDownloader;
        private UpdateInfoProvider _updateInfoProvider = new UpdateInfoProvider();
        public UpdatePage()
        {
            InitializeComponent();
            InitializeUpdateDownloader();
        }
        private void InitializeUpdateDownloader()
        {
            _updateDownloader = new UpdateDownloader();
            _updateInfoProvider.ShowingUpdate += (bool isUpdate) =>
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    if (isUpdate)
                    {
                        InfoUpdateText.Text = $"{Properties.Langs.Lang.networkThereIsAnUpdate}: {UpdateModificationInfo.Version}";
                        BtnLoad.Visibility = Visibility.Visible;
                        BtnCheckUpdate.Visibility = Visibility.Hidden;
                    }
                    else
                    {
                        InfoUpdateText.Text = $"{Properties.Langs.Lang.networkNoUpdates}";
                    }
                });

            };
            _updateDownloader.LoadStart += () =>
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    InfoUpdateText.Text = "";
                    UpdateProgressBar.Visibility = Visibility.Visible;
                    BtnLoad.Visibility = Visibility.Hidden;
                    UpdateProgressBar.Maximum = UpdateModificationInfo.WeightUpdateByte;
                });
            };
            _updateDownloader.UpdateProcess += (string loadInfo, string fileName, long loadSize) =>
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    InfoFileNameText.Text = $"- {fileName} -";
                    InfoUpdateText.Text = loadInfo;
                    UpdateProgressBar.Value = loadSize;
                });
            };
            _updateDownloader.LoadCompleted += () =>
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    UpdateProgressBar.Value = 0;
                    BtnCheckUpdate.Visibility = Visibility.Visible;
                    BtnLoad.Visibility = Visibility.Hidden;
                    UpdateProgressBar.Visibility = Visibility.Hidden;
                    InfoUpdateText.Text = $"{Properties.Langs.Lang.networkUpdateInstalled}";
                });
            };
        }
        private async void BtnLoad_Click(object sender, RoutedEventArgs e)
        {
            await _updateDownloader.LoadUpdate();
            //Properties.Settings.Default.version = UpdateModificationInfo.Version;
        }
        private async void BtnCheckUpdate_Click(object sender, RoutedEventArgs e)
        {
            await _updateInfoProvider.ShowUpdate(new Uri("https://github.com/W1xon/testtest/raw/main/UpdateInfo.txt"));
        }
    }
}
