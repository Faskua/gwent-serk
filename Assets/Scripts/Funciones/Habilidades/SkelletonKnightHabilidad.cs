using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkelletonKnightHabilidad : MonoBehaviour
{
   public ClaseFranja EnemyCC;
   public bool jugable; 

    public void Efecto()
    {
        if(jugable)
        {
            EnemyCC.SkelletonKnight();
        }
    }
    
    void Update()
    {
        EnemyCC = GameObject.FindGameObjectWithTag("EnemyMelee").GetComponent<ClaseFranja>();
        jugable = gameObject.GetComponent<JugarCarta>().jugable;
    }
}
