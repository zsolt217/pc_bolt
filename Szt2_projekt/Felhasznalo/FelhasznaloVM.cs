using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Szt2_projekt
{
    public class FelhasznaloVM : INotifyPropertyChanged
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
        public FelhasznaloVM()
        {
            felhasznalonev = String.Empty;
            vezeteknev = String.Empty;
            keresztnev = String.Empty;
            telefonszam = String.Empty;
            cim = String.Empty;
            email = String.Empty;
        }
        #region sajatadatok
        string felhasznalonev;
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


        public string Felhasznalonev
        {
            get { return felhasznalonev; }
            set { felhasznalonev = value; OnPropertyChanged(); }
        }
        #endregion
    }
}
