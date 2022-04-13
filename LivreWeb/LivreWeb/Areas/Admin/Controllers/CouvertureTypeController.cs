#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LivreWeb.Models;
using LivreWeb.DataAccess;
using LivreWeb.DataAccess.Repository.Interfaces;

namespace LivreWeb.Controllers
{
    [Area("Admin")]
    public class CouvertureTypeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CouvertureTypeController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        // GET: Categories
        public async Task<IActionResult> Index()
        {
            return View(await this._unitOfWork.CouvertureTypeRepository.GetAll());
        }

        // GET: Categories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categorie = await this._unitOfWork.CouvertureTypeRepository.GetFirstOrDefault(cat => cat.Id == id);
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
        public async Task<IActionResult> Create([Bind("Id,Nom")] CouvertureType couvertureType)
        {
            if (ModelState.IsValid)
            {
                await this._unitOfWork.CouvertureTypeRepository.Add(couvertureType);
                await this._unitOfWork.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(couvertureType);
        }

        // GET: Categories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var couvertureType = await this._unitOfWork.CouvertureTypeRepository.GetFirstOrDefault(cat => cat.Id == id);
            if (couvertureType == null)
            {
                return NotFound();
            }
            return View(couvertureType);
        }

        // POST: Categories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nom")] CouvertureType couvertureType)
        {
            if (id != couvertureType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    this._unitOfWork.CouvertureTypeRepository.Update(couvertureType);
                    await _unitOfWork.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }
            return View(couvertureType);
        }

        // GET: Categories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var couvertureType = await this._unitOfWork.CouvertureTypeRepository.GetFirstOrDefault(cat => cat.Id == id);
            if (couvertureType == null)
            {
                return NotFound();
            }

            return View(couvertureType);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var couvertureType = await this._unitOfWork.CouvertureTypeRepository.GetFirstOrDefault(cat => cat.Id == id);
            this._unitOfWork.CouvertureTypeRepository.DeleteOne(couvertureType);
            await _unitOfWork.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
