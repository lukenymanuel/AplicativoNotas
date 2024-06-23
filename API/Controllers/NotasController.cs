using AutoMapper;
using API.DTO;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using API.DTO.Notas;
using API.Repository.IRepository;
using API.DTO.Curso;
using API.Repository.CRepository;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotasController : ControllerBase
    {
        private readonly INotaRepository _repository;
        private readonly ITurmaRepository _turmaRepository;
        private readonly IMapper _mapper;

        public NotasController(INotaRepository repository, IMapper mapper, ITurmaRepository turmaRepository )
        {
            _turmaRepository = turmaRepository;
            _repository = repository;
            _mapper = mapper;
        }
        // GET: api/notas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NotaDetalhesDto>>> GetCursos()
        {
            var notas = await _repository.TodasNotas();
            var notasdto = _mapper.Map<IEnumerable<NotaDetalhesDto>>(notas);
            return Ok(notasdto);
        }
        [HttpGet("Notasdoaluno/{alunoId}")]
        public async Task<ActionResult<IEnumerable<NotaDetalhesDto>>> GetNotasDoAluno(int alunoId)
        {
            var notasDoAluno = await _repository.NotasDoAluno(alunoId);
            var notasDto = notasDoAluno.Select(n => new NotaRetornarDto
            {
                Id = n.Id,
                Valor = n.Valor,
                AlunoId = n.AlunoId,
                ProfessorId = n.ProfessorId,
                DisciplinaId = n.DisciplinaId,
                Prova = n.Prova,
                Trimestre = n.Trimestre
                // Preencha outras propriedades conforme necessário
            }).ToList();

            return Ok(notasDto);
        }


        // GET: api/Notas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NotaDetalhesDto>> GetNota(int id)
        {
            var nota = await _repository.ReceberNota(id);

            if (nota == null)
            {
                return NotFound();
            }

            var notaDto = _mapper.Map<NotaDetalhesDto>(nota);
            return Ok(notaDto);
        }

        // POST: api/Notas
        [HttpPost]
        public async Task<ActionResult<NotaDetalhesDto>> PostNota(NotaAdicionarDto notaDto)
        {
         var turmaid =   _turmaRepository.BurscarIdTurma(notaDto.Turma);
            var nota1 = new NotaDetalhesDto
            {
                Id = notaDto.Id,
                Valor = notaDto.Valor,
                AlunoId = notaDto.AlunoId,
                ProfessorId = notaDto.ProfessorId,
                DisciplinaId = notaDto.DisciplinaId,
                Prova = notaDto.Prova,
                Trimestre = notaDto.Trimestre,
                TurmaId = Convert.ToInt32(turmaid)
                // Preencha outras propriedades conforme necessário
            };
 

             var nota = _mapper.Map<Nota>(nota1);

            await _repository.AdicionarNota(nota);

            // Após adicionar a nota, mapeie a entidade de volta para o DTO para retornar na resposta
            var notaRetorno = _mapper.Map<NotaDetalhesDto>(nota);
            return CreatedAtAction(nameof(GetNota), new { id = nota.Id }, notaRetorno);
        }

        // PUT: api/Notas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNota(int id, NotaDetalhesDto notaDto)
        {
            if (id != notaDto.Id)
            {
                return BadRequest();
            }

            var nota = await _repository.ReceberNota(id);

            if (nota == null)
            {
                return NotFound();
            }

            _mapper.Map(notaDto, nota);

            await _repository.AtualizarNota(nota);

            return NoContent();
        }

        // DELETE: api/Notas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNota(int id)
        {
            var nota = await _repository.ReceberNota(id);

            if (nota == null)
            {
                return NotFound();
            }

            await _repository.DeletarNota(id);

            return NoContent();
        }
    }
}
