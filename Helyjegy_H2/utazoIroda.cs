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
       

        public utazoIroda(string fajl)
        {
            this.fajl = fajl;
            Beolvas();
        }

        internal void LegutolsoJegyvasarloAdatai()
        {
            int utolsoUtasFelszal = 0;
            foreach (var utas in utazokLista)
            {
                if (utas.felszall > utolsoUtasFelszal)
                {
                    utolsoUtasFelszal = utas.felszall;
                }
            }

            var lekerdezes = utazokLista
                 .Where(u => u.felszall == utolsoUtasFelszal)
                 .Select(g => new { sorszam = g.ules, g.tav });

            foreach (var utas in lekerdezes)
            {
                Console.WriteLine("üles sorszáma: {0}, távolság: {1}",utas.sorszam,utas.tav);
            }
          
        }

        internal void TejlesUtatVegigUtaztak()
        {
            
        }

        private void Beolvas()
        {
            string[] sorok = File.ReadAllLines(fajl);
            for (int i = 0; i < sorok.Length; i++)
            {
                if (i == 0)
                {
                    string[] elsosor = sorok[0].Split(' ');
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
