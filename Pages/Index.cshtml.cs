using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RandaManga.Models;

namespace RandaManga.Pages
{
    public class IndexModel : PageModel
    {
        public List<Manga> ExpertsRecomendation{ get; set; }=new List<Manga>();
        public ApplicationContext context;
        public IndexModel(ApplicationContext db)
        {
            this.context = db;
        }
        public void OnGet()
        {
            List<Manga> allMangaList = context.MangaCatalog.AsNoTracking().ToList();
            ExpertsRecomendation.Add(allMangaList.Find(m => m.Name == "ТораДора!"));
            ExpertsRecomendation.Add(allMangaList.Find(m => m.Name == "Берсерк"));
        }
    }
}