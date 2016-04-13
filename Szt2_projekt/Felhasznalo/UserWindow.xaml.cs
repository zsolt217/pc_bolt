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
        private BejelentkezoVM fk;

        public UserWindow()
        {
            InitializeComponent();
            fk = new BejelentkezoVM();
            
        }

        private void MegrendelésButton_Click(object sender, RoutedEventArgs e)
        {
            MegrendelesWindow ujablak = new MegrendelesWindow();
            ujablak.ShowDialog();
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = fk;
        }
    }
}
