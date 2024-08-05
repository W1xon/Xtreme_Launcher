using Launcher_NFS.Model;
using System.Windows;

namespace Launcher_NFS.View
{
    /// <summary>
    /// Логика взаимодействия для MessageWindow.xaml
    /// </summary>
    public partial class MessageWindow : Window
    {
        public MessageWindow(string title, string message, bool relaunch)
        {
            InitializeComponent();

            if (relaunch)
            {
                BtnOk.Click += BtnOkRelaunch_Click;
            }
            else
                BtnOk.Click += BtnOk_Click;
            TitleText.Text = title;
            TextMes.Text = message;
        }
        public static void Show(string title, string mess, bool relaunch = false)
        {
            MessageWindow message = new MessageWindow(title, mess, relaunch);
            message.ShowDialog();
        }
        private void BtnOkRelaunch_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
            System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
            Sound.PlayClick();
            Close();
        }
        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {
            Sound.PlayClick();
            Close();
        }
    }
}
