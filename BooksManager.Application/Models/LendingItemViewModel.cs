using GerenciamentoBiblioteca.Core.Entities;

namespace GerenciamentoBiblioteca.Application.Models
{
    public class LendingItemViewModel
    {
        public LendingItemViewModel(string userName, string bookTitle, DateTime? lendingDate, DateTime? expectedReturnDate, DateTime? returnDate)
        {
            UserName = userName;
            BookTitle = bookTitle;
            LendingDate = lendingDate;
            ExpectedReturnDate = expectedReturnDate;
            ReturnDate = returnDate;
        }

        public string UserName { get; private set; }
        public string BookTitle { get; private set; }
        public DateTime? LendingDate { get; private set; }
        public DateTime? ExpectedReturnDate { get; private set; }
        public DateTime? ReturnDate { get; private set; }
        public static LendingItemViewModel FromEntity(Lending entity)
            => new(entity.User.Name, entity.Book.Title, entity?.LendingDate, entity?.ExpectedReturnDate, entity?.ReturnDate);
    }
}
