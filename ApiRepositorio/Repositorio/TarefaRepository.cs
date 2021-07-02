using ApiDomain.Entities;
using ApiRepository.Context;
using ApiRepository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApiRepository.Repository
{
    public class TarefaRepository : ITarefaRepository
    {
        private readonly TarefaContexto _tarefaContexto;
        public TarefaRepository(TarefaContexto tarefaContexto)
        {
            _tarefaContexto = tarefaContexto;
        }

        public void Adicinoar(Tarefa tarefa)
        {
            _tarefaContexto.Tarefas.Add(tarefa);
        }

        public void Atualizar(Tarefa tarefa)
        {
            _tarefaContexto.Tarefas.Update(tarefa);
        }

        public void Excluir(Tarefa tarefa)
        {
            _tarefaContexto.Tarefas.Remove(tarefa);
        }

        public Tarefa ObterPorId(Guid id)
        {
            return  _tarefaContexto.Tarefas.FirstOrDefault(x => x.Id == id);
        }

        public Tarefa ObterPornome(string nome)
        {
           return _tarefaContexto.Tarefas.FirstOrDefault(x => x.Nome == nome);
        }

        public List<Tarefa> ObterTodos()
        {
            return _tarefaContexto.Tarefas.ToList();
        }
    }
}
