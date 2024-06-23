using API.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models;
public class Nota : Base
{

    public double Valor { get; set; }
    public int AlunoId { get; set; }

    public int ProfessorId { get; set; }
    public int DisciplinaId { get; set; } // Adicionado
    public string? Prova { get; set; } // se é p1 , p2 oou pt
    public int Trimestre { get; set; }
    // propriedade de navegação
    [NotMapped]
    public Aluno? Aluno { get; set; }
    [NotMapped]
    public Professor? Professor { get; set; }
    public Disciplina? Disciplina { get; set; }

}