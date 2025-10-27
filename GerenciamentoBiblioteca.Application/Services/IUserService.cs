using GerenciamentoBiblioteca.Application.Models;

namespace GerenciamentoBiblioteca.Application.Services
{
    public interface IUserService
    {
        Task<ResultViewModel<List<UserItemViewModel>>> GetAllAsync();
        Task<ResultViewModel<UserViewModel>> GetByIdAsync(int id);
        Task<ResultViewModel<int>> CreateAsync(CreateUserInputModel model);
        Task<ResultViewModel> UpdateAsync(UpdateUserInputModel model);
        Task<ResultViewModel> DeleteAsync(int id);
    }
}
