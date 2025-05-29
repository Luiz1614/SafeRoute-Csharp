using SafeRoute.Contracts.Dtos.Requests;
using SafeRoute.Contracts.Dtos.Responses;

namespace SafeRoute.Application.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserResponseDto> AddUserAsync(UserRequestDto requestDto);
        Task<bool> DeleteUserAsync(int id);
        Task<IEnumerable<UserResponseDto>> GetAllUsersAsync();
        Task<UserResponseDto?> GetUserByIdAsync(int id);
        Task<UserResponseDto?> UpdateUserAsync(int id, UserRequestDto requestDto);
    }
}