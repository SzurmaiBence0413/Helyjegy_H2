using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Helyjegy_H2
{
    internal class UtazoIroda
    {
        private string fajl;
        List<Utas> utazokLista = new List<Utas>();
        List<int> megallokLista = new List<int>();



        public UtazoIroda(string fajl)
        {
            this.fajl = fajl;
            Beolvas();
        }

        //Bevétel kiszámolása
        internal void Bevetel()
        {
            int ar = 0;
            int Bevetel = 0;
            foreach (var utas in utazokLista)
            {
                ar += utas.tav / 10 * Utazas.fizetendo;
                int kerekitettAr = OtreKerekito(ar);
                Bevetel += kerekitettAr;
            }


            Console.WriteLine("Ennyi bevétel származott a társaságnak a jegyekből: {0} Ft", Bevetel);
        }

        //Ötre kerekítő függvény
        private int OtreKerekito(int ar)
        {
            int maradék = ar % 5;

            if (maradék < 3)
            {
                return ar - maradék; // Lefelé kerekítés
            }
            else
            {
                return ar + (5 - maradék); // Felfelé kerekítés
            }
        }



        internal void LegutolsoJegyvasarloAdatai()
        {

            int utolsoUtasIndexe = utazokLista.Count - 1; // Utolsó jegyvásárló indexe
            for (int i = 0; i < utazokLista.Count; i++)
            {
                if (i == utolsoUtasIndexe)
                {
                    Console.WriteLine("ülés sorszáma: {0}, beutazott távolság {1}", utazokLista[i].ulesId, utazokLista[i].tav); // Utolsó jegyvásárló álltal beutazott távolság és a ülésének sorszámát kiírjuk
                }
            }



        }



        internal void TejlesUtatVegigUtaztak()
        {
            List<int> sorszamok = new List<int>(); // ülések sorszámának listája
            int teljesTav = Utazas.vonalHossz;
            foreach (var utas in utazokLista)
            {
                if (utas.tav == teljesTav)
                {
                    sorszamok.Add(utas.ulesId);
                }
            }

            foreach (var sorszam in sorszamok)
            {
                Console.Write("{0} ", sorszam);
            }
        }

        private void Beolvas()
        {
            string[] sorok = File.ReadAllLines(fajl);
            for (int i = 0; i < sorok.Length; i++)
            {
                if (i == 0) // ez elsősor kivétele és az utázás adatait Utazás abstact oszályba rakjuk bele
                {
                    string[] oszlopok = sorok[i].Split(' ');
                    int eladottjegyekSzama = int.Parse(oszlopok[0]);
                    int vonalHossz = int.Parse(oszlopok[1]);
                    int fizetendo = int.Parse(oszlopok[2]);
                    Utazas.eladottjegyekSzama = eladottjegyekSzama;
                    Utazas.vonalHossz = vonalHossz;
                    Utazas.fizetendo = fizetendo;

                }
                else
                {
                    string[] oszlopok = sorok[i].Split(' ');

                    int ules = int.Parse(oszlopok[0]);
                    int felszall = int.Parse(oszlopok[1]);
                    int leszall = int.Parse(oszlopok[2]);
                    int tav = leszall - felszall;
                    utazokLista.Add(new Utas(ules, felszall, leszall, tav));
                }
            }

        }

        internal void UtolsoElottiMegalloAdatai()
        {
            int utolsoElottiLe = (from i in utazokLista  //utolsó előtti megálló, ahol leszálló volt
                                  orderby i.leszall
                                  where i.leszall != Utazas.vonalHossz
                                  select i.leszall).Last();

            int utolsoElottiFel = (from i in utazokLista  //utolsó előtti megálló, ahol felszálló volt
                                   orderby i.felszall
                                   where i.felszall != Utazas.vonalHossz
                                   select i.felszall).Last();

            int utolsEllotti = Math.Max(utolsoElottiLe, utolsoElottiFel); //utolsó előtti megálló ahol leszálló és/vagy felszálló volt

            var leSzallokSzama = (from i in utazokLista
                                  where i.leszall == utolsEllotti
                                  select i).Count();



            var felSZallokSzama = (from i in utazokLista
                                   where i.felszall == utolsEllotti
                                   select i).Count();

            Console.WriteLine("Utolsó állomás előtt felszállók száma: {0} fő, leszállók száma {1}", felSZallokSzama, leSzallokSzama);
        }

        internal void MegallokSzama()
        {

            var megallokSzama = (from i in utazokLista select i.felszall).Union(from i in utazokLista select i.leszall);
            Console.WriteLine("A busznak {0} db megállója volt!", megallokSzama.Count() - 2);

        }

        internal void UtasLisat()
        {
            Console.Write("Adj meg egy távolságot: ");
            int bekertTavolsag = int.Parse(Console.ReadLine());
            string celFajlNeve = "kihol.txt";
            List<Utas> KeresettUtazokLista = new List<Utas>();
            bool megalloE = false;
            if (megallokLista.Contains(bekertTavolsag))
            {
                megalloE = true;
            }

            foreach (var utas in utazokLista)
            {
                if (megalloE)
                {
                    if (utas.felszall ==  bekertTavolsag)
                    {
                        KeresettUtazokLista.Add(utas);
                    }
                }
                else
                {
                    if (utas.felszall == bekertTavolsag || utas.leszall == bekertTavolsag)
                    {
                        KeresettUtazokLista.Add(utas);
                    }
                }
            }
           
            
            
            
                
           
        }
    }
}
