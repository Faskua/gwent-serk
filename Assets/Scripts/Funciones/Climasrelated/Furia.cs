using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Furia : MonoBehaviour
{
    public ClaseFranja pCC;
    public ClaseFranja pD;
    public ClaseFranja pS;
    public ClaseFranja eCC;
    public ClaseFranja eD;
    public ClaseFranja eS;
    public bool jugable;

    public void Efecto()
    {
        if(jugable)
        {
            if(gameObject.GetComponent<ClaseCarta>().Frange == 4 && gameObject.GetComponent<ClaseCarta>().Faction == "Sacrificios")
            {
                pCC.Furia();
            }
            if(gameObject.GetComponent<ClaseCarta>().Frange == 5 && gameObject.GetComponent<ClaseCarta>().Faction == "Sacrificios")
            {
                pD.Furia();
            }
            if(gameObject.GetComponent<ClaseCarta>().Frange == 6 && gameObject.GetComponent<ClaseCarta>().Faction == "Sacrificios")
            {
                pS.Furia();
            }
            if(gameObject.GetComponent<ClaseCarta>().Frange == 4 && gameObject.GetComponent<ClaseCarta>().Faction == "Falconia")
            {
                eCC.Furia();
            }
            if(gameObject.GetComponent<ClaseCarta>().Frange == 5 && gameObject.GetComponent<ClaseCarta>().Faction == "Falconia")
            {
                eD.Furia();
            }
            if(gameObject.GetComponent<ClaseCarta>().Frange == 6 && gameObject.GetComponent<ClaseCarta>().Faction == "Falconia")
            {
                eS.Furia();
            }
        }
    }

    void Update()
    {
        jugable = gameObject.GetComponent<JugarCarta>().jugable;
       pCC = GameObject.FindGameObjectWithTag("PlayerMelee").GetComponent<ClaseFranja>(); 
       pD = GameObject.FindGameObjectWithTag("PlayerDistance").GetComponent<ClaseFranja>(); 
       pS = GameObject.FindGameObjectWithTag("PlayerSiege").GetComponent<ClaseFranja>(); 
       eCC = GameObject.FindGameObjectWithTag("EnemyMelee").GetComponent<ClaseFranja>(); 
       eD = GameObject.FindGameObjectWithTag("EnemyDistance").GetComponent<ClaseFranja>(); 
       eS = GameObject.FindGameObjectWithTag("EnemySiege").GetComponent<ClaseFranja>();  
    
    }
}
