using Goodreads.Core.Entities;
using Goodreads.Core.Interfaces.Repository;
using Goodreads.Infra.Data.Context;

namespace Goodreads.Infra.Data.Repository.Reviews;

public class ReviewRepository : BaseRepository<Review, Guid>, IReviewRepository
{
    public ReviewRepository(AppDbContext context) 
        : base(context)
    { }
}