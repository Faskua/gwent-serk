using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ClaseCarta : MonoBehaviour
    {
   
    public string Name; //nombre de la carta
    public int OriginalPower;  //campo para guardar el poder original de la carta, no se cambia para saber el poder de la carta y devolverlo al original cuando utilicen un despeje
    public int Power;  //campo para guardar el indice de poder que veran los jugadores y es el que va a cambiar con los efectos y el clima
    public string DescriptionNskill; // campo para guardar la descripcion y explicar el efecto de la carta en caso de que tenga
    public string Lider;  // campo para saber si es carta lider
    public string Faction; //campo para guardar la faccion
    public string Type; //campo para guardar si es de oro o plata
    public int Frange; // campo para guardar la franja en la que se juega la carta
    public string Franja; // para mostrar la franja de la carta en el juego
    public bool Affected = false; //campo para saber si la carta esta siendo afectada por un clima
    
    public bool Sumada = false; // para saber si ya esta sumada en la franja
    public bool ShierkeAfectada = false; //para la habilidad de flora
    public bool repartida = false; // para arreglar el problema del mazo
        
    }

   

