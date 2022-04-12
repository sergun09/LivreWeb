#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LivreWeb.Models;
using LivreWeb.DataAccess;
using LivreWeb.DataAccess.Repository.Interfaces;

namespace LivreWeb.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategorieRepository _repo;

        public CategoriesController(ICategorieRepository repo)
        {
            this._repo = repo;
        }

        // GET: Categories
        public async Task<IActionResult> Index()
        {
            return View(await this._repo.GetAll());
        }

        // GET: Categories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categorie = await _repo.GetFirstOrDefault(cat => cat.Id == id);
            if (categorie == null)
            {
                return NotFound();
            }

            return View(categorie);
        }

        // GET: Categories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,NombreCommandes")] Categorie categorie)
        {
            if (ModelState.IsValid)
            {
                await _repo.Add(categorie);
                await _repo.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(categorie);
        }

        // GET: Categories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categorie = await _repo.GetFirstOrDefault(cat => cat.Id == id);
            if (categorie == null)
            {
                return NotFound();
            }
            return View(categorie);
        }

        // POST: Categories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,NombreCommandes")] Categorie categorie)
        {
            if (id != categorie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _repo.Update(categorie);
                    await _repo.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }
            return View(categorie);
        }

        // GET: Categories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categorie = await _repo.GetFirstOrDefault(cat => cat.Id == id);
            if (categorie == null)
            {
                return NotFound();
            }

            return View(categorie);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var categorie = await _repo.GetFirstOrDefault(cat => cat.Id == id);
            _repo.DeleteOne(categorie);
            await _repo.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
