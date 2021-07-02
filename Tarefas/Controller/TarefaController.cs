using ApiDomain.Entities;
using ApiRepository.Contracts;
using ApiTarefas.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTarefas.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefaController : ControllerBase
    {
        private readonly ITarefaRepository _tarefaRepository;

        public TarefaController(ITarefaRepository tarefaRepository)
        {
            _tarefaRepository = tarefaRepository;
        }

        [HttpPost]
        public IActionResult Post(TarefaCadastroModel model)
        {
            try
            {
                var tarefa = new Tarefa()
                {
                    Nome = model.Nome,
                    Descricao = model.Descrição
                };

                _tarefaRepository.Adicinoar(tarefa);

                return Ok("Tarefa adicionada com sucesso!");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut]
        public IActionResult Put(TarefasEdicaoModel model)
        {
            try
            {
                var tarefa = _tarefaRepository.ObterPorId(model.Id);

                if (tarefa == null) //verificando se a empresa não existe..
                {
                    //retornando erro HTTP 422
                    return UnprocessableEntity("Tarefa não encontrada.");
                }

                tarefa.Descricao = model.Descricao;
                tarefa.Nome = model.Nome;
                

                _tarefaRepository.Atualizar(tarefa);

                return Ok("Tarefa atualizada com sucesso!");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var tarefa = _tarefaRepository.ObterPorId(id);

                if (tarefa == null)
                {
                    return UnprocessableEntity("Tarefa não encontrada.");
                }

                _tarefaRepository.Excluir(tarefa);

                return Ok("Tarefa removida com sucesso");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }


        [HttpGet]
        public IActionResult ObterTodos()
        {
            try
            {
                var tarefas = _tarefaRepository.ObterTodos();
                var model = new List<TarefaConsultaModel>();

                foreach (var item in tarefas)
                {
                    model.Add(new TarefaConsultaModel
                    {
                        Id = item.Id,
                        Nome = item.Nome,
                        Descricao = item.Descricao,
                        DataCadastro = item.DataCadastro,
                        DataAlteracao = item.DataAlteracao
                    });
                }
                return Ok(model);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("ObterPornome")]
        public IActionResult ObterPornome(string nome)
        {
            try
            {
                var tarefa = _tarefaRepository.ObterPornome(nome);
                var model = new TarefaConsultaModel
                {
                    Id = tarefa.Id,
                    Nome = tarefa.Nome,
                    Descricao = tarefa.Descricao,
                    DataCadastro = tarefa.DataCadastro,
                    DataAlteracao = tarefa.DataAlteracao
                };
                return Ok(model);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
