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
        private BejelentkezoVM felhKezelo;

        public MainWindow()
        {
            InitializeComponent();

            felhKezelo = new BejelentkezoVM();

        }

        private void regisztracioButton_Click(object sender, RoutedEventArgs e)
        {

            RegisztracioWindow regisztracioAblak = new RegisztracioWindow();
            regisztracioAblak.ShowDialog();

        }

        private void bejelentkezesButton_Click(object sender, RoutedEventArgs e)
        {
            string bevittFelhNev = felhasznalonevTextBox.Text;
            string bevittJelszo = jelszoPasswordBox.Password;

            if (bevittFelhNev != "" && bevittJelszo != "")
            {
                if (felhKezelo.Bejelentkezes(bevittFelhNev, bevittJelszo))
                {
                    UserWindow ablak = new UserWindow();
                    ablak.Show();

                    this.Close();
                }
                else
                {
                    MessageBox.Show("Hibás felhasználónév és/vagy jelszó!");
                }
            }
        }
    }
}
