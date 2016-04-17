using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Szt2_projekt.Kozos;

namespace Szt2_projekt.Admin
{
    class TermekModositoVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        TermekVezerlo termekvez;

        public TermekModositoVM()
        {
            termekvez = new TermekVezerlo();
        }

        public string[] Csoportok
        {
            get { return termekvez.Csoportok; }
        }

        public string[] Jellemzok
        {
            get { return termekvez.Jellemzok; }
        }

        public List<string> KivalasztottCsoportJellemzoi
        {
            get { return kivalasztottCsoport != null ? termekvez.CsoportJellemzok[kivalasztottCsoport] : null; }
        }

        string kivalasztottCsoport;
        public string KivalasztottCsoport
        {
            get { return kivalasztottCsoport; }
            set
            {
                kivalasztottCsoport = value;
                OnPropertyChanged();
                OnPropertyChanged("KivalasztottCsoportJellemzoi");
            }
        }

        #region Termekjellemzok
        string tipusszam;
        string cpufoglalat;
        int ar;
        int orajel;
        int magok;
        string memoriatipus;
        string chipset;
        int memoriaslotok;
        string meretszabvany;
        int memoria;
        int kapacitas;
        int fogyasztas;
        int teljesitmeny;

        public string Tipusszam
        {
            get { return tipusszam; }
            set { tipusszam = value; }
        }
        public string Cpufoglalat
        {
            get { return cpufoglalat; }
            set { cpufoglalat = value; }
        }
        public int Ar
        {
            get { return ar; }
            set { ar = value; }
        }
        public int Orajel
        {
            get { return orajel; }
            set { orajel = value; }
        }
        public int Magok
        {
            get { return magok; }
            set { magok = value; }
        }
        public string Memoriatipus
        {
            get { return memoriatipus; }
            set { memoriatipus = value; }
        }
        public string Chipset
        {
            get { return chipset; }
            set { chipset = value; }
        }
        public int Memoriaslotok
        {
            get { return memoriaslotok; }
            set { memoriaslotok = value; }
        }
        public string Meretszabvany
        {
            get { return meretszabvany; }
            set { meretszabvany = value; }
        }
        public int Memoria
        {
            get { return memoria; }
            set { memoria = value; }
        }
        public int Kapacitas
        {
            get { return kapacitas; }
            set { kapacitas = value; }
        }
        public int Fogyasztas
        {
            get { return fogyasztas; }
            set { fogyasztas = value; }
        }
        public int Teljesitmeny
        {
            get { return teljesitmeny; }
            set { teljesitmeny = value; }
        }
        #endregion

        public Dictionary<string,int> BevittSzamErtekek
        {
            // textboxokba beírt számok továbbítása VM felé kulcs-érték párban
            get
            {
                return 
                    new Dictionary<string, int> {
                        {"AR", ar },
                        {"SEBESSEG", orajel},
                        {"MEMORIASLOTOK", memoriaslotok},
                        {"MAGOK", magok},
                        {"KAPACITAS", kapacitas},
                        {"FOGYASZTAS", fogyasztas},
                        {"TELJESITMENY", teljesitmeny}
                    }; 
            }
        }

        public Dictionary<string, string> BevittStringErtekek
        {
            // textboxokba beírt szöveges adatok továbbítása VM felé kulcs-érték párban
            get
            {
                return
                    new Dictionary<string, string> {
                        {"TIPUSSZAM", tipusszam},
                        {"CPUFOGLALAT", cpufoglalat},
                        {"MEMORIATIPUS", memoriatipus},
                        {"CHIPSET", chipset},
                        {"MERETSZABVANY", meretszabvany}
                    };
            }
        }

        public bool TermekHozzaadas()
        {
            return termekvez.TermekHozzaadas(kivalasztottCsoport, BevittSzamErtekek, BevittStringErtekek);
        }

    }
}
