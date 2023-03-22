using Goodreads.Core.Entities;
using Goodreads.Core.Interfaces.Repository;
using Goodreads.Infra.Data.Context;

namespace Goodreads.Infra.Data.Repository.Authors;

public class AuthorRepository : BaseRepository<Author, Guid>, IAuthorRepository
{
    public AuthorRepository(AppDbContext context) 
        : base(context)
    { }
}