using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.CSharp;
using System.Numerics;
using System.Diagnostics;

namespace ConsoleApp2
{
    class N_Silnia
    {
        public static void Calculate()
        {
            Console.Clear();
            Console.WriteLine("Silnie z jakiej liczby chcesz policzyć:");


            int x = 0;
            try
            {
                x = Int32.Parse(Console.ReadLine());
            }
            catch
            {
                return;
            }
            BigInteger Liczenie(BigInteger a)
            {
                if (a == 0) { return 1; }
                else if (a == 1) { return 1; }
                else if (a == 2) { return 2; }
                return a * Liczenie(a - 1);
            }
            //////////Wywołanie obliczenia i pomiar czasu
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();

            var watch = Stopwatch.StartNew();
            var before = Process.GetCurrentProcess().VirtualMemorySize64;

            BigInteger y = Liczenie(x);
            var after = Process.GetCurrentProcess().VirtualMemorySize64;
            watch.Stop();
            ////////////Wyświetlenie wyników
            Console.WriteLine("Silnia z {0} to:{1}", x,y);
            Console.WriteLine("Czas pracy:{0}[us]" ,watch.Elapsed);
            Console.WriteLine("Zużyta pamięć:{0}[us]", (after-before));
        }
    }
}
