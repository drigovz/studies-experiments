using Api.Domain.DTOs.Barbecues;
using Api.Domain.DTOs.Participants;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Services.BarbecueService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Application.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class BarbecuesController : ControllerBase
    {
        private readonly IBarbecueService _service;
        private readonly ILogger<BarbecuesController> _logger;

        public BarbecuesController(IBarbecueService service, ILogger<BarbecuesController> logger)
        {
            _service = service;
            _logger = logger;
        }

        /// <summary>
        /// Buscar todos os churrascos cadastrados
        /// </summary>
        /// <returns>Retorna uma lista com todos os churrascos cadastrados no banco de dados</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BarbecueDTO>>> GetAll()
        {
            try
            {
                var barbecues = await _service.GetAllAsync();
                _logger.LogInformation("Get all barbecues: http://localhost:5000/api/barbecues");
                return barbecues.ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error when try to connect on server. Error: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error when try to connect on server");
            }
        }

        /// <summary>
        /// Exibe detalhes de um determinado churrasco
        /// </summary>
        /// <param name="id">ID do churrasco</param>
        /// <returns>Retorna um objeto contendo todos os detalhes de um churrasco</returns>
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([BindRequired] int id)
        {
            try
            {
                _logger.LogInformation("Access method GetById: http://localhost:5000/api/barbecues/" + id);
                var barbecue = await _service.GetAsync(id);
                if (barbecue == null)
                {
                    _logger.LogWarning($"Failed to get. Barbecue with id {id} not found: http://localhost:5000/api/barbecues/" + id);
                    return NotFound($"Barbecue with id {id} not found");
                }
                else
                    return new ObjectResult(barbecue);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error when try to connect get detais about barbecue. Error: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error when try to connect on server");
            }
        }

        /// <summary>
        /// Insere um novo churrasco na base de dados.
        /// </summary>
        /// <param name="barbecue">Dados do churrasco a ser inserido</param>
        /// <returns>Retorna informações do novo churrasco inserido</returns>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] BarbecueDTO barbecue)
        {
            try
            {
                var result = await _service.PostAsync(barbecue);
                _logger.LogInformation("Add new barbecue: http://localhost:5000/api/barbecues/");
                return new ObjectResult(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error when try to add a new barbecue. Error: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error when try to add a new barbecue: {ex.Message}");
            }
        }

        /// <summary>
        /// Atualiza informações de um churrasco
        /// </summary>
        /// <param name="id">ID do churrasco a ser atualizado</param>
        /// <param name="barbecue">Dados do churrasco a ser atualizado</param>
        /// <returns>Retorna mensagem de sucesso em atualizações bem sucedidas</returns>
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Update([BindRequired] int id, [FromBody] BarbecueDTO barbecue)
        {
            try
            {
                if (barbecue == null || id != barbecue.Id)
                {
                    _logger.LogWarning($"Failed to update. Barbecue with id {id} not found: http://localhost:5000/api/barbecues/" + id);
                    return BadRequest($"Barbecue with id {id} not found");
                }
                else
                {
                    var result = await _service.PutAsync(barbecue);
                    _logger.LogInformation("Update barbecue: http://localhost:5000/api/barbecues/" + id);
                    return StatusCode(StatusCodes.Status200OK, $"Barbecue id {id} update succesfull");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error when try to update barbecue. Error: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error when try to update barbecue {ex.Message}");
            }
        }

        /// <summary>
        /// Exclui um churrasco cadastrado
        /// </summary>
        /// <param name="id">ID do churrasco a ser excluído</param>
        /// <returns>Mensagem de exclusão bem sucedida</returns>
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete([BindRequired] int id)
        {
            try
            {
                var result = await _service.GetAsync(id);
                if (result == null)
                {
                    _logger.LogWarning($"Failed to delete. Barbecue with id {id} not found: http://localhost:5000/api/barbecues/" + id);
                    return NotFound($"Barbecue with id {id} not found");
                }

                await _service.DeleteAsync(id);

                _logger.LogInformation("Delete barbecue: http://localhost:5000/api/barbecues/" + id);

                return StatusCode(StatusCodes.Status200OK, "Barbecue deleted succesfull");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error when try to delete barbecue. Error: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error when try to delete barbecue");
            }
        }

        /// <summary>
        /// Lista todos os participantes de um determinado churrasco
        /// </summary>
        /// <param name="barbecueId">ID do churrasco no qual se deseja ver os participantes</param>
        /// <returns>Retorna uma lista de participantes do churrasco</returns>
        [HttpGet("participants/{barbecueId:int}")]
        public async Task<IEnumerable<Participant>> GetParticipants([BindRequired] int barbecueId)
        {
            _logger.LogInformation("Get all participants of barbecue: http://localhost:5000/api/barbecues/participants/" + barbecueId);
            return await _service.BarbecueParticipants(barbecueId);
        }

        /// <summary>
        /// Incluir um participante no churrasco
        /// </summary>
        /// <param name="participant">Informações do participant do churrasco</param>
        /// <returns>Retorna um objeto com informações do participante adicionado</returns>
        [HttpPost("participants")]
        public async Task<ActionResult> AddParticipantsOnBarbecue([FromBody] ParticipantDTO participant)
        {
            try
            {
                if (participant == null || participant.BarbecueId <= 0)
                {
                    _logger.LogWarning("Participant of barbecue not valid data: http://localhost:5000/api/barbecues/participants/");
                    return BadRequest("Please, make sure to fill in the fields correctly!");
                }

                _logger.LogInformation("Add participants on barbecue: http://localhost:5000/api/barbecues/participants");

                var result = await _service.AddParticipantsOnBarbecue(participant);
                return new ObjectResult(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error when try to add barbecue participants. Error: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error when try to add barbecue participants: {ex.Message}");
            }
        }

        /// <summary>
        /// Remove um participante do churrasco
        /// </summary>
        /// <param name="participantId">ID do participante a ser removido</param>
        /// <returns>Retorna mensagem de participante removido</returns>
        [HttpDelete("participants/{participantId:int}")]
        public async Task<ActionResult> RemoveParticipantsFromBarbecue([BindRequired] int participantId)
        {
            try
            {
                if (participantId <= 0)
                {
                    _logger.LogWarning("Participant of barbecue not found: http://localhost:5000/api/barbecues/participants/" + participantId);
                    return BadRequest("Please, make sure you are correctly parameters!");
                }

                await _service.RemoveParticipantsFromBarbecue(participantId);

                _logger.LogInformation("Remove participant of barbecue: http://localhost:5000/api/barbecues/participants/" + participantId);

                return StatusCode(StatusCodes.Status200OK, "Participant deleted succesfull");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error when try to remove participant from barbecue. Error: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error when try to remove participant from barbecue: {ex.Message}");
            }
        }
    }
}
