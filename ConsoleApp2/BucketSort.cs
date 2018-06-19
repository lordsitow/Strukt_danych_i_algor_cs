using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace ConsoleApp2
{
    class Bucketsort
    {
        public static void Sort()
        {
            //////////Deklarodanie zmiennych
            int a;
            int[] dane1;
            int[] dane;
            Console.Clear();
            Console.WriteLine("Ile liczb chcesz posegregować");
            Int32.TryParse(Console.ReadLine(), out a);
            dane1 = new int[a];
            TimeSpan[] czasy_sortowania = new TimeSpan[a];
            Random losowa = new Random();
            ///////////Losowanko liczb
            for (int i = 0; i < a; i++)
            { dane1[i] = losowa.Next(0, 997); }
            Console.WriteLine("\n To są dane wejściowe:");
            /////////Wyswietlanie danych weściowych
            for (int i = 0; i < dane1.Length; i++)
            {
                Console.Write("{0};", dane1[i]);
            }
            ////Petla
            for (int p = 2; p < dane1.Length; p++)
            {
                dane = new int[p];
                for (int l = 0; l < p; l++)
                { dane[l] = dane1[l]; }
                    /////Rozpoczecie pomiaru czasu
                    var watch = Stopwatch.StartNew();
                    ///Bucket sort
                    int minvalue = dane[0];
                    int maxvalue = dane[0];

                    for (int i = 1; i < dane.Length; i++)
                    {
                        if (dane[i] > maxvalue)
                            maxvalue = dane[i];
                        if (dane[i] < minvalue)
                            minvalue = dane[i];
                    }

                    List<int>[] bucket = new List<int>[maxvalue - minvalue + 1];

                    for (int i = 0; i < bucket.Length; i++)
                    {
                        bucket[i] = new List<int>();
                    }

                    for (int i = 0; i < dane.Length; i++)
                    {
                        bucket[dane[i] - minvalue].Add(dane[i]);
                    }

                    int k = 0;
                    for (int i = 0; i < bucket.Length; i++)
                    {
                        if (bucket[i].Count > 0)
                        {
                            for (int j = 0; j < bucket[i].Count; j++)
                            {
                                dane[k] = bucket[i][j];
                                k++;
                            }
                        }
                    }
                    ///////// koniec pomiaru czasu
                    watch.Stop();
                    czasy_sortowania[p] = watch.Elapsed;
             }
            /////////////////////////
            
            ///////////////////////// Wyświetlanie Danych Wyjściowych
            Console.WriteLine("\n To są czasy sortowania dla kolejnych elementów");
            for (int i = 0; i < czasy_sortowania.Length; i++)
            {
                Console.WriteLine("{0}", czasy_sortowania[i]);
            }
            //////////zapis do pliku 
            Console.WriteLine("czy chcesz zapisać czasy szukania do pliku txt?[y/n]");
            string czy = Console.ReadLine();
            if (czy == "y")
            {
                Console.WriteLine("podaj sciezke do pliku txt");
                czy = Console.ReadLine();
                using (StreamWriter zapis_dane = new StreamWriter(czy))
                {
                    for (int i = 0; i < czasy_sortowania.Length; i++)
                    {
                        zapis_dane.WriteLine(czasy_sortowania[i]);
                    }

                }
            }
                /////////////Koniec funkcji
        }
    }
}