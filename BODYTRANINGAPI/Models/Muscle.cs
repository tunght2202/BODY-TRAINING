namespace BODYTRANINGAPI.Models;

public partial class Muscle
{
    public int MuscleId { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? ImageUrl { get; set; }

    public virtual ICollection<Exercise> Exercises { get; set; }
}
