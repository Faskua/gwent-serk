using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardInfo : MonoBehaviour
{
    public GameObject Card;
    public Text InfoText;
    private GameObject DescriptionText;
    private Text Information;

    void Start()
    {
        DescriptionText = GameObject.Find("DescriptionText");
    }
    
    public void MouseEnter()
    {
        InfoText.text = Card.GetComponent<ClaseCarta>().Name + ". PODER: " + Card.GetComponent<ClaseCarta>().Power.ToString() + ". DESCRIPCIÓN: " + Card.GetComponent<ClaseCarta>().DescriptionNskill + ". FACCIÓN: " + Card.GetComponent<ClaseCarta>().Faction + ". FRANJA: " + Card.GetComponent<ClaseCarta>().Franja + ". TIPO: " + Card.GetComponent<ClaseCarta>().Type;
        Information = Instantiate(InfoText, new Vector2(0,0), Quaternion.identity);
        Information.transform.SetParent(DescriptionText.transform, false);
    }


    public void MouseExit()
    {
       Destroy(Information);
    }
}
