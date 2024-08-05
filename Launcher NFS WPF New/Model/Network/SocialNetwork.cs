using System.Diagnostics;

namespace Launcher_NFS.Model.Network
{
    internal class SocialNetwork
    {
        public static readonly string UrlCoderWorkerVK = "https://vk.com/coderworker";
        public static readonly string UrlCoderWorkerTelegram = "https://t.me/CoderWorker";
        public static readonly string UrlOneNFSModdingTelegram = "https://t.me/+HR-y-jkttdw2Mjhi";
        public static readonly string UrlOneNFSModdingYouTube = "https://www.youtube.com/@i_am_adrenaline";
        public static readonly string UrlEasterAnn = "https://t.me/moiTrehglazki";
        public static void Open(string UrlSocial) => Process.Start(UrlSocial);
    }
}
