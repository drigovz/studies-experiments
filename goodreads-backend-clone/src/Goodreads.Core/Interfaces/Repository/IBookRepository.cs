using Goodreads.Core.Entities;

namespace Goodreads.Core.Interfaces.Repository;

public interface IBookRepository : IBaseRepository<Book, Guid>
{ }