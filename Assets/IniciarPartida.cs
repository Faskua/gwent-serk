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

    public void Menu()
    {
        SceneManager.LoadScene(0);
    }
}
