using System;
using System.Data;

namespace Example2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("REGISTRO DE ESTUDIANTES\n");
            Console.WriteLine("=========================");

            Console.WriteLine("Choose an option?");
            Console.WriteLine("\ta - Add Student");
            Console.WriteLine("\tb - Edit Student");
            Console.WriteLine("\tc - List Students");

            switch (Console.ReadLine())
            {
                case "a":
                    Console.WriteLine("Option is not available!");
                    break;
                case "b":
                    Console.WriteLine("Option is not available!");
                    break;
                case "c":
                    GetStudents();
                    break;
            }
        }

        static void GetStudents()
        {
            
        }
    }
}
