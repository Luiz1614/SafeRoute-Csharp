using SafeRoute.Application.Services.Interfaces;
using SafeRoute.Contracts.Dtos.Requests;
using SafeRoute.Contracts.Dtos.Responses;
using SafeRoute.Infraestructure.Data.Repositories.Interfaces;

namespace SafeRoute.Application
{
    public class SafeResourceService : ISafeResourceService
    {
        private readonly ISafeResourceRepository _resourceRepository;

        public SafeResourceService(ISafeResourceRepository resourceRepository)
        {
            _resourceRepository = resourceRepository;
        }

        public async Task<SafeResourceResponseDto> AddAsync(SafeResourceRequestDto requestDto)
        {
            return await _resourceRepository.AddAsync(requestDto);
        }

        public async Task<IEnumerable<SafeResourceResponseDto>> GetAllAsync()
        {
            return await _resourceRepository.GetAllAsync();
        }

        public async Task<SafeResourceResponseDto?> GetByResourceCodeAsync(string resourceCode)
        {
            return await _resourceRepository.GetByResourceCodeAsync(resourceCode);
        }

        public async Task<SafeResourceResponseDto?> UpdateByResourceCodeAsync(string resourceCode, SafeResourceRequestDto requestDto)
        {
            return await _resourceRepository.UpdateByResourceCodeAsync(resourceCode, requestDto);
        }

        public async Task<bool> DeleteByResourceCodeAsync(string resourceCode)
        {
            return await _resourceRepository.DeleteByResourceCodeAsync(resourceCode);
        }
    }
}
