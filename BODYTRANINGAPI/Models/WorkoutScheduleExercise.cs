namespace BODYTRANINGAPI.Models
{
    public class WorkoutScheduleExercise
    {
        public int WorkoutScheduleId { get; set; }
        public WorkoutSchedule WorkoutSchedule { get; set; }
        public int ExerciseId { get; set; }
        public Exercise Exercise { get; set; }
        public int Sets { get; set; }  // Số set tập
        public int Reps { get; set; }  // Số lần trong mỗi set
        public double? DistanceKm { get; set; }  // Quãng đường (cho bài tập chạy)
        public int? DurationMinutes { get; set; }  // Thời gian (cho bài tập chạy hoặc bài tập cần thời gian)
    }

}
