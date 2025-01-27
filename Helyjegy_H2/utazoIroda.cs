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
        List<Utas> utazasokLista = new List<Utas>();

        public utazoIroda(string fajl)
        {
            this.fajl = fajl;
            Beolvas();
        }

        private void Beolvas()
        {
            string[] sorok = File.ReadAllLines(fajl);
            for (int i = 1; i < sorok.Length; i++)
            {
                string[] oszlopok = sorok[i].Split(' ');
                int ules = int.Parse(oszlopok[0]);
                int felszall = int.Parse(oszlopok[1]);
                int leszall = int.Parse(oszlopok[2]);
                utazasokLista.Add(new Utas(ules, felszall, leszall);
            }

        }
    }
}
