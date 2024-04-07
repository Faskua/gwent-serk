using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DananHabilidad : MonoBehaviour
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
            int p1 = pCC.Danan();
            int p2 = pD.Danan();
            int p3 = pS.Danan();
            int p4 = eCC.Danan();
            int p5 = eD.Danan();
            int p6 = eS.Danan();
            int poder = (p1 + p2 + p3 + p4 + p5 + p6)/6;

            pCC.AplicarDanan(poder);
            pD.AplicarDanan(poder);
            pS.AplicarDanan(poder);
            eCC.AplicarDanan(poder);
            eD.AplicarDanan(poder);
            eS.AplicarDanan(poder);

            gameObject.GetComponent<ClaseCarta>().Power = poder;
        }
    }

    void Update()
    {
       pCC = GameObject.FindGameObjectWithTag("PlayerMelee").GetComponent<ClaseFranja>(); 
       pD = GameObject.FindGameObjectWithTag("PlayerDistance").GetComponent<ClaseFranja>(); 
       pS = GameObject.FindGameObjectWithTag("PlayerSiege").GetComponent<ClaseFranja>(); 
       eCC = GameObject.FindGameObjectWithTag("EnemyMelee").GetComponent<ClaseFranja>(); 
       eD = GameObject.FindGameObjectWithTag("EnemyDistance").GetComponent<ClaseFranja>(); 
       eS = GameObject.FindGameObjectWithTag("EnemySiege").GetComponent<ClaseFranja>(); 
       jugable = gameObject.GetComponent<JugarCarta>().jugable;
    }
}
