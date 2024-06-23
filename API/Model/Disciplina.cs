using API.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models;

public class Disciplina : Base
{

    public string? Nome { get; set; }
    public int CursoId { get; set; }
    public List<Turma>? Turmas { get; set; }
    // propriedade de navegação
    [NotMapped]
    public Curso? Curso { get; set; }
}