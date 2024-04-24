using Launcher_NFS_WPF_New.Properties;
using System;
using System.IO;
using System.Windows.Controls;
using System.Net;
using System.Windows;
using System.Net.NetworkInformation;
using static Launcher_NFS_WPF_New.View.UpdatePage;

namespace Launcher_NFS_WPF_New.Model
{
    public static class GitClient
    {
        public static WebClient client;
        delegate void CancelLoad();
        public static void UpdateLoad(Uri uri, string name, ProgressBar load, TextBlock text, Update_Handler hiddenBtn)
        {
            
            using (client = new WebClient())
            {
                client.OpenRead(uri);
                load.Maximum = UpdateModificationInfo.WeightByte;
                client.DownloadFileCompleted += (s, e) =>
                {
                    hiddenBtn.Invoke(); 
                    if (e.Cancelled)
                    {
                        client.Dispose();
                        return;
                    }
                };
                client.DownloadProgressChanged += (s, e) =>
                {
                    load.Value = e.BytesReceived;
                    text.Text = $"Загружено: {Math.Round((e.BytesReceived / load.Maximum), 2) * 100}% {(e.BytesReceived / 1048576d).ToString("0.00")} Mb";
                };
                client.DownloadFileAsync(uri, $@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\{name}");
            }
        }
        public static bool CheckInternetConnection()
        {
            try
            {
                Ping myPing = new Ping();
                string host = "google.com";
                byte[] buffer = new byte[32];
                int timeout = 1000;
                PingOptions pingOptions = new PingOptions();
                PingReply reply = myPing.Send(host, timeout, buffer, pingOptions);
                return (reply.Status == IPStatus.Success);
            }
            catch (Exception)
            {
                return false;
            }
        }
        
        public static void ShowUpdate(Uri uri, TextBlock text, Update_Handler visibleBtn)
        {
            if (CheckInternetConnection())
                MessageBox.Show("asdfsadf", "error");
            string filePath = $@"{Environment.CurrentDirectory}\UpdateInfo.txt";
            using (client = new WebClient())
            {
                client.DownloadFileCompleted += (s, e) =>
                {
                    UpdateModificationInfo.Set(FileManager.ReadFile(filePath));
                    if (Settings.Default.version != UpdateModificationInfo.Version)
                    {
                        text.Text = $"Есть обновления. Версия: {UpdateModificationInfo.Version}";
                        visibleBtn.Invoke();
                    }
                    else
                        text.Text = "Обновлений нет";
                    File.Delete(filePath);
                };
                client.DownloadFileAsync(uri, filePath);
            }
        }
    }
}
