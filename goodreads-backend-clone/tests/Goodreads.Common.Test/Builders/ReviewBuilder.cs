namespace Goodread.Common.Test.Builders;

public class ReviewBuilder
{
    private static readonly Faker _faker = new();

    private string Comment = _faker.Lorem.Random.Words(10);
    private int Likes = _faker.Random.Int(100);

    public static ReviewBuilder New() => new();

    public ReviewBuilder ReviewWithComments(string comment)
    {
        Comment = comment;
        return this;
    }

    public ReviewBuilder ReviewWithLikes(int likes)
    {
        Likes = likes;
        return this;
    }

    public Review Build() =>
        new Review(Comment, Likes);
}