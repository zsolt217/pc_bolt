using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        private void Kijelentkezes_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MainWindow uj = new MainWindow();
            uj.Show();
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

                try
                {
                    var t1 = torlo.Single();
                    ab.SZEMELYES_ADATOK.Remove((ab.SZEMELYES_ADATOK.Where(x=>x.FELHASZNALO_ID==t1.FELHASZNALO_ID)).SingleOrDefault());
                    ab.FELHASZNALO.Remove(t1);
                    ab.SaveChanges();
                    Frissit();
                }
                catch (Exception j)
                {
                    MessageBox.Show(j.Message);
                }
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
                ab.SaveChanges();
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
                if (cBoxTermekTipus.SelectedItem == "Processzor") 
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
                else if (cBoxTermekTipus.SelectedItem == "Videókártya")
                {
                    var qgpu = from akt in ab.GPU
                               select akt.TIPUSSZAM;
                    lBoxAdminTermekek.ItemsSource = qgpu.ToList();
                }
                else if (cBoxTermekTipus.SelectedItem == "Memória")
                {
                    var qram = from akt in ab.MEMORIA
                               select akt.TIPUSSZAM;
                    lBoxAdminTermekek.ItemsSource = qram.ToList();
                }
                else if (cBoxTermekTipus.SelectedItem == "Winchester")
                {
                    var qhdd = from akt in ab.HDD
                               select akt.TIPUSSZAM;
                    lBoxAdminTermekek.ItemsSource = qhdd.ToList();
                }
                else if (cBoxTermekTipus.SelectedItem == "SSD")
                {
                    var qssd = from akt in ab.SSD
                               select akt.TIPUSSZAM;
                    lBoxAdminTermekek.ItemsSource = qssd.ToList();
                }
                else if (cBoxTermekTipus.SelectedItem == "Táp")
                {
                    var qtap = from akt in ab.TAP
                               select akt.TIPUSSZAM;
                    lBoxAdminTermekek.ItemsSource = qtap.ToList();
                }
                else if (cBoxTermekTipus.SelectedItem == "Ház")
                {
                    var qhaz = from akt in ab.HAZ
                               select akt.TIPUSSZAM;
                    lBoxAdminTermekek.ItemsSource = qhaz.ToList();
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
