using System.ComponentModel.DataAnnotations;

namespace BODYTRANINGAPI.Models
{
    public class WorkoutProgress
    {
        [Key]
        public int ProgressId { get; set; }
        public int WorkoutScheduleId { get; set; }  // Liên kết với WorkoutSchedule
        public bool IsCompleted { get; set; }  // Đã hoàn thành hay chưa
        public DateTime? CompletedAt { get; set; }  // Thời gian hoàn thành
        public string Notes { get; set; }  // Ghi chú thêm về buổi tập (ví dụ: cường độ, cảm giác...)

        // Mối quan hệ với WorkoutSchedule
        public virtual WorkoutSchedule WorkoutSchedule { get; set; }
    }

}
