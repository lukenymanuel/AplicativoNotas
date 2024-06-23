using API.DTO.ProfessorTurma;
using API.Models;
using API.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorTurmaController : ControllerBase
    {
        private readonly IProfessorTurmaRepository _professorTurmaRepository;

        public ProfessorTurmaController(IProfessorTurmaRepository professorTurmaRepository)
        {
            _professorTurmaRepository = professorTurmaRepository;
        }

        [HttpPost]
        public async Task<IActionResult> AdicionarProfessorTurma( ProfessorTurmaDto professorTurmaDto)
        {
            try
            {
                var professorTurma = await _professorTurmaRepository.AdicionarProfessorTurma(professorTurmaDto.ProfessorId, professorTurmaDto.TurmaId);
                return Ok(professorTurma);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> RemoverProfessorTurma(ProfessorTurmaDto professorTurmaDto)
        {
            try
            {
                var professorTurma = await _professorTurmaRepository.RemoverProfessorTurma(professorTurmaDto.ProfessorId, professorTurmaDto.TurmaId);
                if (professorTurma != null)
                {
                    return Ok(professorTurma);
                }
                else
                {
                    return NotFound("Associação não encontrada");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("ExisteProfessorTurma")]
        public async Task<IActionResult> ExisteProfessorTurma(int professorId, int turmaId)
        {
            try
            {
                var existe = await _professorTurmaRepository.ExisteProfessorTurma(professorId, turmaId);
                return Ok(existe);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
