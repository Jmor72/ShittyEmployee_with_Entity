using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using MvcMovie.Models;

namespace MvcMovie.Controllers
{
    public class ShittyEmployeesController : Controller
    {
        private ApplicationDbContext _context;

        public ShittyEmployeesController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: ShittyEmployees
        public IActionResult Index()
        {
            return View(_context.ShittyEmployee.ToList());
        }

        // GET: ShittyEmployees/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            ShittyEmployee shittyEmployee = _context.ShittyEmployee.Single(m => m.ID == id);
            if (shittyEmployee == null)
            {
                return HttpNotFound();
            }

            return View(shittyEmployee);
        }

        // GET: ShittyEmployees/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ShittyEmployees/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ShittyEmployee shittyEmployee)
        {
            if (ModelState.IsValid)
            {
                _context.ShittyEmployee.Add(shittyEmployee);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(shittyEmployee);
        }

        // GET: ShittyEmployees/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            ShittyEmployee shittyEmployee = _context.ShittyEmployee.Single(m => m.ID == id);
            if (shittyEmployee == null)
            {
                return HttpNotFound();
            }
            return View(shittyEmployee);
        }

        // POST: ShittyEmployees/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ShittyEmployee shittyEmployee)
        {
            if (ModelState.IsValid)
            {
                _context.Update(shittyEmployee);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(shittyEmployee);
        }

        // GET: ShittyEmployees/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            ShittyEmployee shittyEmployee = _context.ShittyEmployee.Single(m => m.ID == id);
            if (shittyEmployee == null)
            {
                return HttpNotFound();
            }

            return View(shittyEmployee);
        }

        // POST: ShittyEmployees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            ShittyEmployee shittyEmployee = _context.ShittyEmployee.Single(m => m.ID == id);
            _context.ShittyEmployee.Remove(shittyEmployee);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
