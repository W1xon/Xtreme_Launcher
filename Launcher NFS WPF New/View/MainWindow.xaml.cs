using Launcher_NFS.Model;
using Launcher_NFS.Model.SettingsConfiguration;
using Launcher_NFS.ViewModel;
using System.Windows;
using System.Windows.Input;
namespace Launcher_NFS
{
    /// <summary>ЦЦ
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            LauncherInitialization.Initialize();
            InitializeComponent();
            DataContext = MainViewModel.Instance;
            BtnPlay.Focus();
        }
        private void SetButtonVisivility(bool visible)
        {
            if (visible) VisibleButton();
            else HiddenButton();
        }
        private void HiddenButton()
        {
            BtnSettings.Visibility = Visibility.Hidden;
            BtnUpdate.Visibility = Visibility.Hidden;
            BtnAuthor.Visibility = Visibility.Hidden;
        }
        private void VisibleButton()
        {
            BtnSettings.Visibility = Visibility.Visible;
            BtnUpdate.Visibility = Visibility.Visible;
            BtnAuthor.Visibility = Visibility.Visible;
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Sound.PlayClick();
        }
        private void ButtonSettings_Click(object sender, RoutedEventArgs e)
        {
            Sound.PlayClick();
        }
        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
