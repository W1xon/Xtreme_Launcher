using Launcher_NFS.View;
using System;
using System.Net.NetworkInformation;

namespace Launcher_NFS.Model
{
    internal static class InternetProvider
    {
        public static bool IsConnected()
        {
            if (!HasConnection())
            {
                MessageWindow.Show(Properties.Langs.Lang.networkErrorTitle, Properties.Langs.Lang.networkErrorMessage);
                return false;
            }
            return true;
        }
        public static bool HasConnection()
        {
            try
            {
                Ping myPing = new Ping();
                string host = "google.com";
                byte[] buffer = new byte[32];
                int timeout = 100;
                PingOptions pingOptions = new PingOptions();
                PingReply reply = myPing.Send(host, timeout, buffer, pingOptions);
                return (reply.Status == IPStatus.Success);
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
