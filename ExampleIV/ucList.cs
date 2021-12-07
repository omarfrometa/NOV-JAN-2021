using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExampleIV
{
    public partial class ucList : UserControl
    {
        nov_jan_2021Entities db = new nov_jan_2021Entities();

        public ucList()
        {
            InitializeComponent();
            //GetRecords();
        }

        private void ucList_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                GetRecords();
            }
        }

        private void GetRecords()
        {
            var students = db.Student.ToList();

            if (!string.IsNullOrEmpty(txtEnroll.Text))
            {
                students = students.Where(x => x.Mat.Contains(txtEnroll.Text)).ToList();
            }

            if (!string.IsNullOrEmpty(txtCedula.Text))
            {
                students = students.Where(x => x.Cedula.Contains(txtCedula.Text)).ToList();
            }

            if (!string.IsNullOrEmpty(txtEmail.Text))
            {
                students = students.Where(x => x.Email.ToLower().Contains(txtEmail.Text.ToLower())).ToList();
            }

            if (!string.IsNullOrEmpty(txtFirstName.Text))
            {
                students = students.Where(x => x.FirstName.ToLower().Contains(txtFirstName.Text.ToLower())).ToList();
            }

            if (!string.IsNullOrEmpty(txtLastName.Text))
            {
                students = students.Where(x => x.LastName.ToLower().Contains(txtLastName.Text.ToLower())).ToList();
            }

            if (!string.IsNullOrEmpty(txtPhone.Text))
            {
                students = students.Where(x => x.Phone.Contains(txtPhone.Text)).ToList();
            }

            dgvRecords.DataSource = students;
            lblRecords.Text = $"{students.Count} Registros encontrados.";
            dgvRecords.Columns[0].Visible = false;
            dgvRecords.Columns["Seq"].Visible = false;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            GetRecords();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            foreach (var c in this.Controls)
            {
                if (c is TextBox)
                {
                    ((TextBox)c).Text = string.Empty;
                }
            }
        }
    }
}
