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
            AdminFelhasznaloModosítasWindow ablak = new AdminFelhasznaloModosítasWindow();
            ablak.modositasButton.IsEnabled = false;
            ablak.ShowDialog();                 
        }

        public void Modosit()
        {
            AdminFelhasznaloModosítasWindow ablak = new AdminFelhasznaloModosítasWindow();
            ablak.felvetelButton.IsEnabled = false;
            ablak.ShowDialog();
        }
    }
}
