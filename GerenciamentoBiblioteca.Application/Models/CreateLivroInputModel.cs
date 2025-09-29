using GerenciamentoBiblioteca.Core.Entities;

namespace GerenciamentoBiblioteca.Application.Models
{
    public class CreateLivroInputModel
    {
        public string? Titulo { get; set; }
        public string? Autor { get; set; }
        public string? ISBN { get; set; }
        public int AnoPublicacao { get; set; }

        public Livro ToEntity() 
            => new(Titulo, Autor, ISBN, AnoPublicacao);
    }
}
