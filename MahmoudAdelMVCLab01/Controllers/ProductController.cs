using MahmoudAdelMVCLab01.Models;
using Microsoft.AspNetCore.Mvc;

namespace MahmoudAdelMVCLab01.Controllers;
public class ProductController : Controller {
    public IActionResult Index() {
        return ShowAll();
    }

    public IActionResult ShowAll() {
        var allStudents = ProductBL.GetAll();
        return View(allStudents);
    }

    public IActionResult Details(int id) {
        var product = ProductBL.GetByID(id);
        return View("Details", product);
    }
}
