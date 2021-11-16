using System;

namespace Example1
{
    class Program
    {
        static void Main(string[] args)
        {
            Calc();
        }

        static void Calc()
        {
            //Declare variables and then initialize to zero
            double num1 = 0; double num2 = 0;

            //Display title as the C# console calculator appication
            Console.WriteLine("Console Calculator in C#\r");
            Console.WriteLine("-------------------------\n");

            //Ask the user to type the  first number
            Console.WriteLine("Type a number, and then press Enter Key");
            num1 = Convert.ToDouble(Console.ReadLine());

            //Ask the user to type the  second number
            Console.WriteLine("Type a number, and then press Enter Key");
            num2 = double.Parse(Console.ReadLine());

            //Ask the user to choose an option
            Console.WriteLine("Choose an option from the following list:");
            Console.WriteLine("\ta - Add");
            Console.WriteLine("\ts - Subtract");
            Console.WriteLine("\tm - Multiply");
            Console.WriteLine("\td - Divide");

            Console.WriteLine("Your option? ");

            switch (Console.ReadLine())
            {
                case "a":
                    Console.WriteLine($"Your Result is {num1} + {num2} = " + (num1 + num2));
                    break;
                case "s":
                    Console.WriteLine($"Your Result is {num1} - {num2} = " + (num1 - num2));
                    break;
                case "m":
                    Console.WriteLine($"Your Result is {num1} * {num2} = " + (num1 * num2));
                    break;
                case "d":
                    Console.WriteLine($"Your Result is {num1} / {num2} = " + (num1 / num2));
                    break;
            }

            Console.WriteLine("Do you want to do another transaction?");
            var YesOrNot = Console.ReadLine();
            if(YesOrNot.ToLower().Equals("y"))
            {
                Console.Clear();
                Calc();
            }
            else
            {
                //Wait for the user to respond before closing.
                Console.WriteLine("Press any key to close the Calculator Console App...");
                Console.ReadKey();
            }
        }
    }
}
