using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Szt2_projekt.Admin;

namespace Szt2_projekt.Ugyintezo
{
    class AdminVM
    {
        AdatbazisEntities ab = new AdatbazisEntities();
       

        public void HozzaAd()
        {
            AdminFelhasznaloFelvetelWindow ablak = new AdminFelhasznaloFelvetelWindow();
            ablak.modositasButton.IsEnabled = false;
            ablak.ShowDialog();                 
        }

        public void Modosit(FELHASZNALO modositando)
        {
            AdminFelhasznaloFelvetelWindow ablak = new AdminFelhasznaloFelvetelWindow();
            ablak.felvetelButton.IsEnabled = false;
            ablak.DataContext = modositando;
            ablak.ShowDialog();
        }
    }
}
