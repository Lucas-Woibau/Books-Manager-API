using GerenciamentoBiblioteca.Application.Models;

namespace GerenciamentoBiblioteca.Application.Services
{
    public interface IBookService
    {
        Task<ResultViewModel<List<BookItemViewModel>>> GetAllAsync();
        Task<ResultViewModel<BookViewModel>> GetByIdAsync(int id);
        Task<ResultViewModel<int>> CreateAsync(CreateBookInputModel model);
        Task<ResultViewModel> UpdateAsync(UpdateBookInputModel model);
        Task<ResultViewModel> DeleteAsync(int id);        
    }
}
