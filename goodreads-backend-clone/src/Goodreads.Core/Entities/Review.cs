using Goodreads.Core.Validations;

namespace Goodreads.Core.Entities;

public sealed class Review : BaseEntity
{
    public string Comment { get; private set; }
    public int Likes { get; private set; } = 0;
    public Book Book { get; set; }
    public Guid BookId { get; set; }

    public Review(string comment, int likes)
    {
        Comment = comment;
        Likes = likes;

        EntityValidation(this, new ReviewValidation());
    }

    public Review Update(string comment, int likes)
    {
        Comment = comment;
        Likes = likes;

        EntityValidation(this, new ReviewValidation());

        return this;
    }
}