using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundIdentifyer : MonoBehaviour
{
    void Start()
    {
        GameObject.FindGameObjectWithTag("BackgroundMusic").GetComponent<SoundController>().PlaySong();
    }
}
