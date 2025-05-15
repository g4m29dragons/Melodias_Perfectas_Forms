using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Melodías_Perfectas
{
    public partial class FormularioReporte : Form
    {
        private void MostrarReporte()
        {
            // Asigna los valores del estudiante a cada Label en el formulario
            lblIdentificacion.Text = estudiante.Identificacion;
            lblNombreCompleto.Text = estudiante.NombreCompleto;
            lblGenero.Text = estudiante.Genero;
            lblInstrumento.Text = estudiante.Instrumento;
            lblNumeroClases.Text = estudiante.NumeroClases.ToString();
            lblCostoPorClase.Text = estudiante.CostoPorClase.ToString("C"); // Formato moneda
            lblCostoTotal.Text = estudiante.CalcularCostoTotal().ToString("C"); // Calcula y muestra el costo total
            lblFechaRegistro.Text = estudiante.FechaRegistro.ToString("g"); // Muestra la fecha y hora
        }

        // Variable para almacenar los datos del estudiante
        private GestionEstudiantes estudiante;

        // Constructor que recibe un objeto GestionEstudiantes
        public FormularioReporte(GestionEstudiantes estudiante)
        {
            InitializeComponent(); // Inicializa los componentes del formulario
            this.estudiante = estudiante; // Asigna el estudiante a la variable
            MostrarReporte(); // Llama al método para mostrar los datos
        }

        public FormularioReporte()
        {
            InitializeComponent();
        }

        private void FormularioReporte_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Cierra el formulario de reporte
            this.Close();
            // Abre nuevamente el formulario de registro de datos
            FormularioRegistroDatos frm = new FormularioRegistroDatos();
            frm.Show();
        }
    }
}
