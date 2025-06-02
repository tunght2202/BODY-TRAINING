namespace BODYTRANINGAPI.ViewModels
{
    public class WorkoutPlanModel
    {
        public int PlanId { get; set; }

        public string? Title { get; set; }

        public string? Description { get; set; }

        public DateOnly? StartDate { get; set; }

        public DateOnly? EndDate { get; set; }
    }
}
