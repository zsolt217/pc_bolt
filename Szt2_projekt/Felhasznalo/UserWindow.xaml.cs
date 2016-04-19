using System.ComponentModel;
using System.Linq;
using System.Windows;
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
        KompatibilitasVizsgalo kompatibilitas;

        public UserWindow(decimal felhasznaloid)
        {
            InitializeComponent();
            VM = new FelhasznaloVM(felhasznaloid);
            BS = new FelhasznaloBSL(felhasznaloid, VM);
            kompatibilitas = new KompatibilitasVizsgalo();
            id = felhasznaloid;
            DataContext = VM;
            
        }

        private void MegrendelésButton_Click(object sender, RoutedEventArgs e)
        {
            ALAPLAP alaplap = (ALAPLAP)cBoxAlaplap.SelectedItem;
            CPU cpu = (CPU)cBoxProcesszor.SelectedItem;
            HAZ haz = (HAZ)cBoxHaz.SelectedItem;
            GPU gpu = (GPU)cBoxVideokartya.SelectedItem;
            TAP tap = (TAP)cBoxTapegyseg.SelectedItem;
            HDD hdd = (HDD)cBoxWinchester.SelectedItem;
            SSD ssd = (SSD)cBoxSSD.SelectedItem;
            MEMORIA memoria = (MEMORIA)cBoxMemoria.SelectedItem;
            if (alaplap == null ||
                cpu == null ||
                haz == null ||
                gpu == null ||
                tap == null ||
                hdd == null ||
                ssd == null ||
                memoria == null)
            {
                MessageBox.Show("Nem sikerült a megrendelést rögzíteni, mert a konfiguráció hiányos! Kérjük válassz ki minden minden alkatrészből egyet!");
            }
            else
            {
                if (kompatibilitas.Kompatibilis(alaplap, memoria, hdd, ssd, tap, haz, cpu, gpu))
                {
                    MessageBox.Show("Sikeresen hozzáadva a rendelésekhez!");
                    //TODO RENDELÉSEKHEZ HOZZÁADNI!
                }
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cBoxAlaplap.ItemsSource = DB.ALAPLAP.ToList();
            cBoxHaz.ItemsSource = DB.HAZ.ToList();
            cBoxMemoria.ItemsSource = DB.MEMORIA.ToList();
            cBoxProcesszor.ItemsSource = DB.CPU.ToList();
            cBoxSSD.ItemsSource = DB.SSD.ToList();
            cBoxTapegyseg.ItemsSource = DB.TAP.ToList();
            cBoxVideokartya.ItemsSource = DB.GPU.ToList();
            cBoxWinchester.ItemsSource = DB.HDD.ToList();
        }

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
            ALAPLAP alaplap = (ALAPLAP)cBoxAlaplap.SelectedItem;
            CPU cpu = (CPU)cBoxProcesszor.SelectedItem;
            HAZ haz = (HAZ)cBoxHaz.SelectedItem;
            GPU gpu = (GPU)cBoxVideokartya.SelectedItem;
            TAP tap = (TAP)cBoxTapegyseg.SelectedItem;
            HDD hdd = (HDD)cBoxWinchester.SelectedItem;
            SSD ssd = (SSD)cBoxSSD.SelectedItem;
            MEMORIA memoria = (MEMORIA)cBoxMemoria.SelectedItem;
            if (alaplap == null ||
                cpu == null ||
                haz == null ||
                gpu == null ||
                tap == null ||
                hdd == null ||
                ssd == null ||
                memoria == null)
            {
                MessageBox.Show("Nem sikerült a kedvencekbe menteni, mert a konfiguráció hiányos! Kérjük válassz ki minden minden alkatrészből egyet!");
            }
            else
            {
                if (kompatibilitas.Kompatibilis(alaplap, memoria, hdd, ssd, tap, haz, cpu, gpu))
                {
                    MessageBox.Show("Sikeresen mentve a kedvencek közé konfiguráció!");
                    //TODO MENTÉS A KEDVENCEKBE!
                }
            }
        }
    }
}
