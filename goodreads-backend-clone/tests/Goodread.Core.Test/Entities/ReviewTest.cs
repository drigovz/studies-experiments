namespace Goodreads.Core.Test.Entities;

public class ReviewTest
{
    [Theory]
    [InlineData("")]
    [InlineData(null)]
    [Trait("Domain", "Review")]
    public void Should_Not_Add_Review_With_Invalid_Comment(string invalidComment)
    {
        var review = ReviewBuilder.New().ReviewWithComments(invalidComment).Build();

        review.Valid.Should().BeFalse();
        review.ValidationResult.Errors.Should().NotBeEmpty();
        review.ValidationResult.Errors.Should().HaveCountGreaterThan(0).And.OnlyHaveUniqueItems();
        review.ValidationResult.Errors.Should().Contain(_ => _.ErrorMessage.Contains("Comment"));
    }

    [Fact]
    [Trait("Domain", "Review")]
    public void Should_Update_Review()
    {
        Faker _faker = new();

        var review = ReviewBuilder.New().Build();

        string comment = _faker.Lorem.Random.Words(10);
        int likes = _faker.Random.Int(100);

        var reviewUpdated = review.Update(comment, likes);

        reviewUpdated.Valid.Should().BeTrue();
        reviewUpdated.ValidationResult.Errors.Should().BeEmpty();
        reviewUpdated.ValidationResult.Errors.Should().HaveCount(_ => _ == 0).And.OnlyHaveUniqueItems();
        reviewUpdated.Comment.Should().Be(comment);
        reviewUpdated.Likes.Should().Be(likes);
    }
}