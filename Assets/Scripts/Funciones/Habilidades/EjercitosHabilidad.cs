using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EjercitosHabilidad : MonoBehaviour
{
    public ClaseFranja pS;
    public ClaseFranja eS;
    public bool jugable;
    private int poder;

    public void Efecto()
    {
        if(jugable)
        {
        if(gameObject.GetComponent<ClaseCarta>().Name == "Soldados de la banda del Halcón")
        {
            poder = pS.Ejercitos();
            pS.AplicarEjercitos();
        }
        if(gameObject.GetComponent<ClaseCarta>().Name == "Ejército Demoníaco")
        {
            poder = eS.Ejercitos();
            eS.AplicarEjercitos();
        }
        gameObject.GetComponent<ClaseCarta>().Power = gameObject.GetComponent<ClaseCarta>().OriginalPower * poder;
        }
    }

    void Update()
    {
        jugable = gameObject.GetComponent<JugarCarta>().jugable;
        pS = GameObject.FindGameObjectWithTag("PlayerSiege").GetComponent<ClaseFranja>(); 
        eS = GameObject.FindGameObjectWithTag("EnemySiege").GetComponent<ClaseFranja>(); 
    }
}
