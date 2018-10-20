namespace Domain.Entities.Base
{
    public abstract class Entity
    {
        public int Id { get; set; }

        public override bool Equals(object obj)
        {
            var compareTo = obj as Entity;

            if (ReferenceEquals(this, compareTo)) return true;
            if (ReferenceEquals(null, compareTo)) return false;

            return Id.Equals(compareTo.Id);
        }

        public static bool operator ==(Entity first, Entity second)
        {
            if (ReferenceEquals(first, null) && ReferenceEquals(second, null))
                return true;

            if (ReferenceEquals(first, null) || ReferenceEquals(second, null))
                return false;

            return first.Equals(second);
        }

        public static bool operator !=(Entity first, Entity second)
        {
            return !(first == second);
        }

        public override int GetHashCode()
        {
            return (GetType().GetHashCode() * 255) + Id.GetHashCode();
        }

        public override string ToString()
        {
            return GetType().Name + $"[Id = { Id }]";
        }
    }
}
