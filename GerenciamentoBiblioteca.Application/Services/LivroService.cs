
using GerenciamentoBiblioteca.Application.Models;
using GerenciamentoBiblioteca.Core.Entities;
using GerenciamentoBiblioteca.Core.Enums;
using GerenciamentoBiblioteca.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoBiblioteca.Application.Services
{
    public class LivroService : ILivroService
    {
        private readonly ApplicationDbContext _context;

        public LivroService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<ResultViewModel<List<LivroItemViewModel>>> GetAllAsync()
        {
            var livros = await _context.Livros
                .Where(l => !l.IsDeleted)
                .ToListAsync();

            var model = livros.Select(LivroItemViewModel.FromEntity).ToList();

            return ResultViewModel<List<LivroItemViewModel>>.Success(model);
        }

        public async Task<ResultViewModel<int>> CreateAsync(CreateLivroInputModel model)
        {
            var livro = model.ToEntity();

            await _context.AddAsync(livro);
            await _context.SaveChangesAsync();

            return ResultViewModel<int>.Success(livro.Id);
        }

        public async Task<ResultViewModel<LivroViewModel>> GetByIdAsync(int id)
        {
            var livro = await _context.Livros.SingleOrDefaultAsync(l => l.Id == id);

            if (livro == null)
            {
                return ResultViewModel<LivroViewModel>.Error("Livro não encontrado.");
            }

            var model = LivroViewModel.FromEntity(livro);

            return ResultViewModel<LivroViewModel>.Success(model);
        }

        public async Task<ResultViewModel> UpdateAsync(UpdateLivroInputModel model)
        {
            var livro = await _context.Livros.SingleOrDefaultAsync(l => l.Id == model.IdLivro);

            if (livro == null)
            {
                return ResultViewModel.Error("Livro não encontrado.");
            }

            livro.Update(model.Titulo, model.Autor, model.ISBN, model.AnoPublicacao);
            await _context.SaveChangesAsync();

            return ResultViewModel.Success();
        }

        public async Task<ResultViewModel> DeleteAsync(int id)
        {
            var livro = await _context.Livros.SingleOrDefaultAsync(l => l.Id == id);

            if (livro == null)
            {
                return ResultViewModel.Error("Livro não encontrado.");
            }

            livro.SetAsDeleted();
            await _context.SaveChangesAsync();

            return ResultViewModel.Success();
        }
    }
}
