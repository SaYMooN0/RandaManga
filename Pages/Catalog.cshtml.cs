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
                "https://mangalib.org/soul_eater?section=info", "https://www.mangaread.org/manga/soul-eater/", "souleater", "OHKUBO Atsushi", AgeLimitType.Age16, 2003);
            Manga yuukokunomoriarty = new Manga("���������� ��������", "����� ������������ ����, ���������� ������� ������ �����, � � ������ ����� ����� ��������� �������. � ��� �������� ���������� ������ ������ �������� � ������� �������, �������� ���������� ���, ������������� �� ��������� �������������, � ������� ��������� ������."
                , MangaType.Manga, MangaStatus.Completed, "��������,�����,�������,����������,Ѹ���,�������,����������,���������,����������� / ��������,�� �������,�������� ���,�������,������� / ����������,������������� ������,������� ��������,����� ��",
                "https://mangalib.me/yuukoku-no-moriarty?section=info&ui=4199976", "https://www.mangago.me/read-manga/yuukoku_no_moriarty/", "yuukokunomoriarty", "Ryousuke Takeuchi", AgeLimitType.Age16, 2016);
            Manga shinseikievangelion = new Manga("����������", "������� ���������� ����� 15 ��� ����� ������� �������� �����, � ���������� �������� ������� ��������� ����� �� ���� �������, ���� ���������� �� ����� ���������. �� ���, ��� ������, ������� ��������� ���� �������� ����� ������������ ��������� �������� ��������� �������, ��������� � ���������, ������� ��������� ��������� ������. ������������ ������� �������, ��������� �� ����������, �������� ���������������� ������ � \"�����������\", ������������� � ������� ����� ����������. ������, �������� � ��� ��� ������ ���� ��������, ����� ���� 14-������ ����, ������� �������� ������� ������������ ���� ��� ������ � �������������� \"������������\", ������� ������ ����. ��� �������������� ���� ����� � ��������� � ������ �����-3, � ����� \"NERV\" � �����������, ������� ����������� ������� ������� �� ���������. � ������� ���, ���� � ������ ������ ������ ������������ ���������. �� ��� ������� ������ ������������ � ������ ��� �������� ����� ����� �� ������: ��� ����� ��������.",
                MangaType.Manga, MangaStatus.Completed, "������,�����,����,������� ����������,����������,Ѹ���,��������,�������,������,�����������,�������,�� �������,�������� ���,������ / �����������,������� / ����������,������,�������� ����,���������,������",
                "https://mangahub.ru/title/neon_genesis_evangelion_1994", "https://www.mangago.me/read-manga/neon_genesis_evangelion/", @"shinseikievangelion", "Yoshiyuki Sadamoto", AgeLimitType.Age18, 1995);
            Manga chainsawman = new Manga("�������-���������", "�� ������ ������ ���� ������� ������: ����� � ����� �������, ���� ����� � ������ �� �����, ������ �� �������� �� ����� �������� � ��������� ������ ����. �� �� ���������� �� ������� ���� � ������, ������, ���� �������!� � � ������ ������� ������ ������ �� ����� ����-���������� ������� ������������ �� ��������� ��������, ���� ��� � �������� �� �������. ������ ���� ��� ������� ���� �����, ������� ������ ������ ������ ������ ������, ����� ���� ��������� ���� ������� ������ ����������� ������. �� ��� ��� ������, ����� �� ����� ���� ����: ������ ������� ������ ��� ��������� ������� ��� �� �������? � �����, � ������ ���� ����� �� ������ �����?",
                MangaType.Manga, MangaStatus.Completed, "������,�������,���������,������������������,Ѹ���,��������,�����,�������,�����,���������,�������,�� �������,������,�������� ���,������� / ����������,������������� ������,������� ��������",
                "https://mangalib.me/chainsaw-man?section=info&ui=4199976", "https://www.mangaread.org/manga/chainsaw-man/", "chainsawman", "Tatsuki Fujimoto", AgeLimitType.Age18, 2018);
            allMangaList = context.MangaCatalog.AsNoTracking().ToList();
            if (allMangaList.Count < 4)
            {
                context.MangaCatalog.Add(souleaterManga);
                context.MangaCatalog.Add(yuukokunomoriarty);
                context.MangaCatalog.Add(shinseikievangelion);
                context.MangaCatalog.Add(chainsawman);
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
                    if(Filters.CheckByReleaseYear(manga.ReleaseYear)&&
                        Filters.CheckByAgeRaiting(manga.AgeLimit))
                        mangaListToShow.Add(manga);
            }
        }
    }
}
