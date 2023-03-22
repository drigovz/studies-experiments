using Goodreads.Core.Enums;

namespace Goodreads.Core.Test.Entities;

public class AuthorTest
{
    private static Faker _faker;

    public AuthorTest()
    {
        _faker = new Faker();
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    [Trait("Domain", "Author")]
    public void Should_Not_Add_Author_With_Invalid_Name(string invalidName)
    {
        var author = AuthorBuilder.New().AuthorWithName(invalidName).Build();

        author.Valid.Should().BeFalse();
        author.ValidationResult.Errors.Should().NotBeEmpty();
        author.ValidationResult.Errors.Should().HaveCountGreaterThan(0).And.OnlyHaveUniqueItems();
        author.ValidationResult.Errors.Should().Contain(_ => _.ErrorMessage.Contains("Name"));
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    [Trait("Domain", "Author")]
    public void Should_Not_Add_Author_With_Invalid_City(string invalidCity)
    {
        var author = AuthorBuilder.New().AuthorWithCity(invalidCity).Build();

        author.Valid.Should().BeFalse();
        author.ValidationResult.Errors.Should().NotBeEmpty();
        author.ValidationResult.Errors.Should().HaveCountGreaterThan(0).And.OnlyHaveUniqueItems();
        author.ValidationResult.Errors.Should().Contain(_ => _.ErrorMessage.Contains("City"));
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    [Trait("Domain", "Author")]
    public void Should_Not_Add_Author_With_Invalid_State(string invalidState)
    {
        var author = AuthorBuilder.New().AuthorWithState(invalidState).Build();

        author.Valid.Should().BeFalse();
        author.ValidationResult.Errors.Should().NotBeEmpty();
        author.ValidationResult.Errors.Should().HaveCountGreaterThan(0).And.OnlyHaveUniqueItems();
        author.ValidationResult.Errors.Should().Contain(_ => _.ErrorMessage.Contains("State"));
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    [Trait("Domain", "Author")]
    public void Should_Not_Add_Author_With_Invalid_Country(string invalidCountry)
    {
        var author = AuthorBuilder.New().AuthorWithCountry(invalidCountry).Build();

        author.Valid.Should().BeFalse();
        author.ValidationResult.Errors.Should().NotBeEmpty();
        author.ValidationResult.Errors.Should().HaveCountGreaterThan(0).And.OnlyHaveUniqueItems();
        author.ValidationResult.Errors.Should().Contain(_ => _.ErrorMessage.Contains("Country"));
    }

    [Fact]
    [Trait("Domain", "Author")]
    public void Should_Not_Add_Author_With_Invalid_Birthdate()
    {
        var author = AuthorBuilder.New().AuthorWithBirthdate(DateTime.MinValue).Build();

        author.Valid.Should().BeFalse();
        author.ValidationResult.Errors.Should().NotBeEmpty();
        author.ValidationResult.Errors.Should().HaveCountGreaterThan(0).And.OnlyHaveUniqueItems();
        author.ValidationResult.Errors.Should().Contain(_ => _.ErrorMessage.Contains("Birthdate"));
    }

    [Fact]
    [Trait("Domain", "Author")]
    public void Should_Not_Add_Author_With_Invalid_Gender()
    {
        var gender = (Gender)100;
        var author = AuthorBuilder.New().AuthorWithGender(gender).Build();

        author.Valid.Should().BeFalse();
        author.ValidationResult.Errors.Should().NotBeEmpty();
        author.ValidationResult.Errors.Should().HaveCountGreaterThan(0).And.OnlyHaveUniqueItems();
        author.ValidationResult.Errors.Should().Contain(_ => _.ErrorMessage.Contains("Gender"));
    }

    [Fact]
    [Trait("Domain", "Author")]
    public void Should_Valid_Born_Description()
    {
        Faker faker = new();
        string city = faker.Address.City();
        string state = faker.Address.StateAbbr();
        string country = faker.Address.Country();
        DateTime birthdate = faker.Date.Past(10);

        var author = AuthorBuilder.New()
            .AuthorWithCity(city)
            .AuthorWithState(state)
            .AuthorWithCountry(country)
            .AuthorWithBirthdate(birthdate)
            .Build();

        var bornDesc = author.GetBornDescription();

        author.Valid.Should().BeTrue();
        author.City.Should().Be(city);
        author.State.Should().Be(state);
        author.Country.Should().Be(country);
        author.Birthdate.Should().Be(birthdate);
        bornDesc.Should().Contain(city);
        bornDesc.Should().Contain(state);
        bornDesc.Should().Contain(country);
        bornDesc.Should().Contain($"{birthdate:dd MMMM, yyyy}");
    }

    [Fact]
    [Trait("Domain", "Author")]
    public void Should_Update_Author()
    {
        var author = AuthorBuilder.New().Build();

        int year = _faker.Random.Int(1950, 2000);
        string name = _faker.Person.FullName;
        string city = _faker.Address.City();
        string state = _faker.Address.StateAbbr();
        string country = _faker.Address.Country();
        DateTime birthdate = _faker.Date.Past();
        string website = _faker.Internet.Url();
        string description = _faker.Random.Words();
        Gender gender = _faker.PickRandom<Gender>();

        var authorUpdated = author.Update(name, city, state, country, birthdate, website, description, gender);

        authorUpdated.Valid.Should().BeTrue();
        authorUpdated.ValidationResult.Errors.Should().BeEmpty();
        authorUpdated.ValidationResult.Errors.Should().HaveCount(_ => _ == 0).And.OnlyHaveUniqueItems();
        authorUpdated.Name.Should().Be(name);
        authorUpdated.City.Should().Be(city);
        authorUpdated.State.Should().Be(state);
        authorUpdated.Country.Should().Be(country);
        authorUpdated.Website.Should().Be(website);
        authorUpdated.Description.Should().Be(description);
        authorUpdated.Gender.Should().Be(gender);
    }
}