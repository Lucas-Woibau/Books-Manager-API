using GerenciamentoBiblioteca.Core.Enums;

namespace GerenciamentoBiblioteca.Core.Entities
{
    public class Livro : BaseEntity
    {
        public Livro() { }
        public Livro(string? titulo, string? autor, string? isbn, int anoPublicacao)
            : base()
        {
            Titulo = titulo;
            Autor = autor;
            ISBN = isbn;
            AnoPublicacao = anoPublicacao;

            SetarDisponivel();
        }

        public int Id { get; set; }
        public string? Titulo { get; private set; }
        public string? Autor { get; private set; }
        public string? ISBN { get; private set; }
        public int AnoPublicacao { get; private set; }
        public LivroStatus Status { get; private set; }

        public bool SetarDisponivel()
        {
            Status = LivroStatus.Disponivel;
            return true;
        }
        public bool SetarIndisponivel()
        {
            Status = LivroStatus.Indisponivel;
            return true;
        }

        public void Update(string titulo, string autor, string isbn, int anoPublicacao)
        {
            Titulo = titulo;
            Autor = autor;
            ISBN = isbn;
            AnoPublicacao = anoPublicacao;
        }
    }
}
