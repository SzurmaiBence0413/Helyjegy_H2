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
            utazoIroda utazoIroda = new utazoIroda(fajl);

            Console.WriteLine("2. feladat");
            utazoIroda.LegutolsoJegyvasarloAdatai();

            Console.WriteLine("3. feladat");
            utazoIroda.TejlesUtatVegigUtaztak();

            Console.ReadLine();
        }
    }
}
