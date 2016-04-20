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
                    VM.felhasznalovaltoztatasengedelyezes = false;
                    List<MEMORIA> memoriak = DB.MEMORIA.Where(x => x.MEMORIATIPUS.Equals(VM.SelectedAlaplap.MEMORIATIPUS)).ToList();
                    memoriak.Add(new MEMORIA { TIPUSSZAM = "*nincs elem kivalasztva" });
                    if (!VM.SelectedMemoria.TIPUSSZAM.Contains("*"))
                    {
                        MEMORIA selected = VM.SelectedMemoria;
                        VM.Memoriak = memoriak;
                        VM.SelectedMemoria = selected;
                    }
                    else
                    {
                        VM.Memoriak = memoriak;
                        VM.SelectedMemoria = VM.Memoriak.Last();
                    }
                    List<CPU> cpuk = DB.CPU.Where(x => ((x.CPUFOGLALAT.Equals(VM.SelectedAlaplap.CPUFOGLALAT)) &&
                        (VM.SelectedTap.TIPUSSZAM.Contains("*") ? true : x.FOGYASZTAS < VM.SelectedTap.TELJESITMENY))).ToList(); //abban az esetben ha van táp kiválasztva akk csak kisebb fogyasztású tápot enged kiválasztani mint a táp teljesítménye
                    cpuk.Add(new CPU { TIPUSSZAM = "*nincs elem kivalasztva" });
                    if (!VM.SelectedCpu.TIPUSSZAM.Contains("*"))
                    {
                        CPU selected = VM.SelectedCpu;
                        VM.Cpuk = cpuk;
                        VM.SelectedCpu = selected;
                    }
                    else
                    {
                        VM.Cpuk = cpuk;
                        VM.SelectedCpu = VM.Cpuk.Last();
                    }
                    List<HAZ> hazak = DB.HAZ.Where(x => x.MERETSZABVANY.Equals(VM.SelectedAlaplap.MERETSZABVANY)).ToList();
                    hazak.Add(new HAZ { TIPUSSZAM = "*nincs elem kivalasztva" });
                    if (!VM.SelectedHaz.TIPUSSZAM.Contains("*"))
                    {
                        HAZ selected = VM.SelectedHaz;
                        VM.Hazak = hazak;
                        VM.SelectedHaz = selected;
                    }
                    else
                    {
                        VM.Hazak = hazak;
                        VM.SelectedHaz = hazak.Last();
                    }
                    VM.felhasznalovaltoztatasengedelyezes = true;
                }
                else//nincs elem kiválasztva-ra módosítva
                {
                    VM.felhasznalovaltoztatasengedelyezes = false;
                    List<MEMORIA> memoriak = DB.MEMORIA.ToList();
                    memoriak.Add(new MEMORIA { TIPUSSZAM = "*nincs elem kivalasztva" });
                    if (!VM.SelectedMemoria.TIPUSSZAM.Contains("*"))
                    {
                        MEMORIA selected = VM.SelectedMemoria;
                        VM.Memoriak = memoriak;
                        VM.SelectedMemoria = selected;
                    }
                    else
                    {
                        VM.Memoriak = memoriak;
                        VM.SelectedMemoria = VM.Memoriak.Last();
                    }
                    List<CPU> cpuk = DB.CPU.Where(x => ((VM.SelectedTap.TIPUSSZAM.Contains("*") ? true : x.FOGYASZTAS < VM.SelectedTap.TELJESITMENY))).ToList(); //abban az esetben ha van táp kiválasztva akk csak kisebb fogyasztású tápot enged kiválasztani mint a táp teljesítménye
                    cpuk.Add(new CPU { TIPUSSZAM = "*nincs elem kivalasztva" });
                    if (!VM.SelectedCpu.TIPUSSZAM.Contains("*"))
                    {
                        CPU selected = VM.SelectedCpu;
                        VM.Cpuk = cpuk;
                        VM.SelectedCpu = selected;
                    }
                    else
                    {
                        VM.Cpuk = cpuk;
                        VM.SelectedCpu = VM.Cpuk.Last();
                    }
                    List<HAZ> hazak = DB.HAZ.ToList();
                    hazak.Add(new HAZ { TIPUSSZAM = "*nincs elem kivalasztva" });
                    if (!VM.SelectedHaz.TIPUSSZAM.Contains("*"))
                    {
                        HAZ selected = VM.SelectedHaz;
                        VM.Hazak = hazak;
                        VM.SelectedHaz = selected;
                    }
                    else
                    {
                        VM.Hazak = hazak;
                        VM.SelectedHaz = hazak.Last();
                    }
                    VM.felhasznalovaltoztatasengedelyezes = true;

                }
            }
            else if (e.Valtozott.Equals("SelectedCpu"))
            {
                if (!VM.SelectedCpu.TIPUSSZAM.Contains("*"))
                {
                    VM.felhasznalovaltoztatasengedelyezes = false;
                    List<ALAPLAP> alaplapok = DB.ALAPLAP.Where(x => x.CPUFOGLALAT.Equals(VM.SelectedCpu.CPUFOGLALAT)).ToList();
                    alaplapok.Add(new ALAPLAP { TIPUSSZAM = "*nincs elem kivalasztva" });
                    if (!VM.SelectedAlaplap.TIPUSSZAM.Contains("*"))
                    {
                        ALAPLAP selected = VM.SelectedAlaplap;
                        VM.Alaplapok = alaplapok;
                        VM.SelectedAlaplap = alaplapok.Where(x => x.ALAPLAP_ID == selected.ALAPLAP_ID).Single();
                    }
                    else
                    {
                        VM.Alaplapok = alaplapok;
                        VM.SelectedAlaplap = VM.Alaplapok.Last();
                    }
                    List<TAP> tapok = DB.TAP.Where(x => (x.TELJESITMENY > (VM.SelectedCpu.FOGYASZTAS)) &&
                        (VM.SelectedGpu.TIPUSSZAM.Contains("*") ? true : ((VM.SelectedCpu.FOGYASZTAS + VM.SelectedGpu.FOGYASZTAS) <= x.TELJESITMENY))).ToList();//ha van gpu kiválasztva akk a cpuval együtt a fogyasztásnak kisebb egyenlőnek kelllennie a táp teljestíményével
                    tapok.Add(new TAP { TIPUSSZAM = "*nincs elem kivalasztva" });
                    if (!VM.SelectedTap.TIPUSSZAM.Contains("*"))
                    {
                        TAP selected = VM.SelectedTap;
                        VM.Tapok = tapok;
                        VM.SelectedTap = tapok.Where(x => x.TAP_ID == selected.TAP_ID).Single();
                    }
                    else
                    {
                        VM.Tapok = tapok;
                        VM.SelectedTap = VM.Tapok.Last();
                    }
                    VM.felhasznalovaltoztatasengedelyezes = true;
                }
                else//nincs kiválasztvává módosítva
                {
                    VM.felhasznalovaltoztatasengedelyezes = false;
                    List<ALAPLAP> alaplapok = DB.ALAPLAP.Where(x => (VM.SelectedHaz.TIPUSSZAM.Contains("*") ? true : x.MERETSZABVANY.Contains(VM.SelectedHaz.MERETSZABVANY)) &&
                        (VM.SelectedMemoria.TIPUSSZAM.Contains("*") ? true : x.MEMORIATIPUS.Contains(VM.SelectedMemoria.MEMORIATIPUS))).ToList(); //ha van memória vagy táp akk ennek megfelelően szűri az alaplapokat
                    alaplapok.Add(new ALAPLAP { TIPUSSZAM = "*nincs elem kivalasztva" });
                    if (!VM.SelectedAlaplap.TIPUSSZAM.Contains("*"))
                    {
                        ALAPLAP selected = VM.SelectedAlaplap;
                        VM.Alaplapok = alaplapok;
                        VM.SelectedAlaplap = alaplapok.Where(x => x.ALAPLAP_ID == selected.ALAPLAP_ID).Single();

                    }
                    else
                    {
                        VM.Alaplapok = alaplapok;
                        VM.SelectedAlaplap = VM.Alaplapok.Last();
                    }
                    List<TAP> tapok = DB.TAP.Where(x => (VM.SelectedGpu.TIPUSSZAM.Contains("*") ? true : ((VM.SelectedGpu.FOGYASZTAS) <= x.TELJESITMENY))).ToList();//ha van gpu kiválasztva akk a cpuval együtt a fogyasztásnak kisebb egyenlőnek kelllennie a táp teljestíményével
                    if (!VM.SelectedTap.TIPUSSZAM.Contains("*"))
                    {
                        TAP selected = VM.SelectedTap;
                        VM.Tapok = tapok;
                        VM.SelectedTap = tapok.Where(x => x.TAP_ID == selected.TAP_ID).Single();
                    }
                    else
                    {
                        VM.Tapok = tapok;
                        VM.SelectedTap = VM.Tapok.Last();
                    }
                    VM.felhasznalovaltoztatasengedelyezes = true;
                }
            }
            else if (e.Valtozott.Equals("SelectedGpu"))
            {
                VM.felhasznalovaltoztatasengedelyezes = false;
                if (!VM.SelectedGpu.TIPUSSZAM.Contains("*"))
                {
                    List<TAP> tapok = DB.TAP.Where(x => x.TELJESITMENY >= ((VM.SelectedCpu.TIPUSSZAM.Contains("*") ? 0 : VM.SelectedCpu.FOGYASZTAS) + VM.SelectedGpu.FOGYASZTAS)).ToList();
                    tapok.Add(new TAP { TIPUSSZAM = "*nincs elem kivalasztva" });
                    if (!VM.SelectedTap.TIPUSSZAM.Contains("*"))
                    {
                        TAP selected = VM.SelectedTap;
                        VM.Tapok = tapok;
                        VM.SelectedTap = selected;
                    }
                    else
                    {
                        VM.Tapok = tapok;
                        VM.SelectedTap = VM.Tapok.Last();
                    }
                }
                else
                {
                    List<TAP> tapok = DB.TAP.Where(x => x.TELJESITMENY >= ((VM.SelectedCpu.TIPUSSZAM.Contains("*") ? 0 : VM.SelectedCpu.FOGYASZTAS))).ToList();
                    tapok.Add(new TAP { TIPUSSZAM = "*nincs elem kivalasztva" });
                    if (!VM.SelectedTap.TIPUSSZAM.Contains("*"))
                    {
                        TAP selected = VM.SelectedTap;
                        VM.Tapok = tapok;
                        VM.SelectedTap = selected;
                    }
                    else
                    {
                        VM.Tapok = tapok;
                        VM.SelectedTap = VM.Tapok.Last();
                    }
                }
                VM.felhasznalovaltoztatasengedelyezes = true;

            }
            else if (e.Valtozott.Equals("SelectedMemoria"))
            {
                VM.felhasznalovaltoztatasengedelyezes = false;
                if (!VM.SelectedMemoria.TIPUSSZAM.Contains("*"))
                {
                    List<ALAPLAP> alaplapok = DB.ALAPLAP.Where(x => x.MEMORIATIPUS.Equals(VM.SelectedMemoria.MEMORIATIPUS) && (VM.SelectedHaz.TIPUSSZAM.Contains("*") ? true : x.MERETSZABVANY.Contains(VM.SelectedHaz.MERETSZABVANY)) && (VM.SelectedCpu.TIPUSSZAM.Contains("*") ? true : x.CPUFOGLALAT.Contains(VM.SelectedCpu.CPUFOGLALAT))).ToList();
                    alaplapok.Add(new ALAPLAP { TIPUSSZAM = "*nincs elem kivalasztva" });
                    if (!VM.SelectedAlaplap.TIPUSSZAM.Contains("*"))
                    {
                        ALAPLAP selected = VM.SelectedAlaplap;
                        VM.Alaplapok = alaplapok;
                        VM.SelectedAlaplap = selected;
                    }
                    else
                    {
                        VM.Alaplapok = alaplapok;
                        VM.SelectedAlaplap = VM.Alaplapok.Last();
                    }
                }
                else
                {
                    List<ALAPLAP> alaplapok = DB.ALAPLAP.Where(x => (VM.SelectedHaz.TIPUSSZAM.Contains("*") ? true : x.MERETSZABVANY.Contains(VM.SelectedHaz.MERETSZABVANY)) && (VM.SelectedCpu.TIPUSSZAM.Contains("*") ? true : x.CPUFOGLALAT.Contains(VM.SelectedCpu.CPUFOGLALAT))).ToList(); //ha van memória vagy táp akk ennek megfelelően szűri az alaplapokat
                    alaplapok.Add(new ALAPLAP { TIPUSSZAM = "*nincs elem kivalasztva" });
                    if (!VM.SelectedAlaplap.TIPUSSZAM.Contains("*"))
                    {
                        ALAPLAP selected = VM.SelectedAlaplap;
                        VM.Alaplapok = alaplapok;
                        VM.SelectedAlaplap = selected;
                    }
                    else
                    {
                        VM.Alaplapok = alaplapok;
                        VM.SelectedAlaplap = VM.Alaplapok.Last();
                    }
                }
            }
            else if (e.Valtozott.Equals("SelectedHaz"))
            {
                VM.felhasznalovaltoztatasengedelyezes = false;
                if (!VM.SelectedHaz.TIPUSSZAM.Contains("*"))
                {
                    List<ALAPLAP> alaplapok = DB.ALAPLAP.Where(x => x.MEMORIATIPUS.Equals(VM.SelectedMemoria.MEMORIATIPUS) && (x.MERETSZABVANY.Contains(VM.SelectedHaz.MERETSZABVANY)) && (VM.SelectedCpu.TIPUSSZAM.Contains("*") ? true : x.CPUFOGLALAT.Contains(VM.SelectedCpu.CPUFOGLALAT))).ToList();
                    alaplapok.Add(new ALAPLAP { TIPUSSZAM = "*nincs elem kivalasztva" });
                    if (!VM.SelectedAlaplap.TIPUSSZAM.Contains("*"))
                    {
                        ALAPLAP selected = VM.SelectedAlaplap;
                        VM.Alaplapok = alaplapok;
                        VM.SelectedAlaplap = selected;
                    }
                    else
                    {
                        VM.Alaplapok = alaplapok;
                        VM.SelectedAlaplap = VM.Alaplapok.Last();
                    }
                }
                else
                {
                    List<ALAPLAP> alaplapok = DB.ALAPLAP.Where(x => (VM.SelectedHaz.TIPUSSZAM.Contains("*") ? true : x.MERETSZABVANY.Contains(VM.SelectedHaz.MERETSZABVANY)) && (VM.SelectedCpu.TIPUSSZAM.Contains("*") ? true : x.CPUFOGLALAT.Contains(VM.SelectedCpu.CPUFOGLALAT))).ToList(); //ha van memória vagy táp akk ennek megfelelően szűri az alaplapokat
                    alaplapok.Add(new ALAPLAP { TIPUSSZAM = "*nincs elem kivalasztva" });
                    if (!VM.SelectedAlaplap.TIPUSSZAM.Contains("*"))
                    {
                        ALAPLAP selected = VM.SelectedAlaplap;
                        VM.Alaplapok = alaplapok;
                        VM.SelectedAlaplap = selected;
                    }
                    else
                    {
                        VM.Alaplapok = alaplapok;
                        VM.SelectedAlaplap = VM.Alaplapok.Last();
                    }
                }
                VM.felhasznalovaltoztatasengedelyezes = true;
            }
            else if (e.Valtozott.Equals("SelectedTap"))
            {
                VM.felhasznalovaltoztatasengedelyezes = false;
                if (!VM.SelectedTap.TIPUSSZAM.Contains("*"))
                {
                    List<CPU> cpuk = DB.CPU.Where(x => x.FOGYASZTAS < VM.SelectedTap.TELJESITMENY).ToList();
                    cpuk.Add(new CPU { TIPUSSZAM = "*nincs elem kivalasztva" });
                    VM.Cpuk = cpuk;
                    List<GPU> gpuk = DB.GPU.Where(x => x.FOGYASZTAS < VM.SelectedTap.TELJESITMENY).ToList();
                    gpuk.Add(new GPU { TIPUSSZAM = "*nincs elem kivalasztva" });
                    VM.Gpuk = gpuk;
                }
                VM.felhasznalovaltoztatasengedelyezes = true;
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
