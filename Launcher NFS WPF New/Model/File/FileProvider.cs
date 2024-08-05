using Launcher_NFS.View;
using System.IO;
using System.IO.Compression;
using System.Threading.Tasks;
namespace Launcher_NFS.Model
{
    internal class FileProvider
    {
        public static string ReadFile(string path)
        {
            string content = "";
            if (!File.Exists(path))
            {
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

        public static bool HasFileConfig()
        {
            if (File.Exists(PathProvider.Config.BubenUltra))
                return true;
            return false;
        }
        public static async void InstallGame()
        {
            await UnZip();
            await Task.Run(async () =>
            {
                while (true)
                {
                    await Task.Delay(100);
                    try
                    {
                        Directory.Move(PathProvider.Config.LoadFolder, PathProvider.Config.Folder);
                        return;
                    }
                    catch (System.Exception)
                    {
                        //ждем пока освободится дирректория
                    }
                }
            });
            File.Delete(PathProvider.Config.Zip);
            MessageWindow.Show("Игра скачена", "urraa", true);
        }
        private static async Task UnZip()
        {
            await Task.Run(() =>
             {
                 ZipFile.ExtractToDirectory(PathProvider.Config.Zip, PathProvider.Config.Directory);

             });
        }
    }
}
