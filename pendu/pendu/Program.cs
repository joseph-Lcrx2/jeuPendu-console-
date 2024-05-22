using System;
using System.IO;

namespace pendu
{
    class Program
    {
        
        static void Main(string[] args)
        {
            int rep = 1;
            while (rep == 1)
            {
                Console.Clear();
                partie p1 = new partie();
                p1.play();
                Console.WriteLine("Tapez 1 pour rejouer sinon tapez 0");
                rep = int.Parse(Console.ReadLine());
            }
            
            
        }
    }
}
