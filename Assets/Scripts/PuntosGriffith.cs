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
        int semisuma = 0;
        semisuma = eCC.GetComponent<ClaseFranja>().Suma + eD.GetComponent<ClaseFranja>().Suma + eS.GetComponent<ClaseFranja>().Suma;
        sumagriffith = semisuma;
        griffithText.text = sumagriffith.ToString();  
    }
}
