using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunWithEnums
{
    // специальное перечисление
    enum EmpType
    {
        Manager,        // = 0
        Grunt,          // = 1
        Contractor,     // = 2
        VicePresident   // = 3 
    }

    // Начать нумерацию со значения 102.
    enum EmpTypeEx
    {
        Manager = 102,
        Grunt,          // = 103
        Contractor,     // = 104
        VicePresident   // = 105
    }

    // Значения элементов в перечислении не обязательно д.б. последовательными!
    // На этот раз для элементов ЕmрТуре используется тип byte.
    enum EmpTypeM : byte
    {
        Manager = 10,
        Grunt = 1,
        Contractor = 100,
        VicePresident = 9
        // President = 999 - значение слишком велико для типа byte
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Enums *****");

            // Создать переменную типа ЕmрТуре.
            EmpType emp = EmpType.Contractor;
            AskForBonus(emp);

            // Вывести тип хранилища для значений перечисления.
            Console.WriteLine($"EmpType uses a {Enum.GetUnderlyingType(emp.GetType())} for a storage");

            //На этот раз для получения информации о типе используется операция typeof.
            Console.WriteLine($"EmpType uses a {Enum.GetUnderlyingType(typeof(EmpType))}");

            // Выводит строку "emp is a Contractor".
            Console.WriteLine($"Emp is a {emp.ToString()}");

            // Выводит строку "Contractor = 2".
            Console.WriteLine($"{emp.ToString()} = {(Int32)emp}");
            Console.WriteLine();

            EmpType e2 = EmpType.Grunt;

            // Эти типы являются перечислениями из пространства имен System.
            DayOfWeek day = DayOfWeek.Monday;
            ConsoleColor cc = ConsoleColor.Green;

            EvaluateEnum(e2);
            EvaluateEnum(day);
            EvaluateEnum(cc);

            Console.ReadLine();
        }

        // Перечисления как параметры,
        static void AskForBonus(EmpType e)
        {
            switch (e)
            {
                case EmpType.Manager:
                    Console.WriteLine("How about stock options instead?");
                    break;
                case EmpType.Grunt:
                    Console.WriteLine("You have got to be kidding...");
                    break;
                case EmpType.Contractor:
                    Console.WriteLine("You already get enough cash...");
                    break;
                case EmpType.VicePresident:
                    Console.WriteLine("VERY GOOD, sir!");
                    break;
            }
            Console.WriteLine();
        }

        /*
        static void ThisMethodWillNotCompile()
        {
            // Ошибка! SalesManager отсутствует в перечислении ЕmрТуре!
            ЕmрТуре еmp = ЕmрТуре.SalesManager;

            // Ошибка! Не указано имя ЕmрТуре перед значением Grunt!
            еmр = Grunt;
        }
        */

        // Этот метод выводит детали любого перечисления,
        static void EvaluateEnum(Enum e)
        {
            Console.WriteLine($"=> Inforamtion about {e.GetType().Name}");
            Console.WriteLine($"Underlying storage type: {Enum.GetUnderlyingType(e.GetType())}");

            // Получить все пары "имя-значение" для входного параметра.
            Array enumData = Enum.GetValues(e.GetType());
            Console.WriteLine($"This enum has {enumData.Length}");

            // Вывести строковое имя и ассоциированное значение,
            // используя флаг формата D 
            for (int i = 0; i < enumData.Length; i++)
            {
                Console.WriteLine($"Name: {enumData.GetValue(i)}");
            }
            Console.WriteLine();
        }
    }
}
