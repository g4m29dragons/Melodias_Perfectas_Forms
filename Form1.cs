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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnValidar_Click(object sender, EventArgs e)
        {
            if (textBoxContrasena.Text == "123")
            {
                // Si la contraseña es correcta, abre el formulario de datos
                FormularioRegistroDatos frm = new FormularioRegistroDatos();
                frm.Show();
                this.Hide();  // Oculta el formulario de acceso
            }
            else
            {
                MessageBox.Show("Contraseña incorrecta. Inténtalo de nuevo.");
            }
        }
    }
}
