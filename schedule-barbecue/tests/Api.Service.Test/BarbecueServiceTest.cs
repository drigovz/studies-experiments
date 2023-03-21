using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.DTOs.Barbecues;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Services.BarbecueService;
using Api.Service.Test.Fakes;
using Moq;
using Xunit;

namespace Api.Service.Test
{
   public class BarbecueServiceTest : BarbecueFake
   {
      private IBarbecueService _service;
      private Mock<IBarbecueService> _serviceMock;

      //[Fact(DisplayName = "Should be possivel to execute GET method")]
      [Fact]
      public async Task Should_be_possivel_to_get_barbecue_by_id()
      {
         // Act
         _serviceMock = new Mock<IBarbecueService>();
         _serviceMock.Setup(m => m.GetAsync(Id)).ReturnsAsync(barbecueDetailsDto);
         _service = _serviceMock.Object;

         // Arrange
         var result = await _service.GetAsync(Id);

         // Assert
         Assert.NotNull(result);
         Assert.True(result.Id == Id);
         Assert.Equal(Description, result.Description);
      }

      [Fact]
      public async Task Should_be_return_null_object()
      {
         _serviceMock = new Mock<IBarbecueService>();
         _serviceMock.Setup(m => m.GetAsync(It.IsAny<int>())).Returns(Task.FromResult((BarbecueDetailsDTO)null));
         _service = _serviceMock.Object;

         var result = await _service.GetAsync(Id);

         Assert.Null(result);
      }

      [Fact]
      public async Task Should_be_return_list_of_barbecues()
      {
         _serviceMock = new Mock<IBarbecueService>();
         _serviceMock.Setup(m => m.GetAllAsync()).ReturnsAsync(barbecues);
         _service = _serviceMock.Object;

         var barbecuesList = await _service.GetAllAsync();

         Assert.NotNull(barbecuesList);
         Assert.NotEmpty(barbecuesList);
      }

      [Fact]
      public async Task Should_be_possible_to_create_new_barbecue()
      {
         _serviceMock = new Mock<IBarbecueService>();
         _serviceMock.Setup(m => m.PostAsync(barbecueDto)).ReturnsAsync(barbecueDto);
         _service = _serviceMock.Object;

         var result = await _service.PostAsync(barbecueDto);

         Assert.NotNull(result);
         Assert.Equal(barbecueDto.Description, result.Description);
         Assert.Equal(barbecueDto.AdditionalNotes, result.AdditionalNotes);
      }

      [Fact]
      public async Task Should_be_possible_update_barbecue()
      {
         _serviceMock = new Mock<IBarbecueService>();
         _serviceMock.Setup(m => m.PutAsync(barbecueDto)).ReturnsAsync(barbecueDto);
         _service = _serviceMock.Object;

         var result = await _service.PutAsync(barbecueDto);

         Assert.NotNull(result);
         Assert.Equal(barbecueDto.Id, result.Id);
         Assert.Equal(barbecueDto.Description, result.Description);
         Assert.Equal(barbecueDto.AdditionalNotes, result.AdditionalNotes);
      }

      [Fact]
      public async Task Should_be_possible_delete_barbecue()
      {
         _serviceMock = new Mock<IBarbecueService>();
         _serviceMock.Setup(m => m.DeleteAsync(It.IsAny<int>())).ReturnsAsync(true);
         _service = _serviceMock.Object;

         var result = await _service.DeleteAsync(Id);

         Assert.True(result);
      }

      [Fact]
      public async Task Should_be_return_false_when_try_to_delete_unexistent_barbecue()
      {
         _serviceMock = new Mock<IBarbecueService>();
         _serviceMock.Setup(m => m.DeleteAsync(It.IsAny<int>())).ReturnsAsync(false);
         _service = _serviceMock.Object;

         Random random = new Random();
         int randomId = random.Next(20000, 50000);
         var result = await _service.DeleteAsync(randomId);

         Assert.False(result);
      }

      [Fact]
      public async Task Should_be_return_a_list_of_barbecues_participants()
      {
         _serviceMock = new Mock<IBarbecueService>();
         _serviceMock.Setup(m => m.BarbecueParticipants(Id)).ReturnsAsync(participantsEntity);
         _service = _serviceMock.Object;

         var result = await _service.BarbecueParticipants(Id);
         var expected = typeof(List<Participant>);

         Assert.NotNull(result);
         Assert.IsType(expected, result);
      }

      [Fact]
      public async Task Should_be_possible_to_add_participants_on_barbecue()
      {
         _serviceMock = new Mock<IBarbecueService>();
         _serviceMock.Setup(m => m.AddParticipantsOnBarbecue(participantDTO)).ReturnsAsync(participantDTO);
         _service = _serviceMock.Object;

         var result = await _service.AddParticipantsOnBarbecue(participantDTO);

         Assert.NotNull(result);
         Assert.True(result.BarbecueId > 0);
         Assert.NotEmpty(result.Name);
         Assert.Equal(participantDTO.Name, result.Name);
      }

      [Fact]
      public async Task Should_be_possible_to_remove_participant_of_barbecue()
      {
         _serviceMock = new Mock<IBarbecueService>();
         _serviceMock.Setup(m => m.RemoveParticipantsFromBarbecue(participantDTO.BarbecueId)).ReturnsAsync(true);
         _service = _serviceMock.Object;

         var result = await _service.RemoveParticipantsFromBarbecue(participantDTO.BarbecueId);

         Assert.True(result);
      }
   }
}