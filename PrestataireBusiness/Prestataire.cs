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
    }
}
