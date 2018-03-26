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
                Console.WriteLine("Witaj, którą czynność chcesz wykonać:");
                Console.WriteLine("1.BubbleSort z pliku txt");
                Console.WriteLine("2.Policz n-ty element ciagu fibonacciego");
                Console.WriteLine("3.Oblicz silnię z n");
                Console.WriteLine("4.QSort z pliku txt");
                Console.WriteLine("5.BinaryTree");
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
                else if (a == 5)
                {
                    BinaryTree b = new BinaryTree();

                    b.insert(1);
                    b.insert(6);
                    b.insert(2);
                    b.insert(4);
                    b.insert(5);
                    b.insert(3);

                    b.display();
                }
                Console.ReadKey();
            }
        }
        }
}
