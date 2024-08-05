using System;
using System.ComponentModel;
using System.Net;

namespace Launcher_NFS.Model
{
    internal class GameDownloader
    {
        private WebClient _clientLoadGame;
        private InfoLoad _infoLoad;

        public Action LoadStart;
        public Action<string, long> LoadProcess;
        public Action LoadCompleted;
        public GameDownloader()
        {
            _clientLoadGame = new WebClient();
            _clientLoadGame.DownloadFileCompleted += ClientLoadGame_DownloadFileCompleted;
            _clientLoadGame.DownloadProgressChanged += ClientLoadGame_DownloadProgressChanged;
        }
        public void LoadGame(Uri url)
        {
            if (!InternetProvider.IsConnected()) return;
            LoadStart.Invoke();
            _infoLoad = new InfoLoad(UpdateModificationInfo.Weight);
            _clientLoadGame.DownloadFileAsync(url, PathProvider.Config.Zip);
        }
        private void ClientLoadGame_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            _infoLoad.CurrentSize = e.BytesReceived;
            LoadProcess(_infoLoad.GetInfo(), _infoLoad.CurrentSize);
        }

        private void ClientLoadGame_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            FileProvider.InstallGame();
            LoadCompleted.Invoke();
        }
    }
}
