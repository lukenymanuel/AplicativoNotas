using API.Models;

namespace API.Repository.IRepository
{
    public interface IDisciplinasRepository
    {
       
        public  Task<IEnumerable<Disciplina>> ListarDisciplinas();
            public Task<Disciplina> ReceberDisciplina(int id);
            public Task<Disciplina> AdicionarDisciplina(Disciplina disciplina);
            public Task<Disciplina> AtualizarDisciplina(Disciplina disciplina);
            public Task<Disciplina> DeletarDisciplina(int id);
        public Task<IEnumerable<Disciplina>> DisciplinasCurso(int cursoId);
            }
}
