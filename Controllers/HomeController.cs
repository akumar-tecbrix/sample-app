using Microsoft.AspNetCore.Mvc;
using SampleDockerApp.Models;
using System.Linq;

namespace SampleDockerApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var employees = _context.Employees.ToList();
            return View(employees);
        }
    }
}
