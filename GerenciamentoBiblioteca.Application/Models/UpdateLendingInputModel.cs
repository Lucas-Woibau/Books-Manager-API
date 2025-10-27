namespace GerenciamentoBiblioteca.Application.Models
{
    public class UpdateLendingInputModel
    {
        public int IdLending { get; set; }
        public int IdUser { get; set; }
        public int IdBook { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}
