using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SafeRoute.Contracts.Dtos.Requests;
using SafeRoute.Contracts.Dtos.Responses;
using SafeRoute.Domain.Entities;
using SafeRoute.Infraestructure.Data.AppData;

public class UserRepository : IUserRepository
{
    private readonly ApplicationContext _context;
    private readonly IMapper _mapper;

    public UserRepository(ApplicationContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<UserResponseDto> AddAsync(UserRequestDto requestDto)
    {
        var user = _mapper.Map<User>(requestDto);

        _context.Add(user);
        await _context.SaveChangesAsync();

        var responseDto = _mapper.Map<UserResponseDto>(user);
        return responseDto;
    }

    public async Task<IEnumerable<UserResponseDto>> GetAllAsync()
    {
        var users = await _context.Users.ToListAsync();
        var responseDtos = _mapper.Map<IEnumerable<UserResponseDto>>(users);
        return responseDtos;
    }

    public async Task<UserResponseDto?> GetByIdAsync(Guid id)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
        if (user == null) return null;

        var responseDto = _mapper.Map<UserResponseDto>(user);
        return responseDto;
    }

    public async Task<UserResponseDto?> UpdateAsync(UserRequestDto requestDto)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == requestDto.Id);
        if (user == null) return null;

        user.Name = requestDto.Name;
        user.Email = requestDto.Email;
        user.Phone = requestDto.Phone;

        await _context.SaveChangesAsync();

        var responseDto = _mapper.Map<UserResponseDto>(user);
        return responseDto;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
        if (user == null) return false;

        _context.Users.Remove(user);
        await _context.SaveChangesAsync();

        return true;
    }
}
