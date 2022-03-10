using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCSharpApp
{
    internal class Program
    {
        static int Main(string[] args)
        {
            Console.WriteLine("My First C# App");
            Console.WriteLine("Hello World");

            //обработать любые входные аргументы
            for (int i = 0; i < args.Length; i++)
                Console.WriteLine("Arg: {0}", args[i]);

            //обработать любые входные аргументы, используя foreach
            foreach (string arg in args)
                Console.WriteLine("Arg: {0}", arg);

            //получить агрументы с использованием System.Environment
            string[] theArgs = Environment.GetCommandLineArgs();
            foreach (string arg in theArgs)
                Console.WriteLine("Arg: {0}", arg);

            ShowEnvironmentDetails();

            Console.ReadLine();
            return 0;
        }

        static void ShowEnvironmentDetails()
        {
            //вывести информацию о дисковых устройствах и другие интересные детали
            Console.WriteLine();
            foreach (string drive in Environment.GetLogicalDrives())
                Console.WriteLine("Drive: {0}", drive);
            Console.WriteLine("OS: {0}", Environment.OSVersion);
            Console.WriteLine("Number of processors: {0}", Environment.ProcessorCount);
            Console.WriteLine(".NET Version {0}", Environment.Version);
        }
    }
}
