namespace MahmoudAdelMVCLab.ViewModels;

public class CourseWithTrainees {
	public string CourseName { get; set; } = string.Empty;
	public string TraineeName { get; set; } = string.Empty;
	public float PassingGrade { get; set; }
	public float Grade { get; set; }

	public int CourseId { get; set; }
	public int TraineId { get; set; }
}
