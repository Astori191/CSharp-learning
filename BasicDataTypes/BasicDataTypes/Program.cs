using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace BasicDataTypes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=> Data Declarations:");
            LocalVarDeclarations();
            DefaultDeclarations();
            NewingDataTypes();
            ObjectFunctionality();
            DataTypesFunctionality();
            CharFuntionality();
            ParseFromString();
            ParseFromStringWithTryParse();
            UseDatesAndTimes();
            UseBigInteger();
            Console.ReadLine();
        }

        static void LocalVarDeclarations()
        {
            // типДанных имяПеременной = начальноеЗначение
            int myInt = 0;
            string myString = "This is my character data";

            //Допускается объявление нескольких переменных в одной строке
            bool b1 = true, b2 = false, b3 = b1;
            System.Boolean b4 = false;

            Console.WriteLine("Your data is : {0}, {1}, {2}, {3}, {4}, {5}", myInt, myString, b1, b2, b3, b4);
            Console.WriteLine();
        }

        static void DefaultDeclarations()
        {
            Console.WriteLine("=> Default Declarations: ");
            
            //default присваивает стандартное значение
            int myInt = default;
            Console.WriteLine("Your data is {0}", myInt);
            Console.WriteLine();
        }

        static void NewingDataTypes()
        {
            Console.WriteLine("Using new to create variables:");
            bool b = new bool(); // устанавливается в false
            int i = new int(); // устанавливается в 0
            double d = new double(); // устанавливается в 0

            DateTime dt = new DateTime(); // устанавливается в 1/1/0001 12.00.00
            Console.WriteLine("{0},{1},{2},{3}", b, i, d, dt);
            Console.WriteLine();
        }

        static void ObjectFunctionality()
        {
            Console.WriteLine("=> System.Object Functionality:");
            // ключевое слово int в действительности сокращение для
            // типа System.Int32, который наследует от System.Object следующие члены:
            Console.WriteLine("12.GetHashCode() = {0}", 12.GetHashCode());
            Console.WriteLine("12.Equals(23) = {0}", 12.Equals(23));
            Console.WriteLine("12.ToString() = {0}", 12.ToString());
            Console.WriteLine("12.GetType() = {0}", 12.GetType());
            Console.WriteLine();
        }

        static void DataTypesFunctionality()
        {
            Console.WriteLine("=> Data type Functionality");
            Console.WriteLine("Max of int: {0}", int.MaxValue);
            Console.WriteLine("Min of int: {0}", int.MinValue);
            Console.WriteLine("Max of double: {0}", double.MaxValue);
            Console.WriteLine("Min of double: {0}", double.MinValue);
            Console.WriteLine("double.Epsilon: {0}", double.Epsilon);
            Console.WriteLine("double.PositiveInfinity: {0}", double.PositiveInfinity);
            Console.WriteLine("double.NegativeInfinity: {0}", double.NegativeInfinity);
            Console.WriteLine("bool.FalseString: {0}", bool.FalseString);
            Console.WriteLine("bool.TrueString: {0}", bool.TrueString);
            Console.WriteLine();
        }

        static void CharFuntionality()
        {
            Console.WriteLine("=> char type Functionality:");
            char myChar = 'a';
            Console.WriteLine("char.IsDigit('a'): {0}", char.IsDigit(myChar));
            Console.WriteLine("char.IsLetter('a'): {0}", char.IsLetter(myChar));
            Console.WriteLine("char.IsWhiteSpace('Hello There', 5): {0}", char.IsWhiteSpace("Hello There", 5));
            Console.WriteLine("char.IsWhiteSpace('Hello There', 6): {0}", char.IsWhiteSpace("Hello There", 6));
            Console.WriteLine("char.IsPunctuation('?'): {0}", char.IsPunctuation('?'));
            Console.WriteLine();
        }

        static void ParseFromString()
        {
            // bool b = bool.Parse("Hello") - неправильно!  

            Console.WriteLine("=> Data type parsing:");
            bool b = bool.Parse("True");
            Console.WriteLine("Value of b: {0}", b); // вывод значения b
            double d = double.Parse("99,884");
            Console.WriteLine("Value of d: {0}", d);
            int i = int.Parse("8");
            Console.WriteLine("Value of i: {0}", i);
            char c = char.Parse("w");
            Console.WriteLine("Value of c: {0}", c);
            Console.WriteLine();
        }

        static void ParseFromStringWithTryParse()
        {
            Console.WriteLine("=> Data type parsing with TryParse:");

            if (bool.TryParse("True", out bool b)) ; 
            {
                Console.WriteLine("Value of b: {0}", b);
            }

            string value = "Hello";
            if (double.TryParse(value, out double d)) // d будет равно 0
            {
                Console.WriteLine("Value of d: {0}", d);
            }
            else
            {
                Console.WriteLine("Failed to convert the input ({0}) to a double", value);
            }

            Console.WriteLine(); 
        }

        static void UseDatesAndTimes()
        {
            Console.WriteLine("=> Dates and Times");
            // этот конструктор принимает год, месяц и день.
            DateTime dt = new DateTime(2015, 10, 17); 
            Console.WriteLine("The day of {0} is {1}", dt.Date, dt.DayOfWeek);

            // сейчас месяц Декабрь
            dt = dt.AddMonths(2); 
            Console.WriteLine("Daylight savings: {0}", dt.IsDaylightSavingTime());
            TimeSpan ts = new TimeSpan(4,30,0);
            Console.WriteLine(ts);

            // Вычесть 15 минут из текущего значения TimeSpan и вывести результат.
            Console.WriteLine(ts.Subtract(new TimeSpan(0,15,0)));
            Console.WriteLine();
        }
        
        static void UseBigInteger()
        {
            Console.WriteLine("=> Use BigInteger:");
            BigInteger biggy = BigInteger.Parse("9999999999999999999999999999999999999999999999");
            Console.WriteLine("Value of biggy is {0}", biggy);
            Console.WriteLine("Is biggy an even value?: {0}", biggy.IsEven);
            Console.WriteLine("Is biggy a power of two?: {0}", biggy.IsPowerOfTwo); // biggy - степень 2?

            BigInteger reallyBig = BigInteger.Multiply(biggy, BigInteger.Parse("8888888888888888888888888888888888888888888"));
            Console.WriteLine("Value of reallyBig is: {0}", reallyBig);

            BigInteger reallyBig2 = biggy + reallyBig;
            Console.WriteLine("Value of reallyBig2 is: {0}", reallyBig2);

        }
    }
}
