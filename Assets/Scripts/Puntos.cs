using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Puntos : MonoBehaviour
{
    public Text guttsText; // el text que guarda los puntos totales de gutts

//recibo las 3 zonas de gutts
    public GameObject pCC;
    public GameObject pD;
    public GameObject pS;
   
    private int sumagutts = 0;

    void Update()
    {
        int semisuma = 0;
        semisuma = pCC.GetComponent<ClaseFranja>().Suma + pD.GetComponent<ClaseFranja>().Suma + pS.GetComponent<ClaseFranja>().Suma; //sumo la suma particular de cada franja
        sumagutts = semisuma;
        guttsText.text = sumagutts.ToString(); //la pongo en el texto
    }
}
