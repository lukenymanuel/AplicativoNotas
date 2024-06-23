using API.Data;
using API.Models;
using API.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace API.Repository.CRepository
{
    public class DisciplinaRepository : BaseRepository,IDisciplinasRepository
    {
        private readonly AppDbContext _context;

        public DisciplinaRepository(AppDbContext context) : base(context) 
        {
            _context = context;
        }

        public async Task<IEnumerable<Disciplina>> ListarDisciplinas()
        {
            return await _context.Disciplinas.ToListAsync();
        }

        public async Task<Disciplina> ReceberDisciplina(int id)
        {
            return await _context.Disciplinas.FindAsync(id);
        }

        public async Task<Disciplina> AdicionarDisciplina(Disciplina disciplina)
        {
            _context.Disciplinas.Add(disciplina);
            await _context.SaveChangesAsync();
            return disciplina; // Adicione esta linha para retornar o objeto disciplina
        }
        public async Task<Disciplina> AtualizarDisciplina(Disciplina disciplina)
        {
            _context.Entry(disciplina).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return disciplina; // Adicione esta linha para retornar o objeto disciplina
        }

        public async Task<Disciplina> DeletarDisciplina(int id)
        {
            var disciplina = await _context.Disciplinas.FindAsync(id);
            if (disciplina != null)
            {
                _context.Disciplinas.Remove(disciplina);
                await _context.SaveChangesAsync();
                return disciplina; // Adicione esta linha para retornar o objeto disciplina
            }
            return null; // Adicione esta linha para retornar null se a disciplina não for encontrada
        }
        public async Task<IEnumerable<Disciplina>> DisciplinasCurso(int cursoId)
        {
            return await _context.Disciplinas
                                 .Where(d => d.CursoId == cursoId)
                                 .ToListAsync();
        }

    }
}
