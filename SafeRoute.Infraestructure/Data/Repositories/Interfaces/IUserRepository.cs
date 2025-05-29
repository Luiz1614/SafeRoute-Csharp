using SafeRoute.Contracts.Dtos.Requests;
using SafeRoute.Contracts.Dtos.Responses;

public interface IUserRepository
{
    Task<UserResponseDto> AddAsync(UserRequestDto requestDto);
    Task<bool> DeleteAsync(Guid id);
    Task<IEnumerable<UserResponseDto>> GetAllAsync();
    Task<UserResponseDto?> GetByIdAsync(Guid id);
    Task<UserResponseDto?> UpdateAsync(UserRequestDto requestDto);
}