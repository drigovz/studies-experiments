using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Api.Domain.Entities
{
   public class Barbecue : BaseEntity
   {
      public DateTime Date { get; private set; }
      public string Description { get; private set; }
      public string AdditionalNotes { get; private set; }
      public ICollection<Participant> Participants { get; private set; } = new Collection<Participant>();

      private Barbecue()
      {
      }

      public Barbecue(DateTime date, string description, string additionalNotes)
      {
         Validations(date, description);

         Date = date;
         Description = description;
         AdditionalNotes = additionalNotes;
      }

      private void Validations(DateTime date, string description)
      {
         if (date < DateTime.Now)
            throw new ArgumentException("Date not valid!");

         if (string.IsNullOrEmpty(description))
            throw new ArgumentException("Description is required!");

         if (description.Length <= 2)
            throw new ArgumentException("The description length must contain more than two characters!");
      }
   }
}
