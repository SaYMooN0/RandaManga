using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RandaManga.Models;

namespace RandaManga.Pages
{
    public class MangaPageModel : PageModel
    {
        public ApplicationContext context;
        public MangaPageModel(ApplicationContext db)
        {
            this.context = db;
        }
        public Manga MangaToShow { get; set; }
        public void OnGet()
        {
           int id = Int32.Parse(RouteData.Values["id"].ToString());
           List < Manga > mangas= context.MangaCatalog.AsNoTracking().ToList();
           MangaToShow = mangas.FirstOrDefault(m => m.Id == id);
        }
    }
}
