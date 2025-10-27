namespace GerenciamentoBiblioteca.Core.Entities
{
    public class Lending : BaseEntity
    {
        public Lending()
        {

        }
        public Lending(int idUser, int idBook, DateTime returnDate)
            : base()
        {
            IdUser = idUser;
            IdBook = idBook;
            ReturnDate = returnDate;

            LendingDate = DateTime.Now;
        }
      
        public int IdUser { get; private set; }
        public User User { get; private set; }
        public int IdBook { get; private set; }
        public Book Book { get; private set; }
        public DateTime? LendingDate { get; private set; }
        public DateTime? ReturnDate { get; private set; }

        public void Lend()
        {
            LendingDate = DateTime.Now;
        }

        public void Return()
        {
            ReturnDate = DateTime.Now;
        }

        public void Update(int idUser, int idBook, DateTime returnDate)
        {
            IdUser = idUser;
            IdBook = idBook;
            ReturnDate = returnDate;
        }
    }
}
