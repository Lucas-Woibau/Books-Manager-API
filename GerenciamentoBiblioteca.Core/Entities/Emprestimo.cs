namespace GerenciamentoBiblioteca.Core.Entities
{
    public class Emprestimo : BaseEntity
    {
        public Emprestimo() { }
        public Emprestimo(int idUsuario, int idLivro)
            : base()
        {
            IdUsuario = idUsuario;
            IdLivro = idLivro;

            DataEmprestimo = DateTime.Now;
        }
      
        public int IdUsuario { get; private set; }
        public Usuario Usuario { get; private set; }
        public int IdLivro { get; private set; }
        public Livro Livro { get; private set; }
        public DateTime? DataEmprestimo { get; private set; }
        public DateTime? DataDevolucao { get; private set; }

        public void Emprestar()
        {
            DataEmprestimo = DateTime.Now;
        }

        public void Devolver()
        {
            DataDevolucao = DateTime.Now;
        }

        public void Update(int idUsuario,int idLivro)
        {
            IdUsuario = idUsuario;
            IdLivro = idLivro;
        }
    }
}
