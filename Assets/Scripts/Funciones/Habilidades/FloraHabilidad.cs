using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloraHabilidad : MonoBehaviour
{
    public ClaseFranja Siege;
    public bool jugable;

    public void Efecto()
    {
        if(jugable)
        {
            Siege.Flora();
            gameObject.GetComponent<ClaseCarta>().Power += 1;
        }
    }

    void Update()
    {
        Siege = GameObject.FindGameObjectWithTag("PlayerSiege").GetComponent<ClaseFranja>();
        jugable = gameObject.GetComponent<JugarCarta>().jugable;
    }
}
