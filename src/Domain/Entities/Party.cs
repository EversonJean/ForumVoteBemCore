using Domain.Entities.Base;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Party : Entity
    {
        public string Nome { get; set; }
        public string Sigla { get; set; }

        public virtual ICollection<Elector> Electors { get; set; }
    }
}
