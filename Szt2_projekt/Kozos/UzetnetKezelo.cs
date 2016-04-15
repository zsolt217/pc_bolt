using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szt2_projekt
{
    public enum Uzenetirany { Felhasznalonak, Ugyintezonek }
    public enum Rang { Felhasznalo, Ugyintezo }
    class UzetnetKezelo
    {
        AdatbazisEntities DB;
        public UzetnetKezelo()
        {
            DB = new AdatbazisEntities();
        }

        public bool Uzenetletrehozas(decimal felhid, Uzenetirany irany, string uzenet)
        {
            try
            {
                var p = DB.UZENETEK.OrderByDescending(x => x.UZENET_ID).FirstOrDefault();
                int newId = (null == p ? 0 : (int)p.UZENET_ID) + 1;
                switch (irany)
                {
                    case Uzenetirany.Felhasznalonak:
                        DB.UZENETEK.Add(new UZENETEK { FELHASZNALO_ID = felhid, DATUM = DateTime.Now, IRANY = false, LATTA_E = false, SZOVEG = uzenet, UZENET_ID = newId }); //irány=igaz-ügyitézőnek
                        DB.SaveChanges();
                        return true;
                        break;
                    case Uzenetirany.Ugyintezonek:
                        DB.UZENETEK.Add(new UZENETEK { FELHASZNALO_ID = felhid, DATUM = DateTime.Now, IRANY = true, LATTA_E = false, SZOVEG = uzenet, UZENET_ID = newId }); //irány=igaz-ügyitézőnek
                        DB.SaveChanges();
                        return true;
                        break;
                    default:
                        return false;
                        break;
                }

            }
            catch (Exception hiba)
            {
                Megosztott.Logolas(hiba.InnerException.Message);
                return false;
            }

        }
        
        public List<UZENETEK> UzenetKereso(decimal felhid, Rang rang)
        {
            try
            {
                switch (rang)
                {
                    case Rang.Felhasznalo:
                        return DB.UZENETEK.Where(x => x.FELHASZNALO_ID == felhid).ToList();
                        break;
                    case Rang.Ugyintezo:
                        return DB.UZENETEK.Where(x => x.IRANY == true).ToList();//ügyintézőnek az össze központba címzett megy
                        break;
                    default: return null; break;
                }
            }
            catch (Exception hiba)
            {
                Megosztott.Logolas(hiba.InnerException.Message);
                return null;
            }
        }
        public void UzenetLattamozasModosit()
        { }
    }
}
