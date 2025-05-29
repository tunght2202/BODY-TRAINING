using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BODYTRANINGAPI.Models;

public class  BODYTRAININGDbContext: IdentityDbContext<User>
{
    public BODYTRAININGDbContext(DbContextOptions<BODYTRAININGDbContext> options) : base(options) { }
    public virtual DbSet<Exercise> Exercises { get; set; }

    public virtual DbSet<ExerciseMedia> ExerciseMedia { get; set; }

    public virtual DbSet<MealPlan> MealPlans { get; set; }

    public virtual DbSet<Muscle> Muscles { get; set; }

    public virtual DbSet<ProgressLog> ProgressLogs { get; set; }

    public virtual DbSet<ProgressLogsMedias> ProgressLogsMedias { get; set; }

    public virtual DbSet<WorkoutPlan> WorkoutPlans { get; set; }

    public virtual DbSet<WorkoutSchedule> WorkoutSchedules { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            var tableName = entityType.GetTableName();
            if (tableName.StartsWith("AspNet"))
            {
                entityType.SetTableName(tableName.Substring(6));
            }
        }
        modelBuilder.Entity<Exercise>(entity =>
        {
            entity.HasKey(e => e.ExerciseId);
            entity.Property(e => e.ExerciseId).ValueGeneratedOnAdd();
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.DifficultyLevel).HasMaxLength(50);
            entity.Property(e => e.Title).HasMaxLength(100);
            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.Exercises)
                .HasForeignKey(d => d.CreatedBy);
            entity.HasOne(d => d.Muscle).WithMany(p => p.Exercises)
                .HasForeignKey(d => d.MuscleId);
        });

        modelBuilder.Entity<ExerciseMedia>(entity =>
        {
            entity.HasKey(e => e.MediaId);
            entity.Property(e => e.MediaId).ValueGeneratedOnAdd();
            entity.Property(e => e.Caption).HasMaxLength(200);
            entity.Property(e => e.Uri).HasMaxLength(255);
            entity.HasOne(d => d.Exercise).WithMany(p => p.ExerciseMedia)
                .HasForeignKey(d => d.ExerciseId);
        });

        modelBuilder.Entity<MealPlan>(entity =>
        {
            entity.HasKey(e => e.MealPlanId);
            entity.Property(e => e.MealPlanId).ValueGeneratedOnAdd();
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.MealType).HasMaxLength(50);
            entity.Property(e => e.PhotoUrl).HasMaxLength(255);
            entity.HasOne(d => d.User).WithMany(p => p.MealPlans)
                .HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<Muscle>(entity =>
        {
            entity.HasKey(e => e.MuscleId);
            entity.Property(e => e.MuscleId).ValueGeneratedOnAdd();
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.ImageUrl).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<ProgressLog>(entity =>
        {
            entity.HasKey(e => e.LogId);
            entity.Property(e => e.LogId).ValueGeneratedOnAdd();
            entity.Property(e => e.Bmi)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("BMI");
            entity.Property(e => e.Height).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.Weight).HasColumnType("decimal(5, 2)");
            entity.HasOne(d => d.User).WithMany(p => p.ProgressLogs)
                .HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<ProgressLogsMedias>(entity =>
        {
            entity.HasKey(e => e.PLMId);
            entity.Property(e => e.PLMId).ValueGeneratedOnAdd();
            entity.HasOne(d => d.ProgressLog).WithMany(p => p.ProgressLogsMedias)
                .HasForeignKey(d => d.ProgressLogId);
        });


        modelBuilder.Entity<WorkoutPlan>(entity =>
        {
            entity.HasKey(e => e.PlanId);
            entity.Property(e => e.PlanId).ValueGeneratedOnAdd();
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.Title).HasMaxLength(100);

            entity.HasOne(d => d.User).WithMany(p => p.WorkoutPlans)
                .HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<WorkoutSchedule>(entity =>
        {
            entity.HasKey(e => e.ScheduleId);
            entity.Property(e => e.ScheduleId).ValueGeneratedOnAdd();
            entity.Property(e => e.Status).HasMaxLength(50);

            entity.HasOne(d => d.Plan).WithMany(p => p.WorkoutSchedules)
                .HasForeignKey(d => d.PlanId);
        });

    }

}
