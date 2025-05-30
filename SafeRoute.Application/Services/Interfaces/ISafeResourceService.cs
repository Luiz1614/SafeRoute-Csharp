using SafeRoute.Contracts.Dtos.Requests;
using SafeRoute.Contracts.Dtos.Responses;

namespace SafeRoute.Application.Services.Interfaces
{
    public interface ISafeResourceService
    {
        Task<SafeResourceResponseDto> AddAsync(SafeResourceRequestDto requestDto);
        Task<bool> DeleteByResourceCodeAsync(string resourceCode);
        Task<IEnumerable<SafeResourceResponseDto>> GetAllAsync();
        Task<SafeResourceResponseDto?> GetByResourceCodeAsync(string resourceCode);
        Task<SafeResourceResponseDto?> UpdateByResourceCodeAsync(string resourceCode, SafeResourceRequestDto requestDto);
    }
}