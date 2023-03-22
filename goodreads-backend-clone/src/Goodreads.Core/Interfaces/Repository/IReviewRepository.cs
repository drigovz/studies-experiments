using Goodreads.Core.Entities;

namespace Goodreads.Core.Interfaces.Repository;

public interface IReviewRepository : IBaseRepository<Review, Guid>
{ }