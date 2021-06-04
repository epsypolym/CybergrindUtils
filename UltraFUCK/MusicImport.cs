using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using MelonLoader;
using System.IO;

namespace CGUtils
{
    public class MusicImport : MonoBehaviour
    {
        public AudioSource audiosource;
        public static string musicdir;
        public static string[] dirtylist;
        public static List<string> cleanlist = new List<string>();
        public static bool LoadCustomMusic;

        public static List<AudioClip> music = new List<AudioClip>();
        readonly static string[] supportedFileExtensions =
        {
            ".mp3",
            ".ogg",
            ".wav",
            ".aiff",
            ".mod",
            ".it",
            ".s3m",
            ".xm",
        };

        public static void init()
        {
            musicdir = CGUtils.musicdir;
            dirtylist = Directory.GetFiles(musicdir);
            CleanList();
            GetMusic();
            if(music.Count >= 1) { LoadCustomMusic = true; }
        }

        public static void CleanList()
        {
            foreach (string song in dirtylist)
            {
                foreach (string v in supportedFileExtensions)
                {
                    if (song.EndsWith(v))
                    {
                        cleanlist.Add(song);
                    }
                }

            }
        }

        public static void GetMusic()
        {
            foreach (string song in cleanlist)
            {
                var w3 = new WWW("file:///" + song); //import via shit WWW library
                while (!w3.isDone) { } //wait for library to load the file
                music.Add(w3.GetAudioClip());
            }

        }

    }
}
