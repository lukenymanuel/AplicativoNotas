using API.Models;

namespace API.Repository.IRepository
{
  public interface ICursoRepository :IBaseRepository
        {

        public Task<IEnumerable<Curso>> TodosCursos();

        public Task<Curso> ReceberCurso(int id);

       public  Task<Curso> AdicionarCurso(Curso curso);

       public  Task<Curso> AtualizarCurso(Curso curso);

         public Task<Curso> DeleteCursoAsync(int id);
        }
    
}
