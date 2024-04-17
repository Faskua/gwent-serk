using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Judeau : MonoBehaviour
{
    public ClaseFranja PlayerCC;
    public ClaseFranja PlayerD;
    public ClaseFranja PlayerS;
    public ClaseFranja EnemyCC;
    public ClaseFranja EnemyD;
    public ClaseFranja EnemyS;
    public bool jugable; 
    private bool selected = false; 

     public void Efecto()
     {
        int pcc = PlayerCC.ObtenerMayor(); 
        int pd = PlayerD.ObtenerMayor();
        int ps = PlayerS.ObtenerMayor();
        int ecc = EnemyCC.ObtenerMayor(); //recibo la carta mas fuerte de cada franja
        int ed = EnemyD.ObtenerMayor();
        int es = EnemyS.ObtenerMayor();
        int mayor = Mathf.Max(pcc, Mathf.Max(pd, Mathf.Max(ps, Mathf.Max(ecc, Mathf.Max(ed, es))))); // la comparo

        if(ed == mayor) //y aplico el efecto en la franja
        {
            EnemyD.EliminarMayor(mayor);
            return;
        }
        if(pd == mayor)
        {
            PlayerD.EliminarMayor(mayor);
            return;
        }
        if(pcc == mayor)
        {
            PlayerCC.EliminarMayor(mayor);
            return;
        }
         if(ecc == mayor) 
        {
            EnemyCC.EliminarMayor(mayor);
            return;
        }
        if(es == mayor)
        {
            EnemyS.EliminarMayor(mayor);
            return;
        }
        if(ps == mayor)
        {
            PlayerS.EliminarMayor(mayor);
            return;
        }
     }


    void Update()
    {
        selected = GameObject.Find("CartasGutts").GetComponent<GuttsCards>().GuttsSelected;
        EnemyCC = GameObject.FindGameObjectWithTag("EnemyMelee").GetComponent<ClaseFranja>();
        EnemyD = GameObject.FindGameObjectWithTag("EnemyDistance").GetComponent<ClaseFranja>();
        EnemyS = GameObject.FindGameObjectWithTag("EnemySiege").GetComponent<ClaseFranja>();
        PlayerCC = GameObject.FindGameObjectWithTag("PlayerMelee").GetComponent<ClaseFranja>();
        PlayerD = GameObject.FindGameObjectWithTag("PlayerDistance").GetComponent<ClaseFranja>();
        PlayerS = GameObject.FindGameObjectWithTag("PlayerSiege").GetComponent<ClaseFranja>();
        jugable = gameObject.GetComponent<JugarCarta>().jugable;
    }
}
