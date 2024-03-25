using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Puntos : MonoBehaviour
{
    public Text guttsText;

    public GameObject pCC;
    public GameObject pD;
    public GameObject pS;
   
    private int sumagutts = 0;

    void Update()
    {
        if(sumagutts != pCC.GetComponent<ClaseFranja>().Suma + pD.GetComponent<ClaseFranja>().Suma + pS.GetComponent<ClaseFranja>().Suma)
        {
            sumagutts = pCC.GetComponent<ClaseFranja>().Suma + pD.GetComponent<ClaseFranja>().Suma + pS.GetComponent<ClaseFranja>().Suma;
            guttsText.text = sumagutts.ToString();
        }    
    }
}
