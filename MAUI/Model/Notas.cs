using MAUI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUI.Models;

public class Nota
{
    public int Id { get; set; }
    public double Valor { get; set; }
    public int AlunoId { get; set; }
     public int ProfessorId { get; set; }
    public int DisciplinaId { get; set; } // Adicionado
    public string Prova { get; set; } // se é p1 , p2 oou pt
    public int Trimestre { get; set; }
    public string Turma { get; set; }
}