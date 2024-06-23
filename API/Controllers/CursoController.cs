using API.DTO.Curso;
using API.Models;
using API.Repository.IRepository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CursoController : ControllerBase
    {
        private readonly ICursoRepository _cursoRepository;
        private readonly IMapper _mapper;

        public CursoController(ICursoRepository cursoRepository, IMapper mapper)
        {
            _cursoRepository = cursoRepository;
            _mapper = mapper;
        }

        // GET: api/Curso
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CursoDetalhesDto>>> GetCursos()
        {
            var cursos = await _cursoRepository.TodosCursos();
            var cursosDto = _mapper.Map<IEnumerable<CursoDetalhesDto>>(cursos);
            return Ok(cursosDto);
        }

        // GET: api/Curso/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CursoDetalhesDto>> GetCurso(int id)
        {
            var curso = await _cursoRepository.ReceberCurso(id);

            if (curso == null)
            {
                return NotFound();
            }

            var cursoDto = _mapper.Map<CursoDetalhesDto>(curso);
            return Ok(cursoDto);
        }

        // POST: api/Curso
        [HttpPost]
        public async Task<ActionResult<CursoDetalhesDto>> PostCurso(CursoAdicionarDto cursoCreateDto)
        {
            var curso = _mapper.Map<Curso>(cursoCreateDto);
            await _cursoRepository.AdicionarCurso(curso);
            var cursoDetalhesDto = _mapper.Map<CursoDetalhesDto>(curso);
            return CreatedAtAction(nameof(GetCurso), new { id = curso.Id }, cursoDetalhesDto);
        }

        // PUT: api/Curso/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCurso(int id, CursoDetalhesDto cursoUpdateDto)
        {
            if (id != cursoUpdateDto.Id)
            {
                return BadRequest();
            }

            var curso = await _cursoRepository.ReceberCurso(id);
            if (curso == null)
            {
                return NotFound();
            }

            _mapper.Map(cursoUpdateDto, curso);
            await _cursoRepository.AtualizarCurso(curso);

            return NoContent();
        }

        // DELETE: api/Curso/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCurso(int id)
        {
            var curso = await _cursoRepository.ReceberCurso(id);
            if (curso == null)
            {
                return NotFound();
            }

            await _cursoRepository.DeleteCursoAsync(id);

            return NoContent();
        }
    }
}
