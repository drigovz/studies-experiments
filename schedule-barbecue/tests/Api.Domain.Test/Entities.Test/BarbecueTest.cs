using Api.Test.Builders;
using System;
using Xunit;

namespace Api.Domain.Test.Entities.Test
{
   public class BarbecueTest
   {
      [Fact]
      public void Should_Not_Accept_Invalid_Date()
      {
         var invalidDate = DateTime.Now.AddDays(-1);

         Assert.Throws<ArgumentException>(() =>
             BarbecueBuilder.New().BarbecueWithDate(invalidDate).Build()
         )
         .AssertThrowsWithMessage("Date not valid!");
      }

      [Theory]
      [InlineData("")]
      [InlineData(null)]
      public void Should_Not_Accept_Invalid_Description(string invalidDescription)
      {
         Assert.Throws<ArgumentException>(() =>
             BarbecueBuilder.New().BarbecueWithDescription(invalidDescription).Build()
         )
         .AssertThrowsWithMessage("Description is required!");
      }

      [Theory]
      [InlineData("n")]
      [InlineData("na")]
      public void Should_Not_Accept_Description_With_Less_Than_Two_Characters(string invalidDescription)
      {
         Assert.Throws<ArgumentException>(() =>
            BarbecueBuilder.New().BarbecueWithDescription(invalidDescription).Build()
         )
         .AssertThrowsWithMessage("The description length must contain more than two characters!");
      }
   }
}
