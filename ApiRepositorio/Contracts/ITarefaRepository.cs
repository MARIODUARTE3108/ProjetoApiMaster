using ApiDomain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiRepository.Contracts
{
    public interface ITarefaRepository
    {
        void Adicinoar(Tarefa tarefa);
        void Atualizar(Tarefa tarefa);
        void Excluir(Tarefa tarefa);
        List<Tarefa> ObterTodos();
        Tarefa ObterPornome(string nome);
        Tarefa ObterPorId(Guid id);
    }
}
