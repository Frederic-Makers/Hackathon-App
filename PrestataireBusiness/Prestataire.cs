using System;
using System.Collections.Generic;
using System.Text;

namespace PrestataireBusiness
{

    class Prestataire
    {
        public int id { get; set; }
        public String nom { get; set; }
        public String url { get; set; }
        public String categorie { get; set; }
        public String contact { get; set; }
        public String adresse { get; set; }
        public String description { get; set; }
        public Boolean activation { get; set; }

        public Prestataire(int id, String nom, String url, String categorie, String contact, String adresse,
                       String description, Boolean activation)
        {
            this.id = id;
            this.nom = nom;
            this.url = url;
            this.categorie = categorie;
            this.contact = contact;
            this.adresse = adresse;
            this.description = description;
            this.activation = activation;
        }
    }
}
