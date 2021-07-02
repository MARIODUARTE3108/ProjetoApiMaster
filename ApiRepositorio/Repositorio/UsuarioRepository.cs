
using ApiDomain.Entities;
using ApiRepository.Context;
using ApiRepository.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiRepository.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly TarefaContexto _tarefaContexto;

        public UsuarioRepository(TarefaContexto tarefaContexto)
        {
            _tarefaContexto = tarefaContexto;
        }

        public void Inserir(Usuario usuario)
        {
            _tarefaContexto.Usuarios.Add(usuario);
        }

      
        public Usuario ObterPorEmail(string email)
        {
          return _tarefaContexto.Usuarios.Find(email);
        }

    }
}
