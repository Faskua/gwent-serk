using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardInfo : MonoBehaviour
{

    public GameObject Card;
    public GameObject Info;
    public GameObject DescriptionText;


    void Awake()
    {
        DescriptionText = GameObject.Find("DescriptionText");
    }
    
    public void MouseEnter()
    {
        // Info.GetComponent<TextMeshPro>.Text Input = Card.GetComponent<Clase Clima>.Name + ". " + Card.GetComponent<Clase Clima>.Descrption;
        // GameObject Description = Instantiate(Info);
        // Description.transform.position = DescriptionText.transform.position;
        // Description.transform.SetParent(DescriptionText.transform, false);
    }


    public void MouseExit()
    {
       // Destroy(Description);
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
