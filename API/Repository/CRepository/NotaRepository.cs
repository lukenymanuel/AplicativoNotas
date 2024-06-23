using API.Data;
using API.Models;
using API.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace API.Repository.CRepository
{
    public class NotaRepository : BaseRepository  ,INotaRepository
    {
        private readonly AppDbContext _context;

        public NotaRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Nota> BuscarId(int alunoId)
        {
            return await _context.Notas.FirstOrDefaultAsync(n => n.Id == alunoId);
        }


        public async Task<IEnumerable<Nota>> TodasNotas()
        {
            return await _context.Notas.ToListAsync();
        }

        public async Task<Nota> AdicionarNota(Nota nota)
        {
            _context.Notas.Add(nota);
            await _context.SaveChangesAsync();
            return nota; // Return the added note
        }

        // Method to retrieve a single note by id
        public async Task<Nota> ReceberNota(int id)
        {
            return await _context.Notas.FindAsync(id);
        }
       


        // Method to update an existing note
        public async Task<Nota> AtualizarNota(Nota nota)
        {
            _context.Notas.Update(nota);
            await _context.SaveChangesAsync();
            return nota; // Return the updated note
        }

        // Method to delete a note by id
        public async Task<Nota> DeletarNota(int id)
        {
            var nota = await _context.Notas.FindAsync(id);
            if (nota != null)
            {
                _context.Notas.Remove(nota);
                await _context.SaveChangesAsync();
                return nota; // Return the deleted note
            }
            else
            {
                throw new Exception("Nota not found"); // Or handle this case as needed
            }
        }
        public async Task<IEnumerable<Nota>> NotasDoAluno(int alunoId)
        {
            return await _context.Notas
                .Where(n => n.AlunoId == alunoId)
                .ToListAsync();
        }

        // Existing method to print (retrieve) notes for a given student (alunoId)
    }

}

