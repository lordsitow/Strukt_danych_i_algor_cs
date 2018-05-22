using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ConsoleApp2
{
    
    public class DrzewoSlownik
    {
        public static void slownik_pl_ang()
        {
            int a = 0;
            //Console.WriteLine("Podaj maksymalną ilosc słów w słowniku");
            int b = 1000000;//(Convert.ToInt32(Console.ReadLine())) * 2;
            string[] wczytane_slowa = new string[b];
            System.TimeSpan[] czasy_szukania;
            SortedDictionary<string,string> slownik = new SortedDictionary<string, string>();
            string[] do_wyswietlania = new string[2];
            Console.Clear();
            while (a != 9)
            {
                ////////////////////// MENU
                Console.Clear();
                Console.WriteLine("Witaj, którą czynność chcesz wykonać:");
                Console.WriteLine("1.Dodaj słowo");
                Console.WriteLine("2.Usuń słowo");
                Console.WriteLine("3.Wyświetl słownik");
                Console.WriteLine("4.Wyszukaj słowo");
                Console.WriteLine("5.Załaduj słownik");
                Console.WriteLine("9.Wyjdź do menu głównego");

                if (!Int32.TryParse(Console.ReadLine(), out a))
                {
                    continue;
                }
                if (a == 1)
                {
                    ///////////////////Wprowadzenie slowa
                    Console.WriteLine("Wprowadź polskie slowo");
                    string polskie = Console.ReadLine();
                    Console.WriteLine("Wprowadź angielskie tłumaczenie");
                    string angielskie = Console.ReadLine();
                    ///////////////////Nowy element listy
                    var watch = Stopwatch.StartNew();
                    slownik.Add(polskie,angielskie);
                    watch.Stop();
                    Console.WriteLine("Czas wstawiania to:{0}", watch.Elapsed);
                    Console.ReadKey();
                }
                if (a == 2)
                {
                    ///////////Usuwanie
                    Console.WriteLine("Jaki wyraz chcesz usunąć?");
                    string do_unumiecia = Console.ReadLine();
                    try
                    {
                        slownik.Remove(do_unumiecia);
                    }
                    catch
                    {
                        Console.WriteLine("Nie znaleziono wyrazu");
                    }
                }
                if (a == 3)
                {
                    foreach (KeyValuePair<string,string> x in slownik)
                    {
                        Console.WriteLine("Polskie slowo:{0} angielskie tłmaczenie:{1}", x.Key,x.Value);
                    }
                    Console.ReadKey();
                }
                if (a == 4)////WYSZUKIWANIE SLOWA
                {
                    Console.WriteLine("Jakie słowo chcesz wyszukać?");
                    string do_wyszukania = Console.ReadLine();
                    Console.WriteLine("Chcesz wyszukać słowo \"polskie\" czy \"angielskie?\"");
                    string rodzaj_do_wyszukania = Console.ReadLine();
                    if (rodzaj_do_wyszukania == "polskie")
                    {
                        var watch = Stopwatch.StartNew();
                        slownik.TryGetValue(do_wyszukania, out string znalezione);
                        Console.WriteLine("Znaczenie polskie:{0}, Znaczenie angielskie:{1}", do_wyszukania, znalezione);
                        watch.Stop();
                        Console.WriteLine("Znaczenie polskie:{0}, Znaczenie angielskie:{1}, Czas szukania słowa:{2}", do_wyszukania, znalezione, watch.Elapsed);
                    }
                    else if (rodzaj_do_wyszukania == "angielskie")
                    {
                        slownik.TryGetValue(do_wyszukania,out string znalezione);
                        Console.WriteLine("Znaczenie polskie:{0}, Znaczenie angielskie:{1}", znalezione, do_wyszukania);
                    }
                    Console.ReadKey();
                }
                if (a == 5)
                {
                    ///////////////Odczyt z pliku
                    Console.WriteLine("Ile wyrazów chcesz wczytać?");
                    int ilosc = Convert.ToInt32(Console.ReadLine());
                    //////C:\Users\Arek\source\repos\Strukt_danych_i_algor_cs\ConsoleApp2\slownik_pl.txt
                    Console.WriteLine("Podaj scieżkę dostępu do polskich słów w pliku txt");
                    string miejsce_odczytu = Console.ReadLine();
                    using (StreamReader odczytane_dane = new StreamReader(miejsce_odczytu))
                    {
                        for (int i = 0; i < ilosc; i++)

                        { if (odczytane_dane.ReadLine() != null) { wczytane_slowa[i] = odczytane_dane.ReadLine(); } else { continue; } }

                    }
                    ////////////C:\Users\Arek\source\repos\Strukt_danych_i_algor_cs\ConsoleApp2\slownik_eng.txt
                    Console.WriteLine("Podaj scieżkę dostępu do angielskich słów w pliku txt");
                    miejsce_odczytu = Console.ReadLine();
                    using (StreamReader odczytane_dane = new StreamReader(miejsce_odczytu))
                    {
                        for (int i = ilosc; i < 2 * ilosc; i++)
                        { if (odczytane_dane.ReadLine() != null) { wczytane_slowa[i] = odczytane_dane.ReadLine(); } else { continue; } }
                    }
                    for (int i = 0; i < ilosc; i++)
                    {
                        slownik.Add(wczytane_slowa[i],wczytane_slowa[i + ilosc]);
                    }
                    ///////////////////TESTOWANIE CZASOW SZUKANIA
                    Console.WriteLine("Czy chcesz sprawdziś czasy wyszukiwania?[y/n]");
                    string czy = Console.ReadLine();
                    if (czy == "y")
                    {
                        string[] testowe = new string[ilosc];
                        Random losowa = new Random();
                        for (int i = 0; i < ilosc; i++)
                        {
                            testowe[i] = wczytane_slowa[losowa.Next(0, ilosc)];
                        }
                        czasy_szukania = new TimeSpan[ilosc];
                        for (int i = 0; i < 1000; i++)
                        {
                            string do_wyszukania = testowe[i];
                            var watch = Stopwatch.StartNew();
                            slownik.TryGetValue(do_wyszukania, out string znalezione);
                            watch.Stop();
                            czasy_szukania[i] = watch.Elapsed;
                            Console.WriteLine(watch.Elapsed);

                        }
                        /////////////ZAPIS CZASOW DO PLIKU
                        Console.WriteLine("Czy chcesz zapisać czasy wyszukiwania to pliku?[y/n]");
                        czy = Console.ReadLine();
                        if (czy == "y")
                        {
                            Console.WriteLine("Podajściezkę do zapisu pliku");
                            string path = Console.ReadLine();
                            /////string path = @"C:\Users\Arek\source\repos\Strukt_danych_i_algor_cs\ConsoleApp2\czasy_szukania.txt";
                            File.Create(path).Dispose();
                            using (StreamWriter sr = new StreamWriter(path))
                            {
                                for (int i = 0; i < 1000; i++)
                                { sr.WriteLine(czasy_szukania[i]); }
                            }
                        }
                        Console.ReadKey();
                    }
                    else { continue; }
                }
            }
        }
    }
}