using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EjercitosHabilidad : MonoBehaviour
{
    public ClaseFranja pS;//las franjas de asedio
    public ClaseFranja eS;
    public bool jugable;
    private int poder;
    private bool selected = false;
    private bool selectedgriff = false;
    private bool Turn;

    public void Efecto()
    {
        if(jugable)
        {
        if(gameObject.GetComponent<ClaseCarta>().Name == "Soldados de la banda del Halcón" && selected && Turn)
        {
            poder = pS.Ejercitos();
            pS.AplicarEjercitos();
        }
        if(gameObject.GetComponent<ClaseCarta>().Name == "Ejército Demoníaco" && selectedgriff && Turn == false)
        {
            poder = eS.Ejercitos();
            eS.AplicarEjercitos();
        }
        gameObject.GetComponent<ClaseCarta>().Power = gameObject.GetComponent<ClaseCarta>().OriginalPower * poder;
        }
    }

    void Update()
    {
        Turn = GameObject.Find("TurnCounter").GetComponent<SetTurn>().Turno;
       selected = GameObject.Find("CartasGutts").GetComponent<GuttsCards>().GuttsSelected;
       selectedgriff = GameObject.Find("CartasGriffith").GetComponent<GriffCards>().GrifSelected;
        jugable = gameObject.GetComponent<JugarCarta>().jugable;
        pS = GameObject.FindGameObjectWithTag("PlayerSiege").GetComponent<ClaseFranja>(); 
        eS = GameObject.FindGameObjectWithTag("EnemySiege").GetComponent<ClaseFranja>(); 
    }
}
