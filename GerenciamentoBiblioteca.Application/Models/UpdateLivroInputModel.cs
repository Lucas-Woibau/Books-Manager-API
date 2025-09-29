namespace GerenciamentoBiblioteca.Application.Models
{
    public class UpdateLivroInputModel
    {
        public int IdLivro { get; set; }
        public string? Titulo { get; set; }
        public string? Autor { get; set; }
        public string? ISBN { get; set; }
        public int AnoPublicacao { get; set; }
    }
}
