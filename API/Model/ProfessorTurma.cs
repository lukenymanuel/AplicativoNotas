using API.Models;

namespace API.Model
{
    public class ProfessorTurma : Base
    {
        
        
            public int ProfessorId { get; set; }
            public Professor? Professor { get; set; }

            public int TurmaId { get; set; }
            public Turma? Turma { get; set; }
        

    }
}
