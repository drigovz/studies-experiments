using Api.Test.Builders;
using System;
using Xunit;

namespace Api.Domain.Test.Entities.Test
{
    public class ParticipantTest
    {
        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Should_Not_Accept_Invalid_Name(string invalidName)
        {
            Assert.Throws<ArgumentException>(() =>
                ParticipantBuilder.New().ParticipantWithName(invalidName).Build()
            )
            .AssertThrowsWithMessage("Name is required!");
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-10)]
        [InlineData(-24)]
        [InlineData(-0.1)]
        public void Should_Not_Accept_Invalid_Price(decimal invalidContribuitionValue)
        {
            Assert.Throws<ArgumentException>(() =>
                ParticipantBuilder.New().ParticipantWithContribuitionValue(invalidContribuitionValue).Build()
            )
            .AssertThrowsWithMessage("Contribuition value not valid!");
        }
    }
}
