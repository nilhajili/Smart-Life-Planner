namespace SmartLifePlanner.Models;

public class StudyGoal
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public User User { get; set; } = null!;
    public int TargetHours { get; set; }  
    public int CurrentHours { get; set; } 
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}