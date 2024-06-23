namespace API.DTO.Notas
{
    public class NotaDetalhesDto
    {
        public int Id { get; set; }
        public double Valor { get; set; }
        public int AlunoId { get; set; }
        public int ProfessorId { get; set; }
        public int DisciplinaId { get; set; }
        public int TurmaId { get; set; }
        public string? Prova { get; set; }
        public int Trimestre { get; set; }

        // Campos adicionais de Aluno, Professor e Disciplina podem ser incluídos como DTOs separados se necessário
    }
}
