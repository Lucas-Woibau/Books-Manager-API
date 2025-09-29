using GerenciamentoBiblioteca.Application.Models;
using GerenciamentoBiblioteca.Infrasctruct.Persistance;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoBiblioteca.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly ApplicationDbContext _context;

        public UsuarioService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ResultViewModel<List<UsuarioItemViewModel>>> GetAllAsync()
        {
            var usuarios = await _context.Usuarios
                .ToListAsync();

            var model = usuarios.Select(UsuarioItemViewModel.FromEntity).ToList();

            return ResultViewModel<List<UsuarioItemViewModel>>.Success(model);
        }

        public async Task<ResultViewModel<UsuarioViewModel>> GetByIdAsync(int id)
        {
            var usuario = await _context.Usuarios
                .SingleOrDefaultAsync(u => u.Id == id);

            if (usuario == null)
            {
                return ResultViewModel<UsuarioViewModel>.Error("Usuario não encontrado");
            }

            var model = UsuarioViewModel.FromEntity(usuario);

            return ResultViewModel<UsuarioViewModel>.Success(model);
        }

        public async Task<ResultViewModel<int>> CreateAsync(CreateUsuarioInputModel model)
        {
            var usuario = model.ToEntity();

            await _context.AddAsync(usuario);
            await _context.SaveChangesAsync();

            return ResultViewModel<int>.Success(usuario.Id);
        }

        public async Task<ResultViewModel> UpdateAsync(UpdateUsuarioInputModel model)
        {
            var usuario = await _context.Usuarios.SingleOrDefaultAsync(u => u.Id == model.IdUsuario);

            if (usuario == null)
            {
                return ResultViewModel.Error("Usuário não existe!");
            }

            usuario.Update(model.Nome, model.Email);
            await _context.SaveChangesAsync();

            return ResultViewModel.Success();
        }

        public async Task<ResultViewModel> DeleteAsync(int id)
        {
            var usuario = await _context.Usuarios.SingleOrDefaultAsync(u => u.Id == id);

            if (usuario == null)
            {
                return ResultViewModel.Error("Usuario não encontrado");
            }

            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();

            return ResultViewModel.Success();
        }               
    }
}
