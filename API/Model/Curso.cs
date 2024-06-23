using API.Model;

namespace API.Models;

public class Curso : Base
{
    public string? Nome { get; set; }
    public List<Disciplina>? Disciplinas { get; set; }
}
