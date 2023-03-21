using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.DTOs.Barbecues;
using Api.Domain.Interfaces.Services.BarbecueService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace Api.Application.Test.Controllers.Test
{
    public class BarbecuesControllerTest
    {
        private BarbecuesController _controller;
        private Mock<IBarbecueService> serviceMock = new Mock<IBarbecueService>();
        private Mock<ILogger<BarbecuesController>> loggerMock = new Mock<ILogger<BarbecuesController>>();
        Random random = new Random();

        [Fact]
        public async Task Should_be_possible_to_post_new_barbecue()
        {
            var date = DateTime.UtcNow.AddDays(random.Next(10, 50));
            var description = Faker.Lorem.Words(30).ToString();
            var additionalNotes = Faker.Lorem.Words(50).ToString();

            serviceMock.Setup(m => m.PostAsync(It.IsAny<BarbecueDTO>())).ReturnsAsync(
               new BarbecueDTO
               {
                   Id = Faker.RandomNumber.Next(100),
                   Date = date,
                   Description = description,
                   AdditionalNotes = additionalNotes
               }
            );

            _controller = new BarbecuesController(serviceMock.Object, loggerMock.Object);

            Mock<IUrlHelper> urlMock = new Mock<IUrlHelper>();
            urlMock.Setup(x => x.Link(It.IsAny<string>(), It.IsAny<object>())).Returns("http://localhost:5000");
            _controller.Url = urlMock.Object;

            var barbecueDto = new BarbecueDTO
            {
                Date = date,
                Description = description,
                AdditionalNotes = additionalNotes
            };

            var result = await _controller.Post(barbecueDto);

            Assert.True(result is ObjectResult);

            var resultObject = ((ObjectResult)result).Value as BarbecueDTO;

            Assert.NotNull(resultObject);
            Assert.Equal(barbecueDto.Date, resultObject.Date);
            Assert.Equal(barbecueDto.Description, resultObject.Description);
            Assert.Equal(barbecueDto.AdditionalNotes, resultObject.AdditionalNotes);
        }

        [Fact]
        public async Task Should_be_possible_to_update_barbecue()
        {
            var date = DateTime.UtcNow.AddDays(random.Next(10, 50));
            var description = Faker.Lorem.Words(30).ToString();
            var additionalNotes = Faker.Lorem.Words(50).ToString();

            serviceMock.Setup(m => m.PutAsync(It.IsAny<BarbecueDTO>())).ReturnsAsync(
               new BarbecueDTO
               {
                   Id = Faker.RandomNumber.Next(100),
                   Date = date,
                   Description = description,
                   AdditionalNotes = additionalNotes
               }
            );

            _controller = new BarbecuesController(serviceMock.Object, loggerMock.Object);

            Mock<IUrlHelper> urlMock = new Mock<IUrlHelper>();
            urlMock.Setup(x => x.Link(It.IsAny<string>(), It.IsAny<object>())).Returns("http://localhost:5000");
            _controller.Url = urlMock.Object;

            var barbecueDto = new BarbecueDTO
            {
                Id = Faker.RandomNumber.Next(100),
                Date = date,
                Description = description,
                AdditionalNotes = additionalNotes
            };

            var result = await _controller.Update(barbecueDto.Id, barbecueDto);
            Assert.True(result is ObjectResult);
        }

        [Fact]
        public async Task Should_not_possible_to_update_unexistent_barbecue()
        {
            var id = Faker.RandomNumber.Next(100);
            var date = DateTime.UtcNow.AddDays(random.Next(10, 50));
            var description = Faker.Lorem.Words(30).ToString();
            var additionalNotes = Faker.Lorem.Words(50).ToString();

            serviceMock.Setup(m => m.PutAsync(It.IsAny<BarbecueDTO>())).ReturnsAsync(
               new BarbecueDTO
               {
                   Id = id,
                   Date = date,
                   Description = description,
                   AdditionalNotes = additionalNotes
               }
            );

            _controller = new BarbecuesController(serviceMock.Object, loggerMock.Object);
            _controller.ModelState.AddModelError("id", "Barbecue with not found");

            Mock<IUrlHelper> urlMock = new Mock<IUrlHelper>();
            urlMock.Setup(x => x.Link(It.IsAny<string>(), It.IsAny<object>())).Returns("http://localhost:5000");
            _controller.Url = urlMock.Object;

            var barbecueDto = new BarbecueDTO
            {
                Id = id,
                Date = date,
                Description = description,
                AdditionalNotes = additionalNotes
            };

            ActionResult result = await _controller.Update(Faker.RandomNumber.Next(30000, 50000), barbecueDto);

            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.IsType<string>(badRequestResult.Value);
        }

        [Fact]
        public async Task Should_not_possible_to_delete_unexistent_barbecue()
        {
            var id = Faker.RandomNumber.Next(100, 300);
            serviceMock.Setup(m => m.DeleteAsync(id)).ReturnsAsync(true);

            _controller = new BarbecuesController(serviceMock.Object, loggerMock.Object);

            Mock<IUrlHelper> urlMock = new Mock<IUrlHelper>();
            urlMock.Setup(x => x.Link(It.IsAny<string>(), It.IsAny<object>())).Returns("http://localhost:5000");
            _controller.Url = urlMock.Object;

            var result = await _controller.Delete(id);

            Assert.True(result is ObjectResult);

            var resultValue = ((ObjectResult)result).Value;
            Assert.NotNull(resultValue);
            Assert.True(resultValue is string);
            Assert.Equal($"Barbecue with id {id} not found", resultValue.ToString());
        }

        [Fact]
        public async Task Should_be_possible_to_get_barbecue_by_id()
        {
            var id = Faker.RandomNumber.Next(100, 300);
            var date = DateTime.UtcNow.AddDays(random.Next(60, 90));
            var description = Faker.Lorem.Words(50).ToString();
            var totalParticipants = Faker.RandomNumber.Next(0, 10);
            var additionalNotes = Faker.Lorem.Words(70).ToString();
            var totalValue = (decimal)Faker.RandomNumber.Next(0, 1000);

            serviceMock.Setup(m => m.GetAsync(It.IsAny<int>())).ReturnsAsync(
               new BarbecueDetailsDTO
               {
                   Id = id,
                   Date = date,
                   Description = description,
                   AdditionalNotes = additionalNotes,
                   TotalParticipants = totalParticipants,
                   TotalValue = totalValue
               }
            );

            _controller = new BarbecuesController(serviceMock.Object, loggerMock.Object);

            var result = await _controller.GetById(id);

            Assert.True(result is ObjectResult);

            var resultValue = ((ObjectResult)result).Value as BarbecueDetailsDTO;
            Assert.NotNull(resultValue);
            Assert.Equal(id, resultValue.Id);
            Assert.Equal(date, resultValue.Date);
            Assert.Equal(description, resultValue.Description);
            Assert.Equal(additionalNotes, resultValue.AdditionalNotes);
            Assert.Equal(totalParticipants, resultValue.TotalParticipants);
            Assert.Equal(totalValue, resultValue.TotalValue);
        }

        [Fact]
        public async Task Should_not_possible_to_get_unexistent_barbecue_by_id()
        {
            var id = Faker.RandomNumber.Next(100, 300);
            var fakerId = Faker.RandomNumber.Next(400, 900);

            serviceMock.Setup(m => m.GetAsync(id)).ReturnsAsync(
               new BarbecueDetailsDTO
               {
                   Id = id,
                   Date = DateTime.UtcNow.AddDays(random.Next(60, 90)),
                   Description = Faker.Lorem.Words(50).ToString(),
                   AdditionalNotes = Faker.Lorem.Words(70).ToString(),
                   TotalParticipants = Faker.RandomNumber.Next(0, 10),
                   TotalValue = (decimal)Faker.RandomNumber.Next(0, 1000)
               }
            );

            _controller = new BarbecuesController(serviceMock.Object, loggerMock.Object);

            var result = await _controller.GetById(fakerId);

            Assert.True(result is NotFoundObjectResult);

            var resultValue = ((NotFoundObjectResult)result).Value;
            Assert.NotNull(resultValue);
            Assert.True(resultValue is string);
            Assert.Equal($"Barbecue with id {fakerId} not found", resultValue.ToString());
        }

        [Fact]
        public async Task Should_be_possible_to_list_barbecues()
        {
            var ramdomValue = Faker.RandomNumber.Next(10, 300);
            List<BarbecueDTO> barbecueDto = new List<BarbecueDTO>();

            for (int i = 0; i < ramdomValue; i++)
            {
                var dto = new BarbecueDTO
                {
                    Id = Faker.RandomNumber.Next(10, 500),
                    Date = DateTime.UtcNow.AddDays(random.Next(60, 90)),
                    Description = Faker.Lorem.Words(50).ToString(),
                    AdditionalNotes = Faker.Lorem.Words(70).ToString(),
                };

                barbecueDto.Add(dto);
            }

            serviceMock.Setup(m => m.GetAllAsync()).ReturnsAsync(barbecueDto);

            _controller = new BarbecuesController(serviceMock.Object, loggerMock.Object);

            var result = await _controller.GetAll();

            var resultValue = result.Value;

            Assert.True(resultValue.ToList().Count > 9);
        }
    }
}
