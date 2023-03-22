namespace Goodread.Common.Test.Builders;

public class AuthorBuilder
{
    private static readonly Faker _faker = new();

    private static Random _random = new();
    private static int _ramdomNumber = _random.Next(110);
    
    private string Name = _faker.Person.FullName;
    private string City = _faker.Address.City();
    private string State = _faker.Address.StateAbbr();
    private string Country = _faker.Address.Country();
    private DateTime Birthdate = _faker.Date.Past(_ramdomNumber);
    private string Website = _faker.Internet.Url();
    private string Description = _faker.Random.Words();
    public Gender Gender = _faker.PickRandom<Gender>();

    public static AuthorBuilder New() => new();
    
    public AuthorBuilder AuthorWithName(string name)
    {
        Name = name;
        return this;
    }
    
    public AuthorBuilder AuthorWithCity(string city)
    {
        City = city;
        return this;
    }
    
    public AuthorBuilder AuthorWithState(string state)
    {
        State = state;
        return this;
    }
    
    public AuthorBuilder AuthorWithCountry(string country)
    {
        Country = country;
        return this;
    }
    
    public AuthorBuilder AuthorWithBirthdate(DateTime birthdate)
    {
        Birthdate = birthdate;
        return this;
    }
    
    public AuthorBuilder AuthorWithGender(Gender gender)
    {
        Gender = gender;
        return this;
    }

    public Author Build() =>
        new(Name, City, State, Country, Birthdate, Website, Description, Gender);
}