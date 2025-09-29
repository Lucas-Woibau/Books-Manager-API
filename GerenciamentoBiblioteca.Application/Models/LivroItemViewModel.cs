using GerenciamentoBiblioteca.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciamentoBiblioteca.Application.Models
{
    public class LivroItemViewModel
    {
        public LivroItemViewModel(int id, string titulo, string autor, string iSBN, int anoPublicacao)
        {
            Id = id;
            Titulo = titulo;
            Autor = autor;
            ISBN = iSBN;
            AnoPublicacao = anoPublicacao;
        }

        public int Id { get; private set; }
        public string Titulo { get; private set; }
        public string Autor { get; private set; }
        public string ISBN { get; private set; }
        public int AnoPublicacao { get; private set; }

        public static LivroItemViewModel FromEntity(Livro entity) =>
            new(entity.Id, entity.Titulo, entity.Autor, entity.ISBN, entity.AnoPublicacao);
    }
}
