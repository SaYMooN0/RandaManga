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
        internal List<string> allTags { get; set; } = new() { };
        internal string[] SelectedTags { get; set; } = { };
        public Filters Filters { get; set; } = new();
        public CatalogModel(ApplicationContext db)
        {
            this.context = db;
        }
        public void OnGet()
        {
            Filters.MinYear = 1970;
            Filters.MaxYear = 2023;
            fillContent();
            mangaListToShow = allMangaList.ToList();
        }
        public void OnPostFiltersApplied(Filters filters)
        {
            this.Filters = filters;
            fillContent();
            FormListToShow();
        }
        public void OnPostTagApplied(string[] selectedTags)
        {
            fillContent();
            this.SelectedTags = selectedTags;
            FormListToShow();

        }
        
        public void fillContent()
        {

            allMangaList = context.MangaCatalog.AsNoTracking().ToList();
            if (allMangaList.Count < 4)
            {
                context.FillDataBase();
                allMangaList = context.MangaCatalog.AsNoTracking().ToList();
            }
            foreach (var item in allMangaList)
            {
                foreach (string tag in item.Tags)
                {
                    if (!allTags.Contains(tag))
                        allTags.Add(tag);
                }
            }
            allTags.Sort();
        }
        private void FormListToShow()
        {
            int coincidences = 0;
            foreach (Manga manga in allMangaList)
            {
                coincidences = 0;
                foreach (string t in manga.Tags)
                {
                    if (SelectedTags.Contains(t))
                        coincidences++;
                }
                if (coincidences == SelectedTags.Length)
                    if (Filters.CheckByReleaseYear(manga.ReleaseYear) &&
                        Filters.CheckByAgeRaiting(manga.AgeLimit))
                        mangaListToShow.Add(manga);
            }
        }
    }
}
