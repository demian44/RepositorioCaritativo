using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eventos
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Persona persona = new Persona();

            // Trato de ejecutar los eventos, como todavia no les asigne ningun metodo o manejador
            // el metodo EjecutarEvento va a retornar un mensaje indicando que no se ejecuto el evento
            string resultadoDelMetodo = persona.EjecutarEvento();

            //Imprimo el mensaje que me retorna EjecutarEvento para corroborar que el evento es null.
            MessageBox.Show(resultadoDelMetodo);

            // Al evento del tipo ElDelegado solo le puedo agregar metodos que 
            // retornen void y reciban string
            persona.elEventoLoco += persona.CargarNombre;
            persona.elEventoLoco += this.MostrarMensaje;

            // Una vez que se ejecuta (esta vez con exito porque elEventoLoco dejo de ser null) 
            // Se van a ejecutar los dos metodos que pase arriba y va a retornar un mensaje de exito
            resultadoDelMetodo = persona.EjecutarEvento();

            MessageBox.Show($"Se ejecuto persona.CargarNombre dandole valor a persona.nombre ({persona.nombre})");
            //Imprimo el segundo mensaje que me devuelve EjecutarEvento
            MessageBox.Show(resultadoDelMetodo);
        }
        public void MostrarMensaje(string nombre)
        {
            MessageBox.Show($"Este es el segundo metodo en ejecutarse tambien recibe nombre {nombre}");
        }
    }

    public delegate void ElDelegado(string persona);

    public class Persona
    {
        public string nombre;
        public event ElDelegado elEventoLoco;

        // Uso este metodo para verificar si el evento es null e invocar al mismo.
        // Esta verificacion la hago porque no se si tengo manejadores cargados en el evento
        // Tambien ejecuto el evento dentro de la clase porque no la puedo ejecutar afuera
        public string EjecutarEvento()
        {
            if (this.elEventoLoco == null)
            {
                // Si elEventoLoco es null quiere decir que no tengo manejadores asignados
                return "No habia eventos (this.ElEventoLoco == null)";
            }
            else
            {
                // Si es distinto de null me puedo asegurar que cuando ejecute invoke va a pasar
                // algo (Se van a ejecutar los manejadores (metodos) que le pase en la linea 28 y 29
                this.elEventoLoco.Invoke("Pepe");
                return "Se ejecutaron los eventos";
            }
        }

        public void CargarNombre(string nombre)
        {
            this.nombre = nombre;
        }
    }
}
