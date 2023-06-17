using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RandaManga.Models;

namespace RandaManga.Pages
{
    public class IndexModel : PageModel
    {
        public Manga recomendstionRomance { get; private set; }
        public ApplicationContext context;
        public IndexModel(ApplicationContext db)
        {
            this.context = db;
        }
        public void OnGet()
        {
            List<Manga> allMangaList = context.MangaCatalog.AsNoTracking().ToList();
            recomendstionRomance = allMangaList.Find(m => m.Name == "ТораДора!");
        }
    }
}