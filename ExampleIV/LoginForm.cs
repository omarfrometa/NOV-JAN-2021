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
    public partial class LoginForm : Form
    {
        nov_jan_2021Entities db = new nov_jan_2021Entities();
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            DoLogin();
        }

        private void DoLogin()
        {
            var usr = txtEnroll.Text;
            var pwd = txtPassword.Text;

            var student = db.Student.FirstOrDefault(x => x.Mat == usr && x.Cedula == pwd);
            if(student == null)
            {
                MessageBox.Show("Credenciales Invalidas!");
                return;
            }

            var form = new MainForm(student);
            form.Show(); //Showing MainForm
            this.Hide(); //Hidden LoginForm
        }

        private void chckViewPWD_CheckStateChanged(object sender, EventArgs e)
        {
            if (sender.GetType() == typeof(CheckBox))
            {
                txtPassword.UseSystemPasswordChar = !((CheckBox)sender).Checked;
            }
        }

    }
}
