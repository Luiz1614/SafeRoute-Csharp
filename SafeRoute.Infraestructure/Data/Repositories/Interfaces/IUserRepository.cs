using SafeRoute.Contracts.Dtos.Requests;
using SafeRoute.Contracts.Dtos.Responses;

public interface IUserRepository
{
    Task<UserResponseDto> AddAsync(UserRequestDto requestDto);
    Task<bool> DeleteAsync(int id);
    Task<IEnumerable<UserResponseDto>> GetAllAsync();
    Task<UserResponseDto?> GetByIdAsync(int id);
    Task<UserResponseDto?> UpdateAsync(int id, UserRequestDto requestDto);
}