using API.Data;
using API.Models;
using API.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace API.Repository.CRepository
{
    public class ProfessorRepository : BaseRepository, IProfessorRepository
    {
        private readonly AppDbContext _context;

        public ProfessorRepository(AppDbContext context) : base(context) 
        {
            _context = context;
        }
        public async Task<Professor> LoginProfessor(string username, string password)
        {
            var professor = await _context.Professor
             .Where(u => u.Username == username && u.Password == password)
            .FirstOrDefaultAsync();

            if (professor != null)
            {
                // Faça algo com o objeto aluno (por exemplo, retorne o aluno)
                return professor;
            }
            else
            {
                // Lida com o caso em que o aluno é nulo (lança um erro)
                throw new Exception("Credenciais de login inválidas");
            }
        }


        public async Task<IEnumerable<Professor>> ListarProfessores()
        {
            return await _context.Professor.ToListAsync();

        }

        public async Task<Professor> ObterProfessorPorId(int id)
        {
            return await _context.Professor.FindAsync(id);

        }

        public async Task<Professor> CriarProfessor(Professor professor)
        {
            _context.Professor.Add(professor);
            await _context.SaveChangesAsync();
            return professor;
        }

        public async Task<Professor> AtualizarProfessor(Professor professor)
        {
            _context.Entry(professor).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return professor;
        }

        public async Task<Professor> DeletarProfessor(int id)
        {
            var professor = await ObterProfessorPorId(id);
            if (professor != null)
            {
                _context.Professor.Remove(professor);
                await _context.SaveChangesAsync();
            }
            return null;
        }


    }
}
