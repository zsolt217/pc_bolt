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
        
        public RegisztracioWindow()
        {
            InitializeComponent();
        }

        private void regButton_Click(object sender, RoutedEventArgs e)
        {
            string pass1 = passwordBox1.Password;
            string pass2 = passwordBox2.Password;
            Debug.Print(pass1 + "/" + pass2);
        }
    }
}
