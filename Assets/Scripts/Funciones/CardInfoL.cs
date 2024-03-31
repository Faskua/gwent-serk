using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardInfoL : MonoBehaviour
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
        InfoText.text = Card.GetComponent<CartasdeLider>().Name + ". LÍDER DE FACCIÓN. DESCRIPCIÓN: " + Card.GetComponent<CartasdeLider>().DescriptionNskill + ". FACCIÓN: " + Card.GetComponent<CartasdeLider>().Faction;
        Information = Instantiate(InfoText, new Vector2(0,0), Quaternion.identity);
        Information.transform.SetParent(DescriptionText.transform, false);
    }


    public void MouseExit()
    {
       Destroy(Information);
    }
}
