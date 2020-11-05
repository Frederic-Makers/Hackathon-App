using System;
using System.Collections.Generic;
using System.Text;

namespace PrestataireBusiness
{
    public class Devis
    {
        public int Id { get; set; }
        public String Nom { get; set; }
        public String Prenom { get; set; }
        public DateTime Date { get; set; }
        public String Email { get; set; }
        public String Exigence { get; set; }
        public String Numero { get; set; }

        public List<DevisPrestataire> DevisPrestataires { get; set; }

        public List<Prestataire> PrestatairesIndisponibles { get; set; }

        public Devis()
        {
            this.DevisPrestataires = new List<DevisPrestataire>();
            this.PrestatairesIndisponibles = new List<Prestataire>();
        }
        public Devis(int id, String nom, String prenom, DateTime date, String email, String exigence, String numero) : this()
        {
            this.Id = id;
            this.Nom = nom;
            this.Prenom = prenom;
            this.Date = date;
            this.Email = email;
            this.Exigence = exigence;
            this.Numero = numero;
        }

        //public List<Prestataire> GetPrestatairesDevis (DevisPrestataire dv)
        //{
        //    int tailleListePrestataire = Business.Prestataires.Count;
        //    for (int i = 0; i < tailleListePrestataire; i++)
        //    {
        //        if(Business.Prestataires[i].Id == dv.Id)
        //        {
        //            DevisPrestataires.Add(Business.Prestataires[i].Nom);
        //            for (int i2; i2 < )
        //            {

        //            }
        //        }
        //    }

        //    return null;
        //}
    }
}
