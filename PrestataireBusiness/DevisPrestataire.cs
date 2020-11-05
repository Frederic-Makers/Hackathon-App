namespace PrestataireBusiness
{
    public class DevisPrestataire
    {
        public int DevisId { get; set; }
        public int PrestataireId { get; set; }
        public int Prix { get; set; }
        public string Nom { get; set; }

        public DevisPrestataire(int devisid, int prestataireid, int prix)
        {
            this.DevisId = devisid;
            this.PrestataireId = prestataireid;
            this.Prix = prix;
        }
    }
}