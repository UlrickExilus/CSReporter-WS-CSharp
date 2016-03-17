using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ClienteEjemploCSReporter
{
    public partial class FormConsulta : Form
    {
        public string RFC;
        public string CIEF;
        public string FechaDesde;
        public string FechaHasta;
        public string RFCReceptor;
        public string RFCEmisor;
        public string Tipo;
        public string Estatus;

        public bool EsAceptar;
        public bool BuscarPorRFC;

       
        public FormConsulta() // Constructor
        {
            RFC = "";
            CIEF = "";
            FechaDesde = "";
            FechaHasta = "";
            Tipo = "EMITIDO";
            Estatus = "";

            EsAceptar = false;
            BuscarPorRFC = false;

            InitializeComponent();
        }


        private void checkBoxRFC_CheckedChanged(object sender, EventArgs e)
        {
            /*Algoritmo para habilitar el text box de RFC Específico (Receptor o Emisor)
             Si el tipo de búsqueda es "Emitido", se habilitará el text box del Receptor
             Si el tipo de búsqueda es "Recibido", se habilitará el text box del Emisor*/

            if (this.checkBoxRFC.Checked) // Si está seleccionada la casilla de "Buscar por RFC"
            {
                this.BuscarPorRFC = true;
                this.groupBoxRFC.Enabled = true;
            
                if (this.RadioButtonEmitido.Checked)
                {
                    this.textBoxRFCReceptor.Enabled = true;
                    this.textBoxRFCEmisor.Enabled = false;
                    this.labelReceptor.Enabled = true;
                    this.labelEmisor.Enabled = false;
                }

                if (this.RadioButtonRecibido.Checked)
                {
                    this.textBoxRFCReceptor.Enabled = false;
                    this.textBoxRFCEmisor.Enabled = true;
                    this.labelReceptor.Enabled = false;
                    this.labelEmisor.Enabled = true;
                }

                this.GroupBoxEstatus.Enabled = false;
            }
            else // Si no está seleccionada la casilla de "Buscar por RFC"
            {
                this.BuscarPorRFC = false;
                this.groupBoxRFC.Enabled = false;
                this.GroupBoxEstatus.Enabled = true;
            }
        }


        private void RadioButtonEmitido_CheckedChanged(object sender, EventArgs e)
        {
            /// Si el radio button "Emitido" cambió su estado
            if (this.groupBoxRFC.Enabled)
            {
                if (this.RadioButtonEmitido.Checked)
                {
                    this.textBoxRFCReceptor.Enabled = true;
                    this.textBoxRFCEmisor.Enabled = false;
                    this.labelReceptor.Enabled = true;
                    this.labelEmisor.Enabled = false;
                }
            }
        }



        private void RadioButtonRecibido_CheckedChanged(object sender, EventArgs e)
        {
            /// Si el radio button "Recibido" cambió su estado
            if (this.groupBoxRFC.Enabled)
            {
                if (this.RadioButtonRecibido.Checked)
                {
                    this.textBoxRFCReceptor.Enabled = false;
                    this.textBoxRFCEmisor.Enabled = true;
                    this.labelReceptor.Enabled = false;
                    this.labelEmisor.Enabled = true;
                }
            }
        }



        private void ButtonCancelar_Click(object sender, EventArgs e)
        {
            // Si se hace clic en el botón "Cancelar", cierro el formulario
            this.Close();
        }



        private void ButtonAceptar_Click(object sender, EventArgs e)
        {
            // Si el RFC o CIEF están vacíos, se lo indico al usuario y salgo del método
            if (textBoxRFC.Text.Trim() == "" || textBoxCIEF.Text.Trim() == "")
            {
                MessageBox.Show("Por favor introduzca RFC y CIEF", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information );
                return;
            }

            // Asignamos valores
            EsAceptar = true;
            RFC = textBoxRFC.Text;
            CIEF = textBoxCIEF.Text;
            FechaDesde = DateTimePickerDesde.Value.ToString("yyyy-MM-ddThh:mm:ss");
            FechaHasta = DateTimePickerHasta.Value.ToString("yyyy-MM-ddThh:mm:ss");
            RFCReceptor = this.textBoxRFCReceptor.Text;
            RFCEmisor = this.textBoxRFCEmisor.Text;

            if (RadioButtonEmitido.Checked)
                Tipo = "EMITIDO";
            else
                Tipo = "RECIBIDO";

            if (RadioButtonTodos.Checked)
                Estatus = "";
            else
            {
                if (RadioButtonVigente.Checked)
                    Estatus = "VIGENTE";
                else
                    Estatus = "CANCELADO";
            }

            this.Close();
        }



    }
}
