using GerenciamentoBiblioteca.Application.Models;

namespace GerenciamentoBiblioteca.Application.Services
{
    public interface IUsuarioService
    {
        Task<ResultViewModel<List<UsuarioItemViewModel>>> GetAllAsync();
        Task<ResultViewModel<UsuarioViewModel>> GetByIdAsync(int id);
        Task<ResultViewModel<int>> CreateAsync(CreateUsuarioInputModel model);
        Task<ResultViewModel> UpdateAsync(UpdateUsuarioInputModel model);
        Task<ResultViewModel> DeleteAsync(int id);
    }
}
