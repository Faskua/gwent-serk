using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardZoom : MonoBehaviour
{
    public  GameObject Griffith; //la zona donde pondre la carta zoomeada
    public GameObject ZoomCard; //el prefab dela carta zoomeada
    private GameObject zoomcard; //la carta zoomeada
    private Sprite zoomSprite; //la foto
    private bool Turn;

    void Awake()
    {
        Griffith = GameObject.Find("Rendirse");
        zoomSprite = gameObject.GetComponent<Image>().sprite;
    }

    public void OnHoverEnter()
    {
        if((Turn && gameObject.GetComponent<ClaseCarta>().Faction == "Sacrificios") || gameObject.GetComponent<JugarCarta>().jugable == false)
        {
            zoomcard = Instantiate(ZoomCard, new Vector2(0,0), Quaternion.identity);
            zoomcard.GetComponent<Image>().sprite = zoomSprite;
            zoomcard.transform.SetParent(Griffith.transform, false);//creo la carta y la muevo hasta el boton de rendirse
            zoomcard.transform.position = Griffith.transform.position;
            RectTransform rect = zoomcard.GetComponent<RectTransform>();
            rect.sizeDelta = new Vector2(350, 480); //la vuelvo grande
            return;
        }
        if((Turn == false && gameObject.GetComponent<ClaseCarta>().Faction == "Falconia") || gameObject.GetComponent<JugarCarta>().jugable == false)
        {
            zoomcard = Instantiate(ZoomCard, new Vector2(0,0), Quaternion.identity);
            zoomcard.GetComponent<Image>().sprite = zoomSprite;
            zoomcard.transform.SetParent(Griffith.transform, false);//creo la carta y la muevo hasta el boton de rendirse
            zoomcard.transform.position = Griffith.transform.position;
            RectTransform rect = zoomcard.GetComponent<RectTransform>();
            rect.sizeDelta = new Vector2(350, 480); //la vuelvo grande
            return;
        }
    }

    public void OnHoverExit()
    {
        Destroy(zoomcard);
    }

    void Update()
    {
        Turn = GameObject.Find("TurnCounter").GetComponent<SetTurn>().Turno;
    }
}
