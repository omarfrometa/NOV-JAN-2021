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
    public partial class MainForm : Form
    {
        public MainForm(Student student)
        {
            InitializeComponent();

            lblEnroll.Text = student.Mat;
            lblFullName.Text = $"{student.FirstName} {student.LastName}";
            lblCedula.Text = student.Cedula;
            lblEmail.Text = student.Email;
            lblPhone.Text = Routines.FormatPhone(student.Phone);
            lblCreatedDate.Text = student.CreatedDate.ToString("F");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var form = new Students.CreateForm();
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var form = new Students.ReadForm();
            form.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var form = new Students.UpdateForm();
            form.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var form = new Students.DeleteForm();
            form.Show();
        }
    }
}
