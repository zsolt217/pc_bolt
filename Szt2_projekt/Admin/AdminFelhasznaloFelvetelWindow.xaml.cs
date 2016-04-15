using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Szt2_projekt.Admin
{
    /// <summary>
    /// Interaction logic for AdminFelhasznaloFelvetelWindow.xaml
    /// </summary>
    public partial class AdminFelhasznaloFelvetelWindow : Window
    {
        string[] beosztasok;
        public AdminFelhasznaloFelvetelWindow()
        {
            InitializeComponent();
            beosztasok = new string[3];
            beosztasok[0] = "FELHASZNALO";
            beosztasok[1] = "UGYINTEZO";
            beosztasok[2] = "ADMIN";

            cBoxBeosztas.ItemsSource = beosztasok;


        }
        AdatbazisEntities ab = new AdatbazisEntities();

        private void felvetelButton_Click(object sender, RoutedEventArgs e) //felvétel
        {
            FELHASZNALO ujfelhasznalo = new FELHASZNALO();
            SZEMELYES_ADATOK ujadatok = new SZEMELYES_ADATOK();
            int ujID = (int)ab.FELHASZNALO.Max(x => x.FELHASZNALO_ID) + 1; //talán így is jó

            ujfelhasznalo.FELHASZNALO_ID = ujID;
            ujfelhasznalo.NEV = tBoxFelhasznaloNev.Text;
            ujfelhasznalo.BEOSZTAS = cBoxBeosztas.SelectedItem.ToString();
            ujfelhasznalo.JELSZO = passwordBox1.Password.ToString();
            //ujfelhasznalo.RENDELESEK = new List<RENDELESEK>();
            //ujfelhasznalo.UZENETEK = new List<UZENETEK>();
            ujfelhasznalo.SZEMELYES_ADATOK = ujadatok;

            ujadatok.FELHASZNALO_ID = ujID;
            ujadatok.CIM = tBoxCim.Text;
            ujadatok.EMAILCIM = tBoxEmail.Text;
            ujadatok.TELEFONSZAM = tBoxTelefonSzam.Text;
            ujadatok.KERESZTNEV = tBoxKeresztNev.Text;
            ujadatok.VEZETEKNEV = tBoxVezetekNev.Text;

            ab.FELHASZNALO.Add(ujfelhasznalo);
            ab.SZEMELYES_ADATOK.Add(ujadatok);     
            ab.SaveChanges(); 
            this.DialogResult = true;

        }

        private void megsemButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void Button_Click(object sender, RoutedEventArgs e) //módosítás
        {
            FELHASZNALO aktfelhasznalo = new FELHASZNALO();
            this.DialogResult = true;
        }




    }
}
