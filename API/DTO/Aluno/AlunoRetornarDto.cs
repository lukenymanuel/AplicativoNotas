
using API.DTO.Disciplina;
using API.DTO.Notas;
using API.Models;

namespace API.DTO.Aluno
{
    public class AlunoRetornarDto
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public int CursoId { get; set; }
        public int TurmaId { get; set; }
        public List<DisciplinaDetalhesDto>? Disciplinas { get; set; }

        // You might not want to expose Password in the DTO for security reasons

    }
}
