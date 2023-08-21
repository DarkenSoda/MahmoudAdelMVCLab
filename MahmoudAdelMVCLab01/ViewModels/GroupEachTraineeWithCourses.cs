namespace MahmoudAdelMVCLab.ViewModels;

public class GroupEachTraineeWithCourses {
	public int TraineeID { get; set; }
	public string TraineeName { get; set; } = string.Empty;
	public int DeptID { get; set; }
	public string? TraineeAddress { get; set; }
	public List<string> CourseNames { get; set; } = new List<string>();
}
