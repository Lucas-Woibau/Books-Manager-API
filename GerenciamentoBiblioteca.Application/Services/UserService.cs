using GerenciamentoBiblioteca.Application.Models;
using GerenciamentoBiblioteca.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoBiblioteca.Application.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ResultViewModel<List<UserItemViewModel>>> GetAllAsync()
        {
            var usuarios = await _context.Users
                .ToListAsync();

            var model = usuarios.Select(UserItemViewModel.FromEntity).ToList();

            return ResultViewModel<List<UserItemViewModel>>.Success(model);
        }

        public async Task<ResultViewModel<UserViewModel>> GetByIdAsync(int id)
        {
            var usuario = await _context.Users
                .SingleOrDefaultAsync(u => u.Id == id);

            if (usuario == null)
            {
                return ResultViewModel<UserViewModel>.Error("User not found.");
            }

            var model = UserViewModel.FromEntity(usuario);

            return ResultViewModel<UserViewModel>.Success(model);
        }

        public async Task<ResultViewModel<int>> CreateAsync(CreateUserInputModel model)
        {
            var usuario = model.ToEntity();

            await _context.AddAsync(usuario);
            await _context.SaveChangesAsync();

            return ResultViewModel<int>.Success(usuario.Id);
        }

        public async Task<ResultViewModel> UpdateAsync(UpdateUserInputModel model)
        {
            var usuario = await _context.Users.SingleOrDefaultAsync(u => u.Id == model.IdUser);

            if (usuario == null)
            {
                return ResultViewModel.Error("User not found.");
            }

            usuario.Update(model.Name, model.Email);
            await _context.SaveChangesAsync();

            return ResultViewModel.Success();
        }

        public async Task<ResultViewModel> DeleteAsync(int id)
        {
            var usuario = await _context.Users.SingleOrDefaultAsync(u => u.Id == id);

            if (usuario == null)
            {
                return ResultViewModel.Error("User not found.");
            }

            _context.Users.Remove(usuario);
            await _context.SaveChangesAsync();

            return ResultViewModel.Success();
        }               
    }
}
