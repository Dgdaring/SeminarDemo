using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace SeminarASPDemo.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ProfessorController : ControllerBase
    {
        private readonly ILogger<ProfessorController> _logger;
        private readonly IProfessorDataBase _professorDataBase;
        public ProfessorController(ILogger<ProfessorController> logger, IProfessorDataBase professorDatabase)
        {
            _logger = logger;
            _professorDataBase= professorDatabase;
        }

        [HttpGet("{name}")]
        public ActionResult<Professor> Get(string name) 
        {
            var professor = _professorDataBase.GetProfessor(name);
            if (professor == null)
            {
                //This is superior to console.log because it can be reconfigured in one spot and changed 
                // everywhere
                _logger.LogInformation("The professor requested is not found");
                // 404 status code
                return NotFound();
            }
            //200 status code and returns professor details
            return Ok(professor);
        }

       
        [HttpDelete("{name}")]
        public ActionResult Delete(string name)
        {
            _professorDataBase.Delete(name);
            return Ok();
        }
        
        [Authorize(Roles="Admin")]
        [HttpPost("{professorInfo}")]
        public ActionResult<Professor> AddProf([FromBody] Professor professor)
        {
            _professorDataBase.Add(professor);
            var professorAdded = _professorDataBase.GetProfessor(professor.Name);
            return Ok(professorAdded);
        }
    }
}
