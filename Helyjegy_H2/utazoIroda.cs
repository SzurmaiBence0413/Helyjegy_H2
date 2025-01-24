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
            int mutato = 0;
            string
        }
    }
}
