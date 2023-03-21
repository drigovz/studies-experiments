using System;
using System.Collections.Generic;
using Api.Domain.DTOs.Barbecues;
using Api.Domain.DTOs.Participants;
using Api.Domain.Entities;

namespace Api.Service.Test.Fakes
{
   public class ParticipantFake
   {
      public int Id { get; set; }

      public string Name { get; private set; }

      public decimal ContribuitionValue { get; private set; }

      public BarbecueDTO Barbecue { get; set; }

      public int BarbecueId { get; set; }

      private decimal _sugestedValue;

      public Participant participant { get; set; }

      public List<ParticipantDTO> participants { get; set; } = new List<ParticipantDTO>();

      public List<Participant> participantsEntity { get; set; } = new List<Participant>();

      public decimal SugestedValue
      {
         get { return _sugestedValue; }
         set
         {
            _sugestedValue = value > 0 ? value : 0;
         }
      }

      private decimal _sugestedValueWithDink;

      public decimal SugestedValueWithDink
      {
         get { return _sugestedValueWithDink; }
         set
         {
            _sugestedValueWithDink = value > 0 ? value : 0;
         }
      }

      public ParticipantDTO participantDTO { get; set; }

      public ParticipantFake()
      {
         InitFakeDataObjects();
      }

      protected void InitFakeDataObjects()
      {
         Id = Faker.RandomNumber.Next(100);
         Name = Faker.Name.FullName();
         ContribuitionValue = Faker.RandomNumber.Next(10, 40);
         SugestedValue = Faker.RandomNumber.Next(0, 50);
         SugestedValueWithDink = Faker.RandomNumber.Next(0, 50);
         BarbecueId = Faker.RandomNumber.Next(10, 40);

         participant = new Participant(
            Name,
            ContribuitionValue,
            SugestedValue,
            SugestedValueWithDink
         );

         participant.CreatedAt = DateTime.UtcNow;

         participantDTO = new ParticipantDTO
         {
            Name = Name,
            ContribuitionValue = ContribuitionValue,
            SugestedValue = SugestedValue,
            SugestedValueWithDink = SugestedValueWithDink,
            BarbecueId = BarbecueId
         };

         for (int i = 0; i < 40; i++)
         {
            var participantsDto = new ParticipantDTO()
            {
               Name = Faker.Name.FullName(),
               ContribuitionValue = Faker.RandomNumber.Next(10, 40),
               SugestedValue = Faker.RandomNumber.Next(0, 50),
               SugestedValueWithDink = Faker.RandomNumber.Next(0, 50),
               BarbecueId = Faker.RandomNumber.Next(10, 40)
            };

            participants.Add(participantsDto);

            var entity = new Participant(
               Faker.Name.FullName(),
               Faker.RandomNumber.Next(10, 40),
               Faker.RandomNumber.Next(0, 50),
               Faker.RandomNumber.Next(0, 50)
            );

            participantsEntity.Add(entity);
         }
      }
   }
}