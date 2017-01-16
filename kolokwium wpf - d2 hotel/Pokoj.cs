using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kolokwium_wpf___d2_hotel
{
    class Pokoj : IComparable
    {
        private int nrPokoju;
        private double cenaZaDzien;

        public Pokoj(int nrPokoju, double cenaZaDzien)
        {
            this.nrPokoju = nrPokoju;
            this.cenaZaDzien = cenaZaDzien;
        }
        public override string ToString()
        {
            string temp = "Pokój: nr: "+ Convert.ToString(this.nrPokoju)+", cena za dzień: "+ Convert.ToString(this.cenaZaDzien)+".";
            return temp;
        }
        public int JakiNrPokoju()
        {
            return this.nrPokoju;
        }
        public double JakaCenaZaDzien()
        {
            return this.cenaZaDzien;
        }
        public int CompareTo(object obj)
        {
            if (obj == null) return 1;
            Pokoj innyPokoj = obj as Pokoj;
            if (innyPokoj != null)
                return this.nrPokoju.CompareTo(innyPokoj.nrPokoju);
            else
                throw new ArgumentException("Objekt nie jest pokojem");
        }
    }
}
