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
            var lendings = await _context.Lendings
                .Where(e => !e.IsDeleted)
                .Include(e => e.User)
                .Include(e => e.Book)
                .ToListAsync();

            var models = lendings.Select(LendingItemViewModel.FromEntity).ToList();

            return ResultViewModel<List<LendingItemViewModel>>.Success(models);
        }

        public async Task<ResultViewModel<LendingViewModel>> GetByIdAsync(int id)
        {
            var lendings = await _context.Lendings
                .Include(e => e.User)
                .Include(e => e.Book)
                .SingleOrDefaultAsync(e => e.Id == id);

            if (lendings == null)
            {
                return ResultViewModel<LendingViewModel>.Error("Lending not found.");
            }

            var model = LendingViewModel.FromEntity(lendings);

            return ResultViewModel<LendingViewModel>.Success(model);
        }

        public async Task<ResultViewModel<int>> CreateAsync(CreateLendingInputModel model)
        {
            var book = await _context.Books.SingleOrDefaultAsync(l => l.Id == model.IdBook);
            var user = await _context.Users.SingleOrDefaultAsync(l => l.Id == model.IdUser);

            if (book == null)
            {
                return ResultViewModel<int>.Error("Book not found.");
            }
            if (user == null)
            {
                return ResultViewModel<int>.Error("User not found");
            }

            var lending = model.ToEntity();
            lending.Lend();
            book.SetUnavailable();
            await _context.AddAsync(lending);
            await _context.SaveChangesAsync();

            return ResultViewModel<int>.Success(lending.Id);
        }

        public async Task<ResultViewModel> Update(int id, UpdateLendingInputModel model)
        {
            var lending = await _context.Lendings
                .SingleOrDefaultAsync(l => l.Id == id && l.Id == model.IdLending);

            if (lending == null)
            {
                return ResultViewModel<LendingViewModel>.Error("Lending not found.");
            }

            lending.Update(model.IdUser, model.IdBook, model.ExpectedReturnDate);
            await _context.SaveChangesAsync();

            return ResultViewModel.Success();
        }

        public async Task<ResultViewModel> DeleteAsync(int id)
        {
            var lending = await _context.Lendings.SingleOrDefaultAsync(l => l.Id == id);

            if (lending == null)
            {
                return ResultViewModel<LendingViewModel>.Error("Lending not found.");
            }

            lending.SetAsDeleted();
            await _context.SaveChangesAsync();

            return ResultViewModel.Success();
        }

        public async Task<ResultViewModel> ReturnAsync(int id)
        {
            var lending = await _context.Lendings
                .Include(e => e.Book)
                .SingleOrDefaultAsync(e => e.Id == id);

            if (lending == null)
                return ResultViewModel.Error("Lending not found.");

            if (lending.ReturnDate != null)
                return ResultViewModel.Error("This lending has already been returned.");

            lending.Return();
            lending.Book.SetAvailable();

            _context.Update(lending);
            await _context.SaveChangesAsync();

            if (!lending.VerifyPendingDays())
            {
                return ResultViewModel.Success("Book returned successfully on time.");
            }

            int daysLate = lending.CountPendingDays();
            return ResultViewModel.Success($"Book returned with {daysLate} day(s) of delay.");
        }
    }
}
