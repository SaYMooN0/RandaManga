using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RandaManga.Models;

namespace RandaManga.Pages
{
    public class CatalogModel : PageModel
    {
        
        public ApplicationContext context;
        internal List<Manga> allMangaList { get; set; } = new();
        internal List<Manga> mangaListToShow { get; set; } = new();
        public Filters Filters { get; set; } = new();
        public CatalogModel(ApplicationContext db)
        {
            this.context = db;
        }
        public void OnGet(string? tag)
        {
            
            if (tag != null)
            {
                Filters.Tags[tag] = true;
                FormListToShow();
                OnPostFiltersApplied(this.Filters);
                return;
            }
            fillContent();
            mangaListToShow = allMangaList.ToList();
        }
        public void OnPostFiltersApplied(Filters filters)
        {
            this.Filters = filters;
            fillContent();
            FormListToShow();
        }
        
        public void fillContent()
        {
            allMangaList = context.MangaCatalog.AsNoTracking().ToList();
            if (allMangaList.Count < 10)
            {
                context.FillDataBase();
                allMangaList = context.MangaCatalog.AsNoTracking().ToList();
            }
            foreach (var item in allMangaList)
            {
                foreach (string tag in item.Tags)
                {
                    if (!Filters.Tags.Keys.Contains(tag))
                        Filters.Tags.Add(tag, false);
                }
            }
            

        }
        private void FormListToShow()
        {
            int selectedTagsCount=Filters.SelectedTagsCountGet();
            int coincidences;
            foreach (Manga manga in allMangaList)
            {
                coincidences = 0;
                foreach (string t in manga.Tags)
                {
                    if (Filters.Tags[t])
                        coincidences++;
                }
                if (coincidences == selectedTagsCount)
                    if (Filters.CheckByReleaseYear(manga.ReleaseYear) &&
                        Filters.CheckByAgeRaiting(manga.AgeLimit)&&
                        Filters.CheckByType(manga.Type)&&
                        Filters.CheckByStatus(manga.Status))
                        mangaListToShow.Add(manga);
            }
        }
    }
}
