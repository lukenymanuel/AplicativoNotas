using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUI.Models;

public class Professor 
{   
    public int Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
  //  public List<Turma> Turmas { get; set; }
   // public List<Nota> Notas { get; set; }
    public int DisciplinaId { get; set; }
}
