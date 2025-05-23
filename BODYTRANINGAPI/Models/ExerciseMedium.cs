namespace BODYTRANINGAPI.Models;

public partial class ExerciseMedia
{
    public int MediaId { get; set; }

    public int? ExerciseId { get; set; }

    public string? MediaType { get; set; }

    public string? Uri { get; set; }

    public string? Caption { get; set; }

    public virtual Exercise? Exercise { get; set; }
}
