using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace kolokwium_wpf___d2_hotel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            odswierzHotel();
        }
        Hotel hotel = new Hotel();
        private enum coDodac { nic, data, goscIPokoj}
        private coDodac dodawanie= coDodac.nic;

        private void Wyczysc()
        {
            Tbox_cenaPokoju.Text = "";
            Tbox_imie.Text = "";
            Tbox_nazwisko.Text = "";
            Tbox_nrPokoju.Text = "";
            Lbl_infoHotel.DataContext = "";
        }

        private void Btn_dodaj_Click(object sender, RoutedEventArgs e)
        {
            switch (dodawanie)
            {
                case (coDodac.nic):
                    {
                        break;
                    }
                case (coDodac.data):
                    {
                        DateTime data;
                        if (Dpic_dataRezerwacj.Text == "")
                        {
                            MessageBox.Show("Nie wybrano daty!");
                            return;
                        }
                        try
                        {
                            data = Convert.ToDateTime(Dpic_dataRezerwacj.Text);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                            break;
                        }
                        hotel.UstawDate(data);
                        if (hotel.SprawdzDate())
                        {
                            MessageBox.Show("Dodano date rezerwacji");
                            odswierzHotel();
                        }
                        else
                        {
                            MessageBox.Show("Wybierz datę większą od aktualnej");
                        }
                        break;                        
                    }
                case (coDodac.goscIPokoj):
                    {
                        if (Regex.IsMatch(Tbox_imie.Text, @"^[a-zA-Z] +$"))
                        {
                            MessageBox.Show("Błędny format imienia! Dozwolone znaki to: a-z, A-Z");
                            return;
                        }
                        else if (Regex.IsMatch(Tbox_nazwisko.Text, @"^[a-zA-Z] +$"))
                        {
                            MessageBox.Show("Błędny format nazwiska! Dozwolone znaki to: a-z, A-Z");
                            return;
                        }
                        else if (Regex.IsMatch(Tbox_nrPokoju.Text, @"^[0-9] +$"))
                        {
                            MessageBox.Show("Błędny format numeru pokoju! Dozwolone znaki to: 0-9");
                            return;
                        }
                        else if (Regex.IsMatch(Tbox_cenaPokoju.Text, @"^[0-9,]"))
                        {
                            MessageBox.Show("Błędny format ceny pokoju! Dozwolone znaki to: 0-9, kropka, przecinek");
                            return;
                        }
                        else
                        {
                            MessageBox.Show("Błedne dane goscia lub pokoju (mozliwy zly format)");
                        }
                        hotel.DodajRezerwacje(Tbox_imie.Text, Tbox_nazwisko.Text, Convert.ToInt32(Tbox_nrPokoju.Text), Convert.ToDouble(Tbox_cenaPokoju.Text));
                        odswierzHotel();
                        break;
                    }
            }
            Wyczysc();
        }
        public void odswierzHotel()
        {
            Lbl_hotel.Visibility = Visibility.Visible;
            Lbl_infoHotel.Visibility = Visibility.Visible;
            Lbl_infoHotel.Content = hotel.ToString();
        }

        private void Btn_dataRezerwacj_Click(object sender, RoutedEventArgs e)
        {
            dodawanie = coDodac.data;
            Lbl_data.Visibility = Visibility.Visible;
            Dpic_dataRezerwacj.Visibility = Visibility.Visible;
            Btn_dodaj.Visibility = Visibility.Visible;
            Wyczysc();
            odswierzHotel();
            Lbl_imie.Visibility = Visibility.Hidden;
            Lbl_nazwisko.Visibility = Visibility.Hidden;
            Lbl_nrPokoju.Visibility = Visibility.Hidden;
            Lbl_cenaPokoju.Visibility = Visibility.Hidden;
            Tbox_imie.Visibility = Visibility.Hidden;
            Tbox_nazwisko.Visibility = Visibility.Hidden;
            Tbox_nrPokoju.Visibility = Visibility.Hidden;
            Tbox_cenaPokoju.Visibility = Visibility.Hidden;
            odswierzHotel();
        }

        private void Btn_dodajRezerwacje_Click(object sender, RoutedEventArgs e)
        {
            if (hotel.SprawdzDate())
            {
                dodawanie = coDodac.goscIPokoj;
                Lbl_imie.Visibility = Visibility.Visible;
                Lbl_nazwisko.Visibility = Visibility.Visible;
                Lbl_nrPokoju.Visibility = Visibility.Visible;
                Lbl_cenaPokoju.Visibility = Visibility.Visible;
                Tbox_imie.Visibility = Visibility.Visible;
                Tbox_nazwisko.Visibility = Visibility.Visible;
                Tbox_nrPokoju.Visibility = Visibility.Visible;
                Tbox_cenaPokoju.Visibility = Visibility.Visible;
                Btn_dodaj.Visibility = Visibility.Visible;
                Wyczysc();
                Lbl_data.Visibility = Visibility.Hidden;
                Dpic_dataRezerwacj.Visibility = Visibility.Hidden;
                odswierzHotel();
            }
            else
            {
                MessageBox.Show("Najpier wybierz date");
            }
        }

        private void Btn_usunRezerwacje_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                hotel.OdwolajRezerwacje();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message+ " (Czyli brak rezerwacji do usunięcia)");
            }
            odswierzHotel();
        }

        private void Btn_wyczysc_Click(object sender, RoutedEventArgs e)
        {
            Wyczysc();
        }

        private void Btn_wyjscie_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


    }
}
