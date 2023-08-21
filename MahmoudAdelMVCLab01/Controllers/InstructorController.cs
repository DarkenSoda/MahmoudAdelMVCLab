using MahmoudAdelMVCLab.Models;
using Microsoft.AspNetCore.Mvc;

namespace MahmoudAdelMVCLab.Controllers;
public class InstructorController : Controller {
	private readonly ITIContext context = new ITIContext();
	public IActionResult Index() {
		return ShowAll();
	}

	private IActionResult ShowAll() {
		var allInstructors = context.Instructor.ToList();
		return View(allInstructors);
	}

	public IActionResult Details(int id) {
		var instructor = context.Instructor.Find(id);
		if (instructor == null)
			return RedirectToAction("Index");

		ViewBag.Departments = context.Department.ToList();
		ViewBag.Courses = context.Course.ToList();
		return View(instructor);
	}

	public IActionResult AddNew() {
		ViewBag.Departments = context.Department.ToList();
		ViewBag.Courses = context.Course.ToList();
		return View();
	}

	[HttpPost]
	public IActionResult SaveChanges(Instructor inst, bool isNew) {
		if (inst.Name == null || inst.Salary < 3000) return RedirectToAction("Details", inst);
		if (context.Department.Find(inst.DeptID) == null || (inst.CourseID != null && context.Course.Find(inst.CourseID) == null))
			return RedirectToAction("Details", inst);

		if (isNew) {
			context.Instructor.Add(inst);
		} else {
			var instructorToChange = context.Instructor.Find(inst.Id);
			if (instructorToChange == null) return View("Index");

			instructorToChange.Name = inst.Name;
			instructorToChange.Salary = inst.Salary;
			instructorToChange.Address = inst.Address;
			instructorToChange.DeptID = inst.DeptID;
			instructorToChange.CourseID = inst.CourseID;
		}
		context.SaveChanges();

		return RedirectToAction("Index");
	}
}
