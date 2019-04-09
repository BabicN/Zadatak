using System.Collections.Generic;

namespace Entiteti
{
    public class Dobavljac
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public virtual ICollection<Proizvod> proizvod { get; set; }
    }
}