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

            Manga m = new Manga("Пожиратель душ", "Для борьбы со злобным Кишином, который может ввергнуть мир в пучину безумия," +
                " Шинигами-сама создаёт Академию — место, где проходит совместное обучение Оружий и Повелителей. Первые являются " +
                "тем самым оружием, которое позволит остановить гибель мира; вторые — те, кто будет держать это оружие. Коса Смерти получится," +
                " когда оружие съест 99 злых душ, готовых стать Кишином, и 1 душу ведьмы, а потому все повелители активно соревнуются в создании" +
                " Косы Смерти. Ну что, вы готовы окунуться в мир приключений?", MangaType.Manga, MangaStatus.Completed, "Боевик,Драма,Комедия,Приключения,Психология,Сверхъестественное,Сёнэн,Фэнтези,Этти,Зомби,Демоны,Магия,Боги,Бои на мечах,Борьба за власть,Волшебные существа,ГГ женщина,ГГ мужчина,Дружба,Жестокий мир,Злые духи,Магическая академия,Навыки / способности,Волшебники / маги",
                "https://mangalib.org/soul_eater?section=info", "https://www.mangaread.org/manga/soul-eater/", @"/images/mangaCovers/souleater.jpg", "OHKUBO Atsushi", "16+", 2003);
            context.MangaCatalog.Add(m);
            context.SaveChanges();
            mangaList = context.MangaCatalog.AsNoTracking().ToList();
        }
    }
}
 