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
    /// Interaction logic for AdminFelhasznaloModosítasWindow.xaml
    /// </summary>
    public partial class AdminFelhasznaloModosítasWindow : Window
    {
        string[] beosztasok;
        public AdminFelhasznaloModosítasWindow()
        {
            InitializeComponent();
            beosztasok = new string[3];
            beosztasok[0] = "Felhasználó";
            beosztasok[1] = "Ügyintéző";
            beosztasok[2] = "Admin";

            cBoxBeosztas.ItemsSource = beosztasok;
            

        }

        
    }
}
