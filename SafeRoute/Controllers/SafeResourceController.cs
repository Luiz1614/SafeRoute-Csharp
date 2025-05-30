using Microsoft.AspNetCore.Mvc;
using SafeRoute.Application.Services.Interfaces;
using SafeRoute.Contracts.Dtos.Requests;
using SafeRoute.Contracts.Dtos.Responses;
using System.Net;

namespace SafeRoute.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SafeResourceController : ControllerBase
    {
        private readonly ISafeResourceService _resourceService;

        public SafeResourceController(ISafeResourceService resourceService)
        {
            _resourceService = resourceService;
        }

        [HttpPost]
        public async Task<ActionResult<SafeResourceResponseDto>> AddResource([FromBody] SafeResourceRequestDto request)
        {
            try
            {
                var result = await _resourceService.AddAsync(request);
                return StatusCode((int)HttpStatusCode.Created, result);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, $"Erro interno do servidor: {ex.Message}");
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SafeResourceResponseDto>>> GetAllResources()
        {
            try
            {
                var resources = await _resourceService.GetAllAsync();
                if (resources == null || !resources.Any())
                    return NotFound("Nenhum recurso encontrado.");
                return Ok(resources);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, $"Erro interno do servidor: {ex.Message}");
            }
        }

        [HttpGet("{resourceCode}")]
        public async Task<ActionResult<SafeResourceResponseDto>> GetResourceByCode(string resourceCode)
        {
            try
            {
                var resource = await _resourceService.GetByResourceCodeAsync(resourceCode);
                if (resource == null)
                    return NotFound("Recurso não encontrado.");
                return Ok(resource);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, $"Erro interno do servidor: {ex.Message}");
            }
        }

        [HttpPut("{resourceCode}")]
        public async Task<ActionResult<SafeResourceResponseDto>> UpdateResource(string resourceCode, [FromBody] SafeResourceRequestDto request)
        {
            try
            {
                var result = await _resourceService.UpdateByResourceCodeAsync(resourceCode, request);
                if (result == null)
                    return NotFound("Recurso não encontrado.");
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, $"Erro interno do servidor: {ex.Message}");
            }
        }

        [HttpDelete("{resourceCode}")]
        public async Task<ActionResult> DeleteResource(string resourceCode)
        {
            try
            {
                var deleted = await _resourceService.DeleteByResourceCodeAsync(resourceCode);
                if (!deleted)
                    return NotFound("Recurso não encontrado.");
                return Ok("Recurso deletado com sucesso!");
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, $"Erro interno do servidor: {ex.Message}");
            }
        }
    }
}
