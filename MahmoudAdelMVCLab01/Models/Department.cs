using System.ComponentModel.DataAnnotations;

namespace MahmoudAdelMVCLab.Models;

public class Department {
    public int Id { get; set; }

    [MaxLength(32)]
    public string Name { get; set; } = string.Empty;
    
    public int? ManagerID { get; set; }

    public virtual ICollection<Trainee> TraineeList { get; set; } = new List<Trainee>();
    public virtual ICollection<Instructor> InstructorList { get; set; } = new List<Instructor>();
}
