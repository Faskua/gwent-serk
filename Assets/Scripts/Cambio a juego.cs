using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cambioajuego : MonoBehaviour
{
    public Animator Transition;

    public void ComenzarJuego()
    {
        Transition.SetTrigger("Start");
        SceneManager.LoadScene(1);
    }
    void Start()
    {
        Invoke("ComenzarJuego", 8);
    }
}
