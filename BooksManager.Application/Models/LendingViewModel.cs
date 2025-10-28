using GerenciamentoBiblioteca.Core.Entities;

namespace GerenciamentoBiblioteca.Application.Models
{
    public class LendingViewModel
    {
        public LendingViewModel(string userName, string bookTitle, DateTime? lendingDate, DateTime? expectedReturnDate, DateTime? returnDate)
        {
            Username = userName;
            BookTitle = bookTitle;
            LendingDate = lendingDate;
            ExpectedReturnDate = expectedReturnDate;
            ReturnDate = returnDate;
        }

        public string Username { get; set; }
        public string BookTitle { get; set; }
        public DateTime? LendingDate { get; private set; }
        public DateTime? ExpectedReturnDate { get; private set; }
        public DateTime? ReturnDate { get; private set; }

        public static LendingViewModel FromEntity(Lending entity)
            => new(entity.User.Name, entity.Book.Title, entity.LendingDate, entity.ExpectedReturnDate, entity.ReturnDate);
    }
}


