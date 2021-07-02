using ApiDomain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiRepositorio.Mappings
{
    class TarefaMap : IEntityTypeConfiguration<Tarefa>
    {
        public void Configure(EntityTypeBuilder<Tarefa> builder)
        {
            //nome da tabela
            builder.ToTable("TAREFA");

            //chave primária
            builder.HasKey(p => p.Id);

            //demais campos
            builder.Property(p => p.Id)
                .HasColumnName("IDTAREFA")
                .IsRequired();

            builder.Property(p => p.Nome)
                .HasColumnName("NOME")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(p => p.Descricao)
                .HasColumnName("NOME")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(p => p.DataCadastro)
               .HasColumnName("DATACADASTRO")
               .HasColumnType("date")
               .IsRequired();

            builder.Property(p => p.DataAlteracao)
               .HasColumnName("DATAALTERACAO")
               .HasColumnType("date")
               .IsRequired();
        }
    }
}
