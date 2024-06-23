using API.DTO;
using API.DTO.Aluno;
using API.DTO.Curso;
using API.DTO.Disciplina;
using API.DTO.Notas;
using API.DTO.Professor;
using API.DTO.ProfessorTurma;
using API.Models;
using AutoMapper;

namespace API.Model
{
    public class AplicativoMapping : Profile
    {
        public AplicativoMapping()
        {

            CreateMap<Curso, CursoAdicionarDto>().ReverseMap();
            CreateMap<Curso, CursoDetalhesDto>().ReverseMap();
            CreateMap<Curso, CursoDeletarDto>().ReverseMap();

            CreateMap<Turma, TurmaAdicionarDto>().ReverseMap();
            CreateMap<Turma, TurmaAtualizarDto>().ReverseMap();
            CreateMap<Turma, TurmaDto>().ReverseMap();
            CreateMap<ProfessorDetalhesDto, Professor>().ReverseMap();
            CreateMap<ProfessorDto, Professor>();


            CreateMap<Aluno, AlunoDetalhesDto>().ReverseMap();
            CreateMap<Aluno,AlunoRetornarDto>().ReverseMap();

            CreateMap<Nota, NotaDetalhesDto>().ReverseMap();
            CreateMap<Nota, NotaRetornarDto>().ReverseMap();
            CreateMap<Nota, NotaAdicionarDto>().ReverseMap();

            CreateMap<Disciplina, DisciplinaDetalhesDto>().ReverseMap();
            CreateMap<ProfessorTurma, ProfessorTurmaDto>().ReverseMap();

        }
    }
}
