using LivreWeb.DataAccess.Repository.Interfaces;
using LivreWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LivreWeb.Controllers
{
    [Area("Client")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork unitOfWork;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork )
        {
            _logger = logger;
            this.unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Livre> livres = await this.unitOfWork.LivreRepository.GetAll(includes : "Categorie,CouvertureType");
            return View(livres);
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