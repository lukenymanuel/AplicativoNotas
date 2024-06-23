namespace API.DTO
{
    public class TurmaDto
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public int CursoId { get; set; } // ID do curso associado à turma
                                         // Outras propriedades relevantes para a turma
    }
}
