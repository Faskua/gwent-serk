using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EjercitosHabilidad : MonoBehaviour
{
    public ClaseFranja pS;
    public ClaseFranja eS;
    public bool jugable;

    public void Efecto()
    {
        if(jugable)
        {
        if(gameObject.GetComponent<ClaseCarta>().Name == "Soldados de la banda del Halcón")
        {
            pS.Ejercitos();
        }
        if(gameObject.GetComponent<ClaseCarta>().Name == "Ejército Demoníaco")
        {
            eS.Ejercitos();
        }
        }
    }

    void Update()
    {
        jugable = gameObject.GetComponent<JugarCarta>().jugable;
        pS = GameObject.FindGameObjectWithTag("PlayerSiege").GetComponent<ClaseFranja>(); 
        eS = GameObject.FindGameObjectWithTag("EnemySiege").GetComponent<ClaseFranja>(); 
    }
}
