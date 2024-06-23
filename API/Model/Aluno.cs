using API.Models;
using System.ComponentModel.DataAnnotations;

namespace API.Model;

public class Aluno : Base
{


    public string? Nome { get; set; }
    public string? Username { get; set; }
    public string? Password { get; set; }
    public int CursoId { get; set; }
 //   public List<Nota>? Notas { get; set; }
    public int TurmaId { get; set; }
    // propriedade de navegação
    public Curso? Curso { get; set; }
    public Turma? Turma { get; set; }

}
