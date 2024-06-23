using AutoMapper;
using API.DTO;
using API.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using API.DTO.Disciplina;
using API.Models;
using API.DTO.Curso;

// ...outros usings

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DisciplinasController : ControllerBase
    {
        private readonly IDisciplinasRepository _repository;
        private readonly IMapper _mapper;

        public DisciplinasController(IDisciplinasRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // GET: api/Cursos/5/Disciplinas
        [HttpGet("{cursoId}/Disciplinas")]
        public async Task<ActionResult<IEnumerable<DisciplinaDetalhesDto>>> GetDisciplinasDoCurso(int cursoId)
        {
            var disciplinas = await _repository.DisciplinasCurso(cursoId);
            var disciplinasDto = _mapper.Map<IEnumerable<DisciplinaDetalhesDto>>(disciplinas);
            return Ok(disciplinasDto);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DisciplinaDetalhesDto>>> GetDisciplinas()
        {
           var disciplinas = await _repository.ListarDisciplinas();
            var disciplinasDto = _mapper.Map<IEnumerable<DisciplinaDetalhesDto>>(disciplinas);
            return Ok(disciplinasDto);
        }

        // GET: api/Disciplinas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DisciplinaDetalhesDto>> GetDisciplina(int id)
        {
            var disciplina = await _repository.ReceberDisciplina(id);

            if (disciplina == null)
            {
                return NotFound();
            }

            var disciplinaDto = _mapper.Map<DisciplinaDetalhesDto>(disciplina);
            return Ok(disciplinaDto);
        }

        // POST: api/Disciplinas
        [HttpPost]
        public async Task<ActionResult<DisciplinaDetalhesDto>> PostDisciplina(DisciplinaDetalhesDto disciplinaDto)
        {
            var disciplina = _mapper.Map<Disciplina>(disciplinaDto);

            await _repository.AdicionarDisciplina(disciplina);

            var disciplinaRetorno = _mapper.Map<DisciplinaDetalhesDto>(disciplina);
            return CreatedAtAction(nameof(GetDisciplina), new { id = disciplina.Id }, disciplinaRetorno);
        }

        // ...outras ações do controlador para PUT e DELETE
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTurma(int id, DisciplinaDetalhesDto disciplinaDetalhesDto)
        {
            if (id != disciplinaDetalhesDto.Id)
            {
                return BadRequest();
            }

            var disciplina = await _repository.ReceberDisciplina(id);
            if (disciplina == null)
            {
                return NotFound();
            }

            _mapper.Map(disciplinaDetalhesDto,disciplina ); // Mapeie do DTO de atualização para a entidade existente
            await _repository.AtualizarDisciplina(disciplina);

            return NoContent();
        }
    }
}
