using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CardInfo : MonoBehaviour
{
    public GameObject Card; 
    public Text InfoText; //el prefab de un objeto de texto
    private GameObject DescriptionText; //la zona en la que aparece el texto
    private Text Information;// el texto instanciado
    private bool Turn;

    void Start()
    {
        DescriptionText = GameObject.Find("DescriptionText");
    }
    
    public void MouseEnter()
    {//asigno al prefab el todo lo que quiero que salga en el texto
        if((Turn && gameObject.GetComponent<ClaseCarta>().Faction == "Sacrificios") || gameObject.GetComponent<JugarCarta>().jugable == false)
        {
            InfoText.text = Card.GetComponent<ClaseCarta>().Name + ". PODER: " + Card.GetComponent<ClaseCarta>().Power.ToString() + ". DESCRIPCIÓN: " + Card.GetComponent<ClaseCarta>().DescriptionNskill + ". FACCIÓN: " + Card.GetComponent<ClaseCarta>().Faction + ". FRANJA: " + Card.GetComponent<ClaseCarta>().Franja + ". TIPO: " + Card.GetComponent<ClaseCarta>().Type;
            Information = Instantiate(InfoText, new Vector2(0,0), Quaternion.identity); //creo el objeto y lo pongo en la zona correspondiente
            Information.transform.SetParent(DescriptionText.transform, false);
            return;
        }
        if((Turn == false && gameObject.GetComponent<ClaseCarta>().Faction == "Falconia") || gameObject.GetComponent<JugarCarta>().jugable == false)
        {
            InfoText.text = Card.GetComponent<ClaseCarta>().Name + ". PODER: " + Card.GetComponent<ClaseCarta>().Power.ToString() + ". DESCRIPCIÓN: " + Card.GetComponent<ClaseCarta>().DescriptionNskill + ". FACCIÓN: " + Card.GetComponent<ClaseCarta>().Faction + ". FRANJA: " + Card.GetComponent<ClaseCarta>().Franja + ". TIPO: " + Card.GetComponent<ClaseCarta>().Type;
            Information = Instantiate(InfoText, new Vector2(0,0), Quaternion.identity); //creo el objeto y lo pongo en la zona correspondiente
            Information.transform.SetParent(DescriptionText.transform, false);
            return;
        }
    }


    public void MouseExit()
    {
        if(Information != null)
        {
            Destroy(Information.gameObject);
        }
    }
    void Update()
    {
        Turn = GameObject.Find("TurnCounter").GetComponent<SetTurn>().Turno;
    }
}
