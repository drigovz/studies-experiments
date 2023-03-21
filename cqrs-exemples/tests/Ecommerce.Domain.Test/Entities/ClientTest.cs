using Ecommerce.Domain.Entities;
using FluentAssertions;
using Xunit;

namespace Ecommerce.Domain.Test.Entities
{
    public class ClientTest
    {
        [Fact]
        [Trait("Domain", "Client")]
        public void Should_Not_Accept_Invalid_First_Name()
        {
            var client = new Client(
                "",
                Faker.Name.Last(),
                Faker.Internet.Email()
            );

            client.Valid.Should().BeFalse();
            client.ValidationResult.Errors.Should().NotBeEmpty();
            client.ValidationResult.Errors.Should().HaveCount(c => c > 0).And.OnlyHaveUniqueItems();
            client.ValidationResult.Errors.Should().Contain(x => x.ErrorMessage.Contains("FirstName"));
        }

        [Fact]
        [Trait("Domain", "Client")]
        public void Should_Not_Accept_Invalid_Last_Name()
        {
            var client = new Client(
                Faker.Name.First(),
                "",
                Faker.Internet.Email()
            );

            client.Valid.Should().BeFalse();
            client.ValidationResult.Errors.Should().NotBeEmpty();
            client.ValidationResult.Errors.Should().HaveCount(c => c > 0).And.OnlyHaveUniqueItems();
            client.ValidationResult.Errors.Should().Contain(x => x.ErrorMessage.Contains("LastName"));
        }

        [Fact]
        [Trait("Domain", "Client")]
        public void Should_Not_Accept_Empty_Email()
        {
            var client = new Client(
                Faker.Name.First(),
                Faker.Name.Last(),
                ""
            );

            client.Valid.Should().BeFalse();
            client.ValidationResult.Errors.Should().NotBeEmpty();
            client.ValidationResult.Errors.Should().HaveCount(c => c == 2).And.OnlyHaveUniqueItems();
            client.ValidationResult.Errors.Should().Contain(x => x.ErrorMessage.Contains("Email"));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("email")]
        [InlineData("@email")]
        [Trait("Domain", "Client")]
        public void Should_Not_Accept_Invalid_Email(string invalidEmail)
        {
            var client = new Client(
                Faker.Name.First(),
                Faker.Name.Last(),
                invalidEmail
            );

            client.Valid.Should().BeFalse();
            client.ValidationResult.Errors.Should().NotBeEmpty();
            client.ValidationResult.Errors.Should().HaveCount(c => c > 0).And.OnlyHaveUniqueItems();
            client.ValidationResult.Errors.Should().Contain(x => x.ErrorMessage.Contains("Email"));
        }
    }
}
