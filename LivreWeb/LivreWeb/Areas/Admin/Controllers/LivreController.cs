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
            var livres = await this._unitOfWork.LivreRepository.GetAll(includes : "Categorie,CouvertureType");
            return View(livres);
        }

        // GET: Categories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Panier panier = new()
            {
                Livre = await this._unitOfWork.LivreRepository.GetFirstOrDefault(l => l.Id == id,
                includes: "Categorie,CouvertureType"),
                Quantite = "1"
            };

            if (panier == null)
            {
                return NotFound();
            }

            return View(panier);
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

            ViewBag.categoriesSelect = categoriesSelect;
            ViewData["couverturesSelect"] = couverturesSelect;

            if (id == null || id == 0)
            {
                return View(livre);
            }
            else
            {
                livre = await this._unitOfWork.LivreRepository.GetFirstOrDefault(l => l.Id == id);
                return View(livre);
            }
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
                    // Récupération de la www
                    string wwwPath = this._webHost.WebRootPath;
                    // Création d'un ID unique pour chaque image
                    string fileName = Guid.NewGuid().ToString();
                    // Fusion de la route
                    string path = Path.Combine(wwwPath, @"images\livres");
                    // Récupération de l'extension de l'image : .png / .jpg
                    string extension = Path.GetExtension(file.FileName);

                    if(livre.ImageUrl != null) 
                    {
                        string oldImagePath = Path.Combine(wwwPath, "images/livres");
                        if (System.IO.File.Exists(oldImagePath))
                            System.IO.File.Delete(oldImagePath);
                    }

                    using (var fileStreams = new FileStream(Path.Combine(path, fileName + extension), FileMode.Create)) 
                    {
                        file.CopyTo(fileStreams);
                    }
                    livre.ImageUrl = @"images\livres\" + fileName + extension;

                    if(livre.Id == 0) 
                    {
                        await this._unitOfWork.LivreRepository.Add(livre);
                    }
                    else 
                    {
                        this._unitOfWork.LivreRepository.Update(livre);
                    }
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

            var livre = await this._unitOfWork.LivreRepository.GetFirstOrDefault(l => l.Id == id);
            if (livre == null)
            {
                return NotFound();
            }

            return View(livre);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var livre = await this._unitOfWork.LivreRepository.GetFirstOrDefault(l => l.Id == id);
            if (livre.ImageUrl != null)
            {
                string oldImagePath = Path.Combine(_webHost.WebRootPath, "images/livres");
                if (System.IO.File.Exists(oldImagePath))
                    System.IO.File.Delete(oldImagePath);
            }
            this._unitOfWork.LivreRepository.DeleteOne(livre);
            await _unitOfWork.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
