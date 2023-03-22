namespace Goodreads.Core.Test.Entities;

public class BookTest
{
    private static Faker _faker;

    public BookTest()
    {
        _faker = new Faker();
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    [Trait("Domain", "Book")]
    public void Should_Not_Add_Book_With_Invalid_Title(string invalidTitle)
    {
        var book = BookBuilder.New().BookWithTitle(invalidTitle).Build();

        book.Valid.Should().BeFalse();
        book.ValidationResult.Errors.Should().NotBeEmpty();
        book.ValidationResult.Errors.Should().HaveCountGreaterThan(0).And.OnlyHaveUniqueItems();
        book.ValidationResult.Errors.Should().Contain(_ => _.ErrorMessage.Contains("Title"));
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    [Trait("Domain", "Book")]
    public void Should_Not_Add_Book_With_Invalid_Summary(string invalidSummary)
    {
        var book = BookBuilder.New().BookWithSummary(invalidSummary).Build();

        book.Valid.Should().BeFalse();
        book.ValidationResult.Errors.Should().NotBeEmpty();
        book.ValidationResult.Errors.Should().HaveCountGreaterThan(0).And.OnlyHaveUniqueItems();
        book.ValidationResult.Errors.Should().Contain(_ => _.ErrorMessage.Contains("Summary"));
    }

    [Fact]
    [Trait("Domain", "Book")]
    public void Should_Not_Add_Book_With_Summary_More_Than_300_Chars()
    {
        string summary = _faker.Lorem.Paragraph(400);
        var book = BookBuilder.New().BookWithSummary(summary).Build();

        book.Valid.Should().BeFalse();
        book.ValidationResult.Errors.Should().NotBeEmpty();
        book.ValidationResult.Errors.Should().HaveCountGreaterThan(0).And.OnlyHaveUniqueItems();
        book.ValidationResult.Errors.Should().Contain(_ => _.ErrorMessage.Contains("Summary maximum length is 300 chars"));
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    [Trait("Domain", "Book")]
    public void Should_Not_Add_Book_With_Invalid_Description(string invalidDesc)
    {
        var book = BookBuilder.New().BookWithDescription(invalidDesc).Build();

        book.Valid.Should().BeFalse();
        book.ValidationResult.Errors.Should().NotBeEmpty();
        book.ValidationResult.Errors.Should().HaveCountGreaterThan(0).And.OnlyHaveUniqueItems();
        book.ValidationResult.Errors.Should().Contain(_ => _.ErrorMessage.Contains("Description"));
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    [Trait("Domain", "Book")]
    public void Should_Not_Add_Book_With_Invalid_Thumb(string invalidThumb)
    {
        var book = BookBuilder.New().BookWithThumb(invalidThumb).Build();

        book.Valid.Should().BeFalse();
        book.ValidationResult.Errors.Should().NotBeEmpty();
        book.ValidationResult.Errors.Should().HaveCountGreaterThan(0).And.OnlyHaveUniqueItems();
        book.ValidationResult.Errors.Should().Contain(_ => _.ErrorMessage.Contains("Thumb"));
    }
    
    [Fact]
    [Trait("Domain", "Book")]
    public void Should_Add_Review_Book()
    {
        var book = BookBuilder.New().Build();
        int rating = _faker.Random.Int();
        book.Rate(rating);

        book.Valid.Should().BeTrue();
        book.ValidationResult.Errors.Should().BeEmpty();
        book.ValidationResult.Errors.Should().HaveCount(0).And.OnlyHaveUniqueItems();
        book.Rating.Should().Be(rating);
    }

    [Fact]
    [Trait("Domain", "Book")]
    public void Should_Update_Book()
    {
        var book = BookBuilder.New().Build();

        string titleUpdate = _faker.Company.CompanyName();
        string summaryUpdate = _faker.Lorem.Paragraph();
        string descriptionUpdate = _faker.Lorem.Paragraphs(10);
        string thumbUpdate = _faker.Internet.UrlWithPath();

        var bookUpdated = book.Update(titleUpdate, summaryUpdate, descriptionUpdate, thumbUpdate);

        bookUpdated.Valid.Should().BeTrue();
        bookUpdated.ValidationResult.Errors.Should().BeEmpty();
        bookUpdated.ValidationResult.Errors.Should().HaveCount(_ => _ == 0).And.OnlyHaveUniqueItems();
        bookUpdated.Title.Should().Be(titleUpdate);
        bookUpdated.Summary.Should().Be(summaryUpdate);
        bookUpdated.Description.Should().Be(descriptionUpdate);
        bookUpdated.Thumb.Should().Be(thumbUpdate);
    }
    
    [Fact]
    [Trait("Domain", "Book")]
    public void Should_Add_Authors_On_Book()
    {
        var book = BookBuilder.New().Build();
        var author = AuthorBuilder.New().Build();

        book.AddAuthors(author);

        book.Valid.Should().BeTrue();
        book.ValidationResult.Errors.Should().BeEmpty();
        book.ValidationResult.Errors.Should().HaveCount(0).And.OnlyHaveUniqueItems();
        author.Valid.Should().BeTrue();
        author.ValidationResult.Errors.Should().BeEmpty();
        author.ValidationResult.Errors.Should().HaveCount(0).And.OnlyHaveUniqueItems();
        book.Authors.Should().HaveCountGreaterThan(0).And.HaveCount(1);
        book.Authors.Should().Contain(author);
    }
    
    [Fact]
    [Trait("Domain", "Book")]
    public void Should_Add_Literary_Genders_On_Book()
    {
        var book = BookBuilder.New().Build();
        var literaryGender = LiteraryGenderBuilder.New().Build();

        book.AddLiteraryGenders(literaryGender);

        book.Valid.Should().BeTrue();
        book.ValidationResult.Errors.Should().BeEmpty();
        book.ValidationResult.Errors.Should().HaveCount(0).And.OnlyHaveUniqueItems();
        literaryGender.Valid.Should().BeTrue();
        literaryGender.ValidationResult.Errors.Should().BeEmpty();
        literaryGender.ValidationResult.Errors.Should().HaveCount(0).And.OnlyHaveUniqueItems();
        book.LiteraryGenders.Should().HaveCountGreaterThan(0).And.HaveCount(1);
        book.LiteraryGenders.Should().Contain(literaryGender);
    }
    
    [Fact]
    [Trait("Domain", "Book")]
    public void Should_Add_Reviews_On_Book()
    {
        var book = BookBuilder.New().Build();
        var review = ReviewBuilder.New().Build();

        book.AddReviews(review);

        book.Valid.Should().BeTrue();
        book.ValidationResult.Errors.Should().BeEmpty();
        book.ValidationResult.Errors.Should().HaveCount(0).And.OnlyHaveUniqueItems();
        review.Valid.Should().BeTrue();
        review.ValidationResult.Errors.Should().BeEmpty();
        review.ValidationResult.Errors.Should().HaveCount(0).And.OnlyHaveUniqueItems();
        book.Reviews.Should().HaveCountGreaterThan(0).And.HaveCount(1);
        book.Reviews.Should().Contain(review);
    }
}