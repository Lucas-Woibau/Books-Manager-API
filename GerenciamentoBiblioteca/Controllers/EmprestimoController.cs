using GerenciamentoBiblioteca.Application.Models;
using GerenciamentoBiblioteca.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoBiblioteca.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class EmprestimoController : ControllerBase
    {
        private readonly IEmprestimoService _service;

        public EmprestimoController(IEmprestimoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _service.GetAllAsync();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = _service.GetByIdAsync(id);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateEmprestimoInputModel model)
        {
            var result = await _service.CreateAsync(model);

            if (!result.IsSuccess)
                return BadRequest(result.Message);

            return CreatedAtAction(nameof(GetById), new { id = result.Data }, model);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteAsync(id);

            return Ok();
        }

        [HttpPut("{id}/devolver")]
        public async Task<IActionResult> Put(int id)
        {
            var result = await _service.DevolverAsync(id);

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }
    }
}
