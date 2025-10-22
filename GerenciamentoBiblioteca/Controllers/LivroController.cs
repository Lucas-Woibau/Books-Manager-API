using GerenciamentoBiblioteca.Application.Models;
using GerenciamentoBiblioteca.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoBiblioteca.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class LivroController : Controller
    {
        private readonly ILivroService _service;
        public LivroController(ILivroService service)
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
            var result = await _service.GetByIdAsync(id);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateLivroInputModel model)
        {
            var result = await _service.CreateAsync(model);

            if (!result.IsSuccess) 
                return BadRequest(result.Message);

            return CreatedAtAction(nameof(GetById), new { id = result.Data }, model);
        }

        [HttpPut]
        public async Task<IActionResult> Put(UpdateLivroInputModel model)
        {
            var result = await _service.UpdateAsync(model);

            if(!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteAsync(id);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return Ok();
        }
    }
}
