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
    /// Interaction logic for TermekModositoWindow.xaml
    /// </summary>
    public partial class TermekModositoWindow : Window
    {
        public TermekModositoWindow()
        {
            InitializeComponent();
            ab = new AdatbazisEntities();
            alkatreszek = new string[] { "Alaplap", "Processzor", "Videókártya", "Memória", "Winchester", "SSD", "Táp", "Ház" };
            cBoxTermekTipus.ItemsSource = alkatreszek;
        }
        AdatbazisEntities ab;
        string[] alkatreszek;
        private void felvetelButton_Click(object sender, RoutedEventArgs e) //felvétel
        {
            // itt az összeset ki kell szépen tölteni,csak tisztázni kéne az adatbázisokat
            if (cBoxTermekTipus.SelectedIndex != -1)
            {
                if (cBoxTermekTipus.SelectedItem == "Alaplap")
                {
                    ALAPLAP ujalaplap = new ALAPLAP();

                    ab.ALAPLAP.Add(ujalaplap);
                    ab.SaveChanges();
                }
                else if (cBoxTermekTipus.SelectedItem == "Processzor")
                {
                    CPU ujcpu = new CPU();
                    ujcpu.CPU_ID = ab.CPU.Max(x => x.CPU_ID) + 1; // mindig a legnagyobb id-hoz az egyet
                    ujcpu.FOGYASZTAS = int.Parse(tBoxFogyasztas.Text);
                    ujcpu.SEBESSEG = int.Parse(tBoxOrajel.Text);

                    ab.CPU.Add(ujcpu);
                    ab.SaveChanges();
                }
                else if (cBoxTermekTipus.SelectedItem == "Videókártya")
                {
                    GPU ujgpu = new GPU();

                    ab.GPU.Add(ujgpu);
                    ab.SaveChanges();
                }
                else if (cBoxTermekTipus.SelectedItem == "Memória")
                {
                    MEMORIA ujmemoria = new MEMORIA();

                    ab.MEMORIA.Add(ujmemoria);
                    ab.SaveChanges();
                }
                else if (cBoxTermekTipus.SelectedItem == "Winchester")
                {
                    HDD ujdd = new HDD();

                    ab.HDD.Add(ujdd);
                    ab.SaveChanges();
                }
                else if (cBoxTermekTipus.SelectedItem == "SSD")
                {
                    SSD ujssd = new SSD();

                    ab.SSD.Add(ujssd);
                    ab.SaveChanges();
                }
                else if (cBoxTermekTipus.SelectedItem == "Táp")
                {
                    TAP ujtap = new TAP();

                    ab.TAP.Add(ujtap);
                    ab.SaveChanges();
                }
                else if (cBoxTermekTipus.SelectedItem == "Ház")
                {
                    HAZ ujhaz = new HAZ();

                    ab.HAZ.Add(ujhaz);
                    ab.SaveChanges();
                }
            }

            this.DialogResult = true;
        }

        private void megsemButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
