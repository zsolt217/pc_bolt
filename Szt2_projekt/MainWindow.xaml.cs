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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Szt2_projekt
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private BejelentkezoVM bejelentkezo;

        public MainWindow()
        {
            InitializeComponent();

            bejelentkezo = new BejelentkezoVM();

        }

        private void regisztracioButton_Click(object sender, RoutedEventArgs e)
        {

            RegisztracioWindow regisztracioAblak = new RegisztracioWindow();
            regisztracioAblak.Show();
            this.Close();

        }

        private void bejelentkezesButton_Click(object sender, RoutedEventArgs e)
        {
            string bevittFelhNev = felhasznalonevTextBox.Text;
            string bevittJelszo = jelszoPasswordBox.Password;

            if (bevittFelhNev == "admin" && bevittJelszo == "admin") // ha adminként akarok belépni,egyelőre ez a felhasználónév és jelszó,de a bejelentkezoVM-ben kéne 1 külön cucc az adminnak is,nem?
            {
                AdminWindow adminablak = new AdminWindow();
                adminablak.Show();

                this.Close();
            }
            else if (bevittFelhNev != "" && bevittJelszo != "")
            {
                if (bejelentkezo.Bejelentkezes(bevittFelhNev, bevittJelszo))
                    this.Close();
                else
                {
                    MessageBox.Show("Hibás felhasználónév és/vagy jelszó!");
                    Megosztott.Logolas("Hibás felhasználónév és/vagy jelszó! User: " + bevittFelhNev + ", Pass: " + bevittJelszo);
                }
            }
        }
    }
}
