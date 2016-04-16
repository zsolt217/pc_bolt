using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szt2_projekt
{
    class FelhasznaloBSL
    {
        AdatbazisEntities DB;
        FelhasznaloVM VM;
        public FelhasznaloBSL(decimal felhasznaloid, FelhasznaloVM Felhasznalovm)
        {
            VM = Felhasznalovm;
            DB = new AdatbazisEntities();
            FelhasznaloAdatbetoltesVMbe(felhasznaloid);
        }
        void FelhasznaloAdatbetoltesVMbe(decimal felhasznaloid)//felhasználóvm elemeinek feltöltése
        {
            try
            {
                var aktFelhasznalo = DB.SZEMELYES_ADATOK.Where(x => (int)x.FELHASZNALO_ID == (int)felhasznaloid).Select(x => new { felhnev = x.FELHASZNALO.NEV, cim = x.CIM, email = x.EMAILCIM, keresztnev = x.KERESZTNEV, vezeteknev = x.VEZETEKNEV, telefonszam = x.TELEFONSZAM }).ToList();
                if (aktFelhasznalo.Count() == 1)
                {
                    VM.Cim = aktFelhasznalo.First().cim;
                    VM.Email = aktFelhasznalo.First().email;
                    VM.Keresztnev = aktFelhasznalo.First().keresztnev;
                    VM.Vezeteknev = aktFelhasznalo.First().vezeteknev;
                    VM.Felhasznalonev = aktFelhasznalo.First().felhnev;
                }
            }
            catch (Exception e)//hiba esetén logolás
            {
                Megosztott.Logolas(e.InnerException.Message);
            }
        }


    }
}
