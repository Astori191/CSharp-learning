using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImplicitlyTypedLocalVars
{
    /*class ThisWillNeverComplete
    {
        //Ошибка! Ключевое слово var не может применяться к полям!
        private var myInt = 10;

        //Ошибка! Должно быть присвоено значение!
        private var myData;

        //Ошибка! Значение должно присваиваться в самом объявлении!
        private var myInt;
        myInt = 0;

        //Ошибка! Нельзя присваивать null в качестве начального значения!
        var myObj = null;

        //Ошибка! Ключевое слово var не может применяться к возвращаемому значению или типу параметра!
        private var MyMethod(var x, var y) { }
    }*/

    internal class Program
    {

        static void Main(string[] args)
        {

            //Допустимо, если SportsCar имеет ссылочный тип!
            /* 
            * var myCar = new SportsCar();
            * myCar = null; 
            */

            // Также нормально!
            var myInt = 0;
            var anotherInt = myInt;

            string myString = "Wake up!";
            var myData = myString;

            DeclareImplicitVars();
            LinqQueryOverInts();

            Console.ReadLine();
        }

        static void DeclareExplicitVars()
        {
            // Явно типизированные локальные переменные объявляются следующим образом:
            // типДанных имяПеременной = начальноеЗначение;
            int myInt = 0;
            bool myBool = false;
            string myString = "Time, marches on...";
        }

        static void DeclareImplicitVars()
        {
            // Неявно типизированные локальные переменные объявляются следующим образом:
            // var имяПеременной = начальноеЗначение;
            var myInt = 0;
            var myBool = false;
            var myString = "Time, marches on...";

            // Вывести имена лежащих в основе типов.
            Console.WriteLine($"myInt is a: {myInt.GetType().Name}");
            Console.WriteLine($"myBool is a: {myBool.GetType().Name}");
            Console.WriteLine($"myString is a: {myString.GetType().Name}");

            Console.WriteLine();
        }

        static int GetAnInt()
        {
            var retVal = 9;
            return retVal;
        }

        static void ImplicitTypingIsStrongTyping()
        {
            // Компилятору известно, что s имеет тип System.String.
            var s = "This variable can only hold string data!";
            s = "This is fine..";

            // Можно обращаться к любому члену лежащего в основе типа,
            string upper = s.ToUpper();

            // Ошибка! Присваивание числовых данных строке не допускается!
            // s = 44;
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

            // К какому же типу относится subset?
            Console.WriteLine($"subset is a: {subset.GetType().Name}");
            Console.WriteLine($"subset is defined in: {subset.GetType().Namespace}");
        }
    }
}
