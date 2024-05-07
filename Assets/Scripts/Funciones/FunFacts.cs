using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FunFacts : MonoBehaviour
{
    public Text Datos;
    private int Randomizator;
    void Start()
    {
        Randomizator = Random.Range(1, 20);
        switch(Randomizator)
        {
            case 1:
                Datos.text = "En Suiza es ilegal tener una sola cobaya.";
                break;
            case 2:
                Datos.text = "El corazón de las gambas se encuentra en la cabeza.";
                break;
            case 3:
                Datos.text = "Sabes por qué los australianos revisan sus zapatos antes de usarlos? Resulta que tienen una araña que abre agujeros en la suela de éstos para utilizarlos como guarida... Su veneno es mortal...";
                break;
            case 4:
                Datos.text = "El polvo que vemos a contraluz por el resplandor que entra por las ventanas, está compuesto en un 90% por nuestras células muertas. :)";
                break;
            case 5:
                Datos.text = "En un estudio realizado en la Universidad de La Habana por un grupo de estudiantes de la Facultad de MATCOM, se demostró que es imposible aprobar y dormir.";
                break;
            case 6:
                Datos.text = "Si tomas 100 tazas de café en un día puedes morir a causa de la cafeína, osea, el límite son 99 gente.";
                break;
            case 7:
                Datos.text = "El sudor de los hipopótamos es rosa. Son HipoCoquettes";
                break;
            case 8:
                Datos.text = "Se estima que el 80% de las capacidades cognitivas de un bebé proceden de su herencia materna. Ya sabes a quien culpar por no aprobar Lógica";
                break;
            case 9:
                Datos.text = "Las hormigas nunca duermen... ni los estudiantes universitarios.";
                break;
            case 10:
                Datos.text = "El nombre completo de Minnie Mouse es Minerva Mouse... el de Mickey es Mortimer Mouse";
                break;
            case 11:
                Datos.text = "Si extendiéramos los vasos sanguíneos de extremo a extremo, le daríamos dos vueltas al mundo. Turbio";
                break;
            case 12:
                Datos.text = "La orina del gato brilla bajo la luz ultravioleta. Debido a la gran cantidad de ácido úrico que contiene.";
                break;
            case 13:
                Datos.text = "Una sola hebra de seda de araña es más fina que un cabello humano, pero también cinco veces más fuerte que el acero de la misma anchura.";
                break;
            case 14:
                Datos.text = "Einstein engañaba a su esposa con su propia prima...quien sería su próxima esposa...";
                break;
            case 15:
                Datos.text = "Los miembros principales de La Banda del Halcón original están basados en el grupo de amigos de Miura, excepto Casca, porque no podían interactuar con mujeres :(";
                break;
            case 16:
                Datos.text = "A Miura no se le ocurrió todo el trasfondo de Gutts y Griffith (ni la relación con Casca) hasta el 3er Volúmen del manga, de hecho Gutts portaría una katana, no la MataDragones";
                break;
            case 17:
                Datos.text = "Háganse un favor y lean Berserk. También hay un manga llamado Berserk The Prototype con sólo dos capítulos y que era una prueba antes de hacer Berserk";
                break;
            case 18:
                Datos.text = "Los cascos que usó Gutts en su juventud como mercenario son los mismos que usa el personaje Joan Chen en The Blood of Heroes";
                break;
            case 19:
                Datos.text = "Puck es una referencia directa al elfo del mismo nombre en la obra, El sueño de una Noche de Verano, de William Shakespear";
                break;
            case 20:
                Datos.text = "El nombre de Farnesse es un guiño a la casa de Farnesio en Italia";
                break;
        }
    }
}
