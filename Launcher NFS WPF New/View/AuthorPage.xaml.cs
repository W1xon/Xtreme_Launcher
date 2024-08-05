using Launcher_NFS.Model;
using System.Windows;
using System.Windows.Controls;
using static Launcher_NFS.Model.Network.SocialNetwork;

namespace Launcher_NFS.View
{
    /// <summary>
    /// Логика взаимодействия для AuthorPage.xaml
    /// </summary>
    public partial class AuthorPage : Page
    {
        ResourcesWindow resourcesWindow;
        public AuthorPage()
        {
            InitializeComponent();
        }
        private void ButtonOpenURLCoderWorkerYoutube_Click(object sender, RoutedEventArgs e)
        {
            Sound.PlayClick();
            Open(UrlCoderWorkerVK);
        }
        private void ButtonOpenURLLemonGangCornerYouTube_Click(object sender, RoutedEventArgs e)
        {
            Sound.PlayClick();
            Open(UrlOneNFSModdingYouTube);
        }
        private void ButtonOpenURLCoderWorkerTelegram_Click(object sender, RoutedEventArgs e)
        {
            Sound.PlayClick();
            Open(UrlCoderWorkerTelegram);
        }
        private void ButtonOpenURLLemonGangCornerTelegram_Click(object sender, RoutedEventArgs e)
        {
            Sound.PlayClick();
            Open(UrlOneNFSModdingTelegram);
        }

        private void BtnResource_Click(object sender, RoutedEventArgs e)
        {
            resourcesWindow = new ResourcesWindow();
            resourcesWindow.ShowDialog();
            Sound.PlayClick();
        }
    }
}
