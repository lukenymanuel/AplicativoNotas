using API.Data;
using API.Models;
using API.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace API.Repository.CRepository;
    

        public class TurmaRepository : BaseRepository, ITurmaRepository
        {
            private readonly AppDbContext _context;

            public TurmaRepository(AppDbContext context) : base(context)
            {
                _context = context;
            }

        public async Task<IEnumerable<Turma>> TodasTurmas()
        {
        return await _context.Turmas.ToListAsync();

        }
    public async Task<Turma> BurscarIdTurma(string turma)
    {
        return await _context.Turmas.FirstOrDefaultAsync(t => t.Nome == turma);
    }

    public async Task<Turma> ReceberTurma(int id)
            {
                return await _context.Turmas.FindAsync(id);
            }
    public async Task AdicionarTurma(Turma turma)
    {
        _context.Turmas.Add(turma);
        await _context.SaveChangesAsync();
    }

    public async Task AtualizarTurma(Turma turma)
    {
        _context.Turmas.Update(turma);
        await _context.SaveChangesAsync();
    }

    public async Task DeletarTurmaAsync(int id)
    {
        var turma = await _context.Turmas.FindAsync(id);
        if (turma != null)
        {
            _context.Turmas.Remove(turma);
            await _context.SaveChangesAsync();
        }
    }

}

