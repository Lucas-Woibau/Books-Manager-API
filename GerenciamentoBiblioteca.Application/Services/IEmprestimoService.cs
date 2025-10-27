using GerenciamentoBiblioteca.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciamentoBiblioteca.Application.Services
{
    public interface IEmprestimoService
    {
        Task<ResultViewModel<List<EmprestimoItemViewModel>>> GetAllAsync();
        Task<ResultViewModel<EmprestimoViewModel>> GetByIdAsync(int id);
        Task<ResultViewModel<int>> CreateAsync(CreateEmprestimoInputModel model);
        Task<ResultViewModel> Update(UpdateEmprestimoInputModel model);
        Task<ResultViewModel> DevolverAsync(int id);
        Task<ResultViewModel> DeleteAsync(int id);
    }
}
