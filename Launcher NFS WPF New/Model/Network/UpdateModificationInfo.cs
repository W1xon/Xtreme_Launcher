using System;
using System.Text.RegularExpressions;

namespace Launcher_NFS.Model
{
    internal class UpdateModificationInfo
    {
        public static string Version { get; set; }
        public static long WeightUpdateByte { get; set; }
        public static long Weight { get; set; }
        public static string Sha { get; set; }

        public static bool IsLoad { get; set; }
        public static void Save(string updateInfo)
        {
            Match match = Regex.Match(updateInfo, "Version: (.*?)\nWeight: (.*?)\nWeightUpdate: (.*?)\nSha: (.*?)!");
            Version = match.Groups[1].ToString();
            Weight = Convert.ToInt64(match.Groups[2].ToString());
            WeightUpdateByte = Convert.ToInt64(match.Groups[3].ToString());
            Sha = match.Groups[4].ToString();
        }
    }
}
