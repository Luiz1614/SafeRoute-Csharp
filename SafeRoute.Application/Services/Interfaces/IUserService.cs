using SafeRoute.Contracts.Dtos.Requests;
using SafeRoute.Contracts.Dtos.Responses;

namespace SafeRoute.Application.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserResponseDto> AddUserAsync(UserRequestDto requestDto);
        Task<bool> DeleteUserAsync(Guid id);
        Task<IEnumerable<UserResponseDto>> GetAllUsersAsync();
        Task<UserResponseDto?> GetUserByIdAsync(Guid id);
        Task<UserResponseDto?> UpdateUserAsync(UserRequestDto requestDto);
    }
}