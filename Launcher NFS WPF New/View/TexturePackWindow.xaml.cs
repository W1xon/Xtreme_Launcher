using System.Windows;

namespace Launcher_NFS.View
{
    /// <summary>
    /// Логика взаимодействия для TexturePackWindow.xaml
    /// </summary>
    public partial class TexturePackWindow : Window
    {
        public TexturePackWindow()
        {
            InitializeComponent();
        }

        public static new void Show()
        {
            TexturePackWindow message = new TexturePackWindow();
            message.ShowDialog();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
