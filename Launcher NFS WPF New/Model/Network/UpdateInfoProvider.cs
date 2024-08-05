using Launcher_NFS.View;
using System.Threading.Tasks;
using System;
using System.Net;
using System.IO;
namespace Launcher_NFS.Model
{
    internal class UpdateInfoProvider
    {
        public Action<bool> ShowingUpdate;
        public async Task ShowUpdate(Uri uri)
        {
            if (!InternetProvider.IsConnected()) return;

            string filePath = $"{PathProvider.Config.UpdateFileInfo}";
            await Task.Run(() =>
            {
                using (WebClient client = new WebClient())
                {
                    client.DownloadFileCompleted += (s, e) =>
                    {
                        UpdateModificationInfo.Save(FileProvider.ReadFile(filePath));
                        UpdateRegister();
                        File.Delete(filePath);
                    };
                    client.DownloadFileAsync(uri, filePath);
                }
            });

        }
        private void UpdateRegister()
        {
            if (Properties.Settings.Default.version != UpdateModificationInfo.Version)
            {
                ShowingUpdate.Invoke(true);
            }
            else
                ShowingUpdate.Invoke(false);
        }
        public async Task LoadGameInfo(Uri uri)
        {
            if (!InternetProvider.IsConnected()) return;
            string filePath = PathProvider.Config.UpdateFileInfo;
            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>();

            using (WebClient client = new WebClient())
            {
                client.DownloadFileCompleted += (s, e) =>
                {
                    UpdateModificationInfo.Save(FileProvider.ReadFile(filePath));
                    File.Delete(filePath);
                    tcs.SetResult(true);
                };
                client.DownloadFileAsync(uri, filePath);
            }
            await tcs.Task;
        }
    }
}
