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
            beosztasok[0] = "Felhasználó";
            beosztasok[1] = "Ügyintéző";
            beosztasok[2] = "Admin";

            cBoxBeosztas.ItemsSource = beosztasok;
            

        }
        AdatbazisEntities ab = new AdatbazisEntities();
        private void felvetelButton_Click(object sender, RoutedEventArgs e) //felvétel
        {
            FELHASZNALO ujfelhasznalo = new FELHASZNALO();
            ujfelhasznalo.FELHASZNALO_ID = ab.FELHASZNALO.Count() + 5; // azért nem +1,mert így ütközik a Gabival,akivel konkrétan semmit sem tudok csinálni
            ujfelhasznalo.NEV = tBoxVezetekNev.Text + " " + tBoxKeresztNev.Text;
            ujfelhasznalo.BEOSZTAS = cBoxBeosztas.SelectedItem.ToString();
            ujfelhasznalo.JELSZO = passwordBox1.Password.ToString();
            //ujfelhasznalo.RENDELESEK = new List<RENDELESEK>();
            //ujfelhasznalo.UZENETEK = new List<UZENETEK>();
            ab.FELHASZNALO.Add(ujfelhasznalo);
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
