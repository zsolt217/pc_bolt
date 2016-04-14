using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szt2_projekt
{
    public static class Megosztott
    {
        public static void Logolas(string szoveg)
        {
            using (System.IO.StreamWriter file =
           new System.IO.StreamWriter(@"log.txt", true))
            {
                file.WriteLine(DateTime.Now + Environment.NewLine + szoveg);
            }
        }

        public enum Beosztasok 
        {
            Admin,
            Ügyintéző,
            Felhasználó
        }

    }
}
