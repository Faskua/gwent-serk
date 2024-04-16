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

    public void Efecto()
    {
        if(jugable && selected) //llamando a los metodos de puck que tengo en cada franja
        {
            if(gameObject.GetComponent<ClaseCarta>().Faction == "Sacrificios" && gameObject.GetComponent<ClaseCarta>().Frange == 11)
            {
                pCC.Puck();
            }
            if(gameObject.GetComponent<ClaseCarta>().Faction == "Sacrificios" && gameObject.GetComponent<ClaseCarta>().Frange == 12)
            {
                pD.Puck();
            }
            if(gameObject.GetComponent<ClaseCarta>().Faction == "Falconia" && gameObject.GetComponent<ClaseCarta>().Frange == 13)
            {
                eCC.Puck();
            }
            if(gameObject.GetComponent<ClaseCarta>().Faction == "Falconia" && gameObject.GetComponent<ClaseCarta>().Frange == 14)
            {
                eD.Puck();
            }
        }
    }

    void Update()
    {
       selected = GameObject.Find("CartasGutts").GetComponent<GuttsCards>().GuttsSelected;
       jugable = gameObject.GetComponent<JugarCarta>().jugable;
       pCC = GameObject.FindGameObjectWithTag("PlayerMelee").GetComponent<ClaseFranja>(); 
       pD = GameObject.FindGameObjectWithTag("PlayerDistance").GetComponent<ClaseFranja>(); 
       eCC = GameObject.FindGameObjectWithTag("EnemyMelee").GetComponent<ClaseFranja>(); 
       eD = GameObject.FindGameObjectWithTag("EnemyDistance").GetComponent<ClaseFranja>(); 
    }
}
