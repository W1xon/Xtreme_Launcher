using Launcher_NFS_WPF_New.Model;
using System.Diagnostics;
using System.Media;
using System.Threading;
using System.Windows;
using System.Windows.Controls;

namespace Launcher_NFS_WPF_New.View
{
    /// <summary>
    /// Логика взаимодействия для PlayPage.xaml
    /// </summary>
    public partial class PlayPage : Page
    {
        ButtonSoundler soundPlayer = new ButtonSoundler(@"View\Res\PlayGame.wav");
        public PlayPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            soundPlayer.Play();
            var procInfo = new ProcessStartInfo(Properties.Settings.Default.path);
            procInfo.WorkingDirectory = System.IO.Path.GetDirectoryName(Properties.Settings.Default.path);
            Process.Start(procInfo);

            Thread.Sleep(1000);
            Application.Current.Shutdown();
        }
    }
}
