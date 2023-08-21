using Newtonsoft.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace MahmoudAdelMVCLab.Models;

public class Course {
    public int Id { get; set; }

    [Required]
    [Display(Name ="Course Name")]
    [MinLength(2, ErrorMessage = "Length must be between 2 and 10!")]
    [MaxLength(10, ErrorMessage = "Length must be between 2 and 10!")]
    public string Name { get; set; } = string.Empty;

    [Display(Name = "Passing Grade")]
    [Required(ErrorMessage = "The Passing Grade field is required.")]
    [Range(35,65, ErrorMessage = "Value must be between 35 and 65!")]
    public float PassingGrade { get; set; }
    public virtual ICollection<CourseResult>? CourseResults { get; set; }
}