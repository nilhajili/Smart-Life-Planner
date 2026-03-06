using System.ComponentModel.DataAnnotations;

namespace SmartLifePlanner.Models
{
    public class Task
    {
        public Guid Id { get; set; }  
        public string Name { get; set; } = null!;
        public Guid SubjectId { get; set; }
        public Subject Subject { get; set; } = null!;
        public Guid UserId { get; set; }
        public User User { get; set; } = null!;
        public DateTime? Deadline { get; set; }
        public TaskStatus Status { get; set; } = TaskStatus.Pending;
    }
    public enum TaskStatus
    {
        Pending,
        InProgress,
        Done
    }
}