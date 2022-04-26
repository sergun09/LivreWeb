using LivreWeb.DataAccess.Repository.Interfaces;
using LivreWeb.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace LivreWeb.Controllers
{
    [Area("Client")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork )
        {
            _logger = logger;
            this._unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Livre> livres = await this._unitOfWork.LivreRepository.GetAll(includes : "Categorie,CouvertureType");
            return View(livres);
        }

        public async Task<IActionResult> Details(int Livred)
        {
            if (id == null)
            {
                return NotFound();
            }

            Panier panier = new()
            {
                Livre = await this._unitOfWork.LivreRepository.GetFirstOrDefault(l => l.Id == id,
                includes: "Categorie,CouvertureType"),
                Quantite = "1",
                LivreId = Livreid,
            };

            if (panier == null)
            {
                return NotFound();
            }

            return View(panier);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Details([Bind("Id,Quantite,LivreId,UtilisateurId")]Panier panier)
        {
            // Récupération de l'id de l'utilsateur connecté
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            // Affectation de l'id au panier 
            panier.UtilisateurId = claim.Value;

                


            if (panier == null)
            {
                return NotFound();
            }

            return RedirectToRoute(nameof(Index));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}