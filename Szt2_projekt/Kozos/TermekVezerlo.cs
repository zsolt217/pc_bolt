using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Szt2_projekt.Kozos
{
    class TermekVezerlo
    {
        string[] csoportok;

        public string[] Csoportok
        {
            get { return csoportok; }
        }

        AdatbazisEntities DB;
        public TermekVezerlo()
        {
            DB = new AdatbazisEntities();
            csoportok = new string[] { "Processzor", "Alaplap", "Videókártya", "Memória", "Winchester", "SSD", "Táp", "Ház" };
        }

        public List<string> TermekListazas(string termekcsop)
        {
            if (termekcsop == csoportok[0])
            {
                var t = from akt in DB.CPU
                        select akt.TIPUSSZAM;
                return t.ToList();
            }
            else if (termekcsop == csoportok[1])
            {
                var t = from akt in DB.ALAPLAP
                        select akt.TIPUSSZAM;
                return t.ToList();
            }
            else if (termekcsop == csoportok[2])
            {
                var t = from akt in DB.GPU
                        select akt.TIPUSSZAM;
                return t.ToList();
            }
            else if (termekcsop == csoportok[3])
            {
                var t = from akt in DB.MEMORIA
                        select akt.TIPUSSZAM;
                return t.ToList();
            }
            else if (termekcsop == csoportok[4])
            {
                var t = from akt in DB.HDD
                        select akt.TIPUSSZAM;
                return t.ToList();
            }
            else if (termekcsop == csoportok[5])
            {
                var t = from akt in DB.SSD
                        select akt.TIPUSSZAM;
                return t.ToList();
            }
            else if (termekcsop == csoportok[6])
            {
                var t = from akt in DB.TAP
                        select akt.TIPUSSZAM;
                return t.ToList();
            }
            else if (termekcsop == csoportok[7])
            {
                var t = from akt in DB.HAZ
                        select akt.TIPUSSZAM;
                return t.ToList();
            }
            else
                return null;

        }
    }
}
