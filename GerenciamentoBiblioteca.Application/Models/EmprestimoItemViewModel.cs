using GerenciamentoBiblioteca.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciamentoBiblioteca.Application.Models
{
    public class EmprestimoItemViewModel
    {
        public EmprestimoItemViewModel(string nomeUsuario, string tituloLivro, DateTime? dataEmprestimo, DateTime? dataDevolucao)
        {
            NomeUsuario = nomeUsuario;
            TituloLivro = tituloLivro;
            DataEmprestimo = dataEmprestimo;
            DataDevolucao = dataDevolucao;
        }

        public string NomeUsuario { get; private set; }
        public string TituloLivro { get; private set; }
        public DateTime? DataEmprestimo { get; private set; }
        public DateTime? DataDevolucao { get; private set; }

        public static EmprestimoItemViewModel FromEntity(Emprestimo entity)
            => new(entity.Usuario.Nome, entity.Livro.Titulo, entity?.DataEmprestimo, entity?.DataDevolucao);
    }
}
