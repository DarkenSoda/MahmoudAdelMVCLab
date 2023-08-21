using Microsoft.EntityFrameworkCore;

namespace MahmoudAdelMVCLab.Models;

public class ITIContext : DbContext{

    public virtual DbSet<Course> Course { get; set; }
    public virtual DbSet<Trainee> Trainee { get; set; }
    public virtual DbSet<Department> Department{ get; set; }
    public virtual DbSet<Instructor> Instructor { get; set; }
    public virtual DbSet<CourseResult> CourseResult { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        optionsBuilder.UseSqlServer("Server=.;Database=ITITraining;Trusted_Connection=True;TrustServerCertificate=True;");
    }
}
