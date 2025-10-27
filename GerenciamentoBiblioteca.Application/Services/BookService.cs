using GerenciamentoBiblioteca.Application.Models;
using GerenciamentoBiblioteca.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoBiblioteca.Application.Services
{
    public class BookService : IBookService
    {
        private readonly ApplicationDbContext _context;

        public BookService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<ResultViewModel<List<BookItemViewModel>>> GetAllAsync()
        {
            var livros = await _context.Books
                .Where(l => !l.IsDeleted)
                .ToListAsync();

            var model = livros.Select(BookItemViewModel.FromEntity).ToList();

            return ResultViewModel<List<BookItemViewModel>>.Success(model);
        }

        public async Task<ResultViewModel<int>> CreateAsync(CreateBookInputModel model)
        {
            var livro = model.ToEntity();

            await _context.AddAsync(livro);
            await _context.SaveChangesAsync();

            return ResultViewModel<int>.Success(livro.Id);
        }

        public async Task<ResultViewModel<BookViewModel>> GetByIdAsync(int id)
        {
            var livro = await _context.Books.SingleOrDefaultAsync(l => l.Id == id);

            if (livro == null)
            {
                return ResultViewModel<BookViewModel>.Error("Book not found.");
            }

            var model = BookViewModel.FromEntity(livro);

            return ResultViewModel<BookViewModel>.Success(model);
        }

        public async Task<ResultViewModel> UpdateAsync(UpdateBookInputModel model)
        {
            var livro = await _context.Books.SingleOrDefaultAsync(l => l.Id == model.IdBook);

            if (livro == null)
            {
                return ResultViewModel.Error("Book not found.");
            }

            livro.Update(model.Title, model.Author, model.ISBN, model.PublicationYear);
            await _context.SaveChangesAsync();

            return ResultViewModel.Success();
        }

        public async Task<ResultViewModel> DeleteAsync(int id)
        {
            var livro = await _context.Books.SingleOrDefaultAsync(l => l.Id == id);

            if (livro == null)
            {
                return ResultViewModel.Error("Book not found.");
            }

            livro.SetAsDeleted();
            await _context.SaveChangesAsync();

            return ResultViewModel.Success();
        }
    }
}
