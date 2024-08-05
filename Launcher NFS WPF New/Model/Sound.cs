using System;
using System.Collections.Generic;
using System.Windows.Media;

namespace Launcher_NFS.Model
{
    public class Sound
    {
        private static Dictionary<string, MediaPlayer> _tracks = new Dictionary<string, MediaPlayer>();
        private static string _click = "View\\Res\\BtnClick.wav";
        private static string _clickStart = "View\\Res\\PlayGame.wav";
        private static string _clickPhub = "View\\Res\\PhubClick.wav";
        private static string _newYear = "View\\Res\\Easter Egg\\Music\\Christmas.mp3";

        public static void PlayClick() => Play(_click);
        public static void PlayStart() => Play(_clickStart);
        public static void PlayPhub() => Play(_clickPhub);
        public static void PlayNewYear() => Play(_newYear);
        private static void Play(string uri)
        {
            if (!_tracks.ContainsKey(uri))
            {
                AddTrack(uri);
            }
            Play(_tracks[uri]);
        }
        private static void AddTrack(string uri)
        {
            _tracks.Add(uri, CreateTrack(uri));
        }
        private static MediaPlayer CreateTrack(string uri)
        {
            MediaPlayer player = new MediaPlayer();
            player.Open(new Uri(uri, UriKind.Relative));
            player.Volume = 0.1;
            return player;
        }
        private static void Play(MediaPlayer player)
        {
            player.Stop();
            player.Play();
        }
    }
}
