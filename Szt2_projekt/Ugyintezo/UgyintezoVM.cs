using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

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
            kezelo = new UzetnetKezelo();
            UzenetBetoltes();
        }
        #region Uzenetek
        UzetnetKezelo kezelo;
        List<UZENETEK> bejovok;
        UZENETEK selectedUzenet;
        string kimenouzenet;
        public void UzenetBetoltes()
        {
            bejovok = kezelo.UzenetKereso(0, Rang.Ugyintezo);
            kimenouzenet = String.Empty;
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
