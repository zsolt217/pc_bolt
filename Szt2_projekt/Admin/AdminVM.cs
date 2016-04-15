using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Szt2_projekt.Admin;

namespace Szt2_projekt.Ugyintezo
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
            ablak.DataContext = modositando;
            ablak.ShowDialog();
        }



        public void TermekHozzaAdas()
        {
            TermekModositoWindow ablak = new TermekModositoWindow();
            ablak.ShowDialog();
        }
        //A termékmódosító windowra majd az összes alkatrész tulajdonságot ki fogom pakolni,aztán ami nem szükséges az majd disabled lesz (pl alaplapnál nincs magszám)
        public void TermekModositas(AdminWindow aktualis)
        {
            TermekModositoWindow ablak = new TermekModositoWindow();
            if (aktualis.cBoxTermekTipus.SelectedItem == "Alaplap")
            {
                ablak.tBoxMagokSzama.IsEnabled = false;
            }
            ablak.ShowDialog();
          
        }
    }
}
