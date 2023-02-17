using DeployEntityFramework.Models;
using Microsoft.EntityFrameworkCore;

namespace DeployEntityFramework.Data
{
    public class ProjectContext : DbContext
    {
        public ProjectContext(DbContextOptions<ProjectContext> options) : base(options)
        {            
        }

        public DbSet<StudentModel> Students { get; set; }
    }

    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ProjectContext(
                serviceProvider.GetRequiredService<DbContextOptions<ProjectContext>>()))
            {
                if (context == null || context.Students == null)
                {
                    throw new ArgumentNullException("Null ProjectContext");
                }

                if (!context.Students.Any())
                {
                    var students = new List<StudentModel>();

                    students.Add(new StudentModel() { Id = 1, Name = "Anthony Evans", Reference = "S00001" });
                    students.Add(new StudentModel() { Id = 2, Name = "Ryan Pincher", Reference = "S00002" });
                    students.Add(new StudentModel() { Id = 3, Name = "Lee Spilsbury", Reference = "S00003" });

                    context.Students.AddRange(students);
                }

                context.SaveChanges();
            }
            
        }
    }

}
