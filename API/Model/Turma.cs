using API.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models;

public class Turma : Base
{
    public string? Nome { get; set; }
    public int CursoId { get; set; }
    public List<Professor>? Professores { get; set; }
    public Curso? Curso { get; set; }
    [NotMapped]
    public Disciplina? Disciplina { get; set; } = null;
    [NotMapped]
    public Professor? Professor { get; set; } = null;
}