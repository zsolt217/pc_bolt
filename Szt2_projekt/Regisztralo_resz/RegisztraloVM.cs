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
    enum Irasmod { UjLetrehoz, Modosit }
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
        decimal felhid;//módosítás esetére
        Irasmod irasmod;
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
            switch (irasmod)//kétféle használat mód szerint elágazás
            {
                case Irasmod.UjLetrehoz:
                    var van_e_felhasz = db.FELHASZNALO.Where(x => x.NEV.Equals(felhasznalonev)).ToList();
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
                    break;
                case Irasmod.Modosit:
                    try
                    {
                        foreach (var item in db.FELHASZNALO)
                        {
                            Debug.WriteLine(item.NEV + ": " + item.SZEMELYES_ADATOK.CIM);
                        }
                        db.FELHASZNALO.Where(x => x.FELHASZNALO_ID == felhid).SingleOrDefault().NEV = felhasznalonev;
                        db.FELHASZNALO.Where(x => x.FELHASZNALO_ID == felhid).SingleOrDefault().SZEMELYES_ADATOK.CIM = cim;
                        db.FELHASZNALO.Where(x => x.FELHASZNALO_ID == felhid).SingleOrDefault().SZEMELYES_ADATOK.TELEFONSZAM = telefonszam;
                        db.FELHASZNALO.Where(x => x.FELHASZNALO_ID == felhid).SingleOrDefault().SZEMELYES_ADATOK.EMAILCIM = email;
                        db.FELHASZNALO.Where(x => x.FELHASZNALO_ID == felhid).SingleOrDefault().SZEMELYES_ADATOK.KERESZTNEV = keresztnev;
                        db.FELHASZNALO.Where(x => x.FELHASZNALO_ID == felhid).SingleOrDefault().SZEMELYES_ADATOK.VEZETEKNEV = vezeteknev;
                        db.SaveChanges();
                        foreach (var item in db.FELHASZNALO)
                        {
                            Debug.WriteLine(item.NEV + ": " + item.SZEMELYES_ADATOK.CIM);
                        }
                        return true;
                    }
                    catch (Exception e)
                    {
                        Megosztott.Logolas(e.InnerException.Message);
                        MessageBox.Show("Hiba, nincs mentés!");
                        return true;
                    }
                    break;
                default: return false; break;
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
            irasmod = Irasmod.UjLetrehoz;
        } //alap regisztálás esetén

        public RegisztraloVM(decimal felhasznaloid)// felh módsításra
        {
            db = new AdatbazisEntities();
            try
            {
                var aktFelhasznalo = db.SZEMELYES_ADATOK.Where(x => (int)x.FELHASZNALO_ID == (int)felhasznaloid).Select(x => new { felhnev = x.FELHASZNALO.NEV, cim = x.CIM, email = x.EMAILCIM, keresztnev = x.KERESZTNEV, vezeteknev = x.VEZETEKNEV, telefonszam = x.TELEFONSZAM }).ToList();
                if (aktFelhasznalo.Count() == 1)
                {
                    Cim = aktFelhasznalo.First().cim;
                    Email = aktFelhasznalo.First().email;
                    Keresztnev = aktFelhasznalo.First().keresztnev;
                    Vezeteknev = aktFelhasznalo.First().vezeteknev;
                    Felhasznalonev = aktFelhasznalo.First().felhnev;
                    felhid = felhasznaloid;
                }
            }
            catch (Exception e)//hiba esetén logolás
            {
                Megosztott.Logolas(e.InnerException.Message);
            }
            jelszo1 = String.Empty;
            jelszo2 = String.Empty;
            irasmod = Irasmod.Modosit;
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
