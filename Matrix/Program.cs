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
            Matriz matrix= new Matriz(5);

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

            //Personaje ca = matrix.getPersonaje();
            // matrix.meterEnElTablero(ca);

            /**
            if (matrix.estaLlena())
            {
                Console.WriteLine("esta llena");
            } else
            {
                Console.WriteLine("no esta llena");
            }
            */

            //Llenamos la matriz de personajes
            while (!matrix.estaLlena())
            {
                Personaje ca = matrix.getPersonaje();
                matrix.meterEnElTablero(ca);
            }

            matrix.pintarMatriz();

            if (matrix.estaLlena())
            {
                Console.WriteLine("la matriz esta llena");
            }
            else
            {
                Console.WriteLine("la matriz no esta llena");
            }

            //Buscamos la celda de smith y neo
            int xneo;
            int yneo;
            int xsmith;
            int ysmith;

            for (int fila = 0; fila < matrix.getx(); fila++)
            {
                for (int columna = 0; columna < matrix.gety(); columna++)
                {
                    if (matrix.getPersonajeCelda(fila, columna) is Neo)
                    {
                        xneo = fila;
                        yneo=columna;
                    }
                    else if (matrix.getPersonajeCelda(fila, columna) is Smith)
                    {
                        xsmith=fila;
                        ysmith=columna;
                    }
                }
            }

            //Varibles del tema de los segundos
            int max_time = 20;
            int time = 1;
            bool listaTiene = true;
            //Bucle para los segundos 
            do
            {
                if (time % 1 == 0)
                {
                    matrix.turnoPersonajes();
                }

                if (time % 2 == 0)
                {
                    Console.WriteLine("HA PASADO 2 SEGUNDOS");

                }
                if (time % 5 == 0)
                {
                    Console.WriteLine("HA PASADO 5 SEGUNDOS");
                }

                Thread.Sleep(100);
                time += 1;

            } while ((time <= max_time) );

            if (matrix.getList().Count() == 0)
            {
                Console.WriteLine("se acabo la lista");
            }

            matrix.pintarMatriz();
        }
    }
}
