using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Szt2_projekt
{
    class BejelentkezoVM
    {
        // Próbakomment by Kristóf hellóka ;)
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
                Megosztott.Logolas("Logged in: " + aktualisFelhasznalo.NEV);

                if (f.BEOSZTAS == "ADMIN")
                {
                    AdminWindow aw = new AdminWindow();
                    aw.Show();
                }
                else if (f.BEOSZTAS == "UGYINTEZO")
                {
                    UgyintezoWindow uw = new UgyintezoWindow();
                    uw.Show();
                }
                else
                {
                    UserWindow uw = new UserWindow();
                    uw.Show();
                }
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

            var z = db.FELHASZNALO.Where(f => f.NEV == felhasznalonev.ToUpper());

            if (z.Any())
            {

                var zz = z.Where(f => f.JELSZO == jelszo.ToUpper());

                if (zz.Any())
                    return z.First();

            }

            return null;
            
        }

    }
}
