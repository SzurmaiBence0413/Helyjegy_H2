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

            //2.Adja meg a legutolsó jegyvásárló ülésének sorszámát és az általa beutazott távolságot! A kívánt adatokat a képernyőn jelenítse meg!
            Console.WriteLine("2. feladat");
            utazoIroda.LegutolsoJegyvasarloAdatai();

            //3. Listázza ki, kik utazták végig a teljes utat! Az utasok sorszámát egy-egy szóközzel elválasztva írja a képernyőre!
            Console.WriteLine("\n3. feladat");
            utazoIroda.TejlesUtatVegigUtaztak();

            //4. Határozza meg, hogy a jegyekből mennyi bevétele származott a társaságnak! Az eredményt írja a képernyőre!
            Console.WriteLine("\n4. feladat");
            utazoIroda.Bevetel();

            //6. Adja meg, hogy hány helyen állt meg a busz a kiinduló állomás és a célállomás között! Az eredményt írja a képernyőre!
            Console.WriteLine("\n6. feladat");
            utazoIroda.MegallokSzama();

            //5. Írja a képernyőre, hogy a busz végállomást megelőző utolsó megállásánál hányan szálltak fel és le!
            Console.WriteLine("\n5. feladat");
            utazoIroda.UtolsoElottiMegalloAdatai();

            //7. Készítsen „utaslistát" az út egy pontjáról! A listában ülésenként tüntesse fel, hogy azt az adott pillanatban melyik utas foglalja el!
            //A pontot, azaz a kiindulási állomástól mért távolságot, a felhasználótól kérje be!
            //Ha a beolvasott helyen éppen megálló lett volna, akkor a felszálló utasokat vegye figyelembe, a leszállókat pedig hagyja figyelmen kívül!
            //Az eredményt az ülések sorszámának sorrendjében írja a kihol.txt állományba!
            //Az üres helyek esetén az „üres" szót jelenítse meg! Minden ülés külön sorba kerüljön!
            Console.WriteLine("\n7. feladat");
            utazoIroda.UtasLisat();

            Console.ReadLine();
        }
    }
}
