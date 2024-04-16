using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IniciarPartida : MonoBehaviour
{
    public Animator Transition;

//son los mismos de abajo pero con retraso para dar tiempo a la animacion
    public void AnimComienzo()
    {
        Transition.SetTrigger("Start");
        Invoke("ComenzarJuego", 1);
    }

    public void AnimCredits()
    {
        Transition.SetTrigger("Start");
        Invoke("IraCréditos", 1);
    }

    public void AnimTuto1()
    {
        Transition.SetTrigger("Start");
        Invoke("Tutorial", 1);
    }
    public void AnimTuto2()
    {
        Transition.SetTrigger("Start");
        Invoke("Tutorial2", 2);
    }
    public void AnimTuto3()
    {
        Transition.SetTrigger("Start");
        Invoke("Tutorial3", 1);
    }
    public void AnimTuto4()
    {
        Transition.SetTrigger("Start");
        Invoke("Tutorial4", 1);
    }
    
    public void AnimTuto5()
    {
        Transition.SetTrigger("Start");
        Invoke("Tutorial5", 1);
    }
    public void AnimMenu()
    {
        Transition.SetTrigger("Start");
        Invoke("Menu", 1);
    }
    public void Exit()
    {
        Application.Quit();
    }


//estos metodos no los voy a explicar, son para cambiar de escena
    public void ComenzarJuego()
    {
        SceneManager.LoadScene(1);
    }

    public void IraCréditos()
    {
        SceneManager.LoadScene(2);
    }

    public void Tutorial()
    {
        SceneManager.LoadScene(3);
    }

    public void Tutorial2()
    {
        SceneManager.LoadScene(4);
    }

    public void Tutorial3()
    {
        SceneManager.LoadScene(5);
    }

    public void Tutorial4()
    {
        SceneManager.LoadScene(6);
    }

    public void Tutorial5()
    {
        SceneManager.LoadScene(7);
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
    }

    
}
