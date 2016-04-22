using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Szt2_projekt
{
    public enum RendelesAllapot { Befogadva, Osszeallitas_alatt, Kiszallitas_alatt, Lezart }
    class RendelesVezerlo
    {
        AdatbazisEntities DB;
        Rang rang;
        public RendelesVezerlo(Rang beosztas)
        {
            DB = new AdatbazisEntities();
            rang = beosztas;
        }

        public List<RENDELESEK> RendelesBetoltes()
        {
            if (DB.RENDELESEK.Count() > 0)
            {
                if (rang == Rang.Ugyintezo)
                {
                    try
                    {
                        return DB.RENDELESEK.Where(x => !x.ALLAPOT.Equals("LEZART")).ToList();
                    }
                    catch (Exception e)
                    {
                        Megosztott.Logolas("rendelesvezerlotol " + e.InnerException.Message);
                        return null;
                    }
                }
                else
                {
                    //Marcinak lesz hasznos
                    return null;
                }
            }
            else return null;
        }
        public bool AllapotModosit(decimal id, RendelesAllapot allapot)
        {
            try
            {
                switch (allapot)
                {
                    case RendelesAllapot.Befogadva:
                        DB.RENDELESEK.Where(x => x.RENDELES_ID == id).SingleOrDefault().ALLAPOT = "BEFOGADVA";
                        DB.SaveChanges();
                        return true;
                        break;
                    case RendelesAllapot.Osszeallitas_alatt:
                        DB.RENDELESEK.Where(x => x.RENDELES_ID == id).SingleOrDefault().ALLAPOT = "OSSZEALLITAS_ALATT";
                        DB.SaveChanges();
                        return true;
                        break;
                    case RendelesAllapot.Kiszallitas_alatt:
                        DB.RENDELESEK.Where(x => x.RENDELES_ID == id).SingleOrDefault().ALLAPOT = "KISZALLITAS_ALATT";
                        DB.SaveChanges();
                        return true;
                        break;
                    case RendelesAllapot.Lezart:
                        DB.RENDELESEK.Where(x => x.RENDELES_ID == id).SingleOrDefault().ALLAPOT = "LEZART";
                        DB.SaveChanges();
                        return true;
                        break;
                    default:
                        return false;
                        break;
                }
            }
            catch (Exception e)
            {
                Megosztott.Logolas("rendelesvezerlotol " + e.InnerException.Message);
                return false;
            }
        }

        public void RendelesMentes(RENDELESEK rendeles)
        {
            try
            {
                DB.RENDELESEK.Add(rendeles);
                DB.SaveChanges();
                MessageBox.Show("Rendelés leadva!");
            }
            catch (Exception hiba)
            {
                Megosztott.Logolas(hiba.InnerException.Message);
                MessageBox.Show("Adatbázishiba, nem sikerült rögzíteni.");
            }
        }
    }
}
