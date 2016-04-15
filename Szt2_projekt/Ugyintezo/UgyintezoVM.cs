using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Szt2_projekt
{
    class UgyintezoVM:INotifyPropertyChanged
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
        }
        public string Kimenouzenet
        {
            get { return kimenouzenet; }
            set { kimenouzenet = value; }
        }

        public UZENETEK SelectedUzenet
        {
            get { return selectedUzenet; }
            set { selectedUzenet = value; }
        }
        public List<UZENETEK> Bejovok
        {
            get { return bejovok; }
            
        }

        #endregion

        
    }
}
