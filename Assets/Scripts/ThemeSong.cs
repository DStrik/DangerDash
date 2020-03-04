using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace AGDDPlatformer
{
    public class ThemeSong : MonoBehaviour
    {
        public static ThemeSong instance;
        public AudioClip[] clips;
        public AudioSource source;

        void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(gameObject);
            }

            DontDestroyOnLoad(gameObject);
        }

        // Start is called before the first frame update
        void Start()
        {
            PlayStartThemSong();
        }

        public void PlayStartThemSong()
        {
            source.Stop();
            source.clip = clips[0];
            source.loop = true;
            source.Play();
        }

        public void PlayFinalThemeSong()
        {
            source.Stop();
            source.clip = clips[1];
            source.loop = true;
            source.Play();
        }
    }
}