using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Launcher_NFS_WPF_New.Model
{
    internal class URLManager
    {
        public static readonly string URLCoderWorkerVK = "https://vk.com/coderworker";
        public static readonly string URLCoderWorkerTelegram = "https://t.me/CoderWorker";
        public static readonly string URLOneNFSModdingTelegram = "https://t.me/+HR-y-jkttdw2Mjhi";
        public static readonly string URLOneNFSModdingYouTube = "https://www.youtube.com/@i_am_adrenaline";

        public static void OpenURL(string URLSocial)
        {
            Process.Start(URLSocial);
        }
    }
}
