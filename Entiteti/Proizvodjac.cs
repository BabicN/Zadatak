using System.Collections.Generic;

namespace Entiteti
{
    public class Proizvodjac
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public virtual ICollection<Proizvod> proizvod { get; set; }
    }
}