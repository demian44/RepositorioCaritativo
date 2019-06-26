using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hilos_Eventos
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            Persona persona = new Persona();

            persona.elEventoLoco += persona.CargarNombre;
            persona.elEventoLoco += this.MostrarMensaje;

            // Le paso Ejecutar evento al Hilo, tuve que modificar el evento ahora retorna void
            // Tiene que retornar void si o si para ejecutarse dentro de un hilo (thread)
            Thread hilo = new Thread(persona.EjecutarEvento);
            hilo.Start();

            // IMPORTANTE: como el hilo se ejecuta en paralelo y tiene una demora de 5 segundos
            // El campo persona.nombre va a estar vacio, a menos que durmamos este hilo por mas tiempo

            MessageBox.Show($"Se ejecuto persona.CargarNombre dandole valor a persona.nombre ({persona.nombre})");
            Thread.Sleep(6000); // Duermo este hilo 6 segundos para darle tiempo al hilo secundario a cargarle el nombre a persona
            MessageBox.Show($"Se ejecuto persona.CargarNombre dandole valor a persona.nombre ({persona.nombre})");
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

        // Hice que este evento retorne void para pasarselo al constructor del Thread
        public void EjecutarEvento()
        {
            if (this.elEventoLoco != null)
            {
                // Si es distinto de null me puedo asegurar que cuando ejecute invoke va a pasar
                // algo (Se van a ejecutar los manejadores (metodos) que le pase en la linea 28 y 29
                this.elEventoLoco.Invoke("Pepe");
            }
        }

        public void CargarNombre(string nombre)
        {
            this.nombre = nombre;
        }
    }
}
