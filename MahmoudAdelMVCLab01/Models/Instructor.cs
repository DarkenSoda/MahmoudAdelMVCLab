using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MahmoudAdelMVCLab.Models;

public class Instructor {
    public int Id { get; set; }

    [MaxLength(64)]
    public string Name { get; set; } = string.Empty;
    [MaxLength(32)]
    public string? Image { get; set; }
    public int Salary { get; set; }
    public string? Address { get; set; }

    [ForeignKey("Department")]
    public int DeptID { get; set; }
    public virtual Department? Department { get; set; }

    [ForeignKey("Course")]
    public int? CourseID { get; set; }
    public virtual Course? Course { get; set; }
}
