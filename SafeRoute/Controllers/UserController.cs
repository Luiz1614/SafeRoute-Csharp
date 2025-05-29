using Microsoft.AspNetCore.Mvc;
using SafeRoute.Application.Services.Interfaces;
using SafeRoute.Contracts.Dtos.Requests;
using SafeRoute.Contracts.Dtos.Responses;
using SafeRoute.Domain.Entities;
using System.Net;

namespace SafeRoute.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<ActionResult<UserResponseDto>> AddUser([FromBody] UserRequestDto request)
        {
            try
            {
                var result = await _userService.AddUserAsync(request);

                return StatusCode((int) HttpStatusCode.OK, "Usuário Adicionado com sucesso.");
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserResponseDto>>> GetAllUsers()
        {
            try
            {
                var users = await _userService.GetAllUsersAsync();

                if (users == null)
                    return StatusCode((int) HttpStatusCode.NotFound, "Nenhum Usuário encontrado.");

                return StatusCode((int) HttpStatusCode.OK, users);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserResponseDto>> GetUserById(int id)
        {
            try
            {
                var user = await _userService.GetUserByIdAsync(id);

                if (user == null)
                    return StatusCode((int)HttpStatusCode.NotFound, "Nenhum Usuário encontrado.");

                return StatusCode((int)HttpStatusCode.OK, user);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UserResponseDto>> UpdateUser(int id, [FromBody] UserRequestDto request)
        {
            try
            {
                var result = await _userService.UpdateUserAsync(id, request);

                if (result == null)
                    return StatusCode((int)HttpStatusCode.NotFound, "Nenhum usuário encontrado.");

                return StatusCode((int)HttpStatusCode.NoContent, "Usuário atualizado com sucesso!");
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            try
            {
                var deleted = await _userService.DeleteUserAsync(id);

                if (!deleted)
                    return StatusCode((int)HttpStatusCode.NotFound, "Usuário não encontrado.");

                return StatusCode((int)HttpStatusCode.NoContent, "Usuário deletado com sucesso!");
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, $"Internal server error: {ex.Message}");
            }
        }
    }
}
