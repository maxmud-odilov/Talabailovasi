using Microsoft.AspNetCore.Mvc;
using TalabaIlova.Data;
using TalabaIlova.Models;
using System.Linq;

namespace TalabaIlova.Controllers
{
    public class TalabalarController : Controller
    {
        private readonly TalabaContext _context;

        public TalabalarController(TalabaContext context)
        {
            _context = context;
        }

        // GET: /Talabalar/
        public IActionResult Index()
        {
            var talabalar = _context.Talabalar.ToList();
            return View(talabalar);
        }

        // GET: /Talabalar/Yaratish
        [HttpGet]
        public IActionResult Yaratish()
        {
            return View(); // Formani ko‘rsatadi
        }

        // POST: /Talabalar/Yaratish
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Yaratish(Talaba talaba)
        {
            if (ModelState.IsValid)
            {
                _context.Talabalar.Add(talaba);
                _context.SaveChanges();
                return RedirectToAction("Index"); // Bazaga saqlangandan so‘ng ro‘yxatga qaytadi
            }

            return View(talaba); // Xatolik bo‘lsa formani qayta ko‘rsatadi
        }
    }
}
