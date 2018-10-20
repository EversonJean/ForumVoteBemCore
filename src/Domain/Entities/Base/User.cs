using System;

namespace Domain.Entities.Base
{
    public abstract class User : Entity
    {
        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public bool ConfirmedEmail { get; set; }

        public byte[] Picture { get; set; }

        public string Document { get; set; }

        public DateTime? BirthDate { get; set; }
    }
}
