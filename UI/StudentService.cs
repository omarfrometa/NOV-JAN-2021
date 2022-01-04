using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using UI.DTO;

namespace UI
{
    public class StudentService : BaseService
    {
        public async Task<List<StudentDto>> GetStudentsAsync()
        {
            var result = new List<StudentDto>();
            try
            {
                HttpResponseMessage httpResponse = await client.GetAsync("Students");
                string responseBody = await httpResponse.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<List<StudentDto>>(responseBody); 
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            return result;
        }
    }
}
