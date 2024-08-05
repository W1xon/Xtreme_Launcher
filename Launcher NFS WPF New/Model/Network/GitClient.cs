using Octokit;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Launcher_NFS.Model
{
    public static  class GitClient
    {
        private static GitHubClient gitHubClient = new GitHubClient(new ProductHeaderValue("NFS"));
        private static Credentials credentials = new Credentials(token: "//Здесь мой токен, его я вам не покажу :)");
        public  static List<UpdateFileInfo> updateFiles = new List<UpdateFileInfo>();
        
        public static async Task InitializeUpdateFiles()
        {
            gitHubClient.Credentials = credentials;
            var lastCommit = await gitHubClient.Repository.Commit.Get("W1xon", "testtest", UpdateModificationInfo.Sha);
            // Получаем список файлов, которые были изменены в последнем коммите
            var filesChanged = lastCommit.Files;
            foreach (var file in filesChanged)
            {
                updateFiles.Add(new UpdateFileInfo(file));
            }
        }
        public static void RemoveUpdateFiles()
        {
            if (updateFiles.Count < 1) return;
            updateFiles.RemoveAt(0);
        }
    }
}

