namespace Goodread.Common.Test.Builders;

public class LiteraryGenderBuilder
{
    private static readonly Faker _faker = new();

    private string Title = _faker.Name.Random.Word();
    private string Description = _faker.Name.Random.Words();

    public static LiteraryGenderBuilder New() => new();

    public LiteraryGenderBuilder LiteraryGenderWithTitle(string title)
    {
        Title = title;
        return this;
    }

    public LiteraryGenderBuilder LiteraryGenderWithDescription(string description)
    {
        Description = description;
        return this;
    }

    public LiteraryGender Build() => new(Title, Description);
}