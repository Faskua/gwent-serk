using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuntosGriffith : MonoBehaviour
{
    public Text griffithText; 
    public GameObject eCC;
    public GameObject eD;
    public GameObject eS;

    private int sumagriffith = 0;
    
    void Update()
    {
        if (sumagriffith != eCC.GetComponent<ClaseFranja>().Suma + eD.GetComponent<ClaseFranja>().Suma + eS.GetComponent<ClaseFranja>().Suma)
        {
            sumagriffith = eCC.GetComponent<ClaseFranja>().Suma + eD.GetComponent<ClaseFranja>().Suma + eS.GetComponent<ClaseFranja>().Suma;
            griffithText.text = sumagriffith.ToString();  
        }
    }
}
