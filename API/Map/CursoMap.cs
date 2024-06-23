using API.Model;
using API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Map;
    public class CursoMap : BaseMap<Curso>
    {
        public CursoMap() : base("tb_curso")
        {
        }

        public override void Configure(EntityTypeBuilder<Curso> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Nome).HasColumnName("nome").IsRequired();
            // Não é necessário declarar a lista de Disciplinas aqui.
            // O EF Core gerenciará essa associação automaticamente.
        }
    }