using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eclipse : MonoBehaviour
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
            if(gameObject.GetComponent<ClaseCarta>().Frange == 4)
            {
                pCC.Eclipse();
                eCC.Eclipse();
            }
            if(gameObject.GetComponent<ClaseCarta>().Frange == 5)
            {
                pD.Eclipse();
                eD.Eclipse();
            }
            if(gameObject.GetComponent<ClaseCarta>().Frange == 6)
            {
                pS.Eclipse();
                eS.Eclipse();
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
