namespace PrestataireBusiness
{
    public class DevisPrestataire
    {
        public int Id { get; set; }
        public int DevisId { get; set; }
        public int PrestataireId { get; set; }
        public int PrixId { get; set; }

        public DevisPrestataire(int id, int devisid, int prestataireid, int prixid)
        {
            this.Id = id;
            this.DevisId = devisid;
            this.PrestataireId = prestataireid;
            this.PrixId = prixid;
        }
    }
}