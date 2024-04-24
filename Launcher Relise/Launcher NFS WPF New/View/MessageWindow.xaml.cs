using Launcher_NFS_WPF_New.Model;
using System.Media;
using System.Windows;

namespace Launcher_NFS_WPF_New.View
{
    /// <summary>
    /// Логика взаимодействия для MessageWindow.xaml
    /// </summary>
    public partial class MessageWindow : Window
    {
        ButtonSoundler soundPlayer = new ButtonSoundler("View\\Res\\BtnClick.wav");
        public MessageWindow()
        {
            InitializeComponent();
        }
        public MessageWindow(bool warning)
        {
            InitializeComponent();
            TextWarning.Text = Properties.Langs.Lang.incorretPathMessage;
        }
        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
            Application.Current.Shutdown();
            soundPlayer.Play();
            Close();
        }
    }
}
