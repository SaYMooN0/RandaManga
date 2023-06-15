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
        internal string[] SelectedTags { get; set; }={ };
        public Filters Filters { get; set; }= new();    
        public CatalogModel(ApplicationContext db)
        {
            this.context = db;
        }
        public void OnGet()
        {
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
            Manga souleaterManga = new Manga("���������� ���", "��� ������ �� ������� �������, ������� ����� ��������� ��� � ������ �������," +
                " ��������-���� ������ �������� � �����, ��� �������� ���������� �������� ������ � �����������. ������ �������� " +
                "��� ����� �������, ������� �������� ���������� ������ ����; ������ � ��, ��� ����� ������� ��� ������. ���� ������ ���������," +
                " ����� ������ ����� 99 ���� ���, ������� ����� �������, � 1 ���� ������, � ������ ��� ���������� ������� ����������� � ��������" +
                " ���� ������. �� ���, �� ������ ��������� � ��� �����������?", MangaType.Manga, MangaStatus.Completed, "������,�����,�������,�����������,����������,������������������,Ѹ���,�������,����,�����,������,�����,����,��� �� �����,������ �� ������,��������� ��������,�� �������,�� �������,������,�������� ���,���� ����,���������� ��������,������ / �����������,���������� / ����",
                "https://mangalib.org/soul_eater?section=info", "https://www.mangaread.org/manga/soul-eater/", @"/images/mangaCovers/souleater.jpg", "OHKUBO Atsushi", "16+", 2003);
            Manga yuukokunomoriarty = new Manga("���������� ��������", "����� ������������ ����, ���������� ������� ������ �����, � � ������ ����� ����� ��������� �������. � ��� �������� ���������� ������ ������ �������� � ������� �������, �������� ���������� ���, ������������� �� ��������� �������������, � ������� ��������� ������."
                , MangaType.Manga, MangaStatus.Completed, "��������,�����,�������,����������,Ѹ���,�������,����������,���������,����������� / ��������,�� �������,�������� ���,�������,������� / ����������,������������� ������,������� ��������,����� ��",
                "https://mangalib.me/yuukoku-no-moriarty?section=info&ui=4199976", "https://www.mangago.me/read-manga/yuukoku_no_moriarty/", @"/images/mangaCovers/yuukokunomoriarty.jpg", "Ryousuke Takeuchi", "16+", 2016);

            allMangaList = context.MangaCatalog.AsNoTracking().ToList();
            if (allMangaList.Count < 2)
            {
                context.MangaCatalog.Add(souleaterManga);
                context.MangaCatalog.Add(yuukokunomoriarty);
                context.SaveChanges();
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
                foreach(string t in manga.Tags)
                {
                    if(SelectedTags.Contains(t))
                        coincidences++;
                }
                if (coincidences == SelectedTags.Length)
                    if(manga.ReleaseYear<Filters.MaxYear&&manga.ReleaseYear>Filters.MinYear)
                        mangaListToShow.Add(manga);
            }
        }
    }
}
