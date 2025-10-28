namespace GerenciamentoBiblioteca.Core.Entities
{
    public class Lending : BaseEntity
    {
        public Lending()
        {

        }
        public Lending(int idUser, int idBook, DateTime expectedReturnDate)
            : base()
        {
            IdUser = idUser;
            IdBook = idBook;
            ExpectedReturnDate = expectedReturnDate;

            LendingDate = DateTime.Now;
        }
      
        public int IdUser { get; private set; }
        public User User { get; private set; }
        public int IdBook { get; private set; }
        public Book Book { get; private set; }
        public DateTime LendingDate { get; private set; }
        public DateTime ExpectedReturnDate { get; private set; }
        public DateTime? ReturnDate { get; private set; }

        public void Lend()
        {
            LendingDate = DateTime.Now;
        }

        public void Return()
        {
            ReturnDate = DateTime.Now;
        }

        public bool VerifyPendingDays()
        {
            return DateTime.Now >= ExpectedReturnDate;
        }

        public int CountPendingDays()
        {
            if (ReturnDate == null || ReturnDate <= ExpectedReturnDate)

                return 0;
            TimeSpan daysPassed = ReturnDate.Value - ExpectedReturnDate;
            return (int)Math.Floor(daysPassed.TotalDays);

        }

        public void Update(int idUser, int idBook, DateTime expectedReturnDate)
        {
            IdUser = idUser;
            IdBook = idBook;
            ExpectedReturnDate = expectedReturnDate;
        }
    }
}
