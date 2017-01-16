using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kolokwium_wpf___d2_hotel
{
    class Gosc
    {
        private string imie, nazwisko;
        public Gosc(string imie, string nazwisko)
        {
            this.imie = imie;
            this.nazwisko = nazwisko;
        }
        public override string ToString()
        {
            string temp = "Gość: imie"+ this.imie + ", nazwisko: "+this.nazwisko+".";
            return temp;
        }

    }
}
