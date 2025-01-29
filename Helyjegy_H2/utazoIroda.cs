using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helyjegy_H2
{
    internal class utazoIroda
    {
        private string fajl;
        List<Utas> utazokLista = new List<Utas>();
        List<Utazas> utazasok = new List<Utazas>();


        public utazoIroda(string fajl)
        {
            this.fajl = fajl;
            Beolvas();
        }

        internal void Bevetel()
        {
            double bevetel = 0;
            foreach (var utas in utazokLista)
            {
                bevetel += utas.tav * Utazas.
            }
        }

       
        

        internal void LegutolsoJegyvasarloAdatai()
        {
            int utolsoUtasIndexe = utazokLista.Count - 1;
            for (int i = 0; i < utazokLista.Count; i++)
            {
                if (i == utolsoUtasIndexe)
                {
                    Console.WriteLine("ülés sorszáma: {0}, beutazott távolság {1}", utazokLista[i].ules, utazokLista[i].tav);
                }
            }  

          
          
        }

        internal void TejlesUtatVegigUtaztak()
        {
            List<int> sorszamok = new List<int>();
            foreach (var utas in utazokLista)
            {
              foreach(var u in utazasok)
                {
                    if (utas.tav == u.vonalHossz)
                    {
                        sorszamok.Add(utas.ules);
                    }
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
                    utazasok.Add(new Utazas(eladottjegyekSzama, vonalHossz, fizetendo));

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
    }
}
