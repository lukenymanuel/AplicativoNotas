namespace API.DTO.Aluno
{
    public class AlunoDetalhesDto
    {
       
            public int Id { get; set; }
            public string? Nome { get; set; }
            public string? Username { get; set; }
        public string? Password { get; set; }
            public int CursoId { get; set; }
            public int TurmaId { get; set; }
            // You might not want to expose Password in the DTO for security reasons
        
    }
}
