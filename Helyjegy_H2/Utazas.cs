namespace Helyjegy_H2
{
    internal class Utazas
    {
        public int eladottjegyekSzama;
        public int vonalHossz;
        public int fizetendo;

        public Utazas(int eladottjegyekSzama, int vonalHossz, int fizetendo)
        {
            this.eladottjegyekSzama = eladottjegyekSzama;
            this.vonalHossz = vonalHossz;
            this.fizetendo = fizetendo;
        }
    }
}