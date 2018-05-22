using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class BinaryTree
    {
        private Node1 root;
        private int count;

        public BinaryTree()
        {
            root = null;
            count = 0;
        }
        public bool isEmpty()
        {
            return root == null;
        }

        public void insert(int d)
        {
            if (isEmpty())
            {
                root = new Node1(d);
            }
            else
            {
                root.insertData(ref root, d);
            }

            count++;
        }

        public bool search(int s)
        {
            return root.search(root, s);
        }

        public bool isLeaf()
        {
            if (!isEmpty())
                return root.isLeaf(ref root);

            return true;
        }

        public void display()
        {
            if (!isEmpty())
                root.display(root);
        }

        public int Count()
        {
            return count;
        }
    }

    class Node1
    {
        private int number;
        public Node1 rightLeaf;
        public Node1 leftLeaf;

        public Node1(int value)
        {
            number = value;
            rightLeaf = null;
            leftLeaf = null;
        }

        public bool isLeaf(ref Node1 node)
        {
            return (node.rightLeaf == null && node.leftLeaf == null);

        }

        public void insertData(ref Node1 node, int data)
        {
            if (node == null)
            {
                node = new Node1(data);

            }
            else if (node.number < data)
            {
                insertData(ref node.rightLeaf, data);
            }

            else if (node.number > data)
            {
                insertData(ref node.leftLeaf, data);
            }
        }

        public bool search(Node1 node, int s)
        {
            if (node == null)
                return false;

            if (node.number == s)
            {
                return true;
            }
            else if (node.number < s)
            {
                return search(node.rightLeaf, s);
            }
            else if (node.number > s)
            {
                return search(node.leftLeaf, s);
            }

            return false;
        }

        public void display(Node1 n)
        {
            if (n == null)
                return;

            display(n.leftLeaf);
            Console.Write(" " + n.number);
            display(n.rightLeaf);
        }
    }
    class wykonywujacy
    {
        public static void program()
        {
            BinaryTree b = new BinaryTree();
            int a = 0;
            while (a != 9)
            {
                Console.Clear();
                Console.WriteLine("Witaj, którą czynność chcesz wykonać:");
                Console.WriteLine("1.Wprowadź wartosć do drzewa");
                Console.WriteLine("2.przeszukaj drzewo");
                Console.WriteLine("3.Wyświetl drzewo");
                Console.WriteLine("4.Wprowadź 100 losowych wartości z przedziału 0-1000");
                Console.WriteLine("9.Powrót do menu głównego");


                if (!Int32.TryParse(Console.ReadLine(), out a))
                {
                    continue;
                }

                if (a == 1)
                {
                    Console.WriteLine("Jaką wartosć chcesz wprowadzić?");
                    int q = Int32.Parse(Console.ReadLine());
                    b.insert(q);
                }
                if (a == 2)
                {
                    Console.WriteLine("Jaką wartosć chcesz znaleść?");
                    int q = Int32.Parse(Console.ReadLine());
                    if (b.search(q)){ Console.WriteLine("Znaleziono"); }
                    else if (!b.search(q)) { Console.WriteLine("Nieznaleziono"); }
                }
                if (a == 3)
                {
                    Console.WriteLine("To są wartosci w drzewie:");
                    b.display();
                }
                if (a == 4)
                {
                    Random RandomNumber = new Random();
                    for (int i = 0; i < 100; i++)
                    {
                        b.insert(RandomNumber.Next(1000));
                    }
                }
                Console.ReadKey();
            }
        }
    }
}
