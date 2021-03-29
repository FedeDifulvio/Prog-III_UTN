using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PracticaPDF1
{
    public partial class Formulario5 : Form
    {
        public Formulario5()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (validaciones())
            {
                rtbResultado.Text = ("Nombre: " + tbNombre.Text + "\n" + "Apellido: " + tbApellido.Text + "\n" +
              "edad: " + tbEdad.Text + "\n" + "Dirección: " + tbDireccion.Text).ToUpper(); 
                tbNombre.Text = "";
                tbApellido.Text = "";
                tbEdad.Text = "";
                tbDireccion.Text = "";
            }
        }

        private bool validaciones()
        {
            int errors = 0;

            if (tbNombre.Text == "")
            {
                labelToRed(lblNombre);
                errors++; 
            }
            if (tbApellido.Text == "")
            {
                labelToRed(lblApellido);
                errors++;
            }

            if (tbEdad.Text == "" || !tbEdad.Text.All(char.IsDigit))
            {
                labelToRed(lblEdad);
                errors++;
                if (!tbEdad.Text.All(char.IsDigit))
                {
                    errorProvider1.SetError(lblEdad, "edad debe ser un número");
                }
            }
            
            
            if (tbDireccion.Text == "" )                            
            {
                labelToRed(lblDireccion);
                errors++;
            }

            if (errors > 0)
            {
                errorProvider1.SetError(lblResultado, "campos incompletos o erróneos"); 
                return false;
                
            }
            else
            {
                return true;
            }
            
        }

        private void tbApellido_TextChanged(object sender, EventArgs e)
        {
            labelToNormal(lblApellido);
        }

        private void tbNombre_TextChanged(object sender, EventArgs e)
        {
            labelToNormal(lblNombre);
        }

        private void tbEdad_TextChanged(object sender, EventArgs e)
        {
            labelToNormal(lblEdad);
            errorProvider1.SetError(lblEdad, "");
        }

        private void tbDireccion_TextChanged(object sender, EventArgs e)
        {
            labelToNormal(lblDireccion); 
        } 

        private void labelToNormal(Label lbl)
        {
            lbl.BackColor = Color.Empty;
            lbl.ForeColor = Color.Black;
            errorProvider1.SetError(lblResultado, "");

        }

        private void labelToRed(Label lbl)
        {
            lbl.BackColor = Color.Red;
            lbl.ForeColor = Color.White;
        }
    }
}
