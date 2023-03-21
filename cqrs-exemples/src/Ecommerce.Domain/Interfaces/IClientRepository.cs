using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Interfaces.Repository;

namespace Ecommerce.Domain.Interfaces
{
    public interface IClientRepository : IBaseRepository<Client, int>
    { }
}
