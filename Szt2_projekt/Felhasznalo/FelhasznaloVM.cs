﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Szt2_projekt.Felhasznalo;

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
        public event KompatibilitasVizsgalatEventHandler TermekValtozott;
        private void TermekValtozas([CallerMemberName]string valtozott = "") //egyszerűség kedvéért h ne kelljen minden egyes set-hez odaírni, onproperty mintájára
        {
            if (TermekValtozott != null)
            {
                TermekValtozott(this, new KompatibilitasEventArgs(valtozott));
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
            vezerlo = new KedvencVezerlo();
            kimenouzenet = String.Empty;
            UzenetBetoltes();
            KedvencBetolt();
            felhasznalovaltoztatasengedelyezes = true;
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

        #region Termekek
        List<ALAPLAP> alaplapok;
        ALAPLAP selectedAlaplap;
        List<CPU> cpuk;
        CPU selectedCpu;
        List<GPU> gpuk;
        GPU selectedGpu;
        List<HAZ> hazak;
        HAZ selectedHaz;
        List<HDD> hddk;
        HDD selectedHdd;
        List<MEMORIA> memoriak;
        MEMORIA selectedMemoria;
        List<SSD> ssdk;
        SSD selectedSsd;
        List<TAP> tapok;
        TAP selectedTap;
        public bool felhasznalovaltoztatasengedelyezes;//annak a megoldására h ha kompatibilitasvizsgalo szűri vmely listát akk a selecteditemet módosítja és így új elemre is generál változásvizsgálatot=>végtelen ciklus hibával

        public TAP SelectedTap
        {
            get { return selectedTap; }
            set { selectedTap = value; OnPropertyChanged(); if (felhasznalovaltoztatasengedelyezes) TermekValtozas(); }
        }

        public List<TAP> Tapok
        {
            get { return tapok; }
            set { tapok = value; OnPropertyChanged(); }
        }

        public SSD SelectedSsd
        {
            get { return selectedSsd; }
            set { selectedSsd = value; OnPropertyChanged(); if (felhasznalovaltoztatasengedelyezes) TermekValtozas(); }
        }

        public List<SSD> Ssdk
        {
            get { return ssdk; }
            set { ssdk = value; OnPropertyChanged(); }
        }

        public MEMORIA SelectedMemoria
        {
            get { return selectedMemoria; }
            set { selectedMemoria = value; OnPropertyChanged(); if (felhasznalovaltoztatasengedelyezes) TermekValtozas(); }
        }
        public List<MEMORIA> Memoriak
        {
            get { return memoriak; }
            set { memoriak = value; OnPropertyChanged(); }
        }

        public HDD SelectedHdd
        {
            get { return selectedHdd; }
            set { selectedHdd = value; OnPropertyChanged(); if (felhasznalovaltoztatasengedelyezes) TermekValtozas(); }
        }

        public List<HDD> Hddk
        {
            get { return hddk; }
            set { hddk = value; OnPropertyChanged(); }
        }

        public HAZ SelectedHaz
        {
            get { return selectedHaz; }
            set { selectedHaz = value; OnPropertyChanged(); if (felhasznalovaltoztatasengedelyezes) TermekValtozas(); }
        }

        public List<HAZ> Hazak
        {
            get { return hazak; }
            set { hazak = value; OnPropertyChanged(); }
        }

        public GPU SelectedGpu
        {
            get { return selectedGpu; }
            set { selectedGpu = value; OnPropertyChanged(); if (felhasznalovaltoztatasengedelyezes) TermekValtozas(); }
        }

        public List<GPU> Gpuk
        {
            get { return gpuk; }
            set { gpuk = value; OnPropertyChanged(); }
        }

        public CPU SelectedCpu
        {
            get { return selectedCpu; }
            set { selectedCpu = value; OnPropertyChanged(); if (felhasznalovaltoztatasengedelyezes) TermekValtozas(); }
        }

        public List<CPU> Cpuk
        {
            get { return cpuk; }
            set { cpuk = value; OnPropertyChanged(); }
        }

        public ALAPLAP SelectedAlaplap
        {
            get { return selectedAlaplap; }
            set { selectedAlaplap = value; OnPropertyChanged(); if (felhasznalovaltoztatasengedelyezes) TermekValtozas(); }
        }

        public List<ALAPLAP> Alaplapok
        {
            get { return alaplapok; }
            set { alaplapok = value; OnPropertyChanged(); }
        }

        #endregion

        #region Kedvencek

        private KEDVENCEK selectedKedvenc;

        public KEDVENCEK SelectedKedvenc
        {
            get { return selectedKedvenc; }
            set { selectedKedvenc = value; OnPropertyChanged("SelectedKedvenc"); }
        }

        private KedvencVezerlo vezerlo;
        private ObservableCollection<KEDVENCEK> kedvencek;
        public ObservableCollection<KEDVENCEK> Kedvencek
        {
            get { return kedvencek; }
            set { kedvencek = value; } //OnPropertyChanged(); }
        }

        public void KedvencBetolt()
        {
            Kedvencek = vezerlo.KedvencekBetoltese(id);
        }

        public void KedvencMentes()
        {
            //leendoKedvenc = new KEDVENCEK
            //{
            //    ALAPLAP_ID = SelectedAlaplap.ALAPLAP_ID,
            //    CPU_ID = SelectedCpu.CPU_ID,
            //    GPU_ID = SelectedGpu.GPU_ID,
            //    MEMORIA_ID = SelectedMemoria.MEMORIA_ID,
            //    HDD_ID = SelectedHdd.HDD_ID,
            //    SSD_ID = SelectedSsd.SSD_ID,
            //    HAZ_ID = SelectedHaz.HAZ_ID,
            //    TAP_ID = SelectedTap.TAP_ID
            //};
            //vezerlo.MentesKedvencekbe(id, leendoKedvenc);
            Kedvencek = vezerlo.KedvencekBetoltese(id);
            //OnPropertyChanged("Kedvencek");
        }

        public void KedvencMódosítás(KEDVENCEK selectedKedvenc)
        {
            
        }

        #endregion

       
    }
}
