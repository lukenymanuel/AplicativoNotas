using API.Model;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models;

public class Professor : Base
{   
    public string? Username { get; set; }
    public string? Password { get; set; }
    public List<Turma>? Turmas { get; set; }
    public List<Nota>? Notas { get; set; }
    public int DisciplinaId { get; set; }
    // propriedade de navegação
    public Disciplina? Disciplina { get; set; }
}