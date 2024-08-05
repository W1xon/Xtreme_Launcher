using Octokit;
using System;
using System.Linq;

namespace Launcher_NFS.Model
{
    public struct UpdateFileInfo
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public Uri Url { get; set; }
        public UpdateFileInfo(GitHubCommitFile file)
        {
            Url = new Uri(file.RawUrl);
            string[] paths = file.Filename.Split('/');
            Path = string.Join("\\", paths.Take(paths.Length - 1).ToArray());
            Name = file.Filename.Split('/').Last();
        }
    }
}
