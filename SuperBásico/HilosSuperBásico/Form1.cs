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

namespace EventosSuperBásico
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Thread hilo = new Thread(this.MuyClaroLisa);
            Thread hiloDos = new Thread(this.OMuyOscuuuuro);

            hilo.Start(); 
            hiloDos.Start(); 
        }

        void MuyClaroLisa()
        {
            Thread.Sleep(3000); // Importane el tiempo que duerme el hilo para saber cuanto se demora en mostrar el mensaje
            MessageBox.Show("Muy claro Lisa?");
        }

        void OMuyOscuuuuro()
        {
            Thread.Sleep(1000);
            MessageBox.Show("O muy oscuuuuuro.");
        }
    }
}
