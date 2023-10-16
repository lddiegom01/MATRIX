using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
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
        public Smith getSmithCelda(int x,int y)
        {
            if(this.matrizz[x, y] is Smith)
            {
                return (Smith)this.matrizz[x, y];
            } else
            {
                return null;
            }
        }

        public int getxneo()
        {
            int x = 0;
            for (int fila = 0; fila < this.getx(); fila++)
            {
                for (int columna = 0; columna < this.gety(); columna++)
                {
                    if (this.getPersonajeCelda(fila, columna) is Neo)
                    {
                        x=fila;
                    }
                }
            }
            return x;
        }
        public int getyneo()
        {
            int y = 0;
            for (int fila = 0; fila < this.getx(); fila++)
            {
                for (int columna = 0; columna < this.gety(); columna++)
                {
                    if (this.getPersonajeCelda(fila, columna) is Neo)
                    {
                        y=columna;
                    }
                }
            }
            return y;
        }

        public int getxSmith()
        {
            int x = 0;
            for (int fila = 0; fila < this.getx(); fila++)
            {
                for (int columna = 0; columna < this.gety(); columna++)
                {
                    if (this.getPersonajeCelda(fila, columna) is Smith)
                    {
                        x=fila;
                    }
                }
            }
            return x;
        }
        public int getySmith()
        {
            int y = 0;
            for (int fila = 0; fila < this.getx(); fila++)
            {
                for (int columna = 0; columna < this.gety(); columna++)
                {
                    if (this.getPersonajeCelda(fila, columna) is Smith)
                    {
                        y=columna;
                    }
                }
            }
            return y;
        }

        public void setPersonajeCelda (int x, int y,Personaje personaje)
        {
            if(personaje is Personaje)
            {
                this.matrizz[x,y] = personaje;
            }
        }

        //Metodo que añade un personaje a la lista de personajes de la matriz 
        public void addPersonaje(Personaje personaje) 
        {
            this.listaPersonajes.Add(personaje);
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

        //Turno de los personajes
        public bool turnoPersonajes()
        {
            int xmatriz = this.getx();
            int ymatriz = this.gety();

            for (int fila = 0; fila < xmatriz; fila++)
            {
                for (int columna = 0; columna < ymatriz; columna++)
                {
                    Personaje personajeCheck = this.matrizz[fila, columna];
                    bool esNeo = personajeCheck is Neo;
                    bool esSmith = personajeCheck is Smith;

                    //matamos a los personajes que deben morir y que no sean smith y neo
                    if(!(personajeCheck is null))
                    {
                        if (personajeCheck.getMort()>7 && !esNeo && !esSmith)
                        {
                            this.setCelda(fila, columna, this.getPersonaje());
                            this.listaPersonajes.RemoveAt(0);
                            if(this.listaPersonajes.Count() == 0)
                            {
                                return false;
                            }
                        }
                        else
                        {
                            personajeCheck.masMuerte();
                        }
                    }
                }
            }
            this.pintarMatriz();
            return true;
        }

        //Turno de Neo
        public bool turnoNeo(Neo neo)
        {
            int xneo = this.getxneo();
            int yneo = this.getyneo();
            neo.setElegido();
            if(neo.getElegido())
            {
                for (int x = -1; x<1; x++)
                {
                    for (int y = -1; y<1; y++)
                    {
                        if (((xneo-x)>0) && ((xneo-x)<this.matrizz.GetLength(0))&&((yneo-y)>0) && ((yneo-y)<this.matrizz.GetLength(1))&&(this.matrizz[xneo-x,yneo-y] is null))
                        {
                            setPersonajeCelda(xneo-x,yneo-y, this.getPersonaje());
                            this.listaPersonajes.RemoveAt(0);
                            if (this.listaPersonajes.Count() == 0)
                            {
                                return false;
                            }
                        }
                    }
                } 
            }

            int nuevox = RandomNumber.Aleatorio(0,(int)this.getx()); 
            int nuevoy = RandomNumber.Aleatorio(0,(int)this.gety());
            
            if (this.matrizz[nuevox,nuevoy] is null )
            {
                setPersonajeCelda(nuevox, nuevoy, neo);
            } 
            else if (this.matrizz[nuevox, nuevoy] is Smith)
            {
                Smith smithAuxilio = this.getSmithCelda(nuevox,nuevoy);
                setPersonajeCelda(nuevox, nuevoy, neo);
                setPersonajeCelda(xneo, yneo, smithAuxilio);
            }
            else
            {
                Personaje personajeAuxilio = this.getPersonajeCelda(nuevox, nuevoy);
                setPersonajeCelda(nuevox, nuevoy, neo);
                setPersonajeCelda(xneo, yneo, personajeAuxilio);
            }
            Console.WriteLine("Neo ha actuado");
            return true;
        }

        //Turno de Smith
        public void turnoSmith(Smith smith)
        {
            int capaInfec = RandomNumber.Aleatorio(0, smith.getCapaMaxInfec());
            smith.setCapaInfec(capaInfec);

            int xsmith=this.getxSmith();
            int ysmith=this.getySmith();
            int xneo = this.getxneo();
            int yneo = this.getyneo();

            int distancia = Math.Max(Math.Abs(xsmith-xneo),Math.Abs(ysmith-yneo));
            int[,] auxRecorrido = new int[distancia, 2];

            int sumaSmith = xsmith+ysmith;
            int sumaNeo = xneo+yneo;

            if(sumaNeo%2 == sumaSmith%2)
            {
                for (int i = 0; i<distancia; i++)
                {
                    if (xsmith > xneo)
                    {
                        xsmith--;
                    }
                    else if (xsmith < xneo)
                    {
                        xsmith++;
                    }
                    else
                    {
                        if (xsmith<this.matrizz.GetLength(0)/2)
                        {
                            xsmith++;
                        }
                        else { xsmith--; }
                    }
                    auxRecorrido[i, 0]=xsmith;
                    if (ysmith > yneo)
                    {
                        ysmith--;
                    }
                    else if (ysmith < yneo)
                    {
                        ysmith++;
                    }
                    else
                    {
                        if (ysmith<this.matrizz.GetLength(0)/2)
                        {
                            ysmith++;
                        }
                        else { ysmith--; }
                    }
                    auxRecorrido[i, 1]=ysmith;

                    if (this.matrizz[xsmith,ysmith] is Personaje && !(this.matrizz[xsmith,ysmith] is Neo) && (smith.getCapaInfec() !=0))
                    {
                        this.matrizz[xsmith, ysmith]=null;
                    }
                }
            }
        }
    }
}
