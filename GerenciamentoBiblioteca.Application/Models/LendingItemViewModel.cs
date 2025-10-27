using GerenciamentoBiblioteca.Core.Entities;

namespace GerenciamentoBiblioteca.Application.Models
{
    public class LendingItemViewModel
    {
        public LendingItemViewModel(string userName, string bookTitle, DateTime? lendingDate, DateTime? returnDate)
        {
            UserName = userName;
            BookTitle = bookTitle;
            LendingDate = lendingDate;
            ReturnDate = returnDate;
        }

        public string UserName { get; private set; }
        public string BookTitle { get; private set; }
        public DateTime? LendingDate { get; private set; }
        public DateTime? ReturnDate { get; private set; }

        public static LendingItemViewModel FromEntity(Lending entity)
            => new(entity.User.Name, entity.Book.Title, entity?.LendingDate, entity?.ReturnDate);
    }
}
