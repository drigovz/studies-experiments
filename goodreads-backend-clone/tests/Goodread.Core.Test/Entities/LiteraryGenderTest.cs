namespace Goodreads.Core.Test.Entities;

public class LiteraryGenderTest
{
    private static Faker _faker;

    public LiteraryGenderTest()
    {
        _faker = new Faker();
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    [Trait("Domain", "LiteraryGender")]
    public void Should_Not_Create_Literary_Gender_With_Invalid_Title(string invalidTitle)
    {
        var literaryGender = LiteraryGenderBuilder.New().LiteraryGenderWithTitle(invalidTitle).Build();

        literaryGender.Valid.Should().BeFalse();
        literaryGender.ValidationResult.Errors.Should().NotBeEmpty();
        literaryGender.ValidationResult.Errors.Should().HaveCountGreaterThan(0).And.OnlyHaveUniqueItems();
        literaryGender.ValidationResult.Errors.Should().Contain(_ => _.ErrorMessage.Contains("Title"));
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    [Trait("Domain", "LiteraryGender")]
    public void Should_Not_Create_Literary_Gender_With_Invalid_Description(string invalidDescription)
    {
        var literaryGender = LiteraryGenderBuilder.New().LiteraryGenderWithDescription(invalidDescription).Build();

        literaryGender.Valid.Should().BeFalse();
        literaryGender.ValidationResult.Errors.Should().NotBeEmpty();
        literaryGender.ValidationResult.Errors.Should().HaveCountGreaterThan(0).And.OnlyHaveUniqueItems();
        literaryGender.ValidationResult.Errors.Should().Contain(_ => _.ErrorMessage.Contains("Description"));
    }

    [Fact]
    [Trait("Domain", "LiteraryGender")]
    public void Should_Update_LiteraryGender()
    {
        var literaryGender = LiteraryGenderBuilder.New().Build();

        string title = _faker.Name.Random.Word();
        string description = _faker.Name.Random.Words();

        var literaryGenderUpdated = literaryGender.Update(title, description);

        literaryGenderUpdated.Valid.Should().BeTrue();
        literaryGenderUpdated.ValidationResult.Errors.Should().BeEmpty();
        literaryGenderUpdated.ValidationResult.Errors.Should().HaveCount(_ => _ == 0).And.OnlyHaveUniqueItems();
        literaryGenderUpdated.Title.Should().Be(title);
        literaryGenderUpdated.Description.Should().Be(description);
    }
}