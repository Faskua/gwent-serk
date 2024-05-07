using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puck : MonoBehaviour
{
    public ClaseFranja pCC;
    public ClaseFranja pD;
    public ClaseFranja eCC;
    public ClaseFranja eD;
    public bool jugable;
    private bool selected = false;
    private bool Turn;

    public void Efecto()
    {
        if(jugable && selected) //llamando a los metodos de puck que tengo en cada franja
        {
            if(gameObject.GetComponent<ClaseCarta>().Faction == "Sacrificios" && gameObject.GetComponent<ClaseCarta>().Frange == 11 && Turn)
            {
                pCC.Puck();
            }
            if(gameObject.GetComponent<ClaseCarta>().Faction == "Sacrificios" && gameObject.GetComponent<ClaseCarta>().Frange == 12 && Turn)
            {
                pD.Puck();
            }
            if(gameObject.GetComponent<ClaseCarta>().Faction == "Falconia" && gameObject.GetComponent<ClaseCarta>().Frange == 13 && Turn == false)
            {
                eCC.Puck();
            }
            if(gameObject.GetComponent<ClaseCarta>().Faction == "Falconia" && gameObject.GetComponent<ClaseCarta>().Frange == 14 && Turn == false)
            {
                eD.Puck();
            }
        }
    }

    void Update()
    {
        Turn = GameObject.Find("TurnCounter").GetComponent<SetTurn>().Turno;
       selected = GameObject.Find("CartasGutts").GetComponent<GuttsCards>().GuttsSelected;
       jugable = gameObject.GetComponent<JugarCarta>().jugable;
       pCC = GameObject.FindGameObjectWithTag("PlayerMelee").GetComponent<ClaseFranja>(); 
       pD = GameObject.FindGameObjectWithTag("PlayerDistance").GetComponent<ClaseFranja>(); 
       eCC = GameObject.FindGameObjectWithTag("EnemyMelee").GetComponent<ClaseFranja>(); 
       eD = GameObject.FindGameObjectWithTag("EnemyDistance").GetComponent<ClaseFranja>(); 
    }
}
