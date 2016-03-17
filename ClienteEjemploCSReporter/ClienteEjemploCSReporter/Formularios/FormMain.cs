using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ApiDescargaSAT;
using System.Collections;
using System.IO;
using System.Diagnostics;

namespace ClienteEjemploCSReporter
{
    public partial class FormMain : Form
    {
        private IDescargaSAT descargaSAT; // Declaramos un objeto de la clase IDescargaSAT
        private IConsulta resultadoConsulta; // Declaramos un objeto de la clase IConsulta

        private BackgroundWorker backgroundCarga;
        private FormBackgroundWorker frmBackGround;


        public FormMain() // Constructor
        {
            InitializeComponent(); /// Inicializar componentes

            /// Inicializamos el Background para que no se congele la interfaz mientras se realiza la descarga SAT
            backgroundCarga = new BackgroundWorker();
            backgroundCarga.WorkerSupportsCancellation = true;

            backgroundCarga.DoWork +=
                new DoWorkEventHandler(backgroundCarga_DoWork);

            descargaSAT = new IDescargaSAT(); //Inicializamos una nueva instancia de la clase IDescargaSAT

            textBoxRFCContrato.Select(); /// Enfocamos el textbox del RFC
        }


        ///Método para mostrar el back ground para que no se bloqueé la interfaz
        private void backgroundCarga_DoWork(object sender,
            DoWorkEventArgs e)
        {
            frmBackGround = new FormBackgroundWorker();
            frmBackGround.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            frmBackGround.Show();
            frmBackGround.BringToFront();
            frmBackGround.Focus();
            
            while (true)
            {
                if (backgroundCarga.CancellationPending)
                {
                    e.Cancel = true;
                    frmBackGround.Close();
                    return;
                }
                Application.DoEvents();
            }

        }

        // Se ejecuta con el evento clic del botón "buttonDescargaSAT"
        private void buttonDescargaSAT_Click(object sender, EventArgs e)
        {
            try
            {
                FormConsulta frmConsulta = new FormConsulta(); // Instaciamos al formulario "FormConsulta"
                frmConsulta.ShowDialog();

                if (!frmConsulta.EsAceptar) // Si no se hizo clic en el botón "Aceptar" del formulario, salimos de éste método.
                    return;

                // Instaciamos de la clase "Credencial", la cual nos pedirá el RFC y Password de contrato.
                Credenciales credencial = new Credenciales(this.textBoxRFCContrato.Text.Trim(), this.textBoxPassContrato.Text.Trim());
              

                // Validamos que se haya introducido RFC y Password de contrato
                if (credencial.getUsername() == "" || credencial.getPassword() == "")
                {
                    // Si alguno de los parámetros viene vacío, se lo indico al usuario y salgo del método
                    MessageBox.Show("Por favor introduzca RFC de contrato y contraseña.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                /* Instaciamos un objeto de la clase "Parametros", la cual nos indicará los parámetros 
                 *  que vamos a necesitar para realizar la consulta. */
                Parametros parametros = new Parametros();
                

                /// INICIO DE ASIGNACIÓN DE PARÁMETROS

                /* En el siguiente algoritmo se van a ir asignando los valores al objeto de la clase "Parametros"
                 * bajo el criterio de búsqueda que se ponga en el formulario*/

                /// Consultas de tipo EMITIDAS
                if (frmConsulta.RadioButtonEmitido.Checked)
                {
                    parametros.consulta = TipoConsulta.EMITIDAS; /// Seleccionamos el tipo de consulta a través de la clase TipoConsulta

                    if (frmConsulta.BuscarPorRFC)
                    {
                        // Seleccionamos el Estatus a través de la siguiente clase Estatus
                        parametros.status = Estatus.TODOS;
                        // Seleccionamos el RFC a través de la clase BusquedaRFC
                        parametros.rfcBusqueda = BusquedaRFC.PorRFC(frmConsulta.RFCReceptor); 
                    }
                    else
                    {
                        parametros.rfcBusqueda = BusquedaRFC.TODOS;

                        if (frmConsulta.RadioButtonTodos.Checked)
                            parametros.status = Estatus.TODOS;

                        if (frmConsulta.RadioButtonVigente.Checked)
                            parametros.status = Estatus.VIGENTES;

                        if (frmConsulta.RadioButtonCancelado.Checked)
                            parametros.status = Estatus.CANCELADAS;
                    }
                }
                /// Consultas de tipo RECIBIDAS
                else
                {
                    parametros.consulta = TipoConsulta.RECIBIDAS;

                    if (frmConsulta.BuscarPorRFC)
                    {
                        parametros.status = Estatus.TODOS;
                        parametros.rfcBusqueda = BusquedaRFC.PorRFC(frmConsulta.RFCEmisor);
                    }
                    else
                    {
                        parametros.rfcBusqueda = BusquedaRFC.TODOS;

                        if (frmConsulta.RadioButtonTodos.Checked)
                            parametros.status = Estatus.TODOS;

                        if (frmConsulta.RadioButtonVigente.Checked)
                            parametros.status = Estatus.VIGENTES;

                        if (frmConsulta.RadioButtonCancelado.Checked)
                            parametros.status = Estatus.CANCELADAS;
                    }
                }

                // Asignamos las fechas de inicio y fin formateadas de la siguiente forma: yyyy-MM-ddTHH:mm:ss
                parametros.fechaInicio = Convert.ToDateTime(frmConsulta.FechaDesde).ToString("yyyy-MM-ddT00:00:00");
                parametros.fechaFin = Convert.ToDateTime(frmConsulta.FechaHasta).ToString("yyyy-MM-ddT23:59:59");

                parametros.rfc = frmConsulta.RFC; //Asignamos el RFC
                parametros.cief = frmConsulta.CIEF; //Asignamos la CIEF

                /// FIN DE ASIGNACIÓN DE PARÁMETROS
                

                dataGridViewCFDIs.DataSource = null; // Limpiamos la grilla
                buttonBajarZip.Enabled = false; // Deshabilitamos el botón de descarga del ZIP

                /* Vamos escribiendo el proceso en un archivo txt, el cual leerá cada segundo el back ground 
                 * que se mostrará al usuario durante las consultas*/
                Utilerias.generarInfo("Esperando respuesta..."); 

                /// Back Ground
                this.Visible = false; // Hacemos invisible la interfaz principal
                this.backgroundCarga.RunWorkerAsync("Revalidando comprobantes..."); // Mostramos el back ground

                // Ejecutamos la consulta y guardamos el resultado en un objeto de la clase IConsulta
                resultadoConsulta = descargaSAT.consultar(credencial, parametros);
           

                if (descargaSAT.IsErrorConsulta()) // Consultamos si hubo error al armar la consulta con los parámetros enviados
                {
                    // Si hubo error, cancelamos el back ground, mostramos al usuario los errores y salimos del método.

                    /// Back Ground Cancel
                    this.backgroundCarga.CancelAsync();
                    System.Threading.Thread.Sleep(200);
                    this.Visible = true; 

                    MessageBox.Show(descargaSAT.MsjErrorConsulta(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                //Consultamos cada 5 segundos si el resultado de la consulta ya está terminada
                while (!resultadoConsulta.isTerminada()) 
                {
                    System.Threading.Thread.Sleep(5000); // Esperamos 5 segundos para volver a preguntar en qué Estatus se encuentra la consulta

                    string estado = resultadoConsulta.getStatus(); // Asignamos el estatus
                    string encontrados = resultadoConsulta.getEncontrados(); // Asignamos el total encontrados hasta el momento

                    Utilerias.generarInfo("Encontrados hasta el momento: " + encontrados + Environment.NewLine +
                        "Estatus: " + estado);
                }


                if (resultadoConsulta.isFallo()) // Si la consulta devolvió un fallo
                {
                    /// Back Ground Cancel
                    this.backgroundCarga.CancelAsync();
                    System.Threading.Thread.Sleep(200);
                    this.Visible = true;

                    // Preguntamos por los diferentes posibles estados de fallo y lo indicamos al usuario
                    if (resultadoConsulta.getStatus() == StatusConsulta.FALLO_AUTENTICACION)
                        MessageBox.Show("Error en la autenticación. Por favor verifique su RFC y Contraseña (CIEF).",
                            "Error autenticación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                    {
                        if (resultadoConsulta.getStatus() == StatusConsulta.FALLO)
                            MessageBox.Show("Error general en el Servicio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                        {
                            if (resultadoConsulta.getStatus() == StatusConsulta.FALLO_500_MISMO_HORARIO)
                                MessageBox.Show("Se obtuvieron más de 500 resultados con la misma fecha y horario (minuto exacto).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }


                int nPagina = 1;
                // Asigamos el total de páginas y de registros
                int totalPaginas = resultadoConsulta.getPaginas(); 
                int totalRegistros = resultadoConsulta.getTotalResultados();


                Utilerias.generarInfo("Total de páginas encontradas: " + totalPaginas.ToString() + Environment.NewLine +
                     "Total de registros: " + totalRegistros.ToString());

                // Declaramos un nuevo array list donde asignaremos los CFDIs devueltos
                ArrayList listadoCFDIs = new ArrayList();

                // Recorremos las páginas
                while (nPagina <= totalPaginas)
                {
                    // Obtemos los CFDIs por página
                    ArrayList lista = resultadoConsulta.getResultados(nPagina);

                    // Juntamos en un listado todos los resultados
                    listadoCFDIs.AddRange(lista);

                    nPagina++; // Incrementamos el contador de páginas

                    Utilerias.generarInfo("Obteniendo registros de la página " + nPagina.ToString() + " de " + totalPaginas.ToString());
                }


                /// Formateamos el listado devuelto del Web Service y agregamos al DataGridView
                List<CFDI> listaCFDIs = ListadoCFDI.GenerarListadoSAT(listadoCFDIs);

                /// Agregamos el listado a la fuente de datos del DataGrid
                this.dataGridViewCFDIs.DataSource = listaCFDIs;

                // Si hubo resultados, habilitamos el botón de descarga del ZIP.
                if (listadoCFDIs.Count > 0) { buttonBajarZip.Enabled = true; }


                /// Back Ground Cancel
                this.backgroundCarga.CancelAsync();
                System.Threading.Thread.Sleep(200);
                this.Visible = true;

                // Si no hubo resultados de la consulta, se lo indico al usuario
                if (totalRegistros == 0)
                {
                    MessageBox.Show("No hubo resultados de la consulta.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            catch (Exception ex) // En caso de algún error en general se lo mostramos al usuario
            {
                /// Back Ground Cancel
                this.backgroundCarga.CancelAsync();
                System.Threading.Thread.Sleep(200);
                this.Visible = true;

                MessageBox.Show("Error general: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void buttonBajarZip_Click(object sender, EventArgs e)
        {
            try
            {
                /// Back Ground
                this.Visible = false;
                this.backgroundCarga.RunWorkerAsync("...");
                Utilerias.generarInfo("Descargando archivo ZIP...");

                // Armamos el directorio donde se descargará el archivo ZIP
                string directorio = Utilerias.AppPath() + "\\Temp\\ZIP\\";
                // Armamos la ruta completa con el nombre del archivo
                string rutaTempArchivoZIP = directorio + resultadoConsulta.getFolio() + ".zip";

                // Ejecutamos el método que descargará el archivo ZIP
                resultadoConsulta.downloadZIP(rutaTempArchivoZIP);

                // Si el directorio no existe, lo creamos
                if (!Directory.Exists(directorio))
                {
                    Directory.CreateDirectory(directorio);
                }

                // Abrimos el explorador de archivos con el .zip seleccionado
                string argument = @"/select," + rutaTempArchivoZIP;
                Process.Start("explorer.exe", argument);


                /// Back Ground Cancel
                this.backgroundCarga.CancelAsync();
                System.Threading.Thread.Sleep(200);
                this.Visible = true;
            }
            catch (Exception ex) // En caso de algún error en general se lo mostramos al usuario
            {
                /// Back Ground Cancel
                this.backgroundCarga.CancelAsync();
                System.Threading.Thread.Sleep(200);
                this.Visible = true;

                MessageBox.Show("Error general: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void textBoxRFCContrato_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }


      
    }
}
