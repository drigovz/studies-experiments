using System;
using System.Collections.Generic;
using Api.Domain.DTOs.Barbecues;
using Api.Domain.DTOs.Participants;
using Api.Domain.Entities;

namespace Api.Service.Test.Fakes
{
   public class BarbecueFake
   {
      public int Id { get; set; }
      public DateTime Date { get; set; }
      public string Description { get; set; }
      public string AdditionalNotes { get; set; }
      public int TotalParticipants { get; set; }
      public decimal TotalValue { get; set; }

      public List<BarbecueDTO> barbecues { get; set; } = new List<BarbecueDTO>();
      public BarbecueDTO barbecueDto { get; set; } = new BarbecueDTO();
      public BarbecueDetailsDTO barbecueDetailsDto { get; set; } = new BarbecueDetailsDTO();
      public List<ParticipantDTO> participants { get; set; } = new List<ParticipantDTO>();
      public List<Participant> participantsEntity { get; set; } = new List<Participant>();
      public ParticipantDTO participantDTO { get; set; } = new ParticipantDTO();

      public BarbecueFake()
      {
         InitFakeDataObjects();
      }

      protected void InitFakeDataObjects()
      {
         Id = Faker.RandomNumber.Next(100);
         Date = Faker.Identification.DateOfBirth();
         Description = Faker.Lorem.Words(30).ToString();
         AdditionalNotes = Faker.Lorem.Words(50).ToString();
         
         for (int i = 0; i < 10; i++)
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

         TotalParticipants = participants.Count;

         TotalValue = 0;
         if (participants.Count > 0)
         {
            foreach (var item in participants)
            {
               TotalValue += item.ContribuitionValue;
            }
         }

         for (int i = 0; i < 10; i++)
         {
            var dto = new BarbecueDTO()
            {
               Id = Faker.RandomNumber.Next(100),
               Date = Faker.Identification.DateOfBirth(),
               Description = Faker.Lorem.Words(30).ToString(),
               AdditionalNotes = Faker.Lorem.Words(50).ToString()
            };

            barbecues.Add(dto);
         }

         barbecueDto = new BarbecueDTO()
         {
            Id = Id,
            Date = Date,
            Description = Description,
            AdditionalNotes = AdditionalNotes
         };

         barbecueDetailsDto = new BarbecueDetailsDTO()
         {
            Id = Id,
            Date = Date,
            Description = Description,
            AdditionalNotes = AdditionalNotes,
            TotalParticipants = Faker.RandomNumber.Next(5),
            TotalValue = Faker.RandomNumber.Next(20),
            Participants = participants
         };

         participantDTO = new ParticipantDTO
         {
            Name = Faker.Name.FullName(),
            ContribuitionValue = Faker.RandomNumber.Next(10, 40),
            SugestedValue = Faker.RandomNumber.Next(0, 50),
            SugestedValueWithDink = Faker.RandomNumber.Next(0, 50),
            BarbecueId = Faker.RandomNumber.Next(10, 40)
         };
      }
   }
}