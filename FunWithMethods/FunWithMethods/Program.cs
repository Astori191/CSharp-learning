using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunWithMethods
{
    // Статические методы могут вызываться
    // напрямую без создания экземпляра класса
    // static возвращаемыйТип ИмяМетода(список параметров) { /* Реализация */}

    /*
    Модификатор параметра           Практический смысл

    (отсутствует)                   Если параметр не помечен модификатором, то предполагается,
                                    что он должен передаваться по значению, т.е. вызываемый метод
                                    получает копию исходных данных

    out                             Выходным параметрам должны присваиваться значения внутри
                                    вызываемого метода, следовательно, они передаются по ссылке.
                                    Если в вызываемом методе выходным параметрам не были присвоены
                                    значения, тогда компилятор сообщит об ошибке

    ref                             Значение первоначально присваивается в вызывающем коде и
                                    может быть необязательно изменено в вызываемом методе (поскольку
                                    данные также передаются по ссылке). Если в вызываемом
                                    методе параметру ref значение не присваивалось, то никакой
                                    ошибки компилятор не генерирует

    params                          Этот модификатор позволяет передавать переменное количество
                                    аргументов как единственный логический параметр. Метод может
                                    иметь только один модификатор params, которым должен быть
                                    помечен последний параметр метода. В реальности потребность в
                                    использовании модификатора params возникает не особенно часто,
                                    однако имейте в виду, что он применяется многочисленными
                                    методами внутри библиотек базовых классов
 */

    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("***** Fun with Methods *****\n");

            // Передать две переменные по значению,
            int x = 9, y = 10;
            Console.WriteLine($"Before call X:{x} Y:{y}");
            Console.WriteLine($"Answer is: {Add(x, y)}");
            Console.WriteLine($"After call X:{x} Y:{y}");
            Console.WriteLine();

            // Присваивать начальные значения локальным переменным, используемым
            // как выходные параметры, не обязательно при условии, что они
            // впервые используются впервые в таком качестве.
            // Версия C# 7 позволяет объявлять параметры out в вызове метода.
            Add(90, 90, out int ans);
            int answ;
            Add(90, 110, out answ);
            Console.WriteLine($"90 + 90 = {ans} 90 + 110 = {answ}");
            Console.WriteLine();

            int i;
            string s;
            bool b;
            FillTheseValues(out i, out s, out b);
            Console.WriteLine($"int is: {i}");
            Console.WriteLine($"string is: {s}");
            Console.WriteLine($"bool is: {b}");

            string str1 = "Flip";
            string str2 = "Flop";
            Console.WriteLine($"Before {str1}, {str2}");
            SwapStrings(ref str1, ref str2);
            Console.WriteLine($"After {str1}, {str2}");
            Console.WriteLine();

            SimpleReturnCall();
            CalculateAverageCall();
            EnterLogData("Error example!");
            EnterLogData("Error example2!", "CFO");
            DisplayFancyMessage(message: "WOW! Very fancy indeed", textColor: ConsoleColor.Red,
                backgroundColor: ConsoleColor.White);
            DisplayFancyMessage(backgroundColor: ConsoleColor.Green, message: "Testing...",
                textColor: ConsoleColor.DarkBlue);
            DisplayFancyMessage2(message: "Hello!");
            DisplayFancyMessage2(backgroundColor: ConsoleColor.Green);

            // ОШИБКА в вызове, поскольку позиционные аргументы идут после именованных.
            // DisplayFancyMessage(message: "Testing...", backgroundColor: ConsoleColor.White,
            //     ConsoleColor.Blue);

            Console.ReadLine();
        }
        //По умолчанию аргументы передаются по значению
        static int Add(int x, int y)
        {
            int ans = x + y;
            // Вызывающий код не увидит эти изменения,
            // т.к. модифицируется копия исходных данных,
            x = 10000;
            y = 88888;
            return ans;
        }

        // Значения выходных параметров должны быть установлены
        // внутри вызываемого метода.
        static void Add(int x, int y, out int ans)
        {
            ans = x + y;
        }

        // Возвращение множества выходных параметров
        static void FillTheseValues(out int a, out string s, out bool b)
        {
            a = 9;
            s = "Enjoy your string";
            b = true;
        }

        /*
        static void ThisWontCompile(out int a)
        {
            Console.WriteLine("Error ! Forgot to assign output arg!");
            Ошибка! Забыли присвоить значение выходному параметру’
        }
        */

        /*
        если значение параметра out не интересует, тогда 
        в качестве заполнителя можно использовать отбрасывание
        например когда нужно выяснить, имеет ли строка
        допустимый формат даты, но сама разобранная дата не требуется
        
        if (DateTime.TryParse(datestring, out _)
        {
            // Делать что-то
        }
        */

        // Ссылочные параметры.
        public static void SwapStrings(ref string s1, ref string s2)
        {
            string tmpStr = s1;
            s1 = s2;
            s2 = tmpStr;
        }

        // Возвращает значение по позиции в массиве.
        public static string SimpleReturn(string[] strArray, int position)
        {
            return strArray[position];
        }

        // Возвращение ссылки.
        // Во-первых, взамен return [возвращаемое значение]
        // метод должен делать return ref [возвращаемая ссылка].
        // Во-вторых, объявление метода также обязано включать ключевое слово ref.
        public static ref string SampleRefReturn(string[] strArray, int position)
        {
            return ref strArray[position];
        }

        public static void SimpleReturnCall()
        {
            string[] stringArray = { "one", "two", "three" };
            int pos = 1;
            Console.WriteLine("=> Use Simple Return");
            Console.WriteLine($"Before {stringArray[0]}, {stringArray[1]}, {stringArray[2]}");
            var output = SimpleReturn(stringArray, pos);
            output = "new";
            Console.WriteLine($"After {stringArray[0]}, {stringArray[1]}, {stringArray[2]}");
            Console.WriteLine();

            // Ссылочные локальные переменные и возвращаемые ссылочные значения
            Console.WriteLine("=> Use ref return");
            Console.WriteLine($"Before {stringArray[0]}, {stringArray[1]}, {stringArray[2]}");
            ref var refOutput = ref SampleRefReturn(stringArray, pos);
            refOutput = "new";
            Console.WriteLine($"After {stringArray[0]}, {stringArray[1]}, {stringArray[2]}");
            Console.WriteLine();
        }

        //Результаты стандартного метода не могут присваиваться локальной переменной ref.
        //Метод должен быть создан как возвращающий ссылочное значение.
        //Локальную переменную внутри метода ref нельзя возвращать как локальную переменную ref. 
        //Следующий код работать не будет:

        // ThisWillNotWork(string[] array)
        // {
        //      int foo = 5;
        //      return ref foo;
        // }

        // Возвращение среднего из некоторого количества значений double.
        // Функция, которая позволяет вызывающему коду 
        // передавать любое количество аргументов 
        // и возвращает их среднее значение
        static double CalculateAverage(params double[] values)
        {
            Console.WriteLine($"You sent me {values.Length} doubles");
            double sum = new double();
            if (values.Length == 0)
            {
                return sum;
            }
            for (int i = 0; i < values.Length; i++)
            {
                sum += values[i];
            }
            return (sum / values.Length);

        }

        static void CalculateAverageCall()
        {
            // Передать список значений double, разделенных запятыми...
            double average;
            average = CalculateAverage(4.0, 3.2, 5.7, 64.22, 87.2);
            Console.WriteLine($"Average data is {average}");

            // ... или передать массив значении double.
            double[] data = { 4.0, 3.2, 5.7, 64.22, 87.2 };
            average = CalculateAverage(data);
            Console.WriteLine($"Average data is {average}");

            // Среднее из 0 равно О!
            Console.WriteLine($"Average data is {CalculateAverage()}");
            Console.WriteLine();
        }
        static void EnterLogData(string message, string owner = "Programmer")
        {
            Console.Beep();
            Console.WriteLine($"Error: {message}");
            Console.WriteLine($"Owner of Error {owner}");
            Console.WriteLine();
        }

        /*
        Ошибка! Стандартное значение для необязательного
        аргумента должно быть известно на этапе компиляции!

        static void EnterLogData(string message, string owner = "Programmer", DateTime timestamp = DateTime.Now)
        {
            Console.Beep ();
            Console.WriteLine("Error: {0}", message);
            Console.WriteLine("Owner of Error: {0}", owner);
            Console.WriteLine("Time of Error: {0}", timestamp);
        }
        */

        static void DisplayFancyMessage(ConsoleColor textColor, ConsoleColor backgroundColor, string message)
        {
            // Сохранить старые цвета для их восстановления после вывода сообщения.
            ConsoleColor oldTC = Console.ForegroundColor;
            ConsoleColor oldBgC = Console.BackgroundColor;

            // Установить новые цвета и вывести сообщение.
            Console.ForegroundColor = textColor;
            Console.BackgroundColor = backgroundColor;
            Console.WriteLine(message);

            // Восстановить предыдущие цвета.
            Console.ForegroundColor = oldTC;
            Console.BackgroundColor = oldBgC;
            Console.WriteLine();
        }

        // поддержка необязательных аргументов
        static void DisplayFancyMessage2(ConsoleColor textColor = ConsoleColor.Blue,
            ConsoleColor backgroundColor = ConsoleColor.White,
            string message = "Test Message")
        {
            //...
        }
    }
}
