using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartLifePlanner.DTOs;
using SmartLifePlanner.Services.Interfaces;

namespace SmartLifePlanner.Controllers
{
  
    [ApiController]
    [Route("api/[controller]")]
    public class StudyGoalController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudyGoalController(IStudentService studentService)
        {
            _studentService = studentService;
        }
        
        [HttpPost]
        public async Task<ActionResult<StudyGoalResponseDto>> AddGoal([FromBody] StudyGoalRequestDto dto)
        {
            var result = await _studentService.AddGoalAsync(dto);
            return Ok(result);
        }
        
        [HttpPost("{goalId}/add-hours")]
        public async Task<IActionResult> AddHours(Guid goalId, int hours)
        {
            var updatedGoal = await _studentService.UpdateCurrentHoursAsync(goalId, hours);
            if (updatedGoal == null) 
                return NotFound("Study goal not found");

            return Ok(updatedGoal);
        }
        [HttpGet("{goalId}/progress")]
        public async Task<ActionResult<double>> GetProgress(Guid goalId)
        {
            var progress = await _studentService.GetProgressAsync(goalId);
            return Ok(progress);
        }
    }
}