using Launcher_NFS_WPF_New.Model;
using Launcher_NFS_WPF_New.View;
using Launcher_NFS_WPF_New.ViewModel;
using System;
using System.Media;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
namespace Launcher_NFS_WPF_New
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ButtonSoundler soundPlayer = new ButtonSoundler("View\\Res\\BtnClick.wav");
        public MainWindow()
        {
            InitializeLauncherSettings();
            InitializeComponent();
            PageFrame.Source = new Uri("PlayPage.xaml", UriKind.Relative);
            BtnPlay.Focus();
        }

        private void InitializeLauncherSettings()
        {
            PathManager.Initialise();
            FileManager.ReadFile(PathManager.settings);
            ThemeManager.Initialise();
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            soundPlayer.Play();
            ((SettingsGamePage)MainViewModel.SettingsGamePage).FillingComboBox();
        }

        //private void CloseSideMenu_Click(object sender, RoutedEventArgs e)
        //{
        //    DoubleAnimation animation = new DoubleAnimation();
        //    animation.To = 50;
        //    animation.Duration = new Duration(TimeSpan.FromSeconds(0.3));
        //    SideMenuGrid.BeginAnimation(WidthProperty, animation);
        //}
        //private void OpenSideMenu_Click(object sender, RoutedEventArgs e)
        //{
        //    DoubleAnimation animation = new DoubleAnimation();
        //    animation.To = 200;
        //    animation.Duration = new Duration(TimeSpan.FromSeconds(0.3));
        //    SideMenuGrid.BeginAnimation(WidthProperty, animation);
        //}
    }
}
