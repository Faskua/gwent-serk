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
    private bool selected = false;
    private bool grifselected = false;
    private bool Turn;

    public void Efecto()
    {
        if(jugable && selected && grifselected)
        {
            if(gameObject.GetComponent<ClaseCarta>().Frange == 4 && gameObject.GetComponent<ClaseCarta>().Faction == "Sacrificios" && Turn)//se aplica el metodod de furia en cada franja particular
            {
                pCC.Furia();
            }
            if(gameObject.GetComponent<ClaseCarta>().Frange == 5 && gameObject.GetComponent<ClaseCarta>().Faction == "Sacrificios" && Turn)
            {
                pD.Furia();
            }
            if(gameObject.GetComponent<ClaseCarta>().Frange == 6 && gameObject.GetComponent<ClaseCarta>().Faction == "Sacrificios" && Turn)
            {
                pS.Furia();
            }
            if(gameObject.GetComponent<ClaseCarta>().Frange == 4 && gameObject.GetComponent<ClaseCarta>().Faction == "Falconia" && Turn == false)
            {
                eCC.Furia();
            }
            if(gameObject.GetComponent<ClaseCarta>().Frange == 5 && gameObject.GetComponent<ClaseCarta>().Faction == "Falconia" && Turn == false)
            {
                eD.Furia();
            }
            if(gameObject.GetComponent<ClaseCarta>().Frange == 6 && gameObject.GetComponent<ClaseCarta>().Faction == "Falconia" && Turn == false)
            {
                eS.Furia();
            }
        }
    }

    void Update()
    {
        Turn = GameObject.Find("TurnCounter").GetComponent<SetTurn>().Turno;
       grifselected = GameObject.Find("CartasGriffith").GetComponent<GriffCards>().GrifSelected;
       selected = GameObject.Find("CartasGutts").GetComponent<GuttsCards>().GuttsSelected;
       jugable = gameObject.GetComponent<JugarCarta>().jugable;
       pCC = GameObject.FindGameObjectWithTag("PlayerMelee").GetComponent<ClaseFranja>(); 
       pD = GameObject.FindGameObjectWithTag("PlayerDistance").GetComponent<ClaseFranja>(); 
       pS = GameObject.FindGameObjectWithTag("PlayerSiege").GetComponent<ClaseFranja>(); 
       eCC = GameObject.FindGameObjectWithTag("EnemyMelee").GetComponent<ClaseFranja>(); 
       eD = GameObject.FindGameObjectWithTag("EnemyDistance").GetComponent<ClaseFranja>(); 
       eS = GameObject.FindGameObjectWithTag("EnemySiege").GetComponent<ClaseFranja>();  
    
    }
}
