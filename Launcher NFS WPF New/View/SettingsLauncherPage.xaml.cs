using Launcher_NFS.Model;
using Launcher_NFS.ViewModel;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using static Launcher_NFS.ViewModel.ThemeManager;
namespace Launcher_NFS.View
{
    /// <summary>
    /// Логика взаимодействия для SettingsLauncherPage.xaml
    /// </summary>
    public partial class SettingsLauncherPage : Page
    {

        FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
        private string TextPathGameText
        {
            get { return TextPathGame.Text; }
            set { TextPathGame.Text = value; }
        }
        public SettingsLauncherPage()
        {
            InitializeComponent();
            SetTextPath(PathProvider.Config.Exe);
        }
        private void SetTextPath(string exe)
        {
            TextPathGameText = exe;
        }
        private void ThemeButton_Click(object sender, RoutedEventArgs e)
        {
            if(sender is System.Windows.Controls.Button button && Enum.TryParse(button.Tag.ToString(), out Theme selectedTheme))
            {
                SetTheme(selectedTheme);
            }
        }
        private void PlaySoundForTheme(Theme theme)
        {
            switch (theme) 
            {
                case Theme.Phub:
                    Sound.PlayPhub();
                    break;
                default:
                    Sound.PlayClick();
                    break;
            }
           
        }
        private void ButtonSelectedGamePath_Click(object sender, RoutedEventArgs e)
        {
           Sound.PlayClick();
            var folderDialog = new FolderBrowserDialog();
            if (folderDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedFolder = folderDialog.SelectedPath;
                TextPathGame.Text = selectedFolder;
            }
        }

        private void ButtonLangRu_Click(object sender, RoutedEventArgs e)
        {
           Sound.PlayClick();
            SetLanguage("ru-RU");
        }

        private void ButtonLangEn_Click(object sender, RoutedEventArgs e)
        {
           Sound.PlayClick();
            SetLanguage("en-US");
        }
        private void SetLanguage(string lang)
        {
            if (lang == Properties.Settings.Default.languageCode)
                return;
            MessageWindow.Show(Properties.Langs.Lang.changeLanguageTitle, Properties.Langs.Lang.changeLanguage, true);
            Properties.Settings.Default.languageCode = lang;
            Properties.Settings.Default.Save();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainViewModel.Instance.OpenSettingsGame();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            TexturePackWindow.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            MusicWindow.Show();
        }
    }
}
