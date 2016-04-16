using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Szt2_projekt.Kozos;

namespace Szt2_projekt
{
    class UgyintezoVM : INotifyPropertyChanged
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
        public UgyintezoVM()
        {
            termekvez = new TermekVezerlo();
            kezelo = new UzenetKezelo();
            kimenouzenet = String.Empty;
            kivalasztottCsoport = String.Empty;
            UzenetBetoltes();
        }

        #region Termekek

        TermekVezerlo termekvez;

        public string[] Csoportok
        {
            get { return termekvez.Csoportok; }
        }

        public List<string> KivalasztottCsoportTermekei
        {
            get
            {
                return termekvez.TermekListazas(kivalasztottCsoport);
            }
        }

        string kivalasztottCsoport;
        public string KivalasztottCsoport
        {
            get
            {
                return kivalasztottCsoport;
            }

            set
            {
                kivalasztottCsoport = value; 
                OnPropertyChanged("KivalasztottCsoportTermekei");
            }
        }

        #endregion

        #region Uzenetek
        UzenetKezelo kezelo;
        List<UZENETEK> bejovok;
        UZENETEK selectedUzenet;
        string kimenouzenet;
        public void UzenetBetoltes()
        {
            bejovok = kezelo.UzenetKereso(0, Rang.Ugyintezo);
            
        }
        public bool UzenetKuldes()
        {
            if (kimenouzenet != String.Empty && selectedUzenet != null)//láttamozza az üzenetet
            {
                kezelo.UzenetLattamozasModosit(selectedUzenet.UZENET_ID);
                UzenetBetoltes();
                OnPropertyChanged("Bejovok");
                return kezelo.Uzenetletrehozas(selectedUzenet.FELHASZNALO_ID, Uzenetirany.Felhasznalonak, kimenouzenet);
            }
            return false;
        }
        public string Kimenouzenet
        {
            get { return kimenouzenet; }
            set { kimenouzenet = value; }
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
