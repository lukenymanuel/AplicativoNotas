using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUI.Models;
public class Disciplina
{
    public int Id { get; set; }

    public string Nome { get; set; }
    public int CursoId { get; set; }
    //public List<Turma> Turmas { get; set; }
}

