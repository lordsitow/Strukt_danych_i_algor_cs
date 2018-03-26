using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Numerics;
namespace ConsoleApp2
{
    class Fibonacci
    {
        public static void Calculate()
        {
            Console.WriteLine("Który element ciągu fibo chcesz policzyć:");
            int x = 0;
            try
            {
                x = Int32.Parse(Console.ReadLine());
            }
            catch
            {
                return;
            }
            BigInteger Liczenie(int a)
            {
                if (a == 0) { return 0; }
                if (a == 1) { return 1; }
                return Liczenie(a - 2) + Liczenie(a - 1);
            }
            /////////////liczenie fibo i pomiar czasu
            var watch = Stopwatch.StartNew();
            BigInteger y = Liczenie(x);
            watch.Stop();
            //////////////Wyświetlenie wyników
            Console.Write("{0} element ciągu fibo to: {1}", x, y);
            Console.WriteLine("Czas pracy:{0}[us]", watch.Elapsed);
        }
    }
}
