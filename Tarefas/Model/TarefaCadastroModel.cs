using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTarefas.Model
{
    public class TarefaCadastroModel
    {
        [Required(ErrorMessage ="Por favor, informe o nome da tarefa.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Por favor, informe a descrição da tarefa.")]
        public string Descrição { get; set; }
    }
}
