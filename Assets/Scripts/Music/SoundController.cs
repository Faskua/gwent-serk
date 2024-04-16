using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundController : MonoBehaviour
{
   private static AudioSource music; //el audiosource del objeto que tengo en la escena de menu

   void Awake() 
   {
        if(music != null) //si ya existe el objeto en la escena se destruye
        {
            Destroy(gameObject);
        }
        else //de lo contrario digo que no se destruya y que el music es el audiosource de ese objeto
        {
            DontDestroyOnLoad(this.gameObject); 
            music = GetComponent<AudioSource>();
        }
   }

   public void PlaySong()
   {
        if(music.isPlaying) //si ya se esta reproduciendo no hace nada
        {return;}
        music.Play(); //se reproduce la cancion en bucle
   }

   public void StopSong()
   {
        music.Stop(); 
   }
}
