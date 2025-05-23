namespace BODYTRANINGAPI.Models;

public partial class ProgressLog
{
    public int LogId { get; set; }

    public string? UserId { get; set; }

    public DateOnly? LogDate { get; set; }

    public decimal? Weight { get; set; }

    public decimal? Height { get; set; }

    public decimal? Bmi { get; set; }

    public int? CaloriesBurned { get; set; }

    public int? CaloriesConsumed { get; set; }

    public virtual User? User { get; set; }
}
