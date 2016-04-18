using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Szt2_projekt.Admin;

namespace Szt2_projekt //szval érted,be sem tölti az ablakot
{
    class AdminVM
    {
        AdatbazisEntities ab = new AdatbazisEntities();


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
            ablak.FelhasznaloTablaGrid.DataContext = modositando;
            ablak.SzemelyesTablaGrid.DataContext = modositando.SZEMELYES_ADATOK;
            ablak.ShowDialog();
            modositando.JELSZO = ablak.passwordBox1.Password; // a passwordboxot nem lehet bindingolni
        }



        public void TermekHozzaAdas(AdminWindow aktualis)
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
         
          
        }
    }
}
