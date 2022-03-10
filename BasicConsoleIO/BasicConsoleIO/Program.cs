using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicConsoleIO
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Basic Console I/O");
            GetUserData();
            FormatNumericalData();
            Console.ReadLine();
        }
        private static void GetUserData()
        {
            Console.Write("Please enter your name: ");
            string userName = Console.ReadLine();
            Console.Write("Please enter your age: ");
            string userAge = Console.ReadLine();

            ConsoleColor prevColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine("Hello {0}' You are {1} years old", userName, userAge);
            Console.ForegroundColor = prevColor;

            //заполнители
            Console.WriteLine("{0}, Number {0}, Number {0}", 9);
            Console.WriteLine("{1}, {0}, {2}", 10, 20, 30);
        }

        static void FormatNumericalData()
        {
            int value = 99999;
            Console.WriteLine("The value 99999 in various formats:");
            Console.WriteLine("c format: {0:c}", value);
            Console.WriteLine("d9 format: {0:d9}", value);
            Console.WriteLine("f3 format: {0:f3}", value);
            Console.WriteLine("n format: {0:n}", value);

            Console.WriteLine("E format: {0:E}", value);
            Console.WriteLine("e format {0:e}", value);
            Console.WriteLine("X format {0:X}", value);
            Console.WriteLine("x format {0:x}", value);
        }
    }
}
