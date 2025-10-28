using GerenciamentoBiblioteca.Core.Entities;

namespace GerenciamentoBiblioteca.Application.Models
{
    public class UserViewModel
    {
        public UserViewModel(string nome, string email)
        {
            Name = nome;
            Email = email;
        }

        public string Name { get; private set; }
        public string Email { get; private set; }

        public static UserViewModel FromEntity(User entity)
            => new(entity.Name, entity.Email);
    }
}
