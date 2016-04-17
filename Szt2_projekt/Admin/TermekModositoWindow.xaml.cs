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
        TermekModositoVM VM;
        
        public TermekModositoWindow()
        {
            InitializeComponent();
            VM = new TermekModositoVM();
            this.DataContext = VM;
        }
        
       
        private void felvetelButton_Click(object sender, RoutedEventArgs e) //felvétel
        {
            if (VM.TermekHozzaadas())
                this.DialogResult = true;
            else
                MessageBox.Show("Sikertelen termék hozzáadás!");  
        }

        private void megsemButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void cBoxTermekTipus_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // a kiválasztott termékcsoport jellemzői 
            List<string> jellemzok = VM.KivalasztottCsoportJellemzoi;

            // stackpanel összes dockpaneljét listázza: egy dockpanel = egy jellemző
            stPanelJellemzok.Visibility = Visibility.Visible;
            felvetelButton.IsEnabled = true;
            UIElementCollection element = stPanelJellemzok.Children;
            List<FrameworkElement> lstElement = element.Cast<FrameworkElement>().ToList();
            var lstControl = lstElement.OfType<DockPanel>();

            // a kiválaszott termékcsoporthoz NEM tartozó jellemzők DP elrejtése x:Name alapján 
            foreach (DockPanel dp in lstControl)
            {
                if (jellemzok.Contains(dp.Name.ToUpper()))
                    dp.Visibility = Visibility.Visible;
                else
                    dp.Visibility = Visibility.Collapsed;
            }

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // betöltéskor ne jelenjen meg az összes jellemző, amikor nincs kiválasztva termékcsoport
            stPanelJellemzok.Visibility = Visibility.Hidden;
            felvetelButton.IsEnabled = false;
        }
    }
}
