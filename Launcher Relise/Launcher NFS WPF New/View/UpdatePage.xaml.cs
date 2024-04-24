using Launcher_NFS_WPF_New.Model;
using System;
using System.Windows.Controls;
using System.Windows.Threading;
using System.Windows;
namespace Launcher_NFS_WPF_New.View
{
    /// <summary>
    /// Логика взаимодействия для UpdatePage.xaml
    /// </summary>
    public partial class UpdatePage : Page
    {
        public delegate void Update_Handler();

        private Update_Handler visibleBtn;
        private Update_Handler hiddenBtn;
        public UpdatePage()
        {
            InitializeComponent();
            visibleBtn = () =>
            {
                BtnLoad.Visibility = Visibility.Visible;
            };
            hiddenBtn = () =>
            {
                BtnStop.Visibility = Visibility.Hidden;
                BtnCancel.Visibility = Visibility.Hidden;
                BtnLoad.Visibility = Visibility.Hidden;
                UpdateProgressBar.Visibility = Visibility.Hidden;
                InfoUpdateText.Text = "У вас установлена самая новая версия игры";
            };
        }

        private void BtnLoad_Click(object sender, RoutedEventArgs e)
        {
            InfoUpdateText.Text = "";
            GitClient.UpdateLoad(new Uri("https://github.com/W1xon/PrivateTest/raw/main/NFS.zip"), "NFS.zip", UpdateProgressBar, InfoUpdateText, hiddenBtn);
            BtnStop.Visibility = Visibility.Visible;
            BtnCancel.Visibility = Visibility.Visible;
            UpdateProgressBar.Visibility = Visibility.Visible;
            //Properties.Settings.Default.version = UpdateModificationInfo.Version;
        }
        private void BtnCheckUpdate_Click(object sender, RoutedEventArgs e)
        {
            GitClient.ShowUpdate(new Uri("https://raw.githubusercontent.com/W1xon/PrivateTest/main/UpdateInfo.txt"), InfoUpdateText, visibleBtn);
        }
        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}
