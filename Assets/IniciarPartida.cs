using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IniciarPartida : MonoBehaviour
{
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

    public void Menu()
    {
        SceneManager.LoadScene(0);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
