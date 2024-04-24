using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;

namespace Launcher_NFS_WPF_New.Model
{
    internal class FileManager
    {
        public static Dictionary<string, string> settings = new Dictionary<string, string>();
        public static void Initialisation(string path)
        {
            PathManager.SetFileSettings(path);
            FillSettings(PathManager.settings);

        }
        public static string ReadFile(string path)
        {
            string content = "";
            if (!File.Exists(path))
            {
                MessageBox.Show(path);
                return null;
            }
            using (StreamReader sReader = new StreamReader(path))
            {
                content = sReader.ReadToEnd();
            }
            return content;
        }
        public static void WriteFile(string content, string path)
        {
            using (StreamWriter sWriter = new StreamWriter(path))
            {
                sWriter.Write(content);
            }
        }

        public static void ChangeParam(string param, int status)
        {
            if (settings.Count < 1)
                return;
            settings[param] = status.ToString();

            string content = GetContent();
            WriteFile(content, PathManager.settings);
            WriteFile(content, PathManager.settings.Replace("Settings.ini", "Settings_lowend.ini"));
        }

        private static void FillSettings(string content)
        {
            settings.Clear();
            foreach (string line in content.Split('\n'))
            {
                string name = line.Split('=')[0];
                if (string.IsNullOrEmpty(name))
                    return;

                string status = "";
                if (line.Split('=').Length > 1)
                    status = line.Split('=')[1].Replace(" ", "");
                settings.Add(name, status);
            }
        }

        private static string GetContent()
        {
            string content = "";
            foreach (var line in settings)
            {
                if (line.Value != "")
                    content += $"{line.Key}= {line.Value}\n";
                else
                {
                    content += $"{line.Key}\n";
                }
            }
            return content;
        }
    }
}
