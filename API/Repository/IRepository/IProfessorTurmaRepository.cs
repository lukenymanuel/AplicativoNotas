using API.Model;

namespace API.Repository.IRepository
{
    public interface IProfessorTurmaRepository
    {
        public Task<ProfessorTurma> AdicionarProfessorTurma(int professorId, int turmaId);
        public Task<ProfessorTurma> RemoverProfessorTurma(int professorId, int turmaId);
        public Task<bool> ExisteProfessorTurma(int professorId, int turmaId);
    }
}
