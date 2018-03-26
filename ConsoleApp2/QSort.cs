using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace ConsoleApp2
{
    class QSort
    {
        private static object l;

        public static void Sort()
        {
            //////////wczytanie danych
            string linijka;
            Console.WriteLine("Podaj ścieżkę pliku zdanymi:");
            string miejsce_odczytu = Console.ReadLine();
            Console.WriteLine("Podaj ścieżkę pliku do zapisania:");
            //"C:/Users/Arek/source/repos/Strukt_danych_i_algor_cs/ConsoleApp2/do_sortowania.txt"
            string miejsce_zapisu = Console.ReadLine();
            //"C:/Users/Arek/source/repos/Strukt_danych_i_algor_cs/ConsoleApp2/posortowane.txt"
            using (StreamReader odczytane_dane = new StreamReader(miejsce_odczytu))
            {
                linijka = odczytane_dane.ReadLine();
            }
            ///////////////////////// Konwersja stringa na int[]
            int[] dane = linijka.Split(';').Select(n => Convert.ToInt32(n)).ToArray();

            ///////////////////////// Wyświetlanie Danych Wejściowych
            Console.WriteLine("\n To są dane wejściowe:");
            for (int i = 0; i < dane.Length; i++)
            {
                Console.Write("{0};", dane[i]);
            };
            /////////// Quicksort i pomiar czasu
            var watch = Stopwatch.StartNew();
            //////////////
            QSHelper.QuickSort(dane, 0, dane.Length-1);
            /////
            watch.Stop();
            ///////////////////////// Wyświetlanie Danych
            Console.WriteLine("\n \n To są dane wyjściowe:");
            for (int i = 0; i < dane.Length; i++)
            {
                Console.Write("{0};", dane[i]);
            }
            Console.WriteLine("\n \n Czas pracy:{0}[ms]:", watch.Elapsed);
            /////////////////////Zapis do pliku

            using (StreamWriter zapis_dane = new StreamWriter(miejsce_zapisu))
            {
                for (int i = 0; i < dane.Length; i++)
                {
                    zapis_dane.Write("{0};", dane[i]);
                }
            }
        }
    }
}
