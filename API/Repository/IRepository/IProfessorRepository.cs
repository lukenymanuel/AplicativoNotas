using API.Models;

namespace API.Repository.IRepository
{
    public interface IProfessorRepository
    {
        public Task<Professor> LoginProfessor(string username, string password);
        public Task<IEnumerable<Professor>> ListarProfessores();
       public Task<Professor> ObterProfessorPorId(int id);
    public    Task<Professor> CriarProfessor(Professor professor);
     public   Task<Professor> AtualizarProfessor(Professor professor);
       public Task<Professor> DeletarProfessor(int id);
    }
}
