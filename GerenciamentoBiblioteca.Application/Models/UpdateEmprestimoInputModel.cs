namespace GerenciamentoBiblioteca.Application.Models
{
    public class UpdateEmprestimoInputModel
    {
        public int IdEmprestimo { get; set; }
        public int IdUser { get; set; }
        public int IdLivro { get; set; }
        public DateTime DataDevolucao { get; set; }
    }
}
