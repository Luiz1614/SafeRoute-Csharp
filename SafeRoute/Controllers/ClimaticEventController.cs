using Microsoft.AspNetCore.Mvc;
using SafeRoute.Application.Services.Interfaces;
using SafeRoute.Contracts.Dtos.Requests;
using SafeRoute.Contracts.Dtos.Responses;
using System.Net;

namespace SafeRoute.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClimaticEventController : ControllerBase
{
    private readonly IClimaticEventService _eventService;

    public ClimaticEventController(IClimaticEventService eventService)
    {
        _eventService = eventService;
    }

    [HttpPost]
    public async Task<ActionResult<ClimaticEventResponseDto>> AddEvent([FromBody] ClimaticEventRequestDto request)
    {
        try
        {
            var result = await _eventService.AddEventAsync(request);
            return StatusCode((int)HttpStatusCode.Created, result);
        }
        catch (Exception ex)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, $"Erro interno do servidor: {ex.Message}");
        }
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ClimaticEventResponseDto>>> GetAllEvents()
    {
        try
        {
            var events = await _eventService.GetAllEventsAsync();
            if (events == null || !events.Any())
                return NotFound("Nenhum evento encontrado.");
            return Ok(events);
        }
        catch (Exception ex)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, $"Erro interno do servidor: {ex.Message}");
        }
    }

    [HttpGet("{eventCode}")]
    public async Task<ActionResult<ClimaticEventResponseDto>> GetEventByEventCode(string eventCode)
    {
        try
        {
            var evt = await _eventService.GetEventByEventCodeAsync(eventCode);
            if (evt == null)
                return NotFound("Evento não encontrado.");
            return Ok(evt);
        }
        catch (Exception ex)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, $"Erro interno do servidor: {ex.Message}");
        }
    }

    [HttpPut("{eventCode}")]
    public async Task<ActionResult<ClimaticEventResponseDto>> UpdateEvent(string eventCode, [FromBody] ClimaticEventRequestDto request)
    {
        try
        {
            var result = await _eventService.UpdateEventByEventCodeAsync(eventCode, request);
            if (result == null)
                return NotFound("Evento não encontrado.");
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, $"Erro interno do servidor: {ex.Message}");
        }
    }

    [HttpDelete("{eventCode}")]
    public async Task<ActionResult> DeleteEvent(string eventCode)
    {
        try
        {
            var deleted = await _eventService.DeleteEventByEventCodeAsync(eventCode);
            if (!deleted)
                return NotFound("Evento não encontrado.");
            return Ok("Evento deletado com sucesso!");
        }
        catch (Exception ex)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, $"Erro interno do servidor: {ex.Message}");
        }
    }
}
