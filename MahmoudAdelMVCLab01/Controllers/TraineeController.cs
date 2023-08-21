using MahmoudAdelMVCLab.Models;
using MahmoudAdelMVCLab.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MahmoudAdelMVCLab.Controllers;
public class TraineeController : Controller {
	private readonly ITIContext context = new ITIContext();
	public IActionResult Index() {
		var studentsWithCourses = context.Trainee
			.Join(
				context.CourseResult,
				trainee => trainee.Id,
				result => result.TraineeID,
				(trainee, result) => new {
					TraineeID = trainee.Id,
					TraineeName = trainee.Name,
					TraineeDepartment = trainee.DeptID,
					TraineeAddress = trainee.Address,
					CourseID = result.CourseID
				}
			)
			.Join(
				context.Course,
				combined => combined.CourseID,
				course => course.Id,
				(combined, course) => new {
					TraineeID = combined.TraineeID,
					TraineeName = combined.TraineeName,
					TraineeDepartment = combined.TraineeDepartment,
					TraineeAddress = combined.TraineeAddress,
					CourseName = course.Name,
					CourseID = course.Id
				}
			)
			.ToList();

		var groupedStudentsWithCourses = studentsWithCourses
			.GroupBy(student => new {
				student.TraineeID,
				student.TraineeName,
				student.TraineeDepartment,
				student.TraineeAddress
			})
			.Select(group => new GroupEachTraineeWithCourses() {
				TraineeID = group.Key.TraineeID,
				TraineeName = group.Key.TraineeName,
				DeptID = group.Key.TraineeDepartment,
				TraineeAddress = group.Key.TraineeAddress,
				CourseNames = group.Select(s => s.CourseName).ToList()
			})
			.ToList();

		return View(groupedStudentsWithCourses);
	}

	public IActionResult ShowResult(int id, string crs) {
		Trainee std = context.Trainee.Where(st => st.Id == id).First();
		Course course = context.Course.Where(cr => cr.Name == crs).First();
		CourseResult result = context.CourseResult.Where(res => res.TraineeID == std.Id && res.CourseID == course.Id).First();

		TraineeCourses vm = new TraineeCourses() {
			TraineeImage = std.Image,
			TraineeName = std.Name,
			CourseName = course.Name,
			Degree = result.Degree,
			PassingGrade = course.PassingGrade,
		};
		return View(vm);
	}
}
