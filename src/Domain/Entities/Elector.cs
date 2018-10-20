using Domain.Entities.Base;

namespace Domain.Entities
{
    public class Elector : User
    {
        public int AddressId { get; set; }

        public virtual Address Address { get; set; }
        
        public int PartyId { get; set; }

        public virtual Party Party { get; set; }
    }
}
