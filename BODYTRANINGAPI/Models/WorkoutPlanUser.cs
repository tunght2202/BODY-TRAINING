namespace BODYTRANINGAPI.Models
{
    public class WorkoutPlanUser
    {
        public int PlanId { get; set; }
        public string UserId { get; set; }  // Người thực hiện kế hoạch
        public DateTime DateAssigned { get; set; }  // Ngày người dùng bắt đầu kế hoạch
        public bool IsCompleted { get; set; }  // Kết thúc kế hoạch hoặc chưa

        // Mối quan hệ với WorkoutPlan
        public virtual WorkoutPlan WorkoutPlan { get; set; }
    }

}
