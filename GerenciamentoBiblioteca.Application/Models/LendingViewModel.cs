using GerenciamentoBiblioteca.Core.Entities;

namespace GerenciamentoBiblioteca.Application.Models
{
    public class LendingViewModel
    {
        public LendingViewModel(int idUser, User user, int idBook, Book book, DateTime? lendingDate, DateTime? expectedReturnDate, DateTime? returnDate)
        {
            IdUser = idUser;
            User = user;
            IdBook = idBook;
            Book = book;
            LendingDate = lendingDate;
            ExpectedReturnDate = expectedReturnDate;
            ReturnDate = returnDate;
        }

        public int IdUser { get; private set; }
        public User User { get; private set; }
        public int IdBook { get; private set; }
        public Book Book { get; private set; }
        public DateTime? LendingDate { get; private set; }
        public DateTime? ExpectedReturnDate { get; private set; }
        public DateTime? ReturnDate { get; private set; }

        public static LendingViewModel FromEntity(Lending entity) 
            => new(entity.IdUser,entity.User, entity.IdBook, entity.Book, entity.LendingDate, entity.ExpectedReturnDate, entity.ReturnDate);
    }
}


