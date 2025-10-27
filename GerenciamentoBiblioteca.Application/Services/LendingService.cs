using GerenciamentoBiblioteca.Application.Models;
using GerenciamentoBiblioteca.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoBiblioteca.Application.Services
{
    public class LendingService : ILendingService
    {
        private readonly ApplicationDbContext _context;

        public LendingService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ResultViewModel<List<LendingItemViewModel>>> GetAllAsync()
        {
            var emprestimos = await _context.Lendings
                .Where(e => !e.IsDeleted)
                .Include(e => e.User)
                .Include(e => e.Book)
                .ToListAsync();

            var models = emprestimos.Select(LendingItemViewModel.FromEntity).ToList();

            return ResultViewModel<List<LendingItemViewModel>>.Success(models);
        }

        public async Task<ResultViewModel<LendingViewModel>> GetByIdAsync(int id)
        {
            var emprestimos = await _context.Lendings.SingleOrDefaultAsync(e => e.Id == id);

            if (emprestimos == null)
            {
                return ResultViewModel<LendingViewModel>.Error("Lending not found.");
            }

            var model = LendingViewModel.FromEntity(emprestimos);

            return ResultViewModel<LendingViewModel>.Success(model);
        }

        public async Task<ResultViewModel<int>> CreateAsync(CreateLendingInputModel model)
        {
            var livro = await _context.Books.SingleOrDefaultAsync(l => l.Id == model.IdBook);
            var usuario = await _context.Users.SingleOrDefaultAsync(l => l.Id == model.IdUser);

            if (livro == null)
            {
                return ResultViewModel<int>.Error("Book not found.");
            }
            if (usuario == null)
            {
                return ResultViewModel<int>.Error("User not found");
            }

            var emprestimo = model.ToEntity();
            emprestimo.Lend();
            livro.SetUnavailable();
            await _context.AddAsync(emprestimo);
            await _context.SaveChangesAsync();

            return ResultViewModel<int>.Success(emprestimo.Id);
        }

        public async Task<ResultViewModel> Update(int id, UpdateLendingInputModel model)
        {
            var emprestimo = await _context.Lendings
                .SingleOrDefaultAsync(l => l.Id == id && l.Id == model.IdLending);

            if (emprestimo == null)
            {
                return ResultViewModel<LendingViewModel>.Error("Lending not found.");
            }

            emprestimo.Update(model.IdUser, model.IdBook, model.ReturnDate);
            await _context.SaveChangesAsync();

            return ResultViewModel.Success();
        }

        public async Task<ResultViewModel> DeleteAsync(int id)
        {
            var emprestimo = await _context.Lendings.SingleOrDefaultAsync(l => l.Id == id);

            if (emprestimo == null)
            {
                return ResultViewModel<LendingViewModel>.Error("Lending not found.");
            }

            emprestimo.SetAsDeleted();
            await _context.SaveChangesAsync();

            return ResultViewModel.Success();
        }

        public async Task<ResultViewModel> ReturnAsync(int id)
        {
            var emprestimo = await _context.Lendings
                .Include(e => e.Book)
                .SingleOrDefaultAsync(e => e.Id == id);

            if (emprestimo == null)
                return ResultViewModel.Error("Lending not found.");

            if (emprestimo.ReturnDate != null)
                return ResultViewModel.Error("This lending is already done.");

            emprestimo.Lend();
            emprestimo.Book.SetAvailable();

            await _context.SaveChangesAsync();

            return ResultViewModel.Success();
        }
    }
}
