using System;
using System.Collections.Generic;
using System.Text;

namespace PrestataireBusiness
{

    public class Prestataire
    {
        public int Id { get; set; }
        public String Nom { get; set; }
        public String Url { get; set; }
        public String Categorie { get; set; }
        public String Contact { get; set; }
        public String Adresse { get; set; }
        public String Description { get; set; }
        public Boolean Activation { get; set; }
        public int Prix { get; set; }

        public Prestataire(int id, String nom, String url, String categorie, String contact, String adresse,
                       String description, Boolean activation, int prix)
        {
            this.Id = id;
            this.Nom = nom;
            this.Url = url;
            this.Categorie = categorie;
            this.Contact = contact;
            this.Adresse = adresse;
            this.Description = description;
            this.Activation = activation;
            this.Prix = prix;
        }
    }
}
