using Microsoft.EntityFrameworkCore;

namespace CoreApp.Models
{
    public class CoreContext : DbContext
    {
        public CoreContext(DbContextOptions<CoreContext> options)
            : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<Level> Levels { get; set; }
        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Assignment>().HasData(
                new Assignment { AssignmentId = 1, AssignmentName = "Assignment 6.1", GitHubUrl = "Test Url"}
            );

            modelBuilder.Entity<Level>().HasData(
                new Level { LevelId = 1, Name = "Level1" },
                new Level { LevelId = 2, Name = "Level2" },
                new Level { LevelId = 3, Name = "Level3" },
                new Level { LevelId = 4, Name = "Level4" },
                new Level { LevelId = 5, Name = "Level5" },
                new Level { LevelId = 6, Name = "Level6" },
                new Level { LevelId = 7, Name = "Level7" },
                new Level { LevelId = 8, Name = "Level8" },
                new Level { LevelId = 9, Name = "Level9" },
                new Level { LevelId = 10, Name = "Level10" }
            );

            modelBuilder.Entity<Student>().HasData(
                    new Student { StudentId = 1, FirstName = "John", LastName = "Doe", Grade = 92 },
                    new Student { StudentId = 2, FirstName = "Sally", LastName = "Johnson", Grade = 79 },
                    new Student { StudentId = 3, FirstName = "Jim", LastName = "Fredrick", Grade = 88 },
                    new Student { StudentId = 4, FirstName = "Carrie", LastName = "Smith", Grade = 69 },
                    new Student { StudentId = 5, FirstName = "Larry", LastName = "Fisher", Grade = 96 },
                    new Student { StudentId = 6, FirstName = "Fred", LastName = "Doe", Grade = 84 },
                    new Student { StudentId = 7, FirstName = "Kelly", LastName = "Johnson", Grade = 76 },
                    new Student { StudentId = 8, FirstName = "Wendy", LastName = "Fredrick", Grade = 91 },
                    new Student { StudentId = 9, FirstName = "Justin", LastName = "Smith", Grade = 72 },
                    new Student { StudentId = 10, FirstName = "Peytyn", LastName = "Fisher", Grade = 94 }
            );
        }
    }
}