using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardZoom : MonoBehaviour
{
    public  GameObject Griffith;
    public GameObject ZoomCard;
    private GameObject zoomcard;
    private Sprite zoomSprite;

    void Awake()
    {
        Griffith = GameObject.Find("Rendirse");
        zoomSprite = gameObject.GetComponent<Image>().sprite;
    }

    public void OnHoverEnter()
    {
        zoomcard = Instantiate(ZoomCard, new Vector2(0,0), Quaternion.identity);
        zoomcard.GetComponent<Image>().sprite = zoomSprite;
        zoomcard.transform.SetParent(Griffith.transform, true);
        RectTransform rect = zoomcard.GetComponent<RectTransform>();
        rect.sizeDelta = new Vector2(210, 300);
        zoomcard.transform.position = Griffith.transform.position;
    }

    public void OnHoverExit()
    {
         Destroy(zoomcard);
    }
}
