
namespace Entiteti
{
    public class Proizvod
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public int Cena { get; set; }
        public int KategorijaId { get; set; }
        public int DobavljacId { get; set; }
        public int ProizvodjacId { get; set; }
        public virtual Kategorija kategorija { get; set; }
        public virtual Dobavljac dobavljac { get; set; }
        public virtual Proizvodjac proizvodjac { get; set; }
    }
}