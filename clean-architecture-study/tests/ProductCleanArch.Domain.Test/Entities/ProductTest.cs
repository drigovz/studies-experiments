using FluentAssertions;
using ProductsCleanArch.Domain.Entities;
using ProductsCleanArch.Domain.Validations;
using System;
using Xunit;

namespace ProductCleanArch.Domain.Test.Entities
{
    public class ProductTest
    {
        private readonly int _id;
        private readonly string _name;
        private readonly string _description;
        private readonly decimal _price;
        private readonly string _image;
        private readonly int _stock;
        private readonly int _categoryId;

        public ProductTest()
        {
            _id = Faker.RandomNumber.Next(1, 10);
            _name = Faker.Company.Name();
            _description = Faker.Lorem.Paragraph();
            _price = Convert.ToDecimal(Faker.RandomNumber.Next(10, 10000).ToString("D2"));
            _image = Faker.Internet.Url();
            _stock = Faker.RandomNumber.Next(1, 100);
            _categoryId = Faker.RandomNumber.Next(1, 100);
        }

        //[Fact]
        //[Trait("Domain", "Entity - Product")]
        //public void Should_Create_New_Product_Without_Exceptions()
        //{
        //    Action action = () => new Product(_id, _name, _description, _price, _stock, _image, _categoryId);
        //    action.Should().NotThrow<DomainExceptionValidation>();
        //}

        //[Theory]
        //[InlineData(-1)]
        //[InlineData(0)]
        //[Trait("Domain", "Entity - Product")]
        //public void Should_Not_Create_Product_With_Invalid_ID(int invalidId)
        //{
        //    Action action = () => new Product(invalidId, _name, _description, _price, _stock, _image, _categoryId);
        //    action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid Id!");
        //}

        //[Theory]
        //[InlineData("")]
        //[InlineData(null)]
        //[Trait("Domain", "Entity - Product")]
        //public void Should_Not_Create_New_Product_With_Empty_Name(string invalidString)
        //{
        //    Action action = () => new Product(invalidString, _description, _price, _stock, _image, _categoryId);
        //    action.Should().Throw<DomainExceptionValidation>().WithMessage("Name is required!");
        //}

        //[Theory]
        //[InlineData("a")]
        //[InlineData("ab")]
        //[Trait("Domain", "Entity - Product")]
        //public void Should_Not_Create_New_Product_With_Invalid_Name(string invalidName)
        //{
        //    Action action = () => new Product(invalidName, _description, _price, _stock, _image, _categoryId);
        //    action.Should().Throw<DomainExceptionValidation>().WithMessage("Name need more than 2 chars!");
        //}

        //[Theory]
        //[InlineData("")]
        //[InlineData(null)]
        //[Trait("Domain", "Entity - Product")]
        //public void Should_Not_Create_New_Product_With_Empty_Description(string invalidString)
        //{
        //    Action action = () => new Product(_name, invalidString, _price, _stock, _image, _categoryId);
        //    action.Should().Throw<DomainExceptionValidation>().WithMessage("Description is required!");
        //}

        //[Theory]
        //[InlineData("a")]
        //[InlineData("ab")]
        //[InlineData("abc")]
        //[InlineData("abcd")]
        //[Trait("Domain", "Entity - Product")]
        //public void Should_Not_Create_New_Product_With_Invalid_Description(string invalidDescription)
        //{
        //    Action action = () => new Product(_name, invalidDescription, _price, _stock, _image, _categoryId);
        //    action.Should().Throw<DomainExceptionValidation>().WithMessage("Description need more than 2 chars!");
        //}

        //[Theory]
        //[InlineData(0.0)]
        //[InlineData(-1)]
        //[Trait("Domain", "Entity - Product")]
        //public void Should_Not_Create_New_Product_With_Invalid_Price(decimal invalidPrice)
        //{
        //    Action action = () => new Product(_name, _description, invalidPrice, _stock, _image, _categoryId);
        //    action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid price value!");
        //}

        //[Theory]
        //[InlineData(0)]
        //[InlineData(-1)]
        //[Trait("Domain", "Entity - Product")]
        //public void Should_Not_Create_New_Product_With_Invalid_Stock(int invalidStock)
        //{
        //    Action action = () => new Product(_name, _description, _price, invalidStock, _image, _categoryId);
        //    action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid stock value!");
        //}

        //[Fact]
        //[Trait("Domain", "Entity - Product")]
        //public void Should_Not_Create_New_Product_With_Invalid_Image()
        //{
        //    Action action = () => new Product(_name, _description, _price, _stock, Faker.Lorem.Paragraph(4000), _categoryId);
        //    action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid image name, too long, maximum 250 characters!");
        //}
    }
}
