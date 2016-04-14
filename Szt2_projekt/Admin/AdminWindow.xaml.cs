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
using Szt2_projekt.Ugyintezo;

namespace Szt2_projekt
{
    /// <summary>
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        AdatbazisEntities ab;
        public AdminWindow()
        {
            InitializeComponent();
            admin = new AdminVM();
            ab = new AdatbazisEntities();

            var felhasznalok = from akt in ab.FELHASZNALO
                               orderby akt.NEV
                               select akt.NEV;

            lBoxAdminFelhasznalok.ItemsSource = felhasznalok.ToList();

        }
        AdminVM admin; // tök őszintén: minek neki usingolnia a "Szt2_projekt.Ugyintezo;"-t,ahogy h elérje az AdminVM osztályt?

        void Frissit() // egyelőre ezzel a megoldással "frissül" a listbox(mármint minden gombnyomás után lefut a lekérdezés)
        {
            var felhasznalok = from akt in ab.FELHASZNALO
                               orderby akt.NEV
                               select akt.NEV;

            lBoxAdminFelhasznalok.ItemsSource = felhasznalok.ToList();
        }
        private void button_Click(object sender, RoutedEventArgs e) // felhasználó hozzáadás
        {
            admin.FelhasznaloHozzaAdas();
            Frissit();

        }

        private void button_Copy_Click(object sender, RoutedEventArgs e) // felhasználó törlése
        {
            if (lBoxAdminFelhasznalok.SelectedIndex != -1)
            {
                string torlendouser = lBoxAdminFelhasznalok.SelectedItem.ToString();
                var torlo = from akt in ab.FELHASZNALO
                            where akt.NEV == torlendouser
                            select akt;

                ab.FELHASZNALO.Remove(torlo.First());
                ab.SaveChanges();
                //Gabit miért nem tudja kitörölni?
                Frissit();

            }
        }

        private void button_Copy1_Click(object sender, RoutedEventArgs e) // felhasználó módosítása
        {
            if (lBoxAdminFelhasznalok.SelectedIndex != -1)
            {               
                var q = from akt in ab.FELHASZNALO
                          where akt.NEV == lBoxAdminFelhasznalok.SelectedItem.ToString()
                          select akt;

                FELHASZNALO f = q.First();
                admin.FelhasznaloModositas(f);
                Frissit();
            }
           
        }

        private void button_Copy2_Click(object sender, RoutedEventArgs e) //Termék hozzáadása
        {

        }
    }
}
