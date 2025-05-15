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
    public partial class FormularioRegistroDatos : Form
    {
        public FormularioRegistroDatos()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBoxInstrumento.SelectedItem.ToString())
            {
                case "Piano":
                    txtCostoPorClase.Text = "100000";
                    break;
                case "Guitarra":
                    txtCostoPorClase.Text = "80000";
                    break;
                case "Violín":
                    txtCostoPorClase.Text = "90000";
                    break;
                case "Batería":
                    txtCostoPorClase.Text = "85000";
                    break;
                case "Canto":
                    txtCostoPorClase.Text = "95000";
                    break;
            }
        }

        private bool ValidarCampos()
        {
            // Verificar que todos los campos estén llenos
            if (string.IsNullOrEmpty(txtIdentificacion.Text) ||
                string.IsNullOrEmpty(txtNombreCompleto.Text) ||
                (radioButtonMasculino.Checked == false && radioButtonFemenino.Checked == false) ||
                comboBoxInstrumento.SelectedIndex == -1 ||
                string.IsNullOrEmpty(txtNumeroClases.Text))
            {
                return false;
            }

            // Verificar que el número de clases sea un valor numérico válido
            int numeroClases;
            if (!int.TryParse(txtNumeroClases.Text, out numeroClases))
            {
                return false;
            }

            return true;
        }


        private GestionEstudiantes estudiante;
        private void button1_Click(object sender, EventArgs e)
        {
            estudiante = new GestionEstudiantes()
            {
                Identificacion = txtIdentificacion.Text,
                NombreCompleto = txtNombreCompleto.Text,
                Genero = radioButtonMasculino.Checked ? "Masculino" : "Femenino",
                Instrumento = comboBoxInstrumento.SelectedItem.ToString(),
                NumeroClases = int.Parse(txtNumeroClases.Text),
                CostoPorClase = decimal.Parse(txtCostoPorClase.Text),
                FechaRegistro = dateTimePickerRegistro.Value
            };

            MessageBox.Show("Registro guardado exitosamente.");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Asegúrate de que el objeto estudiante esté inicializado
            if (estudiante != null)
            {
                // Abre el formulario de reporte pasando el objeto estudiante
                FormularioReporte frmReporte = new FormularioReporte(estudiante);
                frmReporte.Show();
                this.Hide();  // Oculta el formulario de ingreso de datos
            }
            else
            {
                MessageBox.Show("Debe guardar un registro antes de calcular el costo.");
            }
        }

        private void txtIdentificacion_TextChanged(object sender, EventArgs e)
        {

        }

        private void FormularioRegistroDatos_Load(object sender, EventArgs e)
        {
            // Establece el valor del DateTimePicker a la fecha actual
            dateTimePickerRegistro.Value = DateTime.Now;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Está seguro de que desea salir?", "Confirmar salida", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
