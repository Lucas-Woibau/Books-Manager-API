using GerenciamentoBiblioteca.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciamentoBiblioteca.Application.Models
{
    public class EmprestimoViewModel
    {
        public EmprestimoViewModel(int idUsuario, Usuario usuario, int idLivro, Livro livro, DateTime? dataEmprestimo, DateTime? dataDevolucao)
        {
            IdUsuario = idUsuario;
            Usuario = usuario;
            IdLivro = idLivro;
            Livro = livro;
            DataEmprestimo = dataEmprestimo;
            DataDevolucao = dataDevolucao;
        }

        public int IdUsuario { get; private set; }
        public Usuario Usuario { get; private set; }
        public int IdLivro { get; private set; }
        public Livro Livro { get; private set; }
        public DateTime? DataDevolucao { get; private set; }
        public DateTime? DataEmprestimo { get; private set; }

        public static EmprestimoViewModel FromEntity(Emprestimo entity) 
            => new(entity.IdUsuario,entity.Usuario, entity.IdLivro, entity.Livro, entity.DataEmprestimo, entity.DataDevolucao);
    }
}
