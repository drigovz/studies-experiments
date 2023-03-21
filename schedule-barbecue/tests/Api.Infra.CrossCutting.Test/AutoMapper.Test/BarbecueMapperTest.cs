using System;
using System.Collections.Generic;
using Api.Domain.DTOs.Barbecues;
using Api.Domain.DTOs.Participants;
using Api.Domain.Entities;
using Api.Infra.CrossCutting.Test.Config;
using Xunit;

namespace Api.Infra.CrossCutting.Test.AutoMapper.Test
{
   public class BarbecueMapperTest : BaseTestService
   {
      [Fact]
      public void Should_be_possible_to_mapper_BarbecueDTO_to_Barbecue_Entity()
      {
         var barbecueDto = new BarbecueDTO
         { 
            Id = Faker.RandomNumber.Next(100),
            AdditionalNotes = Faker.Lorem.Words(50).ToString(),
            Description = Faker.Lorem.Words(30).ToString(),
            Date = DateTime.UtcNow.AddDays(Faker.RandomNumber.Next(10))
         };

         var dtoToEntity = mapper.Map<Barbecue>(barbecueDto);

         Assert.Equal(barbecueDto.Id, dtoToEntity.Id);
         Assert.Equal(barbecueDto.Date, dtoToEntity.Date);
         Assert.Equal(barbecueDto.Description, dtoToEntity.Description);
         Assert.Equal(barbecueDto.AdditionalNotes, dtoToEntity.AdditionalNotes);
      }

      [Fact]
      public void Should_be_possible_to_mapper_BarbecueDetailDTO_to_Barbecue_Entity()
      {
         int ramdomValue = Faker.RandomNumber.Next(0, 20);
         List<ParticipantDTO> participants = new List<ParticipantDTO>();

         for (int i = 0; i < ramdomValue; i++)
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
         }

         decimal totalValue = 0;
         if (participants.Count > 0)
         {
            foreach (var item in participants)
            {
               totalValue += item.ContribuitionValue;
            }
         }

         var barbecueDetailsDto = new BarbecueDetailsDTO
         {
            Id = Faker.RandomNumber.Next(100),
            AdditionalNotes = Faker.Lorem.Words(50).ToString(),
            Description = Faker.Lorem.Words(30).ToString(),
            Date = DateTime.UtcNow.AddDays(Faker.RandomNumber.Next(10)),
            Participants = participants, 
            TotalParticipants = participants.Count, 
            TotalValue = totalValue
         };

         var dtoToEntity = mapper.Map<Barbecue>(barbecueDetailsDto);

         Assert.Equal(barbecueDetailsDto.Id, dtoToEntity.Id);
         Assert.Equal(barbecueDetailsDto.AdditionalNotes, dtoToEntity.AdditionalNotes);
         Assert.Equal(barbecueDetailsDto.Description, dtoToEntity.Description);
         Assert.Equal(barbecueDetailsDto.Date, dtoToEntity.Date);
         Assert.Equal(barbecueDetailsDto.Participants.Count, dtoToEntity.Participants.Count);
      }
   }
}
