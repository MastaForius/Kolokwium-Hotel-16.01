using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kolokwium_wpf___d2_hotel
{
    interface IHotel
    {
        void DodajRezerwacje(string imie, string nazwisko, int nrPokoju, double cena);
        void OdwolajRezerwacje();
    }
}
