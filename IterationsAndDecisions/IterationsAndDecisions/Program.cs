using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IterationsAndDecisions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //ForLoopExample();
            //ForEachLoopExample();
            //LinqQueryOverInts();
            //WhileLoopExample();
            //DoWhileLoopExample();
            //IfElseExample();
            //ExecuteIfElseUsingConditionalOperator();
            //SwitchExample();
            //SwitchOnStringExample();
            //SwitchOnEnumExample();
            ExecutePatternMatchingSwitch();
            ExecutePatternMatchingSwitchWithWhen();

            Console.ReadLine();
        }

        // Базовый цикл for.
        static void ForLoopExample()
        {
            // Переменная i видима только в контексте цикла for.
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine($"Number is: {i} ");
            }
            // Здесь переменная i больше видимой не будет.
            Console.WriteLine();
        }

        // Проход по элементам массива посредством foreach.
        static void ForEachLoopExample()
        {
            string[] carTypes = { "Ford", "BMW", "Honda" };
            foreach (string carType in carTypes)
                Console.WriteLine(carType);

            int[] myInts = { 1, 2, 3 };
            foreach (int i in myInts)
                Console.WriteLine(i);

            Console.WriteLine();
        }

        static void LinqQueryOverInts()
        {
            int[] numbers = { 10, 20, 30, 40, 1, 2, 3, 8 };
            // Запрос LINQ!
            var subset = from i in numbers where i < 10 select i;
            Console.Write("Values in subset: ");

            foreach (var i in subset)
            {
                Console.Write($"{i}");
            }
            Console.WriteLine();
        }

        static void WhileLoopExample()
        {
            string userIsDone = "";
            // Проверить копию строки в нижнем регистре
            while (userIsDone.ToLower() != "yes")
            {
                Console.WriteLine("In while loop");
                Console.Write("Are you done? [yes] [no]: ");
                userIsDone = Console.ReadLine();
            }
            Console.WriteLine();
        }

        static void DoWhileLoopExample()
        {
            string userIsDone = "";
            do
            {
                Console.WriteLine("In do/while loop");
                Console.Write("Are you done? [yes] [no]: ");
                userIsDone = Console.ReadLine();
            } while (userIsDone.ToLower() != "yes"); //Обрати внимание на точку с запятой!
            Console.WriteLine();
        }

        /*        Операция  Пример использования       Описание
                    ==       if (age == 30)            Возвращает true, если выражения являются одинаковыми
                    !=       if ("Foo" != myStr)       Возвращает true, если выражения являются разными
                    <        if (bonus < 2000)         Возвращает true, если выражение слева
                    >        if (bonus > 2000)         (bonus) меньше, больше, меньше или равно
                    <=       if (bonus <= 2000)        либо больше или равно выражению справа
                    >=       if (bonus >= 2000)        (2000)
        */

        static void IfElseExample()
        {
            string stringData = "My text";
            // Недопустимо, т.к. свойство Length возвращает int, а не bool,
            //if (stringData.Length)
            if (stringData.Length > 10)
            {
                Console.WriteLine("string greater than 10 characters");
            }
            else
            {
                Console.WriteLine("string is not greater than 10 characters");
            }
            Console.WriteLine();
        }

        // Условная операция (?:)
        // условие ? первое_выражение : второе_выражение;
        // В качестве оператора могут применяться только:
        // - выражения присваивания, - вызова, - инкремента, - декремента, - создания объекта

        static void ExecuteIfElseUsingConditionalOperator()
        {
            string stringData = "Another text";
            Console.WriteLine(stringData.Length > 10
                ? "string greater than 10 characters"
                : "string is not greater than 10 characters");
            Console.WriteLine();
        }

        /*  Операция            Пример                  Описание
               &&     if (аде == 30 && name == "Fred")  Операция “И”. Возвращает true, если все выражения дают true
               ||     if (age ==30 | | name == "Fred")  Операция “ИЛИ”. Возвращает true, если хотя бы одно из выражений дает true
               !      if(!myBool)                       Операция “НЕ”. Возвращает true, если выражение дает false, 
                                                        или false, если выражение дает true
         */

        static void SwitchExample()
        {
            Console.WriteLine("1 [C#], 2 [VB]");
            Console.Write("Choose: ");
            string langChoice = Console.ReadLine();
            int n = int.Parse(langChoice);

            switch (n)
            {
                case 1:
                    Console.WriteLine("Good choice! C# is a fine language.");
                    break;
                case 2:
                    Console.WriteLine("VB: OOP, multithreading, and more.");
                    break;
                default:
                    Console.WriteLine("Good luck then");
                    break;
            }
            Console.WriteLine();
        }

        static void SwitchOnStringExample()
        {
            Console.WriteLine("C# or VB");
            Console.Write("Choose: ");
            string langChoice = Console.ReadLine();
            switch (langChoice)
            {
                case "C#":
                    Console.WriteLine("Good choice! C# is a fine language.");
                    break;
                case "VB":
                    Console.WriteLine("VB: OOP, multithreading, and more.");
                    break;
                default:
                    Console.WriteLine("Good luck then");
                    break;
            }
            Console.WriteLine();
        }

        static void SwitchOnEnumExample()
        {
            Console.WriteLine("Enter your favorite day of week: ");
            DayOfWeek favDay;
            try
            {
                favDay = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Bad input");
                return;
            }
            switch (favDay)
            {
                case DayOfWeek.Monday:
                    Console.WriteLine("Another day, another dollar.");
                    break;
                case DayOfWeek.Tuesday:
                    Console.WriteLine("At least it is not Monday.");
                    break;
                case DayOfWeek.Wednesday:
                    Console.WriteLine("A fine day.");
                    break;
                case DayOfWeek.Thursday:
                    Console.WriteLine("Almost Friday...");
                    break;
                case DayOfWeek.Friday:
                    Console.WriteLine("Yes, Friday rules!");
                    break;
                case DayOfWeek.Saturday:
                case DayOfWeek.Sunday:
                    Console.WriteLine("Weekend");
                    break;
            }
            Console.WriteLine();
        }

        static void ExecutePatternMatchingSwitch()
        {
            Console.WriteLine("1 [Integer (5)], 2 [String (\"Hi\")], 3 [Decimal (2.5)]");
            Console.Write("Write your option: ");
            string userChoice = Console.ReadLine();
            object choice;

            // Стандартный оператор switch, в котором применяется
            // сопоставление с образцом с константами
            switch (userChoice)
            {
                case "1":
                    choice = 5;
                    break;
                case "2":
                    choice = "Hi";
                    break;
                case "3":
                    choice = 2.5;
                    break;
                default:
                    choice = "Something else";
                    break;
            }

            // Новый оператор switch, в котором применяется
            // сопоставление с образцом с типами

            switch (choice)
            {
                case int i:
                    Console.WriteLine($"Your choice is integer {i}");
                    break;
                case string s:
                    Console.WriteLine($"Your choice is string {s}");
                    break;
                case double d:
                    Console.WriteLine($"Your choice is double {d}");
                    break;
                default:
                    Console.WriteLine("Something else");
                    break;
            }
            Console.WriteLine();
        }

        static void ExecutePatternMatchingSwitchWithWhen()
        {
            Console.WriteLine("1 [C#] 2 [VB]");
            Console.Write("Pick your language");

            object langChoice = Console.ReadLine();
            var choice = int.TryParse(langChoice.ToString(), out int c) ? c : langChoice;

            switch (choice)
            {
                case int i when i == 2:
                case string s when s.Equals("VB", StringComparison.OrdinalIgnoreCase):
                    Console.WriteLine("VB: OOP, multithreading, and more!");
                    break;
                case int i when i == 1:
                case string s when s.Equals("C#", StringComparison.OrdinalIgnoreCase):
                    Console.WriteLine("Good choice, C# is a fine language.");
                    break;
                default:
                    Console.WriteLine("Good luck!");
                    break;
            }
            Console.WriteLine();
        }
    }
}
