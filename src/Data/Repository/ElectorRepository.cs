using Data.Context;
using Domain.Entities;
using Domain.Interfaces.Repositories;

namespace Data.Repository
{
    public class ElectorRepository : Repository<Elector>, IElectorRepository
    {
        public ElectorRepository(BaseContext context) : base (context)
        {
        }
    }
}
