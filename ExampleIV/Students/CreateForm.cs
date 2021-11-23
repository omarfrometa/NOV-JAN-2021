using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExampleIV.Students
{
    public partial class CreateForm : Form
    {
        nov_jan_2021Entities db = new nov_jan_2021Entities();
        List<string> Msg = new List<string>();
        public CreateForm()
        {
            InitializeComponent();
        }

        private void txtCedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtEnroll_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (CheckForm())
            {
                Save();
            }
            else
            {
                var message = "";
                foreach (var item in Msg)
                {
                    message += $"{item}\n";
                }

                MessageBox.Show(message);
            }
        }

        private bool CheckForm()
        {
            Msg = new List<string>();
            var result = true;

            if (string.IsNullOrEmpty(txtFirstName.Text))
            {
                Msg.Add("El Nombre es un campo requerido.");
                result = false;
            }

            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                Msg.Add("El Correo Elecronico es un campo requerido.");
                result = false;
            }

            return result;
        }

        private void Save()
        {
            var student = new Student {
                Id = Guid.NewGuid(),
                Mat = txtEnroll.Text,
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text,
                Cedula = txtCedula.Text,
                Email = txtEmail.Text,
                Phone = txtPhone.Text,
                Enabled = false,
                CreatedDate = DateTime.Now
            };

            db.Student.Add(student);
            var result = db.SaveChanges() > 0;

            if (result)
            {
                MessageBox.Show($"El estudiante {student.FirstName} {student.LastName} fue creado con exito.");

                ClearForm();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            txtEnroll.Text = string.Empty;
            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtCedula.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtPhone.Text = string.Empty;
        }
    }
}
