using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunWithStrings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Strings *****");
            Console.WriteLine();

            BasicStringFunctionality();
            StringConcatenation();
            EscapeChars();
            StringEquality();
            StringEqualitySpecifyingCompareRules();
            StringAreImmutable();
            StringAreImmutable2();
            FunWithStringBuilder();
            StringInterpolation();
            Console.ReadLine();
        }

        private static void BasicStringFunctionality()
        {
            Console.WriteLine("=> Basic String functionality:");
            string firstName = "Freddy";

            Console.WriteLine("Value of firstName: {0}", firstName); // Значение firstName.
            Console.WriteLine("firstName has {0} characters", firstName.Length); // Длина firstname.
            Console.WriteLine("firstName in uppercase: {0}", firstName.ToUpper()); // firstName в верхнем регистре.
            Console.WriteLine("firstName in lowercase: {0}", firstName.ToLower()); // firstName в нижнем регистре.
            Console.WriteLine("firstName contains the letter y?: {0}", firstName.Contains("y")); // Содержит ли firstName букву у?
            Console.WriteLine("firstName after repace: {0}", firstName.Replace("dy", "o")); // ?

            Console.WriteLine();
        }

        private static void StringConcatenation()
        {
            Console.WriteLine("=> StringConcatenation:");
            string s1 = "Programming the ";
            string s2 = "PsychoDrill (PTP)";

            string s3 = s1 + s2; // конкатенация
            string s4 = string.Concat(s1, s2);

            Console.WriteLine(s3);
            Console.WriteLine(s4);

            Console.WriteLine();
        }

        private static void EscapeChars()
        {
            Console.WriteLine("=> Escape characters:\a"); // \a - звуковой сигнал
            string strWithTabs = "Model\tColor\tSpeed\tPetName\a"; // \t - табуляция   
            Console.WriteLine(strWithTabs);

            Console.WriteLine("Everyone loves \"Hello world\"\a"); // \" - символ двойной ковычки
            Console.WriteLine("C:\\MyApp\\bin\\Debug\a"); // \\ - символ обратной косой черты

            // Добавить четыре пустых строки и снова выдать звуковой сигнал.
            Console.WriteLine("All finished. \n\n\n\a");

            // Следующая строка воспроизводится дословно
            // @ - дословные сроки, обработка управляющих последовательностей отключена
            Console.WriteLine(@"C:\MyApp\bin\Debug");

            // При использовании дословных строк пробельные символы предохраняются,
            string myLongString = @"This is a very 
                                                very
                                                    very
                                                        long string";
            Console.WriteLine(myLongString);
            // Применяя дословные строки можно напрямую вставлять символы двойной кавычки
            Console.WriteLine(@"Cerebus said ""Darrr! Pret-ty sun-sets""");

            Console.WriteLine();
        }

        static void StringEquality()
        {
            Console.WriteLine("=> String equality:");
            string s1 = "Hello!";
            string s2 = "Yo!";
            Console.WriteLine("s1 = {0}", s1);
            Console.WriteLine("s2 = {0}", s2);
            Console.WriteLine();

            // проверить строки на равенство
            Console.WriteLine("s1 == s2: {0}", s1 == s2);
            Console.WriteLine("s1 == Hello!: {0}", s1 == "Hello!");
            Console.WriteLine("s1 == HELLO!: {0}", s1 == "HELLO!");
            Console.WriteLine("s1 == hello!: {0}", s1 == "hello!");
            Console.WriteLine("s1.Equals(s2): {0}", s1.Equals(s2));
            Console.WriteLine("\"Yo!\".Equals(s2): {0}", "Yo!".Equals(s2));

            Console.WriteLine();
        }

        static void StringEqualitySpecifyingCompareRules()
        {
            Console.WriteLine("=> String equality (Case Insensitive:");
            string s1 = "Hello!";
            string s2 = "HELLO!";
            Console.WriteLine("s1 = {0}", s1);
            Console.WriteLine("s2 = {0}", s2);
            Console.WriteLine();

            // Проверить результаты изменения стандартных правил сравнения.
            Console.WriteLine("Default rules: s1={0}, s2={1}, s1.Equals(s2): {2}", s1, s2, s1.Equals(s2));
            Console.WriteLine("Ignore case: s1.Equals(s2, StringComparison.OrdinalIgnoreCase): {0}",
                s1.Equals(s2, StringComparison.OrdinalIgnoreCase));
            Console.WriteLine("Ignore case, Invariant Culture: s1.Equals(s2, StringComparison.InvariantCultureIgnoreCase): {0}",
                s1.Equals(s2, StringComparison.InvariantCultureIgnoreCase));

            Console.WriteLine();

            Console.WriteLine("Default rules: s1={0}, s2={1}, s1.IndexOf(\"E\"): {2}",
                s1, s2, s1.IndexOf("E"));
            Console.WriteLine("Ignore case: s1.IndexOf(\"E\",StringComparison.OrdinalIgnoreCase): {0}",
                s1.IndexOf("E", StringComparison.OrdinalIgnoreCase));
            Console.WriteLine("Ignore case, Invarariant Culture: si.IndexOf(\"E\",StringComparison.InvanantCultureIgnoreCase): {0}",
                s1.IndexOf("E", StringComparison.InvariantCultureIgnoreCase));

            Console.WriteLine();
        }

        static void StringAreImmutable()
        {
            // Установить начальное значение для строки,
            string s1 = "This is my main string";
            Console.WriteLine("s1 = {0}", s1);

            // Преобразована ли строка si в верхний регистр?
            string upperString = s1.ToUpper();
            Console.WriteLine("upperString = {0}", upperString);

            // Нет! Строка si осталась в том же виде!
            Console.WriteLine("s1 = {0}", s1);
        }

        static void StringAreImmutable2()
        {
            string s2 = "My other string";
            Console.WriteLine("s2 = {0}", s2);

            s2 = "My new other string";
            Console.WriteLine("s2 = {0}", s2);

            Console.WriteLine();
        }

        static void FunWithStringBuilder()
        {
            Console.WriteLine("=> Using the StringBuilder:");
            // Создать экземпляр StringBuilder с исходным размером в 256 символов.
            StringBuilder sb = new StringBuilder("***Fantastic Games***", 256);
            sb.Append("\n");
            sb.AppendLine("Half-life");
            sb.AppendLine("Morrowind");
            sb.AppendLine("Deus Ex" + "2");
            sb.AppendLine("System Shock");
            Console.WriteLine(sb.ToString());

            sb.Replace("2", " Invisible War");
            Console.WriteLine(sb.ToString());
            Console.WriteLine("sb has {0} chars.", sb.Length);

            Console.WriteLine();
        }

        static void StringInterpolation()
        {
            // Некоторые локальные переменные будут включены в крупную строку.
            int age = 4;
            string name = "Soren";

            // Использование синтаксиса с фигурными скобками.
            string greeting = string.Format("Hello {0} you are {1} years old.", name.ToUpper(), age);

            // Использование интерполяции строк.
            string greeting2 = $"\tHello {name.ToUpper()} you are {age} years old.";
            Console.WriteLine(greeting2);

            Console.WriteLine();
        }


    }
}
