using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Guwna
    {
        static void Main(string[] args)
        {
            int a=0;
            while ( a  != 40)
            {
                Console.Clear();
                Console.WriteLine("Arkadiusz Tokarski 226742");
                Console.WriteLine("Witaj, którą czynność chcesz wykonać:");
                Console.WriteLine("1.BubbleSort z pliku txt");
                Console.WriteLine("2.Policz n-ty element ciagu fibonacciego");
                Console.WriteLine("3.Oblicz silnię z n");
                Console.WriteLine("4.QSort z pliku txt");
                Console.WriteLine("5.Drzewo binarne");
                Console.WriteLine("6.Kopiec");
                Console.WriteLine("7.ListoSlownik pl->ang");
                Console.WriteLine("8.DrzewoSlownik pl->ang");
                Console.WriteLine("9.BucketSort");
                Console.WriteLine("40.Zakończ program");
                Console.WriteLine("");

                if(!Int32.TryParse(Console.ReadLine(),out a))
                {
                    continue;
                }

                if (a == 1) { BubbleSort.Sort(); }
                else if (a == 2) { Fibonacci.Calculate(); }
                else if (a == 3) { N_Silnia.Calculate();  }
                else if (a == 4) { QSort.Sort(); }
                else if (a == 5) { wykonywujacy.program(); }
                else if (a == 6) { Heap.doktor_edker(); }
                else if (a == 7) { ListoSlownik.slownik_pl_ang(); }
                else if (a == 8) { DrzewoSlownik.slownik_pl_ang(); }
                else if (a == 9) { Bucketsort.Sort(); }
                Console.ReadKey();
            }
        }
        }
}
