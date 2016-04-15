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
        AdminVM admin; // tök őszintén: minek neki usingolnia a "Szt2_projekt.Ugyintezo;"-t,ahogy h elérje az AdminVM osztályt?
        public AdminWindow()
        {
            InitializeComponent();

            string[] alkatreszek = new string[] { "Alaplap", "Processzor", "Videókártya", "Memória", "Winchester", "SSD", "Táp", "Ház" };
            cBoxTermekTipus.ItemsSource = alkatreszek;


            admin = new AdminVM();
            ab = new AdatbazisEntities();

            var felhasznalok = from akt in ab.FELHASZNALO
                               orderby akt.NEV
                               select akt.NEV;

            lBoxAdminFelhasznalok.ItemsSource = felhasznalok.ToList();

        }


        #region Felhasználós cuccok
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
        #endregion

        #region Termékes cuccok
        private void button_Copy2_Click(object sender, RoutedEventArgs e) //Termék hozzáadása
        {
            admin.TermekHozzaAdas();
        }

        private void cBoxTermekTipus_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cBoxTermekTipus.SelectedIndex != -1)
            {
                if (cBoxTermekTipus.SelectedItem == "Processzor") // ez így működőképes,de a többi alkatrészre is meg kell írni az if-eket
                {
                    var qcpu = from akt in ab.CPU
                               select akt.TIPUSSZAM;
                    lBoxAdminTermekek.ItemsSource = qcpu.ToList();
                }
                else if (cBoxTermekTipus.SelectedItem == "Alaplap")
                {
                    var qalaplap = from akt in ab.ALAPLAP
                                   select akt.TIPUSSZAM;
                    lBoxAdminTermekek.ItemsSource = qalaplap.ToList();
                }
            }
        }
        private void button_Copy4_Click(object sender, RoutedEventArgs e) //termék módosítás
        {
            if (lBoxAdminTermekek.SelectedIndex != -1)
            {
                admin.TermekModositas(this);
            }
        }


        #endregion


    }
}
