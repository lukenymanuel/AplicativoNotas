namespace API.DTO
{
    public class TurmaAdicionarDto
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public int CursoId { get; set; } // ID do curso ao atualizar uma turma
                                         // Outras propriedades necessárias para atualizar uma turma// Outras propriedades necessárias para criar uma turma
    }
}
