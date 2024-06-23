using API.Map;
using API.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


public class AlunoMap : BaseMap<Aluno>
{
    public AlunoMap() : base("tb_aluno")
    {
    }

    public override void Configure(EntityTypeBuilder<Aluno> builder)
    {
        base.Configure(builder);

        builder.Property(x => x.Nome).HasColumnName("nome_aluno").IsRequired();
        builder.Property(x => x.Username).HasColumnName("username").IsRequired();
        builder.Property(x => x.Password).HasColumnName("password").IsRequired();
        builder.Property(x => x.CursoId).HasColumnName("curso_id").IsRequired();
        builder.Property(x => x.TurmaId).HasColumnName("turma_id").IsRequired();

        builder.HasOne(x => x.Curso).WithMany().HasForeignKey(x => x.CursoId);
        builder.HasOne(x => x.Turma).WithMany().HasForeignKey(x => x.TurmaId);

    }
}
