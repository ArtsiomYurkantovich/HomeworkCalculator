using System;
using System.Globalization;

namespace Сalculator
{
    class Program
    {
        private const string Clear = "clear";
        private const string Exit = "exit";
        private const string Info = "info";
        private const string Add = "add";
        private const string Addition = "+";
        private const string Substraction = "-";
        private const string Multiplication = "*";
        private const string Division = "/";
        private const string Percentage = "%";
        private const string ResAdd = "sum";
        private const string Square = "square";
        private static double FirstNumber;
        private static double SecondNumber;
        private static double Result;
        private static bool RequestedExit;

        // Method that prints out the commands list
        static void ShowCommands()
        {
          
            Console.WriteLine($"{Clear} - Clear console content.");
            Console.WriteLine($"{Exit} - Exit the application.");
            Console.WriteLine($"{Info} - Show list of commands.");
            Console.WriteLine($"{Add} - Add a number.");
            Console.WriteLine($"{Addition} - Addition of two number.");
            Console.WriteLine($"{Substraction} - Difference of two number.");
            Console.WriteLine($"{Multiplication} - Multiplication of two number.");
            Console.WriteLine($"{Division} - Division of two number.");
            Console.WriteLine($"{Percentage} - Finding a percentage of a number .");
            Console.WriteLine($"{Square} - Square root of number.");
            Console.WriteLine($"{ResAdd} - Mathematical operations on the result.");
           
        }

        // Method which allows you to enter numbers and check if they are entered correctly
        static void EnterNumber()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Enter please first number: ");
            while (!double.TryParse(Console.ReadLine(), NumberStyles.Float, CultureInfo.InvariantCulture, out FirstNumber))
            {
                Console.Write("Enter please correct first number: ");
            }
           
            Console.Write("Enter please second number: ");
            while (!double.TryParse(Console.ReadLine(), NumberStyles.Float, CultureInfo.InvariantCulture, out SecondNumber))
            {
                Console.Write("Enter please correct second number: ");
            }
            Console.ResetColor();
        }

        static void AdditionNumber()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Result = FirstNumber + SecondNumber;
            Console.WriteLine($"*****\t {FirstNumber} + {SecondNumber} = {Result}\t*****");
            Console.ResetColor();
        }

        static void SubstractionNumber()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Result = FirstNumber - SecondNumber;
            Console.WriteLine($"*****\t {FirstNumber} - {SecondNumber} = {Result} \t*****");
            Console.ResetColor();

        }

        static void MultiplicationNumber()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Result = FirstNumber * SecondNumber;
            Console.WriteLine($"*****\t {FirstNumber} * {SecondNumber} = {Result} \t*****");
            Console.ResetColor();
        }

        // Method implements division and checks division by zero
        static void DivisionNumber()
        {
            if (SecondNumber == 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Attention! Zero cannot be divided.  Please re-enter the second number.");
                Console.ResetColor();

                Console.Write("Enter please second number: ");
                while (!double.TryParse(Console.ReadLine(), NumberStyles.Float, CultureInfo.InvariantCulture, out SecondNumber))
                {
                    Console.Write("Enter please correct second number: ");
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Result = FirstNumber / SecondNumber;
                Console.WriteLine($"*****\t {FirstNumber} / {SecondNumber} = {Result} \t*****");
                Console.ResetColor();
            }
        }

        // Method of finding the percentage of a number.
        static void PercentageOfNumber()
        {
            Console.Write("Please enter percent: ");
            double pers;
           
            while (!double.TryParse(Console.ReadLine(), out pers))
            {
                Console.Write("Please enter correct percent: ");
            }
            
            Console.ForegroundColor = ConsoleColor.Red;
            Result = (FirstNumber * (pers)) / 100;
            Console.WriteLine($"*****\t ({FirstNumber} * {pers}) / 100 = {Result} \t*****");
           
            Result = (SecondNumber * (pers)) / 100;
            Console.WriteLine($"*****\t ({SecondNumber} * {pers}) / 100 = {Result} \t*****");
            Console.ResetColor();

        }

        // Finding the square root of the first and second numbers
        static void SquareNumber()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Result = Math.Sqrt(FirstNumber);
            Console.WriteLine($"*****\t Square root of the first numbers  = {Math.Sqrt(FirstNumber)} \t*****");
            
            Result = Math.Sqrt(SecondNumber);
            Console.WriteLine($"*****\t Square root of the second numbers = {Math.Sqrt(SecondNumber)} \t*****");
            Console.ResetColor();
        }

        // Mathematical operations on the result
        static void ResultOperation()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            FirstNumber = Result;
            Console.Write("Enter please number: ");
            Console.ResetColor();
            
            while (!double.TryParse(Console.ReadLine(), NumberStyles.Float, CultureInfo.InvariantCulture, out SecondNumber))
            {
                Console.Write("Enter please correct second number: ");
            }
            Console.WriteLine();
            ShowCommands();
            ApplyCommand();
           
        }

        // Clear console content.
        
        static void ClearDisplay()
        {
            Console.Clear();
        }

        // Methode implements basic commands
        
        static void ApplyCommand()
        {
            Console.WriteLine();
            Console.Write("> ");
            string command = Console.ReadLine().ToLower();
            switch (command)
            {
                case Info:
                    ShowCommands();
                    break;
                case Addition:
                    AdditionNumber();
                    Console.WriteLine();
                    break;
                case Add:
                    EnterNumber();
                    Console.WriteLine();
                    break;
                case Exit:
                    RequestedExit = true;
                    break;
                case Substraction:
                    SubstractionNumber();
                    Console.WriteLine();
                    break;
                case Multiplication:
                    MultiplicationNumber();
                    Console.WriteLine();
                    break;
                case Division:
                    DivisionNumber();
                    Console.WriteLine();
                    break;
                case Percentage:
                    PercentageOfNumber();
                    Console.WriteLine();
                    break;
                case Square:
                    SquareNumber();
                    Console.WriteLine();
                    break;
                case ResAdd:
                    ResultOperation();
                    Console.WriteLine();
                    break;
                case Clear:
                    ClearDisplay();
                    Console.WriteLine();
                    break;
               
                default:
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Error! Please enter command at list information");
                    Console.WriteLine();
                    Console.ResetColor();
                    break;
            }
        }

        static void RunApplication()
        {
            Console.WriteLine();
            EnterNumber();
            Console.WriteLine();
            
            // While RequestExit = false perform method ApplyCommand
            
            while (!RequestedExit)
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("*** SELECT ONE OF THE OPERATIONS!!! ***");
                Console.ResetColor();
                ShowCommands();
                ApplyCommand();

            }
        }

        static void Main(string[] args)
        {
            RunApplication();
        }
    }
}
