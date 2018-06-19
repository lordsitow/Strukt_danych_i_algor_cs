using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;

namespace ConsoleApp2
{
    public class Heap
    {
        private IList<int> data;
        public int HeapSize;

        public Heap()
        {
            data = new List<int>();
            //dodaję zerowy element ponieważ zaczynamy wypełniać tablicę od indeksu 1
            data.Add(0);
        }

        public void DispData(Heap _heap)
        {
            foreach (int element in _heap.data)
            {
                Console.WriteLine(element);
            }
        }

        private void Swap(int index0, int index1)
        {
            int aux = data[index0];
            data[index0] = data[index1];
            data[index1] = aux;
        }

        public void Insert(int n)
        {
            HeapSize++;
            data.Add(n);
            //data[HeapSize] == n;
            int Index = HeapSize;
            while (Index > 1)
            {
                if (n > data[Index / 2]) Swap(Index, Index / 2);
                else break;
                Index = Index / 2;
            }
        }

        public void MoveDownHeap(int topIndex)
        {
            int index = topIndex;
            int n = data[topIndex];
            while (index * 2 <= HeapSize)
            {
                int indexGreater;
                if ((index * 2 < HeapSize) && (data[index * 2 + 1] > data[index * 2]))
                    indexGreater = index * 2 + 1;
                else
                    indexGreater = index * 2;
                if (n < data[indexGreater])
                    Swap(index, indexGreater);
                else break;
                index = indexGreater;
            }
        }

        public void DeleteMax()
        {
            data[1] = data[HeapSize];
            data.RemoveAt(HeapSize);
            HeapSize--;
            MoveDownHeap(1);
        }

        public void Construct(int index)
        {
            if (2 * index <= HeapSize / 2) Construct(2 * index);
            if (2 * index + 1 <= HeapSize / 2) Construct(2 * index + 1);
            MoveDownHeap(index);
        }

        public void Check()
        {
            for (int i = 1; i <= HeapSize / 2; i++)
            {
                if (data[i] < data[2 * i]) throw new Exception("Error in Heap");
                if (2 * i + 1 <= HeapSize)
                    if (data[i] < data[2 * i + 1]) throw new Exception("Error in Heap");
            }
        }
        public int Max()
        {
            return data[1];
        }
        public static void doktor_edker()
        {
            Heap heap = new Heap();
            int a = 0;
            int b = 2;
            TimeSpan[] czasy;
            int iter = 0;
            while (iter != 9)
            {
                Console.Clear();
                Console.WriteLine("Witaj, którą czynność chcesz wykonać:");
                Console.WriteLine("1.Testowanie czasów Kopcowania");
                Console.WriteLine("2.Usuń największą wartość w kopcu");
                Console.WriteLine("3.Wyświetl kopiec");
                Console.WriteLine("9.Wyjdź do menu głównego");
                heap.Check();
                if (!Int32.TryParse(Console.ReadLine(), out iter))
                {
                    continue;
                }
                if (iter == 1)
                {
                    Console.WriteLine("Dla jakiej ilości liczb chcesz przetestować czasy");
                    Int32.TryParse(Console.ReadLine(), out a);
                    czasy = new TimeSpan[a];
                    Random RandomNumber = new Random();
                    while (a != b)
                    {
                        var watch=Stopwatch.StartNew();
                        for (int i = 0; i < b; i++)
                        {
                            heap.Insert(RandomNumber.Next(1000));
                        }
                        watch.Stop();
                        czasy[b] = watch.Elapsed;
                        b++;
                    }
                    ///////////////////////// Wyświetlanie Danych Wyjściowych
                    Console.WriteLine("\n To są czasy sortowania dla kolejnych elementów");
                    for (int i = 0; i < czasy.Length; i++)
                    {
                        Console.WriteLine("{0}", czasy[i]);
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
                            for (int i = 0; i < czasy.Length; i++)
                            {
                                zapis_dane.WriteLine(czasy[i]);
                            }

                        }
                    }
                }
                if (iter == 2) {heap.DeleteMax();}
                if (iter == 3) {heap.DispData(heap);}
                
                Console.ReadLine();
                
            }
        }
    }
}
