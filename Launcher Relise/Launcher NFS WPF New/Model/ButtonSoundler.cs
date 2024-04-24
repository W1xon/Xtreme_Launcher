using System;
using System.Windows;
using System.Windows.Media;

namespace Launcher_NFS_WPF_New.Model
{
    public class ButtonSoundler
    {
        private MediaPlayer player;
        public ButtonSoundler(string path)
        {
            player = new MediaPlayer();
            player.Open(new Uri(path, UriKind.Relative));
            player.Volume = 0.1;
        }


        public void Play()
        {
            player.Stop();
            player.Play();
        }
    }
}
