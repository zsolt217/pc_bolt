using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Szt2_projekt.Admin;
using Szt2_projekt.Kozos;

namespace Szt2_projekt //szval érted,be sem tölti az ablakot
{
    class AdminVM : INotifyPropertyChanged
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

        //AdatbazisEntities ab = new AdatbazisEntities();
        public AdminVM()
        {
            termekvez = new TermekVezerlo();
            kivalasztottCsoport = String.Empty;
        }

        public void FelhasznaloHozzaAdas()
        {
            AdminFelhasznaloFelvetelWindow ablak = new AdminFelhasznaloFelvetelWindow();
            ablak.modositasButton.IsEnabled = false;
            ablak.ShowDialog();
        }

        public void FelhasznaloModositas(FELHASZNALO modositando)
        {
            AdminFelhasznaloFelvetelWindow ablak = new AdminFelhasznaloFelvetelWindow();
            ablak.felvetelButton.IsEnabled = false;
            ablak.Title = string.Format("Felhasználó módosítás: {0} ({1})", modositando.NEV, modositando.BEOSZTAS); 
            ablak.FelhasznaloTablaGrid.DataContext = modositando;
            ablak.SzemelyesTablaGrid.DataContext = modositando.SZEMELYES_ADATOK;
            ablak.ShowDialog();
            if (ablak.passwordBox1.Password != string.Empty)
            {
                modositando.JELSZO = ablak.passwordBox1.Password; // a passwordboxot nem lehet bindingolni
            }

        }


        #region Termekek
        TermekVezerlo termekvez;

        public string[] Csoportok
        {
            get { return termekvez.Csoportok; }
        }

        public List<string> KivalasztottCsoportTermekei
        {
            get { return termekvez.TermekListazas(kivalasztottCsoport); }
        }

        string kivalasztottCsoport;
        public string KivalasztottCsoport
        {
            get { return kivalasztottCsoport; }
            set
            {
                kivalasztottCsoport = value;
                OnPropertyChanged("KivalasztottCsoportTermekei");
            }
        }

        string kivalasztottTipusszam;
        public string KivalasztottTipusszam
        {
            get { return kivalasztottTipusszam; }
            set { kivalasztottTipusszam = value; OnPropertyChanged(); }
        }

        public bool TermekTorles
        {
            get { return termekvez.TermekTorles(kivalasztottCsoport, kivalasztottTipusszam); }
        }

        /* public void TermekHozzaAdas(AdminWindow aktualis)
         {
             TermekModositoWindow ablak = new TermekModositoWindow();
             ablak.modositasButton.IsEnabled = false;
             ablak.ShowDialog();
             aktualis.FrissitTermek();
         }
         public void TermekModositas(AdminWindow aktualis)
         {
             TermekModositoWindow ablak = new TermekModositoWindow();
             ablak.felvetelButton.IsEnabled = false;
             ablak.cBoxTermekTipus.SelectedItem= aktualis.lBoxAdminTermekek.SelectedItem;
             ablak.ShowDialog();


         }*/
        #endregion
    }
}
