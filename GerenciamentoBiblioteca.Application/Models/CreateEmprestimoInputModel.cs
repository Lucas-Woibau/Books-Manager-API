using GerenciamentoBiblioteca.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciamentoBiblioteca.Application.Models
{
    public class CreateEmprestimoInputModel
    {
        public int IdUsuario { get; set; }
        public int IdLivro { get; set; }
        public DateTime DataDevolucao { get; set; }

        public Emprestimo ToEntity()
            => new(IdUsuario, IdLivro, DataDevolucao);
    }
}
