using Api.Domain.Entities;
using Bogus;
using System;

namespace Api.Test.Builders
{
   public class BarbecueBuilder
   {
      static Faker faker = new Faker();

      public DateTime Date = DateTime.UtcNow.AddDays(faker.Random.Number(5));
      public string Description = faker.Lorem.Paragraph();
      public string AdditionalNotes = faker.Lorem.Paragraph();

      public static BarbecueBuilder New()
      {
         return new BarbecueBuilder();
      }

      public BarbecueBuilder BarbecueWithDate(DateTime date)
      {
         Date = date;
         return this;
      }

      public BarbecueBuilder BarbecueWithDescription(string description)
      {
         Description = description;
         return this;
      }

      public BarbecueBuilder BarbecueWithAdditionalNotes(string additionalNotes)
      {
         AdditionalNotes = additionalNotes;
         return this;
      }

      public Barbecue Build()
      {
         return new Barbecue(Date, Description, AdditionalNotes);
      }
   }
}
