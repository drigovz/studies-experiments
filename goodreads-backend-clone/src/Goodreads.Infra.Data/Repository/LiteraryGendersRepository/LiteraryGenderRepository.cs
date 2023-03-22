using Goodreads.Core.Entities;
using Goodreads.Core.Interfaces.Repository;
using Goodreads.Infra.Data.Context;

namespace Goodreads.Infra.Data.Repository.LiteraryGendersRepository;

public class LiteraryGenderRepository : BaseRepository<LiteraryGender, Guid>, ILiteraryGenderRepository
{
    public LiteraryGenderRepository(AppDbContext context) 
        : base(context)
    { }
}