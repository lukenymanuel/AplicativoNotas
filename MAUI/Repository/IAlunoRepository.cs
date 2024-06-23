using MAUI.Model;
using MAUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUI.Repository;
 public interface IAlunoRepository
{
       public Task<Aluno> Login(string username,string password);
    public Task<IEnumerable<Nota>> VerNotas(int alunoId);
    public  Task<Professor> LancarNota(Nota nota);
    public Task<Professor> LoginProf(string username, string password);


}
