using Launcher_NFS_WPF_New.Model;
using System.Windows.Controls;
using static Launcher_NFS_WPF_New.Model.Params;

namespace Launcher_NFS_WPF_New.View
{
    /// <summary>
    /// Логика взаимодействия для SettingsGamePage.xaml
    /// </summary>
    public partial class SettingsGamePage : Page
    {
        ButtonSoundler soundPlayer = new ButtonSoundler("View\\Res\\BtnClick.wav");
        public SettingsGamePage()
        {
            InitializeComponent();
        }
        public void FillingComboBox()
        {

            var settings = FileManager.settings;

            if (settings.ContainsKey(g_VSyncOn))
            {
                ComboBoxVSync.SelectedIndex = int.Parse(settings[g_VSyncOn]);
                ComboBoxVSync.FontSize = 30;
            }
            if (settings.ContainsKey(g_FSAALevel))
            {
                ComboBoxFSAALevel.SelectedIndex = int.Parse(settings[g_FSAALevel]);
                ComboBoxFSAALevel.FontSize = 30;
            }
            if (settings.ContainsKey(g_TextureFiltering))
            {
                ComboBoxTextureFiltering.SelectedIndex = int.Parse(settings[g_TextureFiltering]);
                ComboBoxTextureFiltering.FontSize = 30;
            }
            if (settings.ContainsKey(g_WorldLodLevel))
            {
                ComboBoxWorldLodLevel.SelectedIndex = int.Parse(settings[g_WorldLodLevel]);
                ComboBoxWorldLodLevel.FontSize = 30;
            }
            if (settings.ContainsKey(g_CarLodLevel))
            {
                ComboBoxCarLodLevel.SelectedIndex = int.Parse(settings[g_CarLodLevel]);
                ComboBoxCarLodLevel.FontSize = 30;
            }
            if (settings.ContainsKey(g_CarEnvironmentMapEnable))
            {
                ComboBoxCarEnvironmentMapEnable.SelectedIndex = int.Parse(settings[g_CarEnvironmentMapEnable]);
                ComboBoxCarEnvironmentMapEnable.FontSize = 30;
            }
            if (settings.ContainsKey(g_CarEnvironmentMapUpdateData))
            {
                ComboBoxCarEnvironmentMapUpdateData.SelectedIndex = int.Parse(settings[g_CarEnvironmentMapUpdateData]);
                ComboBoxCarEnvironmentMapUpdateData.FontSize = 30;
            }
            if (settings.ContainsKey(g_RoadReflectionEnable))
            {
                ComboBoxRoadReflectionEnable.SelectedIndex = int.Parse(settings[g_RoadReflectionEnable]);
                ComboBoxRoadReflectionEnable.FontSize = 30;
            }
            if (settings.ContainsKey(g_ShadowDetail))
            {
                ComboBoxShadowDetail.SelectedIndex = int.Parse(settings[g_ShadowDetail]);
                ComboBoxShadowDetail.FontSize = 30;
            }
            if (settings.ContainsKey(g_RainEnable))
            {
                ComboBoxRainEnable.SelectedIndex = int.Parse(settings[g_RainEnable]);
                ComboBoxRainEnable.FontSize = 30;
            }
            if (settings.ContainsKey(g_MotionBlurEnable))
            {
                ComboBoxAdditionalPostEffects.SelectedIndex = int.Parse(settings[g_MotionBlurEnable]);
                ComboBoxAdditionalPostEffects.FontSize = 30;
            }
        }
        private void ComboBox_SelectionChanged_VSync(object sender, SelectionChangedEventArgs e)
        {
            if (sender is ComboBox comboBox)
            {
                ChangeVSyncOn(comboBox.SelectedIndex);
            }
        }

        private void ComboBox_SelectionChanged_FSAALevel(object sender, SelectionChangedEventArgs e)
        {
            if (sender is ComboBox comboBox)
            {
                ChangeFSAALevel(comboBox.SelectedIndex);
            }
        }

        private void ComboBox_SelectionChanged_TextureFiltering(object sender, SelectionChangedEventArgs e)
        {
            if (sender is ComboBox comboBox)
            {
                ChangeTextureFiltering(comboBox.SelectedIndex);
            }
        }

        private void ComboBox_SelectionChanged_WorldLodLevel(object sender, SelectionChangedEventArgs e)
        {
            if (sender is ComboBox comboBox)
            {
                ChangeWorldLodLevel(comboBox.SelectedIndex);
            }
        }

        private void ComboBox_SelectionChanged_CarLodLevel(object sender, SelectionChangedEventArgs e)
        {
            if (sender is ComboBox comboBox)
            {
                ChangeCarLodLevel(comboBox.SelectedIndex);
            }
        }

        private void ComboBox_SelectionChanged_CarEnvironmentMapEnable(object sender, SelectionChangedEventArgs e)
        {
            if (sender is ComboBox comboBox)
            {
                ChangeCarEnvironmentMapEnable(comboBox.SelectedIndex);
            }
        }

        private void ComboBox_SelectionChanged_CarEnvironmentMapUpdateData(object sender, SelectionChangedEventArgs e)
        {
            if (sender is ComboBox comboBox)
            {
                ChangeCarEnvironmentMapUpdateData(comboBox.SelectedIndex);
            }
        }

        private void ComboBox_SelectionChanged_RoadReflectionEnable(object sender, SelectionChangedEventArgs e)
        {
            if (sender is ComboBox comboBox)
            {
                ChangeRoadReflectionEnable(comboBox.SelectedIndex);
            }
        }

        private void ComboBox_SelectionChanged_ShadowDetail(object sender, SelectionChangedEventArgs e)
        {
            if (sender is ComboBox comboBox)
            {
                ChangeShadowDetail(comboBox.SelectedIndex);
            }
        }

        private void ComboBox_SelectionChanged_RainEnable(object sender, SelectionChangedEventArgs e)
        {
            if (sender is ComboBox comboBox)
            {
                ChangeRainEnable(comboBox.SelectedIndex);
            }
        }

        private void ComboBox_SelectionChanged_AdditionalPostEffects(object sender, SelectionChangedEventArgs e)
        {
            if (sender is ComboBox comboBox)
            {
                ChangeMotionBlurEnable(comboBox.SelectedIndex);
                ChangeOverBrightEnable(comboBox.SelectedIndex);
                ChangeVisualTreatment(comboBox.SelectedIndex);
                ChangeParticleSystemEnable(comboBox.SelectedIndex);

            }
        }

        private void ComboBox_DropDownOpened(object sender, System.EventArgs e)
        {
            soundPlayer.Play();
        }
    }
}
