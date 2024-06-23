using API.Data;
using API.Model;
using API.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace API.Repository.CRepository
{
    public class AlunoRepository : BaseRepository , IAlunoRepository
    {
        private readonly AppDbContext _context;

        public AlunoRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<Aluno> LoginAluno(string username, string password)
        {
            var aluno = await _context.Alunos
                                      .FirstOrDefaultAsync(u => u.Username == username && u.Password == password);
            return aluno;
        }


        // Constructor and context setup

        public async Task<IEnumerable<Aluno>> TodosAlunos()
        {
            return await _context.Alunos.ToListAsync();
        }

        public async Task<Aluno> ReceberAluno(int id)
        {
            return await _context.Alunos.FindAsync(id);
        }

        public async Task<Aluno> AdicionarAluno(Aluno aluno)
        {
            _context.Alunos.Add(aluno);
            await _context.SaveChangesAsync();
            return aluno; // Return the added aluno
        }


        public async Task<Aluno> AtualizarAluno(Aluno aluno)
        {
            _context.Alunos.Update(aluno);
            await _context.SaveChangesAsync();
            return aluno; // Return the updated aluno
        }


        public async Task<Aluno> DeletarAluno(int id)
        {
            var aluno = await _context.Alunos.FindAsync(id);
            if (aluno != null)
            {
                _context.Alunos.Remove(aluno);
                await _context.SaveChangesAsync();
                return aluno; // Return the deleted aluno
            }
            else
            {
                throw new Exception("Aluno not found"); // Or handle this case as needed
            }
        }
        public async Task<bool> AlunoPertenceTurma(int alunoId, int turmaId)
        {
            return await _context.Alunos.AnyAsync(a => a.Id == alunoId && a.TurmaId == turmaId);
        }

    }
}
