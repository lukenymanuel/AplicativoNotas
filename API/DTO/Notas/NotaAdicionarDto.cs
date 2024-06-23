namespace API.DTO.Notas
{
    public class NotaAdicionarDto
    {
        public int Id { get; set; }
        public double Valor { get; set; }
        public int AlunoId { get; set; }
        public int ProfessorId { get; set; }
        public int DisciplinaId { get; set; }
        public string? Turma { get; set; }
        public string? Prova { get; set; }
        public int Trimestre { get; set; }
    }
}
