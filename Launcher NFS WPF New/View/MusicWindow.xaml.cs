using System.Windows;

namespace Launcher_NFS.View
{
    /// <summary>
    /// Логика взаимодействия для TexturePackWindow.xaml
    /// </summary>
    public partial class MusicWindow : Window
    {
        public MusicWindow()
        {
            InitializeComponent();
        }

        public static new void Show()
        {
            MusicWindow message = new MusicWindow();
            message.ShowDialog();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
