using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Szt2_projekt
{
    class BejelentkezoVM
    {
        // Próbakomment by Kristóf
        private FELHASZNALO aktualisFelhasznalo;

        public string AktualisFelhasznaloID
        {
            get
            {
                return aktualisFelhasznalo.FELHASZNALO_ID.ToString();
            }
        }

        public string AktualisFelhasznaloNev
        {
            get
            {
                return aktualisFelhasznalo.NEV;
            }
        }
        private AdatbazisEntities db;

        public BejelentkezoVM()
        {

            db = new AdatbazisEntities();

            aktualisFelhasznalo = new FELHASZNALO();

        }

        public bool Bejelentkezes(string felhasznalonev, string jelszo)
        {
            FELHASZNALO f = this.TartalmazasVizsgalat(felhasznalonev, jelszo);
            if (f != null)
            {
                aktualisFelhasznalo = f;
            }

            return f != null;
        }

        private bool TartalmazasVizsgalat(string felhasznalonev)
        {
            int tartalmaz = db.FELHASZNALO.Count(x => x.NEV.Equals(felhasznalonev.ToUpper()));
            return tartalmaz > 0;
        }

        private FELHASZNALO TartalmazasVizsgalat(string felhasznalonev, string jelszo)
        {
            var z = from f in db.FELHASZNALO
                    where f.NEV.Equals(felhasznalonev.ToUpper())
                    select f;

            return z.First();

            //var zu = db.FELHASZNALO.Where(x => x.NEV.Equals(felhasznalonev.ToUpper()) && x.JELSZO.Equals(jelszo.ToUpper())).First();
            //return f;
        }

        protected void Regisztracio()
        {

        }


    }
}
