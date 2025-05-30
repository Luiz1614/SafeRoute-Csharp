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

    public async Task<UserResponseDto?> GetUserByCpfAsync(string cpf)
    {
        return await _userRepository.GetByCpfAsync(cpf);
    }

    public async Task<UserResponseDto?> UpdateUserByCpfAsync(string cpf, UserRequestDto requestDto)
    {
        return await _userRepository.UpdateByCpfAsync(cpf, requestDto);
    }

    public async Task<bool> DeleteUserByCpfAsync(string cpf)
    {
        return await _userRepository.DeleteByCpfAsync(cpf);
    }
}
