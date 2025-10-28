using GerenciamentoBiblioteca.Application.Models;

namespace GerenciamentoBiblioteca.Application.Services
{
    public interface ILendingService
    {
        Task<ResultViewModel<List<LendingItemViewModel>>> GetAllAsync();
        Task<ResultViewModel<LendingViewModel>> GetByIdAsync(int id);
        Task<ResultViewModel<int>> CreateAsync(CreateLendingInputModel model);
        Task<ResultViewModel> Update(int id, UpdateLendingInputModel model);
        Task<ResultViewModel> ReturnAsync(int id);
        Task<ResultViewModel> DeleteAsync(int id);
    }
}
