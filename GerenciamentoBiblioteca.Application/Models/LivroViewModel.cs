using GerenciamentoBiblioteca.Core.Entities;
using GerenciamentoBiblioteca.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciamentoBiblioteca.Application.Models
{
    public class LivroViewModel
    {
        public LivroViewModel(int id, string titulo, string autor, string? iSBN, int anoPublicacao, LivroStatus status)
        {
            Id = id;
            Titulo = titulo;
            Autor = autor;
            ISBN = iSBN;
            AnoPublicacao = anoPublicacao;

            Status = status;
        }

        public int Id { get; private set; }
        public string Titulo { get; private set; }
        public string Autor { get; private set; }
        public string? ISBN { get; private set; }
        public int AnoPublicacao { get; private set; }
        public LivroStatus Status { get; private set; }

        public static LivroViewModel FromEntity(Livro entity) =>
            new(entity.Id, entity.Titulo, entity.Autor, entity.ISBN, entity.AnoPublicacao, entity.Status);
    }
}
