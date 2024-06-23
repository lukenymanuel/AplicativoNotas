using API.Models;
using API.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTO;
using API.DTO.Curso;
using Microsoft.EntityFrameworkCore;
// Adicione o namespace para os DTOs de Turma

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurmaController : ControllerBase
    {
        private readonly ITurmaRepository _repo;
        private readonly IMapper _mapper; // Injete o IMapper

        public TurmaController(ITurmaRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper; // Atribua o IMapper
        }

        // GET: api/Turma
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TurmaDto>>> GetTurmas()
        {
            var turmas = await _repo.TodasTurmas();
            return Ok(_mapper.Map<IEnumerable<TurmaDto>>(turmas)); // Mapeie para o DTO de leitura
        }
        [HttpGet("turma/{nomeTurma}")]
        public async Task<ActionResult<Turma>> GetTurmaIdPorNome(string nomeTurma)
        {
            var turma = await _repo.BurscarIdTurma(nomeTurma); // Fix the method name here
            if (turma == null)
            {
                return NotFound(); // Return 404 if the turma is not found
            }

            return Ok(turma); // Return the turma object
        }


        // GET: api/Turma/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TurmaDto>> GetTurma(int id)
        {
            var turma = await _repo.ReceberTurma(id);

            if (turma == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<TurmaDto>(turma)); // Mapeie para o DTO de leitura
        }

        // POST: api/Turma
        [HttpPost]
        public async Task<ActionResult<TurmaDto>> PostTurma(TurmaAdicionarDto turmaCreateDto)
        {
            var turma = _mapper.Map<Turma>(turmaCreateDto); // Mapeie do DTO de criação para a entidade
            await _repo.AdicionarTurma(turma);

            var turmaReadDto = _mapper.Map<TurmaDto>(turma); // Mapeie da entidade para o DTO de detalhes
            return CreatedAtAction("GetTurma", new { id = turmaReadDto.Id }, turmaReadDto);
        }

        // PUT: api/Turma/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTurma(int id, TurmaAtualizarDto turmaUpdateDto)
        {
            if (id != turmaUpdateDto.Id)
            {
                return BadRequest();
            }

            var turma = await _repo.ReceberTurma(id);
            if (turma == null)
            {
                return NotFound();
            }

            _mapper.Map(turmaUpdateDto, turma); // Mapeie do DTO de atualização para a entidade existente
            await _repo.AtualizarTurma(turma);

            return NoContent();
        }

        // DELETE: api/Turma/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTurma(int id)
        {
            var turma = await _repo.ReceberTurma(id);
            if (turma == null)
            {
                return NotFound();
            }

            await _repo.DeletarTurmaAsync(id);

            return NoContent();
        }
    }
}
