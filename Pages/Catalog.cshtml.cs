using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RandaManga.Models;

namespace RandaManga.Pages
{
    public class CatalogModel : PageModel
    {
        public ApplicationContext context;
        internal List<Manga> mangaList { get; set; } = new();
        public CatalogModel(ApplicationContext db)
        {
            this.context = db;
        }
        public void OnGet()
        {
            mangaList = context.MangaCatalog.AsNoTracking().ToList();
            Manga m = new Manga();
            context.MangaCatalog.Add(m);

        }
    }
}