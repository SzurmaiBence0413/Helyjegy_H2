using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helyjegy_H2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string fajl = "eladott.txt";
            UtazoIroda utazoIroda = new UtazoIroda(fajl);

            Console.WriteLine("2. feladat");
            utazoIroda.LegutolsoJegyvasarloAdatai();

            Console.WriteLine("3. feladat");
            utazoIroda.TejlesUtatVegigUtaztak();

            Console.WriteLine("\n4. feladat");
            utazoIroda.Bevetel();

            Console.WriteLine("\n5. feladat");
            utazoIroda.UtolsoElottiMegalloAdatai();

            Console.WriteLine("\n6. feladat");
            utazoIroda.MegallokSzama();

            Console.WriteLine("\n7. feladat");


            Console.ReadLine();
        }
    }
}
