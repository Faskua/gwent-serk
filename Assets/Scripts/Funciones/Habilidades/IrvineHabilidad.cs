using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IrvineHabilidad : MonoBehaviour
{
    public bool jugable;
    public ClaseFranja PlayerD;

    public void Efecto()
    {
        if(jugable)
        {
            PlayerD.Irvine();
        }
    }
    void Update()
    {
        PlayerD = GameObject.FindGameObjectWithTag("PlayerDistance").GetComponent<ClaseFranja>();
        jugable = gameObject.GetComponent<JugarCarta>().jugable;
    }
}
