using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoddHabilidad : MonoBehaviour
{
    public bool jugable;
    public ClaseFranja CC;
    public ClaseFranja D;
    public ClaseFranja S;
    private bool selected = false;  
    private bool Turn;  


    public void Efecto()
    {
        if(jugable && selected && Turn == false)
        {
            int cc = CC.CardsinFrange.Count;
            int d = D.CardsinFrange.Count;
            int s = S.CardsinFrange.Count;
            int menor = 0;

            //calculo el menor de los .count sin contar los 0
            if(cc != 0 && (d == 0 || cc <= d) && (s == 0 || cc <= s))
            {
                menor = cc;
            }
            else if(d != 0 && (cc == 0 || d <= cc) && (s == 0 || d <= s))
            {
                menor = d;
            }
            else
            {
                menor = s;
            }

            if(menor < 4 && menor != 0) //si es menor que 4 llamo al metodo de zodd en la franja
            {
                if(d == menor)
                {
                    D.Zodd(menor);
                    return;
                }
                if(cc == menor)
                {
                    CC.Zodd(menor);
                    return;
                }
                if(s == menor)
                {
                    S.Zodd(menor);
                    return;
                }
            }
        }
    }

    void Update()
    {
        Turn = GameObject.Find("TurnCounter").GetComponent<SetTurn>().Turno;
        selected = GameObject.Find("CartasGriffith").GetComponent<GriffCards>().GrifSelected;
        jugable = gameObject.GetComponent<JugarCarta>().jugable;
        CC = GameObject.FindGameObjectWithTag("PlayerMelee").GetComponent<ClaseFranja>(); 
        D = GameObject.FindGameObjectWithTag("PlayerDistance").GetComponent<ClaseFranja>(); 
        S = GameObject.FindGameObjectWithTag("PlayerSiege").GetComponent<ClaseFranja>(); 
    }
}
