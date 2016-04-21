using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Szt2_projekt.Felhasznalo
{
    public class KedvencVezerlo
    {
        private AdatbazisEntities DB;

        public KedvencVezerlo()
        {
            DB = new AdatbazisEntities();
        }

        public List<KEDVENCEK> KedvencekBetoltese(decimal felh_id)
        {
            List<KEDVENCEK> aktFelhasznaloKedvencei = DB.KEDVENCEK.Where(x => x.FELHASZNALO_ID == felh_id).ToList();
            return aktFelhasznaloKedvencei;
        }

        public void MentesKedvencekbe(decimal felh_id, KEDVENCEK leendoKedvenc)
        {
            try
            {
                List<KEDVENCEK> aktFelhasznaloKedvencei = DB.KEDVENCEK.Where(x => x.FELHASZNALO_ID == felh_id).ToList();

                //Ha a felhasználónak még egyetlen kedvence sincsen.
                if (aktFelhasznaloKedvencei.Count == 0)
                {
                    DB.KEDVENCEK.Add(new KEDVENCEK
                    {
                        KEDVENCEK_ID = 1,
                        FELHASZNALO_ID = felh_id,
                        ALAPLAP_ID = leendoKedvenc.ALAPLAP_ID,
                        CPU_ID = leendoKedvenc.CPU_ID,
                        GPU_ID = leendoKedvenc.GPU_ID,
                        MEMORIA_ID = leendoKedvenc.MEMORIA_ID,
                        HDD_ID = leendoKedvenc.HDD_ID,
                        SSD_ID = leendoKedvenc.SSD_ID,
                        HAZ_ID = leendoKedvenc.HAZ_ID,
                        TAP_ID = leendoKedvenc.TAP_ID
                    });
                }
                else //Ha vannak kedvencei megvizsgáljuk, hogy van e már ilyen kedvenc 
                {
                    bool letezikKedvenc = false;
                    foreach (var letezoKedvenc in aktFelhasznaloKedvencei)
                    {
                        if (LetezikEMar(leendoKedvenc, letezoKedvenc))
                        {
                            letezikKedvenc = true;
                            break;
                        }
                    }

                    //Ha még nincs ilyen kedvence a felhasználónak
                    if (letezikKedvenc == false)
                    {
                        decimal last_ID = DB.KEDVENCEK.Count();
                        DB.KEDVENCEK.Add(new KEDVENCEK
                        {
                            KEDVENCEK_ID = last_ID + 1,
                            FELHASZNALO_ID = felh_id,
                            ALAPLAP_ID = leendoKedvenc.ALAPLAP_ID,
                            CPU_ID = leendoKedvenc.CPU_ID,
                            GPU_ID = leendoKedvenc.GPU_ID,
                            MEMORIA_ID = leendoKedvenc.MEMORIA_ID,
                            HDD_ID = leendoKedvenc.HDD_ID,
                            SSD_ID = leendoKedvenc.SSD_ID,
                            HAZ_ID = leendoKedvenc.HAZ_ID,
                            TAP_ID = leendoKedvenc.TAP_ID
                        });
                    }
                }
                DB.SaveChanges();
            }
            catch (Exception hiba)
            {
                Megosztott.Logolas(hiba.InnerException.Message);
            }
        }

        // Megvizsgálja hogy 2 kedvenc egyenlő e. A felhasználó id-t nem vizsgálja 
        // hisz egy adott felhasználóra nézzük hogy az ő aktuális kedvencei között ott van e amit mi szeretnénk felvenni.
        private bool LetezikEMar(KEDVENCEK leendoKedvenc, KEDVENCEK letezoKedvenc)
        {
            if (leendoKedvenc.ALAPLAP_ID == letezoKedvenc.ALAPLAP_ID &&
                leendoKedvenc.CPU_ID == letezoKedvenc.CPU_ID &&
                leendoKedvenc.MEMORIA_ID == letezoKedvenc.MEMORIA_ID &&
                leendoKedvenc.GPU_ID == letezoKedvenc.GPU_ID &&
                leendoKedvenc.HAZ_ID == letezoKedvenc.HAZ_ID &&
                leendoKedvenc.TAP_ID == letezoKedvenc.TAP_ID &&
                leendoKedvenc.HDD_ID == letezoKedvenc.HDD_ID &&
                leendoKedvenc.SSD_ID == letezoKedvenc.SSD_ID
                )
            {
                return true;
            }

            return false;
        }
    }

}
