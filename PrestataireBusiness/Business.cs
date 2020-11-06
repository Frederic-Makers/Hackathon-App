using System;
using System.Collections.ObjectModel;

namespace PrestataireBusiness
{
    public class Business
    {
        public static ObservableCollection<Prestataire> Prestataires { get; set; }
        public static ObservableCollection<Devis> Devis { get; set; }
        public static ObservableCollection<Devis> DevisWork { get; set; }
        public static ObservableCollection<Devis> DevisFinish { get; set; }
        public static ObservableCollection<DevisPrestataire> DevisPrestataire { get; set; }
        public static Prestataire p { set; get; }
        public static Devis d { get; set; }

        static Business()
        {
            Prestataires = new ObservableCollection<Prestataire>();
            Devis = new ObservableCollection<Devis>();
            DevisWork = new ObservableCollection<Devis>();
            DevisFinish = new ObservableCollection<Devis>();
            DevisPrestataire = new ObservableCollection<DevisPrestataire>();
            p = new Prestataire();
            d = new Devis();
        }
    }
}
