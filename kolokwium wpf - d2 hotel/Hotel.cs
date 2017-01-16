using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kolokwium_wpf___d2_hotel
{
    class Hotel : IHotel, IData
    {
        private SortedDictionary<Pokoj, Gosc> rezerwacje = new SortedDictionary<Pokoj, Gosc>();
        private double zysk = -80;
        private DateTime data;

        public void DodajRezerwacje(string imie, string nazwisko, int nrPokoju, double cena)
        {
            rezerwacje.Add(new Pokoj(nrPokoju, cena),new Gosc(imie, nazwisko));
            zysk += cena;
        }
        public void OdwolajRezerwacje()
        {
            rezerwacje.Remove(rezerwacje.Keys.Last());
        }
        public void UstawDate(DateTime time)
        {
            this.data = time;
        }
        public bool SprawdzDate()
        {
            return (this.data > DateTime.Now) ? true : false;
        }
        public override string ToString()
        {
            string temp = "Rezerwacje: "+ Environment.NewLine;
            foreach (Object obj in rezerwacje)
            {
                temp += obj.ToString() + Environment.NewLine;
            }
            temp +="Zysk: " +Convert.ToString(zysk)+"."+Environment.NewLine;
            return temp;
        }
    }
}
