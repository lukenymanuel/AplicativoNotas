using API.Models;

namespace API.Repository.IRepository
{
    public interface ITurmaRepository
    {
       public Task<IEnumerable<Turma>> TodasTurmas();
        public Task<Turma> ReceberTurma(int id);
        public Task AdicionarTurma(Turma turma); // Alterado para retornar Task
        public Task AtualizarTurma(Turma turma); // Alterado para retornar Task
        public Task DeletarTurmaAsync(int id); // Alterado para retornar Task
        public Task<Turma> BurscarIdTurma(string turma);  }
}
