using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fact
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите число:");
            int n = Int32.Parse(Console.ReadLine());
            int r = 1;

            while (n > 0) {
                r += r * (n - 1);
                n--;
            }

            Console.WriteLine("{0}", r);
            Console.ReadLine();
        }
    }
}
