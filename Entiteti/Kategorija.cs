using System.Collections.Generic;

namespace Entiteti
{
    public class Kategorija
    {
        public int Id { get; set; }
        public string Tip { get; set; }
        public virtual ICollection<Proizvod> proizvod { get; set; }
    }
}