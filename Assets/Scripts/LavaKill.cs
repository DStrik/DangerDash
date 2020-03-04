using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AGDDPlatformer
{
    public class LavaKill : MonoBehaviour
    {
        public GameObject playerBase;
        private PlayerController player;

        [Header("Audio")]
        public AudioSource source;
        public AudioClip deathSound;

        void Awake()
        {
            Transform parent = playerBase.transform;
            for (int i = 0; i < parent.childCount; i++)
            {
                if(parent.GetChild(i).tag == "Player1")
                {
                    player = parent.GetChild(i).gameObject.GetComponent<PlayerController>();
                }
            }
        }
        
        void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.tag == "Player1")
            {
                source.PlayOneShot(deathSound);
                player.ResetPlayer();
            }
        }
    }
}
