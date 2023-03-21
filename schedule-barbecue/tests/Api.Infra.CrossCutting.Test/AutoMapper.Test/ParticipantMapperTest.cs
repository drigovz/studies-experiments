using System;
using Api.Domain.DTOs.Participants;
using Api.Domain.Entities;
using Api.Infra.CrossCutting.Test.Config;
using Xunit;

namespace Api.Infra.CrossCutting.Test.AutoMapper.Test
{
   public class ParticipantMapperTest : BaseTestService
   {
      [Fact]
      public void Should_be_possible_to_mapper_ParticipantDTO_to_Participant_Entity()
      {
         var participantDto = new ParticipantDTO
         {
            Name = Faker.Name.FullName(),
            BarbecueId = Faker.RandomNumber.Next(100),
            ContribuitionValue = Convert.ToDecimal(Faker.RandomNumber.Next(0, 10000)),
            SugestedValue = Convert.ToDecimal(Faker.RandomNumber.Next(0, 100)),
            SugestedValueWithDink = Convert.ToDecimal(Faker.RandomNumber.Next(0, 150)),
         };

         var dtoToEntity = mapper.Map<Participant>(participantDto);

         Assert.Equal(participantDto.Name, dtoToEntity.Name);
         Assert.Equal(participantDto.BarbecueId, dtoToEntity.BarbecueId);
         Assert.Equal(participantDto.ContribuitionValue, dtoToEntity.ContribuitionValue);
         Assert.Equal(participantDto.SugestedValue, dtoToEntity.SugestedValue);
         Assert.Equal(participantDto.SugestedValueWithDink, dtoToEntity.SugestedValueWithDink);
      }
   }
}
