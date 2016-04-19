using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Szt2_projekt
{
    public delegate void KompatibilitasVizsgalatEventHandler(object source, KompatibilitasEventArgs e);

    public class KompatibilitasEventArgs : EventArgs
    {
        string valtozott;

        public string Valtozott
        {
            get { return valtozott; }
        }
        public KompatibilitasEventArgs(string valtozott)
        {
            this.valtozott = valtozott;
        }
    }
    public class KompatibilitasVizsgalo
    {
        FelhasznaloVM VM;
        AdatbazisEntities DB;
        public KompatibilitasVizsgalo(FelhasznaloVM be)//lényege vm-ben jön létre esemény, BSL-ből kapom a VM referenciát és a kapcsolat akk VM meg ez az osztály között van
        {
            VM = be;
            VM.TermekValtozott += VM_TermekValtozott;
            DB = new AdatbazisEntities();
        }

        void VM_TermekValtozott(object source, KompatibilitasEventArgs e)
        {
            /*Amire figyelnem kell
             * hazméretszabvany==alaplapmeretszabvany
             * alaplap foglalata ==cpu foglalat
             * alaplap memtípus==memoriatipus
             * tapteljesitmeny>=(cpufogyasztas+gpufogyasztas)
             * továbbá minden VM lista végére teszek egy "*nincs elem kivalasztva"
             */
            if (e.Valtozott.Equals("SelectedAlaplap"))
            {
                if (!VM.SelectedAlaplap.TIPUSSZAM.Contains("*"))//ha nem nincs elem kiv. 
                {
                    List<HAZ> hazak = DB.HAZ.Where(x => x.MERETSZABVANY.Equals(VM.SelectedAlaplap.MERETSZABVANY)).ToList();
                    hazak.Add(new HAZ { TIPUSSZAM = "*nincs elem kivalasztva" });
                    VM.Hazak = hazak;
                    List<MEMORIA> memoriak = DB.MEMORIA.Where(x => x.MEMORIATIPUS.Equals(VM.SelectedAlaplap.MEMORIATIPUS)).ToList();
                    memoriak.Add(new MEMORIA { TIPUSSZAM = "*nincs elem kivalasztva" });
                    VM.Memoriak = memoriak;
                    List<CPU> cpuk = DB.CPU.Where(x => x.CPUFOGLALAT.Equals(VM.SelectedAlaplap.CPUFOGLALAT)).ToList();
                    cpuk.Add(new CPU { TIPUSSZAM = "*nincs elem kivalasztva" });
                    VM.Cpuk = cpuk;
                }
            }
            else if (e.Valtozott.Equals("SelectedCpu"))
            {

            }
            else if (e.Valtozott.Equals("SelectedGpu"))
            {

            }
            else if (e.Valtozott.Equals("SelectedMemoria"))
            {

            }
            else if (e.Valtozott.Equals("SelectedHaz"))
            {

            }
            else if (e.Valtozott.Equals("SelectedTap"))
            {

            }


        }



        //public bool Kompatibilis(ALAPLAP alaplap, MEMORIA memoria, HDD hdd, SSD ssd, TAP tap, HAZ haz, CPU cpu, GPU gpu)
        //{
        //    bool kompatibilis = false;
        //    decimal osszFogyasztas = cpu.FOGYASZTAS + gpu.FOGYASZTAS;

        //    if (alaplap.CPUFOGLALAT == cpu.CPUFOGLALAT &&
        //        alaplap.MEMORIATIPUS != memoria.MEMORIATIPUS &&
        //        tap.TELJESITMENY >= osszFogyasztas)
        //    {
        //        kompatibilis = true;
        //    }
        //    else if (alaplap.CPUFOGLALAT != cpu.CPUFOGLALAT)
        //    {
        //        MessageBox.Show("Az alaplap és a processzor nem kompatibilis egymással! Kérjük válasszon másik alaplapot vagy processzort!");
        //    }
        //    //else if (alaplap.MEMORIATIPUS == memoria.MEMORIATIPUS) //A memória memóriatípusa kötőjel nélküli az alaplap memóriatípusa kötőjeles! 
        //    //{
        //    //    MessageBox.Show("Az alaplap memóriatípusa és a memória típusa nem egyezik meg! Kérjük válasszon másik alaplapot vagy memóriát!");
        //    //}
        //    else if (tap.TELJESITMENY < osszFogyasztas)
        //    {
        //        MessageBox.Show("A táp nem tudja kiszolgálni az adott konfigurációt! Kérjük válasszon nagyobb tápot vagy másik konfigurációt!");
        //    }

        //    return kompatibilis;
        //}
    }
}
