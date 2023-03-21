using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Services.Participants;
using Api.Service.Test.Fakes;
using Moq;
using Xunit;

namespace Api.Service.Test
{
   public class ParticipantsServiceTest : ParticipantFake
   {
      private IParticipantService _service;
      private Mock<IParticipantService> _serviceMock;

      [Fact]
      public async Task Should_be_possible_to_list_all_participants_of_barbecue()
      {
         _serviceMock = new Mock<IParticipantService>();
         _serviceMock.Setup(m => m.GetAllAsync()).ReturnsAsync(participantsEntity);
         _service = _serviceMock.Object;

         var result = await _service.GetAllAsync();

         Assert.NotNull(result);
         Assert.NotEmpty(result);
      }

      [Fact]
      public async Task Should_be_return_participant()
      {
         _serviceMock = new Mock<IParticipantService>();
         _serviceMock.Setup(m => m.GetAsync(Id)).ReturnsAsync(participant);
         _service = _serviceMock.Object;

         var result = await _service.GetAsync(Id);

         Assert.NotNull(result);
         Assert.NotNull(result.Name);
      }

      [Fact]
      public async Task Should_be_return_null_participant()
      {
         _serviceMock = new Mock<IParticipantService>();
         _serviceMock.Setup(m => m.GetAsync(It.IsAny<int>())).Returns(Task.FromResult((Participant)null));
         _service = _serviceMock.Object;

         var result = await _service.GetAsync(Id);

         Assert.Null(result);
      }

      [Fact]
      public async Task Should_be_possible_to_create_new_participant()
      {
         _serviceMock = new Mock<IParticipantService>();
         _serviceMock.Setup(m => m.PostAsync(participant)).ReturnsAsync(participant);
         _service = _serviceMock.Object;

         var result = await _service.PostAsync(participant);

         Assert.NotNull(result);
         Assert.NotNull(result.CreatedAt);
         Assert.NotNull(result.Name);
      }

      [Fact]
      public async Task Should_be_possible_to_update_participant()
      {
         _serviceMock = new Mock<IParticipantService>();
         _serviceMock.Setup(m => m.PutAsync(participant)).ReturnsAsync(participant);
         _service = _serviceMock.Object;

         var result = await _service.PutAsync(participant);

         Assert.NotNull(result);
         Assert.Equal(participantDTO.ContribuitionValue, result.ContribuitionValue);
         Assert.Equal(participantDTO.Name, result.Name);
         Assert.Equal(participantDTO.ContribuitionValue, result.ContribuitionValue);
      }
   }
}