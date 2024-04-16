using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Amanecer : MonoBehaviour
{
    private GameObject PCemetery; //los cementerios
    private GameObject ECemetery;
    private ClaseFranja pCC; //las 6 franjas normales
    private ClaseFranja pD;
    private ClaseFranja pS;
    private ClaseFranja eCC;
    private ClaseFranja eD;
    private ClaseFranja eS;

    private ClaseClima ClimagepCC; //las 6 de clima
    private ClaseClima ClimagepD;
    private ClaseClima ClimagepS;
    private ClaseClima ClimageeCC;
    private ClaseClima ClimageeD;
    private ClaseClima ClimageeS;
    private bool jugable; //si se puede jugar la carta o no

    public void Efecto()
    {
        if(jugable)
        {
            //activo el efecto de amanecer que tengo en todas las franjas
            pCC.Amanecer();
            eCC.Amanecer();
            pD.Amanecer();
            eD.Amanecer();
            pS.Amanecer();
            eS.Amanecer();

            GoToCemetery();
        }
    }
    public void GoToCemetery() //este metodo es para mandar los eclipses y la carta de despeje a los cementerios
    {
        foreach(GameObject card in ClimagepCC.CardsinFrange)
        {
            if(card.GetComponent<ClaseCarta>().Name == "Eclipse")
            {card.transform.SetParent(PCemetery.transform, false);
            card.transform.position = PCemetery.transform.position;}
        }
        foreach(GameObject card in ClimagepD.CardsinFrange)
        {
            if(card.GetComponent<ClaseCarta>().Name == "Eclipse")
            {card.transform.SetParent(PCemetery.transform, false);
            card.transform.position = PCemetery.transform.position;}
        }
        foreach(GameObject card in ClimagepS.CardsinFrange)
        {
            if(card.GetComponent<ClaseCarta>().Name == "Eclipse")
            {card.transform.SetParent(PCemetery.transform, false);
            card.transform.position = PCemetery.transform.position;}
        }
        foreach(GameObject card in ClimageeCC.CardsinFrange)
        {
            if(card.GetComponent<ClaseCarta>().Name == "Eclipse")
            {card.transform.SetParent(ECemetery.transform, false);
            card.transform.position = ECemetery.transform.position;}
        }
        foreach(GameObject card in ClimageeD.CardsinFrange)
        {
            if(card.GetComponent<ClaseCarta>().Name == "Eclipse")
            {card.transform.SetParent(ECemetery.transform, false);
            card.transform.position = ECemetery.transform.position;}
        }
        foreach(GameObject card in ClimageeS.CardsinFrange)
        {
            if(card.GetComponent<ClaseCarta>().Name == "Eclipse")
            {card.transform.SetParent(ECemetery.transform, false);
            card.transform.position = ECemetery.transform.position;}
        }

        if(gameObject.GetComponent<ClaseCarta>().Faction == "Sacrificios")
        {
            gameObject.transform.position = PCemetery.transform.position;
            gameObject.transform.SetParent(PCemetery.transform, true);
        }
        if(gameObject.GetComponent<ClaseCarta>().Faction == "Falconia")
        {
            gameObject.transform.position = ECemetery.transform.position;
            gameObject.transform.SetParent(ECemetery.transform, true);
        }
    }

    void Start()
    {
        PCemetery = GameObject.Find("PlayerCemetery"); //busco los cementerios
        ECemetery = GameObject.Find("EnemyCemetery");
    }
    void Update()
    {
       jugable = gameObject.GetComponent<JugarCarta>().jugable;
       pCC = GameObject.FindGameObjectWithTag("PlayerMelee").GetComponent<ClaseFranja>(); //busco las zonas
       pD = GameObject.FindGameObjectWithTag("PlayerDistance").GetComponent<ClaseFranja>(); 
       pS = GameObject.FindGameObjectWithTag("PlayerSiege").GetComponent<ClaseFranja>(); 
       eCC = GameObject.FindGameObjectWithTag("EnemyMelee").GetComponent<ClaseFranja>(); 
       eD = GameObject.FindGameObjectWithTag("EnemyDistance").GetComponent<ClaseFranja>(); 
       eS = GameObject.FindGameObjectWithTag("EnemySiege").GetComponent<ClaseFranja>();  
       
       ClimagepCC = GameObject.FindGameObjectWithTag("pClimageM").GetComponent<ClaseClima>(); //busco las zonas de clima
       ClimagepD = GameObject.FindGameObjectWithTag("pClimageD").GetComponent<ClaseClima>(); 
       ClimagepS = GameObject.FindGameObjectWithTag("pClimageS").GetComponent<ClaseClima>(); 
       ClimageeCC = GameObject.FindGameObjectWithTag("eClimageM").GetComponent<ClaseClima>(); 
       ClimageeD = GameObject.FindGameObjectWithTag("eClimageD").GetComponent<ClaseClima>(); 
       ClimageeS = GameObject.FindGameObjectWithTag("eClimageS").GetComponent<ClaseClima>();  
    }
}
