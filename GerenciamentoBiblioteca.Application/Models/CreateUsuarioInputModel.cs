using GerenciamentoBiblioteca.Core.Entities;

namespace GerenciamentoBiblioteca.Application.Models
{
    public class CreateUsuarioInputModel
    {
        public string? Nome { get; set; }
        public string? Email { get; set; }

        public Usuario ToEntity()
            => new(Nome, Email);
    }
}
