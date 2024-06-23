using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Data;
using API.Model;
using System.ComponentModel.DataAnnotations;
using API.Repository.IRepository;
using API.DTO.Aluno;
using AutoMapper;
using API.Repository.CRepository;
using API.DTO.Disciplina;
using API.DTO.Notas;
namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunosController : ControllerBase
    {
    
       private readonly IDisciplinasRepository _disciplinasRepository;
        private readonly IAlunoRepository _repository;
        private readonly INotaRepository _notaRepository; 
        private readonly IMapper _mapper;
        public AlunosController(IAlunoRepository repository, IMapper mapper,INotaRepository notaRepository,IDisciplinasRepository disciplinasRepository) 
        {   
            _notaRepository = notaRepository;
            _disciplinasRepository = disciplinasRepository;
            _repository = repository;
            _mapper = mapper;   
        }

        [HttpGet("{username}/{password}")]
        public async Task<IActionResult> Login(string username, string password)
        {
            var aluno = await _repository.LoginAluno(username, password);
            if (aluno == null)
            {
                return BadRequest("Invalid login credentials");
            }
            var disciplinas = await _disciplinasRepository.DisciplinasCurso(aluno.CursoId);

            var disciplinasDto = disciplinas.Select(d => new DisciplinaDetalhesDto
            {
                Id = d.Id,
                Nome = d.Nome,
                CursoId = d.CursoId
            }).ToList();


            var alunoDto = new AlunoRetornarDto
            {
                Id = aluno.Id,
                Nome = aluno.Nome,
                Username = aluno.Username,
                Password = aluno.Password,
                CursoId = aluno.CursoId,
                 TurmaId = aluno.TurmaId,
                Disciplinas = disciplinasDto,

            };


            return Ok(alunoDto);
        }

        // GET: api/Alunos


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Aluno>>> GetAlunos()
        {
            return Ok(await _repository.TodosAlunos());
        }

        // GET: api/Alunos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AlunoDetalhesDto>> GetAluno(int id)
        {
            var aluno = await _repository.ReceberAluno(id);

            if (aluno == null)
            {
                return NotFound();
            }

            var alunoDto = _mapper.Map<AlunoDetalhesDto>(aluno);
            return Ok(alunoDto);
        }

        // POST: api/Alunos
        [HttpPost]
        public async Task<ActionResult<AlunoDetalhesDto>> PostAluno(AlunoDetalhesDto alunoDto)
        {
            var aluno = _mapper.Map<Aluno>(alunoDto);

            await _repository.AdicionarAluno(aluno);

            var alunoRetorno = _mapper.Map<AlunoDetalhesDto>(aluno);
            return CreatedAtAction(nameof(GetAluno), new { id = aluno.Id }, alunoRetorno);
        }

        // PUT: api/Alunos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAluno(int id, AlunoDetalhesDto alunoDto)
        {
            if (id != alunoDto.Id)
            {
                return BadRequest();
            }

            var alunoToUpdate = await _repository.ReceberAluno(id);

            if (alunoToUpdate == null)
            {
                return NotFound();
            }

            _mapper.Map(alunoDto, alunoToUpdate);
            await _repository.AtualizarAluno(alunoToUpdate);

            return NoContent();
        }

        // DELETE: api/Alunos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAluno(int id)
        {
            var aluno = await _repository.ReceberAluno(id);

            if (aluno == null)
            {
                return NotFound();
            }

            await _repository.DeletarAluno(id);

            // Se você quiser retornar algum dado após a exclusão, mapeie e retorne aqui.
            // Exemplo:
            // var alunoDto = _mapper.Map<AlunoDetalhesDto>(aluno);
            // return Ok(alunoDto);

            return NoContent();
        }


    }
}
