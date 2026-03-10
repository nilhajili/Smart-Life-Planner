using Microsoft.EntityFrameworkCore;
using SmartLifePlanner.Data;
using SmartLifePlanner.DTOs;
using SmartLifePlanner.Models;
using SmartLifePlanner.Services.Interfaces;
using TaskEntity = SmartLifePlanner.Models.Task;

namespace SmartLifePlanner.Services;

public class StudentService : IStudentService
{
    private readonly AppDbContext _context;

    public StudentService(AppDbContext context)
    {
        _context = context;
    }
    public async Task<TaskResponseDto> AddTaskAsync(TaskRequestDto dto)
    {
        var task = new TaskEntity
        {
            Id = Guid.NewGuid(),
            Name = dto.Name,
            Deadline = dto.Deadline,
            Status = dto.Status,
            UserId = dto.UserId,
            SubjectId = dto.SubjectId
        };

        await _context.Tasks.AddAsync(task);
        await _context.SaveChangesAsync();

        return new TaskResponseDto
        {
            Id = task.Id,
            Name = task.Name,
            Deadline = task.Deadline,
            Status = task.Status,
            SubjectId = task.SubjectId
        };
    }

    public async Task<TaskResponseDto> UpdateTaskAsync(Guid id, TaskRequestDto dto)
    {
        var task = await _context.Tasks.FirstOrDefaultAsync(x => x.Id == id);
        if (task == null) throw new Exception("Task not found");

        task.Name = dto.Name;
        task.Deadline = dto.Deadline;
        task.Status = dto.Status;
        task.SubjectId = dto.SubjectId;

        await _context.SaveChangesAsync();

        return new TaskResponseDto
        {
            Id = task.Id,
            Name = task.Name,
            Deadline = task.Deadline,
            Status = task.Status,
            SubjectId = task.SubjectId
        };
    }

    public async Task<List<TaskResponseDto>> GetTasksAsync(Guid userId)
    {
        return await _context.Tasks
            .Where(x => x.UserId == userId)
            .Select<TaskEntity, TaskResponseDto>(x => new TaskResponseDto
            {
                Id = x.Id,
                Name = x.Name,
                Deadline = x.Deadline,
                Status = x.Status,
                SubjectId = x.SubjectId
            })
            .ToListAsync();
    }
    
    public async Task<StudyGoalResponseDto> AddGoalAsync(StudyGoalRequestDto dto)
    {
        var goal = new SmartLifePlanner.Models.StudyGoal
        {
            Id = Guid.NewGuid(),
            SubjectId = dto.SubjectId,
            TargetHours = dto.TargetHours,
            CurrentHours = 0,
            UserId = dto.UserId,
            StartDate = DateTime.Now,
            EndDate = DateTime.Now.AddDays(30)
        };

        await _context.StudyGoals.AddAsync(goal);
        await _context.SaveChangesAsync();

        return new StudyGoalResponseDto
        {
            Id = goal.Id,
            SubjectId = goal.SubjectId,
            TargetHours = goal.TargetHours,
            CurrentHours = goal.CurrentHours,
            Progress = 0
        };
    }

    public async Task<StudyGoalResponseDto?> UpdateCurrentHoursAsync(Guid goalId, int hours)
    {
        var goal = await _context.StudyGoals.FirstOrDefaultAsync(x => x.Id == goalId);
        if (goal == null) return null;

        goal.CurrentHours += hours;
        await _context.SaveChangesAsync();

        return new StudyGoalResponseDto
        {
            Id = goal.Id,
            SubjectId = goal.SubjectId,
            TargetHours = goal.TargetHours,
            CurrentHours = goal.CurrentHours,
            Progress = (double)goal.CurrentHours / goal.TargetHours * 100
        };
    }

    public async Task<double> GetProgressAsync(Guid goalId)
    {
        var goal = await _context.StudyGoals.FirstOrDefaultAsync(x => x.Id == goalId);
        if (goal == null) throw new Exception("Goal not found");

        return (double)goal.CurrentHours / goal.TargetHours * 100;
    }
    public async Task<Subject> AddSubjectAsync(Guid userId, string name)
    {
        var subject = new Subject
        {
            Id = Guid.NewGuid(),
            Name = name,
            UserId = userId
        };

        await _context.Subjects.AddAsync(subject);
        await _context.SaveChangesAsync();

        return subject;
    }
    
    public async Task<List<Subject>> GetUserSubjectsAsync(Guid userId)
    {
        return await _context.Subjects
            .Where(s => s.UserId == userId)
            .Include(s => s.Tasks)
            .Include(s => s.StudyGoals)
            .ToListAsync();
    }
    
    public async Task<Subject?> GetSubjectByIdAsync(Guid subjectId)
    {
        return await _context.Subjects
            .Include(s => s.Tasks)
            .Include(s => s.StudyGoals)
            .FirstOrDefaultAsync(s => s.Id == subjectId);
    }
}