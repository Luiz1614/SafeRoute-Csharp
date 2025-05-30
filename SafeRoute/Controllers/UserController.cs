using Microsoft.AspNetCore.Mvc;
using SafeRoute.Application.Services.Interfaces;
using SafeRoute.Contracts.Dtos.Requests;
using SafeRoute.Contracts.Dtos.Responses;
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
                return StatusCode((int)HttpStatusCode.OK, "Usuário adicionado com sucesso.");
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, $"Erro interno do servidor: {ex.Message}");
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserResponseDto>>> GetAllUsers()
        {
            try
            {
                var users = await _userService.GetAllUsersAsync();

                if (users == null || !users.Any())
                    return StatusCode((int)HttpStatusCode.NotFound, "Nenhum usuário encontrado.");

                return StatusCode((int)HttpStatusCode.OK, users);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, $"Erro interno do servidor: {ex.Message}");
            }
        }

        [HttpGet("{cpf}")]
        public async Task<ActionResult<UserResponseDto>> GetUserByCpf(string cpf)
        {
            try
            {
                var user = await _userService.GetUserByCpfAsync(cpf);

                if (user == null)
                    return StatusCode((int)HttpStatusCode.NotFound, "Nenhum usuário encontrado.");

                return StatusCode((int)HttpStatusCode.OK, user);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, $"Erro interno do servidor: {ex.Message}");
            }
        }

        [HttpPut("{cpf}")]
        public async Task<ActionResult<UserResponseDto>> UpdateUser(string cpf, [FromBody] UserRequestDto request)
        {
            try
            {
                var result = await _userService.UpdateUserByCpfAsync(cpf, request);

                if (result == null)
                    return StatusCode((int)HttpStatusCode.NotFound, "Nenhum usuário encontrado.");

                return StatusCode((int)HttpStatusCode.OK, "Usuário atualizado com sucesso!");
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, $"Erro interno do servidor: {ex.Message}");
            }
        }

        [HttpDelete("{cpf}")]
        public async Task<ActionResult> DeleteUser(string cpf)
        {
            try
            {
                var deleted = await _userService.DeleteUserByCpfAsync(cpf);

                if (!deleted)
                    return StatusCode((int)HttpStatusCode.NotFound, "Usuário não encontrado.");

                return StatusCode((int)HttpStatusCode.OK, "Usuário deletado com sucesso!");
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, $"Erro interno do servidor: {ex.Message}");
            }
        }
    }
}
