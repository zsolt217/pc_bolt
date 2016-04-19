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
using Szt2_projekt.Admin;

namespace Szt2_projekt
{
    /// <summary>
    /// Interaction logic for UgyintezoWindow.xaml
    /// </summary>
    public partial class UgyintezoWindow : Window
    {
        UgyintezoVM VM;
        
        public UgyintezoWindow()
        {
            InitializeComponent();
            VM = new UgyintezoVM();
            DataContext = VM;
        }
        private void ValaszKuldese_Click(object sender, RoutedEventArgs e)
        {
            if (VM.UzenetKuldes())
            {
                MessageBox.Show("Sikeres küldés");
            }
            else MessageBox.Show("Sikertelen küldés");
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

        private void ujTermekButton_Click(object sender, RoutedEventArgs e)
        {
            TermekModositoWindow ablak = new TermekModositoWindow();
            ablak.modositasButton.IsEnabled = false;
            if (ablak.ShowDialog() == true)
            {
                VM.KivalasztottCsoport = VM.KivalasztottCsoport; // trükk, hogy frissítse a listbox tartalmát a binding (termék típusnév változáskor)
            }
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            if (lBoxAdminTermekek.SelectedIndex != -1)
            {
                TermekModositoWindow ablak = new TermekModositoWindow(VM.KivalasztottCsoport, VM.KivalasztottTipusszam);
                ablak.felvetelButton.IsEnabled = false;
                ablak.modositasButton.IsEnabled = true;
                if (ablak.ShowDialog() == true)
                {
                    VM.KivalasztottCsoport = VM.KivalasztottCsoport; // trükk, hogy frissítse a listbox tartalmát a binding (termék típusnév változáskor)
                }
            }
            
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (lBoxAdminTermekek.SelectedIndex != -1)
            {
                if (VM.TermekTorles)
                {
                    VM.KivalasztottCsoport = VM.KivalasztottCsoport; // trükk, hogy frissítse a listbox tartalmát a binding (termék törléskor)
                    MessageBox.Show("Sikeres törlés");
                }
                    
                else 
                    MessageBox.Show("Sikertelen törlés!\nA termékre van aktív rendelés.");
            }
            
        }

    }
}
