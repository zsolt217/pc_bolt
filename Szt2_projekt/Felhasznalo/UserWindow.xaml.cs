using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using Szt2_projekt.Felhasznalo;

namespace Szt2_projekt
{
    /// <summary>
    /// Interaction logic for UserWindow.xaml
    /// </summary>
    public partial class UserWindow : Window
    {
        AdatbazisEntities DB = new AdatbazisEntities();
        FelhasznaloVM VM;
        FelhasznaloBSL BS;
        decimal id;
        //KompatibilitasVizsgalo kompatibilitas;

        public UserWindow(decimal felhasznaloid)
        {
            InitializeComponent();
            VM = new FelhasznaloVM(felhasznaloid);
            BS = new FelhasznaloBSL(felhasznaloid, VM);
            //kompatibilitas = new KompatibilitasVizsgalo();
            id = felhasznaloid;
            DataContext = VM;

        }

        private void MegrendelésButton_Click(object sender, RoutedEventArgs e)
        {
            //ALAPLAP alaplap = (ALAPLAP)cBoxAlaplap.SelectedItem;
            //CPU cpu = (CPU)cBoxProcesszor.SelectedItem;
            //HAZ haz = (HAZ)cBoxHaz.SelectedItem;
            //GPU gpu = (GPU)cBoxVideokartya.SelectedItem;
            //TAP tap = (TAP)cBoxTapegyseg.SelectedItem;
            //HDD hdd = (HDD)cBoxWinchester.SelectedItem;
            //SSD ssd = (SSD)cBoxSSD.SelectedItem;
            //MEMORIA memoria = (MEMORIA)cBoxMemoria.SelectedItem;
            //if (alaplap == null ||
            //    cpu == null ||
            //    haz == null ||
            //    gpu == null ||
            //    tap == null ||
            //    hdd == null ||
            //    ssd == null ||
            //    memoria == null)
            //{
            //    MessageBox.Show("Nem sikerült a megrendelést rögzíteni, mert a konfiguráció hiányos! Kérjük válassz ki minden minden alkatrészből egyet!");
            //}
            //else
            //{
            //    if (kompatibilitas.Kompatibilis(alaplap, memoria, hdd, ssd, tap, haz, cpu, gpu))
            //    {
            //        MessageBox.Show("Sikeresen hozzáadva a rendelésekhez!");
            //        //TODO RENDELÉSEKHEZ HOZZÁADNI!
            //    }
            //}
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //cBoxAlaplap.ItemsSource = DB.ALAPLAP.ToList();
            //cBoxHaz.ItemsSource = DB.HAZ.ToList();
            //cBoxMemoria.ItemsSource = DB.MEMORIA.ToList();
            //cBoxProcesszor.ItemsSource = DB.CPU.ToList();
            //cBoxSSD.ItemsSource = DB.SSD.ToList();
            //cBoxTapegyseg.ItemsSource = DB.TAP.ToList();
            //cBoxVideokartya.ItemsSource = DB.GPU.ToList();
            //cBoxWinchester.ItemsSource = DB.HDD.ToList();
            labelek = new List<Label>();
            labelek.Add(lbl1);
            labelek.Add(lbl2);
            labelek.Add(lbl3);
            labelek.Add(lbl4);
            labelek.Add(lbl5);
            labelek.Add(lbl6);
            labelek.Add(lbl7);
            alaplaplabelnevek = new string[] { "Ár:", "Név:", "Processzor foglalat:", "Memóriaslotok száma:", "Memóriatípus:", "Chipset:", "Méretszabvány:" };
            tarololabelnevek = new string[] { "Ár:", "Név:", "Kapacitás:" };
            proclabelnevek = new string[] { "Ár:", "Név:", "Foglalat:", "Fogyasztás:", "Órajel:", "Magok száma:" };
            gpulabelnevek = new string[] { "Ár:", "Név:", "Fogyasztás:", "Memória:" };
            ramlabelnevek = new string[] { "Ár:", "Név:", "Típus:", "Órajel:", "Kapacitás:" };
            taplabelnevek = new string[] { "Ár:", "Név:", "Teljesítmény:" };
            hazlabelnevek = new string[] { "Ár:", "Név:", "Méretszabvány:" };

        }
        string[] alaplaplabelnevek;
        string[] tarololabelnevek;
        string[] proclabelnevek;
        string[] gpulabelnevek;
        string[] ramlabelnevek;
        string[] taplabelnevek;
        string[] hazlabelnevek;
        List<Label> labelek;


        private void Kijelentkezo_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            MainWindow uj = new MainWindow();
            uj.Show();
        }

        private void FelhAdatModosit_Click(object sender, RoutedEventArgs e)
        {
            RegisztracioWindow uj = new RegisztracioWindow(id);
            uj.ShowDialog();
        }

        private void kuldesButton_Click(object sender, RoutedEventArgs e)
        {
            if (VM.UzenetKuldes())
            {
                MessageBox.Show("Sikeres küldés");
            }
            else MessageBox.Show("Sikertelen küldés");
        }

        private void MentésButton_Click(object sender, RoutedEventArgs e)
        {
            //ALAPLAP alaplap = (ALAPLAP)cBoxAlaplap.SelectedItem;
            //CPU cpu = (CPU)cBoxProcesszor.SelectedItem;
            //HAZ haz = (HAZ)cBoxHaz.SelectedItem;
            //GPU gpu = (GPU)cBoxVideokartya.SelectedItem;
            //TAP tap = (TAP)cBoxTapegyseg.SelectedItem;
            //HDD hdd = (HDD)cBoxWinchester.SelectedItem;
            //SSD ssd = (SSD)cBoxSSD.SelectedItem;
            //MEMORIA memoria = (MEMORIA)cBoxMemoria.SelectedItem;
            //if (alaplap == null ||
            //    cpu == null ||
            //    haz == null ||
            //    gpu == null ||
            //    tap == null ||
            //    hdd == null ||
            //    ssd == null ||
            //    memoria == null)
            //{
            //    MessageBox.Show("Nem sikerült a kedvencekbe menteni, mert a konfiguráció hiányos! Kérjük válassz ki minden minden alkatrészből egyet!");
            //}
            //else
            //{
            //    if (kompatibilitas.Kompatibilis(alaplap, memoria, hdd, ssd, tap, haz, cpu, gpu))
            //    {
            //        MessageBox.Show("Sikeresen mentve a kedvencek közé konfiguráció!");
            //        //TODO MENTÉS A KEDVENCEKBE!
            //    }
            //}
        }


        #region unchecked rbutton események,nem kell megnyitni

        void LabelContentTorles()
        {
            foreach (Label akt in labelek)
            {
                akt.Content = string.Empty;
            }
        }
        private void rbAlaplap_Unchecked(object sender, RoutedEventArgs e)
        {
            LabelContentTorles();
        }

        private void rbProcesszor_Unchecked(object sender, RoutedEventArgs e)
        {
            LabelContentTorles();
        }

        private void rbVideokartya_Unchecked(object sender, RoutedEventArgs e)
        {
            LabelContentTorles();
        }

        private void rbMemoria_Unchecked(object sender, RoutedEventArgs e)
        {
            LabelContentTorles();
        }

        private void rbWinchester_Unchecked(object sender, RoutedEventArgs e)
        {
            LabelContentTorles();
        }

        private void rbSSD_Unchecked(object sender, RoutedEventArgs e)
        {
            LabelContentTorles();
        }

        private void rbTap_Unchecked(object sender, RoutedEventArgs e)
        {
            LabelContentTorles();
        }

        private void rbHaz_Unchecked(object sender, RoutedEventArgs e)
        {
            LabelContentTorles();
        }
        #endregion


        AdatbazisEntities ab;
        private void rbAlaplap_Checked(object sender, RoutedEventArgs e)
        {

            for (int i = 0; i < alaplaplabelnevek.Length; i++)
            {
                labelek[i].Content = alaplaplabelnevek[i];
            }

            if (cBoxAlaplap.SelectedIndex != cBoxAlaplap.Items.Count) //ha nem az utolsó van kiválasztva
            {
                ab = new AdatbazisEntities();
                ALAPLAP alap = new ALAPLAP();

                string keres = cBoxAlaplap.SelectedItem.ToString();
                var q = from akt in ab.ALAPLAP
                        where akt.TIPUSSZAM == keres
                        select akt;


                alap = q.FirstOrDefault();
                //AlkatreszAdatokGrid.DataContext = alap;

            }
        }

        private void rbWinchester_Checked(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < tarololabelnevek.Length; i++)
            {
                labelek[i].Content = tarololabelnevek[i];
            }
        }


        private void rbProcesszor_Checked(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < proclabelnevek.Length; i++)
            {
                labelek[i].Content = proclabelnevek[i];
            }
        }

        private void rbVideokartya_Checked(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < gpulabelnevek.Length; i++)
            {
                labelek[i].Content = gpulabelnevek[i];
            }
        }


        private void rbMemoria_Checked(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < ramlabelnevek.Length; i++)
            {
                labelek[i].Content = ramlabelnevek[i];
            }
        }

        private void rbSSD_Checked(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < tarololabelnevek.Length; i++)
            {
                labelek[i].Content = tarololabelnevek[i];
            }
        }

        private void rbTap_Checked(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < taplabelnevek.Length; i++)
            {
                labelek[i].Content = taplabelnevek[i];
            }
        }

        private void rbHaz_Checked(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < hazlabelnevek.Length; i++)
            {
                labelek[i].Content = hazlabelnevek[i];
            }
        }
    }
}
