using System;
using System.Collections.ObjectModel;

namespace PrestataireBusiness
{
    public class Business
    {
        public static ObservableCollection<Prestataire> Prestataires { get; set; }
        public static ObservableCollection<Devis> Devis { get; set; }
        public static ObservableCollection<DevisPrestataire> DevisPrestataire { get; set; }
        static Business()
        {
            Prestataires = new ObservableCollection<Prestataire>();
            Devis = new ObservableCollection<Devis>();
            DevisPrestataire = new ObservableCollection<DevisPrestataire>();
        }
    }
}
