using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartLifePlanner.Models;
using SmartLifePlanner.Services.Interfaces;

namespace SmartLifePlanner.Controllers
{
   
    [ApiController]
    [Route("api/[controller]")]
    public class SubjectController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public SubjectController(IStudentService studentService)
        {
            _studentService = studentService;
        }
        [HttpPost]
        public async Task<ActionResult<Subject>> AddSubject([FromQuery] Guid userId, [FromQuery] string name)
        {
            var subject = await _studentService.AddSubjectAsync(userId, name);
            return Ok(subject);
        }
        
        [HttpGet("user/{userId}")]
        public async Task<ActionResult<List<Subject>>> GetUserSubjects(Guid userId)
        {
            var subjects = await _studentService.GetUserSubjectsAsync(userId);
            return Ok(subjects);
        }
        [HttpGet("{subjectId}")]
        public async Task<ActionResult<Subject>> GetSubjectById(Guid subjectId)
        {
            var subject = await _studentService.GetSubjectByIdAsync(subjectId);
            if (subject == null) return NotFound();
            return Ok(subject);
        }
    }
}