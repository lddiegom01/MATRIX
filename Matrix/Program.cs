using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Matrix
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Creamos la matrix
            Matriz matrix= new Matriz(6);

            //Creamos a Neo
            Neo neo = new Neo(true, 0, 22);

            //Creamos a Smith
            Smith smith = new Smith(7, 0, 500);


            //Llenamos la lista dinamica de la matrix con personajes creados de manera aleatoria
            for (int i = 0; i < 200 ; i++)
            {
                int muerte = RandomNumber.Aleatorio(0, 9);
                int anio = RandomNumber.Aleatorio(18, 90);

                matrix.addPersonaje(new Personaje(muerte, anio));
            }

            //Imprimimos por pantalla los nombres y ciudades de algunos personajes random de la lista 
            //Cosa que no entiendo, pero eso ya es otro tema
            for (int i = 0;i < 10 ; i++) 
            {
                int elegido = RandomNumber.Aleatorio(0, 199);

                Console.Write(matrix.getNombreDePersonaje(elegido));
                Console.Write(" ");
                Console.WriteLine(matrix.getCiudadDelPersonaje(elegido));

            }

            Personaje c = new Personaje(5, 18);

            matrix.meterEnElTablero(neo);

            matrix.meterEnElTablero(smith);

            //Llenamos la matriz de personajes
            while (!matrix.estaLlena())
            {
                Personaje ca = matrix.getPersonaje();
                matrix.meterEnElTablero(ca);
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("El tablero inicial es: ");
            matrix.pintarMatriz();

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Empieza el juego");
            Console.WriteLine();
            Console.WriteLine();

            //Varibles del tema de los segundos
            int max_time = 20;
            int time = 1;
            bool continuaElPrograma = true;
            //Bucle para los segundos 
            do
            {
                if (time % 1 == 0)
                {
                    continuaElPrograma = matrix.turnoPersonajes();
                    Console.WriteLine("Los personajes han actuado");
                }

                if (time % 2 == 0 && continuaElPrograma)
                {
                    matrix.turnoSmith(smith);
                    Console.WriteLine("Smith ha actuado");

                }
                if (time % 5 == 0 && continuaElPrograma)
                { 
                    int xneo=matrix.getxneo();
                    int yneo=matrix.getyneo();
                    continuaElPrograma = matrix.turnoNeo(xneo, yneo, neo);
                }

                Thread.Sleep(1000);
                time += 1;

            } while ((time <= max_time && continuaElPrograma) );

            if (continuaElPrograma)
            {
                Console.WriteLine("Se acabo la lista");
            } 
            else
            {
                Console.WriteLine("Se acabo el tiempo");
            }
            Console.WriteLine("El tablero ha quedado asi: ");
            matrix.pintarMatriz();
        }
    }
}
