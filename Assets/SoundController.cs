using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundController : MonoBehaviour
{
   private static AudioSource music;

   void Awake() 
   {
        if(music != null) 
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
            music = GetComponent<AudioSource>();
        }
   }

   public void PlaySong()
   {
        if(music.isPlaying)
        {return;}
        music.Play();
   }

   public void StopSong()
   {
        music.Stop();
   }
}
