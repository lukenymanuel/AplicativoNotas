using API.Data;
using API.Models;
using API.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace API.Repository.CRepository
{
    public class CursoRepository : BaseRepository, ICursoRepository
    {
        private readonly AppDbContext _context;

        public CursoRepository(AppDbContext context) :base(context) 
        {
            _context = context;
        }

        public async Task<IEnumerable<Curso>> TodosCursos()
        {
            return await _context.Cursos.ToListAsync();
        }

        public async Task<Curso> ReceberCurso(int id)
        {
            return await _context.Cursos.FindAsync(id);
        }

        public async Task<Curso> AdicionarCurso(Curso curso)
        {
            _context.Cursos.Add(curso);
            await _context.SaveChangesAsync();
            return curso;
        }

        public async Task<Curso> AtualizarCurso(Curso curso)
        {
            _context.Cursos.Update(curso);
            await _context.SaveChangesAsync();
            return curso;
        }

        public async Task<Curso> DeleteCursoAsync(int id)
        {
            var curso = await _context.Cursos.FindAsync(id);
            if (curso != null)
            {
                _context.Cursos.Remove(curso);
                await _context.SaveChangesAsync();
                return curso; // Retorna o objeto curso se for encontrado e removido
            }
            else
            {
                return null; // Retorna null se o curso não for encontrado
            }
        }

    }

}
