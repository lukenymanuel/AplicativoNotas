using API.Model;

namespace API.Repository.IRepository
{
    public interface IAlunoRepository 
    {
        public  Task<Aluno> LoginAluno(string username, string password);
        public  Task<IEnumerable<Aluno>> TodosAlunos();
        public Task<Aluno> ReceberAluno(int id);
        public  Task<Aluno> AdicionarAluno(Aluno aluno);
        public Task<Aluno> AtualizarAluno(Aluno aluno);
        public Task<Aluno> DeletarAluno(int id);
       public Task<bool> AlunoPertenceTurma(int alunoId, int turmaId);
    }
}
