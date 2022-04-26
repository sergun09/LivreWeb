#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LivreWeb.Models;
using LivreWeb.DataAccess;
using LivreWeb.DataAccess.Repository.Interfaces;

namespace LivreWeb.Controllers
{
    [Area("Admin")]
    public class EntreprisesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public EntreprisesController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        // GET: Entreprises
        public async Task<IActionResult> Index()
        {
            return View(await this._unitOfWork.EntrepriseRepository.GetAll());
        }

        // GET: Entrpise/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Adresse,Ville,Departement,CodePostal,Numero")] Entreprise entreprise)
        {
            if (ModelState.IsValid)
            {
                await this._unitOfWork.EntrepriseRepository.Add(entreprise);
                await this._unitOfWork.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(entreprise);
        }

        // GET: Categories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enteprise = await this._unitOfWork.EntrepriseRepository.GetFirstOrDefault(e => e.Id == id);
            if (enteprise == null)
            {
                return NotFound();
            }
            return View(enteprise);
        }

        // POST: Categories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nom,NombreCommandes")] Entreprise entreprise)
        {
            if (id != entreprise.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    this._unitOfWork.EntrepriseRepository.Update(entreprise);
                    await _unitOfWork.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }
            return View(entreprise);
        }

        // GET: Categories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entreprise = await this._unitOfWork.EntrepriseRepository.GetFirstOrDefault(cat => cat.Id == id);
            if (entreprise == null)
            {
                return NotFound();
            }

            return View(entreprise);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var entreprise = await this._unitOfWork.EntrepriseRepository.GetFirstOrDefault(cat => cat.Id == id);
            this._unitOfWork.EntrepriseRepository.DeleteOne(entreprise);
            await _unitOfWork.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
