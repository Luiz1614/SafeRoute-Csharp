using SafeRoute.Contracts.Dtos.Requests;
using SafeRoute.Contracts.Dtos.Responses;

namespace SafeRoute.Application.Services.Interfaces
{
    public interface IClimaticEventService
    {
        Task<ClimaticEventResponseDto> AddEventAsync(ClimaticEventRequestDto requestDto);
        Task<bool> DeleteEventByEventCodeAsync(string eventCode);
        Task<IEnumerable<ClimaticEventResponseDto>> GetAllEventsAsync();
        Task<ClimaticEventResponseDto?> GetEventByEventCodeAsync(string eventCode);
        Task<ClimaticEventResponseDto?> UpdateEventByEventCodeAsync(string eventCode, ClimaticEventRequestDto requestDto);
    }
}