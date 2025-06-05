using System.ComponentModel.DataAnnotations;

namespace BODYTRANINGAPI.Models;

public partial class ExerciseMedia
{
    [Key]
    public int MediaId { get; set; }

    public int ExerciselId { get; set; }

    public string? Uri { get; set; }

    public string? Caption { get; set; }
    public Exercise Exercise { get; set; }

}
