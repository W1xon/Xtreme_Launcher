using Launcher_NFS_WPF_New.Model;
using Launcher_NFS_WPF_New.ViewModel;
using System.Media;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using static Launcher_NFS_WPF_New.ViewModel.ThemeManager;
namespace Launcher_NFS_WPF_New.View
{
    /// <summary>
    /// Логика взаимодействия для SettingsLauncherPage.xaml
    /// </summary>
    public partial class SettingsLauncherPage : Page
    {

        ButtonSoundler soundPlayer = new ButtonSoundler("View\\Res\\BtnClick.wav");
        ButtonSoundler soundPhubPlayer = new ButtonSoundler("View\\Res\\PhubClick.wav");
        OpenFileDialog openFileDialog = new OpenFileDialog();
        public string TextPathGameText
        {
            get { return TextPathGame.Text; }
            set { TextPathGame.Text = value; }
        }
        public SettingsLauncherPage()
        {
            InitializeComponent();
            openFileDialog.Filter = "Файлы exe|*.exe";

        }

        private void ButtonSelectedThemeNight_Click(object sender, RoutedEventArgs e)
        {
            soundPlayer.Play();
            SetTheme(Theme.Night);
        }

        private void ButtonSelectedDefaultTheme_Click(object sender, RoutedEventArgs e)
        {
            soundPlayer.Play();
            SetTheme(Theme.Default);
        }
        private void ButtonSelectedThemeDay_Click(object sender, RoutedEventArgs e)
        {
            soundPlayer.Play();
            SetTheme(Theme.Day);
        }
        private void ButtonSelectedThemeDark_Click(object sender, RoutedEventArgs e)
        {
            soundPlayer.Play();
            SetTheme(Theme.Dark);
        }

        private void ButtonSelectedGreenTheme_Click(object sender, RoutedEventArgs e)
        {

            soundPlayer.Play();
            SetTheme(Theme.Green);
        }

        private void ButtonSelectedBlueTheme_Click(object sender, RoutedEventArgs e)
        {
            soundPlayer.Play();
            SetTheme(Theme.Blue);
        }
        private void ButtonSelectedSciFiTheme_Click(object sender, RoutedEventArgs e)
        {
            soundPlayer.Play();
            SetTheme(Theme.SciFi);
        }

        private void ButtonSelectedSteamTheme_Click(object sender, RoutedEventArgs e)
        {
            soundPlayer.Play();
            SetTheme(Theme.Steam);
        }
        private void ButtonSelectedSpotifyTheme_Click(object sender, RoutedEventArgs e)
        {
            soundPlayer.Play();
            SetTheme(Theme.Spotify);
        }
        private void ButtonSelectedPhubTheme_Click(object sender, RoutedEventArgs e)
        {
            soundPhubPlayer.Play();
            SetTheme(Theme.Phub);
        }
        private void ButtonSelectedGamePath_Click(object sender, RoutedEventArgs e)
        {
            soundPlayer.Play();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (!PathManager.IsCorrectFileSettings(openFileDialog.FileName))
                {
                    MessageWindow message = new MessageWindow(true);
                    message.Show();
                    return;
                }
                TextPathGame.Text = openFileDialog.FileName;
                FileManager.Initialisation(openFileDialog.FileName);
                ((SettingsGamePage)MainViewModel.SettingsGamePage).FillingComboBox();
            }
        }

        private void ButtonLangRu_Click(object sender, RoutedEventArgs e)
        {
            soundPlayer.Play();
            SetLanguage("ru-RU");
        }

        private void ButtonLangEn_Click(object sender, RoutedEventArgs e)
        {
            soundPlayer.Play();
            SetLanguage("en-US");
        }

        private void SetLanguage(string lang)
        {
            if (lang == Properties.Settings.Default.languageCode)
                return;
            MessageWindow message = new MessageWindow();
            message.ShowDialog();
            Properties.Settings.Default.languageCode = lang;
            Properties.Settings.Default.Save();
        }

    }
}
