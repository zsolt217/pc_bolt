using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Szt2_projekt.Felhasznalo
{
    public class KompatibilitasVizsgalo
    {
        public bool Kompatibilis(ALAPLAP alaplap, MEMORIA memoria, HDD hdd, SSD ssd, TAP tap, HAZ haz, CPU cpu, GPU gpu)
        {
            bool kompatibilis = false;
            decimal osszFogyasztas = cpu.FOGYASZTAS + gpu.FOGYASZTAS;

            if (alaplap.CPUFOGLALAT == cpu.CPUFOGLALAT &&
                alaplap.MEMORIATIPUS != memoria.MEMORIATIPUS &&
                tap.TELJESITMENY >= osszFogyasztas)
            {
                kompatibilis = true;
            }
            else if (alaplap.CPUFOGLALAT != cpu.CPUFOGLALAT)
            {
                MessageBox.Show("Az alaplap és a processzor nem kompatibilis egymással! Kérjük válasszon másik alaplapot vagy processzort!");
            }
            //else if (alaplap.MEMORIATIPUS == memoria.MEMORIATIPUS) //A memória memóriatípusa kötőjel nélküli az alaplap memóriatípusa kötőjeles! 
            //{
            //    MessageBox.Show("Az alaplap memóriatípusa és a memória típusa nem egyezik meg! Kérjük válasszon másik alaplapot vagy memóriát!");
            //}
            else if (tap.TELJESITMENY < osszFogyasztas)
            {
                MessageBox.Show("A táp nem tudja kiszolgálni az adott konfigurációt! Kérjük válasszon nagyobb tápot vagy másik konfigurációt!");
            }

            return kompatibilis;
        }
    }
}
