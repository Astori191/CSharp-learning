using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunWithArrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Arrays *****");
            SimpleArrays();
            ArrayInitialization();
            DeclareImplicitArrays();
            ArrayOfObjects();
            RectMultidimensionalArray();
            JaggedMultidimensionalArray();
            PassAndReciveArrays();
            SystemArrayFunctionality();
            Console.ReadLine();
        }

        static void SimpleArrays()
        {
            Console.WriteLine("=> Simple Array Creation.");
            // создать массив int содержащий 3 элемента с индексами 0, 1, 2
            int[] myInts = new int[3];
            myInts[0] = 100;
            myInts[1] = 200;
            myInts[2] = 300;

            // Вывести все значения.
            foreach (int myInt in myInts)
            {
                Console.WriteLine(myInt);
            }
            // создать массив string содержащий 100 элементов с индексами 0-99
            string[] myStrings = new string[100];
            Console.WriteLine();
        }

        static void ArrayInitialization()
        {
            // Синтаксис инициализации массива с использованием ключевого слова new.
            string[] stringArray = new string[] { "one", "two", "three" };
            Console.WriteLine($"stringArray has {stringArray.Length} elements");

            // Синтаксис инициализации массива без использования ключевого слова new.
            bool[] boolArray = { false, false, true };
            Console.WriteLine($"boolArray has {boolArray.Length} elements");

            // Инициализация массива с применением ключевого слова new и указанием размера.
            int[] intArray = new int[4] { 20, 22, 23, 0 };
            Console.WriteLine($"intArray has {intArray.Length} elements");

            // Несоответствие размера и количества элементов!
            // int[] intArray = new int[2] { 20, 22, 23, 0 };

            Console.WriteLine();
        }

        static void DeclareImplicitArrays()
        {
            Console.WriteLine("Implicit Array Initialization.");

            // Переменная а на самом деле имеет тип int[].
            var a = new[] { 1, 10, 100, 1000 };
            Console.WriteLine($"a is a: {a.ToString()}");

            // Переменная b на самом деле имеет тип doublet].
            var b = new[] { 1, 1.5, 2, 2.5 };
            Console.WriteLine($"b is a: {b.ToString()}");

            // Переменная с на самом деле имеет тип string[].
            var c = new[] { $"hello", "null", "world" };
            Console.WriteLine($"c is a: {c.ToString()}");
            Console.WriteLine();

            // Ошибка! Смешанные типы!
            // var d = new[] {"Greetings", 322, 'J', false };
        }

        static void ArrayOfObjects()
        {
            Console.WriteLine("=> Array of Objects.");

            // Массив объектов может содержать все что угодно,
            object[] myObjects = new object[4];
            myObjects[0] = 10;
            myObjects[1] = false;
            myObjects[2] = new DateTime(1969, 3, 24);
            myObjects[3] = "Form and Void!";
            foreach (object obj in myObjects)
            {
                // Вывести тип и значение каждого элемента в массиве.
                Console.WriteLine($"Type: {obj.GetType()}, Value: {obj}");
            }
            Console.WriteLine();
        }

        static void RectMultidimensionalArray()
        {
            Console.WriteLine("=> Rectangular multidimensional array.");

            // Прямоугольный многомерный массив.
            int[,] myMatrix;
            myMatrix = new int[3, 4];

            // Заполнить массив (3 * 4) .
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    myMatrix[i, j] = i * j;
                }
            }

            // Вывести содержимое массива (3 * 4) .
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Console.Write(myMatrix[i, j] + "\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        static void JaggedMultidimensionalArray()
        {
            Console.WriteLine("=> Jagged multidimensional array.");

            // Зубчатый многомерный массив (т.е. массив массивов).
            // Здесь мы имеем массив из 5 разных массивов,
            int[][] myJagArray = new int[5][];
            Console.WriteLine(myJagArray.Length);

            // Создать зубчатый массив.
            for (int i = 0; i < myJagArray.Length; i++)
            {
                myJagArray[i] = new int[i + 7];
            }

            // Вывести все строки (помните, что каждый элемент имеет стандартное значение 0).
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < myJagArray[i].Length; j++)
                {
                    Console.Write(myJagArray[i][j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        // принимает входной массив значений int и выводит все его элементы на консоль
        static void PrintArray(int[] myInts)
        {
            for (int i = 0; i < myInts.Length; i++)
            {
                Console.WriteLine($"Item {i} is {myInts[i]}");
            }
        }

        // заполняет массив значений string и возвращает его вызывающему коду
        static string[] GetStringArray()
        {
            string[] theStrings = { "Hello", "from", "GetStringArray" };
            return theStrings;
        }

        static void PassAndReciveArrays()
        {
            Console.WriteLine("=> Arrays as params and return values.");

            // Передать массив в качестве параметра.
            int[] ages = { 20, 22, 23, 0 };
            PrintArray(ages);
            // Получить массив как возвращаемое значение,
            string[] strs = GetStringArray();
            foreach (string str in strs)
            {
                Console.WriteLine(str);
            }
            Console.WriteLine();
        }

        static void SystemArrayFunctionality()
        {
            Console.WriteLine("=> Working with System.Array");

            // Инициализировать элементы при запуске.
            string[] gothicBands = { "Tones on Tail", "Bauhaus", "Sisters of Mercy" };

            // Вывести имена в порядке их объявления.
            Console.WriteLine("=> Here is the array: ");
            for (int i = 0; i < gothicBands.Length; i++)
            {
                // Вывести имя.
                Console.Write(gothicBands[i] + ", ");
            }
            Console.WriteLine("\n");

            // Обратить порядок следования элементов...
            Array.Reverse(gothicBands);
            Console.WriteLine("=> Reversed array: ");
            for (int i = 0; i < gothicBands.Length; i++)
            {
                Console.Write(gothicBands[i] + ", ");
            }
            Console.WriteLine("\n");

            // Удалить все элементы кроме первого.
            Console.WriteLine("Cleared out all except one...");
            Array.Clear(gothicBands, 1, 2);
            for (int i = 0; i < gothicBands.Length; i++)
            {
                Console.Write(gothicBands[i] + ", ");
            }
            Console.WriteLine();
        }
        /*
            Обратите внимание, что многие члены класса System.Array определены как статические
            и потому вызываются на уровне класса (примерами могут служить методы Array.Sort() и Array.Reverse()). 
            Методам подобного рода передается массив, подлежащий обработке. 
            Другие члены System.Array (такие как свойство Length) действуют
            на уровне объекта, поэтому могут вызываться прямо на типе массива. 
         */
    }
}
