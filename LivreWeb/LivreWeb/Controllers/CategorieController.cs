using LivreWeb.Data;
using Microsoft.AspNetCore.Mvc;

namespace LivreWeb.Controllers
{
    public class CategorieController : Controller
    {
        private readonly LivreContext context;

        public CategorieController(LivreContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            var cats = context.Categories.ToList();
            return View(cats);
        }
    }
}
