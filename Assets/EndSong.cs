using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndSong : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject.FindGameObjectWithTag("BackgroundMusic").GetComponent<SoundController>().StopSong();
    }
}
