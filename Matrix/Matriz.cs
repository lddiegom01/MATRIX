using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    internal class Matriz
    {
        // readonly int filas = 7;
        // readonly int columnas = 7;
        public List<Personaje> listaPersonajes = new List<Personaje>();
        Personaje[,] matrizz;

        public Matriz(int locura)
        {
            this.matrizz= new Personaje[locura,locura];
            this.listaPersonajes.Clear();
        }

        //Metodos que devuelven las lineas y las columnas
        public int getx() { return (int) this.matrizz.GetLength(0);}
        public int gety() { return (int)this.matrizz.GetLength(1); }

        //Devuelve el personaje introduciendo una celda
        public Personaje getPersonajeCelda(int x, int y)
        {
            return this.matrizz[x,y];
        }

        //Devuelve la lista de personajes
        public List<Personaje> getList()
        {
            return this.listaPersonajes;
        }

        //Metodo que añade un personaje a la lista de personajes de la matriz 
        public void addPersonaje(Personaje personaje) 
        {
            this.listaPersonajes.Add(personaje);
        }

        //Metodo que elimina el primer personaje de la lista
        public void eliminarDeLaLista()
        {
            this.listaPersonajes.RemoveAt(0);
        }
        //Devuelve solo el nombre de un personaje de la lista
        public string getNombreDePersonaje(int num)
        {
            return this.listaPersonajes[num].getNombre();
        }

        //Devuelve solo la ciudad de un personaje de la lista 

        public string getCiudadDelPersonaje(int num)
        {
            return this.listaPersonajes[num].getCiudad();
        }

        public Personaje getPersonaje()
        {
                return (Personaje)this.listaPersonajes.First();
        }

        //Mete en el tablero un personaje metido por parametro
        public void meterEnElTablero(Personaje person)
        {
            bool vacio = true;
            while (vacio) 
            {
                int x = RandomNumber.Aleatorio(0, this.matrizz.GetLength(0));
                int y = RandomNumber.Aleatorio(0, this.matrizz.GetLength(1));
                if (this.matrizz[x, y] == null)
                {
                    this.matrizz[x, y]=person;
                    vacio = false;
                }
            }
        }

        //Imprime la matriz por pantalla de tal forma que hace un bucle por las filas,despues por las columnas
        //y va comprobando si es un personaje o no, con una red de condicionales que va imprimiendo por pantalla c si es personaje
        //n si es neo, s si es smith o - si no es un personaje
        public void pintarMatriz()
        {
            for (int fila = 0; fila < this.matrizz.GetLength(0); fila++)
            {
                for (int columna = 0; columna < this.matrizz.GetLength(1); columna++)
                {
                    if (this.matrizz[fila, columna] is null)
                    {
                        Console.Write("-" + "\t");
                    }
                    else
                    {
                        if (this.matrizz[fila, columna] is Neo)
                        {
                            Console.Write("N" + "\t"); // Imprimir Neo y agregar una tabulación

                        }
                        else
                        {
                            if (this.matrizz[fila, columna] is Smith)
                            {
                                Console.Write("S" + "\t"); // Imprimir Smith y agregar una tabulación
                            }
                            else
                            {
                                Console.Write("C" + "\t"); // Imprimir un elemento de la matriz y agregar una tabulación
                            }
                        }
                    }
                }
                Console.WriteLine(); // Salto de línea para pasar a la siguiente línea
            }
        }

        //Comprueba si la matriz esta llena devolviendo un booleano
        public bool estaLlena()
        {
            foreach (Personaje person in this.matrizz)
            {
                if (person == null)
                {
                    return false;
                }
            }
            return true;
        }

        //Mete la x y la y por parametro y un personaje para añadirlo en la celda especificada
        public void setCelda(int x, int y, Personaje pj)
        {
            this.matrizz[x, y]=pj;
        }

        public void llenarMatriz(List<Personaje> list)
        {
            int fila = 0;
            int columna = 0;
            while (!this.estaLlena())
            {
                for (int i = 0; i < fila; i++)
                {
                    for (int j = 0; j < columna; j++)
                    {
                        if (i * columna + j < list.Count)
                        {
                            if (this.matrizz[i,j] == null)
                            {
                                this.matrizz[i, j] = list[i * columna + j];
                            }
                            
                        }
                        else
                        {
                            // Puedes establecer una referencia nula o un valor por defecto si la lista es más pequeña que la matriz
                            this.matrizz[i, j] = null; // o new Personaje("ValorPorDefecto");
                        }
                    }
                }
            }
        }

        public void meterPersonaje(Personaje personaje)
        {
            int fila = RandomNumber.Aleatorio(0, this.matrizz.GetLength(0));
            int columna = RandomNumber.Aleatorio(0, this.matrizz.GetLength(1));

            if(personaje is Personaje)
            {
                if(this.matrizz == null)
                {
                    this.matrizz[fila, columna] = personaje;
                }
            }
        }

        public void turnoPersonajes()
        {
            int xmatriz = this.getx();
            int ymatriz = this.gety();
            bool listaTiene = true;
            for (int fila = 0; fila < xmatriz; fila++)
            {
                for (int columna = 0; columna < ymatriz; columna++)
                {
                    Personaje personajeCheck = this.getPersonajeCelda(fila, columna);
                    bool esNeo = personajeCheck is Neo;
                    bool esSmith = personajeCheck is Smith;

                    //matamos a los personajes que deben morir y que no sean smith y neo
                    if (personajeCheck.getMort()>7 && !esNeo && !esSmith)
                    {
                        this.setCelda(fila, columna, null);
                    }
                    else
                    {
                        personajeCheck.masMuerte();
                    }
                }
            }
            while (!this.estaLlena())
            {
                Personaje ca = this.getPersonaje();
                this.meterEnElTablero(ca);
                //matrix.eliminarDeLaLista();
            }
            this.pintarMatriz();
            Console.WriteLine("HA PASADO 1 SEGUNDO");
        }
    }
}
