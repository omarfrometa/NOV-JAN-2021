using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExampleIV._1077982
{
    public partial class AddForm : Form
    {
        nov_jan_2021Entities db = new nov_jan_2021Entities();

        public AddForm()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void Save()
        {
            var ciudadano = new C1077982_Ciudadano();
            ciudadano.Cedula = txtCedula.Text;
            ciudadano.Nombre = txtNombre.Text;
            ciudadano.Sexo = "M";
            ciudadano.Apellido1 = txtApellido1.Text;
            ciudadano.Apellido2 = txtApellido2.Text;
            ciudadano.FechaNacimiento = dtpFechaNac.Value;
            ciudadano.LugarNacimiento = txtLugarNacimiento.Text;
            ciudadano.TipoSangre = txtTipoSangre.Text;
            ciudadano.Ocupacion = txtOcupacion.Text;
            ciudadano.EstadoCivil = txtEstadoCivil.Text;
            ciudadano.Nacionalidad = txtNacionalidad.Text;

            ciudadano.FechaExpiracion = DateTime.Now.AddYears(4);
            ciudadano.FechaCreacion = DateTime.Now;

            db.C1077982_Ciudadano.Add(ciudadano);
            var added = db.SaveChanges() > 0;

            if (added)
            {
                MessageBox.Show($"El Ciudadano {txtNombre.Text} {txtApellido1.Text} fue agregado correctamente.");

                ClearForm();
            }
        }

        private void ClearForm()
        {
            txtCedula.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtApellido1.Text = string.Empty;
            txtApellido2.Text = string.Empty;
            dtpFechaNac.Value = DateTime.Now.AddYears(-18);
            txtLugarNacimiento.Text = string.Empty;
            txtTipoSangre.Text = string.Empty;
            txtOcupacion.Text = string.Empty;
            txtEstadoCivil.Text = string.Empty;
            txtNacionalidad.Text = string.Empty;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
