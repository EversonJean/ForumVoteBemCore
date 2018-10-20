using Domain.Entities.Base;
using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Address : Entity
    {
        public string Logradouro { get; set; }

        public string Numero { get; set; }

        public string Bairro { get; set; }

        public string Cep { get; set; }

        public int ElectorId { get; set; }

        public virtual Elector Elector { get; set; }
    }
}
