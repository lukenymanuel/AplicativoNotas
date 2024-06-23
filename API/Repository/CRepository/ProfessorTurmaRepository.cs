/*using API.Data;
using API.Model;
using API.Models;
using API.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace API.Repository.CRepository
{
    public class ProfessorTurmaRepository : BaseRepository, IProfessorTurmaRepository
    {
        private readonly AppDbContext _context;
        private readonly IProfessorRepository _professorRepository;
        private readonly ITurmaRepository _turmaRepository;

        public ProfessorTurmaRepository(AppDbContext context, IProfessorRepository professorRepository, ITurmaRepository turmaRepository) : base(context)
        {
            _context = context;
            _professorRepository = professorRepository;
            _turmaRepository = turmaRepository;
        }

        public async Task<bool> ExisteProfessorTurma(int professorId, int turmaId)
        {
            return await _context.ProfessorTurma.AnyAsync(pt => pt.ProfessorId == professorId && pt.TurmaId == turmaId);
        }

        public async Task<ProfessorTurma> AdicionarProfessorTurma(int professorId, int turmaId)
        {
            // Verificar se o professor e a turma existem
            var professor = await _professorRepository.ObterProfessorPorId(professorId);
            var turma = await _turmaRepository.ReceberTurma(turmaId);

            if (professor == null || turma == null)
                throw new Exception("Professor ou Turma não encontrados");

            // Verificar se a associação já existe
            if (await ExisteProfessorTurma(professorId, turmaId))
                throw new Exception("Associação já existe");

            // Criar e adicionar a nova associação
            var professorTurma = new ProfessorTurma { ProfessorId = professorId, TurmaId = turmaId };
            await _context.ProfessorTurma.AddAsync(professorTurma);
            await _context.SaveChangesAsync();
            return professorTurma;
        }

        public async Task<ProfessorTurma> RemoverProfessorTurma(int professorId, int turmaId)
        {
            var professorTurma = await _context.ProfessorTurma.FirstOrDefaultAsync(pt => pt.ProfessorId == professorId && pt.TurmaId == turmaId);

            if (professorTurma == null)
                throw new Exception("Associação não encontrada");

            _context.ProfessorTurma.Remove(professorTurma);
            await _context.SaveChangesAsync();
            return professorTurma; // Retorna o objeto removido ou null se não for encontrado
        }
    }
}
*/