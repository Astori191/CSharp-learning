using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeConversions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with type conversions *****");
            // Добавить две переменные типа short и вывести результат,
            short numb1 = 9, numb2 = 10;
            Console.WriteLine("{0} + {1} = {2}", numb1, numb2, Add(numb1, numb2));
            Console.WriteLine();

            // Следующий код вызовет ошибку на этапе компиляции т.к результат
            // выходит за пределы диапазона допустимых значений для типа short
            //short numb1 = 30000, numb2 = 30000;
            //short answer = Add(numb1, numb2);

            // Cужающие преобразования приводят к ошибкам на этапе компиляции
            //byte myByte = 0;
            //int myInt = 200;
            //myByte = myInt;

            short numb3 = 30000, numb4 = 30000;

            // Явно привести int к short (и разрешить потерю данных).
            short answer = (short)Add(numb3, numb4);
            Console.WriteLine($"{numb3} + {numb4} = {answer}");

            NarrowingAttempt();
            ProcessBytes();
            ProcessBytesMod();
            ProcessBytesMod2();

            Console.ReadLine();
        }

        static int Add(int n1, int n2)
        {
            return n1 + n2;
        }

        static void NarrowingAttempt()
        {
            byte myByte = 0;
            int myInt = 200;
            // Явно привести int к byte (без потери данных).
            myByte = (byte)myInt;
            Console.WriteLine($"Value of myByte is {myByte}");

            Console.WriteLine();
        }

        static void ProcessBytes()
        {
            byte b1 = 100;
            byte b2 = 250;
            byte sum = (byte)Add(b1, b2);
            Console.WriteLine($"sum = {sum}");

            Console.WriteLine();
        }

        static void ProcessBytesMod()
        {
            byte b1 = 100;
            byte b2 = 250;

            //На этот раз сообщить компилятору о необходимости добавления
            // кода CIL, необходимого для генерации исключениях если возникает
            // переполнение или потеря значимости.
            try
            {
                byte sum = checked((byte)Add(b1, b2));
                Console.WriteLine($"sum = {sum}");
            }
            catch (OverflowException ex)
            {
                Console.WriteLine(ex.Message);
            }
            // или
            try
            {
                // проверка на переполнение целого блока
                checked
                {
                    byte sum = checked((byte)Add(b1, b2));
                    Console.WriteLine($"sum = {sum}");
                }
            }
            catch (OverflowException ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine();
        }

        static void ProcessBytesMod2()
        {
            byte b1 = 100;
            byte b2 = 250;

            // Предполагая, что флаг /checked активизирован, этот блок
            // не будет генерировать исключение времени выполнения,
            unchecked
            {
                byte sum = (byte)(b1 + b2);
                Console.WriteLine($"sum = {sum}");
            }
        }
    }
}
