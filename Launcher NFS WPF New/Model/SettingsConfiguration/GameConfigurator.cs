using System.Collections.Generic;
using static Launcher_NFS.Model.FileProvider;
namespace Launcher_NFS.Model.SettingsConfiguration
{
    internal class GameConfigurator
    {
        public static Dictionary<string, string> settingsConfiguration = new Dictionary<string, string>();

        public static void Initialize()
        {
            string config = ReadFile(PathProvider.Config.SettingsOne);
            if (config != null)
                StringToConfiguration(config);
        }
        public static void ChangeParam(Parameters parameters, int status)
        {
            if (settingsConfiguration.Count < 1)
                return;

            settingsConfiguration[nameof(parameters)] = status.ToString();
            SaveConfiguration();
        }
        private static void SaveConfiguration()
        {
            string content = ConfigurationToString();
            WriteFile(content, PathProvider.Config.SettingsOne);
            WriteFile(content, PathProvider.Config.SettingsTwo);
        }

        private static string ConfigurationToString()
        {
            string confString = "";
            foreach (var line in settingsConfiguration)
            {
                if (line.Value != "")
                    confString += $"{line.Key}= {line.Value}\n";
                else
                {
                    confString += $"{line.Key}\n";
                }
            }
            return confString;
        }

        public static void StringToConfiguration(string content)
        {
            settingsConfiguration.Clear();
            string name, status = "";
            foreach (string line in content.Split('\n'))
            {
                name = line.Split('=')[0];
                if (string.IsNullOrEmpty(name))
                    return;

                if (line.Split('=').Length > 1)
                    status = line.Split('=')[1].Replace(" ", "");
                settingsConfiguration.Add(name, status);
            }
        }
    }
}
