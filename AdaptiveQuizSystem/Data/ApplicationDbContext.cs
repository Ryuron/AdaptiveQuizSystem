using AdaptiveQuizSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace AdaptiveQuizSystem.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Quiz> Quizzes { get; set; }
        public DbSet<QuizQuestion> QuizQuestions { get; set; }
        public DbSet<QuizResult> QuizResults { get; set; }  // Fixed: was missing
        public DbSet<QuizResultDetail> QuizResultDetails { get; set; }  // Fixed: was duplicated

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure relationships and constraints based on your database schema

            // Users table
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UserId);
                entity.Property(e => e.Username).HasMaxLength(50).IsRequired();
                entity.HasIndex(e => e.Username).IsUnique();
                entity.Property(e => e.Email).HasMaxLength(100).IsRequired();
                entity.Property(e => e.Role).HasMaxLength(10).IsRequired();
                entity.Property(e => e.CurrentLevel).HasMaxLength(10).IsRequired();
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("GETDATE()");
            });

            // Subjects table
            modelBuilder.Entity<Subject>(entity =>
            {
                entity.HasKey(e => e.SubjectId);
                entity.Property(e => e.SubjectName).HasMaxLength(50).IsRequired();
            });

            // Questions table
            modelBuilder.Entity<Question>(entity =>
            {
                entity.HasKey(e => e.QuestionId);
                entity.Property(e => e.Content).IsRequired();
                entity.Property(e => e.OptionA).HasMaxLength(255).IsRequired();
                entity.Property(e => e.OptionB).HasMaxLength(255).IsRequired();
                entity.Property(e => e.OptionC).HasMaxLength(255).IsRequired();
                entity.Property(e => e.OptionD).HasMaxLength(255).IsRequired();
                entity.Property(e => e.CorrectAnswer).HasMaxLength(1).IsRequired();
                entity.Property(e => e.DifficultyLevel).HasMaxLength(20).IsRequired();
                entity.Property(e => e.TotalAttempts).HasDefaultValue(0);
                entity.Property(e => e.CorrectAttempts).HasDefaultValue(0);
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("GETDATE()");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.Questions)
                    .HasForeignKey(d => d.SubjectId);
            });

            // Quizzes table
            modelBuilder.Entity<Quiz>(entity =>
            {
                entity.HasKey(e => e.QuizId);
                entity.Property(e => e.Title).HasMaxLength(100).IsRequired();
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("GETDATE()");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.Quizzes)
                    .HasForeignKey(d => d.SubjectId);

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.Quizzes)
                    .HasForeignKey(d => d.CreatedBy);
            });

            // QuizQuestions table
            modelBuilder.Entity<QuizQuestion>(entity =>
            {
                entity.HasKey(e => e.QuizQuestionId);

                entity.HasOne(d => d.Quiz)
                    .WithMany(p => p.QuizQuestions)
                    .HasForeignKey(d => d.QuizId);

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.QuizQuestions)
                    .HasForeignKey(d => d.QuestionId);
            });

            // QuizResults table
            modelBuilder.Entity<QuizResult>(entity =>
            {
                entity.HasKey(e => e.QuizResultId);
                entity.Property(e => e.StartTime).HasDefaultValueSql("GETDATE()");
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("GETDATE()");

                entity.HasOne(d => d.Quiz)
                    .WithMany(p => p.QuizResults)
                    .HasForeignKey(d => d.QuizId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.QuizResults)
                    .HasForeignKey(d => d.UserId);
            });

            // QuizResultDetails table
            modelBuilder.Entity<QuizResultDetail>(entity =>
            {
                entity.HasKey(e => e.QuizResultDetailId);
                entity.Property(e => e.UserAnswer).HasMaxLength(1).IsRequired();

                entity.HasOne(d => d.QuizResult)
                    .WithMany(p => p.QuizResultDetails)
                    .HasForeignKey(d => d.QuizResultId);

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.QuizResultDetails)
                    .HasForeignKey(d => d.QuestionId);
            });
        }
    }
}
