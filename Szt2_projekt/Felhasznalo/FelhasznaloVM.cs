using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Szt2_projekt
{
    public class FelhasznaloVM : INotifyPropertyChanged
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
        public FelhasznaloVM(decimal felhid)
        {
            id = felhid;
            felhasznalonev = String.Empty;
            vezeteknev = String.Empty;
            keresztnev = String.Empty;
            telefonszam = String.Empty;
            cim = String.Empty;
            email = String.Empty;
            kezelo = new UzenetKezelo();
            kimenouzenet = String.Empty;
            UzenetBetoltes();
        }
        #region sajatadatok
        decimal id;
        string felhasznalonev;
        string vezeteknev;
        string keresztnev;
        string telefonszam;
        string cim;
        string email;

        public decimal Id
        {
            get { return id; }
        }
        public string Email
        {
            get { return email; }
            set { email = value; OnPropertyChanged(); }
        }

        public string Cim
        {
            get { return cim; }
            set { cim = value; OnPropertyChanged(); }
        }

        public string Telefonszam
        {
            get { return telefonszam; }
            set { telefonszam = value; OnPropertyChanged(); }
        }


        public string Vezeteknev
        {
            get { return vezeteknev; }
            set { vezeteknev = value; OnPropertyChanged(); }
        }

        public string Keresztnev
        {
            get { return keresztnev; }
            set { keresztnev = value; OnPropertyChanged(); }
        }


        public string Felhasznalonev
        {
            get { return felhasznalonev; }
            set { felhasznalonev = value; OnPropertyChanged(); }
        }
        #endregion

        #region Uzenetek
        UzenetKezelo kezelo;
        List<UZENETEK> bejovok;
        UZENETEK selectedUzenet;
        string kimenouzenet;
        public void UzenetBetoltes()
        {
            bejovok = kezelo.UzenetKereso(id, Rang.Felhasznalo);
        }
        public bool UzenetKuldes()
        {
            if (kimenouzenet != String.Empty && selectedUzenet != null)//láttamozza az üzenetet
            {
                kezelo.UzenetLattamozasModosit(selectedUzenet.UZENET_ID);
                UzenetBetoltes();
                OnPropertyChanged("Bejovok");
                return kezelo.Uzenetletrehozas(selectedUzenet.FELHASZNALO_ID, Uzenetirany.Ugyintezonek, kimenouzenet);
            }
            return false;
        }
        public string Kimenouzenet
        {
            get { return kimenouzenet; }
            set { kimenouzenet = value; OnPropertyChanged(); }
        }

        public UZENETEK SelectedUzenet
        {
            get { return selectedUzenet; }
            set
            {
                selectedUzenet = value;
                OnPropertyChanged("UzenetSzoveg");
                kimenouzenet = String.Empty;
                OnPropertyChanged("Kimenouzenet");
            }
        }
        public string UzenetSzoveg
        {
            get { return (null == SelectedUzenet ? String.Empty : SelectedUzenet.SZOVEG); }
        }
        public List<UZENETEK> Bejovok
        {
            get { return bejovok; }

        }

        #endregion
    }
}
