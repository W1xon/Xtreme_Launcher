using System.Threading.Tasks;
using System.Threading;
using System.ComponentModel;
using System.Net;
using System;

namespace Launcher_NFS.Model
{
    internal class UpdateDownloader
    {
        private SemaphoreSlim _semaphore = new SemaphoreSlim(1, 1);
        public WebClient _clientLoadUpdate = new WebClient();
        private InfoLoad _infoLoad;

        public Action LoadStart;
        public Action<string, string, long> UpdateProcess;
        public Action LoadCompleted;
        public UpdateDownloader()
        {
            _clientLoadUpdate.DownloadFileCompleted += ClientLoadUpdate_DownloadFileCompleted;
            _clientLoadUpdate.DownloadProgressChanged += ClientLoadUpdate_DownloadProgressChanged;
        }
        public async Task LoadUpdate()
        {
            if (!InternetProvider.IsConnected()) return;
            await GitClient.InitializeUpdateFiles();
            _infoLoad = new InfoLoad(UpdateModificationInfo.WeightUpdateByte, GitClient.updateFiles.Count);
            LoadStart.Invoke();
            foreach (var file in GitClient.updateFiles)
            {
                await _semaphore.WaitAsync();
                PathProvider.CreateFolder($@"{PathProvider.Config.Folder}\{file.Path}");
                _infoLoad.FileName = file.Name;
                _clientLoadUpdate.DownloadFileAsync(file.Url, $@"{PathProvider.Config.Folder}\{file.Path}\{file.Name}");
            }
        }
        private void ClientLoadUpdate_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            _infoLoad.CurrentSize = e.BytesReceived;
            UpdateProcess.Invoke(_infoLoad.GetUpdateInfo(), _infoLoad.FileName, _infoLoad.Size + _infoLoad.CurrentSize);
        }
        private void ClientLoadUpdate_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            _infoLoad.Size += _infoLoad.CurrentSize;
            _infoLoad.LoadFileCount++;
            if (_infoLoad.LoadFileCount == _infoLoad.FileCount)
            {
                LoadCompleted.Invoke();
            }
            _semaphore.Release();
        }
    }
}
