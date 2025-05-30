using SafeRoute.Contracts.Dtos.Requests;
using SafeRoute.Contracts.Dtos.Responses;

namespace SafeRoute.Application.Services.Interfaces;

public interface IUserService
{
    Task<UserResponseDto> AddUserAsync(UserRequestDto requestDto);
    Task<bool> DeleteUserByCpfAsync(string cpf);
    Task<IEnumerable<UserResponseDto>> GetAllUsersAsync();
    Task<UserResponseDto?> GetUserByCpfAsync(string cpf);
    Task<UserResponseDto?> UpdateUserByCpfAsync(string cpf, UserRequestDto requestDto);
}