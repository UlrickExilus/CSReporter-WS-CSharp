using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ApiDescargaSAT;

namespace ClienteEjemploCSReporter
{
    public partial class FormBackgroundWorker : Form
    {
        public FormBackgroundWorker()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Método que leerá el archivo con la información de los procesos realizados
        /// </summary>
        /// <returns>String | Retorna un string con la información de los procesos</returns>
        private string mensaje()
        {
            string texto = labelInfo.Text;
            try
            {
                texto = System.IO.File.ReadAllText( Utilerias.AppPath() + @"\info.txt");
            }
            catch 
            { }
            return texto;
        }

        /*Evento del timer que se ejecuta cada segundo, la cual mostrará al usuario 
         * en el back ground los procesos realizados*/
        private void timer1_Tick(object sender, EventArgs e)
        {
            labelInfo.Text = mensaje();
        }
    }


  
}
