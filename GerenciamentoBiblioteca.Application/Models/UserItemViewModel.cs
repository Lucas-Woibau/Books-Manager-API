using GerenciamentoBiblioteca.Core.Entities;
using System;
using System.Collections.Generic;
namespace GerenciamentoBiblioteca.Application.Models
{
    public class UserItemViewModel
    {
        public UserItemViewModel(int id, string name, string email)
        {
            Id = id;
            Name = name;
            Email = email;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }

        public static UserItemViewModel FromEntity(User entity)
            => new(entity.Id, entity.Name, entity.Email);
    }
}
