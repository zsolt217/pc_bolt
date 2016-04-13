using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Szt2_projekt.Regisztralo_resz
{
    public class RegisztraloVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
        string felhasznalonev;
       string jelszo1;
        string jelszo2;
        string vezeteknev;
        string keresztnev;
        string telefonszam;
        string cim;
        string email;

       

        public string Email
        {
            get { return email; }
            set { email = value; OnPropertyChanged(); }
        }

        public string Cim
        {
            get { return cim; }
            set { cim = value; OnPropertyChanged(); }
        }

        public string Telefonszam
        {
            get { return telefonszam; }
            set { telefonszam = value; OnPropertyChanged(); }
        }


        public string Vezeteknev
        {
            get { return vezeteknev; }
            set { vezeteknev = value; OnPropertyChanged(); }
        }

        public string Keresztnev
        {
            get { return keresztnev; }
            set { keresztnev = value; OnPropertyChanged(); }
        }
        public string Jelszo2
        {
            get { return jelszo2; }
            set { jelszo2 = value; OnPropertyChanged(); }
        }

        public string Jelszo1
        {
            get { return jelszo1; }
            set { jelszo1 = value; OnPropertyChanged(); }
        }

        public string Felhasznalonev
        {
            get { return felhasznalonev; }
            set { felhasznalonev = value; OnPropertyChanged(); }
        }
    }
    
}
