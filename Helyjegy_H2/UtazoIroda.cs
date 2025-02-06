using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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

        internal void Bevetel()
        {
            int ar = 0;
            int Bevetel = 0;
            foreach (var utas  in utazokLista )
            {
                ar += utas.tav / 10 * Utazas.fizetendo;
                int kerekitettAr = OtreKerekito(ar);
                Bevetel+= kerekitettAr;
            }


            Console.WriteLine("Ennyi bevétel származott a társaságnak a jegyekből: {0} Ft",Bevetel);
        }

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
            int utolsoUtasIndexe = utazokLista.Count - 1;
            for (int i = 0; i < utazokLista.Count; i++)
            {
                if (i == utolsoUtasIndexe)
                {
                    Console.WriteLine("ülés sorszáma: {0}, beutazott távolság {1}", utazokLista[i].ulesId, utazokLista[i].tav);
                }
            }  

          
          
        }

     

        internal void TejlesUtatVegigUtaztak()
        {
            List<int> sorszamok = new List<int>();
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
                Console.Write("{0} ",sorszam);
            }
        }

        private void Beolvas()
        {
            string[] sorok = File.ReadAllLines(fajl);
            for (int i = 0; i < sorok.Length; i++)
            {
                if (i == 0)
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
                    utazokLista.Add(new Utas(ules, felszall, leszall,tav));
                }
            } 

        }

        internal void UtolsoElottiMegalloAdatai()
        {
            int utolsoElottiMegallo = -1;
            int feldb = 0;
            int ledb = 0;
            for (int i = 0; i < n; i++)
            {
                if (utolsoElottiMegallo < utazokLista[i].felszall && utazokLista[i].felszall != hossz)
                {
                    utolsoElottiMegallo = utazokLista[i].felszall;
                    feldb = 1;
                }
                else if (utolsoElottiMegallo == utazokLista[i].Fel)
                {
                    feldb++;
                }
            }
            for (int i = 0; i < n; i++)
            {
                if (ueáll < [i].Le && járat[i].Le != hossz)
                {
                    ueáll = járat[i].Le;
                    ledb = 1;
                    feldb = 0;
                }
                else if (ueáll == járat[i].Le)
                {
                    ledb++;
                }
            }
            Console.WriteLine("Az utolsó megállóban {0} felszálló és {1} leszálló volt.", feldb, ledb);
        }

        internal void MegallokSzama()
        {
            foreach (var megallo in utazokLista)
            {
                if (!megallokLista.Contains(megallo.felszall))
                {
                    megallokLista.Add(megallo.felszall);
                }
            }
            Console.WriteLine("Ennyi megálló volt {0}",megallokLista.Count);


        }
    }
}
