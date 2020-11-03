using System;
using System.Collections.ObjectModel;

namespace PrestataireBusiness
{
    public class Business
    {
        public static ObservableCollection<Prestataire> Prestataires { get; set; }

        static Business()
        {
            Prestataires = new ObservableCollection<Prestataire>();
        }
    }
}
