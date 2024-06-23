using MAUI.Models;

namespace MAUI.Model;

    public class Aluno
    {
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public int CursoId { get; set; }

    public int TurmaId { get; set; }
    public List<Disciplina> Disciplinas { get; set; }
   // public List<Nota> Notas { get; set; } // Add this line
}

