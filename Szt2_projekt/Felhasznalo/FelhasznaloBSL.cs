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
        KompatibilitasVizsgalo vizsgalo;
        public FelhasznaloBSL(decimal felhasznaloid, FelhasznaloVM Felhasznalovm)
        {
            VM = Felhasznalovm;
            DB = new AdatbazisEntities();
            FelhasznaloAdatbetoltesVMbe(felhasznaloid);
            TermekekBetoltese();
            vizsgalo = new KompatibilitasVizsgalo(VM); //feliratkozik az ablak termékváltozás eseményére
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

        void TermekekBetoltese()
        {
            List<ALAPLAP> alaplapok = DB.ALAPLAP.ToList();
            alaplapok.Add(new ALAPLAP { TIPUSSZAM = "*nincs elem kivalasztva" });
            VM.Alaplapok = alaplapok;
            VM.SelectedAlaplap = VM.Alaplapok.Last();
            List<CPU> cpuk = DB.CPU.ToList();
            cpuk.Add(new CPU { TIPUSSZAM = "*nincs elem kivalasztva" });
            VM.Cpuk = cpuk;
            VM.SelectedCpu = VM.Cpuk.Last();
            List<GPU> gpuk = DB.GPU.ToList();
            gpuk.Add(new GPU { TIPUSSZAM = "*nincs elem kivalasztva" });
            VM.Gpuk = gpuk;
            VM.SelectedGpu = VM.Gpuk.Last();
            List<HAZ> hazak = DB.HAZ.ToList();
            hazak.Add(new HAZ { TIPUSSZAM = "*nincs elem kivalasztva" });
            VM.Hazak = hazak;
            VM.SelectedHaz = VM.Hazak.Last();
            List<HDD> hddk = DB.HDD.ToList();
            hddk.Add(new HDD { TIPUSSZAM = "*nincs elem kivalasztva" });
            VM.Hddk = hddk;
            VM.SelectedHdd = VM.Hddk.Last();
            List<MEMORIA> memoriak = DB.MEMORIA.ToList();
            memoriak.Add(new MEMORIA { TIPUSSZAM = "*nincs elem kivalasztva" });
            VM.Memoriak = memoriak;
            VM.SelectedMemoria = VM.Memoriak.Last();
            List<SSD> ssdk = DB.SSD.ToList();
            ssdk.Add(new SSD { TIPUSSZAM = "*nincs elem kivalasztva" });
            VM.Ssdk = ssdk;
            VM.SelectedSsd = VM.Ssdk.Last();
            List<TAP> tapok = DB.TAP.ToList();
            tapok.Add(new TAP { TIPUSSZAM = "*nincs elem kivalasztva" });
            VM.Tapok = tapok;
            VM.SelectedTap = VM.Tapok.Last();
        }
        //public void RendelesMentes()
        //{
        //    if (VM.SelectedAlaplap.TIPUSSZAM.Contains("*")||VM.SelectedCpu.TIPUSSZAM.Contains("*")||
        //        VM.SelectedHaz.TIPUSSZAM.Contains("*")||VM.SelectedTap.TIPUSSZAM.Contains("*")||VM.SelectedHdd.TIPUSSZAM.Contains("*")||
        //        VM.SelectedMemoria.TIPUSSZAM.Contains("*"))

        //    {
        //        MessageBox.Show("Nem sikerült a megrendelést rögzíteni, mert a konfiguráció hiányos! Kérjük válassz ki minden minden alkatrészből egyet!");
        //    }
        //    el
        //    decimal osszFogyasztas = vm.FOGYASZTAS + gpu.FOGYASZTAS;

        //    if (alaplap.CPUFOGLALAT == cpu.CPUFOGLALAT &&
        //        alaplap.MEMORIATIPUS != memoria.MEMORIATIPUS &&
        //        tap.TELJESITMENY >= osszFogyasztas)
        //    {
        //        kompatibilis = true;
        //    }
        //    //else
        //    //{
        //    //    if (kompatibilitas.Kompatibilis(alaplap, memoria, hdd, ssd, tap, haz, cpu, gpu))
        //    //    {
        //    //        MessageBox.Show("Sikeresen hozzáadva a rendelésekhez!");
        //    //        //TODO RENDELÉSEKHEZ HOZZÁADNI!
        //    //    }
        //    //}
        //}

    }
}
