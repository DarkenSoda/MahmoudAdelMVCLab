using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MahmoudAdelMVCLab.Models;

public class Trainee {
    public int Id { get; set; }

    [MaxLength(64)]
    public string Name { get; set; } = string.Empty;

    [MaxLength(32)]
    public string? Image { get; set; }
    public string? Address { get; set; }
    public float? Grade { get; set; }

    [ForeignKey("Department")]
    public int DeptID { get; set; }

    public virtual Department? Department { get; set; }
    public virtual ICollection<CourseResult>? CourseResults { get; set; }
}