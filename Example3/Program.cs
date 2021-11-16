using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example3
{
    class Program
    {
        static nov_jan_2021Entities db = new nov_jan_2021Entities();

        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()
        {
            Console.WriteLine("REGISTRO DE ESTUDIANTES\n");
            Console.WriteLine("=========================");

            Console.WriteLine("Choose an option?");
            Console.WriteLine("\ta - Add Student");
            Console.WriteLine("\tb - Edit Student");
            Console.WriteLine("\tc - List Students");
            Console.WriteLine("\td - Remove an Student");

            switch (Console.ReadLine())
            {
                case "a":
                    AddStudent();
                    break;
                case "b":
                    UpdateStudent();
                    break;
                case "c":
                    GetStudents();
                    break;
                case "d":
                    RemoveStudent();
                    break;
            }

            Console.ReadLine();
        }

        static void AddStudent()
        {
            var student = new Student();
            Console.WriteLine("NEW STUDENT\n");

            Console.WriteLine("Write your Enroll Number");
            student.Mat = Console.ReadLine();

            Console.WriteLine("Write your First Name");
            student.FirstName = Console.ReadLine();

            Console.WriteLine("Write your Last Name");
            student.LastName = Console.ReadLine();

            Console.WriteLine("Write your Cedula");
            student.Cedula = Console.ReadLine();

            Console.WriteLine("Write your Email");
            student.Email = Console.ReadLine();

            Console.WriteLine("Write your Phone");
            student.Phone = Console.ReadLine();

            student.Id = Guid.NewGuid();
            student.Enabled = true;
            student.CreatedDate = DateTime.Now;

            db.Student.Add(student);
            var result = db.SaveChanges() > 0;

            if (result)
            {
                Console.WriteLine("STUDENT ADDED");

                GetStudents();

                Console.ReadLine();

                Menu();
            }
        }
        static void GetStudents()
        {
            Console.WriteLine("LIST OF STUDENTS");

            var students = db.Student.OrderBy(x=> x.FirstName).ToList();

            int index = 1;
            foreach (var s in students)
            {
                Console.WriteLine($"Seq= {index} | Matricula={s.Mat} | Nombre={s.FirstName} | Apellido={s.LastName} | Email={s.Email}");
                index++;
            }

            Menu();
        }
        static void RemoveStudent()
        {
            Console.WriteLine("REMOVING STUDENT\n\n");
            
            Console.WriteLine("Write your Enroll Number");
            var enrrol = Console.ReadLine();

            var student = db.Student.FirstOrDefault(x => x.Mat.Equals(enrrol));
            if (student != null)
            {
                Console.WriteLine("Are you sure?");
                var sure = Console.ReadLine();
                if(sure.ToLower().Equals("y"))
                {
                    db.Student.Remove(student);
                    var result = db.SaveChanges() > 0;

                    if (result)
                    {
                        Console.WriteLine("STUDENT REMOVED\n");

                        GetStudents();

                        Console.ReadLine();
                    }
                }

                        Menu();

            }
        }

        static void UpdateStudent()
        {
            Console.WriteLine("UPDATE STUDENT\n\n");
            Console.WriteLine("Write your Enroll Number");
            var enrrol = Console.ReadLine();

            var student = db.Student.FirstOrDefault(x => x.Mat.Equals(enrrol));
            if (student != null)
            {
                Console.WriteLine($"Write your First Name ({student.FirstName})");
                var firstname = Console.ReadLine();
                if (!student.FirstName.ToLower().Equals(firstname.ToLower()))
                {
                    student.FirstName = firstname;
                }

                Console.WriteLine($"Write your Last Name ({student.LastName})");
                var lastName = Console.ReadLine();
                if (!student.LastName.ToLower().Equals(lastName.ToLower()))
                {
                    student.LastName = lastName;
                }

                Console.WriteLine($"Write your Cedula ({student.Cedula})");
                var cedula = Console.ReadLine();
                if (!student.Cedula.ToLower().Equals(cedula.ToLower()))
                {
                    student.Cedula = cedula;
                }

                Console.WriteLine($"Write your Email ({student.Email})");
                var email = Console.ReadLine();
                if (!student.Email.ToLower().Equals(email.ToLower()))
                {
                    student.Email = email;
                }

                Console.WriteLine($"Write your Phone ({student.Phone})");
                var phone = Console.ReadLine();
                if (!student.Phone.ToLower().Equals(phone.ToLower()))
                {
                    student.Phone = phone;
                }

                db.Student.Attach(student);
                db.Entry(student).State = System.Data.Entity.EntityState.Modified;
                var result = db.SaveChanges() > 0;

                if (result)
                {
                    Console.WriteLine("STUDENT UPDATED\n");

                    GetStudents();

                    Console.ReadLine();

                    Menu();
                }
            }
        }
    }
}
