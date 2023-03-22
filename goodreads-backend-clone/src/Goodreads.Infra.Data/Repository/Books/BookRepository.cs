using Goodreads.Core.Entities;
using Goodreads.Core.Interfaces.Repository;
using Goodreads.Infra.Data.Context;

namespace Goodreads.Infra.Data.Repository.Books;

public class BookRepository : BaseRepository<Book, Guid>, IBookRepository
{
    public BookRepository(AppDbContext context) 
        : base(context)
    { }
}