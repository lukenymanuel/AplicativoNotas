using API.Model;
using API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Map
{
    public class TurmaMap : BaseMap<Turma>
    {
        public TurmaMap() : base("tb_turma")
        {
        }

        public override void Configure(EntityTypeBuilder<Turma> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Nome).HasColumnName("nome");
            builder.Property(x => x.CursoId).HasColumnName("curso_id").IsRequired();
           
            builder.HasOne(x => x.Curso).WithMany().HasForeignKey(x => x.CursoId);

            // Não é necessário declarar a lista de Alunos aqui.
            // O EF Core gerenciará essa associação automaticamente.
        }
    }
}
