using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;
using MelonLoader;
using System.Collections;

namespace CGUtils
{
    public class CGMusic : MonoBehaviour
    {
        public AudioSource audiosource;

        public List<AudioClip> music = MusicImport.music;
        private AudioClip lastClip;

        AudioClip RandomClip()
        {
            {
                int attempts = 3;
                AudioClip newClip = music[UnityEngine.Random.Range(0, music.Count)];

                while (newClip == lastClip && attempts > 0)
                {
                    newClip = music[UnityEngine.Random.Range(0, music.Count)];
                    attempts--;
                }

                lastClip = newClip;
                return newClip;
            }
        }

        void Start()
        {
            audiosource.PlayOneShot(RandomClip());
            MelonCoroutines.Start(musiccheckloop());
        }

        void Update()
        {
            audiosource.volume = CGUtils.volslider.normalizedValue;
            
        }

        IEnumerator musiccheckloop()
        {
            if (!audiosource.isPlaying)
            {
                audiosource.PlayOneShot(RandomClip());
                yield return new WaitForSeconds(0.5f);
                MelonCoroutines.Start(musiccheckloop());

            }
            else
            {
                yield return new WaitForSeconds(0.5f);
                MelonCoroutines.Start(musiccheckloop());
            }
        }
    }
}
