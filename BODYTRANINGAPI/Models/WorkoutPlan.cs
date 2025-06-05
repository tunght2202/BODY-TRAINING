using System.ComponentModel.DataAnnotations;

namespace BODYTRANINGAPI.Models;

public class WorkoutPlan
{
    public int PlanId { get; set; }
    public string UserId { get; set; }
    public string Title { get; set; } // Tên kế hoạch
    public string Description { get; set; } // Mô tả kế hoạch
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public bool ChooseStatus { get; set; }
    public bool DeleteStatus { get; set; }
    public bool Access { get; set; }
    // Mối quan hệ với WorkoutSchedules
    public ICollection<WorkoutSchedule> WorkoutSchedules { get; set; }

    // Mối quan hệ với người dùng (ai đang thực hiện kế hoạch này)
    public ICollection<WorkoutPlanUser> WorkoutPlanUsers { get; set; } 
    public User User { get; set; } 
}
