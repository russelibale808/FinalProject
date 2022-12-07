using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyProject.Data;
using MyProject.Models;
using System.Diagnostics;

namespace MyProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly RusselContext _context;

        public HomeController(ILogger<HomeController> logger, RusselContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            List<Keyboard>? brands = _context.Keyboards
                .GroupBy(x => x.Brand)
                .Select(g => g.FirstOrDefault())
                .ToList();
            ViewBag.Brands = brands;
            return View();
        }

        public IActionResult Brand(string? brand)
        {
            if (brand == null || brand.Length ==0)
            {
                return NotFound();
            }

            List<Keyboard>? keyboards =  _context.Keyboards
                .Where(x => x.Brand == brand)
                .GroupBy(x => x.Size)
                .Select(g => g.FirstOrDefault())
                .ToList();
            if (keyboards == null)
            {
                return NotFound();
            }

            ViewBag.Brand = brand;
            return View(keyboards);

        }


        public IActionResult BrandAndSize(string? brand, string? size)
        {
            if (brand == null || size == null)
            {
                return NotFound();
            }

            List<Keyboard>? keyboards =  _context.Keyboards
                .Where(x => x.Brand == brand && x.Size == size)
                .ToList();
            if (keyboards == null)
            {
                return NotFound();
            }

            ViewBag.Brand = brand;
            ViewBag.Size = size;
            return View(keyboards);

        }

        public IActionResult Keyboard(int? id) // Keyboard.ID
        {
            var kbd = _context.Keyboards.Find(id);
            if (kbd == null)
            {
                return View();
            }

            return View(kbd);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}