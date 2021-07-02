using ApiDomain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiRepository.Context
{
    public class TarefaContexto :DbContext
    {
        public TarefaContexto(DbContextOptions<TarefaContexto> options) : base(options) { }
        public TarefaContexto()
        {
        }

        public DbSet<Tarefa> Tarefas { get; set; }
        public DbSet<Usuario> Usuarios{ get; set; }
       
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder();
            builder.AddJsonFile("appsettings.json", optional: false);
            var configuration = builder.Build();
        }
    }
}
