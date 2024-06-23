using API.DTO.Disciplina;

namespace API.DTO.Professor
{
  
        public class ProfessorDetalhesDto
        {
        public int Id { get; set; }
        public string? Username { get; set; }
            public string? Password { get; set; }

            public int DisciplinaId { get; set; }
        }

    
}
