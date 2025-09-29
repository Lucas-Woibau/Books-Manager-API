using GerenciamentoBiblioteca.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciamentoBiblioteca.Application.Models
{
    public class UsuarioItemViewModel
    {
        public UsuarioItemViewModel(int id, string nome, string email)
        {
            Id = id;
            Nome = nome;
            Email = email;
        }

        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }

        public static UsuarioItemViewModel FromEntity(Usuario entity)
            => new(entity.Id, entity.Nome, entity.Email);
    }
}
