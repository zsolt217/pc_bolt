using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szt2_projekt.Ugyintezo
{
    class AdminVM
    {
        AdatbazisEntities ab = new AdatbazisEntities();
        public void HozzaAd()
        {
            FELHASZNALO ujfelhasznalo = new FELHASZNALO();
            ujfelhasznalo.FELHASZNALO_ID = ab.FELHASZNALO.Count() + 1;
            ujfelhasznalo.NEV = "KisPista";
            ujfelhasznalo.BEOSZTAS = "Paraszt";
            ujfelhasznalo.JELSZO = "traktor";
            //ujfelhasznalo.RENDELESEK = new List<RENDELESEK>();
            //ujfelhasznalo.UZENETEK = new List<UZENETEK>();
            ab.FELHASZNALO.Add(ujfelhasznalo);
            ab.SaveChanges();
        }
    }
}
