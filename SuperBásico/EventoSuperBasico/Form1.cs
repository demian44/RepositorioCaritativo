using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EventoSuperBasico
{
    delegate void ElDelegado(string numeroCualquiera);
    public partial class Form1 : Form
    {
        event ElDelegado ElEvento;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Antes de asignar this.ElEvento es null
            ElEvento += this.MostrarMensajeUno; //Acá this.ElEvento dejo de ser null
            ElEvento += this.MostrarMensajeDos;
            ElEvento.Invoke("Mensaje que paso al invoke");
        }

        void MostrarMensajeUno(string numeritoCualquiera)
        {
            // Puede hacer lo que se te cante
            MessageBox.Show("MostrarMensajeUno: este es un manejador. Mensaje recibido: '" + numeritoCualquiera + "'.");
        }


        void MostrarMensajeDos(string numeritoCualquiera)
        {
            // Puede hacer lo que se te cante
            MessageBox.Show("MostrarMensajeDos: este es otro manejador. Mensaje recibido: '" + numeritoCualquiera + "'.");
        }
    }
}
