using GerenciamentoBiblioteca.Application.Models;

namespace GerenciamentoBiblioteca.Application.Services
{
    public interface ILivroService
    {
        Task<ResultViewModel<List<LivroItemViewModel>>> GetAllAsync();
        Task<ResultViewModel<LivroViewModel>> GetByIdAsync(int id);
        Task<ResultViewModel<int>> CreateAsync(CreateLivroInputModel model);
        Task<ResultViewModel> UpdateAsync(UpdateLivroInputModel model);
        Task<ResultViewModel> DeleteAsync(int id);        
    }
}
