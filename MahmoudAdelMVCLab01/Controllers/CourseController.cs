using MahmoudAdelMVCLab.Models;
using MahmoudAdelMVCLab.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace MahmoudAdelMVCLab.Controllers;
public class CourseController : Controller {
	private readonly ITIContext context = new ITIContext();

	public IActionResult Index() {
		var crsList = context.Course.ToList();
		return View(crsList);
	}

	public IActionResult Details(int id) {
		var enrolledStudents = context.CourseResult
			.Join(context.Trainee,
				courseResult => courseResult.TraineeID,
				trainee => trainee.Id,
				(courseResult, trainee) => new {
					StudentName = trainee.Name,
					Grade = courseResult.Degree,
					TraineeId = trainee.Id,
					crsID = courseResult.CourseID
				})
			.Join(context.Course,
				student => student.crsID,
				course => course.Id,
				(student, course) => new CourseWithTrainees {
					TraineeName = student.StudentName,
					Grade = student.Grade,
					CourseId = student.crsID,
					CourseName = course.Name,
					TraineId = student.TraineeId,
					PassingGrade = course.PassingGrade
				})
			.Where(result => result.CourseId == id).ToList();

		return View(enrolledStudents);
	}

	public IActionResult EditCourse(int id) {
		var crs = context.Course.Find(id);
		return View(crs);
	}

	public IActionResult AddCourse() {
		return View();
	}

	[HttpPost]
	public IActionResult SaveChanges(Course crs) {
		if (!ModelState.IsValid) {
            string viewName = crs.Id == 0 ? nameof(AddCourse) : nameof(EditCourse);
            return View(viewName);
        }

		if (crs.Id == 0) {
			context.Course.Add(crs);
		} else {
			var courseToEdit = context.Course.Find(crs.Id);
			if (courseToEdit == null) return RedirectToAction(nameof(Index));
			
			courseToEdit.Name = crs.Name;
			courseToEdit.PassingGrade = crs.PassingGrade;
		}

		context.SaveChanges();
		return RedirectToAction(nameof(Index));
	}

	public IActionResult Unique(string name, int Id) {
		Course? foundCourse = context.Course.Where(crs => crs.Name == name).FirstOrDefault();

		if (foundCourse == null || foundCourse.Id == Id) {
			return Json(true);
		}
		return Json($"The course name '{name}' is already taken.");
	}
}
