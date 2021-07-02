using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTarefas.Model
{
    public class TarefasEdicaoModel
    {
        [Required(ErrorMessage = "Por favor, informe o id da tarefa.")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Por favor, informe o nome da tarefa.")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Por favor, informe a descrição da tarefa.")]
        public string Descricao { get; set; } 


    }
}
