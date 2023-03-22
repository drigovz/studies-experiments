using Goodreads.Core.Validations;

namespace Goodreads.Core.Entities;

public sealed class Book : BaseEntity
{
    public string Title { get; private set; }
    public string Summary { get; private set; }
    public string Description { get; private set; }
    public string Thumb { get; private set; }
    public int Rating { get; private set; } = 0;

    public List<Author> Authors { get; private set; }
    public List<LiteraryGender> LiteraryGenders { get; private set; }
    public List<Review> Reviews { get; private set; }

    public Book(string title, string summary, string description, string thumb)
    {
        Title = title;
        Summary = summary;
        Description = description;
        Thumb = thumb;

        EntityValidation(this, new BookValidator());
    }

    public Book Update(string title, string summary, string description, string thumb)
    {
        Title = title;
        Summary = summary;
        Description = description;
        Thumb = thumb;

        EntityValidation(this, new BookValidator());

        return this;
    }
    
    public int Rate(int rate)
    {
        Rating = rate;
        return Rating;
    }

    public List<Author> AddAuthors(Author author)
    {
        Authors ??= new List<Author>();
        
        Authors.Add(author);
        return Authors;
    }

    public List<LiteraryGender> AddLiteraryGenders(LiteraryGender literaryGender)
    {
        LiteraryGenders ??= new List<LiteraryGender>();
        
        LiteraryGenders.Add(literaryGender);
        return LiteraryGenders;
    }

    public List<Review> AddReviews(Review review)
    {
        Reviews ??= new List<Review>();
        
        Reviews.Add(review);
        return Reviews;
    }
}