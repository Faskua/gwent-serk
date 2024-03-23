using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardZoom : MonoBehaviour
{
    public  GameObject Canvas;
    public GameObject ZoomCard;
    private GameObject EnemyHand;
    private GameObject Siege;
    private GameObject ClimaSiege;
    private GameObject zoomcard;
    private Sprite zoomSprite;

    void Awake()
    {
        Canvas = GameObject.Find("Main Canvas");
        EnemyHand = GameObject.Find("EnemyHand");
        Siege = GameObject.Find("EnemySiege");
        ClimaSiege = GameObject.Find("eSiegeClimage");
        zoomSprite = gameObject.GetComponent<Image>().sprite;
    }

    public void OnHoverEnter()
    {
        if(ZoomCard.transform.parent == EnemyHand.transform || ZoomCard.transform.parent == Siege.transform || ZoomCard.transform.parent == ClimaSiege.transform)
        {
            zoomcard = Instantiate(ZoomCard, new Vector2(Input.mousePosition.x, Input.mousePosition.y - 250),Quaternion.identity);
        zoomcard.GetComponent<Image>().sprite = zoomSprite;
        zoomcard.transform.SetParent(Canvas.transform, true);
        RectTransform rect = zoomcard.GetComponent<RectTransform>();
        rect.sizeDelta = new Vector2(180 , 260);  
        }
        else
        {
        zoomcard = Instantiate(ZoomCard, new Vector2(Input.mousePosition.x, Input.mousePosition.y + 200), Quaternion.identity);
        zoomcard.GetComponent<Image>().sprite = zoomSprite;
        zoomcard.transform.SetParent(Canvas.transform, true);
        RectTransform rect = zoomcard.GetComponent<RectTransform>();
        rect.sizeDelta = new Vector2(180, 260);
        }
    }

    public void OnHoverExit()
    {
         Destroy(zoomcard);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
