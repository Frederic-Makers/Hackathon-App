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
        public String Email { get; set; }
        public String Exigence { get; set; }
        public String Numero { get; set; }

        public Devis()
        {

        }
        public Devis(int id, String nom, String prenom, String email, String exigence, String numero)
        {
            this.Id = id;
            this.Nom = nom;
            this.Prenom = prenom;
            this.Email = email;
            this.Exigence = exigence;
            this.Numero = numero;
        }

    }
}
