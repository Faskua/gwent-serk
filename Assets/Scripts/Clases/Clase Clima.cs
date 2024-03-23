using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClaseClima : MonoBehaviour
{
    public string Name;
    public string Description;
    public GameObject Card;
    public GameObject Info;
   /* public GameObject DescriptionText;


    void Awake()
    {
        DescriptionText = GameObject.Find("DescriptionText");
    }
    
    public void MouseEnter()
    {
        Info.GetComponent<TextMeshPro>().text = Card.GetComponent<Clase_Clima>().Name + ". " + Card.GetComponent<Clase_Clima>().Description;
        GameObject CardInfo = Instantiate(Info);
        CardInfo.transform.position = DescriptionText.transform.position;
        CardInfo.transform.SetParent(DescriptionText.transform, false);
    }
/*

    public void MouseExit()
    {
        Destroy(CardInfo);
    }

*/
}
