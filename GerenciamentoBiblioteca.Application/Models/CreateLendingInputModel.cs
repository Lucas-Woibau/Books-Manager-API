using GerenciamentoBiblioteca.Core.Entities;

namespace GerenciamentoBiblioteca.Application.Models
{
    public class CreateLendingInputModel
    {
        public int IdUser { get; set; }
        public int IdBook { get; set; }
        public DateTime ExpectedReturnDate { get; set; }

        public Lending ToEntity()
            => new(IdUser, IdBook, ExpectedReturnDate);
    }
}
