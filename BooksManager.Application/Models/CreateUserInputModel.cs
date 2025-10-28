using GerenciamentoBiblioteca.Core.Entities;

namespace GerenciamentoBiblioteca.Application.Models
{
    public class CreateUserInputModel
    {
        public string? Name { get; set; }
        public string? Email { get; set; }

        public User ToEntity()
            => new(Name, Email);
    }
}
