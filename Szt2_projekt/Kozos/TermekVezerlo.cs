using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Szt2_projekt.Kozos
{
    class TermekVezerlo
    {
        string[] csoportok;
        string[] jellemzok;
        Dictionary<string, List<string>> csoportJellemzok;

        public Dictionary<string, List<string>> CsoportJellemzok
        {
            get { return csoportJellemzok; }
        }

        public string[] Csoportok
        {
            get { return csoportok; }
        }
        public string[] Jellemzok
        {
            get { return jellemzok; }
        }

        AdatbazisEntities DB;
        public TermekVezerlo()
        {
            DB = new AdatbazisEntities();
            csoportok = new string[] { "Processzor", "Alaplap", "Videókártya", "Memória", "Winchester", "SSD", "Táp", "Ház" };
            jellemzok = new string[] { "CPUFOGLALAT","MEMORIASLOTOK","MEMORIATIPUS","CHIPSET","MERETSZABVANY","FOGYASZTAS","ORAJEL","MAGOK","MEMORIA","KAPACITAS","TELJESITMENY" };
            csoportJellemzok = new Dictionary<string, List<string>>();
            csoportJellemzok.Add(csoportok[0], new List<string> { jellemzok[0], jellemzok[5], jellemzok[6], jellemzok[7] });
            csoportJellemzok.Add(csoportok[1], new List<string> { jellemzok[0], jellemzok[1], jellemzok[2], jellemzok[3], jellemzok[4] });
            csoportJellemzok.Add(csoportok[2], new List<string> { jellemzok[8], jellemzok[5] });
            csoportJellemzok.Add(csoportok[3], new List<string> { jellemzok[2], jellemzok[6], jellemzok[9] });
            csoportJellemzok.Add(csoportok[4], new List<string> { jellemzok[9] });
            csoportJellemzok.Add(csoportok[5], new List<string> { jellemzok[9] });
            csoportJellemzok.Add(csoportok[6], new List<string> { jellemzok[10] });
            csoportJellemzok.Add(csoportok[7], new List<string> { jellemzok[4] });
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

        public object TermekAdatok(string termekcsop, string tipusszam)
        {
            if (termekcsop == csoportok[0])
            {
                var t = from akt in DB.CPU
                        where akt.TIPUSSZAM == tipusszam
                        select akt;
                return t.First();
            }
            else if (termekcsop == csoportok[1])
            {
                var t = from akt in DB.ALAPLAP
                        where akt.TIPUSSZAM == tipusszam
                        select akt;
                return t.First();
            }
            else if (termekcsop == csoportok[2])
            {
                var t = from akt in DB.GPU
                        where akt.TIPUSSZAM == tipusszam
                        select akt;
                return t.First();
            }
            else if (termekcsop == csoportok[3])
            {
                var t = from akt in DB.MEMORIA
                        where akt.TIPUSSZAM == tipusszam
                        select akt;
                return t.First();
            }
            else if (termekcsop == csoportok[4])
            {
                var t = from akt in DB.HDD
                        where akt.TIPUSSZAM == tipusszam
                        select akt;
                return t.First();
            }
            else if (termekcsop == csoportok[5])
            {
                var t = from akt in DB.SSD
                        where akt.TIPUSSZAM == tipusszam
                        select akt;
                return t.First();
            }
            else if (termekcsop == csoportok[6])
            {
                var t = from akt in DB.TAP
                        where akt.TIPUSSZAM == tipusszam
                        select akt;
                return t.First();
            }
            else if (termekcsop == csoportok[7])
            {
                var t = from akt in DB.HAZ
                        where akt.TIPUSSZAM == tipusszam
                        select akt;
                return t.First();
            }
            else
                return null;
        }

        public object TermekAdatok(string termekcsop, decimal id)
        {
            if (termekcsop == csoportok[0])
            {
                var t = from akt in DB.CPU
                        where akt.CPU_ID == id
                        select akt;
                return t.First();
            }
            else if (termekcsop == csoportok[1])
            {
                var t = from akt in DB.ALAPLAP
                        where akt.ALAPLAP_ID == id
                        select akt;
                return t.First();
            }
            else if (termekcsop == csoportok[2])
            {
                var t = from akt in DB.GPU
                        where akt.GPU_ID == id
                        select akt;
                return t.First();
            }
            else if (termekcsop == csoportok[3])
            {
                var t = from akt in DB.MEMORIA
                        where akt.MEMORIA_ID == id
                        select akt;
                return t.First();
            }
            else if (termekcsop == csoportok[4])
            {
                var t = from akt in DB.HDD
                        where akt.HDD_ID == id
                        select akt;
                return t.First();
            }
            else if (termekcsop == csoportok[5])
            {
                var t = from akt in DB.SSD
                        where akt.SSD_ID == id
                        select akt;
                return t.First();
            }
            else if (termekcsop == csoportok[6])
            {
                var t = from akt in DB.TAP
                        where akt.TAP_ID == id
                        select akt;
                return t.First();
            }
            else if (termekcsop == csoportok[7])
            {
                var t = from akt in DB.HAZ
                        where akt.HAZ_ID == id
                        select akt;
                return t.First();
            }
            else
                return null;
        }

        public bool TermekHozzaadas(string termekcsop, Dictionary<string, int> szamErtekek, Dictionary<string, string> stringErtekek)
        {
           
            if (termekcsop == csoportok[0])
            {
                CPU ujcpu = new CPU();
                ujcpu.CPU_ID = DB.CPU.Max(x => x.CPU_ID) + 1; // mindig a legnagyobb id-hoz az egyet
                ujcpu.TIPUSSZAM = stringErtekek["TIPUSSZAM"];
                ujcpu.AR = szamErtekek["AR"];
                ujcpu.CPUFOGLALAT = stringErtekek["CPUFOGLALAT"];
                ujcpu.FOGYASZTAS = szamErtekek["FOGYASZTAS"];
                ujcpu.SEBESSEG = szamErtekek["SEBESSEG"];
                ujcpu.MAGOK = szamErtekek["MAGOK"];
                DB.CPU.Add(ujcpu);
            }
            else if (termekcsop == csoportok[1])
            {
                ALAPLAP ujalaplap = new ALAPLAP();
                ujalaplap.ALAPLAP_ID = DB.ALAPLAP.Max(x => x.ALAPLAP_ID) + 1; // mindig a legnagyobb id-hoz az egyet
                ujalaplap.TIPUSSZAM = stringErtekek["TIPUSSZAM"];
                ujalaplap.AR = szamErtekek["AR"];
                ujalaplap.CPUFOGLALAT = stringErtekek["CPUFOGLALAT"];
                ujalaplap.MEMORIASLOTOK = szamErtekek["MEMORIASLOTOK"];
                ujalaplap.MEMORIATIPUS = stringErtekek["MEMORIATIPUS"];
                ujalaplap.CHIPSET = stringErtekek["CHIPSET"];
                ujalaplap.MERETSZABVANY = stringErtekek["MERETSZABVANY"];
                DB.ALAPLAP.Add(ujalaplap);
            }
            else if (termekcsop == csoportok[2])
            {
                GPU ujgpu = new GPU();
                ujgpu.GPU_ID = DB.GPU.Max(x => x.GPU_ID) + 1; // mindig a legnagyobb id-hoz az egyet
                ujgpu.TIPUSSZAM = stringErtekek["TIPUSSZAM"];
                ujgpu.AR = szamErtekek["AR"];
                ujgpu.MEMORIA = szamErtekek["MEMORIA"];
                ujgpu.FOGYASZTAS = szamErtekek["FOGYASZTAS"];
                DB.GPU.Add(ujgpu);

            }
            else if (termekcsop == csoportok[3])
            {
                MEMORIA ujmemoria = new MEMORIA();
                ujmemoria.MEMORIA_ID = DB.MEMORIA.Max(x => x.MEMORIA_ID) + 1; // mindig a legnagyobb id-hoz az egyet
                ujmemoria.TIPUSSZAM = stringErtekek["TIPUSSZAM"];
                ujmemoria.AR = szamErtekek["AR"];
                ujmemoria.MEMORIATIPUS = stringErtekek["MEMORIATIPUS"];
                ujmemoria.SEBESSEG = szamErtekek["SEBESSEG"];
                ujmemoria.KAPACITAS = szamErtekek["KAPACITAS"];
                DB.MEMORIA.Add(ujmemoria);
            }
            else if (termekcsop == csoportok[4])
            {
                HDD ujhdd = new HDD();
                ujhdd.HDD_ID = DB.HDD.Max(x => x.HDD_ID) + 1; // mindig a legnagyobb id-hoz az egyet
                ujhdd.TIPUSSZAM = stringErtekek["TIPUSSZAM"];
                ujhdd.AR = szamErtekek["AR"];
                ujhdd.KAPACITAS = szamErtekek["KAPACITAS"];
                DB.HDD.Add(ujhdd);
            }
            else if (termekcsop == csoportok[5])
            {
                SSD ujhdd = new SSD();
                ujhdd.SSD_ID = DB.SSD.Max(x => x.SSD_ID) + 1; // mindig a legnagyobb id-hoz az egyet
                ujhdd.TIPUSSZAM = stringErtekek["TIPUSSZAM"];
                ujhdd.AR = szamErtekek["AR"];
                ujhdd.KAPACITAS = szamErtekek["KAPACITAS"];
                DB.SSD.Add(ujhdd);
            }
            else if (termekcsop == csoportok[6])
            {
                TAP ujtap = new TAP();
                ujtap.TAP_ID = DB.TAP.Max(x => x.TAP_ID) + 1; // mindig a legnagyobb id-hoz az egyet
                ujtap.TIPUSSZAM = stringErtekek["TIPUSSZAM"];
                ujtap.AR = szamErtekek["AR"];
                ujtap.TELJESITMENY = szamErtekek["TELJESITMENY"];
                DB.TAP.Add(ujtap);
            }
            else if (termekcsop == csoportok[7])
            {
                HAZ ujhaz = new HAZ();
                ujhaz.HAZ_ID = DB.HAZ.Max(x => x.HAZ_ID) + 1; // mindig a legnagyobb id-hoz az egyet
                ujhaz.TIPUSSZAM = stringErtekek["TIPUSSZAM"];
                ujhaz.AR = szamErtekek["AR"];
                ujhaz.MERETSZABVANY = stringErtekek["MERETSZABVANY"];
                DB.HAZ.Add(ujhaz);
            }

            try
            {
                DB.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                // Retrieve the error messages as a list of strings.
                var errorMessages = ex.EntityValidationErrors
                        .SelectMany(x => x.ValidationErrors)
                        .Select(x => x.ErrorMessage);

                // Join the list to a single string.
                var fullErrorMessage = string.Join("; ", errorMessages);

                // Combine the original exception message with the new one.
                var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);

                // Throw a new DbEntityValidationException with the improved exception message.
                throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
            }

            return true; 
        }

        public bool TermekModositas(string termekcsop, decimal id, Dictionary<string, int> szamErtekek, Dictionary<string, string> stringErtekek)
        {
            object o = TermekAdatok(termekcsop, id);

            if (termekcsop == csoportok[0])
            {
                CPU ujcpu = o as CPU;
                ujcpu.TIPUSSZAM = stringErtekek["TIPUSSZAM"];
                ujcpu.AR = szamErtekek["AR"];
                ujcpu.CPUFOGLALAT = stringErtekek["CPUFOGLALAT"];
                ujcpu.FOGYASZTAS = szamErtekek["FOGYASZTAS"];
                ujcpu.SEBESSEG = szamErtekek["SEBESSEG"];
                ujcpu.MAGOK = szamErtekek["MAGOK"];
            }
            else if (termekcsop == csoportok[1])
            {
                ALAPLAP ujalaplap = o as ALAPLAP;
                ujalaplap.TIPUSSZAM = stringErtekek["TIPUSSZAM"];
                ujalaplap.AR = szamErtekek["AR"];
                ujalaplap.CPUFOGLALAT = stringErtekek["CPUFOGLALAT"];
                ujalaplap.MEMORIASLOTOK = szamErtekek["MEMORIASLOTOK"];
                ujalaplap.MEMORIATIPUS = stringErtekek["MEMORIATIPUS"];
                ujalaplap.CHIPSET = stringErtekek["CHIPSET"];
                ujalaplap.MERETSZABVANY = stringErtekek["MERETSZABVANY"];
            }
            else if (termekcsop == csoportok[2])
            {
                GPU ujgpu = o as GPU;
                ujgpu.TIPUSSZAM = stringErtekek["TIPUSSZAM"];
                ujgpu.AR = szamErtekek["AR"];
                ujgpu.MEMORIA = szamErtekek["MEMORIA"];
                ujgpu.FOGYASZTAS = szamErtekek["FOGYASZTAS"];

            }
            else if (termekcsop == csoportok[3])
            {
                MEMORIA ujmemoria = o as MEMORIA;
                ujmemoria.TIPUSSZAM = stringErtekek["TIPUSSZAM"];
                ujmemoria.AR = szamErtekek["AR"];
                ujmemoria.MEMORIATIPUS = stringErtekek["MEMORIATIPUS"];
                ujmemoria.SEBESSEG = szamErtekek["SEBESSEG"];
                ujmemoria.KAPACITAS = szamErtekek["KAPACITAS"];
            }
            else if (termekcsop == csoportok[4])
            {
                HDD ujhdd = o as HDD;
                ujhdd.TIPUSSZAM = stringErtekek["TIPUSSZAM"];
                ujhdd.AR = szamErtekek["AR"];
                ujhdd.KAPACITAS = szamErtekek["KAPACITAS"];
            }
            else if (termekcsop == csoportok[5])
            {
                SSD ujhdd = o as SSD;
                ujhdd.TIPUSSZAM = stringErtekek["TIPUSSZAM"];
                ujhdd.AR = szamErtekek["AR"];
                ujhdd.KAPACITAS = szamErtekek["KAPACITAS"];
            }
            else if (termekcsop == csoportok[6])
            {
                TAP ujtap = o as TAP;
                ujtap.TIPUSSZAM = stringErtekek["TIPUSSZAM"];
                ujtap.AR = szamErtekek["AR"];
                ujtap.TELJESITMENY = szamErtekek["TELJESITMENY"];
            }
            else if (termekcsop == csoportok[7])
            {
                HAZ ujhaz = o as HAZ;
                ujhaz.TIPUSSZAM = stringErtekek["TIPUSSZAM"];
                ujhaz.AR = szamErtekek["AR"];
                ujhaz.MERETSZABVANY = stringErtekek["MERETSZABVANY"];
            }

            try
            {
                DB.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                // Retrieve the error messages as a list of strings.
                var errorMessages = ex.EntityValidationErrors
                        .SelectMany(x => x.ValidationErrors)
                        .Select(x => x.ErrorMessage);

                // Join the list to a single string.
                var fullErrorMessage = string.Join("; ", errorMessages);

                // Combine the original exception message with the new one.
                var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);

                // Throw a new DbEntityValidationException with the improved exception message.
                throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
            }

            return true;
        }
    }
}
