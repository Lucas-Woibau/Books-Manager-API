using GerenciamentoBiblioteca.Core.Entities;

namespace GerenciamentoBiblioteca.Application.Models
{
    public class UserViewModel
    {
        public UserViewModel(int id, string nome, string email)
        {
            Id = id;
            Name = nome;
            Email = email;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }

        public static UserViewModel FromEntity(User entity)
            => new(entity.Id, entity.Name, entity.Email);
    }
}
