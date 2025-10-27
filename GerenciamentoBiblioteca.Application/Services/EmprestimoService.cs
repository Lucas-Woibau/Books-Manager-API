using GerenciamentoBiblioteca.Application.Models;
using GerenciamentoBiblioteca.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciamentoBiblioteca.Application.Services
{
    public class EmprestimoService : IEmprestimoService
    {
        private readonly ApplicationDbContext _context;

        public EmprestimoService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ResultViewModel<List<EmprestimoItemViewModel>>> GetAllAsync()
        {
            var emprestimos = await _context.Emprestimos
                .Where(e => !e.IsDeleted)
                .Include(e => e.Usuario)
                .Include(e => e.Livro)
                .ToListAsync();

            var models = emprestimos.Select(EmprestimoItemViewModel.FromEntity).ToList();

            return ResultViewModel<List<EmprestimoItemViewModel>>.Success(models);
        }

        public async Task<ResultViewModel<EmprestimoViewModel>> GetByIdAsync(int id)
        {
            var emprestimos = await _context.Emprestimos.SingleOrDefaultAsync(e => e.Id == id);

            if (emprestimos == null)
            {
                return ResultViewModel<EmprestimoViewModel>.Error("Emprestimo não encontrado.");
            }

            var model = EmprestimoViewModel.FromEntity(emprestimos);

            return ResultViewModel<EmprestimoViewModel>.Success(model);
        }

        public async Task<ResultViewModel<int>> CreateAsync(CreateEmprestimoInputModel model)
        {
            var livro = await _context.Livros.SingleOrDefaultAsync(l => l.Id == model.IdLivro);
            var usuario = await _context.Usuarios.SingleOrDefaultAsync(l => l.Id == model.IdUsuario);

            if (livro == null)
            {
                return ResultViewModel<int>.Error("Livro não encontrado!");
            }
            if (usuario == null)
            {
                return ResultViewModel<int>.Error("Usuario não encontrado!");
            }

            var emprestimo = model.ToEntity();
            emprestimo.Emprestar();
            livro.SetarIndisponivel();
            await _context.AddAsync(emprestimo);
            await _context.SaveChangesAsync();

            return ResultViewModel<int>.Success(emprestimo.Id);
        }

        public async Task<ResultViewModel> Update(UpdateEmprestimoInputModel model)
        {
            var emprestimo = await _context.Emprestimos.SingleOrDefaultAsync(l => l.Id == model.IdEmprestimo);

            if (emprestimo == null)
            {
                return ResultViewModel<EmprestimoViewModel>.Error("Emprestimo não encontrado.");
            }

            emprestimo.Update(model.IdUser, model.IdLivro, model.DataDevolucao);
            await _context.SaveChangesAsync();

            return ResultViewModel.Success();
        }

        public async Task<ResultViewModel> DeleteAsync(int id)
        {
            var emprestimo = await _context.Emprestimos.SingleOrDefaultAsync(l => l.Id == id);

            if (emprestimo == null)
            {
                return ResultViewModel<EmprestimoViewModel>.Error("Emprestimo não encontrado.");
            }

            emprestimo.SetAsDeleted();
            await _context.SaveChangesAsync();

            return ResultViewModel.Success();
        }

        public async Task<ResultViewModel> DevolverAsync(int id)
        {
            var emprestimo = await _context.Emprestimos
                .Include(e => e.Livro)
                .SingleOrDefaultAsync(e => e.Id == id);

            if (emprestimo == null)
                return ResultViewModel.Error("Empréstimo não encontrado.");

            if (emprestimo.DataDevolucao != null)
                return ResultViewModel.Error("Este empréstimo já foi devolvido.");

            emprestimo.Devolver();
            emprestimo.Livro.SetarDisponivel();

            await _context.SaveChangesAsync();

            return ResultViewModel.Success();
        }
    }
}
