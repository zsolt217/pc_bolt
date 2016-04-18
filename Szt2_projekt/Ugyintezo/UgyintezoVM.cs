using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Szt2_projekt.Kozos;
using System.Windows;

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
            rendvezerlo = new RendelesVezerlo(Rang.Ugyintezo);
            rendelesek = rendvezerlo.RendelesBetoltes();
        }

        #region Termekek

        TermekVezerlo termekvez;

        public string[] Csoportok
        {
            get { return termekvez.Csoportok; }
        }

        public List<string> KivalasztottCsoportTermekei
        {
            get { return termekvez.TermekListazas(kivalasztottCsoport); }
        }

        string kivalasztottCsoport;
        public string KivalasztottCsoport
        {
            get { return kivalasztottCsoport; }
            set
            {
                kivalasztottCsoport = value; 
                OnPropertyChanged("KivalasztottCsoportTermekei");
            }
        }

        string kivalasztottTipusszam;
        public string KivalasztottTipusszam
        {
            get { return kivalasztottTipusszam; }
            set { kivalasztottTipusszam = value; OnPropertyChanged(); }
        }

        /*public void KivalasztottTermekAdatai()
        {
            termekvez.Termekcsop = kivalasztottCsoport;
            termekvez.Tipusszam = kivalasztottTipusszam;
        }*/

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

        #region Rendelesek
        List<RENDELESEK> rendelesek;
             
                
        RendelesVezerlo rendvezerlo;
        public List<RENDELESEK> Rendelesek
        {
            get { return rendelesek; }
            //set { rendelesek = value; }
        }
        RENDELESEK selectedrendeles;

        public RENDELESEK Selectedrendeles
        {
            get { return selectedrendeles; }
            set { selectedrendeles = value; }
        }
        RendelesAllapot selectedallapot;

        public string Selectedallapot
        {
            set
            {
                if (value.Equals("Befogadva")) selectedallapot = RendelesAllapot.Befogadva;
                else if (value.Equals("Osszeallitas_alatt")) selectedallapot = RendelesAllapot.Osszeallitas_alatt;
                else if (value.Equals("Kiszallitas_alatt")) selectedallapot = RendelesAllapot.Kiszallitas_alatt;
                else if (value.Equals("Lezart")) selectedallapot = RendelesAllapot.Lezart;
                if (selectedrendeles != null)
                {
                    if (rendvezerlo.AllapotModosit(selectedrendeles.RENDELES_ID, selectedallapot)) MessageBox.Show("Sikeres változtatás!");
                    else MessageBox.Show("Sikertelen változtatás!");
                    rendelesek = rendvezerlo.RendelesBetoltes();
                    OnPropertyChanged("Rendelesek");
                }
            }
            get
            {
                if (selectedrendeles != null)
                {
                    if (selectedrendeles.ALLAPOT.Equals("BEFOGADVA")) return "Befogadva";
                    else if (selectedrendeles.ALLAPOT.Equals("OSSZEALLITAS_ALATT")) return "Osszeallitas_alatt";
                    else if (selectedrendeles.ALLAPOT.Equals("KISZALLITAS_ALATT")) return "Kiszallitas_alatt";
                    else return "Lezart"; //(selectedrendeles.ALLAPOT.Equals("LEZART"))
                }
                else return String.Empty;
            }
        }
        public List<string> RendelesAllapotok
        {
            get { return Enum.GetValues(typeof(RendelesAllapot)).Cast<RendelesAllapot>().Select(x => x.ToString()).ToList(); }
        }
        #endregion
    }
}
