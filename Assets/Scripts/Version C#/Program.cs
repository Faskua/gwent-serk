using System;
using System.Collections.Generic;
namespace Proyecto
{
    //definiendo las cartas en general
    public class Carta
    {
        public string Nombre {get; private set;}
        protected string Descripcion {get; private set;}
        protected int OriginalPower {get; private set;}
        public int Poder {get; set;}
        protected string Franja {get; private set;}
        public Jugador Propietario {get; set;} //
        protected string Tipo{get; private set;}
        protected string Lider{get;private set;}
        public virtual void JugarCarta()
        {
            if(Franja == "Melee") Propietario.Melee.Add(this);
            if(Franja == "Range") Propietario.Range.Add(this);
            if(Franja == "Siege") Propietario.Siege.Add(this);
            Propietario.Mano.Remove(this);
            Console.WriteLine("Carta Jugada");
        }
        public Carta(string nombre, string descripcion, int poder, string franja, string tipo, string lider)
        {
            this.Nombre = nombre;
            this.Descripcion = descripcion;
            this.OriginalPower = poder;
            this.Poder = poder;
            this.Franja = franja;
            this.Tipo = tipo;
            this.Lider = lider;
        }
    }
    //definiendo las cartas con efecto
    public abstract class CartaConEfecto : Carta
    {
        public override void JugarCarta()
        {
            base.JugarCarta();
            Efecto();
        }
        protected abstract void Efecto();
        public CartaConEfecto(string nombre, string descripcion, int poder, string franja, Jugador jugador, string tipo, string lider) : base(nombre, descripcion, poder, franja, tipo, lider){}
        
    }

    //definiendo al jugador
    public class Jugador
    {
        protected string Nombre{get; private set;}
        public int Puntos
        {
            get
            {
                int melee = 0;
                foreach (Carta item in Melee)
                {
                    melee += item.Poder;
                }
                int range = 0;
                foreach (Carta item in Range)
                {
                    range += item.Poder;
                }
                int siege = 0;
                foreach (Carta item in Siege)
                {
                    siege += item.Poder;
                }
                return melee + range + siege;
            }
        }
        public int Victorias{get; set;}
        public bool Rendido = false;
        protected Carta Heroe;
        public List<Carta> Mano = new List<Carta>();
        public List<Carta> Mazo = new List<Carta>();
        public List<Carta> Melee = new List<Carta>();
        public List<Carta> Range = new List<Carta>();
        public List<Carta> Siege = new List<Carta>();
        protected List<Carta> ClimaMelee = new List<Carta>();
        protected List<Carta> ClimaRange = new List<Carta>();
        protected List<Carta> ClimaSiege = new List<Carta>();
        public void Robar3()
        {
            for (int i = 0; i < 3; i++)
            {
                Mano.Add(Mazo[i]);
            }
        }
        public void Adueñarse()
        {
            foreach (var item in this.Mazo)
            {
                item.Propietario = this;
            }
        }

        public Jugador(string nombre, Carta heroe)
        {
            this.Nombre = nombre;
            this.Heroe = heroe;
        }
    }

    //comienzo a definir las cartas con efectos 
    public class Flora :CartaConEfecto
    {
        public Flora(string nombre, string descripcion, int poder, string franja, Jugador jugador, string tipo, string lider) : base(nombre, descripcion, poder, franja, jugador, tipo, lider){}
        protected override void Efecto()
        {
            foreach (Carta item in Propietario.Siege)
            {
                if(item.Nombre == "Shierke")
                {
                    this.Poder += 1;
                    item.Poder += 2;
                    return;
                }
            }
        }

    }
    public class BandaDelHalcon : CartaConEfecto
    {
        public BandaDelHalcon(string nombre, string descripcion, int poder, string franja, Jugador jugador, string tipo, string lider) : base(nombre, descripcion, poder, franja, jugador, tipo, lider){}
        protected override void Efecto()
        {
            int cantEjercitos = 1;
            foreach (Carta item in Propietario.Siege)
            {
                if(item.Nombre == "Soldados de la Banda del Halcón")
                {
                    cantEjercitos += 1;
                }
            }
            foreach (Carta item in Propietario.Siege)
            {
                if(item.Nombre == "Soldados de la Banda del Halcón")
                {
                    item.Poder *= cantEjercitos;
                }
            }
        }
    }
    class Program
    {
        public static void Main()
        {
            Carta Taylor = new Carta("Taylor", "Cantante pop cazadora de hombres", 300, "Heroe mi chama", "Oro", "lider");
            Jugador Sylvita = new Jugador("SylvitaLa+Tixa", Taylor);
            Carta Madara = new Carta("Madara", "La definicion de tanque", 40000, "Todas, es la pinga", "Oro", "lider");
            Jugador Alejandro = new Jugador("AlejandritoTixa", Madara);

            Carta Draculaura = new Carta("Draculaura", "Vampireza que desprende flow", 5, "Range", "Oro", "no lider");
            Carta Frankie = new Carta("Frankie", "ITS ALIVEE!!!", 4, "Melee", "Plata", "no lider");
            Carta Cleo = new Carta("Cleo", "La verdadera, unica y repelente", 7, "Siege", "Oro", "no lider");
            Carta Lagoona = new Carta("Lagoona", "Jau yu duin mait", 4, "Melee", "Plata", "no lider");
            Carta Clawdeen = new Carta("Clawdeen", "UUUNA LOOBA EN EL ARMAARIO", 4, "Melee", "Plata", "no lider");
            Carta Barbie = new Carta("Barbie", "Barbie es todo en esta vida, menos machista", 60, "Siege", "Oro", "no lider");
            Carta Luchia = new Carta("Luchia", "Cantante pop cazadora de hombres", 5, "Range", "Plata", "no lider");
            Carta Rina = new Carta("Rina", "Verde como el pus del grano que te reventaste :)", 7, "Range", "Oro", "no lider");
            Carta Karen = new Carta("Karen", "Culea hasta en el polo norte", 6, "Melee", "Plata", "no lider");
            Carta Hanon = new Carta("Hanon", "Nunca he visto a una niña de 13 desear tanto a un hombre", 4, "Range", "Plata", "nolider");

            Sylvita.Mazo.Add(Draculaura);
            Sylvita.Mazo.Add(Frankie);
            Sylvita.Mazo.Add(Cleo);
            Sylvita.Mazo.Add(Lagoona);
            Sylvita.Mazo.Add(Clawdeen);
            Sylvita.Mazo.Add(Barbie);
            Sylvita.Mazo.Add(Luchia);
            Sylvita.Mazo.Add(Rina);
            Sylvita.Mazo.Add(Karen);
            Sylvita.Mazo.Add(Hanon);
            
            Carta Naruto = new Carta("Naruto", "SASUKEEEEEEEEE!", 7, "Melee", "Plata", "no lider");
            Carta Sasuke = new Carta("Sasuke", "NARUTOOOOOOOOO!", 6, "Range", "Plata", "no lider");
            Carta Sakura = new Carta("Sakura", "Sasuke-Kun <3", 5, "Melee", "Plata", "no lider");
            Carta Hinata = new Carta("Hinata", "Naruto-Kun Naruto-Kun, NARUTO-KUUUUN", 4, "Range", "Plata", "no lider");
            Carta Jiraiya = new Carta("Jiraiya", "Su muerte fue mi desarrollo de personaje", 60, "Siege", "Oro", "no lider");
            Carta Orochimaru = new Carta("Orochimaru", "Ni siquiera este es menos serpiente venenosa que tu", 5, "Melee", "Plata", "no lider");
            Carta Kakashi = new Carta("Kakashi", "El papa de los cachorros", 4, "Melee", "Oro", "no lider");
            Carta Tsunade = new Carta("Tsunade", "TETUDA", 5, "Melee", "Plata", "no lider");
            Carta Itachi = new Carta("Itachi", "Quieres que asesine al clan entero? Al toque mi rey", 7, "Siege", "Oro", "lider");

            Alejandro.Mazo.Add(Naruto);
            Alejandro.Mazo.Add(Sasuke);
            Alejandro.Mazo.Add(Sakura);
            Alejandro.Mazo.Add(Hinata);
            Alejandro.Mazo.Add(Jiraiya);
            Alejandro.Mazo.Add(Orochimaru);
            Alejandro.Mazo.Add(Kakashi);
            Alejandro.Mazo.Add(Tsunade);
            Alejandro.Mazo.Add(Itachi);
            
            Alejandro.Adueñarse();
            Sylvita.Adueñarse();

            string input;
            bool turno = true;
            while(Sylvita.Victorias < 3 || Alejandro.Victorias < 3)
            {
                Console.WriteLine("puntos de Sylvia: " + Sylvita.Puntos);
                Console.WriteLine("puntos de Alejandro: " + Alejandro.Puntos);
                if(turno)
                {
                    if(Sylvita.Mano.Count == 0 || Sylvita.Rendido) turno = true;
                    Console.WriteLine("Cartas de Sylvia: ");
                    foreach (var item in Sylvita.Mano)
                    {
                        Console.WriteLine(item.Nombre);
                    }
                    input = Console.ReadLine();
                    if(input == "robar") 
                        Sylvita.Robar3();
                    else if(IsPosible(input))
                        Sylvita.Mano[int.Parse(input) - 1].JugarCarta();
                    else if(input == "rendirse")
                        Sylvita.Rendido = true;
                    else
                    {
                        Console.WriteLine("Escribiste mal, hazlo de nuevo");
                        input = Console.ReadLine();
                    }
                    turno = false;
                }
                else
                {
                    if(Alejandro.Mano.Count == 0 || Alejandro.Rendido) turno = true;
                    Console.WriteLine("Cartas de Alejandro: ");
                    foreach (var item in Alejandro.Mano)
                    {
                        Console.WriteLine(item.Nombre);
                    }
                    input = Console.ReadLine();
                    if(input == "robar") 
                        Alejandro.Robar3();
                    else if(IsPosible(input))
                        Alejandro.Mano[int.Parse(input) - 1].JugarCarta();
                    else if(input == "rendirse")
                        Alejandro.Rendido = true;
                    else
                    {
                        Console.WriteLine("Escribiste mal, hazlo de nuevo");
                        input = Console.ReadLine();
                    }
                    turno = true;
                }
                if(Sylvita.Rendido && Alejandro.Rendido)
                {
                    if(Alejandro.Puntos > Sylvita.Puntos) Alejandro.Victorias += 1;
                    if(Alejandro.Puntos < Sylvita.Puntos) Sylvita.Victorias += 1;
                    Sylvita.Rendido = false;
                    Alejandro.Rendido = false;
                }
            }
            if(Alejandro.Victorias == 2)
                Console.WriteLine("Gané c:");
            else
                Console.WriteLine("Ganaste bb");
        }

        public static bool IsPosible(string inp)
        {
            try
            {
                int res = int.Parse(inp);
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}