using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    public class Personaje : Methods
    {
        //Clase interna localizacion para ser un atributo de la clase personajes
        internal class Localizacion
        {
            private int latitud;
            private int longitud;
            private string ciudad;
            public Localizacion(string ciu)
            {
                this.latitud = RandomNumber.Aleatorio(-90, 90);
                this.longitud = RandomNumber.Aleatorio(-180, 180);
                this.ciudad = ciu;
            }

            //Override del metodo toString() en la clase ocalizacion
            void toString()
            {
                Console.WriteLine("latitud: " + this.latitud + ", longitud: " +this.longitud+ ", ciudad: " + ciudad);
            }

            //Devuelve la ciudad de la localizacion
            public string getCiudad()
            {
                return this.ciudad;
            }
        }

        private int mortalidad;
        Localizacion localizacion;
        protected int edad;
        protected string nombre;

        //Array final de nombres posibles para los personajes
        readonly string[] nombres = new string[] { "Lucky Luck", "Clarita", "Michael Jordan",
            "Michael Jackson", "Obama", "Antonio Sobrino", "Pessi", "Cristiano Goat",
            "Hannah Montana", "Greta Thunberg", "Alexia Putellas", "Rafa Nadal", "Faker", "Lucio",
            "Ibai Llanos", "Carlos", "Beatrice", "Beethoven", "Mohamed", "Mohamed", "McLovin",
            "McDonalds", "Vito Corleone", "Batman", "Irene Montero", "Axel Blaze", "Iker Casillas",
            "Junji Ito", "Zeus", "Ra", "Abraham","Yoda","Ice Cream","ElRubiusOMG"};

        //Array final de ciudades posibles para los personajes
        readonly string[] ciudades = new string[] { "Puertollano", "Gotham", "Jerusalen", "Madrid", "Betis", "Pueblo Paleta", "Conchinchina" };

        /**
         * Creador de personajes
         * 
         * @param mortalidad: un numero del 1 al 10 que indique lo que le queda para morir a un personaje
         * (muere cuando llega al 10)
         * 
         * @param edad: sUUUUUdaaa
         * 
         */
        public Personaje(int mortalidad, int edad)
        {
            this.mortalidad=mortalidad;
            this.localizacion= new Localizacion(ciudades[RandomNumber.Aleatorio(0, ciudades.Length)]);
            this.edad=edad;
            this.nombre= nombres[RandomNumber.Aleatorio(0, nombres.Length)];
        }


        //Devuelve la mortalidad
        public int getMort() { return this.mortalidad; }


        //Aumenta en 1 la mortalidad del personaje
        public void masMuerte()
        {
            this.mortalidad = mortalidad+1;
        }

        //Devuelve el nombre del personaje
        public string getNombre () 
        {
            return this.nombre;
        }

        //Devuelve la ciudad del personaje
        public string getCiudad()
        {
            return this.localizacion.getCiudad();
        }

        //Override del metodo toString() en la clase personaje
        void toString()
        {
            Console.WriteLine("La mortalidad es: "+this.mortalidad+", la localizacion es: "+this.localizacion.ToString()+", " +
                "la edad es: "+this.edad+", el nombre es: "+this.nombre);
        }

        //Metodos implementados en la interfaz y que por lo tanto tienen que llevarlos aunque sean vacios
        void Methods.generate() { }
        void Methods.print() { }
        void Methods.prompt() { }
    }
}
