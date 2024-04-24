using System;
using System.Text.RegularExpressions;

namespace Launcher_NFS_WPF_New.Model
{
    internal class UpdateModificationInfo
    {
        public static string Version { get; set; }
        public static double WeightByte { get; set; }

        public static void Set(string updateInfo)
        {
            Match match = Regex.Match(updateInfo, "Version: (.*?)\nWeight: (.*?)b");
            Version = match.Groups[1].ToString();
            WeightByte =Convert.ToDouble( match.Groups[2].ToString());
        }
    }
}
