using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoddHabilidad : MonoBehaviour
{
    public bool jugable;
    public ClaseFranja CC;
    public ClaseFranja D;
    public ClaseFranja S;    


    public void Efecto()
    {
        if(jugable)
        {
            int cc = CC.CardsinFrange.Count;
            int d = D.CardsinFrange.Count;
            int s = S.CardsinFrange.Count;

            if(cc != 0 && cc < 4 && d != 0 && d < 4 && s != 0 && s < 4)
            {
                int menor = Mathf.Min(cc, Mathf.Min(d, s));
                D.Zodd(menor);
            } 
            else if(cc != 0 && cc < 4 && d != 0 && d < 4)
            {
                int menor = Mathf.Min(cc, d);
                CC.Zodd(menor);
            }
             else if(cc != 0 && cc < 4 && s != 0 && s < 4)
            {
                int menor = Mathf.Min(cc, s);
                S.Zodd(menor);
            }
             else if(s != 0 && s < 4 && d != 0 && d < 4)
            {
                int menor = Mathf.Min(s, d);
                D.Zodd(menor);
            }
             else if(cc != 0 && cc < 4)
            {
                int menor = cc;
                CC.Zodd(menor);
            }
             else if(d != 0 && d < 4)
            {
                int menor = d;
                D.Zodd(menor);
            }
             else if(s != 0 && s < 4)
            {
                int menor = s;
                S.Zodd(menor);
            }
        }
    }

    void Update()
    {
        jugable = gameObject.GetComponent<JugarCarta>().jugable;
        CC = GameObject.FindGameObjectWithTag("PlayerMelee").GetComponent<ClaseFranja>(); 
        D = GameObject.FindGameObjectWithTag("PlayerDistance").GetComponent<ClaseFranja>(); 
        S = GameObject.FindGameObjectWithTag("PlayerSiege").GetComponent<ClaseFranja>(); 
    }
}
