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

namespace Szt2_projekt
{
    /// <summary>
    /// Interaction logic for UserWindow.xaml
    /// </summary>
    public partial class UserWindow : Window
    {
        FelhasznaloVM VM;
        FelhasznaloBSL BS;
        decimal id;

        public UserWindow(decimal felhasznaloid)
        {
            InitializeComponent();
            VM = new FelhasznaloVM();
            BS = new FelhasznaloBSL (felhasznaloid,VM);
            id = felhasznaloid;
            DataContext = VM;
            
        }

        private void MegrendelésButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Kijelentkezo_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MainWindow uj = new MainWindow();
            uj.Show();
        }

        private void FelhAdatModosit_Click(object sender, RoutedEventArgs e)
        {
            RegisztracioWindow uj = new RegisztracioWindow(id);
            uj.ShowDialog();
        }
    }
}
