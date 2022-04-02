using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunWithLocalFunctions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(AddWrapper(5, 7));
        }
        static int Add(int x, int y)
        {
            // выполнить проверку здесь
            return x + y;

        }
        static int AddWrapper(int x, int y)
        {
            // выполнить проверку здесь
            return Add();
            int Add()
            {
                return x + y;
            }
        }
    }
}
