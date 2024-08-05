using Launcher_NFS.Model;
using Launcher_NFS.Model.SettingsConfiguration;
using Launcher_NFS.ViewModel;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Launcher_NFS.View
{
    /// <summary>
    /// Логика взаимодействия для SettingsGamePage.xaml
    /// </summary>
    public partial class SettingsGamePage : Page
    {


        public SettingsGamePage()
        {
            InitializeComponent();
            InitializeComboBox();
            DataContext = MainViewModel.Instance;
        }
        private void InitializeComboBox()
        {
            Dictionary<ComboBox, string> comboBoxSettingsMapping = new Dictionary<ComboBox, string>
            {
                { ComboBoxVSync, "g_VSyncOn" },
                { ComboBoxFSAALevel, "g_FSAALevel" },
                { ComboBoxTextureFiltering, "g_TextureFiltering" },
                { ComboBoxWorldLodLevel, "g_WorldLodLevel" },
                { ComboBoxCarLodLevel, "g_CarLodLevel" },
                { ComboBoxCarEnvironmentMapEnable, "g_CarEnvironmentMapEnable" },
                { ComboBoxCarEnvironmentMapUpdateData, "g_CarEnvironmentMapUpdateData" },
                { ComboBoxRoadReflectionEnable, "g_RoadReflectionEnable" },
                { ComboBoxShadowDetail, "g_ShadowDetail" },
                { ComboBoxRainEnable, "g_RainEnable" },
             { ComboBoxAdditionalPostEffects, "g_MotionBlurEnable" }
            };

            var settings = GameConfigurator.settingsConfiguration;
            foreach ( var pair in comboBoxSettingsMapping)
            {
                var combobox = pair.Key;
                var key = pair.Value;

                if (settings.ContainsKey(key))
                {
                    combobox.SelectedIndex = int.Parse(settings[key]);
                }
            }
        }
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is ComboBox comboBox && Enum.TryParse(comboBox.Tag.ToString(), out Parameters parameters))
            {
                GameConfigurator.ChangeParam(parameters, comboBox.SelectedIndex);
            }
        }

        private void ComboBox_SelectionChanged_AdditionalPostEffects(object sender, SelectionChangedEventArgs e)
        {
            if (sender is ComboBox comboBox)
            {
                GameConfigurator.ChangeParam(Parameters.g_MotionBlurEnable, comboBox.SelectedIndex);
                GameConfigurator.ChangeParam(Parameters.g_OverBrightEnable, comboBox.SelectedIndex);
                GameConfigurator.ChangeParam(Parameters.g_VisualTreatment, comboBox.SelectedIndex);
                GameConfigurator.ChangeParam(Parameters.g_ParticleSystemEnable, comboBox.SelectedIndex);
            }
        }

        private void ComboBox_DropDownOpened(object sender, EventArgs e)
        {
            Sound.PlayClick();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainViewModel.Instance.OpenSettingsLauncherPage();
        }
    }
}
