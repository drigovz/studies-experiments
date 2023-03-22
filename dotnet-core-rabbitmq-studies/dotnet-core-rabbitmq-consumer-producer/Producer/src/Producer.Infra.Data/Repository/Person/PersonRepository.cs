using Producer.Core.Interfaces.Repository;
using Producer.Core.Entities;
using Producer.Core.Interfaces.DatabaseConfig;

namespace Producer.Infra.Data.Repository;

public class PersonRepository: BaseRepository<Person>, IPersonRepository
{
    public PersonRepository(IMongoDbSettings settings) 
        : base(settings)
    { }
}