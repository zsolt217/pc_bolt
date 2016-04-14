using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Diagnostics;

namespace Szt2_projekt
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
        AdatbazisEntities db;

        public bool Regisztralas()
        {
            if (felhasznalonev == string.Empty)
            {
                MessageBox.Show("Írjon be felhasználónevet!");
                return false;
            }
            if (jelszo1 == String.Empty || jelszo2 == String.Empty)
            {
                MessageBox.Show("Adjon meg jelszót!");
                return false;
            }
            if (jelszo1 != jelszo2)
            {
                MessageBox.Show("A két jelszó nem egyezik!");
                return false;
            }
            var van_e_felhasz = db.FELHASZNALO.Where(x => x.NEV.Equals(felhasznalonev));
            if (van_e_felhasz.Count() != 0)
            {
                MessageBox.Show("Már létezik ilyen nevű felhasználó");
                return false;
            }
            try
            {
                var p = db.FELHASZNALO.OrderByDescending(x => x.FELHASZNALO_ID).FirstOrDefault();
                int newId = (null == p ? 0 : (int)p.FELHASZNALO_ID) + 1;
                FELHASZNALO ujfelh = new FELHASZNALO { FELHASZNALO_ID = newId, JELSZO = jelszo1, BEOSZTAS = "FELHASZNALO", NEV = felhasznalonev };
                db.FELHASZNALO.Add(ujfelh);
                SZEMELYES_ADATOK ujadat = new SZEMELYES_ADATOK { FELHASZNALO_ID = newId, VEZETEKNEV = vezeteknev, KERESZTNEV = keresztnev, CIM = cim, EMAILCIM = email, TELEFONSZAM = telefonszam };
                db.SZEMELYES_ADATOK.Add(ujadat);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Megosztott.Logolas(e.InnerException.Message);
                MessageBox.Show("Hiba, nincs mentés!");
                return true;
            }

        }
        public RegisztraloVM()
        {
            db = new AdatbazisEntities();
            felhasznalonev = String.Empty;
            jelszo1 = String.Empty;
            jelszo2 = String.Empty;
            vezeteknev = String.Empty;
            keresztnev = String.Empty;
            telefonszam = String.Empty;
            cim = String.Empty;
            email = String.Empty;
        }



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
