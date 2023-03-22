namespace Goodread.Common.Test.Builders;

public class BookBuilder
{
    private static readonly Faker _faker = new();

    private string Title = _faker.Company.CompanyName();
    private string Summary = _faker.Lorem.Paragraph();
    private string Description = _faker.Lorem.Paragraphs(10);
    private string Thumb = _faker.Internet.UrlWithPath();

    public static BookBuilder New() => new();

    public BookBuilder BookWithTitle(string title)
    {
        Title = title;
        return this;
    }

    public BookBuilder BookWithSummary(string summary)
    {
        Summary = summary;
        return this;
    }

    public BookBuilder BookWithDescription(string description)
    {
        Description = description;
        return this;
    }

    public BookBuilder BookWithThumb(string thumb)
    {
        Thumb = thumb;
        return this;
    }

    public Book Build() =>
        new(Title, Summary, Description, Thumb);
}