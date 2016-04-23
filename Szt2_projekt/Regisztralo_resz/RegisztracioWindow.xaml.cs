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
    /// Interaction logic for RegisztracioWindow.xaml
    /// </summary>
    public partial class RegisztracioWindow : Window
    {
        RegisztraloVM VM;
        public RegisztracioWindow()
        {
            InitializeComponent();
            VM = new RegisztraloVM();
            DataContext = VM;
        }
        public RegisztracioWindow(decimal felhid) //adatmódosítás esetére
        {
            InitializeComponent();
            VM = new RegisztraloVM(felhid);
            this.Title = string.Format("Személyes adatok módosítása: {0}", VM.Felhasznalonev);
            this.regButton.Content = "Módosítás";
            DataContext = VM;
        }

        private void regButton_Click(object sender, RoutedEventArgs e)
        {
            VM.Jelszo1 = passwordBox1.Password;
            VM.Jelszo2 = passwordBox2.Password;
            if (VM.Regisztralas())
            {
                this.DialogResult = true;
            }
        }

        private void megsemButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
