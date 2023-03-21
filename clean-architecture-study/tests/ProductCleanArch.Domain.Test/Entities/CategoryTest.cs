using FluentAssertions;
using ProductsCleanArch.Domain.Entities;
using ProductsCleanArch.Domain.Validations;
using System;
using Xunit;

namespace ProductCleanArch.Domain.Test.Entities
{
    public class CategoryTest
    {
        //[Fact]
        //[Trait("Domain", "Entity - Category")]
        //public void Should_Create_New_Category_Without_Exceptions()
        //{
        //    Action action = () => new Category(Faker.Company.Name());
        //    action.Should().NotThrow<DomainExceptionValidation>();
        //}

        //[Theory]
        //[InlineData(-1)]
        //[InlineData(0)]
        //[Trait("Domain", "Entity - Category")]
        //public void Should_Not_Create_New_Category_With_Invalid_Id(int invalidId)
        //{
        //    Action action = () => new Category(invalidId, Faker.Company.Name());
        //    action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid Id!");
        //}

        //[Theory]
        //[InlineData("")]
        //[InlineData(null)]
        //[Trait("Domain", "Entity - Category")]
        //public void Should_Not_Create_New_Category_With_Empty_Name(string invalidString)
        //{
        //    Action action = () => new Category(1, invalidString);
        //    action.Should().Throw<DomainExceptionValidation>().WithMessage("Name is required!");
        //}

        //[Theory]
        //[InlineData("a")]
        //[InlineData("ab")]
        //[Trait("Domain", "Entity - Category")]
        //public void Should_Not_Create_New_Category_With_Invalid_Name(string invalidName)
        //{
        //    Action action = () => new Category(1, invalidName);
        //    action.Should().Throw<DomainExceptionValidation>().WithMessage("Name need more than 2 chars!");
        //}
    }
}
