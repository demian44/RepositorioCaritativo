using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

namespace Hilos1
{
    public partial class Form1 : Form
    {
        List<Thread> hilos;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.hilos = new List<Thread>();
            Thread hiloEnviarMensaje1 = new Thread(this.EnviarMensaje1);
            Thread hiloEnviarMensaje2 = new Thread(this.EnviarMensaje2);

            // Se lanzan los dos hilos, si bien primero se empieza a ejecutar EnviarMensaje1 este duerme 
            // mas tiempo por lo cual seguramente se vera el mensaje "O muy oscuro...." primero
            hiloEnviarMensaje1.Start("Muy claro Lisa?");
            hiloEnviarMensaje2.Start("O muy oscuro....");

            //Agrego a la lista los hilos ya que en algun momentos me convendria matarlos por las dudas
            this.hilos.Add(hiloEnviarMensaje1);
            this.hilos.Add(hiloEnviarMensaje2);
        }

        // Como lo voy a usar en un hilo, necesariamente tiene que ser void y recibir un parametro
        // del tipo object. Por que?? Porque cuando instancias un Thread y le pasas un metodo como 
        // al constructor espera recibir un metodo cualquiera que retorne void y reciba object....
        public void EnviarMensaje1(object mensaje)
        {
            Thread.Sleep(5000);
            MessageBox.Show($"EnviarMensaje2: {(string)mensaje}");
        }
        
        // La unica diferencia con el metodo anterior es que este duerme menos tiempo.
        public void EnviarMensaje2(object mensaje)
        {
            Thread.Sleep(1000);
            MessageBox.Show($"EnviarMensaje2: {(string)mensaje}");
        }

        // Este metodo se ejecuta cuando se esta cerrando la aplicacion
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Nos aseguramos de matar todos los hilos.
            int i = 0;
            foreach(Thread hilo in this.hilos)
            {
                // Checkeo si esta corriendo y lo hago cagar pa dentro.
                if(hilo.IsAlive)
                {
                    hilo.Abort();
                    MessageBox.Show($"Se cierra el hilo: {++i}");
                }
                else
                {
                    MessageBox.Show($"El hilo {++i} ya estaba cerrado.");
                }
            }

        }
    }


}

