using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Interfaces;
using Ecommerce.Infra.Data.Context;

namespace Ecommerce.Infra.Data.Repositories
{
    public class ClientRepository : BaseRepository<Client, int>, IClientRepository
    {
        public ClientRepository(AppDbContext context)
            : base(context)
        { }
    }
}
