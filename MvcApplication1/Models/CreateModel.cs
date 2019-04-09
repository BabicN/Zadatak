using System.Collections.Generic;
using Entiteti;

namespace MvcApplication1.Models
{
    public class CreateModel
    {
        public Proizvod proizvod { get; set; }
        public IEnumerable<Kategorija> kategorija { get; set; }
        public IEnumerable<Dobavljac> dobavljac { get; set; }
        public IEnumerable<Proizvodjac> proizvodjac { get; set; }
    }
}