using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BODYTRANINGAPI.Models;

public class BODYTRAININGDbContext : IdentityDbContext<User>
{
    public BODYTRAININGDbContext(DbContextOptions<BODYTRAININGDbContext> options) : base(options) { }

    public virtual DbSet<Exercise> Exercises { get; set; }
    public virtual DbSet<ExerciseMedia> ExerciseMedia { get; set; }
    public virtual DbSet<ExerciseMuscle> ExerciseMuscles { get; set; }
    public virtual DbSet<MealPlan> MealPlans { get; set; }
    public virtual DbSet<DailyMealPlan> DailyMealPlans { get; set; }
    public virtual DbSet<Muscle> Muscles { get; set; }
    public virtual DbSet<ProgressLog> ProgressLogs { get; set; }
    public virtual DbSet<ProgressLogsMedias> ProgressLogsMedias { get; set; }
    public virtual DbSet<WorkoutPlan> WorkoutPlans { get; set; }
    public virtual DbSet<WorkoutPlanUser> WorkoutPlanUsers { get; set; }
    public virtual DbSet<WorkoutProgress> WorkoutProgresses { get; set; }
    public virtual DbSet<WorkoutSchedule> WorkoutSchedules { get; set; }
    public virtual DbSet<WorkoutScheduleExercise> WorkoutScheduleExercises { get; set; }
    public virtual DbSet<MealItem> MealItems { get; set; }
    public virtual DbSet<MealItemImage> MealItemImages { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Sửa lại bảng `AspNet` thành đúng tên bảng
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            var tableName = entityType.GetTableName();
            if (tableName.StartsWith("AspNet"))
            {
                entityType.SetTableName(tableName.Substring(6));
            }
        }

        // Cập nhật mối quan hệ giữa Exercise và ExerciseMuscles
        modelBuilder.Entity<Exercise>()
            .HasMany(e => e.ExerciseMuscles)
            .WithOne(d => d.Exercise)
            .HasForeignKey(d => d.ExerciseId);

        // Mối quan hệ nhiều-nhiều giữa Exercise và Muscle
        modelBuilder.Entity<ExerciseMuscle>()
            .HasKey(e => new { e.ExerciseId, e.MuscleId });

        modelBuilder.Entity<ExerciseMuscle>()
            .HasOne(e => e.Exercise)
            .WithMany(d => d.ExerciseMuscles)
            .HasForeignKey(e => e.ExerciseId);

        modelBuilder.Entity<ExerciseMuscle>()
            .HasOne(e => e.Muscle)
            .WithMany(m => m.ExerciseMuscles)
            .HasForeignKey(e => e.MuscleId);

        // Cập nhật ExerciseMedia để sửa lỗi "ExerciselId" -> thành "ExerciseId"
        modelBuilder.Entity<Exercise>()
            .HasMany(d => d.ExerciseMedias)
            .WithOne(m => m.Exercise)
            .HasForeignKey(m => m.ExerciselId); // Sửa ExerciselId thành ExerciseId
      
        modelBuilder.Entity<WorkoutPlan>()
            .HasKey(pl => pl.PlanId); 

        // Mối quan hệ giữa WorkoutPlan và WorkoutSchedule
        modelBuilder.Entity<WorkoutPlan>()
            .HasMany(wp => wp.WorkoutSchedules)
            .WithOne(ws => ws.WorkoutPlan)
            .HasForeignKey(ws => ws.PlanId)
            .OnDelete(DeleteBehavior.NoAction); // Sử dụng NoAction để tránh Cascade

        // Mối quan hệ giữa WorkoutSchedule và WorkoutScheduleExercise
        modelBuilder.Entity<WorkoutScheduleExercise>()
            .HasKey(wse => new { wse.WorkoutScheduleId, wse.ExerciseId });

        modelBuilder.Entity<WorkoutScheduleExercise>()
            .HasOne(wse => wse.WorkoutSchedule)
            .WithMany(ws => ws.WorkoutScheduleExercises)
            .HasForeignKey(wse => wse.WorkoutScheduleId)
            .OnDelete(DeleteBehavior.NoAction); // Cài đặt NoAction

        modelBuilder.Entity<WorkoutScheduleExercise>()
            .HasOne(wse => wse.Exercise)
            .WithMany(e => e.WorkoutScheduleExercises)
            .HasForeignKey(wse => wse.ExerciseId)
            .OnDelete(DeleteBehavior.NoAction); // Cài đặt NoAction


        modelBuilder.Entity<WorkoutProgress>()
            .HasKey(wp => wp.ProgressId); // Khóa chính cho WorkoutProgress

        // Mối quan hệ giữa WorkoutSchedule và WorkoutProgress
        modelBuilder.Entity<WorkoutProgress>()
            .HasOne(wp => wp.WorkoutSchedule)
            .WithOne(ws => ws.WorkoutProgress)
            .HasForeignKey<WorkoutProgress>(wp => wp.WorkoutScheduleId)
            .OnDelete(DeleteBehavior.Cascade); // Cascade khi xóa

        // Mối quan hệ giữa WorkoutPlan và WorkoutPlanUser
        modelBuilder.Entity<WorkoutPlanUser>()
            .HasKey(wpu => new { wpu.PlanId, wpu.UserId });

        modelBuilder.Entity<WorkoutPlanUser>()
            .HasOne(wpu => wpu.WorkoutPlan)
            .WithMany(wp => wp.WorkoutPlanUsers)
            .HasForeignKey(wpu => wpu.PlanId);
        // Khai báo khóa chính cho MealPlan
        modelBuilder.Entity<MealPlan>()
            .HasKey(pl => pl.Id);

        // Mối quan hệ giữa MealPlan và DailyMealPlan
        modelBuilder.Entity<MealPlan>()
            .HasMany(p => p.DailyMeals)
            .WithOne(d => d.MealPlan)
            .HasForeignKey(d => d.MealPlanId);

        // Mối quan hệ giữa DailyMealPlan và MealItem
        modelBuilder.Entity<DailyMealPlan>()
            .HasMany(d => d.Meals)
            .WithOne(m => m.DailyMealPlan)
            .HasForeignKey(m => m.DailyMealPlanId);

        // Mối quan hệ giữa MealItem và MealItemImage
        modelBuilder.Entity<MealItem>()
            .HasMany(m => m.MealItemImages)
            .WithOne(i => i.MealItem)
            .HasForeignKey(i => i.MealItemId);
        modelBuilder.Entity<ProgressLog>(ProgressLog => 
        {
            ProgressLog.HasKey(pl => pl.LogId);
            ProgressLog.HasOne(pl => pl.User)
                .WithMany(u => u.ProgressLogs)
                .HasForeignKey(pl => pl.UserId)
                .OnDelete(DeleteBehavior.Cascade); // Xóa cascade khi người dùng bị xóa
        });
        modelBuilder.Entity<ProgressLogsMedias>(plm => 
        {
            plm.HasKey(plm => plm.PLMId);
            plm.HasOne(plm => plm.ProgressLog)
                .WithMany(pl => pl.ProgressLogsMedias)
                .HasForeignKey(plm => plm.ProgressLogId)
                .OnDelete(DeleteBehavior.Cascade); // Xóa cascade khi ProgressLog bị xóa
        });
    }
}
