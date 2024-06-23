using API.Models;

namespace API.Repository.IRepository
{
    public interface INotaRepository
    {

        public  Task<Nota> AdicionarNota(Nota nota);
       public  Task<IEnumerable<Nota>> NotasDoAluno(int alunoId);
        public Task<Nota> ReceberNota(int id);
        public  Task<Nota> AtualizarNota(Nota nota);
        public Task<Nota> DeletarNota(int id);
        public Task<IEnumerable<Nota>> TodasNotas();
    }
}
