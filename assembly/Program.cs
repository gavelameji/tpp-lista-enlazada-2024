using linkedlist;
using System;
using System.Collections.Generic;

namespace assembly
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Lista<int> l = new Lista<int>();
            l.Anadir(1);
            l.Anadir(2);
            l.Anadir(3);
            l.Anadir(4);
            l.Anadir(5);
            l.Anadir(6);  
            l.Anadir(7);
            l.Anadir(8);

            Console.WriteLine(l);

            Lista<string> l2 = new Lista<string>();
            l2.Anadir("uno");
            l2.Anadir("dos");
            l2.Anadir("tres");
            l2.Anadir("cuatro");
            l2.Anadir("cinco");

            Console.WriteLine(l2);

            foreach(int i in l)
            {
                Console.WriteLine(i);
            }

        }
    }
}
