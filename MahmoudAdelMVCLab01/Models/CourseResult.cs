using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MahmoudAdelMVCLab.Models;

public class CourseResult {
	public int Id { get; set; }

	[Range(0, 100)]
	public float Degree { get; set; }

	[ForeignKey("Course")]
	public int CourseID { get; set; }

	[ForeignKey("Trainee")]
	public int TraineeID { get; set; }

	public virtual Course? Course { get; set; }
	public virtual Trainee? Trainee { get; set; }
}