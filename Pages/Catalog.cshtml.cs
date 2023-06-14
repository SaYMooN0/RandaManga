using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RandaManga.Models;

namespace RandaManga.Pages
{
    public class CatalogModel : PageModel
    {
        public ApplicationContext context;
        internal List<Manga> mangaList { get; set; } = new();
        internal List<string> allTags { get; set; } = new();
        public CatalogModel(ApplicationContext db)
        {
            this.context = db;
        }
        public void OnGet()
        {
            Manga m = new Manga("���������� ���", "��� ������ �� ������� �������, ������� ����� ��������� ��� � ������ �������," +
                " ��������-���� ������ �������� � �����, ��� �������� ���������� �������� ������ � �����������. ������ �������� " +
                "��� ����� �������, ������� �������� ���������� ������ ����; ������ � ��, ��� ����� ������� ��� ������. ���� ������ ���������," +
                " ����� ������ ����� 99 ���� ���, ������� ����� �������, � 1 ���� ������, � ������ ��� ���������� ������� ����������� � ��������" +
                " ���� ������. �� ���, �� ������ ��������� � ��� �����������?", MangaType.Manga, MangaStatus.Completed, "������,�����,�������,�����������,����������,������������������,Ѹ���,�������,����,�����,������,�����,����,��� �� �����,������ �� ������,��������� ��������,�� �������,�� �������,������,�������� ���,���� ����,���������� ��������,������ / �����������,���������� / ����",
                "https://mangalib.org/soul_eater?section=info", "https://www.mangaread.org/manga/soul-eater/", @"/images/mangaCovers/souleater.jpg", "OHKUBO Atsushi", "16+", 2003);
            mangaList = context.MangaCatalog.AsNoTracking().ToList();
            if (mangaList.Count == 0)
            {
                context.MangaCatalog.Add(m);
                context.SaveChanges();
                mangaList = context.MangaCatalog.AsNoTracking().ToList();
            }
            foreach (var item in mangaList)
            {
                foreach (string tag in item.Tags)
                {
                    if (!allTags.Contains(tag))
                        allTags.Add(tag);
                }
            }
            allTags.Sort();
        }
    }
}
