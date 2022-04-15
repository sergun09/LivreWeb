#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LivreWeb.Models;
using LivreWeb.DataAccess;
using LivreWeb.DataAccess.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LivreWeb.Controllers
{
    [Area("Admin")]
    public class LivreController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        private IWebHostEnvironment _webHost;

        public LivreController(IUnitOfWork unitOfWork, IWebHostEnvironment webHost)
        {
            this._unitOfWork = unitOfWork;
            this._webHost = webHost;
        }

        // GET: Categories
        public async Task<IActionResult> Index()
        {
            return View(await this._unitOfWork.LivreRepository.GetAll());
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

        // GET: Categories/Edit/5
        public async Task<IActionResult> Upsert(int? id)
        {
            Livre livre = new();
            IEnumerable<SelectListItem> categoriesSelect = this._unitOfWork.CategorieRepository.GetAll().Result.Select(cat => new SelectListItem 
            {
                Text = cat.Nom,
                Value = cat.Id.ToString()
            });

            IEnumerable<SelectListItem> couverturesSelect = this._unitOfWork.CouvertureTypeRepository.GetAll().Result.Select(couv => new SelectListItem
            {
                Text = couv.Nom,
                Value = couv.Id.ToString()
            });

            if (id == null || id == 0)
            {
                ViewBag.categoriesSelect = categoriesSelect;
                ViewData["couverturesSelect"] = couverturesSelect;
                return View(livre);
            }
            else
            {
                livre = await this._unitOfWork.LivreRepository.GetFirstOrDefault(l => l.Id == id);
                return View(livre);
            }
            return View();
        }

        // POST: Categories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert([Bind("Id,Titre,Description,ISBN,Auteur,Prix,CategorieId,CouvertureTypeId")] Livre livre, IFormFile file)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    string wwwPath = this._webHost.WebRootPath;
                    string fileName = Guid.NewGuid().ToString();
                    string path = Path.Combine(wwwPath, @"images\livres");
                    string extension = Path.GetExtension(file.FileName);

                    using (var fileStreams = new FileStream(Path.Combine(path, fileName + extension), FileMode.Create)) 
                    {
                        file.CopyTo(fileStreams);
                    }
                    livre.ImageUrl = @"images\livres\" + fileName + extension;

                    await this._unitOfWork.LivreRepository.Add(livre);
                    await _unitOfWork.SaveChanges();
                    return RedirectToAction(nameof(Index)); 
                }
                catch (DbUpdateConcurrencyException)
                {
                    return NotFound();
                }
            }
            
            return View(livre);
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
