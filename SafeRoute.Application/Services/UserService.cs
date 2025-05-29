using SafeRoute.Application.Services.Interfaces;
using SafeRoute.Contracts.Dtos.Requests;
using SafeRoute.Contracts.Dtos.Responses;

namespace SafeRoute.Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<UserResponseDto> AddUserAsync(UserRequestDto requestDto)
    {
        return await _userRepository.AddAsync(requestDto);
    }

    public async Task<IEnumerable<UserResponseDto>> GetAllUsersAsync()
    {
        return await _userRepository.GetAllAsync();
    }

    public async Task<UserResponseDto?> GetUserByIdAsync(int id)
    {
        return await _userRepository.GetByIdAsync(id);
    }

    public async Task<UserResponseDto?> UpdateUserAsync(int id, UserRequestDto requestDto)
    {
        return await _userRepository.UpdateAsync(id, requestDto);
    }

    public async Task<bool> DeleteUserAsync(int id)
    {
        return await _userRepository.DeleteAsync(id);
    }
}
