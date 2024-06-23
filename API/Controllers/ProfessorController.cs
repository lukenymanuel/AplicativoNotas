using Microsoft.AspNetCore.Mvc;
using API.Models;
using API.Repository.IRepository;
using AutoMapper;
using System.Threading.Tasks;
using API.DTO.Professor;
using API.DTO.Notas;
using API.Repository.CRepository;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class ProfessoresController : ControllerBase
{
    private readonly INotaRepository _notaRepository;

    private readonly IProfessorRepository _repository;
    private readonly IAlunoRepository _alunoRepository;
    private readonly IMapper _mapper;

    public ProfessoresController(IProfessorRepository repository, IMapper mapper, INotaRepository notaRepository, IAlunoRepository alunoRepository)
    {
       
        _repository = repository;
        _alunoRepository = alunoRepository;
        _notaRepository = notaRepository;
        _repository = repository;
        _mapper = mapper;
    }

    [HttpGet("{username}/{password}")]
    public async Task<IActionResult> Login(string username, string password)
    {
        var professor = await _repository.LoginProfessor(username, password);
        if (professor == null)
        {
            return BadRequest("Invalid login credentials");
        }
        
            var professorDto =  _mapper.Map<ProfessorDetalhesDto>(professor);
        // Successful login
        return Ok(professorDto);
    }



    [HttpGet]
    public async Task<ActionResult<IEnumerable<Professor>>> GetProfessores()
    {
        return Ok(await _repository.ListarProfessores());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProfessorDetalhesDto>> GetProfessor(int id)
    {
        var professor = await _repository.ObterProfessorPorId(id);

        if (professor == null)
        {
            return NotFound();
        }

        var professorDto = _mapper.Map<ProfessorDetalhesDto>(professor);
        return Ok(professorDto);
    }

    [HttpPost]
    public async Task<ActionResult<ProfessorDetalhesDto>> PostProfessor(ProfessorDetalhesDto professorDto)
    {
        var professor = _mapper.Map<Professor>(professorDto);

        await _repository.CriarProfessor(professor);

        var professorRetorno = _mapper.Map<ProfessorDetalhesDto>(professor);
        return CreatedAtAction(nameof(GetProfessor), new { id = professor.Id }, professorRetorno);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutProfessor(int id, ProfessorDetalhesDto professorDto)
    {
        if (id != professorDto.Id)
        {
            return BadRequest();
        }

        var professorToUpdate = await _repository.ObterProfessorPorId(id);

        if (professorToUpdate == null)
        {
            return NotFound();
        }

        _mapper.Map(professorDto, professorToUpdate);
        await _repository.AtualizarProfessor(professorToUpdate);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProfessor(int id)
    {
        var professorToDelete = await _repository.ObterProfessorPorId(id);

        if (professorToDelete == null)
        {
            return NotFound();
        }

        await _repository.DeletarProfessor(id);

        return NoContent();
    }
}
