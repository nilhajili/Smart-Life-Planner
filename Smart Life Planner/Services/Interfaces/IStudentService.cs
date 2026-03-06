using SmartLifePlanner.DTOs;
using SmartLifePlanner.Models;

namespace SmartLifePlanner.Services.Interfaces;

public interface IStudentService
{
    Task<TaskResponseDto> AddTaskAsync(TaskRequestDto request);

    Task<TaskResponseDto> UpdateTaskAsync(Guid id, TaskRequestDto request);

    Task<List<TaskResponseDto>> GetTasksAsync(Guid userId);

    Task<StudyGoalResponseDto> AddGoalAsync(StudyGoalRequestDto request);

    Task<StudyGoalResponseDto> UpdateCurrentHoursAsync(Guid goalId, int hours);
    Task<Subject> AddSubjectAsync(Guid userId, string name);
    Task<List<Subject>> GetUserSubjectsAsync(Guid userId);
    Task<Subject?> GetSubjectByIdAsync(Guid subjectId);

    Task<double> GetProgressAsync(Guid goalId);
}