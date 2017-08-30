using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_batalla
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            Jugador jugador = new Jugador(rnd.Next(1, 5), rnd.Next(50, 101));
            Enemigo enemigo = new Enemigo(rnd.Next(1, 5), rnd.Next(50, 101));

            Duelo duelo = new Duelo(jugador, enemigo);

            Console.ReadLine();
        }
    }

    class Jugador
    {
        public Jugador(int armaInt, int vida)
        {
            Arma = armaArr[armaInt];
            Vida = vida;
        }

        private string[] armaArr = { "hacha", "espada", "arco", "cuchara" };
        public string Arma { get; set; }
        public int Vida { get; set; }
    }

    class Enemigo
    {
        public Enemigo(int nombreInt, int vida)
        {
            Nombre = nombreArr[nombreInt];
            Vida = vida;
        }

        private string[] nombreArr = { "oso", "dragon", "pato", "lombriz"};
        public string Nombre { get; set; }
        public int Vida { get; set; }
    }

    class Duelo
    {
        Random rnd = new Random();

        private int turno = 1;
        private bool ambosVivos = true;

        public Duelo(Jugador jugador, Enemigo enemigo)
        {
            MostrarEstado(jugador, enemigo);

            while(ambosVivos)
            {
                Comenzar(jugador, enemigo);
            }
        }

        private void MostrarEstado(Jugador jugador, Enemigo enemigo)
        {
            Console.WriteLine("El jugador utiliza {0} contra un(a) {1}", jugador.Arma, enemigo.Nombre);
            Console.WriteLine();
            Console.WriteLine("La vida del jugador es de {0}. La vida del enemigo es de {1}", jugador.Vida, enemigo.Vida);
        }

        private void Comenzar(Jugador jugador, Enemigo enemigo)
        {
            Console.WriteLine("***Turno {0}***", turno);
            Atacar(jugador, enemigo);
            Atacar(enemigo, jugador);
            turno++;

            if (jugador.Vida <= 0)
            {
                ambosVivos = false;
                Console.WriteLine("Perdiste...");
            }
            else if (enemigo.Vida <= 0)
            {
                ambosVivos = false;
                Console.WriteLine("¡Ganaste!");
            }
        }
        
        //Sistema encargado de atacar al enemigo y checar si falló o no el ataque
        private void Atacar(Jugador jugador, Enemigo enemigo)
        {
            Console.Write("Jugador ataca con {0}. ", jugador.Arma);

            if (rnd.Next(1, 11) <= 9)
            {
                int daño = rnd.Next(5, 11);
                Console.WriteLine("Hace un daño de {0}", daño);
                enemigo.Vida -= daño;
            }
            else
            {
                Console.WriteLine("Falla el ataque");
            }
        }
        //Sistema encargado de atacar al jugador y checar si falló o no el ataque
        private void Atacar(Enemigo enemigo, Jugador jugador)
        {
            Console.Write("Enemigo ataca. ");

            if (rnd.Next(1, 11) <= 9)
            {
                int daño = rnd.Next(5, 11);
                Console.WriteLine("Hace un daño de {0}", daño);
                jugador.Vida -= daño;
            }
            else
            {
                Console.WriteLine("Falla el ataque");
            }
        }
    }
}
