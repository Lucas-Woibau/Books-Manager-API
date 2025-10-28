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
            var users = await _context.Users
                .ToListAsync();

            var model = users.Select(UserItemViewModel.FromEntity).ToList();

            return ResultViewModel<List<UserItemViewModel>>.Success(model);
        }

        public async Task<ResultViewModel<UserViewModel>> GetByIdAsync(int id)
        {
            var user = await _context.Users
                .SingleOrDefaultAsync(u => u.Id == id);

            if (user == null)
            {
                return ResultViewModel<UserViewModel>.Error("User not found.");
            }

            var model = UserViewModel.FromEntity(user);

            return ResultViewModel<UserViewModel>.Success(model);
        }

        public async Task<ResultViewModel<int>> CreateAsync(CreateUserInputModel model)
        {
            var user = model.ToEntity();

            await _context.AddAsync(user);
            await _context.SaveChangesAsync();

            return ResultViewModel<int>.Success(user.Id);
        }

        public async Task<ResultViewModel> UpdateAsync(UpdateUserInputModel model)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.Id == model.IdUser);

            if (user == null)
            {
                return ResultViewModel.Error("User not found.");
            }

            user.Update(model.Name, model.Email);
            await _context.SaveChangesAsync();

            return ResultViewModel.Success();
        }

        public async Task<ResultViewModel> DeleteAsync(int id)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.Id == id);

            if (user == null)
            {
                return ResultViewModel.Error("User not found.");
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return ResultViewModel.Success();
        }               
    }
}
