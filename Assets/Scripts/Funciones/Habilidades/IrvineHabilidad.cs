using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IrvineHabilidad : MonoBehaviour
{
    public bool jugable;
    public ClaseFranja PlayerD;
    private bool selected = false;

    public void Efecto()
    {
        if(jugable && selected)
        {
            PlayerD.Irvine(); //lama al metodo de de irvine dentro de clase franja
        }
    }
    void Update()
    {
       selected = GameObject.Find("CartasGriffith").GetComponent<GriffCards>().GrifSelected;
        PlayerD = GameObject.FindGameObjectWithTag("PlayerDistance").GetComponent<ClaseFranja>();
        jugable = gameObject.GetComponent<JugarCarta>().jugable;
    }
}
