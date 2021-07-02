using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ApiDomain.Entities
{
    public class Tarefa
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }

        public DateTime DataCadastro { get; set; }
        public DateTime DataAlteracao { get; set; }

    }
}
