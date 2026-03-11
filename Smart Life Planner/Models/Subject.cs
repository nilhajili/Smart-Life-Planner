using System;
using System.Collections.Generic;

namespace SmartLifePlanner.Models
{
    public class Subject
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public Guid? UserId { get; set; }
        public User? User { get; set; } 
        public ICollection<Task> Tasks { get; set; } = new List<Task>();
        public ICollection<StudyGoal> StudyGoals { get; set; } = new List<StudyGoal>();
    }
}