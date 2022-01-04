using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.DTO;

namespace UI
{
    public partial class Form1 : Form
    {
        private StudentService studentService;

        public Form1()
        {
            InitializeComponent();

            getStudents();
        }

        async void getStudents()
        {
            var result = new List<StudentDto>();
            try
            {
                var client = new HttpClient
                {
                    BaseAddress = new Uri(System.Configuration.ConfigurationSettings.AppSettings["BaseAddress"].ToString())
                };

                HttpResponseMessage httpResponse = await client.GetAsync("Students");
                string responseBody = await httpResponse.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<List<StudentDto>>(responseBody);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            dgvStudents.DataSource = result.ToList();
        }
    }
}
