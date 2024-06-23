using API.Model;
using API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Map
{
    public class DisciplinaMap : BaseMap<Disciplina>
    {
        public DisciplinaMap() : base("tb_disciplina")
        {
        }

        public override void Configure(EntityTypeBuilder<Disciplina> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Nome).HasColumnName("nome").IsRequired();
            builder.Property(x => x.CursoId).HasColumnName("curso_id").IsRequired();

            builder.HasOne(x => x.Curso).WithMany().HasForeignKey(x => x.CursoId);
            // Não é necessário declarar a lista de Turmas aqui.
            // O EF Core gerenciará essa associação automaticamente.
        }
    }
}