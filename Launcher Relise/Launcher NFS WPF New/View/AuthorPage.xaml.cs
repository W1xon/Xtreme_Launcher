using Launcher_NFS_WPF_New.Model;
using System;
using System.Media;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using static Launcher_NFS_WPF_New.Model.URLManager;

namespace Launcher_NFS_WPF_New.View
{
    /// <summary>
    /// Логика взаимодействия для AuthorPage.xaml
    /// </summary>
    public partial class AuthorPage : Page
    {
        ButtonSoundler soundPlayer = new ButtonSoundler("View\\Res\\BtnClick.wav");
        ResourcesWindow resourcesWindow;
        public AuthorPage()
        {
            InitializeComponent();
        }

        private void ButtonOpenURLCWVK_Click(object sender, RoutedEventArgs e)
        {
            soundPlayer.Play();
            OpenURL(URLCoderWorkerVK);
        }
        private void ButtonOpenURLONMYouTube_Click(object sender, RoutedEventArgs e)
        {
            soundPlayer.Play();
            OpenURL(URLOneNFSModdingYouTube);
        }
        private void ButtonOpenURLCWTelegram_Click(object sender, RoutedEventArgs e)
        {
            soundPlayer.Play();
            OpenURL(URLCoderWorkerTelegram);
        }
        private void ButtonOpenURLONMTelegram_Click(object sender, RoutedEventArgs e)
        {
            soundPlayer.Play();
            OpenURL(URLOneNFSModdingTelegram);
        }

        private void BtnResource_Click(object sender, RoutedEventArgs e)
        {
            resourcesWindow = new ResourcesWindow();
            resourcesWindow.ShowDialog();
            soundPlayer.Play();
        }
    }
}
