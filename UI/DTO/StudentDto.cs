using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.DTO
{
    public class StudentDto
    {
        public System.Guid Id { get; set; }
        public int Seq { get; set; }
        public string Mat { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Cedula { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool Enabled { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public Nullable<System.DateTime> LastAccessDate { get; set; }
    }
}
